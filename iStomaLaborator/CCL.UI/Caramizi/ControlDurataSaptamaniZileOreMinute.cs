using System;
using System.ComponentModel;
using System.Windows.Forms;
using ILL.iStomaLab;
using CCL.iStomaLab;

namespace CCL.UI.Caramizi
{
    [DefaultEvent("CerereUpdate")]
    public partial class ControlDurataSaptamaniZileOreMinute : PanelContainerCCL
    {
        #region Declaratii Generale

        public event CEvenimente.ZonaModificata CerereUpdate;
        private bool lIsInModificationMode = true;
        private bool lIsInReadOnlyMode = false;
        private bool lUtilizeazaButonGuma = true;
        private bool lUtilizeazaSaptamani = true;
        private bool lUtilizeazaZile = true;
        private bool lUtilizeazaOre = true;
        private bool lUtilizeazaMinute = true;
        private string lProprietateCorespunzatoare; //utila pentru Reflection (initializare dinamica)

        #endregion

        #region Proprietati

        [Description("Durata introdusa in zile")]
        [Category("iDava")]
        [DefaultValue(0)]
        [Browsable(false)]
        public int DurataSaptamani
        {
            get
            {
                int DurataIntrodusa = this.Durata;
                if (DurataIntrodusa > 0)
                {
                    if (this.rbZile.Checked)
                        return DurataIntrodusa / 7;
                    else
                        if (this.rbOre.Checked)
                            return DurataIntrodusa / (7 * 24);
                        else
                            if (this.rbMinute.Checked)
                                return DurataIntrodusa / (7 * 24 * 60);
                }
                return DurataIntrodusa;
            }
            set
            {
                this.rbSaptamani.Checked = true;
                this.txtDurata.Text = Convert.ToString(value);
            }
        }

        [Description("Durata introdusa in zile")]
        [Category("iDava")]
        [DefaultValue(0)]
        [Browsable(false)]
        public int DurataZile
        {
            get
            {
                int DurataIntrodusa = this.Durata;
                if (DurataIntrodusa > 0)
                {
                    if (this.rbSaptamani.Checked)
                        return DurataIntrodusa * 7;
                    else
                        if (this.rbOre.Checked)
                            return DurataIntrodusa / 24;
                        else
                            if (this.rbMinute.Checked)
                                return DurataIntrodusa / (24 * 60);
                }
                return DurataIntrodusa;
            }
            set
            {
                this.rbZile.Checked = true;
                this.txtDurata.Text = Convert.ToString(value);
            }
        }

        [Description("Durata introdusa in ore")]
        [Category("iDava")]
        [DefaultValue(0)]
        [Browsable(false)]
        public int DurataOre
        {
            get
            {
                int DurataIntrodusa = this.Durata;
                if (DurataIntrodusa > 0)
                {
                    if (this.rbSaptamani.Checked)
                        return DurataIntrodusa * 7 * 24;
                    else
                        if (this.rbZile.Checked)
                            return DurataIntrodusa * 24;
                        else
                            if (this.rbMinute.Checked)
                                return DurataIntrodusa / 60;
                }
                return DurataIntrodusa;
            }
            set
            {
                this.rbOre.Checked = true;
                this.txtDurata.Text = Convert.ToString(value);
            }
        }

        [Description("Durata introdusa in minute")]
        [Category("iDava")]
        [DefaultValue(0)]
        [Browsable(false)]
        public int DurataMinute
        {
            get
            {
                int DurataIntrodusa = this.Durata;
                if (DurataIntrodusa > 0)
                {
                    if (this.rbSaptamani.Checked)
                        return DurataIntrodusa * 7 * 24 * 60;
                    else
                        if (this.rbZile.Checked)
                            return DurataIntrodusa * 24 * 60;
                        else
                            if (this.rbOre.Checked)
                                return DurataIntrodusa * 60;
                }
                return DurataIntrodusa;
            }
            set
            {
                this.rbMinute.Checked = true;
                this.txtDurata.Text = Convert.ToString(value);
            }
        }

        [Description("Durata introdusa; Nu tinem cont de unitatea de masura")]
        [DefaultValue(0)]
        [Category("iDava")]
        public int Durata
        {
            get
            {
                int DurataIntrodusa = 0;
                if (!string.IsNullOrEmpty(this.txtDurata.Text.Trim()))
                {
                    Int32.TryParse(this.txtDurata.Text.Trim(), out DurataIntrodusa);
                }
                return DurataIntrodusa;
            }
            set
            {
                int DurataUtila = value;
                if (this.lUtilizeazaSaptamani && DurataUtila % (7 * ((this.lUtilizeazaOre) ? 24 : 1) * ((this.lUtilizeazaMinute) ? 60 : 1)) == 0)
                {
                    this.rbSaptamani.Checked = true;
                    DurataUtila = DurataUtila / (7 * ((this.lUtilizeazaOre) ? 24 : 1) * ((this.lUtilizeazaMinute) ? 60 : 1));
                }
                else
                    if (this.lUtilizeazaZile && DurataUtila % (((this.lUtilizeazaOre) ? 24 : 1) * ((this.lUtilizeazaMinute) ? 60 : 1)) == 0)
                    {
                        this.rbZile.Checked = true;
                        DurataUtila = DurataUtila / (((this.lUtilizeazaOre) ? 24 : 1) * ((this.lUtilizeazaMinute) ? 60 : 1));
                    }
                    else
                        if (this.lUtilizeazaOre && DurataUtila % ((this.lUtilizeazaMinute) ? 60 : 1) == 0)
                        {
                            this.rbOre.Checked = true;
                            DurataUtila = DurataUtila / ((this.lUtilizeazaMinute) ? 60 : 1);
                        }
                        else
                            if (this.lUtilizeazaMinute)
                            {
                                this.rbMinute.Checked = true;
                            }
                this.txtDurata.Text = Convert.ToString(DurataUtila);
            }
        }

