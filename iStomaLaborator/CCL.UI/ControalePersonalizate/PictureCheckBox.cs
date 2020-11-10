using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CCL.UI.ControalePersonalizate
{
    [DefaultEvent("CheckedChanged")]
    public class PictureCheckBox : PictureBox
    {
        public event System.EventHandler CheckedChanged;

        private Image lImagineSelectat = null;
        private Image lImagineDeselectat = null;
        private bool lBifat = false;
        private bool lEcranInModificare = true;

        public bool Checked
        {
            get { return this.lBifat; }
        }

        public PictureCheckBox()
        {
            this.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        public void SetImagini(Image pImagineSelectat, Image pImagineDeselectat)
        {
            this.lImagineSelectat = pImagineSelectat;
            this.lImagineDeselectat = pImagineDeselectat;
        }

        public void Initializeaza(bool pBifat)
        {
            this.lBifat = pBifat;

            if (this.lBifat)
                this.Image = this.lImagineSelectat;
            else
                this.Image = this.lImagineDeselectat;

            this.Refresh();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            //Doar in modificare permitem schimbarea
            if (this.lEcranInModificare)
            {
                Initializeaza(!this.lBifat);

                anuntaSchimbareaStarii();
            }
        }

        private void anuntaSchimbareaStarii()
        {
            if (this.CheckedChanged != null)
                CheckedChanged(this, null);
        }

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
        }
    }
}
