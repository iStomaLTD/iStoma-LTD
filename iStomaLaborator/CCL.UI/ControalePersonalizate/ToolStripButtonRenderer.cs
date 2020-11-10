using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCL.UI.ControalePersonalizate
{

    /// <summary>
    /// Pentru a putea da o culoare de fond unui buton din meniul de optiuni
    /// </summary>
    public class ToolStripButtonRenderer : ToolStripProfessionalRenderer
    {
        public ToolStripButtonRenderer()
        {
            this.RoundedEdges = false;
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            Rectangle bounds = new Rectangle(Point.Empty, e.ToolStrip.Size);
            using (Brush butonNeselectat = new SolidBrush(IHMStilAplicatie._SMeniuSusBaraOptiuniFundal))
            {
                e.Graphics.FillRectangle(butonNeselectat, e.AffectedBounds);
                e.Graphics.FillRectangle(butonNeselectat, e.ConnectedArea);
            }
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            //Chenarul barei de optiuni are culoarea butonului selectat
            using (Pen butonNeselectat = new Pen(IHMStilAplicatie._SMeniuSusButonSelectat))
            {
                e.Graphics.DrawRectangle(butonNeselectat, new Rectangle(e.AffectedBounds.X, e.AffectedBounds.Y, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1));
            }
        }

        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            using (Brush butonNeselectat = new SolidBrush(IHMStilAplicatie._SMeniuSusBaraOptiuniFundal))
            {
                e.Graphics.FillRectangle(butonNeselectat, e.AffectedBounds);
            }
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            var btn = e.Item as ToolStripSeparator;
            if (btn != null)
            {
                using (Pen butonNeselectat = new Pen(IHMStilAplicatie._SMeniuSusButonSelectat))
                {
                    if (e.Vertical)
                        e.Graphics.DrawLine(butonNeselectat, new Point(e.Item.Size.Width / 2, 3), new Point(e.Item.Size.Width / 2, e.Item.Size.Height - 6));
                    else
                        e.Graphics.DrawLine(butonNeselectat, new Point(3, e.Item.Size.Height / 2), new Point(e.Item.Size.Width - 6, e.Item.Size.Height / 2));
                }
            }
            else
                base.OnRenderSeparator(e);
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            var btn = e.Item as ToolStripItem;
            if (btn != null)
            {
                Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);
                if (btn.Selected)
                {
                    using (Brush butonNeselectat = new SolidBrush(IHMStilAplicatie._SMeniuSusBaraOptiuniMouseOver))
                    {
                        e.Graphics.FillRectangle(butonNeselectat, bounds);
                    }
                }
                else
                {
                    using (Brush buton = new SolidBrush(IHMStilAplicatie._SMeniuSusBaraOptiuniFundal))
                    {
                        e.Graphics.FillRectangle(buton, bounds);
                    }
                }
            }
            else
                base.OnRenderMenuItemBackground(e);
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            var btn = e.Item as ToolStripItem;
            if (btn != null)
            {
                if (btn.Selected || (e.Item is ToolStripButton && ((ToolStripButton)e.Item).Checked) || (e.Item is ToolStripDropDownButton && ((ToolStripDropDownButton)e.Item).Pressed))
                {
                    TextRenderer.DrawText(e.Graphics, e.Text, e.TextFont, e.TextRectangle, IHMStilAplicatie._SMeniuSusTextButonSelectat, e.TextFormat);
                }
                else
                    TextRenderer.DrawText(e.Graphics, e.Text, e.TextFont, e.TextRectangle, IHMStilAplicatie._SMeniuSusText, e.TextFormat);
            }
            else
                base.OnRenderItemText(e);
        }

        protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
        {
            var btn = e.Item as ToolStripDropDownButton;
            if (btn != null)
            {
                Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);

                if (btn.Selected)
                {
                    using (Brush butonNeselectat = new SolidBrush(IHMStilAplicatie._SMeniuSusBaraOptiuniMouseOver))
                    {
                        e.Graphics.FillRectangle(butonNeselectat, bounds);
                    }
                }
                else
                    if (btn.Pressed)
                {
                    using (Brush butonSelectat = new SolidBrush(IHMStilAplicatie._SMeniuSusButonSelectat))
                    {
                        e.Graphics.FillRectangle(butonSelectat, bounds);
                    }
                }
                else
                {
                    using (Brush buton = new SolidBrush(IHMStilAplicatie._SMeniuSusBaraOptiuniFundal))
                    {
                        e.Graphics.FillRectangle(buton, bounds);
                    }
                }
            }
            else
                base.OnRenderDropDownButtonBackground(e);
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            var btn = e.Item as ToolStripButton;
            if (btn != null)
            {
                Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);
                if (btn.Checked)
                {
                    using (Brush butonSelectat = new SolidBrush(IHMStilAplicatie._SMeniuSusButonSelectat))
                    {
                        e.Graphics.FillRectangle(butonSelectat, bounds);
                    }
                }
                else
                {
                    if (btn.Selected)
                    {
                        using (Brush butonNeselectat = new SolidBrush(IHMStilAplicatie._SMeniuSusBaraOptiuniMouseOver))
                        {
                            e.Graphics.FillRectangle(butonNeselectat, bounds);
                        }
                    }
                    else
                    {
                        using (Brush buton = new SolidBrush(IHMStilAplicatie._SMeniuSusBaraOptiuniFundal))
                        {
                            e.Graphics.FillRectangle(buton, bounds);
                        }
                    }
                }
            }
            else
                base.OnRenderButtonBackground(e);
        }
    }
}
