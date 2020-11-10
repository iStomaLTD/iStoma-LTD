using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iStomaLab.Generale;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab;
using static iStomaLab.Setari.Lucrari.ControlListaDePreturiClienti;
using CCL.UI;
using CDL.iStomaLab;

namespace iStomaLab.Rapoarte
{
    public partial class ControlRaportClientiNoi : UserControlPersonalizat
    {

        #region Declaratii generale


        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colDenumire,
            colDataCreare,
            colObservatii,
            colStare,
            colTotalLucrari,
            colSold,
            colTotalFacturi,
            colTotalIncasari,
            colDeschideDosar
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlRaportClientiNoi()
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
            this.ctrlPerioada.PerioadaSchimbata += CtrlPerioada_PerioadaSchimbata;
            this.txtCautare.CerereUpdate += TxtCautare_CerereUpdate;
            this.dgvLista.CellClick += DgvLista_CellClick;
            this.dgvLista.CereRefresh += DgvLista_CereRefresh;
        }

        private void initTextML()
        {

        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.ctrlPerioada.Initializeaza(CDL.iStomaLab.CDefinitiiComune.EnumTipPerioada.Saptamana, DateTime.Today);
            this.txtCautare.Goleste();
            this.lblTitlu.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ClientiNoi);

            ConstruiesteColoaneDGV();

            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void CtrlPerioada_PerioadaSchimbata(object sender, EventArgs e)
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

