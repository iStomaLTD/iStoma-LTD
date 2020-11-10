using System.Drawing;
using System.Windows.Forms;
using ILL.iStomaLab;
using ILL.iStomaLab;
using static CDL.iStomaLab.CStructuriComune;

namespace CCL.UI.Caramizi
{
    public partial class ControlLegendaImagini<R> : UserControl, IAcceptaValidare<R>
    {

        #region Declaratii generale

        private static Color CULOARE_LINIE_ALTERNANTA = Color.LightGray;
        public SelectieImagineHandler SelectieEfectuata;
        public delegate void SelectieImagineHandler(R pImagineSelectata);

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoane
        {
            colImagine = 1,
            colSemnificatie = 0
        }

        #endregion

        #region Proprietati

        public R ImagineSelectata { get; private set; }

        #endregion

        #region Constructor si Initializare

        public ControlLegendaImagini()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            ConstruiesteColoaneDGV();
        }

        public void Initializeaza()
        {
            this.dgvLegenda.ClearSelection();
        }

        public void Initializeaza(LegendaImagini pLegendaImagini)
        {
            ImagineSelectata = default(R);

            ConstruiesteRanduriDGV(pLegendaImagini);
        }

        #endregion

        #region Evenimente

        private void dgvLegenda_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //click-ul pe imagine da selectia
            if (e.ColumnIndex == (int)EnumColoane.colImagine && e.RowIndex >= 0)
            {
                Validare();
            }
        }

        #endregion

        #region Metode private

        private void AnuntaSelectia()
        {
            if (this.SelectieEfectuata != null)
                SelectieEfectuata(ImagineSelectata);
        }

        private void ConstruiesteColoaneDGV()
        {
            //this.dgvLegenda.AranjeazaProprietati(CULOARE_LINIE_ALTERNANTA);
            //this.dgvLegenda.CellBorderStyle = DataGridViewCellBorderStyle.None;
            this.dgvLegenda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLegenda.AdaugaColoanaText(EnumColoane.colSemnificatie.ToString(), "Semnificație", 50, true, DataGridViewColumnSortMode.NotSortable);
            this.dgvLegenda.AdaugaColoanaButonStandard(EnumColoane.colImagine.ToString(), "Imagine", "", 60, false);
        }

        private void ConstruiesteRanduriDGV(LegendaImagini pLegendaImagini)
        {
            DataGridViewImageButtonCell celulaImagine = null;
            DataGridViewRow RandAdaugat = null;
            this.dgvLegenda.Rows.Add(pLegendaImagini.Count);
            int indexRand = 0;
            foreach (StructLegendaImagini ImagineLegenda in pLegendaImagini)
            {
                RandAdaugat = this.dgvLegenda.Rows[indexRand];
                RandAdaugat.Tag = ImagineLegenda;
                RandAdaugat.DefaultCellStyle.ForeColor = ImagineLegenda.CuloareText;

                //Imaginea
                celulaImagine = RandAdaugat.Cells[(int)EnumColoane.colImagine] as DataGridViewImageButtonCell;
                celulaImagine.ImageNormal = ImagineLegenda.Imagine;

                //Semnificatia
                RandAdaugat.Cells[(int)EnumColoane.colSemnificatie].Value = ImagineLegenda.Semnificatie;

                indexRand++;
            }

            RandAdaugat = null;
            celulaImagine = null;

            this.dgvLegenda.ClearSelection();
        }

        #endregion

        #region Metode publice

        public R Validare()
        {
            this.ImagineSelectata = this.dgvLegenda.GetObiectLinieSelectata<R>();
            AnuntaSelectia();

            return this.ImagineSelectata;
        }

        #endregion

    }
}
