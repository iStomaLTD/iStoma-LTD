using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ILL.iStomaLab;
using ILL.BLL.General;
using ILL.iStomaLab;
using CCL.iStomaLab;

namespace CCL.UI.Caramizi
{
    [DefaultEvent("CerereUpdate")]
    public partial class LabelGumaFind : PanelContainerCCL, IAllowModification
    {
        #region Declaratii generale

        public event CEvenimente.ZonaModificata CerereUpdate;
        public event CEvenimente.EventDeschideEcranCautare DeschideEcranCautare;
        public event CEvenimente.EventDeschideEcranCautare AfiseazaDetaliiObiectAtasat;

        private bool _bIsInModificationMode = true;
        private bool _bIsInReadOnlyMode = false;
        private string _sProprietateCorespunzatoare; //utila pentru Reflection (initializare dinamica)
        private string _sTextVid = "...";
        private ICheie lObiectCorespunzator = null;
        private IAfisaj lObiectAfisajCorespunzator = null;
        private bool _bFolosesteToString = false;
        private bool _AfiseazaButonDetalii = false;
        private bool _AfiseazaButonGuma = true;
        private bool _AfiseazaButonCautare = true;

        #endregion

        #region Proprietati

        [Description("Titlul ToolTip-ului (doar daca acesta este afisat - vezi proprietatea ToolTipActiv)")]
        [Category("ToolTip")]
        [DefaultValue("Info")]
        [Browsable(true)]
        public String ToolTipTitle
        {
            get { return this.lblText.ToolTipTitle; }
            set { this.lblText.ToolTipTitle = value; }
        }

        [Description("Informatia pe care ToolTip-ul o va afisa (doar daca acesta este afisat - vezi proprietatea ToolTipActiv)")]
        [Category("ToolTip")]
        [Browsable(true)]
        public String ToolTipText
        {
            get { return this.lblText.ToolTipText; }
            set { this.lblText.ToolTipText = value; }
        }

