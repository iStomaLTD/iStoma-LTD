using System.Drawing;
using System.Windows.Forms;

namespace CCL.UI.ControaleSpecializate
{
    public class PanelImagineCuTransparenta : PanelPersonalizat
    {
        Graphics graphics = null;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT

                return cp;
            }
        }

        public Image Imagine { get; set; }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Don't paint background
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Update the private member so we can use it in the OnDraw method
            this.graphics = e.Graphics;

            // Set the best settings possible (quality-wise)
            this.graphics.TextRenderingHint =
                System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.graphics.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            this.graphics.PixelOffsetMode =
                System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.graphics.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            // Calls the OnDraw subclass method
            OnDraw();
        }

        protected void OnDraw()
        {
            // Desenam imaginea
            if (this.Imagine != null)
                this.graphics.DrawImage(this.Imagine, new Point(0, 0));
        }
    }
}
