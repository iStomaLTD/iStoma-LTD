using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iStomaLab.Generale;
using iStomaLab.Caramizi;
using BLL.iStomaLab;
using iStomaLab.TablouDeBord.Comunicare;
using MailKit.Net.Imap;
using System;
using BLL.iStomaLab.Email;
using MailKit;
using System.Net;
using static iStomaLab.BLLUtile;
using System.Threading;

namespace iStomaLab.TablouDeBord.Email
{
    public partial class ControlComunicare : UserControlPersonalizat
    {

        #region Declaratii generale

        private BEmail lEmail = null;
        private TablouDeBord.Email.ControlInbox lctrlInbox = null;
        private IMailFolder lFolder = null;

        #endregion

        #region Enumerari si Structuri


        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlComunicare()
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
            this.btnAdaugaEmail.Click += BtnAdaugaEmail_Click;
            this.tvFolderEmail.FolderSelected += TvFolderEmail_FolderSelected;
        }

        private void initTextML()
        {

        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            getEmailuri();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void TvFolderEmail_FolderSelected(object sender, TreeViewFolderEmail.FolderSelectedEventArgs e)
        {
            OpenFolder(e.Folder);
        }

        private void BtnAdaugaEmail_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (FormAdaugaEmail.Afiseaza(this.GetFormParinte(), null))
                {
                    getEmailuri();
                }
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

        private void getEmailuri()
        {
            try
            {
                incepeIncarcarea();

                BColectieEmail lista = BEmail.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

                if(!(lista.Count == flpListaEmailuri.Controls.Count))
                {
                    ImapClient client = new ImapClient();
                    foreach (var clientEmail in lista)
                    {
                        ControlAdresaEmail ctrlAdresaEmail = new ControlAdresaEmail();
                        ctrlAdresaEmail.Tag = clientEmail;
                        this.flpListaEmailuri.Controls.Add(ctrlAdresaEmail);
                        ctrlAdresaEmail.Initializeaza(clientEmail);
                    }

                    initControlGestiuneInbox(lista[0]);
                }
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
        
        private void incarcaOptiuneaSelectata(IEnumerable<IMessageSummary> pSummaries, IMailFolder pMailFolder)
        {
            if (this.lctrlInbox != null)
                this.lctrlInbox.Visible = false;

            initControlGestiuneInbox(pSummaries, pMailFolder);
        }

        public void incarcaOptiuneaSelectata(BEmail pEmail)
        {
            if (this.lctrlInbox != null)
                this.lctrlInbox.Visible = false;

            initControlGestiuneInbox(pEmail);
        }

        private void initControlGestiuneInbox(IEnumerable<IMessageSummary> pSummaries, IMailFolder pMailFolder)
        {
            if (this.lctrlInbox == null)
            {
                this.lctrlInbox = new ControlInbox();
                this.lctrlInbox.Name = "ctrlGestiuneInbox";
                adaugaControlInZonaUtila(this.lctrlInbox);
            }

            this.lctrlInbox.Initializeaza(this.lEmail, pSummaries, pMailFolder);
            this.lctrlInbox.Visible = true;
            this.lctrlInbox.BringToFront();
        }

        private void initControlGestiuneInbox(BEmail pEmail)
        {
            if (this.lctrlInbox == null)
            {
                this.lctrlInbox = new ControlInbox();
                this.lctrlInbox.Name = "ctrlGestiuneInbox";
                adaugaControlInZonaUtila(this.lctrlInbox);
            }

            this.lctrlInbox.Initializeaza(pEmail);
            this.lctrlInbox.Visible = true;
            this.lctrlInbox.BringToFront();
        }

        private void adaugaControlInZonaUtila(Control pControl)
        {
            this.panelEmail.Controls.Add(pControl);
            pControl.Dock = DockStyle.Fill;
        }

        private async void LoadMessages()
        {
            if (lFolder.Count > 0)
            {
                var summaries = await lFolder.FetchAsync(0, -1, MessageSummaryItems.Full | MessageSummaryItems.UniqueId);

                incarcaOptiuneaSelectata(summaries, lFolder);
            }
        }

        #endregion

        #region Metode publice

        internal async void Logheaza(BEmail pEmail, ImapClient pClient)
        {
            var host = pEmail.HostIMAP.Trim();
            string passwd = pEmail.ParolaMail.Trim();
            var user = pEmail.AdresaMail.Trim();
            string protocol;
            string url;

            ICredentials Credentials = new NetworkCredential(user, passwd);

            if (pEmail.SSL)
                protocol = "imaps";
            else
                protocol = "imap";

            if (pEmail.PortIMAP != 0)
                url = string.Format("{0}://{1}:{2}", protocol, host, pEmail.PortIMAP);
            else
                url = string.Format("{0}://{1}", protocol, host);

            Uri Uri = new Uri(url);

            try
            {
                await Reconnect(Uri, Credentials, pClient);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            LoadContent(pClient);

        }

        public void LoadContent(ImapClient pClient)
        {

            tvFolderEmail.LoadFolders(pClient);
        }

        public async void OpenFolder(IMailFolder pFolder)
        {
            if (this.lFolder == pFolder)
                return;

            if (this.lFolder != null)
            {

            }
            this.lFolder = pFolder;

            if (pFolder.IsOpen)
            {
                LoadMessages();
                return;
            }

            await pFolder.OpenAsync(FolderAccess.ReadWrite);
            LoadMessages();
        }

        [STAThread]
        public async Task Reconnect(Uri pUri, ICredentials pCredentials, ImapClient pClient)
        {
            await pClient.ConnectAsync(pUri).ConfigureAwait(false);
            pClient.AuthenticationMechanisms.Remove("XOAUTH2");

            try
            {
                pClient.Authenticate(pCredentials);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Enable less secunde app in gmail");
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
