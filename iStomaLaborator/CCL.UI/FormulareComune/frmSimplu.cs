using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CCL.UI.FormulareComune
{
    public partial class frmSimplu : Form
    {

        #region Declaratii generale

        private Color lCuloareInchisa = Color.Gray;
        private Color lCuloareDeschisa = Color.LightGray;
        private bool lDeschideLaPozitiaMouseului = true;
        private CCL.UI.CEnumerariComune.EnumTipDeschidere lTipDeschidere = CEnumerariComune.EnumTipDeschidere.StangaJos;
        private Point lPunctMouse = Point.Empty;
        protected bool lSeIncarca = true;

        #endregion

        #region Enumerari si Structuri

        #endregion

        #region Proprietati

        public bool PermiteRedimensionarea { get; protected set; }

        [Browsable(true)]
        [DefaultValue(true)]
        [DisplayName("DeschideLaPozitiaMouseului")]
        [Category("iDava")]
        public bool DeschideLaPozitiaMouseului
        {
            get { return this.lDeschideLaPozitiaMouseului; }
            set { this.lDeschideLaPozitiaMouseului = value; }
        }

        [Browsable(true)]
        [DefaultValue(CEnumerariComune.EnumTipDeschidere.StangaJos)]
        [DisplayName("TipDeschidere")]
        [Category("iDava")]
        public CCL.UI.CEnumerariComune.EnumTipDeschidere TipDeschidere
        {
            get { return this.lTipDeschidere; }
            set { this.lTipDeschidere = value; }
        }

        #endregion

        #region Constructor si Initializare

        public frmSimplu()
            : base()
        {
            incepeIncarcarea();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
        }

        #endregion

        #region Evenimente

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Rectangle newRect = new Rectangle(ClientRectangle.X, ClientRectangle.Y,
            ClientRectangle.Width, ClientRectangle.Height);

            SizeF textSize = g.MeasureString(this.Text, base.Font);
            int textX = (int)(base.Size.Width / 2) - (int)(textSize.Width / 2);
            int textY = (int)(base.Size.Height / 2) - (int)(textSize.Height / 2);

            g.SmoothingMode = SmoothingMode.HighQuality;

            //using (Brush Pensula = new LinearGradientBrush(newRect, this.lCuloareInchisa, this.lCuloareDeschisa, LinearGradientMode.Vertical))
            //{
            //    g.FillRectangle(Pensula, newRect);
            //}

            using (Brush pensulaFundal = new SolidBrush(this.BackColor))
            {
                g.FillRectangle(pensulaFundal, newRect);
            }

            g.DrawRectangle(Pens.Black, newRect.X, newRect.Y, newRect.Width - 1, newRect.Height - 1);

            if (this.PermiteRedimensionarea)
            {
                //Desenam zona de redimensionare a ecranului
                g.DrawLine(Pens.Black, newRect.X + newRect.Width - 1, newRect.Y + newRect.Height - 1, newRect.X + newRect.Width - 12, newRect.Y + newRect.Height - 1);
                g.DrawLine(Pens.Black, newRect.X + newRect.Width - 1, newRect.Y + newRect.Height - 1, newRect.X + newRect.Width - 1, newRect.Y + newRect.Height - 12);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            //Marim sau ne pozitionam

            //Daca suntem in zona de redimensionare semnalizam acest lucru
            if (e.Location.X > this.Width - 10 && e.Location.Y > this.Height - 10)
            {
                if (this.PermiteRedimensionarea)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //E de bun simt marimea minima de 50px
                        this.Width = Math.Max(50, e.Location.X);
                        this.Height = Math.Max(50, e.Location.Y);

                        this.Refresh();
                    }
                    else
                    {
                        this.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
                    }
                }
            }
            else
                this.Cursor = System.Windows.Forms.Cursors.Default;

            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Default;
            base.OnMouseLeave(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            //Salvam pozitia mouse-ului pentru a putea determina cu cat marim ecranul
            this.lPunctMouse = e.Location;
            base.OnMouseClick(e);
        }

        #endregion

        #region Metode private

        protected Form GetFormParinte()
        {
            return this;
        }

        protected void DeschidereMouseStangaJos()
        {
            this.DeschideLaPozitiaMouseului = true;
            this.StartPosition = FormStartPosition.Manual;
            this.TipDeschidere = CEnumerariComune.EnumTipDeschidere.StangaJos;

            SeteazaPozitia();
        }

        protected void incepeIncarcarea()
        {
            this.lSeIncarca = true;
        }

        protected void finalizeazaIncarcarea()
        {
            this.lSeIncarca = false;
        }

        protected void inchideEcranulOK()
        {
            inchideEcranul(DialogResult.OK);
        }

        protected void inchideEcranulCancel()
        {
            inchideEcranul(DialogResult.Cancel);
        }

        protected void inchideEcranul(DialogResult pRaspuns)
        {
            this.DialogResult = pRaspuns;
            this.Close();
        }

        #endregion

        #region Metode publice

        public void SeteazaPozitia()
        {
            IHMUtile.StabilesteLocatia(this, null, this.lDeschideLaPozitiaMouseului, this.lTipDeschidere, true);
        }

        #endregion

    }
}
