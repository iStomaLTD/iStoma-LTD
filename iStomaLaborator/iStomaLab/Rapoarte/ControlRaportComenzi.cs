using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Preturi;
using BLL.iStomaLab;
using CCL.UI;
using CDL.iStomaLab;
using CCL.iStomaLab;
using BLL.iStomaLab.Comune;
using iStomaLab.TablouDeBord.Clienti;

namespace iStomaLab.Rapoarte
{
    public partial class ControlRaportComenzi : Generale.UserControlPersonalizat
    {

        #region Declaratii generale

        int idlucrare, idclient;

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colClient,
            colFisaClient,
            colMedic,
            colLucrare,
            colValoareInitiala,
            colValoareFinala,
            colMoneda,
            colNrElemente,
            colEtapaCurenta,
            colTotalEtape,
            colTehnician,
            colTermen,
            colDataPrimire,
            colDataLaGata,
            colNumePacient,
            colObservatii,
            colDataCreare,
            colCodLucrareClient,
            colCodComanda,
            colDiscount,
            colStare
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlRaportComenzi()
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
            this.txtCautaComanda.CerereUpdate += TxtCautaComanda_CerereUpdate;

            this.ctrlCautareDupaTextClinica.SelecteazaObiectAfisaj += CtrlCautareDupaTextClinica_Update;
            this.ctrlCautareDupaTextClinica.StergeObiectAfisaj += CtrlCautareDupaTextClinica_Update;
            this.ctrlCautareDupaTextClinica.DeschideEcranCautare += CtrlCautareDupaTextClinica_Update;

            this.ctrlCautareDupaTextLucrare.SelecteazaObiectAfisaj += ctrlCautareDupaTextLucrare_Update;
            this.ctrlCautareDupaTextLucrare.StergeObiectAfisaj += ctrlCautareDupaTextLucrare_Update;
            this.ctrlCautareDupaTextLucrare.DeschideEcranCautare += ctrlCautareDupaTextLucrare_Update;

            this.btnVizibilitateZonaRezumat.Click += BtnVizibilitateZonaRezumat_Click;

            this.dgvLista.CellClick += DgvLista_CellClick;
            this.dgvLista.CereRefresh += DgvLista_CereRefresh;

            this.ctrlRezumatClinici.DeschideObiectul += CtrlRezumatClinici_DeschideObiectul;
        }
        private void initTextML()
        {

        }
        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.txtCautaComanda.Goleste();

