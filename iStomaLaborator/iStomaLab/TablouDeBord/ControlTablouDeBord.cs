using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.iStomaLab;
using CDL.iStomaLab;
using CCL.UI;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Reprezentanti;
using iStomaLab.Generale;
using BLL.iStomaLab.Preturi;
using BLL.iStomaLab.Utilizatori;
using iStomaLab.TablouDeBord.Clienti;
using CCL.iStomaLab;
using BLL.iStomaLab.Comune;
using System.Text.RegularExpressions;

namespace iStomaLab.TablouDeBord
{
    public partial class ControlTablouDeBord : Generale.UserControlPersonalizat
    {

        #region Declaratii generale
        private BClienti lClient = null;
        private bool lArataZonaCautareRapida = true;
        int idlucrare, idclient;
        string xx;
        bool modedit;
        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colCuloareTehnician,
            colClient,
            colFisaClient,
            colMedic,
            colLucrare,
            colValoareInitiala,
            colValoareFinala, //pretmodificabil
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
            colCuloare,
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

        public ControlTablouDeBord()
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
            this.dgvListaComenzi.CellEndEdit += DgvListaDePreturiClienti_CellEndEdit;   
            this.btnAdaugareComanda.Click += BtnAdaugareComanda_Click;
            this.dgvListaComenzi.EditareLinie += DgvListaComenzi_EditareLinie;

            this.ctrlPerioada.PerioadaSchimbata += CtrlPerioada_PerioadaSchimbata;
            this.dgvListaComenzi.CellClick += DgvListaComenzi_CellClick;
            this.dgvListaComenzi.StergereLinie += DgvListaComenzi_StergereLinie;
            this.btnActivDezactivat.Click += BtnActivDezactivat_Click;

            this.txtCautaComanda.CerereUpdate += TxtCautaComanda_CerereUpdate;
            this.rbTot.CheckedChanged += ZonaFiltru_CheckedChanged;
            this.rbClinica.CheckedChanged += ZonaFiltru_CheckedChanged;
            this.rbMedic.CheckedChanged += ZonaFiltru_CheckedChanged;
            this.rbPacient.CheckedChanged += ZonaFiltru_CheckedChanged;
            this.rbTehnician.CheckedChanged += ZonaFiltru_CheckedChanged;

            this.btnInchidePanelOptiuni.Click += BtnInchidePanelOptiuni_Click;
            this.btnSchimbaEtapa.Click += BtnSchimbaEtapa_Click;
            this.btnArataAdaugareRapida.Click += BtnArataAdaugareRapida_Click;

            this.dgvListaComenzi.CereRefresh += DgvListaComenzi_CereRefresh;

            //eventuri pentru zona adaugare rapida
            this.ctrlADCautareClinica.CerereUpdate += CtrlADCautareClinica_CerereUpdate;
            this.ctrlADCautareLucrare.CerereUpdate += CtrlADCautareLucrare_CerereUpdate;
            this.ctrlADCautaTehnician.CerereUpdate += CtrlADCautaTehnician_CerereUpdate;

            this.btnGoleste.Click += BtnGoleste_Click;
            this.btnAdaugaLucrareRapida.Click += BtnAdaugaLucrareRapida_Click;

            this.ctrlDataInteres.CerereUpdate += CtrlDataInteres_CerereUpdate;
        }

