using System;
using System.Windows.Forms;

namespace CCL.UI.ControalePersonalizate.DGV
{
    public class DataGridViewMultiTypeCell : DataGridViewCell
    {
        private EnumTipCelula lTipCelula = EnumTipCelula.Vid;

        public enum EnumTipCelula
        {
            Vid = 0,
            Text = 1,
            Lista = 2,
            Bifa = 3,
            Buton = 4
        }

        public EnumTipCelula TipCelula
        {
            get { return this.lTipCelula; }
            set { this.lTipCelula = value; }
        }

        protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            switch (this.lTipCelula)
            {
                case EnumTipCelula.Vid:
                    break;
                case EnumTipCelula.Text:
                    break;
                case EnumTipCelula.Lista:
                    ComboBoxRenderer.DrawDropDownButton(graphics, clipBounds, System.Windows.Forms.VisualStyles.ComboBoxState.Normal);
                    break;
                case EnumTipCelula.Bifa:
                    System.Windows.Forms.VisualStyles.CheckBoxState StareBifa = System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal;
                    if (this.Value != null && Convert.ToBoolean(this.Value))
                    {
                        StareBifa = System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal;
                    }
                    CheckBoxRenderer.DrawCheckBox(graphics, clipBounds.Location, StareBifa);
                    break;
                case EnumTipCelula.Buton:
                    break;
                default:
                    break;
            }
        }
    }
}
