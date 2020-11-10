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
using CDL.iStomaLab;
using BLL.iStomaLab;
using CCL.iStomaLab;
using CCL.UI;
using static iStomaLab.Imprimare.FormImprimareCReports;
using iStomaLab.Imprimare;
using CrystalDecisions.CrystalReports.Engine;

namespace iStomaLab.TablouDeBord.Facturare
{
    public partial class ControlListaFacturiEmise : UserControlPersonalizat
    {

        #region Declaratii generale

        private ReportDocument lRptDoc = new ReportDocument();

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colDataEmiterii,
            colSerieFactura,
            colNumarFactura,
            colClinica,
            colValoare,
            colAchitat,
            colRestPlata,
            colCursBNR,
            colObservatii,
            colTipDocument,
            colDetaliiClinica
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlListaFacturiEmise()
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
            this.ctrlCautareDupaTextClinica.SelecteazaObiectAfisaj += CtrlCautareDupaTextClinica_Update;
            this.ctrlCautareDupaTextClinica.StergeObiectAfisaj += CtrlCautareDupaTextClinica_Update;
            this.ctrlCautareDupaTextClinica.DeschideEcranCautare += CtrlCautareDupaTextClinica_Update;

            this.dgvLista.EditareLinie += DgvLista_EditareLinie;
            this.dgvLista.StergereLinie += DgvLista_StergereLinie;
            this.dgvLista.CellClick += DgvLista_CellClick;
            this.dgvLista.CereRefresh += DgvLista_CereRefresh;

            this.VisibleChanged += ControlListaFacturiEmise_VisibleChanged;

            this.btnImprima.Click += BtnImprima_Click;
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
            this.lblClinica.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Clinica);
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.txtCautare.Goleste();

            this.ctrlPerioada.Initializeaza(CDefinitiiComune.EnumTipPerioada.Luna, DateTime.Now);
            this.ctrlCautareDupaTextClinica.Initializeaza(StructIdDenumire.Empty, CEnumerariComune.EnumTipDeschidere.DreaptaJos);

