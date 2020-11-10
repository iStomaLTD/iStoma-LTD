using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ILL.iStomaLab;
using CDL.iStomaLab;
using CCL.iStomaLab;

namespace CCL.UI
{
    public class MaskedTextBoxPersonalizat : System.Windows.Forms.MaskedTextBox,
        CCL.UI.IMembriComuniControalePersonalizate
    {

        #region Declaratii Generale

        private EnumTipMasca _tipMasca = EnumTipMasca.Niciuna;
        public event ValoareModificata AfterUpdate;
        public delegate void ValoareModificata(Control sender, string sNumeProprietateAtasata, string sNouaValoare);
        public event EventCNPModificat CNPModificat;
        public delegate void EventCNPModificat(Control psender, CDefinitiiComune.EnumSex plSex,
            DateTime pdDataNasterii, int plIdRegiune, int plIdLocalitate,
            CDefinitiiComune.EnumTitulatura plTitulatura, bool pbNascutInRomania);
        private string _sVecheaValoare;
        private bool _bIsInReadOnlyMode = false;
        private string _sProprietateCorespunzatoare; //utila pentru Reflection (initializare dinamica)
        private bool _bIsInModificationMode = true;
        private bool _bEroareMasca = true;
        private string lTitluToolTip = string.Empty;
        private string lMesajToolTip = string.Empty;
        private int lMaxLength = 15;
        protected bool lAfterUpdateLaKeyPressed = false;

        #endregion

        #region Enumerari si Structuri

        public enum EnumTipMasca
        {
            Niciuna = 0,
            CNP = 1,
            Data = 2,
            TextSiCifre = 3,
            Telefon = 4,
            Decimal
        }

        #endregion

        #region Proprietati

        [Description("Precizam expres ca acest control este intotdeauna in mod ReadOnly (Metoda AllowModification nu va avea niciun efect)")]
        [Category("iDava")]
        [DefaultValue(false)]
        public bool IsInReadOnlyMode
        {
            get { return this._bIsInReadOnlyMode; }
            set { this._bIsInReadOnlyMode = value; }
        }

        [Description("Verificam accesibilitatea controlului")]
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
            set { this._sProprietateCorespunzatoare = value; }
        }

        [Description("Tipul de masca corespunzator")]
        [Category("iDava")]
        public EnumTipMasca TipMasca
        {
            get { return this._tipMasca; }
            set
            {
                this._tipMasca = value;
                switch (this._tipMasca)
                {
                    case EnumTipMasca.Niciuna:
                        break;
                    case EnumTipMasca.CNP:
                        this.MaxLength = 13;
                        this.Mask = CUtil.Masca_CNP;
                        break;
                    case EnumTipMasca.Decimal:
                        this.MaxLength = 20;
                        break;
                }
            }
        }

