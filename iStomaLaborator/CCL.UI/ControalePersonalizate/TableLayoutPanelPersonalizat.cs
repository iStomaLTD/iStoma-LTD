using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CCL.UI
{
    public class TableLayoutPanelPersonalizat : TableLayoutPanel
    {
        #region Declaratii generale

        private Color lCuloareLinieAlternanta = Color.LightGray;
        private bool lGestioneazaAlternanta = true;

        #endregion

        #region Proprietati

        [Description("Culoarea de fundal a liniilor alternante; Se foloseste in tandem cu proprietatea <GestioneazaAlternantaLiniilor>")]
        [Category("iDava")]
        [Browsable(true)]
        public Color CuloareLinieAlternanta
        {
            get { return this.lCuloareLinieAlternanta; }
            set { this.lCuloareLinieAlternanta = value; }
        }

        [Description("Permite gestionarea alternantei liniilor; Se foloseste in tandem cu proprietatea <CuloareLinieAlternanta>")]
        [Category("iDava")]
        [Browsable(true)]
        [DefaultValue(true)]
        public bool GestioneazaAlternantaLiniilor
        {
            get { return this.lGestioneazaAlternanta; }
            set { this.lGestioneazaAlternanta = value; }
        }

        #endregion

        #region Constructori

        public TableLayoutPanelPersonalizat()
        {
            SeteazaDoubleBuffer();
        }

        public TableLayoutPanelPersonalizat(IContainer container)
            : this()
        {
            container.Add(this);
        }

        private void SeteazaDoubleBuffer()
        {
            // this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        #endregion

        #region Evenimente suprascrise

        protected override void OnCellPaint(TableLayoutCellPaintEventArgs e)
        {
            if (this.lGestioneazaAlternanta)
            {
                if (e.Row % 2 == 0)
                    e.Graphics.FillRectangle(new SolidBrush(this.lCuloareLinieAlternanta), e.CellBounds);
                else
                    e.Graphics.FillRectangle(new SolidBrush(this.BackColor), e.CellBounds);
            }

            base.OnCellPaint(e);
        }

        #endregion

    }
}
