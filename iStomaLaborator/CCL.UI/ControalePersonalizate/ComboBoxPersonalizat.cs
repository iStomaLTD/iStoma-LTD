using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ILL.iStomaLab;
using ILL.iStomaLab;
using CCL.iStomaLab;

namespace CCL.UI
{
    [DefaultEvent("CerereUpdate")]
    public class ComboBoxPersonalizat : System.Windows.Forms.ComboBox,
        CCL.UI.IMembriComuniControalePersonalizate, IAllowModification
    {
        #region Declaratii Generale

        private System.ComponentModel.IContainer components = null;
        public event ZonaModificata CerereUpdate;
        public delegate void ZonaModificata(object psender, string proprietate, object sNouaValoare);

        private bool _bIsInModificationMode = true;
        private bool _bIsInReadOnlyMode = false;
        protected bool lSeIncarca = false;
        private string _sVecheaValoare;
        private bool _bAutoComplete = false;
        private bool _bInitByPropertyText = false; //Ne spune ca modificarea valorii controlului a fost facuta prin proprietatea Text
        private bool _bRaiseEventLaModificareProgramatica = false; //Pentru a face AfterUpdate chiar si la modificarea programatica a valorii 
        private EnumTipLista _lTipLista = EnumTipLista.Nespecificat;

        private string _sProprietateCorespunzatoare; //utila pentru Reflection (initializare dinamica)

        #endregion

        #region Enumerari si Structuri

        public enum EnumTipLista : int
        {
            Nespecificat = 0,
            Numerica = 1
        }

        #endregion

        #region Proprietati

        [Description("Id-ul obiectului selectat (0 daca nu avem selectie)")]
        [Category("iDava")]
        [Browsable(false)]
        public int IdObiectCorespunzator
        {
            get
            {
                if (this.SelectedItem == null)
                    return 0;
                else
                    return ((ICheie)this.SelectedItem).Id;
            }
        }

        [Description("Tipul listei. Pentru lista numerica folositi metoda de initializare")]
        [Category("iDava")]
        public EnumTipLista TipulListei
        {
            get { return this._lTipLista; }
            set { this._lTipLista = value; }
        }

        [Description("Precizam expres ca acest control este intotdeauna in mod ReadOnly (Metoda AllowModification nu va avea niciun efect)")]
        [Category("iDava")]
        public bool IsInReadOnlyMode
        {
            get { return this._bIsInReadOnlyMode; }
            set { this._bIsInReadOnlyMode = value; }
        }

        [Description("Verificam accesibilitatea controlului")]
        [Category("iDava")]
        [Browsable(false)]
        public bool IsInModificationMode
        {
            get { return this._bIsInModificationMode; }
        }

        [Description("Precizam numele proprietatii obiectului sursa ce contine valoarea cu care vom initializa textul acestei zone. Utila pentru utilizarea initializarii dinamice.")]
        [Category("iDava")]
        public string ProprietateCorespunzatoare
        {
            get { return this._sProprietateCorespunzatoare; }
            set { this._sProprietateCorespunzatoare = value; }
        }

        [Description("Precizam textul din lista derulanta. Util doar in cazul in care DropDownStyle = DropDown")]
        [Category("iDava")]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                bool reinitLock = false; //   'permite gestiunea dublului-apel la proprietate. Cateodata base.Text face apel la proprietatea Text, ceea ce pune probleme pentru lock
                this.lSeIncarca = true;
                try
                {
                    if (!this._bInitByPropertyText)
                    {
                        this._bInitByPropertyText = true;
                        reinitLock = true;
                    }
                    base.Text = value;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (reinitLock == true) this._bInitByPropertyText = false;
                    this.lSeIncarca = false;
                }
            }
        }

        protected void setText(string pText)
        {
            base.Text = pText;
        }

        [Description("Activam auto completarea. Util doar in cazul in care DropDownStyle = DropDown")]
        [Category("iDava")]
        public bool AutoCompletePersonalizat
        {
            get
            {
                return this._bAutoComplete;
            }
            set
            {
                this._bAutoComplete = value;
            }
        }

        [Description("Pentru a implementa interfata IMembriComuniControalePersonalitate. Nu are niciun alt rol")]
        [Category("iDava")]
        public bool HideSelection
        {
            get { return true; }
            set { }
        }

        #endregion

        #region Constructori

        public ComboBoxPersonalizat()
        {
            SeteazaDoubleBuffer();
            InitializeComponent();
        }

        public ComboBoxPersonalizat(IContainer container)
            : this()
        {
            container.Add(this);
        }

        private void SeteazaDoubleBuffer()
        {
            // this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void InitializeazaListaNumerica(int plPrimaValoare, int plUltimaValoare, int plPas)
        {
            this.lSeIncarca = true;

            this.Items.Clear();
            if (plPrimaValoare == plUltimaValoare)
            {
                this.Items.Add(plPrimaValoare);
            }
            else
            {
                for (int i = plPrimaValoare; i < plUltimaValoare; i += plPas)
                {
                    this.Items.Add(i);
                }
            }

            this.lSeIncarca = false;
        }

        #endregion

        #region Metode

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

        public bool SeIncarca()
        {
            return this.lSeIncarca;
        }

        public bool AcceptaActiunea(EnumTipActiuneControl pTipActiune)
        {
            //Orice fel de modificare este permisa doar in modul modificare si doar daca lista este editabila
            //Nu acceptam decuparea decat in modificare
            switch (pTipActiune)
            {
                case EnumTipActiuneControl.SelectareText:
                    return this.DropDownStyle == System.Windows.Forms.ComboBoxStyle.DropDown;
                case EnumTipActiuneControl.Cautare:
                    return false;
                case EnumTipActiuneControl.Diacritice:
                    return (this._bIsInModificationMode &&
                            this.DropDownStyle == System.Windows.Forms.ComboBoxStyle.DropDown &&
                            this.TipulListei != EnumTipLista.Numerica);
                case EnumTipActiuneControl.Undo:
                    return false;
                case EnumTipActiuneControl.Decupare:
                    return this._bIsInModificationMode && this.DropDownStyle == System.Windows.Forms.ComboBoxStyle.DropDown;
                case EnumTipActiuneControl.Inserare:
                    return this._bIsInModificationMode && this.DropDownStyle == System.Windows.Forms.ComboBoxStyle.DropDown;
                case EnumTipActiuneControl.Export:
                case EnumTipActiuneControl.Printare:
                case EnumTipActiuneControl.CopiereTabel:
                    return false;
            }
            return false;
        }

        public void ExecutaActiunea(EnumTipActiuneControl pTipActiune)
        {

        }

        /// <summary>
        /// Trecem din mod modificare in mod lectura si invers
        /// </summary>
        /// <param name="pbInModificationMode"></param>
        public void AllowModification(bool pbInModificationMode)
        {
            //Daca modul ReadOnly este cerut expres nu vom schimba starea controlului la trecerea in mod modificare
            if (this._bIsInReadOnlyMode)
            {
                pbInModificationMode = false;
            }

            this._bIsInModificationMode = pbInModificationMode;

            this.Enabled = this._bIsInModificationMode;
        }

        /// <summary>
        /// Selectam textul din zona utila
        /// Pentru situatiile in care un camp este obligatoriu; 
        /// revenim la vechea valoare din oficiu;
        /// apoi o selectam pentru a fi usor de inlocuit
        /// 
        /// De asemenea zona de text v-a primi focusul
        /// </summary>
        public void SelecteazaTextul()
        {
            this.Focus();
            if (this.DropDownStyle == System.Windows.Forms.ComboBoxStyle.DropDown)
            {
                this.SelectionStart = 0;
                this.SelectionLength = this.Text.Length;
            }
        }

        internal void ClearSelection()
        {
            if (this.DropDownStyle == System.Windows.Forms.ComboBoxStyle.DropDown)
            {
                this.SelectionStart = 0;
                this.SelectionLength = 0;
            }
        }

        public void Paste()
        {
            if (this.DropDownStyle == System.Windows.Forms.ComboBoxStyle.DropDown)
            {
                this.SelectedText = System.Windows.Forms.Clipboard.GetText();
            }
        }

        public void Copy()
        {
            if (this.DropDownStyle == System.Windows.Forms.ComboBoxStyle.DropDown)
            {
                if (string.IsNullOrEmpty(this.SelectedText))
                    System.Windows.Forms.Clipboard.SetText(this.Text);
                else
                    System.Windows.Forms.Clipboard.SetText(this.SelectedText);
            }
        }

        public void Cut()
        {
            if (this.DropDownStyle == System.Windows.Forms.ComboBoxStyle.DropDown)
            {
                if (string.IsNullOrEmpty(this.SelectedText))
                {
                    System.Windows.Forms.Clipboard.SetText(this.Text);
                    this.Text = string.Empty;
                }
                else
                {
                    System.Windows.Forms.Clipboard.SetText(this.SelectedText);
                    this.SelectedText = string.Empty;
                }
            }
        }

        public void Undo()
        {
        }

        public void InsereazaText(string pText)
        {
            int Pozitie = this.SelectionStart;
            this.Text = this.Text.Insert(Pozitie, pText);
            this.SelectionStart = Pozitie + 1;
        }

        public new void BeginUpdate()
        {
            base.BeginUpdate();
            this.lSeIncarca = true;
        }

        public new void EndUpdate()
        {
            this.lSeIncarca = false;
            base.EndUpdate();
        }

        protected void incepeIncarcarea()
        {
            this.lSeIncarca = true;
        }

        protected void finalizeazaIncarcarea()
        {
            this.lSeIncarca = false;
        }

        #endregion

        #region Evenimente

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (this.lSeIncarca) return;

            if (this.CerereUpdate != null && this.DropDownStyle != System.Windows.Forms.ComboBoxStyle.DropDown)
            {

                if (this._lTipLista == EnumTipLista.Numerica)
                {
                    int lValoare = -1;
                    if (this.Text.Length > 0)
                    {
                        lValoare = Convert.ToInt16(this.Text);
                    }
                    CerereUpdate(this, this._sProprietateCorespunzatoare, lValoare);
                }
                else
                {
                    CerereUpdate(this, this._sProprietateCorespunzatoare, this.SelectedValue);
                }

                AllowModification(this._bIsInModificationMode);
            }
            else
            {
                base.OnSelectedIndexChanged(e);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        //protected override void OnKeyUp(System.Windows.Forms.KeyEventArgs e)
        {
            if (this._bIsInModificationMode == false || (this._lTipLista == EnumTipLista.Numerica && !char.IsNumber(Convert.ToChar(e.KeyCode))))
            {
                e.SuppressKeyPress = true;
            }
            else
            {
                if (this.DropDownStyle == System.Windows.Forms.ComboBoxStyle.DropDown)
                {
                    //Simulam AutoCompletion caci cel standard ingreuneaza exagerat incarcarea listei
                    if (Char.IsLetterOrDigit(Convert.ToChar(e.KeyCode)) && this._bAutoComplete)
                    {
                        string sTextIntrodus = this.Text.ToUpper();
                        string sValoareAfisaj = string.Empty;
                        foreach (Object xElementLista in this.Items)
                        {
                            if (!string.IsNullOrEmpty(this.DisplayMember))
                                sValoareAfisaj = Convert.ToString(CUtil.GetPropertyValue(xElementLista, this.DisplayMember));
                            else
                                sValoareAfisaj = xElementLista.ToString();
                            if (CUtil.InlocuiesteDiacritice(sValoareAfisaj.ToUpper()).StartsWith(CUtil.InlocuiesteDiacritice(sTextIntrodus)))
                            {
                                this.Text = sValoareAfisaj;
                                break;
                            }
                        }
                        this.SelectionStart = sTextIntrodus.Length;
                        this.SelectionLength = this.Text.Length - sTextIntrodus.Length;
                    }
                }
            }
        }

        protected override void OnValidated(EventArgs e)
        {
            if (this.lSeIncarca) return;

            try
            {
                //Pentru System.Windows.Forms.ComboBoxStyle.DropDownList avem SelectedIndexChanged
                if (this.CerereUpdate != null && this.DropDownStyle != System.Windows.Forms.ComboBoxStyle.DropDownList && ((!this._bInitByPropertyText) || (this._bRaiseEventLaModificareProgramatica)))
                {
                    if (this.Text != this._sVecheaValoare)
                    {
                        if (this._lTipLista == EnumTipLista.Numerica)
                        {
                            int lValoare = -1;
                            if (this.Text.Length > 0)
                            {
                                lValoare = Convert.ToInt16(this.Text);
                            }
                            CerereUpdate(this, this._sProprietateCorespunzatoare, lValoare);
                        }
                        else
                        {
                            object sValoare = this.Text;
                            if (!string.IsNullOrEmpty(this.ValueMember))
                            {
                                sValoare = this.SelectedValue;
                            }
                            CerereUpdate(this, this._sProprietateCorespunzatoare, sValoare);
                        }

                        this._sVecheaValoare = this.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IHMUtile.getText(605), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnEnter(EventArgs e)
        {
            this._sVecheaValoare = this.Text;
            base.OnEnter(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        public List<int> Cauta(string pText)
        {
            return CUtil.ExtrageListaPozitiiAparente(this.Text, pText);
        }

        public void SelecteazaLaPozitia(int pPozitie, int pLungimeText)
        {
            if (!this.IsDisposed)
            {
                this.SelectionStart = pPozitie;
                this.SelectionLength = pLungimeText;
            }
        }

        protected override void OnSelectedItemChanged(EventArgs e)
        {
            base.OnSelectedItemChanged(e);
        }

        public T GetAs<T>(T pRaspunsVid)
        {
            if (this.SelectedItem == null)
                return pRaspunsVid;

            return (T)this.SelectedItem;
        }

        public int GetSelectedValueAsInt32()
        {
            return CUtil.GetAsInt32(this.SelectedValue);
        }

        #endregion

    }
}
