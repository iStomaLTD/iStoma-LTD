using System;
using System.ComponentModel;
using System.Windows.Forms;
using CDL.iStomaLab;

namespace CCL.UI.Caramizi
{
    [DefaultEvent("MonedaSchimbata")]
    //public partial class controlLeiEuro : UserControl
    public partial class controlLeiEuro : FlowLayoutPanel
    {

        public event System.EventHandler MonedaSchimbata;

        public bool IsInReadOnlyMode
        {
            get { return !this.rbLei.Enabled; }
            set
            {
                this.rbLei.Enabled = !value;
                this.rbEuro.Enabled = !value;
            }
        }

        public CDefinitiiComune.EnumTipMoneda Moneda
        {
            get
            {
                if (this.rbEuro.Checked)
                    return CDefinitiiComune.EnumTipMoneda.Euro;

                return CDefinitiiComune.EnumTipMoneda.Lei;
            }
            set
            {
                if (!IHMUtile.SuntemInDebug())
                {
                    if (value == CDefinitiiComune.EnumTipMoneda.Euro)
                    {
                        if (CCL.iStomaLab.CUtil.ExistaMonedaAlternativa())
                            this.rbEuro.Checked = true;
                        else
                            this.rbLei.Checked = true;
                    }
                    else
                    {
                        if (CCL.iStomaLab.CUtil.ExistaMonedaNationala())
                            this.rbLei.Checked = true;
                        else
                            this.rbEuro.Checked = true;
                    }
                }
            }
        }

        public controlLeiEuro()
        {
            InitializeComponent();

            if (!IHMUtile.SuntemInDebug())
            {
                if (CCL.iStomaLab.CUtil.ExistaMonedaNationala())
                {
                    this.rbLei.Text = CCL.iStomaLab.CUtil.GetNumeMonedaNationala();
                    this.rbLei.Visible = true;
                }
                else
                    this.rbLei.Visible = false;

                if (CCL.iStomaLab.CUtil.ExistaMonedaAlternativa())
                {
                    this.rbEuro.Text = CCL.iStomaLab.CUtil.GetNumeMonedaAlternativa();
                    this.rbEuro.Visible = true;
                }
                else
                    this.rbEuro.Visible = false;
            }
        }

        public void Initializeaza(CDefinitiiComune.EnumTipMoneda pTipMoneda)
        {
            this.Moneda = pTipMoneda;
        }

        public void Goleste()
        {
            if (this.rbLei.Visible)
                this.rbLei.Checked = true;
        }

        public void AllowModification(bool pInModificare)
        {
            this.rbLei.AllowModification(pInModificare);
            this.rbEuro.AllowModification(pInModificare);
        }

        private void anuntaModificareaMonezii()
        {
            if (this.MonedaSchimbata != null)
                MonedaSchimbata(this, null);
        }

        private void rbLei_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbLei.Checked)
                anuntaModificareaMonezii();
        }

        private void rbEuro_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbEuro.Checked)
                anuntaModificareaMonezii();
        }

        public void SeteazaMonedaImpusa(CDL.iStomaLab.CDefinitiiComune.EnumTipMoneda pTipMoneda)
        {
            if (pTipMoneda == CDefinitiiComune.EnumTipMoneda.Lei)
            {
                this.rbLei.Visible = true;
                this.rbEuro.Visible = false;

                this.rbEuro.Checked = false;
                this.rbLei.Checked = true;
            }
            else
            {
                this.rbEuro.Visible = true;
                this.rbLei.Visible = false;

                this.rbLei.Checked = false;
                this.rbEuro.Checked = true;
            }
        }
    }
}
