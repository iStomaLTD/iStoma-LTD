using BLL.iStomaLab;
using BLL.iStomaLab.Email;
using CCL.iStomaLab;
using CCL.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iStomaLab.Generale
{
    public partial class FormSetariEmail : FormPersonalizat
    {

        #region Declaratii generale

        private BEmail lEmail = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormSetariEmail(BEmail pEmail)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lEmail = pEmail;

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {

                adaugaHandlere();
                initTextML();

                this.CentratCuDeplasare();
            }
        }

        private void adaugaHandlere()
        {
            this.Load += _Load;
            this.ctrlValidareAnulareSetariEmail.Validare += CtrlValidareAnulareSetariEmail_Validare;
        }

        private void initTextML()
        {
            this.Text = string.Empty;
            this.lblAdresaEmail.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.AdresaEmail);
            this.lblUtilizator.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Utilizator);
            this.lblServerSMTP.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ServerSMTP);
            this.lblPortSMTP.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PortSMTP);
            this.lblServerIMAP.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ServerIMAP);
            this.lblPortIMAP.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PortIMAP);
            this.chkSSL.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.SSL);
        }

        void _Load(object sender, EventArgs e)
        {
            try
            {
                Initializeaza();
                AllowModification(true);
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

            if (this.lEmail != null)
            {
                this.txtAdresaMail.Text = this.lEmail.AdresaMail;
                this.txtUtilizator.Text = this.lEmail.User;
                this.txtServerSMTP.Text = this.lEmail.HostSMTP;
                this.txtPortSMTP.Text = this.lEmail.PortSMTP.ToString();
                this.txtServerIMAP.Text = this.lEmail.HostIMAP;
                this.txtPortIMAP.Text = this.lEmail.PortIMAP.ToString();
                this.chkSSL.Checked = this.lEmail.SSL;
            }

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void CtrlValidareAnulareSetariEmail_Validare(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (Salveaza())
                    inchideEcranulOK();
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
            finally
            {
                finalizeazaIncarcarea();
            }

        }

        #endregion

        #region Metode private

        private void seteazaAlerta()
        {
            IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.txtAdresaMail, this.lblAdresaEmail);
            this.txtAdresaMail.Focus();
        }

        bool Salveaza()
        {
            bool esteValid = BEmail.SuntInformatiileNecesareCoerente(this.txtAdresaMail.Text, this.lEmail.ParolaMail, this.txtServerSMTP.Text, CUtil.GetAsInt32(this.txtPortSMTP.Text),
                this.txtServerIMAP.Text, CUtil.GetAsInt32(this.txtPortIMAP.Text));

            if (esteValid)
            {
                this.lEmail.AdresaMail = this.txtAdresaMail.Text;
                this.lEmail.User = this.txtUtilizator.Text;
                this.lEmail.HostSMTP = this.txtServerSMTP.Text;
                this.lEmail.PortSMTP = CUtil.GetAsInt32(this.txtPortSMTP.Text);
                this.lEmail.HostIMAP = this.txtServerIMAP.Text;
                this.lEmail.PortIMAP = CUtil.GetAsInt32(this.txtPortIMAP.Text);
                this.lEmail.SSL = this.chkSSL.Checked;
                this.lEmail.UpdateAll();
            }
            else
            {
                seteazaAlerta();
            }

            return esteValid;
        }

        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente, BEmail pEmail)
        {
            using (FormSetariEmail ecran = new FormSetariEmail(pEmail))
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
