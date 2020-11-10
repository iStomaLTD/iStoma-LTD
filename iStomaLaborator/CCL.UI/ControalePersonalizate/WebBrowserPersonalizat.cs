using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;
using ILL.iStomaLab;
using mshtml;

using HtmlSelection = mshtml.IHTMLSelectionObject;
using HtmlTextRange = mshtml.IHTMLTxtRange;
using CCL.iStomaLab;

namespace CCL.UI
{
    [ComVisibleAttribute(true)]
    [ClassInterfaceAttribute(ClassInterfaceType.AutoDispatch)]
    [DockingAttribute(DockingBehavior.AutoDock)]
    [PermissionSetAttribute(SecurityAction.InheritanceDemand, Name = "FullTrust")]
    [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
    public partial class WebBrowserPersonalizat : WebBrowser, CCL.UI.IMembriComuniControalePersonalizate
    {

        #region Declaratii generale

        private bool _bIsInModificationMode = true;
        private bool _bIsInReadOnlyMode = false;
        private string _sProprietateCorespunzatoare; //utila pentru Reflection (initializare dinamica)

        protected const string SELECT_TYPE_TEXT = "text";
        protected const string SELECT_TYPE_CONTROL = "control";
        protected const string SELECT_TYPE_NONE = "none";

        #endregion

        #region Proprietati

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectionStart
        {
            get
            {
                if (this.Document != null)
                    return (int)this.Document.InvokeScript("getSelectionStart", null);

                return 0;
            }
            set { }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectionLength
        {
            get
            {
                object lungime = this.Document.InvokeScript("getSelectionLength", null);
                if (lungime == null)
                    return 0;

                return (int)lungime;
            }
            set { }
        }

        public new bool ScrollBarsEnabled
        {
            get { return base.ScrollBarsEnabled; }
            set { base.ScrollBarsEnabled = value; }
        }

        [Description("Precizam expres ca acest control este intotdeauna in mod ReadOnly (Metoda AllowModification nu va avea niciun efect)")]
        [Category("iDava")]
        public bool IsInReadOnlyMode
        {
            get { return this._bIsInReadOnlyMode; }
            set
            {
                this._bIsInReadOnlyMode = value;
            }
        }

        [Description("Verificam accesibilitatea controlului")]
        [Category("iDava")]
        [Browsable(false)]
        public bool IsInModificationMode
        {
            get
            {
                return this._bIsInModificationMode;// && Convert.ToBoolean(this.Document.InvokeScript("SePoateFaceInserarea"));
            }
        }

        public void SelecteazaTextul()
        {
            //this.Document.InvokeScript("SelecteazaTotTextul");
            this.Document.ExecCommand("SelectAll", false, null);
        }

        public List<int> Cauta(string pText)
        {
            return CUtil.ExtrageListaPozitiiAparente(this.Text, pText);
        }

        public void SelecteazaLaPozitia(int pPozitie, int pLungimeText)
        {
        }

        [Description("Pentru a implementa interfata IMembriComuniControalePersonalitate. Nu are niciun alt rol")]
        [Category("iDava")]
        public bool HideSelection
        {
            get { return true; }
            set { }
        }

        public void Paste()
        {
            this.Document.ExecCommand("Paste", false, null);
        }

        public void Undo()
        {
            this.Document.ExecCommand("Undo", false, null);
        }

        public void Redo()
        {
            this.Document.ExecCommand("Redo", false, null);
        }

        /// <summary>
        /// Se copiaza fie textul selectat fie textul controlului selectat in cazul in care nu exista text selectat
        /// </summary>
        public void Copy()
        {
            this.Document.ExecCommand("Copy", false, null);
        }

        public void Cut()
        {
            this.Document.ExecCommand("Cut", false, null);
        }

        public string SelectedText
        {
            get
            {
                HtmlTextRange range = GetTextRange();

                if (range == null)
                    return string.Empty;

                return range.text;
            }
            set
            {
            }
        }

        [Description("Precizam numele proprietatii obiectului sursa ce contine valoarea cu care vom initializa textul acestei zone. Utila pentru utilizarea initializarii dinamice.")]
        [Category("iDava")]
        public string ProprietateCorespunzatoare
        {
            get { return this._sProprietateCorespunzatoare; }
            set
            {
                this._sProprietateCorespunzatoare = value;
            }
        }

        [Description("Textul zonei de text")]
        [Category("iDava")]
        public override string Text
        {
            get { return this.DocumentText; }
            set
            {
                this.DocumentText = value;
                AllowModification(this._bIsInModificationMode);
            }
        }

        [Browsable(false)]
        public string TextFaraDiacritice
        {
            get { return CUtil.InlocuiesteDiacritice(this.Document.Body.InnerText.Trim()); }
        }

        #endregion

        #region Constructori

        public WebBrowserPersonalizat()
        {
            SeteazaDoubleBuffer();
            AdaugaMeniuContextual();
        }

        public WebBrowserPersonalizat(IContainer container)
            : this()
        {
            container.Add(this);
        }

        protected void SeteazaDoubleBuffer()
        {
            // this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        public void Initializeaza()
        {
            this.GoBlank();
            this.Document.OpenNew(true);
        }

        public void Initializeaza(string pText)
        {
            this.GoBlank();
            this.Document.OpenNew(false);
            this.Document.Write(pText);
            this.Refresh();
        }

        public void GoBlank()
        {
            this.Navigate("about:blank");
        }

        #endregion

        #region Metode publice

        public void SetOrientarePrint(bool formatA5, bool formatHalfA4, bool formatHalfA4x2)
        {
            //((mshtml.IHTMLDocument2)this.Document.DomDocument).DefaultPageSettings.Landscape = true;
        }

        public event System.EventHandler IncepeActiune;
        public event System.EventHandler FinalizeazaActiune;
        public void AnuntaIncepereActiune(EnumTipActiuneControl pTipActiune)
        {
            try
            {
                if (IncepeActiune != null)
                    IncepeActiune(this, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IHMUtile.getText(605), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AnuntaFinalizareActiune(EnumTipActiuneControl pTipActiune)
        {
            try
            {
                if (FinalizeazaActiune != null)
                    FinalizeazaActiune(this, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IHMUtile.getText(605), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool AcceptaActiunea(EnumTipActiuneControl pTipActiune)
        {
            //Orice fel de modificare este permisa doar in modul modificare si doar daca lista este editabila
            //Nu acceptam decuparea decat in modificare
            switch (pTipActiune)
            {
                case EnumTipActiuneControl.SelectareText:
                    return true;
                case EnumTipActiuneControl.Cautare:
                    return false;
                case EnumTipActiuneControl.Diacritice:
                    return true;
                case EnumTipActiuneControl.Undo:
                    return false;
                case EnumTipActiuneControl.Decupare:
                case EnumTipActiuneControl.Inserare:
                case EnumTipActiuneControl.Mesaj:
                    return this._bIsInModificationMode;
                case EnumTipActiuneControl.Export:
                case EnumTipActiuneControl.Printare:
                    return true;
                case EnumTipActiuneControl.CopiereTabel:
                    return false;
            }

            return false;
        }

        public void ExecutaActiunea(EnumTipActiuneControl pTipActiune)
        {
            switch (pTipActiune)
            {
                case EnumTipActiuneControl.Diacritice:
                    break;
                case EnumTipActiuneControl.Undo:
                    break;
                case EnumTipActiuneControl.Cautare:
                    break;
                case EnumTipActiuneControl.Decupare:
                    break;
                case EnumTipActiuneControl.Inserare:
                    break;
                case EnumTipActiuneControl.Export:
                    break;
                case EnumTipActiuneControl.Printare:
                    this.ShowPrintPreviewDialog();
                    break;
                case EnumTipActiuneControl.CopiereTabel:
                    break;
                case EnumTipActiuneControl.SelectareText:
                    break;
            }
        }

        /// <summary>
        /// Trecem din mod modificare in mod lectura si invers
        /// </summary>
        /// <param name="pbInModificationMode"></param>
        public void AllowModification(bool pbInModificationMode)
        {
            this._bIsInModificationMode = pbInModificationMode;
        }

        public virtual void InsereazaText(string pText)
        {
            Object[] objArray = new Object[1];
            objArray[0] = (Object)pText;
            object idZonaInsertie = this.Document.InvokeScript("InsereazaText", objArray);

            objArray[0] = (Object)idZonaInsertie;
            this.Document.InvokeScript("ActiveazaControl", objArray);
        }

        public static string IncarcaJavaScript()
        {
            StringBuilder JavaScript = new StringBuilder();

            JavaScript.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=iso-8859-1\" />");
            JavaScript.Append("<script type=\"text/javascript\">" + CCL.UI.IHMUtile.jQuery + "</script>");
            JavaScript.Append("<script type=\"text/javascript\">" + CCL.UI.IHMUtile.jQueryUI + "</script>");
            JavaScript.Append("<script type=\"text/javascript\">" + CCL.UI.IHMUtile.FunctiiJSStandard + "</script>");
            JavaScript.Append("<script type=\"text/javascript\">");
            JavaScript.Append("function AllowModification(InModificare)");
            JavaScript.Append("{$('input[type=\"image\"]').each(function(){");
            JavaScript.Append("if(InModificare == false){$(this).hide('fast');}");
            JavaScript.Append("else{$(this).show('fast');}});");
            JavaScript.Append("$('input[type=\"text\"], textarea').each(function(){");
            JavaScript.Append("if(InModificare == false){$(this).attr('readonly','readonly');}");
            JavaScript.Append("else{$(this).removeAttr('readonly');}});}");
            JavaScript.Append("$(document).ready(function(){");
            JavaScript.Append(" $(\"*\").focus(function(){");
            JavaScript.Append("     lIdControlFocus = this.id;");
            JavaScript.Append(" });");
            JavaScript.Append(" $(\'a,input[type=\"text\"], input[type=\"image\"]\').click(function(){");
            JavaScript.Append("     window.external.GestioneazaEvenimentWebBrowser(this.id,null);");
            JavaScript.Append(" });");
            JavaScript.Append(" $('textarea').blur(function(){");
            JavaScript.Append("     window.external.GestioneazaEvenimentWebBrowser(this.id, this.value);");
            JavaScript.Append(" });");
            JavaScript.Append("});");
            JavaScript.Append("</script>");
            //"<script type=\"text/javascript\">$(document).ready(function(){$(\"a\").draggable();});</script>";
            return JavaScript.ToString();
        }

        public static string IncarcaCSS()
        {
            return "<style type='text/css'>" + CCL.UI.IHMUtile.StilCSSAplicatie + "</style>";
        }

        #endregion

        #region Metode private

        private void AdaugaMeniuContextual()
        {
            //Adaugam meniul contextual
            this.ContextMenuStrip = ControaleCreateDinamic.GetMeniuContextualZonaText();
        }

        #endregion

        #region Metode protected

        protected Form GetFormParinte()
        {
            return IHMUtile.GetFormParinte(this);

            //Control parinte = this.Parent;

            //do
            //{
            //    if(parinte != null)
            //    {
            //        if (parinte is Form)
            //            return parinte as Form;
            //        else
            //            parinte = parinte.Parent;
            //    }

            //} while (parinte == null);

            //return null;
        }

        protected IHTMLDocument2 GetDomDocument()
        {
            return this.Document.DomDocument as IHTMLDocument2;
        }

        // get the selected range object
        protected HtmlTextRange GetTextRange()
        {
            // define the selected range object
            HtmlSelection selection;
            HtmlTextRange range = null;

            try
            {
                // calculate the text range based on user selection
                selection = GetDomDocument().selection;
                if (IsStatedTag(selection.type, SELECT_TYPE_TEXT) || IsStatedTag(selection.type, SELECT_TYPE_NONE))
                {
                    range = selection.createRange() as HtmlTextRange;
                }
            }
            catch (Exception)
            {
                // have unknown error so set return to null
                range = null;
            }

            return range;

        } // GetTextRange

        // determine if the tage name is of the correct type
        protected bool IsStatedTag(string tagText, string tagType)
        {
            return (string.Compare(tagText, tagType, true) == 0) ? true : false;

        } //IsStatedTag

        #endregion

        #region Evenimente

        protected override void OnEnter(EventArgs e)
        {
            ControaleCreateDinamic.SetControlTinta(this);
            base.OnEnter(e);
        }

        #endregion

    }
}