            this.ctrlCautareDupaTextClinica.Focus();

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void DgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.lSeIncarca || e.RowIndex < 0) return;
            try
            {
                incepeIncarcarea();

                string numeColoana = this.dgvLista.Columns[e.ColumnIndex].Name;

                if (numeColoana.Equals(EnumColoaneDGV.colDetaliiClinica.ToString()))
                {
                    BClientiFacturi fact = this.dgvLista.SelectedRow.Tag as BClientiFacturi;

                    IHMUtile.DeschideDosarClient(this.GetFormParinte(), fact.IdClient);
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

        private void BtnImprima_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (this.dgvLista.SelectedRow != null)
                {
                    BClientiFacturi factura = this.dgvLista.SelectedRow.Tag as BClientiFacturi;

                    //Imprimare.CImprimareFacturaClient.Imprima(this.GetFormParinte(), factura);

                    string rptImprimare = CUtil.GetLocatieRapoarte();
                    rptImprimare += "RptFacturaClient.rpt";

                    StructParametriiRaport structParam = new StructParametriiRaport();
                    this.lRptDoc.Load(rptImprimare);
                    structParam.lFactura = factura;
                    structParam.lRptImprimare = rptImprimare;
                    structParam.lRptDoc = setParamReportDocument();
                    structParam.lRptDoc.Load(rptImprimare);

                    FormImprimareCReports.Afiseaza(this.GetFormParinte(), structParam);
                }
                else
                {
                    Mesaj.Afiseaza(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.SelectatiLinia));
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

        private void DgvLista_StergereLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca || pIndexRand < 0) return;
            try
            {
                incepeIncarcarea();

                if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stergere)))
                {
                    BClientiFacturi fact = this.dgvLista.Rows[pIndexRand].Tag as BClientiFacturi;

                    fact.Close(true, string.Empty, null);

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

        private void ControlListaFacturiEmise_VisibleChanged(object sender, EventArgs e)
        {
            this.ctrlCautareDupaTextClinica.AscundeEcranRezultatCautare();
        }

        private void DgvLista_EditareLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BClientiFacturi fact = this.dgvLista.Rows[pIndexRand].Tag as BClientiFacturi;

                if (fact != null)
                {
                    if (FormCreeazaFacturaClient.Afiseaza(this.GetFormParinte(), fact))
                    {
                        //incarcaRand(this.dgvLista.Rows[pIndexRand], fact, fact.GetListaLucrari(null));
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
            setNrLinii(this.dgvLista.FiltreazaDupaText(this.txtCautare.Text));
        }

        private void setNrLinii(int pNrLinii)
        {
            double totalRON = 0;
            double totalEUR = 0;

            BClientiFacturi factura = null;
            foreach (DataGridViewRow rand in this.dgvLista.Rows)
            {
                if (rand.Visible)
                {
                    factura = rand.Tag as BClientiFacturi;

                    if (factura.MonedaFactura == CDefinitiiComune.EnumTipMoneda.Euro)
                        totalEUR += DataGridViewPersonalizat.GetValoareTagColoanaRand(rand, EnumColoaneDGV.colValoare.ToString());
                    else
                        totalRON += DataGridViewPersonalizat.GetValoareTagColoanaRand(rand, EnumColoaneDGV.colValoare.ToString());
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

            this.dgvLista.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvLista.AdaugaColoanaData(EnumColoaneDGV.colDataEmiterii.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataEmiterii), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colTipDocument.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tip), 80, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colSerieFactura.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Serie), 60, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaNumerica(EnumColoaneDGV.colNumarFactura.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Numar), 60, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colClinica.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Clinica), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaButonClasic(EnumColoaneDGV.colDetaliiClinica.ToString(), string.Empty, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DeschideFisaClinicii), DataGridViewPersonalizat._SLatimeButonDeschidere, false);

            this.dgvLista.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colValoare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Valoare), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colAchitat.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Achitat), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colRestPlata.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.RestDePlata), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colObservatii.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colCursBNR.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Curs), 80, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvLista.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvLista.IncepeContructieRanduri();

            BColectieClientiFacturi listaFacturi = BClientiFacturi.GetListByClientSiPerioada(this.ctrlCautareDupaTextClinica.IdObiectAfisajCorespunzator, this.ctrlPerioada.DataInceput, this.ctrlPerioada.DataSfarsit, CDefinitiiComune.EnumStare.Activa, null);

            BColectieClientiComenzi listaLucrari = BClientiComenzi.GetByListaIdFacturi(listaFacturi.GetListaId(), null);

            BColectieClientiPlatiComenzi listaPlatiComenzi = BClientiPlatiComenzi.GetByListIdComenzi(listaLucrari.GetListaId(), null);
            
            BColectieClientiComenzi listaLucrariPeFact = new BColectieClientiComenzi();
            BColectieClientiPlatiComenzi listaPlatiComenziPeFact = new BColectieClientiPlatiComenzi();

            foreach (var fact in listaFacturi)
            {
                if (fact.EsteActiv)
                {
                    listaLucrariPeFact = listaLucrari.GetByIdFactura(fact.Id);
                    listaPlatiComenziPeFact = listaPlatiComenzi.GetByIdComenzi(listaLucrariPeFact.GetListaId());

                    incarcaRand(this.dgvLista.Rows[this.dgvLista.Rows.Add()], fact, listaLucrariPeFact, listaPlatiComenziPeFact);
                }

            }

            filtreazaDupaText();

            this.dgvLista.FinalizeazaContructieRanduri();
        }

        private void incarcaRand(DataGridViewRow pRand, BClientiFacturi pElem, BColectieClientiComenzi pListaLucrari, BColectieClientiPlatiComenzi pListaPlatiPeFact)
        {
            pRand.Tag = pElem;

            double valoare = pListaLucrari.GetValoareTotalaFactura(CDefinitiiComune.EnumTipMoneda.Lei, pElem.CursBNR);
            double achitat = pListaPlatiPeFact.GetValoarePlatita();

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);

            if (pElem.EsteFiscalizata())
            {
                pRand.Cells[EnumColoaneDGV.colTipDocument.ToString()].Value = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Factura);

                DataGridViewPersonalizat.IndeparteazaAlerta(pRand, EnumColoaneDGV.colTipDocument.ToString());
            }
            else
            {
                pRand.Cells[EnumColoaneDGV.colTipDocument.ToString()].Value = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Proforma);

                DataGridViewPersonalizat.SeteazaAlerta(pRand, EnumColoaneDGV.colTipDocument.ToString());
            }

            pRand.Cells[EnumColoaneDGV.colDataEmiterii.ToString()].Value = pElem.DataFactura;
            pRand.Cells[EnumColoaneDGV.colSerieFactura.ToString()].Value = pElem.SerieFactura;
            pRand.Cells[EnumColoaneDGV.colNumarFactura.ToString()].Value = pElem.NumarFactura;
            pRand.Cells[EnumColoaneDGV.colClinica.ToString()].Value = pElem.DenumireClient;
            DataGridViewPersonalizat.InitCelulaValoareMonetara(pRand, EnumColoaneDGV.colValoare.ToString(), valoare, CDefinitiiComune.EnumTipMoneda.Lei);
            //pRand.Cells[EnumColoaneDGV.colValoare.ToString()].Value = ;
            if (pElem.MonedaFactura != CDefinitiiComune.EnumTipMoneda.Lei)
                DataGridViewPersonalizat.SeteazaAlerta(pRand, EnumColoaneDGV.colValoare.ToString());
            pRand.Cells[EnumColoaneDGV.colValoare.ToString()].ToolTipText = CUtil.GetValoareMonetara(valoare, pElem.MonedaFactura);

            DataGridViewPersonalizat.InitCelulaValoareMonetara(pRand, EnumColoaneDGV.colAchitat.ToString(), achitat, CDefinitiiComune.EnumTipMoneda.Lei);
            DataGridViewPersonalizat.InitCelulaValoareMonetara(pRand, EnumColoaneDGV.colRestPlata.ToString(), valoare - achitat, CDefinitiiComune.EnumTipMoneda.Lei);

            pRand.Cells[EnumColoaneDGV.colCursBNR.ToString()].Value = pElem.CursBNR;
            pRand.Cells[EnumColoaneDGV.colObservatii.ToString()].Value = pElem.Observatii;

            DataGridViewPersonalizat.InitCelulaStergere(pRand);

            DataGridViewPersonalizat.InitCelulaDeschideClasic(pRand, EnumColoaneDGV.colDetaliiClinica.ToString());
        }

        private ReportDocument setParamReportDocument()
        {
            BClientiFacturi fact = this.dgvLista.SelectedRow.Tag as BClientiFacturi;
            lRptDoc.SetParameterValue("xnIdFactura", fact.Id);
            return lRptDoc;
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