            this.ctrlPerioada.Initializeaza(CDefinitiiComune.EnumTipPerioada.Luna, DateTime.Today);
            this.ctrlCautareDupaTextClinica.Initializeaza(StructIdDenumire.Empty, CEnumerariComune.EnumTipDeschidere.DreaptaJos);
            this.ctrlCautareDupaTextClinica.Focus();

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
                    BClientiComenzi comandaSelectata = this.dgvLista.SelectedRow.Tag as BClientiComenzi;
                    if (comandaSelectata != null)
                    {
                        if (denumireColoanaSelectata.Equals(EnumColoaneDGV.colFisaClient.ToString()))
                        {
                            BClienti client = BClienti.getClient(comandaSelectata.IdClient, null);

                            if (TablouDeBord.Clienti.FormDosarClient.Afiseaza(this.GetFormParinte(), client))
                                incarcaRand(this.dgvLista.SelectedRow, comandaSelectata);
                        }
                        else if (denumireColoanaSelectata.Equals(EnumColoaneDGV.colTotalEtape.ToString()))
                        {
                            if (FormLucrareListaEtapeRealizate.Afiseaza(this.GetFormParinte(), comandaSelectata))
                            {
                                comandaSelectata.Refresh(null);
                                incarcaRand(this.dgvLista.SelectedRow, comandaSelectata);
                            }
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
        private void CtrlRezumatClinici_DeschideObiectul(Control pSender, int pIdObiect, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                TablouDeBord.Clienti.FormDosarClient.Afiseaza(this.GetFormParinte(), pIdObiect);
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
        private void TxtCautaComanda_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
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
        private void CtrlCautareDupaTextClinica_Update(object sender, EventArgs e)
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

        #endregion

        #region Metode private

        private void filtreazaDupaText()
        {
            setNrLinii(this.dgvLista.FiltreazaDupaText(this.txtCautaComanda.Text));
        }
        private void setNrLinii(int pNrLinii)
        {
            int nrElemente = 0;

            BClientiComenzi lucrare = null;
            foreach (DataGridViewRow rand in this.dgvLista.Rows)
            {
                if (rand.Visible)
                {
                    lucrare = rand.Tag as BClientiComenzi;

                    nrElemente += lucrare.NrElemente;
                }
            }

            this.lblTotal.Text = string.Format("{0}: {1} [{2}: {3}]",
              BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Lucrari),
              pNrLinii,
              BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrElemente),
              nrElemente);
        }
        private void incarcaRand(DataGridViewRow pRand, BClientiComenzi pElem)
        {
            pRand.Tag = pElem;

            idclient = pElem.IdClient;
            idlucrare = pElem.IdLucrare;

            pRand.Cells[EnumColoaneDGV.colCodLucrareClient.ToString()].Value = pElem.Id;

            pRand.Cells[EnumColoaneDGV.colCodComanda.ToString()].Value = pElem.CodLucrare;
            pRand.Cells[EnumColoaneDGV.colClient.ToString()].Value = pElem.GetDenumireClinicaCabinet();

            DataGridViewPersonalizat.InitCelulaDeschideClasic(pRand, EnumColoaneDGV.colFisaClient.ToString());

            if (pElem.IdReprezentantClient != 0)
            {
                pRand.Cells[EnumColoaneDGV.colMedic.ToString()].Value = pElem.GetIdentitateMedic();
            }
            else
            {
                pRand.Cells[EnumColoaneDGV.colMedic.ToString()].Value = string.Empty;
            }
            if (pElem.Urgent)
            {
                DataGridViewPersonalizat.SeteazaAlerta(pRand, EnumColoaneDGV.colLucrare.ToString());
                pRand.Cells[EnumColoaneDGV.colLucrare.ToString()].ToolTipText = string.Format("{0} - {1}", BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Urgent), pElem.DenumireLucrare);
            }
            else
            {
                DataGridViewPersonalizat.IndeparteazaAlerta(pRand, EnumColoaneDGV.colLucrare.ToString());
                pRand.Cells[EnumColoaneDGV.colLucrare.ToString()].ToolTipText = pElem.DenumireLucrare;
            }

            pRand.Cells[EnumColoaneDGV.colLucrare.ToString()].Value = pElem.GetDenumirePrescurtata();
            pRand.Cells[EnumColoaneDGV.colNrElemente.ToString()].Value = pElem.NrElemente.ToString();

            if (pElem.IdEtapaCurenta != 0)
                pRand.Cells[EnumColoaneDGV.colEtapaCurenta.ToString()].Value = pElem.DenumireEtapa;
            else
                pRand.Cells[EnumColoaneDGV.colEtapaCurenta.ToString()].Value = string.Empty;

            if (pElem.Refacere)
            {
                DataGridViewPersonalizat.SeteazaAlerta(pRand, EnumColoaneDGV.colEtapaCurenta.ToString());
                pRand.Cells[EnumColoaneDGV.colEtapaCurenta.ToString()].ToolTipText = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Refacere);
            }
            else
                DataGridViewPersonalizat.IndeparteazaAlerta(pRand, EnumColoaneDGV.colEtapaCurenta.ToString());

            if (pElem.IdTehnician != 0)
                pRand.Cells[EnumColoaneDGV.colTehnician.ToString()].Value = pElem.GetIdentitateTehnician();
            else
                pRand.Cells[EnumColoaneDGV.colTehnician.ToString()].Value = string.Empty;

            pRand.Cells[EnumColoaneDGV.colStare.ToString()].Value = pElem.StatusEtapaEticheta;

