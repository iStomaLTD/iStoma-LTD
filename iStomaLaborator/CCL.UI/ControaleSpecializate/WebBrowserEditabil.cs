using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using CCL.UI.Caramizi.HTML;
using mshtml;

using HtmlSelection = mshtml.IHTMLSelectionObject;
using HtmlControlRange = mshtml.IHTMLControlRange;
using HtmlElementCollection = mshtml.IHTMLElementCollection;
using HtmlAnchorElement = mshtml.IHTMLAnchorElement;
using HtmlTextRange = mshtml.IHTMLTxtRange;

using HtmlTable = mshtml.IHTMLTable;
using HtmlTableRow = mshtml.IHTMLTableRow;
using HtmlElement = mshtml.IHTMLElement;

namespace CCL.UI.ControaleSpecializate
{
    public class WebBrowserEditabil : WebBrowserPersonalizat
    {

        #region Declaratii generale

        public event EventHandler ContentChanged;
        public event EventHandler UpdateUI;

        private volatile bool rebaseUrlsNeeded = false;

        public const string DefaultHtml =
            @"<html>
            <head>
            <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"" />
            </head>
            <body></body>
            </html>";

        // find and replace internal text range
        private HtmlTextRange _findRange;

        // general constants
        private const int HTML_BUFFER_SIZE = 256;

        // internal body property values
        private Color _bodyBackColor;
        private Color _bodyForeColor;
        private HtmlFontProperty _bodyFont;
        private int[] _customColors;
        private string _bodyText;
        private string _bodyHtml;

        // default values used to reset values
        private Color _defaultBackColor;
        private Color _defaultForeColor;
        private HtmlFontProperty _defaultFont;

        // define the tags being used by the application
        private const string BODY_TAG = "BODY";
        private const string SCRIPT_TAG = "SCRIPT";
        private const string ANCHOR_TAG = "A";
        private const string FONT_TAG = "FONT";
        private const string BOLD_TAG = "STRONG";
        private const string UNDERLINE_TAG = "U";
        private const string ITALIC_TAG = "EM";
        private const string STRIKE_TAG = "STRIKE";
        private const string SUBSCRIPT_TAG = "SUB";
        private const string SUPERSCRIPT_TAG = "SUP";
        private const string HEAD_TAG = "HEAD";
        private const string IMAGE_TAG = "IMG";
        private const string TABLE_TAG = "TABLE";
        private const string TABLE_ROW_TAG = "TR";
        private const string TABLE_CELL_TAG = "TD";
        private const string TABLE_HEAD_TAG = "TH";
        private const string SPAN_TAG = "SPAN";
        private const string OPEN_TAG = "<";
        private const string CLOSE_TAG = ">";

        // browser html constant expressions
        private const string EMPTY_SPACE = @"&nbsp;";
        private const string BLANK_HTML_PAGE = "about:blank";
        private const string TARGET_WINDOW_NEW = "_BLANK";
        private const string TARGET_WINDOW_SAME = "_SELF";
        private const string DEFAULT_HTML_TEXT = "";

        private const string HREF_TEST_EXPRESSION = @"mailto\:|(news|(ht|f)tp(s?))\:\/\/[\w]+(.[\w]+)([\w\-\.,@?^=%&:/~\+#]*[\w\-\@?^=%&/~\+#])?";
        private const string BODY_PARSE_PRE_EXPRESSION = @"(<body).*?(</body)";
        private const string BODY_PARSE_EXPRESSION = @"(?<bodyOpen>(<body).*?>)(?<innerBody>.*?)(?<bodyClose>(</body\s*>))";
        private const string BODY_DEFAULT_TAG = @"<Body></Body>";
        private const string BODY_TAG_PARSE_MATCH = @"${bodyOpen}${bodyClose}";
        private const string BODY_INNER_PARSE_MATCH = @"${innerBody}";
        private const string CONTENTTYPE_PARSE_EXPRESSION = @"^(?<mainType>\w+)(\/?)(?<subType>\w*)((\s*;\s*charset=)?)(?<charSet>.*)";
        private const string CONTENTTYPE_PARSE_MAINTYPE = @"${mainType}";
        private const string CONTENTTYPE_PARSE_SUBTYPE = @"${subType}";
        private const string CONTENTTYPE_PARSE_CHARSET = @"${charSet}";

        // define commands for mshtml execution execution
        private const string HTML_COMMAND_OVERWRITE = "OverWrite";
        private const string HTML_COMMAND_BOLD = "Bold";
        private const string HTML_COMMAND_UNDERLINE = "Underline";
        private const string HTML_COMMAND_ITALIC = "Italic";
        private const string HTML_COMMAND_SUBSCRIPT = "Subscript";
        private const string HTML_COMMAND_SUPERSCRIPT = "Superscript";
        private const string HTML_COMMAND_STRIKE_THROUGH = "StrikeThrough";
        private const string HTML_COMMAND_FONT_NAME = "FontName";
        private const string HTML_COMMAND_FONT_SIZE = "FontSize";
        private const string HTML_COMMAND_FORE_COLOR = "ForeColor";
        private const string HTML_COMMAND_BACK_COLOR = "BackColor";
        private const string HTML_COMMAND_INSERT_FORMAT_BLOCK = "FormatBlock";
        private const string HTML_COMMAND_REMOVE_FORMAT = "RemoveFormat";
        private const string HTML_COMMAND_JUSTIFY_LEFT = "JustifyLeft";
        private const string HTML_COMMAND_JUSTIFY_CENTER = "JustifyCenter";
        private const string HTML_COMMAND_JUSTIFY_RIGHT = "JustifyRight";
        private const string HTML_COMMAND_INDENT = "Indent";
        private const string HTML_COMMAND_OUTDENT = "Outdent";
        private const string HTML_COMMAND_INSERT_LINE = "InsertHorizontalRule";
        private const string HTML_COMMAND_INSERT_LIST = "Insert{0}List"; // replace with (Un)Ordered
        private const string HTML_COMMAND_INSERT_IMAGE = "InsertImage";
        private const string HTML_COMMAND_INSERT_LINK = "CreateLink";
        private const string HTML_COMMAND_REMOVE_LINK = "Unlink";
        private const string HTML_COMMAND_TEXT_CUT = "Cut";
        private const string HTML_COMMAND_TEXT_COPY = "Copy";
        private const string HTML_COMMAND_TEXT_PASTE = "Paste";
        private const string HTML_COMMAND_TEXT_DELETE = "Delete";
        private const string HTML_COMMAND_TEXT_UNDO = "Undo";
        private const string HTML_COMMAND_TEXT_REDO = "Redo";
        private const string HTML_COMMAND_TEXT_SELECT_ALL = "SelectAll";
        private const string HTML_COMMAND_TEXT_UNSELECT = "Unselect";
        private const string HTML_COMMAND_TEXT_PRINT = "Print";

        #endregion

        #region Enumerari si Structuri

        public enum EnumComandaHTML
        {
            ActionCopy = 1,
            ActionCut = 2,
            ActionUndo = 3,
            ActionRedo = 4,
            ActionSave = 5,
            ActionPaste = 6,
            AlignCenter = 7,
            AlignLeft = 8,
            AlignRight = 9,
            AlignFull = 789,
            ColorChangeBackColor = 10,
            ColorChangeForeColor = 11,
            FontBold = 12,
            FontChange = 13,
            FontClearFormat = 14,
            FontItalic = 15,
            FontUnderline = 16,
            InsertCampFuziune = 17,
            InsertLine = 18,
            InsertLink = 19,
            InsertTable = 20,
            InsertUnorderedList = 21,
            InsertOrderedList = 22,
            SizeChange = 23,
            SizeDecrease = 24,
            SizeIncrease = 25,
            FindReplace = 26,
            Indent = 27,
            Outdent = 28,
            ActionPrint = 29,
            ActionPrintPreview = 30,
            FontStriketrough = 31,
            FontIndice = 32,
            FontExponent = 33,
            InsertInlineImage = 34
        }

        #endregion

