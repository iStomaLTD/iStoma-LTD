using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;
using CCL.iStomaLab;
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
//using static iStomaLab.TablouDeBord.Clienti.ControlCreareClient;

namespace iStomaLab.TablouDeBord.Clienti
{
    public partial class FormCreareClient : FormPersonalizat
    {

        #region Declaratii generale

        public static EnumPanelDeAfisat _SPanelDeAfisat = EnumPanelDeAfisat.ParteaI;

        #endregion

        #region Enumerari si Structuri
        public enum EnumPanelDeAfisat
        {
            ParteaI,
            ParteaII,
            ParteaIII
        }
        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormCreareClient()
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
            this.ctrlValidareAnulare.Validare += CtrlValidareAnulare_Validare;
        }
        
        private void initTextML()
        {
            this.Text = string.Empty;
            this.lblDenumire.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire);
            this.lblTelefonMobil.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TelefonMobil);
            this.lblTelefonFix.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TelefonFix);
            this.lblEmail.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Email);
            this.lblWebSite.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Website);
            this.lblRecomandant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Recomandant);
            this.lblObservatiiDateClinica.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii);
            this.lblDenumireFiscala.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DenumireFiscala);
            this.lblTip.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tip);
            this.lblCUI.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CUI);
            this.lblNrRegCom.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.RegCom);
            this.lblIBAN.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.IBAN);
            this.lblBanca.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Banca);
            this.lblReprezentantLegal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ReprezentantLegal);
            this.lblInCalitateDe.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.InCalitateDe);
            this.lblNrContract.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrContract);
            this.lblDataContract.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataContract);
            this.lblObservatiiDateFirma.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii);
            this.lblAgent.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Agent);
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

            _SPanelDeAfisat = EnumPanelDeAfisat.ParteaI;       
            
            this.panelDateClinica.Visible = true;
            this.panelDateClinica.BringToFront();

            this.ctrlAgent.Initializeaza();
            this.txtDenumire.Goleste();
            this.txtTelefonMobil.Goleste();
            this.txtTelefonFix.Goleste();
            this.txtEmail.Goleste();
            this.txtWebsite.Goleste();
            this.ctrlCautareRecomandant.Initializeaza(StructIdDenumire.Empty, CEnumerariComune.EnumTipDeschidere.DreaptaJos);
            this.txtObservatiiDateClinica.Goleste();
            this.txtDenumireFiscala.Goleste();
            this.txtCUI.Goleste();
            this.txtNrRegCom.Goleste();
            this.txtIBAN.Goleste();
            this.ctrlCautareBanca.Initializeaza(StructIdDenumire.Empty, CEnumerariComune.EnumTipDeschidere.DreaptaJos);
            this.txtReprezentantLegal.Goleste();
            this.txtNrContract.Goleste();
            this.txtNrContract.MaxLength = BClienti.StructCampuriTabela.NrContractMaxLength;
            this.ctrlAlegeDataContract.Goleste();
            this.txtObservatiiDateFirma.Goleste();

            this.lblRecomandant.Visible = false;
            this.ctrlCautareRecomandant.Visible = false;
            this.lblAgent.Visible = false;
            this.ctrlAgent.Visible = false;

            initListe();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void CtrlValidareAnulare_Validare(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (this.StabilestePanelDeAfisat())
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

        #endregion

        #region Metode private
        private void initListe()
        {
            this.cboCalitateReprezentant.DataSource = BDefinitiiGenerale.StructCalitateReprezentant.getListaRolCuEmpty();
            this.cboTipClient.DataSource = BDefinitiiGenerale.StructTipFiscalitate.GetListaTipFiscalitate();

            this.cboCalitateReprezentant.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboTipClient.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private bool esteValidaParteaI()
        {
            return !string.IsNullOrEmpty(this.txtDenumire.Text);
        }

        private void seteazaAlerte()
        {
            IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.txtDenumire, this.lblDenumire);
            this.txtDenumire.Focus();
        }
        #endregion

        #region Metode publice
         
        public static bool Afiseaza(Form pEcranPariente)
        {
            using (FormCreareClient ecran = new FormCreareClient())
            {
                ecran.AplicaPreferinteleUtilizatorului();
                return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
            }
        }

        internal bool StabilestePanelDeAfisat()
        {
            if (FormCreareClient._SPanelDeAfisat == EnumPanelDeAfisat.ParteaI)
            {
                if (esteValidaParteaI())
                {
                    this.panelDateFirma.Visible = true;
                    this.panelDateFirma.BringToFront();
                    FormCreareClient._SPanelDeAfisat = EnumPanelDeAfisat.ParteaII;
                }
                else
                {
                    seteazaAlerte();
                }
            }
            else if (FormCreareClient._SPanelDeAfisat == EnumPanelDeAfisat.ParteaII)
            {
                FormCreareClient._SPanelDeAfisat = EnumPanelDeAfisat.ParteaIII;
                if (Salveaza())
                    return true;
            }
            return false;
        }

        internal bool Salveaza()
        {
            bool esteOk = BClienti.SuntInformatiileNecesareCoerente(this.txtDenumire.Text);

            if (esteOk)
            {
                BClienti.Add(this.txtDenumire.Text, this.cboTipClient.SelectedIndex, this.txtDenumireFiscala.Text, this.txtCUI.Text, this.txtNrRegCom.Text, this.txtTelefonMobil.Text, this.txtTelefonFix.Text, string.Empty, string.Empty, this.txtEmail.Text, this.txtWebsite.Text, this.txtObservatiiDateClinica.Text, this.ctrlCautareRecomandant.TipObiectAfisajCorespunzator, this.ctrlCautareRecomandant.IdObiectAfisajCorespunzator, this.txtIBAN.Text, this.ctrlCautareBanca.IdObiectAfisajCorespunzator, this.txtReprezentantLegal.Text, this.cboCalitateReprezentant.SelectedIndex, CUtil.GetAsInt32(this.txtNrContract.Text), this.ctrlAlegeDataContract.DataAfisata, this.txtObservatiiDateFirma.Text, this.ctrlAgent.GetIdTehnician(), null);
            }
            else
            {
                seteazaAlerte();
            }

            return esteOk;
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
