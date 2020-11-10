using System;
using System.ComponentModel;
using System.Windows.Forms;
using ILL.iStomaLab;

namespace CCL.UI.Caramizi
{
    [DefaultEvent("TextChanged")]
    public partial class ControlSMS : UserControlComun, IAllowModification
    {

        #region Declaratii generale

        public event System.EventHandler TextChanged;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati

        public override string Text
        {
            get
            {
                return this.txtMesaj.Text;
            }
            set
            {
                this.txtMesaj.Text = value;
            }
        }

        #endregion

        #region Constructor si Initializare

        public ControlSMS()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lblContinut.Text = IHMUtile.getText(48);
            this.lblMesaje.Text = string.Format("{0}:", IHMUtile.getText(1488));

            this.txtMesaj.TextChanged += txtMesaj_TextChanged;
        }

        public void Initializeaza(string pMesaj)
        {
            Initializeaza(CDL.iStomaLab.CConstante.LUNGIME_SMS, pMesaj);
        }

        public void Initializeaza(int pLungimeSMS, string pMesaj)
        {
            incepeIncarcarea();
            this.txtMesaj.Text = pMesaj;
            calculeazaMesajeSiCaractere(pMesaj.Length);
            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        void txtMesaj_TextChanged(object sender, EventArgs e)
        {
            if (this.TextChanged != null)
                TextChanged(this, null);
        }

        private void txtMesaj_KeyUpPersonalizat(object sender, KeyEventArgs e)
        {
            try
            {
                calculeazaMesajeSiCaractere(this.txtMesaj.Text.Length);
            }
            catch (Exception ex)
            {
                //Nu facem nimic
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Metode private

        private void calculeazaMesajeSiCaractere(int pNrCaractereIntroduse)
        {
            int nrMesaje = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(pNrCaractereIntroduse) / CDL.iStomaLab.CConstante.LUNGIME_SMS));
            this.lblMesaje.Text = string.Format("{0}: {1}", IHMUtile.getText(1488), nrMesaje);

            this.lblCaractereRamase.Text = string.Format("{0}/{1}", pNrCaractereIntroduse, nrMesaje * CDL.iStomaLab.CConstante.LUNGIME_SMS);
        }

        #endregion

        #region Metode publice

        public void Insereaza(string pText)
        {
            this.txtMesaj.InsereazaText(pText);
        }

        public void Goleste()
        {
            this.txtMesaj.Goleste();
        }

        public bool AreValoare()
        {
            return this.txtMesaj.AreValoare();
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
            this.txtMesaj.AllowModification(this.lEcranInModificare);
        }

        #endregion

    }
}
