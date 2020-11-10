using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace ActualizareAplicatie
{
    public partial class frmActualizeaza : Form
    {
        private bool lActualizareEfectuata = false;
        private Tuple<string, string> utilizator = null;
        private BMasina masina = null;
        private EnumOperatie lOperatie = EnumOperatie.Modificari;
        private string lModificariDisponibile = string.Empty;
        private string lActiune = string.Empty;
        private bool lActualizareInCurs = false;
        private bool lExistaUpgradeDisponibil = false;
        private bool lAreDreptUpgrade = true;
        private bool lPermiteLansareaManuala = true;
        private int lTipAplicatie = 0;

        private enum EnumOperatie
        {
            Modificari,
            Actualizeaza
        }

        private void initTipAplicatie()
        {
            try
            {
                this.lTipAplicatie = CUtile.GetTipAplicatieDinRegistri();
            }
            catch (Exception)
            {
                this.lTipAplicatie = 0;
            }
        }

        public frmActualizeaza()
        {
            InitializeComponent();

            initTipAplicatie();

            this.lnkISTOMA.Visible = CUtile.EsteInLimbaRomana();

            initML();
        }

        private void initML()
        {
            this.Text = string.Concat("iStoma LTD", " - ", BMultiLingv.GetById(BMultiLingv.EnumDictionar.actualizare, this.lTipAplicatie));

            this.lblAsteptati.Text = BMultiLingv.GetById(BMultiLingv.EnumDictionar.vaRugamSaAsteptati, this.lTipAplicatie);
            this.lblInitializareComunicareIStoma.Text = BMultiLingv.GetById(BMultiLingv.EnumDictionar.seInitComunicareaCuServerulIStoma, this.lTipAplicatie);
            this.lnkISTOMA.Text = BMultiLingv.GetById(BMultiLingv.EnumDictionar.DetaliiIStoma, this.lTipAplicatie);
            this.lblTitlu.Text = BMultiLingv.GetById(BMultiLingv.EnumDictionar.inNouaVersiuneVetiAveaUrmatoarele, this.lTipAplicatie);
            this.btnLanseazaActualizarea.Text = BMultiLingv.GetById(BMultiLingv.EnumDictionar.actualizare, this.lTipAplicatie);
            this.btnFinalizeaza.Text = BMultiLingv.GetById(BMultiLingv.EnumDictionar.deschideIStoma, this.lTipAplicatie);
            this.lblActiune.Text = BMultiLingv.GetById(BMultiLingv.EnumDictionar.actiune, this.lTipAplicatie);
        }

        public frmActualizeaza(string[] args)
        {
            InitializeComponent();

            initTipAplicatie();

            this.lnkISTOMA.Visible = CUtile.EsteInLimbaRomana();

            initML();

            if (args != null && args.Length > 0)
            {
                if (args[0].Equals("L"))
                    this.lPermiteLansareaManuala = false;
            }

            this.btnFinalizeaza.Visible = this.lPermiteLansareaManuala;
        }

        private void btnLanseazaActualizarea_Click(object sender, EventArgs e)
        {
            try
            {
                lanseazaActualizarea();
            }
            catch (Exception ex)
            {
                this.btnLanseazaActualizarea.Visible = true;
                MessageBox.Show(ex.Message, BMultiLingv.GetById(BMultiLingv.EnumDictionar.eroare, this.lTipAplicatie), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void verificaDacaMaiExistaUpgradeuri()
        {
            this.lOperatie = EnumOperatie.Modificari;

            this.btnLanseazaActualizarea.Visible = false;
            this.lblActiune.Visible = true;
            this.pbStareActualizare.Visible = true;
            this.btnFinalizeaza.Visible = false;

            this.bwServer.RunWorkerAsync();
        }

        private void lanseazaActualizarea()
        {
            this.lOperatie = EnumOperatie.Actualizeaza;

            this.btnLanseazaActualizarea.Visible = false;
            this.lblActiune.Visible = true;
            this.pbStareActualizare.Visible = true;
            this.btnFinalizeaza.Visible = false;

            this.bwServer.RunWorkerAsync();
        }

        private void btnFinalizeaza_Click(object sender, EventArgs e)
        {
            if (this.lActualizareEfectuata || MessageBox.Show(string.Concat(BMultiLingv.GetById(BMultiLingv.EnumDictionar.actualizarileUlterioareDevinDispoDupaActualizare, this.lTipAplicatie), "\r\n", BMultiLingv.GetById(BMultiLingv.EnumDictionar.suntetiSigurCaNuDoritiActualizareaAplicatiei, this.lTipAplicatie), "\r\n"), BMultiLingv.GetById(BMultiLingv.EnumDictionar.actualizari, this.lTipAplicatie), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                lanseazaIStoma();
            }
        }

        private void lanseazaIStoma()
        {
            System.Diagnostics.Process.Start(Path.Combine(CUtile.GetLocatieAplicatie(), "iStomaLTD.exe"));

            this.Close();
        }

        private void frmActualizeaza_Load(object sender, EventArgs e)
        {
            try
            {
                if (!CUtile.existaConexiuneBDD())
                {
                    frmDetaliiBDD bdd = new frmDetaliiBDD();
                    bdd.ShowDialog();
                }

                if (!CUtile.existaConexiuneBDD())
                {
                    this.Close();
                    return;
                }

                this.panelDetalii.Visible = false;
                this.panelStart.Visible = true;
                this.lOperatie = EnumOperatie.Modificari;
                this.bwServer.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, BMultiLingv.GetById(BMultiLingv.EnumDictionar.eroare, this.lTipAplicatie), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bwServer_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                switch (this.lOperatie)
                {
                    case EnumOperatie.Modificari:
                        recupereazaModificari();
                        break;
                    case EnumOperatie.Actualizeaza:
                        this.lActualizareInCurs = true;
                        actualizeazaAplicatia();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, BMultiLingv.GetById(BMultiLingv.EnumDictionar.eroare, this.lTipAplicatie), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bwServer_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.lblActiune.Text = this.lActiune;
            this.pbStareActualizare.Value = e.ProgressPercentage;
        }

        private void bwServer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            switch (this.lOperatie)
            {
                case EnumOperatie.Modificari:

                    if (!this.lExistaUpgradeDisponibil)
                    {
                        //Doar prima oara afisam asta
                        if (!this.lActualizareEfectuata)
                        {
                            MessageBox.Show(BMultiLingv.GetById(BMultiLingv.EnumDictionar.nuExistaActualizariDisponibile, this.lTipAplicatie), getDenumireAplicatie(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        return;
                    }

                    this.txtModificari.Text = this.lModificariDisponibile;

                    this.lblActiune.Visible = false;
                    this.pbStareActualizare.Visible = false;

                    this.panelStart.Visible = false;
                    this.panelDetalii.Visible = true;
                    this.btnLanseazaActualizarea.Visible = this.lExistaUpgradeDisponibil;
                    this.btnLanseazaActualizarea.Focus();

                    //Daca upgrade-ul trebuia facut atunci il facem
                    if (!this.lPermiteLansareaManuala)
                        lanseazaActualizarea();
                    break;
                case EnumOperatie.Actualizeaza:
                    if (this.lAreDreptUpgrade)
                    {
                        this.lblActiune.Text = BMultiLingv.GetById(BMultiLingv.EnumDictionar.vaMultumim, this.lTipAplicatie);
                        this.btnLanseazaActualizarea.Visible = false;
                        this.pbStareActualizare.Visible = false;

                        this.lActualizareInCurs = false;

                        //Daca acest upgrade trebuia facut atunci deschidem automat aplicatia (scutim un click)
                        if (!this.lPermiteLansareaManuala)
                            lanseazaIStoma();
                        else
                            verificaDacaMaiExistaUpgradeuri();
                    }
                    else
                    {
                        MessageBox.Show(string.Concat(BMultiLingv.GetById(BMultiLingv.EnumDictionar.nuAtiAchizitionatAcesteActualizari, this.lTipAplicatie), "\r\n\r\n",
                            BMultiLingv.GetById(BMultiLingv.EnumDictionar.contactatiUnReprIDavaSolutionsPtMaiMDetalii, this.lTipAplicatie)),
                            BMultiLingv.GetById(BMultiLingv.EnumDictionar.actualizarileNuSuntDisponibile, this.lTipAplicatie),
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.btnFinalizeaza.Visible = true;
                    this.btnFinalizeaza.Focus();

                    this.lActualizareInCurs = false;
                    break;
            }
        }

        private void recupereazaModificari()
        {
            this.utilizator = CUtile.GetUtilizatorISTOMA();
            this.masina = new BMasina();

            Actualizari.ActualizariSoapClient act = new Actualizari.ActualizariSoapClient();

            this.lModificariDisponibile = act.GetDescriereVersiuneDisponibila(this.utilizator.Item1, this.utilizator.Item2, CUtile.getCheieLicenta(), masina.Id);
            this.lExistaUpgradeDisponibil = act.ExistaActualizareDisponibila(this.utilizator.Item1, this.utilizator.Item2, CUtile.getCheieLicenta(), masina.Id);
            act.Close();
        }

        private void actualizeazaAplicatia()
        {
            this.lActiune = BMultiLingv.GetById(BMultiLingv.EnumDictionar.recuperareaInfoReferitoaeLaVersiuneaActuala, this.lTipAplicatie);// "Recuperarea informațiilor referitoare la versiunea actuală";
            this.bwServer.ReportProgress(10);

            //Descarcam elementele necesare
            this.utilizator = CUtile.GetUtilizatorISTOMA();
            this.masina = new BMasina();

            string idMasina = masina.Id;

            this.lActiune = BMultiLingv.GetById(BMultiLingv.EnumDictionar.conectareLaServer, this.lTipAplicatie);// "Conectare la server";
            this.bwServer.ReportProgress(20);

            Actualizari.ActualizariSoapClient act = new Actualizari.ActualizariSoapClient();
            byte[] arhiva = act.GetVersiuneaUrmatoare(this.utilizator.Item1, this.utilizator.Item2, CUtile.getCheieLicenta(), idMasina); 
            string versiune = string.Empty;

            this.lAreDreptUpgrade = arhiva != null;

            if (this.lAreDreptUpgrade)
            {
                this.lActiune = BMultiLingv.GetById(BMultiLingv.EnumDictionar.recuperareaNoilorFunctionalitati, this.lTipAplicatie);//"Recuperarea noilor funcționalități";
                this.bwServer.ReportProgress(40);

                string folderActual = CUtile.GetLocatieAplicatie();

                //Incarcam arhiva in memorie
                using (MemoryStream arhivaMemorie = new MemoryStream(arhiva))
                {
                    List<Ionic.Zip.ZipEntry> listaSQL = new List<Ionic.Zip.ZipEntry>();
                    List<Ionic.Zip.ZipEntry> listaFisiere = new List<Ionic.Zip.ZipEntry>();
                    bool upgradeML = false;
                    //Cream arhiva
                    using (Ionic.Zip.ZipFile fisierZip = Ionic.Zip.ZipFile.Read(arhivaMemorie))
                    {
                        foreach (Ionic.Zip.ZipEntry intrare in fisierZip)
                        {

                            if (intrare.FileName.EndsWith(".sql"))
                            {
                                //Fisier de executat SQL
                                listaSQL.Add(intrare);
                            }
                            else
                            {
                                //Fisier de copiat
                                if (intrare.FileName.Contains("upgradeMultiLingv"))
                                    upgradeML = true;
                                else
                                {
                                    if (intrare.FileName.Contains(".vrs"))
                                        versiune = intrare.FileName.Substring(0, intrare.FileName.IndexOf(".vrs"));
                                    else
                                        listaFisiere.Add(intrare);
                                }
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(versiune))
                    {
                        string versiuneBDDExistenta = CUtile.getUltimaVersiuneBDD();

                        if (string.IsNullOrEmpty(versiuneBDDExistenta))
                            versiuneBDDExistenta = "1";

                        if (!versiune.Equals(versiuneBDDExistenta) && Convert.ToInt32(versiune) > Convert.ToInt32(versiuneBDDExistenta))
                        {

                            this.lActiune = BMultiLingv.GetById(BMultiLingv.EnumDictionar.modificareaStructuriiDeDate, this.lTipAplicatie);//"Modificarea structurii de date";
                            this.bwServer.ReportProgress(80);

                            foreach (Ionic.Zip.ZipEntry executaSQL in listaSQL)
                            {
                                //Executam scripturile
                                System.IO.StreamReader reader = new StreamReader(executaSQL.OpenReader());

                                CUtile.executaFisierSQL(reader.ReadToEnd(), "-$$$-");
                            }

                            //Facem update la versiunea BDD
                            CUtile.UpdateVersiuneBDD(versiune);

                            if (upgradeML)
                            {
                                //rescriem tabela de multi lingv
                                byte[] fisierMultiLingv = null;

                                iStoma.VerificareSoapClient servVerif = new iStoma.VerificareSoapClient();
                                fisierMultiLingv = servVerif.IncarcaMultiLingv(this.utilizator.Item1, this.utilizator.Item2);

                                CUtile.updateMultiLingv(fisierMultiLingv);
                            }
                        }
                    }

                    this.lActiune = BMultiLingv.GetById(BMultiLingv.EnumDictionar.modificareaLibrariilorIStoma, this.lTipAplicatie);//"Modificarea librariilor iStoma";
                    this.bwServer.ReportProgress(100);

                    foreach (Ionic.Zip.ZipEntry fisierCopiere in listaFisiere)
                    {
                        //Inlocuim fisierele
                        //Stergem fisierele care exista deja
                        if (File.Exists(Path.Combine(folderActual, fisierCopiere.FileName)))
                            File.Delete(Path.Combine(folderActual, fisierCopiere.FileName));

                        fisierCopiere.Extract(folderActual, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);
                    }

                    //Anuntam serverul ca actualizarea a fost efectuata
                    act.SeteazaNouaVersiune(this.utilizator.Item1, this.utilizator.Item2, CUtile.getCheieLicenta(), idMasina);
                    act.Close();

                    this.lActualizareEfectuata = true;
                }
            }
            else
                this.lActualizareEfectuata = true;
        }

        private void frmActualizeaza_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.lActualizareInCurs)
            {
                MessageBox.Show(BMultiLingv.GetById(BMultiLingv.EnumDictionar.vaRugamSaAsteptatiFinalizareaActualizarii, this.lTipAplicatie), BMultiLingv.GetById(BMultiLingv.EnumDictionar.actualizareInCurs, this.lTipAplicatie), MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }

        private void lnkISTOMA_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.lTipAplicatie == 0)
                CUtile.PornesteProces("http://www.istoma.ro");
            else
                CUtile.PornesteProces("http://www.iclinic.ro");
        }

        private void lnkIDAVA_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CUtile.PornesteProces("http://www.idava.ro");
        }

        private string getDenumireAplicatie()
        {
            if (this.lTipAplicatie == 0)
                return "iStoma";

            return "iClinic";
        }
    }
}
