using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Comune;
using CCL.UI;
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

namespace iStomaLab.TablouDeBord.Clienti
{
    public partial class FormDetaliuClient : Generale.FormPersonalizat
    {

        #region Declaratii generale

        private BClienti lClient = null;
        private BAdrese lAdresa = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormDetaliuClient(BClienti pClient, BAdrese pAdresa)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lClient = pClient;
            this.lAdresa = pAdresa;

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {

                adaugaHandlere();
                initTextML();

                this.CentratCuDeplasare();
            }
           this.Focus();
        }

        private void adaugaHandlere()
        {
            this.Load += _Load;
            this.ctrlValidareAnulareClient.Validare += CtrlValidareAnulareClient_Click;
            this.btnSediuClient.Click += BtnSediuClient_Click;
        }

        private void initTextML()
        {
            this.Text = string.Empty;
            this.lblTitluEcran.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Clinica);
            this.lblDenumireClient.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire);
            this.lblDenumireFiscalaClient.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DenumireFiscala);
            this.lblCUIClient.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CUI);
            this.lblRegComClient.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.RegistrulComertului);
            this.lblEmailClient.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Email);
            this.lblPaginaWebClient.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PaginaWeb);
            this.lblTelefonMobilClient.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TelefonMobil);
            this.lblTelefonFixClient.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TelefonFix);
            this.lblFaxClient.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Fax);
            this.lblSkypeClient.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Skype);
            this.lblObservatiiClient.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii);
            this.lblRecomandant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Recomandant);
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

            this.txtAdresaClient.Enabled = false;
            incarcaListe();

            if (this.lClient == null)
            {
                this.txtDenumireClient.Goleste();
                this.txtDenumireFiscalaClient.Goleste();
                this.txtCUIClient.Goleste();
                this.txtRegComClient.Goleste();
                this.txtEmailClient.Goleste();
                this.txtPaginaWebClient.Goleste();
                this.txtTelefonMobilClient.Goleste();
                this.txtTelefonFixClient.Goleste();
                this.txtFaxClient.Goleste();
                this.txtSkypeClient.Goleste();
                this.txtObservatiiClient.Goleste();
                this.txtDenumireClient.Focus();
                this.txtAdresaClient.Goleste();
                this.ctrlRecomandant.Initializeaza(StructIdDenumire.Empty, CEnumerariComune.EnumTipDeschidere.DreaptaSus);
            }
            else
            {
                this.txtDenumireClient.Text = this.lClient.Denumire;
                this.txtDenumireFiscalaClient.Text = this.lClient.DenumireFiscala;
                this.txtCUIClient.Text = this.lClient.CUI;
                this.txtRegComClient.Text = this.lClient.RegCom;
                this.txtEmailClient.Text = this.lClient.AdresaMail;
                this.txtTelefonMobilClient.Text = this.lClient.TelefonMobil;
                this.txtTelefonFixClient.Text = this.lClient.TelefonFix;
                this.txtFaxClient.Text = this.lClient.Fax;
                this.txtSkypeClient.Text = this.lClient.ContSkype;
                this.txtObservatiiClient.Text = this.lClient.ObservatiiDateClinica;
                // this.txtAdresaClient.Text = BAdrese.DetaliiAdresa(BAdrese.getAdresaByIdProprietar(this.lClient.Id, null));
                this.cboTipClient.SelectedIndex = this.lClient.TipClient;
            }

            //this.ctrlDetaliuClient.Initializeaza(this.lClient);
            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente
        
        private void CtrlValidareAnulareClient_Click(object sender, EventArgs e)
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

        private void BtnSediuClient_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                Generale.FormAdresaISTOMA.Afiseaza(this.GetFormParinte(), this.lClient);
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

        private void incarcaListe()
        {
            this.cboTipClient.DataSource = BDefinitiiGenerale.StructTipFiscalitate.GetListaTipFiscalitate();
            this.cboTipClient.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void seteazaAlerta()
        {
            IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.txtDenumireClient, this.lblDenumireClient);
            this.txtDenumireClient.Focus();
        }



        #endregion

        #region Metode publice

        internal static bool Afiseaza(Form pEcranPariente, int pIdClient)
        {
            if (pIdClient <= 0) return false;

            return Afiseaza(pEcranPariente, new BClienti(pIdClient));
        }

        public static bool Afiseaza(Form pEcranPariente, BClienti pClient)
        {
            if (pClient == null) return false;

            using (FormDetaliuClient ecran = new FormDetaliuClient(pClient, null))
            {
                ecran.AplicaPreferinteleUtilizatorului();
                return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
            }
        }

        internal bool Salveaza()
        {
            bool esteValid = BClienti.SuntInformatiileNecesareCoerente(this.txtDenumireClient.Text);

            this.lClient.Denumire = this.txtDenumireClient.Text;
            this.lClient.DenumireFiscala = this.txtDenumireFiscalaClient.Text;
            this.lClient.CUI = this.txtCUIClient.Text;
            this.lClient.RegCom = this.txtRegComClient.Text;
            this.lClient.AdresaMail = this.txtEmailClient.Text;
            this.lClient.PaginaWeb = this.txtPaginaWebClient.Text;
            this.lClient.TelefonMobil = this.txtTelefonMobilClient.Text;
            this.lClient.TelefonFix = this.txtTelefonFixClient.Text;
            this.lClient.Fax = this.txtFaxClient.Text;
            this.lClient.ContSkype = this.txtSkypeClient.Text;
            this.lClient.ObservatiiDateClinica = this.txtObservatiiClient.Text;
            this.lClient.TipClient = this.cboTipClient.SelectedIndex;

            if (esteValid)
            {
                this.lClient.UpdateAll();
            }
            else
            {
                seteazaAlerta();
            }

            return esteValid;
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
            this.txtDenumireClient.AllowModification(this.lEcranInModificare);
            this.txtDenumireFiscalaClient.AllowModification(this.lEcranInModificare);
            this.txtCUIClient.AllowModification(this.lEcranInModificare);
            this.txtRegComClient.AllowModification(this.lEcranInModificare);
            this.txtEmailClient.AllowModification(this.lEcranInModificare);
            this.txtPaginaWebClient.AllowModification(this.lEcranInModificare);
            this.txtTelefonFixClient.AllowModification(this.lEcranInModificare);
            this.txtTelefonMobilClient.AllowModification(this.lEcranInModificare);
            this.txtFaxClient.AllowModification(this.lEcranInModificare);
            this.txtSkypeClient.AllowModification(this.lEcranInModificare);
            this.txtObservatiiClient.AllowModification(this.lEcranInModificare);
        }

        #endregion


    }
}
