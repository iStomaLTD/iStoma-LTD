using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ILL.iStomaLab;

namespace CCL.UI.FormulareComune
{
    public partial class frmAfiseazaControlCuValidare<C, T> : frmCuHeaderSiValidare where C : Control, IControlCuHandlerSelectieSiValidare<T>
    {

        #region Declaratii generale

        C lControlIncarcat = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati

        public List<T> ListaElementeSelectionate { get; private set; }

        #endregion

        #region Constructor si Initializare

        public frmAfiseazaControlCuValidare(C pControl, string pTitluEcran)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.Text = pTitluEcran;
            this.lControlIncarcat = pControl;
            Initializeaza();
        }

        public void Initializeaza()
        {
            this.SuspendLayout();

            this.PermiteDeplasareaEcranului = true;
            this.PermiteMaximizareaEcranului = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(this.lControlIncarcat.MinimumSize.Width, 
                                        this.lControlIncarcat.MinimumSize.Height + this.lblTitluEcran.Height + this.btnValidare.Height + 10);

            this.panelGlobal.Controls.Add(this.lControlIncarcat);
            this.lControlIncarcat.Dock = DockStyle.Fill;

            this.lControlIncarcat.SelectieMultiplaEfectuata += lControlIncarcat_SelectieMultiplaEfectuata;
            this.btnValidare.Click += btnValidare_Click;

            this.ResumeLayout();
        }

        #endregion

        #region Evenimente

        void btnValidare_Click(object sender, EventArgs e)
        {
            try
            {
                this.lControlIncarcat.ValideazaSelectiaMultipla();
            }
            catch (Exception ex)
            {
                Mesaj.Eroare(this, ex.Message);
            }	
        }

        void lControlIncarcat_SelectieMultiplaEfectuata(List<T> pListaElemente)
        {
            this.ListaElementeSelectionate = pListaElemente;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        #endregion

        #region Metode private



        #endregion

        #region Metode publice



        #endregion

    }
}
