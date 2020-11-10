using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CCL.UI.FormulareComune
{
    public partial class frmCuloriSemnificatie : frmCuHeader
    {

        #region Declaratii generale

        private List<Tuple<Color, Color, string>> lListaCuloriSemnificatie = null;

        #endregion

        #region Enumerari si Structuri

        private enum EnumColDGV
        {
            colSemnificatie
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public frmCuloriSemnificatie(Dictionary<int, Tuple<Color, Color, string>> pDictCuloriSemnificatie, string pTitlu)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.PermiteDeplasareaEcranului = true;
            this.PermiteMaximizareaEcranului = true;
            this.PermiteRedimensionarea = true;

            this.StartPosition = FormStartPosition.CenterScreen;

            this.Text = pTitlu;// "Semnificația culorilor";

            this.lListaCuloriSemnificatie = new List<Tuple<Color, Color, string>>();

            foreach (KeyValuePair<int, Tuple<Color, Color, string>> linie in pDictCuloriSemnificatie)
            {
                this.lListaCuloriSemnificatie.Add(linie.Value);
            }
        }

        private void frmCuloriSemnificatie_Load(object sender, EventArgs e)
        {
            try
            {
                Initializeaza();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IHMUtile.getText(605), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Initializeaza()
        {
            //O singura coloana
            this.dgvSemnificatieCulori.IncepeConstructieColoane(Color.White);
            this.dgvSemnificatieCulori.AscundeHeader();

            this.dgvSemnificatieCulori.AdaugaColoanaText(EnumColDGV.colSemnificatie.ToString(), string.Empty, 100, true, DataGridViewColumnSortMode.Programmatic);

            this.dgvSemnificatieCulori.FinalizeazaConstructieColoane();

            //Incarcam lista
            this.dgvSemnificatieCulori.IncepeContructieRanduri();

            DataGridViewRow rand = null;
            foreach (var element in this.lListaCuloriSemnificatie)
            {
                rand = this.dgvSemnificatieCulori.AdaugaRandNou();

                rand.MinimumHeight = 30;

                rand.DefaultCellStyle.BackColor = element.Item1;
                rand.DefaultCellStyle.ForeColor = element.Item2;

                rand.DefaultCellStyle.SelectionBackColor = element.Item1;
                rand.DefaultCellStyle.SelectionForeColor = element.Item2;

                rand.Cells[EnumColDGV.colSemnificatie.ToString()].Value = element.Item3;
            }

            rand = null;
            this.dgvSemnificatieCulori.FinalizeazaContructieRanduri();
        }

        #endregion

        #region Evenimente



        #endregion

        #region Metode private



        #endregion

        #region Metode publice

        public static void Afiseaza(Form pEcranParinte, Dictionary<int, Tuple<Color, Color, string>> pDictCuloriSemnificatie, string pTitlu)
        {
            using (frmCuloriSemnificatie ecran = new frmCuloriSemnificatie(pDictCuloriSemnificatie, pTitlu))
            {
                IHMUtile.DeschideEcran(pEcranParinte, ecran);
            }
        }

        #endregion

    }
}
