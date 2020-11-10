using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Comune;
using BLL.iStomaLab.Locatii;
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
using System.Windows.Forms;
using static iStomaLab.Imprimare.FormImprimareCReports;

namespace iStomaLab.TablouDeBord.Facturare
{
    public partial class FormCreeazaFacturaClient : FormPersonalizat
    {

        #region Declaratii generale

        private BColectieClientiComenzi lListaLucrari = null;
        private BClienti lClient = null;
        private ReportDocument lRptDoc = new ReportDocument();
        private BClientiFacturi lFactura = null;

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colData,
            colLucrare,
            colNrElemente,
            colPretUnitar, //calculat valoare/nr elem
            colTotal,
            colFacturat,
            colPacient,
            colDetaliiLucrare
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormCreeazaFacturaClient(BClienti pClient, BColectieClientiComenzi pListaLucrari, BClientiFacturi pFactura)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lListaLucrari = pListaLucrari;
            this.lClient = pClient;
            this.lFactura = pFactura;

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                this.txtSerieFactura.MaxLength = BClientiFacturi.StructCampuriTabela.SerieFacturaMaxLength;
                this.txtObservatii.MaxLength = BClientiFacturi.StructCampuriTabela.ObservatiiMaxLength;

                adaugaHandlere();
                initTextML();

