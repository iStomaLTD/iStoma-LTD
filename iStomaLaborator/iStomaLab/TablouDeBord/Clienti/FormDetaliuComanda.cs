using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Preturi;
using BLL.iStomaLab.Reprezentanti;
using BLL.iStomaLab.Utilizatori;
using CCL.iStomaLab;
using CCL.UI;
using CCL.UI.Imprimare;
using CDL.iStomaLab;
using iStomaLab.Generale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CDL.iStomaLab.CDefinitiiComune;

namespace iStomaLab.TablouDeBord.Clienti
{
    public partial class FormDetaliuComanda : FormPersonalizat
    {

        #region Declaratii generale
        string moneda;
        private BClientiComenzi lComanda = null;
        private BClienti lClient = null;
        private BListaPreturiStandard lLucrare = null;
        private BListaPreturiStandard lLucrareSelectata = null;
        private BListaPreturiClienti lpretnegociat = null;
        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormDetaliuComanda(BClientiComenzi pComanda, BClienti pClient, BListaPreturiStandard pLucrare)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lComanda = pComanda;
            this.lClient = pClient;
            this.lLucrareSelectata = pLucrare;
            this.lpretnegociat = BListaPreturiClienti.GetPretClient(pLucrare.Id, pClient.Id, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

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
            this.ctrlValidareAnulareComanda.Validare += CtrlValidareAnulareComanda_Validare;
            this.cboEtapaCurenta.SelectedIndexChanged += CboEtapaCurenta_SelectedIndexChanged;
            this.lgfTehnician.DeschideEcranCautare += TxtCautaTehnician_DeschideEcranCautare;
            this.btnVeziToateEtapele.Click += BtnVeziToateEtapele_Click;
            this.btnPrintBarCode.Click += BtnPrintBarCode_Click;
            this.lgfLucrare.DeschideEcranCautare += TxtCautaLucrare_DeschideEcranCautare;
            this.txtNrElemente.LostFocus += eventHandler;
            this.txtpretunitarfin.LostFocus += eventHandler;
        }

        private void eventHandler(object sender, EventArgs e)
        {
            if (this.lLucrareSelectata.ValoareEUR != 0)
            {
                this.lblValoareFinala.Text = string.Concat("TOTAL:", " ", this.txtpretunitarfin.ValoareDouble * this.txtNrElemente.ValoareDouble, " ", "EUR");
            }
            else
            {
                this.lblValoareFinala.Text = string.Concat("TOTAL:", " ", this.txtpretunitarfin.ValoareDouble * this.txtNrElemente.ValoareDouble, " ", "RON");
            }
        }

