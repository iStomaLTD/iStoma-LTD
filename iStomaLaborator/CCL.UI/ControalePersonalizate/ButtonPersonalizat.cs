using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using CDL.iStomaLab;

namespace CCL.UI
{
    public class ButtonPersonalizat : Button
    {
        #region Declaratii generale

        private bool lIsSelectat = false;
        private EnumTipButon lButtonType = EnumTipButon.Standard;
        private bool lEsteInModModificare = true;
        private CDefinitiiComune.EnumSex lGenulTextului = CDefinitiiComune.EnumSex.Barbatesc;
        private bool lUtilizeazaToolTip = false;
        private string lMesajToolTip = string.Empty;
        private string lTitluToolTip = string.Empty;
        private ToolTipIcon lToolTipIcon = ToolTipIcon.Info;

        private static Color lCuloareInchisa = System.Drawing.Color.FromArgb(224, 224, 224);
        private static Color lCuloareDeschisa = Color.LightGray;

        private static Color lCUloareButonParametrajInchisa = Color.Blue;
        private static Color lCUloareButonParametrajDeschisa = Color.Blue;

        private int lDistantaMargini = 3;

        //private Image lImagineDesen = null;
        private bool lButonActiv = false; //butonul devine activ cand mouse-ul se gaseste pe el; in acel moment va avea chenarul rosu
        private bool lButonFocus = false; //Cand mouse-ul e apasat simulam focusul (folosim doar culoarea deschisa)

        #endregion

        #region Enumeratii si Structuri

        public enum EnumTipButon
        {
            ActiviDezactivati = 10,
            Adaugare = 20,
            AfisareLista = 25,
            Ajutor = 29,
            GestiuneFiltreVerticala = 26,
            GestiuneFiltreOrizontala = 27,
            Anulare = 30,
            Bascula = 40,
            Calendar = 50,
            Cautare = 60,
            CautareGoogle = 65,
            CautareWikipedia = 66,
            Calculator = 67,
            Copiere = 68,
            DetaliiPopUp = 70, //Deschide fereastra de detalii a unui obiect in mod Pup-Up
            Deschide = 71,
            Dreapta = 75,
            Documente = 76,
            Editare = 77,
            Email = 79,
            Export = 78,
            Guma = 80,
            Istoric = 85,
            InchidereEcran = 86,
            Minimizare = 87,
            MaiMulte = 88,
            Jos = 90,
            LecturaModificare = 100,
            LansareCautare = 105,
            MeniuStanga = 110,
            NavigarePrimul = 111,
            NavigareInapoi = 112,
            NavigareInainte = 113,
            NavigareUltimul = 114,
            Parametraj = 120,
            Print = 123,
            Refresh = 124,
            Salvare = 125,
            Standard = 130,
            SortareAlfabetica = 140,
            Sus = 150,
            Stanga = 155,
            Stergere = 158,
            Validare = 160,
            Zoom = 190,
        }

        #endregion

        #region Constructor

        public ButtonPersonalizat()
        {
            InitializeazaButonul();
        }

        public ButtonPersonalizat(IContainer container)
            : this()
        {
            container.Add(this);
        }

        #endregion

        #region Proprietati

        [Description("Afisam imaginea de informatii in stanga b")]
        [Category("iDava")]
        [DefaultValue(false)]
        public bool AfiseazaImagineSemnalizareToolTip { get; set; }

        [Description("Precizam daca butonul este selectat sau nu. Starea normala a butonului corespunde valorii false")]
        [Category("iDava")]
        [DefaultValue(false)]
        public virtual bool Selectat
        {
            get
            {
                return this.Visible && this.lIsSelectat;
            }
            set
            {
                this.lIsSelectat = value;
                ButtonSelectedChanged();
            }
        }

        [Description("Indica daca butonul este in modificare sau nu")]
        [Category("iDava")]
        [Browsable(false)]
        public bool IsInModificationMode
        {
            get
            {
                return this.lEsteInModModificare;
            }
        }

        [Description("Precizam genul textului afisat pe buton (Ex: pentru a obtine textul Active in loc de Activi)")]
        [Category("iDava")]
        [Browsable(false)]
        public CDefinitiiComune.EnumSex GenulTextului
        {
            get { return this.lGenulTextului; }
            set { this.lGenulTextului = value; }
        }

