using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ILL.iStomaLab;
using CDL.iStomaLab;
using CCL.UI.Caramizi;
using CCL.iStomaLab;

namespace CCL.UI
{
    [DefaultEvent("CerereUpdate")]
    public partial class controlAlegeData : PanelContainerCCL, IAllowModification
    {
        #region Declaratii generale

        public event ZonaModificata CerereUpdate;
        public delegate void ZonaModificata(Control psender, string proprietate, object sNouaValoare);
        public event System.EventHandler AfisareCalendar;
        public event System.EventHandler InchidereCalendar;

        private bool lCuOre;
        private bool lCuSecunde;
        private CEnumerariComune.EnumTipDeschidere lTipDeschidere;
        //private CEnumerariComune.EnumTipAliniere _lTipAliniere;

        private bool lIsInModificationMode = true;
        private bool lIsInReadOnlyMode = false;
        private string lProprietateCorespunzatoare; //utila pentru Reflection (initializare dinamica)
        private DateTime lPragInferior = CConstante.DataNula;
        private DateTime lPragSuperior = CConstante.DataNula;
        private bool lAfiseazaButonGuma;
        private bool lAfiseazaZonaDeData = true;

        #endregion

        #region Enumerari


        #endregion

        #region Constructori

        public controlAlegeData()
        {
            InitializeComponent();
            InitializeazaData(CConstante.DataNula, false, false);
            this.txtData.ContextMenuStrip = ControaleCreateDinamic.GetMeniuContextualZonaText();
            this.btnAlegeData.TabStop = false;
        }

        public void Initializeaza(DateTime pDataDeAfisat)
        {
            this.DataAfisata = pDataDeAfisat;
        }

        public void InitializeazaData(DateTime dDataDeAfisat, bool bCuOra, bool bCuSecunde)
        {
            this.lCuOre = bCuOra;
            this.lCuSecunde = bCuSecunde;
            try
            {
                this.txtData.Mask = CUtil.GetDateMask(bCuOra, bCuSecunde);
            }
            catch (Exception)
            {
            }
            this.DataAfisata = dDataDeAfisat;
        }

        #endregion

        #region Proprietati

        public ButtonPersonalizat ButonAfiseazaCalendar
        {
            get { return this.btnAlegeData; }
        }

        [Description("Precizam expres ca acest control este intotdeauna in mod ReadOnly (Metoda AllowModification nu va avea niciun efect)")]
        [Category("iDava")]
        public bool IsInReadOnlyMode
        {
            get { return this.lIsInReadOnlyMode; }
            set
            {
                this.lIsInReadOnlyMode = value;
                this.txtData.IsInReadOnlyMode = this.lIsInReadOnlyMode;
            }
        }

        [Description("Precizam numele proprietatii obiectului sursa ce contine valoarea cu care vom initializa textul acestei zone. Utila pentru utilizarea initializarii dinamice.")]
        [Category("iDava")]
        public string ProprietateCorespunzatoare
        {
            get { return this.lProprietateCorespunzatoare; }
            set
            {
                this.lProprietateCorespunzatoare = value;
                this.txtData.ProprietateCorespunzatoare = value;
            }
        }

        [Description("Afiseaza si ora si minutele din data cu care alimentam acest control")]
        [Category("iDava")]
        public bool AfiseazaCuOra
        {
            get { return this.lCuOre; }
            set
            {
                this.lCuOre = value;
                this.txtData.Mask = CUtil.GetDateMask(this.lCuOre, this.lCuSecunde);
            }
        }

        [Description("Afiseaza si secunedele alaturi de ora si minute din data cu care alimentam acest control")]
        [Category("iDava")]
        public bool AfiseazaCuSecunde
        {
            get { return this.lCuSecunde; }
            set
            {
                this.lCuSecunde = value;
                this.txtData.Mask = CUtil.GetDateMask(this.lCuOre, this.lCuSecunde);
            }
        }

        [Description("Textul zonei de text")]
        [Category("iDava")]
        public override string Text
        {
            get
            {
                if (this.DataAfisata == CConstante.DataNula)
                    return string.Empty;
                else
                    return this.txtData.Text;
            }
            set
            {
                DateTime dDataAfisata = CConstante.DataNula;
                if (!DateTime.TryParse(value, out dDataAfisata))
                    dDataAfisata = CConstante.DataNula;
                this.DataAfisata = dDataAfisata;
            }
        }

