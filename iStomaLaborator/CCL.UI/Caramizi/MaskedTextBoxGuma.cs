using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CDL.iStomaLab;
using ILL.iStomaLab;
using CCL.iStomaLab;

namespace CCL.UI.Caramizi
{
    [DefaultEvent("CerereUpdate")]
    public partial class MaskedTextBoxGuma : PanelContainerCCL, IAllowModification
    {
        #region Declaratii generale

        public event CEvenimente.ZonaModificata CerereUpdate;
        public event CEvenimente.EventCNPModificat CNPModificat;
        public event KeyEventHandler KeyUpPersonalizat;
        public event KeyPressEventHandler KeyPressPersonalizat;

        private bool _bIsInModificationMode = true;
        private bool _bIsInReadOnlyMode = false;
        private string _sProprietateCorespunzatoare; //utila pentru Reflection (initializare dinamica)
        private ButtonPersonalizat lButonAccept = null;
        private bool _UtilizeazaButonGuma = true;

        #endregion

        #region Proprietati

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

        public HorizontalAlignment TextAlign { get { return this.txtInformatieUtila.TextAlign; } set { this.txtInformatieUtila.TextAlign = value; } }

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
        [DefaultValue(false)]
        public bool IsInReadOnlyMode
        {
            get { return this._bIsInReadOnlyMode; }
            set
            {
                this._bIsInReadOnlyMode = value;
                this.txtInformatieUtila.IsInReadOnlyMode = this._bIsInReadOnlyMode;
            }
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
                this.txtInformatieUtila.ProprietateCorespunzatoare = value;
            }
        }

        [Description("Textul zonei de text")]
        [Category("iDava")]
        [DefaultValue("")]
        public override string Text
        {
            get { return this.txtInformatieUtila.Text; }
            set
            {
                this.txtInformatieUtila.Text = value;
                AllowModification(this._bIsInModificationMode);
            }
        }

        public string TextNumarTelefon
        {
            get { return CUtil.GetNumarTelefonUtil(this.Text); }
        }

        [Browsable(false)]
        [DefaultValue(0)]
        public decimal ValoareDecimal
        {
            get { return this.txtInformatieUtila.ValoareDecimal; }
            set { this.txtInformatieUtila.ValoareDecimal = value; }
        }

        [Browsable(false)]
        [DefaultValue(0)]
        public double ValoareDouble
        {
            get { return this.txtInformatieUtila.ValoareDouble; }
            set { this.txtInformatieUtila.ValoareDouble = value; }
        }

        [Browsable(false)]
        [DefaultValue(0)]
        public int ValoareIntreaga
        {
            get { return this.txtInformatieUtila.ValoareIntreaga; }
            set { this.txtInformatieUtila.ValoareIntreaga = value; }
        }

        [Description("MaxLength-ul zonei de text")]
        [Category("iDava")]
        [DefaultValue(15)]
        public int MaxLength
        {
            get { return this.txtInformatieUtila.MaxLength; }
            set
            {
                this.txtInformatieUtila.MaxLength = value;
            }
        }

        [Description("Tipul de masca corespunzator")]
        [Category("iDava")]
        public CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca TipMasca
        {
            get { return this.txtInformatieUtila.TipMasca; }
            set
            {
                this.txtInformatieUtila.TipMasca = value;
            }
        }

        [Browsable(false)]
        [DefaultValue(false)]
        public bool FaraZecimale { get { return this.txtInformatieUtila.FaraZecimale; } set { this.txtInformatieUtila.FaraZecimale = value; } }

        #endregion

        #region Constructori

        public MaskedTextBoxGuma()
        {
            DoubleBuffered = true;

            InitializeComponent();

            this.txtInformatieUtila.ContextMenuStrip = ControaleCreateDinamic.GetMeniuContextualZonaText();
        }

        #endregion

        #region Metode

