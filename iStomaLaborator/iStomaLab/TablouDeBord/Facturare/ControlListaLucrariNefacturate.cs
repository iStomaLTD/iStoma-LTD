using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iStomaLab.Generale;
using CDL.iStomaLab;
using CCL.UI;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab;
using CCL.iStomaLab;

namespace iStomaLab.TablouDeBord.Facturare
{
    public partial class ControlListaLucrariNefacturate : UserControlPersonalizat
    {

        #region Declaratii generale


        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colDataPrimire,
            colClinica,
            colMedic,
            colCabinet,
            colLucrare,
            colNrElemente,
            colEtapaCurenta,
            colStareEtapa,
            colValoare,
            colMoneda,
            colDataLaGata,
            colTehnician,
            colPacient,
            colDetaliiClinica,
            colDetaliiFisa,
            colCodComanda,
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlListaLucrariNefacturate()
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
            this.ctrlCautareClinica.CerereUpdate += CtrlCautareClinica_CerereUpdate;
            this.txtCautare.CerereUpdate += TxtCautare_CerereUpdate;
            this.btnFactureaza.Click += BtnAchita_Click;
            this.ctrlPerioada.PerioadaSchimbata += CtrlPerioada_PerioadaSchimbata;
            this.dgvLista.CellClick += DgvLista_CellClick;
            this.dgvLista.CereRefresh += DgvLista_CereRefresh;

            this.ctrlDataInteres.CerereUpdate += CtrlDataInteres_CerereUpdate;
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

        private void initTextML()
        {
            this.btnFactureaza.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Factureaza);
            this.lblClinica.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Clinica);
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.txtCautare.Goleste();
            this.ctrlPerioada.Initializeaza(CDefinitiiComune.EnumTipPerioada.Luna, DateTime.Now);
            this.ctrlDataInteres.Initializeaza();

            this.btnOptiuni.Initializeaza(this.panelOptiuni);
            this.btnInchidePanelOptiuni.Initializeaza(this.panelOptiuni);
            this.panelOptiuni.Initializeaza();

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void CtrlDataInteres_CerereUpdate(object sender, EventArgs e)
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

