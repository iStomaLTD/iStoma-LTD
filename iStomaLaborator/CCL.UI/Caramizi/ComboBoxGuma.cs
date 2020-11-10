using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ILL.iStomaLab;

namespace CCL.UI.Caramizi
{
    [DefaultEvent("CerereUpdate")]
    public partial class ComboBoxGuma : PanelContainerCCL, IAllowModification
    {
        #region Declaratii Generale

        public event CEvenimente.ZonaModificata CerereUpdate;
        public event CEvenimente.EventDeschideEcranCautare AfiseazaDetaliiObiectAtasat;
        public event CEvenimente.EventDeschideEcranCautare CerereAccesParametraj;

        private bool _bIsInModificationMode = true;
        private bool _bIsInReadOnlyMode = false;
        private string _sProprietateCorespunzatoare = ""; //utila pentru Reflection (initializare dinamica)
        private bool _AfiseazaButonDetalii = false;
        private bool _AfiseazaButonParametraj = false;
        private bool _UtilizeazaButonGuma = true;

        #endregion

        #region Proprietati

        /// <summary>
        /// Pentru a nu gestiona selectia in timpul incarcarii
        /// </summary>
        [Browsable(false)]
        public bool SeIncarca
        {
            get { return this.lSeIncarca; }
            set { this.lSeIncarca = value; }
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

        [Description("DataSource pentru ComboBox-ul controlului")]
        [Category("iDava")]
        public object DataSource
        {
            get
            {
                return this.cboListaCompleta.DataSource;
            }
            set
            {
                incepeIncarcarea();
                this.cboListaCompleta.DataSource = value;
                finalizeazaIncarcarea();
            }
        }

        [Description("ValueMember pentru ComboBox-ul controlului")]
        [Category("iDava")]
        public string ValueMember
        {
            get
            {
                return this.cboListaCompleta.ValueMember;
            }
            set
            {
                this.cboListaCompleta.ValueMember = value;
            }
        }

        [Description("DisplayMember pentru ComboBox-ul controlului")]
        [Category("iDava")]
        public string DisplayMember
        {
            get
            {
                return this.cboListaCompleta.DisplayMember;
            }
            set
            {
                this.cboListaCompleta.DisplayMember = value;
            }
        }

        [Description("SelectedItem pentru ComboBox-ul controlului")]
        [Category("iDava")]
        public object SelectedItem
        {
            get
            {
                return this.cboListaCompleta.SelectedItem;
            }
            set
            {
                this.cboListaCompleta.SelectedItem = value;
                AllowModification(this._bIsInModificationMode);
            }
        }

        [Description("SelectedValue pentru ComboBox-ul controlului")]
        [Category("iDava")]
        public object SelectedValue
        {
            get
            {
                return this.cboListaCompleta.SelectedValue;
            }
            set
            {
                this.cboListaCompleta.SelectedValue = value;
            }
        }

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
                    return this.cboListaCompleta.IdObiectCorespunzator;
            }
        }

        [Description("SelectedIndex pentru ComboBox-ul controlului")]
        [Category("iDava")]
        public int SelectedIndex
        {
            get
            {
                return this.cboListaCompleta.SelectedIndex;
            }
            set
            {
                this.cboListaCompleta.SelectedIndex = value;
            }
        }

        [Description("DataBindings pentru ComboBox-ul controlului")]
        [Category("iDava")]
        public new ControlBindingsCollection DataBindings
        {
            get
            {
                return this.cboListaCompleta.DataBindings;
            }
        }

        [Description("Activam auto completarea. Util doar in cazul in care DropDownStyle = DropDown")]
        [Category("iDava")]
        [DefaultValue(false)]
        public bool AutoCompletePersonalizat
        {
            get
            {
                return this.cboListaCompleta.AutoCompletePersonalizat;
            }
            set
            {
                this.cboListaCompleta.AutoCompletePersonalizat = value;
            }
        }

        [Description("AutoCompleteSource pentru ComboBox-ul controlului")]
        [Category("iDava")]
        public AutoCompleteSource AutoCompleteSource
        {
            get
            {
                return this.cboListaCompleta.AutoCompleteSource;
            }
            set
            {
                this.cboListaCompleta.AutoCompleteSource = value;
            }
        }

        [Description("AutoCompleteMode pentru ComboBox-ul controlului")]
        [Category("iDava")]
        public AutoCompleteMode AutoCompleteMode
        {
            get
            {
                return this.cboListaCompleta.AutoCompleteMode;
            }
            set
            {
                this.cboListaCompleta.AutoCompleteMode = value;
            }
        }

