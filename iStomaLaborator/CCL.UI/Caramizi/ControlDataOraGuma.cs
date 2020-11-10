using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CDL.iStomaLab;
using ILL.iStomaLab;

namespace CCL.UI.Caramizi
{
    [DefaultEvent("CerereUpdate")]
    //public partial class ControlDataOraGuma : UserControlComun, IAllowModification
    public partial class ControlDataOraGuma : PanelContainerCCL, IAllowModification
    {

        #region Declaratii generale

        public event ZonaModificata CerereUpdate;
        public delegate void ZonaModificata(Control psender, string proprietate, object sNouaValoare);
        public event System.EventHandler AfisareCalendar;
        public event System.EventHandler InchidereCalendar;

        private bool _bIsInModificationMode = true;
        private bool _bIsInReadOnlyMode = false;
        private string _sProprietateCorespunzatoare; //utila pentru Reflection (initializare dinamica)
        private DateTime lPragInferior = CConstante.DataNula;
        private DateTime lPragSuperior = CConstante.DataNula;
        private bool lAfiseazaButonGuma = true;
        private bool lModificareData = true;
        private bool lModificareOre = true;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati

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
        public override string Text
        {
            get
            {
                DateTime dDataAfisata = this.DataAfisata;
                if (dDataAfisata != CConstante.DataNula)
                    return dDataAfisata.ToString("dd/MM/yyyy HH:mm");
                else
                    return string.Empty;
            }
            set
            {
                DateTime dDataAfisata = CConstante.DataNula;
                if (!DateTime.TryParse(value, out dDataAfisata))
                    dDataAfisata = CConstante.DataNula;
                this.DataAfisata = dDataAfisata;
            }
        }

        [Description("Data cu care alimentam acest control")]
        [Category("iDava")]
        public DateTime DataAfisata
        {
            get
            {
                DateTime dDataAfisata = CConstante.DataNula;
                if (this.ctrlData.DataAfisata != CConstante.DataNula && !String.IsNullOrEmpty(this.cboOre.Text))
                {
                    dDataAfisata = this.ctrlData.DataAfisata;
                    dDataAfisata = new DateTime(dDataAfisata.Year, dDataAfisata.Month, dDataAfisata.Day, this.cboOre.Ora, this.cboOre.Minut, 0);
                }

                return dDataAfisata;
            }
            set
            {
                this.lSeIncarca = true;
                this.ctrlData.DataAfisata = value;

                this.cboOre.UpdateItems(string.Format("{0:HH}:{0:mm}", value));

                this.cboOre.BeginUpdate();
                this.cboOre.Initializeaza(ComboBoxOra.EnumPas.CinciMinute);

                if (value != CConstante.DataNula)
                    this.cboOre.TextCaData = value;
                else
                    this.cboOre.Text = "00:00";

                AllowModification(this.lModificareData, this.lModificareOre);

                this.cboOre.EndUpdate();
                this.lSeIncarca = false;
            }
        }

        public bool AreValoare
        {
            get { return this.DataAfisata != CConstante.DataNula; }
        }

        [Description("Tipul de deschidere al calendarului asociat")]
        [Category("iDava")]
        public CEnumerariComune.EnumTipDeschidere TipDeschidereCalendar
        {
            get { return this.ctrlData.TipDeschidereCalendar; }
            set { this.ctrlData.TipDeschidereCalendar = value; }
        }

        //[Description("Tipul de aliniere al calendarului asociat fata de butonul ce afiseaza calendarul")]
        //[Category("iDava")]
        //public CEnumerariComune.EnumTipAliniere TipAliniereCalendar
        //{
        //    get { return this.ctrlData.TipAliniereCalendar; }
        //    set { this.ctrlData.TipAliniereCalendar = value; }
        //}

        [Description("Data sub care nu permitem selectia unei date")]
        [Category("iDava")]
        public DateTime PragInferior
        {
            get { return this.lPragInferior; }
            set
            {
                this.lPragInferior = value;
                this.ctrlData.PragInferior = value;
            }
        }

