using System.ComponentModel;
using System.Windows.Forms;
using ILL.iStomaLab;

namespace CCL.UI
{
    public class RadioButtonPersonalizat : System.Windows.Forms.RadioButton, IAllowModification
    {
        private bool lEcranInModificare = true;

        public RadioButtonPersonalizat()
        {
            SeteazaDoubleBuffer();
        }

        public RadioButtonPersonalizat(IContainer container)
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

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
            this.Enabled = this.lEcranInModificare;
        }
    }
}
