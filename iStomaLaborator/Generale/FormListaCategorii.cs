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

        public static BCategorii _SCategorie = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormListaCategorii()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

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
            ConstruiesteRanduriDGV(_SCategorie);

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
                if (Setari.Liste.Categorii.FormDetaliiCategorie.Afiseaza(this,null, false))
                {
                    ConstruiesteRanduriDGV(null);
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
                    _SCategorie = categorie;
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

        private void ConstruiesteRanduriDGV(BCategorii pCategorie)
        {
            this.dgvListaCategorii.IncepeContructieRanduri();
            BColectieCategorii listaElem = null;

            if (pCategorie == null)
            {
                listaElem = BCategorii.GetListByParamCategorii(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);
            }
            else
            {
                listaElem = BCategorii.GetListByParamSubcategorii(pCategorie.Id, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);
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

        public static bool Afiseaza(Form pEcranPariente)
        {
            using (FormListaCategorii ecran = new FormListaCategorii())
            {
                return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
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
