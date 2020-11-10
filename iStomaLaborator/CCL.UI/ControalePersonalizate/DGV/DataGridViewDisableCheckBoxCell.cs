using System;
using System.Drawing;
using System.Windows.Forms;

namespace CCL.UI
{
    public class DataGridViewDisableCheckBoxCell : DataGridViewCheckBoxCell
    {
        //private bool enabledValue;

        ///// <summary>
        ///// This property decides whether the checkbox should be shown 
        ///// checked or unchecked.
        ///// </summary>

        //public bool Enabled
        //{
        //    get
        //    {
        //        return enabledValue;
        //    }
        //    set
        //    {
        //        enabledValue = value;
        //    }
        //}

        /// Override the Clone method so that the Enabled property is copied.

        //public override object Clone()
        //{
        //    DataGridViewDisableCheckBoxCell cell =
        //        (DataGridViewDisableCheckBoxCell)base.Clone();
        //    cell.Enabled = this.Enabled;
        //    return cell;
        //}
        protected override void Paint(System.Drawing.Graphics graphics,
                                                    Rectangle clipBounds,
                                                    Rectangle cellBounds,
                                                    int rowIndex,
                                                    DataGridViewElementStates elementState,
                                                    object value,
                                                    object formattedValue,
                                                    string errorText,
                                                    DataGridViewCellStyle cellStyle,
                                                    DataGridViewAdvancedBorderStyle advancedBorderStyle,
                                                    DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value,
            formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            if (this.ReadOnly)
            {
                System.Drawing.Size xCheckBoxSize = CheckBoxRenderer.GetGlyphSize(graphics, System.Windows.Forms.VisualStyles.CheckBoxState.CheckedDisabled);
                System.Drawing.Point xPoint = cellBounds.Location;
                xPoint.Offset(Convert.ToInt32((cellBounds.Width - xCheckBoxSize.Width) / 2), Convert.ToInt32((cellBounds.Height - xCheckBoxSize.Height) / 2));
                if ((true).Equals(this.Value))
                {
                    CheckBoxRenderer.DrawCheckBox(graphics, xPoint, System.Windows.Forms.VisualStyles.CheckBoxState.CheckedDisabled);
                }
                else
                {
                    CheckBoxRenderer.DrawCheckBox(graphics, xPoint, System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedDisabled);
                }
            }
        }
        //protected override void Paint
        //(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds,
        //        int rowIndex, DataGridViewElementStates elementState, object value,
        //        object formattedValue, string errorText, DataGridViewCellStyle cellStyle,
        //        DataGridViewAdvancedBorderStyle advancedBorderStyle,
        //            DataGridViewPaintParts paintParts)
        //{

        //    SolidBrush cellBackground = new SolidBrush(cellStyle.BackColor);
        //    graphics.FillRectangle(cellBackground, cellBounds);
        //    cellBackground.Dispose();
        //    PaintBorder(graphics, clipBounds, cellBounds,
        //    cellStyle, advancedBorderStyle);
        //    Rectangle checkBoxArea = cellBounds;
        //    Rectangle buttonAdjustment = this.BorderWidths(advancedBorderStyle);
        //    checkBoxArea.X += buttonAdjustment.X;
        //    checkBoxArea.Y += buttonAdjustment.Y;

        //    checkBoxArea.Height -= buttonAdjustment.Height;
        //    checkBoxArea.Width -= buttonAdjustment.Width;
        //    Point drawInPoint = new Point(cellBounds.X + cellBounds.Width / 2 - 7,
        //        cellBounds.Y + cellBounds.Height / 2 - 7);

        //    if (this.ReadOnly)
        //    {
        //        if (Convert.ToBoolean(this.Value) == true)
        //        {
        //            CheckBoxRenderer.DrawCheckBox(graphics, drawInPoint,
        //           System.Windows.Forms.VisualStyles.CheckBoxState.CheckedDisabled);
        //        }
        //        else
        //        {
        //            CheckBoxRenderer.DrawCheckBox(graphics, drawInPoint,
        //                    System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedDisabled);
        //        }

        //    }
        //    else
        //    {
        //        if (Convert.ToBoolean(this.Value) == true)
        //        {
        //            CheckBoxRenderer.DrawCheckBox(graphics, drawInPoint,
        //                       System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal);
        //        }
        //        else
        //        {
        //            CheckBoxRenderer.DrawCheckBox(graphics, drawInPoint,
        //                   System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
        //        }
        //    }
        //}
    }
}