                this.CentratCuDeplasare();
            }
        }

        private void adaugaHandlere()
        {
            this.Load += _Load;

            this.ctrlMoneda.MonedaSchimbata += CtrlMoneda_MonedaSchimbata;
            this.txtCursSchimb.AfterUpdate += TxtCursSchimb_AfterUpdate;

            this.ctrlValidareAnulare.Validare += CtrlValidareAnulare_Validare;

            this.btnImprima.Click += BtnImprima_Click;
            this.btnFiscalizeaza.Click += BtnFiscalizeaza_Click;

            this.dgvLista.StergereLinie += DgvLista_StergereLinie;
            this.dgvLista.CellClick += DgvLista_CellClick;

            this.txtCautare.CerereUpdate += TxtCautare_CerereUpdate;

            this.btnAdauga.Click += BtnAdauga_Click;
        }

        private void initTextML()
        {
            this.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Factura);

            this.lblTip.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tip);
            this.lblData.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Data);
            this.lblTotal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Total);
            this.lblLucrari.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Lucrari);
            this.lblCurs.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Curs);
            this.lblMoneda.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Moneda);
            this.lblSerieNr.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.SerieNr);
            this.lblObservatii.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii);
            this.btnFiscalizeaza.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Fiscalizeaza);
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
            this.txtTotal.AllowModification(false);

            this.txtSerieFactura.AllowModification(false);
            this.txtNumarFactura.AllowModification(false);
          
            this.cboTip.DataSource = BClientiFacturi.StructTipDocumentNotaPlata.GetList();
            this.cboTip.ValueMember = "Id";
            this.cboTip.DisplayMember = "Nume";

            if (this.lFactura == null || !this.lFactura.EsteFiscalizata())
            {
                //este proforma:
                this.ctrlDataOraFactura.Initializeaza(DateTime.Now, ComboBoxOra.EnumPas.CinciMinute);
                this.txtCursSchimb.ValoareDouble = BComportamentAplicatie.GetCursBNR();
                this.txtSerieFactura.Goleste();
                this.txtNumarFactura.Goleste();
                this.txtObservatii.Goleste();
                this.txtNumarFactura.Visible = false;
                this.txtSerieFactura.Visible = false;
                this.lblSerieNr.Visible = false;
                this.lblSeparatorSerieNumarFactura.Visible = false;
                this.btnFiscalizeaza.Visible = this.lFactura != null;
                this.cboTip.SelectedItem = BClientiFacturi.EnumTipDocumentNotaPlata.Proforma;
            }
            else
            {
                //este factura:
                this.ctrlDataOraFactura.Initializeaza(this.lFactura.DataFactura, ComboBoxOra.EnumPas.CinciMinute);
                this.txtCursSchimb.ValoareDouble = this.lFactura.CursBNR;
                this.txtSerieFactura.Text = this.lFactura.SerieFactura;
                this.txtNumarFactura.Text = this.lFactura.NumarFactura.ToString();
                this.txtObservatii.Text = this.lFactura.Observatii;
                this.ctrlMoneda.Moneda = this.lFactura.MonedaFactura;

                this.btnFiscalizeaza.Visible = !this.lFactura.EsteFiscalizata();

                //this.txtNumarFactura.Visible = false;
                //this.txtSerieFactura.Visible = false;
                //this.lblSerieNr.Visible = false;
                //this.lblSeparatorSerieNumarFactura.Visible = false;

                this.cboTip.SelectedItem = this.lFactura.GetTipDocumentNotaPlata();
                this.cboTip.AllowModification(false);
            }

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            initTotal();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void BtnAdauga_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BColectieClientiComenzi listaComenziDeAdaugat = TablouDeBord.Clienti.FormSelectieLucrariNefacturate.Afiseaza(this.GetFormParinte(), this.lClient, getListaLucrari());

                //Daca avem ceva atunci vom adauga in DGV si vom recalcula totalul

                if (!CUtil.EsteListaVida<BClientiComenzi>(listaComenziDeAdaugat))
                {
                    foreach (var item in listaComenziDeAdaugat)
                    {
                        incarcaRand(this.dgvLista.AdaugaRandNou(), item);

                        if(this.lFactura != null)
                        {
                            item.IdFactura = this.lFactura.Id;
                            item.UpdateAll();
                        }
                    }

                    initTotal();
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

        private void BtnFiscalizeaza_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BLocatii firma = BLocatii.GetLocatieCurenta();
                string serieFactura = firma.SerieFacturi;

                if (serieFactura == string.Empty)
                    Mesaj.Informare(this.GetFormParinte(), string.Format("{0}: {1}", BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NuExistaSerieFacturaAlocataPeLocatie), firma.Denumire), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Facturare));
                else
                {
                    this.lFactura.Fiscalizeaza(null);

                    inchideEcranulOK();
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

        private void DgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.lSeIncarca || e.RowIndex < 0) return;
            try
            {
                incepeIncarcarea();

                string numeColoana = this.dgvLista.Columns[e.ColumnIndex].Name;

                BClientiComenzi comanda = this.dgvLista.Rows[e.RowIndex].Tag as BClientiComenzi;
                if (numeColoana.Equals(EnumColoaneDGV.colTotal.ToString()))
                {
                    //Cerem valoarea

                    Tuple<double, CDefinitiiComune.EnumTipMoneda> valoare = CCL.UI.IHMUtile.GetValoareMonetara(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Total), comanda.ValoareFinala, comanda.Moneda);

                    if (valoare != null)
                    {
                        comanda.Moneda = valoare.Item2;
                        comanda.ValoareFinala = valoare.Item1;
                        comanda.UpdateAll();

                        incarcaRand(this.dgvLista.Rows[e.RowIndex], comanda);

                        initTotal();
                    }
                }
                else
                {
                    if (numeColoana.Equals(EnumColoaneDGV.colDetaliiLucrare.ToString()))
                    {
                        if (IHMUtile.DeschideComanda(this.GetFormParinte(), comanda.Id))
                        {
                            comanda.Refresh(null);
                            incarcaRand(this.dgvLista.Rows[e.RowIndex], comanda);
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

                this.dgvLista.FiltreazaDupaText(this.txtCautare.Text);
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

                BClientiComenzi fisa = this.dgvLista.Rows[pIndexRand].Tag as BClientiComenzi;
                if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), fisa.ToString()))
                {
                    if (this.lFactura != null)
                    {
                        fisa.IdFactura = 0;
                        fisa.UpdateAll();
                    }

                    this.dgvLista.Rows.RemoveAt(pIndexRand);

                    initTotal();
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

        private void CtrlValidareAnulare_Validare(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                salveaza();
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

        private void TxtCursSchimb_AfterUpdate(Control sender, string sNumeProprietateAtasata, string sNouaValoare)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                initTotal();
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

        private void CtrlMoneda_MonedaSchimbata(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                initTotal();
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

                salveaza();

                //Imprimare.CImprimareFacturaClient.Imprima(this.GetFormParinte(), this.lFactura);

                string rptImprimare = CUtil.GetLocatieRapoarte();
                if (this.lFactura == null || !this.lFactura.EsteFiscalizata())
                {
                    //este proforma
                    rptImprimare += "RptProformaClient.rpt";
                    SetareParametriiRaport(rptImprimare);
                }
                else
                {
                    //este factura
                    rptImprimare += "RptFacturaClient.rpt";
                    SetareParametriiRaport(rptImprimare); 
                }

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

        private BClientiFacturi.EnumTipDocumentNotaPlata getTipDocument()
        {
            if (this.cboTip.SelectedItem != null)
            {
                return ((BClientiFacturi.StructTipDocumentNotaPlata)this.cboTip.SelectedItem).IdEnum;
            }

            return BClientiFacturi.EnumTipDocumentNotaPlata.Proforma;
        }

        private void salveaza()
        {
            if (this.lFactura == null)
            {
                int idFact = BClientiFacturi.Add(this.lClient.Id, this.ctrlDataOraFactura.DataAfisata, this.txtSerieFactura.Text, this.txtNumarFactura.ValoareIntreaga, this.txtObservatii.Text, this.ctrlMoneda.Moneda, this.txtCursSchimb.GetValoareMonetara(), getListaLucrari(), getTipDocument(), null);

                this.lFactura = new BClientiFacturi(idFact);
                Initializeaza();
            }
            else
            {
                this.lFactura.DataFactura = this.ctrlDataOraFactura.DataAfisata;
                this.lFactura.SerieFactura = this.txtSerieFactura.Text;
                this.lFactura.NumarFactura = this.txtNumarFactura.ValoareIntreaga;
                this.lFactura.CursBNR = this.txtCursSchimb.GetValoareMonetara();
                this.lFactura.MonedaFactura = this.ctrlMoneda.Moneda;
                this.lFactura.Observatii = this.txtObservatii.Text;
                this.lFactura.UpdateAll();
            }
        }

        private BColectieClientiComenzi getListaLucrari()
        {
            return this.dgvLista.GetListaObiecte<BColectieClientiComenzi, BClientiComenzi>();
        }

        private void initTotal()
        {
            this.txtTotal.ValoareDouble = getListaLucrari().GetTotal(this.ctrlMoneda.Moneda, this.txtCursSchimb.GetValoareMonetara());
            initColoanaValoareFacturata();
        }

        private void SetareParametriiRaport(string pRptImprimare)
        {
            StructParametriiRaport structParam = new StructParametriiRaport();
            this.lRptDoc.Load(pRptImprimare);
            structParam.lFactura = this.lFactura;
            structParam.lRptImprimare = pRptImprimare;
            structParam.lRptDoc = setParamReportDocument();
            structParam.lRptDoc.Load(pRptImprimare);

            FormImprimareCReports.Afiseaza(this.GetFormParinte(), structParam);
        }

        private void initColoanaValoareFacturata()
        {
            BClientiComenzi lucrareTemp = null;
            CDefinitiiComune.EnumTipMoneda moneda = this.ctrlMoneda.Moneda;
            double cursSchimb = this.txtCursSchimb.ValoareDouble;
            foreach (DataGridViewRow rand in this.dgvLista.Rows)
            {
                lucrareTemp = rand.Tag as BClientiComenzi;

                DataGridViewPersonalizat.InitCelulaValoareMonetara(rand, EnumColoaneDGV.colFacturat.ToString(), lucrareTemp.GetValoareMoneda(moneda, cursSchimb), moneda);
            }
        }

        private void ConstruiesteColoaneDGV()
        {
            this.dgvLista.IncepeConstructieColoane();

            this.dgvLista.AdaugaColoanaData(EnumColoaneDGV.colData.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Data), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA_ORA);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colPacient.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pacient), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colLucrare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Lucrare), 130, true, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaButonClasic(EnumColoaneDGV.colDetaliiLucrare.ToString(), string.Empty, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.AfiseazaLucrarea), DataGridViewPersonalizat._SLatimeButonDeschidere, false);

            this.dgvLista.AdaugaColoanaNumerica(EnumColoaneDGV.colNrElemente.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrElem), 40, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colPretUnitar.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PretUnitar), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colTotal.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PretTotal), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colFacturat.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PretFactura), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvLista.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvLista.IncepeContructieRanduri();

            //Incarcam lista
            foreach (var elem in this.lListaLucrari)
            {
                incarcaRand(this.dgvLista.Rows[this.dgvLista.Rows.Add()], elem);
            }

            this.dgvLista.FinalizeazaContructieRanduri();
        }

        private void incarcaRand(DataGridViewRow pRand, BClientiComenzi pElem)
        {
            pRand.Tag = pElem;

            if (pElem.DataPrimire != CConstante.DataNula)
                pRand.Cells[EnumColoaneDGV.colData.ToString()].Value = pElem.DataPrimire;
            else
                pRand.Cells[EnumColoaneDGV.colData.ToString()].Value = string.Empty;

            pRand.Cells[EnumColoaneDGV.colLucrare.ToString()].Value = pElem.DenumireLucrare;
            pRand.Cells[EnumColoaneDGV.colNrElemente.ToString()].Value = pElem.NrElemente;
            pRand.Cells[EnumColoaneDGV.colPretUnitar.ToString()].Value = CUtil.GetValoareMonetara(pElem.GetPretUnitar(), pElem.Moneda);
            pRand.Cells[EnumColoaneDGV.colTotal.ToString()].Value = CUtil.GetValoareMonetara(pElem.ValoareFinala, pElem.Moneda);
            pRand.Cells[EnumColoaneDGV.colFacturat.ToString()].Value = CUtil.GetValoareMonetara(pElem.GetValoareMoneda(this.ctrlMoneda.Moneda, this.txtCursSchimb.ValoareDouble), this.ctrlMoneda.Moneda);
            pRand.Cells[EnumColoaneDGV.colPacient.ToString()].Value = pElem.GetNumePrenumePacient();

            if (pElem.EstePretulModificat())
            {
                DataGridViewPersonalizat.SeteazaAlerta(pRand, EnumColoaneDGV.colTotal.ToString());
            }
            else
                DataGridViewPersonalizat.IndeparteazaAlerta(pRand, EnumColoaneDGV.colTotal.ToString());

            DataGridViewPersonalizat.InitCelulaStergere(pRand);
            DataGridViewPersonalizat.InitCelulaDeschideClasic(pRand, EnumColoaneDGV.colDetaliiLucrare.ToString());
        }

        private ReportDocument setParamReportDocument()
        {
            lRptDoc.SetParameterValue("xnIdFactura", this.lFactura.Id);
            return lRptDoc;
        }

        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente, BClientiFacturi pFactura)
        {
            return Afiseaza(pEcranPariente, pFactura.GetClient(null), pFactura.GetListaLucrari(null), pFactura);
        }

        public static bool Afiseaza(Form pEcranPariente, BClienti pClient, BColectieClientiComenzi pListaLucrari, BClientiFacturi pFactura)
        {
            if (pClient == null)
            {
                Mesaj.Afiseaza(pEcranPariente, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.SelectatiClinica));
                return false;
            }

            if (CUtil.EsteListaVida<BClientiComenzi>(pListaLucrari))
            {
                Mesaj.Afiseaza(pEcranPariente, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.SelectatiLucrarile));
                return false;
            }

            using (FormCreeazaFacturaClient ecran = new FormCreeazaFacturaClient(pClient, pListaLucrari, pFactura))
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
