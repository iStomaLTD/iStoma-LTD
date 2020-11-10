using BLL.iStomaLab;
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

namespace iStomaLab
{
    public partial class frmDespre : FormPersonalizat
    {


        #region Declaratii generale


        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private frmDespre()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

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

            this.btnSugestie.Click += BtnSugestie_Click;
            this.btnCheckForUpdates.Click += BtnCheckForUpdates_Click;
            this.lblTelefonMobilSuport.Click += LblSuport_Click;
            this.lblTelMobilJuridic.Click += LblTelMobilJuridic_Click;
            this.lblTelefonFixSuport.Click += LblTelefonFixSuport_Click;
            this.lblTelefonFeedBack.Click += LblFeedBack_Click;
            this.lblMarketing.Click += LblMarketing_Click;
            this.btnOptimizeaza.Click += BtnOptimizeaza_Click;
            this.lnkPiataStomatologica.LinkClicked += LnkPiataStomatologica_LinkClicked;
            this.lnkCloud.LinkClicked += LnkCloud_LinkClicked;
        }

        private void initTextML()
        {
            this.Text = string.Empty;


            this.Icon = CCL.UI.Imagini.GetIconAplicatie();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.PermiteDeplasareaEcranului = true;
            this.PermiteMaximizareaEcranului = false;
            this.PermiteRedimensionarea = false;

            this.lblTitluVersiuneAplicatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.VersiuneAplicatie);
            this.lblTitluVersiuneBDD.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.VersiuneBazaDeDate);
            this.btnSugestie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.MasBucuraDacaPuncteDeSuspensie);
            this.btnOptimizeaza.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Optimizeaza);
            this.btnConsiliereJuridic.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Consiliere);
            //Nu mai oferim consiliere
            this.btnConsiliereJuridic.Visible = false;
            this.lblJuridic.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Contracte);

            string linkCloud = string.Empty; //BComportamentAplicatie.GetURLCloudClinica();

            this.lnkCloud.Text = linkCloud;
            this.lnkCloud.Visible = !string.IsNullOrEmpty(linkCloud);

            this.lblTitluEcran.Text = string.Empty;
        }

        void _Load(object sender, EventArgs e)
        {
            try
            {
                Initializeaza();

                this.panelGlobal.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        private string getLicenta()
        {
            return CCL.iStomaLab.Utile.CGestiuneIO.getLicenta();
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.lblVersiuneAplicatie.Text = Versiuni.VERSIUNE_APLICATIE_AFISAJ;
            this.lblVersiuneBDD.Text = Versiuni.getVersiuneAfisajBDD();
            this.lblNumeCalculator.Text = string.Format("{0} [{1}]", CCL.iStomaLab.Utile.CGestiuneIO.getComputerName(),
                 CCL.iStomaLab.Utile.CGestiuneIO.GetInternalIP());

            this.lblLicenta.Text = string.Format("{0}: {1}", BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Licenta), getLicenta());

            this.lnkIStomaLTD.Visible = true; //this.lPreferinteUtilizator.LimbaEnum == BMultiLingv.EnumLimba.Romana;

            this.pictureBoxPersonalizat1.Image = CCL.UI.Imagini.GetLogoAplicatie();
            this.lnkIStomaLTD.Text = CCL.UI.Imagini.GetWebSiteAplicatie();

            this.wbNoutatiVersiune.Navigate(string.Concat("https://istoma.ro/NoutatiVersiune.aspx?ta=", CConstante.TIP_APLICATIE, "&v=", Versiuni.VERSIUNE_APLICATIE));

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void BtnOptimizeaza_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                DateTime dataInceput = DateTime.Now;

                BGeneral.OptimizeazaBDD();

                Mesaj.Afiseaza(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Succes), string.Concat(DateAndTime.DateDiff(DateInterval.Second, dataInceput, DateTime.Now), " ", BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Secunde).ToLower()));
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

        private void LblMarketing_Click(object sender, EventArgs e)
        {
            sunaLaISTOMA("Marketing iStoma", "0724478662");
        }

        private void LblFeedBack_Click(object sender, EventArgs e)
        {
            sunaLaISTOMA("Ionut iStoma", "0737424273");
        }

        private void LblTelefonFixSuport_Click(object sender, EventArgs e)
        {
            sunaLaISTOMA("Suport iStoma Fix", "0215551052");
        }

        private void LblSuport_Click(object sender, EventArgs e)
        {
            sunaLaISTOMA("Suport iStoma", "0731478662");
        }

        private void LblTelMobilJuridic_Click(object sender, EventArgs e)
        {
            sunaLaISTOMA("Contracte iStoma", "0734786621");
        }

        private void BtnCheckForUpdates_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                inchideEcranul(DialogResult.Retry);
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

        private void BtnSugestie_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                frmSugestieClient.Afiseaza(this.GetFormParinte());
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

        private void btnCitesteNewsletterOnline_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(string.Concat("http://www.istoma.ro/Newsletter/DetaliiVersiune.aspx?v=", Versiuni.VERSIUNE_APLICATIE));
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        private void LnkCloud_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //System.Diagnostics.Process.Start(BComportamentAplicatie.GetURLCloudClinica());
        }

        private void LnkPiataStomatologica_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://www.piatastomatologica.ro/");
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        private void lnkIStoma_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(string.Concat("http://", CCL.UI.Imagini.GetWebSiteAplicatie()));
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        private void btnValidare_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Metode private

        private void sunaLaISTOMA(string pNume, string pNumarTelefon)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                inchideEcranulOK();

                //IHMUtile._AccesTotal.afiseazaDetaliiObiect(null, new BLL.General.Comune.StructPersSauOrganizatie(CDefinitiiComune.EnumTipObiect.EchipaISTOMA, 1, pNume, pNumarTelefon, "contact@iStoma.ro", string.Empty));
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

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente)
        {
            using (frmDespre ecran = new frmDespre())
            {
                ecran.AplicaPreferinteleUtilizatorului();
                //return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
                return CCL.UI.IHMUtile.DeschideEcranShowDialog(pEcranPariente, ecran) == DialogResult.Retry;
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
