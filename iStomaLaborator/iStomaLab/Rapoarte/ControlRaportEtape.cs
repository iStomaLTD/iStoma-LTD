using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab;
using CDL.iStomaLab;
using CCL.UI;
using BLL.iStomaLab.Preturi;
using CCL.iStomaLab;
using BLL.iStomaLab.Utilizatori;
using static CDL.iStomaLab.CDefinitiiComune;

namespace iStomaLab.Rapoarte
{
    public partial class ControlRaportEtape : Generale.UserControlPersonalizat
    {

        #region Declaratii generale


        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colDataTermen,
            colTehnician,
            colEtapa,
            colStatus,
            colRefacere,
            colObservatiiEtapa,
            colLucrarePrescurtata,
            colDeschideLucrare,
            colNumarElemente,
            colUrgenta,
            colObservatiiLucrare,
            colClinica,
            colDeschideClinica,
            colPacient,
            colDataCreare,
            colDataLaGata,
            colDataPrimire,
            colValoareInitiala,
            colValoareFinala,
            colMoneda,
            colDiscount
        }

        //private enum EnumColoaneDGVRezumat
        //{
        //    colNrElemente
        //}

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlRaportEtape()
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
            this.ctrlCautaTehnician.CerereUpdate += CtrlCautaTehnician_CerereUpdate;
            this.txtCautare.CerereUpdate += TxtCautare_CerereUpdate;
            this.dgvLista.CellClick += DgvLista_CellClick;
            this.dgvLista.CellDoubleClick += DgvLista_CellDoubleClick;

            this.ctrlCautareDupaTextLucrare.SelecteazaObiectAfisaj += ctrlCautareDupaTextLucrare_Update;
            this.ctrlCautareDupaTextLucrare.StergeObiectAfisaj += ctrlCautareDupaTextLucrare_Update;
            this.ctrlCautareDupaTextLucrare.DeschideEcranCautare += ctrlCautareDupaTextLucrare_Update;

            this.btnVizibilitateZonaRezumat.Click += BtnVizibilitateZonaRezumat_Click;

            this.ctrlDataInteres.CerereUpdate += CtrlDataInteres_CerereUpdate;

