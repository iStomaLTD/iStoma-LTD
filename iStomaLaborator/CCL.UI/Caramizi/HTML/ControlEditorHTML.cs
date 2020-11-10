using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using mshtml;
using CDL.iStomaLab;
using System.Text.RegularExpressions;
using CCL.UI.ControaleSpecializate;
using CCL.iStomaLab.Utile;

namespace CCL.UI.Caramizi.HTML
{
    /// <summary>
    /// http://www.dreamincode.net/forums/topic/48398-creating-a-wysiwyg-html-editor-in-c%23/
    /// HTMLEditor.document.ExecCommand("Bold", false, null);
    /// HTMLEditor.document.ExecCommand("Underline", false, null);
    /// HTMLEditor.document.ExecCommand("Italics", false, null);
    /// HTMLEditor.document.ExecCommand("StrikeThrough", false, null);
    /// HTMLEditor.document.ExecCommand("FontName", false, "Times New Roman");
    /// HTMLEditor.document.ExecCommand("FontName", false, "Arial");
    /// HTMLEditor.document.ExecCommand("FontName", false, "etc.");
    /// HTMLEditor.document.ExecCommand("FontSize", false, "1");
    /// HTMLEditor.document.ExecCommand("FontSize", false, "2");
    /// HTMLEditor.document.ExecCommand("FontSize", false, "3");
    /// HTMLEditor.document.ExecCommand("InsertUnorderedList", false, null);
    /// HTMLEditor.document.ExecCommand("InsertOrderedList", false, null);
    /// HTMLEditor.document.ExecCommand("Cut", false, null);
    /// HTMLEditor.document.ExecCommand("Copy", false, null);
    /// HTMLEditor.document.ExecCommand("Paste", false, null);
    /// HTMLEditor.document.ExecCommand("CreateLink", true, null); 
    /// 
    /// //HERE IS THE WAY TO INSERT YOUR OWN TEXT INTO THE HTML EDITOR:
    /// 
    /// String TEXT = "YOUR TEXT GOES HERE!";
    /// 
    /// IHTMLTxtRange range =
    /// doc.selection.createRange() as IHTMLTxtRange;
    /// range.pasteHTML(TEXT);
    /// range.collapse(false);
    /// range.select();
    /// 
    /// //Recuperare HTML
    /// String SAVECONTENTS = HTMLEditor.DocumentText;
    /// 
    /// 
    /// //Images:
    /// string IMGSRC = "http://www.example.com/example.jpg";
    /// HTMLEditor.document.ExecCommand("InsertImage", false,  IMGSRC);
    /// 
    /// //LINK:
    /// string URL = "http://www.example.com";
    /// string Text = "Example.com";
    /// IHTMLTxtRange range = doc.selection.createRange() as IHTMLTxtRange;
    /// range.pasteHTML("<A href=\"" + URL + "\">" + Text + "</A>");
    /// range.collapse(false);
    /// range.select();
    /// 
    /// 
    /// //HR:
    /// 
    /// HTMLEditor.document.ExecCommand("InsertHorizontalRule", false, null);
    /// 
    /// 
    /// //ALIGN:
    /// 
    /// HTMLEditor.document.ExecCommand("JustifyLeft", false, null);
    /// HTMLEditor.document.ExecCommand("JustifyRight", false, null);
    /// HTMLEditor.document.ExecCommand("JustifyCenter", false, null);
    /// HTMLEditor.document.ExecCommand("JustifyFull", false, null);
    /// </summary>
    [DefaultEvent("Salveaza")]
    public partial class ControlEditorHTML : UserControl
    {

        #region Declaratii generale

        public event System.EventHandler Salveaza;

        private bool lEcranInModificare = false;
        private bool lSeIncarca = false;
        private IHTMLDocument2 lDocHMTL;
        private Dictionary<object, WebBrowserEditabil.EnumComandaHTML> lCorespondentaButonComanda;
        private string lContinutOriginal = string.Empty;

        #endregion

        #region Enumerari si Structuri

        #endregion

        #region Proprietati

        public bool IsContextMenuEnabled { get; set; }

