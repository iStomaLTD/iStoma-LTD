using BLL.iStomaLab.Email;
using iStomaLab.TablouDeBord.Email;
using MailKit;
using MailKit.Net.Imap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iStomaLab.Generale
{
    public partial class FormExtrageEmailuri : FormPersonalizat
    {

        #region Declaratii generale



        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormExtrageEmailuri()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

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
        }

        private void initTextML()
        {
            this.Text = string.Empty;
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

            this.pbIncarcaEmailuri.Visible = false;

            salveazaEmailuri();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente



        #endregion

        #region Metode private

        private void salveazaEmailuri()
        {
            BColectieEmail lista = BEmail.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);
            BEmail email = lista.GetById(lista[0].Id);
            ImapClient client = new ImapClient();
            Logheaza(email, client);
        }

        internal async void Logheaza(BEmail pEmail, ImapClient pClient)
        {
            var host = pEmail.HostIMAP.Trim();
            string passwd = CCL.iStomaLab.Utile.CSecuritate.Decrypt(pEmail.ParolaMail);
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

            incarcaMailuri(pEmail, pClient);
        }

        private void incarcaMailuri(BEmail pEmail, ImapClient pClient)
        {
            pClient.GetFolder(SpecialFolder.Sent).Open(FolderAccess.ReadWrite);
            IEnumerable<IMessageSummary> sent = pClient.GetFolder(SpecialFolder.Sent).Fetch(0, -1, MessageSummaryItems.Full | MessageSummaryItems.UniqueId).ToList();

            pClient.GetFolder(SpecialFolder.Drafts).Open(FolderAccess.ReadWrite);
            IEnumerable<IMessageSummary> drafts = pClient.GetFolder(SpecialFolder.Drafts).Fetch(0, -1, MessageSummaryItems.Full | MessageSummaryItems.UniqueId).ToList();

            pClient.GetFolder(SpecialFolder.Trash).Open(FolderAccess.ReadWrite);
            IEnumerable<IMessageSummary> trash = pClient.GetFolder(SpecialFolder.Trash).Fetch(0, -1, MessageSummaryItems.Full | MessageSummaryItems.UniqueId).ToList();

            pClient.GetFolder(SpecialFolder.Flagged).Open(FolderAccess.ReadWrite);
            IEnumerable<IMessageSummary> flagged = pClient.GetFolder(SpecialFolder.Flagged).Fetch(0, -1, MessageSummaryItems.Full | MessageSummaryItems.UniqueId).ToList();

            pClient.GetFolder(SpecialFolder.Junk).Open(FolderAccess.ReadWrite);
            IEnumerable<IMessageSummary> junk = pClient.GetFolder(SpecialFolder.Junk).Fetch(0, -1, MessageSummaryItems.Full | MessageSummaryItems.UniqueId).ToList();

            pClient.GetFolder(SpecialFolder.All).Open(FolderAccess.ReadWrite);
            IEnumerable<IMessageSummary> all = pClient.GetFolder(SpecialFolder.All).Fetch(0, -1, MessageSummaryItems.Full | MessageSummaryItems.UniqueId).ToList();

            int nrEmailuriDeExtras = sent.ToList().Count + drafts.ToList().Count + trash.ToList().Count + flagged.ToList().Count + junk.ToList().Count + all.ToList().Count;

            pbIncarcaEmailuri.Minimum = 1;
            pbIncarcaEmailuri.Maximum = nrEmailuriDeExtras;
            pbIncarcaEmailuri.Value = 1;
            pbIncarcaEmailuri.Step = 1;

            if (sent != null && drafts != null && trash != null && flagged != null && junk != null && all != null)
            {
                this.pbIncarcaEmailuri.Visible = true;

                //List<IEnumerable<IMessageSummary>> listaAll = new List<IEnumerable<IMessageSummary>>();
                //listaAll.Add(sent);
                //listaAll.Add(drafts);
                //listaAll.Add(trash);
                //listaAll.Add(flagged);
                //listaAll.Add(junk);

                getMesageDinCategorii(pEmail, sent, MessageFlags.Answered);
                getMesageDinCategorii(pEmail, drafts, MessageFlags.Draft);
                getMesageDinCategorii(pEmail, trash, MessageFlags.None);
                getMesageDinCategorii(pEmail, flagged, MessageFlags.Flagged);
                getMesageDinCategorii(pEmail, junk, MessageFlags.UserDefined);
                getMesageDinAll(pEmail, all);
            }
            
            inchideEcranulOK();

        }

        private void getMesageDinCategorii(BEmail pEmail, IEnumerable<IMessageSummary> pTipFolder, MessageFlags pFlag)
        {
            foreach (var mail in pTipFolder)
            {
                int nrAtasamente = 0;
                foreach (var attach in mail.BodyParts)
                {
                    if (!string.IsNullOrEmpty(attach.FileName) && string.IsNullOrEmpty(attach.ContentId))
                    {
                        nrAtasamente++;
                    }
                }
                BEmailuriExtrase.Add(pEmail.Id, getIndiceFlag(pFlag), nrAtasamente, getData(mail.Date), mail.Envelope.Subject, mail.Envelope.From.ToString(), mail.Envelope.To.ToString(), (int)mail.UniqueId.Id, string.Empty, null);
                this.pbIncarcaEmailuri.PerformStep();
                nrAtasamente = 0;
            }
        }

        private void getMesageDinAll(BEmail pEmail, IEnumerable<IMessageSummary> pTipFolder)
        {
            
            List<DateTime> lista = BEmailuriExtrase.GetListUniqueId(pEmail.Id, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

            foreach (var mail in pTipFolder)
            {
                int nrAtasamente = 0;
                foreach (var attach in mail.BodyParts)
                {
                    if (!string.IsNullOrEmpty(attach.FileName) && string.IsNullOrEmpty(attach.ContentId))
                    {
                        nrAtasamente++;
                    }
                }
                if (!lista.Contains(getData(mail.Date)))
                {
                    BEmailuriExtrase.Add(pEmail.Id, getIndiceFlag(mail.Flags), nrAtasamente, getData(mail.Date), mail.Envelope.Subject, mail.Envelope.From.ToString(), mail.Envelope.To.ToString(), (int)mail.UniqueId.Id, string.Empty, null);
                    this.pbIncarcaEmailuri.PerformStep();
                    nrAtasamente = 0;
                }
            }
        }

        public DateTime getData(DateTimeOffset date)
        {
            return date.UtcDateTime;
        }

        private int getIndiceFlag(MessageFlags? pFlag)
        {
            switch (pFlag)
            {
                case MessageFlags.None:
                    return 1;
                case MessageFlags.Answered:
                    return 2;
                case MessageFlags.Deleted:
                    return 3;
                case MessageFlags.Draft:
                    return 4;
                case MessageFlags.Flagged:
                    return 5;
                case MessageFlags.Recent:
                    return 6;
                case MessageFlags.Seen:
                    return 7;
                case MessageFlags.UserDefined:
                    return 8;
            }
            return 0;
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

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente)
        {
            using (FormExtrageEmailuri ecran = new FormExtrageEmailuri())
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
