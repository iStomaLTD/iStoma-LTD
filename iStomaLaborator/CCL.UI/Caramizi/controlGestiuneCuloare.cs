using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ILL.iStomaLab;

namespace CCL.UI.Caramizi
{
    [DefaultEvent("CuloareSchimbata")]
    public partial class controlGestiuneCuloare : PanelContainerCCL, IAllowModification
    {

        #region Declaratii generale

        private int lARGBCuloare = 0;
        public event CuloareSchimbataHandler CuloareSchimbata;
        public delegate void CuloareSchimbataHandler(Control pControl, int pARGBCuloareNoua);
        private Color lCuloareSelectata = Color.Red;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati

        public Color CuloareSelectata { get { return this.lCuloareSelectata; } }

        public int CuloareARGB
        {
            get { return this.lARGBCuloare; }
        }

        #endregion

        #region Constructor si Initializare

        public controlGestiuneCuloare()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Click += ControlGestiuneCuloare_Click;
        }

        public void Initializeaza(Color pCuloare)
        {
            Initializeaza(pCuloare.ToArgb());
        }

        public void Initializeaza(int pARGBCuloare)
        {
            base.InitializeazaVariabileleGenerale();
            this.lARGBCuloare = pARGBCuloare;
            this.lCuloareSelectata = Imagini.getColorFromARGB(this.lARGBCuloare);

            incepeIncarcarea();

            this.Refresh();

            finalizeazaIncarcarea();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            this.BackColor = this.lCuloareSelectata;
            base.OnPaintBackground(e);
        }

        #endregion

        #region Evenimente

        private void ControlGestiuneCuloare_Click(object sender, EventArgs e)
        {
            if (!this.lEcranInModificare) return;

            try
            {
                CautaCuloare(false);
            }
            catch (Exception ex)
            {
                Mesaj.Eroare(this.GetFormParinte(), ex.Message, string.Empty);
            }
        }

        private void btnSchimbaCuloare_Click(object sender, EventArgs e)
        {
            try
            {
                CautaCuloare(false);
            }
            catch (Exception ex)
            {
                Mesaj.Eroare(this.GetFormParinte(), ex.Message, string.Empty);
            }
        }

        #endregion

        #region Metode private

        private void anuntaSchimbareaCulorii()
        {
            if (CuloareSchimbata != null)
                CuloareSchimbata(this, this.CuloareARGB);
        }

        #endregion

        #region Metode publice

        /// <summary>
        /// Cautam o noua culoare
        /// </summary>
        /// <param name="pDoarDacaNuExistaCuloare">False pentru a forta cautarea</param>
        public void CautaCuloare(bool pDoarDacaNuExistaCuloare)
        {
            if (pDoarDacaNuExistaCuloare && this.lARGBCuloare != 0) return;

            Color culoare = Imagini.getCuloare(this.GetFormParinte(), this.BackColor);
            if (!culoare.IsEmpty)
            {
                this.lCuloareSelectata = culoare;
                this.lARGBCuloare = CCL.UI.Imagini.getARGBFromColor(this.lCuloareSelectata);
                this.BackColor = this.lCuloareSelectata;

                //Anuntam schimbarea culorii
                anuntaSchimbareaCulorii();
            }
        }

        public void Goleste()
        {
            this.lARGBCuloare = 0;
            if (this.Parent != null)
                this.BackColor = this.Parent.BackColor;
            else
                this.BackColor = Color.Transparent;
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
            this.btnSchimbaCuloare.Visible = pPermiteModificarea;
        }

        #endregion

    }
}