        [Description("Data peste care nu permitem selectia unei date")]
        [Category("iDava")]
        public DateTime PragSuperior
        {
            get { return this.lPragSuperior; }
            set
            {
                this.lPragSuperior = value;
                this.ctrlData.PragSuperior = value;
            }
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
                AllowModification(this.lModificareData, this.lModificareOre);
            }
        }

        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                this.ctrlData.BackColor = value;
            }
        }

        #endregion

        #region Constructor si Initializare

        public ControlDataOraGuma()
        {
            InitializeComponent();

            this.ctrlData.AfisareCalendar += ctrlData_AfisareCalendar;
            this.ctrlData.InchidereCalendar += ctrlData_InchidereCalendar;
        }

        public void Initializeaza(DateTime pData, ComboBoxOra.EnumPas pPas)
        {
            this.DataAfisata = pData;
            this.cboOre.Initializeaza(pPas);
            AllowModification(this._bIsInModificationMode);
        }

        public void Initializeaza(DateTime pData)
        {
            this.DataAfisata = pData;
            this.cboOre.Initializeaza(ComboBoxOra.EnumPas.CinciMinute);
            AllowModification(this._bIsInModificationMode);
        }

        #endregion

        #region Evenimente

        private void btnGuma_Click(object sender, EventArgs e)
        {
            //Stergem data
            if (this.lModificareData)
                this.ctrlData.DataAfisata = CConstante.DataNula;

            //Stergem ora
            if (this.lModificareOre)
                this.cboOre.Text = string.Empty;

            cboOra_CerereUpdate(this, this._sProprietateCorespunzatoare, CConstante.DataNula);
        }

        private void ctrlData_CerereUpdate(Control psender, string proprietate, object sNouaValoare)
        {
            if (string.IsNullOrEmpty(this.cboOre.Text))
                this.cboOre.Text = "00:00";

            cboOra_CerereUpdate(psender, proprietate, sNouaValoare);
        }

        private void cboOre_TextChanged(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            cboOra_CerereUpdate(sender, this.cboOre.ProprietateCorespunzatoare, this.cboOre.Text);
        }

        private void cboOra_CerereUpdate(object psender, string proprietate, object sNouaValoare)
        {
            if (this.lSeIncarca) return;
            try
            {
                if (psender != ctrlData)
                {
                    string OraPrimita = Convert.ToString(sNouaValoare);
                    int Pozitia1 = 0;
                    int Pozitia2 = 0;
                    int Pozitia3 = 0;
                    int Pozitia4 = 0;
                    if (!string.IsNullOrEmpty(OraPrimita))
                    {
                        OraPrimita = OraPrimita.Replace(":", "");
                        if (OraPrimita.Length > 0)
                        {
                            Pozitia1 = Convert.ToInt32(OraPrimita.Substring(0, 1));
                            if (Pozitia1 < 0 || Pozitia1 > 2)
                                Pozitia1 = 0;
                            if (OraPrimita.Length > 1)
                            {
                                Pozitia2 = Convert.ToInt32(OraPrimita.Substring(1, 1));
                                if (Pozitia1 == 2 && Pozitia2 > 3)
                                    Pozitia2 = 0;
                                if (OraPrimita.Length > 2)
                                {
                                    Pozitia3 = Convert.ToInt32(OraPrimita.Substring(2, 1));
                                    if (Pozitia3 < 0 || Pozitia3 > 5)
                                        Pozitia3 = 0;

                                    if (OraPrimita.Length > 3)
                                        Pozitia4 = Convert.ToInt32(OraPrimita.Substring(3, 1));
                                }
                            }
                        }
                    }
                    string NouaOra = string.Format("{0}{1}:{2}{3}", Pozitia1, Pozitia2, Pozitia3, Pozitia4);
                    if (!this.cboOre.Text.Equals(NouaOra))
                        this.cboOre.Text = NouaOra;
                }
                if (this.CerereUpdate != null)
                {
                    CerereUpdate(this, this._sProprietateCorespunzatoare, this.DataAfisata);
                }
            }
            catch (Exception)
            {
                this.cboOre.Text = string.Empty;
                if (this.CerereUpdate != null)
                {
                    CerereUpdate(this, this._sProprietateCorespunzatoare, this.DataAfisata);
                }
            }
            AllowModification(this.lModificareData, this.lModificareOre);
        }

        void ctrlData_InchidereCalendar(object sender, EventArgs e)
        {
            try
            {
                if (this.InchidereCalendar != null)
                    InchidereCalendar(this, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IHMUtile.getText(605), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ctrlData_AfisareCalendar(object sender, EventArgs e)
        {
            try
            {
                if (this.AfisareCalendar != null)
                    AfisareCalendar(this, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IHMUtile.getText(605), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Metode private



        #endregion

        #region Metode publice

        public void AfiseazaCalendar()
        {
            this.ctrlData.AfiseazaCalendar();
        }

        public void SeteazaMinutul(int pMinut)
        {
            this.cboOre.TextCaData = new DateTime(1, 1, 1, this.cboOre.Ora, pMinut, 0);
        }

        public void AllowModification(bool pbInModificationMode)
        {
            this.AllowModification(pbInModificationMode, pbInModificationMode);
        }

        /// <summary>
        /// Trecem din modul modificare in modul lectura si invers
        /// </summary>
        /// <param name="pbInModificationMode"></param>
        public void AllowModification(bool pModificareData, bool pModificareOre)
        {
            //Daca modul ReadOnly este cerut expres nu vom schimba starea controlului la trecerea in mod modificare
            if (this._bIsInReadOnlyMode)
            {
                pModificareData = false;
                pModificareOre = false;
            }
            this._bIsInModificationMode = pModificareData || pModificareOre;
            this.lModificareData = pModificareData;
            this.lModificareOre = pModificareOre;

            bool ButonGumaVizibil = this.lAfiseazaButonGuma && this._bIsInModificationMode && (this.ctrlData.DataAfisata != CConstante.DataNula || !string.IsNullOrEmpty(this.cboOre.Text));
            this.ctrlData.AllowModification(pModificareData);
            this.cboOre.AllowModification(pModificareOre);
            this.btnGuma.AllowModification(ButonGumaVizibil);
        }

        public void Goleste()
        {
            this.DataAfisata = CConstante.DataNula;
        }

        public void setVizibilitateOra(bool pVizibil)
        {
            this.cboOre.Visible = pVizibil;
        }

        public bool EsteDinTrecut()
        {
            return this.DataAfisata <= DateTime.Now;
        }

        #endregion

    }
}
