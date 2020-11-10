using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Comune;
using CCL.iStomaLab;
using CCL.UI;
using CDL.iStomaLab;
using iStomaLab.Generale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static CDL.iStomaLab.CStructuriComune;

namespace iStomaLab.TablouDeBord.Facturare
{
    public partial class FormCreeazaIncasareClient : FormPersonalizat
    {
        #region Declaratii generale

        private BClienti lClient = null;
        private BColectieClientiComenzi lComenzi = null;
        private BColectieClientiFacturi lFacturi = null;
        private BClientiPlati lPlata = null;
        double lSold = 0, lTotal = 0;

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colData,
            colFactura,
            colDetaliiFactura,
            colValoare,
            colPlatit,
            colRestDePlata,
            colObservatii
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormCreeazaIncasareClient(BClienti pClient, BColectieClientiComenzi pComenzi, BColectieClientiFacturi pFacturi, BClientiPlati pPlata)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lClient = pClient;
            this.lComenzi = pComenzi;
            this.lFacturi = pFacturi;
            this.lPlata = pPlata;

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

            this.ctrlValidareAnulare.Validare += CtrlValidareAnulare_Validare;
            this.ctrlLeiEuro.MonedaSchimbata += CtrlLeiEuro_MonedaSchimbata;
            this.txtCursSchimb.AfterUpdate += TxtCursSchimb_AfterUpdate;
            this.txtSuma.KeyUpPersonalizat += TxtSuma_KeyUpPersonalizat;

            this.dgvListaFacturi.CellClick += DgvListaFacturi_CellClick;
        }