        [Description("Textul zonei de text")]
        [Category("iDava")]
        [DefaultValue("")]
        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                TesteazaMasca(false);
            }
        }

        public override int MaxLength
        {
            get
            {
                return this.lMaxLength;
            }
            set
            {
                this.lMaxLength = value;
                base.MaxLength = this.lMaxLength;
            }
        }

        [Browsable(false)]
        [DefaultValue(0)]
        public decimal ValoareDecimal
        {
            get
            {
                return CUtil.GetTextDecimal(this.Text);
            }
            set { this.Text = CUtil.GetValoareMonetara(Convert.ToDouble(value)); }
        }

        [Browsable(false)]
        [DefaultValue(0)]
        public double ValoareDouble
        {
            get
            {
                return CUtil.GetTextDouble(this.Text);
            }
            set
            {
                //Nu fol val monetara deoarece ne incurcam in semne de punctuatie la modificare
                this.Text = Convert.ToString(value);
            }
        }

        [Browsable(false)]
        [DefaultValue(0)]
        public int ValoareIntreaga
        {
            get
            {
                return CUtil.GetTextInt32(this.Text);
            }
            set { this.Text = Convert.ToString(value); }
        }

        /// <summary>
        /// Vechea valoare
        /// </summary>
        public string VecheaValoare
        {
            get { return this._sVecheaValoare; }
        }

        [Browsable(false)]
        [DefaultValue(false)]
        public bool FaraZecimale { get; set; }

        #endregion

        #region Constructori

        public MaskedTextBoxPersonalizat()
        {
            SeteazaDoubleBuffer();
        }

        public MaskedTextBoxPersonalizat(IContainer container)
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

        #endregion

        #region Evenimente

        protected override void OnGotFocus(EventArgs e)
        {
            this._sVecheaValoare = this.Text;
            base.OnGotFocus(e);
            ControaleCreateDinamic.AscundeToolTip(this);
            //IHMUtile.AfiseazaTastaturaWin8();
        }

        protected override void OnValidated(EventArgs e)
        {
            try
            {
                base.OnValidated(e);
                if ((string.IsNullOrEmpty(this._sVecheaValoare) && !string.IsNullOrEmpty(this.Text.Trim())) || !this._sVecheaValoare.Trim().Equals(this.Text.Trim()))
                {
                    if (this.AfterUpdate != null || this.CNPModificat != null)
                    {
                        if (this.AfterUpdate != null)
                            AfterUpdate(this, this._sProprietateCorespunzatoare, this.Text.Trim());

                        TesteazaMasca(true);
                    }
                }
            }
            catch (Exception ex)
            {
                Mesaj.Eroare(IHMUtile.GetFormParinte(this), ex.Message);
            }
            //IHMUtile.AfiseazaTastaturaWin8();
        }

        private void anuntaAfterUpdate()
        {
            if (this.AfterUpdate != null)
            {
                AfterUpdate(this, this._sProprietateCorespunzatoare, this.Text.Trim());
            }
        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);

            if (!string.IsNullOrEmpty(this.lMesajToolTip))
                ControaleCreateDinamic.AfiseazaToolTip(this, ToolTipIcon.Error, this.lTitluToolTip, this.lMesajToolTip);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            ControaleCreateDinamic.AscundeToolTip(this);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                OnValidated(e);
                e.Handled = true; //sa nu mai avem zgomotul acela naspa
                e.SuppressKeyPress = true;
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(this.Mask))
            {
                if ((this.Text.Length - this.SelectedText.Length) > this.lMaxLength && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
                {
                    e.Handled = true;
                }
                else
                {
                    if (this.TipMasca != EnumTipMasca.TextSiCifre)
                    {
                        //Daca nu avem o masca atunci vom accepta doar cifre
                        if (this.FaraZecimale && (e.KeyChar == '.' || e.KeyChar == ','))
                        {
                            e.Handled = true;
                            return;
                        }

                        if (Char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Back || e.KeyChar == '.' || e.KeyChar == ',' || e.KeyChar == '-')
                            e.Handled = false;
                        else
                            e.Handled = true;
                    }
                }

                if (this.lAfterUpdateLaKeyPressed)
                    anuntaAfterUpdate();
            }
            else
            {
                base.OnKeyPress(e);
            }
        }

        #endregion

        #region Metode de clasa

        public double GetValoareMonetara()
        {
            return CUtil.GetAsDouble(this.Text);
            //string val = this.Text;

            //if (string.IsNullOrEmpty(val))
            //    return 0;

            //try
            //{
            //    return Convert.ToDouble(val);
            //}
            //catch (Exception)
            //{
            //    if (val.Contains("."))
            //    {
            //        return Convert.ToDouble(val.Replace(".", ","));
            //    }
            //    else
            //    {
            //        if (val.Contains(","))
            //        {
            //            return Convert.ToDouble(val.Replace(",", "."));
            //        }
            //    }

            //    return 0;
            //}
        }

        private void TesteazaMasca(bool pbRaiseEventCNPModificat)
        {
            this._bEroareMasca = false;
            this.lTitluToolTip = CUtil.getText(31);
            this.lMesajToolTip = string.Empty;
            if (this.TipMasca == EnumTipMasca.CNP)
            {
                if (!string.IsNullOrEmpty(this.Text.Trim()))
                {
                    CDefinitiiComune.EnumSex lEnumSex = CDefinitiiComune.EnumSex.Nedefinit;
                    CDefinitiiComune.EnumTitulatura lTitulatura = CDefinitiiComune.EnumTitulatura.Domn;
                    DateTime dDataNasterii = CConstante.DataNula;
                    int lIdLocalitateNastere = 0;
                    bool bNascutInRomania = true;
                    int lCodJudetNastere = 0;
                    this._bEroareMasca = CUtil.ObtineInformatiiCNP(this.Text, ref this.lMesajToolTip, ref lEnumSex, ref dDataNasterii,
                        ref lCodJudetNastere, ref lIdLocalitateNastere, ref lTitulatura, ref bNascutInRomania);
                    if (!this._bEroareMasca)
                    {
                        //Totul este in regula
                        if (pbRaiseEventCNPModificat)
                        {
                            if (this.CNPModificat != null)
                            {
                                CNPModificat(this, lEnumSex, dDataNasterii, lCodJudetNastere, lIdLocalitateNastere, lTitulatura,
                                    bNascutInRomania);
                            }
                        }
                    }
                }
            }
            else
            if (this.TipMasca == EnumTipMasca.Telefon)
            {
                this._bEroareMasca = !string.IsNullOrEmpty(this.Text) && this.Text.Length != 10;
            }

            if (this._bEroareMasca)
                this.BackColor = System.Drawing.Color.FromArgb(255, 26, 26);
            else
            {
                if (this._bIsInModificationMode)
                    this.BackColor = System.Drawing.SystemColors.Window;
                else
                    this.BackColor = System.Drawing.SystemColors.Control;
            }
        }

        #endregion

        #region Metode de instanta

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

        public virtual void Goleste()
        {
            this.Text = string.Empty;
        }

        public bool AreValoare()
        {
            return !string.IsNullOrEmpty(base.Text.Trim());
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
                    return true;
                case EnumTipActiuneControl.Diacritice:
                    return false;
                case EnumTipActiuneControl.Undo:
                    return base.CanUndo;
                case EnumTipActiuneControl.Decupare:
                    return false;
                case EnumTipActiuneControl.Inserare:
                    double ValoareClipBoard = 0;
                    return this._bIsInModificationMode && double.TryParse(Clipboard.GetText(), out ValoareClipBoard);
                case EnumTipActiuneControl.Calculator:
                    return true;
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
            if (this._bIsInReadOnlyMode)
            {
                pbInModificationMode = false;
            }

            this._bIsInModificationMode = pbInModificationMode;

            this.ReadOnly = !this._bIsInModificationMode;
            if (this._bEroareMasca)
            {
                this.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                if (this._bIsInModificationMode)
                    this.BackColor = System.Drawing.SystemColors.Window;
                else
                    this.BackColor = System.Drawing.SystemColors.Control;
            }
        }

        public void InsereazaText(string pText)
        {
            int Pozitie = this.SelectionStart;
            this.Text = this.Text.Insert(Pozitie, pText);
            this.SelectionStart = Pozitie + 1;
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
            this.SelectionStart = 0;
            this.SelectionLength = this.Text.Length;
        }

        public List<int> Cauta(string pText)
        {
            return CUtil.ExtrageListaPozitiiAparente(this.Text, pText);
        }

        public void SelecteazaLaPozitia(int pPozitie, int pLungimeText)
        {
            this.SelectionStart = pPozitie;
            this.SelectionLength = pLungimeText;
        }

        #endregion

    }
}