            this.dgvLista.CereRefresh += DgvLista_CereRefresh;

        }

        private void initTextML()
        {
            this.lblTehnician.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tehnician);
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.ctrlPerioada.Initializeaza(CDL.iStomaLab.CDefinitiiComune.EnumTipPerioada.Saptamana, DateTime.Today);
            this.txtCautare.Goleste();
            this.ctrlCautaTehnician.Initializeaza();
            this.ctrlCautaTehnician.AfiseazaButonGuma(true);

            this.btnOptiuni.Initializeaza(this.panelOptiuni);
            this.btnInchidePanelOptiuni.Initializeaza(this.panelOptiuni);
            this.panelOptiuni.Initializeaza();

            this.ctrlDataInteres.Initializeaza();

            ConstruiesteColoaneDGV();

            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void BtnVizibilitateZonaRezumat_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.splitContainer.Panel2Collapsed = this.btnVizibilitateZonaRezumat.Selectat;
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

        private void DgvLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //La dublu click pe numele tehnicianului il setam ca tehnician selectat daca nu este deja, daca este atunci nu golim 

            if (this.lSeIncarca || e.RowIndex<0) return;
            try
            {
                incepeIncarcarea();

                string numeColoana = this.dgvLista.Columns[e.ColumnIndex].Name;

                if(numeColoana.Equals(EnumColoaneDGV.colTehnician.ToString()))
                {
                    BClientiComenziEtape etapaSelectata = this.dgvLista.SelectedRow.Tag as BClientiComenziEtape;

                    this.ctrlCautaTehnician.SelectieInteligenta(etapaSelectata.IdTehnician);

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

        private void DgvLista_CereRefresh(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                ConstruiesteColoaneDGV();
                //ConstruiesteColoaneDGVTehnicieni();
                //ConstruiesteColoaneDGVLucrari();

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

        private void ctrlCautareDupaTextLucrare_Update(object sender, EventArgs e)
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

                string denumireColoanaSelectata = this.dgvLista.Columns[e.ColumnIndex].Name;
                 
                BClientiComenziEtape etapaSelectata = this.dgvLista.SelectedRow.Tag as BClientiComenziEtape;

                if (etapaSelectata != null)
                {
                    if (denumireColoanaSelectata.Equals(EnumColoaneDGV.colDeschideClinica.ToString()) && etapaSelectata.IdClient != 0)
                    {
                        if (TablouDeBord.Clienti.FormDosarClient.Afiseaza(this.GetFormParinte(), BClienti.getClient(etapaSelectata.IdClient, null)))
                        {
                            incarcaRand(this.dgvLista.SelectedRow, etapaSelectata);
                        }
                    }
                    else if (denumireColoanaSelectata.Equals(EnumColoaneDGV.colDeschideLucrare.ToString()) && etapaSelectata.IdLucrare != 0)
                    {
                        BClientiComenzi comanda = BClientiComenzi.getComanda(etapaSelectata.IdComandaClient, null);
                        BClienti client = BClienti.getClient(etapaSelectata.IdClient, null);
                        BListaPreturiStandard lucrare = BListaPreturiStandard.getById(etapaSelectata.IdLucrare, null);

                        if(TablouDeBord.Clienti.FormDetaliuComanda.Afiseaza(this.GetFormParinte(), comanda, client, lucrare))
                        {
                            incarcaRand(this.dgvLista.SelectedRow, etapaSelectata);
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

        private void CtrlCautaTehnician_CerereUpdate(object sender, EventArgs e)
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

        #endregion

        #region Metode private

        private void filtreazaDupaText()
        {
            setNrLinii(this.dgvLista.FiltreazaDupaText(this.txtCautare.Text));
        }

        private void setNrLinii(int pNrLinii)
        {
            this.lblTotal.Text = string.Format("{0}: {1}",
                BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Etape),
                pNrLinii);
        }

        private void ConstruiesteColoaneDGV()
        {
            this.dgvLista.IncepeConstructieColoane();

            this.dgvLista.AdaugaColoanaData(EnumColoaneDGV.colDataPrimire.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataPrimire), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);

            this.dgvLista.AdaugaColoanaData(EnumColoaneDGV.colDataTermen.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataTermen), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colTehnician.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tehnician), 130, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colEtapa.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Etapa), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colStatus.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stare), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colValoareInitiala.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ValoareInitiala), 100, DataGridViewColumnSortMode.Automatic);
            this.dgvLista.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colMoneda.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Moneda), 100, DataGridViewColumnSortMode.Automatic);
            this.dgvLista.Columns[EnumColoaneDGV.colMoneda.ToString()].Visible = false;
            this.dgvLista.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colDiscount.ToString(), " % ", 35, DataGridViewColumnSortMode.Automatic);
            this.dgvLista.Columns[EnumColoaneDGV.colDiscount.ToString()].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvLista.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colValoareFinala.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Valoare), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colRefacere.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Refacere), 60, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.Columns[EnumColoaneDGV.colRefacere.ToString()].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colObservatiiEtapa.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ObsEtapa), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colLucrarePrescurtata.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Lucrare), 130, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaButonClasic(EnumColoaneDGV.colDeschideLucrare.ToString(), string.Empty, string.Empty, 40, false);

            this.dgvLista.AdaugaColoanaNumerica(EnumColoaneDGV.colNumarElemente.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrElem), 40, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colUrgenta.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Urgent), 50, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.Columns[EnumColoaneDGV.colUrgenta.ToString()].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colObservatiiLucrare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ObsLucrare), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colClinica.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Clinica), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaButonClasic(EnumColoaneDGV.colDeschideClinica.ToString(), string.Empty, string.Empty, 40, false);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colPacient.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pacient), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaData(EnumColoaneDGV.colDataLaGata.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataLaGata), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);

            this.dgvLista.AdaugaColoanaData(EnumColoaneDGV.colDataCreare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataCreare), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA_ORA);

            this.dgvLista.FinalizeazaConstructieColoane();
        }
        private void ConstruiesteRanduriDGV()
        {
            this.dgvLista.IncepeContructieRanduri();

            BColectieClientiComenziEtape listaElem = BClientiComenziEtape.GetListByTehnicianSiLucrareIntrePerioada(this.ctrlCautaTehnician.GetIdTehnician(), this.ctrlCautareDupaTextLucrare.IdObiectAfisajCorespunzator, this.ctrlPerioada.DataInceput, this.ctrlPerioada.DataSfarsit, this.ctrlDataInteres.GetDataInteres(), null);

            Dictionary<int, int> dictTehnicieniNrElemenete = new Dictionary<int, int>();
            Dictionary<int, int> dictLucrariNrElemenete = new Dictionary<int, int>();
            Dictionary<int, int> dictEtapeNrElemenete = new Dictionary<int, int>();

            int idTehnicianTemp = 0;
            int idLucrareTemp = 0;
            int idEtapaTemp = 0;
            int nrElemTemp = 0;
            List<int> listaIdTehnicieni = new List<int>();
            List<int> listaIdLucrari = new List<int>();
            List<int> listaIdEtape = new List<int>();
            foreach (var elem in listaElem)
            {
                incarcaRand(this.dgvLista.Rows[this.dgvLista.Rows.Add()], elem);

                idTehnicianTemp = elem.IdTehnician;
                idLucrareTemp = elem.IdLucrare;
                idEtapaTemp = elem.IdEtapa;
                nrElemTemp = elem.NumarElemente;

                if (!dictTehnicieniNrElemenete.ContainsKey(idTehnicianTemp))
                    dictTehnicieniNrElemenete.Add(idTehnicianTemp, 0);
                dictTehnicieniNrElemenete[idTehnicianTemp] += nrElemTemp;
                if (!listaIdTehnicieni.Contains(idTehnicianTemp))
                    listaIdTehnicieni.Add(idTehnicianTemp);

                if (!listaIdLucrari.Contains(idLucrareTemp))
                {
                    if (!dictLucrariNrElemenete.ContainsKey(idLucrareTemp))
                        dictLucrariNrElemenete.Add(idLucrareTemp, 0);
                    dictLucrariNrElemenete[idLucrareTemp] += nrElemTemp;
                    listaIdLucrari.Add(idLucrareTemp);
                }

                if (!dictEtapeNrElemenete.ContainsKey(idEtapaTemp))
                    dictEtapeNrElemenete.Add(idEtapaTemp, 0);
                dictEtapeNrElemenete[idEtapaTemp] += nrElemTemp;
                if (!listaIdEtape.Contains(idEtapaTemp))
                    listaIdEtape.Add(idEtapaTemp);

            }

            initRezumatTehnicieni(listaIdTehnicieni, dictTehnicieniNrElemenete);

            initRezumatLucrari(listaIdLucrari, dictLucrariNrElemenete);

            initRezumatEtape(listaIdEtape, dictEtapeNrElemenete);

            filtreazaDupaText();

            this.dgvLista.FinalizeazaContructieRanduri();
        }

        private void initRezumatTehnicieni(List<int> pListaIdTehnicieni, Dictionary<int, int> pDictTehnicieniNrElem)
        {
            BColectieUtilizator listaTehnicieni = BUtilizator.getByListaId(pListaIdTehnicieni, null);
            Dictionary<int, string> dictIdDenumire = listaTehnicieni.GetAsDictIdDenumire();

            this.ctrlRezumatTehnicieni.Initializeaza(dictIdDenumire, pDictTehnicieniNrElem, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tehnician), false);
        }
        private void initRezumatLucrari(List<int> pListaIdLucrari, Dictionary<int, int> pDictLucrariNrElem)
        {
            BColectieListaPreturiStandard listaLucrari = BListaPreturiStandard.getByListaId(pListaIdLucrari, null);
            Dictionary<int, string> dictIdDenumire = listaLucrari.GetAsDictIdDenumire();

            this.ctrlRezumatLucrari.Initializeaza(dictIdDenumire, pDictLucrariNrElem, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Lucrari), false);
        }
        private void initRezumatEtape(List<int> pListaIdEtape, Dictionary<int, int> pDictEtapeNrElem)
        {
            BColectieEtape listaEtape = BEtape.getByListaId(pListaIdEtape, null);

            Dictionary<int, string> dictIdDenumire = listaEtape.GetAsDictIdDenumire();

            this.ctrlRezumatEtape.Initializeaza(dictIdDenumire, pDictEtapeNrElem, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Etape), false);
        }
        private void incarcaRand(DataGridViewRow pRand, BClientiComenziEtape pElem)
        {
            pRand.Tag = pElem;

            pRand.Cells[EnumColoaneDGV.colDataCreare.ToString()].Value = pElem.DataCreareLucrare;
            pRand.Cells[EnumColoaneDGV.colDataPrimire.ToString()].Value = pElem.DataPrimireLucrare;
            pRand.Cells[EnumColoaneDGV.colDataLaGata.ToString()].Value = pElem.DataLaGataLucrare;

            pRand.Cells[EnumColoaneDGV.colDataTermen.ToString()].Value = pElem.DataFinal;
            pRand.Cells[EnumColoaneDGV.colTehnician.ToString()].Value = pElem.GetIdentitateTehnician();
            pRand.Cells[EnumColoaneDGV.colEtapa.ToString()].Value = pElem.DenumireEtapa;
            pRand.Cells[EnumColoaneDGV.colStatus.ToString()].Value = BClientiComenziEtape.StructStareEtapa.GetStructById(pElem.Status).Denumire;
            if (pElem.Refacere)
            {
                pRand.Cells[EnumColoaneDGV.colRefacere.ToString()].Value = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.X);
                DataGridViewPersonalizat.SeteazaAlerta(pRand, EnumColoaneDGV.colRefacere.ToString());
            }
            else
            {
                DataGridViewPersonalizat.IndeparteazaAlerta(pRand, EnumColoaneDGV.colRefacere.ToString());
            }

            pRand.Cells[EnumColoaneDGV.colObservatiiEtapa.ToString()].Value = pElem.Observatii;
            pRand.Cells[EnumColoaneDGV.colLucrarePrescurtata.ToString()].Value = pElem.GetDenumirePrescurtataLucrare();
            pRand.Cells[EnumColoaneDGV.colLucrarePrescurtata.ToString()].ToolTipText = pElem.DenumireLucrare;
            DataGridViewPersonalizat.InitCelulaDeschideClasic(pRand, EnumColoaneDGV.colDeschideLucrare.ToString());
            pRand.Cells[EnumColoaneDGV.colNumarElemente.ToString()].Value = pElem.NumarElemente.ToString();

            if (pElem.Urgent)
            {
                pRand.Cells[EnumColoaneDGV.colUrgenta.ToString()].Value = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.X);
                DataGridViewPersonalizat.SeteazaAlerta(pRand, EnumColoaneDGV.colUrgenta.ToString());
            }
            else
            {
                DataGridViewPersonalizat.IndeparteazaAlerta(pRand, EnumColoaneDGV.colUrgenta.ToString());
            }

            pRand.Cells[EnumColoaneDGV.colObservatiiLucrare.ToString()].Value = pElem.ObservatiiComanda;
            pRand.Cells[EnumColoaneDGV.colClinica.ToString()].Value = pElem.DenumireClient;
            DataGridViewPersonalizat.InitCelulaDeschideClasic(pRand, EnumColoaneDGV.colDeschideClinica.ToString());
            pRand.Cells[EnumColoaneDGV.colPacient.ToString()].Value = pElem.GetIdentitatePacient();
            
            pRand.Cells[EnumColoaneDGV.colMoneda.ToString()].Value = pElem.GetEtichetaMoneda();
            pRand.Cells[EnumColoaneDGV.colValoareInitiala.ToString()].Value = CUtil.GetValoareMonetara(pElem.ValoareInitiala, pElem.Moneda);

            double pretLista = pElem.ValoareInitiala;
            double pretNegociat = pElem.ValoareFinala;
            double diferenta = pretLista - pretNegociat;
            double ajustare = CUtil.GetProcentDinTotal(diferenta, pretLista);

            pRand.Cells[EnumColoaneDGV.colDiscount.ToString()].Value = CUtil.GetValoareMonetara(ajustare);
            pRand.Cells[EnumColoaneDGV.colValoareFinala.ToString()].Value = CUtil.GetValoareMonetara(pElem.ValoareFinala, pElem.Moneda);
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