        [Description("Sunt situatii cand butonul guma poate fi util la crearea inregistrarii dar nicidecum la modificarea acesteia. Cu ajutorul acestei proprietati putem renunta la utilizarea butonului guma")]
        [DefaultValue(true)]
        [Category("iDava")]
        public bool UtilizeazaButonGuma
        {
            get { return this.lUtilizeazaButonGuma; }
            set
            {
                this.lUtilizeazaButonGuma = value;
                this.txtDurata.UtilizeazaButonGuma = this.lUtilizeazaButonGuma;
            }
        }

        [Description("Pentru a permite utilizarea saptamanilor la introducerea duratei")]
        [DefaultValue(true)]
        [Category("iDava")]
        public bool UtilizeazaSaptamani
        {
            get { return this.lUtilizeazaSaptamani; }
            set
            {
                this.lUtilizeazaSaptamani = value;
                this.rbSaptamani.Visible = this.lUtilizeazaSaptamani;
            }
        }

        [Description("Pentru a permite utilizarea zilelor la introducerea duratei")]
        [DefaultValue(true)]
        [Category("iDava")]
        public bool UtilizeazaZile
        {
            get { return this.lUtilizeazaZile; }
            set
            {
                this.lUtilizeazaZile = value;
                this.rbZile.Visible = this.lUtilizeazaZile;
            }
        }

        [Description("Pentru a permite utilizarea orelor la introducerea duratei")]
        [DefaultValue(true)]
        [Category("iDava")]
        public bool UtilizeazaOre
        {
            get { return this.lUtilizeazaOre; }
            set
            {
                this.lUtilizeazaOre = value;
                this.rbOre.Visible = this.lUtilizeazaOre;
            }
        }

        [Description("Pentru a permite utilizarea minutelor la introducerea duratei")]
        [DefaultValue(true)]
        [Category("iDava")]
        public bool UtilizeazaMinute
        {
            get { return this.lUtilizeazaMinute; }
            set
            {
                this.lUtilizeazaMinute = value;
                this.rbMinute.Visible = this.lUtilizeazaMinute;
            }
        }

        [Description("Precizam expres ca acest control este intotdeauna in mod ReadOnly (Metoda AllowModification nu va avea niciun efect)")]
        [Category("iDava")]
        public bool IsInReadOnlyMode
        {
            get { return this.lIsInReadOnlyMode; }
            set
            {
                this.lIsInReadOnlyMode = value;
                AllowModification(this.lIsInModificationMode);
            }
        }

        [Description("Pentru a putea cunoaste din exterior modul in care se afla lista")]
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
            set
            {
                this.lProprietateCorespunzatoare = value;
                this.txtDurata.ProprietateCorespunzatoare = value;
            }
        }

        #endregion

        #region Constructori

        public ControlDurataSaptamaniZileOreMinute()
        {
            DoubleBuffered = true;
            InitializeComponent();

            this.rbMinute.Text = CUtil.getText(1056);
            this.rbOre.Text = CUtil.getText(1053);
            this.rbSaptamani.Text = CUtil.getText(1041);
            this.rbZile.Text = CUtil.getText(1042);
        }

        #endregion

        #region Metode

        public void Goleste()
        {
            this.txtDurata.Goleste();
        }

        /// <summary>
        /// Trecem din mod modificare in mod lectura si invers
        /// </summary>
        /// <param name="pbInModificationMode"></param>
        public void AllowModification(bool pbInModificationMode)
        {
            this.lIsInModificationMode = pbInModificationMode && !this.lIsInReadOnlyMode;
            this.txtDurata.AllowModification(this.lIsInModificationMode);
            this.rbSaptamani.Enabled = this.lIsInModificationMode;
            this.rbZile.Enabled = this.lIsInModificationMode;
            this.rbOre.Enabled = this.lIsInModificationMode;
            this.rbMinute.Enabled = this.lIsInModificationMode;
        }

        public void SetByDiferentaDate(DateTime pData1, DateTime pData2)
        {
            this.Durata = Math.Abs(Convert.ToInt32(DateAndTime.DateDiff(DateInterval.Minute, pData1, pData2)));
        }

        private void ComandaUpdate(object pNouaValoare)
        {
            if (this.CerereUpdate != null)
                CerereUpdate(this, this.ProprietateCorespunzatoare, pNouaValoare);
        }

        #endregion

        #region Evenimente

        private void rbSaptamani_CheckedChanged(object sender, EventArgs e)
        {
            ComandaUpdate(this.DurataSaptamani);
        }

        private void rbZile_CheckedChanged(object sender, EventArgs e)
        {
            ComandaUpdate(this.DurataZile);
        }

        private void rbOre_CheckedChanged(object sender, EventArgs e)
        {
            ComandaUpdate(this.DurataOre);
        }

        private void rbMinute_CheckedChanged(object sender, EventArgs e)
        {
            ComandaUpdate(this.DurataMinute);
        }

        private void txtDurata_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            ComandaUpdate(pNouaValoare);
        }

        #endregion

    }
}
