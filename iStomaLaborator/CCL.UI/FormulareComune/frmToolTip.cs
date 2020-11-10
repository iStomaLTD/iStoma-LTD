using System;
using System.Drawing;
using System.Windows.Forms;

namespace CCL.UI.FormulareComune
{
    /// <summary>
    /// ToolTip-ul pe care il folosim pentru afisarea mesajelor in aplicatie (la controalele unde se doreste acest lucru)
    /// </summary>
    public partial class frmToolTip : frmSimplu
    {
        private static frmToolTip _instanta = null;
        private ToolTipIcon lIconita;
        private string lTitlu;
        private string lMesaj;
        private bool lAfisat;
        private Font FONT_TOOLTIP;
        private Font FONT_TITLU_TOOLTIP;
        private RectangleF lDreptunghiImagine = RectangleF.Empty;
        private RectangleF lDreptunghiTitlu = RectangleF.Empty;
        private RectangleF lDreptunghiMesaj = RectangleF.Empty;
        private const int LATIME_MAXIMA = 500;

        public static frmToolTip Instanta
        {
            get
            {
                if (_instanta == null)
                    _instanta = new frmToolTip();
                return _instanta;
            }
        }

        private frmToolTip()
        {
            InitializeComponent();
            this.TopMost = true;
            this.FONT_TOOLTIP = new Font("Arial", 10);
            this.FONT_TITLU_TOOLTIP = new Font(this.FONT_TOOLTIP, FontStyle.Bold);
        }

        public void Afiseaza(ToolTipIcon pIconita, string pTitlu, string pMesaj)
        {
            this.lIconita = pIconita;
            this.lTitlu = pTitlu;
            this.lMesaj = pMesaj;
            this.lAfisat = false;

            setMarimeSiPozitie();
            this.tToolTip.Start();
        }

        public void Ascunde()
        {
            this.tToolTip.Stop();
            this.Hide();
            this.lAfisat = false;
        }

        public static void Distruge()
        {
            if (_instanta != null)
                _instanta.Dispose();

            _instanta = null;
        }

        public new void Dispose()
        {
            this.FONT_TITLU_TOOLTIP.Dispose();
            this.FONT_TOOLTIP.Dispose();

            this.FONT_TITLU_TOOLTIP = null;
            this.FONT_TOOLTIP = null;

            base.Dispose();
        }

        private void setMarimeSiPozitie()
        {
            using (Graphics g = this.CreateGraphics())
            {
                SizeF marimeTitlu = g.MeasureString(this.lTitlu, this.FONT_TITLU_TOOLTIP);
                if (marimeTitlu.Width > LATIME_MAXIMA)
                    marimeTitlu = g.MeasureString(this.lTitlu, this.FONT_TITLU_TOOLTIP, LATIME_MAXIMA);

                SizeF marimeContinut = g.MeasureString(this.lMesaj, this.FONT_TOOLTIP);
                if (marimeContinut.Width > LATIME_MAXIMA)
                    marimeContinut = g.MeasureString(this.lMesaj, this.FONT_TOOLTIP, LATIME_MAXIMA);

                float marimeImagine = 16f;
                float distantaZone = 3f;

                float latime = marimeImagine + marimeTitlu.Width;
                latime = 3 * distantaZone + Math.Max(latime, marimeContinut.Width - marimeImagine) + 10; //marja 10px

                float lungime = 5 * distantaZone + marimeImagine + Math.Max(0, marimeTitlu.Height - marimeImagine) + marimeContinut.Height;

                this.lDreptunghiImagine = new RectangleF(distantaZone, distantaZone, marimeImagine, marimeImagine);
                this.lDreptunghiTitlu = new RectangleF(2 * distantaZone + marimeImagine,
                                                        distantaZone,// + Math.Max(0, marimeTitlu.Height - marimeImagine) / 2,
                                                        marimeTitlu.Width,
                                                        marimeTitlu.Height);
                this.lDreptunghiMesaj = new RectangleF(distantaZone,
                                                        4 * distantaZone + marimeImagine + Math.Max(0, marimeTitlu.Height - marimeImagine),
                                                        marimeContinut.Width,
                                                        marimeContinut.Height);

                this.Size = new Size((int)Math.Round(latime, 0), (int)Math.Round(lungime, 0));
            }

            IHMUtile.StabilesteLocatia(this, null, true, CEnumerariComune.EnumTipDeschidere.StangaJos,true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle chenar = this.ClientRectangle;
            g.FillRectangle(Brushes.Cornsilk, chenar);
            g.DrawRectangle(IHMUtile.PENSULA_CHENAR, new Rectangle(chenar.X, chenar.Y, chenar.Width - 1, chenar.Height - 1));

            g.DrawImage(Imagini.getImagineSemnalizare(this.lIconita), this.lDreptunghiImagine);

            g.DrawString(this.lTitlu, FONT_TITLU_TOOLTIP, Brushes.Black, this.lDreptunghiTitlu);
            g.DrawString(this.lMesaj, FONT_TOOLTIP, Brushes.Black, this.lDreptunghiMesaj);
        }

        private void tToolTip_Tick(object sender, EventArgs e)
        {
            if (!this.lAfisat)
            {
                this.lAfisat = true;
                this.Show();
            }

            if (this.tToolTip.Interval == 5000)
                Ascunde();
        }
    }
}
