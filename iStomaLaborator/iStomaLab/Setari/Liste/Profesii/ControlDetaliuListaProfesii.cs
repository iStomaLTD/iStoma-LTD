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
using BLL.iStomaLab.Referinta;
using BLL.iStomaLab;
using CDL.iStomaLab;
using CCL.UI;

namespace iStomaLab.Setari.Liste
{
    public partial class ControlDetaliuLista : UserControlPersonalizat
    {

        #region Declaratii generale


        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colDenumire,
            colCodCOR
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlDetaliuLista()
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
            this.btnAdaugaProfesie.Click += BtnAdaugaProfesie_Click;
            this.txtCautareProfesie.CerereUpdate += TxtCautareProfesie_CerereUpdate;
            this.dgvListaProfesii.EditareLinie += DgvListaProfesii_EditareLinie;
            this.dgvListaProfesii.StergereLinie += DgvListaProfesii_StergereLinie;
            this.btnActiviInactivi.Click += BtnActiviInactivi_Click;
        }
        
        private void initTextML()
        {
            this.lblTitluLista.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Profesii);
            this.lblTotalProfesie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Total);
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.txtCautareProfesie.Goleste();
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

        private void TxtCautareProfesie_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvListaProfesii.FiltreazaDupaText(this.txtCautareProfesie.Text);
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

        private void BtnAdaugaProfesie_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (Setari.Liste.FormAdaugareInLista.Afiseaza(this.GetFormParinte(), null))
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

        private void DgvListaProfesii_EditareLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BProfesii profesieDeModificat = this.dgvListaProfesii.Rows[pIndexRand].Tag as BProfesii;

                if (profesieDeModificat != null && !this.btnActiviInactivi.Selectat)
                {
                    if (FormAdaugareInLista.Afiseaza(this.GetFormParinte(), profesieDeModificat))
                    {
                        incarcaRand(this.dgvListaProfesii.Rows[pIndexRand], profesieDeModificat);
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

        private void DgvListaProfesii_StergereLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BProfesii profesieDeSters = this.dgvListaProfesii.Rows[pIndexRand].Tag as BProfesii;

                if (profesieDeSters != null)
                {
                    if (!this.btnActiviInactivi.Selectat)
                    {
                        if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), profesieDeSters.Denumire))
                        {
                            profesieDeSters.Close(true, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stergere), null);
                            ConstruiesteRanduriDGV();
                        }
                    }
                    else
                    {
                        if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiReactivarea), profesieDeSters.Denumire))
                        {
                            profesieDeSters.Close(false, string.Empty, null);
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

        #endregion

        #region Metode private

        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaProfesii.IncepeConstructieColoane();

            this.dgvListaProfesii.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvListaProfesii.AdaugaColoanaText(EnumColoaneDGV.colDenumire.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaProfesii.AdaugaColoanaText(EnumColoaneDGV.colCodCOR.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CodCOR), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaProfesii.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvListaProfesii.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            var listaElem = BProfesii.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Toate, null);

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

        private void ConstruiesteRanduriDGV(BColectieProfesii pListaProfesii)
        {
            this.dgvListaProfesii.IncepeContructieRanduri();
            
            foreach (var elem in pListaProfesii)
            {
                incarcaRand(this.dgvListaProfesii.Rows[this.dgvListaProfesii.Rows.Add()], elem);
            }

            this.dgvListaProfesii.FinalizeazaContructieRanduri();

            int totalProfesii = this.dgvListaProfesii.RowCount;

            if (totalProfesii == 1)
            {
                this.lblTotalProfesie.Text = totalProfesii.ToString() + BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ElementGasit);
            }
            else
            {
                this.lblTotalProfesie.Text = totalProfesii.ToString() + BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ElementeGasite);
            }

        }

        private void incarcaRand(DataGridViewRow pRand, BProfesii pElem)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);
            pRand.Cells[EnumColoaneDGV.colDenumire.ToString()].Value = pElem.Denumire;
            pRand.Cells[EnumColoaneDGV.colCodCOR.ToString()].Value = pElem.CodCOR;
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
