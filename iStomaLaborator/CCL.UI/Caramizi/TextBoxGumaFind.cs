using System;
using System.ComponentModel;
using System.Drawing;
using ILL.iStomaLab;
using ILL.BLL.General;

namespace CCL.UI.Caramizi
{
    [DefaultEvent("CautaText")]
    public partial class TextBoxGumaFind : TextBoxGuma, IAllowModification
    {
        public event CEvenimente.EventDeschideEcranCautare CautaText;

        public TextBoxGumaFind()
        {
            InitializeComponent();
        }

        public void Initializeaza(IAfisaj pIdentitate)
        {
            this.Text = pIdentitate.DenumireAfisaj;
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (this.CautaText != null)
                CautaText(this, this.Text);
        }

        public override void AllowModification(bool pbInModificationMode)
        {
            this.lEcranInModificare = pbInModificationMode;

            this.btnFind.Visible = this.lEcranInModificare;
            this.txtInformatieUtila.AllowModification(this.lEcranInModificare);

            if (!this.lEcranInModificare)
            {
                //ascundem butonul de cautare si butonul guma atunci cand suntem in lectura
                this.btnGuma.Visible = false;
                //zona de text va ocupa spatiul ramas
                this.txtInformatieUtila.Location = new Point(0, 0);
                this.txtInformatieUtila.Width = this.Width;
            }
            else
            {
                //in modificare butonul de cautare este vizibil intotdeauna iar cel guma doar daca avem un text in zona utila
                this.txtInformatieUtila.Location = new Point(this.btnGuma.Width + 2, 0);
                bool avemText = this.AreValoare();
                int latimeText = this.Width - (this.btnFind.Width + 2);
                this.btnGuma.Visible = avemText;
                if (avemText)
                    latimeText -= (this.btnGuma.Width + 2);
                this.txtInformatieUtila.Width = latimeText;
            }
        }

    }
}
