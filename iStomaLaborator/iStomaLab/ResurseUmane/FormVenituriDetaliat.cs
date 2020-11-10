using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Preturi;
using BLL.iStomaLab.Utilizatori;
using CCL.iStomaLab;
using CCL.UI;
using CDL.iStomaLab;
using CrystalDecisions.CrystalReports.Engine;
using iStomaLab.Generale;
using iStomaLab.Imprimare;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iStomaLab.Imprimare.FormImprimareCReports;

namespace iStomaLab.ResurseUmane
{
    public partial class FormVenituriDetaliat : FormPersonalizat
    {

        #region Declaratii generale

        private BUtilizator lUtilizator = null;
        //private DateTime? lDataInceput;
        //private DateTime? lDataFinal;

        private DateTime lDataInceput = CConstante.DataNula;
        private DateTime lDataFinal = CConstante.DataNula;
        private ReportDocument lRptDoc = new ReportDocument();

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colEtapa,
            colDataInceput,
            colDenumireLucrare,
            colDenumirePacient,
            colNrElemente,
            colClinica,
            colPret,
            colValoare
        }

        #endregion

        #region Proprietati


        #endregion

        #region Constructor si Initializare

        private FormVenituriDetaliat(BUtilizator pUtilizator, DateTime pDataInceput, DateTime pDataSfarsit)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lUtilizator = pUtilizator;
            this.lDataInceput = pDataInceput;
            this.lDataFinal = pDataSfarsit;

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                adaugaHandlere();
                initTextML();

