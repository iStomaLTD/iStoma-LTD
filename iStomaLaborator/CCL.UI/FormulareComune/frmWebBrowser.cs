using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCL.UI.Interfete;
using System.Text.RegularExpressions;
using ILL.iStomaLab;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using CCL.iStomaLab.Utile;
using CCL.iStomaLab;

namespace CCL.UI
{

    [System.Runtime.InteropServices.ComVisible(true)]
    [System.Runtime.InteropServices.ClassInterface(System.Runtime.InteropServices.ClassInterfaceType.None)]
    public partial class frmWebBrowser : FormulareComune.frmCuHeader, IGestiuneEvenimenteWebBrowser
    {
        #region Declaratii generale

        [DllImport("KERNEL32.DLL", EntryPoint = "SetProcessWorkingSetSize", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool SetProcessWorkingSetSize(IntPtr pProcess, int dwMinimumWorkingSetSize, int dwMaximumWorkingSetSize);

        [DllImport("KERNEL32.DLL", EntryPoint = "GetCurrentProcess", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern IntPtr GetCurrentProcess();

        private bool _bEcranInModificare;
        private string _AdresaWeb;
        private bool lPermiteSalvareaImaginii = false;
        private string lTextDeCautat = string.Empty;
        private bool lSalveazaDetaliiYouTube = false;
        private bool lSalveazaLinkFacebook = false;

        public event System.EventHandler SalvareExterna;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati

        public FileInfo ImagineSalvata { get; private set; }
        public string AdresaWeb { get { return this._AdresaWeb; } }

        #endregion

        #region Constructor si Initializare

        public frmWebBrowser()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            this.PermiteDeplasareaEcranului = true;
            this.PermiteMaximizareaEcranului = true;
            this.btnSalveazaImaginea.Visible = false; //Acesta va fi vizibil doar dupa incarcarea paginii (in caz de nevoie)
            this.btnLinkToFacebook.Visible = false; //Acesta va fi vizibil doar dupa incarcarea paginii (in caz de nevoie)
            this.Text = "iStoma";
        }

        public frmWebBrowser(Size pMarimeEcran)
            : this()
        {
            this.MinimumSize = pMarimeEcran;
        }

        public frmWebBrowser(string pAdresa)
            : this(pAdresa, false, false)
        {
        }

        public frmWebBrowser(string pAdresa, bool pPermiteSalvareaImaginii, bool pPermiteSalvareaLinkului)
            : this()
        {
            this._AdresaWeb = pAdresa;
            this.lPermiteSalvareaImaginii = pPermiteSalvareaImaginii;
            this.lSalveazaLinkFacebook = pPermiteSalvareaLinkului;
        }

        private void frmWebBrowser_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_AdresaWeb))
                this.wbBrowser.Navigate(this._AdresaWeb);
            this.wbBrowser.ObjectForScripting = this;
        }

        #endregion

        #region Evenimente

        private void wbBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.btnSalveazaImaginea.Visible = this.lPermiteSalvareaImaginii;
            this.btnLinkToFacebook.Visible = this.lSalveazaLinkFacebook;
        }

        private void btnLinkToFacebook_Click(object sender, EventArgs e)
        {
            try
            {
                this._AdresaWeb = this.wbBrowser.Url.LocalPath;
                inchideEcranul(System.Windows.Forms.DialogResult.Yes);

            }
            catch (Exception ex)
            {
                Mesaj.Afiseaza(this, ex.Message);
            }
        }