        private void TxtCautare_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare) 
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                filtreazaDupaText();
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

        private void DgvLista_CereRefresh(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                ConstruiesteColoaneDGV();

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

        private void DgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.lSeIncarca || e.RowIndex < 0) return;
            try
            {
                incepeIncarcarea();

                string denumireColoanaSelectata = this.dgvLista.Columns[e.ColumnIndex].Name;

                if (this.dgvLista.SelectedRow != null)
                {
                    BClienti client = this.dgvLista.SelectedRow.Tag as BClienti;

                    if (client != null)
                    {
                        if (denumireColoanaSelectata.Equals(EnumColoaneDGV.colDeschideDosar.ToString()))
                        {
                            if (TablouDeBord.Clienti.FormDosarClient.Afiseaza(this.GetFormParinte(), client))
                                incarcaRand(this.dgvLista.SelectedRow, client, client.GetUltimaLucrare(null), client.GetUltimaFactura(null), client.GetListaLucrari(null).Count(), client.GetTotalFacturi(null), client.GetTotalIncasari(null));
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

        private void filtreazaDupaText()
        {
            setNrLinii(this.dgvLista.FiltreazaDupaText(this.txtCautare.Text));
        }

        private void setNrLinii(int pNrLinii)
        {
            BClienti client = null;
            foreach (DataGridViewRow rand in this.dgvLista.Rows)
            {
                if (rand.Visible)
                {
                    client = rand.Tag as BClienti;
                }
            }

            this.lblTotal.Text = string.Format("{0}: {1}",
              BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Lucrari),
              pNrLinii);
        }
        
        private void ConstruiesteColoaneDGV()
        {
            this.dgvLista.IncepeConstructieColoane();

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colDataCreare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataCreare), 150, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colDenumire.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire), 200, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaButonClasic(EnumColoaneDGV.colDeschideDosar.ToString(), string.Empty, string.Empty, 40, false);

            this.dgvLista.AdaugaColoaneTelefonEmail();

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colObservatii.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii), 200, true, DataGridViewColumnSortMode.Automatic);

            IHMUtile.AdaugaColoanaUltimaLucrare(this.dgvLista);

            IHMUtile.AdaugaColoanaUltimaFactura(this.dgvLista);

            this.dgvLista.AdaugaColoanaNumerica(EnumColoaneDGV.colTotalLucrari.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TotalLucrari), 150, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colTotalFacturi.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TotalFacturi), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colTotalIncasari.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TotalIncasari), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colSold.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Sold), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvLista.IncepeContructieRanduri();
            
            BColectieClienti listaElem = BClienti.GetListaClientiNoiPerioada(this.ctrlPerioada.DataInceput, this.ctrlPerioada.DataSfarsit, null);
            List<int> listaIdClinici = listaElem.GetListaId();

            BColectieClientiComenzi listaUltimelorLucrari = BClientiComenzi.GetUltimeleLucrariPerClinica(listaIdClinici, null);
            BColectieClientiFacturi listaUltimelorFacturi = BClientiFacturi.GetUltimeleFacturiPerClinica(listaIdClinici, null);

            Dictionary<int, double> dictIdClinicaTotalFacturi = BClientiFacturi.GetDictIdClinicaTotalFacturi(listaIdClinici, null);
            Dictionary<int, double> dictIdClinicaTotalIncasari = BClientiPlati.GetDictIdClinicaTotalIncasari(listaIdClinici, null);

            Dictionary<int, int> dictIdClinicaNrLucrari = BClientiComenzi.GetDictIdClinicaNrLucrari(listaIdClinici, null);

            int idTemp = 0;
            double totalFact = 0;
            double totalInc = 0;
            foreach (var elem in listaElem)
            {
                idTemp = elem.Id;

                if (dictIdClinicaTotalFacturi.ContainsKey(idTemp))
                    totalFact = dictIdClinicaTotalFacturi[idTemp];
                else
                    totalFact = 0;

                if (dictIdClinicaTotalIncasari.ContainsKey(idTemp))
                    totalInc = dictIdClinicaTotalIncasari[idTemp];
                else
                    totalInc = 0;

                incarcaRand(this.dgvLista.AdaugaRandNou(), elem, listaUltimelorLucrari.GetUltimaByIdClient(elem.Id), listaUltimelorFacturi.GetUltimaByIdClient(elem.Id), dictIdClinicaNrLucrari.ContainsKey(elem.Id) ? dictIdClinicaNrLucrari[elem.Id] : 0, totalFact, totalInc);
            }

            this.dgvLista.FinalizeazaContructieRanduri();

            this.lblTotal.Text = string.Format("{0}: {1}", BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ClientiNoi), this.dgvLista.RowCount.ToString());
        }

        private void incarcaRand(DataGridViewRow pRand, BClienti pClienti, BClientiComenzi pUltimaLucrare, BClientiFacturi pUltimaFactura, int pNrLucrari, double pTotalFacturi, double pTotalIncasari)      
        {
            pRand.Tag = pClienti;
            pRand.Cells[EnumColoaneDGV.colDataCreare.ToString()].Value = pClienti.DataCreare;
            pRand.Cells[EnumColoaneDGV.colDenumire.ToString()].Value = pClienti.Denumire;
            DataGridViewPersonalizat.InitCelulaDeschideClasic(pRand, EnumColoaneDGV.colDeschideDosar.ToString());
            DataGridViewPersonalizat.InitCeluleTelefonEmail(pRand, pClienti.TelefonMobil, pClienti.AdresaMail);
            pRand.Cells[EnumColoaneDGV.colObservatii.ToString()].Value = pClienti.ObservatiiDateClinica;
            IHMUtile.IncarcaRandUltimaLucrare(pRand, pUltimaLucrare);
            IHMUtile.IncarcaRandUltimaFactura(pRand, pUltimaFactura);
            DataGridViewPersonalizat.InitCelulaValoareNumerica(pRand, EnumColoaneDGV.colTotalLucrari.ToString(), pNrLucrari);
            DataGridViewPersonalizat.InitCelulaValoareMonetara(pRand, EnumColoaneDGV.colTotalFacturi.ToString(), pTotalFacturi);
            DataGridViewPersonalizat.InitCelulaValoareMonetara(pRand, EnumColoaneDGV.colTotalIncasari.ToString(), pTotalIncasari);
            DataGridViewPersonalizat.InitCelulaValoareMonetara(pRand, EnumColoaneDGV.colSold.ToString(), pTotalIncasari - pTotalFacturi);
            DataGridViewPersonalizat.SeteazaAlerta(pRand, EnumColoaneDGV.colSold.ToString());
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
