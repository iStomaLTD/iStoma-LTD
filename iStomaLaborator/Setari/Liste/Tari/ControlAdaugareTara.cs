using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iStomaLab.Generale;
using BLL.iStomaLab;
using BLL.iStomaLab.Referinta;
using CCL.UI;

namespace iStomaLab.Setari.Liste.Tari
{
    public partial class ControlAdaugareTara : UserControlPersonalizat
    {

        #region Declaratii generale

        BTari lTara = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlAdaugareTara()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {

                adaugaHandlere();
                initTextML();
            }
        }

        private void adaugaHandlere()
        {

        }

        private void initTextML()
        {
            this.lblDenumireTara.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tara);
            this.lblNumeOficialTara.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NumeOficial);
            this.lblAbreviereTara.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Abreviere);
            this.lblPrefixTelefonicTara.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PrefixTelefonic);
            this.lblCetatenieTara.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Cetatenie);
            this.lblLimbaTara.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Limba);
        }

        public void Initializeaza(BTari pTara)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.lTara = pTara;

            if (this.lTara == null)
            {
                this.txtDenumireTara.Goleste();
                this.txtNumeOficialTara.Goleste();
                this.txtPrefixTelefonicTara.Goleste();
                this.txtAbreviereTara.Goleste();
                this.txtCetatenieTara.Goleste();
                //this.cboLimbaTara.DataSource=;
            }else
            {
                this.txtDenumireTara.Text = this.lTara.NumeScurt;
                this.txtNumeOficialTara.Text = this.lTara.NumeOficial;
                this.txtPrefixTelefonicTara.Text = this.lTara.PrefixTelefonic;
                this.txtAbreviereTara.Text = this.lTara.Abreviere;
                this.txtCetatenieTara.Text = this.lTara.Cetatenie;
                //this.cboLimbaTara.Text = this.lTara.LimbaDenumirii;
            }

            
            	
            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente



        #endregion

        #region Metode private



        #endregion

        #region Metode publice

        internal bool Salveaza()
        {
            if (this.lTara == null)
            {
                if (BTari.SuntInformatiileNecesareCoerente(this.txtDenumireTara.Text, 1))
                {
                    BTari.Add(this.txtDenumireTara.Text, this.txtNumeOficialTara.Text, this.txtPrefixTelefonicTara.Text, this.txtAbreviereTara.Text, this.txtCetatenieTara.Text, 1, 1, null);
                }else
                {
                    IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());
                    this.txtDenumireTara.Focus();
                    this.lblDenumireTara.ForeColor = Color.Red;
                }

            }else
            {
                this.lTara.NumeScurt = this.txtDenumireTara.Text;
                this.lTara.NumeOficial = this.txtNumeOficialTara.Text;
                this.lTara.PrefixTelefonic = this.txtPrefixTelefonicTara.Text;
                this.lTara.Abreviere = this.txtAbreviereTara.Text;
                this.lTara.Cetatenie = this.txtCetatenieTara.Text;

                if (BTari.SuntInformatiileNecesareCoerente(this.txtDenumireTara.Text, 1))
                {
                    this.lTara.UpdateAll();
                }else
                {
                    IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());
                    this.txtDenumireTara.Focus();
                    this.lblDenumireTara.ForeColor = Color.Red;
                }

            }

            return BTari.SuntInformatiileNecesareCoerente(this.txtDenumireTara.Text, 1);
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
            this.txtDenumireTara.AllowModification(this.lEcranInModificare);
            this.txtNumeOficialTara.AllowModification(this.lEcranInModificare);
            this.txtPrefixTelefonicTara.AllowModification(this.lEcranInModificare);
            this.txtAbreviereTara.AllowModification(this.lEcranInModificare);
            this.txtCetatenieTara.AllowModification(this.lEcranInModificare);
            this.cboLimbaTara.AllowModification(this.lEcranInModificare);
        }

        #endregion


    }
}
