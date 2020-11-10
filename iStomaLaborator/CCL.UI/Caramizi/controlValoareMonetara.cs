using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CCL.UI.Caramizi
{
    [DefaultEvent("KeyUpPersonalizat")]
    public partial class controlValoareMonetara : UserControl
    {
        public CDL.iStomaLab.CDefinitiiComune.EnumTipMoneda Moneda { get { return this.ctrlLeiEUR.Moneda; } }
        public event System.EventHandler KeyUpPersonalizat;
        public event System.EventHandler CerereUpdate;
        public event EventHandler MonedaSchimbata;

        public Tuple<double, CDL.iStomaLab.CDefinitiiComune.EnumTipMoneda> ValoareTuple
        {
            get
            {
                return new Tuple<double, CDL.iStomaLab.CDefinitiiComune.EnumTipMoneda>(this.Valoare, this.Moneda);
            }
        }

        public double Valoare
        {
            get { return this.txtValoare.ValoareDouble; }
            set { this.txtValoare.ValoareDouble = value; }
        }

        public bool IsInReadOnlyMode
        {
            get { return this.txtValoare.IsInReadOnlyMode; }
            set
            {
                this.txtValoare.IsInReadOnlyMode = value;
                this.ctrlLeiEUR.IsInReadOnlyMode = value;
            }
        }

        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                this.txtValoare.BackColor = value;
                this.ctrlLeiEUR.BackColor = value;
                base.BackColor = value;
            }
        }

        public controlValoareMonetara()
        {
            InitializeComponent();
            //this.txtValoare.TextAlign = HorizontalAlignment.Right;
        }

        public void Initializeaza(Tuple<double, CDL.iStomaLab.CDefinitiiComune.EnumTipMoneda> pValoare)
        {
            if (pValoare == null)
            {
                this.Goleste();
            }
            else
                Initializeaza(pValoare.Item1, pValoare.Item2);
        }

        public void Initializeaza(double pValoare, CDL.iStomaLab.CDefinitiiComune.EnumTipMoneda pTipMoneda)
        {
            this.txtValoare.ValoareDouble = pValoare;
            this.ctrlLeiEUR.Moneda = pTipMoneda;
        }

        public void SeteazaMonedaImpusa(CDL.iStomaLab.CDefinitiiComune.EnumTipMoneda pTipMoneda)
        {
            this.ctrlLeiEUR.SeteazaMonedaImpusa(pTipMoneda);
        }

        public void Goleste()
        {
            this.txtValoare.Goleste();
            this.ctrlLeiEUR.Goleste();
        }

        public void AllowModification(bool pPermiteModificarea)
        {
            this.txtValoare.AllowModification(pPermiteModificarea);
            this.ctrlLeiEUR.AllowModification(pPermiteModificarea);
        }

        private void txtValoare_KeyUpPersonalizat(object sender, KeyEventArgs e)
        {
            try
            {
                if (this.KeyUpPersonalizat != null)
                    KeyUpPersonalizat(this, e);
            }
            catch (Exception ex)
            {
                Mesaj.Eroare(IHMUtile.GetFormParinte(this), ex.Message);
            }
        }

        private void ctrlLeiEUR_MonedaSchimbata(object sender, EventArgs e)
        {
            try
            {
                if (this.MonedaSchimbata != null)
                    MonedaSchimbata(this, e);
            }
            catch (Exception ex)
            {
                Mesaj.Eroare(IHMUtile.GetFormParinte(this), ex.Message);
            }
        }

        private void txtValoare_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            try
            {
                if (this.CerereUpdate != null)
                    CerereUpdate(this, null);
            }
            catch (Exception ex)
            {
                Mesaj.Eroare(IHMUtile.GetFormParinte(this), ex.Message);
            }
        }

        public void SeFolosesteButonulGuma(bool pSeFoloseste)
        {
            this.txtValoare.UtilizeazaButonGuma = pSeFoloseste;
        }
    }
}
