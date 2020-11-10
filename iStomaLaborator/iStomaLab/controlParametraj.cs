using BLL.iStomaLab;
using BLL.iStomaLab.Comune;
using BLL.iStomaLab.Locatii;
using BLL.iStomaLab.Referinta;
using BLL.iStomaLab.Utilizatori;
using CCL.iStomaLab;
using CCL.iStomaLab.Utile;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iStomaLab
{
    public partial class controlParametraj : CCL.UI.FormulareComune.frmSimplu
    {

        #region Declaratii generale

        private int lEtapa = 0;
        private int lNumarIncercari = 0;

        private string lActivare = "33";
        private string lExceptie = string.Empty;

        CCL.iStomaLab.Utile.ServerSQL lServerAles = null;
        string lNumeServer = string.Empty;
        string lNumeInstanta = string.Empty;
        string lNumeUser = string.Empty;
        string lParolaSQL = string.Empty;
        string lNumeBDD = string.Empty;

        string lCodClient = string.Empty;
        string lParolaISTOMA = string.Empty;
        string lLicenta = string.Empty;

        List<string> lListaBDD = null;

        private string lCaleFolderDocumente = string.Empty;

        #endregion

        #region Enum si Struct

        private enum EnumScripturi
        {
            CreareBDD = 0,
            RecuperareInformatii = 1,
            Tabele = 2,
            View = 3,
            PS = 4,
            Tari = 5,
            Regiuni = 6,
            Localitati = 7,
            CP = 8,
            COR = 9,
            CAEN = 10,
            SMTP = 11,
            Drepturi = 12,
            Meniu = 13,
            Citate = 14,
            MultiLingv = 15,
            Afectiuni = 16,
            OrganeArtificiale = 17,
            ProduseGestiune = 18,
            Interventii = 19,
            TratamenteAdministrative = 20,
            EvenimenteCalendaristice = 21
        }

        #endregion

        #region Constructori

        public controlParametraj()
        {
            InitializeComponent();

            this.ShowIcon = true;
            this.ShowInTaskbar = true;
            this.txtServerManual.ReadOnly = false;
            this.txtServerManual.Enabled = true;

            this.lEtapa = 0;

            this.Icon = CCL.UI.Imagini.GetIconAplicatie();
            this.picLogo.Image = CCL.UI.Imagini.GetLogoAplicatie();

            this.btnAdaugaBDD.Text = string.Concat("Creează BDD ", CConstante._DENUMIRE_APLICATIE);

            this.Shown += ControlParametraj_Shown;
        }

        private void ControlParametraj_Shown(object sender, EventArgs e)
        {
            this.txtCodClient.Focus();
        }

        private void frmActivare_Load(object sender, EventArgs e)
        {
            try
            {
                afiseazaEtapa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Evenimente

        private void chkServerulEstePeAcestCalculator_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.lblUserSQL.Visible = !this.chkServerulEstePeAcestCalculator.Checked;
                this.txtUserSQL.Visible = !this.chkServerulEstePeAcestCalculator.Checked;
                this.lblParolaSQL.Visible = !this.chkServerulEstePeAcestCalculator.Checked;
                this.txtParolaSQL.Visible = !this.chkServerulEstePeAcestCalculator.Checked;

                if (this.chkServerulEstePeAcestCalculator.Checked)
                {
                    this.txtServerManual.Text = "localhost";
                    incarcaVariabileBDD();
                    incarcaListaBDD();
                }
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        private void btnAlegeFolder_Click(object sender, EventArgs e)
        {
            try
            {
                if (CCL.UI.IHMUtile.DeschideEcran(CCL.UI.IHMUtile.GetFormParinte(this), this.fbdAlegeFolder))
                    this.txtCaleSalvareDocumente.Text = this.fbdAlegeFolder.SelectedPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkTsC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CCL.UI.IHMUtile.PornesteProces("http://licente.istoma.ro/TermeniSiConditii.aspx");
        }

        [STAThread]
        private void btnActivare_Click(object sender, EventArgs e)
        {
            try
            {

                if (CGestiuneIO.ExistaConexiuneInternet())
                {
                    bool lanseazaBW = false;

                    if (this.lEtapa == 0)
                    {
                        this.lCodClient = this.txtCodClient.Text.Trim();
                        this.lParolaISTOMA = this.txtParola.Text.Trim();
                        this.lLicenta = this.txtLicenta.Text.Trim();

                        if (string.IsNullOrEmpty(this.lCodClient) ||
                            string.IsNullOrEmpty(this.lParolaISTOMA) ||
                            string.IsNullOrEmpty(this.lLicenta) ||
                            this.lCodClient.Length < 7 ||
                            this.lParolaISTOMA.Length < 6 ||
                            this.lLicenta.Length < 24)
                        {
                            //"Detalii licență"
                            MessageBox.Show("Va rugam sa introduceti datele licentei", "Licenta iStoma LTD", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            if (string.IsNullOrEmpty(this.txtCodClient.Text))
                                this.txtCodClient.Focus();
                            else
                            {
                                if (string.IsNullOrEmpty(this.txtParola.Text))
                                    this.txtParola.Focus();
                                else
                                {
                                    if (string.IsNullOrEmpty(this.txtLicenta.Text))
                                        this.txtLicenta.Focus();
                                }
                            }

                            return;
                        }
                        else
                        {
                            if (!this.chkAcceptaTermeniiSiConditiile.Checked)
                            {
                                //"Termeni și condiții"
                                //"Pentru activarea iStoma este necesara citirea și acceptarea termenilor și condițiilor"
                                MessageBox.Show("Pentru activarea licentei va rugam sa cititi si sa acceptati termenii si conditiile",
                                    "Termeni si conditii", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                return;
                            }
                            else
                            {
                                lanseazaBW = true;
                            }
                        }
                    }
                    else
                        if (this.lEtapa == 1)
                    {
                        incarcaVariabileBDD();

                        lanseazaBW = verificaConexiunea();

                        if (lanseazaBW && this.cboBDD.SelectedItem == null)
                        {
                            lanseazaBW = false;
                            //"Baza de date"
                            //"Selectați o bază de date"
                            MessageBox.Show("Selectati o baza de date", "Baza de date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.cboBDD.DroppedDown = true;

                            return;
                        }
                    }
                    else
                    {
                        //"Configurare directoare"
                        this.lblEtapa.Text = "Configurare directoare";
                        incarcaVariabileDocumente();
                        lanseazaBW = verificaFolderDocumente();
                    }

                    if (lanseazaBW)
                    {
                        zoneActive(false);
                        this.bwVerifica.RunWorkerAsync();
                    }
                    else
                    {
                        //Pentru a fece prima verificare a utilizatorului
                        IHMUtile.verificaCalculatorul();
                    }
                }
                else
                {
                    //"Nu există conexiune la internet"
                    //"Activarea iStoma se poate face doar online"
                    MessageBox.Show("Activarea iStoma se poate face doar online", "Nu exista conexiune la internet", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnulare_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
            Application.Exit();
        }

        private void picLogo_Click(object sender, EventArgs e)
        {
            CCL.UI.IHMUtile.PornesteProces("http://www.istoma.ro");
        }

        private void picProdus_Click(object sender, EventArgs e)
        {
            CCL.UI.IHMUtile.PornesteProces("http://istoma.ro/Contact-iDava-Solutions.aspx");
        }

        private void seteazaFoldereleDeDocumente()
        {
            if (!string.IsNullOrEmpty(this.lCaleFolderDocumente))
            {
                //Directorul temporar de afla in acelasi folder cu documentele
                CGestiuneIO.seteazaFolderDocumente(this.lCaleFolderDocumente);

                try
                {
                    //Adaugam logo pentru sediu
                    string folderAplicatie = CUtil.GetLocatieAplicatie();
                    folderAplicatie += "\\LogoIStoma.png";

                    //if (System.IO.File.Exists(folderAplicatie))
                    //{
                    //    BLocatii sediu = BLocatii.GetById(3, null);
                    //    sediu.SeteazaLogo(folderAplicatie);
                    //}
                }
                catch (Exception)
                {
                    //Nu e nicio pb daca nu putem adauga logo
                }
            }
        }

        private void seteazaConexiuneBDD()
        {
            if (!string.IsNullOrEmpty(this.lNumeServer) &&
               (this.chkServerulEstePeAcestCalculator.Checked || !string.IsNullOrEmpty(this.lNumeUser) && !string.IsNullOrEmpty(this.lParolaSQL)))
            {
                //recuperam lista de BDD
                CGestiuneIO.seteazaConexiuneBDD(this.lNumeServer, this.lNumeInstanta, this.lNumeUser, this.lParolaSQL, this.chkServerulEstePeAcestCalculator.Checked, this.lNumeBDD);
            }
        }

        private void cboListaServere_SelectedIndexChanged(object sender, EventArgs e)
        {
            //setam numele instantei
            ServerSQL serverAles = this.cboListaServere.SelectedItem as ServerSQL;
            this.txtServerManual.Text = serverAles.ServerName;
            if (!string.IsNullOrEmpty(serverAles.InstanceName))
            {
                this.txtNumeInstantaSQL.Text = serverAles.InstanceName;
            }
            else
            {
                this.txtNumeInstantaSQL.Text = "SQLEXPRESS";
            }
            incarcaListaBDD();
        }

        private void btnAdaugaBDD_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificaConexiunea())
                {
                    incarcaVariabileBDD();
                    incarcaVariabileISTOMA();

                    this.lNumeBDD = string.Empty;

                    //Numele bazei de date
                    CCL.UI.FormulareComune.frmInputBox frmNumeBaza = new CCL.UI.FormulareComune.frmInputBox(CCL.UI.FormulareComune.frmInputBox.EnumTipInput.TextSimplu,
                        CConstante._DENUMIRE_APLICATIE, "Numele bazei de date", "Baza de date", 20, CCL.UI.CEnumerariComune.EnumTipDeschidere.DreaptaSus, -1);
                    if (CCL.UI.IHMUtile.DeschideEcran(this, frmNumeBaza))
                        this.lNumeBDD = frmNumeBaza.TextIntrodus;

                    if (!string.IsNullOrEmpty(this.lNumeBDD))
                    {
                        zoneActive(false);
                        this.pbAvans.Value = 0;
                        bwBDD.RunWorkerAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(CUtil.GetTextCompletExceptie(ex), "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtServerManual_Validated(object sender, EventArgs e)
        {
            incarcaListaBDD();
        }

        private void txtNumeInstantaSQL_Validated(object sender, EventArgs e)
        {
            incarcaListaBDD();
        }

        private void txtUserSQL_Validated(object sender, EventArgs e)
        {
            incarcaListaBDD();
        }

        private void txtParolaSQL_Validated(object sender, EventArgs e)
        {
            incarcaListaBDD();
        }

        [STAThread]
        private void bwVerifica_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.pbAvans.Value = e.ProgressPercentage;
        }

        [STAThread]
        private void bwVerifica_DoWork(object sender, DoWorkEventArgs e)
        {
            this.lActivare = "33";
            this.lExceptie = string.Empty;
            //Tuple<string, string> mesajEroare = null;
            try
            {
                //Verificam licenta
                if (this.lEtapa == 0)
                {
                    this.bwVerifica.ReportProgress(30);
                    this.bwVerifica.ReportProgress(60);
                    iStoma.VerificareSoapClient verif = new iStoma.VerificareSoapClient();
                    this.lActivare = verif.VerificaLicenta(this.txtCodClient.Text.Trim(), CSecuritate.GetMd5Hash(this.txtParola.Text.Trim()), this.txtLicenta.Text.Trim(), BMasina.getDenumireMasina(), BMasina.getIdMasina());
                    this.bwVerifica.ReportProgress(90);

                    //incarcam lista de servere pt etapa 2 pentru a nu bloca ecranul
                    this.lListaServereSQL = ServerSQL.GetListaServereSQL();
                }
                else
                    if (this.lEtapa == 1)
                {
                    //Incarcam conexiunea la BDD
                    seteazaConexiuneBDD();
                    this.lActivare = "13";
                }
                else
                {
                    //Incarcam conexiunea la BDD
                    seteazaFoldereleDeDocumente();

                    this.lActivare = "13";
                }
            }
            catch (Exception ex)
            {
                this.lExceptie = string.Concat("err: ", CUtil.GetTextCompletExceptie(ex));
            }
        }

        [STAThread]
        private void bwVerifica_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (this.lEtapa == 0)
                {
                    //Activeaza licenta
                    if (this.lActivare.Equals("66"))
                    {
                        //Userul nu exista
                        //"Informațiile furnizate nu sunt valide!"
                        MessageBox.Show("Informatiile introduse nu sunt valide", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        this.lNumarIncercari++;

                        if (this.lNumarIncercari > 3)
                            this.lEtapa = 13; //fortam inchiderea ecranului 
                    }
                    else
                    {
                        if (this.lActivare.Equals("33"))
                        {
                            //Eroare tehnica
                            MessageBox.Show("Contactati un reprezentant IDAVA SOLUTIONS", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            //Totul este ok => scriem in registri si trecem la BDD
                            EcranPrincipal.updateLicenta(this.txtLicenta.Text.Trim());

                            this.lEtapa = 1;
                        }
                    }
                }
                else
                {
                    if (this.lEtapa == 1)
                        this.lEtapa = 2;
                    else
                        this.lEtapa = 3;
                }

                if (this.lEtapa <= 2)
                    afiseazaEtapa();

                if (this.lEtapa > 2)
                {
                    if (this.lActivare.Equals("13"))
                    {
                        iStoma.VerificareSoapClient verif = new iStoma.VerificareSoapClient();

                        verif.ActualizeazaInformatiiConexiune(this.lCodClient, CSecuritate.GetMd5Hash(this.lParolaISTOMA), this.lLicenta, BMasina.getIdMasina(), this.lNumeServer, this.lNumeInstanta, this.lNumeUser, this.lNumeBDD, this.lCaleFolderDocumente);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                        this.Close();
                    }
                }

                if (!string.IsNullOrEmpty(lExceptie))
                {
                    //Avem exceptie
                    MessageBox.Show(lExceptie, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    zoneActive(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                zoneActive(true);
            }
        }

        [STAThread]
        void bwBDD_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            try
            {
                //pacient, nr total pacienti, indexul pacientului
                EnumScripturi infoProgres = (EnumScripturi)Convert.ToInt32(e.UserState);
                string textProgres = string.Empty;
                int procentProgres = e.ProgressPercentage;

                switch (infoProgres)
                {
                    case EnumScripturi.CreareBDD:
                        textProgres = string.Concat("Baza de date", " ... 4");//"Creare bază de date";
                        break;
                    case EnumScripturi.RecuperareInformatii:
                        textProgres = string.Concat("Baza de date", " ... 3");//"Recuperare informații";
                        break;
                    case EnumScripturi.Tabele:
                        textProgres = string.Concat("Baza de date", " ... 2");//"Creare tabele";
                        break;
                    case EnumScripturi.View:
                        textProgres = string.Concat("Baza de date", " ... 1");//"Creare view-uri";
                        break;
                    case EnumScripturi.PS:
                        textProgres = string.Concat("Baza de date", " ... 0");//"Creare proceduri stocate";
                        break;
                    case EnumScripturi.Tari:
                        textProgres = string.Concat("Încărcare date de referință", "... 17");//"Încărcare date de referință - Țări";
                        break;
                    case EnumScripturi.Regiuni:
                        textProgres = string.Concat("Încărcare date de referință", " ... 16");//"Încărcare date de referință - Regiuni";
                        break;
                    case EnumScripturi.Localitati:
                        textProgres = string.Concat("Încărcare date de referință", " ... 15");//"Încărcare date de referință - Localități";
                        break;
                    case EnumScripturi.CP:
                        textProgres = string.Concat("Încărcare date de referință", " ... 14");//"Încărcare date de referință - Coduri Poștale";
                        break;
                    case EnumScripturi.COR:
                        textProgres = string.Concat("Încărcare date de referință", " ... 13");//"Încărcare date de referință - Coduri COR";
                        break;
                    case EnumScripturi.CAEN:
                        textProgres = string.Concat("Încărcare date de referință", " ... 12");//"Încărcare date de referință - Coduri CAEN";
                        break;
                    case EnumScripturi.SMTP:
                        textProgres = string.Concat("Încărcare date de referință", " ... 11");//"Încărcare date de referință - SMTP";
                        break;
                    case EnumScripturi.EvenimenteCalendaristice:
                        textProgres = string.Concat("Încărcare date de referință", " ... 10");//"Încărcare date de referință - Calendar";
                        break;
                    case EnumScripturi.Drepturi:
                        textProgres = string.Concat("Încărcare date de referință", " ... 9");//"Încărcare date de referință - Drepturi";
                        break;
                    case EnumScripturi.Meniu:
                        textProgres = string.Concat("Încărcare date de referință", " ... 8");//"Încărcare date de referință - Meniu";
                        break;
                    case EnumScripturi.Citate:
                        textProgres = string.Concat("Încărcare date de referință", " ... 7");//"Încărcare date de referință - Citate celebre";
                        break;
                    case EnumScripturi.MultiLingv:
                        textProgres = string.Concat("Încărcare date de referință", " ... 6");//"Încărcare date de referință - Multilingv";
                        break;
                    case EnumScripturi.Afectiuni:
                        textProgres = string.Concat("Încărcare date de referință", " ... 5");//"Încărcare date de referință - Afecțiuni";
                        break;
                    case EnumScripturi.OrganeArtificiale:
                        textProgres = string.Concat("Încărcare date de referință", " ... 4");//"Încărcare date de referință - Lucrări protetice";
                        break;
                    case EnumScripturi.ProduseGestiune:
                        textProgres = string.Concat("Încărcare date de referință", " ... 3");//"Încărcare date de referință - Produse medicale";
                        break;
                    case EnumScripturi.Interventii:
                        textProgres = string.Concat("Încărcare date de referință", " ... 2");//"Încărcare date de referință - Intervenții";
                        break;
                    case EnumScripturi.TratamenteAdministrative:
                        textProgres = string.Concat("Încărcare date de referință", " ... 1");//"Încărcare date de referință - Tratamente administrative";
                        break;
                }

                this.lblEtapa.Text = textProgres;
                this.pbAvans.Value = procentProgres;
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        [STAThread]
        private void bwBDD_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.bwBDD.ReportProgress(1, (int)EnumScripturi.CreareBDD);

                //Recuperam informatiile de pe iStoma doar daca reusim sa cream baza de date
                CGestiuneIO.creazaBDD(this.lNumeServer, this.lNumeInstanta, this.lNumeUser, this.lParolaSQL, this.lNumeBDD, this.chkServerulEstePeAcestCalculator.Checked);

                string parolaHash = CSecuritate.GetMd5Hash(this.lParolaISTOMA);

                //recuperam scripturile de creare
                Dictionary<EnumScripturi, byte[]> dictScripturi = new Dictionary<EnumScripturi, byte[]>();
                //0 = nume
                //1 = prenume
                //2 = cnp
                //3 = versiune BDD
                //4 = denumire cabinet
                //5 = nr tel
                //6 = mail
                //7 = site
                //8 = data de nastere zzLLaaaa
                //9 = limba vorbita
                //10 = tara clientului
                List<string> detaliiUser = null;

                this.bwBDD.ReportProgress(5, (int)EnumScripturi.RecuperareInformatii);

                //ne legam la serviciu
                iStoma.VerificareSoapClient servVerif = new iStoma.VerificareSoapClient();

                dictScripturi.Add(EnumScripturi.Tabele, servVerif.IncarcaTabele(this.lCodClient, parolaHash));
                dictScripturi.Add(EnumScripturi.View, servVerif.IncarcaView(this.lCodClient, parolaHash));
                dictScripturi.Add(EnumScripturi.PS, servVerif.IncarcaPS(this.lCodClient, parolaHash));
                dictScripturi.Add(EnumScripturi.Tari, servVerif.IncarcaTari(this.lCodClient, parolaHash));
                dictScripturi.Add(EnumScripturi.Regiuni, servVerif.IncarcaRegiuni(this.lCodClient, parolaHash));
                dictScripturi.Add(EnumScripturi.Localitati, servVerif.IncarcaLocalitati(this.lCodClient, parolaHash));
                //dictScripturi.Add(EnumScripturi.CP, servVerif.IncarcaCP(this.lCodClient, parolaHash));
                //dictScripturi.Add(EnumScripturi.COR, servVerif.IncarcaCOR(this.lCodClient, parolaHash));
                //dictScripturi.Add(EnumScripturi.CAEN, servVerif.IncarcaCAEN(this.lCodClient, parolaHash));
                dictScripturi.Add(EnumScripturi.SMTP, servVerif.IncarcaSMTP(this.lCodClient, parolaHash));
                //dictScripturi.Add(EnumScripturi.Drepturi, servVerif.IncarcaDrepturi(this.lCodClient, parolaHash));
                //dictScripturi.Add(EnumScripturi.Meniu, servVerif.IncarcaMeniu(this.lCodClient, parolaHash));
                //dictScripturi.Add(EnumScripturi.Citate, servVerif.IncarcaCitate(this.lCodClient, parolaHash));
                //dictScripturi.Add(EnumScripturi.MultiLingv, servVerif.IncarcaMultiLingv(this.lCodClient, parolaHash));
                //dictScripturi.Add(EnumScripturi.Afectiuni, servVerif.IncarcaAfectiuni(this.lCodClient, parolaHash));
                //dictScripturi.Add(EnumScripturi.OrganeArtificiale, servVerif.IncarcaOrganeArtificiale(this.lCodClient, parolaHash));
                //dictScripturi.Add(EnumScripturi.ProduseGestiune, servVerif.IncarcaProduseGestiune(this.lCodClient, parolaHash));
                //dictScripturi.Add(EnumScripturi.Interventii, servVerif.IncarcaInterventii(this.lCodClient, parolaHash));
                //dictScripturi.Add(EnumScripturi.TratamenteAdministrative, servVerif.IncarcaTratamenteAdministrative(this.lCodClient, parolaHash));
                //dictScripturi.Add(EnumScripturi.EvenimenteCalendaristice, servVerif.IncarcaEvenimenteCalendaristice(this.lCodClient, parolaHash));

                detaliiUser = servVerif.GetInformatiiClient(this.lCodClient, parolaHash);

                BMultiLingv.EnumLimba limbaUtilizator = BMultiLingv.EnumLimba.Romana;
                int idTaraClient = BTari.ConstIDRomania;

                //LIMBA
                try
                {
                    if (detaliiUser.Count > 9)
                        limbaUtilizator = (BMultiLingv.EnumLimba)Convert.ToInt32(detaliiUser[9]);
                }
                catch (Exception)
                {
                }

                //TARA
                try
                {
                    if (detaliiUser.Count > 9)
                        idTaraClient = Convert.ToInt32(detaliiUser[10]);
                }
                catch (Exception)
                {
                }

                //List<string> listaRecomandari = servVerif.IncarcaRecomandari(this.lCodClient, parolaHash);

                servVerif.Close();

                string continutFisierSQL = string.Empty;

                this.bwBDD.ReportProgress(10, (int)EnumScripturi.Tabele);

                //Tabele
                continutFisierSQL = CGestiuneIO.DeCompreseazaText(dictScripturi[EnumScripturi.Tabele]);
                CGestiuneIO.executaFisierSQL(this.lNumeServer, this.lNumeInstanta, this.lNumeUser, this.lParolaSQL, this.chkServerulEstePeAcestCalculator.Checked, this.lNumeBDD, continutFisierSQL);

                this.bwBDD.ReportProgress(13, (int)EnumScripturi.View);

                //View
                continutFisierSQL = CGestiuneIO.DeCompreseazaText(dictScripturi[EnumScripturi.View]);
                CGestiuneIO.executaFisierSQL(this.lNumeServer, this.lNumeInstanta, this.lNumeUser, this.lParolaSQL, this.chkServerulEstePeAcestCalculator.Checked, this.lNumeBDD, continutFisierSQL, "-$$$-");

                this.bwBDD.ReportProgress(16, (int)EnumScripturi.PS);

                //PS
                continutFisierSQL = CGestiuneIO.DeCompreseazaText(dictScripturi[EnumScripturi.PS]);
                CGestiuneIO.executaFisierSQL(this.lNumeServer, this.lNumeInstanta, this.lNumeUser, this.lParolaSQL, this.chkServerulEstePeAcestCalculator.Checked, this.lNumeBDD, continutFisierSQL, "-$$$-");

                this.bwBDD.ReportProgress(20, (int)EnumScripturi.Tari);

                //Populam tabelele nou create
                //TARI
                continutFisierSQL = CGestiuneIO.DeCompreseazaText(dictScripturi[EnumScripturi.Tari]);
                CGestiuneIO.executaFisierSQL(this.lNumeServer, this.lNumeInstanta, this.lNumeUser, this.lParolaSQL, this.chkServerulEstePeAcestCalculator.Checked, this.lNumeBDD, continutFisierSQL);

                this.bwBDD.ReportProgress(23, (int)EnumScripturi.Regiuni);

                //REGIUNI
                continutFisierSQL = CGestiuneIO.DeCompreseazaText(dictScripturi[EnumScripturi.Regiuni]);
                CGestiuneIO.executaFisierSQL(this.lNumeServer, this.lNumeInstanta, this.lNumeUser, this.lParolaSQL, this.chkServerulEstePeAcestCalculator.Checked, this.lNumeBDD, continutFisierSQL);

                this.bwBDD.ReportProgress(28, (int)EnumScripturi.Localitati);

                //LOCALITATI
                continutFisierSQL = CGestiuneIO.DeCompreseazaText(dictScripturi[EnumScripturi.Localitati]);
                CGestiuneIO.executaFisierSQL(this.lNumeServer, this.lNumeInstanta, this.lNumeUser, this.lParolaSQL, this.chkServerulEstePeAcestCalculator.Checked, this.lNumeBDD, continutFisierSQL, "-$$$-");

                //this.bwBDD.ReportProgress(35, (int)EnumScripturi.CP);

                ////CODURI POSTALE
                //continutFisierSQL = CGestiuneIO.DeCompreseazaText(dictScripturi[EnumScripturi.CP]);
                //CGestiuneIO.executaFisierSQL(this.lNumeServer, this.lNumeInstanta, this.lNumeUser, this.lParolaSQL, this.chkServerulEstePeAcestCalculator.Checked, this.lNumeBDD, continutFisierSQL, "-$$$-");

                //this.bwBDD.ReportProgress(45, (int)EnumScripturi.COR);

                ////CODURI COR
                //continutFisierSQL = CGestiuneIO.DeCompreseazaText(dictScripturi[EnumScripturi.COR]);
                //CGestiuneIO.executaFisierSQL(this.lNumeServer, this.lNumeInstanta, this.lNumeUser, this.lParolaSQL, this.chkServerulEstePeAcestCalculator.Checked, this.lNumeBDD, continutFisierSQL, "-$$$-");

                //this.bwBDD.ReportProgress(55, (int)EnumScripturi.CAEN);

                ////CODURI CAEN
                //continutFisierSQL = CGestiuneIO.DeCompreseazaText(dictScripturi[EnumScripturi.CAEN]);
                //CGestiuneIO.executaFisierSQL(this.lNumeServer, this.lNumeInstanta, this.lNumeUser, this.lParolaSQL, this.chkServerulEstePeAcestCalculator.Checked, this.lNumeBDD, continutFisierSQL, "-$$$-");

                //this.bwBDD.ReportProgress(65, (int)EnumScripturi.Drepturi);

                ////DREPTURI
                //continutFisierSQL = CGestiuneIO.DeCompreseazaText(dictScripturi[EnumScripturi.Drepturi]);
                //CGestiuneIO.executaFisierSQL(this.lNumeServer, this.lNumeInstanta, this.lNumeUser, this.lParolaSQL, this.chkServerulEstePeAcestCalculator.Checked, this.lNumeBDD, continutFisierSQL);

                this.bwBDD.ReportProgress(67, (int)EnumScripturi.SMTP);

                //SMTP
                continutFisierSQL = CGestiuneIO.DeCompreseazaText(dictScripturi[EnumScripturi.SMTP]);
                CGestiuneIO.executaFisierSQL(this.lNumeServer, this.lNumeInstanta, this.lNumeUser, this.lParolaSQL, this.chkServerulEstePeAcestCalculator.Checked, this.lNumeBDD, continutFisierSQL);

                this.bwBDD.ReportProgress(70, (int)EnumScripturi.Citate);

                ////CITATE
                //continutFisierSQL = CGestiuneIO.DeCompreseazaText(dictScripturi[EnumScripturi.Citate]);
                //CGestiuneIO.executaFisierSQL(this.lNumeServer, this.lNumeInstanta, this.lNumeUser, this.lParolaSQL, this.chkServerulEstePeAcestCalculator.Checked, this.lNumeBDD, continutFisierSQL);

                //this.bwBDD.ReportProgress(73, (int)EnumScripturi.MultiLingv);

                ////MULTI LINGV
                //continutFisierSQL = CGestiuneIO.DeCompreseazaText(dictScripturi[EnumScripturi.MultiLingv]);
                //CGestiuneIO.executaFisierSQL(this.lNumeServer, this.lNumeInstanta, this.lNumeUser, this.lParolaSQL, this.chkServerulEstePeAcestCalculator.Checked, this.lNumeBDD, continutFisierSQL, "-$$$-");

                //this.bwBDD.ReportProgress(78, (int)EnumScripturi.Meniu);

                ////MENIU
                //continutFisierSQL = CGestiuneIO.DeCompreseazaText(dictScripturi[EnumScripturi.Meniu]);
                //CGestiuneIO.executaFisierSQL(this.lNumeServer, this.lNumeInstanta, this.lNumeUser, this.lParolaSQL, this.chkServerulEstePeAcestCalculator.Checked, this.lNumeBDD, continutFisierSQL);

                //this.bwBDD.ReportProgress(80, (int)EnumScripturi.Afectiuni);

                //Activam conexiunea la noua BDD
                seteazaConexiuneBDD();

                ////Adaugam specialitatea Medicina dentara "Medicină dentară"
                //int idSpecialitateStomatologica = BLL.General.Comune.BSpecialitati.Add(BLL.General.BMultiLingvPC.getElementById(BLL.General.BMultiLingv.EnumDictionar.MedicinaDentara), false, true, false, false, true, true, null);

                ////ADAUGAM AFECTIUNILE SPECIFICE ACESTEI SPECIALITATI
                //continutFisierSQL = CGestiuneIO.DeCompreseazaText(dictScripturi[EnumScripturi.Afectiuni]);
                //CGestiuneIO.executaFisierSQL(this.lNumeServer, this.lNumeInstanta, this.lNumeUser, this.lParolaSQL, this.chkServerulEstePeAcestCalculator.Checked, this.lNumeBDD, continutFisierSQL);

                //this.bwBDD.ReportProgress(82, (int)EnumScripturi.OrganeArtificiale);

                ////ADAUGAM ORGANELE ARTIFICIALE
                //continutFisierSQL = CGestiuneIO.DeCompreseazaText(dictScripturi[EnumScripturi.OrganeArtificiale]);
                //CGestiuneIO.executaFisierSQL(this.lNumeServer, this.lNumeInstanta, this.lNumeUser, this.lParolaSQL, this.chkServerulEstePeAcestCalculator.Checked, this.lNumeBDD, continutFisierSQL);

                //this.bwBDD.ReportProgress(85, (int)EnumScripturi.ProduseGestiune);

                ////ADAUGAM PRODUSELE DE GESTIUNE
                //continutFisierSQL = CGestiuneIO.DeCompreseazaText(dictScripturi[EnumScripturi.ProduseGestiune]);
                //CGestiuneIO.executaFisierSQL(this.lNumeServer, this.lNumeInstanta, this.lNumeUser, this.lParolaSQL, this.chkServerulEstePeAcestCalculator.Checked, this.lNumeBDD, continutFisierSQL);

                //this.bwBDD.ReportProgress(87, (int)EnumScripturi.Interventii);

                ////ADAUGAM INTERVENTIILE
                //continutFisierSQL = CGestiuneIO.DeCompreseazaText(dictScripturi[EnumScripturi.Interventii]);
                //CGestiuneIO.executaFisierSQL(this.lNumeServer, this.lNumeInstanta, this.lNumeUser, this.lParolaSQL, this.chkServerulEstePeAcestCalculator.Checked, this.lNumeBDD, continutFisierSQL);

                //Setam versiunea BDD
                CGestiuneIO.executaFisierSQL(this.lNumeServer, this.lNumeInstanta, this.lNumeUser, this.lParolaSQL, this.chkServerulEstePeAcestCalculator.Checked, this.lNumeBDD,
                    string.Format("INSERT INTO VersiuniBDD_TD(tVersiune) VALUES ('{0}')", detaliiUser[3]));

                //Adaugam utilizatorul cu specialitatea stomatolog
                int idUser = BUtilizator.Add(this.lCodClient, this.lParolaISTOMA, detaliiUser[0], detaliiUser[1], detaliiUser[2]);

                //Actualizam informatiile clientului cu cele pe care ni le-a furnizat
                BUtilizator userCreat = BUtilizator.GetById(idUser, null);
                userCreat.TelefonMobil = detaliiUser[5];
                userCreat.AdresaMail = detaliiUser[6];
                userCreat.PaginaWeb = detaliiUser[7];
                userCreat.Titulatura = CDefinitiiComune.EnumTitulatura.Doctor;
                userCreat.DataNastere = CUtil.getDateFromString(detaliiUser[8]);
                //userCreat.Rol = BUtilizator.EnumRolUtilizator.Medic;
                userCreat.NumarOrdine = 1;
                //userCreat.UltimaOptiuneAccesata = BLL.General.BMeniu.EnumOptiune.SetariInitiale;
                userCreat.UpdateAll(null);

                //this.bwBDD.ReportProgress(95, (int)EnumScripturi.TratamenteAdministrative);

                ////ADAUGAM TRATAMENTELE ADMINISTRATIVE
                //continutFisierSQL = CGestiuneIO.DeCompreseazaText(dictScripturi[EnumScripturi.TratamenteAdministrative]);
                //CGestiuneIO.executaFisierSQL(this.lNumeServer, this.lNumeInstanta, this.lNumeUser, this.lParolaSQL, this.chkServerulEstePeAcestCalculator.Checked, this.lNumeBDD, continutFisierSQL, "-$$$-");

                //this.bwBDD.ReportProgress(96, (int)EnumScripturi.EvenimenteCalendaristice);

                ////EVENIMENTE CALENDARISTICE - Avem nevoie de utilizator
                //continutFisierSQL = CGestiuneIO.DeCompreseazaText(dictScripturi[EnumScripturi.EvenimenteCalendaristice]);
                //CGestiuneIO.executaFisierSQL(this.lNumeServer, this.lNumeInstanta, this.lNumeUser, this.lParolaSQL, this.chkServerulEstePeAcestCalculator.Checked, this.lNumeBDD, continutFisierSQL);

                //string numeRadacinaDefault = "Clinica de stomatologie";
                //string numeGrupDefault = "Grup";
                string numeSediuDefault = "Stoma";
                //string numeSectieDefault = "Medicină dentară";
                //string numeCabinet1Default = "Cabinet 1";

                //Adaugam locatia medicala (Asociatie + grup + sediu + uf)
                //string numeRadacina = detaliiUser[4];
                string numeSediu = detaliiUser[4];

                //if (string.IsNullOrEmpty(numeRadacina))
                //    numeRadacina = numeRadacinaDefault;

                if (string.IsNullOrEmpty(numeSediu))
                    numeSediu = numeSediuDefault;

                int idSediu = BLocatii.Add(numeSediu, null);

                //Adaugam adresa sediului
                BAdrese.Add(BAdrese.EnumTipAdresa.Principala, string.Empty, string.Empty, string.Empty, string.Empty,
                    string.Empty, string.Empty, string.Empty, idTaraClient, -1, -1, string.Empty, string.Empty, CDefinitiiComune.EnumTipObiect.Locatie, idSediu, null);

                //Vom considera ca radacina este locatia fiscala
                BLocatii sediu = new BLocatii(idSediu, null);

                //Setam tel si email pt sediu
                sediu.TelefonMobil = detaliiUser[5];
                sediu.AdresaMail = detaliiUser[6];
                sediu.PaginaWeb = detaliiUser[7];

                sediu.UpdateAll();
            }
            catch (Exception ex)
            {
                this.lExceptie = ex.Message;
            }
        }

        [STAThread]
        private void bwBDD_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.lExceptie))
            {
                //trecem la etapa de selectare a folderelor aplicatiei
                this.lEtapa = 2;
                afiseazaEtapa();
            }
            else
            {
                MessageBox.Show(this.lExceptie, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                zoneActive(true);
            }
        }

        #endregion

        #region Metode private

        private void zoneActive(bool pActive)
        {
            this.picAsteptare.Visible = !pActive;
            this.pbAvans.Visible = !pActive;

            this.btnActivare.Visible = pActive;
            this.btnAnulare.Visible = pActive;

            this.txtCodClient.Enabled = pActive;
            this.txtParola.Enabled = pActive;
            this.txtLicenta.Enabled = pActive;
            this.chkAcceptaTermeniiSiConditiile.Enabled = pActive;

            this.cboListaServere.Enabled = pActive && this.cboListaServere.Items.Count > 0;
            this.txtServerManual.Enabled = pActive;
            this.txtUserSQL.Enabled = pActive;
            this.txtParolaSQL.Enabled = pActive;
            this.cboBDD.Enabled = pActive;
            this.txtNumeInstantaSQL.Enabled = pActive;
            this.btnAdaugaBDD.Visible = pActive;

            this.btnAlegeFolder.Enabled = pActive;
        }
        List<ServerSQL> lListaServereSQL = null;

        private void afiseazaEtapa()
        {
            if (this.lEtapa == 0)
            {
                this.txtCodClient.Focus();
            }

            if (this.lEtapa == 1)
            {
                //incarcam lista de servere SQL din retea
                this.cboListaServere.DataSource = this.lListaServereSQL;

                if (this.lListaServereSQL == null || this.lListaServereSQL.Count == 0)
                {
                    this.txtServerManual.Text = "localhost";// CGestiuneIO.getComputerName();
                    this.txtNumeInstantaSQL.Text = "SQLExpress";
                }

                this.txtUserSQL.Text = "sa";
            }

            zoneActive(true);
            this.panelLicenta.Visible = this.lEtapa == 0;
            this.panelBDD.Visible = this.lEtapa == 1;
            this.lblEtapa.Visible = this.lEtapa < 2;
            this.panelDocumente.Visible = this.lEtapa == 2;
        }

        private bool verificaFolderDocumente()
        {
            if (string.IsNullOrEmpty(this.txtCaleSalvareDocumente.Text))
            {
                // "Documente"
                //"Precizați directorul de salvare al documentelor"
                MessageBox.Show("Precizati folderul de salvare a documentelor", "Documente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool verificaConexiunea()
        {
            incarcaVariabileBDD();

            if (!CGestiuneIO.ConexiuneBDDValida(this.lNumeServer, this.lNumeInstanta, this.lNumeUser, this.lParolaSQL, this.chkServerulEstePeAcestCalculator.Checked))
            {
                //"Conexiune server"
                //"Informațiile furnizate nu sunt valide"
                MessageBox.Show("Informațiile furnizate nu sunt valide", "Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void incarcaVariabileDocumente()
        {
            this.lCaleFolderDocumente = this.txtCaleSalvareDocumente.Text.Trim();
        }

        private void incarcaVariabileBDD()
        {
            this.lServerAles = this.cboListaServere.SelectedItem as ServerSQL;
            this.lNumeServer = this.txtServerManual.Text;
            this.lNumeInstanta = this.txtNumeInstantaSQL.Text.Trim();
            this.lNumeUser = this.txtUserSQL.Text.Trim();
            this.lParolaSQL = this.txtParolaSQL.Text.Trim();
            if (this.cboBDD.SelectedItem != null)
                this.lNumeBDD = Convert.ToString(this.cboBDD.SelectedItem);
        }

        private void incarcaVariabileISTOMA()
        {
            this.lCodClient = this.txtCodClient.Text;
            this.lParolaISTOMA = this.txtParola.Text;
            this.lLicenta = this.txtLicenta.Text;
        }

        private void incarcaListaBDD()
        {
            incarcaListaBDD(false);
        }

        private void incarcaListaBDD(bool pAfiseazaEroarea)
        {
            incarcaVariabileBDD();

            bool conexiuneOK = false;

            if (!string.IsNullOrEmpty(this.lNumeServer) &&
                (this.chkServerulEstePeAcestCalculator.Checked || !string.IsNullOrEmpty(this.lNumeUser) && !string.IsNullOrEmpty(this.lParolaSQL)))
            {
                //recuperam lista de BDD
                if (CGestiuneIO.ConexiuneBDDValida(this.lNumeServer, this.lNumeInstanta, this.lNumeUser, this.lParolaSQL, this.chkServerulEstePeAcestCalculator.Checked))
                {
                    //doar daca nu am selectat o BDD reinitializam lista
                    object bddSelectata = this.cboBDD.SelectedItem;
                    this.cboBDD.DataSource = CGestiuneIO.getListaBDD(this.lNumeServer, this.lNumeInstanta, this.lNumeUser, this.lParolaSQL, this.chkServerulEstePeAcestCalculator.Checked);
                    this.cboBDD.SelectedItem = bddSelectata;

                    conexiuneOK = true;
                }
            }

            if (!conexiuneOK && pAfiseazaEroarea)
            {
                //"Informațiile furnizate nu sunt valide"
                MessageBox.Show("Informațiile furnizate nu sunt valide", "Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void initCulori()
        {
            Color alb = Color.FromArgb(249, 249, 249);
            Color gri = Color.FromArgb(230, 230, 230);
            this.BackColor = alb;
            this.panelBDD.BackColor = gri;
            this.panelDocumente.BackColor = gri;
            this.panelLicenta.BackColor = gri;
        }

        #endregion
    }
}
