using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CCL.UI.ControaleSpecializate
{
    public class ButonInchidePanelOptiuni : Button
    {
        private PanelPersonalizat lPanelAsociat = null;

        public ButonInchidePanelOptiuni() : base()
        {
            this.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.FlatAppearance.BorderSize = 0;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "btnInchidePanelOptiuni";
            this.Size = new System.Drawing.Size(35, 25);
            this.TabIndex = 13;
            this.TabStop = false;
            this.Text = "X";
        }

        public void Initializeaza(PanelPersonalizat pPanelAsociat)
        {
            this.lPanelAsociat = pPanelAsociat;
            CCL.UI.IHMUtile.SeteazaProprietatiButonInchiderePanelOptiuni(this);
        }

        protected override void OnClick(EventArgs e)
        {
            if (this.lPanelAsociat != null)
            {
                this.lPanelAsociat.Visible = false;
            }

            base.OnClick(e);
        }
    }
}
