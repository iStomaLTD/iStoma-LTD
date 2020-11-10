using System;
using System.Windows.Forms;

namespace CCL.UI
{
    public partial class frmCalculator : FormulareComune.frmCuHeader
    {
        private double lRezultat = 0;
        private EnumTipOperatie lTipOperatieRestanta = EnumTipOperatie.Niciuna;
        private bool lNumarNou = true;

        public string Rezultat { get; private set; }

        private enum EnumTipOperatie
        {
            Niciuna = 0,
            Adunare = 1,
            Scadere = 2,
            Inmultire = 3,
            Impartire = 4
        }

        public frmCalculator(string sText)
        {
            InitializeComponent();

            this.Text = IHMUtile.getText(1248); // "Calculator";

            if (!string.IsNullOrEmpty(sText))
                double.TryParse(sText, out lRezultat);

            DeschidereMouseStangaJosCuDeplasare();
        }

        private void frmCalculator_Load(object sender, EventArgs e)
        {
            this.txtRezultat.Text = Convert.ToString(lRezultat);
        }

        private void btnValidare_Click(object sender, EventArgs e)
        {
            this.Rezultat = txtRezultat.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCifra_Click(object sender, EventArgs e)
        {
            if (((Control)sender).Text.Equals("."))
            {
                if (lNumarNou)
                {
                    this.txtRezultat.Text = "0.";
                    lNumarNou = false;
                }
                else
                    this.txtRezultat.Text += ".";
            }
            else
            {
                if (!lNumarNou)
                {
                    string TextPartial = this.txtRezultat.Text + ((Control)sender).Text;
                    double NumarPartial = 0;
                    double.TryParse(TextPartial.Replace(".", ","), out NumarPartial);
                    this.txtRezultat.Text = Convert.ToString(NumarPartial);
                }
                else
                {
                    this.txtRezultat.Text = ((Control)sender).Text;
                    lNumarNou = false;
                }
            }
        }

        private void btnCalculeaza_Click(object sender, EventArgs e)
        {
            double NumarPartial = 0;
            double.TryParse(this.txtRezultat.Text.Replace(".", ","), out NumarPartial);

            switch (this.lTipOperatieRestanta)
            {
                case EnumTipOperatie.Niciuna:
                    double.TryParse(this.txtRezultat.Text.Replace(".", ","), out this.lRezultat);
                    this.lNumarNou = true;
                    break;
                case EnumTipOperatie.Adunare:
                    this.lRezultat += NumarPartial;
                    this.lNumarNou = true;
                    break;
                case EnumTipOperatie.Scadere:
                    this.lRezultat -= NumarPartial;
                    this.lNumarNou = true;
                    break;
                case EnumTipOperatie.Inmultire:
                    this.lRezultat *= NumarPartial;
                    this.lNumarNou = true;
                    break;
                case EnumTipOperatie.Impartire:
                    this.lRezultat /= NumarPartial;
                    this.lNumarNou = true;
                    break;
                default:
                    break;
            }

            string Operatie = ((Control)sender).Text;
            if (Operatie.Equals("+"))
                lTipOperatieRestanta = EnumTipOperatie.Adunare;
            else
            {
                if (Operatie.Equals("-"))
                    lTipOperatieRestanta = EnumTipOperatie.Scadere;
                else
                    if (Operatie.Equals("*"))
                        lTipOperatieRestanta = EnumTipOperatie.Inmultire;
                    else
                        if (Operatie.Equals("/"))
                            lTipOperatieRestanta = EnumTipOperatie.Impartire;
                        else
                            if (Operatie.Equals("="))
                                lTipOperatieRestanta = EnumTipOperatie.Niciuna;
            }
            this.txtRezultat.Text = Convert.ToString(lRezultat);
        }

        private void txtRezultat_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            if (pNouaValoare != null)
                double.TryParse(Convert.ToString(pNouaValoare), out lRezultat);
            else
                lRezultat = 0;

            this.txtRezultat.Text = Convert.ToString(lRezultat);
        }

        private void btnGuma_Click(object sender, EventArgs e)
        {
            this.txtRezultat.Text = "0";
        }

        private void btnSterge_Click(object sender, EventArgs e)
        {
            if (this.txtRezultat.Text.Length > 1)
                this.txtRezultat.Text = this.txtRezultat.Text.Substring(0,this.txtRezultat.Text.Length - 1);
            else
                this.txtRezultat.Text = "0";
        }
    }
}
