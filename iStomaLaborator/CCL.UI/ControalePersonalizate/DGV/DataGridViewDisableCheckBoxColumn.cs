using System.Windows.Forms;

namespace CCL.UI
{
    public class DataGridViewDisableCheckBoxColumn : DataGridViewCheckBoxColumn
    {
        private bool lEnabled = true;

        public DataGridViewDisableCheckBoxColumn()
        {
            this.CellTemplate = new DataGridViewDisableCheckBoxCell();
        }

        public bool Enabled
        {
            get { return this.lEnabled; }
            set
            {
                this.lEnabled = value;
                foreach (DataGridViewRow Rand in this.DataGridView.Rows)
                {
                    ((DataGridViewDisableCheckBoxCell)Rand.Cells[this.Index]).ReadOnly = !this.lEnabled;
                }
                this.DataGridView.Invalidate();
            }
        }
    }
}