        [Description("Returneaza colectia de elemente din lista derulanta")]
        [Category("iDava")]
        [Browsable(false)]
        public ComboBox.ObjectCollection Items
        {
            get { return this.cboListaCompleta.Items; }
        }

        [Description("Textul pentru ComboBox-ul controlului")]
        [Category("iDava")]
        public override string Text
        {
            get { return this.cboListaCompleta.Text; }
            set
            {
                this.cboListaCompleta.Text = value;
                AllowModification(this._bIsInModificationMode);
            }
        }

        [Description("DroppedDown pentru ComboBox-ul controlului")]
        [Category("iDava")]
        [DefaultValue(false)]
        public bool DroppedDown
        {
            get
            {
                return this.cboListaCompleta.DroppedDown;
            }
            set
            {
                this.cboListaCompleta.DroppedDown = value;
            }
        }

        [Description("DropDownStyle pentru ComboBox-ul controlului")]
        [Category("iDava")]
        public ComboBoxStyle DropDownStyle
        {
            get
            {
                return this.cboListaCompleta.DropDownStyle;
            }
            set
            {
                this.cboListaCompleta.DropDownStyle = value;
            }
        }

        [Description("DropDownHeight pentru ComboBox-ul controlului")]
        [Category("iDava")]
        public int DropDownHeight
        {
            get
            {
                return this.cboListaCompleta.DropDownHeight;
            }
            set
            {
                this.cboListaCompleta.DropDownHeight = value;
            }
        }

        [Description("DropDownWidth pentru ComboBox-ul controlului")]
        [Category("iDava")]
        public int DropDownWidth
        {
            get
            {
                return this.cboListaCompleta.DropDownWidth;
            }
            set
            {
                if (value > 0)
                    this.cboListaCompleta.DropDownWidth = value;
            }
        }

        [Description("MaxDropDownItems pentru ComboBox-ul controlului")]
        [Category("iDava")]
        public int MaxDropDownItems
        {
            get
            {
                return this.cboListaCompleta.MaxDropDownItems;
            }
            set
            {
                this.cboListaCompleta.MaxDropDownItems = value;
            }
        }

        [Description("Precizam expres ca acest control este intotdeauna in mod ReadOnly (Metoda AllowModification nu va avea niciun efect)")]
        [Category("iDava")]
        [DefaultValue(false)]
        public bool IsInReadOnlyMode
        {
            get { return this._bIsInReadOnlyMode; }
            set
            {
                this._bIsInReadOnlyMode = value;
                this.cboListaCompleta.IsInReadOnlyMode = value;
            }
        }

        [Description("Pentru a putea cunoaste din exterior modul in care se afla lista")]
        [Category("iDava")]
        [Browsable(false)]
        [DefaultValue(true)]
        public bool IsInModificationMode
        {
            get { return this._bIsInModificationMode; }
        }

        [Description("Precizam numele proprietatii obiectului sursa ce contine valoarea cu care vom initializa textul acestei zone. Utila pentru utilizarea initializarii dinamice.")]
        [Category("iDava")]
        [DefaultValue("")]
        public string ProprietateCorespunzatoare
        {
            get { return this._sProprietateCorespunzatoare; }
            set
            {
                this._sProprietateCorespunzatoare = value;
                this.cboListaCompleta.ProprietateCorespunzatoare = value;
            }
        }

        [Description("Tipul listei. Pentru lista numerica folositi metoda de initializare")]
        [Category("iDava")]
        public CCL.UI.ComboBoxPersonalizat.EnumTipLista TipulListei
        {
            get { return cboListaCompleta.TipulListei; }
            set { cboListaCompleta.TipulListei = value; }
        }

        [Description("Precizam daca, la apasarea tastei TAB cand focusul este pe lista derulanta, btonul Guma v-a primi focus")]
        [Category("iDava")]
        [DefaultValue(false)]
        public bool FocusPeGuma
        {
            get { return btnGuma.TabStop; }
            set { btnGuma.TabStop = value; }
        }

        [Description("In cazul in care avem nevoie sa consultam detaliile obiectului atasat vom seta la true;  altfel la false;")]
        [Category("iDava")]
        [DefaultValue(false)]
        public bool AfiseazaButonDetalii
        {
            get { return this._AfiseazaButonDetalii; }
            set
            {
                this._AfiseazaButonDetalii = value;
                AllowModification(this._bIsInModificationMode);
            }
        }

