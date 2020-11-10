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
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Referinta;
using CCL.UI;
using CCL.iStomaLab;
using iStomaLab.TablouDeBord.Facturare;
using CDL.iStomaLab;

namespace iStomaLab.TablouDeBord.Clienti
{
    public partial class ControlDosarClientPlati : UserControlPersonalizat
    {

        #region Declaratii generale

        private BClienti lClient = null;

        private double lTotalFacturiInRON = 0;
        private double lTotalIncasariInRON = 0;

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGVFacturi
        {
            colDataEmiterii,
            colSerieFactura,
            colNumarFactura,
            colValoare,
            colPlatit,
            colRest,
            colCursBNR,
            colObservatii,
            colTipDocument
        }

        private enum EnumColoaneDGVIncasari
        {
            colData,
            colModalitate,
            colValoare,
            colCursBNR,
            colDetaliiIncasare,
            colObservatii
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlDosarClientPlati()
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
            this.dgvFacturi.EditareLinie += DgvFacturi_EditareLinie;
            this.dgvFacturi.StergereLinie += DgvFacturi_StergereLinie;
            this.btnAdaugaIncasare.Click += BtnAdaugaIncasare_Click;
            this.dgvIncasari.EditareLinie += DgvIncasari_EditareLinie;
            this.dgvIncasari.StergereLinie += DgvIncasari_StergereLinie;
            this.btnAdaugaFactura.Click += BtnAdaugaFactura_Click;
        }

