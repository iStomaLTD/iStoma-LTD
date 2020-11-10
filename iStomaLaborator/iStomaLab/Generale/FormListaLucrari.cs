using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Comune;
using BLL.iStomaLab.Preturi;
using BLL.iStomaLab.Referinta;
using CCL.iStomaLab;
using CCL.UI;
using CCL.UI.TGV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iStomaLab.Generale
{
    public partial class FormListaLucrari : FormPersonalizat
    {

        #region Declaratii generale

        private BListaPreturiStandard lLucrare = null;
        private BClienti lClient = null;
        private bool lArataCategorii = true; 

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colDenumire,
            colPret,
            colMoneda
        }

        private enum EnumColTGV
        {
            colExpand,
            colDenumire,
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public FormListaLucrari(BClienti pClient)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lClient = pClient;

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {

                adaugaHandlere();
                initTextML();

                this.CentratCuDeplasare();
            }
        }

        private void adaugaHandlere()
        {
            this.Load += _Load;
            this.dgvListaLucrari.SelectieUnicaEfectuata += DgvListaLucrari_SelectieUnicaEfectuata;
            this.ctrlValidareAnulare.Validare += CtrlValidareAnulare_Validare;
            this.txtCautaLucrare.CerereUpdate += TxtCautaLucrare_CerereUpdate;
            this.tgvListaCategorii.CellClick += TgvListaCategorii_CellClick;
            this.btnFiltreOrizontala.Click += BtnFiltreVerticala_Click;
        }

        private void initTextML()
        {
            this.Text = string.Empty;
        }

        void _Load(object sender, EventArgs e)
        {
            try
            {
                Initializeaza();
                AllowModification(true);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.txtCautaLucrare.Goleste();

            this.btnFiltreOrizontala.Initializeaza(BComportamentAplicatie.EnumComportamentAplicatie.ArataCategoriileInEcranulLucrari, true);
    
            initComportamentAplicatie();
            
            this.btnFiltreOrizontala.Selectat = false;    //lore aici era =this.lArataCategorii;(adica .t.) si nu facea nimic la primul click pe ->

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void BtnFiltreVerticala_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();         
                initComportamentAplicatie();
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

        private void TgvListaCategorii_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (this.lSeIncarca || e.RowIndex < 0) return;
            try
            {
                incepeIncarcarea();

                if (e.ColumnIndex == 0 && e.RowIndex == -1)
                {
                    foreach (var node in this.tgvListaCategorii.Nodes)
                    {
                        if (node.RowIndex == 0 && !node.EsteExpandat)
                        {
                            node.Expand();
                        }
                        else
                        {
                            node.Collapse();
                        }

                        if (areToateNodurileExpandate(node))
                        {
                            this.tgvListaCategorii.CollapseAll();
                            break;
                        }
                        else
                        {
                            this.tgvListaCategorii.ExpandAll();
                            break;
                        }
                    }
                }
                else
                {
                    this.tgvListaCategorii.SelectedNode.Expand();
                    ConstruiesteRanduriDGV();
                }

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

        private void TxtCautaLucrare_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvListaLucrari.FiltreazaDupaText(this.txtCautaLucrare.Text);
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

        private void CtrlValidareAnulare_Validare(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (this.dgvListaLucrari.SelectedRow != null)
                {
                    Tuple<BListaPreturiStandard, BListaPreturiClienti> elemLinie = this.dgvListaLucrari.SelectedRow.Tag as Tuple<BListaPreturiStandard, BListaPreturiClienti>;

                    if (elemLinie != null)
                    {
                        this.lLucrare = elemLinie.Item1;

                        if (this.lLucrare != null)
                        {
                            inchideEcranulOK();
                        }
                    }
                }
                else
                {
                    Mesaj.Informare(this, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.SelectatiOLucrareDinLista), string.Empty);
                }
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

        private void DgvListaLucrari_SelectieUnicaEfectuata(object sender, DataGridViewCellEventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BListaPreturiStandard lucrareSelectata = this.dgvListaLucrari.Rows[e.RowIndex].Tag as BListaPreturiStandard;

                if (lucrareSelectata != null)
                {
                    this.lLucrare = lucrareSelectata;
                    inchideEcranulOK();
                }
                else
                {
                    Tuple<BListaPreturiStandard, BListaPreturiClienti> valori = this.dgvListaLucrari.Rows[this.dgvListaLucrari.CurrentCell.RowIndex].Tag as Tuple<BListaPreturiStandard, BListaPreturiClienti>;
                    BListaPreturiStandard lucrareStandard = valori.Item1;
                    if (lucrareStandard != null)
                    {
                        this.lLucrare = lucrareStandard;
                        inchideEcranulOK();
                    }
                }
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

        #endregion

        #region Metode private

        private void initComportamentAplicatie()
        {
            this.lArataCategorii = BComportamentAplicatie.GetArataCategoriileInEcranulLucrari();
           
            this.tgvListaCategorii.Visible = this.lArataCategorii;
           
            if (this.lArataCategorii)
            {
                ConstruiesteColoaneTGV();
                ConstruiesteRanduriTGV();

                this.tgvListaCategorii.Rows[0].Selected = true;
                this.tgvListaCategorii.CollapseAll();

                this.dgvListaLucrari.Dock = DockStyle.None;               
                this.dgvListaLucrari.Width = this.Width - this.tgvListaCategorii.Width;
            }
            else
            {
                this.dgvListaLucrari.Width = this.panelListaLucrari.Width;
                this.dgvListaLucrari.Dock = DockStyle.Fill;
            }
        }

        private bool areToateNodurileExpandate(TreeGridNode pNodDeVerificat)
        {
            if (!pNodDeVerificat.EsteExpandat)
                return false;
            foreach (TreeGridNode nod in pNodDeVerificat.Nodes)
            {
                if (nod.Nodes.Count == 0)
                    continue;
                if (!areToateNodurileExpandate(nod))
                    return false;
            }
            return true;
        }

        #region Initializare DGV Lista Lucrari

        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaLucrari.IncepeConstructieColoane();

            this.dgvListaLucrari.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.SelectieUnica);

            this.dgvListaLucrari.AdaugaColoanaText(EnumColoaneDGV.colDenumire.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaLucrari.AdaugaColoanaNumerica(EnumColoaneDGV.colPret.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Valoare), 80, DataGridViewColumnSortMode.Automatic);

            this.dgvListaLucrari.AdaugaColoanaText(EnumColoaneDGV.colMoneda.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Moneda), 70, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaLucrari.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {

            var listaElemStandard = BListaPreturiStandard.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

            if (this.lArataCategorii)
            {
                if (this.tgvListaCategorii.Rows[0].Selected)
                    ConstruiesteRanduriDGV(listaElemStandard);
                else
                {
                    BCategorii categorie = this.tgvListaCategorii.SelectedRow.Tag as BCategorii;
                    if (categorie != null)
                    {
                        if (categorie.IdCategorie != 0)
                        {
                            int idCategorie = categorie.Id;
                            ConstruiesteRanduriDGV(listaElemStandard.GetListaPreturiIdCategorie(idCategorie));
                        }
                        else
                        {
                            List<int> listaId = BCategorii.GetListaIdCategorieComun(categorie.Id, null);
                            listaId.AddRange(BCategorii.GetListaIdCategorii(categorie.Id, null));

                            if (!CUtil.EsteListaIntVida(listaId))
                            {
                                ConstruiesteRanduriDGV(BListaPreturiStandard.getByListaIdCategorii(listaId, null));
                            }
                            else
                            {
                                ConstruiesteRanduriDGV(BListaPreturiStandard.GetListByParamIdCategorie(categorie.Id, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null));
                            }
                        }
                    }
                }
            }
            else
            {
                ConstruiesteRanduriDGV(listaElemStandard);
            }

        }

        private void ConstruiesteRanduriDGV(BColectieListaPreturiStandard pListaPreturi)
        {
            this.dgvListaLucrari.IncepeContructieRanduri();

            if (this.lClient == null)
            {
                foreach (var elem in pListaPreturi)
                {
                    incarcaRand(this.dgvListaLucrari.Rows[this.dgvListaLucrari.Rows.Add()], elem);
                }
            }
            else
            {
                foreach (var elem in pListaPreturi)
                {
                    incarcaRand(this.dgvListaLucrari.Rows[this.dgvListaLucrari.Rows.Add()], elem, BListaPreturiClienti.GetPretClient(elem.Id, this.lClient.Id, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null));
                }
            }

            this.dgvListaLucrari.FinalizeazaContructieRanduri();
        }

        private void incarcaRand(DataGridViewRow pRand, BListaPreturiStandard pElem)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaSelectieUnica(pRand, this.lEcranInModificare);
            pRand.Cells[EnumColoaneDGV.colDenumire.ToString()].Value = pElem.Denumire;
            pRand.Cells[EnumColoaneDGV.colPret.ToString()].Value = pElem.GetValoare();
            pRand.Cells[EnumColoaneDGV.colMoneda.ToString()].Value = pElem.GetEtichetaMoneda();
        }

        private void incarcaRand(DataGridViewRow pRand, BListaPreturiStandard pElem, BListaPreturiClienti pPretClient)
        {
            pRand.Tag = new Tuple<BListaPreturiStandard, BListaPreturiClienti>(pElem, pPretClient);

            DataGridViewPersonalizat.InitCelulaSelectieUnica(pRand, this.lEcranInModificare);
            pRand.Cells[EnumColoaneDGV.colDenumire.ToString()].Value = pElem.Denumire;
            pRand.Cells[EnumColoaneDGV.colPret.ToString()].Value = pElem.ValoareRON == 0 ? pElem.ValoareEUR : pElem.ValoareRON;
            if (pPretClient != null)
                pRand.Cells[EnumColoaneDGV.colPret.ToString()].Value = pPretClient.GetValoareClient();
            else
            {
                pRand.Cells[EnumColoaneDGV.colPret.ToString()].Value = pElem.ValoareRON == 0 ? pElem.ValoareEUR : pElem.ValoareRON;
            }
            pRand.Cells[EnumColoaneDGV.colMoneda.ToString()].Value = pElem.ValoareRON == 0 ? CUtil.getText(1265) : CUtil.getText(1264);
        }

        #endregion

        #region Initializare TGV Lista Categorii

        private void ConstruiesteColoaneTGV()
        {
            this.tgvListaCategorii.IncepeConstructieColoane();

            TreeGridColumn colExpand = new TreeGridColumn();
            colExpand.Name = EnumColTGV.colExpand.ToString();
            colExpand.HeaderText = string.Empty;
            colExpand.MinimumWidth = 20;
            colExpand.Width = 20;
            colExpand.Frozen = true;
            colExpand.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.tgvListaCategorii.Columns.Add(colExpand);

            this.tgvListaCategorii.AdaugaColoanaText(EnumColTGV.colDenumire.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire), 100, true, DataGridViewColumnSortMode.Automatic);

            this.tgvListaCategorii.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriTGV()
        {
            this.tgvListaCategorii.Nodes.Clear();

            var listaCategorii = BCategorii.GetListByParamCategorii(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

            incarcaRandToateCategoriile();

            foreach (var categorie in listaCategorii)
            {
                incarcaRandCategorie(categorie);
            }

            this.tgvListaCategorii.FinalizeazaContructieRanduri();
            this.tgvListaCategorii.ClearSelection();
        }

        private void incarcaRandCategorie(BCategorii pCategorie)
        {

            TreeGridNode NodCategorie = this.tgvListaCategorii.CreazaNod(-1);
            NodCategorie.Tag = pCategorie;

            TreeGridNode NodSubCategorie = null;

            if (pCategorie != null)
            {
                var listaSubcategorii = BCategorii.GetListByParamSubcategorii(pCategorie.Id, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

                NodCategorie.Cells[EnumColTGV.colDenumire.ToString()].Value = pCategorie.Denumire;
                NodCategorie.DefaultCellStyle.Font = new Font(this.tgvListaCategorii.Font, FontStyle.Bold);

                if (listaSubcategorii.Count > 0)
                {
                    foreach (var subcategorie in listaSubcategorii)
                    {
                        NodSubCategorie = NodCategorie.CreazaNod(-1);
                        incarcaRandSubcategorie(NodSubCategorie, subcategorie);
                    }
                }
            }
        }

        private void incarcaRandToateCategoriile()
        {

            TreeGridNode NodCategorie = this.tgvListaCategorii.CreazaNod(-1);

            NodCategorie.Cells[EnumColTGV.colDenumire.ToString()].Value = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Toate);
            NodCategorie.DefaultCellStyle.Font = new Font(this.tgvListaCategorii.Font, FontStyle.Bold);
        }

        private void incarcaRandSubcategorie(TreeGridNode randTGV, BCategorii pCategorie)
        {
            randTGV.Tag = pCategorie;
            randTGV.Cells[1].Value = pCategorie.Denumire;
        }

        #endregion

        #endregion

        #region Metode publice

        public static BListaPreturiStandard Afiseaza(Form pEcranPariente, BClienti pClient)
        {
            using (FormListaLucrari ecran = new FormListaLucrari(pClient))
            {
                ecran.AplicaPreferinteleUtilizatorului();
                CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);

                return ecran.lLucrare;
            }

        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
        }

        #endregion


    }
}