        public bool AreData
        {
            get { return this.DataAfisata != CConstante.DataNula; }
        }

        [Description("Data cu care alimentam acest control")]
        [Category("iDava")]
        public DateTime DataAfisata
        {
            get
            {
                string textData = this.txtData.Text.Replace("/", "").Replace(".", "").Replace("_", "").Replace("-", "").Replace(":", "").Trim();
                if (string.IsNullOrEmpty(textData)) return CConstante.DataNula;

                DateTime dDataAfisata = CConstante.DataNula;
                try
                {
                    int zi = Convert.ToInt32(textData.Substring(0, 2));
                    int luna = Convert.ToInt32(textData.Substring(2, 2));
                    int an = Convert.ToInt32(textData.Substring(4, 4));
                    dDataAfisata = new DateTime(an, luna, zi, 0, 0, 0);
                }
                catch (Exception)
                {
                    dDataAfisata = CConstante.DataNula;
                }

                return dDataAfisata;
            }
            set
            {
                if (value != CConstante.DataNula)
                {
                    if (this.lCuOre)
                        if (this.lCuSecunde)
                            this.txtData.Text = value.ToString("dd/MM/yyyy HH:mm:ss");
                        else
                            this.txtData.Text = value.ToString("dd/MM/yyyy HH:mm");
                    else
                        this.txtData.Text = value.ToString("dd/MM/yyyy");
                }
                else
                    this.txtData.Text = string.Empty;
            }
        }

        [Description("Tipul de deschidere al calendarului asociat")]
        [Category("iDava")]
        public CEnumerariComune.EnumTipDeschidere TipDeschidereCalendar
        {
            get { return this.lTipDeschidere; }
            set { lTipDeschidere = value; }
        }

        //[Description("Tipul de aliniere al calendarului asociat fata de butonul ce afiseaza calendarul")]
        //[Category("iDava")]
        //public CEnumerariComune.EnumTipAliniere TipAliniereCalendar
        //{
        //    get { return this._lTipAliniere; }
        //    set { _lTipAliniere = value; }
        //}

        [Description("Data sub care nu permitem selectia unei date")]
        [Category("iDava")]
        public DateTime PragInferior
        {
            get { return this.lPragInferior; }
            set { this.lPragInferior = value; }
        }

        [Description("Data peste care nu permitem selectia unei date")]
        [Category("iDava")]
        public DateTime PragSuperior
        {
            get { return this.lPragSuperior; }
            set { this.lPragSuperior = value; }
        }

        [Description("Modifica afisarea butonului guma")]
        [Category("iDava")]
        [DefaultValue(true)]
        public bool AfiseazaButonGuma
        {
            get { return this.lAfiseazaButonGuma; }
            set
            {
                this.lAfiseazaButonGuma = value;
                AllowModification(this.lIsInModificationMode);
            }
        }

        [Description("Modifica afisarea zonei de data (pentru a putea folosi acest control ca in agenda)")]
        [Category("iDava")]
        [DefaultValue(true)]
        public bool AfiseazaZonaDeData
        {
            get { return this.lAfiseazaZonaDeData; }
            set
            {
                this.lAfiseazaZonaDeData = value;
                AllowModification(this.lIsInModificationMode);
            }
        }

        #endregion

        #region Metode

        public void AfiseazaCalendar()
        {
            CautaData();
        }

        private void btnAlegeData_Click(object sender, EventArgs e)
        {
            CautaData();
        }

