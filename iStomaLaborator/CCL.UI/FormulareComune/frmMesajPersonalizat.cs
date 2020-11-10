using System;
using System.Drawing;
using System.Windows.Forms;


namespace CCL.UI.FormulareComune
{
    public partial class frmMesajPersonalizat : frmCuHeader
    {

        #region Declaratii generale

        private static string _OK = "OK";
        private static string _Anuleaza = "Anuleaza";
        private static string _Da = "Da";
        private static string _Nu = "Nu";

        #endregion

        #region Enumerari si Structuri

        public enum EnumTipButon
        {
            Da = 1,
            Nu = 2,
            Anuleaza = 3,
            OK = 4
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public static void InitializeazaLimba(string pOK, string pAnuleaza, string pDa, string pNu)
        {
            _OK = pOK;
            _Anuleaza = pAnuleaza;
            _Da = pDa;
            _Nu = pNu;
        }

        public frmMesajPersonalizat(string psMesaj, string ptitlu, Mesaj.EnumButoane pButoane, Mesaj.EnumIcoana pIcoana) :
            this(psMesaj, ptitlu, pButoane, pIcoana, EnumTipButon.Da, CEnumerariComune.EnumTipDeschidere.DreaptaSus)
        {
        }

        public frmMesajPersonalizat(string psMesaj, string ptitlu, Mesaj.EnumButoane pButoane, Mesaj.EnumIcoana pIcoana, EnumTipButon pButonEnter,
            CCL.UI.CEnumerariComune.EnumTipDeschidere pTipDeschidere)
        {
            InitializeComponent();

            this.btnCancel.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnOK.ImageAlign = ContentAlignment.MiddleLeft;

            this.PermiteRedimensionarea = false;
            this.PermiteMaximizareaEcranului = false;
            this.PermiteDeplasareaEcranului = true;
            this.TipDeschidere = pTipDeschidere;
            this.Text = ptitlu;
            this.lblMesaj.Text = psMesaj;
            this.BackColor = Color.White;
            this.txtMesaj.Visible = false;

            using (Graphics g = this.lblMesaj.CreateGraphics())
            {
                SizeF marime = g.MeasureString(psMesaj, this.lblMesaj.Font, this.lblMesaj.Width);

                if (marime.Height > this.lblMesaj.Height)
                {
                    Screen ecranCurent = Screen.FromControl(this); //this is the Form class

                    if (ecranCurent == null)
                        ecranCurent = Screen.PrimaryScreen;

                    if (ecranCurent.WorkingArea.Height < this.Height + Convert.ToInt32(Math.Floor(marime.Height - this.lblMesaj.Height)) + 15)
                    {
                        this.Height = Math.Min(ecranCurent.WorkingArea.Height, this.Height + Convert.ToInt32(Math.Floor(marime.Height - this.lblMesaj.Height)) + 15);

                        this.lblMesaj.Visible = false;
                        this.txtMesaj.Visible = true;
                        this.txtMesaj.Text = psMesaj;
                    }
                    else
                    {
                        this.Height = Math.Min(ecranCurent.WorkingArea.Height, this.Height + Convert.ToInt32(Math.Floor(marime.Height - this.lblMesaj.Height)) + 15);
                    }
                }
            }

            this.SeteazaPozitia();

            bool ButonOKVizibil = true;
            bool ButonCancelVizibil = true;

            switch (pButoane)
            {
                case Mesaj.EnumButoane.OK:
                    this.btnOK.Text = _OK;
                    this.btnOK.TipButon = ButtonPersonalizat.EnumTipButon.Validare;
                    this.btnOK.Tag = DialogResult.OK;
                    ButonCancelVizibil = false;
                    this.AcceptButton = this.btnOK;
                    break;
                case Mesaj.EnumButoane.Anuleaza:
                    this.btnCancel.Text = _Anuleaza;
                    this.btnCancel.Tag = DialogResult.Cancel;
                    this.btnCancel.TipButon = ButtonPersonalizat.EnumTipButon.Anulare;
                    ButonOKVizibil = false;
                    this.AcceptButton = this.btnCancel;
                    break;
                case Mesaj.EnumButoane.OkAnuleaza:
                    this.btnOK.Text = _OK;
                    this.btnOK.Tag = DialogResult.OK;
                    this.btnOK.TipButon = ButtonPersonalizat.EnumTipButon.Validare;
                    this.btnCancel.Text = _Anuleaza;
                    this.btnCancel.Tag = DialogResult.Cancel;
                    this.btnCancel.TipButon = ButtonPersonalizat.EnumTipButon.Anulare;
                    if (pButonEnter == EnumTipButon.Anuleaza)
                        this.AcceptButton = this.btnCancel;
                    else
                        this.AcceptButton = this.btnOK;
                    break;
                case Mesaj.EnumButoane.DaNu:
                    this.btnOK.Text = _Da;
                    this.btnOK.Tag = DialogResult.Yes;
                    this.btnOK.TipButon = ButtonPersonalizat.EnumTipButon.Validare;
                    this.btnCancel.Text = _Nu;
                    this.btnCancel.Tag = DialogResult.No;
                    this.btnCancel.TipButon = ButtonPersonalizat.EnumTipButon.Anulare;
                    if (pButonEnter == EnumTipButon.Nu)
                        this.AcceptButton = this.btnCancel;
                    else
                        this.AcceptButton = this.btnOK;
                    break;
                default:
                    break;
            }

            //Modificam vizibilitatea butoanelor
            this.btnOK.Visible = ButonOKVizibil;
            this.btnCancel.Visible = ButonCancelVizibil;

            //Modificam pozitia butoanelor
            if (ButonOKVizibil && ButonCancelVizibil)
            {
                this.btnOK.Location = new Point(this.Width / 2 - this.btnOK.Width - 1, this.btnOK.Location.Y);
                this.btnCancel.Location = new Point(this.Width / 2 + 1, this.btnCancel.Location.Y);
            }
            else
                if (ButonOKVizibil)
                this.btnOK.Location = new Point(this.Width / 2 - this.btnOK.Width / 2, this.btnOK.Location.Y);
            else
                this.btnCancel.Location = new Point(this.Width / 2 - this.btnCancel.Width / 2, this.btnCancel.Location.Y);
        }

        private void frmMesajPersonalizat_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Evenimente

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = (DialogResult)btnOK.Tag;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = (DialogResult)btnCancel.Tag; ;
        }

        #endregion

        #region Metode private



        #endregion

        #region Metode publice



        #endregion

        #region IControlDava Members

        public void AllowModification(bool bPermiteModificarea)
        {
        }

        #endregion

    }
}