        [Description("True pentru a folosi ToolTip pentru aceasta zona, False pentru a-l dezactiva")]
        [Category("ToolTip")]
        [DefaultValue(false)]
        [Browsable(true)]
        public bool ToolTipActiv
        {
            get { return this.lblText.ToolTipActiv; }
            set { this.lblText.ToolTipActiv = value; }
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

        [Description("Folosim metoda ToString a obiectului corespunzator pentru a alimenta textul controlului")]
        [Category("iDava")]
        public bool FolosesteToString
        {
            get { return this._bFolosesteToString; }
            set
            {
                this._bFolosesteToString = value;
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
        [Browsable(true)]
        public override string Text
        {
            get { return this.lblText.Text; }
            set
            {
                this.lblText.Text = value;
                AllowModification(this._bIsInModificationMode);
            }
        }

        [Browsable(false)]
        public IAfisaj ObiectAfisajCorespunzator
        {
            get { return this.lObiectAfisajCorespunzator; }
            set
            {
                this.lObiectAfisajCorespunzator = value;
                if (value == null)
                    this.Text = _sTextVid;
                else
                    this.Text = value.DenumireAfisaj;
            }
        }

        [Description("Obiectul corespunzator acestui Label")]
        [Category("iDava")]
        [Browsable(false)]
        public ICheie ObiectCorespunzator
        {
            get { return this.lObiectCorespunzator; }
            set
            {
                this.lObiectCorespunzator = value;
                if (this._bFolosesteToString)
                {
                    if (value == null)
                    {
                        this.Text = _sTextVid;
                    }
                    else
                    {
                        this.Text = value.ToString();
                    }
                }
            }
        }

        [Description("Id-ul obiectului corespunzator acestui Label")]
        [Category("iDava")]
        [Browsable(false)]
        public int IdObiectCorespunzator
        {
            get
            {
                if (this.lObiectCorespunzator == null && this.lObiectAfisajCorespunzator == null)
                    return 0;

                if (this.lObiectAfisajCorespunzator != null)
                    return this.lObiectAfisajCorespunzator.Id;

                return this.lObiectCorespunzator.Id;
            }
        }

        [Description("In cazul in care avem nevoie sa consultam detaliile obiectului atasat vom seta la true;  altfel la false;")]
        [Category("iDava")]
        public bool AfiseazaButonDetalii
        {
            get { return this._AfiseazaButonDetalii; }
            set
            {
                this._AfiseazaButonDetalii = value;
                AllowModification(this._bIsInModificationMode);
            }
        }

        [Description("In cazul in care putem sterge obiectul atasat vom seta la true;  altfel (cand putem doar inlocui) la false;")]
        [Category("iDava")]
        public bool AfiseazaButonGuma
        {
            get { return this._AfiseazaButonGuma; }
            set
            {
                this._AfiseazaButonGuma = value;
                AllowModification(this._bIsInModificationMode);
            }
        }

        [Description("In cazul in care putem schimba/cauta obiectul atasat vom seta la true;  altfel la false;")]
        [Category("iDava")]
        public bool AfiseazaButonCautare
        {
            get { return this._AfiseazaButonCautare; }
            set
            {
                this._AfiseazaButonCautare = value;
                AllowModification(this._bIsInModificationMode);
            }
        }

        public ContentAlignment TextAlign
        {
            get { return this.lblText.TextAlign; }
            set { this.lblText.TextAlign = value; }
        }

        #endregion

        #region Constructori

        public LabelGumaFind()
        {
            DoubleBuffered = true;

            InitializeComponent();

            //Adaugam meniul contextual
            this.lblText.ContextMenuStrip = ControaleCreateDinamic.GetMeniuContextualZonaText();
            this.TextAlign = ContentAlignment.MiddleLeft;
        }

        #endregion

        #region Metode

        public void setLabelBorderStyle(System.Windows.Forms.BorderStyle pBorderStyle)
        {
            this.lblText.BorderStyle = pBorderStyle;
        }

        public bool AreValoare()
        {
            return this.lObiectAfisajCorespunzator != null || this.lObiectCorespunzator != null || !this.Text.Equals(this._sTextVid);
        }

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

            bool ButonAfiseazaDetaliiVizibil = !this.lblText.Text.Trim().Equals(this._sTextVid) &&
                                            this._AfiseazaButonDetalii;
            bool ButonCautareVizibil = this._bIsInModificationMode && this._AfiseazaButonCautare;
            bool ButonGumaVizibil = this._bIsInModificationMode &&
                                    (!this.lblText.Text.Trim().Equals(this._sTextVid) && !string.IsNullOrEmpty(this.lblText.Text.Trim())) &&
                                    this._AfiseazaButonGuma;

            this.btnCautare.Visible = ButonCautareVizibil;
            this.btnGuma.Visible = ButonGumaVizibil;
            this.btnAfiseazaDetalii.Visible = ButonAfiseazaDetaliiVizibil;

            //Modificam pozitia si latimea controalelor in functie de vizibilitatea acestora
            Point Locatie = this.btnCautare.Location;
            int LatimeLabel = this.Width;
            if (ButonCautareVizibil)
            {
                Locatie.X += this.btnCautare.Width + 2;
                LatimeLabel -= (this.btnCautare.Width + 2);

                this.btnCautare.Height = this.Height - 1;
            }
            if (ButonAfiseazaDetaliiVizibil)
            {
                this.btnAfiseazaDetalii.Location = Locatie;
                Locatie.X += this.btnAfiseazaDetalii.Width + 2;
                LatimeLabel -= (this.btnAfiseazaDetalii.Width + 2);
                this.btnAfiseazaDetalii.Height = this.Height - 1;
            }
            if (ButonGumaVizibil)
            {
                this.btnGuma.Location = new Point(this.Width - this.btnGuma.Width, this.btnGuma.Location.Y);
                LatimeLabel -= (this.btnGuma.Width + 2);
                this.btnGuma.Height = this.Height - 1;
            }

            //Pentru corectie DPI 120
            this.lblText.Height = this.Height - 1;

            //Label-ul se pozitioneaza dupa butoanele vizibile si are latimea maxima posibila (acopera spatiile goale)
            this.lblText.Location = Locatie;
            this.lblText.Width = LatimeLabel;
        }

        public void Goleste()
        {
            this.ObiectCorespunzator = null;
            this.ObiectAfisajCorespunzator = null;
            this.Text = _sTextVid;
        }

        #endregion

        #region Evenimente

        /// <summary>
        /// Stergem continutul Label-ului si anuntam controlul parinte 
        /// pentru a putea actualiza proprietatea corespunzatoare
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuma_Click(object sender, EventArgs e)
        {
            Goleste();
            if (this.CerereUpdate != null)
            {
                //De obicei salvam id-ul obiectului in baza iar -1 <=> null
                CerereUpdate(this, this._sProprietateCorespunzatoare, -1);
            }
            AllowModification(this._bIsInModificationMode);
        }

        /// <summary>
        /// Lasam controlul parinte sa deschida ecranul corespunzator si apoi sa alimenteze acest control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCautare_Click(object sender, EventArgs e)
        {
            if (DeschideEcranCautare != null)
            {
                DeschideEcranCautare(this, this.lObiectCorespunzator);
            }
        }

        /// <summary>
        /// Anuntam controlul parinte ca vrem sa afisam detaliile obiectului atasat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAfiseazaDetalii_Click(object sender, EventArgs e)
        {
            if (AfiseazaDetaliiObiectAtasat != null)
            {
                AfiseazaDetaliiObiectAtasat(this, this.lObiectCorespunzator);
            }
        }

        private void lblText_Enter(object sender, EventArgs e)
        {
            ControaleCreateDinamic.SetControlTinta(this.lblText);
        }

        #endregion

        public void Incarca<T>(List<T> pListaElemente)
        {
            this.Text = CUtil.getListaCaText<T>(pListaElemente, ", ");
        }

        public void SetToolTip(ToolTip pCtrlToolTip, string pText)
        {
            pCtrlToolTip.SetToolTip(this.lblText, pText);
        }
    }
}
