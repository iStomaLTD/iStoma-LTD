using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ILL.iStomaLab;
using CCL.iStomaLab;
using System.Drawing;

namespace CCL.UI
{
    public class LabelPersonalizat : System.Windows.Forms.Label,
        CCL.UI.IMembriComuniControalePersonalizate
    {

        #region Declaratii generale

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati

        [Description("Titlul ToolTip-ului (doar daca acesta este afisat - vezi proprietatea ToolTipActiv)")]
        [Category("ToolTip")]
        [DefaultValue("")]
        [Browsable(true)]
        public string ToolTipTitle { get; set; }

        [Description("Informatia pe care ToolTip-ul o va afisa (doar daca acesta este afisat - vezi proprietatea ToolTipActiv)")]
        [Category("ToolTip")]
        [Browsable(true)]
        [DefaultValue("")]
        public string ToolTipText { get; set; }

        [Description("True pentru a folosi ToolTip pentru aceasta zona, False pentru a-l dezactiva")]
        [Category("ToolTip")]
        [DefaultValue(false)]
        [Browsable(true)]
        public bool ToolTipActiv { get; set; }

        #endregion

        #region Constructor si Initializare

        public LabelPersonalizat()
        {
            SeteazaDoubleBuffer();
            AdaugaMeniuContextual();
        }

        public LabelPersonalizat(IContainer container)
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

        protected override void OnEnter(EventArgs e)
        {
            ControaleCreateDinamic.SetControlTinta(this);
            base.OnEnter(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            if (this.ToolTipActiv == true)
            {
                string sMesajToolTip = string.Empty;
                if (!string.IsNullOrEmpty(this.ToolTipText))
                    sMesajToolTip = this.ToolTipText;
                else
                    sMesajToolTip = this.Text;
                ControaleCreateDinamic.AfiseazaToolTip(this, ToolTipIcon.Info, this.ToolTipTitle, sMesajToolTip);
            }
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (this.ToolTipActiv == true)
                ControaleCreateDinamic.AscundeToolTip(this);
            base.OnMouseLeave(e);
        }

        #endregion

        #region Metode private

        public void AdaugaMeniuContextual()
        {
            //Adaugam meniul contextual
            this.ContextMenuStrip = ControaleCreateDinamic.GetMeniuContextualZonaText();
        }

        #endregion

        #region Metode publice

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

        public void Goleste()
        {
            this.Text = string.Empty;
        }

        public bool AcceptaActiunea(EnumTipActiuneControl pTipActiune)
        {
            switch (pTipActiune)
            {
                case EnumTipActiuneControl.Diacritice:
                    return false;
                case EnumTipActiuneControl.Undo:
                    return false;
                case EnumTipActiuneControl.Cautare:
                    return false;
                case EnumTipActiuneControl.Decupare:
                    return false;
                case EnumTipActiuneControl.Inserare:
                    return false;
                case EnumTipActiuneControl.Export:
                    return false;
                case EnumTipActiuneControl.Printare:
                    return false;
                case EnumTipActiuneControl.CopiereTabel:
                    return false;
                case EnumTipActiuneControl.SelectareText:
                    return false;
            }
            return false;
        }

        public void ExecutaActiunea(EnumTipActiuneControl pTipActiune)
        {

        }

        #endregion

        #region IMembriComuniControalePersonalizate Members

        public List<int> Cauta(string pText)
        {
            return CUtil.ExtrageListaPozitiiAparente(this.Text, pText);
        }

        public void SelecteazaLaPozitia(int pPozitie, int pLungimeText)
        {
            //Nu avem cum sa facem asta la label
        }

        [Description("Pentru a implementa interfata IMembriComuniControalePersonalitate. Nu are niciun alt rol")]
        [Category("iDava")]
        [DefaultValue(true)]
        public bool HideSelection
        {
            get { return true; }
            set { }
        }

        [DefaultValue(false)]
        public bool IsInModificationMode
        {
            get { return false; }
        }

        [DefaultValue(true)]
        public bool IsInReadOnlyMode
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        [DefaultValue("")]
        public string ProprietateCorespunzatoare
        {
            get
            {
                return string.Empty;
            }
            set
            {
            }
        }

        [DefaultValue(0)]
        public int SelectionStart
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        [DefaultValue(0)]
        public int SelectionLength
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        [DefaultValue("")]
        public string SelectedText
        {
            get
            {
                return string.Empty;
            }
            set
            {
            }
        }

        public void AllowModification(bool pbInModificationMode)
        {

        }

        public void SelecteazaTextul()
        {

        }

        public void Paste()
        {

        }

        public void Undo()
        {

        }

        public void Copy()
        {
            Clipboard.SetText(this.Text);
        }

        public void Cut()
        {
        }

        public void InsereazaText(string pText)
        {
            int Pozitie = this.SelectionStart;
            this.Text = this.Text.Insert(Pozitie, pText);
            this.SelectionStart = Pozitie + 1;
        }

        public void SeteazaAlerta()
        {
            this.ForeColor = Color.Red;
        }

        public void IndeparteazaAlerta()
        {
            this.ForeColor = Color.Black;
        }

        public void GestioneazaAlertaValoareNegativa(double pSold)
        {
            if (pSold < 0)
                this.SeteazaAlerta();
            else
                this.IndeparteazaAlerta();
        }

        #endregion

    }
}
