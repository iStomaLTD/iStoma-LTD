using System;
using System.ComponentModel;
using System.Drawing;

namespace CCL.UI.ControaleSpecializate
{
    public class LabelClickable : LabelPersonalizat
    {
        public Color lCuloareFundal = Color.White;

        public LabelClickable(IContainer container)
            : this()
        {
            container.Add(this);
        }

        public LabelClickable()
        {
            this.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.BackColor = Color.LightGray;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.BackColor = this.lCuloareFundal;
        }
    }
}
