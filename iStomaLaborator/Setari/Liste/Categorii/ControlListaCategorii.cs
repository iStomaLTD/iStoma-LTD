using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iStomaLab.Generale;
using BLL.iStomaLab;
using BLL.iStomaLab.Referinta;
using CCL.UI.TGV;
using CCL.UI;
using CCL.UI.Caramizi;

namespace iStomaLab.Setari.Liste.Categorii
{
    public partial class ControlListaCategorii : UserControlPersonalizat
    {

        #region Declaratii generale


        #endregion

        #region Enumerari si Structuri

        private enum EnumColTGV
        {
            colExpand,
            colModifica,
            colDenumire,
            colCuloare
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlListaCategorii()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                adaugaHandlere();
                initTextML();
            }
        }

        private void adaugaHandlere()
        {
            this.btnAdaugaCategorie.Click += BtnAdaugaCategorie_Click;
            this.tgvListaCategorii.CellClick += TgvListaCategorii_CellClick;
            this.tgvListaCategorii.StergereLinie += TgvListaCategorii_StergereLinie;
            this.txtCautaCategorie.CerereUpdate += TxtCautaCategorie_CerereUpdate;
            this.tgvListaCategorii.EditareLinie += TgvListaCategorii_EditareLinie;
        }

        private void initTextML()
        {
            this.lblCategorie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Categorie);
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.tgvListaCategorii.ExpandAll();
            this.txtCautaCategorie.Goleste();

            ConstructieColoaneTGV();
            ConstruiesteRanduriTGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void TgvListaCategorii_EditareLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BCategorii categorie = this.tgvListaCategorii.CurrentNode.Parent.Tag as BCategorii;

                BCategorii celulaSelectata = this.tgvListaCategorii.CurrentNode.Tag as BCategorii;

                object adaugaSubcategorie = this.tgvListaCategorii.CurrentNode.Tag;

                if (adaugaSubcategorie != null && adaugaSubcategorie.Equals(1))
                {
                    if (FormDetaliiCategorie.Afiseaza(this.GetFormParinte(), categorie, false))
                    {
                        ConstruiesteRanduriTGV();
                    }
                }

                if (celulaSelectata != null && celulaSelectata.IdCategorie == 0)
                {
                    if (FormDetaliiCategorie.Afiseaza(this.GetFormParinte(), celulaSelectata, true))
                    {
                        ConstruiesteRanduriTGV();
                    }
                }

                if (celulaSelectata != null && celulaSelectata.IdCategorie != 0)
                {
                    if (FormDetaliiCategorie.Afiseaza(this.GetFormParinte(), celulaSelectata, false))
                    {
                        ConstruiesteRanduriTGV();
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

        private void TxtCautaCategorie_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.tgvListaCategorii.FiltreazaDupaText(this.txtCautaCategorie.Text);
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

        private void TgvListaCategorii_StergereLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BCategorii categorie = this.tgvListaCategorii.Rows[this.tgvListaCategorii.CurrentCell.RowIndex].Tag as BCategorii;

                if (categorie != null)
                {
                    if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), categorie.Denumire))
                    {
                        categorie.Close(true, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stergere), null);
                        ConstruiesteRanduriTGV();
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

        private void TgvListaCategorii_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (e.ColumnIndex == 0 && e.RowIndex == -1)
                {
                    foreach (var node in this.tgvListaCategorii.Nodes)
                    {
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

                BCategorii celulaSelectata = this.tgvListaCategorii.CurrentNode.Tag as BCategorii;

                if (celulaSelectata != null && celulaSelectata.IdCategorie == 0)
                {
                    this.tgvListaCategorii.CurrentNode.Cells[EnumColTGV.colCuloare.ToString()].Style.SelectionBackColor = BDefinitiiGenerale.getCuloareDinARGB(celulaSelectata.Culoare);
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

        private void BtnAdaugaCategorie_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (FormDetaliiCategorie.Afiseaza(this.GetFormParinte(), null, false))
                {
                    ConstruiesteRanduriTGV();
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

        private void ConstructieColoaneTGV()
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

            this.tgvListaCategorii.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.Editare);
            
            this.tgvListaCategorii.AdaugaColoanaText(EnumColTGV.colDenumire.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire), 100, true, DataGridViewColumnSortMode.Automatic);

            this.tgvListaCategorii.AdaugaColoanaText(EnumColTGV.colCuloare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Culoare), 50, false, DataGridViewColumnSortMode.Automatic);

            this.tgvListaCategorii.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.tgvListaCategorii.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriTGV()
        {
            this.tgvListaCategorii.Nodes.Clear();


            var listaCategorii = BCategorii.GetListByParamCategorii(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

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

            TreeGridNode NodAdauga = null;
            TreeGridNode NodSubCategorie = null;

            var listaSubcategorii = BCategorii.GetListByParamSubcategorii(pCategorie.Id, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

            if (pCategorie != null)
            {
                TreeGridView.InitCelulaEditare(NodCategorie, this.lEcranInModificare);
                NodCategorie.Cells[EnumColTGV.colDenumire.ToString()].Value = pCategorie.Denumire;
                NodCategorie.DefaultCellStyle.Font = new Font(this.tgvListaCategorii.Font, FontStyle.Bold);
                NodCategorie.Cells[EnumColTGV.colCuloare.ToString()].Style.BackColor = BDefinitiiGenerale.getCuloareDinARGB(pCategorie.Culoare);
                NodCategorie.Cells[EnumColTGV.colCuloare.ToString()].Tag = pCategorie.Culoare;
                TreeGridView.InitCelulaStergere(NodCategorie);

                NodAdauga = NodCategorie.CreazaNod(-1);
                incarcaRandAdaugaSubcategorie(NodAdauga, pCategorie);

                if (listaSubcategorii.Count > 0)
                {
                    foreach (var subcategorie in listaSubcategorii)
                    {
                        NodSubCategorie = NodCategorie.CreazaNod(-1);
                        incarcaRandSubcategorie(NodSubCategorie, subcategorie);
                    }
                }
            }

            NodCategorie.Expand();
        }

        private void incarcaRandAdaugaSubcategorie(TreeGridNode randTGV, BCategorii pCategorie)
        {
            randTGV.Tag = 1;
            randTGV.DefaultCellStyle.ForeColor = Color.BlueViolet;
            randTGV.Cells[2].Value = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.AdaugaSubcategorie);

        }

        private void incarcaRandSubcategorie(TreeGridNode randTGV, BCategorii pCategorie)
        {
            randTGV.Tag = pCategorie;
            randTGV.Cells[2].Value = pCategorie.Denumire;
        }


        #endregion

        #region Metode publice



        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
        }

        #endregion


    }
}