            if (pElem.DataSfarsitEtapa != CConstante.DataNula)
            {
                pRand.Cells[EnumColoaneDGV.colTermen.ToString()].Value = pElem.DataSfarsitEtapa;
                pRand.Cells[EnumColoaneDGV.colTermen.ToString()].ToolTipText = CUtil.GetNumeZiSaptamana(pElem.DataSfarsitEtapa.DayOfWeek);
                if (pElem.DataSfarsitEtapa <= DateTime.Today && !pElem.Acceptata)
                {
                    DataGridViewPersonalizat.SeteazaAlerta(pRand, EnumColoaneDGV.colTermen.ToString());
                }
                else
                {
                    DataGridViewPersonalizat.IndeparteazaAlerta(pRand, EnumColoaneDGV.colTermen.ToString());
                }
            }

            DataGridViewPersonalizat.InitCelulaDeschideClasic(pRand, EnumColoaneDGV.colTotalEtape.ToString());

            pRand.Cells[EnumColoaneDGV.colDataPrimire.ToString()].Value = pElem.DataPrimire;
            if (pElem.DataLaGata != CConstante.DataNula)
            {
                pRand.Cells[EnumColoaneDGV.colDataLaGata.ToString()].Value = pElem.DataLaGata;
            }
            else
            {
                pRand.Cells[EnumColoaneDGV.colDataLaGata.ToString()].Value = string.Empty;
            }

            if (pElem.DataLaGata.Date <= DateTime.Today && !pElem.Acceptata)
                DataGridViewPersonalizat.SeteazaAlerta(pRand, EnumColoaneDGV.colDataLaGata.ToString());
            else
                DataGridViewPersonalizat.IndeparteazaAlerta(pRand, EnumColoaneDGV.colDataLaGata.ToString());
            pRand.Cells[EnumColoaneDGV.colNumePacient.ToString()].Value = pElem.GetNumePrenumePacient();
            pRand.Cells[EnumColoaneDGV.colObservatii.ToString()].Value = pElem.Observatii;
            pRand.Cells[EnumColoaneDGV.colDataCreare.ToString()].Value = pElem.DataCreare;

            if (pElem.IdFactura > 0)
            {
                DataGridViewPersonalizat.SeteazaOK(pRand, EnumColoaneDGV.colNumePacient.ToString());
            }

            BListaPreturiClienti pElemClient = BListaPreturiClienti.GetPretClient(pElem.IdLucrare, pElem.IdClient, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);
            pRand.Cells[EnumColoaneDGV.colMoneda.ToString()].Value = pElem.GetEtichetaMoneda();
            pRand.Cells[EnumColoaneDGV.colValoareInitiala.ToString()].Value = CUtil.GetValoareMonetara(pElem.ValoareInitiala, pElem.Moneda);

            double pretLista = pElem.ValoareInitiala;
            double pretNegociat = pElem.ValoareFinala;
            double diferenta = pretLista - pretNegociat;
            double ajustare = CUtil.GetProcentDinTotal(diferenta, pretLista);

