using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CCL.UI.ControaleSpecializate
{
    public class ButonOptiunePanelOptiuni : Button
    {
        public ButonOptiunePanelOptiuni() : base()
        {
            this.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
           | System.Windows.Forms.AnchorStyles.Right)));
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.FlatAppearance.BorderSize = 0;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UseVisualStyleBackColor = false;
        }

        public void Initializeaza()
        {
            Initializeaza(this.Text);
        }

        public void Initializeaza(string pText)
        {
            CCL.UI.IHMUtile.SeteazaProprietatiButonOptiuni(this);
            this.Text = pText;
        }
    }
}