        public override string Text
        {
            get
            {
                if (this.lDocHMTL != null)
                {//Nu avem ce cauta in HTML cu asa ceva
                    string textHTML = this.lDocHMTL.body.innerHTML;
                    if (!string.IsNullOrEmpty(textHTML))
                        textHTML = textHTML.Replace(CConstante.LinieNoua, "");

                    return textHTML;
                }

                return string.Empty;
            }
            set
            {
                if (this.lDocHMTL != null)
                    this.lDocHMTL.body.innerHTML = value;
            }
        }

        [Browsable(false)]
        [DefaultValue(null)]
        public byte[] TextCompresat
        {
            get
            {
                return CGestiuneIO.CompreseazaTextHTML(this.Text);
            }
            set { this.Text = CGestiuneIO.DeCompreseazaText(value); }
        }

        #endregion

        #region Constructor si Initializare

        public ControlEditorHTML()
        {
            this.DoubleBuffered = true;

            InitializeComponent();

            this.lCorespondentaButonComanda = new Dictionary<object, WebBrowserEditabil.EnumComandaHTML>();
            this.lCorespondentaButonComanda.Add(this.tsBtnCopy, WebBrowserEditabil.EnumComandaHTML.ActionCopy);
            this.lCorespondentaButonComanda.Add(this.tsBtnCut, WebBrowserEditabil.EnumComandaHTML.ActionCut);
            this.lCorespondentaButonComanda.Add(this.btnUndo, WebBrowserEditabil.EnumComandaHTML.ActionUndo);
            this.lCorespondentaButonComanda.Add(this.btnRedo, WebBrowserEditabil.EnumComandaHTML.ActionRedo);
            this.lCorespondentaButonComanda.Add(this.tsBtnSave, WebBrowserEditabil.EnumComandaHTML.ActionSave);
            this.lCorespondentaButonComanda.Add(this.tsBtnPaste, WebBrowserEditabil.EnumComandaHTML.ActionPaste);
            this.lCorespondentaButonComanda.Add(this.tsBtnCenter, WebBrowserEditabil.EnumComandaHTML.AlignCenter);
            this.lCorespondentaButonComanda.Add(this.tsBtnAlignLeft, WebBrowserEditabil.EnumComandaHTML.AlignLeft);
            this.lCorespondentaButonComanda.Add(this.tsBtnAlignRight, WebBrowserEditabil.EnumComandaHTML.AlignRight);
            this.lCorespondentaButonComanda.Add(this.tsBtnAlignFull, WebBrowserEditabil.EnumComandaHTML.AlignFull);
            this.lCorespondentaButonComanda.Add(this.tsBtnBackColor, WebBrowserEditabil.EnumComandaHTML.ColorChangeBackColor);
            this.lCorespondentaButonComanda.Add(this.tsBtnColor, WebBrowserEditabil.EnumComandaHTML.ColorChangeForeColor);
            this.lCorespondentaButonComanda.Add(this.tsBtnBold, WebBrowserEditabil.EnumComandaHTML.FontBold);
            this.lCorespondentaButonComanda.Add(this.tsBtnFont, WebBrowserEditabil.EnumComandaHTML.FontChange);
            this.lCorespondentaButonComanda.Add(this.tsBtnClearFormating, WebBrowserEditabil.EnumComandaHTML.FontClearFormat);
            this.lCorespondentaButonComanda.Add(this.tsBtnItalic, WebBrowserEditabil.EnumComandaHTML.FontItalic);
            this.lCorespondentaButonComanda.Add(this.tsBtnUnderline, WebBrowserEditabil.EnumComandaHTML.FontUnderline);
            this.lCorespondentaButonComanda.Add(this.tsBtnStriketrough, WebBrowserEditabil.EnumComandaHTML.FontStriketrough);
            //this.lCorespondentaButonComanda.Add(this.tsBtnIndice, WebBrowserEditabil.EnumComandaHTML.FontIndice);
            //this.lCorespondentaButonComanda.Add(this.tsBtnExponent, WebBrowserEditabil.EnumComandaHTML.FontExponent);
            this.lCorespondentaButonComanda.Add(this.btnCampDeFuziune, WebBrowserEditabil.EnumComandaHTML.InsertCampFuziune);
            this.lCorespondentaButonComanda.Add(this.btnInsereazaLinie, WebBrowserEditabil.EnumComandaHTML.InsertLine);
            this.lCorespondentaButonComanda.Add(this.tsBtnInsereazaLink, WebBrowserEditabil.EnumComandaHTML.InsertLink);
            this.lCorespondentaButonComanda.Add(this.tsBtnInsereazaImagine, WebBrowserEditabil.EnumComandaHTML.InsertInlineImage);
            this.lCorespondentaButonComanda.Add(this.tsBtnInsereazaTable, WebBrowserEditabil.EnumComandaHTML.InsertTable);
            this.lCorespondentaButonComanda.Add(this.tsBtnUnorderedList, WebBrowserEditabil.EnumComandaHTML.InsertUnorderedList);
            this.lCorespondentaButonComanda.Add(this.tsBtnOrderedList, WebBrowserEditabil.EnumComandaHTML.InsertOrderedList);
            //this.lCorespondentaButonComanda.Add(this.tsCboSize, WebBrowserEditabil.EnumComandaHTML.SizeChange);
            this.lCorespondentaButonComanda.Add(this.btnDecrease, WebBrowserEditabil.EnumComandaHTML.SizeDecrease);
            this.lCorespondentaButonComanda.Add(this.btnIncrease, WebBrowserEditabil.EnumComandaHTML.SizeIncrease);
            this.lCorespondentaButonComanda.Add(this.tsBtnFindReplace, WebBrowserEditabil.EnumComandaHTML.FindReplace);
            this.lCorespondentaButonComanda.Add(this.tsBtnIndent, WebBrowserEditabil.EnumComandaHTML.Indent);
            this.lCorespondentaButonComanda.Add(this.tsBtnOutdent, WebBrowserEditabil.EnumComandaHTML.Outdent);
            //this.lCorespondentaButonComanda.Add(this.tsBtnPrint, WebBrowserEditabil.EnumComandaHTML.ActionPrint);
            this.lCorespondentaButonComanda.Add(this.tsBtnPrintPreview, WebBrowserEditabil.EnumComandaHTML.ActionPrintPreview);

            this.wbContinut.AllowNavigation = true;
            this.wbContinut.AllowWebBrowserDrop = false;
            this.wbContinut.WebBrowserShortcutsEnabled = true;
            this.wbContinut.IsWebBrowserContextMenuEnabled = false;
            this.wbContinut.ScriptErrorsSuppressed = true;
            this.wbContinut.ScrollBarsEnabled = true;

            if (!IHMUtile.SuntemInDebug())
            {
                this.wbContinut.SourceHTML = WebBrowserEditabil.DefaultHtml;

                this.tsBtnBold.ToolTipText = IHMUtile.getText(1226);
                this.tsBtnItalic.ToolTipText = IHMUtile.getText(1227);
                this.tsBtnUnderline.ToolTipText = IHMUtile.getText(1228);
                this.tsBtnBackColor.ToolTipText = IHMUtile.getText(1549);
                this.tsBtnColor.ToolTipText = IHMUtile.getText(641);
                this.tsBtnUnorderedList.ToolTipText = IHMUtile.getText(1551);
                this.tsBtnOrderedList.ToolTipText = IHMUtile.getText(1550);
                this.tsBtnAlignLeft.ToolTipText = IHMUtile.getText(1203);
                this.tsBtnCenter.ToolTipText = IHMUtile.getText(1204);
                this.tsBtnAlignRight.ToolTipText = IHMUtile.getText(1205);
                this.tsBtnClearFormating.ToolTipText = IHMUtile.getText(1552);
                this.tsBtnPaste.ToolTipText = IHMUtile.getText(1553);
                this.tsBtnCut.ToolTipText = IHMUtile.getText(1555);
                this.tsBtnCopy.ToolTipText = IHMUtile.getText(1554);
                this.tsBtnSave.ToolTipText = IHMUtile.getText(1556);
                this.btnUndo.ToolTipText = IHMUtile.getText(1557);
                this.btnRedo.ToolTipText = IHMUtile.getText(1558);
                this.btnIncrease.ToolTipText = IHMUtile.getText(1559);
                this.btnDecrease.ToolTipText = IHMUtile.getText(1560);
                this.btnInsereazaLinie.ToolTipText = IHMUtile.getText(1561);
                this.tsBtnInsereazaLink.ToolTipText = IHMUtile.getText(1219);
                this.tsBtnInsereazaImagine.ToolTipText = IHMUtile.getText(1396);
                this.btnCampDeFuziune.ToolTipText = IHMUtile.getText(1562);
                this.tsBtnInsereazaTable.ToolTipText = IHMUtile.getText(1563);
                this.tsBtnAlignFull.ToolTipText = IHMUtile.getText(1207);
                this.tsBtnFont.ToolTipText = IHMUtile.getText(1223);
                this.tsBtnFindReplace.ToolTipText = IHMUtile.getText(1232);
                this.tsBtnIndent.ToolTipText = IHMUtile.getText(1564);
                this.tsBtnOutdent.ToolTipText = IHMUtile.getText(1565);
                //this.tsBtnPrint.ToolTipText = IHMUtile.getText(1566);
                this.tsBtnPrintPreview.ToolTipText = IHMUtile.getText(1567);
                this.tsBtnStriketrough.ToolTipText = IHMUtile.getText(1229);
                //this.tsBtnIndice.ToolTipText = IHMUtile.getText(1230);
                //this.tsBtnExponent.ToolTipText = IHMUtile.getText(1231);
            }
        }

