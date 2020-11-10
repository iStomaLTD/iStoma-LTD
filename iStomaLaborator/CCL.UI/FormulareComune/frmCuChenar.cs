using System;
using System.Drawing;
using System.Windows.Forms;

namespace CCL.UI.FormulareComune
{
    public partial class frmCuChenar : frmCuHeader
    {
        //protected bool lSeIncarca = false;
        protected bool lEcranInModificare = true;

        public frmCuChenar()
        {
            incepeIncarcarea();

            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.PermiteDeplasareaEcranului = true;
            this.PermiteMaximizareaEcranului = false;
            this.PermiteRedimensionarea = false;
        }

        protected void initPaletaCulori()
        {
            this.BackColor = Color.Silver;
            this.panelContainer.BackColor = Color.White;
        }

        protected void incepeIncarcarea()
        {
            this.lSeIncarca = true;
        }

        protected void finalizeazaIncarcarea()
        {
            this.lSeIncarca = false;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.panelContainer.Width = this.Width - this.panelContainer.Location.X - 1;
            this.panelContainer.Height = this.Height - this.panelContainer.Location.Y - 1;
        }
    }
}