        private void initTextML()
        {
            this.lblTitluFacturi.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Facturi);
            this.lblTitluIncasari.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Incasari);
            this.lblDenumireFiscala.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DenFisc);
            this.lblTip.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tip);
            this.lblCUI.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CUI);
            this.lblNrRegCom.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.RegCom);
            this.lblIBAN.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.IBAN);
            this.lblBanca.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Banca);
            this.lblReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Repr);
            this.lblNrContract.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrContr);
            this.lblDataContract.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataContr);
            this.lblObservatiiDateFirma.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii);

            this.lblTotalIncasari.Text = string.Format("{0}: {1}", BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Incasari), 0);
        }

        public void Initializeaza(BClienti pClient)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.lClient = pClient;

            initListe();

            this.txtDenumireFiscala.Text = this.lClient.DenumireFiscala;
            this.cboTipClient.SelectedIndex = this.lClient.TipClient;
            this.txtCUI.Text = this.lClient.CUI;
            this.txtNrRegCom.Text = this.lClient.RegCom;
            this.txtIBAN.Text = this.lClient.Iban;
            if (this.lClient.IdBanca != 0)
                this.ctrlCautareBanca.Initializeaza(new StructIdDenumire(this.lClient.IdBanca, BBanci.getBanca(this.lClient.IdBanca, null).Denumire), CEnumerariComune.EnumTipDeschidere.DreaptaJos);
            else
                this.ctrlCautareBanca.Initializeaza(StructIdDenumire.Empty, CEnumerariComune.EnumTipDeschidere.DreaptaJos);
            this.txtReprezentantLegal.Text = this.lClient.ReprezentantLegal;
            this.cboTipReprezentant.SelectedIndex = this.lClient.CalitateReprezentant;
            if (this.lClient.NumarContract != 0)
                this.txtNrContract.Text = this.lClient.NumarContract.ToString();
            else
                this.txtNrContract.Goleste();
            this.ctrlDataContract.DataAfisata = this.lClient.DataContract;
            this.txtObservatiiDateFirma.Text = this.lClient.ObservatiiDateFirma;

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            ConstruiesteColoaneDGVIncasari();
            ConstruiesteRanduriDGVIncasari();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente
        private void BtnAdaugaFactura_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BColectieClientiComenzi listaLucrari = this.lClient.GetListaLucrariNefacturate(null);

                if (CUtil.EsteListaVida<BClientiComenzi>(listaLucrari))
                {
                    Mesaj.Afiseaza(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NuExistaLucrariDeLaAceastaClinica));
                }
                else
                {
                    if (FormCreeazaFacturaClient.Afiseaza(this.GetFormParinte(), this.lClient, listaLucrari, null))
                    {
                        ConstruiesteRanduriDGV();

                        setSold();
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

        private void BtnAdaugaIncasare_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BColectieClientiComenzi listaLucrari = BClientiComenzi.GetListaNeachitateIntegral(this.lClient.Id, null);
                // BColectieClientiComenzi listaLucrari = BClientiComenzi.GetByIdClient(this.lClient.Id, null); 
                // BClientiComenzi.GetByListaIdFacturi(listaFacturi.GetListaId(), null);

                BColectieClientiFacturi listaFacturi = BClientiFacturi.getByListaId(listaLucrari.GetListaIdFacturi(), null);
                // BClientiFacturi.GetListaNeachitateIntegral(this.lClient.Id, null);
                // GetListByClient(this.lClient.Id, CDefinitiiComune.EnumStare.Activa, null).GetListaNeachitateIntegral(listaLucrari);

                if (!CUtil.EsteListaVida<BClientiFacturi>(listaFacturi))
                {
                    if (FormCreeazaIncasareClient.Afiseaza(this.GetFormParinte(), this.lClient, listaLucrari, listaFacturi, null))
                    {
                        ConstruiesteRanduriDGV();
                        ConstruiesteRanduriDGVIncasari();
                    }
                }
                else
                {
                    Mesaj.Afiseaza(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NuExistaLucrariDeLaAceastaClinica));
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

        private void DgvFacturi_StergereLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca || pIndexRand < 0) return;
            try
            {
                incepeIncarcarea();

                if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stergere)))
                {
                    BClientiFacturi factura = this.dgvFacturi.Rows[pIndexRand].Tag as BClientiFacturi;
                    factura.Close(true, string.Empty, null);
                    ConstruiesteRanduriDGV();

                    setSold();
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

        private void DgvIncasari_StergereLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BClientiPlati incasariDeSters = this.dgvIncasari.Rows[pIndexRand].Tag as BClientiPlati;

                if (incasariDeSters != null)
                {
                    if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stergere)))
                    {
                        BClientiPlati incasare = this.dgvIncasari.Rows[pIndexRand].Tag as BClientiPlati;
                        incasare.Close(true, string.Empty, null);
                        ConstruiesteRanduriDGV();
                        ConstruiesteRanduriDGVIncasari();

                        setSold();
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

        private void DgvIncasari_EditareLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BClientiPlati plata = this.dgvIncasari.Rows[pIndexRand].Tag as BClientiPlati;

                if (plata != null)
                {
                    BColectieClientiPlatiComenzi listaPlati = BClientiPlatiComenzi.GetByIdPlata(plata.Id, null);
                    if (!CUtil.EsteListaVida<BClientiPlatiComenzi>(listaPlati))
                    {
                        BColectieClientiComenzi listaLucrari = BClientiComenzi.getByListaId(listaPlati.GetListaIdComenzi(), null);

                        BColectieClientiFacturi listaFacturi = BClientiFacturi.GetByListId(listaLucrari.GetListaIdFacturi(), null);

                        if (FormCreeazaIncasareClient.Afiseaza(this.GetFormParinte(), this.lClient, listaLucrari, listaFacturi, plata))
                        {
                            incarcaRandIncasare(this.dgvIncasari.Rows[pIndexRand], plata);
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

        private void DgvFacturi_EditareLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BClientiFacturi fact = this.dgvFacturi.Rows[pIndexRand].Tag as BClientiFacturi;

                if (fact != null)
                {
                    if (FormCreeazaFacturaClient.Afiseaza(this.GetFormParinte(), fact))
                    {
                        incarcaRand(this.dgvFacturi.Rows[pIndexRand], fact, fact.GetListaLucrari(null), fact.GetListaPlati(null));

                        setTotalFacturi();

                        setSold();
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

        private void initListe()
        {
            this.cboTipReprezentant.DataSource = BDefinitiiGenerale.StructCalitateReprezentant.getListaRolCuEmpty();
            this.cboTipClient.DataSource = BDefinitiiGenerale.StructTipFiscalitate.GetListaTipFiscalitate();

            this.cboTipReprezentant.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboTipClient.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ConstruiesteColoaneDGVIncasari()
        {
            this.dgvIncasari.IncepeConstructieColoane();

            this.dgvIncasari.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvIncasari.AdaugaColoanaData(EnumColoaneDGVIncasari.colData.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Data), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvIncasari.AdaugaColoanaText(EnumColoaneDGVIncasari.colModalitate.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Modalitate), 150, false, DataGridViewColumnSortMode.Automatic);

            this.dgvIncasari.AdaugaColoanaValoareMonetara(EnumColoaneDGVIncasari.colValoare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Valoare), 150, DataGridViewColumnSortMode.Automatic);

            this.dgvIncasari.AdaugaColoanaText(EnumColoaneDGVFacturi.colObservatii.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvIncasari.AdaugaColoanaText(EnumColoaneDGVIncasari.colCursBNR.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CursBNR), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvIncasari.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvIncasari.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteColoaneDGV()
        {
            this.dgvFacturi.IncepeConstructieColoane();

            this.dgvFacturi.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvFacturi.AdaugaColoanaData(EnumColoaneDGVFacturi.colDataEmiterii.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataEmiterii), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvFacturi.AdaugaColoanaText(EnumColoaneDGVFacturi.colTipDocument.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tip), 60, false, DataGridViewColumnSortMode.Automatic);

            this.dgvFacturi.AdaugaColoanaText(EnumColoaneDGVFacturi.colSerieFactura.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Serie), 60, false, DataGridViewColumnSortMode.Automatic);

            this.dgvFacturi.AdaugaColoanaNumerica(EnumColoaneDGVFacturi.colNumarFactura.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Nr), 60, DataGridViewColumnSortMode.Automatic);

            this.dgvFacturi.AdaugaColoanaValoareMonetara(EnumColoaneDGVFacturi.colValoare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Valoare), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvFacturi.AdaugaColoanaValoareMonetara(EnumColoaneDGVFacturi.colPlatit.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Platit), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvFacturi.AdaugaColoanaValoareMonetara(EnumColoaneDGVFacturi.colRest.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.RestDePlata), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvFacturi.AdaugaColoanaText(EnumColoaneDGVFacturi.colObservatii.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvFacturi.AdaugaColoanaValoareMonetara(EnumColoaneDGVFacturi.colCursBNR.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Curs), 80, DataGridViewColumnSortMode.Automatic);

            this.dgvFacturi.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvFacturi.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGVIncasari()
        {
            this.dgvIncasari.IncepeContructieRanduri();

            BColectieClientiPlati listaPlati = BClientiPlati.GetListByParamIdClient(this.lClient.Id, CDefinitiiComune.EnumStare.Activa, null);

            foreach (var item in listaPlati)
            {
                incarcaRandIncasare(this.dgvIncasari.Rows[this.dgvIncasari.Rows.Add()], item);
            }

            this.dgvIncasari.FinalizeazaContructieRanduri();

            setTotalIncasari();

            setSold();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvFacturi.IncepeContructieRanduri();

            BColectieClientiFacturi listaFacturi = BClientiFacturi.GetListByClient(this.lClient.Id, CDL.iStomaLab.CDefinitiiComune.EnumStare.Toate, null);

            BColectieClientiComenzi listaLucrari = BClientiComenzi.GetByListaIdFacturi(listaFacturi.GetListaId(), null);
            BColectieClientiPlatiComenzi listaPlatiComenzi = BClientiPlatiComenzi.GetByListIdComenzi(listaLucrari.GetListaId(), null);

            BColectieClientiComenzi listaLucrariPeFact = new BColectieClientiComenzi();
            BColectieClientiPlatiComenzi listaPlatiComenziPeFact = new BColectieClientiPlatiComenzi();

            //Incarcam lista
            foreach (var fact in listaFacturi)
            {
                if (fact.EsteActiv)
                {
                    listaLucrariPeFact = listaLucrari.GetByIdFactura(fact.Id);
                    listaPlatiComenziPeFact = listaPlatiComenzi.GetByIdComenzi(listaLucrariPeFact.GetListaId());
                    incarcaRand(this.dgvFacturi.Rows[this.dgvFacturi.Rows.Add()], fact, listaLucrariPeFact, listaPlatiComenziPeFact);
                }
            }

            this.dgvFacturi.FinalizeazaContructieRanduri();

            setTotalFacturi();
            //this.lblTotalFacturi.Text = string.Format("{0}: {1}", BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Facturi), this.dgvFacturi.RowCount.ToString());
        }

        private void incarcaRand(DataGridViewRow pRand, BClientiFacturi pElem, BColectieClientiComenzi pListaLucrari, BColectieClientiPlatiComenzi pListaPlatiPeFact)
        {
            pRand.Tag = pElem;
            double valoare = pListaLucrari.GetValoareTotalaFactura(CDefinitiiComune.EnumTipMoneda.Lei, pElem.CursBNR);
            double achitat = pListaPlatiPeFact.GetValoarePlatita(); //pListaPlatiPeFact.GetSumaPlatita();

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);

            pRand.Cells[EnumColoaneDGVFacturi.colDataEmiterii.ToString()].Value = pElem.DataFactura;
            pRand.Cells[EnumColoaneDGVFacturi.colTipDocument.ToString()].Value = pElem.ToStringTipDocument();
            pRand.Cells[EnumColoaneDGVFacturi.colSerieFactura.ToString()].Value = pElem.SerieFactura;
            pRand.Cells[EnumColoaneDGVFacturi.colNumarFactura.ToString()].Value = pElem.NumarFactura != 0 ? pElem.NumarFactura: pElem.Id;
            DataGridViewPersonalizat.InitCelulaValoareMonetara(pRand, EnumColoaneDGVFacturi.colValoare.ToString(), valoare, CDefinitiiComune.EnumTipMoneda.Lei);
            if (pElem.MonedaFactura != CDefinitiiComune.EnumTipMoneda.Lei)
                DataGridViewPersonalizat.SeteazaAlerta(pRand, EnumColoaneDGVFacturi.colValoare.ToString());
            pRand.Cells[EnumColoaneDGVFacturi.colValoare.ToString()].ToolTipText = CUtil.GetValoareMonetara(valoare, pElem.MonedaFactura);

            DataGridViewPersonalizat.InitCelulaValoareMonetara(pRand, EnumColoaneDGVFacturi.colPlatit.ToString(), achitat, CDefinitiiComune.EnumTipMoneda.Lei);
            DataGridViewPersonalizat.InitCelulaValoareMonetara(pRand, EnumColoaneDGVFacturi.colRest.ToString(), valoare - achitat, CDefinitiiComune.EnumTipMoneda.Lei);

            if (valoare - achitat != 0)
                DataGridViewPersonalizat.SeteazaCuloareTextCelula(pRand, EnumColoaneDGVFacturi.colRest.ToString(), Color.Red);
            else
                DataGridViewPersonalizat.SeteazaCuloareTextCelula(pRand, EnumColoaneDGVFacturi.colRest.ToString(), Color.Black);


            pRand.Cells[EnumColoaneDGVFacturi.colCursBNR.ToString()].Value = pElem.CursBNR;
            pRand.Cells[EnumColoaneDGVFacturi.colObservatii.ToString()].Value = pElem.Observatii;

            DataGridViewPersonalizat.InitCelulaStergere(pRand);
        }

        private void incarcaRandIncasare(DataGridViewRow pRand, BClientiPlati pElem)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);

            pRand.Cells[EnumColoaneDGVIncasari.colData.ToString()].Value = pElem.DataPlata;
            pRand.Cells[EnumColoaneDGVIncasari.colModalitate.ToString()].Value = BDefinitiiGenerale.StructModalitatePlata.GetStringByEnum((BDefinitiiGenerale.EnumModalitatePlata)pElem.ModalitatePlata);
            DataGridViewPersonalizat.InitCelulaValoareMonetara(pRand, EnumColoaneDGVIncasari.colValoare.ToString(), pElem.SumaPlatita, CDefinitiiComune.EnumTipMoneda.Lei);

            pRand.Cells[EnumColoaneDGVFacturi.colObservatii.ToString()].Value = pElem.Observatii;
            pRand.Cells[EnumColoaneDGVIncasari.colCursBNR.ToString()].Value = pElem.CursBNR;

            DataGridViewPersonalizat.InitCelulaStergere(pRand);
        }

        private void setTotalFacturi()
        {
            double totalRON = 0;
            double totalEUR = 0;

            this.lTotalFacturiInRON = 0;
            BClientiFacturi factura = null;
            double valTemp = 0;
            foreach (DataGridViewRow rand in this.dgvFacturi.Rows)
            {
                if (rand.Visible)
                {
                    factura = rand.Tag as BClientiFacturi;
                    valTemp = DataGridViewPersonalizat.GetValoareTagColoanaRand(rand, EnumColoaneDGVFacturi.colValoare.ToString());
                    if (factura.MonedaFactura == CDefinitiiComune.EnumTipMoneda.Euro)
                    {
                        totalEUR += valTemp;
                        this.lTotalFacturiInRON += CUtil.GetValoareMoneda(valTemp, factura.MonedaFactura, factura.CursBNR, CDefinitiiComune.EnumTipMoneda.Lei);
                    }
                    else
                    {
                        totalRON += valTemp;
                        this.lTotalFacturiInRON += valTemp;
                    }
                }
            }

            this.lblTotalFacturi.Text = string.Format("{0}: {1} [{2}: {3}]",
                BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Facturi),
                this.dgvFacturi.RowCount,
                BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Total),
               CUtil.getValoareMonetaraLeiPlusEuro(totalRON, totalEUR));


        }

        private void setTotalIncasari()
        {
            double totalRON = 0;

            BClientiPlati plata = null;
            this.lTotalIncasariInRON = 0;
            double valTemp = 0;
            foreach (DataGridViewRow rand in this.dgvIncasari.Rows)
            {
                if (rand.Visible)
                {
                    plata = rand.Tag as BClientiPlati;

                    valTemp = DataGridViewPersonalizat.GetValoareTagColoanaRand(rand, EnumColoaneDGVIncasari.colValoare.ToString());
                    totalRON += valTemp;

                }
            }

            this.lTotalIncasariInRON = totalRON;

            this.lblTotalIncasari.Text = string.Format("{0}: {1} [{2}: {3}]",
                        BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Incasari),
                        this.dgvIncasari.RowCount,
                        BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Total),
                       CUtil.GetValoareMonetara(totalRON));
        }

        private void setSold()
        {
            double sold = this.lTotalIncasariInRON - this.lTotalFacturiInRON;

            this.lblSold.Text = string.Format("{0}: {1}", BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Sold), CUtil.GetValoareMonetaraLei(sold));

            this.lblSold.GestioneazaAlertaValoareNegativa(sold);
        }

        #endregion

        #region Metode publice

        internal void UpdateDateFiscale()
        {
            this.lClient.DenumireFiscala = this.txtDenumireFiscala.Text;
            this.lClient.TipClient = this.cboTipClient.SelectedIndex;
            this.lClient.CUI = this.txtCUI.Text;
            this.lClient.RegCom = this.txtNrRegCom.Text;
            this.lClient.Iban = this.txtIBAN.Text;
            this.lClient.IdBanca = this.ctrlCautareBanca.IdObiectAfisajCorespunzator;
            this.lClient.ReprezentantLegal = this.txtReprezentantLegal.Text;
            this.lClient.CalitateReprezentant = this.cboTipReprezentant.SelectedIndex;
            this.lClient.NumarContract = CUtil.GetAsInt32(this.txtNrContract.Text);
            this.lClient.DataContract = this.ctrlDataContract.DataAfisata;
            this.lClient.ObservatiiDateFirma = this.txtObservatiiDateFirma.Text;

            this.lClient.UpdateAll();
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