                this.CentratCuDeplasare();
            }
        }


        private void adaugaHandlere()
        {
            this.Load += _Load;
            this.txtCautare.CerereUpdate += TxtCautare_CerereUpdate;
            this.ctrlValidareAnulare.Validare += CtrlValidareAnulare_Validare;
            this.btnImprimare.Click += BtnImprimare_Click;
            this.btnVizibilitateZonaRezumat.Click += BtnVizibilitateZonaRezumat_Click;
        }

        private void initTextML()
        {
            this.Text = this.lUtilizator.GetNumeCompletUtilizator();
            //this.btnImprimare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Imprimare);
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
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.txtCautare.Goleste();

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

        private void BtnImprimare_Click(object sender, EventArgs e)
        {
            if (!this.lEcranInModificare) return;

            try
            {
                //Imprimare.frmImprimareDGV.Imprima(dgvListaDetaliat as CCL.UI.DataGridViewPersonalizat);

                string rptImprimare = CUtil.GetLocatieRapoarte();
                rptImprimare += "RptListaDetaliiVenituri.rpt";

                StructParametriiRaport structParam = new StructParametriiRaport();
                this.lRptDoc.Load(rptImprimare);
                structParam.lUtilizator = this.lUtilizator;
                structParam.lDataInceput = this.lDataInceput;
                structParam.lDataFinal = this.lDataFinal;
                structParam.lRptImprimare = rptImprimare;
                structParam.lRptDoc = setParamReportDocument();
                structParam.lRptDoc.Load(rptImprimare);

                FormImprimareCReports.Afiseaza(this.GetFormParinte(), structParam);
                //FormImprimareCReports.Afiseaza(this.GetFormParinte(), this.lUtilizator, this.lDataInceput, this.lDataFinal, rptImprimare);

            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        private void CtrlValidareAnulare_Validare(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                inchideEcranulOK();
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
            setNrLinii(this.dgvListaDetaliat.FiltreazaDupaText(this.txtCautare.Text));
        }

        private void setNrLinii(int pNrLinii)
        {
            double pretTemp = 0;

            foreach (DataGridViewRow rand in this.dgvListaDetaliat.Rows)
            {
                pretTemp += CUtil.GetAsDouble(rand.Cells[EnumColoaneDGV.colPret.ToString()].Value);
                //pretTemp += DataGridViewPersonalizat.GetValoareTagColoanaRand(rand, EnumColoaneDGV.colPret.ToString());
            }

            this.lblTotal.Text = string.Format("{0}: {1} [{2}: {3}]",
                BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Etape),
                pNrLinii,
                BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Venit),
               CUtil.GetValoareMonetaraLei(pretTemp));
        }


        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaDetaliat.IncepeConstructieColoane();

            this.dgvListaDetaliat.AdaugaColoanaData(EnumColoaneDGV.colDataInceput.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Data), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);
            this.dgvListaDetaliat.AdaugaColoanaText(EnumColoaneDGV.colDenumireLucrare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Lucrare), 100, true, DataGridViewColumnSortMode.Automatic);
            this.dgvListaDetaliat.AdaugaColoanaText(EnumColoaneDGV.colDenumirePacient.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pacient), 100, true, DataGridViewColumnSortMode.Automatic);
            this.dgvListaDetaliat.AdaugaColoanaText(EnumColoaneDGV.colClinica.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Clinica), 100, true, DataGridViewColumnSortMode.Automatic);
            this.dgvListaDetaliat.AdaugaColoanaText(EnumColoaneDGV.colEtapa.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Etapa), 100, true, DataGridViewColumnSortMode.Automatic);
            this.dgvListaDetaliat.AdaugaColoanaNumerica(EnumColoaneDGV.colNrElemente.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrElemente), 100, DataGridViewColumnSortMode.Automatic);
            this.dgvListaDetaliat.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colValoare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Valoare), 100, DataGridViewColumnSortMode.Automatic);
            this.dgvListaDetaliat.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colPret.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Venit), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvListaDetaliat.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaDetaliat.IncepeContructieRanduri();

            BColectieClientiComenziEtape listaElem = BClientiComenziEtape.GetListaVenituriDetaliat(this.lUtilizator.Id, this.lDataInceput, this.lDataFinal, null);
            //BColectieClientiComenziEtape listaElem = BClientiComenziEtape.GetListaVenituriDetaliat(this.lUtilizator.Id, this.lDataInceput.Value, this.lDataFinal.Value, null);
            //BClientiComenziEtape.GetListVenituriByIdTehnician(this.lUtilizator.Id, this.lDataInceput.Value, this.lDataFinal.Value, null); 

            Dictionary<int, int> dictCliniciNrElemente = new Dictionary<int, int>();
            Dictionary<int, int> dictLucrariNrElemente = new Dictionary<int, int>();
            Dictionary<int, int> dictEtapeNrElemente = new Dictionary<int, int>();

            int idClinicaTemp = 0;
            int idLucrareTemp = 0;
            int idEtapaTemp = 0;
            int nrElemTemp = 0;
            int pretTemp = 0;
            int idEtapaVenitTemp = 0;
            List<int> listaIdClinici = new List<int>();
            List<int> listaIdLucrari = new List<int>();
            List<int> listaIdEtape = new List<int>();

            foreach (var elem in listaElem)
            {
                incarcaRand(this.dgvListaDetaliat.Rows[this.dgvListaDetaliat.Rows.Add()], elem);

                idClinicaTemp = elem.IdClient;
                idLucrareTemp = elem.IdLucrare;
                idEtapaTemp = elem.IdEtapa;
                nrElemTemp = elem.NumarElemente;
                pretTemp = Convert.ToInt32(elem.Venit);
                idEtapaVenitTemp = elem.IdEtapaVenit;

                //if (!listaIdLucrari.Contains(idLucrareTemp))
                //{
                //    if (!dictLucrariNrElemente.ContainsKey(idLucrareTemp))
                //        dictLucrariNrElemente.Add(idLucrareTemp, 0);
                //    dictLucrariNrElemente[idLucrareTemp] += nrElemTemp;
                //    listaIdLucrari.Add(idLucrareTemp);
                //}

                if (!dictCliniciNrElemente.ContainsKey(idClinicaTemp))
                    dictCliniciNrElemente.Add(idClinicaTemp, 0);
                dictCliniciNrElemente[idClinicaTemp] += nrElemTemp;

                if (!dictLucrariNrElemente.ContainsKey(idLucrareTemp))
                    dictLucrariNrElemente.Add(idLucrareTemp, 0);
                dictLucrariNrElemente[idLucrareTemp] += nrElemTemp;

                if (!dictEtapeNrElemente.ContainsKey(idEtapaTemp))
                    dictEtapeNrElemente.Add(idEtapaTemp, 0);
                dictEtapeNrElemente[idEtapaTemp] += nrElemTemp;

                if (!listaIdClinici.Contains(idClinicaTemp))
                    listaIdClinici.Add(idClinicaTemp);
                if (!listaIdLucrari.Contains(idLucrareTemp))
                    listaIdLucrari.Add(idLucrareTemp);
                if (!listaIdEtape.Contains(idEtapaTemp))
                    listaIdEtape.Add(idEtapaTemp);
            }

            initRezumatClinici(listaIdClinici, dictCliniciNrElemente);

            initRezumatLucrari(listaIdLucrari, dictLucrariNrElemente);

            initRezumatEtape(listaIdEtape, dictEtapeNrElemente);

            filtreazaDupaText();

            this.dgvListaDetaliat.FinalizeazaContructieRanduri();
        }

        private void initRezumatClinici(List<int> pListaIdClinici, Dictionary<int, int> pDictCliniciNrElem)
        {
            BColectieClienti listaClinici = BClienti.getByListaId(pListaIdClinici, null);
            Dictionary<int, string> dictIdDenumire = listaClinici.GetAsDictIdDenumire();

            this.ctrlRezumatClienti.Initializeaza(dictIdDenumire, pDictCliniciNrElem, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Clinica), false);
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

            pRand.Cells[EnumColoaneDGV.colDataInceput.ToString()].Value = pElem.DataInceput;
            pRand.Cells[EnumColoaneDGV.colDenumireLucrare.ToString()].Value = pElem.DenumireLucrare;
            pRand.Cells[EnumColoaneDGV.colDenumirePacient.ToString()].Value = pElem.GetIdentitatePacient();
            pRand.Cells[EnumColoaneDGV.colClinica.ToString()].Value = pElem.DenumireClient;
            pRand.Cells[EnumColoaneDGV.colEtapa.ToString()].Value = pElem.DenumireEtapa;
            DataGridViewPersonalizat.InitCelulaValoareMonetara(pRand, EnumColoaneDGV.colNrElemente.ToString(), pElem.NumarElemente);
            pRand.Cells[EnumColoaneDGV.colValoare.ToString()].Value = pElem.ValoareFinala;
            pRand.Cells[EnumColoaneDGV.colPret.ToString()].Value = pElem.Venit;
            this.dgvListaDetaliat.SeteazaFontIngrosat(pRand, EnumColoaneDGV.colPret.ToString());
        }

        private ReportDocument setParamReportDocument()
        {
            //ReportDocument lRptDoc = new ReportDocument();
            lRptDoc.SetParameterValue("@IdTehnician", this.lUtilizator.Id);
            lRptDoc.SetParameterValue("NumeTehnician", this.lUtilizator.GetNumeCompletUtilizator());
            lRptDoc.SetParameterValue("@DataInceput", this.lDataInceput);
            lRptDoc.SetParameterValue("@DataSfarsit", this.lDataFinal);
            return lRptDoc;
        }

        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente, BUtilizator pUtilizator, DateTime pDataInceput, DateTime pDataSfarsit)
        {
            using (FormVenituriDetaliat ecran = new FormVenituriDetaliat(pUtilizator, pDataInceput, pDataSfarsit))
            {
                ecran.AplicaPreferinteleUtilizatorului();
                return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
            }
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
        }

        #endregion


    }
}
