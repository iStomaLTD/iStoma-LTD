using System.Drawing;
using System.Windows.Forms;

namespace CCL.UI.ControalePersonalizate
{
    public class ToolStripPersonalizat : ToolStrip
    {
        public ToolStripPersonalizat()
        {
            this.GripStyle = ToolStripGripStyle.Hidden;
            this.BackColor = IHMStilAplicatie._SMeniuSusButonNeSelectat;// SystemColors.Control;

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            this.RenderMode = ToolStripRenderMode.Professional;
            this.Renderer = new ToolStripButtonRenderer();
        }
    }
}
