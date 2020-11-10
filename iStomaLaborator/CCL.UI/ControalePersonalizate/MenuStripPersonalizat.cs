using System.ComponentModel;
using System.Windows.Forms;

namespace CCL.UI
{
    public class MenuStripPersonalizat : MenuStrip
    {
        public MenuStripPersonalizat()
        {
            SeteazaDoubleBuffer();
        }

        public MenuStripPersonalizat(IContainer container)
            : this()
        {
            container.Add(this);
        }

        private void SeteazaDoubleBuffer()
        {
            // this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.BackColor = System.Drawing.Color.White;
            this.ForeColor = System.Drawing.Color.Black;
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }
    }
}
