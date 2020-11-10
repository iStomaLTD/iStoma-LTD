using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.UI.ControaleSpecializate
{
    public class ButonMaiMulte : ButtonPersonalizat
    {
        private PanelPersonalizat lPanelAsociat = null;

        public ButonMaiMulte() : base()
        {
            this.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Location = new System.Drawing.Point(692, 2);
            this.Name = "btnOptiuni";
            this.Size = new System.Drawing.Size(29, 23);
            this.Text = string.Empty;
            this.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.MaiMulte;
            this.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
        }

        public void Initializeaza(PanelPersonalizat pPanelAsociat)
        {
            this.lPanelAsociat = pPanelAsociat;
            this.lPanelAsociat.Visible = false;
        }

        protected override void OnClick(EventArgs e)
        {
            if (this.lPanelAsociat != null)
            {
                this.lPanelAsociat.Visible = !this.lPanelAsociat.Visible;
                this.lPanelAsociat.BringToFront();
            }

            base.OnClick(e);
        }
    }
}
