using System;
using System.Windows.Forms;

namespace ActualizareAplicatie
{
    public partial class frmDetaliiBDD : Form
    {
        private int lTipAplicatie = 0;

        private void initTipAplicatie()
        {
            try
            {
                this.lTipAplicatie = CUtile.GetTipAplicatieDinRegistri();
            }
            catch (Exception)
            {
                this.lTipAplicatie = 0;
            }
        }

        public frmDetaliiBDD()
        {
            InitializeComponent();

            this.Text = BMultiLingv.GetById(BMultiLingv.EnumDictionar.conexiuneLaBazaDeDate, 0);
            this.lblBDD.Text = BMultiLingv.GetById(BMultiLingv.EnumDictionar.bazaDeDate, 0);
            this.lblInstantaSQL.Text = BMultiLingv.GetById(BMultiLingv.EnumDictionar.numeInstantaSQL, 0);
            this.lblParolaSQL.Text = BMultiLingv.GetById(BMultiLingv.EnumDictionar.parola, 0);
            this.lblServerManual.Text = BMultiLingv.GetById(BMultiLingv.EnumDictionar.server, 0);
            this.lblUserSQL.Text = BMultiLingv.GetById(BMultiLingv.EnumDictionar.userSQL, 0);
            this.btnSalveazaConexiune.Text = BMultiLingv.GetById(BMultiLingv.EnumDictionar.salveaza, 0);

            this.txtServerManual.Text = "localhost";
            this.txtNumeInstantaSQL.Text = "SQLExpress";
            this.txtNumeBDD.Text = "iStomaLTD";

            this.txtUserSQL.Text = "sa";
            this.txtParolaSQL.Text = "123456";
        }

        private void btnSalveazaConexiune_Click(object sender, EventArgs e)
        {
            if (CUtile.ConexiuneBDDValida(this.txtServerManual.Text.Trim(), this.txtNumeInstantaSQL.Text.Trim(),
                this.txtUserSQL.Text.Trim(), this.txtParolaSQL.Text.Trim()))
            {
                CUtile.seteazaConexiuneBDD(this.txtServerManual.Text.Trim(), this.txtNumeInstantaSQL.Text.Trim(),
                    this.txtUserSQL.Text.Trim(), this.txtParolaSQL.Text.Trim(), this.txtNumeBDD.Text.Trim());
                this.Close();
            }
            else
            {
                MessageBox.Show(BMultiLingv.GetById(BMultiLingv.EnumDictionar.informatiileIntroduseNuSuntCorecte, 0), BMultiLingv.GetById(BMultiLingv.EnumDictionar.conexiuneLaBazaDeDate, 0), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
