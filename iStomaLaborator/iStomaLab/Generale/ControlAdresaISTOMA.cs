using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.iStomaLab.Comune;
using BLL.iStomaLab;
using CDL.iStomaLab;
using ILL.BLL.General;
using CCL.iStomaLab;
using BLL.iStomaLab.Locatii;
using BLL.iStomaLab.Referinta;
using CCL.UI;

namespace iStomaLab.Generale
{
    public partial class ControlAdresaISTOMA : UserControlPersonalizat
    {
        #region Declaratii generale

        public event CDefinitiiComune.SelectieUnicaHandler<BAdrese> SelectieEfectuata;
        public event System.EventHandler InchideEcranPopUp;

        private CDefinitiiComune.EnumTipObiect lTipObiectProprietar;
        private int lIdProprietar;
        private IProprietar lProprietar = null;

        private BAdrese lAdresaAfisata;
        private BColectieAdrese lListaAdrese;
        private StructDetaliiAdresa lDetaliiAdresa = new StructDetaliiAdresa();
        private BAdrese.EnumTipAdresa lTipAdresaImpus = BAdrese.EnumTipAdresa.Nedefinit;
        private bool lModSelectie = false;
        private double lLatitudine = 0;
        private double lLongitudine = 0;

        //Vom folosi informatiile de la nivelul sediului
        private static int _SidTaraDinOficiu = BTari.ConstIDRomania;
        private static int _SidRegiuneDinOficiu = 0;
        private static int _SidLocalitateDinOficiu = 0;

        protected void CereInchidereEcranPopUp()
        {
            if (this.InchideEcranPopUp != null)
                InchideEcranPopUp(this, null);
        }

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati

        /// <summary>
        /// In modul de creare nu avem un obiect propriu-zis caruia sa ii atasam adresa
        /// Folosind aceasta proprietate avem acces la informatiile introduse de utilizator in acest control
        /// </summary>
        [Browsable(false)]
        public StructDetaliiAdresa DetaliiAdresa
        {
            get { return this.lDetaliiAdresa; }
        }

        #endregion

        #region Constructor si Initializare

        public ControlAdresaISTOMA()
        {
            InitializeComponent();

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                adaugaHandlere();
                initTextML();
                
                this.txtStrada.CapitalizeazaCuvintele = true;
            }
        }

        private void adaugaHandlere()
        {
            this.btnAdauga.Click += btnAdauga_Click;

            this.ctrlTara.SelecteazaObiectAfisaj += ctrlTara_SelecteazaObiectAfisaj;
            this.ctrlTara.StergeObiectAfisaj += ctrlTara_StergeObiectAfisaj;

            this.ctrlRegiune.SelecteazaObiectAfisaj += ctrlRegiune_SelecteazaObiectAfisaj;
            this.ctrlRegiune.StergeObiectAfisaj += ctrlRegiune_StergeObiectAfisaj;

            this.ctrlLocalitate.SelecteazaObiectAfisaj += ctrlLocalitate_SelecteazaObiectAfisaj;
            this.ctrlLocalitate.StergeObiectAfisaj += ctrlLocalitate_StergeObiectAfisaj;

            this.btnOptiuni.Click += BtnOptiuni_Click;
            this.btnInchidePanelOptiuni.Click += BtnInchidePanelOptiuni_Click;
        }

