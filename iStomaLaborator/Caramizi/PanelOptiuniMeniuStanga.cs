using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStomaLab.Caramizi
{
    internal class PanelOptiuniMeniuStanga : CCL.UI.FlowLayoutPanelPersonalizat
    {
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
    }
}
