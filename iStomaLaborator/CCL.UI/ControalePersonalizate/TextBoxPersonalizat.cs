using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ILL.iStomaLab;
using ILL.iStomaLab;
using CCL.iStomaLab;

namespace CCL.UI
{
    public class TextBoxPersonalizat : System.Windows.Forms.TextBox,
        CCL.UI.IMembriComuniControalePersonalizate, IAllowModification
    {
        #region Declaratii Generale

        private string lVecheaValoare;
        private bool lInitByPropertyText = false; //Ne spune ca modificarea valorii controlului a fost facuta prin proprietatea Text
        private bool lRaiseEventLaModificareProgramatica = false; //Pentru a face AfterUpdate chiar si la modificarea programatica a valorii 
        private bool lIsInModificationMode = true;
        private bool lIsInReadOnlyMode = false;
        private string lProprietateCorespunzatoare; //utila pentru Reflection (initializare dinamica)
        private EnumTipInformatie lTipInformatie = EnumTipInformatie.Nedefinit;
        private bool lEroareMasca = false;

        public event ValoareModificata AfterUpdate;
        public delegate void ValoareModificata(Control sender, string sNumeProprietateAtasata, string sNouaValoare);

        #endregion

        #region Enumerari + Structuri

        public enum EnumTipInformatie
        {
            Nedefinit = 0,
            AdresaMail = 1
        }

        #endregion

        #region Proprietati

        [Description("Precizam expres ca acest control este intotdeauna in mod ReadOnly (Metoda AllowModification nu va avea niciun efect)")]
        [Category("iDava")]
        public bool IsInReadOnlyMode
        {
            get { return this.lIsInReadOnlyMode; }
            set { this.lIsInReadOnlyMode = value; }
        }

        [Description("Verificam accesibilitatea controlului")]
        [Category("iDava")]
        [Browsable(false)]
        public bool IsInModificationMode
        {
            get { return this.lIsInModificationMode; }
        }

        [Description("Precizam numele proprietatii obiectului sursa ce contine valoarea cu care vom initializa textul acestei zone. Utila pentru utilizarea initializarii dinamice.")]
        [Category("iDava")]
        public string ProprietateCorespunzatoare
        {
            get { return this.lProprietateCorespunzatoare; }
            set { this.lProprietateCorespunzatoare = value; }
        }

        [Description("Tipul informatiei este util pentru a face automat validarile corespunzatoare")]
        [Category("iDava")]
        public EnumTipInformatie TipInformatie
        {
            get { return this.lTipInformatie; }
            set
            {
                this.lTipInformatie = value;
            }
        }

        [Description("Pentru ca prima litera din aceasta zona sa fie majuscula")]
        [Category("iDava")]
        [DefaultValue(true)]
        public bool CapitalizeazaPrimaLitera { get; set; }

        [Description("Pentru ca prima litera a fiecarui cuvant din aceasta zona sa fie majuscula")]
        [Category("iDava")]
        [DefaultValue(false)]
        public bool CapitalizeazaCuvintele { get; set; }

        public bool TotulCuMajuscule { get; set; }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                bool reinitLock = false; //   'permite gestiunea dublului apel la proprietate. Cateodata base.Text face apel la proprietatea Text, ceea ce pune probleme pentru lock
                try
                {
                    if (!this.lInitByPropertyText)
                    {
                        this.lInitByPropertyText = true;
                        reinitLock = true;
                    }

                    if (this.TotulCuMajuscule)
                        base.Text = CUtil.Majuscule(value);
                    if (this.CapitalizeazaPrimaLitera)
                        base.Text = CUtil.Capitalizeaza(value);
                    else
                        if (this.CapitalizeazaCuvintele)
                            base.Text = CUtil.CapitalizeazaCuvintele(value);
                        else
                            base.Text = value;

                    TesteazaTipInformatie();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (reinitLock == true) this.lInitByPropertyText = false;
                }
            }
        }

        public string TextNumarTelefon
        {
            get { return CUtil.GetNumarTelefonUtil(this.Text); }
        }

        [Description("Pentru a face AfterUpdate chiar si la modificarea programatica a valorii")]
        [Category("Personalizate")]
        public bool RaiseEventLaModificareProgramatica
        {
            get
            {
                return this.lRaiseEventLaModificareProgramatica;
            }
            set
            {
                this.lRaiseEventLaModificareProgramatica = value;
            }
        }

        [Browsable(false)]
        public String VecheaValoare
        {
            get
            {
                return this.lVecheaValoare;
            }
        }

        #endregion

        #region Constructori

        public TextBoxPersonalizat()
        {
            SeteazaDoubleBuffer();
        }

        public TextBoxPersonalizat(IContainer container)
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
                    return (this.lIsInModificationMode &&
                            this.TipInformatie != EnumTipInformatie.AdresaMail);
                case EnumTipActiuneControl.Undo:
                    return base.CanUndo;
                case EnumTipActiuneControl.Decupare:
                case EnumTipActiuneControl.Inserare:
                case EnumTipActiuneControl.Mesaj:
                    return this.lIsInModificationMode;
                case EnumTipActiuneControl.Calculator:
                    return this.lIsInModificationMode;
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

        public string GetTextPentruFiltrare()
        {
            return CUtil.InlocuiesteDiacritice(this.Text.Trim()).ToUpper();
        }

        public bool AreValoare()
        {
            return !string.IsNullOrEmpty(this.Text.Trim());
        }

        public void Goleste()
        {
            this.Text = string.Empty;
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

        private void TesteazaTipInformatie()
        {
            if (this.lTipInformatie != EnumTipInformatie.Nedefinit)
            {
                this.lEroareMasca = false;
                //string sTitluToolTip = CUtil.getText(31);
                //string sMesajToolTip = string.Empty;

                switch (this.lTipInformatie)
                {
                    case EnumTipInformatie.Nedefinit:
                        break;
                    case EnumTipInformatie.AdresaMail:
                        if (!CUtil.VerificaFormatAdresaMail(this.Text))
                        {
                            this.lEroareMasca = true;
                            //sMesajToolTip = "Formatul adresei de mail nu pare corect";
                        }
                        break;
                    default:
                        break;
                }

                if (this.lEroareMasca)
                {
                    this.BackColor = System.Drawing.Color.Red;
                    //ControaleCreateDinamic.AfiseazaToolTip(this, ToolTipIcon.Error, sTitluToolTip, sMesajToolTip);
                }
                else
                {
                    if (this.lIsInModificationMode)
                        this.BackColor = System.Drawing.SystemColors.Window;
                    else
                        this.BackColor = System.Drawing.SystemColors.Control;

                    //ControaleCreateDinamic.AscundeToolTip(this);
                }
            }
        }

        public void InsereazaText(string pText)
        {
            int Pozitie = this.SelectionStart;
            int lungime = this.SelectionLength;

            string textNou = string.Format("{0}{1}{2}", this.Text.Substring(0, Pozitie), pText, this.Text.Substring(Pozitie + lungime));

            this.Text = textNou;

            this.SelectionStart = Pozitie + pText.Length;
        }

        /// <summary>
        /// Trecem din mod modificare in mod lectura si invers
        /// </summary>
        /// <param name="pbInModificationMode"></param>
        public void AllowModification(bool pbInModificationMode)
        {
            if (this.lIsInReadOnlyMode)
            {
                pbInModificationMode = false;
            }

            this.lIsInModificationMode = pbInModificationMode;

            this.ReadOnly = !this.lIsInModificationMode;
            if (this.lEroareMasca)
            {
                this.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                if (this.BackColor == System.Drawing.SystemColors.Window || this.BackColor == System.Drawing.SystemColors.Control)
                {
                    if (this.lIsInModificationMode)
                        this.BackColor = System.Drawing.SystemColors.Window;
                    else
                        this.BackColor = System.Drawing.SystemColors.Control;
                }
            }
        }

        #endregion

        #region Metode supra-scrise

        protected override void OnEnter(EventArgs e)
        {
            this.lVecheaValoare = this.Text;
            base.OnEnter(e);

           // IHMUtile.AfiseazaTastaturaWin8();
        }

        private bool esteTastaNumerica(Keys pCheieTasta)
        {
            return pCheieTasta == Keys.NumPad0 ||
                pCheieTasta == Keys.NumPad1 ||
                pCheieTasta == Keys.NumPad2 ||
                pCheieTasta == Keys.NumPad3 ||
                pCheieTasta == Keys.NumPad4 ||
                pCheieTasta == Keys.NumPad5 ||
                pCheieTasta == Keys.NumPad6 ||
                pCheieTasta == Keys.NumPad7 ||
                pCheieTasta == Keys.NumPad8 ||
                pCheieTasta == Keys.NumPad9;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            //In lectura nu modificam niciun text
            if (!this.lIsInModificationMode)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            if ((e.KeyCode == Keys.Return) && (this.Multiline == false))
            {
                OnValidated(e);
                e.Handled = true; //sa nu mai avem zgomotul acela naspa
                e.SuppressKeyPress = true;
            }
            else
            {
                //Capitalizam prima litera din orice zona de text
                if ((this.CapitalizeazaCuvintele || this.CapitalizeazaPrimaLitera || this.TotulCuMajuscule) && Char.IsLetter((char)e.KeyValue) && !esteTastaNumerica(e.KeyCode))
                {
                    if ((this.Text.Length == 0 || this.Text.Length == this.SelectedText.Length))
                    {
                        this.Text = Convert.ToString((char)e.KeyValue);
                        this.SelectionStart = 1;
                        e.SuppressKeyPress = true;
                    }
                    else
                        if (this.TotulCuMajuscule || this.CapitalizeazaCuvintele && (this.SelectionStart == 0 || (this.SelectionStart > 0 && (this.Text[this.SelectionStart - 1] == ' ' || this.Text[this.SelectionStart - 1] == '-'))))
                        {
                            if (this.Text.Length < this.SelectionStart)
                            {
                                this.Text = string.Format("{0}{1}{2}", this.Text.Substring(0, this.SelectionStart), Convert.ToString((char)e.KeyValue),
                                    this.Text.Substring(this.SelectionStart + 1));
                                this.SelectionStart = this.Text.Length;
                            }
                            else
                            {
                                if (this.SelectionStart + this.SelectionLength < this.Text.Length)
                                {
                                    this.Text = string.Format("{0}{1}{2}",
                                        this.Text.Substring(0, this.SelectionStart),
                                        Convert.ToString((char)e.KeyValue),
                                        this.Text.Substring(this.SelectionStart + this.SelectionLength));
                                    this.SelectionStart += 1;
                                }
                                else
                                {
                                    this.Text = string.Format("{0}{1}", this.Text.Substring(0, this.SelectionStart), Convert.ToString((char)e.KeyValue));
                                    this.SelectionStart = this.Text.Length;
                                }
                            }

                            e.SuppressKeyPress = true;
                        }
                }
            }
        }

        protected override void OnValidated(EventArgs e)
        {
            if (this.AfterUpdate != null & ((!this.lInitByPropertyText) || (this.lRaiseEventLaModificareProgramatica)))
            {
                if (this.Text != this.lVecheaValoare)
                {
                    AfterUpdate(this, this.lProprietateCorespunzatoare, this.Text);
                    TesteazaTipInformatie();
                    this.lVecheaValoare = this.Text;
                }
            }
            //IHMUtile.AfiseazaTastaturaWin8();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            ControaleCreateDinamic.AscundeToolTip(this);
            base.OnMouseLeave(e);
        }

        #endregion

    }
}