        private void initTextML()
        {
            this.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Incasare);
            this.lblSuma.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Suma);
            this.lblData.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Data);
            this.lblModalitate.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Modalitate);
            this.lblCurs.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Curs);
        }

        void _Load(object sender, EventArgs e)
        {
            try
            {
                Initializeaza(this.lPlata);
                AllowModification(true);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        public void Initializeaza(BClientiPlati pPlata)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.ctrlDataOraIncasare.Initializeaza(DateTime.Now, ComboBoxOra.EnumPas.CinciMinute);
            this.cboModalitateIncasare.DataSource = BDefinitiiGenerale.StructModalitatePlata.GetListaModalitatiAchitare(false);
            //this.cboModalitateIncasare.ValueMember = "Id";
            //this.cboModalitateIncasare.DisplayMember = "Nume";

            //this.txtCursSchimb.ValoareDouble = BComportamentAplicatie.GetCursBNR();
            //this.txtSuma.Goleste();

            if (pPlata != null)
            {
                this.ctrlDataOraIncasare.Initializeaza(pPlata.DataPlata, ComboBoxOra.EnumPas.CinciMinute);
                this.cboModalitateIncasare.SelectedItem = pPlata.ModalitatePlata;
                this.txtCursSchimb.Text = pPlata.CursBNR.ToString();
                this.txtSuma.Text = pPlata.ToStringSumaPlatita();
                this.txtObservatii.Text = pPlata.Observatii;
                this.txtSuma.AllowModification(false);
                this.lblSold.Visible = false;
                this.ctrlLeiEuro.AllowModification(false);
                this.ctrlDataOraIncasare.AllowModification(false);
            }
            else
            {
                this.ctrlDataOraIncasare.Initializeaza(DateTime.Now, ComboBoxOra.EnumPas.CinciMinute);
                this.txtCursSchimb.ValoareDouble = BComportamentAplicatie.GetCursBNR();
                this.txtSuma.Goleste();
                this.txtSuma.Focus();
                this.txtObservatii.Goleste();
                this.cboModalitateIncasare.SelectedItem = BDefinitiiGenerale.EnumModalitatePlata.Banca;
                initTotal();
            }

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            initSoldClient();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void TxtSuma_KeyUpPersonalizat(object sender, KeyEventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();
                initSoldClient();
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

        private void DgvListaFacturi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.lSeIncarca || e.RowIndex < 0) return;
            try
            {
                incepeIncarcarea();

                string numeColoana = this.dgvListaFacturi.Columns[e.ColumnIndex].Name;

                BClientiFacturi factura = this.dgvListaFacturi.Rows[e.RowIndex].Tag as BClientiFacturi;
                if (numeColoana.Equals(EnumColoaneDGV.colDetaliiFactura.ToString()))
                {
                    if (factura != null)
                    {
                        if (FormCreeazaFacturaClient.Afiseaza(this.GetFormParinte(), factura))
                            incarcaRand(this.dgvListaFacturi.Rows[e.RowIndex], factura, factura.GetListaLucrari(null), factura.GetListaPlati(null));
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

        private void CtrlLeiEuro_MonedaSchimbata(object sender, EventArgs e)
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

        private void CtrlValidareAnulare_Validare(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (this.lPlata != null)
                {
                    this.lPlata.Observatii = this.txtObservatii.Text;
                    this.lPlata.ModalitatePlata = getModalitateDePlata();
                    this.lPlata.UpdateAll();

                    inchideEcranulOK();
                }
                else if (salveaza())
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

        private void initSoldClient()
        {
            this.lblSold.Text = string.Format("{0}: {1} LEI", BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Sold), CUtil.GetValoareMonetara(this.lSold - this.txtSuma.ValoareDouble));
        }
        
        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaFacturi.IncepeConstructieColoane();

            this.dgvListaFacturi.AdaugaColoanaData(EnumColoaneDGV.colData.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Data), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA_ORA);

            this.dgvListaFacturi.AdaugaColoanaText(EnumColoaneDGV.colFactura.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Factura), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaFacturi.AdaugaColoanaButonClasic(EnumColoaneDGV.colDetaliiFactura.ToString(), string.Empty, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.AfiseazaLucrarea), DataGridViewPersonalizat._SLatimeButonDeschidere, false);

            this.dgvListaFacturi.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colValoare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Valoare), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvListaFacturi.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colPlatit.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Platit), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvListaFacturi.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colRestDePlata.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.RestDePlata), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvListaFacturi.AdaugaColoanaText(EnumColoaneDGV.colObservatii.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaFacturi.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaFacturi.IncepeContructieRanduri();

            BColectieClientiPlatiComenzi listaPlatiCurente = BClientiPlatiComenzi.GetByListIdComenzi(this.lComenzi.GetListaId(), null);
            Dictionary<int, BColectieClientiComenzi> dictFacturiComenzi = getDictFacturiComenzi();

            BColectieClientiComenzi comenziTemp = new BColectieClientiComenzi();

            //Incarcam lista
            foreach (var elem in this.lFacturi)
            {
                if (dictFacturiComenzi.ContainsKey(elem.Id))
                {
                    comenziTemp = dictFacturiComenzi[elem.Id];
                }
                else
                {
                    comenziTemp = new BColectieClientiComenzi();
                }

                incarcaRand(this.dgvListaFacturi.Rows[this.dgvListaFacturi.Rows.Add()], elem, comenziTemp, listaPlatiCurente);
            }

            this.dgvListaFacturi.FinalizeazaContructieRanduri();
        }

        private void incarcaRand(DataGridViewRow pRand, BClientiFacturi pElem, BColectieClientiComenzi pListaComenzi, BColectieClientiPlatiComenzi pListaPlatiCurente)
        {
            pRand.Tag = pElem;
            double valoare = pElem.GetValoare(pListaComenzi, this.ctrlLeiEuro.Moneda, this.txtCursSchimb.ValoareDouble);
            double platit = pListaPlatiCurente.GetByIdComenzi(pListaComenzi.GetListaId()).GetValoarePlatita();
            double restDePlata = valoare - platit;

            if (pElem.DataFactura != CConstante.DataNula)
                pRand.Cells[EnumColoaneDGV.colData.ToString()].Value = pElem.DataFactura;
            else
                pRand.Cells[EnumColoaneDGV.colData.ToString()].Value = string.Empty;

            pRand.Cells[EnumColoaneDGV.colFactura.ToString()].Value = pElem.ToStringImprimare();
            pRand.Cells[EnumColoaneDGV.colValoare.ToString()].Value = CUtil.GetValoareMonetara(valoare);
            pRand.Cells[EnumColoaneDGV.colPlatit.ToString()].Value = CUtil.GetValoareMonetara(platit);
            pRand.Cells[EnumColoaneDGV.colRestDePlata.ToString()].Value = CUtil.GetValoareMonetara(restDePlata);
            pRand.Cells[EnumColoaneDGV.colObservatii.ToString()].Value = pElem.Observatii;

            DataGridViewPersonalizat.InitCelulaDeschideClasic(pRand, EnumColoaneDGV.colDetaliiFactura.ToString());

            this.lSold += restDePlata;
            this.lTotal += valoare;
        }

        private BDefinitiiGenerale.EnumModalitatePlata getModalitateDePlata()
        {
            if (this.cboModalitateIncasare.SelectedItem == null)
                return BDefinitiiGenerale.EnumModalitatePlata.Nedefinit;

            return ((BDefinitiiGenerale.StructModalitatePlata)this.cboModalitateIncasare.SelectedItem).IdEnum;
        }

        private bool salveaza()
        {
            BDefinitiiGenerale.EnumModalitatePlata modalitate = getModalitateDePlata();

            bool esteValid = this.txtSuma.ValoareDouble > 0 && modalitate != BDefinitiiGenerale.EnumModalitatePlata.Nedefinit && this.ctrlDataOraIncasare.AreValoare && this.ctrlDataOraIncasare.DataAfisata <= DateTime.Now;
            if (esteValid)
            {
                return BClientiPlati.Add(this.lClient.Id, this.ctrlDataOraIncasare.DataAfisata, this.txtSuma.ValoareDouble, modalitate, this.txtCursSchimb.ValoareDouble, this.txtObservatii.Text, this.lComenzi, null) > 0;
            }
            else
            {
                seteazaAlerta();
            }
            return false;
        }

        private void seteazaFocus()
        {
            Control[] lstControale = { this.txtSuma, this.ctrlDataOraIncasare, this.cboModalitateIncasare };

            foreach (var control in lstControale)
            {
                if (string.IsNullOrEmpty(control.Text))
                {
                    control.Focus();
                    break;
                }
            }

        }

        private void seteazaAlerta()
        {
            IHMEfecteSpeciale.AplicaEfectNU(this);
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.txtSuma, this.lblSuma);
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.ctrlDataOraIncasare, this.lblData);
            if (!this.ctrlDataOraIncasare.EsteDinTrecut())
                this.lblData.SeteazaAlerta();
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.cboModalitateIncasare, this.lblModalitate);
            seteazaFocus();
        }

        private Dictionary<int, BColectieClientiComenzi> getDictFacturiComenzi()
        {
            Dictionary<int, BColectieClientiComenzi> dictRetur = new Dictionary<int, BColectieClientiComenzi>();

            if (!CUtil.EsteListaVida<BClientiComenzi>(this.lComenzi))
            {
                BColectieClientiComenzi comenziTemp = new BColectieClientiComenzi();
                int idFacturaTemp = 0;

                foreach (var item in this.lComenzi)
                {
                    idFacturaTemp = item.IdFactura;

                    if (!dictRetur.ContainsKey(idFacturaTemp))
                    {
                        comenziTemp = new BColectieClientiComenzi();
                        comenziTemp.Add(item);
                        dictRetur.Add(idFacturaTemp, comenziTemp);
                    }
                    else
                    {
                        comenziTemp = dictRetur[idFacturaTemp];
                        comenziTemp.Add(item);
                        dictRetur[idFacturaTemp] = comenziTemp;
                    }
                }
            }

            return dictRetur;
        }

        private void initTotal()
        {
            BColectieClientiComenzi listaDinFacturiAfisate = this.lComenzi.GetByListaIdFacturi(this.lFacturi.GetListaId());
            BColectieClientiPlatiComenzi listaPlatiCurente = BClientiPlatiComenzi.GetByListIdComenzi(listaDinFacturiAfisate.GetListaId(), null);
            double platit = listaPlatiCurente.GetByIdComenzi(listaDinFacturiAfisate.GetListaId()).GetValoarePlatita();
            double totalFacturi = listaDinFacturiAfisate.GetTotal(this.ctrlLeiEuro.Moneda, this.txtCursSchimb.GetValoareMonetara());

            this.txtSuma.ValoareDouble = totalFacturi - platit;
            initColoanaValoareFacturata();
        }

        private void initColoanaValoareFacturata()
        {
            BClientiFacturi facturaTemp = null;
            CDefinitiiComune.EnumTipMoneda moneda = this.ctrlLeiEuro.Moneda;
            double cursSchimb = this.txtCursSchimb.ValoareDouble;

            Dictionary<int, BColectieClientiComenzi> dictFacturiComenzi = getDictFacturiComenzi();

            BColectieClientiComenzi comenziTemp = new BColectieClientiComenzi();

            foreach (DataGridViewRow rand in this.dgvListaFacturi.Rows)
            {
                facturaTemp = rand.Tag as BClientiFacturi;

                if (dictFacturiComenzi.ContainsKey(facturaTemp.Id))
                {
                    comenziTemp = dictFacturiComenzi[facturaTemp.Id];
                }
                else
                {
                    comenziTemp = new BColectieClientiComenzi();
                }

                DataGridViewPersonalizat.InitCelulaValoareMonetara(rand, EnumColoaneDGV.colValoare.ToString(), facturaTemp.GetValoare(comenziTemp, moneda, cursSchimb), moneda);
            }
        }

        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente, BClienti pClient, BColectieClientiComenzi pComenzi, BColectieClientiFacturi pFacturi, BClientiPlati pPlata)
        {
            using (FormCreeazaIncasareClient ecran = new FormCreeazaIncasareClient(pClient, pComenzi, pFacturi, pPlata))
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
