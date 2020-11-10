using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Comune;
using BLL.iStomaLab.Referinta;
using BLL.iStomaLab.Utilizatori;
using CCL.iStomaLab;
using CCL.iStomaLab.Utile;
using CCL.UI;
using CCL.UI.FormulareComune;
using CDL.iStomaLab;
using iStomaLab.Caramizi;
using iStomaLab.Generale;
using iStomaLab.Marketing;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BLL.iStomaLab.Utilizatori.BUtilizatorDrepturi;
using static CDL.iStomaLab.CDefinitiiComune;

namespace iStomaLab
{
    public partial class EcranPrincipal : Form, ILL.iStomaLab.IComunicareIHM, ILL.General.Interfete.IAccesTotal
    {

        #region Declaratii generale

        private ColectieStructOptiuni lListaOptiuni = null;
        private ColectieStructRubrici lListaRubrici = null;

        private System.Windows.Forms.NotifyIcon niNotificariUtilizator;
        private bool lSeVreaDeconectare = false;
        private bool lInchideAplicatia = false;
        private bool lEcranInModificare = true;
        private bool lSeIncarca = false;
        private EnumRubrica lRubricaSelectata = EnumRubrica.TablouDeBord;
        private EnumOptiune lOptiuneSelectata = EnumOptiune.TablouDeBord;
        private ButonOptiuneMeniuStanga btnOptiuneMeniuStanga = null;

        private Setari.Personal.ControlListaUtilizatori lctrlGestiunePersonal = null;
        private TablouDeBord.Clienti.ControlListaClienti lctrlGestiuneClienti = null;
        //private ControlComunicare lctrlComunicare = null;
        private Rapoarte.ControlListaRapoarte lctrlListaRapoarte = null;
        private Setari.Lucrari.ControlGestiuneListaDePreturi lctrlGestiuneListaDePreturi = null;
        private Setari.Locatii.ControlListaLocatii lctrlGestiuneLocatii = null;
        private Setari.Liste.ControlGestiuneListe lctrlGestiuneDiverse = null;
        private TablouDeBord.ControlTablouDeBord lctrlTablouDeBord = null;
        private TablouDeBord.Facturare.ControlGestiuneFacturare lctrlFacturare = null;
        private Setari.Comportament.ControlListaComportament lctrlComportament = null;
        private Marketing.ControlMarketingProspecti lctrlMarketingProspecti = null;
        private Marketing.ControlMarketingTrimitereSMS lctrlMarketingTrimitereSMS = null;
        private Marketing.ControlMarketingTrimitereEmail lctrlMarketingTrimitereEmail = null;
        private Gestiune.ControlGestiuneFurnizori lctrlGestiuneFurnizori = null;
        private Gestiune.ControlGestiuneStocuri lctrlGestiuneStocuri = null;
        private Gestiune.ControlGestiunePlati lctrlGestiunePlati = null;
        private ResurseUmane.ControlConcedii lctrlConcedii = null;
        private ResurseUmane.ControlPiataStomatologica lctrlPiataStomatologica = null;
        private ResurseUmane.ControlPontaj lctrlPontaj = null;
        private ResurseUmane.ControlVenituri lctrlVenituri= null; 

        #endregion

        #region Enumerari si Structuri


        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        internal static bool existaLicenta()
        {
            return existaCheieLicenta();
        }


        private static bool existaCheieLicenta()
        {
            RegistryKey cheie = Registry.CurrentUser.OpenSubKey(@_SOFT_REG);
            if (cheie == null)
                cheie = Registry.CurrentUser.CreateSubKey(@_SOFT_REG);

            string cheieLicenta = Convert.ToString(cheie.GetValue("LICENTA"));

            if (string.IsNullOrEmpty(cheieLicenta))
            {
                CGestiuneIO.PuneLicentaInRegistriiDacaExistaInConfig();
                cheieLicenta = Convert.ToString(cheie.GetValue("LICENTA"));
            }

            return !string.IsNullOrEmpty(cheieLicenta);
        }

        internal static bool existaConexiuneBDD()
        {
            return CGestiuneIO.existaConexiuneBDD();
        }

        private frmAsteptare lEcranAsteptare = new frmAsteptare();
        private void afiseazaEcranAsteptare()
        {
            if (this.lEcranAsteptare == null || this.lEcranAsteptare.IsDisposed)
                this.lEcranAsteptare = new frmAsteptare();

            this.lEcranAsteptare.Show();
            this.lEcranAsteptare.Refresh();
            System.Threading.Thread.Sleep(500);
        }

        public void inchideEcranAsteptare()
        {
            if (this.lEcranAsteptare != null && !this.lEcranAsteptare.IsDisposed)
                this.lEcranAsteptare.Close();
        }

        public EcranPrincipal()
        {
            bool continuaExecutia = true;
            //verificam informatiile
            if (!existaLicenta() || !existaConexiuneBDD())
            {
                inchideEcranAsteptare();
                using (controlParametraj activare = new controlParametraj())
                {
                    if (!activare.IsDisposed)
                        continuaExecutia = CCL.UI.IHMUtile.DeschideEcran(this, activare);
                }

                if (!continuaExecutia)
                {
                    Application.Exit();

                    return;
                }
            }

            afiseazaEcranAsteptare();

            Tuple<string, string> raspuns = BGeneral.VerificaComunicareaCuBazaDeDate();
            if (raspuns != null)
            {
                if (!string.IsNullOrEmpty(raspuns.Item1) || !string.IsNullOrEmpty(raspuns.Item2))
                {
                    MessageBox.Show(raspuns.Item1, raspuns.Item2, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    forteazaInchidereaAplicatiei();

                    return;
                }
            }

            //Vericam licenta
            raspuns = verificaCalculatorul();

            if (raspuns != null)
            {
                if (!string.IsNullOrEmpty(raspuns.Item1) || !string.IsNullOrEmpty(raspuns.Item2))
                {
                    MessageBox.Show(raspuns.Item1, raspuns.Item2, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    forteazaInchidereaAplicatiei();

                    return;
                }
            }

            //Daca totul este OK continuam

            if (BUtilizator.GetUtilizatorConectat() == null)
            {
                inchideEcranAsteptare();
                if (!FormLogin.Afiseaza(null))
                {
                    forteazaInchidereaAplicatiei();
                    return;
                }
            }

           if(!IHMUtile.VerificaSiInstaleazaCrystalReports("Crystal Reports", false))
                MessageBox.Show(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NuExistaInstalatSAPCrystalReports), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Eroare), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Mesaj.Informare(this, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NuExistaInstalatSAPCrystalReports), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Eroare));

            this.DoubleBuffered = true;
            InitializeComponent();
            this.niNotificariUtilizator = new System.Windows.Forms.NotifyIcon(this.components);