        #region Proprietati

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SourceHTML
        {
            get
            {
                return this.Document.Body.Parent.OuterHtml;
            }
            set
            {
                if (DesignMode)
                    return;

                this.Navigate("about:blank");
                this.Document.ContextMenuShowing += ShowContextMenu;

                //Wait document load
                for (int i = 0; i < 200 && this.ReadyState != WebBrowserReadyState.Complete; i++)
                {
                    Application.DoEvents();
                    Thread.Sleep(5);
                }

                //Write html code
                this.Document.Write(WebBrowserPersonalizat.IncarcaJavaScript());

                this.Document.Write(
                    @"<script>
                    function getCommandValue(commandId){
                        return document.queryCommandValue(commandId);
                    }
                    function getSelectionStart(){
                        var range=document.selection.createRange();
                        range.moveStart('character', -document.body.innerText.length);
                        return range.text.length;
                    }
                    function getSelectionLength(){
                        return document.selection.createRange().text.length;
                    }
                    function setSelection(start,length){
                        var range=document.selection.createRange();
                        range.collapse(true);
                        range.moveStart('character', start);
                        range.moveEnd('character', length);
                        range.select();
                    }
                    </script>");
                this.Document.Write(value);
                //Enable contentEditable
                //wbContinut.Document.Body.SetAttribute("contentEditable", "true");

                //Attacth events handlers
                this.Document.AttachEventHandler("onmouseup", OnUpdateUI);
                this.Document.AttachEventHandler("onblur", OnUpdateUI);

                this.Document.AttachEventHandler("onkeyup", OnContentChanged);
                this.Document.AttachEventHandler("onkeypress", OnContentChanged);
                this.Document.AttachEventHandler("ondrop", OnContentChanged);
                this.Document.AttachEventHandler("oncut", OnContentChanged);
                this.Document.AttachEventHandler("onpaste", OnContentChanged);

                this.Document.Body.KeyDown += DocumentKeyDown;

                //Invoke ContentChanged event
                OnContentChanged(this, EventArgs.Empty);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectionHTML
        {
            get { return this.Document.ActiveElement.InnerHtml; }
            set
            {
                this.Document.ActiveElement.InnerHtml = value;
                OnContentChanged(this, EventArgs.Empty);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Font SelectionFont
        {
            get { return new Font(SelectionFontName, SelectionFontSize); }
            set
            {
                if (value != null)
                {
                    SelectionFontName = value.Name;
                    SelectionFontSize = (int)value.SizeInPoints;

                    SelectionBold = value.Bold;
                    SelectionItalic = value.Italic;
                    SelectionUnderline = value.Underline;
                }
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectionFontName
        {
            get { return QueryCommandValue("FontName").ToString(); }
            set { ExecCommand("FontName", false, value); }
        }

        /// <summary>
        /// Obtiene o establece el tamaño, en puntos, de la fuente del texto seleccionado
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectionFontSize
        {
            get
            {
                object res = QueryCommandValue("FontSize");
                if (res is DBNull)
                    return 0;

                switch (Convert.ToInt32(res))
                {
                    case 1:
                        return 8;
                    case 2:
                        return 10;
                    case 3:
                        return 12;
                    case 4:
                        return 18;
                    case 5:
                        return 24;
                    case 6:
                        return 36;
                    case 7:
                        return 48;

                    default:
                        return 10;
                }
            }
            set
            {
                int size;
                if (value <= 8)
                    size = 1;
                else if (value <= 10)
                    size = 2;
                else if (value <= 12)
                    size = 3;
                else if (value <= 18)
                    size = 4;
                else if (value <= 24)
                    size = 5;
                else if (value <= 36)
                    size = 6;
                else
                    size = 7;

                ExecCommand("FontSize", false, size);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SelectionBold
        {
            get { return Convert.ToBoolean(QueryCommandValue("Bold")); }
            set
            {
                if (SelectionBold != value)
                    ExecCommand("Bold", false, null);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SelectionItalic
        {
            get { return Convert.ToBoolean(QueryCommandValue("Italic")); }
            set
            {
                if (SelectionItalic != value)
                    ExecCommand("Italic", false, null);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SelectionUnderline
        {
            get { return Convert.ToBoolean(QueryCommandValue("Underline")); }
            set
            {
                if (SelectionUnderline != value)
                    ExecCommand("Underline", false, null);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SelectionSubscript
        {
            get { return Convert.ToBoolean(QueryCommandValue("Subscript")); }
            set
            {
                if (SelectionSubscript != value)
                    ExecCommand("Subscript", false, null);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SelectionSuperscript
        {
            get { return Convert.ToBoolean(QueryCommandValue("Superscript")); }
            set
            {
                if (SelectionSuperscript != value)
                    ExecCommand("Superscript", false, null);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SelectionBullets
        {
            get { return Convert.ToBoolean(QueryCommandValue("InsertUnorderedList")); }
            set
            {
                if (SelectionBullets != value)
                    ExecCommand("InsertUnorderedList", false, null);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SelectionNumbering
        {
            get { return Convert.ToBoolean(QueryCommandValue("InsertOrderedList")); }
            set
            {
                if (SelectionNumbering != value)
                    ExecCommand("InsertOrderedList", false, null);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color SelectionForeColor
        {
            get
            {
                try
                {
                    return ColorTranslator.FromHtml(QueryCommandValue("ForeColor").ToString());
                }
                catch
                {
                    return Color.Empty;
                }
            }
            set { ExecCommand("ForeColor", false, ColorTranslator.ToHtml(value)); }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color SelectionBackColor
        {
            get
            {
                try
                {
                    return ColorTranslator.FromHtml(QueryCommandValue("BackColor").ToString());
                }
                catch
                {
                    return Color.Empty;
                }
            }
            set { ExecCommand("BackColor", false, ColorTranslator.ToHtml(value)); }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HorizontalAlignment SelectionAlignment
        {
            get
            {
                if (Convert.ToBoolean(QueryCommandValue("JustifyRight")))
                    return HorizontalAlignment.Right;
                if (Convert.ToBoolean(QueryCommandValue("JustifyCenter")))
                    return HorizontalAlignment.Center;

                return HorizontalAlignment.Left;
            }
            set
            {
                switch (value)
                {
                    case HorizontalAlignment.Left:
                        ExecCommand("JustifyLeft", false, null);
                        break;
                    case HorizontalAlignment.Center:
                        ExecCommand("JustifyCenter", false, null);
                        break;
                    case HorizontalAlignment.Right:
                        ExecCommand("JustifyRight", false, null);
                        break;
                }
            }
        }

        private void OnUpdateUI(object sender, EventArgs e)
        {
            if (UpdateUI != null)
                UpdateUI(sender, e);
        }

        private void OnContentChanged(object sender, EventArgs e)
        {
            if (ContentChanged != null)
                ContentChanged(sender, e);
            OnUpdateUI(sender, e);
        }

        void DocumentKeyDown(object sender, HtmlElementEventArgs e)
        {
            if (e.CtrlKeyPressed && e.KeyPressedCode == 67)
            {
                this.Document.Window.Alert("Copy event from managed code");
                e.ReturnValue = false;
            }
        }

        private void ShowContextMenu(object sender, HtmlElementEventArgs e)
        {
            //if (ContextMenuStrip != null)
            //{
            //    ContextMenuStrip.Show(this, e.MousePosition);
            //    e.ReturnValue = false;
            //}
            //else if (IsContextMenuEnabled == false)
            //{
            //    e.ReturnValue = false;
            //}
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string BodyHTML
        {
            get { return this.Document.Body.InnerHtml; }
            set
            {
                this.Document.Body.InnerHtml = value;
                OnContentChanged(this, EventArgs.Empty);
            }
        }


        #endregion

        #region Constructor si Initializare

        public WebBrowserEditabil()
            : base()
        {
        }

        public WebBrowserEditabil(IContainer container)
            : base(container)
        {
        }

        public void Initializeaza()
        {
            // default values used to reset values
            _defaultBackColor = Color.White;
            _defaultForeColor = Color.Black;
            _defaultFont = new HtmlFontProperty(this.Font);

            _bodyText = DEFAULT_HTML_TEXT;
            _bodyHtml = DEFAULT_HTML_TEXT;

            _bodyBackColor = _defaultBackColor;
            _bodyForeColor = _defaultForeColor;
            _bodyFont = _defaultFont;
        }

        #endregion

        #region Evenimente



        #endregion

        #region Metode private



        #endregion

        #region Metode publice

        public mshtml.HTMLBody GetBody()
        {
            IHTMLDocument2 doc = GetDomDocument();
            if (doc != null)
                return doc.body as mshtml.HTMLBody;
            return null;
        }

        protected object QueryCommandValue(string commandId)
        {
            return this.Document.InvokeScript("getCommandValue", new object[] { commandId });
        }

        private int getSizeFontSelectie()
        {
            object res = null;

            IHTMLDocument2 doc = GetDomDocument();

            if (doc != null)
                res = doc.queryCommandValue("FontSize");

            doc = null;

            if (res == null || res is DBNull)
                return 3;

            return (int)res;
        }

        private List<System.IO.FileInfo> fisierInline = null;

        public List<System.IO.FileInfo> GetFisierInline()
        {
            return this.fisierInline;
        }

        public void DistrugeFisierInline()
        {
            this.fisierInline = null;
        }

        public void ExecCommand(EnumComandaHTML pComanda)
        {
            switch (pComanda)
            {
                case EnumComandaHTML.ActionPrint:
                    // Print the current document
                    DocumentPrint();
                    break;
                case EnumComandaHTML.ActionPrintPreview:
                    this.ShowPrintPreviewDialog();
                    break;
                case EnumComandaHTML.ActionCopy:
                    this.Copy();
                    break;
                case EnumComandaHTML.ActionPaste:
                    this.Paste();
                    break;
                case EnumComandaHTML.ActionCut:
                    this.Cut();
                    break;
                case EnumComandaHTML.ActionUndo:
                    this.Undo();
                    break;
                case EnumComandaHTML.ActionRedo:
                    this.Redo();
                    break;
                case EnumComandaHTML.ActionSave:
                    //Nu are sens aici
                    break;
                case EnumComandaHTML.AlignFull:
                    this.Document.ExecCommand("JustifyFull", false, null);
                    break;
                case EnumComandaHTML.AlignCenter:
                    this.Document.ExecCommand("JustifyCenter", false, null);
                    break;
                case EnumComandaHTML.AlignLeft:
                    this.Document.ExecCommand("JustifyLeft", false, null);
                    break;
                case EnumComandaHTML.AlignRight:
                    this.Document.ExecCommand("JustifyRight", false, null);
                    break;
                case EnumComandaHTML.ColorChangeBackColor:
                    FormatBackColorPrompt();
                    break;
                case EnumComandaHTML.ColorChangeForeColor:
                    // COLOR style creation
                    FormatFontColorPrompt();
                    break;
                case EnumComandaHTML.FontBold:
                    this.Document.ExecCommand("Bold", false, null);
                    break;
                case EnumComandaHTML.FontChange:
                    // FONT style creation
                    FormatFontAttributesPrompt();
                    break;
                case EnumComandaHTML.FontClearFormat:
                    this.Document.ExecCommand("RemoveParaFormat", false, null);
                    this.Document.ExecCommand("RemoveFormat", false, null);
                    break;
                case EnumComandaHTML.FontItalic:
                    this.Document.ExecCommand("Italic", false, null);
                    break;
                case EnumComandaHTML.FontUnderline:
                    this.Document.ExecCommand("Underline", false, null);
                    break;
                case EnumComandaHTML.FontStriketrough:
                    // Selection STRIKEOUT command
                    FormatStrikeout();
                    break;
                case EnumComandaHTML.FontIndice:
                    // Selection SUBSCRIPT command
                    FormatSubscript();
                    break;
                case EnumComandaHTML.FontExponent:
                    // Selection SUPERSCRIPT command
                    FormatSuperscript();
                    break;
                case EnumComandaHTML.InsertCampFuziune:
                    break;
                case EnumComandaHTML.InsertLine:
                    this.Document.ExecCommand("InsertHorizontalRule", false, null);
                    break;
                case EnumComandaHTML.InsertInlineImage:
                    using (System.Windows.Forms.OpenFileDialog ofdIncarcaImagine = new OpenFileDialog())
                    {
                        ofdIncarcaImagine.Multiselect = true;
                        if (IHMUtile.DeschideEcran(this.GetFormParinte(), ofdIncarcaImagine))
                        {
                            if (fisierInline == null)
                                fisierInline = new List<System.IO.FileInfo>();

                            System.IO.FileInfo infoFisier = null;
                            foreach (string fisier in ofdIncarcaImagine.FileNames)
                            {
                                infoFisier = new System.IO.FileInfo(fisier);
                                fisierInline.Add(infoFisier);

                                if (this.Document != null)
                                {
                                    //InsertHtml(string.Format(@"<img src=""{0}"" />", infoFisier.FullName), false);
                                    //this.Document.OpenNew(true);
                                    if (this.Document.Body != null)
                                        this.Document.Body.InnerHtml += string.Format(@"<img src=""{0}"" />", infoFisier.FullName);
                                    else
                                    {
                                        this.Document.OpenNew(true);
                                        this.Document.Write(string.Format(@"<img src=""{0}"" />", infoFisier.FullName));
                                    }
                                }
                                else
                                {
                                    this.Initializeaza(string.Format(@"<img src=""{0}"" />", infoFisier.FullName));
                                }
                            }
                        }
                    }
                    break;
                case EnumComandaHTML.InsertLink:
                    InsertLinkPrompt();
                    break;
                case EnumComandaHTML.InsertTable:
                    // Display a dialog to enable the user to insert a table
                    TableInsertPrompt();
                    break;
                case EnumComandaHTML.InsertUnorderedList:
                    this.Document.ExecCommand("InsertUnorderedList", false, null);
                    break;
                case EnumComandaHTML.InsertOrderedList:
                    this.Document.ExecCommand("InsertOrderedList", false, null);
                    break;
                case EnumComandaHTML.SizeChange:
                    break;
                case EnumComandaHTML.SizeDecrease:
                case EnumComandaHTML.SizeIncrease:
                    int sizeActual = getSizeFontSelectie();
                    sizeActual = sizeActual + ((pComanda == EnumComandaHTML.SizeIncrease) ? 1 : -1);
                    //if (sizeActual > 0 && sizeActual < 8)
                    this.Document.ExecCommand("FontSize", false, sizeActual);
                    break;
                case EnumComandaHTML.FindReplace:
                    // Display a dialog to enable user to perform find and replace operations
                    FindReplacePrompt();
                    break;
                case EnumComandaHTML.Indent:
                    // Tab Right
                    FormatTabRight();
                    break;
                case EnumComandaHTML.Outdent:
                    // Tab Left
                    FormatTabLeft();
                    break;
                default:
                    break;
            }
        }

        protected void ExecCommand(string command, bool showUI, object value)
        {
            this.Document.ExecCommand(command, showUI, value);
            OnContentChanged(this, EventArgs.Empty);
        }

        public void DeleteSelection()
        {
            ExecCommand("Delete", false, null);
        }

        public void SetSelectionTag(string tag)
        {
            ExecCommand("FormatBlock", false, "<" + tag + ">");
        }

        public void SelectAll()
        {
            ExecCommand("SelectAll", false, null);
        }

        public void Select(int start, int lenght)
        {
            Document.InvokeScript("setSelection", new object[] { start, lenght });
        }

        public override void InsereazaText(string pText)
        {
            InsertHtml(pText, true);
        }

        public void InsertHtml(string html, bool replaceSelection)
        {
            IHTMLTxtRange range = GetTextRange();
            if (range != null)
            {
                range.pasteHTML(html);
            }

            //if (replaceSelection)
            //    DeleteSelection();

            //if (this.Document.ActiveElement != null && this.Document.ActiveElement.InnerHtml != null)
            //{
            //    this.Document.ActiveElement.InnerHtml += html;
            //}
            //else if (string.IsNullOrEmpty(BodyHTML))
            //{
            //    BodyHTML = html;
            //}
            //else
            //{
            //    HtmlElement nuevo = this.Document.CreateElement("span");
            //    nuevo.OuterHtml = html;
            //    this.Document.ActiveElement.InsertAdjacentElement(HtmlElementInsertionOrientation.AfterEnd, nuevo);
            //}
            OnContentChanged(this, EventArgs.Empty);
        }

        #endregion

        #region Table Processing Operations

        // public function to create a table class
        // insert method then works on this table
        public void TableInsert(HtmlTableProperty tableProperties)
        {
            // call the private insert table method with a null table entry
            ProcessTable(null, tableProperties);

        } //TableInsert

        // public function to modify a tables properties
        // ensure a table is currently selected or insertion point is within a table
        public bool TableModify(HtmlTableProperty tableProperties)
        {
            // define the Html Table element
            HtmlTable table = GetTableElement();

            // if a table has been selected then process
            if (table != null)
            {
                ProcessTable(table, tableProperties);
                return true;
            }
            else
            {
                return false;
            }

        } //TableModify

        // present to the user the table properties dialog
        // using all the default properties for the table based on an insert operation
        public void TableInsertPrompt()
        {
            // if user has selected a table create a reference
            HtmlTable table = GetFirstControl() as HtmlTable;
            ProcessTablePrompt(table);

        } //TableInsertPrompt


        // present to the user the table properties dialog
        // ensure a table is currently selected or insertion point is within a table
        public bool TableModifyPrompt()
        {
            // define the Html Table element
            HtmlTable table = GetTableElement();

            // if a table has been selected then process
            if (table != null)
            {
                ProcessTablePrompt(table);
                return true;
            }
            else
            {
                return false;
            }

        } //TableModifyPrompt


        // will insert a new row into the table
        // based on the current user row and insertion after
        public void TableInsertRow()
        {
            // see if a table selected or insertion point inside a table
            HtmlTable table = null;
            HtmlTableRow row = null;
            GetTableElement(out table, out row);

            // process according to table being defined
            if (table != null && row != null)
            {
                try
                {
                    // find the existing row the user is on and perform the insertion
                    int index = row.rowIndex + 1;
                    HtmlTableRow insertedRow = table.insertRow(index) as HtmlTableRow;
                    // add the new columns to the end of each row
                    int numberCols = row.cells.length;
                    for (int idxCol = 0; idxCol < numberCols; idxCol++)
                    {
                        insertedRow.insertCell(-1);
                    }
                }
                catch (Exception ex)
                {
                    throw new HtmlEditorException("Unable to insert a new Row", "TableinsertRow", ex);
                }
            }
            else
            {
                throw new HtmlEditorException("Row not currently selected within the table", "TableInsertRow");
            }

        } //TableInsertRow


        // will delete the currently selected row
        // based on the current user row location
        public void TableDeleteRow()
        {
            // see if a table selected or insertion point inside a table
            HtmlTable table = null;
            HtmlTableRow row = null;
            GetTableElement(out table, out row);

            // process according to table being defined
            if (table != null && row != null)
            {
                try
                {
                    // find the existing row the user is on and perform the deletion
                    int index = row.rowIndex;
                    table.deleteRow(index);
                }
                catch (Exception ex)
                {
                    throw new HtmlEditorException("Unable to delete the selected Row", "TableDeleteRow", ex);
                }
            }
            else
            {
                throw new HtmlEditorException("Row not currently selected within the table", "TableDeleteRow");
            }

        } //TableDeleteRow


        // present to the user the table properties dialog
        // using all the default properties for the table based on an insert operation
        private void ProcessTablePrompt(HtmlTable table)
        {
            using (TablePropertyForm dialog = new TablePropertyForm())
            {
                // define the base set of table properties
                HtmlTableProperty tableProperties = GetTableProperties(table);

                // set the dialog properties
                dialog.TableProperties = tableProperties;
                DefineDialogProperties(dialog);
                // based on the user interaction perform the neccessary action
                if (dialog.ShowDialog(this.Parent) == DialogResult.OK)
                {
                    tableProperties = dialog.TableProperties;
                    if (table == null) TableInsert(tableProperties);
                    else ProcessTable(table, tableProperties);
                }
            }

        } // ProcessTablePrompt


        // function to insert a basic table
        // will honour the existing table if passed in
        private void ProcessTable(IHTMLTable table, HtmlTableProperty tableProperties)
        {
            try
            {
                // obtain a reference to the body node and indicate table present
                IHTMLDOMNode bodyNode = (IHTMLDOMNode)GetBody();
                bool tableCreated = false;

                // ensure a table node has been defined to work with
                if (table == null)
                {
                    // create the table and indicate it was created
                    table = (IHTMLTable)GetDomDocument().createElement(TABLE_TAG);
                    tableCreated = true;
                }

                // define the table border, width, cell padding and spacing
                table.border = tableProperties.BorderSize;
                if (tableProperties.TableWidth > 0) table.width = (tableProperties.TableWidthMeasurement == MeasurementOption.Pixel) ? string.Format("{0}", tableProperties.TableWidth) : string.Format("{0}%", tableProperties.TableWidth);
                else table.width = string.Empty;
                if (tableProperties.TableAlignment != HorizontalAlignOption.Default) table.align = tableProperties.TableAlignment.ToString().ToLower();
                else table.align = string.Empty;
                table.cellPadding = tableProperties.CellPadding.ToString();
                table.cellSpacing = tableProperties.CellSpacing.ToString();

                // define the given table caption and alignment
                string caption = tableProperties.CaptionText;
                IHTMLTableCaption tableCaption = table.caption;
                if (caption != null && caption != string.Empty)
                {
                    // ensure table caption correctly defined
                    if (tableCaption == null) tableCaption = table.createCaption();
                    ((HtmlElement)tableCaption).innerText = caption;
                    if (tableProperties.CaptionAlignment != HorizontalAlignOption.Default) tableCaption.align = tableProperties.CaptionAlignment.ToString().ToLower();
                    if (tableProperties.CaptionLocation != VerticalAlignOption.Default) tableCaption.vAlign = tableProperties.CaptionLocation.ToString().ToLower();
                }
                else
                {
                    // if no caption specified remove the existing one
                    if (tableCaption != null)
                    {
                        // prior to deleting the caption the contents must be cleared
                        ((HtmlElement)tableCaption).innerText = null;
                        table.deleteCaption();
                    }
                }

                // determine the number of rows one has to insert
                int numberRows, numberCols;
                if (tableCreated)
                {
                    numberRows = Math.Max((int)tableProperties.TableRows, 1);
                }
                else
                {
                    numberRows = Math.Max((int)tableProperties.TableRows, 1) - (int)table.rows.length;
                }

                // layout the table structure in terms of rows and columns
                table.cols = (int)tableProperties.TableColumns;
                if (tableCreated)
                {
                    // this section is an optimization based on creating a new table
                    // the section below works but not as efficiently
                    numberCols = Math.Max((int)tableProperties.TableColumns, 1);
                    // insert the appropriate number of rows
                    IHTMLTableRow tableRow;
                    for (int idxRow = 0; idxRow < numberRows; idxRow++)
                    {
                        tableRow = table.insertRow(-1) as IHTMLTableRow;
                        // add the new columns to the end of each row
                        for (int idxCol = 0; idxCol < numberCols; idxCol++)
                        {
                            tableRow.insertCell(-1);
                        }
                    }
                }
                else
                {
                    // if the number of rows is increasing insert the decrepency
                    if (numberRows > 0)
                    {
                        // insert the appropriate number of rows
                        for (int idxRow = 0; idxRow < numberRows; idxRow++)
                        {
                            table.insertRow(-1);
                        }
                    }
                    else
                    {
                        // remove the extra rows from the table
                        for (int idxRow = numberRows; idxRow < 0; idxRow++)
                        {
                            table.deleteRow(table.rows.length - 1);
                        }
                    }
                    // have the rows constructed
                    // now ensure the columns are correctly defined for each row
                    HtmlElementCollection rows = table.rows;
                    foreach (IHTMLTableRow tableRow in rows)
                    {
                        numberCols = Math.Max((int)tableProperties.TableColumns, 1) - (int)tableRow.cells.length;
                        if (numberCols > 0)
                        {
                            // add the new column to the end of each row
                            for (int idxCol = 0; idxCol < numberCols; idxCol++)
                            {
                                tableRow.insertCell(-1);
                            }
                        }
                        else
                        {
                            // reduce the number of cells in the given row
                            // remove the extra rows from the table
                            for (int idxCol = numberCols; idxCol < 0; idxCol++)
                            {
                                tableRow.deleteCell(tableRow.cells.length - 1);
                            }
                        }
                    }
                }

                // if the table was created then it requires insertion into the DOM
                // otherwise property changes are sufficient
                if (tableCreated)
                {
                    // table processing all complete so insert into the DOM
                    IHTMLDOMNode tableNode = (IHTMLDOMNode)table;
                    HtmlElement tableElement = (HtmlElement)table;
                    IHTMLSelectionObject selection = GetDomDocument().selection;
                    IHTMLTxtRange textRange = GetTextRange();
                    // final insert dependant on what user has selected
                    if (textRange != null)
                    {
                        // text range selected so overwrite with a table
                        try
                        {
                            string selectedText = textRange.text;
                            if (selectedText != null)
                            {
                                // place selected text into first cell
                                IHTMLTableRow tableRow = table.rows.item(0, null) as IHTMLTableRow;
                                (tableRow.cells.item(0, null) as HtmlElement).innerText = selectedText;
                            }
                            textRange.pasteHTML(tableElement.outerHTML);
                        }
                        catch (Exception ex)
                        {
                            throw new HtmlEditorException("Invalid Text selection for the Insertion of a Table.", "ProcessTable", ex);
                        }
                    }
                    else
                    {
                        IHTMLControlRange controlRange = GetAllControls();
                        if (controlRange != null)
                        {
                            // overwrite any controls the user has selected
                            try
                            {
                                // clear the selection and insert the table
                                // only valid if multiple selection is enabled
                                for (int idx = 1; idx < controlRange.length; idx++)
                                {
                                    controlRange.remove(idx);
                                }
                                controlRange.item(0).outerHTML = tableElement.outerHTML;
                                // this should work with initial count set to zero
                                // controlRange.add((HtmlControlElement)table);
                            }
                            catch (Exception ex)
                            {
                                throw new HtmlEditorException("Cannot Delete all previously Controls selected.", "ProcessTable", ex);
                            }
                        }
                        else
                        {
                            // insert the table at the end of the HTML
                            bodyNode.appendChild(tableNode);
                        }
                    }
                }
                else
                {
                    // table has been correctly defined as being the first selected item
                    // need to remove other selected items
                    IHTMLControlRange controlRange = GetAllControls();
                    if (controlRange != null)
                    {
                        // clear the controls selected other than than the first table
                        // only valid if multiple selection is enabled
                        for (int idx = 1; idx < controlRange.length; idx++)
                        {
                            controlRange.remove(idx);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // throw an exception indicating table structure change error
                throw new HtmlEditorException("Unable to modify Html Table properties.", "ProcessTable", ex);
            }

        } //ProcessTable


        // determine if the current selection is a table
        // return the table element
        private void GetTableElement(out IHTMLTable table, out IHTMLTableRow row)
        {
            table = null;
            row = null;
            IHTMLTxtRange range = GetTextRange();

            try
            {
                // first see if the table element is selected
                table = GetFirstControl() as IHTMLTable;
                // if table not selected then parse up the selection tree
                if (table == null && range != null)
                {
                    IHTMLElement element = (IHTMLElement)range.parentElement();
                    // parse up the tree until the table element is found
                    while (element != null && table == null)
                    {
                        element = (IHTMLElement)element.parentElement;
                        // extract the Table properties
                        if (element is IHTMLTable)
                        {
                            table = (IHTMLTable)element;
                        }
                        // extract the Row  properties
                        if (element is IHTMLTableRow)
                        {
                            row = (IHTMLTableRow)element;
                        }
                    }
                }
            }
            catch (Exception)
            {
                // have unknown error so set return to null
                table = null;
                row = null;
            }

        } //GetTableElement

        private IHTMLTable GetTableElement()
        {
            // define the table and row elements and obtain there values
            IHTMLTable table = null;
            IHTMLTableRow row = null;
            GetTableElement(out table, out row);

            // return the defined table element
            return table;

        }


        // given an HtmlTable determine the table properties
        private HtmlTableProperty GetTableProperties(IHTMLTable table)
        {
            // define a set of base table properties
            HtmlTableProperty tableProperties = new HtmlTableProperty(true);

            // if user has selected a table extract those properties
            if (table != null)
            {
                try
                {
                    // have a table so extract the properties
                    IHTMLTableCaption caption = table.caption;
                    // if have a caption persist the values
                    if (caption != null)
                    {
                        tableProperties.CaptionText = ((IHTMLElement)table.caption).innerText;
                        if (caption.align != null) tableProperties.CaptionAlignment = (HorizontalAlignOption)TryParseEnum(typeof(HorizontalAlignOption), caption.align, HorizontalAlignOption.Default);
                        if (caption.vAlign != null) tableProperties.CaptionLocation = (VerticalAlignOption)TryParseEnum(typeof(VerticalAlignOption), caption.vAlign, VerticalAlignOption.Default);
                    }
                    // look at the table properties
                    object tableBorder = table.border;
                    if (tableBorder != null) tableProperties.BorderSize = TryParseByte(tableBorder.ToString(), tableProperties.BorderSize);
                    if (table.align != null) tableProperties.TableAlignment = (HorizontalAlignOption)TryParseEnum(typeof(HorizontalAlignOption), table.align, HorizontalAlignOption.Default);
                    // define the table rows and columns
                    int rows = Math.Min(table.rows.length, Byte.MaxValue);
                    int cols = Math.Min(table.cols, Byte.MaxValue);
                    if (cols == 0 && rows > 0)
                    {
                        // cols value not set to get the maxiumn number of cells in the rows
                        foreach (IHTMLTableRow tableRow in table.rows)
                        {
                            cols = Math.Max(cols, (int)tableRow.cells.length);
                        }
                    }
                    tableProperties.TableRows = (byte)Math.Min(rows, byte.MaxValue);
                    tableProperties.TableColumns = (byte)Math.Min(cols, byte.MaxValue);
                    // define the remaining table properties
                    object cellPadding = table.cellPadding;
                    object cellSpacing = table.cellSpacing;
                    if (cellPadding != null) tableProperties.CellPadding = TryParseByte(Convert.ToString(cellPadding), tableProperties.CellPadding);
                    if (cellSpacing != null) tableProperties.CellSpacing = TryParseByte(Convert.ToString(cellSpacing), tableProperties.CellSpacing);
                    if ((object)table.width != null)
                    {
                        string tableWidth = Convert.ToString((object)table.width);
                        if (tableWidth.TrimEnd(null).EndsWith("%"))
                        {
                            tableProperties.TableWidth = TryParseUshort(tableWidth.Remove(tableWidth.LastIndexOf("%"), 1), tableProperties.TableWidth);
                            tableProperties.TableWidthMeasurement = MeasurementOption.Percent;
                        }
                        else
                        {
                            tableProperties.TableWidth = TryParseUshort(tableWidth, tableProperties.TableWidth);
                            tableProperties.TableWidthMeasurement = MeasurementOption.Pixel;
                        }
                    }
                    else
                    {
                        tableProperties.TableWidth = 0;
                        tableProperties.TableWidthMeasurement = MeasurementOption.Pixel;
                    }
                }
                catch (Exception ex)
                {
                    // throw an exception indicating table structure change be determined
                    throw new HtmlEditorException("Unable to determine Html Table properties.", "GetTableProperties", ex);
                }
            }

            // return the table properties
            return tableProperties;

        } //GetTableProperties


        // based on the user selection return a table definition
        // if table selected (or insertion point within table) return these values
        public void GetTableDefinition(out HtmlTableProperty table, out bool tableFound)
        {
            // see if a table selected or insertion point inside a table
            IHTMLTable htmlTable = GetTableElement();

            // process according to table being defined
            if (htmlTable == null)
            {
                table = new HtmlTableProperty(true);
                tableFound = false;
            }
            else
            {
                table = GetTableProperties(htmlTable);
                tableFound = true;
            }

        } //GetTableDefinition


        // Determine if the insertion point or selection is a table
        private bool IsParentTable()
        {
            // see if a table selected or insertion point inside a table
            IHTMLTable htmlTable = GetTableElement();

            // process according to table being defined
            if (htmlTable == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        } //IsParentTable

        #endregion

        #region Font and Color Processing Operations

        // using the exec command define font properties for the selected text
        public void FormatFontAttributes(HtmlFontProperty font)
        {
            // obtain the selected range object
            HtmlTextRange range = GetTextRange();

            if (range != null && HtmlFontProperty.IsNotNull(font))
            {
                // Use the FONT object to set the properties
                // FontName, FontSize, Bold, Italic, Underline, Strikeout
                ExecuteCommandRange(range, HTML_COMMAND_FONT_NAME, font.Name);
                // set the font size provide set to a value
                if (font.Size != HtmlFontSize.Default) ExecuteCommandRange(range, HTML_COMMAND_FONT_SIZE, (int)font.Size);
                // determine the BOLD property and correct as neccessary
                object currentBold = QueryCommandRange(range, HTML_COMMAND_BOLD);
                bool fontBold = (currentBold is System.Boolean) ? fontBold = (bool)currentBold : false;
                if (font.Bold != fontBold) ExecuteCommandRange(HTML_COMMAND_BOLD, null);
                // determine the UNDERLINE property and correct as neccessary
                object currentUnderline = QueryCommandRange(range, HTML_COMMAND_UNDERLINE);
                bool fontUnderline = (currentUnderline is System.Boolean) ? fontUnderline = (bool)currentUnderline : false;
                if (font.Underline != fontUnderline) ExecuteCommandRange(HTML_COMMAND_UNDERLINE, null);
                // determine the ITALIC property and correct as neccessary
                object currentItalic = QueryCommandRange(range, HTML_COMMAND_ITALIC);
                bool fontItalic = (currentItalic is System.Boolean) ? fontItalic = (bool)currentItalic : false;
                if (font.Italic != fontItalic) ExecuteCommandRange(HTML_COMMAND_ITALIC, null);
                // determine the STRIKEOUT property and correct as neccessary
                object currentStrikeout = QueryCommandRange(range, HTML_COMMAND_STRIKE_THROUGH);
                bool fontStrikeout = (currentStrikeout is System.Boolean) ? fontStrikeout = (bool)currentStrikeout : false;
                if (font.Strikeout != fontStrikeout) ExecuteCommandRange(HTML_COMMAND_STRIKE_THROUGH, null);
                // determine the SUPERSCRIPT property and correct as neccessary
                object currentSuperscript = QueryCommandRange(range, HTML_COMMAND_SUPERSCRIPT);
                bool fontSuperscript = (currentSuperscript is System.Boolean) ? fontSuperscript = (bool)currentSuperscript : false;
                if (font.Superscript != fontSuperscript) ExecuteCommandRange(HTML_COMMAND_SUPERSCRIPT, null);
                // determine the SUBSCRIPT property and correct as neccessary
                object currentSubscript = QueryCommandRange(range, HTML_COMMAND_SUBSCRIPT);
                bool fontSubscript = (currentSubscript is System.Boolean) ? fontSubscript = (bool)currentSubscript : false;
                if (font.Subscript != fontSubscript) ExecuteCommandRange(HTML_COMMAND_SUBSCRIPT, null);
            }
            else
            {
                // do not have text selected or a valid font class
                throw new HtmlEditorException("Invalid Text selection made or Invalid Font selection.", "FormatFont");
            }

        } //FormatFontAttributes


        // using the exec command define color properties for the selected tag
        public void FormatFontColor(Color color)
        {
            // Use the COLOR object to set the property ForeColor
            string colorHtml;
            if (color != Color.Empty) colorHtml = ColorTranslator.ToHtml(color);
            else colorHtml = null;
            ExecuteCommandRange(HTML_COMMAND_FORE_COLOR, colorHtml);

        } //FormatFontColor

        public void FormatBackColor(Color color)
        {
            // Use the COLOR object to set the property ForeColor
            string colorHtml = "Black";
            if (color != Color.Empty) colorHtml = ColorTranslator.ToHtml(color);
            else colorHtml = null;
            ExecuteCommandRange(HTML_COMMAND_BACK_COLOR, colorHtml);

        } //FormatFontColor

        // display the defined font dialog use to set the selected text FONT
        public void FormatFontAttributesPrompt()
        {
            using (FontAttributeForm dialog = new FontAttributeForm())
            {
                DefineDialogProperties(dialog);
                dialog.HtmlFont = GetFontAttributes();
                if (dialog.ShowDialog(this.Parent) == DialogResult.OK)
                {
                    HtmlFontProperty font = dialog.HtmlFont;
                    FormatFontAttributes(new HtmlFontProperty(font.Name, font.Size, font.Bold, font.Italic, font.Underline, font.Strikeout, font.Subscript, font.Superscript));
                }
            }

        } //FormatFontAttributesPrompt

        public void FormatBackColorPrompt()
        {
            using (ColorDialog dialog = new ColorDialog())
            {
                if (IHMUtile.DeschideEcran(this.GetFormParinte(), dialog))
                {
                    Color color = dialog.Color;
                    FormatBackColor(color);
                }
            }
        }

        // display the system color dialog and use to set the selected text
        public void FormatFontColorPrompt()
        {
            // display the Color dialog and use the selected color to modify text
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.AnyColor = true;
                colorDialog.SolidColorOnly = true;
                colorDialog.AllowFullOpen = true;
                colorDialog.Color = GetFontColor();
                colorDialog.CustomColors = _customColors;
                if (colorDialog.ShowDialog(this.Parent) == DialogResult.OK)
                {
                    _customColors = colorDialog.CustomColors;
                    FormatFontColor(colorDialog.Color);
                }
            }

        } //FormatFontColorPrompt


        // determine the Font of the selected text range
        // set to the default value of not defined
        public HtmlFontProperty GetFontAttributes()
        {
            // get the text range working with
            HtmlTextRange range = GetTextRange();

            if (range != null)
            {
                // get font name to show
                object currentName = QueryCommandRange(range, HTML_COMMAND_FONT_NAME);
                string fontName = (currentName is System.String) ? (string)currentName : _bodyFont.Name;
                // determine font size to show
                object currentSize = QueryCommandRange(range, HTML_COMMAND_FONT_SIZE);
                HtmlFontSize fontSize = (currentSize is System.Int32) ? (HtmlFontSize)currentSize : _bodyFont.Size;
                // determine the BOLD property
                bool fontBold = IsFontBold(range);
                // determine the UNDERLINE property
                bool fontUnderline = IsFontUnderline(range);
                // determine the ITALIC property
                bool fontItalic = IsFontItalic(range);
                // determine the STRIKEOUT property
                bool fontStrikeout = IsFontStrikeout(range);
                // determine the SUPERSCRIPT property
                bool fontSuperscript = IsFontSuperscript(range);
                // determine the SUBSCRIPT property
                bool fontSubscript = IsFontSubscript(range);
                // calculate the Font and return
                return new HtmlFontProperty(fontName, fontSize, fontBold, fontUnderline, fontItalic, fontStrikeout, fontSubscript, fontSuperscript);
            }
            else
            {
                // no rnage selected so return null
                return _defaultFont;
            }

        } //GetFontAttributes


        // determine if the current font selected is bold given a range
        private bool IsFontBold(HtmlTextRange range)
        {
            // determine the BOLD property
            object currentBold = QueryCommandRange(range, HTML_COMMAND_BOLD);
            return (currentBold is System.Boolean) ? (bool)currentBold : _bodyFont.Bold;

        } //IsFontBold

        // determine if the current font selected is bold given a range
        public bool IsFontBold()
        {
            // get the text range working with
            HtmlTextRange range = GetTextRange();
            // return the font property
            return IsFontBold(range);

        } //IsFontBold


        // determine if the current font selected is Underline given a range
        private bool IsFontUnderline(HtmlTextRange range)
        {
            // determine the UNDERLINE property
            object currentUnderline = QueryCommandRange(range, HTML_COMMAND_UNDERLINE);
            return (currentUnderline is System.Boolean) ? (bool)currentUnderline : _bodyFont.Underline;

        } //IsFontUnderline

        // determine if the current font selected is Underline
        public bool IsFontUnderline()
        {
            // get the text range working with
            HtmlTextRange range = GetTextRange();
            // return the font property
            return IsFontUnderline(range);

        } //IsFontUnderline


        // determine if the current font selected is Italic given a range
        private bool IsFontItalic(HtmlTextRange range)
        {
            // determine the ITALIC property
            object currentItalic = QueryCommandRange(range, HTML_COMMAND_ITALIC);
            return (currentItalic is System.Boolean) ? (bool)currentItalic : _bodyFont.Italic;

        } //IsFontItalic

        // determine if the current font selected is Italic
        public bool IsFontItalic()
        {
            // get the text range working with
            HtmlTextRange range = GetTextRange();
            // return the font property
            return IsFontItalic(range);

        } //IsFontItalic


        // determine if the current font selected is Strikeout given a range
        private bool IsFontStrikeout(HtmlTextRange range)
        {
            // determine the STRIKEOUT property
            object currentStrikeout = QueryCommandRange(range, HTML_COMMAND_STRIKE_THROUGH);
            return (currentStrikeout is System.Boolean) ? (bool)currentStrikeout : _bodyFont.Strikeout;

        } //IsFontStrikeout

        // determine if the current font selected is Strikeout
        public bool IsFontStrikeout()
        {
            // get the text range working with
            HtmlTextRange range = GetTextRange();
            // return the font property
            return IsFontStrikeout(range);

        } //IsFontStrikeout

        // determine if the current font selected is Superscript given a range
        private bool IsFontSuperscript(HtmlTextRange range)
        {
            // determine the SUPERSCRIPT property
            object currentSuperscript = QueryCommandRange(range, HTML_COMMAND_SUPERSCRIPT);
            return (currentSuperscript is System.Boolean) ? (bool)currentSuperscript : false;

        } //IsFontSuperscript

        // determine if the current font selected is Superscript
        public bool IsFontSuperscript()
        {
            // get the text range working with
            HtmlTextRange range = GetTextRange();
            // return the font property
            return IsFontSuperscript(range);

        } //IsFontSuperscript

        // determine if the current font selected is Subscript given a range
        private bool IsFontSubscript(HtmlTextRange range)
        {
            // determine the SUBSCRIPT property
            object currentSubscript = QueryCommandRange(range, HTML_COMMAND_SUBSCRIPT);
            return (currentSubscript is System.Boolean) ? (bool)currentSubscript : false;

        } //IsFontSubscript

        // determine if the current font selected is Subscript
        public bool IsFontSubscript()
        {
            // get the text range working with
            HtmlTextRange range = GetTextRange();
            // return the font property
            return IsFontSubscript(range);

        } //IsFontSubscript


        // determine the color of the selected text range
        // set to the default value of not defined
        private Color GetFontColor()
        {
            object fontColor = QueryCommandRange(HTML_COMMAND_FORE_COLOR);
            return (fontColor is System.Int32) ? ColorTranslator.FromWin32((int)fontColor) : _bodyForeColor;

        } //GetFontColor

        #endregion

        #region Find and Replace Operations

        // dialog to allow the user to perform a find and replace
        public void FindReplacePrompt()
        {

            // define a default value for the text to find
            HtmlTextRange range = GetTextRange();
            string initText = string.Empty;
            if (range != null)
            {
                string findText = range.text;
                if (findText != null) initText = findText.Trim();
            }

            // prompt the user for the new href
            using (FindReplaceForm dialog = new FindReplaceForm(initText,
                       new FindReplaceResetDelegate(this.FindReplaceReset),
                       new FindFirstDelegate(this.FindFirst),
                       new FindNextDelegate(this.FindNext),
                       new FindReplaceOneDelegate(this.FindReplaceOne),
                       new FindReplaceAllDelegate(this.FindReplaceAll)))
            {
                DefineDialogProperties(dialog);
                DialogResult result = dialog.ShowDialog(this.Parent);
            }

        } //FindReplacePrompt


        // reset the find and replace options to initialize a new search
        public void FindReplaceReset()
        {
            // reset the range being worked with
            _findRange = (HtmlTextRange)GetBody().createTextRange();
            ((HtmlSelection)GetDomDocument().selection).empty();

        } //FindReplaceReset


        // finds the first occurrence of the given text string
        // uses false for the search options
        public bool FindFirst(string findText)
        {
            return FindFirst(findText, false, false);

        } //FindFirst

        // finds the first occurrence of the given text string
        public bool FindFirst(string findText, bool matchWhole, bool matchCase)
        {
            // reset the text search range prior to making any calls
            FindReplaceReset();

            // calls the Find Next once search has been initialized
            return FindNext(findText, matchWhole, matchCase);

        } //FindFirst


        // finds the next occurrence of a given text string
        // assumes a previous search was made
        // uses false for the search options
        public bool FindNext(string findText)
        {
            return FindNext(findText, false, false);

        } //FindNext

        // finds the next occurrence of a given text string
        // assumes a previous search was made
        public bool FindNext(string findText, bool matchWhole, bool matchCase)
        {
            return (FindText(findText, matchWhole, matchCase) != null ? true : false);

        } //FindNext


        // replace the first occurrence of the given string with the other
        // uses false for the search options
        public bool FindReplaceOne(string findText, string replaceText)
        {
            return FindReplaceOne(findText, replaceText);

        } //FindReplaceOne

        // replace the first occurrence of the given string with the other
        public bool FindReplaceOne(string findText, string replaceText, bool matchWhole, bool matchCase)
        {
            // find the given text within the find range
            HtmlTextRange replaceRange = FindText(findText, matchWhole, matchCase);
            if (replaceRange != null)
            {
                // if text found perform a replace
                replaceRange.text = replaceText;
                replaceRange.select();
                // replace made to return success
                return true;
            }
            else
            {
                // no replace was made so return false
                return false;
            }

        } //FindReplaceOne


        // replaces all the occurrence of the given string with the other
        // uses false for the search options
        public int FindReplaceAll(string findText, string replaceText)
        {
            return FindReplaceAll(findText, replaceText, false, false);

        } //FindReplaceAll

        // replaces all the occurrences of the given string with the other
        public int FindReplaceAll(string findText, string replaceText, bool matchWhole, bool matchCase)
        {
            int found = 0;
            HtmlTextRange replaceRange = null;

            do
            {
                // find the given text within the find range
                replaceRange = FindText(findText, matchWhole, matchCase);
                // if found perform a replace
                if (replaceRange != null)
                {
                    replaceRange.text = replaceText;
                    found++;
                }
            } while (replaceRange != null);

            // return count of items repalced
            return found;

        } //FindReplaceAll


        // function to perform the actual find of the given text
        private HtmlTextRange FindText(string findText, bool matchWhole, bool matchCase)
        {
            // define the search options
            int searchOptions = 0;
            if (matchWhole) searchOptions = searchOptions + 2;
            if (matchCase) searchOptions = searchOptions + 4;

            if (_findRange.text == null)
                return null;

            // perform the search operation
            if (_findRange.findText(findText, _findRange.text.Length, searchOptions))
            {
                // select the found text within the document
                _findRange.select();
                // limit the new find range to be from the newly found text
                HtmlTextRange foundRange = GetDomDocument().selection.createRange() as HtmlTextRange;
                _findRange = (HtmlTextRange)GetBody().createTextRange();
                _findRange.setEndPoint("StartToEnd", foundRange);
                // text found so return this selection
                return foundRange;
            }
            else
            {
                // reset the find ranges
                FindReplaceReset();
                // no text found so return null range
                return null;
            }

        } //FindText 

        #endregion

        #region Document Processing Operations

        // print the html text using the document print command
        // print preview is not supported
        public void DocumentPrint()
        {
            ExecuteCommandDocument(HTML_COMMAND_TEXT_PRINT);

        } //TextPrint

        #endregion

        #region Linkuri

        // create a web link from the users selected text
        public void InsertLink(string href)
        {
            ExecuteCommandRange(HTML_COMMAND_INSERT_LINK, href);

        } //InsertLink

        public string CreateLinkHTML(string pText, string pLink)
        {
            return string.Concat("<A href=\"", pLink, "\">", pText, "</A>");
        }

        // public function to insert a link and prompt a user for the href
        // calls the public InsertLink method
        public void InsertLinkPrompt()
        {
            // get the text range working with
            HtmlTextRange range = GetTextRange();
            string hrefText = (range == null) ? null : range.text;
            string hrefLink = string.Empty;
            NavigateActionOption target;

            // ensure have text in the range otherwise nothing works
            if (range != null)
            {
                // calculate the items working with
                HtmlAnchorElement anchor = null;
                HtmlElement element = (HtmlElement)range.parentElement();
                // parse up the tree until the anchor element is found
                while (element != null && !(element is HtmlAnchorElement))
                {
                    element = (HtmlElement)element.parentElement;
                }
                // extract the HREF properties
                if (element is HtmlAnchorElement)
                {
                    anchor = (HtmlAnchorElement)element;
                    if (anchor.href != null) hrefLink = anchor.href;
                }
                // if text is a valid href then set the link
                if (hrefLink == string.Empty && IsValidHref(hrefText))
                {
                    hrefLink = hrefText;
                }

                // prompt the user for the new href
                using (EnterHrefForm dialog = new EnterHrefForm())
                {
                    dialog.HrefText = hrefText;
                    dialog.HrefLink = hrefLink;
                    DefineDialogProperties(dialog);
                    DialogResult result = dialog.ShowDialog(this.Parent);
                    // based on the user interaction perform the neccessary action
                    // after one has a valid href
                    if (result == DialogResult.Yes)
                    {
                        hrefLink = dialog.HrefLink;
                        target = dialog.HrefTarget;
                        if (IsValidHref(hrefLink))
                        {
                            // insert or update the current link
                            if (anchor == null)
                            {
                                if (string.IsNullOrEmpty(hrefText) || !dialog.HrefText.Equals(hrefText))
                                {
                                    range.pasteHTML(CreateLinkHTML(dialog.HrefText, hrefLink));
                                    range.collapse(false);
                                    range.select();
                                }
                                else
                                {
                                    ExecuteCommandRange(range, HTML_COMMAND_INSERT_LINK, hrefLink);
                                    element = (HtmlElement)range.parentElement();
                                    // parse up the tree until the anchor element is found
                                    while (element != null && !(element is HtmlAnchorElement))
                                    {
                                        element = (HtmlElement)element.parentElement;
                                    }
                                    if (element != null) anchor = (HtmlAnchorElement)element;
                                }
                            }
                            else
                            {
                                anchor.href = hrefLink;
                            }
                            if (anchor != null && target != NavigateActionOption.Default)
                            {
                                anchor.target = (target == NavigateActionOption.NewWindow) ? TARGET_WINDOW_NEW : TARGET_WINDOW_SAME;
                            }
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        // remove the current link assuming present
                        if (anchor != null) ExecuteCommandRange(range, HTML_COMMAND_REMOVE_LINK, null); ;
                    }
                }
            }
            else
            {
                throw new HtmlEditorException("Must Select Text from which to create a Link.", "InsertLink");
            }

        } //InsertLinkPrompt

        // remove a web link from the users selected text
        public void RemoveLink()
        {
            ExecuteCommandRange(HTML_COMMAND_REMOVE_LINK, null);

        } //InsertLink

        #endregion

        #region Utility Functions

        // performs a parse of the string into an enum
        private object TryParseEnum(Type enumType, string stringValue, object defaultValue)
        {
            // try the enum parse and return the default 
            object result = defaultValue;
            try
            {
                // try the enum parse operation
                result = Enum.Parse(enumType, stringValue, true);
            }
            catch (Exception)
            {
                // default value will be returned
                result = defaultValue;
            }

            // return the enum value
            return result;

        } //TryParseEnum


        // perform of a string into a byte number
        private byte TryParseByte(string stringValue, byte defaultValue)
        {
            byte result = defaultValue;
            double doubleValue;
            // try the conversion to a double number
            if (Double.TryParse(stringValue, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out doubleValue))
            {
                try
                {
                    // try a cast to a byte
                    result = (byte)doubleValue;
                }
                catch (Exception)
                {
                    // default value will be returned
                    result = defaultValue;
                }
            }

            // return the byte value
            return result;

        } //TryParseByte


        // perform of a string into a byte number
        private ushort TryParseUshort(string stringValue, ushort defaultValue)
        {
            ushort result = defaultValue;
            double doubleValue;
            // try the conversion to a double number
            if (Double.TryParse(stringValue, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out doubleValue))
            {
                try
                {
                    // try a cast to a byte
                    result = (ushort)doubleValue;
                }
                catch (Exception)
                {
                    // default value will be returned
                    result = defaultValue;
                }
            }

            // return the byte value
            return result;

        } //TryParseUshort


        // ensure dialog resembles the user form characteristics
        private void DefineDialogProperties(Form dialog)
        {
            // set ambient control properties
            dialog.Font = this.Parent.Font;
            dialog.ForeColor = this.Parent.ForeColor;
            dialog.BackColor = this.Parent.BackColor;
            dialog.Cursor = this.Parent.Cursor;
            dialog.RightToLeft = this.Parent.RightToLeft;
        } //DefineDialogProperties

        // determine if a string url is valid
        private bool IsValidHref(string href)
        {
            if (string.IsNullOrEmpty(href)) return false;

            return Regex.IsMatch(href, HREF_TEST_EXPRESSION, RegexOptions.IgnoreCase);

        } //IsValidHref

        // removes references to about:blank from the anchors
        private void RebaseAnchorUrl()
        {
            if (rebaseUrlsNeeded)
            {
                // review the anchors and remove any references to about:blank
                mshtml.HTMLBody body = GetBody();
                IHTMLElementCollection anchors = body.getElementsByTagName(ANCHOR_TAG);
                foreach (IHTMLElement element in anchors)
                {
                    try
                    {
                        IHTMLAnchorElement anchor = element as IHTMLAnchorElement;
                        string href = anchor.href;
                        // see if href need updating
                        if (href != null && Regex.IsMatch(href, BLANK_HTML_PAGE, RegexOptions.IgnoreCase))
                        {
                            anchor.href = href.Replace(BLANK_HTML_PAGE, string.Empty);
                        }
                    }
                    catch (Exception)
                    {
                        // ignore any errors
                    }
                }
            }

        } //RebaseAnchorUrl

        #endregion

        #region Selected Text Formatting Operations

        // Tab the current line to the right
        public void FormatTabRight()
        {
            ExecuteCommandRange(HTML_COMMAND_INDENT, null);

        } //FormatTabRight

        // Tab the current line to the left
        public void FormatTabLeft()
        {
            ExecuteCommandRange(HTML_COMMAND_OUTDENT, null);

        } //FormatTabLeft

        // using the document toggles the selection with a Strikeout tag
        public void FormatStrikeout()
        {
            ExecuteCommandRange(HTML_COMMAND_STRIKE_THROUGH, null);

        } //FormatStrikeout

        // using the document toggles the selection with a Subscript tag
        public void FormatSubscript()
        {
            ExecuteCommandRange(HTML_COMMAND_SUBSCRIPT, null);

        } //FormatSubscript

        // using the document toggles the selection with a Superscript tag
        public void FormatSuperscript()
        {
            ExecuteCommandRange(HTML_COMMAND_SUPERSCRIPT, null);

        } //FormatSuperscript

        #endregion

        #region MsHtml Command Processing

        // executes the execCommand on the selected range
        private void ExecuteCommandRange(string command, object data)
        {
            // obtain the selected range object and execute command
            HtmlTextRange range = GetTextRange();
            ExecuteCommandRange(range, command, data);

        } // ExecuteCommandRange

        // executes the execCommand on the selected range (given the range)
        private void ExecuteCommandRange(HtmlTextRange range, string command, object data)
        {
            try
            {
                if (range != null)
                {
                    // ensure command is a valid command and then enabled for the selection
                    if (range.queryCommandSupported(command))
                    {
                        if (range.queryCommandEnabled(command))
                        {
                            // mark the selection with the appropriate tag
                            range.execCommand(command, false, data);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Unknown error so inform user
                throw new HtmlEditorException("Unknown MSHTML Error.", command, ex);
            }

        } // ExecuteCommandRange


        // executes the execCommand on the document
        private void ExecuteCommandDocument(string command)
        {
            ExecuteCommandDocument(command, false);

        } // ExecuteCommandDocument

        // executes the execCommand on the document with a system prompt
        private void ExecuteCommandDocumentPrompt(string command)
        {
            ExecuteCommandDocument(command, true);

        } // ExecuteCommandDocumentPrompt

        // executes the execCommand on the document with a system prompt
        private void ExecuteCommandDocument(string command, bool prompt)
        {
            try
            {
                // ensure command is a valid command and then enabled for the selection
                if (GetDomDocument().queryCommandSupported(command))
                {
                    // if (document.queryCommandEnabled(command)) {}
                    // Test fails with a COM exception if command is Print

                    // execute the given command
                    GetDomDocument().execCommand(command, prompt, null);
                }
            }
            catch (Exception ex)
            {
                // Unknown error so inform user
                throw new HtmlEditorException("Unknown MSHTML Error.", command, ex);
            }

        } // ExecuteCommandDocumentPrompt


        // determines the value of the command
        private object QueryCommandRange(string command)
        {
            // obtain the selected range object and execute command
            HtmlTextRange range = GetTextRange();
            return QueryCommandRange(range, command);

        } // QueryCommandRange

        // determines the value of the command
        private object QueryCommandRange(HtmlTextRange range, string command)
        {
            object retValue = null;
            if (range != null)
            {
                try
                {
                    // ensure command is a valid command and then enabled for the selection
                    if (range.queryCommandSupported(command))
                    {
                        if (range.queryCommandEnabled(command))
                        {
                            retValue = range.queryCommandValue(command);
                        }
                    }
                }
                catch (Exception)
                {
                    // have unknown error so set return to null
                    retValue = null;
                }
            }

            // return the obtained value
            return retValue;

        } //QueryCommandRange

        // get the selected range object
        private HtmlElement GetFirstControl()
        {
            // define the selected range object
            HtmlSelection selection;
            HtmlControlRange range;
            HtmlElement control = null;

            try
            {
                // calculate the first control based on the user selection
                selection = GetDomDocument().selection;
                if (IsStatedTag(selection.type, SELECT_TYPE_CONTROL))
                {
                    range = selection.createRange() as HtmlControlRange;
                    if (range.length > 0) control = range.item(0);
                }
            }
            catch (Exception)
            {
                // have unknown error so set return to null
                control = null;
            }

            return control;

        } // GetFirstControl

        // obtains a control range to be worked with
        private HtmlControlRange GetAllControls()
        {
            // define the selected range object
            HtmlSelection selection;
            HtmlControlRange range = null;

            try
            {
                // calculate the first control based on the user selection
                selection = GetDomDocument().selection;
                if (IsStatedTag(selection.type, SELECT_TYPE_CONTROL))
                {
                    range = selection.createRange() as HtmlControlRange;
                }
            }
            catch (Exception)
            {
                // have unknow error so set return to null
                range = null;
            }

            return range;

        } //GetAllControls

        #endregion

    }
}
