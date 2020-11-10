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
using System.Threading;
using CCL.UI;
using System.Net;
using MailKit.Net.Imap;
using MailKit;
using BLL.iStomaLab;
using BLL.iStomaLab.Email;
using CCL.iStomaLab;

namespace iStomaLab.TablouDeBord.Email
{
    public partial class ControlAdaugaEmail : UserControlPersonalizat
    {

        #region Declaratii generale

        private BEmail lEmail = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlAdaugaEmail()
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
            this.lblEmail.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Email);
            this.lblParola.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Parola);
            this.lblInfoEmail.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.InfoIntroducereEmail);
        }

        public void Initializeaza(BEmail pEmail)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.lEmail = pEmail;

            if (this.lEmail == null)
            {
                this.txtEmail.Goleste();
                this.txtParola.Goleste();
                this.txtUser.Goleste();
            }
            else
            {
                this.txtEmail.Text = lEmail.AdresaMail;
                this.txtParola.Text = lEmail.ParolaMail;
                this.txtUser.Text = lEmail.User;
            }

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente



        #endregion

        #region Metode private

        private void seteazaAlerta()
        {
            IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.txtEmail, this.lblEmail);
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.txtParola, this.lblParola);
            seteazaFocus();
        }

        private string getSMTP()
        {
            if (!string.IsNullOrEmpty(this.txtEmail.Text))
                return BMultiLingv.getElementById(BMultiLingv.EnumDictionar.SMTPPunct) + this.txtEmail.Text.Split('@').Last();
            return string.Empty;
        }

        private int getSMTPPort()
        {
            return 587;
        }

        private string getIMAP()
        {
            if (!string.IsNullOrEmpty(this.txtEmail.Text))
                return BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ImapPunct) + this.txtEmail.Text.Split('@').Last();
            return string.Empty;
        }

        private int getIMAPPort()
        {
            if (!this.txtEmail.Text.Split('@').Last().Equals("gmail.com"))
                return 143;
            return 993;
        }

        private bool getSSL()
        {
            if (!this.txtEmail.Text.Split('@').Last().Equals("gmail.com"))
                return false;
            return true;
        }

        private void seteazaFocus()
        {
            TextBoxBase[] lstAlta = { this.txtEmail, this.txtParola };

            foreach (var control in lstAlta)
            {
                if (string.IsNullOrEmpty(control.Text))
                {
                    control.Focus();
                    break;
                }
            }

        }

        #endregion

        #region Metode publice

        internal bool Salveaza()
        {
            bool esteValid = BEmail.SuntInformatiileNecesareCoerente(this.txtEmail.Text, this.txtParola.Text, getSMTP(), getSMTPPort(), getIMAP(), getIMAPPort());

            if (this.lEmail == null)
            {
                if (esteValid)
                    BEmail.Add(this.txtEmail.Text, this.txtParola.Text, getSMTP(), getSMTPPort(), getIMAP(), getIMAPPort(), 2000, getSSL(), this.txtUser.Text, 1, CCL.iStomaLab.Utile.CGestiuneIO.getComputerName(), null);
                else
                    seteazaAlerta();
            }
            else
            {
                this.lEmail.AdresaMail = this.txtEmail.Text;
                this.lEmail.ParolaMail = this.txtParola.Text;
                this.lEmail.HostSMTP = getSMTP();
                this.lEmail.PortSMTP = getSMTPPort();
                this.lEmail.HostIMAP = getIMAP();
                this.lEmail.PortIMAP = getIMAPPort();
                this.lEmail.SSL = getSSL();
                this.lEmail.User = this.txtUser.Text;
                this.lEmail.IdCalculator = CCL.iStomaLab.Utile.CGestiuneIO.getComputerName();
                if (esteValid)
                    this.lEmail.UpdateAll();
                else
                    seteazaAlerta();
            }
            return esteValid;
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
