using BLL.iStomaLab;
using CCL.iStomaLab;
using iStomaLab.Generale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iStomaLab.Imprimare
{
    public partial class FormImprimaWebBrowser : FormPersonalizat
    {

        #region Declaratii generale

        private string lBody;
        private string lSubiect;
        private int lIdSediu = 3;
        //private IContact lContact = null;
        private bool? lImprimaLogo = null;
        private bool lFolosesteCSSTabel = true;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormImprimaWebBrowser(string pSubiect, string pBody, int pIdSediu, bool? pImprimaLogo, bool pFolosesteCSSTabel)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lSubiect = pSubiect;
            this.lBody = pBody;
            this.lIdSediu = pIdSediu;
            //this.lContact = pContact;
            this.lImprimaLogo = pImprimaLogo;
            this.lFolosesteCSSTabel = pFolosesteCSSTabel;

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                adaugaHandlere();
                initTextML();

                this.CentratCuDeplasare();
            }
        }

        private void adaugaHandlere()
        {
            this.Load += FormImprimaWebBrowser_Load;
            this.btnImprima.Click += BtnImprima_Click;
            this.btnTrimitePeMail.Click += BtnTrimitePeMail_Click;
            this.chkImprimaLogo.CheckedChanged += ChkImprimaLogo_CheckedChanged;
        }

        private void initTextML()
        {
            this.Text = string.Empty;
            this.chkImprimaLogo.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.FolosesteLogo);
            this.btnImprima.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Imprimare);
        }

        void FormImprimaWebBrowser_Load(object sender, EventArgs e)
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

            if (this.lImprimaLogo.HasValue)
                this.chkImprimaLogo.Checked = this.lImprimaLogo.Value;
            //else
            //    this.chkImprimaLogo.Checked = BComportamentAplicatie.GetImprimareLogoConsimtamantInformat();

            this.wbContinut.Initializeaza(CUtil.GetHTMLImprimare(this.lBody,  string.Empty));

            this.btnTrimitePeMail.Visible = false;// this.lContact != null;

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void ChkImprimaLogo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //BComportamentAplicatie.SetImprimareLogoConsimtamantInformat(this.chkImprimaLogo.Checked);

                Initializeaza();
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        private void BtnTrimitePeMail_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                //IHMUtile.TrimiteEmail(this, null, null, this.lSubiect, this.lBody, false);
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

        private void BtnImprima_Click(object sender, EventArgs e)
        {
            try
            {
                incepeIncarcarea();

                this.wbContinut.ShowPrintPreviewDialog();
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



        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranParinte, string pBody, int pIdSediu, bool? pImprimaLogo, bool pFolosesteCSSTabel)
        {
            return Afiseaza(pEcranParinte,  string.Empty, pBody, pIdSediu, pImprimaLogo, pFolosesteCSSTabel);
        }

        public static bool Afiseaza(Form pEcranParinte, string pBody, int pIdSediu, bool? pImprimaLogo)
        {
            return Afiseaza(pEcranParinte, string.Empty, pBody, pIdSediu, pImprimaLogo, true);
        }

        public static bool Afiseaza(Form pEcranParinte, string pSubiect, string pBody, int pIdSediu, bool? pImprimaLogo, bool pFolosesteCSSTabel)
        {
            using (FormImprimaWebBrowser ecran = new FormImprimaWebBrowser(pSubiect, pBody, pIdSediu, pImprimaLogo, pFolosesteCSSTabel))
            {
                ecran.AplicaPreferinteleUtilizatorului();
                return CCL.UI.IHMUtile.DeschideEcran(pEcranParinte, ecran);
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
