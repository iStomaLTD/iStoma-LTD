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
using BLL.iStomaLab.Locatii;
using CCL.UI;
using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;

namespace iStomaLab.Setari.Locatii
{
    public partial class ControlListaLocatii : UserControlPersonalizat
    {

        #region Declaratii generale


        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colDenumire,
            //colInitiala,
            colDenumireFiscala,
            colInfoContact,
            colSerieFacturi,
            colNumarulUltimeiFacturi,
            colSerieChitante,
            colNumarulUltimeiChitante,
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlListaLocatii()
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
            this.btnAdaugaLocatie.Click += BtnAdaugaLocatie_Click;
            this.dgvListaLocatii.StergereLinie += DgvListaLocatii_StergereLinie;
            this.dgvListaLocatii.EditareLinie += DgvListaLocatii_EditareLinie;
            this.txtCautaLocatie.CerereUpdate += TxtCautaLocatie_CerereUpdate;
            this.btnActiviInactivi.Click += BtnActiviInactivi_Click;
        }

        private void initTextML()
        {
            this.lblTitluListaLocatii.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Locatie);
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.txtCautaLocatie.Goleste();

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

        private void TxtCautaLocatie_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvListaLocatii.FiltreazaDupaText(this.txtCautaLocatie.Text);
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

        private void DgvListaLocatii_EditareLinie(CCL.UI.DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BLocatii locatieDeModificat = this.dgvListaLocatii.Rows[pIndexRand].Tag as BLocatii;

                if (locatieDeModificat != null && !this.btnActiviInactivi.Selectat)
                {
                    if (FormDetaliuLocatie.Afiseaza(this.GetFormParinte(), locatieDeModificat))
                    {
                        incarcaRand(this.dgvListaLocatii.Rows[pIndexRand], locatieDeModificat);
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

        private void DgvListaLocatii_StergereLinie(CCL.UI.DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BLocatii locatieDeSters = this.dgvListaLocatii.Rows[pIndexRand].Tag as BLocatii;

                if (locatieDeSters != null)
                {

                    if (!this.btnActiviInactivi.Selectat)
                    {
                        if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), locatieDeSters.Denumire))
                        {
                            locatieDeSters.Close(true, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stergere), null);
                            ConstruiesteRanduriDGV();
                        }
                    }
                    else
                    {
                        if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiReactivarea), locatieDeSters.Denumire))
                        {
                            locatieDeSters.Close(false, string.Empty, null);
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

        private void BtnAdaugaLocatie_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (FormDetaliuLocatie.Afiseaza(this.GetFormParinte(), null))
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

        #endregion

        #region Metode private

        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaLocatii.IncepeConstructieColoane();

            this.dgvListaLocatii.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvListaLocatii.AdaugaColoanaText(EnumColoaneDGV.colDenumire.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaLocatii.AdaugaColoanaText(EnumColoaneDGV.colDenumireFiscala.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DenumireFiscala), 130, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaLocatii.AdaugaColoanaText(EnumColoaneDGV.colSerieFacturi.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.SerieFacturi), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaLocatii.AdaugaColoanaText(EnumColoaneDGV.colNumarulUltimeiFacturi.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrUltimaFactura), 140, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaLocatii.AdaugaColoanaText(EnumColoaneDGV.colSerieChitante.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.SerieChitante), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaLocatii.AdaugaColoanaText(EnumColoaneDGV.colNumarulUltimeiChitante.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrUltimaChitanta), 140, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaLocatii.AdaugaColoanaText(EnumColoaneDGV.colInfoContact.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.InfoContact), 100, true, DataGridViewColumnSortMode.Automatic);

            //this.dgvListaLocatii.AdaugaColoanaText(EnumColoaneDGV.colInitiala.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Initiala), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaLocatii.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvListaLocatii.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            var listaElem = BLocatii.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Toate, null);

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

        private void ConstruiesteRanduriDGV(BColectieLocatii pListaLocatii)
        {
            this.dgvListaLocatii.IncepeContructieRanduri();

            foreach (var elem in pListaLocatii)
            {
                incarcaRand(this.dgvListaLocatii.Rows[this.dgvListaLocatii.Rows.Add()], elem);
            }

            this.dgvListaLocatii.FinalizeazaContructieRanduri();

            this.lblTotalLocatii.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Total) + this.dgvListaLocatii.RowCount.ToString();
        }

        private void incarcaRand(DataGridViewRow pRand, BLocatii pElem)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);
            pRand.Cells[EnumColoaneDGV.colDenumire.ToString()].Value = pElem.Denumire;
            //pRand.Cells[EnumColoaneDGV.colInitiala.ToString()].Value = pElem.InitialaLocatie;
            pRand.Cells[EnumColoaneDGV.colDenumireFiscala.ToString()].Value = pElem.DenumireFiscala;
            pRand.Cells[EnumColoaneDGV.colInfoContact.ToString()].Value = pElem.InfoContact;

            pRand.Cells[EnumColoaneDGV.colSerieFacturi.ToString()].Value = pElem.SerieFacturi;
            pRand.Cells[EnumColoaneDGV.colNumarulUltimeiFacturi.ToString()].Value = pElem.NumarUltimaFactura;

            pRand.Cells[EnumColoaneDGV.colSerieChitante.ToString()].Value = pElem.SerieChitante;
            pRand.Cells[EnumColoaneDGV.colNumarulUltimeiChitante.ToString()].Value = pElem.NumarUltimaChitanta;

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
