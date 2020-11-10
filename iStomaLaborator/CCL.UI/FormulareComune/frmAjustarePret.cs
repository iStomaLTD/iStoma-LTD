using CCL.iStomaLab;
using ILL.iStomaLab;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CCL.UI.FormulareComune
{
    public partial class frmAjustarePret : frmCuHeader
    {

        #region Declaratii generale

        private double lPretVechi = 0;
        private double lPretActual = 0;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private frmAjustarePret(double pPretVechi, double pPretActual)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lPretVechi = pPretVechi;
            this.lPretActual = pPretActual;

            this.PermiteDeplasareaEcranului = true;
            this.PermiteMaximizareaEcranului = false;
            this.PermiteRedimensionarea = false;
            this.Text = string.Empty;
            this.AcceptButton = this.ctrlValidareAnulare.ButonValidare;

            this.StartPosition = FormStartPosition.CenterScreen;

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                adaugaHandlere();
                initTextML();
            }
        }

        private void adaugaHandlere()
        {
        }

        private void initTextML()
        {
            this.lblValoareVeche.Text = CUtil.getText(1592);
            this.lblAjustare.Text = CUtil.getText(1650);
            this.lblValoare.Text = CUtil.getText(2301);
        }

        private void frmAjustarePret_Load(object sender, EventArgs e)
        {
            try
            {
                Initializeaza();
            }
            catch (Exception ex)
            {
                Mesaj.Eroare(this, ex.Message);
            }
        }

        public void Initializeaza()
        {
            incepeIncarcarea();

            this.lblValoareVeche.Text = CUtil.GetValoareMonetara(this.lPretVechi);

            if (this.lPretVechi != 0)
                this.txtAjustare.Text = Convert.ToString(Math.Round((this.lPretActual * 100) / this.lPretVechi, 2) - 100);
            else
                this.txtAjustare.Goleste();

            this.txtPret.Text = Convert.ToString(this.lPretActual);

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void txtAjustare_KeyUpPersonalizat(object sender, KeyEventArgs e)
        {
            try
            {
                //Actualizam pretul
                this.txtPret.Text = Convert.ToString(Math.Round(this.lPretVechi + (this.lPretVechi * this.txtAjustare.ValoareDouble) / 100, 2));
            }
            catch (Exception ex)
            {
                Mesaj.Eroare(this, ex.Message);
            }
        }

        private void txtPret_KeyUpPersonalizat(object sender, KeyEventArgs e)
        {
            try
            {
                //Actualizam ajustarea
                if (this.lPretVechi != 0)
                    this.txtAjustare.Text = Convert.ToString(Math.Round((this.txtPret.ValoareDouble * 100) / this.lPretVechi, 2) - 100);
                else
                    this.txtAjustare.Goleste();
            }
            catch (Exception ex)
            {
                Mesaj.Eroare(this, ex.Message);
            }
        }

        private void ctrlValidareAnulare_Validare(object sender, EventArgs e)
        {
            try
            {
                inchideEcranul(System.Windows.Forms.DialogResult.OK);
            }
            catch (Exception ex)
            {
                Mesaj.Eroare(this, ex.Message);
            }
        }

        private void ctrlValidareAnulare_Anulare(object sender, EventArgs e)
        {
            try
            {
                inchideEcranul(System.Windows.Forms.DialogResult.Cancel);
            }
            catch (Exception ex)
            {
                Mesaj.Eroare(this, ex.Message);
            }
        }

        #endregion

        #region Metode private



        #endregion

        #region Metode publice

        public static double GetPretAjustat(Form pEcranParinte, double pPretVechi, double pPretActual)
        {
            using (frmAjustarePret ecran = new frmAjustarePret(pPretVechi, pPretActual))
            {
                ecran.BackColor = Color.White;
                ecran.txtPret.BackColor = Color.White;
                ecran.txtAjustare.BackColor = Color.White;
                ecran.ctrlValidareAnulare.BackColor = Color.White;

                if (CCL.UI.IHMUtile.DeschideEcran(pEcranParinte, ecran))
                    return ecran.txtPret.ValoareDouble;

                return pPretActual;
            }
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
        }

        #endregion

    }
}
