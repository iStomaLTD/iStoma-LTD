using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CCL.UI.Caramizi
{
    [DefaultEvent("Validare")]
    public partial class controlValidareAnulare : UserControl
    {

        #region Declaratii generale

        private bool lEcranInModificare = true;
        public event System.EventHandler Validare;
        public event System.EventHandler Anulare;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati

        public Button ButonValidare { get { return this.btnValidare; } }
        public Button ButonAnulare { get { return this.btnAnulare; } }

        #endregion

        #region Constructor si Initializare

        public controlValidareAnulare()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
        }

        #endregion

        #region Evenimente

        protected override void OnParentChanged(EventArgs e)
        {
            if (this.Parent != null)
                this.BackColor = this.Parent.BackColor;
            base.OnParentChanged(e);
        }

        private void btnValidare_Click(object sender, EventArgs e)
        {
            cereValidare();
        }

        private void btnAnulare_Click(object sender, EventArgs e)
        {
            cereAnulare();
        }

        #endregion

        #region Metode private

        private void cereValidare()
        {
            if (Validare != null)
                Validare(this, null);
            else
                IHMUtile.InchideFormularParinte(this, DialogResult.OK);
        }

        private void cereAnulare()
        {
            if (Anulare != null)
                Anulare(this, null);
            else
                IHMUtile.InchideFormularParinte(this);
        }

        #endregion

        #region Metode publice



        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
            this.btnValidare.Visible = this.lEcranInModificare;

            if (this.lEcranInModificare)
            {
                this.btnValidare.Location = new Point(0, 0);
                this.btnAnulare.Location = new Point(this.btnValidare.Width + 10, 0);
            }
            else
            {
                this.btnAnulare.Location = new Point((this.Width - this.btnAnulare.Width) / 2, 0);
            }
        }

        #endregion

    }
}