        public void ShowPrintPreviewDialog()
        {
            this.wbContinut.ShowPrintPreviewDialog();
        }

        public void Initializeaza()
        {
            InitializeazaEditor(null, string.Empty);
        }

        public void Initializeaza(byte[] pDocument)
        {
            InitializeazaEditor(pDocument, string.Empty);
        }

        public void Initializeaza(string pDocument)
        {
            InitializeazaEditor(null, pDocument);
        }

        public void ReseteazaText()
        {
            this.wbContinut.Navigate("about:blank");
            this.wbContinut.Document.OpenNew(false);
        }

        private void InitializeazaEditor(byte[] pDocument, string pHtmlDoc)
        {
            this.lSeIncarca = true;

            if (pDocument == null)
            {
                //Doar daca nu avem un document in binar
                if (string.IsNullOrEmpty(pHtmlDoc))
                    this.lContinutOriginal = WebBrowserEditabil.DefaultHtml;
                else
                    this.lContinutOriginal = pHtmlDoc;
            }

            if (string.IsNullOrEmpty(this.lContinutOriginal) && pDocument != null)
                this.lContinutOriginal = CGestiuneIO.DeCompreseazaText(pDocument);

            if (this.wbContinut.Document != null && this.wbContinut.Document.DomDocument != null)
            {
                //Pentru a nu mai vedea dialogul IE care ne intreaba daca vrem sa salvam documentul
                (this.wbContinut.Document.DomDocument as IHTMLDocument2).designMode = "Off";
            }

            try
            {
                if (this.wbContinut.Document != null && this.wbContinut.Document.Body != null && this.wbContinut.BodyHTML != null)
                {
                    ReseteazaText();
                    this.wbContinut.Document.Write(this.lContinutOriginal);
                    this.wbContinut.Refresh();
                }
                else
                    this.wbContinut.Document.Write(this.lContinutOriginal);
            }
            catch (Exception)
            {
                //In caz de exceptie vom afisa continutul original
                this.wbContinut.Document.Write(this.lContinutOriginal);
            }

            //this.wbContinut.DocumentText = "<html><body></body></html>"; //This will get our HTML editor ready, inserting common HTML blocks into the document
            this.lDocHMTL = (this.wbContinut.Document.DomDocument as IHTMLDocument2);

            this.wbContinut.DistrugeFisierInline();

            //Pentru a ramane in editare
            if (this.wbContinut.Document != null && this.wbContinut.Document.DomDocument != null)
            {
                //Pentru a nu mai vedea dialogul IE care ne intreaba daca vrem sa salvam documentul
                (this.wbContinut.Document.DomDocument as IHTMLDocument2).designMode = "On";
            }

            this.lSeIncarca = false;
        }