        private void DgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.lSeIncarca || e.RowIndex < 0) return;
            try
            {
                incepeIncarcarea();

                string numeColoana = this.dgvLista.Columns[e.ColumnIndex].Name;

                BClientiComenzi fisa = this.dgvLista.Rows[e.RowIndex].Tag as BClientiComenzi;

                if (numeColoana.Equals(EnumColoaneDGV.colDetaliiClinica.ToString()))
                {
                    IHMUtile.DeschideDosarClient(this.GetFormParinte(), fisa.IdClient);
                }
                else
                {
                    if (numeColoana.Equals(EnumColoaneDGV.colDetaliiFisa.ToString()))
                    {
                        IHMUtile.DeschideComanda(this.GetFormParinte(), fisa.Id);
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

        private void BtnAchita_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BColectieClientiComenzi listaLucrari = this.dgvLista.GetListaObiecteBifate<BColectieClientiComenzi, BClientiComenzi>();

                BClienti client = this.ctrlCautareClinica.GetClient();
                if (client == null)
                {
                    if (this.dgvLista.SelectedRows.Count == 1)
                    {
                        BClientiComenzi comanda = this.dgvLista.SelectedRow.Tag as BClientiComenzi;
                        client = BClienti.getClient(comanda.IdClient, null);
                    }
                    else
                    {
                        int idClient = listaLucrari.GetIdClientDinLista();
                        if (idClient != 0)
                            client = BClienti.getClient(idClient, null);
                    }
                }

                if (FormCreeazaFacturaClient.Afiseaza(this.GetFormParinte(), client, listaLucrari, null))
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

        private void CtrlCautareClinica_CerereUpdate(object sender, EventArgs e)
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

        #endregion

        #region Metode private

        private void filtreazaDupaText()
        {
            setNrLinii(this.dgvLista.FiltreazaDupaText(this.txtCautare.Text));
        }

        private void setNrLinii(int pNrLinii)
        {
            double totalRON = 0;
            double totalEUR = 0;

            BClientiComenzi lucrare = null;
            foreach (DataGridViewRow rand in this.dgvLista.Rows)
            {
                if (rand.Visible)
                {
                    lucrare = rand.Tag as BClientiComenzi;

                    if (lucrare.Moneda == CDefinitiiComune.EnumTipMoneda.Euro)
                        totalEUR += lucrare.ValoareFinala;
                    else
                        totalRON += lucrare.ValoareFinala;
                }
            }

            this.lblTotal.Text = string.Format("{0}: {1} [{2}: {3}]",
                BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Comenzi),
                pNrLinii,
                BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Total),
               CUtil.getValoareMonetaraLeiPlusEuro(totalRON, totalEUR));
        }

        private void ConstruiesteColoaneDGV()
        {
            this.dgvLista.IncepeConstructieColoane();

            this.dgvLista.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.SelectieMultipla);

            this.dgvLista.AdaugaColoanaData(EnumColoaneDGV.colDataPrimire.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataPrimire), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colCodComanda.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CodComanda), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colClinica.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Clinica), 130, true, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaButonClasic(EnumColoaneDGV.colDetaliiClinica.ToString(), string.Empty, string.Empty, 30, false);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colMedic.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Medic), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colCabinet.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Cabinet), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colPacient.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pacient), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colLucrare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Lucrare), 130, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaNumerica(EnumColoaneDGV.colNrElemente.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrElem), 50, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaButonClasic(EnumColoaneDGV.colDetaliiFisa.ToString(), string.Empty, string.Empty, 30, false);

            this.dgvLista.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colValoare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Valoare), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colMoneda.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Moneda), 70, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaData(EnumColoaneDGV.colDataLaGata.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataLaGata), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colEtapaCurenta.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.EtapaCurenta), 70, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colStareEtapa.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stare), 70, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colTehnician.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tehnician), 70, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvLista.IncepeContructieRanduri();

            BColectieClientiComenzi listaElem = null;

            listaElem = BClientiComenzi.GetListaLucrariNefacturate(this.ctrlCautareClinica.GetIdClinica(), this.ctrlPerioada.DataInceput, this.ctrlPerioada.DataSfarsit, this.ctrlDataInteres.GetDataInteres(), null);

            //Incarcam lista
            foreach (var elem in listaElem)
            {
                incarcaRand(this.dgvLista.Rows[this.dgvLista.Rows.Add()], elem);
            }

            filtreazaDupaText();

            this.dgvLista.FinalizeazaContructieRanduri();
        }

        private void incarcaRand(DataGridViewRow pRand, BClientiComenzi pElem)
        {
            pRand.Tag = pElem;

            if (pElem.DataPrimire != CConstante.DataNula)
                pRand.Cells[EnumColoaneDGV.colDataPrimire.ToString()].Value = pElem.DataPrimire;
            else
                pRand.Cells[EnumColoaneDGV.colDataPrimire.ToString()].Value = string.Empty;

            pRand.Cells[EnumColoaneDGV.colCodComanda.ToString()].Value = pElem.CodLucrare;
            pRand.Cells[EnumColoaneDGV.colClinica.ToString()].Value = pElem.DenumireClinica;
            pRand.Cells[EnumColoaneDGV.colMedic.ToString()].Value = pElem.GetIdentitateMedic();
            pRand.Cells[EnumColoaneDGV.colCabinet.ToString()].Value = pElem.DenumireCabinet;
            pRand.Cells[EnumColoaneDGV.colLucrare.ToString()].Value = pElem.DenumireLucrare;
            pRand.Cells[EnumColoaneDGV.colNrElemente.ToString()].Value = pElem.NrElemente.ToString();
            pRand.Cells[EnumColoaneDGV.colValoare.ToString()].Value = pElem.ValoareFinala;
            pRand.Cells[EnumColoaneDGV.colMoneda.ToString()].Value = pElem.GetEtichetaMoneda();
            if (pElem.DataLaGata != CConstante.DataNula)
                pRand.Cells[EnumColoaneDGV.colDataLaGata.ToString()].Value = pElem.DataLaGata;
            else
                pRand.Cells[EnumColoaneDGV.colDataLaGata.ToString()].Value = string.Empty;

            pRand.Cells[EnumColoaneDGV.colStareEtapa.ToString()].Value = pElem.StatusEtapaEticheta;
            pRand.Cells[EnumColoaneDGV.colEtapaCurenta.ToString()].Value = pElem.DenumireEtapa;
            pRand.Cells[EnumColoaneDGV.colTehnician.ToString()].Value = pElem.GetIdentitateTehnician();
            pRand.Cells[EnumColoaneDGV.colPacient.ToString()].Value = pElem.GetNumePrenumePacient();

            DataGridViewPersonalizat.InitCelulaDeschideClasic(pRand, EnumColoaneDGV.colDetaliiClinica.ToString());
            DataGridViewPersonalizat.InitCelulaDeschideClasic(pRand, EnumColoaneDGV.colDetaliiFisa.ToString());
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