        private void initTextML()
        {
            this.lblComenziInLucru.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Lucrare);
            this.btnSchimbaEtapa.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.SchimbaEtapa);
            this.lblCauta.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Cauta);

            this.lblADClinica.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Clinica);
            this.lblADMedic.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Medic);
            this.lblAdCabinet.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Cabinet);
            this.lblADLucrare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Lucrare);
            this.lblADEtapa.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Etapa);
            this.lblADTehnician.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tehnician);
            this.lblADCuloare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Culoare);
            this.lblADPacient.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pacient);
            this.lblADNrElemente.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrElem);

            this.rbTot.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tot);
            this.rbClinica.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Clinica);
            this.rbMedic.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Medic);
            this.rbPacient.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pacient);
            this.rbTehnician.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tehnician);
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.txtCautaComanda.Goleste();

            this.btnOptiuni.Initializeaza(this.panelOptiuni);
            this.btnInchidePanelOptiuni.Initializeaza(this.panelOptiuni);
            this.panelOptiuni.Initializeaza();

            this.ctrlDataInteres.Initializeaza();

            this.ctrlPerioada.Initializeaza(CDefinitiiComune.EnumTipPerioada.Luna, DateTime.Today);
            this.btnActivDezactivat.Selectat = false;

            this.btnArataAdaugareRapida.Initializeaza(BLL.iStomaLab.Comune.BComportamentAplicatie.EnumComportamentAplicatie.ArataZonaAdaugareComandaRapida, this.lArataZonaCautareRapida);

            initComportamentAplicatie();
            this.btnArataAdaugareRapida.Selectat = !this.lArataZonaCautareRapida;


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

        private void BtnArataAdaugareRapida_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                initComportamentAplicatie();
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

        private void BtnAdaugaLucrareRapida_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                //Adaugam lucrarea
                //Minim clinica si lucrarea trebuie sa fie selectate
                if (this.ctrlADCautareClinica.AreValoare() && this.ctrlADCautareLucrare.AreValoare())
                {

                    if (this.ctrlADCautareEtapa.AreValoare() || !this.ctrlADCautaTehnician.AreValoare())
                    {
                        Tuple<string, string> numePrenumePac = CUtil.GetNumePrenumeDinText(this.txtADPacient.Text);
                        BClientiComenzi.Add(this.ctrlADCautareClinica.GetIdClient(), this.ctrlADCautareMedicClinica.GetIdMedic(), numePrenumePac.Item1, numePrenumePac.Item2, 0, 0, this.ctrlADDataOraPrimire.DataAfisata, CConstante.DataNula, string.Empty, this.ctrlADCautareCabinetClinica.GetIdCabinet(), this.ctrlADCautareLucrare.GetIdLucrare(), false, 0, 0, this.txtADNrElemente.ValoareIntreaga, this.ctrlADCautareEtapa.GetIdEtapa(), this.ctrlADCautaTehnician.GetIdTehnician(), CConstante.DataNula, false, 0, this.txtADCuloare.Text, string.Empty, false, string.Empty, null);

                        this.ctrlADCautareLucrare.Goleste();
                        this.ctrlADDataOraPrimire.DataAfisata = DateTime.Now;

                        ConstruiesteRanduriDGV();

                        this.dgvListaComenzi.ScrollToBottom();
                    }
                    else
                    {
                        if (this.ctrlADCautaTehnician.AreValoare())
                        {
                            this.ctrlADCautareEtapa.DeschideLista();
                        }
                    }
                }
                else
                {
                    Mesaj.Eroare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.SelectatiCelPutinClinicaSiLucrarea));
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

        private void CtrlADCautaTehnician_CerereUpdate(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.txtADCuloare.Focus();
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

        private void CtrlADCautareLucrare_CerereUpdate(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.ctrlADCautareEtapa.Initializeaza(this.ctrlADCautareLucrare.GetLucrare());

                this.ctrlADCautareEtapa.Focus();
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

        private void CtrlADCautareClinica_CerereUpdate(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.ctrlADCautareCabinetClinica.Initializeaza(this.ctrlADCautareClinica.GetClient());
                this.ctrlADCautareMedicClinica.Initializeaza(this.ctrlADCautareClinica.GetClient());

                this.ctrlADDataOraPrimire.DataAfisata = DateTime.Now;
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

        private void BtnGoleste_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                golesteZonaAdaugareRapida();
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

        private void DgvListaComenzi_CereRefresh(object sender, EventArgs e)
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

        private void BtnSchimbaEtapa_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                //Recuperam lucrarile
                BColectieClientiComenzi listaLucrari = this.dgvListaComenzi.GetListaObiecteBifate<BColectieClientiComenzi, BClientiComenzi>();

                if (!CUtil.EsteListaVida<BClientiComenzi>(listaLucrari))
                {
                    //Cerem confirmarea daca avem lucrari selectate

                    //Deschidem ecranul ce ne permite introducerea etapei, a tehnicianului si a datei

                    Tuple<int, int, DateTime, bool, int> dateEtapa = FormSchimbareEtapa.Afiseaza(this.GetFormParinte());

                    //Facem Update-ul
                    if (dateEtapa != null)
                        listaLucrari.TreciLaEtapa(dateEtapa.Item1, dateEtapa.Item2, dateEtapa.Item3, dateEtapa.Item4, dateEtapa.Item5, null);

                    ConstruiesteRanduriDGV();
                }
                else
                {
                    Mesaj.Afiseaza(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.SelectatiCelPutinOLucrareDinLista));
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

        private void BtnInchidePanelOptiuni_Click(object sender, EventArgs e)
        {
            this.panelOptiuni.Visible = false;
        }

        private void BtnActivDezactivat_Click(object sender, EventArgs e)
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

        private void DgvListaComenzi_StergereLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BClientiComenzi comandaDeSters = this.dgvListaComenzi.Rows[pIndexRand].Tag as BClientiComenzi;

                if (comandaDeSters != null)
                {
                    if (!this.btnActivDezactivat.Selectat)
                    {
                        if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), comandaDeSters.DenumireLucrare))
                        {
                            comandaDeSters.Close(true, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stergere), null);
                            ConstruiesteRanduriDGV();
                        }
                    }
                    else
                    {
                        if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiReactivarea), comandaDeSters.DenumireLucrare))
                        {
                            comandaDeSters.Close(false, string.Empty, null);
                            ConstruiesteRanduriDGV();
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

        private void DgvListaComenzi_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (this.lSeIncarca || e.RowIndex < 0) return;
            try
            {
                incepeIncarcarea();

                string denumireColoanaSelectata = this.dgvListaComenzi.Columns[e.ColumnIndex].Name;

                if (this.dgvListaComenzi.SelectedRow != null)
                {
                    BClientiComenzi comandaSelectata = this.dgvListaComenzi.SelectedRow.Tag as BClientiComenzi;
                    if (comandaSelectata != null)
                    {
                        if (denumireColoanaSelectata.Equals(EnumColoaneDGV.colFisaClient.ToString()))
                        {
                            BClienti client = BClienti.getClient(comandaSelectata.IdClient, null);

                            if (TablouDeBord.Clienti.FormDosarClient.Afiseaza(this.GetFormParinte(), client))
                                incarcaRand(this.dgvListaComenzi.SelectedRow, comandaSelectata);
                        }
                        else if (denumireColoanaSelectata.Equals(EnumColoaneDGV.colTotalEtape.ToString()))
                        {
                            if (FormLucrareListaEtapeRealizate.Afiseaza(this.GetFormParinte(), comandaSelectata))
                            {
                                comandaSelectata.Refresh(null);
                                incarcaRand(this.dgvListaComenzi.SelectedRow, comandaSelectata);
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

        private void DgvListaComenzi_EditareLinie(DataGridViewPersonalizat pDGVSende, int pIndexRand)
        {
            this.modedit = true;

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();
                /// lore 02.09.2019
                //  Tuple<BClientiComenzi, BListaPreturiClienti> comandaDeModificat = this.dgvListaComenzi.Rows[pIndexRand].Tag as Tuple<BClientiComenzi, BListaPreturiClienti>;
                //  BListaPreturiStandard pretstandard = BListaPreturiStandard.getById(comandaDeModificat.Item1.IdLucrare, null);
                ///////////////////////
                BClientiComenzi comandaDeModificat = this.dgvListaComenzi.Rows[pIndexRand].Tag as BClientiComenzi;
                if (comandaDeModificat != null) //&& !this.btnActivDezactivat.Selectat
                {
                    BListaPreturiStandard lucrare = BListaPreturiStandard.getById(comandaDeModificat.IdLucrare, null);

                    if (TablouDeBord.Clienti.FormDetaliuComanda.Afiseaza(this.GetFormParinte(), comandaDeModificat, BClienti.getClient(comandaDeModificat.IdClient, null), lucrare))
                    {
                        incarcaRand(this.dgvListaComenzi.Rows[pIndexRand], comandaDeModificat); //, pretstandard, comandaDeModificat.Item2);   /// lore 02.09.2019
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

        ///lore 30.08.3019
        private void DgvListaDePreturiClienti_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.modedit = true;
            if (this.lSeIncarca || e.RowIndex < 0) return;
            try
            {
                incepeIncarcarea();
                Tuple<BClientiComenzi, BListaPreturiClienti> valori = this.dgvListaComenzi.Rows[e.RowIndex].Tag as Tuple<BClientiComenzi, BListaPreturiClienti>;

                if (valori == null)
                    return;

                BClientiComenzi pelement = valori.Item1;
                BListaPreturiClienti pretClient = valori.Item2;
                //  BListaPreturiClienti pretClient = BListaPreturiClienti.GetPretClient(pelement.IdLucrare, pelement.IdClient, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);
                BListaPreturiStandard pretStandard = BListaPreturiStandard.getById(pelement.IdLucrare, null);

                bool refresh = false;
                if (pretClient != null)
                {
                    refresh = pretClient.UpdatePret(CUtil.GetAsDouble(this.dgvListaComenzi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));    //numar = this.dgvListaComenzi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value
                }
                else
                {
                    //Adaugare
                    double pretNou = CUtil.GetAsDouble(this.dgvListaComenzi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    if (pretNou != pretStandard.GetValoare())
                    {
                        int id = BListaPreturiClienti.Add(pretStandard.Id, this.lClient.Id, pretNou, pretStandard.GetMoneda(), pretStandard.TermenMediuZile, null);

                        if (id > 0)
                        {
                            refresh = true;
                            pretClient = new BListaPreturiClienti(id);
                        }
                    }
                }

                /*  if (refresh)
                  {
                    incarcaRand(this.dgvListaComenzi.Rows[e.RowIndex], pelement);//, pretStandard, pretClient);
                  }*/

                incarcaRand(this.dgvListaComenzi.Rows[e.RowIndex], pelement);
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
        /////////////////////////////////////////////////////////////

        private void BtnAdaugareComanda_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                // BClienti client = Generale.FormListaClinici.Afiseaza(this.GetFormParinte());

                BClienti client = Caramizi.frmListaObiecte<BClienti>.Afiseaza<BClienti>(this.GetFormParinte(), BClienti.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Clinica), CDL.iStomaLab.CDefinitiiComune.EnumTipSelectie.SelectieUnica);

                if (client != null)
                {
                    if (Clienti.FormDetaliuComanda.Afiseaza(this.GetFormParinte(), null, client, null))
                    {
                        ConstruiesteRanduriDGV();
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

        #region Zona Cautare

        private void ZonaFiltru_CheckedChanged(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if ((sender as RadioButton).Checked)
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

        #endregion

        #endregion

        #region Metode private

        private void initComportamentAplicatie()
        {
            this.lArataZonaCautareRapida = BComportamentAplicatie.GetArataZonaAdaugareComandaRapida();

            this.panelZonaAdaugare.Visible = this.lArataZonaCautareRapida;

            if (this.lArataZonaCautareRapida)
            {
                this.dgvListaComenzi.Height = this.Height - this.ctrlPerioada.Height - this.btnAdaugareComanda.Height - this.lblTotal.Height - 20 - this.panelZonaAdaugare.Height;
            }
            else
            {
                int inaltimeDGV = this.Height - this.ctrlPerioada.Height - this.btnAdaugareComanda.Height - this.lblTotal.Height - 20;
                this.dgvListaComenzi.Height = inaltimeDGV;
            }

            this.lblTotal.Location = new Point(this.lblTotal.Location.X, this.dgvListaComenzi.Location.Y + this.dgvListaComenzi.Height + 5);
            this.btnArataAdaugareRapida.Location = new Point(this.btnArataAdaugareRapida.Location.X, this.dgvListaComenzi.Location.Y + this.dgvListaComenzi.Height + 5);
        }

        private void golesteZonaAdaugareRapida()
        {
            this.ctrlADCautareClinica.Goleste();
            this.ctrlADCautareMedicClinica.Initializeaza(null);
            this.ctrlADCautareMedicClinica.Goleste();
            this.ctrlADCautareCabinetClinica.Initializeaza(null);
            this.ctrlADCautareCabinetClinica.Goleste();
            this.ctrlADCautareLucrare.Goleste();
            this.ctrlADCautaTehnician.Goleste();
            this.ctrlADCautareEtapa.Goleste();

            this.txtADCuloare.Goleste();
            this.txtADPacient.Goleste();
            this.txtADNrElemente.Goleste();

            this.ctrlADDataOraPrimire.Initializeaza(CConstante.DataNula, ComboBoxOra.EnumPas.CinciMinute);
        }

        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaComenzi.IncepeConstructieColoane();

            this.dgvListaComenzi.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.SelectieMultipla);

            this.dgvListaComenzi.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvListaComenzi.AdaugaColoanaText(EnumColoaneDGV.colCuloareTehnician.ToString(), string.Empty, 15, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaComenzi.AdaugaColoanaText(EnumColoaneDGV.colCodLucrareClient.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Cod), 50, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaComenzi.AdaugaColoanaText(EnumColoaneDGV.colCodComanda.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CodComanda), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaComenzi.AdaugaColoanaData(EnumColoaneDGV.colDataPrimire.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataPrimire), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA_ORA);

            this.dgvListaComenzi.AdaugaColoanaText(EnumColoaneDGV.colClient.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Clinica), 130, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaComenzi.AdaugaColoanaButonClasic(EnumColoaneDGV.colFisaClient.ToString(), string.Empty, string.Empty, 36, false);

            this.dgvListaComenzi.AdaugaColoanaText(EnumColoaneDGV.colMedic.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Medic), 130, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaComenzi.AdaugaColoanaText(EnumColoaneDGV.colLucrare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Lucrare), 300, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaComenzi.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colValoareInitiala.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ValoareInitiala), 100, DataGridViewColumnSortMode.Automatic);
            this.dgvListaComenzi.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colMoneda.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Moneda), 100, DataGridViewColumnSortMode.Automatic);
            this.dgvListaComenzi.Columns[EnumColoaneDGV.colMoneda.ToString()].Visible = false;
            this.dgvListaComenzi.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colDiscount.ToString(), " % ", 35, DataGridViewColumnSortMode.Automatic);
            this.dgvListaComenzi.Columns[EnumColoaneDGV.colDiscount.ToString()].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvListaComenzi.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colValoareFinala.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Valoare), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvListaComenzi.AdaugaColoanaNumerica(EnumColoaneDGV.colNrElemente.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrElem), 35, DataGridViewColumnSortMode.Automatic);

            this.dgvListaComenzi.AdaugaColoanaText(EnumColoaneDGV.colCuloare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Culoare), 80, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaComenzi.AdaugaColoanaText(EnumColoaneDGV.colEtapaCurenta.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.EtapaCurenta), 150, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaComenzi.AdaugaColoanaText(EnumColoaneDGV.colStare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stare), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaComenzi.AdaugaColoanaData(EnumColoaneDGV.colTermen.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Termen), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA_ORA);

            this.dgvListaComenzi.AdaugaColoanaText(EnumColoaneDGV.colTehnician.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tehnician), 130, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaComenzi.AdaugaColoanaButonClasic(EnumColoaneDGV.colTotalEtape.ToString(), string.Empty, string.Empty, 40, false);

            this.dgvListaComenzi.AdaugaColoanaText(EnumColoaneDGV.colNumePacient.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pacient), 130, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaComenzi.AdaugaColoanaText(EnumColoaneDGV.colObservatii.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ObsLucrare), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaComenzi.AdaugaColoanaData(EnumColoaneDGV.colDataLaGata.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataLaGata), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA_ORA);

            this.dgvListaComenzi.AdaugaColoanaData(EnumColoaneDGV.colDataCreare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataCreare), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA_ORA);

            this.dgvListaComenzi.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvListaComenzi.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            var listaElem = BClientiComenzi.GetListByParamIntrePerioada(-1, this.ctrlPerioada.DataInceput, this.ctrlPerioada.DataSfarsit, CDL.iStomaLab.CDefinitiiComune.EnumStare.Toate, this.ctrlDataInteres.GetDataInteres(), null);

            if (listaElem.ContineElementeDeactivate())
            {
                this.btnActivDezactivat.Visible = true;
            }
            else
            {
                this.btnActivDezactivat.Visible = false;
                this.btnActivDezactivat.Selectat = false;
            }

            if (!this.btnActivDezactivat.Selectat)
                ConstruiesteRanduriDGV(listaElem.GetListaActive());
            else
                ConstruiesteRanduriDGV(listaElem.GetListaInactive());
        }

        private void ConstruiesteRanduriDGV(BColectieClientiComenzi pListaComenzi)
        {
            this.dgvListaComenzi.IncepeContructieRanduri();
            foreach (var elem in pListaComenzi)
            {
                ///lore 02.09.2019  
                BListaPreturiStandard pElem2 = BListaPreturiStandard.getById(elem.IdLucrare, null);
                BListaPreturiClienti pElemClient = BListaPreturiClienti.GetPretClient(elem.IdLucrare, elem.IdClient, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

                incarcaRand(this.dgvListaComenzi.Rows[this.dgvListaComenzi.Rows.Add()], elem);//, pElem2, pElemClient);            
            }
            this.dgvListaComenzi.FinalizeazaContructieRanduri();
            filtreazaDupaText();
        }


        private void filtreazaDupaText()
        {
            setNrLinii(this.dgvListaComenzi.FiltreazaDupaText(this.txtCautaComanda.Text, getNumeColoanaFiltru()));
        }

        private string getNumeColoanaFiltru()
        {
            if (this.rbTot.Checked) return string.Empty;

            if (this.rbClinica.Checked) return EnumColoaneDGV.colClient.ToString();

            if (this.rbMedic.Checked) return EnumColoaneDGV.colMedic.ToString();

            if (this.rbPacient.Checked) return EnumColoaneDGV.colNumePacient.ToString();

            if (this.rbTehnician.Checked) return EnumColoaneDGV.colTehnician.ToString();

            return string.Empty;
        }

        private void setNrLinii(int pNrLinii)
        {
            this.lblTotal.Text = string.Format("{0}: {1}",
                BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Lucrari),
                pNrLinii);
        }

        private void incarcaRand(DataGridViewRow pRand, BClientiComenzi pElem)
        {
            pRand.Tag = pElem;     
            //asa era initial  pRand.Tag = new Tuple<BClientiComenzi, BListaPreturiStandard, BListaPreturiClienti>(pElem, pElem2, pElemClient);

            idclient = pElem.IdClient;
            idlucrare = pElem.IdLucrare;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);

            DataGridViewPersonalizat.SeteazaCuloareFundalCelula(pRand, EnumColoaneDGV.colCuloareTehnician.ToString(), BDefinitiiGenerale.getCuloareDinARGB(pElem.CuloareTehnician));
            pRand.Cells[EnumColoaneDGV.colCuloareTehnician.ToString()].ToolTipText = pElem.GetIdentitateTehnician();

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

            pRand.Cells[EnumColoaneDGV.colCuloare.ToString()].Value = pElem.Culoare;
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
           
            pRand.Cells[EnumColoaneDGV.colDiscount.ToString()].Value = CUtil.GetValoareMonetara(ajustare);  // BListaPreturiClienti.GetEtichetaAjustare();   

            //daca este reducere, atunci % cu minus si alerta text cu rosu
            if (pretNegociat < pretLista)
                DataGridViewPersonalizat.SeteazaAlerta(pRand, EnumColoaneDGV.colDiscount.ToString());
            else
                DataGridViewPersonalizat.IndeparteazaAlerta(pRand, EnumColoaneDGV.colDiscount.ToString());

            pRand.Cells[EnumColoaneDGV.colValoareFinala.ToString()].Value = CUtil.GetValoareMonetara(pElem.ValoareFinala, pElem.Moneda);
            DataGridViewPersonalizat.InitCelulaStergere(pRand);
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