        private void initTextML()
        {
            this.btnCreeazaSelecteaza.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Selecteaza);
            this.lblAp.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ApartamentPrescurtat);
            this.lblBloc.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.BlocPrescurtat);
            this.lblDataVerificare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataVerificare);
            this.lblEtaj.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.EtajPrescurtat);
            this.lblFax.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Fax);
            this.lblInterfon.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Interfon);
            this.lblJudet.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Judet);
            this.lblLocalitate.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Localitate);
            this.lblNr.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NumarPrescurtat);
            this.lblScara.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ScaraPrescurtat);
            this.lblStrada.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Strada);
            this.lblTara.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tara);
            this.lblTelefonFix.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TelefonFixPrescurtat);
            this.lblTip.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tip);
            this.chkActuala.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Actuala);
        }

        public void Initializeaza(BAdrese pAdresa)
        {
            this.Visible = false;
            this.lModCreare = false;
            incepeIncarcarea();
            gestioneazaVisibilitateButonSelectie();
            if (pAdresa != null)
                this.lAdresaAfisata = pAdresa;
            else
                this.lDetaliiAdresa = new StructDetaliiAdresa();

            this.cboListaAdrese.Visible = false;
            this.btnStareAdrese.Visible = false;
            this.btnStareAdrese.Selectat = false;

            InitializeazaListele();

            InitializeazaControalele();

            finalizeazaIncarcarea();
            this.Visible = true;
        }

        public void Initializeaza(BAdrese pAdresa, CDefinitiiComune.EnumTipObiect pTipProprietar, int pIdProprietar, BAdrese.EnumTipAdresa pTipAdresaImpus)
        {
            this.Visible = false;
            this.lModCreare = false;
            this.lTipAdresaImpus = pTipAdresaImpus;

            this.lTipObiectProprietar = pTipProprietar;
            this.lIdProprietar = pIdProprietar;
            this.lAdresaAfisata = pAdresa;

            if (pAdresa == null)
                this.lDetaliiAdresa = new StructDetaliiAdresa();

            incepeIncarcarea();
            gestioneazaVisibilitateButonSelectie();

            if (this.lAdresaAfisata != null)
            {
                this.flpOptiuni.Visible = false;
                this.panelDetaliiAdresa.Dock = DockStyle.Fill;
            }
            else
            {
                this.flpOptiuni.Visible = true;
                this.panelDetaliiAdresa.Dock = DockStyle.None;
            }

            this.cboListaAdrese.Visible = false;
            this.btnStareAdrese.Visible = false;
            this.btnStareAdrese.Selectat = false;

            InitializeazaListele();

            InitializeazaControalele();

            finalizeazaIncarcarea();
            this.Visible = true;
        }

        public void Initializeaza(int pIdAdresa)
        {
            this.Visible = false;
            this.lModCreare = false;
            incepeIncarcarea();
            gestioneazaVisibilitateButonSelectie();
            if (pIdAdresa > 0)
                this.lAdresaAfisata = new BAdrese(pIdAdresa, null);
            else
                this.lDetaliiAdresa = new StructDetaliiAdresa();

            this.cboListaAdrese.Visible = false;
            this.btnStareAdrese.Visible = false;
            this.btnStareAdrese.Selectat = false;

            InitializeazaListele();

            InitializeazaControalele();

            finalizeazaIncarcarea();
            this.Visible = true;
        }

        public BAdrese Initializeaza(CDefinitiiComune.EnumTipObiect pTipProprietar, int pIdProprietar, bool pModCreare, bool pModSelectie)
        {
            this.Visible = false;
            base.InitializeazaVariabileleGenerale();
            this.lEcranInModificare = false;
            this.lModCreare = pModCreare;
            this.lModSelectie = pModSelectie;

            this.lListaAdrese = null;
            this.lAdresaAfisata = null;

            this.flpOptiuni.Visible = false;
            this.panelDetaliiAdresa.Dock = DockStyle.Fill;
            //this.lProprietar = pProprietar;

            if (pIdProprietar > 0)
            {
                this.lTipObiectProprietar = pTipProprietar;
                this.lIdProprietar = pIdProprietar;
            }
            else
            {
                //In modul creare (la organizatii externe de exemplu)
                //permitem doar completarea unei adrese
                this.lModCreare = true;
                this.cboListaAdrese.Visible = false;
                this.btnAdauga.Visible = false;
                this.btnAnulare.Visible = false;
                this.btnValidare.Visible = false;

                this.lDetaliiAdresa = new StructDetaliiAdresa();
                this.lTipObiectProprietar = CDefinitiiComune.EnumTipObiect.Nedefinit;
                this.lIdProprietar = -1;
            }

            incepeIncarcarea();

            gestioneazaVisibilitateButonSelectie();

            //Afisam adresele active
            this.btnStareAdrese.Visible = false;
            this.btnStareAdrese.Selectat = false;

            if (this.lIdProprietar > 0)
            {
                IncarcaListaAdreseExistente();

                //Determinam adresa de afisat
                this.lAdresaAfisata = ((BColectieAdrese)this.cboListaAdrese.DataSource).GetAdresaDeAfisatDinOficiu();
            }

            InitializeazaListele();

            InitializeazaControalele();

            finalizeazaIncarcarea();

            this.Visible = true;

            return this.lAdresaAfisata;
        }

        public void Initializeaza(IProprietar pProprietar, bool pModCreare, bool pModSelectie)
        {
            this.Visible = false;
            base.InitializeazaVariabileleGenerale();
            this.lEcranInModificare = false;
            this.lModCreare = pModCreare;
            this.lModSelectie = pModSelectie;

            this.lListaAdrese = null;
            this.lAdresaAfisata = null;
            this.lProprietar = pProprietar;

            if (pProprietar != null)
            {
                this.lTipObiectProprietar = pProprietar.TipObiect;
                this.lIdProprietar = pProprietar.Id;
            }
            else
            {
                //In modul creare (la organizatii externe de exemplu)
                //permitem doar completarea unei adrese
                this.lModCreare = true;
                this.cboListaAdrese.Visible = false;
                this.btnAdauga.Visible = false;
                this.btnAnulare.Visible = false;
                this.btnValidare.Visible = false;

                this.lDetaliiAdresa = new StructDetaliiAdresa();
                this.lTipObiectProprietar = CDefinitiiComune.EnumTipObiect.Nedefinit;
                this.lIdProprietar = -1;
            }

            incepeIncarcarea();

            gestioneazaVisibilitateButonSelectie();

            //Afisam adresele active
            this.btnStareAdrese.Visible = false;
            this.btnStareAdrese.Selectat = false;

            if (this.lIdProprietar > 0)
            {
                IncarcaListaAdreseExistente();

                //Determinam adresa de afisat
                this.lAdresaAfisata = ((BColectieAdrese)this.cboListaAdrese.DataSource).GetAdresaDeAfisatDinOficiu();
            }

            InitializeazaListele();

            InitializeazaControalele();

            finalizeazaIncarcarea();

            this.Visible = true;
        }

        #endregion

        #region Evenimente

        /// <summary>
        /// Se modifica valoarea unui control in modul consultare/modificare
        /// </summary>
        /// <param name="psender"></param>
        /// <param name="pNumeProprietate"></param>
        /// <param name="pNouaValoare"></param>
        private void ProprietateDinamica_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            if (!this.lSeIncarca)
            {
                try
                {
                    if (!this.lModCreare || this.lAdresaAfisata == null)
                    {
                        incepeIncarcarea(); // Se revine la valoare initiala in caz de eroare
                        bool VerificareOK = SuntDateleCoerente();
                        finalizeazaIncarcarea();
                        if (VerificareOK)
                        {
                            if (this.lAdresaAfisata != null)
                            {
                                if (CUtil.SetProperty(this.lAdresaAfisata, pNumeProprietate, pNouaValoare))
                                {
                                    this.lAdresaAfisata.UpdateAll(null);
                                }
                            }
                            else
                            {
                                //Mod creare fara obiect atasat
                                object obj = this.lDetaliiAdresa;
                                if (CUtil.SetProperty(obj, pNumeProprietate, pNouaValoare))
                                {
                                    this.lDetaliiAdresa = (StructDetaliiAdresa)obj;
                                }
                            }
                        }
                    }
                    else
                    {
                    }
                }
                catch (Exception exc)
                {
                    GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), exc);
                }
            }
        }

        private void chkActuala_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.lSeIncarca && !this.lModCreare)
            {
                try
                {
                    this.lAdresaAfisata.UpdateAll(null);
                }
                catch (Exception ex)
                {
                    GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
                }
            }
        }

        void ctrlTara_StergeObiectAfisaj(object sender, EventArgs e)
        {
            try
            {
                if (this.lAdresaAfisata != null)
                {
                    this.lAdresaAfisata.IdTara = 0;
                    this.lAdresaAfisata.IdRegiune = 0;
                    this.lAdresaAfisata.IdLocalitate = 0;
                    this.lAdresaAfisata.UpdateAll();
                }
                else
                {
                    this.lDetaliiAdresa.IdTara = 0;
                    this.lDetaliiAdresa.IdRegiune = 0;
                    this.lDetaliiAdresa.IdLocalitate = 0;
                    this.lDetaliiAdresa.IdCodPostal = 0;
                }

                initRegiune(0, 0);
                initLocalitate(0, 0);
                allowModificationRegiuni();
                allowModificationLocalitati();
                this.ctrlTara.Focus();
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        void ctrlTara_SelecteazaObiectAfisaj(object sender, EventArgs e)
        {
            try
            {
                if (this.lAdresaAfisata != null)
                {                                      
                   this.lAdresaAfisata.IdTara = this.ctrlTara.ObiectAfisajCorespunzator.Id;                  
                   this.lAdresaAfisata.IdRegiune = 0;
                    this.lAdresaAfisata.IdLocalitate = 0;
                    this.lAdresaAfisata.UpdateAll();
                }
                else
                {
                    this.lDetaliiAdresa.IdTara = this.ctrlTara.ObiectAfisajCorespunzator.Id;
                    this.lDetaliiAdresa.IdRegiune = 0;
                    this.lDetaliiAdresa.IdLocalitate = 0;
                    this.lDetaliiAdresa.IdCodPostal = 0;
                }

                this.lEcranInModificare = true;

                initRegiune(this.ctrlTara.ObiectAfisajCorespunzator.Id, 0);
                initLocalitate(0, 0);
                allowModificationRegiuni();
                allowModificationLocalitati();
                this.ctrlRegiune.Focus();
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        void ctrlRegiune_StergeObiectAfisaj(object sender, EventArgs e)
        {
            try
            {
                if (this.lAdresaAfisata != null)
                {
                    this.lAdresaAfisata.IdRegiune = 0;
                    this.lAdresaAfisata.IdLocalitate = 0;
                    this.lAdresaAfisata.UpdateAll();
                }
                else
                {
                    this.lDetaliiAdresa.IdRegiune = 0;
                    this.lDetaliiAdresa.IdLocalitate = 0;
                    this.lDetaliiAdresa.IdCodPostal = 0;
                }
                initLocalitate(0, 0);
                allowModificationLocalitati();

                this.ctrlRegiune.Focus();
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        void ctrlRegiune_SelecteazaObiectAfisaj(object sender, EventArgs e)
        {
            try
            {
                if (this.lAdresaAfisata != null)
                {
                    this.lAdresaAfisata.IdRegiune = this.ctrlRegiune.ObiectAfisajCorespunzator.Id;
                    this.lAdresaAfisata.IdLocalitate = 0;
                    this.lAdresaAfisata.UpdateAll();
                }
                else
                {
                    this.lDetaliiAdresa.IdRegiune = this.ctrlRegiune.ObiectAfisajCorespunzator.Id;
                    this.lDetaliiAdresa.IdLocalitate = 0;
                    this.lDetaliiAdresa.IdCodPostal = 0;
                }
            
             
                initLocalitate(this.ctrlRegiune.ObiectAfisajCorespunzator.Id, 0);
                allowModificationLocalitati();
                this.ctrlLocalitate.Focus();
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        void ctrlLocalitate_StergeObiectAfisaj(object sender, EventArgs e)
        {
            try
            {
                if (this.lAdresaAfisata != null)
                {
                    this.lAdresaAfisata.IdLocalitate = 0;
                    this.lAdresaAfisata.UpdateAll();
                }
                else
                {
                    this.lDetaliiAdresa.IdLocalitate = 0;
                    this.lDetaliiAdresa.IdCodPostal = 0;
                }

                this.ctrlLocalitate.Focus();
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        void ctrlLocalitate_SelecteazaObiectAfisaj(object sender, EventArgs e)
        {
            try
            {
                if (this.lAdresaAfisata != null)
                {
                    this.lAdresaAfisata.IdLocalitate = this.ctrlLocalitate.ObiectAfisajCorespunzator.Id;
                    this.lAdresaAfisata.UpdateAll();
                }
                else
                {
                    this.lDetaliiAdresa.IdLocalitate = this.ctrlLocalitate.ObiectAfisajCorespunzator.Id;
                    this.lDetaliiAdresa.IdCodPostal = 0;
                }
                //lore 22.08.2019
                initLocalitate(this.ctrlRegiune.ObiectAfisajCorespunzator.Id, this.ctrlLocalitate.ObiectAfisajCorespunzator.Id);
                allowModificationLocalitati();
                this.ctrlLocalitate.Focus();
                ///
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        private void BtnInchidePanelOptiuni_Click(object sender, EventArgs e)
        {
            this.panelOptiuni.Visible = false;
        }

        private void BtnOptiuni_Click(object sender, EventArgs e)
        {
            this.panelOptiuni.Visible = !this.panelOptiuni.Visible;
            this.panelOptiuni.BringToFront();

            CCL.UI.IHMUtile.SeteazaProprietatiPanelOptiuni(this.panelOptiuni);
            CCL.UI.IHMUtile.SeteazaProprietatiButonInchiderePanelOptiuni(this.btnInchidePanelOptiuni);
        }

        #endregion

        #region Metode private

        private static void initLocatieDinOficiu()
        {
            ////Initializam detaliile de localizare din oficiu cu cele ale sediului (doar prima oara)
            //if (_SidTaraDinOficiu <= 0)
            //{
            //    BLocatii locatiaCurenta = BLocatii.GetLocatieCurenta(null);
            //    if (locatiaCurenta != null)
            //    {
            //        BAdrese adrSediu = locatiaCurenta.getAdresaSediu(null);

            //        if (adrSediu != null)
            //        {
            //            _SidTaraDinOficiu = adrSediu.IdTara;
            //            _SidRegiuneDinOficiu = adrSediu.IdRegiune;
            //            _SidLocalitateDinOficiu = adrSediu.IdLocalitate;
            //        }

            //        adrSediu = null;
            //    }
            //    locatiaCurenta = null;
            //}
        }

        private void gestioneazaVisibilitateButonSelectie()
        {
            this.btnCreeazaSelecteaza.Visible = this.lModSelectie;
        }

        private void anuntaSelectia()
        {
            if (this.SelectieEfectuata != null)
                SelectieEfectuata(this.lAdresaAfisata);
        }

        /// <summary>
        /// Incarcam lista de adrese disponibile
        /// Lista este vizibila doar daca avem minim 2 adrese
        /// In cazul in care avem o singura adresa aceasta este afisata din oficiu, 
        /// deci lista nu are rost
        /// </summary>
        private void IncarcaListaAdreseExistente()
        {
            //Recuperam lista de adrese
            if (this.lListaAdrese == null)
                this.lListaAdrese = BAdrese.GetListByParam(0, this.lTipObiectProprietar, this.lIdProprietar, CDefinitiiComune.EnumStare.Toate, null);

            //Daca nu avem nicio adresa vom crea una
            if (CUtil.EsteListaVida<BAdrese>(this.lListaAdrese))
                this.lListaAdrese.Add(BAdrese.AddEmpty(this.lTipObiectProprietar, this.lIdProprietar, BAdrese.EnumTipAdresa.Nedefinit, null));

            this.cboListaAdrese.DataSource = this.lListaAdrese;//.GetListaDupaStare((this.btnStareAdrese.Selectat ? CDefinitiiComune.EnumStare.Dezactiva : CDefinitiiComune.EnumStare.Activa));
            this.cboListaAdrese.ValueMember = "Id";
            this.cboListaAdrese.DisplayMember = "NumeAfisaj";
            this.cboListaAdrese.SelectedItem = null;
            this.cboListaAdrese.Visible = (this.cboListaAdrese.Items.Count > 1);

            //Butonul Activi/inactivi este vizibil doar daca avem adrese inchise
            this.btnStareAdrese.Visible = this.lListaAdrese.ExistaElementeInchise();
        }

        /// <summary>
        /// Initializam listele derulante
        /// </summary>
        private void InitializeazaListele()
        {
            IncarcaListaTipuriAdresa();
        }

        /// <summary>
        /// Initializam zonele ecranului
        /// </summary>
        private void InitializeazaControalele()
        {
            this.btnAdauga.Visible = !this.lModCreare && !this.btnStareAdrese.Selectat && this.lEcranInModificare;
            this.btnValidare.Visible = this.lModCreare && !this.btnStareAdrese.Selectat && this.lEcranInModificare && this.lIdProprietar > 0;
            this.btnAnulare.Visible = this.lModCreare && !this.btnStareAdrese.Selectat && this.lEcranInModificare && this.lIdProprietar > 0;

            //Daca nu avem un proprietar permitem crearea unei singure adrese
            initLocatieDinOficiu();
            if (this.lAdresaAfisata == null && !this.lModCreare)
            {
                this.lblTip.Visible = false;
                this.cboTipAdresa.Visible = false;
                this.panelDetaliiAdresa.Visible = false;
            }
            else
            {
                this.lblTip.Visible = true;
                this.cboTipAdresa.Visible = true;
                this.panelDetaliiAdresa.Visible = true;

                // Invizibile in modul creare
                this.ctrlCreare.Visible = !this.lModCreare;
                this.ctrlInchidere.Visible = !this.lModCreare;

                if (this.lModCreare)
                {
                    // Toate zonele sunt vide in modul creare

                    // Controalele de baza
                    this.ctrlDataVerificare.DataAfisata = CConstante.DataNula;
                    this.txtStrada.Text = string.Empty;
                    this.txtNumar.Text = string.Empty;
                    this.txtInterfon.Text = string.Empty;
                    this.txtBloc.Text = string.Empty;
                    this.txtScara.Text = string.Empty;
                    this.txtEtaj.Text = string.Empty;
                    this.txtApartament.Text = string.Empty;
                    this.txtTelefon.Text = string.Empty;
                    this.txtFax.Text = string.Empty;
                    this.chkActuala.Checked = false;
                    this.txtComentarii.Text = string.Empty;

                    // Listele derulante
                    this.cboTipAdresa.SelectedItem = BAdrese.StructTipAdresa.GetStructByEnum(BAdrese.EnumTipAdresa.Principala);

                    initTara(_SidTaraDinOficiu);
                    initRegiune(_SidTaraDinOficiu, _SidRegiuneDinOficiu);
                    initLocalitate(_SidRegiuneDinOficiu, _SidLocalitateDinOficiu);

                    this.lDetaliiAdresa.TipAdresa = BAdrese.EnumTipAdresa.Principala;
                    this.lDetaliiAdresa.IdTara = _SidTaraDinOficiu;
                    this.lDetaliiAdresa.IdRegiune = _SidRegiuneDinOficiu;
                    this.lDetaliiAdresa.IdLocalitate = _SidLocalitateDinOficiu;
                }
                else
                {
                    if (this.lTipAdresaImpus == BAdrese.EnumTipAdresa.SediuSocial)
                    {
                        //Nu afisam valabilitatea, complement, etc.
                        this.ctrlDataVerificare.Visible = false;
                        this.lblDataVerificare.Visible = false;
                        this.chkActuala.Visible = false;
                    }

                    // Controalele de baza
                    this.ctrlDataVerificare.DataAfisata = this.lAdresaAfisata.DataVerificare;
                    this.txtStrada.Text = this.lAdresaAfisata.NumeStrada;
                    this.txtNumar.Text = this.lAdresaAfisata.Numar;
                    this.txtInterfon.Text = this.lAdresaAfisata.CodInterfon;
                    this.txtBloc.Text = this.lAdresaAfisata.Bloc;
                    this.txtScara.Text = this.lAdresaAfisata.Scara;
                    this.txtEtaj.Text = this.lAdresaAfisata.Etaj;
                    this.txtApartament.Text = this.lAdresaAfisata.Apartament;
                    this.txtComentarii.Text = this.lAdresaAfisata.Comentariu;

                    // Listele derulante
                    this.cboTipAdresa.SelectedItem = this.lAdresaAfisata.TipAdresa;
                    initTara(this.lAdresaAfisata.IdTara);
                    initRegiune(this.lAdresaAfisata.IdTara, this.lAdresaAfisata.IdRegiune);
                    initLocalitate(this.lAdresaAfisata.IdRegiune, this.lAdresaAfisata.IdLocalitate);

                    //Butonul de acces la localizarea geografica

                    // Controalele mai complexe
                    this.ctrlCreare.Initializeaza(this.lAdresaAfisata);
                    string InfoAdresa = this.lAdresaAfisata.ToString();
                    this.ctrlInchidere.Initializeaza(this.lAdresaAfisata,
                    String.Format(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.mesajConfirmareInchidereX), InfoAdresa),
                    String.Format(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.mesajConfirmareReactivareX), InfoAdresa));
                }
            }
        }

        /// <summary>
        /// Incarcam lista de tipuri de adresa
        /// </summary>
        private void IncarcaListaTipuriAdresa()
        {
            List<BAdrese.StructTipAdresa> listaTipuri = BAdrese.StructTipAdresa.GetList();
            if (this.lTipAdresaImpus == BAdrese.EnumTipAdresa.SediuSocial)
                listaTipuri.Add(BAdrese.StructTipAdresa.GetStructByEnum(BAdrese.EnumTipAdresa.SediuSocial));

            this.cboTipAdresa.DataSource = listaTipuri;
            this.cboTipAdresa.ValueMember = "Id";
            this.cboTipAdresa.DisplayMember = "Nume";

            listaTipuri = null;
        }

        /// <summary>
        /// Incarcam lista de tari
        /// </summary>
        private void initTara(int pIdTara)
        {
            if (pIdTara > 0)
                this.ctrlTara.Initializeaza(new StructIdDenumire(pIdTara, BTari.getTara(pIdTara, null).NumeScurt), CEnumerariComune.EnumTipDeschidere.DreaptaJos);
            else
                this.ctrlTara.Initializeaza(StructIdDenumire.Empty, CEnumerariComune.EnumTipDeschidere.DreaptaJos);
        }

        private void initRegiune(int pIdTara, int pIdRegiune)
        {
            if (pIdRegiune > 0)
                this.ctrlRegiune.Initializeaza(pIdTara, new StructIdDenumire(pIdRegiune, BRegiuni.getRegiune(pIdRegiune, null).Nume), CCL.UI.CEnumerariComune.EnumTipDeschidere.DreaptaJos);
            else
                this.ctrlRegiune.Initializeaza(pIdTara, StructIdDenumire.Empty, CCL.UI.CEnumerariComune.EnumTipDeschidere.DreaptaJos);
        }

        private void initLocalitate(int pIdRegiune, int pIdLocalitate)
        {
            if (pIdLocalitate > 0)
                this.ctrlLocalitate.Initializeaza(pIdRegiune, new StructIdDenumire(pIdLocalitate, BLocalitati.getLocalitate(pIdLocalitate, null).Nume), CCL.UI.CEnumerariComune.EnumTipDeschidere.DreaptaJos);
            else
                this.ctrlLocalitate.Initializeaza(pIdRegiune, StructIdDenumire.Empty, CCL.UI.CEnumerariComune.EnumTipDeschidere.DreaptaJos);
        }

        private void allowModificationTari()
        {
            this.ctrlTara.AllowModification(this.lEcranInModificare && !this.btnStareAdrese.Selectat);
        }

        private void allowModificationRegiuni()
        {
            this.ctrlRegiune.AllowModification(this.lEcranInModificare && !this.btnStareAdrese.Selectat);
        }

        private void allowModificationLocalitati()
        {
            this.ctrlLocalitate.AllowModification(this.lEcranInModificare && !this.btnStareAdrese.Selectat);
        }

        #endregion

        #region Metode publice

        public void SePermiteAdaugarea(bool pSePermite)
        {
            this.btnAdauga.Visible = pSePermite;
        }

        public void PuneFocusPeStrada()
        {
            this.txtStrada.Focus();
        }

        public bool ExistaObiectAdresa()
        {
            return this.lAdresaAfisata != null;
        }

        public void SalveazaAdresa()
        {
            creeazaAdresa();
        }

        public bool EsteAdresaCompletata()
        {
            //if (BComportamentAplicatie.VerificaAdresaPostalaDosarPacient() == CDefinitiiComune.EnumRaspuns.Da)
            //{
            //    if (this.lAdresaAfisata != null && this.lAdresaAfisata.EsteCompletata())
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}

            return true;
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool bPermiteModificarea)
        {
            this.lEcranInModificare = bPermiteModificarea;

            // Butoanele
            this.btnAdauga.Visible = this.lEcranInModificare && !this.btnStareAdrese.Selectat && !this.lModCreare;
            // Butoanul de validare si de anulare sunt vizibile doar daca se doreste adaugarea unei adrese
            this.btnValidare.Visible = this.lEcranInModificare && this.lModCreare && this.lIdProprietar > 0;
            this.btnAnulare.Visible = this.lEcranInModificare && this.lModCreare && this.lIdProprietar > 0;

            // Controalele de baza
            this.ctrlDataVerificare.AllowModification(this.lEcranInModificare && !this.btnStareAdrese.Selectat);
            this.txtStrada.AllowModification(this.lEcranInModificare && !this.btnStareAdrese.Selectat);
            this.txtNumar.AllowModification(this.lEcranInModificare && !this.btnStareAdrese.Selectat);
            this.txtInterfon.AllowModification(this.lEcranInModificare && !this.btnStareAdrese.Selectat);
            this.txtBloc.AllowModification(this.lEcranInModificare && !this.btnStareAdrese.Selectat);
            this.txtScara.AllowModification(this.lEcranInModificare && !this.btnStareAdrese.Selectat);
            this.txtEtaj.AllowModification(this.lEcranInModificare && !this.btnStareAdrese.Selectat);
            this.txtApartament.AllowModification(this.lEcranInModificare && !this.btnStareAdrese.Selectat);
            this.txtTelefon.AllowModification(this.lEcranInModificare && !this.btnStareAdrese.Selectat);
            this.txtFax.AllowModification(this.lEcranInModificare && !this.btnStareAdrese.Selectat);
            this.chkActuala.Enabled = this.lEcranInModificare && !this.btnStareAdrese.Selectat;
            this.txtComentarii.AllowModification(this.lEcranInModificare && !this.btnStareAdrese.Selectat);

            // Listele derulante
            //this.cboTara.AllowModification(this.lEcranInModificare && (this.cboTara.Items.Count > 0) && !this.btnStareAdrese.Selectat);
            //this.cboJudet.AllowModification(this.lEcranInModificare && (this.cboJudet.Items.Count > 0) && !this.btnStareAdrese.Selectat);
            //this.cboLocalitate.AllowModification(this.lEcranInModificare && (this.cboLocalitate.Items.Count > 0) && !this.btnStareAdrese.Selectat);
            //this.cboCP.AllowModification(this.lEcranInModificare && (this.cboCP.Items.Count > 0) && !this.btnStareAdrese.Selectat);
            allowModificationTari();
            allowModificationRegiuni();
            allowModificationLocalitati();

            this.cboTipAdresa.AllowModification(this.lEcranInModificare && !this.btnStareAdrese.Selectat && this.lTipAdresaImpus == BAdrese.EnumTipAdresa.Nedefinit);

            // Controalele mai complexe
            this.ctrlCreare.AllowModification(this.lEcranInModificare && !this.btnStareAdrese.Selectat);
            this.ctrlInchidere.AllowModification(this.lEcranInModificare);
        }

        #endregion

        private void btnStareAdrese_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lSeIncarca)
                {
                    // La inchidere simulam clickul pe acest buton si dorim doar schimbarea starii butonului si modificare accesibilitatii
                    this.btnAdauga.Visible = !this.btnStareAdrese.Selectat;
                    IncarcaListaAdreseExistente();
                    AllowModification(this.lEcranInModificare);
                }
                else
                {
                    this.lModCreare = false;
                    incepeIncarcarea();
                    this.btnAdauga.Visible = !this.btnStareAdrese.Selectat;
                    this.btnValidare.Visible = false;
                    this.btnAnulare.Visible = false;
                    IncarcaListaAdreseExistente();

                    //Determinam adresa de afisat
                    this.lAdresaAfisata = ((BColectieAdrese)this.cboListaAdrese.DataSource).GetAdresaDeAfisatDinOficiu();

                    InitializeazaListele();
                    InitializeazaControalele();

                    AllowModification(this.lEcranInModificare);

                    finalizeazaIncarcarea();
                }
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        private void cboListaAdrese_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lSeIncarca || this.cboListaAdrese.SelectedItem == null) return;

            try
            {
                if (!this.lSeIncarca && this.cboListaAdrese.SelectedItem != null)
                {
                    this.lAdresaAfisata = cboListaAdrese.SelectedItem as BAdrese;

                    incepeIncarcarea();

                    this.cboListaAdrese.SelectedItem = null;
                    InitializeazaListele();
                    InitializeazaControalele();

                    AllowModification(this.lEcranInModificare);
                }
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
            finally { finalizeazaIncarcarea(); }
        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            try
            {
                //Daca avem un tip de adresa impus atunci cream adresa
                if (this.lTipAdresaImpus != BAdrese.EnumTipAdresa.Nedefinit)
                {
                    Initializeaza(BAdrese.AddEmpty(this.lTipObiectProprietar, this.lIdProprietar, BAdrese.EnumTipAdresa.Principala, null), this.lTipObiectProprietar, this.lIdProprietar, this.lTipAdresaImpus);

                    //Plasam focusul pe strada
                    this.txtStrada.Focus();
                }
                else
                {
                    //Cream adresa
                    BAdrese.EnumTipAdresa tipAdresa = CUtil.EsteListaVida<BAdrese>(this.lListaAdrese) ? BAdrese.EnumTipAdresa.Principala : BAdrese.EnumTipAdresa.Secundara;

                    Initializeaza(this.lTipObiectProprietar, this.lIdProprietar, false, this.lModSelectie);
                    this.lEcranInModificare = true;

                    //Afisam adresa nou creata
                    this.lAdresaAfisata = BAdrese.AddEmpty(this.lTipObiectProprietar, this.lIdProprietar, BAdrese.EnumTipAdresa.Principala, null);

                    incepeIncarcarea();

                    this.cboListaAdrese.SelectedItem = null;
                    InitializeazaListele();
                    InitializeazaControalele();

                    AllowModification(this.lEcranInModificare);

                    //Plasam focusul pe strada
                    this.txtStrada.Focus();

                    //this.lModCreare = true;
                    //this.btnValidare.Visible = true;
                    //this.btnAnulare.Visible = true;
                    //// Pana nu validam crearea nu avem ce informatii referitoare la creare sa afisam si
                    //// nici ce sa inchidem
                    //this.panelDetaliiAdresa.Visible = true;
                    //this.ctrlCreare.Visible = false;
                    //this.ctrlInchidere.Visible = false;
                    //incepeIncarcarea();

                    //InitializeazaControalele();

                    ////Daca este prima adresa pe care o cream atunci consideram ca aceasta este adresa principala actuala
                    ////altfel o consideram ca fiind secundara
                    //if (CUtil.EsteListaVida<BAdrese>(this.lListaAdrese))
                    //{
                    //    this.cboTipAdresa.SelectedItem = BAdrese.EnumTipAdresa.Principala;
                    //    this.chkActuala.Checked = true;
                    //}
                    //else
                    //    this.cboTipAdresa.SelectedItem = BAdrese.EnumTipAdresa.Secundara;

                    //this.ctrlDataVerificare.DataAfisata = DateTime.Today;
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

        private bool SuntDateleCoerente()
        {
            string MesajEroare = string.Empty;

            // Tipul adresei este obligatoriu
            if (this.cboTipAdresa.SelectedItem == null ||
                ((BAdrese.StructTipAdresa)this.cboTipAdresa.SelectedItem).Id == BAdrese.EnumTipAdresa.Nedefinit)
            {
                // Semnalam eroarea
                // "Tipul adresei este obligatoriu"
                MesajEroare = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TipulAdreseiEsteObligatoriu);
                // Incercam sa corectam eroarea
                if (this.lAdresaAfisata != null)
                {
                    this.cboTipAdresa.SelectedItem = this.lAdresaAfisata.TipAdresa;
                }
                //Deschidem lista pentru ca utilizatorul sa poate cu usurinta selecta un alt tip de adresa
                this.cboTipAdresa.DroppedDown = true;
            }

            if (!string.IsNullOrEmpty(MesajEroare))
                Mesaj.Afiseaza(this.GetFormParinte(), MesajEroare, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Eroare), Mesaj.EnumButoane.OK, Mesaj.EnumIcoana.Eroare);

            return string.IsNullOrEmpty(MesajEroare);
        }

        private void btnCreeazaSelecteaza_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lModCreare)
                    creeazaAdresa();

                anuntaSelectia();
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
            finally { finalizeazaIncarcarea(); }
        }

        private void creeazaAdresa()
        {
            // Tipul adresei este obligatoriu
            if (SuntDateleCoerente())
            {
                this.lModCreare = false;

                //Adaugam adresa in Baza de date
                if (this.lIdProprietar > 0)
                {
                    int IdAdresaCreata = BAdrese.Add(((BAdrese.StructTipAdresa)this.cboTipAdresa.SelectedItem).Id,
                        this.txtStrada.Text,
                        this.txtNumar.Text,
                        this.txtBloc.Text,
                        this.txtScara.Text,
                        this.txtEtaj.Text,
                        this.txtApartament.Text,
                        this.txtInterfon.Text,
                        this.ctrlTara.ObiectAfisajCorespunzator.Id,
                        this.ctrlRegiune.ObiectAfisajCorespunzator.Id,
                        this.ctrlLocalitate.ObiectAfisajCorespunzator.Id,
                        string.Empty, 
                        this.txtComentarii.Text,
                        this.lTipObiectProprietar,
                        this.lIdProprietar,
                        null);
                    BAdrese AdresaCreata = new BAdrese(IdAdresaCreata);
                    this.lListaAdrese.Add(AdresaCreata);
                    IncarcaListaAdreseExistente();
                    this.lAdresaAfisata = AdresaCreata;
                    AdresaCreata = null;
                }

                incepeIncarcarea();
                InitializeazaControalele();
            }
        }

        private void btnValidare_Click(object sender, EventArgs e)
        {
            try
            {
                creeazaAdresa();
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
            finally { finalizeazaIncarcarea(); }
        }

        private void btnAnulare_Click(object sender, EventArgs e)
        {
            try
            {
                this.lModCreare = false;
                InitializeazaControalele();

                CereInchidereEcranPopUp();
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        private void ctrlInchidere_ModificareInchidere(object sender, EventArgs e)
        {
            try
            {
                incepeIncarcarea();
                this.lListaAdrese = null;
                IncarcaListaAdreseExistente();
                this.btnStareAdrese.Selectat = !this.lAdresaAfisata.EsteActiv;
                AllowModification(this.lEcranInModificare);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
            finally { finalizeazaIncarcarea(); }
        }

    }
}
