using System;
using System.Windows.Forms;

namespace CCL.UI.Caramizi
{
    public partial class ControlNumarLuni : PanelContainerCCL, ILL.iStomaLab.IAllowModification
    {

        #region Declaratii generale

        public event CEvenimente.ZonaModificata CerereUpdate;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati

        public int NumarLuni
        {
            get
            {
                int nr = 0;
                if (int.TryParse(this.txtNrLuni.Text, out nr))
                    return nr;
                return 0;
            }
            set { this.txtNrLuni.Text = Convert.ToString(value); }
        }

        #endregion

        #region Constructor si Initializare

        public ControlNumarLuni()
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
            this.txtNrLuni.CerereUpdate += txtNrLuni_CerereUpdate;
        }

        private void initTextML()
        {
            this.lblLuni.Text = "luni";
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();


            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void txtNrLuni_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            try
            {
                if (CerereUpdate != null)
                    CerereUpdate(this, string.Empty, this.txtNrLuni.Text);
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


        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
            this.txtNrLuni.AllowModification(this.lEcranInModificare);
        }

        #endregion


    }
}
