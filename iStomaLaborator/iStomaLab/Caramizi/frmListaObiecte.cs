using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CCL.UI;
using CCL.iStomaLab;
using CDL.iStomaLab;
using iStomaLab.Generale;
using iStomaLab;
using BLL.iStomaLab;

namespace iStomaLab.Caramizi
{
    [DefaultProperty("ElementSelectionat")]
    public partial class frmListaObiecte<T> : FormPersonalizat
    {

        #region Declaratii generale

        private List<T> lListaElemente = null;
        private CDefinitiiComune.EnumTipSelectie lModSelectie = CDefinitiiComune.EnumTipSelectie.FaraSelectie;
        private List<T> lListaElementeSelectionate = null;
        private List<T> lListaElementeEvidentiate = null; //Lista ce contine obiectele pe care le vom afisa ingrosat (sublista a listei de elemente)
        private List<T> lListaElementeBifate = null; //Lista ce contine obiectele pe care le vom bifa (doar in cazul selectiei multiple)
        private Font lFontEvidentiere = null; //Fontul utilizat pentru elementele evidentiate
        private bool lSelectiaInStanga = true;
        private bool lAfiseazaHeaderDGV = true;
        private bool lAfiseazaDoarToString = false;
        private bool lPermiteSelectiaGoala = false;

        #endregion

        #region Enumerari si Structuri

        #endregion

        #region Proprietati

        public T ElementSelectionat
        {
            get
            {
                if (this.lListaElementeSelectionate != null && this.lListaElementeSelectionate.Count > 0)
                {
                    return this.lListaElementeSelectionate[0];
                }
                return default(T);
            }
        }

        public List<T> ListaElementeSelectionate
        {
            get { return this.lListaElementeSelectionate; }
        }

        #endregion

        #region Constructor si Initializare

        public frmListaObiecte(List<T> pListaElemente,
            string pTitluEcran,
            CDefinitiiComune.EnumTipSelectie pModSelectie)
            : this(pListaElemente, pTitluEcran, pModSelectie, null, null, null, false, -1, true, true, true)
        {
        }

        public frmListaObiecte(List<T> pListaElemente,
            string pTitluEcran,
            CDefinitiiComune.EnumTipSelectie pModSelectie,
            List<T> pListaElementeEvidentiate,
            List<T> pListaElementeBifate,
            Control pControlLegatura,
            bool pDeschideLaPozitiaMouseului,
            int pWidthEcran,
            bool pSelectiaInStanga,
            bool pAfiseazaHeaderDGV)
            : this(pListaElemente, pTitluEcran, pModSelectie, pListaElementeEvidentiate, pListaElementeBifate, pControlLegatura,
            pDeschideLaPozitiaMouseului, pWidthEcran, pSelectiaInStanga, pAfiseazaHeaderDGV, false, true, true)
        {
        }

        public frmListaObiecte(List<T> pListaElemente,
            string pTitluEcran,
            CDefinitiiComune.EnumTipSelectie pModSelectie,
            List<T> pListaElementeEvidentiate,
            List<T> pListaElementeBifate,
            Control pControlLegatura,
            bool pDeschideLaPozitiaMouseului,
            int pWidthEcran,
            bool pSelectiaInStanga,
            bool pAfiseazaHeaderDGV,
            bool pAfiseazaDoarToString) : this(pListaElemente, pTitluEcran, pModSelectie, pListaElementeEvidentiate, pListaElementeBifate, pControlLegatura, pDeschideLaPozitiaMouseului, pWidthEcran, pSelectiaInStanga, pAfiseazaHeaderDGV, pAfiseazaDoarToString, false, true)
        {

        }