            IHMUtile._AccesTotal = this;

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                adaugaHandlere();
                initTextML();
            }

            this.mnuUpgrade.Visible = _SExistaUpgradeDisponibil;

            inchideEcranAsteptare();
        }

        internal static Tuple<string, string> verificaCalculatorul()
        {
            //MessageBox.Show("verificaCalculatorul");
            //Pentru a genera imaginea ce contine data verificarii -> Altfel nu putem transforma sirurile de caractere
            CSecuritate.Marcheaza(Properties.Resources.idv);
            return verifCalc();
        }

        private static string getCheieLicenta()
        {
            RegistryKey cheie = Registry.CurrentUser.OpenSubKey(@_SOFT_REG);
            if (cheie != null)
                return Convert.ToString(cheie.GetValue("LICENTA"));

            return string.Empty;
        }

        private static string _SActivare = "33";
        private static string _MesajEroare = "";
        private static DateTime _SDataServer = CConstante.DataNula;
        private static DateTime _SDataVerifServerIStoma = CConstante.DataNula;
        private static bool _SExistaUpgradeDisponibil = false;
        private static string _SCumStaCuPlata = string.Empty;
        internal static Tuple<string, string> verifCalc()
        {
            //MessageBox.Show("Verif calc");
            Tuple<string, string> retur = null;
            _SActivare = "33";
            _MesajEroare = string.Empty;
            _SDataVerifServerIStoma = CConstante.DataNula;

            try
            {
                //MessageBox.Show("Inainte de net");
                if (CGestiuneIO.ExistaConexiuneInternet())
                {
                    //MessageBox.Show("Are net");

                    BMasina.setIdMasina();

                    BUtilizator userIST = BUtilizator.GetUtilizatorISTOMA(null);

                    iStatie.ValidareStatieDeLucruSoapClient verif = new iStatie.ValidareStatieDeLucruSoapClient();

                    string idMasina = BMasina.getIdMasina();
                    string licenta = getCheieLicenta();

                    string raspuns = verif.VerificaStatiaV2(userIST.ContStoma, userIST.ParolaStoma, licenta, idMasina, BMasina.getDenumireMasina());

                    //MessageBox.Show(raspuns);
                    _SDataServer = CSecuritate.FinalizeazaInregistrarea(raspuns);
                    verif.Close();

                    if (_SDataServer != CConstante.DataNula)
                        _SActivare = "13";
                    else
                        _SActivare = "66";
                    verif.Close();

                    Actualizari.ActualizariSoapClient act = new Actualizari.ActualizariSoapClient();
                    _SExistaUpgradeDisponibil = act.ExistaActualizareDisponibila(userIST.ContStoma, userIST.ParolaStoma, getCheieLicenta(), BMasina.getIdMasina());
                    act.Close();

                    verif = null;

                    if (_SActivare.Equals("66"))
                    {
                        if (!string.IsNullOrEmpty(raspuns))
                            retur = new Tuple<string, string>(string.Empty, string.Empty);
                        else
                            retur = new Tuple<string, string>(String.Format("{0} - {1} - ({2}:{3} - {4:dd.MM.yyyy HH:mm})", "Contactati un reprezentant IDAVA SOLUTIONS", BMasina.getIdMasina(), userIST != null ? userIST.ContStoma : "U", userIST != null ? userIST.ParolaStoma : "P", DateTime.Now), "Licenta iStoma LTD");
                    }
                    else
                    {
                        iStoma.VerificareSoapClient plata = new iStoma.VerificareSoapClient();
                        _SCumStaCuPlata = plata.CumStaCuPlata(userIST.ContStoma, userIST.ParolaStoma, getCheieLicenta());
                        plata.Close();
                        plata = null;
                    }

                    userIST = null;
                    _SDataVerifServerIStoma = DateTime.Now;
                }
                else
                {
                    if (!verifLicentaRecenta())
                    {
                        _SActivare = "66";
                        //"Vă rugăm să vă conectați la internet pentru verificarea licenței"

                        //Nu putem folosi multilingv cand dictionarul nu poate fi incarcat
                        retur = new Tuple<string, string>("Vă rugăm să vă conectați la internet pentru verificarea licenței", "Contactati un reprezentant iStoma LTD");
                    }
                }
            }
            catch (Exception)
            {
                //Oricum nu face sens sa crape aplicatia daca nu are omul internet, indiferent de motiv
            }

            return retur;
        }

        internal static bool verifLicentaRecenta()
        {
            DateTime dataVerif = CSecuritate.getDataVerificare();

            //In lipsa unei conexiuni permanente la internet verificarea licentei este totusi necesara o data pe luna
            if (dataVerif > DateTime.Today.AddDays(1) || DateAndTime.DateDiff(DateInterval.Day, dataVerif, DateTime.Today) > 30)
                dataVerif = CConstante.DataNula;

            return dataVerif != CConstante.DataNula;
        }

        private void forteazaInchidereaAplicatiei()
        {
            this.Close();
            Application.Exit();
            Program.KillAll();
        }

        void _Load(object sender, EventArgs e)
        {
            try
            {
                if (!CCL.UI.IHMUtile.SuntemInDebug())
                {
                    CCL.UI.IHMUtile._ComunicareIHM = this;
                    Initializeaza();
                    AllowModification(true);
                }
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this, ex);
            }
        }

        private void setProprietatiRubrica(ButonRubricaMeniuStanga pButon, StructRubrici pRubrica, PanelOptiuniMeniuStanga pPanelOptiuni, bool pDeschis)
        {
            pButon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
           | System.Windows.Forms.AnchorStyles.Right)));
            pButon.FlatAppearance.BorderSize = 0;
            pButon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            pButon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            pButon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            pButon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            pButon.Location = new System.Drawing.Point(3, 32);
            pButon.Size = new System.Drawing.Size(160, 23);
            //pButon.TabIndex = 3;
            pButon.Text = "";
            pButon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            pButon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            pButon.UseVisualStyleBackColor = true;
            pButon.Name = string.Concat("btnRubrica_", Convert.ToInt32(pRubrica.Id));
            pButon.Initializeaza(pRubrica.Denumire, pRubrica.Id, pDeschis, pPanelOptiuni);
        }

        private void setProprietatiPanel(PanelOptiuniMeniuStanga pPanel, StructRubrici pRubrica)
        {
            pPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
           | System.Windows.Forms.AnchorStyles.Right)));
            pPanel.BackColor = System.Drawing.Color.White;
            pPanel.Location = new System.Drawing.Point(17, 32);
            pPanel.Margin = new System.Windows.Forms.Padding(17, 3, 3, 3);
            pPanel.Size = new System.Drawing.Size(165, 88);
            //pPanel.TabIndex = 1;
            pPanel.Visible = false;
            pPanel.Name = string.Concat("panelOptiuni_", Convert.ToInt32(pRubrica.Id));
        }

        private void setProprietatiOptiuni(ButonOptiuneMeniuStanga pButon, StructOptiuni pOptiune, bool pSelectat)
        {
            pButon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            pButon.FlatAppearance.BorderSize = 0;
            pButon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            pButon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            pButon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            pButon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            pButon.Location = new System.Drawing.Point(3, 3);
            pButon.Size = new System.Drawing.Size(160, 23);
            //pButon.TabIndex = 0;
            pButon.Text = "";
            pButon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            pButon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            pButon.UseVisualStyleBackColor = true;
            pButon.Name = string.Concat("btnOptiune_", Convert.ToInt32(pOptiune.Id));
            pButon.Initializeaza(pOptiune.Denumire, pOptiune.Id, pSelectat);
        }


        public void Initializeaza()
        {
            incepeIncarcarea();

            this.mnuStOptComunicare.Visible = false;

            this.txtClinica.Initializeaza(StructIdDenumire.Empty, CCL.UI.CEnumerariComune.EnumTipDeschidere.DreaptaJos);
            this.txtClinica.AscundeButonCautare();

            this.lListaOptiuni = BUtilizatorDrepturi.GetByUserConectat(null);
            this.lListaRubrici = this.lListaOptiuni.GetListaRubriciAsStruct();

            if (!this.lListaRubrici.Contains(this.lRubricaSelectata))
            {
                if (this.lListaRubrici.Count > 0)
                    this.lRubricaSelectata = this.lListaRubrici[0].Id;
            }

            if (!this.lListaOptiuni.Contine(this.lOptiuneSelectata))
            {
                this.lOptiuneSelectata = this.lListaOptiuni.GetPrimaByRubrica(this.lRubricaSelectata);
            }

            //incarcam meniul din stanga dinamic
            this.flpMeniuStanga.SuspendLayout();
            this.flpMeniuStanga.Controls.Clear();

            //rubrici

            ButonRubricaMeniuStanga btnRubrica = null;
            ButonOptiuneMeniuStanga btnOptiune = null;
            PanelOptiuniMeniuStanga panelOptiuni = null;
            int inaltime = 0;
            int nrOptiuni = 0;

            foreach (var idRubrica in this.lListaRubrici)
            {
                //Adaugam rubrica
                btnRubrica = new ButonRubricaMeniuStanga();
                panelOptiuni = new PanelOptiuniMeniuStanga();

                setProprietatiPanel(panelOptiuni, idRubrica);
                setProprietatiRubrica(btnRubrica, idRubrica, panelOptiuni, idRubrica.Id == this.lRubricaSelectata);
                btnRubrica.Click += MnuRubrica_Click;

                //O punem in flp principal
                this.flpMeniuStanga.Controls.Add(btnRubrica);

                //Adaugam flp
                flpMeniuStanga.Controls.Add(panelOptiuni);
                inaltime = 0;
                nrOptiuni = 0;
                foreach (var optiune in this.lListaOptiuni.GetByRubricaAsStruct(idRubrica.Id))
                {
                    //Adaugam optiunile
                    btnOptiune = new ButonOptiuneMeniuStanga();

                    setProprietatiOptiuni(btnOptiune, StructOptiuni.GetByIdEnum(optiune.Id), optiune.Id == this.lOptiuneSelectata);

                    btnOptiune.Click += MnuStOpt_Click;

                    panelOptiuni.Controls.Add(btnOptiune);

                    nrOptiuni += 1;
                    inaltime += btnOptiune.Height + 6;
                }

                //Setam corect inaltimea panelOptiuni
                panelOptiuni.Height = inaltime;
            }

            this.flpMeniuStanga.ResumeLayout();

            CCL.UI.IHMUtile._ComunicareIHM = this;

            incarcaOptiuneaSelectata(this.lOptiuneSelectata);

            initCursBNR();

            setTitluEcran();

            finalizeazaIncarcarea();
        }

        private void setVizibilitate(bool pVizibil, ButonRubricaMeniuStanga pRubrica, PanelOptiuniMeniuStanga pPanel, List<EnumOptiune> pListaOptiuniRubrica)
        {
            pRubrica.SetDisponibilitate(pVizibil);
            pPanel.SetDisponibilitate(pVizibil);

            int nrOptiuni = 0;
            int inaltime = 0;
            ButonOptiuneMeniuStanga optiuneTemp = null;
            foreach (var item in pPanel.Controls)
            {
                if (item is ButonOptiuneMeniuStanga)
                {
                    optiuneTemp = item as ButonOptiuneMeniuStanga;
                    if (optiuneTemp.SetDisponibilitate(pListaOptiuniRubrica.Contains(optiuneTemp.Optiune)))
                    {
                        nrOptiuni += 1;
                        inaltime += optiuneTemp.Height + 6;
                    }
                }
            }

            if (pVizibil)
                pPanel.Height = inaltime;
        }

        private void adaugaHandlere()
        {
            this.Load += _Load;
            this.mnuIesire.Click += MnuIesire_Click;
            this.mnuDeconectare.Click += MnuDeconectare_Click;
            this.mnuPauza.Click += MnuPauza_Click;
            this.mnuMeniuStanga.Click += MnuMeniuStanga_Click;
            this.mnuCheckInOut.Click += MnuCheckInOut_Click;
            this.mnuSchimbaParola.Click += MnuSchimbaParola_Click;

            this.mnuStTablouDeBord.Click += MnuRubrica_Click;
            this.mnuStRapoarte.Click += MnuRubrica_Click;
            this.mnuStSetari.Click += MnuRubrica_Click;
            this.mnuStMarketing.Click += MnuRubrica_Click;
            this.mnuStGestiune.Click += MnuRubrica_Click;

            this.mnuStOptRapoarte.Click += MnuStOpt_Click;
            this.mnuStOptSetariListaDePreturi.Click += MnuStOpt_Click;
            this.mnuStOptSetariLocatii.Click += MnuStOpt_Click;
            this.mnuStOptSetariPersonal.Click += MnuStOpt_Click;
            this.mnuStOptTablouDeBord.Click += MnuStOpt_Click;
            this.mnuStOptClienti.Click += MnuStOpt_Click;
            this.mnuStOptSetariDiverse.Click += MnuStOpt_Click;
            this.mnuStOptComunicare.Click += MnuStOpt_Click;
            this.mnuStOptFacturare.Click += MnuStOpt_Click;

            this.mnuStOptProspecti.Click += MnuStOpt_Click;
            this.mnuStOptTrimitereSMS.Click += MnuStOpt_Click;
            this.mnuStOptTrimitereEmail.Click += MnuStOpt_Click;
            this.mnuStOptSetariComportament.Click += MnuStOpt_Click;

            this.mnuStOptGestiuneFurnizori.Click += MnuStOpt_Click;
            this.mnuStOptGestiuneStocuri.Click += MnuStOpt_Click;
            this.mnuStOptGestiunePlati.Click += MnuStOpt_Click;

            this.ctrlPauza.ParolaCorecta += CtrlPauza_ParolaCorecta;
            this.FormClosing += EcranPrincipal_FormClosing;

            this.mnuAdaugaClinica.Click += MnuAdaugaClinica_Click;
            this.mnuAdaugaComanda.Click += MnuAdaugaComanda_Click;
            this.mnuAdaugaMedic.Click += MnuAdaugaMedic_Click;

            this.FormClosing += EcranPrincipal_FormClosing1;

            this.mnuBtnCursBNR.Click += MnuBtnCursBNR_Click;

            this.mnuUpgrade.Click += MnuUpgrade_Click;

            this.txtClinica.SelecteazaObiectAfisaj += TxtClinica_SelecteazaObiectAfisaj;

            this.btnDespre.Click += BtnDespre_Click;

            this.mnuScanBarcode.Click += MnuScanBarCode_Click;
        }

        private void initTextML()
        {
            this.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.IstomaLTD);
            this.mnuStTablouDeBord.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TablouDeBord);
            this.mnuStOptTablouDeBord.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TablouDeBord);
            this.mnuStOptClienti.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Clienti);
            this.mnuStOptComunicare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Comunicare);
            this.mnuStOptFacturare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Facturare);
            this.mnuStRapoarte.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Rapoarte);
            this.mnuStOptRapoarte.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Rapoarte);
            this.mnuStSetari.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Setari);
            this.mnuStOptSetariListaDePreturi.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ListaDePreturi);
            this.mnuStOptSetariLocatii.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Locatii);
            this.mnuStOptSetariPersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Personal);
            this.mnuStOptSetariDiverse.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Diverse);
            this.mnuMeniuStanga.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.MeniuStanga);
            this.mnuSchimbaParola.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.SchimbaParola);
            this.mnuPauza.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pauza);
            this.mnuDeconectare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Deconectare);
            this.mnuIesire.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Iesire);

            this.mnuAdauga.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Adauga);
            this.mnuAdaugaClinica.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.AdaugaClinica);
            this.mnuAdaugaComanda.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.AdaugaComanda);
            this.mnuAdaugaMedic.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.AdaugaMedic);

            this.mnuBtnCursBNR.Text = string.Format("{0}:...", BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CursBNR));
        }

        #endregion

        #region Evenimente

        private void TxtClinica_SelecteazaObiectAfisaj(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                int idClinica = this.txtClinica.IdObiectAfisajCorespunzator;
                this.txtClinica.Goleste();
                this.txtClinica.AscundeButonCautare();

                IHMUtile.DeschideDosarClient(this.GetFormParinte(), idClinica);
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

        private Form GetFormParinte()
        {
            return this;
        }

        #region Comunicare IHM

        public System.Drawing.Point GetLocation() { return this.Location; }
        public System.Drawing.Size GetSize() { return this.Size; }

        public void ImprimaDGV(object pDGV)
        {
            Imprimare.frmImprimareDGV.Imprima(pDGV as CCL.UI.DataGridViewPersonalizat);
        }

        public void ExportaDGV(object pDGV)
        {
            Export.frmExportDGV.Exporta(this, pDGV as CCL.UI.DataGridViewPersonalizat, string.Empty, true, false);
        }

        public void TrimiteDGVPeEmail(object pDGV)
        {

        }

        #endregion

        #region Meniu Sus

        private void MnuUpgrade_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                lanseazaUpgrade(false);
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

        private void MnuBtnCursBNR_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (ServiciiExterne.FormCursBNR.Afiseaza(this))
                    initCursBNR();
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this, ex);
            }
            finally
            {
                finalizeazaIncarcarea();
            }
        }

        private void BtnDespre_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (frmDespre.Afiseaza(this))
                    lanseazaUpgrade(true);
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

        private void MnuScanBarCode_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                FormScanareBarcode.Afiseaza(this);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this, ex);
            }
            finally
            {
                finalizeazaIncarcarea();
            }

        }

        private void MnuAdaugaMedic_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                TablouDeBord.Clienti.FormCreareReprezentant.Afiseaza(this, null);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this, ex);
            }
            finally
            {
                finalizeazaIncarcarea();
            }

        }

        private void MnuAdaugaComanda_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BClienti client = FormListaClinici.Afiseaza(this);

                if (client != null)
                {
                    if (TablouDeBord.Clienti.FormDetaliuComanda.Afiseaza(this, null, client, null))
                    {
                        if (this.lctrlTablouDeBord != null)
                            this.lctrlTablouDeBord.Initializeaza();
                    }
                }

            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this, ex);
            }
            finally
            {
                finalizeazaIncarcarea();
            }

        }

        private void MnuAdaugaClinica_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                TablouDeBord.Clienti.FormCreareClient.Afiseaza(this);

                //TablouDeBord.Clienti.FormDetaliuClient.Afiseaza(this, null);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this, ex);
            }
            finally
            {
                finalizeazaIncarcarea();
            }

        }

        private void MnuCheckInOut_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                FormCheckInOut.Afiseaza(this);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this, ex);
            }
            finally
            {
                finalizeazaIncarcarea();
            }

        }

        private void MnuSchimbaParola_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                int idUser = BUtilizator.GetIdUtilizatorConectat(null);
                SchimbaParolaISTOMA(idUser);
                Deconecteaza();
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this, ex);
            }
            finally
            {
                finalizeazaIncarcarea();
            }

        }

        private void MnuMeniuStanga_Click(object sender, EventArgs e)
        {

            this.flpMeniuStanga.Visible = !this.flpMeniuStanga.Visible;


            if (this.flpMeniuStanga.Visible)
            {
                this.panelContainer.Dock = DockStyle.None;
                this.panelContainer.Height = this.panelGlobal.Height;
                this.panelContainer.Width = this.panelGlobal.Width - this.flpMeniuStanga.Width;
            }
            else
            {
                this.panelContainer.Width = this.panelGlobal.Width;
                this.panelContainer.Dock = DockStyle.Fill;
            }

        }

        private void MnuIesire_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MnuDeconectare_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                Deconecteaza();
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this, ex);
            }
            finally
            {
                finalizeazaIncarcarea();
            }
        }
        public void Deconecteaza()
        {
            setUltimulUtilizatorConectat();

            //if (this.lPreferinteUtilizator != null)
            //{
            //    //Deconectam toti utilizatorii ce au conexiune automata pe acest calculator
            //    BPreferinteAplicatie.GetPreferinteAplicatieByMasina().Deconecteaza(null);
            //}

            //BUtilizator.DeconectareUtilizator();
            //IHMUtile.DistrugeObiectele();

            this.lSeVreaDeconectare = true;
            BUtilizator.DeconecteazaUtilizatorConectat(null);
            BGeneral.DistrugeObiectele();

            Program._SDeconectat = true;
            this.lInchideAplicatia = false;
            this.Close();
        }


        private void MnuPauza_Click(object sender, EventArgs e)
        {
            this.mnuSus.Visible = false;
            this.panelGlobal.Visible = false;
            this.ctrlPauza.Visible = true;
            this.ctrlPauza.Focus();
            this.ctrlPauza.Initializeaza();
        }

        #endregion

        private void EcranPrincipal_FormClosing1(object sender, FormClosingEventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                CCL.DAL.CCerereSQL.creazaCopieDeRezerva(false);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this, ex);
            }
            finally
            {
                finalizeazaIncarcarea();
            }

        }

        private void MnuStOpt_Click(object sender, EventArgs e)
        {
            schimbaOptiuneaActiva(sender as ButonOptiuneMeniuStanga);
        }

        private void MnuRubrica_Click(object sender, EventArgs e)
        {
            schimbaDeschidereaRubricilor(sender as ButonRubricaMeniuStanga);
        }

        private void CtrlPauza_ParolaCorecta(object sender, EventArgs e)
        {
            this.mnuSus.Visible = true;
            this.panelGlobal.Visible = true;
            this.ctrlPauza.Visible = false;
        }

        private void EcranPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.lSeVreaDeconectare)
            {
                bool ok = FormInchidereAplicatie.Afiseaza(this);

                if (!ok)
                    e.Cancel = true;
                else
                    this.lInchideAplicatia = true;
            }
        }

        #endregion

        #region Metode private

        private void lanseazaUpgrade(bool pPermiteLansarea)
        {
            System.Diagnostics.Process.Start(string.Concat(CUtil.GetLocatieAplicatie(), "\\ActualizareAplicatie.exe"), pPermiteLansarea ? "" : "L");

            //Fortam inchiderea tuturor instantelor gasite ale aplicatiei
            Program.KillAll();
            //forteazaInchidereaAplicatiei();
        }

        private void initCursBNR()
        {
            this.mnuBtnCursBNR.Text = string.Format("{0}: {1}", BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CursBNR), BComportamentAplicatie.GetCursBNR());
        }

        private void setTitluEcran()
        {
            this.Text = string.Format("{0} - {1} {2}", BMultiLingv.getElementById(BMultiLingv.EnumDictionar.IstomaLTD), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.BineAtiVenit), BUtilizator.GetUtilizatorConectat().ToString());
        }

        #region Controale incarcate dinamic

        private void adaugaControlInZonaUtila(Control pControl)
        {
            this.panelContainer.Controls.Add(pControl);
            pControl.Dock = DockStyle.Fill;
        }

        private void initControlGestiunePersonal()
        {
            if (this.lctrlGestiunePersonal == null)
            {
                this.lctrlGestiunePersonal = new Setari.Personal.ControlListaUtilizatori();
                this.lctrlGestiunePersonal.Name = "ctrlGestiunePersonal";
                adaugaControlInZonaUtila(this.lctrlGestiunePersonal);
            }

            this.lctrlGestiunePersonal.Initializeaza();
            this.lctrlGestiunePersonal.Visible = true;
            this.lctrlGestiunePersonal.BringToFront();
        }

        private void initControlGestiuneClienti()
        {
            if (this.lctrlGestiuneClienti == null)
            {
                this.lctrlGestiuneClienti = new TablouDeBord.Clienti.ControlListaClienti();
                this.lctrlGestiuneClienti.Name = "ctrlGestiuneClienti";
                adaugaControlInZonaUtila(this.lctrlGestiuneClienti);
            }

            this.lctrlGestiuneClienti.Initializeaza();
            this.lctrlGestiuneClienti.Visible = true;
            this.lctrlGestiuneClienti.BringToFront();
        }

        private void initControlGestiuneRapoarte()
        {
            if (this.lctrlListaRapoarte == null)
            {
                this.lctrlListaRapoarte = new Rapoarte.ControlListaRapoarte();
                this.lctrlListaRapoarte.Name = "ctrlGestiuneRapoarte";
                adaugaControlInZonaUtila(this.lctrlListaRapoarte);
            }

            this.lctrlListaRapoarte.Initializeaza();
            this.lctrlListaRapoarte.Visible = true;
            this.lctrlListaRapoarte.BringToFront();
        }

        //private void initControlGestiuneComunicare()
        //{
        //    if (this.lctrlComunicare == null)
        //    {
        //        this.lctrlComunicare = new ControlComunicare();
        //        this.lctrlComunicare.Name = "ctrlGestiuneComunicare";
        //        adaugaControlInZonaUtila(this.lctrlComunicare);
        //    }

        //    this.lctrlComunicare.Initializeaza();
        //    this.lctrlComunicare.Visible = true;
        //    this.lctrlComunicare.BringToFront();
        //}

        private void initControlGestiuneListaDePreturi()
        {
            if (this.lctrlGestiuneListaDePreturi == null)
            {
                this.lctrlGestiuneListaDePreturi = new Setari.Lucrari.ControlGestiuneListaDePreturi();
                this.lctrlGestiuneListaDePreturi.Name = "ctrlGestiuneListaDePreturi";
                adaugaControlInZonaUtila(this.lctrlGestiuneListaDePreturi);
            }

            this.lctrlGestiuneListaDePreturi.Initializeaza();
            this.lctrlGestiuneListaDePreturi.Visible = true;
            this.lctrlGestiuneListaDePreturi.BringToFront();
        }

        private void initControlGestiuneLocatii()
        {
            if (this.lctrlGestiuneLocatii == null)
            {
                this.lctrlGestiuneLocatii = new Setari.Locatii.ControlListaLocatii();
                this.lctrlGestiuneLocatii.Name = "ctrlGestiuneLocatii";
                adaugaControlInZonaUtila(this.lctrlGestiuneLocatii);
            }

            this.lctrlGestiuneLocatii.Initializeaza();
            this.lctrlGestiuneLocatii.Visible = true;
            this.lctrlGestiuneLocatii.BringToFront();
        }

        private void initControlGestiuneDiverse()
        {
            if (this.lctrlGestiuneDiverse == null)
            {
                this.lctrlGestiuneDiverse = new Setari.Liste.ControlGestiuneListe();
                this.lctrlGestiuneDiverse.Name = "ctrlGestiuneDiverse";
                adaugaControlInZonaUtila(this.lctrlGestiuneDiverse);
            }

            this.lctrlGestiuneDiverse.Initializeaza();
            this.lctrlGestiuneDiverse.Visible = true;
            this.lctrlGestiuneDiverse.BringToFront();
        }

        private void initControlTablouDeBord()
        {
            if (this.lctrlTablouDeBord == null)
            {
                this.lctrlTablouDeBord = new TablouDeBord.ControlTablouDeBord();
                this.lctrlTablouDeBord.Name = "ctrlTablouDeBord";
                adaugaControlInZonaUtila(this.lctrlTablouDeBord);
            }

            this.lctrlTablouDeBord.Initializeaza();
            this.lctrlTablouDeBord.Visible = true;
            this.lctrlTablouDeBord.BringToFront();
        }

        private void initControlFacturare()
        {
            if (this.lctrlFacturare == null)
            {
                this.lctrlFacturare = new TablouDeBord.Facturare.ControlGestiuneFacturare();
                this.lctrlFacturare.Name = "ctrlFacturare";
                adaugaControlInZonaUtila(this.lctrlFacturare);
            }

            this.lctrlFacturare.Initializeaza();
            this.lctrlFacturare.Visible = true;
            this.lctrlFacturare.BringToFront();
        }

        private void initControlSetariComportament()
        {
            if (this.lctrlComportament == null)
            {
                this.lctrlComportament = new Setari.Comportament.ControlListaComportament();
                this.lctrlComportament.Name = "ctrlComportament";
                adaugaControlInZonaUtila(this.lctrlComportament);
            }

            this.lctrlComportament.Initializeaza();
            this.lctrlComportament.Visible = true;
            this.lctrlComportament.BringToFront();
        }

        private void initControlMarketingProspecti()
        {
            if (this.lctrlMarketingProspecti == null)
            {
                this.lctrlMarketingProspecti = new Marketing.ControlMarketingProspecti();
                this.lctrlMarketingProspecti.Name = "ctrlMarketingProspecti";
                adaugaControlInZonaUtila(this.lctrlMarketingProspecti);
            }

            this.lctrlMarketingProspecti.Initializeaza();
            this.lctrlMarketingProspecti.Visible = true;
            this.lctrlMarketingProspecti.BringToFront();
        }

        private void initControlMarketingTrimitereSMS()
        {
            if (this.lctrlMarketingTrimitereSMS == null)
            {
                this.lctrlMarketingTrimitereSMS = new Marketing.ControlMarketingTrimitereSMS();
                this.lctrlMarketingTrimitereSMS.Name = "ctrlMarketingTrimitereSMS";
                adaugaControlInZonaUtila(this.lctrlMarketingTrimitereSMS);
            }

            this.lctrlMarketingTrimitereSMS.Initializeaza();
            this.lctrlMarketingTrimitereSMS.Visible = true;
            this.lctrlMarketingTrimitereSMS.BringToFront();
        }

        private void initControlMarketingTrimitereEmail()
        {
            if (this.lctrlMarketingTrimitereEmail == null)
            {
                this.lctrlMarketingTrimitereEmail = new Marketing.ControlMarketingTrimitereEmail();
                this.lctrlMarketingTrimitereEmail.Name = "ctrlMarketingTrimitereEmail";
                adaugaControlInZonaUtila(this.lctrlMarketingTrimitereEmail);
            }

            this.lctrlMarketingTrimitereEmail.Initializeaza();
            this.lctrlMarketingTrimitereEmail.Visible = true;
            this.lctrlMarketingTrimitereEmail.BringToFront();
        }

        private void initControlGestiuneFurnizori()
        {
            if (this.lctrlGestiuneFurnizori == null)
            {
                this.lctrlGestiuneFurnizori = new Gestiune.ControlGestiuneFurnizori();
                this.lctrlGestiuneFurnizori.Name = "ctrlGestiuneFurnizori";
                adaugaControlInZonaUtila(this.lctrlGestiuneFurnizori);
            }

            this.lctrlGestiuneFurnizori.Initializeaza();
            this.lctrlGestiuneFurnizori.Visible = true;
            this.lctrlGestiuneFurnizori.BringToFront();
        }

        private void initControlGestiuneStocuri()
        {
            if (this.lctrlGestiuneStocuri == null)
            {
                this.lctrlGestiuneStocuri = new Gestiune.ControlGestiuneStocuri();
                this.lctrlGestiuneStocuri.Name = "ctrlGestiuneStocuri";
                adaugaControlInZonaUtila(this.lctrlGestiuneStocuri);
            }

            this.lctrlGestiuneStocuri.Initializeaza();
            this.lctrlGestiuneStocuri.Visible = true;
            this.lctrlGestiuneStocuri.BringToFront();
        }

        private void initControlGestiunePlati()
        {
            if (this.lctrlGestiunePlati == null)
            {
                this.lctrlGestiunePlati = new Gestiune.ControlGestiunePlati();
                this.lctrlGestiunePlati.Name = "ctrlGestiunePlati";
                adaugaControlInZonaUtila(this.lctrlGestiunePlati);
            }

            this.lctrlGestiunePlati.Initializeaza();
            this.lctrlGestiunePlati.Visible = true;
            this.lctrlGestiunePlati.BringToFront();
        }

        private void initControlConcedii()
        {
            if (this.lctrlConcedii == null)
            {
                this.lctrlConcedii = new ResurseUmane.ControlConcedii();
                this.lctrlConcedii.Name = "ctrlConcedii";
                adaugaControlInZonaUtila(this.lctrlConcedii);
            }

            this.lctrlConcedii.Initializeaza();
            this.lctrlConcedii.Visible = true;
            this.lctrlConcedii.BringToFront();
        }

        private void initControlPiataStomatologica()
        {
            if (this.lctrlPiataStomatologica == null)
            {
                this.lctrlPiataStomatologica = new ResurseUmane.ControlPiataStomatologica();
                this.lctrlPiataStomatologica.Name = "ctrlPiataStomatologica";
                adaugaControlInZonaUtila(this.lctrlPiataStomatologica);
            }

            this.lctrlPiataStomatologica.Initializeaza();
            this.lctrlPiataStomatologica.Visible = true;
            this.lctrlPiataStomatologica.BringToFront();
        }

        private void initControlPontaj()
        {
            if (this.lctrlPontaj == null)
            {
                this.lctrlPontaj = new ResurseUmane.ControlPontaj();
                this.lctrlPontaj.Name = "ctrlPontaj";
                adaugaControlInZonaUtila(this.lctrlPontaj);
            }

            this.lctrlPontaj.Initializeaza();
            this.lctrlPontaj.Visible = true;
            this.lctrlPontaj.BringToFront();
        }

        private void initControlVenituri()
        {
            if (this.lctrlVenituri == null)
            {
                this.lctrlVenituri = new ResurseUmane.ControlVenituri();
                this.lctrlVenituri.Name = "ctrlVenituri";
                adaugaControlInZonaUtila(this.lctrlVenituri);
            }

            this.lctrlVenituri.Initializeaza();
            this.lctrlVenituri.Visible = true;
            this.lctrlVenituri.BringToFront();
        }


        #endregion

        private void incarcaOptiuneaSelectata(EnumOptiune pOptiune)
        {
            this.lOptiuneSelectata = pOptiune;

            this.panelContainer.AscundeControaleleIncarcate();
            
            switch (pOptiune)
            {
                case EnumOptiune.SetariPersonal:
                    initControlGestiunePersonal();
                    break;
                case EnumOptiune.Clienti:
                    initControlGestiuneClienti();
                    break;
                case EnumOptiune.SetariListaPreturi:
                    initControlGestiuneListaDePreturi();
                    break;
                case EnumOptiune.SetariLocatii:
                    initControlGestiuneLocatii();
                    break;
                case EnumOptiune.SetariDiverse:
                    initControlGestiuneDiverse();
                    break;
                case EnumOptiune.Rapoarte:
                    initControlGestiuneRapoarte();
                    break;
                case EnumOptiune.TablouDeBord:
                    initControlTablouDeBord();
                    break;
                case EnumOptiune.Facturare:
                    initControlFacturare();
                    break;
                case EnumOptiune.MarketingTrimitereEmail:
                    initControlMarketingTrimitereEmail();
                    break;
                case EnumOptiune.MarketingTrimitereSMS:
                    initControlMarketingTrimitereSMS();
                    break;
                case EnumOptiune.MarketingProspecti:
                    initControlMarketingProspecti();
                    break;
                case EnumOptiune.SetariComportament:
                    initControlSetariComportament();
                    break;
                case EnumOptiune.GestiuneFurnizori:
                    initControlGestiuneFurnizori();
                    break;
                case EnumOptiune.GestiuneStocuri:
                    initControlGestiuneStocuri();
                    break;
                case EnumOptiune.GestiunePlati:
                    initControlGestiunePlati();
                    break;
                case EnumOptiune.ResurseUmaneConcedii:
                    initControlConcedii();
                    break;
                case EnumOptiune.ResurseUmanePiataStomatologica:
                    initControlPiataStomatologica();
                    break;
                case EnumOptiune.ResurseUmanePontaj:
                    initControlPontaj();
                    break;
                case EnumOptiune.ResurseUmaneVenituri:
                    initControlVenituri();
                    break;
            }
        }


        private void incepeIncarcarea()
        {
            this.lSeIncarca = true;
        }

        private void finalizeazaIncarcarea()
        {
            this.lSeIncarca = false;
        }

        private void schimbaOptiuneaActiva(ButonOptiuneMeniuStanga pSender)
        {
            EnumOptiune optiune = pSender.Optiune;

            foreach (Control panelRubrica in this.flpMeniuStanga.Controls)
            {
                if (panelRubrica is PanelOptiuniMeniuStanga)
                {
                    foreach (var butonOptiuni in panelRubrica.Controls)
                    {
                        if (butonOptiuni is ButonOptiuneMeniuStanga)
                        {
                            (butonOptiuni as ButonOptiuneMeniuStanga).SchimbaSelectia(butonOptiuni == pSender);
                        }
                    }
                }
            }

            incarcaOptiuneaSelectata(optiune);
        }

        private void setUltimulUtilizatorConectat()
        {
            BUtilizator user = BUtilizator.GetUtilizatorConectat();
            CCL.iStomaLab.Utile.CGestiuneIO.setUltimulUtilizatorConectat(user.ContStoma);
        }

        private void schimbaDeschidereaRubricilor(ButonRubricaMeniuStanga pSender)
        {
            EnumRubrica rubricaNoua = pSender.Rubrica;
            foreach (Control btnRubrica in this.flpMeniuStanga.Controls)
            {
                if (btnRubrica is ButonRubricaMeniuStanga)
                {
                    if (btnRubrica == pSender)
                    {
                        (btnRubrica as ButonRubricaMeniuStanga).SchimbaDeschiderea(pSender.Deschis);
                    }
                    else
                    {
                        (btnRubrica as ButonRubricaMeniuStanga).SchimbaDeschiderea(false);
                    }
                }
            }
            this.lRubricaSelectata = rubricaNoua;

            //Deschidem prima optiune din aceasta rubrica
            schimbaOptiuneaActiva(getPrimaOptiuneDinRubrica());
        }

        private ButonOptiuneMeniuStanga getPrimaOptiuneDinRubrica()
        {
            return getButonOptiune(this.lListaOptiuni.GetPrimaByRubrica(this.lRubricaSelectata));
            //switch (this.lRubricaSelectata)
            //{
            //    case EnumRubrica.TablouDeBord:
            //        return this.mnuStOptTablouDeBord;
            //    case EnumRubrica.Rapoarte:
            //        return this.mnuStOptRapoarte;
            //    case EnumRubrica.Setari:
            //        return this.mnuStOptSetariListaDePreturi;
            //    case EnumRubrica.Marketing:
            //        return this.mnuStOptProspecti;
            //    case EnumRubrica.Gestiune:
            //        return this.mnuStOptGestiuneFurnizori;
            //}

            //return this.mnuStOptTablouDeBord;
        }

        private ButonOptiuneMeniuStanga getButonOptiune(EnumOptiune pOptiune)
        {
            ButonOptiuneMeniuStanga optTemp = null;
            foreach (Control item in this.flpMeniuStanga.Controls)
            {
                if (item is PanelOptiuniMeniuStanga)
                {
                    foreach (var opt in item.Controls)
                    {
                        if (opt is ButonOptiuneMeniuStanga)
                        {
                            optTemp = (opt as ButonOptiuneMeniuStanga);
                            if (optTemp.Optiune == pOptiune)
                                return optTemp;
                        }
                    }
                }
            }

            return null;
        }

        #endregion

        #region Metode publice

        private const string _SOFT_REG = @"SOFTWARE\iStomaLTD";

        public bool InchideAplicatia { get { return this.lInchideAplicatia; } }

        internal static void updateLicenta(string pLicenta)
        {
            RegistryKey cheie = Registry.CurrentUser.CreateSubKey(@_SOFT_REG);
            cheie.SetValue("LICENTA", pLicenta);

            CSecuritate.Marcheaza(Properties.Resources.idv);
        }

        public int CereFunctionalitate(int pIdEcran, string pLocalizare, string pDescriere, int pTip)
        {
            if (!CGestiuneIO.ExistaConexiuneInternet())
            {
                // "Nu există conexiune la internet"
                Mesaj.Eroare(this, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NuExistaConexiuneLaInternet), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Eroare));
                return -1;
            }

            int id = 0;
            try
            {
                BUtilizator clientIStoma = BUtilizator.GetUtilizatorISTOMA(null);
                if (clientIStoma != null)
                {
                    iFunctionalitati.FunctionalitatiSoapClient servCerere = new iFunctionalitati.FunctionalitatiSoapClient();
                    id = servCerere.CereFunctionalitate(clientIStoma.ContStoma, clientIStoma.ParolaStoma, getCheieLicenta(), pIdEcran, pLocalizare, pDescriere, pTip);
                    servCerere.Close();
                }
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }

            if (id <= 0)
                Mesaj.Eroare(this, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ContactatiUnReprezentantIdavaSolutions),
                             BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Eroare));

            return id;
        }

        public void Notifica(string pText, string pTitlu, string pContinut, bool pEroare)
        {
            Notifica(EnumTipNotificare.Mesaj, pText, pTitlu, pContinut, pEroare);
        }

        public void Notifica(EnumTipNotificare pTipNotificare, string pText, string pTitlu, string pContinut, bool pEroare)
        {
            pContinut = System.Text.RegularExpressions.Regex.Replace(pContinut, @"<[^>]*>", String.Empty);

            if (pTipNotificare == EnumTipNotificare.PacientSosit)
            {
                string temp = pTitlu;
                pTitlu = pContinut;
                pContinut = temp;
            }

            if (CUtil.isNotNull(pContinut) && pContinut.Length > 64)
                pContinut = string.Concat(pContinut.Substring(0, 60), "...");

            if (CUtil.isNotNull(pText) && pText.Length > 64)
                pText = string.Concat(pText.Substring(0, 60), "...");

            if (CUtil.isNotNull(pTitlu) && pTitlu.Length > 64)
                pText = string.Concat(pTitlu.Substring(0, 60), "...");

            this.niNotificariUtilizator.Visible = true;
            this.niNotificariUtilizator.Text = pText;
            this.niNotificariUtilizator.ShowBalloonTip(10000, pTitlu, pContinut, (pEroare ? ToolTipIcon.Error : ToolTipIcon.Info));
        }

        public void AscundeIconitaNotificare()
        {
            this.niNotificariUtilizator.Visible = false;
        }

        public bool SchimbaParolaISTOMA(int pIdUser)
        {
            try
            {
                //care este noua parola?
                using (CCL.UI.FormulareComune.frmInputBox parola = new frmInputBox(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NouaParola), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Parola), string.Empty, 20, true, false, true))
                {
                    if (CCL.UI.IHMUtile.DeschideEcran(this, parola))
                    {
                        if (parola.TextIntrodus.Length < 2)
                        {
                            // "Parola trebuie să conțină minim 6 caractere"
                            Mesaj.Eroare(this, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ParolaTrebuieSaContinaMinimSaseCaractere), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Parola));
                        }
                        else
                        {
                            BUtilizator userIST = BUtilizator.GetById(pIdUser, null);

                            int idUserConectat = BUtilizator.GetUtilizatorConectat().Id;

                            if (userIST.EsteADMIN())
                            {
                                //Pentru utilizatorul sistem trebuie sa actualizam si parola de pe server
                                iStoma.VerificareSoapClient verif = new iStoma.VerificareSoapClient();
                                if (verif.Actualizeaza(userIST.ContStoma, userIST.ParolaStoma, getCheieLicenta(), CSecuritate.GetMd5Hash(parola.TextIntrodus)))
                                {
                                    userIST.SchimbaParola(CSecuritate.GetMd5Hash(parola.TextIntrodus));

                                    if (userIST.Id != idUserConectat)
                                        return true;
                                }
                                else
                                    Mesaj.Eroare(this, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ContactatiUnReprezentantIdavaSolutions),
                                        BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Eroare));
                                verif.Close();
                            }
                            else
                            {
                                userIST.SchimbaParola(CSecuritate.GetMd5Hash(parola.TextIntrodus));
                                if (userIST.Id != idUserConectat)
                                    return true;
                            }

                            if (userIST.Id == idUserConectat)
                                Deconecteaza();
                        }
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region Gestiune Coloane DGV

        public void SeteazaColoanaSortare(string pNumeLista, string pNumeColoana, int pOrdineSortare)
        {
            try
            {
                BLL.iStomaLab.Comune.BListeAfisaj.UpdateColoanaSortare(pNumeLista, pNumeColoana, pOrdineSortare, null);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this, ex);
            }
        }

        public void SeteazaIndexColoana(string pNumeLista, string pNumeColoana, int pDisplayIndex)
        {
            try
            {
                BLL.iStomaLab.Comune.BColoaneListeAfisaj.UpdateIndexColoana(pNumeLista, pNumeColoana, pDisplayIndex, null);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this, ex);
            }
        }

        public void SeteazaLatimeColoana(string pNumeLista, string pNumeColoana, int pLatime)
        {
            try
            {
                BLL.iStomaLab.Comune.BColoaneListeAfisaj.UpdateLatimeColoana(pNumeLista, pNumeColoana, pLatime, null);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this, ex);
            }
        }

        public Tuple<string, int, int> GetColoanaSortare(string pNumeLista)
        {
            try
            {
                BLL.iStomaLab.Comune.BListeAfisaj coloanaSortare = BLL.iStomaLab.Comune.BListeAfisaj.GetListaByNume(pNumeLista, null);

                if (coloanaSortare != null)
                    return new Tuple<string, int, int>(coloanaSortare.ColoanaSortare, coloanaSortare.OrdineSortare, coloanaSortare.Id);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this, ex);
            }

            return null;
        }

        public List<string> GetListaColoaneAscunde(string pNumeLista)
        {
            return BLL.iStomaLab.Comune.BColoaneListeAfisaj.GetListaColoaneAscunse(pNumeLista, null);
        }

        public Dictionary<string, int> GetOrdineAfisareColoane(string pNumeLista)
        {
            return BLL.iStomaLab.Comune.BColoaneListeAfisaj.GetOrdineAfisareColoane(pNumeLista, null);
        }

        public Dictionary<string, int> GetLatimeColoane(string pNumeLista)
        {
            return BLL.iStomaLab.Comune.BColoaneListeAfisaj.GetLatimeColoane(pNumeLista, null);
        }

        #endregion

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
        }

        #endregion

    }
}

