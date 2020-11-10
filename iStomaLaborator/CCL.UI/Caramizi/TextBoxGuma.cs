using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ILL.iStomaLab;
using CCL.iStomaLab;

namespace CCL.UI.Caramizi
{
    [DefaultEvent("CerereUpdate")]
    public partial class TextBoxGuma : PanelContainerCCL, IAllowModification
    {
        #region Declaratii generale

        public event System.EventHandler TextChanged;
        public event CEvenimente.ZonaModificata CerereUpdate;
        public event KeyEventHandler KeyUpPersonalizat;

        public event System.EventHandler GotFocusTextBox;
        public event System.EventHandler LostFocusTextBox;

        //protected bool lEcranInModificare = true;
        protected bool lIsInReadOnlyMode = false;
        private string _sProprietateCorespunzatoare; //utila pentru Reflection (initializare dinamica)
        private bool _UtilizeazaButonGuma = true;
        private ButtonPersonalizat lButonAccept = null;
        //protected bool lSeIncarca = false;
        private bool lPoateFiControlTinta = true;
        private string lTextUltimaCautare = string.Empty;
        internal bool lModCautare = false;

        #endregion

        #region Proprietati

        [Browsable(true)]
        [DefaultValue(true)]
        public bool PoateFiControlTinta
        {
            get { return this.lPoateFiControlTinta; }
            set { this.lPoateFiControlTinta = value; }
        }

        /// <summary>
        /// Butonul ce trebuie apasat cand tasta Enter este apasata
        /// </summary>
        [Browsable(false)]
        public ButtonPersonalizat AcceptButton
        {
            get { return this.lButonAccept; }
            set { this.lButonAccept = value; }
        }

        [Description("Precizam expres ca acest control este intotdeauna in mod ReadOnly (Metoda AllowModification nu va avea niciun efect)")]
        [Category("iDava")]
        public bool IsInReadOnlyMode
        {
            get { return this.lIsInReadOnlyMode; }
            set
            {
                this.lIsInReadOnlyMode = value;
                this.txtInformatieUtila.IsInReadOnlyMode = this.lIsInReadOnlyMode;
            }
        }

        [Description("Tipul informatiei este util pentru a face automat validarile corespunzatoare")]
        [Category("iDava")]
        public CCL.UI.TextBoxPersonalizat.EnumTipInformatie TipInformatie
        {
            get { return this.txtInformatieUtila.TipInformatie; }
            set
            {
                this.txtInformatieUtila.TipInformatie = value;
            }
        }

        [Description("Pentru a face AfterUpdate chiar si la modificarea programatica a valorii")]
        [Category("Personalizate")]
        public bool RaiseEventLaModificareProgramatica
        {
            get
            {
                return this.txtInformatieUtila.RaiseEventLaModificareProgramatica;
            }
            set
            {
                this.txtInformatieUtila.RaiseEventLaModificareProgramatica = value;
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
                this.txtInformatieUtila.ProprietateCorespunzatoare = value;
            }
        }

        [Description("Textul zonei de text")]
        [Category("iDava")]
        public override string Text
        {
            get
            {
                if (CUtil.isNotNull(this.txtInformatieUtila.Text))
                    return this.txtInformatieUtila.Text.Trim();
                return string.Empty;
            }
            set
            {
                this.txtInformatieUtila.Text = value;
                this.lTextUltimaCautare = string.Empty;
                AllowModification(this.lEcranInModificare);
            }
        }

        public string TextNumarTelefon
        {
            get { return this.txtInformatieUtila.TextNumarTelefon; }
        }

        [Description("Pentru ca prima litera din aceasta zona sa fie majuscula")]
        [Category("iDava")]
        [DefaultValue(true)]
        public bool CapitalizeazaPrimaLitera
        {
            get { return this.txtInformatieUtila.CapitalizeazaPrimaLitera; }
            set { this.txtInformatieUtila.CapitalizeazaPrimaLitera = value; }
        }

        [Description("Pentru ca prima litera a fiecarui cuvant din aceasta zona sa fie majuscula")]
        [Category("iDava")]
        [DefaultValue(false)]
        public bool CapitalizeazaCuvintele
        {
            get { return this.txtInformatieUtila.CapitalizeazaCuvintele; }
            set { this.txtInformatieUtila.CapitalizeazaCuvintele = value; }
        }

        [Browsable(false)]
        public string TextFaraDiacritice
        {
            get { return CUtil.InlocuiesteDiacritice(this.txtInformatieUtila.Text.Trim()); }
        }

        [Description("ScrollBars-ul zonei de text")]
        [Category("iDava")]
        public ScrollBars ScrollBars
        {
            get { return this.txtInformatieUtila.ScrollBars; }
            set
            {
                this.txtInformatieUtila.ScrollBars = value;
            }
        }

        [Description("Culoarea de fundal a zonei de text")]
        [Category("iDava")]
        public Color TextBackColor
        {
            get { return this.txtInformatieUtila.BackColor; }
            set
            {
                this.txtInformatieUtila.BackColor = value;
            }
        }

