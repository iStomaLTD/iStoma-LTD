using BLL.iStomaLab;
using BLL.iStomaLab.Comune;
using BLL.iStomaLab.Locatii;
using CCL.iStomaLab;
using CCL.UI;
using iStomaLab.Generale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BLL.iStomaLab.BDefinitiiGenerale;

namespace iStomaLab.Setari.Locatii
{
    public partial class FormDetaliuLocatie : FormPersonalizat
    {

        #region Declaratii generale

        private BLocatii lLocatie = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormDetaliuLocatie(BLocatii pLocatie)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.picLogoLocatie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.lLocatie = pLocatie;

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

            this.btnDocumentLocatie.Click += BtnDocumentLocatie_Click;
            this.btnStergeLogoLocatie.Click += BtnStergeLogoLocatie_Click;

            this.ctrlValidareAnulareLocatie.Validare += CtrlValidareAnulareLocatie_Validare;
        }

        private void initTextML()
        {
            this.Text = string.Empty;

            this.lblAdresa.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Adresa);
            this.lblDenumireLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire);
            this.lblMailLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Email);
            this.lblSkypeLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Skype);
            this.lblFaxLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Fax);
            this.lblTelefonMobilLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TelefonMobil);
            this.lblPaginaWebLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PaginaWeb);
            this.lblDenumireFiscalaLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DenumireFiscala);
            this.lblLogoLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Logo);
            this.lblDimensiuniLogoLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DimensiuneLogo);
            this.rbCmiLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CMI);
            this.rbSrlLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.SRL);
            this.chkTvaLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TVA);
            this.lblCodFiscalLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CodFiscal);
            this.lblNrInregistrareLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrInregistrare);
            this.lblIbanLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.IBAN);
            this.lblBancaLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Banca);
            this.lblReprezentantLegalLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ReprezentantLegal);
            this.lblCalitateReprezentantLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Calitate);
            this.lblSerieChitanteLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.SerieChitante);
            this.lblNrUltimaChitantaLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrUltimaChitanta);
            this.lblSerieFacturiLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.SerieFacturi);
            this.lblNrUltimaFacturaLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrUltimaFactura);

            this.rbCmiLocatie.Visible = false;
            this.rbSrlLocatie.Visible = false;
            this.chkTvaLocatie.Visible = false;
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

            this.txtDenumireLocatie.Text = this.lLocatie.Denumire;
            this.txtMailLocatie.Text = this.lLocatie.AdresaMail;
            this.txtSkypeLocatie.Text = this.lLocatie.ContSkype;
            this.txtFaxLocatie.Text = this.lLocatie.Fax;
            this.txtTelefonMobilLocatie.Text = this.lLocatie.TelefonMobil;
            this.txtPaginaWebLocatie.Text = this.lLocatie.PaginaWeb;
            this.txtDenumireFiscalaLocatie.Text = this.lLocatie.DenumireFiscala;
            this.chkTvaLocatie.Checked = this.lLocatie.PlatitorDeTVA;
            this.rbCmiLocatie.Checked = this.lLocatie.TipFiscalitate == 1 ? true : false;
            this.rbSrlLocatie.Checked = this.lLocatie.TipFiscalitate == 2 ? true : false;
            this.txtCodFiscalLocatie.Text = this.lLocatie.CodFiscal;
            this.txtNrInregistrareLocatie.Text = this.lLocatie.NumarInregistrare;
            this.txtIbanLocatie.Text = this.lLocatie.ContIBAN;
            this.txtBancaLocatie.Text = this.lLocatie.DenumireBanca;
            this.txtReprezentantLegalLocatie.Text = this.lLocatie.ReprezentantLegal;
            this.txtCalitateReprezentantLocatie.Text = this.lLocatie.CalitateReprezentantLegal;
            this.txtSerieChitanteLocatie.Text = this.lLocatie.SerieChitante;
            this.txtNrUltimaChitantaLocatie.Text = this.lLocatie.NumarUltimaChitanta.ToString();
            this.txtSerieFacturiLocatie.Text = this.lLocatie.SerieFacturi;
            this.txtNrUltimaFacturaLocatie.Text = this.lLocatie.NumarUltimaFactura.ToString();

            this.ctrlAdresa.Initializeaza(this.lLocatie.GetAdresa(null), this.lLocatie.TipObiect, this.lLocatie.Id, BAdrese.EnumTipAdresa.SediuSocial);

            initLogoSediu();

            finalizeazaIncarcarea();
        }

        private void initLogoSediu()
        {
            Image logo = this.lLocatie.GetLogoSediu(null); 
            this.picLogoLocatie.Image = logo;

            this.btnStergeLogoLocatie.Visible = logo != null;
        }

        #endregion

        #region Evenimente

        private void CtrlValidareAnulareLocatie_Validare(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (this.Salveaza())
                    inchideEcranulOK();
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

        private void BtnDocumentLocatie_Click(object sender, EventArgs e)
        {
            FileInfo imagine = IHMUtile.GetFisierUnic(this.GetFormParinte());

            if (imagine != null)
            {
                this.lLocatie.UpdateLogoSediu(imagine, null);
                initLogoSediu();
            }
        }

        private void BtnStergeLogoLocatie_Click(object sender, EventArgs e)
        {
            if (this.picLogoLocatie.Image != null)
            {
                if (IHMUtile.ConfirmareStergere(this.GetFormParinte()))
                {
                    this.lLocatie.StergeLogoSediu(null);
                    initLogoSediu();
                }
            }
        }

        #endregion

        #region Metode private

        private EnumTipFiscalitate getTipFiscalitate()
        {
            return EnumTipFiscalitate.SRL;

            //if (this.rbCmiLocatie.Checked)
            //    return (int)EnumTipFiscalitate.CMI;
            //else if (this.rbSrlLocatie.Checked)
            //    return (int)EnumTipFiscalitate.SRL;

            //return (int)EnumTipFiscalitate.Nedefinit;
        }

        private void seteazaAlerta()
        {
            IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.txtDenumireLocatie, this.lblDenumireLocatie);
            seteazaFocus();
        }

        private void seteazaFocus()
        {
            Control[] lstFocus = { this.txtDenumireLocatie };
            foreach (var control in lstFocus)
            {
                if (string.IsNullOrEmpty(control.Text))
                {
                    control.Focus();
                    break;
                }
            }
        }

        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente, BLocatii pLocatie)
        {
            if (pLocatie == null)
            {
                string denumire = CCL.UI.IHMUtile.GetTextSimpluUtilizator(pEcranPariente, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire), BLocatii.StructCampuriTabela.DenumireMaxLength);

                if (string.IsNullOrEmpty(denumire))
                    return false;
                else
                {
                    int idLocatieAdaugata = BLocatii.Add(denumire, null);

                    pLocatie = new BLocatii(idLocatieAdaugata, null);
                }
            }

            using (FormDetaliuLocatie ecran = new FormDetaliuLocatie(pLocatie))
            {
                ecran.AplicaPreferinteleUtilizatorului();
                return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
            }
        }

        internal bool Salveaza()
        {
            bool esteValid = BLocatii.SuntInformatiileNecesareCoerente(this.txtDenumireLocatie.Text, 1);
            if (this.lLocatie == null)
            {
                if (esteValid)
                {
                    BLocatii.Add(this.txtDenumireLocatie.Text, BLocatii.EnumTipLocatie.Sediu, 0, 0, 0, 0, 0, this.txtTelefonMobilLocatie.Text, this.txtFaxLocatie.Text, this.txtSkypeLocatie.Text, string.Empty, this.txtMailLocatie.Text, this.txtPaginaWebLocatie.Text, string.Empty, this.picLogoLocatie.ImageLocation, 0, this.txtDenumireFiscalaLocatie.Text, getTipFiscalitate(), this.txtCodFiscalLocatie.Text, this.txtNrInregistrareLocatie.Text, this.txtIbanLocatie.Text, this.txtBancaLocatie.Text, this.txtReprezentantLegalLocatie.Text, this.txtCalitateReprezentantLocatie.Text, this.txtSerieChitanteLocatie.Text, CUtil.GetAsInt32(this.txtNrInregistrareLocatie.Text), this.txtSerieFacturiLocatie.Text, 0, this.chkTvaLocatie.Checked, string.Empty, 0, 0, null);
                }
                else
                {
                    seteazaAlerta();
                }
            }
            else
            {
                this.lLocatie.Denumire = this.txtDenumireLocatie.Text;
                this.lLocatie.AdresaMail = this.txtMailLocatie.Text;
                this.lLocatie.ContSkype = this.txtSkypeLocatie.Text;
                this.lLocatie.Fax = this.txtFaxLocatie.Text;
                this.lLocatie.PaginaWeb = this.txtPaginaWebLocatie.Text;
                this.lLocatie.TelefonMobil = this.txtTelefonMobilLocatie.Text;
                this.lLocatie.DenumireFiscala = this.txtDenumireFiscalaLocatie.Text;
                this.lLocatie.Logo = this.picLogoLocatie.ImageLocation;
                //this.lLocatie.TipFiscalitate = getTipFiscalitate();
                this.lLocatie.PlatitorDeTVA = this.chkTvaLocatie.Checked;
                this.lLocatie.CodFiscal = this.txtCodFiscalLocatie.Text;
                this.lLocatie.NumarInregistrare = this.txtNrInregistrareLocatie.Text;
                this.lLocatie.ContIBAN = this.txtIbanLocatie.Text;
                this.lLocatie.DenumireBanca = this.txtBancaLocatie.Text;
                this.lLocatie.ReprezentantLegal = this.txtReprezentantLegalLocatie.Text;
                this.lLocatie.CalitateReprezentantLegal = this.txtCalitateReprezentantLocatie.Text;
                this.lLocatie.SerieChitante = this.txtSerieChitanteLocatie.Text;
                this.lLocatie.NumarUltimaChitanta = CUtil.GetAsInt32(this.txtNrUltimaChitantaLocatie.Text);
                this.lLocatie.SerieFacturi = this.txtSerieFacturiLocatie.Text;
                this.lLocatie.NumarUltimaFactura = CUtil.GetAsInt32(this.txtNrUltimaFacturaLocatie.Text);
                if (esteValid)
                {
                    this.lLocatie.UpdateAll();
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

            this.ctrlAdresa.AllowModification(this.lEcranInModificare);
            this.txtDenumireLocatie.AllowModification(this.lEcranInModificare);
            this.txtMailLocatie.AllowModification(this.lEcranInModificare);
            this.txtSkypeLocatie.AllowModification(this.lEcranInModificare);
            this.txtFaxLocatie.AllowModification(this.lEcranInModificare);
            this.txtTelefonMobilLocatie.AllowModification(this.lEcranInModificare);
            this.txtPaginaWebLocatie.AllowModification(this.lEcranInModificare);
            this.txtDenumireFiscalaLocatie.AllowModification(this.lEcranInModificare);
            this.chkTvaLocatie.AllowModification(this.lEcranInModificare);
            this.rbCmiLocatie.AllowModification(this.lEcranInModificare);
            this.rbSrlLocatie.AllowModification(this.lEcranInModificare);
            this.txtCodFiscalLocatie.AllowModification(this.lEcranInModificare);
            this.txtNrInregistrareLocatie.AllowModification(this.lEcranInModificare);
            this.txtIbanLocatie.AllowModification(this.lEcranInModificare);
            this.txtBancaLocatie.AllowModification(this.lEcranInModificare);
            this.txtReprezentantLegalLocatie.AllowModification(this.lEcranInModificare);
            this.txtCalitateReprezentantLocatie.AllowModification(this.lEcranInModificare);
            this.txtSerieChitanteLocatie.AllowModification(this.lEcranInModificare);
            this.txtNrUltimaChitantaLocatie.AllowModification(this.lEcranInModificare);
            this.txtSerieFacturiLocatie.AllowModification(this.lEcranInModificare);
            this.txtNrUltimaFacturaLocatie.AllowModification(this.lEcranInModificare);
        }

        #endregion


    }
}
