using System.Windows.Forms;

namespace CCL.UI.ControalePersonalizate.DGV
{
    public class DataGridViewMultiTypeColumn : DataGridViewColumn
    {
        public DataGridViewMultiTypeColumn()
        {
            this.CellTemplate = new DataGridViewMultiTypeCell();
        }

        public override object Clone()
        {
            return base.Clone();
        }
    }
}
