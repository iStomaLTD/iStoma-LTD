using System.Windows.Forms;

namespace CCL.UI.ControalePersonalizate
{
    public class ListViewPersonalizat : ListView
    {
        public void AfisajVerticalCuOColoana()
        {
            this.View = View.List;
            this.HeaderStyle = ColumnHeaderStyle.None;

            ColumnHeader header = new ColumnHeader();
            header.Text = "Titlu";
            header.Name = "colTitlu";
            header.Width = this.Width;

            this.Columns.Add(header);
        }
    }
}
