using System.ComponentModel;
using System.Windows.Forms;

namespace CCL.UI
{
    public class RichTextBoxPersonalizat : RichTextBox
    {
        public RichTextBoxPersonalizat()
        {
            SeteazaDoubleBuffer();
        }

        public RichTextBoxPersonalizat(IContainer container)
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
    }
}
