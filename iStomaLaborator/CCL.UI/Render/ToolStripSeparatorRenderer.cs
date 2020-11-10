using System;
using System.Drawing;
using System.Windows.Forms;

namespace CCL.UI.Render
{
    public class ToolStripSeparatorRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            if (!e.Vertical || (e.Item as ToolStripSeparator) == null)
                base.OnRenderSeparator(e);
            else
            {
                Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);
                bounds.Y += 3;
                bounds.Height = Math.Max(0, bounds.Height - 6);
                if (bounds.Height >= 4) bounds.Inflate(0, -2);
                Pen pen = new Pen(Color.DarkBlue);
                int x = bounds.Width / 2;
                e.Graphics.DrawLine(pen, x, bounds.Top, x, bounds.Bottom - 1);
                pen.Dispose();
                pen = new Pen(Color.Blue);
                e.Graphics.DrawLine(pen, x + 1, bounds.Top + 1, x + 1, bounds.Bottom);
                pen.Dispose();
                pen = null;
            }
        }
    }
}
