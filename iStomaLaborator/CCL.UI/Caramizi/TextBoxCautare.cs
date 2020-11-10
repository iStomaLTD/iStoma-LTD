using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CCL.UI.Caramizi
{
    [DefaultEvent("CerereUpdate")]
    public partial class TextBoxCautare : TextBoxGuma
    {
        private bool lFolosesteIntarziere = true;

        public event System.EventHandler TastaEnterApasata;
        public event System.EventHandler RandulUrmator;
        public event System.EventHandler RandulPrecedent;

        [DefaultValue(true)]
        public bool FolosesteIntarziere { get { return this.lFolosesteIntarziere; } set { this.lFolosesteIntarziere = value; } }

        public TextBoxPersonalizat TextBox { get { return this.txtInformatieUtila; } }

        public TextBoxCautare()
        {
            InitializeComponent();

            this.lblIconitaCautare.Click += LblIconitaCautare_Click;

            aranjeazaControalele();

            this.txtInformatieUtila.GotFocus += TxtInformatieUtila_GotFocus;
            this.txtInformatieUtila.LostFocus += TxtInformatieUtila_LostFocus;
            base.CapitalizeazaPrimaLitera = false;
            base.CapitalizeazaCuvintele = false;
            base.lModCautare = true;
        }

        private void aranjeazaControalele()
        {
            if (this.lblIconitaCautare != null)
            {
                this.lblIconitaCautare.Parent = this;
                this.lblIconitaCautare.Margin = new Padding(0);
                this.lblIconitaCautare.Padding = new Padding(0);
                this.lblIconitaCautare.BackColor = Color.White;
                this.lblIconitaCautare.Width = this.txtInformatieUtila.Height - 2;
                this.lblIconitaCautare.Height = this.txtInformatieUtila.Height - 2;
                this.lblIconitaCautare.Location = new Point(this.Width - (this.lblIconitaCautare.Width + 1), this.txtInformatieUtila.Location.Y + 1);
                this.lblIconitaCautare.BorderStyle = BorderStyle.None;
                this.lblIconitaCautare.BringToFront();
            }
        }

        private void setVizibilitateLabelCautare()
        {
            this.lblIconitaCautare.Visible = !this.txtInformatieUtila.Focused && !this.txtInformatieUtila.AreValoare();
        }

        private void TxtInformatieUtila_LostFocus(object sender, EventArgs e)
        {
            setVizibilitateLabelCautare();

            InvokeLostFocus(this, e);
        }

        private void TxtInformatieUtila_GotFocus(object sender, EventArgs e)
        {
            setVizibilitateLabelCautare();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            aranjeazaControalele();

            base.OnSizeChanged(e);
        }

        private void LblIconitaCautare_Click(object sender, EventArgs e)
        {
            this.txtInformatieUtila.Focus();
        }

        public void AnuleazaValidarea()
        {
            this.txtInformatieUtila.CausesValidation = false;
        }

        protected override void btnGuma_Click(object sender, EventArgs e)
        {
            if (!this.FolosesteIntarziere)
                base.btnGuma_Click(sender, e);
            else
            {
                this.txtInformatieUtila.Goleste();
                this.AllowModification(this.lEcranInModificare);
                gestioneazaModificare();
            }
        }

        private bool EnterApasat()
        {
            if (this.TastaEnterApasata != null)
            {
                TastaEnterApasata(this, null);
                return true;
            }

            return false;
        }

        private bool treciLaRandulUrmator()
        {
            if (this.RandulUrmator != null)
            {
                RandulUrmator(this, null);
                return true;
            }
            return false;
        }

        private bool treciLaRandulPrecedent()
        {
            if (this.RandulPrecedent != null)
            {
                RandulPrecedent(this, null);
                return true;
            }
            return false;
        }

        protected override void txtInformatieUtila_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Down || e.KeyData == Keys.Right || e.KeyData == Keys.Up || e.KeyData == Keys.Left || e.KeyData == Keys.Escape)
            {
                if (e.KeyData == Keys.Enter)
                {
                    if (EnterApasat())
                        return;
                    else
                        base.txtInformatieUtila_KeyUp(sender, e);
                }
                else
                {
                    if (e.KeyData == Keys.Down || e.KeyData == Keys.Right)
                    {
                        if (treciLaRandulUrmator())
                        {
                            e.Handled = true;
                            e.SuppressKeyPress = true;
                            return;
                        }
                        else
                            base.txtInformatieUtila_KeyUp(sender, e);
                    }
                    else
                    {
                        if (e.KeyData == Keys.Up || e.KeyData == Keys.Left)
                        {
                            if (treciLaRandulPrecedent())
                                return;
                            else
                                base.txtInformatieUtila_KeyUp(sender, e);
                        }
                        else
                        {
                            //if (EnterApasat())
                            //    return;
                            //else
                            base.txtInformatieUtila_KeyUp(sender, e);
                        }
                    }
                }
            }

            if (!this.FolosesteIntarziere)
                base.txtInformatieUtila_KeyUp(sender, e);
            else
                gestioneazaModificare();
        }

        protected override void txtInformatieUtila_AfterUpdate(Control sender, string sNumeProprietateAtasata, string sNouaValoare)
        {
            if (!this.FolosesteIntarziere)
                base.txtInformatieUtila_AfterUpdate(sender, sNumeProprietateAtasata, sNouaValoare);
            else
                gestioneazaModificare();
        }

        private void timerDeclansareEvent_Tick(object sender, EventArgs e)
        {
            bool update = cereUpdate();
            this.timerDeclansareEvent.Stop();

            //Altfel pune focus aiurea cand apasam pe tab
            if (update)
            {
                PlaseazaFocusDupaText();
                //this.txtInformatieUtila.Focus();
            }
        }

        private void gestioneazaModificare()
        {
            try
            {
                AllowModification(this.lEcranInModificare);

                this.timerDeclansareEvent.Stop();
                this.timerDeclansareEvent.Start();
            }
            catch (Exception)
            {
                //In caz de exceptie nu facem nimic
            }
        }

        public new void Focus()
        {
            PlaseazaFocusDupaText();
            //this.txtInformatieUtila.Focus();
        }

        public void PlaseazaFocusDupaText()
        {
            int pozitie = this.txtInformatieUtila.Text.Length;
            if (pozitie < 0)
                pozitie = 0;

            if (!this.txtInformatieUtila.Focused)
                this.txtInformatieUtila.Focus();

            this.txtInformatieUtila.SelecteazaLaPozitia(pozitie, 0);
        }

        public void SeteazaCuloareFundal(Color pCuloare)
        {
            this.BackColor = pCuloare;
            this.txtInformatieUtila.BackColor = pCuloare;
        }
    }
}