        [Description("In cazul in care avem de a face cu o lista parametrabila vom seta la true;  altfel la false;")]
        [Category("iDava")]
        [DefaultValue(false)]
        public bool AfiseazaButonParametraj
        {
            get { return this._AfiseazaButonParametraj; }
            set
            {
                this._AfiseazaButonParametraj = value;
                AllowModification(this._bIsInModificationMode);
            }
        }

        #endregion

        #region Constructori

        public ComboBoxGuma()
        {
            DoubleBuffered = true;

            InitializeComponent();

            //Adaugam meniul contextual
            this.cboListaCompleta.ContextMenuStrip = ControaleCreateDinamic.GetMeniuContextualZonaText();
            this.cboListaCompleta.Leave += cboListaCompleta_Leave;
        }

        #endregion

        #region Metode publice

        public void AcceptaFocusPeGuma(bool pAccepta)
        {
            this.btnGuma.TabStop = pAccepta;
        }

        /// <summary>
        /// Trecem din mod modificare in mod lectura si invers
        /// </summary>
        /// <param name="pbInModificationMode"></param>
        public void AllowModification(bool pbInModificationMode)
        {
            //int Pozitie1 = -1;
            //int LungimeTextSelectat = -1;

            //if (this.cboListaCompleta.DropDownStyle == ComboBoxStyle.DropDown)
            //{
            //    Pozitie1 = this.cboListaCompleta.SelectionStart;
            //    LungimeTextSelectat = this.cboListaCompleta.SelectionLength;
            //}

            //Daca modul ReadOnly este cerut expres nu vom schimba starea controlului la trecerea in mod modificare
            if (this._bIsInReadOnlyMode)
                pbInModificationMode = false;

            this._bIsInModificationMode = pbInModificationMode;
            bool ButonAfiseazaDetalii = this.SelectedItem != null && this._AfiseazaButonDetalii;
            bool ButonAccesParametraj = this._bIsInModificationMode && this._AfiseazaButonParametraj;
            bool ButonGumaVizibil = this._UtilizeazaButonGuma && this._bIsInModificationMode &&
                ((this.DropDownStyle == ComboBoxStyle.DropDown && !string.IsNullOrEmpty(this.Text)) ||
                (this.DropDownStyle != ComboBoxStyle.DropDown && cboListaCompleta.SelectedItem != null &&
                !string.IsNullOrEmpty(cboListaCompleta.SelectedItem.ToString())));

            this.cboListaCompleta.AllowModification(this._bIsInModificationMode);
            this.btnGuma.AllowModification(ButonGumaVizibil);
            this.btnAccesParametraj.AllowModification(ButonAccesParametraj);
            this.btnAfiseazaDetalii.AllowModification(ButonAfiseazaDetalii);

            //Modificam pozitia si latimea controalelor in functie de vizibilitatea acestora
            Point Locatie = this.btnAccesParametraj.Location;
            int LatimeLista = this.Width;

            // Butonul de acces la parametraj
            if (ButonAccesParametraj)
            {
                this.btnAccesParametraj.Location = Locatie;
                Locatie.X += this.btnAccesParametraj.Width + 4;
                LatimeLista -= (this.btnAccesParametraj.Width + 4);
            }

            //Pentru ca butonul de parametraj este mai jos iar celelalte incep de sus de tot
            Locatie.Y = 0;

            //Butonul de afisare a detaliilor
            if (ButonAfiseazaDetalii)
            {
                this.btnAfiseazaDetalii.Location = Locatie;
                Locatie.X += this.btnAfiseazaDetalii.Width + 2;
                LatimeLista -= (this.btnAfiseazaDetalii.Width + 2);
            }
            if (ButonGumaVizibil)
            {
                this.btnGuma.Location = new Point(this.Width - (this.btnGuma.Width + 2), this.btnGuma.Location.Y);
                LatimeLista -= (this.btnGuma.Width + 5);
            }
            else
                LatimeLista = LatimeLista - 2;//lasam un pic de spatiu

            //Lista derulanta se pozitioneaza dupa butoanele vizibile si are latimea maxima posibila (acopera spatiile goale)
            this.cboListaCompleta.Location = Locatie;
            this.cboListaCompleta.Width = LatimeLista;

            ////Daca avem selectie cand apare butonul guma si se redimensioneaza lista atunci trebuie sa pastram selectia originala
            //if (Pozitie1 >= 0 && LungimeTextSelectat >= 0)
            //{
            //    this.cboListaCompleta.SelecteazaLaPozitia(Pozitie1, LungimeTextSelectat);
            //    this.cboListaCompleta.Focus();
            //}
            //else
            if (this.DropDownStyle == ComboBoxStyle.DropDown && !this.cboListaCompleta.Focused)
                this.cboListaCompleta.SelecteazaLaPozitia(0, 0);
        }

