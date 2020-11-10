using System;
using System.Drawing;
using System.Windows.Forms;

namespace CCL.UI.FormulareComune
{
    public partial class frmAfisareControl : frmCuHeader
    {

        #region Declaratii generale

        private Control lControlDeGazduit;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public frmAfisareControl(Control pControlDeGazduit)
        {
            InitializeComponent();

            this.lControlDeGazduit = pControlDeGazduit;

            if (this.lControlDeGazduit != null)
                this.lControlDeGazduit.Visible = false;

            this.PermiteDeplasareaEcranului = true;
            this.PermiteMaximizareaEcranului = true;

            Size MarimeEcran = pControlDeGazduit.MinimumSize;
            MarimeEcran.Height += this.lblTitluEcran.Height;

            this.Size = MarimeEcran;

            IHMUtile.StabilesteLocatia(this, null, false, CEnumerariComune.EnumTipDeschidere.CentrulEcranului,true);

            //Adaugam controlul in panelul corespunzator
            this.panelGlobal.Controls.Clear();
            //this.panelGlobal.Controls.Add(pControlDeGazduit);
            this.lControlDeGazduit.Parent = this.panelGlobal;
            this.lControlDeGazduit.Dock = DockStyle.Fill;

            //Ca sa fortam redesenarea controlului
            if (this.lControlDeGazduit != null)
                this.lControlDeGazduit.Visible = true;
        }

        #endregion

        private void frmAfisareControl_SizeChanged(object sender, EventArgs e)
        {
            if (this.lControlDeGazduit != null)
                this.lControlDeGazduit.Invalidate();
        }

        private void frmAfisareControl_Shown(object sender, EventArgs e)
        {
            if (this.lControlDeGazduit != null)
                this.lControlDeGazduit.Focus();
        }

        #region Evenimente



        #endregion

        #region Metode private



        #endregion

        #region Metode publice


        #endregion
       
    }
}
