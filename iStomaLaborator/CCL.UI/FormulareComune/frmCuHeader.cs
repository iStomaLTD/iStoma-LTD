using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CCL.UI.FormulareComune
{
    [DefaultProperty("Text")]
    public partial class frmCuHeader : frmSimplu
    {

        #region Declaratii generale

        private Point lPunctMouseInitial;
        private Size lMarimeInitiala = Size.Empty;
        private Point lPunctInainteDeZoom = Point.Empty;
        private Point lLocatieInitiala = Point.Empty; //utila pentru redimensionaea ecranului
        private bool lPermiteDeplasareaEcranului = false;
        private bool lPermiteMaximizareaEcranului = false;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati

        [Browsable(true)]
        [Category("iDava")]
        [DefaultValue(false)]
        public bool PermiteDeplasareaEcranului
        {
            get { return this.lPermiteDeplasareaEcranului; }
            set { this.lPermiteDeplasareaEcranului = value; }
        }

        [Browsable(true)]
        [Category("iDava")]
        [DefaultValue(false)]
        public bool PermiteMaximizareaEcranului
        {
            get { return this.lPermiteMaximizareaEcranului; }
            set
            {
                this.lPermiteMaximizareaEcranului = value;
                base.PermiteRedimensionarea = this.lPermiteMaximizareaEcranului;
                this.lblTitluEcran.PermiteRedimensionarea = this.lPermiteMaximizareaEcranului;
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                this.lblTitluEcran.Text = value;
            }
        }

        #endregion

        #region Constructor si Initializare

        public frmCuHeader()
        {
            InitializeComponent();

            //La acest buton nu trebuie sa ajungem cu Tab-ul
            this.btnInchidereEcran.TabStop = false;

            this.lblTitluEcran.MouseDown += lblTitluEcran_MouseDown;
            this.lblTitluEcran.MouseMove += lblTitluEcran_MouseMove;
            this.lblTitluEcran.MouseUp += lblTitluEcran_MouseUp;
            this.lblTitluEcran.MouseDoubleClick += lblTitluEcran_MouseDoubleClick;
            this.BackColor = Color.White;
        }

        #endregion

        #region Evenimente

        private void btnInchidereEcran_Click(object sender, EventArgs e)
        {
            inchideEcranul(System.Windows.Forms.DialogResult.Cancel);
        }

        private void lblTitluEcran_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.lPermiteMaximizareaEcranului)
            {
                if (this.lMarimeInitiala.IsEmpty)
                {
                    this.lMarimeInitiala = this.MinimumSize;
                    this.lPunctInainteDeZoom = this.Location;
                }

                if (this.lMarimeInitiala.IsEmpty)
                    this.lMarimeInitiala = this.Size;

                if (this.Size == this.lMarimeInitiala)
                {
                    //full screen
                    Maximizeaza();
                }
                else
                {
                    this.Size = this.lMarimeInitiala;
                    //this.Location = this.lPunctInainteDeZoom;

                    Screen ecranCurent = Screen.FromControl(this); //this is the Form class

                    if (ecranCurent == null)
                        ecranCurent = Screen.PrimaryScreen;

                    System.Drawing.Point locatie = IHMUtile._ComunicareIHM.GetLocation();

                    int x = Math.Max(0, locatie.X);
                    int y = Math.Max(0, locatie.Y);

                    this.Location = new Point(x + ecranCurent.WorkingArea.Size.Width / 2 - this.Size.Width / 2, y + ecranCurent.WorkingArea.Size.Height / 2 - this.Size.Height / 2);
                    this.StartPosition = FormStartPosition.CenterScreen;
                }

                this.Invalidate();
            }
        }

        private void lblTitluEcran_MouseDown(object sender, MouseEventArgs e)
        {
            //salvam lacatia mouseului pentru a putea deplasa ecranul
            this.lPunctMouseInitial = e.Location;
            this.lLocatieInitiala = this.Location;
        }

        private void lblTitluEcran_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.lPermiteDeplasareaEcranului)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    Point noulPunct = new Point(this.Location.X - (this.lPunctMouseInitial.X - e.Location.X),
                                                this.Location.Y - (this.lPunctMouseInitial.Y - e.Location.Y));

                    //redimensionam ecranul sau il deplasam?
                    if (e.Location.X < 10 && e.Location.Y < 10)
                    {
                        if (!this.lMarimeInitiala.IsEmpty)
                        {
                            this.Width = Math.Max(100, this.lMarimeInitiala.Width + (this.lLocatieInitiala.X - noulPunct.X));
                            this.Height = Math.Max(100, this.lMarimeInitiala.Height + (this.lLocatieInitiala.Y - noulPunct.Y));
                        }
                    }

                    //In ambele cazuri deplasam ecranul

                    //simulam deplasarea ecranului
                    this.Location = noulPunct;
                    this.lPunctInainteDeZoom = this.Location;
                }
            }
        }

        void lblTitluEcran_MouseUp(object sender, MouseEventArgs e)
        {
            this.Invalidate();
        }

        #endregion

        #region Metode private

        protected void DeschidereMouseStangaJosCuDeplasare()
        {
            this.PermiteDeplasareaEcranului = true;
            this.DeschideLaPozitiaMouseului = true;
            this.StartPosition = FormStartPosition.Manual;
            this.TipDeschidere = CEnumerariComune.EnumTipDeschidere.StangaJos;

            base.SeteazaPozitia();
        }

        #endregion

        #region Metode publice

        protected void Maximizeaza()
        {
            Screen ecranCurent = Screen.FromControl(this); //this is the Form class

            if (ecranCurent == null)
                ecranCurent = Screen.PrimaryScreen;

            //System.Drawing.Size marime = IHMUtile._ComunicareIHM.GetSize();

            //this.Size = new System.Drawing.Size(marime.Width - 6, marime.Height - 6);
            //this.Location = new Point(Convert.ToInt32((marime.Width - this.Width) / 2), Convert.ToInt32((marime.Height - this.Height) / 2));

            this.Size = new System.Drawing.Size(ecranCurent.WorkingArea.Size.Width - 6, ecranCurent.WorkingArea.Size.Height - 6);
            System.Drawing.Point locatie = IHMUtile._ComunicareIHM.GetLocation();

            this.Location = new Point(Math.Max(0, locatie.X) + 3, Math.Max(0, locatie.Y) + 3); // new Point(Convert.ToInt32((ecranCurent.WorkingArea.Size.Width - this.Width) / 2), Convert.ToInt32((ecranCurent.WorkingArea.Size.Height - this.Height) / 2));
        }

        #endregion

    }
}