        private void btnSalveazaImaginea_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lSalveazaDetaliiYouTube)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();

                    return;
                }
                else
                {
                    StringBuilder htmlImagini = new StringBuilder();
                    //Afisam toate imaginile din link si invitam utilizatorul sa o selecteze pe cea pe care doreste sa o salveze
                    if (!string.IsNullOrEmpty(this.wbBrowser.DocumentText))
                    {
                        List<string> listaLinkuri = FetchLinksFromSource(this.wbBrowser.DocumentText);
                        if (CUtil.EsteListaVida<string>(listaLinkuri))
                        {
                            Mesaj.Informare(this, "Nu au fost identificate imagini în această pagină. Navigați către o altă pagină.", "Imagini");
                        }
                        else
                        {
                            htmlImagini.Append("<html><body>");
                            htmlImagini.Append("<a href='BACK'>&#206;napoi</a>");
                            htmlImagini.Append("<h2>Da&#355;i click pe imaginea dorit&#259; pentru a o salva</h2>");
                            foreach (var linkImagine in listaLinkuri)
                            {
                                htmlImagini.Append(string.Format("<a href='SELIMG|$&$|{0}'><img src='{0}'></img></a>", linkImagine));
                            }
                            htmlImagini.Append("</body></html>");
                        }
                    }

                    //Afisam lista de imagini doar daca aceasta exista
                    if (htmlImagini.Length > 0)
                        this.wbBrowser.DocumentText = htmlImagini.ToString();
                }
            }
            catch (Exception ex)
            {
                Mesaj.Afiseaza(this, ex.Message);
            }
        }

        private void wbBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (this.lSalveazaDetaliiYouTube) return;

            string adresa = e.Url.LocalPath;
            if (adresa.Equals("BACK"))
            {
                e.Cancel = true;
                this.wbBrowser.GoBack();
            }
            else
            {
                if (adresa.StartsWith("SELIMG"))
                {
                    e.Cancel = true;

                    string[] elemente = adresa.Split(new string[] { "|$&$|" }, StringSplitOptions.None);
                    if (elemente.Length > 1)
                    {
                        string linkImagine = elemente[1];

                        if (!string.IsNullOrEmpty(e.Url.Query))
                            linkImagine = string.Concat(linkImagine, e.Url.Query);

                        using (WebClient webClient = new WebClient())
                        {
                            using (Stream stream = webClient.OpenRead(linkImagine))
                            {
                                using (Bitmap bitmap = new Bitmap(stream))
                                {
                                    //Salvam in directorul temporar
                                    string caleDirector = string.Empty;

                                    //Inlocuim anumite caractere din textul cautat pentru a nu influenta calea de salvare
                                    //if (linkImagine.Contains("/"))
                                    //    caleDirector = string.Format("{0}\\{1}_{2}", CCL.General.Utile.CGestiuneIO.GetValoareDupaTipCheie(General.Utile.CGestiuneIO.EnumTipCheie.AdresaDirectorTemporar), this.lTextDeCautat.Replace("\\", "").Replace("/", ""), linkImagine.Substring(linkImagine.LastIndexOf("/") + 1));
                                    //else
                                    caleDirector = string.Format("{0}\\{1}", CCL.iStomaLab.Utile.CGestiuneIO.GetValoareDupaTipCheie(CGestiuneIO.EnumTipCheie.AdresaDirectorTemporar), this.lTextDeCautat.Replace("\\", "").Replace("/", ""), "_fb_", DateTime.Now.ToString("yyyyMMddHHmm"));

                                    stream.Flush();
                                    stream.Close();

                                    System.Drawing.Imaging.ImageFormat formatImagine = System.Drawing.Imaging.ImageFormat.Bmp;
                                    if (caleDirector.Contains(".jpg") || caleDirector.Contains(".jpeg"))
                                        formatImagine = System.Drawing.Imaging.ImageFormat.Jpeg;
                                    else
                                        if (caleDirector.Contains(".png"))
                                        formatImagine = System.Drawing.Imaging.ImageFormat.Png;

                                    bitmap.Save(caleDirector.Replace("/", ""), formatImagine);

                                    this.ImagineSalvata = new FileInfo(caleDirector);

                                    //Inchidem ecranul
                                    inchideEcranul(DialogResult.OK);
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Metode private

        private List<string> FetchLinksFromSource(string htmlSource)
        {
            List<string> links = new List<string>();
            string regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>";
            MatchCollection matchesImgSrc = Regex.Matches(htmlSource, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            string href = string.Empty;
            foreach (Match m in matchesImgSrc)
            {
                href = m.Groups[1].Value;

                //Nu adaugam gif-urile - acestea sunt de obicei imagini locale ale site-urilor
                //Acceptam doar jpg, png si bmp
                //Nu adaugam dubluri
                //Trebuie sa fie link serios (sa inceapa cu http)
                if (!href.EndsWith(".gif") && href.ToUpper().StartsWith("HTTP") && !links.Contains(href) && (href.Contains(".png") || href.Contains(".bmp") || href.Contains(".jpg") || href.Contains(".jpeg")))
                    links.Add(href);
            }
            return links;
        }

        private static string FormateazaTextCautareWeb(string pTextDeCautat)
        {
            return CUtil.InlocuiesteDiacritice(pTextDeCautat).Replace("(", " ").Replace(")", " ").Replace("  ", " ").Trim().Replace(" ", "+");
        }

        #endregion

        #region Metode publice

        public void GestioneazaEvenimentWebBrowser(string pComanda, string pDetalii)
        {
        }

        public void CautaPeFaceBook(string pTextDeCautat, string pTitluEcran, bool pPermiteSalvareaImaginii, bool pLinkToFacebook)
        {
            this.lTextDeCautat = pTextDeCautat;
            this.lPermiteSalvareaImaginii = pPermiteSalvareaImaginii;
            this.lSalveazaLinkFacebook = pLinkToFacebook;

            if (string.IsNullOrEmpty(pTextDeCautat.Trim()))
                this._AdresaWeb = "http://www.facebook.com";
            else
            {
                if (pTextDeCautat.StartsWith("/"))
                {
                    this._AdresaWeb = string.Concat("www.facebook.com", pTextDeCautat);
                }
                else
                {
                    this._AdresaWeb = "http://www.facebook.com/search/results.php?q=" +
                    FormateazaTextCautareWeb(pTextDeCautat);
                }
            }
            this.Text = pTitluEcran;
        }

        public void CautaPeGoogle(string pTextDeCautat)
        {
            this.lTextDeCautat = pTextDeCautat;
            if (string.IsNullOrEmpty(pTextDeCautat.Trim()))
                this._AdresaWeb = "http://www.google.ro";
            else
            {
                this._AdresaWeb = "https://www.google.ro/search?q=" + FormateazaTextCautareWeb(pTextDeCautat);
                //this._AdresaWeb = "http://www.google.ro/#hl=&output=search&q=" + FormateazaTextCautareWeb(pTextDeCautat);
            }
            this.Text = this.lTextDeCautat;
        }

        public void CautarePeWikipedia(string pTextDeCautat)
        {
            this.lTextDeCautat = pTextDeCautat;
            if (string.IsNullOrEmpty(pTextDeCautat.Trim()))
                this._AdresaWeb = "http://ro.wikipedia.org";
            else
                this._AdresaWeb = "http://ro.wikipedia.org/wiki/Special:Search?search=" + FormateazaTextCautareWeb(pTextDeCautat) + "&go=Go";
            this.Text = this.lTextDeCautat;
        }

        public void CautareInDEX(string pTextDeCautat)
        {
            this.lTextDeCautat = pTextDeCautat;
            if (string.IsNullOrEmpty(pTextDeCautat.Trim()))
                this._AdresaWeb = "http://dexonline.ro";
            else
                this._AdresaWeb = "http://dexonline.ro/definitie/" + FormateazaTextCautareWeb(pTextDeCautat) + "&go=Go";
            this.Text = this.lTextDeCautat;
        }

        private void incarcaHTML(string pContinutHTML)
        {
            this.wbBrowser.Initializeaza(pContinutHTML);
        }

        public static void AfiseazaAjutor(Form pEcranParinte, int pIdEcran)
        {
            using (frmWebBrowser instanta = new frmWebBrowser(IHMUtile.GetLinkHelpIStoma(pIdEcran), false, false))
            {
                CCL.UI.IHMUtile.DeschideEcran(pEcranParinte, instanta);
            }
        }

        public static void Afiseaza(Form pEcranParinte, string pContinut)
        {
            using (frmWebBrowser instanta = new frmWebBrowser(new Size(900, 500)))
            {
                instanta.incarcaHTML(pContinut);
                CCL.UI.IHMUtile.DeschideEcran(pEcranParinte, instanta);
            }
        }

        public static Tuple<string, string> CautaVideoPeYouTube(Form pEcranParinte, string pTitluEcran)
        {
            using (frmWebBrowser youtube = new frmWebBrowser(new Size(900, 500)))
            {
                youtube.lSalveazaDetaliiYouTube = true;
                youtube.lPermiteSalvareaImaginii = true; // ca sa ramana butonul vizibil dupa incarcarea paginii
                youtube.btnSalveazaImaginea.Visible = true;
                youtube.btnSalveazaImaginea.Text = "Salvează video";
                youtube.Text = pTitluEcran;
                youtube._AdresaWeb = string.Format("http://www.youtube.com/results?search_query={0}", FormateazaTextCautareWeb(pTitluEcran));

                if (CCL.UI.IHMUtile.DeschideEcran(pEcranParinte, youtube))
                {
                    string path = youtube.wbBrowser.Url.AbsoluteUri;
                    string continut = youtube.wbBrowser.DocumentText;

                    //Extragem id-ul si denumirea
                    if (path.Contains("v="))
                    {
                        string idVideo = string.Empty;
                        string denumireVideo = string.Empty;

                        idVideo = path.Substring(path.LastIndexOf("v=") + 2);
                        int indexTitlu = continut.IndexOf("<title>");

                        if (indexTitlu > 0 && indexTitlu + 20 < continut.Length)
                        {
                            denumireVideo = continut.Substring(indexTitlu + 7, continut.IndexOf("</title>") - (indexTitlu + 7));

                            denumireVideo = denumireVideo.Replace("YouTube - ", "").Trim();
                        }

                        return new Tuple<string, string>(denumireVideo, idVideo);
                    }
                }

                return null;
            }
        }

        public static void AfiseazaVideoYouTube(Form pEcranParinte, string pTitluEcran, string pIdVideoYoutube, int pSecundaStart)
        {
            using (frmWebBrowser youtube = new frmWebBrowser(new Size(900, 500)))
            {
                youtube.Text = pTitluEcran;

                youtube.incarcaHTML(string.Format("<!DOCTYPE html><html style='overflow:hidden;width:100%;height:100%;margin: 0;padding: 0;'><body style='overflow:hidden;background-color:black;width:100%;height:100%;min-height: 100%;'><div style='overflow:hidden;position: fixed;width:853px;height:480px;top: 50%;    left: 50%;    margin-top: -240px;    margin-left: -428px;'><object width='853' height='480'><param name='movie' value='http://www.youtube.com/v/{0}&autoplay=1&start={1}'></param></param><param name='allowFullScreen' value='true'></param><param name='allowScriptAccess' value='always'></param><embed src='http://www.youtube.com/v/{0}&autoplay=1&hl=en_US&feature=player_embedded&version=3&start={1}' type='application/x-shockwave-flash' allowfullscreen='true' allowScriptAccess='always' width='853' height='480'></embed></object></div></body></html>", pIdVideoYoutube, pSecundaStart));
                CCL.UI.IHMUtile.DeschideEcran(pEcranParinte, youtube);
            }
        }

        public new void Dispose()
        {
            this.wbBrowser.Dispose();

            IntPtr pHandle = GetCurrentProcess();
            SetProcessWorkingSetSize(pHandle, -1, -1);

            base.Dispose();
            System.GC.SuppressFinalize(this);
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool bPermiteModificarea)
        {
            this._bEcranInModificare = bPermiteModificarea;
        }

        #endregion

    }
}