        [Description("Precizam tipul butonului pentru a putea gestiona afisajul in cazul aplicarii unui skin")]
        [Category("iDava")]
        public EnumTipButon TipButon
        {
            get
            {
                return this.lButtonType;
            }
            set
            {
                this.lButtonType = value;

                FormateazaButon();
            }
        }

        [Description("Precizam daca se afiseaza tool-tip-ul cand mouse-ul este deasupra butonului")]
        [DefaultValue(false)]
        [Category("iDava")]
        public bool UtilizeazaToolTip
        {
            get { return this.lUtilizeazaToolTip; }
            set { this.lUtilizeazaToolTip = value; }
        }

        [Description("Iconita tool-tip-ului; Are sens doar daca se utilizeaza tool-tip-ul")]
        [Category("iDava")]
        public ToolTipIcon ToolTipIcon
        {
            get { return this.lToolTipIcon; }
            set { this.lToolTipIcon = value; }
        }

        [Description("Titlul tool-tip-ului; Are sens doar daca se utilizeaza tool-tip-ul")]
        [Category("iDava")]
        [DefaultValue("")]
        public string ToolTipTitle
        {
            get { return this.lTitluToolTip; }
            set { this.lTitluToolTip = value; }
        }

        [Description("Mesajul tool-tip-ului; Are sens doar daca se utilizeaza tool-tip-ul")]
        [Category("iDava")]
        [DefaultValue("")]
        public string ToolTipMessage
        {
            get { return this.lMesajToolTip; }
            set { this.lMesajToolTip = value; }
        }

        public new Image Image
        {
            get { return base.Image; }
            set { base.Image = value; }
        }

        #endregion

        #region Metode

        protected System.Windows.Forms.Form GetFormParinte()
        {
            return IHMUtile.GetFormParinte(this);
        }

        public static void SeteazaCuloriButoane(Color pCuloareButonStandard, Color pCuloareButonParametraj, Color pCuloareChenarMouseOver, bool pCuloarePlina)
        {
            if (pCuloareButonStandard.R == 240 && pCuloareButonStandard.G == 240 && pCuloareButonStandard.B == 240)
            {
                lCuloareInchisa = Color.Gray;
                if (pCuloarePlina)
                    lCuloareDeschisa = Color.Gray;
                else
                    lCuloareDeschisa = Color.LightGray;
            }
            else
            {
                lCuloareInchisa = pCuloareButonStandard;
                if (pCuloarePlina)
                    lCuloareDeschisa = pCuloareButonStandard;
                else
                    lCuloareDeschisa = IHMUtile.LightenColor(lCuloareInchisa, 0.4);
            }

            IHMUtile.PENSULA_CHENAR_SELECTAT = new Pen(pCuloareChenarMouseOver);
            lCUloareButonParametrajInchisa = pCuloareButonParametraj;

            if (pCuloarePlina)
                lCUloareButonParametrajDeschisa = pCuloareButonParametraj;
            else
                lCUloareButonParametrajDeschisa = IHMUtile.LightenColor(lCUloareButonParametrajInchisa, 0.4);
        }

        private void InitializeazaButonul()
        {
            SeteazaDoubleBuffer();
            ActiveazaButonul();
        }

        private void SeteazaDoubleBuffer()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        /// <summary>
        /// Trecem din mod modificare in mod lectura si invers
        /// Pentru un buton guma sau de parametraj acest lucru inseamna ca il facem invizibil sau vizibil
        /// </summary>
        /// <param name="pbInModificationMode"></param>
        public void AllowModification(bool pbInModificationMode)
        {
            this.lEsteInModModificare = pbInModificationMode;
            if (this.lButtonType == EnumTipButon.Guma ||
                this.lButtonType == EnumTipButon.Parametraj ||
                this.lButtonType == EnumTipButon.Cautare ||
                this.lButtonType == EnumTipButon.Calendar ||
                this.lButtonType == EnumTipButon.DetaliiPopUp)
            {
                this.Visible = this.lEsteInModModificare;
            }
            else
            {
                this.Enabled = this.lEsteInModModificare;
            }
        }