        public void InitializeazaListaNumerica(int plPrimaValoare, int plUltimaValoare, int plPas)
        {
            cboListaCompleta.InitializeazaListaNumerica(plPrimaValoare, plUltimaValoare, plPas);
        }

        public void ClearSelection()
        {
            this.cboListaCompleta.ClearSelection();
        }

        public void BeginUpdate()
        {
            this.lSeIncarca = true;
            this.cboListaCompleta.BeginUpdate();
        }

        public void EndUpdate()
        {
            this.cboListaCompleta.EndUpdate();
            this.lSeIncarca = false;
        }

        public void DeselecteazaTextul()
        {
            if (this.cboListaCompleta.DropDownStyle == ComboBoxStyle.DropDown)
            {
                this.cboListaCompleta.SelecteazaLaPozitia(0, 0);
                this.cboListaCompleta.SelectionStart = 0;
                this.cboListaCompleta.SelectionLength = 0;
                this.cboListaCompleta.SelectedText = null;
            }
        }

        #endregion

        #region Metode private

        #endregion

        #region Evenimente

        void cboListaCompleta_Leave(object sender, EventArgs e)
        {
            if (this.cboListaCompleta.DropDownStyle == ComboBoxStyle.DropDown && this.FocusPeGuma)
            {
                if (this.cboListaCompleta.SelectedItem != null && this.btnGuma.Visible == false && this.UtilizeazaButonGuma && this.lEcranInModificare)
                {
                    AllowModification(this.lEcranInModificare);
                    this.btnGuma.Focus();
                }
            }
        }

        private void cboListaCompleta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;

            //Aparitia butonului guma strica autocompleteul
            if (this.cboListaCompleta.DropDownStyle != ComboBoxStyle.DropDown)
                AllowModification(this._bIsInModificationMode);
        }

        private void cboListaCompleta_CerereUpdate(object psender, string proprietate, object sNouaValoare)
        {
            if (this.lSeIncarca) return;

            if (this.CerereUpdate != null)
            {
                if (this.TipulListei == ComboBoxPersonalizat.EnumTipLista.Numerica)
                {
                    int lValoare = -1;
                    if (sNouaValoare != null)
                    {
                        lValoare = Convert.ToInt16(sNouaValoare);
                    }
                    CerereUpdate(this, this._sProprietateCorespunzatoare, lValoare);
                }
                else
                {
                    CerereUpdate(this, this._sProprietateCorespunzatoare, sNouaValoare);
                }
                AllowModification(this._bIsInModificationMode);
            }
        }

        private void btnGuma_Click(object sender, EventArgs e)
        {
            this.cboListaCompleta.SelectedItem = null;
            if (this.DropDownStyle == ComboBoxStyle.DropDown)
                this.cboListaCompleta.Text = string.Empty;

            if (this.TipulListei == ComboBoxPersonalizat.EnumTipLista.Numerica && this.DropDownStyle == ComboBoxStyle.DropDown)
            {
                if (this.CerereUpdate != null)
                {
                    this.Text = string.Empty;
                    CerereUpdate(this, this._sProprietateCorespunzatoare, -1);
                }
            }
            else
            {
                if (this.DropDownStyle == ComboBoxStyle.DropDown)
                {
                    if (this.CerereUpdate != null)
                    {
                        this.Text = string.Empty;
                        CerereUpdate(this, this._sProprietateCorespunzatoare, -1);
                    }
                }
            }
            AllowModification(this._bIsInModificationMode);
        }

        /// <summary>
        /// Cand acest control primeste focusul il transmite listei derulante
        /// </summary>
        /// <param name="e"></param>
        protected override void OnGotFocus(EventArgs e)
        {
            this.cboListaCompleta.Focus();
        }

        /// <summary>
        /// Se doreste afisarea detaliilor elementului selectat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAfiseazaDetalii_Click(object sender, EventArgs e)
        {
            if (AfiseazaDetaliiObiectAtasat != null)
            {
                AfiseazaDetaliiObiectAtasat(this, this.SelectedItem);
            }
        }

        private void btnAccesParametraj_Click(object sender, EventArgs e)
        {
            if (CerereAccesParametraj != null)
            {
                CerereAccesParametraj(this, this.SelectedItem);
            }
        }

        private void cboListaCompleta_Enter(object sender, EventArgs e)
        {
            ControaleCreateDinamic.SetControlTinta(this.cboListaCompleta);
        }

        #endregion

    }
}