        public void CautaData()
        {
            //Determinam locatia de deschidere a calendarului asociat
            if (this.AfisareCalendar != null)
                AfisareCalendar(this, null);

            using (frmControlBox xSelecteazaData = new frmControlBox(this.lTipDeschidere))
            {
                xSelecteazaData.PermiteDeplasareaEcranului = true;
                xSelecteazaData.PragInferior = this.lPragInferior;
                xSelecteazaData.PragSuperior = this.lPragSuperior;
                xSelecteazaData.DataInitializare = this.DataAfisata;
                xSelecteazaData.Text = string.Empty;

                CCL.UI.IHMUtile.DeschideEcran(this.GetFormParinte(), xSelecteazaData);

                if (xSelecteazaData.DataAleasa != CConstante.DataNula)
                {
                    this.txtData.Focus();
                    this.DataAfisata = xSelecteazaData.DataAleasa;
                    this.SelectNextControl(this, true, true, false, false);
                    this.AllowModification(this.lIsInModificationMode);

                    //OARE DE CE AM PUS CONDITIA ASTA?
                    //E UTILA TREABA ASTA LA TRIMITEREA DE SMS-URI CA SA REINITIALIZAM LISTA
                    //if (!this.lAfiseazaZonaDeData)
                    ComandaUpdate();
                }
            }

            if (this.InchidereCalendar != null)
                InchidereCalendar(this, null);
        }

        /// <summary>
        /// Trecem din modul modificare in modul lectura si invers
        /// </summary>
        /// <param name="pbInModificationMode"></param>
        public void AllowModification(bool pbInModificationMode)
        {
            //Daca modul ReadOnly este cerut expres nu vom schimba starea controlului la trecerea in mod modificare
            if (this.lIsInReadOnlyMode)
            {
                pbInModificationMode = false;
            }
            this.lIsInModificationMode = pbInModificationMode;

            if (this.lAfiseazaZonaDeData)
            {
                bool ButonGumaVizibil = this.lAfiseazaButonGuma && this.lIsInModificationMode && this.DataAfisata != CConstante.DataNula;
                bool ButonAlegeDataVizibil = this.lIsInModificationMode;

                this.txtData.AllowModification(this.lIsInModificationMode);
                this.btnAlegeData.AllowModification(ButonAlegeDataVizibil);
                this.btnGuma.AllowModification(ButonGumaVizibil);

                //Determinam latimea maxima a zonei utile
                int LatimeZonaDeText = this.Width;
                if (ButonAlegeDataVizibil)
                {
                    LatimeZonaDeText -= (this.btnAlegeData.Width + 2);
                    this.btnAlegeData.Height = Math.Min(this.txtData.Height, this.Height - 2);
                }

                if (ButonGumaVizibil)
                {
                    LatimeZonaDeText -= (this.btnGuma.Width + 2);
                }

                this.txtData.Width = LatimeZonaDeText;

                //Repozitionam zonele ramase vizibile
                if (ButonAlegeDataVizibil)
                {
                    if (ButonGumaVizibil)
                    {
                        this.btnAlegeData.Location = new Point(this.txtData.Location.X + this.txtData.Width + 2, this.btnAlegeData.Location.Y);
                    }
                    else
                    {
                        this.btnAlegeData.Location = new Point(this.Width - this.btnAlegeData.Width, this.btnGuma.Location.Y);
                    }
                }

                if (ButonGumaVizibil)
                {
                    this.btnGuma.Location = new Point(this.Width - this.btnGuma.Width, this.btnGuma.Location.Y);
                    this.btnGuma.Height = Math.Min(this.txtData.Height, this.Height - 2);

                    //this.btnGuma.Location = new Point(btnAlegeData.Location.X + btnAlegeData.Width + 2, this.btnGuma.Location.Y);
                }
            }
            else
            {
                IntindeButonulDeAlegereData();
            }
        }

