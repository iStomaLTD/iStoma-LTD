using System.ComponentModel;
using System.Windows.Forms;

namespace CCL.UI.Caramizi
{
    public class UserControlComun : UserControl
    {

        #region Declaratii generale

        private System.ComponentModel.IContainer components = null; // Required designer variable

        protected bool lEcranInModificare = true;
        protected bool lSeIncarca = false;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati

        //public System.Drawing.SizeF AutoScaleDimensions { get; set; }
        //public System.Windows.Forms.AutoScaleMode AutoScaleMode { get; set; }

        #endregion

        #region Constructor si Initializare

        public UserControlComun()
        {
            InitializeComponent();
        }

        public UserControlComun(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            //this.Font = CDL.iStomaLab.CDefinitiiComune._Font_DPI;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.SuspendLayout();

            //this.Font = CDL.iStomaLab.CDefinitiiComune._Font_DPI;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region Evenimente
        #endregion

        #region Metode private

        protected void InitializeazaVariabileleGenerale()
        {

        }

        protected void incepeIncarcarea()
        {
            this.lSeIncarca = true;
        }

        protected void finalizeazaIncarcarea()
        {
            this.lSeIncarca = false;
        }

        #endregion

        #region Metode publice
        #endregion

    }
}
