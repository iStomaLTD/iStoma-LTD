using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iStomaLab.Generale;
using BLL.iStomaLab.Utilizatori;
using CCL.iStomaLab;
using CCL.UI;
using BLL.iStomaLab.Comune;
using static BLL.iStomaLab.Utilizatori.BUtilizatorDrepturi;

namespace iStomaLab.Setari.Personal
{
    public partial class ControlUtilizatorDrepturi : UserControlPersonalizat
    {

        #region Declaratii generale

        private BUtilizator lUtilizator = null;
        //private StructOptiuni lListeOptiuni = StructOptiuni.Empty;
        private List<StructOptiuni> lListeOptiuni = new List<StructOptiuni>();

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlUtilizatorDrepturi()
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
            this.txtCautaOptiuniDrepturi.CerereUpdate += TxtCautareOptiuniDrepturi_CerereUpdate;
            this.txtCautareListaSelectata.CerereUpdate += TxtCautareListaSelectata_CerereUpdate;
            this.btnInapoi.Click += btnInapoi_Click;
            this.btnInainte.Click += btnInainte_Click;
            //this.dgvListaOptiuniDrepturi.CellClick += DgvListaOptiuniDrepturi_CellClick;
        }

        private void initTextML()
        {

        }

        public void Initializeaza(BUtilizator pUtilizator)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.txtCautaOptiuniDrepturi.Goleste();
            this.txtCautareListaSelectata.Goleste();

            this.lUtilizator = pUtilizator;

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            ConstruiesteColoaneDGVListaSelectata();
            ConstruiesteRanduriDGVListaSelectata();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void TxtCautareOptiuniDrepturi_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvListaOptiuniDrepturi.FiltreazaDupaText(this.txtCautaOptiuniDrepturi.Text);
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

        private void TxtCautareListaSelectata_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvListaSelectata.FiltreazaDupaText(this.txtCautareListaSelectata.Text);
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

        //private void DgvListaOptiuniDrepturi_CellClick(object sender, DataGridViewCellEventArgs e)
        //{

        //    if (this.lSeIncarca || e.RowIndex < 0) return;
        //    try
        //    {
        //        incepeIncarcarea();

        //        ConstruiesteRanduriDGV();

        //    }
        //    catch (Exception ex)
        //    {
        //        GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
        //    }
        //    finally
        //    {
        //        finalizeazaIncarcarea();
        //    }

        //}


        private void btnInapoi_Click(object sender, EventArgs e)
        {
            try
            {
                incepeIncarcarea();

                if (!lUtilizator.EsteADMIN())
                {
                    BColectieUtilizatorDrepturi listaDrepturiSterse = this.dgvListaSelectata.GetListaObiecteBifate<BColectieUtilizatorDrepturi, BUtilizatorDrepturi>();
                    listaDrepturiSterse.Delete(null);
                }
                
                ConstruiesteRanduriDGVListaSelectata();
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

        private void btnInainte_Click(object sender, EventArgs e)
        {
            try
            {
                incepeIncarcarea();

                if (!lUtilizator.EsteADMIN())
                {
                    this.lListeOptiuni = this.dgvListaOptiuniDrepturi.GetListaObiecteBifate<List<StructOptiuni>, StructOptiuni>();
                    BUtilizatorDrepturi.Add(this.lUtilizator.Id, this.lListeOptiuni, null);
                }

                ConstruiesteRanduriDGVListaSelectata();

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
            this.dgvListaOptiuniDrepturi.IncepeConstructieColoane();
            this.dgvListaOptiuniDrepturi.EditMode = DataGridViewEditMode.EditOnEnter;

            this.dgvListaOptiuniDrepturi.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.SelectieMultipla);

            this.dgvListaOptiuniDrepturi.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Denumire);

            this.dgvListaOptiuniDrepturi.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteColoaneDGVListaSelectata()
        {
            this.dgvListaSelectata.IncepeConstructieColoane();
            this.dgvListaSelectata.EditMode = DataGridViewEditMode.EditOnEnter;

            this.dgvListaSelectata.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.SelectieMultipla);

            this.dgvListaSelectata.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Denumire);

            this.dgvListaSelectata.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaOptiuniDrepturi.IncepeContructieRanduri();

            var listaElem = StructOptiuni.GetList();

            //Incarcam lista
            foreach (var elem in listaElem)
            {
                incarcaRand(this.dgvListaOptiuniDrepturi.AdaugaRandNou(), elem);
            }

            this.dgvListaOptiuniDrepturi.FinalizeazaContructieRanduri();
        }

        private void ConstruiesteRanduriDGVListaSelectata()
        {
            this.dgvListaSelectata.IncepeContructieRanduri();

            var listaElem = BUtilizatorDrepturi.GetListByParam(EnumRubrica.Nedefinit, EnumOptiune.Nedefinit, this.lUtilizator.Id, null);

            foreach (var elem in listaElem)
            {
                incarcaRandListaSelectata(this.dgvListaSelectata.Rows[this.dgvListaSelectata.Rows.Add()], elem);
            }

            this.dgvListaSelectata.FinalizeazaContructieRanduri();
        }

        private void incarcaRand(DataGridViewRow pRand, StructOptiuni pElem)
        {
            pRand.Tag = pElem;

            this.dgvListaOptiuniDrepturi.InitCelulaDenumire(pRand, pElem.Denumire);
        }

        private void incarcaRandListaSelectata(DataGridViewRow pRand, BUtilizatorDrepturi pElem)
        {
            pRand.Tag = pElem;
            this.dgvListaSelectata.InitCelulaDenumire(pRand, pElem.DenumireAfisaj);
        }



        #endregion

        #region Metode publice



        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;

            this.dgvListaOptiuniDrepturi.AllowModification(this.lEcranInModificare);
            this.dgvListaSelectata.AllowModification(this.lEcranInModificare);
            this.btnInainte.AllowModification(this.lEcranInModificare);
            this.btnInapoi.AllowModification(this.lEcranInModificare);
        }

        #endregion


    }
}