        private void initTextML()
        {
            this.Text = string.Empty;
            this.lblNrElemente.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrElemente);
            this.chkUrgent.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Urgent);
            this.lblTehnician.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tehnician);
            this.lblMedic.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Medic);
            this.lblComandaPacientNume.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Nume);
            this.lblComandaPacientPrenume.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Prenume);
            this.lblVarsta.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Varsta);
            this.lblAni.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ani);
            this.lblComandaPacientSex.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Sex);
            this.rbFeminin.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.captionFeminin);
            this.rbMasculin.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.captionMasculin);
            this.lblComandaDataPrimire.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataPrimire);
            this.lblComandaDataLaGata.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataLaGata);
            this.lblObservatiiEtapaCurenta.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii);
            this.lblCabinet.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Cabinet);
            this.lblLucrare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Lucrare);
            this.lblEtapaCurenta.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Etapa);
            this.lblClinica.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Clinica);
            this.lblTermen.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Termen);
            this.chkRefacere.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Refacere);
            this.lblStare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stare);
            this.lblCuloare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Culoare);
            this.gbEtapaCurenta.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.EtapaCurenta);
            this.gbLucrare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Lucrare);
            this.gbObservatii.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii);
            this.gbPacient.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pacient);
            this.btnVeziToateEtapele.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.VeziToateEtapele);
            this.btnPrintBarCode.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PrinteazaBarCode);
            this.chkAcceptata.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Acceptata);
            this.lblCodComanda.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CodComanda);
            // this.lblpretunitarinit.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ValoareInitiala);
            // this.lblpretunitarfin.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Valoare);
        }

        void _Load(object sender, EventArgs e)
        {
            try
            {
                Initializeaza(this.lComanda, this.lClient, this.lLucrareSelectata);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        public void Initializeaza(BClientiComenzi pComanda, BClienti pClient, BListaPreturiStandard pLucrare)
        {
            base.InitializeazaVariabileleGenerale();
            incepeIncarcarea();

            this.cboComandaReprezentant.Focus();
            this.txtComandaPacientNume.CapitalizeazaPrimaLitera = true;
            this.txtComandaPacientPrenume.CapitalizeazaPrimaLitera = true;
            this.btnVeziToateEtapele.Visible = this.lComanda != null;

            this.lgfTehnician.FolosesteToString = true;
            this.lgfLucrare.FolosesteToString = true;

            this.lgfClinica.AfiseazaButonGuma = false;
            this.lgfClinica.AfiseazaButonCautare = false;

            this.lgfLucrare.AfiseazaButonGuma = false;
            this.lgfTehnician.AfiseazaButonGuma = false;

            if (this.lComanda == null)
            {
                this.lgfClinica.Goleste();
                this.lgfLucrare.Text = this.lLucrareSelectata.Denumire;
                this.lgfTehnician.Goleste();
                this.txtNrElemente.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Unu);

                this.lgfClinica.Text = this.lClient.Denumire;

                this.ctrlComandaDataPrimire.DataAfisata = DateTime.Now;

                if (this.lLucrareSelectata.TermenMediuZile != 0)
                {
                    this.ctrlComandaDataLaGata.Initializeaza(this.ctrlComandaDataPrimire.DataAfisata.AddDays(this.lLucrareSelectata.TermenMediuZile), ComboBoxOra.EnumPas.JumatateDeOra);
                }
                else
                    this.ctrlComandaDataLaGata.Initializeaza(CConstante.DataNula, ComboBoxOra.EnumPas.JumatateDeOra);

                this.ctrlDataOraTermen.Initializeaza(CConstante.DataNula, ComboBoxOra.EnumPas.JumatateDeOra);

                this.txtComandaPacientNume.Goleste();
                this.txtComandaPacientPrenume.Goleste();
                this.txtVarsta.Goleste();
                this.txtObservatiiComanda.Goleste();
                this.txtCodComanda.Goleste();

                ////lore 03.09.2019

                if (this.lLucrareSelectata.ValoareEUR != 0)
                {
                    if (this.lpretnegociat == null)
                    {
                        this.lblPretUnitarInitial.Text = this.lLucrareSelectata.ValoareEUR.ToString();
                        this.txtpretunitarfin.ValoareDouble = this.lLucrareSelectata.ValoareEUR;
                    }
                    else
                    {
                        this.lblPretUnitarInitial.Text = this.lpretnegociat.ValoareEUR.ToString();
                        this.txtpretunitarfin.ValoareDouble = this.lpretnegociat.ValoareEUR;
                    }
                    this.lblmoneda.Text = "EUR";
                    this.lblValoareFinala.Text = string.Concat("TOTAL:", " ", this.txtpretunitarfin.ValoareDouble * this.txtNrElemente.ValoareDouble, " ", this.lblmoneda.Text);
                }
                else
                {
                    if (this.lpretnegociat == null)
                    {
                        this.lblPretUnitarInitial.Text = this.lLucrareSelectata.ValoareRON.ToString();
                        this.txtpretunitarfin.ValoareDouble = this.lLucrareSelectata.ValoareRON;
                    }
                    else
                    {
                        this.lblPretUnitarInitial.Text = (this.lpretnegociat.ValoareRON).ToString();
                        this.txtpretunitarfin.ValoareDouble = this.lpretnegociat.ValoareRON;
                    }
                    this.lblmoneda.Text = "RON";
                    this.lblValoareFinala.Text = string.Concat("TOTAL:", " ", this.txtpretunitarfin.ValoareDouble * this.txtNrElemente.ValoareDouble, " ", this.lblmoneda.Text);
                }
            }
            else
            {
                this.lLucrareSelectata = BListaPreturiStandard.getById(this.lComanda.IdLucrare, null);
                if (this.lComanda.IdTehnician > 0)
                    this.lgfTehnician.ObiectCorespunzator = BUtilizator.GetById(this.lComanda.IdTehnician, null);
                else
                    this.lgfTehnician.Goleste();

                this.lgfClinica.Text = this.lClient.Denumire;
                this.lgfLucrare.Text = this.lLucrareSelectata.Denumire;
                this.cboComandaReprezentant.SelectedValue = lComanda.IdReprezentantClient;
                this.cboCabinet.SelectedValue = lComanda.IdCabinet;
                this.txtComandaPacientNume.Text = lComanda.NumePacient;
                this.txtComandaPacientPrenume.Text = lComanda.PrenumePacient;
                this.txtVarsta.ValoareIntreaga = lComanda.Varsta;
                this.rbFeminin.Checked = this.lComanda.SexPacient == 1;
                this.rbMasculin.Checked = this.lComanda.SexPacient == 2;
                this.ctrlComandaDataPrimire.DataAfisata = lComanda.DataPrimire;
                this.ctrlComandaDataLaGata.Initializeaza(lComanda.DataLaGata, ComboBoxOra.EnumPas.JumatateDeOra);
                this.txtObservatiiComanda.Text = lComanda.Observatii;
                this.txtObservatiiEtapaCurenta.Text = lComanda.ObservatiiEtapa;
                this.chkUrgent.Checked = lComanda.Urgent;
                this.txtNrElemente.Text = lComanda.NrElemente.ToString();
                this.ctrlDataOraTermen.Initializeaza(this.lComanda.DataSfarsitEtapa, ComboBoxOra.EnumPas.JumatateDeOra);
                this.chkRefacere.Checked = this.lComanda.Refacere;
                this.txtCuloare.Text = this.lComanda.Culoare;
                this.chkAcceptata.Checked = this.lComanda.Acceptata;
                this.txtCodComanda.Text = this.lComanda.CodLucrare;
                ////lore 05.09.2019
                this.lblPretUnitarInitial.Text = pComanda.PretUnitarInitial.ToString();
                this.txtpretunitarfin.ValoareDouble = pComanda.PretUnitarFinal;
                ////lore 03.09.2019
                if (this.lLucrareSelectata.ValoareEUR != 0)
                {
                    this.lblmoneda.Text = "EUR";
                    this.lblValoareFinala.Text = string.Concat("TOTAL:", " ", this.txtpretunitarfin.ValoareDouble * this.txtNrElemente.ValoareDouble, " ", this.lblmoneda.Text);
                }
                else
                {
                    this.lblmoneda.Text = "RON";
                    this.lblValoareFinala.Text = string.Concat("TOTAL:", " ", this.txtpretunitarfin.ValoareDouble * this.txtNrElemente.ValoareDouble, " ", this.lblmoneda.Text);
                }
            }

            initListe();

            if (this.lComanda != null && !this.lComanda.EsteActiv)
                AllowModification(false);
            else
                AllowModification(true);

            finalizeazaIncarcarea();
        }


        #endregion

        #region Evenimente

        private void CtrlValidareAnulareComanda_Validare(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();
                if (this.Salveaza())
                {
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

        private void BtnVeziToateEtapele_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (TablouDeBord.Clienti.FormLucrareListaEtapeRealizate.Afiseaza(this.GetFormParinte(), this.lComanda))
                {
                    this.lComanda.Refresh(null);
                    Initializeaza(this.lComanda, this.lClient, this.lLucrareSelectata);
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


        private void BtnPrintBarCode_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                CImprimaBarCode.Imprima(string.Format("{0}-{1}", lLucrareSelectata.CodIntern, lComanda.DenumireClinica), lComanda.Id.ToString());
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


        private void CboEtapaCurenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.chkRefacere.Checked = false;
                this.cboStare.SelectedIndex = 0;
                this.ctrlDataOraTermen.DataAfisata = CConstante.DataNula;
                this.txtObservatiiEtapaCurenta.Goleste();
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

        private void LgfClinica_DeschideEcranCautare(Control psender, object pxObiectExistent)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BClienti client = FormListaClinici.Afiseaza(this.GetFormParinte());

                if (client != null)
                {
                    this.lClient = client;
                    this.lgfClinica.Text = this.lClient.Denumire;
                    initListe();
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

        private void TxtCautaLucrare_DeschideEcranCautare(Control psender, object pxObiectExistent)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BListaPreturiStandard lucrare = FormListaLucrari.Afiseaza(this.GetFormParinte(), this.lClient);
                if (lucrare != null)
                {
                    this.lLucrareSelectata = lucrare;
                    this.lgfLucrare.Text = this.lLucrareSelectata.Denumire;
                    initListe();
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

        private void TxtCautaTehnician_DeschideEcranCautare(Control psender, object pxObiectExistent)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BUtilizator tehnician = FormListaUtilizatori.Afiseaza(this.GetFormParinte(), EnumRol.Tehnician);
                if (tehnician != null)
                    this.lgfTehnician.ObiectCorespunzator = tehnician;
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

        private void LblFindLucrare_DeschideEcranCautare(Control psender, object pxObiectExistent)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BListaPreturiStandard lucrare = FormListaLucrari.Afiseaza(this.GetFormParinte(), this.lClient);
                if (lucrare != null)
                {
                    this.lLucrareSelectata = lucrare;
                    Initializeaza(this.lComanda, this.lClient, this.lLucrareSelectata);
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
        private bool esteDataSfarsitDupaDataInceput()
        {
            return DateAndTime.DateDiff(DateInterval.Day, this.ctrlComandaDataPrimire.DataAfisata, this.ctrlDataOraTermen.DataAfisata) >= 0;
        }

        private int getSexClient()
        {
            if (rbFeminin.Checked)
                return 1;
            if (rbMasculin.Checked)
                return 2;
            return 0;
        }

        private void initListe()
        {
            Dictionary<int, string> lstReprezentanti = new Dictionary<int, string>();
            Dictionary<int, string> lstCabinete = new Dictionary<int, string>();
            //Dictionary<int, string> lstEtape = new Dictionary<int, string>();

            lstReprezentanti.Add(0, string.Empty);
            lstCabinete.Add(0, string.Empty);
            //lstEtape.Add(0, string.Empty);

            foreach (var elem in BClientiReprezentanti.GetListByIdClient(this.lClient.Id, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null))
            {
                lstReprezentanti.Add(elem.Id, BClientiReprezentanti.getReprezentant(elem.Id, null).GetIdentitateReprezentant());
            }
            foreach (var elem in BClientiCabinete.GetListByIdClient(this.lClient.Id, CDefinitiiComune.EnumStare.Activa, null))
            {
                lstCabinete.Add(elem.Id, elem.Denumire);
            }

            this.cboStare.BeginUpdate();
            this.cboStare.DataSource = BClientiComenziEtape.StructStareEtapa.GetList();
            this.cboStare.EndUpdate();

            BColectieEtape listaEtape = new BColectieEtape();
            if (this.lLucrareSelectata != null)
            {
                BColectieLucrariEtape etape = BLucrariEtape.GetListByParamIdLucrare(this.lLucrareSelectata.Id, EnumStare.Activa, null);
                if (etape.Count > 0)
                {
                    listaEtape = BEtape.getByListaId(etape.GetListaIdEtape(), null);
                    //foreach (var elem in etape)
                    //{
                    //    lstEtape.Add(elem.IdEtapa, BEtape.GetEtapaById(elem.IdEtapa, EnumStare.Activa, null).Denumire);
                    //}
                }
                else
                {
                    listaEtape = BEtape.GetListByParam(EnumStare.Activa, null);
                    //foreach (var elem in etapeStandard)
                    //{
                    //    lstEtape.Add(elem.Id, elem.Denumire);
                    //}
                }
            }

            this.cboComandaReprezentant.DataSource = new BindingSource(lstReprezentanti, null);
            this.cboComandaReprezentant.DisplayMember = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Value);
            this.cboComandaReprezentant.ValueMember = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Key);

            this.cboCabinet.DataSource = new BindingSource(lstCabinete, null);
            this.cboCabinet.DisplayMember = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Value);
            this.cboCabinet.ValueMember = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Key);

            vizibilitateZonaCabinete(lstCabinete.Count > 1);
            vizibilitateZonaMedici(lstReprezentanti.Count > 1);

            this.cboEtapaCurenta.BeginUpdate();
            this.cboEtapaCurenta.DataSource = listaEtape;
            this.cboEtapaCurenta.EndUpdate();

            if (this.lComanda != null)
            {
                if (this.lComanda.IdReprezentantClient != 0)
                    this.cboComandaReprezentant.SelectedValue = this.lComanda.IdReprezentantClient;
                if (this.lComanda.IdCabinet != 0)
                    this.cboCabinet.SelectedValue = this.lComanda.IdCabinet;
                if (this.lComanda.IdEtapaSetari > 0)
                    this.cboEtapaCurenta.SelectedItem = this.lComanda.IdEtapaSetari;
                else
                    this.cboEtapaCurenta.SelectedItem = null;
                this.cboStare.SelectedIndex = Convert.ToInt32(this.lComanda.StatusEtapa);
            }

            this.cboComandaReprezentant.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboCabinet.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboEtapaCurenta.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboStare.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void vizibilitateZonaCabinete(bool pVizibil)
        {
            this.lblCabinet.Visible = pVizibil;
            this.cboCabinet.Visible = pVizibil;
        }

        private void vizibilitateZonaMedici(bool pVizibil)
        {
            this.lblMedic.Visible = pVizibil;
            this.cboComandaReprezentant.Visible = pVizibil;
        }

        private void seteazaAlerta()
        {
            IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.lgfClinica, this.lblClinica);
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.lgfLucrare, this.lblLucrare);
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.txtNrElemente, this.lblNrElemente);
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.ctrlComandaDataPrimire, this.lblComandaDataPrimire);
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.ctrlDataOraTermen, this.lblTermen);
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.txtComandaPacientNume, this.lblComandaPacientNume);
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.lgfTehnician, this.lblTehnician);
            seteazaFocus();
        }

        private bool suntCompleteInformatiile()
        {
            return !string.IsNullOrEmpty(this.txtNrElemente.Text) && this.ctrlComandaDataPrimire.AreValoare && this.ctrlDataOraTermen.AreValoare && !string.IsNullOrEmpty(this.txtComandaPacientNume.Text) && this.lgfTehnician.IdObiectCorespunzator != 0;
        }

        private bool verificaData()
        {
            if (esteDataSfarsitDupaDataInceput())
                return true;
            Mesaj.Eroare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.MesajEroareDataTermen));
            return false;
        }

        private void seteazaFocus()
        {
            Control[] lstControale = { this.lgfClinica, this.lgfLucrare, this.lgfTehnician, this.txtNrElemente, this.ctrlComandaDataPrimire, this.ctrlDataOraTermen, this.txtComandaPacientNume };

            foreach (var control in lstControale)
            {
                if (string.IsNullOrEmpty(control.Text))
                {
                    control.Focus();
                    break;
                }
            }

        }

        private int getIdEtapaCurenta()
        {
            if (this.cboEtapaCurenta.SelectedItem == null)
                return 0;

            return (this.cboEtapaCurenta.SelectedItem as BEtape).Id;
        }

        private BClientiComenziEtape.EnumStareEtapa getStare()
        {
            if (this.cboStare.SelectedItem != null)
                return ((BClientiComenziEtape.StructStareEtapa)this.cboStare.SelectedItem).Id;

            return BClientiComenziEtape.EnumStareEtapa.Nedefinita;
        }


        #endregion

        #region Metode publice

        /// <lore 04.09.2019/>
        public int ExtracToTnteger()
        {
            string text = this.lblPretUnitarInitial.Text;
            string integerString = string.Empty;
            foreach (Char c in text)
            {
                if (Char.IsDigit(c))
                {
                    integerString += c;
                }
            }
            return Int32.Parse(integerString);
        }
        /////////////////////

        public static bool Afiseaza(Form pEcranPariente, int pIdComandaClient)
        {
            if (pIdComandaClient <= 0) return false;

            BClientiComenzi comanda = new BClientiComenzi(pIdComandaClient);

            return Afiseaza(pEcranPariente, comanda, comanda.GetClient(), comanda.GetPretSetari());
        }

        public static bool Afiseaza(Form pEcranPariente, BClientiComenzi pComanda, BClienti pClient, BListaPreturiStandard pLucrare)
        {
            if (pComanda == null)
            {
                //mod creare
                if (pLucrare == null)
                    pLucrare = FormListaLucrari.Afiseaza(pEcranPariente, pClient);

                if (pLucrare != null)
                {
                    using (FormDetaliuComanda ecran = new FormDetaliuComanda(pComanda, pClient, pLucrare))
                    {
                        ecran.AplicaPreferinteleUtilizatorului();
                        return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
                    }
                }
            }
            else
            {
                //mod modificare
                using (FormDetaliuComanda ecran = new FormDetaliuComanda(pComanda, pClient, pLucrare))
                {
                    ecran.AplicaPreferinteleUtilizatorului();
                    return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
                }
            }
            return false;
        }


        internal bool Salveaza()
        {
            bool esteValid = BClientiComenzi.SuntInformatiileNecesareCoerente(this.lLucrareSelectata.Id);
            double pPretUnitarInitial = Convert.ToDouble(this.lblPretUnitarInitial.Text);
            double pPretUnitarFinal = this.txtpretunitarfin.ValoareDouble;

            if (this.lComanda == null)
            {
                if (esteValid && suntCompleteInformatiile())
                {
                    this.lComanda = BClientiComenzi.Add(this.lClient.Id, CUtil.GetAsInt32(this.cboComandaReprezentant.SelectedValue), this.txtComandaPacientNume.Text, this.txtComandaPacientPrenume.Text, this.txtVarsta.ValoareIntreaga, getSexClient(), this.ctrlComandaDataPrimire.DataAfisata, this.ctrlComandaDataLaGata.DataAfisata, this.txtObservatiiComanda.Text, CUtil.GetAsInt32(this.cboCabinet.SelectedValue), this.lLucrareSelectata.Id, this.chkUrgent.Checked, pPretUnitarInitial, pPretUnitarFinal, CUtil.GetAsInt32(this.txtNrElemente.Text), getIdEtapaCurenta(), this.lgfTehnician.IdObiectCorespunzator, this.ctrlDataOraTermen.DataAfisata, this.chkRefacere.Checked, this.cboStare.SelectedIndex, this.txtCuloare.Text, this.txtObservatiiEtapaCurenta.Text, this.chkAcceptata.Checked, this.txtCodComanda.Text, null);
                }
                else
                {
                    seteazaAlerta();
                }
            }
            else
            {
                this.lComanda.IdClient = this.lClient.Id;
                this.lComanda.IdReprezentantClient = this.cboComandaReprezentant.GetSelectedValueAsInt32();
                this.lComanda.IdLucrare = this.lLucrareSelectata.Id;
                this.lComanda.NumePacient = this.txtComandaPacientNume.Text;
                this.lComanda.PrenumePacient = this.txtComandaPacientPrenume.Text;
                this.lComanda.Varsta = this.txtVarsta.ValoareIntreaga;
                this.lComanda.SexPacient = getSexClient();
                this.lComanda.DataPrimire = this.ctrlComandaDataPrimire.DataAfisata;
                this.lComanda.DataLaGata = this.ctrlComandaDataLaGata.DataAfisata;
                this.lComanda.IdCabinet = this.cboCabinet.GetSelectedValueAsInt32();
                this.lComanda.Urgent = this.chkUrgent.Checked;
                //lore 05.09.2019
                this.lComanda.ValoareInitiala = (pPretUnitarInitial * Convert.ToDouble(this.txtNrElemente.Text));
                this.lComanda.ValoareFinala = (pPretUnitarFinal * Convert.ToDouble(this.txtNrElemente.Text));
                this.lComanda.PretUnitarInitial = pPretUnitarInitial;
                this.lComanda.PretUnitarFinal = pPretUnitarFinal;
                //////////////////////
                this.lComanda.NrElemente = CUtil.GetAsInt32(this.txtNrElemente.Text);
                this.lComanda.Culoare = this.txtCuloare.Text;
                this.lComanda.Observatii = this.txtObservatiiComanda.Text;
                this.lComanda.Acceptata = this.chkAcceptata.Checked;
                this.lComanda.CodLucrare = this.txtCodComanda.Text;
                //this.lComanda.IdTehnician = this.lgfTehnician.IdObiectCorespunzator;

                if (esteValid && suntCompleteInformatiile())
                {
                    this.lComanda.UpdateAll(getIdEtapaCurenta(), this.lgfTehnician.IdObiectCorespunzator, this.ctrlDataOraTermen.DataAfisata, this.txtObservatiiEtapaCurenta.Text, this.chkRefacere.Checked, this.cboStare.SelectedIndex, null);
                }
                else
                {
                    seteazaAlerta();
                }
            }

            return esteValid && suntCompleteInformatiile() && verificaData();
        }
        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
            this.ctrlValidareAnulareComanda.AllowModification(this.lEcranInModificare);
            this.txtCodComanda.AllowModification(this.lEcranInModificare);
            this.ctrlComandaDataPrimire.AllowModification(this.lEcranInModificare);
            this.chkAcceptata.AllowModification(this.lEcranInModificare);
            this.txtCuloare.AllowModification(this.lEcranInModificare);
            this.chkUrgent.AllowModification(this.lEcranInModificare);
            this.txtNrElemente.AllowModification(this.lEcranInModificare);
            this.lgfLucrare.AllowModification(this.lEcranInModificare);
            this.ctrlComandaDataLaGata.AllowModification(this.lEcranInModificare);
            this.cboComandaReprezentant.AllowModification(this.lEcranInModificare);
            this.cboCabinet.AllowModification(this.lEcranInModificare);
            this.lgfClinica.AllowModification(this.lEcranInModificare);
            this.txtVarsta.AllowModification(this.lEcranInModificare);
            this.rbMasculin.AllowModification(this.lEcranInModificare);
            this.rbFeminin.AllowModification(this.lEcranInModificare);
            this.txtComandaPacientNume.AllowModification(this.lEcranInModificare);
            this.txtComandaPacientPrenume.AllowModification(this.lEcranInModificare);
            this.txtObservatiiComanda.AllowModification(this.lEcranInModificare);
            this.txtObservatiiEtapaCurenta.AllowModification(this.lEcranInModificare);
            this.cboStare.AllowModification(this.lEcranInModificare);
            this.lgfTehnician.AllowModification(this.lEcranInModificare);
            this.lblStare.AllowModification(this.lEcranInModificare);
            this.cboEtapaCurenta.AllowModification(this.lEcranInModificare);
            this.chkRefacere.AllowModification(this.lEcranInModificare);
            this.ctrlDataOraTermen.AllowModification(this.lEcranInModificare);
            //this.btnVeziToateEtapele.AllowModification(this.lEcranInModificare);
            this.txtpretunitarfin.AllowModification(this.lEcranInModificare);
        }

        #endregion


    }
}
