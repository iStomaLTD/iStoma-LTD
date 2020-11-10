using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCL.UI.ControaleSpecializate
{
    public class PanelOptiuni : PanelPersonalizat
    {
        public PanelOptiuni() : base()
        {
            this.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Name = "panelOptiuni";
            this.Visible = false;
        }

        public void Initializeaza()
        {
            CCL.UI.IHMUtile.SeteazaProprietatiPanelOptiuni(this);
        }
    }
}
