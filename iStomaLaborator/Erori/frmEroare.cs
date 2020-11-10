using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iStomaLab.Erori
{
    public partial class frmEroare : Generale.FormPersonalizat
    {

        #region Declaratii Generale

        private Exception lExceptie;
        private bool lDetaliiAfisate = false;

        #endregion

        #region Constructori

        public frmEroare()
        {
            InitializeComponent();
        }

        public frmEroare(Exception pxExceptie)
        {
            InitializeComponent();
            this.lExceptie = pxExceptie;
            this.lDetaliiAfisate = false;

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                //this.btnDetalii.Text = BLL.General.BMultiLingvPC.getElementById(BLL.General.BMultiLingv.EnumDictionar.Detalii);
                //AscundeButonDetalii();
                //this.btnInchide.Text = string.Empty;
                //this.btnAnuntaIDava.Text = BLL.General.BMultiLingvPC.getElementById(BLL.General.BMultiLingv.EnumDictionar.SemnaleazaAceastaEroare);
                //this.PermiteDeplasareaEcranului = true;
            }
        }

        private void frmEroare_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    this.txtEroare.Text = this.lExceptie.Message;
            //    this.txtDetalii.Text = IHMUtile.GetTextCompletExceptie(this.lExceptie);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, BLL.General.BMultiLingvPC.getElementById(BLL.General.BMultiLingv.EnumDictionar.eroare), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        #endregion

        private void btnDetalii_Click(object sender, EventArgs e)
        {
            if (this.lDetaliiAfisate)
            {
                this.Size = new Size(502, 238);
            }
            else
            {
                this.Size = new Size(502, 424);
            }

            this.lDetaliiAfisate = !this.lDetaliiAfisate;
        }

        private void btnAnuntaIDava_Click(object sender, EventArgs e)
        {
            bool ok = true;
            try
            {
                //ok = IHMUtile._AccesTotal.SemnaleazaEroarea(string.Concat(this.txtEroare.Text, CDL.General.CConstante.LinieNouaHTML, "==================================", CDL.General.CConstante.LinieNouaHTML, this.txtDetalii.Text));
            }
            catch (Exception)
            {
            }
            finally
            {
                if (ok)
                {
                    this.TopMost = false;

                    //Inchidem ecranul dupa ce am semnalat eroarea
                    inchideEcranul();
                }
            }
        }

        #region Metode

        internal void AscundeButonDetalii()
        {
            //this.btnDetalii.Visible = false;
        }

        #endregion

        #region Evenimente

        #endregion

    }
}
