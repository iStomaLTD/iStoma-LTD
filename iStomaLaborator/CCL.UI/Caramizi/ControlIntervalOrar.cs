using System;
using ILL.iStomaLab;
using ILL.iStomaLab;

namespace CCL.UI.Caramizi
{

    public partial class ControlIntervalOrar<R> : PanelContainerCCL, IAcceptaValidare<R> where R : Tuple<int, int>
    {
        private bool lEcranInModificare;
        private bool lSeIncarca;

        private static int _UltimaOraMinutInceput = -1;
        private static int _UltimaOraMinutFinal = -1;

        #region Declaratii generale


        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati

        public int OraMinutInceput
        {
            get { return this.cboOraInceput.OraMinut; }
        }

        public int OraMinutFinal
        {
            get { return this.cboOraFinal.OraMinut; }
        }

        #endregion

        #region Constructor si Initializare

        public ControlIntervalOrar()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
        }

        public static void DistrugeObiectele()
        {
            _UltimaOraMinutInceput = -1;
            _UltimaOraMinutFinal = -1;
        }

        public void Initializeaza()
        {
            this.SuspendLayout();

            this.lSeIncarca = true;

            this.cboOraInceput.Initializeaza(ComboBoxOra.EnumPas.SfertDeOra, true, 0, 24);
            this.cboOraFinal.Initializeaza(ComboBoxOra.EnumPas.SfertDeOra, true, 0, 24);

            this.cboOraInceput.SelectedItem = null;
            this.cboOraFinal.SelectedItem = null;

            if (_UltimaOraMinutInceput >= 0)
                this.cboOraInceput.SelecteazaElement(_UltimaOraMinutInceput, true);

            if (_UltimaOraMinutFinal >= 0)
                this.cboOraFinal.SelecteazaElement(_UltimaOraMinutFinal, true);

            this.lSeIncarca = false;

            this.ResumeLayout();
        }

        #endregion

        #region Evenimente

        private void cboOraInceput_CerereUpdate(object psender, string proprietate, object sNouaValoare)
        {
            if (this.lSeIncarca) return;

            _UltimaOraMinutInceput = this.OraMinutInceput;

            if (this.OraMinutInceput > this.OraMinutFinal)
            {
                this.lSeIncarca = true;
                this.cboOraFinal.SelecteazaElement(this.OraMinutInceput, true);
                this.lSeIncarca = false;
            }
        }

        private void cboOraFinal_CerereUpdate(object psender, string proprietate, object sNouaValoare)
        {
            if (this.lSeIncarca) return;

            _UltimaOraMinutFinal = this.OraMinutFinal;

            if (this.OraMinutInceput > this.OraMinutFinal)
            {
                this.lSeIncarca = true;
                this.cboOraInceput.SelecteazaElement(this.OraMinutFinal, true);
                this.lSeIncarca = false;
            }
        }

        #endregion

        #region Metode private



        #endregion

        #region Metode publice

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
        }

        public R Validare()
        {
            int oraMinInceput = this.OraMinutInceput;
            int oraMinFinal = this.OraMinutFinal;

            if (oraMinInceput >= oraMinFinal)
                throw new Exception("Intervalul ales nu poate fi validat");

            return (R)new Tuple<int, int>(oraMinInceput, oraMinFinal);
        }

        #endregion

    }
}
