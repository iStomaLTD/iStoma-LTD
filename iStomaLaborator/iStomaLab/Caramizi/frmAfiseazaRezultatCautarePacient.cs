using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Referinta;
using CCL.iStomaLab;
using iStomaLab.Generale;
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
    public partial class frmAfiseazaRezultatCautarePacient : Form
    {
        #region Declaratii generale

        public event SelectiePersSauOrgHandler ElementSelectat;
        public event System.EventHandler InchideEcranul;
        public delegate void SelectiePersSauOrgHandler(StructIdDenumire pElement);
        private List<StructIdDenumire> lListaElementeGasite = null;
        private int lIdClient = 0;
        private int lIdPacAdaugat = 0;
        public static int ultimaVal = 0;
        private BClientiPacienti lPacient = null;
        private string lDenumire = string.Empty;
        private string lPrenume = string.Empty;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public frmAfiseazaRezultatCautarePacient(BClienti pClient, BClientiPacienti pPacient, string pDenumire)     //(BClienti pClient, BClientiPacienti pPacient)
        {
            
            this.DoubleBuffered = true;

            InitializeComponent();   

            this.StartPosition = FormStartPosition.Manual;

            this.ShowInTaskbar = false;
            this.TopMost = true;

            this.dgvLista.IncepeConstructieColoane();

            this.dgvLista.AdaugaColoanaText("colDenumire", string.Empty, 30, true, DataGridViewColumnSortMode.NotSortable);

            this.dgvLista.AdaugaColoanaText("colPrenume", BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Prenume), 70, false, DataGridViewColumnSortMode.Automatic);
           
            //Nu afisam linie de separare pentru a nu incarca afisajul
            this.dgvLista.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            this.dgvLista.AscundeHeader();

            this.dgvLista.FinalizeazaConstructieColoane();

            this.dgvLista.CellClick += DgvLista_CellClick; // selectie cu mouse-ul         
        }

        // selectie cu mouse-ul
        private void DgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.lListaElementeGasite.Count == 0)
            {
                this.Hide();
                int idPac = this.lPacient != null ? this.lPacient.Id : 0;
                TablouDeBord.Clienti.FormDetaliuPacient.Afiseaza(null, this.lIdClient, ref idPac, this.lDenumire);
                ultimaVal = idPac;
            }
           
            anuntaSelectia();           
        }

        private void frmAfiseazaRezultatCautarePersoanaSauOrganizatie_Load(object sender, EventArgs e)
        {
            try
            {
                Initializeaza(this.lIdClient, this.lDenumire);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this, ex);
            }
        }

        public void Initializeaza(int pIdClient, string pDenumire)
        {
            this.lDenumire = pDenumire;
            this.lIdClient = pIdClient;

            if (string.IsNullOrEmpty(pDenumire))
                this.lListaElementeGasite = null;
            else
                this.lListaElementeGasite = BClientiPacienti.GetListaCautare(this.lIdClient, pDenumire, null);

            initPaginatie();

            construiesteRanduri();
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

            //Adaugam randul de Adaugare (doar daca nu am gasit nimic pentru a evita adaugarea de dubluri si doar daca avem un text pe care il cautam)
            if (CUtil.EsteListaVida<StructIdDenumire>(this.lListaElementeGasite) && !string.IsNullOrEmpty(this.lDenumire))
            {
                initRand(this.dgvLista.AdaugaRandNou(), new StructIdDenumire(0, this.lDenumire));
            }

            this.dgvLista.FinalizeazaContructieRanduri();
            if (this.dgvLista.Rows.Count > 0)
                this.dgvLista.Rows[0].Selected = true;
        }

        private void initRand(DataGridViewRow pRand, StructIdDenumire pElem)
        {
            pRand.Tag = pElem;
            pRand.Cells[0].Value = pElem.Denumire;
            if (pElem.Id == 0)
            {
                pRand.DefaultCellStyle.ForeColor = CCL.UI.IHMStilAplicatie._SDGVTextOK;          //culoare verde in grid;               
                pRand.DefaultCellStyle.Font = new Font(this.dgvLista.Font, FontStyle.Bold);
                pRand.DefaultCellStyle.SelectionForeColor = CCL.UI.IHMStilAplicatie._SDGVTextOK; //culoare verde in grid;;
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
            }
        }

        #endregion

        #region Metode publice

        internal void AplicaPreferintele()
        {
            //IHMAplicaPreferinteleUtilizatorului.AplicaPreferintelePeFormular(this, BLL.General.BPreferinteAplicatie.GetPreferinteUtilizatorConectat());
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

        //returnam ultimul id din baza de date - valoarea pacientului din control
        public static int GetIdPacient(ref int idPacAdd)
        {
            idPacAdd = ultimaVal;
            return idPacAdd;
        }
        #endregion
    }
}
