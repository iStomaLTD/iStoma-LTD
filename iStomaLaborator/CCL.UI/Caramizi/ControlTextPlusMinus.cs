using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CCL.UI.Caramizi
{
    [DefaultEvent("ValoareModificata")]
    public partial class ControlTextPlusMinus : UserControlComun
    {

        #region Declaratii generale

        public event System.EventHandler ValoareModificata;

        private int lValoareActuala = 0;
        private int lValoareMinima = 0;
        private int lValoareMaxima = 0;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati

        public int Valoare { get { return this.lValoareActuala; } }

        #endregion

        #region Constructor si Initializare

        public ControlTextPlusMinus()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
        }

        public void Initializeaza(int pValoareActuala, int pValoareMinima, int pValoareMaxima)
        {
            base.InitializeazaVariabileleGenerale();

            this.lValoareActuala = pValoareActuala;
            this.lValoareMaxima = pValoareMaxima;
            this.lValoareMinima = pValoareMinima;

            incepeIncarcarea();

            initValoarea();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void txtValoare_AfterUpdate(Control sender, string sNumeProprietateAtasata, string sNouaValoare)
        {
            try
            {
                int nouaValoare = this.txtValoare.ValoareIntreaga;
                if (nouaValoare <= this.lValoareMaxima && nouaValoare >= this.lValoareMinima)
                {
                    this.lValoareActuala = nouaValoare;
                    anuntaModificareaValorii();
                    AllowModification(this.lEcranInModificare);
                }
                else
                {
                    this.txtValoare.ValoareIntreaga = this.lValoareActuala;
                }
            }
            catch (Exception ex)
            {
                Mesaj.Eroare(IHMUtile.GetFormParinte(this), ex.Message, IHMUtile.getText(605));
            }	
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            try
            {
                this.lValoareActuala += 1;
                initValoarea();
                anuntaModificareaValorii();

                AllowModification(this.lEcranInModificare);
            }
            catch (Exception ex)
            {
                Mesaj.Eroare(IHMUtile.GetFormParinte(this), ex.Message, IHMUtile.getText(605));
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            try
            {
                this.lValoareActuala -= 1;
                initValoarea();
                anuntaModificareaValorii();

                AllowModification(this.lEcranInModificare);
            }
            catch (Exception ex)
            {
                Mesaj.Eroare(IHMUtile.GetFormParinte(this), ex.Message, IHMUtile.getText(605));
            }
        }

        #endregion

        #region Metode private

        private void initValoarea()
        {
            this.txtValoare.ValoareIntreaga = this.lValoareActuala;
        }

        private void anuntaModificareaValorii()
        {
            if (this.ValoareModificata != null)
            {
                ValoareModificata(this, null);
            }
        }

        #endregion

        #region Metode publice

        public void Goleste()
        {
            this.txtValoare.ValoareIntreaga = 0;
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;

            this.btnMinus.Visible = this.lEcranInModificare && this.lValoareActuala > this.lValoareMinima;
            this.btnPlus.Visible = this.lEcranInModificare && this.lValoareActuala < this.lValoareMaxima;
            this.txtValoare.AllowModification(this.lEcranInModificare);
        }

        #endregion

    }
}
