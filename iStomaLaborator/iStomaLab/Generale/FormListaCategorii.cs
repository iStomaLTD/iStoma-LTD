using BLL.iStomaLab.Referinta;
using CCL.UI;
using CCL.UI.FormulareComune;
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
    public partial class FormListaCategorii : frmCuHeader
    {
        #region Declaratii generale

        private BCategorii lCategorie = null;
        private int lIdCategorieParinte = 0;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormListaCategorii(int pIdCategorieParinte)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lIdCategorieParinte = pIdCategorieParinte;

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {

                adaugaHandlere();
                initTextML();

                this.CenterToScreen();
                this.PermiteDeplasareaEcranului = true;
            }
        }

        private void adaugaHandlere()
        {
            this.Load += _Load;
            this.dgvListaCategorii.SelectieUnicaEfectuata += DgvListaCategorii_SelectieUnicaEfectuata;
            this.btnAdauga.Click += BtnAdauga_Click;
            this.txtCauta.CerereUpdate += TxtCauta_CerereUpdate;
        }

        private void initTextML()
        {
            if (this.lIdCategorieParinte > 0)
                this.Text = BCategorii.GetDenumireById(this.lIdCategorieParinte);
            else
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
            incepeIncarcarea();

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            this.txtCauta.Goleste();

            this.dgvListaCategorii.ColumnHeadersVisible = false;
            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void TxtCauta_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvListaCategorii.FiltreazaDupaText(this.txtCauta.Text);
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

        private void BtnAdauga_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BCategorii categParinte = null;
                if (this.lIdCategorieParinte > 0)
                    categParinte = BCategorii.getCategorieById(this.lIdCategorieParinte, null);

                if (Setari.Liste.Categorii.FormDetaliiCategorie.Afiseaza(this, categParinte, false))
                {
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

        private void DgvListaCategorii_SelectieUnicaEfectuata(object sender, DataGridViewCellEventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BCategorii categorie = this.dgvListaCategorii.Rows[this.dgvListaCategorii.CurrentCell.RowIndex].Tag as BCategorii;

                if (categorie != null)
                {
                    this.lCategorie = categorie;
                    this.inchideEcranulOK();
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

        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaCategorii.IncepeConstructieColoane();

            this.dgvListaCategorii.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.SelectieUnica);

            this.dgvListaCategorii.AdaugaColoanaText(null, null, 0, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaCategorii.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaCategorii.IncepeContructieRanduri();
            BColectieCategorii listaElem = null;

            if (this.lIdCategorieParinte <= 0)
            {
                listaElem = BCategorii.GetListByParamCategorii(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);
            }
            else
            {
                listaElem = BCategorii.GetListByParamSubcategorii(this.lIdCategorieParinte, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);
            }

            foreach (var elem in listaElem)
            {
                incarcaRand(this.dgvListaCategorii.Rows[this.dgvListaCategorii.Rows.Add()], elem);
            }

            this.dgvListaCategorii.FinalizeazaContructieRanduri();

            this.lblNrElemente.Text = listaElem.Count + " elemente";
        }

        private void incarcaRand(DataGridViewRow pRand, BCategorii pElem)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaSelectieUnica(pRand, true);
            pRand.Cells[1].Value = pElem.Denumire;
        }

        #endregion

        #region Metode publice

        public static BCategorii Afiseaza(Form pEcranPariente, int pIdCategorieParinte)
        {
            using (FormListaCategorii ecran = new FormListaCategorii(pIdCategorieParinte))
            {
                CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
                return ecran.lCategorie;
            }
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
        }

        #endregion
    }
}