            pRand.Cells[EnumColoaneDGV.colDiscount.ToString()].Value = CUtil.GetValoareMonetara(ajustare);
            pRand.Cells[EnumColoaneDGV.colValoareFinala.ToString()].Value = CUtil.GetValoareMonetara(pElem.ValoareFinala, pElem.Moneda);
        }
        private void ConstruiesteColoaneDGV()
        {
            this.dgvLista.IncepeConstructieColoane();

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colCodLucrareClient.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Cod), 50, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colCodComanda.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CodComanda), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaData(EnumColoaneDGV.colDataPrimire.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataPrimire), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA_ORA);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colClient.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Clinica), 130, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaButonClasic(EnumColoaneDGV.colFisaClient.ToString(), string.Empty, string.Empty, 36, false);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colMedic.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Medic), 130, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colLucrare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Lucrare), 300, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colValoareInitiala.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ValoareInitiala), 100, DataGridViewColumnSortMode.Automatic);
            this.dgvLista.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colMoneda.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Moneda), 100, DataGridViewColumnSortMode.Automatic);
            this.dgvLista.Columns[EnumColoaneDGV.colMoneda.ToString()].Visible = false;
            this.dgvLista.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colDiscount.ToString(), " % ", 35, DataGridViewColumnSortMode.Automatic);
            this.dgvLista.Columns[EnumColoaneDGV.colDiscount.ToString()].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvLista.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colValoareFinala.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Valoare), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaNumerica(EnumColoaneDGV.colNrElemente.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrElem), 35, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colEtapaCurenta.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.EtapaCurenta), 150, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colStare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stare), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaData(EnumColoaneDGV.colTermen.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Termen), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA_ORA);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colTehnician.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tehnician), 130, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaButonClasic(EnumColoaneDGV.colTotalEtape.ToString(), string.Empty, string.Empty, 40, false);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colNumePacient.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pacient), 130, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colObservatii.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ObsLucrare), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaData(EnumColoaneDGV.colDataLaGata.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataLaGata), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA_ORA);

            this.dgvLista.AdaugaColoanaData(EnumColoaneDGV.colDataCreare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataCreare), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA_ORA);

            this.dgvLista.FinalizeazaConstructieColoane();
        }
        private void ConstruiesteRanduriDGV()
        {
            this.dgvLista.IncepeContructieRanduri();

            var listaElem = BClientiComenzi.GetListByClientSiLucrareIntrePerioada(this.ctrlCautareDupaTextClinica.IdObiectAfisajCorespunzator, this.ctrlCautareDupaTextLucrare.IdObiectAfisajCorespunzator, this.ctrlPerioada.DataInceput, this.ctrlPerioada.DataSfarsit, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, BComportamentAplicatie.Enum_TablouDeBord_DataInteres.DataPrimire, null);

            Dictionary<int, int> dictCliniciNrElemenete = new Dictionary<int, int>();
            Dictionary<int, int> dictLucrariNrElemenete = new Dictionary<int, int>();

            int idClinicaTemp = 0;
            int idLucrareTemp = 0;
            int nrElemTemp = 0;
            List<int> listaIdClinici = new List<int>();
            List<int> listaIdLucrari = new List<int>();
            foreach (var elem in listaElem)
            {
                incarcaRand(this.dgvLista.Rows[this.dgvLista.Rows.Add()], elem);

                idClinicaTemp = elem.IdClient;
                idLucrareTemp = elem.IdLucrare;
                nrElemTemp = elem.NrElemente;

                if (!dictCliniciNrElemenete.ContainsKey(idClinicaTemp))
                    dictCliniciNrElemenete.Add(idClinicaTemp, 0);
                dictCliniciNrElemenete[idClinicaTemp] += nrElemTemp;

                if (!dictLucrariNrElemenete.ContainsKey(idLucrareTemp))
                    dictLucrariNrElemenete.Add(idLucrareTemp, 0);
                dictLucrariNrElemenete[idLucrareTemp] += nrElemTemp;

                if (!listaIdClinici.Contains(idClinicaTemp))
                    listaIdClinici.Add(idClinicaTemp);
                if (!listaIdLucrari.Contains(idLucrareTemp))
                    listaIdLucrari.Add(idLucrareTemp);
            }

            initRezumatClinici(listaIdClinici, dictCliniciNrElemenete);

            initRezumatLucrari(listaIdLucrari, dictLucrariNrElemenete);

            filtreazaDupaText();

            this.dgvLista.FinalizeazaContructieRanduri();
        }
        private void initRezumatClinici(List<int> pListaIdClinici, Dictionary<int, int> pDictCliniciNrElem)
        {
            BColectieClienti listaClinici = BClienti.getByListaId(pListaIdClinici, null);
            Dictionary<int, string> dictIdDenumire = listaClinici.GetAsDictIdDenumire();

            this.ctrlRezumatClinici.Initializeaza(dictIdDenumire, pDictCliniciNrElem, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Clinici), true);
        }
        private void initRezumatLucrari(List<int> pListaIdLucrari, Dictionary<int, int> pDictLucrariNrElem)
        {
            BColectieListaPreturiStandard listaLucrari = BListaPreturiStandard.getByListaId(pListaIdLucrari, null);
            Dictionary<int, string> dictIdDenumire = listaLucrari.GetAsDictIdDenumire();

            this.ctrlRezumatLucrari.Initializeaza(dictIdDenumire, pDictLucrariNrElem, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Lucrari), false);
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
