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
using BLL.iStomaLab;
using CDL.iStomaLab;
using CCL.UI;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Utilizatori;
using BLL.iStomaLab.Comune;
using BLL.iStomaLab.Preturi;
using CCL.iStomaLab;
using static iStomaLab.Imprimare.FormImprimareCReports;
using iStomaLab.Imprimare;
using CrystalDecisions.CrystalReports.Engine;

namespace iStomaLab.ResurseUmane
{
    public partial class ControlVenituri : UserControlPersonalizat
    {

        #region Declaratii generale
        private DateTime lDataInceput = CConstante.DataNula;
        private DateTime lDataFinal = CConstante.DataNula;
        private ReportDocument lRptDoc = new ReportDocument();

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colTehnician,
            colTipVenit,
            colNrElemente,
            colTotal,
            colDetalii
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlVenituri()
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
            this.txtCautare.CerereUpdate += TxtCautare_CerereUpdate;
            this.dgvListaVenituri.CereRefresh += DgvListaVenituri_CereRefresh;
            this.dgvListaVenituri.CellClick += DgvListaVenituri_CellClick;
            this.ctrlPerioada.PerioadaSchimbata += CtrlPerioada_PerioadaSchimbata;
            this.btnImprimare.Click += BtnImprimare_Click;
        }

        private void initTextML()
        {
            this.lblCauta.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Cauta);
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.txtCautare.Goleste();

            this.ctrlPerioada.Initializeaza(CDefinitiiComune.EnumTipPerioada.Luna, DateTime.Today);

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void BtnImprimare_Click(object sender, EventArgs e)
        {
            if (!this.lEcranInModificare) return;

            try
            {
                //Imprimare.frmImprimareDGV.Imprima(dgvListaDetaliat as CCL.UI.DataGridViewPersonalizat);
                string rptImprimare = CUtil.GetLocatieRapoarte();
                rptImprimare += "RptListaRezumatVenituri.rpt";

                StructParametriiRaport structParam = new StructParametriiRaport();
                this.lRptDoc.Load(rptImprimare);
                structParam.lDataInceput = this.ctrlPerioada.DataInceput;
                structParam.lDataFinal = this.ctrlPerioada.DataSfarsit;
                structParam.lRptImprimare = rptImprimare;
                structParam.lRptDoc = setParamReportDocument();
                structParam.lRptDoc.Load(rptImprimare);

                FormImprimareCReports.Afiseaza(this.GetFormParinte(), structParam);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
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

        private void DgvListaVenituri_CereRefresh(object sender, EventArgs e)
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

        private void DgvListaVenituri_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (this.lSeIncarca || e.RowIndex < 0) return;
            try
            {
                incepeIncarcarea();

                string numeColoana = this.dgvListaVenituri.Columns[e.ColumnIndex].Name;

                if (numeColoana.Equals(EnumColoaneDGV.colDetalii.ToString()))
                {
                    BUtilizator utilizatorSelectat = this.dgvListaVenituri.SelectedRow.Tag as BUtilizator;

                    if (utilizatorSelectat != null)
                        FormVenituriDetaliat.Afiseaza(this.GetFormParinte(), utilizatorSelectat, this.ctrlPerioada.DataInceput, this.ctrlPerioada.DataSfarsit);
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

        #endregion

        #region Metode private


        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaVenituri.IncepeConstructieColoane();

            this.dgvListaVenituri.AdaugaColoanaText(EnumColoaneDGV.colTehnician.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tehnician), 200, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaVenituri.AdaugaColoanaText(EnumColoaneDGV.colTipVenit.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TipVenit), 200, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaVenituri.AdaugaColoanaNumerica(EnumColoaneDGV.colNrElemente.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrElemente), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvListaVenituri.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colTotal.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Total), 250, DataGridViewColumnSortMode.Automatic);

            this.dgvListaVenituri.AdaugaColoanaButonClasic(EnumColoaneDGV.colDetalii.ToString(), string.Empty, string.Empty, 40, false);

            this.dgvListaVenituri.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaVenituri.IncepeContructieRanduri();

            BColectieUtilizator listaUtilizatori = BUtilizator.GetListByParam(CDefinitiiComune.EnumStare.Activa, CDefinitiiComune.EnumRol.Nedefinit, null);

            BColectieUtilizatoriVenituri listaVenituri = BUtilizatoriVenituri.getByListaId(listaUtilizatori.GetListaId(), null);
            Dictionary<int, Tuple<double, double>> dictTotal = BClientiComenziEtape.GetListaVenituri(this.ctrlPerioada.DataInceput, this.ctrlPerioada.DataSfarsit, null);

            foreach (var elem in listaUtilizatori)
            {
                incarcaRand(this.dgvListaVenituri.Rows[this.dgvListaVenituri.Rows.Add()], elem, listaVenituri.GetVenituriActiveInPerioada(elem.Id, this.ctrlPerioada.DataInceput, this.ctrlPerioada.DataSfarsit), dictTotal.ContainsKey(elem.Id) ? dictTotal[elem.Id] : null);
            }

            this.lblTotal.Text = string.Format("{0}: {1}", BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ElementeGasite), this.dgvListaVenituri.RowCount.ToString());

            this.dgvListaVenituri.FinalizeazaContructieRanduri();
        }

        private void incarcaRand(DataGridViewRow pRand, BUtilizator pElem, BColectieUtilizatoriVenituri pVenituri, Tuple<double, double> pTotal)
        {
            pRand.Tag = pElem;
            pRand.Cells[EnumColoaneDGV.colTehnician.ToString()].Value = pElem.GetNumeCompletUtilizator();

            if (!CUtil.EsteListaVida<BUtilizatoriVenituri>(pVenituri))
                pRand.Cells[EnumColoaneDGV.colTipVenit.ToString()].Value = pVenituri.ToString();

            this.dgvListaVenituri.SeteazaFontIngrosat(pRand, EnumColoaneDGV.colTotal.ToString());

            if (pTotal != null)
            {
                DataGridViewPersonalizat.InitCelulaValoareMonetara(pRand, EnumColoaneDGV.colNrElemente.ToString(), pTotal.Item1);
                DataGridViewPersonalizat.InitCelulaValoareMonetara(pRand, EnumColoaneDGV.colTotal.ToString(), pTotal.Item2);
            }

            DataGridViewPersonalizat.InitCelulaDeschideClasic(pRand, EnumColoaneDGV.colDetalii.ToString());
        }

        private ReportDocument setParamReportDocument()
        {
            //ReportDocument lRptDoc = new ReportDocument();
            lRptDoc.SetParameterValue("@DataInceput", this.ctrlPerioada.DataInceput);
            lRptDoc.SetParameterValue("@DataSfarsit", this.ctrlPerioada.DataSfarsit);
            return lRptDoc;
        }

        private void filtreazaDupaText()
        {
            setNrLinii(this.dgvListaVenituri.FiltreazaDupaText(this.txtCautare.Text));
        }

        private void setNrLinii(int pNrLinii)
        {
            this.lblTotal.Text = string.Format("{0}: {1}",
                BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Venituri),
                pNrLinii);
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
