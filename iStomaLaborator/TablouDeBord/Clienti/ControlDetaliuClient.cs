using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab;
using CCL.UI;
using BLL.iStomaLab.Comune;
using BLL.iStomaLab.Referinta;

namespace iStomaLab.TablouDeBord.Clienti
{
    public partial class ControlDetaliuClient : Generale.UserControlPersonalizat
    {

        #region Declaratii generale

        private BClienti lClient = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlDetaliuClient()
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
            this.btnSediuClient.Click += BtnSediuClient_Click;
        }
        
        private void initTextML()
        {
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

        public void Initializeaza(BClienti pClient)
        {
            base.InitializeazaVariabileleGenerale();
            this.lClient = pClient;

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
                this.txtObservatiiClient.Text = this.lClient.Observatii;
               // this.txtAdresaClient.Text = BAdrese.DetaliiAdresa(BAdrese.getAdresaByIdProprietar(this.lClient.Id, null));
                this.cboTipClient.SelectedIndex = this.lClient.TipClient;
            }

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

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

        internal bool Salveaza()
        {
            bool esteValid = BClienti.SuntInformatiileNecesareCoerente(this.txtDenumireClient.Text);

            if (this.lClient == null)
            {
                if (esteValid)
                {
                    BClienti.Add(this.txtDenumireClient.Text, this.cboTipClient.SelectedIndex, this.txtDenumireFiscalaClient.Text, this.txtCUIClient.Text, this.txtRegComClient.Text, this.txtTelefonMobilClient.Text, this.txtTelefonFixClient.Text,
                    this.txtFaxClient.Text, this.txtSkypeClient.Text, this.txtEmailClient.Text, this.txtPaginaWebClient.Text, this.txtObservatiiClient.Text, 0, 0, null);
                }
                else
                {
                    seteazaAlerta();
                }
            }
            else
            {
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
                this.lClient.Observatii = this.txtObservatiiClient.Text;
                this.lClient.TipClient = this.cboTipClient.SelectedIndex;

                if (esteValid)
                {
                    this.lClient.UpdateAll();
                }
                else
                {
                    seteazaAlerta();
                }
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
