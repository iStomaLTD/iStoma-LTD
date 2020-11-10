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
using CCL.UI;
using BLL.iStomaLab;
using BLL.iStomaLab.Referinta;
using static CCL.UI.ComboBoxPersonalizat;
using CDL.iStomaLab;

namespace iStomaLab.Setari.Liste.ListeParametrabile
{
    public partial class ControlListaParametrabila : UserControlPersonalizat
    {

        #region Declaratii generale

        private CDL.iStomaLab.CDefinitiiComune.EnumTipLista lTipLista = CDL.iStomaLab.CDefinitiiComune.EnumTipLista.AltePersoane;

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colDenumire,
            colDataCreare
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlListaParametrabila()
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
            this.dgvListaParametrabila.EditareLinie += DgvListaParametrabila_EditareLinie;
            this.dgvListaParametrabila.StergereLinie += DgvListaParametrabila_StergereLinie;
            this.txtCautareLista.CerereUpdate += TxtCautareLista_CerereUpdate;
            this.btnAdaugare.Click += BtnAdaugare_Click;
            this.btnActiviInactivi.Click += BtnActiviInactivi_Click;
        }
        
        private void initTextML()
        {

        }

        public void Initializeaza(CDL.iStomaLab.CDefinitiiComune.EnumTipLista pTipLista)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();
            this.lTipLista = pTipLista;

            this.txtCautareLista.Goleste();
            this.btnActiviInactivi.Selectat = false;

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void BtnActiviInactivi_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                ConstruiesteRanduriDGV();
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

        private void BtnAdaugare_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                string denumire = CCL.UI.IHMUtile.GetTextSimpluUtilizator(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire), BListeParametrabile.StructCampuriTabela.DenumireMaxLength);

                if (!string.IsNullOrEmpty(denumire))
                {
                    BListeParametrabile.Add(this.lTipLista, denumire, null);
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

        private void TxtCautareLista_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvListaParametrabila.FiltreazaDupaText(this.txtCautareLista.Text);
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

        private void DgvListaParametrabila_StergereLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BListeParametrabile parametruDeSters = this.dgvListaParametrabila.Rows[pIndexRand].Tag as BListeParametrabile;

                if (parametruDeSters != null)
                {
                    
                    if (!this.btnActiviInactivi.Selectat)
                    {
                        if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmareInchidere), parametruDeSters.Denumire))
                        {
                            parametruDeSters.Close(true, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Inchidere), null);
                            ConstruiesteRanduriDGV();
                        }
                    }
                    else
                    {
                        if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiReactivarea), parametruDeSters.Denumire))
                        {
                            parametruDeSters.Close(false, string.Empty, null);
                            ConstruiesteRanduriDGV();
                        }
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

        private void DgvListaParametrabila_EditareLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BListeParametrabile elem = this.dgvListaParametrabila.Rows[pIndexRand].Tag as BListeParametrabile;

                if (elem != null && !this.btnActiviInactivi.Selectat)
                {
                    string denumire = CCL.UI.IHMUtile.GetTextSimpluUtilizator(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire), elem.Denumire, BListeParametrabile.StructCampuriTabela.DenumireMaxLength);

                    if (!string.IsNullOrEmpty(denumire) && !elem.Denumire.Equals(denumire))
                    {
                        elem.Denumire = denumire;
                        elem.UpdateAll();

                        incarcaRand(this.dgvListaParametrabila.Rows[pIndexRand], elem);
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

        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaParametrabila.IncepeConstructieColoane();

            this.dgvListaParametrabila.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvListaParametrabila.AdaugaColoanaText(EnumColoaneDGV.colDenumire.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaParametrabila.AdaugaColoanaData(EnumColoaneDGV.colDataCreare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataCreare), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA_ORA);

            this.dgvListaParametrabila.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvListaParametrabila.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            var listaElem = BListeParametrabile.GetListByParam(this.lTipLista, CDL.iStomaLab.CDefinitiiComune.EnumStare.Toate, null);

            if (listaElem.ContineElementeDeactivate())
            {
                this.btnActiviInactivi.Visible = true;
            }
            else
            {
                this.btnActiviInactivi.Visible = false;
                this.btnActiviInactivi.Selectat = false;
            }


            if (!this.btnActiviInactivi.Selectat)
                ConstruiesteRanduriDGV(listaElem.GetListaActive());
            else
                ConstruiesteRanduriDGV(listaElem.GetListaInactive());
        }

        private void ConstruiesteRanduriDGV(BColectieListeParametrabile pLista)
        {
            this.dgvListaParametrabila.IncepeContructieRanduri();
            
            foreach (var elem in pLista)
            {
                incarcaRand(this.dgvListaParametrabila.Rows[this.dgvListaParametrabila.Rows.Add()], elem);
            }

            this.dgvListaParametrabila.FinalizeazaContructieRanduri();

            this.lblTotalLista.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Total) + this.dgvListaParametrabila.RowCount.ToString();
        }

        private void incarcaRand(DataGridViewRow pRand, BListeParametrabile pElem)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);
            pRand.Cells[EnumColoaneDGV.colDenumire.ToString()].Value = pElem.Denumire;
            pRand.Cells[EnumColoaneDGV.colDataCreare.ToString()].Value = pElem.DataCreare;
            DataGridViewPersonalizat.InitCelulaStergere(pRand);

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