        public void SeteazaToolTip(string pToolTip)
        {
            this.UtilizeazaToolTip = !string.IsNullOrEmpty(pToolTip);
            this.ToolTipMessage = pToolTip;
        }

        public void ActiveazaButonul()
        {
            //this.BackColor = System.Drawing.Color.LightPink;
            //this.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        }

        public void ApasaButonul()
        {
            //this.BackColor = System.Drawing.Color.Thistle;
            //this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        }

        private Color getCuloareInchisa()
        {
            if (this.lButonFocus) return getCuloareDeschisa();

            switch (this.lButtonType)
            {
                case EnumTipButon.Parametraj:
                    return lCUloareButonParametrajInchisa;
                case EnumTipButon.InchidereEcran:
                case EnumTipButon.Minimizare:
                    return Color.Red;
                case EnumTipButon.Validare:
                    return Color.Green; // Color.FromArgb(218, 254, 213);
                case EnumTipButon.Anulare:
                    return Color.Red; //Color.FromArgb(255, 221, 221);
            }
            return lCuloareInchisa;
        }

        private Color getCuloareDeschisa()
        {
            switch (this.lButtonType)
            {
                case EnumTipButon.Parametraj:
                    return lCUloareButonParametrajDeschisa;
                case EnumTipButon.InchidereEcran:
                case EnumTipButon.Minimizare:
                    return Color.Pink;
                case EnumTipButon.Validare:
                    return Color.Honeydew;
                case EnumTipButon.Anulare:
                    return Color.Honeydew;
            }

            return lCuloareDeschisa;
        }

        /// <summary>
        /// Formatam butonul in concordanta cu tipul si modul acestuia
        /// </summary>
        private void FormateazaButon()
        {
            switch (this.lButtonType)
            {
                case EnumTipButon.InchidereEcran:
                    this.Image = null;
                    this.Text = "X";
                    break;
                case EnumTipButon.Minimizare:
                    this.Image = null;
                    this.Text = "_";
                    break;
                case EnumTipButon.Istoric:
                    this.Image = null;
                    this.Text = "H";
                    this.Size = new Size(23, 23);
                    break;
                case EnumTipButon.Ajutor:
                    this.Image = CCL.UI.Imagini.getImagineHelp();
                    this.Text = "";
                    break;
                case EnumTipButon.Zoom:
                    this.Image = CCL.UI.Properties.Resources.zoomIn;
                    this.ForeColor = System.Drawing.SystemColors.ControlText;
                    this.Text = "";
                    break;
                case EnumTipButon.Standard:
                    //Momentan nu avem nicio actiune pentru acest tip de buton
                    this.ForeColor = System.Drawing.SystemColors.ControlText;
                    break;
                case EnumTipButon.Editare:
                    this.Image = CCL.UI.Properties.Resources.edit16x16;
                    this.ForeColor = System.Drawing.SystemColors.ControlText;
                    this.Text = "";
                    break;
                case EnumTipButon.Parametraj:
                    //Butonul de parametraj nu are niciodata imagine
                    this.Image = null;
                    this.ForeColor = System.Drawing.SystemColors.ControlText;
                    this.Text = "";
                    break;
                case EnumTipButon.Bascula:
                    this.Image = null;
                    this.ForeColor = System.Drawing.SystemColors.ControlText;
                    break;
                case EnumTipButon.Guma:
                    this.Image = CCL.UI.Properties.Resources.eraser;
                    this.ForeColor = System.Drawing.SystemColors.ControlText;
                    this.Text = "";
                    break;
                case EnumTipButon.Refresh:
                    this.Image = CCL.UI.Properties.Resources.refresh;
                    this.ForeColor = System.Drawing.SystemColors.ControlText;
                    this.Text = "";
                    break;
                case EnumTipButon.Calendar:
                    this.Image = CCL.UI.Properties.Resources.calendarIcon;// calendar_plus;
                    this.ForeColor = System.Drawing.SystemColors.ControlText;
                    this.Text = "";
                    break;
                case EnumTipButon.Cautare:
                    //Un buton de cautare are textul "..." dar niciodata imagine
                    this.Text = "...";
                    this.Image = null;
                    this.ForeColor = System.Drawing.SystemColors.ControlText;
                    break;
                case EnumTipButon.CautareGoogle:
                    //Un buton de cautare pe google nu are text ci doar imagine
                    this.Text = null;
                    this.Image = CCL.UI.Properties.Resources.google16;
                    this.ForeColor = System.Drawing.SystemColors.ControlText;
                    break;
                case EnumTipButon.CautareWikipedia:
                    //Un buton de cautare pe google nu are text ci doar imagine
                    this.Text = null;
                    this.Image = CCL.UI.Properties.Resources.WikipediaLogo;
                    this.ForeColor = System.Drawing.SystemColors.ControlText;
                    break;
                case EnumTipButon.ActiviDezactivati:
                    // In acest caz butonul are doua stari Activi/Dezactivati
                    // Starea initiala este: "Activi" si va corespunde valorii false a proprietatii 
                    // Selectat. Cand aceasta este true vom avea starea "Dezactivati"
                    this.ForeColor = System.Drawing.Color.Black;
                    this.Text = "";
                    setImagineStatutActiviDezactivati();
                    break;
                case EnumTipButon.MeniuStanga:
                    this.UseVisualStyleBackColor = false;
                    this.lIsSelectat = false;
                    this.FlatAppearance.BorderSize = 0;
                    this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    this.ForeColor = System.Drawing.Color.Transparent;
                    this.BackColor = System.Drawing.Color.Transparent;
                    this.Margin = new System.Windows.Forms.Padding(0);
                    break;
                case EnumTipButon.LecturaModificare:
                    // In acest caz butonul are doua stari Lectura si Modificare
                    // Lectura <=> Selectat = false; 
                    // Modificare <=> Selectat = true; (Util pentru AllowModification)
                    this.Text = "";
                    if (this.lIsSelectat)
                        this.Image = CCL.UI.Properties.Resources.ModModificare24;
                    else
                        this.Image = CCL.UI.Properties.Resources.ModCitire24;
                    break;
                case EnumTipButon.LansareCautare:
                    this.Text = "";
                    this.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
                    this.Image = CCL.UI.Properties.Resources.Cauta25;
                    break;
                case EnumTipButon.GestiuneFiltreVerticala:
                    this.Text = "";
                    setImagineStatutFiltreVerticala();
                    break;
                case EnumTipButon.GestiuneFiltreOrizontala:
                    this.Text = "";
                    setImagineStatutFiltreOrizontala();
                    break;
                case EnumTipButon.Sus:
                    this.Text = "";
                    this.Image = CCL.UI.Properties.Resources.Sus24;
                    break;
                case EnumTipButon.Jos:
                    this.Text = "";
                    this.Image = CCL.UI.Properties.Resources.Jos24;
                    break;
                case EnumTipButon.Stanga:
                    this.Text = "";
                    this.Image = CCL.UI.Properties.Resources.Stanga24;
                    break;
                case EnumTipButon.Dreapta:
                    this.Text = "";
                    this.Image = CCL.UI.Properties.Resources.Dreapta24;
                    break;
                case EnumTipButon.Documente:
                    base.Image = CCL.UI.Properties.Resources.MyDocuments16;
                    break;
                case EnumTipButon.Adaugare:
                    this.Text = "";
                    this.Image = CCL.UI.Properties.Resources.Adauga;
                    break;
                case EnumTipButon.Email:
                    this.Text = "";
                    this.Image = CCL.UI.Properties.Resources.email;
                    break;
                case EnumTipButon.Validare:
                    this.Image = CCL.UI.Properties.Resources.Validare;
                    break;
                case EnumTipButon.Salvare:
                    this.Image = CCL.UI.Properties.Resources.Text_save;
                    break;
                case EnumTipButon.Anulare:
                    this.Image = CCL.UI.Properties.Resources.Anulare;
                    break;
                case EnumTipButon.SortareAlfabetica:
                    this.Image = CCL.UI.Properties.Resources.btn_asc_sort;
                    break;
                case EnumTipButon.Stergere:
                    this.Image = CCL.UI.Properties.Resources.deleteGri2;
                    break;
                case EnumTipButon.DetaliiPopUp:
                    this.Text = "";
                    this.Image = CCL.UI.Properties.Resources.ToolTip16;
                    break;
                case EnumTipButon.Deschide:
                    this.Image = Imagini.getImagineDeschideDocument();
                    break;
                case EnumTipButon.NavigarePrimul:
                    this.Text = "";
                    this.Image = CCL.UI.Properties.Resources.Primul;
                    break;
                case EnumTipButon.NavigareInapoi:
                    this.Text = "";
                    this.Image = CCL.UI.Properties.Resources.Inapoi;
                    break;
                case EnumTipButon.NavigareInainte:
                    this.Text = "";
                    this.Image = CCL.UI.Properties.Resources.Inainte;
                    break;
                case EnumTipButon.NavigareUltimul:
                    this.Text = "";
                    this.Image = CCL.UI.Properties.Resources.Ultimul;
                    break;
                case EnumTipButon.AfisareLista:
                    this.Text = "";
                    this.Image = CCL.UI.Properties.Resources.AfisareLista;
                    break;
                case EnumTipButon.Print:
                    this.Image = CCL.UI.Properties.Resources.printer;
                    break;
                case EnumTipButon.Export:
                    this.Image = CCL.UI.Properties.Resources.Text_table;
                    break;
                case EnumTipButon.Copiere:
                    this.Image = CCL.UI.Properties.Resources.Text_copy;
                    break;
                case EnumTipButon.MaiMulte:
                    this.Text = string.Empty;
                    this.Image = Imagini.GetImagineMaiMulte();
                    break;
                case EnumTipButon.Calculator:
                    this.Text = string.Empty;
                    this.Image = Imagini.GetImagineCalculator();
                    break;
            }
        }

        private void setImagineStatutFiltreVerticala()
        {
            if (this.lIsSelectat)
                this.Image = CCL.UI.Properties.Resources.Sus24;
            else
                this.Image = CCL.UI.Properties.Resources.Jos24;
        }

        private void setImagineStatutFiltreOrizontala()
        {
            if (this.lIsSelectat)
                this.Image = CCL.UI.Properties.Resources.Stanga24;
            else
                this.Image = CCL.UI.Properties.Resources.Dreapta24;
        }

        private void setImagineStatutLecturaModificare()
        {
            if (this.lIsSelectat)
                this.Image = CCL.UI.Properties.Resources.ModModificare24;
            else
                this.Image = CCL.UI.Properties.Resources.ModCitire24;
        }

        private void setImagineStatutZoom()
        {
            if (this.lIsSelectat)
                this.Image = CCL.UI.Properties.Resources.zoomOut;
            else
                this.Image = CCL.UI.Properties.Resources.zoomIn;
        }

        private void setImagineStatutActiviDezactivati()
        {
            if (this.lIsSelectat)
                this.Image = CCL.UI.Properties.Resources.NOK;
            else
                this.Image = CCL.UI.Properties.Resources.OK;
        }

        private void ButtonSelectedChanged()
        {
            switch (this.lButtonType)
            {
                case EnumTipButon.Zoom:
                    setImagineStatutZoom();
                    break;
                case EnumTipButon.Standard:
                    break;
                case EnumTipButon.Parametraj:
                    break;
                case EnumTipButon.Bascula:
                    if (this.lIsSelectat)
                        this.Image = CCL.UI.Properties.Resources.sageataJos;
                    else
                        this.Image = null;
                    break;
                case EnumTipButon.Guma:
                    break;
                case EnumTipButon.Calendar:
                    break;
                case EnumTipButon.Cautare:
                    break;
                case EnumTipButon.ActiviDezactivati:
                    setImagineStatutActiviDezactivati();
                    break;
                case EnumTipButon.LecturaModificare:
                    setImagineStatutLecturaModificare();
                    break;
                case EnumTipButon.GestiuneFiltreOrizontala:
                    setImagineStatutFiltreOrizontala();
                    break;
                case EnumTipButon.GestiuneFiltreVerticala:
                    setImagineStatutFiltreVerticala();
                    break;
            }

            //setImage();
        }

        private void SimuleazaFocus()
        {
            this.lButonFocus = true;
            this.Invalidate();
        }

        private void SimuleazaNormal()
        {
            this.lButonFocus = false;
            this.Invalidate();
        }

        private Image getImage(ref bool pDisposeImage)
        {
            Image lImagineDesen = base.Image;
            if (lImagineDesen == null)
                lImagineDesen = base.BackgroundImage;

            if (lImagineDesen != null)
                if (lImagineDesen.Height > this.Height)
                {
                    Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                    lImagineDesen = lImagineDesen.GetThumbnailImage(24, 24, myCallback, IntPtr.Zero);

                    pDisposeImage = true;
                }

            return lImagineDesen;
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        private Point getPunctDesenareImagine(Image imagine)
        {
            Point PunctImagine = new Point(0, 0);
            ContentAlignment AliniereImagine = base.ImageAlign;
            if (string.IsNullOrEmpty(this.Text))
                AliniereImagine = ContentAlignment.MiddleCenter;

            switch (AliniereImagine)
            {
                case ContentAlignment.BottomCenter:
                    PunctImagine = new Point(base.Width / 2 - base.Image.Width / 2, base.Height / 2 - imagine.Height / 2);
                    break;
                case ContentAlignment.BottomLeft:
                    PunctImagine = new Point(this.lDistantaMargini, base.Height / 2 - imagine.Height / 2);
                    break;
                case ContentAlignment.BottomRight:
                    PunctImagine = new Point((base.Width - imagine.Width) - this.lDistantaMargini, base.Height / 2 - imagine.Height / 2);
                    break;
                case ContentAlignment.MiddleCenter:
                    PunctImagine = new Point(base.Width / 2 - imagine.Width / 2, base.Height / 2 - imagine.Height / 2);
                    break;
                case ContentAlignment.MiddleLeft:
                    PunctImagine = new Point(this.lDistantaMargini, base.Height / 2 - imagine.Height / 2);
                    break;
                case ContentAlignment.MiddleRight:
                    PunctImagine = new Point((base.Width - imagine.Width) - this.lDistantaMargini, base.Height / 2 - imagine.Height / 2);
                    break;
                case ContentAlignment.TopCenter:
                    PunctImagine = new Point(base.Width / 2 - imagine.Width / 2, base.Height / 2 - imagine.Height / 2);
                    break;
                case ContentAlignment.TopLeft:
                    PunctImagine = new Point(this.lDistantaMargini, base.Height / 2 - imagine.Height / 2);
                    break;
                case ContentAlignment.TopRight:
                    PunctImagine = new Point((base.Width - imagine.Width) - this.lDistantaMargini, base.Height / 2 - imagine.Height / 2);
                    break;
                default:
                    break;
            }
            return PunctImagine;
        }

        #endregion

        #region Evenimente

        protected override void OnClick(EventArgs e)
        {
            this.Selectat = !this.Selectat;

            //setImage();

            this.Invalidate();

            base.OnClick(e);
        }

        protected override void OnMouseHover(EventArgs e)
        {
            if (this.lUtilizeazaToolTip && !this.AfiseazaImagineSemnalizareToolTip)
                afiseazaToolTip();

            base.OnMouseHover(e);
        }

        private void afiseazaToolTip()
        {
            ControaleCreateDinamic.AfiseazaToolTip(this, this.lToolTipIcon, this.lTitluToolTip, this.lMesajToolTip);
        }

        protected override void OnMouseMove(MouseEventArgs mevent)
        {
            if (this.lUtilizeazaToolTip && this.AfiseazaImagineSemnalizareToolTip && mevent.Location.X >= (this.Width - 20))
                afiseazaToolTip();

            base.OnMouseMove(mevent);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            if (this.TipButon != EnumTipButon.MeniuStanga)
            {
                Graphics g = pevent.Graphics;

                Rectangle newRect = new Rectangle(ClientRectangle.X, ClientRectangle.Y,
                ClientRectangle.Width, ClientRectangle.Height);

                Rectangle rectUtil = new Rectangle(ClientRectangle.X, ClientRectangle.Y,
                ClientRectangle.Width - 1, ClientRectangle.Height - 1);

                if (this.Parent != null)
                {
                    using (Brush fundal = new SolidBrush(this.Parent.BackColor))
                    {
                        g.FillRectangle(fundal, ClientRectangle);
                    }
                }

                using (GraphicsPath path = DreptunghiRotunjit.Create(rectUtil, 3, DreptunghiRotunjit.RectangleCorners.All))
                {
                    SizeF textSize = g.MeasureString(this.Text, base.Font);
                    int textX = (int)(base.Size.Width / 2) - (int)(textSize.Width / 2);
                    int textY = (int)(base.Size.Height / 2) - (int)(textSize.Height / 2);

                    g.SmoothingMode = SmoothingMode.HighQuality;

                    //Coloram dreptunghiul vizibil la ecran - fol culoarea de fundal a parintelui
                    if (this.Parent != null)
                    {
                        using (Brush pensulaParinte = new SolidBrush(this.Parent.BackColor))
                        {
                            g.FillRectangle(pensulaParinte, newRect);
                        }
                    }

                    //Coloram interiorul
                    using (Brush Pensula = new LinearGradientBrush(newRect, getCuloareInchisa(), getCuloareDeschisa(), LinearGradientMode.Vertical))
                    {
                        if (this.lButtonType == EnumTipButon.InchidereEcran || this.lButtonType == EnumTipButon.Minimizare)
                            g.FillRectangle(Pensula, newRect);
                        else
                            g.FillPath(Pensula, path);
                    }

                    //Desenam marginile
                    if (this.lButtonType == EnumTipButon.InchidereEcran || this.lButtonType == EnumTipButon.Minimizare)
                        g.DrawRectangle((this.lButonActiv ? Pens.DarkGray : Pens.Black), newRect.X, newRect.Y, newRect.Width - 1, newRect.Height - 1);
                    else
                    {
                        if (IHMUtile.PENSULA_CHENAR_SELECTAT != null && IHMUtile.PENSULA_CHENAR != null)
                            g.DrawPath((this.lButonActiv ? IHMUtile.PENSULA_CHENAR_SELECTAT : IHMUtile.PENSULA_CHENAR), path);
                    }

                    //Pentru a redesena doar zona asta
                    g.SetClip(path);

                    if (base.Image != null || base.BackgroundImage != null)
                    {
                        bool disposeImage = false;
                        Image lImagineDesen = getImage(ref disposeImage);
                        if (lImagineDesen != null)
                            g.DrawImage(lImagineDesen, getPunctDesenareImagine(lImagineDesen));
                        if (disposeImage)
                        {
                            lImagineDesen.Dispose();
                            lImagineDesen = null;
                        }
                    }

                    Color culoareText = base.ForeColor;
                    if (!this.Enabled)
                        culoareText = getCuloareInchisa();
                    if (this.lButtonType == EnumTipButon.InchidereEcran || this.lButtonType == EnumTipButon.Minimizare)
                        culoareText = Color.White;

                    if (!string.IsNullOrEmpty(this.Text))
                    {
                        using (Brush pensulaC = new SolidBrush(culoareText))
                        {
                            g.DrawString(this.Text, base.Font, pensulaC, textX, textY);
                        }
                    }

                    //Daca avem tooltip activ atunci desenam butonul de info
                    if (this.AfiseazaImagineSemnalizareToolTip && this.UtilizeazaToolTip)
                        g.DrawImage(Imagini.getImagineInformatii(), new Rectangle(newRect.X + (newRect.Width - 18), newRect.Y + (newRect.Height - 16) / 2, 16, 16));

                    g.ResetClip();
                }
            }
            else
                base.OnPaint(pevent);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.lButonActiv = true;
            this.Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            SimuleazaFocus();
            base.OnEnter(e);
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            SimuleazaNormal();
            base.OnMouseUp(e);
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            SimuleazaFocus();
            base.OnMouseDown(e);
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            this.lButonActiv = false;
            this.Invalidate();

            ascundeToolTip();

            base.OnMouseLeave(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            SimuleazaNormal();

            ascundeToolTip();

            base.OnLeave(e);
        }

        private void ascundeToolTip()
        {
            if (this.lUtilizeazaToolTip == true)
                ControaleCreateDinamic.AscundeToolTip(this);
        }

        #endregion
    }
}
