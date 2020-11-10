using BLL.iStomaLab;
using BLL.iStomaLab.Referinta;
using CCL.iStomaLab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iStomaLab.Caramizi
{
    public partial class frmAfiseazaRezultatCautareTara : Form
    {

        #region Declaratii generale

        public event SelectiePersSauOrgHandler ElementSelectat;
        public event System.EventHandler InchideEcranul;
        public delegate void SelectiePersSauOrgHandler(StructIdDenumire pElement);

        private string lDenumire = string.Empty;
        private List<StructIdDenumire> lListaElementeGasite = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public frmAfiseazaRezultatCautareTara(string pDenumire)
        {
            this.DoubleBuffered = true;
            this.lDenumire = pDenumire;

            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;

            this.ShowInTaskbar = false;
            this.TopMost = true;

            this.dgvLista.IncepeConstructieColoane();

            this.dgvLista.AdaugaColoanaText("colDenumire", string.Empty, 100, true, DataGridViewColumnSortMode.NotSortable);

            //Nu afisam linie de separare pentru a nu incarca afisajul
            this.dgvLista.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            this.dgvLista.AscundeHeader();

            this.dgvLista.FinalizeazaConstructieColoane();
        }

        private void frmAfiseazaRezultatCautarePersoanaSauOrganizatie_Load(object sender, EventArgs e)
        {
            try
            {
                Initializeaza(this.lDenumire);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this, ex);
            }
        }

        public void Initializeaza(string pDenumire)
        {
            this.lDenumire = pDenumire;

            if (string.IsNullOrEmpty(pDenumire))
                this.lListaElementeGasite = null;
            else
                this.lListaElementeGasite = BTari.GetListaCautare(pDenumire, null);

            initPaginatie();

            //incepeIncarcarea();

            construiesteRanduri();

            //finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void dgvLista_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                anuntaSelectia();
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this, ex);
            }
        }

        private void ctrlPaginatie_PaginaSchimbata(object sender, EventArgs e)
        {
            try
            {
                construiesteRanduri();
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this, ex);
            }
        }

        private void btnAnuleaza_Click(object sender, EventArgs e)
        {
            this.Hide();
            anuntaInchidereaEcranului();
        }

        #endregion

        #region Metode private

        private void anuntaInchidereaEcranului()
        {
            if (this.InchideEcranul != null)
                InchideEcranul(this, null);
        }

        private void anuntaSelectia()
        {
            if (this.ElementSelectat != null && this.dgvLista.SelectedRows.Count > 0)
                ElementSelectat((StructIdDenumire)this.dgvLista.SelectedRows[0].Tag);
        }

        private void construiesteRanduri()
        {
            this.dgvLista.IncepeContructieRanduri();

            if (!CUtil.EsteListaVida<StructIdDenumire>(this.lListaElementeGasite))
            {
                for (int i = this.ctrlPaginatie.getIndexStart(); i < this.ctrlPaginatie.getIndexStop(); i++)
                {
                    initRand(this.dgvLista.AdaugaRandNou(), this.lListaElementeGasite[i]);
                }
            }

            //Nu permitem crearea de tari in iStoma
            //Adaugam randul de Adaugare (doar daca nu am gasit nimic pentru a evita adaugarea de dubluri si doar daca avem un text pe care il cautam)
            if (CCL.iStomaLab.CUtil.EsteListaVida<BLL.iStomaLab.StructIdDenumire>(this.lListaElementeGasite) && !string.IsNullOrEmpty(this.lDenumire))
            {
                initRand(this.dgvLista.AdaugaRandNou(), new BLL.iStomaLab.StructIdDenumire(0, this.lDenumire));
            }

            this.dgvLista.FinalizeazaContructieRanduri();
            if (this.dgvLista.Rows.Count > 0)
                this.dgvLista.Rows[0].Selected = true;
        }

        private void initRand(DataGridViewRow pRand, BLL.iStomaLab.StructIdDenumire pElem)
        {
            pRand.Tag = pElem;
            pRand.Cells[0].Value = pElem.Denumire;
            if (pElem.Id == 0)
            {
                pRand.DefaultCellStyle.ForeColor = CCL.UI.IHMStilAplicatie._SDGVTextAlerta;
                pRand.DefaultCellStyle.Font = new Font(this.dgvLista.Font, FontStyle.Bold);
                pRand.DefaultCellStyle.SelectionForeColor = CCL.UI.IHMStilAplicatie._SDGVTextAlerta;
            }
        }

        private void initPaginatie()
        {
            if (this.lListaElementeGasite == null)
            {
                this.ctrlPaginatie.Initializeaza(0, 0);
            }
            else
            {
                //Lasam un rand pentru adaugare
                this.ctrlPaginatie.Initializeaza(this.lListaElementeGasite.Count, 10);
                //((this.dgvLista.Height - (System.Windows.Forms.SystemInformation.HorizontalScrollBarHeight)) / this.dgvLista.RowTemplate.Height)-1);
            }
        }

        #endregion

        #region Metode publice

        internal void AplicaPreferintele()
        {
            this.BackColor = Color.White;
            this.ctrlPaginatie.BackColor = Color.White;
            this.panelGlobal.BackColor = Color.White;
        }

        internal void Selecteaza()
        {
            anuntaSelectia();
        }

        internal void MutaSelectiaInJos()
        {
            mutaSelectia(true);
        }

        internal void MutaSelectiaInSus()
        {
            mutaSelectia(false);
        }

        private void mutaSelectia(bool pInJos)
        {
            int indexSelectie = 0;
            if (this.dgvLista.SelectedRows.Count > 0)
            {
                indexSelectie = this.dgvLista.SelectedRows[0].Index;
                indexSelectie += pInJos ? 1 : -1;
            }

            if (indexSelectie < 0) indexSelectie = 0;

            if (this.dgvLista.Rows.Count > indexSelectie)
            {
                this.dgvLista.ClearSelection();
                this.dgvLista.Rows[indexSelectie].Selected = true;
            }
        }

        internal void DistrugeCautarea()
        {
            this.lListaElementeGasite = null;
            this.dgvLista.Goleste();
        }

        #endregion

    }
}