        public frmListaObiecte(List<T> pListaElemente,
            string pTitluEcran,
            CDefinitiiComune.EnumTipSelectie pModSelectie,
            List<T> pListaElementeEvidentiate,
            List<T> pListaElementeBifate,
            Control pControlLegatura,
            bool pDeschideLaPozitiaMouseului,
            int pWidthEcran,
            bool pSelectiaInStanga,
            bool pAfiseazaHeaderDGV,
            bool pAfiseazaDoarToString,
            bool pPermiteSelectiaGoala,
            bool pPermiteMultiSelectDGV)
        {
            this.InitializeComponent();

            this.dgvListaObiecte.SePermiteMultiBifa(pPermiteMultiSelectDGV);

            this.txtCautare.RandulUrmator += txtCautare_RandulUrmator;
            this.txtCautare.RandulPrecedent += txtCautare_RandulPrecedent;

            this.lListaElemente = pListaElemente;
            this.lModSelectie = pModSelectie;
            this.Text = pTitluEcran;
            this.lListaElementeEvidentiate = pListaElementeEvidentiate;
            this.lListaElementeBifate = pListaElementeBifate;
            this.lSelectiaInStanga = pSelectiaInStanga;
            this.lAfiseazaHeaderDGV = pAfiseazaHeaderDGV;
            this.lPermiteSelectiaGoala = pPermiteSelectiaGoala;

            this.DeschideLaPozitiaMouseului = pDeschideLaPozitiaMouseului;
            this.PermiteDeplasareaEcranului = true;
            this.PermiteMaximizareaEcranului = true;

            this.lAfiseazaDoarToString = pAfiseazaDoarToString;

            //Setam marimea ecranului in functie de marimea listei
            //consideram 25 = inaltimea unui rand si 20 inaltimea header-ului
            int InaltimeEcran = this.txtCautare.Height + Convert.ToInt32(6 * CDefinitiiComune._FactorMultiplicareDPI_X) + this.lblTitluEcran.Height + this.btnValidare.Height + this.lListaElemente.Count * 24 + ((this.lAfiseazaHeaderDGV) ? 20 : 0);
            InaltimeEcran = Math.Max(150 * (int)CDefinitiiComune._FactorMultiplicareDPI_Y, InaltimeEcran);

            if (pWidthEcran > 0)
                this.Width = Convert.ToInt32(pWidthEcran * CDefinitiiComune._FactorMultiplicareDPI_X);

            Screen ecranCurent = Screen.FromControl(this); //this is the Form class

            if (ecranCurent == null)
                ecranCurent = Screen.PrimaryScreen;

            //Arata ciudat daca depasim jumatate din inaltimea ecranului
            if (InaltimeEcran > ecranCurent.WorkingArea.Height / 2 - 20)
            {
                InaltimeEcran = ecranCurent.WorkingArea.Height / 2 - 20;
                this.Height = InaltimeEcran;
                //this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.Height = InaltimeEcran;

                //if (!this.DeschideLaPozitiaMouseului)
                //{
                //    this.TipDeschidere = CEnumerariComune.EnumTipDeschidere.CentrulEcranului;
                //    this.StartPosition = FormStartPosition.CenterScreen;
                //}
                //else
                //    DeschidereMouseStangaJosCuDeplasare();
            }

            if (!this.DeschideLaPozitiaMouseului)
            {
                this.TipDeschidere = CEnumerariComune.EnumTipDeschidere.CentrulEcranului;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
                DeschidereMouseStangaJosCuDeplasare();

            this.MinimumSize = this.Size;
        }

        protected override void OnShown(EventArgs e)
        {
            this.txtCautare.Focus();
            base.OnShown(e);
        }

        private void frmListaObiecte_Load(object sender, EventArgs e)
        {
            Initializeaza();
        }

        public void Initializeaza()
        {
            this.lSeIncarca = true;
            this.btnValidare.Visible = (this.lModSelectie != CDefinitiiComune.EnumTipSelectie.FaraSelectie);
            this.txtCautare.Goleste();

            this.dgvListaObiecte.PermiteSortarea(this.lAfiseazaHeaderDGV);
            ConstruiesteColoaneDGVListaElemente();
            //Asa vom afisa elementele pe care le vrem scoase in evidenta
            this.lFontEvidentiere = new Font(this.dgvListaObiecte.DefaultCellStyle.Font, FontStyle.Bold);
            ConstruiesteRanduriDGVListaElemente();
            this.lSeIncarca = false;
        }

        #endregion

        #region Evenimente

        private void txtCautare_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {

            try
            {
                incepeIncarcarea();

                this.dgvListaObiecte.FiltreazaDupaText(this.txtCautare.Text);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
            finally
            {
                finalizeazaIncarcarea();
            }
        }

        private void dgvListaObiecte_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string NumeColoana = this.dgvListaObiecte.Columns[e.ColumnIndex].Name;
                if (e.RowIndex >= 0)
                {
                    T xElemSelectat = (T)this.dgvListaObiecte.Rows[e.RowIndex].Tag;

                    if (NumeColoana.Equals(DataGridViewPersonalizat.lColoanaSelectieUnica))
                    {
                        this.lListaElementeSelectionate = new List<T>();
                        this.lListaElementeSelectionate.Add(xElemSelectat);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        void dgvListaObiecte_SelectieMultiplaEfectuata(CCL.UI.DataGridViewPersonalizat pDGVSender, bool pToateSelectate)
        {
            //plasam focusul pe butonul de validare pentru a valida selectia
            this.btnValidare.Focus();
        }

        private void dgvListaObiecte_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.lSeIncarca == false && this.dgvListaObiecte.IsCurrentCellDirty)
            {
                this.dgvListaObiecte.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnValidare_Click(object sender, EventArgs e)
        {
            try
            {
                this.lListaElementeSelectionate = new List<T>();
                if (this.lModSelectie == CDefinitiiComune.EnumTipSelectie.SelectieMultipla)
                    this.lListaElementeSelectionate = this.dgvListaObiecte.GetListaObiecteBifate<List<T>, T>();
                else
                    if (this.dgvListaObiecte.SelectedRows.Count > 0 && this.dgvListaObiecte.SelectedRows[0].Visible)
                    this.lListaElementeSelectionate.Add(this.dgvListaObiecte.GetObiectLinieSelectata<T>());
                else
                {
                    //Daca avem un singur rand vizibil atunci vom considera ca acesta este cel selectat
                    bool unRandVizibil = false;
                    DataGridViewRow randVizibil = null;
                    foreach (DataGridViewRow rand in this.dgvListaObiecte.Rows)
                    {
                        if (rand.Visible)
                        {
                            if (unRandVizibil)
                            {
                                unRandVizibil = false;
                                break;
                            }
                            else
                            {
                                unRandVizibil = true;
                                randVizibil = rand;
                            }
                        }
                    }

                    if (unRandVizibil && randVizibil.Tag is T)
                        this.lListaElementeSelectionate.Add((T)randVizibil.Tag);
                }

                if (this.lListaElementeSelectionate.Count == 0 && this.dgvListaObiecte.SelectedRows.Count > 0)
                    this.lListaElementeSelectionate.Add((T)this.dgvListaObiecte.SelectedRow.Tag);

                if (this.lListaElementeSelectionate.Count > 0 || this.lPermiteSelectiaGoala)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    //Mesaj.Afiseaza(this, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CelPutinOLinieTrebuieBifata));
                    //Inchidem pur si simplu
                    inchideEcranulCancel();
                }
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        void txtCautare_RandulPrecedent(object sender, EventArgs e)
        {
            try
            {
                this.dgvListaObiecte.SelecteazaLinie(false);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        void txtCautare_RandulUrmator(object sender, EventArgs e)
        {
            try
            {
                this.dgvListaObiecte.SelecteazaLinie(true);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        #endregion

        #region Metode private

        private void AdaugaColoanaSelectieMultipla()
        {
            if (this.lModSelectie == CDefinitiiComune.EnumTipSelectie.SelectieMultipla)
                this.dgvListaObiecte.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.SelectieMultipla, this.lSelectiaInStanga);
        }

        private void AdaugaColoaneSelectie()
        {
            if (this.lSelectiaInStanga)
                AdaugaColoanaSelectieMultipla();

            if (this.lModSelectie != CDefinitiiComune.EnumTipSelectie.FaraSelectie)
                this.dgvListaObiecte.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.SelectieUnica, this.lSelectiaInStanga);

            if (!this.lSelectiaInStanga)
                AdaugaColoanaSelectieMultipla();
        }

        private void ConstruiesteColoaneDGVListaElemente()
        {
            this.dgvListaObiecte.IncepeConstructieColoane();

            if (this.lSelectiaInStanga)
                AdaugaColoaneSelectie();

            //Construim coloanele corespunzatoare proprietatilor de afisaj
            this.dgvListaObiecte.Columns.Add(DataGridViewPersonalizat.CreazaColoana());

            if (!this.lSelectiaInStanga)
                AdaugaColoaneSelectie();

            if (!this.lAfiseazaHeaderDGV)
                this.dgvListaObiecte.AscundeHeader();

            this.dgvListaObiecte.FinalizeazaConstructieColoane();
        }

        /// <summary>
        /// Populam DGV-ul cu elementele listei
        /// </summary>
        private void ConstruiesteRanduriDGVListaElemente()
        {
            this.dgvListaObiecte.IncepeContructieRanduri();

            foreach (T Elem in this.lListaElemente)
            {
                DataGridViewRow dgvr = this.dgvListaObiecte.Rows[this.dgvListaObiecte.Rows.Add()];
                dgvr.Tag = Elem;

                //Bifam elementele transmise ca atare
                if (this.lModSelectie == CDefinitiiComune.EnumTipSelectie.SelectieMultipla && this.lListaElementeBifate != null &&
                    this.lListaElementeBifate.Contains(Elem))
                    dgvr.Cells[DataGridViewPersonalizat.lColoanaSelectieMultipla].Value = true;

                //Evidentiem elementele transmise
                if (this.lListaElementeEvidentiate != null && this.lListaElementeEvidentiate.Contains(Elem))
                    dgvr.DefaultCellStyle.Font = this.lFontEvidentiere;

                if (this.lModSelectie != CDefinitiiComune.EnumTipSelectie.FaraSelectie)
                    ((DataGridViewImageButtonCell)dgvr.Cells[DataGridViewPersonalizat.lColoanaSelectieUnica]).ImageNormal = CCL.UI.Imagini.getImagineValidare();

                dgvr.Cells["colValoare"].Value = Elem.ToString();

            }
            //Selectia primului element nu are sens
            this.dgvListaObiecte.FinalizeazaContructieRanduri();
        }

        #endregion

        #region Metode publice

        public static T Afiseaza<T>(Form pEcranParinte, List<T> pListaObiecte, string pTitluEcran, CDefinitiiComune.EnumTipSelectie pTipSelectie)
        {
            using (frmListaObiecte<T> EcranPrincipal = new frmListaObiecte<T>(pListaObiecte, pTitluEcran, pTipSelectie))
            {
                if (CCL.UI.IHMUtile.DeschideEcran(pEcranParinte, EcranPrincipal))
                    return EcranPrincipal.lListaElementeSelectionate[0];
            }

            return default(T);
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
        }

        public bool DependentaModificata(string pIdDependenta)
        {
            return true;
        }

        #endregion

    }
}
