using System;
using System.ComponentModel;
using System.Drawing;

namespace CCL.UI
{
    public class TextBoxCuEticheta : TextBoxPersonalizat
    {
        private string lEticheta = string.Empty;

        public TextBoxCuEticheta():base()
        {
        }

        public TextBoxCuEticheta(IContainer container)
            : base(container)
        {
        }

        public void SetEticheta(string pEticheta)
        {
            this.lEticheta = pEticheta;

            this.Text = this.lEticheta;
            this.ForeColor = Color.Gray;
        }

        public void SetText(string pText)
        {
            if (string.IsNullOrEmpty(pText))
            {
                this.Text = this.lEticheta;
                this.ForeColor = Color.Gray;
            }
            else
            {
                this.Text = pText;
                this.ForeColor = Color.Black;
            }
        }

        public new bool AreValoare()
        {
            if (this.Text.Equals(this.lEticheta))
                return false;

            return base.AreValoare();
        }

        public string GetText()
        {
            if (this.Text.Equals(this.lEticheta))
                return string.Empty;

            return this.Text;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            if (this.Text.Equals(this.lEticheta))
                this.Goleste();

            this.ForeColor = Color.Black;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if (string.IsNullOrEmpty(this.Text))
            {
                this.Text = this.lEticheta;
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            if (this.Text.Equals(this.lEticheta))
            {
                this.ForeColor = Color.Gray;
            }
            else
            {
                this.ForeColor = Color.Black;
            }
        }

    }
}
