using System;
using System.Windows.Forms;

namespace CCL.UI.Caramizi
{
    public partial class ControlInterval : Panel
    {

        #region Declaratii generale

        public event System.EventHandler SelectieSchimbata;
        private bool lSeIncarca = false;
        private ComboBoxOra.EnumPas lPas = ComboBoxOra.EnumPas.OraFixa;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati

        public DateTime DataInceput
        {
            get
            {
                return this.cboOraInceput.TextCaData;
            }
        }

        public DateTime DataSfarsit
        {
            get
            {
                return this.cboOraFinal.TextCaData;
            }
        }

        #endregion

        #region Constructor si Initializare

        public ControlInterval()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                adaugaHandlere();
                initTextML();
            }
        }

        private void adaugaHandlere()
        {
            this.cboOraInceput.CerereUpdate += cboOra_CerereUpdate;
            this.cboOraFinal.CerereUpdate += cboOra_CerereUpdate;
        }

        private void initTextML()
        {

        }

        public void Initializeaza()
        {
            Initializeaza(ComboBoxOra.EnumPas.OraFixa);
        }

        public void Initializeaza(ComboBoxOra.EnumPas pPas)
        {
            incepeIncarcarea();

            this.lPas = pPas;

            this.cboOraInceput.Initializeaza(this.lPas);
            this.cboOraFinal.Initializeaza(this.lPas);

            finalizeazaIncarcarea();
        }

        public void Initializeaza(ComboBoxOra.EnumPas pPas, int pOraInceput, int pOraSfarsit)
        {
            if (pOraInceput <= pOraSfarsit)
            {
                pOraInceput = 8;
                pOraSfarsit = 21;
            }

            this.lPas = pPas;

            this.cboOraInceput.Initializeaza(this.lPas);
            this.cboOraFinal.Initializeaza(this.lPas);

            this.cboOraInceput.SelectedIndex = pOraInceput * (60 / Convert.ToInt32(this.lPas));
            this.cboOraFinal.SelectedIndex = pOraSfarsit * (60 / Convert.ToInt32(this.lPas));
        }

        public void SeteazaInterval(DateTime pOraInceput, DateTime pOraFinal)
        {
            this.cboOraInceput.TextCaData = pOraInceput;
            this.cboOraFinal.TextCaData = pOraFinal;
        }

        #endregion

        #region Evenimente

        void cboOra_CerereUpdate(object psender, string proprietate, object sNouaValoare)
        {
            if (this.lSeIncarca) return;

            if (this.SelectieSchimbata != null)
                SelectieSchimbata(psender, null);
        }

        #endregion

        #region Metode private

        private void incepeIncarcarea()
        {
            this.lSeIncarca = true;
        }

        private void finalizeazaIncarcarea()
        {
            this.lSeIncarca = false;
        }

        #endregion

        #region Metode publice

        public void SetVizibilitateZone(bool pAmbeleZoneVizibile)
        {
            this.labelPersonalizat1.Visible = pAmbeleZoneVizibile;
            this.cboOraFinal.Visible = pAmbeleZoneVizibile;
        }

        #endregion

        #region IControlDava Members

        public void PermiteIntroducereaManuala()
        {
            this.cboOraInceput.DropDownStyle = ComboBoxStyle.DropDown;
            this.cboOraFinal.DropDownStyle = ComboBoxStyle.DropDown;
        }

        public void AllowModification(bool pPermiteModificarea)
        {
            this.cboOraInceput.AllowModification(pPermiteModificarea);
            this.cboOraFinal.AllowModification(pPermiteModificarea);
        }

        public bool AreValoare()
        {
            return this.cboOraInceput.OraMinut != this.cboOraFinal.OraMinut && this.cboOraInceput.OraMinut < this.cboOraFinal.OraMinut;
        }

        public bool EsteDataInInterval(DateTime pDataTest)
        {
            int oraMinutTest = pDataTest.Hour * 60 + pDataTest.Minute;

            return oraMinutTest >= this.cboOraInceput.OraMinut && oraMinutTest <= this.cboOraFinal.OraMinut;
        }

        public int GetOraMinutInceput()
        {
            return this.cboOraInceput.OraMinut;
        }

        public int GetOraMinutFinal()
        {
            return this.cboOraFinal.OraMinut;
        }

        #endregion

    }
}