        [Description("Stilul bordurii zonei de text")]
        [Category("iDava")]
        public BorderStyle TextBorderStyle
        {
            get { return this.txtInformatieUtila.BorderStyle; }
            set
            {
                this.txtInformatieUtila.BorderStyle = value;
            }
        }

        public bool UseSystemPasswordChar
        {
            get { return this.txtInformatieUtila.UseSystemPasswordChar; }
            set
            {
                this.txtInformatieUtila.UseSystemPasswordChar = value;
            }
        }

        [Description("MaxLength-ul zonei de text")]
        [Category("iDava")]
        public int MaxLength
        {
            get { return this.txtInformatieUtila.MaxLength; }
            set
            {
                this.txtInformatieUtila.MaxLength = value;
            }
        }

        [Description("Multiline-ul zonei de text")]
        [Category("iDava")]
        public bool Multiline
        {
            get { return this.txtInformatieUtila.Multiline; }
            set
            {
                this.txtInformatieUtila.Multiline = value;
                if (this.txtInformatieUtila.Multiline)
                    this.txtInformatieUtila.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
                else
                    this.txtInformatieUtila.ScrollBars = System.Windows.Forms.ScrollBars.None;
            }
        }

        [Description("Sunt situatii cand butonul guma poate fi util la crearea inregistrarii dar nicidecum la modificarea acesteia. Cu ajutorul acestei proprietati putem renunta la utilizarea butonului guma")]
        [DefaultValue(true)]
        [Category("iDava")]
        public bool UtilizeazaButonGuma
        {
            get { return this._UtilizeazaButonGuma; }
            set
            {
                this._UtilizeazaButonGuma = value;
            }
        }

        #endregion

        #region Constructori

        public TextBoxGuma()
        {
            DoubleBuffered = true;

            InitializeComponent();

            this.txtInformatieUtila.TabIndex = 0;
            this.btnGuma.TabIndex = 1;

            //Adaugam meniul contextual
            this.txtInformatieUtila.ContextMenuStrip = ControaleCreateDinamic.GetMeniuContextualZonaText();
            this.CapitalizeazaPrimaLitera = true;
            this.CapitalizeazaCuvintele = false;

            this.txtInformatieUtila.KeyDown += txtInformatieUtila_KeyDown;
            this.txtInformatieUtila.TextChanged += txtInformatieUtila_TextChanged;

            this.txtInformatieUtila.IncepeActiune += txtInformatieUtila_IncepeActiune;
            this.txtInformatieUtila.FinalizeazaActiune += txtInformatieUtila_FinalizeazaActiune;

            this.txtInformatieUtila.MouseClick += TxtInformatieUtila_MouseClick;
            this.txtInformatieUtila.GotFocus += TxtInformatieUtila_GotFocus;
            this.txtInformatieUtila.LostFocus += TxtInformatieUtila_LostFocus;
        }

        private void TxtInformatieUtila_LostFocus(object sender, EventArgs e)
        {
            if (this.LostFocusTextBox != null)
                LostFocusTextBox(this, null);
        }

        private void TxtInformatieUtila_GotFocus(object sender, EventArgs e)
        {
            if (this.GotFocusTextBox != null)
                GotFocusTextBox(this, null);
        }

