using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStomaLab.Caramizi
{
    internal class PanelOptiuniMeniuStanga : CCL.UI.FlowLayoutPanelPersonalizat
    {
        private bool lEsteDisponibil = true;

        public PanelOptiuniMeniuStanga() : base()
        {
            initProprietatiStandard();
        }

        private void initProprietatiStandard()
        {
            this.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.Size = new System.Drawing.Size(151, 100);
            this.BackColor = System.Drawing.Color.White;
            this.Visible = false;
        }

        internal void SetDisponibilitate(bool pVizibil)
        {
            this.lEsteDisponibil = pVizibil;
            //this.Visible = pVizibil;
        }

        internal bool EsteDisponibil()
        {
            return this.lEsteDisponibil;
        }
    }
}