        #endregion

        #region Evenimente

        private void tsBtnHTML_Click(object sender, EventArgs e)
        {
            try
            {
                string text = this.wbContinut.DocumentText;
                FormulareComune.frmInputBox.GetTextUtilizator(this.GetFormParinte(), "HTML", string.Empty, CCL.iStomaLab.CUtil.InlocuiesteDiacriticeHTMLFaraEnter(text), 32000, false, true, true);
            }
            catch (Exception ex)
            {
                Mesaj.Eroare(this.GetFormParinte(), ex.Message);
            }
        }

        private void wbContinut_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.AbsoluteUri.StartsWith("http://") && (ModifierKeys == Keys.Control || !this.lEcranInModificare))
            {
                //permitem navigarea doar daca nu suntem in modificare sau daca avem tasta CTRL apasata
                using (frmWebBrowser web = new frmWebBrowser(e.Url.AbsoluteUri, false, false))
                {
                    IHMUtile.DeschideEcran(this.GetFormParinte(), web);
                }

                e.Cancel = true;
            }
        }

        private void ButonComanda_Click(object sender, EventArgs e)
        {
            ///  this.wbContinut.Document.ExecCommand("StrikeThrough", false, null);
            ///  this.wbContinut.Document.ExecCommand("FontName", false, "Times New Roman");
            ///  this.wbContinut.Document.ExecCommand("FontName", false, "Arial");
            ///  this.wbContinut.Document.ExecCommand("FontName", false, "etc.");
            ///  this.wbContinut.Document.ExecCommand("FontSize", false, "1");
            ///  this.wbContinut.Document.ExecCommand("FontSize", false, "2");
            ///  this.wbContinut.Document.ExecCommand("FontSize", false, "3");
            ///  this.wbContinut.Document.ExecCommand("CreateLink", true, null); 
            WebBrowserEditabil.EnumComandaHTML comanda = this.lCorespondentaButonComanda[sender];
            switch (comanda)
            {
                case WebBrowserEditabil.EnumComandaHTML.ActionSave:
                    anuntaSalvarea(e);
                    break;
                default:
                    this.wbContinut.ExecCommand(comanda);
                    break;
            }
        }

        public List<System.IO.FileInfo> GetFisierInline()
        {
            return this.wbContinut.GetFisierInline();
        }

        private void tsCboFont_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tsCboSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void wbContinut_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //this.Text = this.lContinutOriginal;

            if (this.lDocHMTL != null)
            {
                if (this.lEcranInModificare)
                    this.lDocHMTL.designMode = "On";
                else
                    this.lDocHMTL.designMode = "Off";
            }
        }

        #endregion

        #region Metode private

        private Form GetFormParinte()
        {
            return IHMUtile.GetFormParinte(this);
        }

        private void anuntaSalvarea(EventArgs e)
        {
            if (this.Salveaza != null)
                Salveaza(this, e);
        }

        private static readonly Regex CleanXssRegex = new Regex("<script.*?/script>|\"javascript:",
                                                                RegexOptions.IgnoreCase | RegexOptions.Singleline |
                                                                RegexOptions.CultureInvariant | RegexOptions.Compiled);

        #endregion

        #region Metode publice

        public void Goleste()
        {
            Initializeaza(string.Empty);
            this.AllowModification(this.lEcranInModificare);
        }

        public static string CleanXSS(string html)
        {
            return CleanXssRegex.Replace(html, string.Empty);
        }

        public new void Focus()
        {
            this.wbContinut.Document.Focus();
        }

        public void AscundeButonSalvare()
        {
            this.tsBtnSave.Visible = false;
            this.tsSepSalvare.Visible = false;
        }

        public void AscundeButonIncarcareImagine()
        {
            this.tsBtnInsereazaImagine.Visible = false;
        }

        public void AscundeButonVeziSursaHTML()
        {
            this.tsBtnHTML.Visible = false;
            this.tsSepHTML.Visible = false;
        }

        public void InsertHTML(string pText)
        {
            this.wbContinut.InsereazaText(pText);
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
            this.tsMeniu.Visible = this.lEcranInModificare;

            if (this.lDocHMTL != null)
            {
                if (this.lEcranInModificare)
                    this.lDocHMTL.designMode = "On";
                else
                    this.lDocHMTL.designMode = "Off";
            }

            this.wbContinut.AllowModification(this.lEcranInModificare);
        }

        #endregion

    }
}