        private void IntindeButonulDeAlegereData()
        {
            this.txtData.Visible = false;
            this.btnAlegeData.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Golim zona de text utila
        /// </summary>
        public void Goleste()
        {
            this.txtData.Text = string.Empty;
            AllowModification(this.lIsInModificationMode);
        }

        public bool EstePanaInclusivAzi()
        {
            if (!AreValoare())
                return false;
            else return DateAndTime.DateDiff(DateInterval.Day, this.DataAfisata, DateTime.Today) <= 0;
        }

        public bool AreValoare()
        {
            return this.DataAfisata != CConstante.DataNula;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool baseResult = base.ProcessCmdKey(ref msg, keyData);

            if ((keyData == Keys.Tab || keyData == Keys.Enter) && txtData.Focused)
            {
                string sData = txtData.Text.Replace(".", "").Replace("/", "").Replace("\\", "").Replace("-", "").Trim();
                if (!string.IsNullOrEmpty(sData) && sData.Length < 6)
                {
                    int lZi = DateTime.Now.Day;
                    int lLuna = DateTime.Now.Month;
                    int lAn = DateTime.Now.Year;
                    if (sData.Length == 1)
                        lZi = Convert.ToInt32(sData);
                    else
                    {
                        lZi = Convert.ToInt32(sData.Substring(0, 2));
                        if (sData.Length > 2)
                        {
                            if (sData.Length == 3)
                                lLuna = Convert.ToInt32(sData.Substring(2, 1));
                            else
                                lLuna = Convert.ToInt32(sData.Substring(2, 2));
                        }
                    }
                    this.DataAfisata = new DateTime(lAn, lLuna, lZi, 0, 0, 0);
                }

                //this.SelectNextControl(this, true, true, false, false);
                //Fara focusul asta nu trece mai departe
                this.btnAlegeData.Focus();
                return true;
            }
            else
            {
                //Ne incurca la data
                //if (keyData == Keys.Back || keyData == Keys.Delete)
                //    return true;
            }

            return baseResult;
        }

        public DateTime GetValoare()
        {
            return this.DataAfisata;
        }

        #endregion

        #region Evenimente

        private void btnGuma_Click(object sender, EventArgs e)
        {
            this.DataAfisata = CConstante.DataNula;
            ComandaUpdate();

            AllowModification(this.lIsInModificationMode);
        }

        private void txtData_AfterUpdate(Control sender, string sNumeProprietateAtasata, string sNouaValoare)
        {
            if (this.CerereUpdate != null)
            {
                bool DataValida = true;
                if ((this.lPragInferior != CConstante.DataNula || this.lPragSuperior != CConstante.DataNula) && this.DataAfisata != CConstante.DataNula)
                    if (this.lPragInferior > this.DataAfisata || this.lPragSuperior < this.DataAfisata)
                        DataValida = false;

                DateTime dDataAfisata = CConstante.DataNula;
                if (!DateTime.TryParse(this.txtData.VecheaValoare, out dDataAfisata))
                    dDataAfisata = CConstante.DataNula;

                if (!DataValida)
                    this.DataAfisata = dDataAfisata;

                if (dDataAfisata != CConstante.DataNula && this.DataAfisata == CConstante.DataNula)
                    this.DataAfisata = dDataAfisata;
                else
                    this.DataAfisata = this.DataAfisata;

                ComandaUpdate();

                AllowModification(this.lIsInModificationMode);
            }
        }

        private void ComandaUpdate()
        {
            if (CerereUpdate != null)
                CerereUpdate(this, this.lProprietateCorespunzatoare, this.DataAfisata);
        }

        private void btnAlegeData_Enter(object sender, EventArgs e)
        {

        }

        private void txtData_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.lIsInModificationMode)
            {

                if (this.txtData.SelectionStart < 3)
                {
                    this.txtData.SelectionStart = 0;
                    this.txtData.SelectionLength = 2;
                }
                else
                {
                    if (this.txtData.SelectionStart >= 3 && this.txtData.SelectionStart < 6)
                    {
                        this.txtData.SelectionStart = 3;
                        this.txtData.SelectionLength = 2;
                    }
                    else
                    {
                        if (this.lCuOre)
                        {
                            if (this.txtData.SelectionStart >= 6 && this.txtData.SelectionStart < 11)
                            {
                                this.txtData.SelectionStart = 6;
                                this.txtData.SelectionLength = 4;
                            }
                            else
                            {
                                if (this.txtData.SelectionStart >= 11 && this.txtData.SelectionStart < 14)
                                {
                                    this.txtData.SelectionStart = 11;
                                    this.txtData.SelectionLength = 2;
                                }
                                else
                                {
                                    this.txtData.SelectionStart = 14;
                                    this.txtData.SelectionLength = 2;
                                }
                            }
                        }
                        else
                        {
                            this.txtData.SelectionStart = 6;
                            this.txtData.SelectionLength = 4;
                        }
                    }
                }
            }
        }

        private void txtData_Enter(object sender, EventArgs e)
        {
            ControaleCreateDinamic.SetControlTinta(this.txtData);
        }

        #endregion

    }
}
