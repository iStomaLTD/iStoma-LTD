using BLL.iStomaLab;
using CCL.iStomaLab;
using CCL.UI;
using CDL.iStomaLab;
using iStomaLab.Generale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iStomaLab
{
    public partial class frmSugestieClient : FormPersonalizat
    {

        #region Declaratii generale


        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private frmSugestieClient()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                this.PermiteDeplasareaEcranului = true;
                this.PermiteMaximizareaEcranului = false;
                this.PermiteRedimensionarea = false;
                this.StartPosition = FormStartPosition.CenterScreen;

                this.txtSugestie.CapitalizeazaPrimaLitera = true;

                adaugaHandlere();
                initTextML();
            }
        }

        private void adaugaHandlere()
        {
            this.Load += _Load;
        }

        private void initTextML()
        {
            this.Text = string.Empty;
            this.lblSugestie.Text =BMultiLingv.getElementById(BMultiLingv.EnumDictionar.MasBucuraDacaPuncteDeSuspensie);
            this.lblVaMultumim.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.VaMultumim);
        }

        void _Load(object sender, EventArgs e)
        {
            try
            {
                Initializeaza();
                //AllowModification(true);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();
            //TODO			
            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void ctrlValidareAnulare_Validare(object sender, EventArgs e)
        {
            try
            {
                if (!this.txtSugestie.AreValoare())
                    this.txtSugestie.Focus();
                else
                {
                    int id = IHMUtile._AccesTotal.CereFunctionalitate(1, "Sugestie", CUtil.InlocuiesteDiacriticeHTML(string.Concat(this.txtSugestie.Text,
                        CConstante.LinieNoua, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.VaMultumim), CConstante.LinieNoua, this.lUtilizatorConectat.ToStringPoliticos())), 2);

                    if (id > 0)
                    {
                        Mesaj.Informare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.VaMultumim), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Sugestie));
                        //IHMUtile._AccesTotal.Notifica(CCL.UI.Imagini.GetDenumireAplicatie(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Sugestie), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.VaMultumim), false);
                    }

                    inchideEcranul(System.Windows.Forms.DialogResult.OK);
                }
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        #endregion

        #region Metode private



        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente)
        {
            using (frmSugestieClient ecran = new frmSugestieClient())
            {
                ecran.AplicaPreferinteleUtilizatorului();
                return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
            }
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
        }

        #endregion


    }
}
