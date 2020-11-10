using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iStomaLab.Generale;
using BLL.iStomaLab.Locatii;
using BLL.iStomaLab;
using CCL.iStomaLab;
using CCL.iStomaLab.Utile;
using System.IO;
using BLL.iStomaLab.Referinta;
using CCL.UI;
using static BLL.iStomaLab.BDefinitiiGenerale;

namespace iStomaLab.Setari.Locatii
{
    public partial class ControlDetaliuLocatie : UserControlPersonalizat
    {

        #region Declaratii generale

        BLocatii lLocatie = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlDetaliuLocatie()
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
            this.btnDocumentLocatie.Click += BtnDocumentLocatie_Click;
            this.btnStergeLogoLocatie.Click += BtnStergeLogoLocatie_Click;
            this.cboTipLocatie.Enter += CboTipLocatie_Enter;
        }

        private void initTextML()
        {
            this.lblInformatiiGeneraleLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.InformatiiGenerale);
            this.lblDenumireLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire);
            this.lblInitialaLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Initiala);
            this.lblTipLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tip);
            this.lblLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Locatie);
            this.lblCuloareLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Culoare);
            this.lblInfoContactLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.InfoContact);
            this.lblMailLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Email);
            this.lblSkypeLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Skype);
            this.lblFaxLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Fax);
            this.lblTelefonMobilLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TelefonMobil);
            this.lblContYMLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ContYM);
            this.lblPaginaWebLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PaginaWeb);
            this.lblInformatiiFiscaleLocatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.InformatiiFiscale);
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
        }

        public void Initializeaza(BLocatii pLocatie)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.lLocatie = pLocatie;
            initListe();

            if (this.lLocatie == null)
            {
                this.txtDenumireLocatie.Goleste();
                this.txtInitialaLocatie.Goleste();
                this.txtLocatie.Goleste();
                this.ctrlGestiuneCuloareLocatie.Goleste();
                this.txtInfoContactLocatie.Goleste();
                this.txtMailLocatie.Goleste();
                this.txtSkypeLocatie.Goleste();
                this.txtFaxLocatie.Goleste();
                this.txtTelefonMobilLocatie.Goleste();
                this.txtContYMLocatie.Goleste();
                this.txtPaginaWebLocatie.Goleste();
                this.txtDenumireFiscalaLocatie.Goleste();
                this.chkTvaLocatie.Checked = false;
                this.rbCmiLocatie.Checked = false;
                this.rbSrlLocatie.Checked = false;
                this.txtCodFiscalLocatie.Goleste();
                this.txtNrInregistrareLocatie.Goleste();
                this.txtIbanLocatie.Goleste();
                this.txtIbanLocatie.CapitalizeazaPrimaLitera = true;
                this.txtCalitateReprezentantLocatie.CapitalizeazaPrimaLitera = true;
                this.txtBancaLocatie.Goleste();
                this.txtReprezentantLegalLocatie.Goleste();
                this.txtCalitateReprezentantLocatie.Goleste();
                this.txtSerieChitanteLocatie.Goleste();
                this.txtNrUltimaChitantaLocatie.Goleste();
                this.txtSerieFacturiLocatie.Goleste();
                this.txtNrUltimaFacturaLocatie.Goleste();
            }
            else
            {
                this.txtDenumireLocatie.Text = pLocatie.Denumire;
                this.txtInitialaLocatie.Text = pLocatie.InitialaLocatie;
                this.cboTipLocatie.SelectedIndex = pLocatie.TipLocatie;
                this.ctrlGestiuneCuloareLocatie.Initializeaza(pLocatie.Culoare);
                this.txtInfoContactLocatie.Text = pLocatie.InfoContact;
                this.txtMailLocatie.Text = pLocatie.AdresaMail;
                this.txtSkypeLocatie.Text = pLocatie.ContSkype;
                this.txtFaxLocatie.Text = pLocatie.Fax;
                this.txtTelefonMobilLocatie.Text = pLocatie.TelefonMobil;
                this.txtContYMLocatie.Text = pLocatie.ContYM;
                this.txtPaginaWebLocatie.Text = pLocatie.PaginaWeb;
                if (!string.IsNullOrEmpty(this.lLocatie.Logo))
                    this.picLogoLocatie.Image = CCL.UI.Imagini.GetThumbnailImage(CCL.UI.IHMUtile.getImagineDinFisier(lLocatie.Logo), 90, 90, true);
                this.txtDenumireFiscalaLocatie.Text = pLocatie.DenumireFiscala;
                this.chkTvaLocatie.Checked = pLocatie.PlatitorDeTVA;
                this.rbCmiLocatie.Checked = pLocatie.TipFiscalitate == 1 ? true : false;
                this.rbSrlLocatie.Checked = pLocatie.TipFiscalitate == 2 ? true : false;
                this.txtCodFiscalLocatie.Text = pLocatie.CodFiscal;
                this.txtNrInregistrareLocatie.Text = pLocatie.NumarInregistrare;
                this.txtIbanLocatie.Text = pLocatie.ContIBAN;
                this.txtBancaLocatie.Text = pLocatie.DenumireBanca;
                this.txtReprezentantLegalLocatie.Text = pLocatie.ReprezentantLegal;
                this.txtCalitateReprezentantLocatie.Text = pLocatie.CalitateReprezentantLegal;
                this.txtSerieChitanteLocatie.Text = pLocatie.SerieChitante;
                this.txtNrUltimaChitantaLocatie.Text = pLocatie.NumarUltimaChitanta.ToString();
                this.txtSerieFacturiLocatie.Text = pLocatie.SerieFacturi;
                this.txtNrUltimaFacturaLocatie.Text = pLocatie.NumarUltimaFactura.ToString();
            }

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void CboTipLocatie_Enter(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.cboTipLocatie.DroppedDown = true;
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
            Image image = CCL.UI.IHMUtile.getImagineDinFisier(GetCaleSalvareFisier(null));
            this.picLogoLocatie.Image = CCL.UI.Imagini.GetThumbnailImage(image, 90, 90, true);
        }

        private void BtnStergeLogoLocatie_Click(object sender, EventArgs e)
        {
            if (this.picLogoLocatie.Image != null)
            {

            }
        }

        #endregion

        #region Metode private

        private void initListe()
        {
            this.cboTipLocatie.DataSource = BDefinitiiGenerale.StructTipLocatie.getListaLocatii();
            this.cboTipLocatie.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private int getTipFiscalitate()
        {
            if (this.rbCmiLocatie.Checked)
                return (int)EnumTipFiscalitate.CMI;
            else if (this.rbSrlLocatie.Checked)
                return (int)EnumTipFiscalitate.SRL;
            return (int)EnumTipFiscalitate.Nedefinit;
        }

        private string GetCaleSalvareFisier(string pExtensie)
        {
            string caleLogoSediu = "";

            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = string.Concat(pExtensie, "|", pExtensie, "|All Files (*.*)|*.*");
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            caleLogoSediu = openFileDialog1.FileName;
                        }
                    }
                }
                catch (Exception ex)
                {
                    GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
                }
            }
            this.picLogoLocatie.ImageLocation = caleLogoSediu;

            return caleLogoSediu;
        }

        private void seteazaAlerta()
        {
            IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.txtDenumireLocatie, this.lblDenumireLocatie);
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.cboTipLocatie, this.lblTipLocatie);
            seteazaFocus();
        }

        private void seteazaFocus()
        {
            Control[] lstFocus = { this.txtDenumireLocatie, this.cboTipLocatie };
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

        internal bool Salveaza()
        {
            bool esteValid = BLocatii.SuntInformatiileNecesareCoerente(this.txtDenumireLocatie.Text, this.cboTipLocatie.SelectedIndex);
            if (this.lLocatie == null)
            {
                if (esteValid)
                {
                    BLocatii.Add(this.txtDenumireLocatie.Text, this.cboTipLocatie.SelectedIndex, 0, 0, 0, 0, 0, this.txtTelefonMobilLocatie.Text, this.txtFaxLocatie.Text, this.txtSkypeLocatie.Text, this.txtContYMLocatie.Text, this.txtMailLocatie.Text, this.txtPaginaWebLocatie.Text, this.txtInfoContactLocatie.Text, this.picLogoLocatie.ImageLocation, 0, this.txtDenumireFiscalaLocatie.Text, getTipFiscalitate(), this.txtCodFiscalLocatie.Text, this.txtNrInregistrareLocatie.Text, this.txtIbanLocatie.Text, this.txtBancaLocatie.Text, this.txtReprezentantLegalLocatie.Text, this.txtCalitateReprezentantLocatie.Text, this.txtSerieChitanteLocatie.Text, CUtil.GetAsInt32(this.txtNrInregistrareLocatie.Text), this.txtSerieFacturiLocatie.Text, 0, this.chkTvaLocatie.Checked, this.txtInitialaLocatie.Text, 0, this.ctrlGestiuneCuloareLocatie.CuloareARGB, null);
                }
                else
                {
                    seteazaAlerta();
                }
            }
            else
            {
                this.lLocatie.Denumire = this.txtDenumireLocatie.Text;
                this.lLocatie.InitialaLocatie = this.txtInitialaLocatie.Text;
                this.lLocatie.TipLocatie = this.cboTipLocatie.SelectedIndex;
                this.lLocatie.Culoare = this.ctrlGestiuneCuloareLocatie.CuloareARGB;
                this.lLocatie.InfoContact = this.txtInfoContactLocatie.Text;
                this.lLocatie.AdresaMail = this.txtMailLocatie.Text;
                this.lLocatie.ContSkype = this.txtSkypeLocatie.Text;
                this.lLocatie.Fax = this.txtFaxLocatie.Text;
                this.lLocatie.ContYM = this.txtContYMLocatie.Text;
                this.lLocatie.PaginaWeb = this.txtPaginaWebLocatie.Text;
                this.lLocatie.TelefonMobil = this.txtTelefonMobilLocatie.Text;
                this.lLocatie.DenumireFiscala = this.txtDenumireFiscalaLocatie.Text;
                this.lLocatie.Logo = this.picLogoLocatie.ImageLocation;
                this.lLocatie.TipFiscalitate = getTipFiscalitate();
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
            this.txtDenumireLocatie.AllowModification(this.lEcranInModificare);
            this.txtInitialaLocatie.AllowModification(this.lEcranInModificare);
            this.cboTipLocatie.AllowModification(this.lEcranInModificare);
            this.txtLocatie.AllowModification(this.lEcranInModificare);
            this.ctrlGestiuneCuloareLocatie.AllowModification(this.lEcranInModificare);
            this.txtInfoContactLocatie.AllowModification(this.lEcranInModificare);
            this.txtMailLocatie.AllowModification(this.lEcranInModificare);
            this.txtSkypeLocatie.AllowModification(this.lEcranInModificare);
            this.txtFaxLocatie.AllowModification(this.lEcranInModificare);
            this.txtTelefonMobilLocatie.AllowModification(this.lEcranInModificare);
            this.txtContYMLocatie.AllowModification(this.lEcranInModificare);
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
