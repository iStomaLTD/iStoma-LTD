using System.Windows.Forms;

namespace CCL.UI
{
    public class DataGridViewImageButtonColumn : DataGridViewButtonColumn
    {
        public DataGridViewImageButtonColumn()
        {
            this.CellTemplate = new DataGridViewImageButtonCell();
            this.Width = 22;
            this.Resizable = DataGridViewTriState.False;
        }
    }
}