        private void TxtInformatieUtila_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.GotFocusTextBox != null)
                GotFocusTextBox(this, null);
        }

        void txtInformatieUtila_TextChanged(object sender, EventArgs e)
        {
            this.OnTextChanged(e);

            if (!this.lSeIncarca && this.TextChanged != null)
                TextChanged(this, null);
        }

        void txtInformatieUtila_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && this.KeyUpPersonalizat != null)
            {
                KeyUpPersonalizat(this, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else
                this.OnKeyDown(e);
        }

        #endregion

        #region Metode

        public void Capitalizare(bool pCapitalizeazaCuvintele, bool pCapitalizeazaPrimaLitera)
        {
            this.CapitalizeazaCuvintele = pCapitalizeazaCuvintele;
            this.CapitalizeazaPrimaLitera = pCapitalizeazaPrimaLitera;
        }

        protected bool cereUpdate()
        {
            if ((!this.lModCautare || (this.lModCautare && !this.lTextUltimaCautare.Equals(this.txtInformatieUtila.Text))) && this.CerereUpdate != null)
            {
                this.lTextUltimaCautare = this.txtInformatieUtila.Text;
                CerereUpdate(this, this._sProprietateCorespunzatoare, this.txtInformatieUtila.Text);

                return true;
            }

            return false;
        }

        internal void InsereazaText(string pText)
        {
            this.txtInformatieUtila.InsereazaText(pText);
        }

        public void BeginUpdate()
        {
            this.lSeIncarca = true;
        }

        public void EndUpdate()
        {
            this.lSeIncarca = true;
        }

        public string GetTextPentruFiltrare()
        {
            return this.txtInformatieUtila.GetTextPentruFiltrare();
        }

        public bool AreValoare()
        {
            return this.txtInformatieUtila.AreValoare();
        }

        /// <summary>
        /// Trecem din mod modificare in mod lectura si invers
        /// </summary>
        /// <param name="pbInModificationMode"></param>
        public virtual void AllowModification(bool pbInModificationMode)
        {
            //Daca modul ReadOnly este cerut expres nu vom schimba starea controlului la trecerea in mod modificare
            if (this.lIsInReadOnlyMode)
                pbInModificationMode = false;

            this.lEcranInModificare = pbInModificationMode;

            bool ButonGumaVizibil = this._UtilizeazaButonGuma && this.lEcranInModificare && !String.IsNullOrEmpty(this.txtInformatieUtila.Text.Trim());

            this.txtInformatieUtila.AllowModification(this.lEcranInModificare);
            this.btnGuma.AllowModification(ButonGumaVizibil);

            int LatimeZonaDeText = this.Width;
            if (ButonGumaVizibil)
            {
                this.btnGuma.Location = new Point(this.Width - this.btnGuma.Width, this.btnGuma.Location.Y);
                LatimeZonaDeText -= (this.btnGuma.Width + 2);
            }

            this.txtInformatieUtila.Width = LatimeZonaDeText;
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
            this.txtInformatieUtila.SelecteazaTextul();
        }

        public void DeSelecteazaTextul()
        {
            this.txtInformatieUtila.SelecteazaLaPozitia(0, 0);
        }

        /// <summary>
        /// Golim zona de text utila
        /// </summary>
        public void Goleste()
        {
            incepeIncarcarea();

            this.lTextUltimaCautare = string.Empty;
            this.txtInformatieUtila.Goleste();
            AllowModification(this.lEcranInModificare);

            finalizeazaIncarcarea();
        }

        /// <summary>
        /// Recuperam textul pe care utilizatorul doreste sa il foloseasca la cautare
        /// Fie textul complet in cazul in care 
        /// </summary>
        /// <returns></returns>
        private string GetTextDeCautat()
        {
            string TextCautare = this.txtInformatieUtila.Text;
            if (this.txtInformatieUtila.SelectionLength > 1)
            {
                TextCautare = this.txtInformatieUtila.SelectedText;
            }
            return TextCautare;
        }

        public void Undo()
        {
            this.txtInformatieUtila.Undo();
        }

        #endregion

        #region Evenimente

        public event System.EventHandler IncepeActiune;
        public event System.EventHandler FinalizeazaActiune;

        void txtInformatieUtila_FinalizeazaActiune(object sender, EventArgs e)
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

        void txtInformatieUtila_IncepeActiune(object sender, EventArgs e)
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

        /// <summary>
        /// S-a modificat continutul TextBox-ului
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="sNouaValoare"></param>
        protected virtual void txtInformatieUtila_AfterUpdate(Control sender, string sNumeProprietateAtasata, string sNouaValoare)
        {
            if (this.CerereUpdate != null)
            {
                CerereUpdate(this, this._sProprietateCorespunzatoare, sNouaValoare);
                AllowModification(this.lEcranInModificare);
            }
        }

        /// <summary>
        /// Se doreste stergerea zonei de text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void btnGuma_Click(object sender, EventArgs e)
        {
            this.txtInformatieUtila.Text = String.Empty;

            cereUpdate();

            AllowModification(this.lEcranInModificare);
        }

        /// <summary>
        /// Apasam o tasta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void txtInformatieUtila_KeyUp(object sender, KeyEventArgs e)
        {
            AllowModification(this.lEcranInModificare);
            if (this.KeyUpPersonalizat != null)
            {
                KeyUpPersonalizat(this, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;//sa nu mai avem zgomotul acela naspa
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (this.lButonAccept != null)
                {
                    e.Handled = true; //sa nu mai avem zgomotul acela naspa
                    //Daca avem un buton ce trebuie apasat cand dam enter atunci il apasam
                    this.lButonAccept.PerformClick();
                }
                else
                {
                    if (!this.Multiline)
                    {
                        // Daca zona nu este multilinie caz in care se doreste trecerea la linia urmatoare 
                        // declansam cererea de modificare
                        txtInformatieUtila_AfterUpdate(this.txtInformatieUtila, this._sProprietateCorespunzatoare, this.Text);
                    }
                }
            }
        }

        private void TextBoxGuma_Enter(object sender, EventArgs e)
        {
            //NE INCURCA LA ZONA DE CAUTARE; DE CE OARE O FI PUS AICI?
            //this.txtInformatieUtila.Focus();
        }

        private void txtInformatieUtila_Enter(object sender, EventArgs e)
        {
            if (this.lPoateFiControlTinta)
                ControaleCreateDinamic.SetControlTinta(this.txtInformatieUtila);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            //Nu tot textul trebuie selectat la primirea focusului (arata naspa)
            if (this.txtInformatieUtila.AreValoare())
                this.txtInformatieUtila.SelecteazaLaPozitia(this.txtInformatieUtila.Text.Length > 0 ? this.txtInformatieUtila.Text.Length - 1 : 0, 0);
            else
                this.txtInformatieUtila.Focus();

            base.OnGotFocus(e);
        }

        #endregion

    }
}