        /// <summary>
        /// Trecem din mod modificare in mod lectura si invers
        /// </summary>
        /// <param name="pbInModificationMode"></param>
        public void AllowModification(bool pbInModificationMode)
        {
            //Daca modul ReadOnly este cerut expres nu vom schimba starea controlului la trecerea in mod modificare
            if (this._bIsInReadOnlyMode)
                pbInModificationMode = false;

            this._bIsInModificationMode = pbInModificationMode;

            bool ButonGumaVizibil = this._UtilizeazaButonGuma && this._bIsInModificationMode && !String.IsNullOrEmpty(this.txtInformatieUtila.Text.Trim());

            this.txtInformatieUtila.AllowModification(this._bIsInModificationMode);
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
        /// Golim zona de text utila
        /// </summary>
        public void Goleste()
        {
            this.txtInformatieUtila.Text = string.Empty;
            AllowModification(this._bIsInModificationMode);
        }

        public bool AreValoare()
        {
            return this.txtInformatieUtila.AreValoare();
        }

        /// <summary>
        /// Selectam textul si setam focusul pentru a putea inlocui cu usurinta textul
        /// </summary>
        public void SelectAll()
        {
            this.txtInformatieUtila.Focus();
            this.txtInformatieUtila.SelectAll();
        }

        #endregion

        #region Evenimente

        protected override void OnGotFocus(EventArgs e)
        {
            //base.OnGotFocus(e);
            this.txtInformatieUtila.Focus();
        }

        /// <summary>
        /// S-a modificat continutul MaskedTextBox-ului
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="sNouaValoare"></param>
        private void txtInformatieUtila_AfterUpdate(Control sender, string sNumeProprietateAtasata, string sNouaValoare)
        {
            if (this.CerereUpdate != null)
            {
                CerereUpdate(this, this._sProprietateCorespunzatoare, sNouaValoare);
                AllowModification(this._bIsInModificationMode);
            }
        }

        /// <summary>
        /// Se doreste stergerea zonei de text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuma_Click(object sender, EventArgs e)
        {
            this.txtInformatieUtila.Text = String.Empty;
            if (this.CerereUpdate != null)
            {
                CerereUpdate(this, this._sProprietateCorespunzatoare, String.Empty);
            }
            AllowModification(this._bIsInModificationMode);
            this.txtInformatieUtila.Focus();
        }

        /// <summary>
        /// Apasam o tasta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInformatieUtila_KeyUp(object sender, KeyEventArgs e)
        {
            AllowModification(this._bIsInModificationMode);

            //Nu are sens sa facem modif in lectura sau readonly
            if (this._bIsInModificationMode)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (this.lButonAccept != null)
                    {
                        //Daca avem un buton ce trebuie apasat cand dam enter atunci il apasam
                        this.lButonAccept.PerformClick();
                    }
                    else
                    {
                        // Mutam focusul pe butonul guma pentru a declansa cerea de modificare
                        txtInformatieUtila_AfterUpdate(this.txtInformatieUtila, this._sProprietateCorespunzatoare, this.Text);
                    }
                }
                else
                {
                    if (this.KeyUpPersonalizat != null)
                        KeyUpPersonalizat(this, e);
                }
            }
        }

        #endregion

        private void txtInformatieUtila_CNPModificat(Control psender, CDefinitiiComune.EnumSex plSex,
            DateTime pdDataNasterii, int plIdRegiune, int plIdLocalitate,
            CDefinitiiComune.EnumTitulatura plTitulatura, bool pbNascutInRomania)
        {
            if (this.CNPModificat != null)
                CNPModificat(this, plSex, pdDataNasterii, plIdRegiune, plIdLocalitate, plTitulatura, pbNascutInRomania);
        }

        private void txtInformatieUtila_Enter(object sender, EventArgs e)
        {
            ControaleCreateDinamic.SetControlTinta(this.txtInformatieUtila);
        }

        private void txtInformatieUtila_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.KeyPressPersonalizat != null)
                KeyPressPersonalizat(this, e);
        }
    }
}
