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
using MimeKit;
using MailKit.Net.Smtp;
using BLL.iStomaLab.Email;
using System.IO;
using System.Runtime.InteropServices;
using System.Resources;

namespace iStomaLab.TablouDeBord.Comunicare
{
    public partial class ControlScrieEmail : UserControlPersonalizat
    {

        #region Declaratii generale

        private BEmail lEmail = null;
        private MimeMessage lMessage = new MimeMessage();
        private List<string> lAtasamente = new List<string>();
        private ImageList imgAtasamanete = new ImageList();
        private List<Tuple<string, Image>> lstAtasamente = null;
        private BodyBuilder pBuilder = new BodyBuilder();

        private BLLUtile.StructMailKitInbox lMailInbox = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlScrieEmail()
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
            this.mnuScrieEmailTrimite.Click += MnuScrieEmailTrimite_Click;
            this.mnuScrieEmailAttach.Click += MnuScrieEmailAttach_Click;
            this.mnuScrieEmailSave.Click += MnuScrieEmailSave_Click;
            this.lblFrom.DeschideEcranCautare += LblFrom_DeschideEcranCautare;
            this.dgvListaAtasamente.SelectionChanged += DgvListaAtasamente_SelectionChanged;
        }
        
        private void initTextML()
        {

        }

        public void Initializeaza(BLLUtile.StructMailKitInbox pMailInbox)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.lMailInbox = pMailInbox;

            if(this.lMailInbox == null)
            {
                this.lblFrom.Goleste();
                this.txtScrieEmailTo.Goleste();
                this.txtScrieEmailSubiect.Goleste();
                this.ctrlScrieEmail.Goleste();
            }
            else
            {
                this.lblFrom.Text = this.lMailInbox.To;
                this.txtScrieEmailSubiect.Text ="Re: "+ this.lMailInbox.Subiect;
                this.txtScrieEmailTo.Text = this.lMailInbox.From.ToString();
                this.ctrlScrieEmail.Focus();
            }
            
            this.ctrlScrieEmail.Initializeaza();
            this.ctrlScrieEmail.AllowModification(true);
            this.ctrlScrieEmail.AscundeButonIncarcareImagine();
            this.ctrlScrieEmail.AscundeButonSalvare();
            this.ctrlScrieEmail.AscundeButonVeziSursaHTML();

            ConstruiesteColoaneAtasamenteDGV();
            ConstruiesteRanduriAtasamenteDGV(null);
            this.dgvListaAtasamente.ColumnHeadersVisible = false;

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void DgvListaAtasamente_SelectionChanged(object sender, EventArgs e)
        {
            string email = this.dgvListaAtasamente.Rows[this.dgvListaAtasamente.CurrentCell.RowIndex].Tag as string;

            System.Diagnostics.Process.Start(email);
        }

        private void MnuScrieEmailSave_Click(object sender, EventArgs e)
        {
            trimiteEmail(false);
        }

        private void MnuScrieEmailAttach_Click(object sender, EventArgs e)
        {
            adaugaAtasament(this.lMessage, true);
        }

        private void LblFrom_DeschideEcranCautare(Control psender, object pxObiectExistent)
        {
            FormListaEmail.Afiseaza(this.GetFormParinte(), this.lblFrom.Location.X, this.lblFrom.Location.Y);
            if (FormListaEmail._SEmail != null)
            {
                this.lEmail = FormListaEmail._SEmail;
                this.lblFrom.Text = this.lEmail.AdresaMail;
            }
        }

        private void MnuScrieEmailTrimite_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();
                if (!string.IsNullOrEmpty(this.lblFrom.Text) && !string.IsNullOrEmpty(this.txtScrieEmailTo.Text) && !string.IsNullOrEmpty(this.txtScrieEmailSubiect.Text) && this.lEmail != null)
                {
                    trimiteEmail(true);
                    MessageBox.Show("Email-ul a fost trimis!");
                }

                else
                {
                    MessageBox.Show("Mail-ul nu poate fi trimis!");
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

        #region Old-School method
        [DllImport("shell32.dll")]
        static extern IntPtr ExtractAssociatedIcon(IntPtr hInst,
           StringBuilder lpIconPath, out ushort lpiIcon);

        public static Icon GetIconOldSchool(string fileName)
        {
            ushort uicon;
            StringBuilder strB = new StringBuilder(fileName);
            IntPtr handle = ExtractAssociatedIcon(IntPtr.Zero, strB, out uicon);
            Icon ico = Icon.FromHandle(handle);

            return ico;
        }
        #endregion

        private void adaugaAtasament(MimeMessage pMessage, bool deschideDialog)
        {
            if (deschideDialog)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.pBuilder.Attachments.Add(ofd.FileName);
                    //this.lAtasamente.Add(ofd.SafeFileName);
                    this.lAtasamente.Add(System.IO.Path.GetFileName(ofd.FileName));


                    //if (this.lSeIncarca) return;
                    //try
                    //{
                    //    incepeIncarcarea();
                    //    try
                    //    {
                    //        Icon iconForFile = Icon.ExtractAssociatedIcon(ofd.FileName);
                    //        object obj = ResourceManager.GetObject("Icon_253", resourceCulture);
                    //        return ((System.Drawing.Icon)(obj));
                    //        this.lstAtasamente.Add(new Tuple<string, Image>(ofd.SafeFileName, iconForFile.ToBitmap()));
                    //    }
                    //    catch(Exception e)
                    //    {
                    //        Icon iconForFile = GetIconOldSchool(ofd.FileName);
                    //        //this.lstAtasamente.Add(new Tuple<string, Icon>(ofd.SafeFileName, null));
                    //    }
                        
                    //}
                    //catch (Exception ex)
                    //{
                    //    GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
                    //}
                    //finally
                    //{
                    //    finalizeazaIncarcarea();
                    //}
                    
                    
                }

                ConstruiesteColoaneAtasamenteDGV();
                ConstruiesteRanduriAtasamenteDGV(this.lstAtasamente);
                this.dgvListaAtasamente.ColumnHeadersVisible = false;
            }

            pMessage.Body = this.pBuilder.ToMessageBody();

        }

        private void trimiteEmail(bool pTrimite)
        {
            this.lMessage.From.Add(new MailboxAddress(this.lEmail.User, this.lEmail.AdresaMail));
            this.lMessage.To.Add(new MailboxAddress(this.txtScrieEmailTo.Text, this.txtScrieEmailTo.Text));
            this.lMessage.Subject = this.txtScrieEmailSubiect.Text;

            this.lMessage.Body = new TextPart("plain")
            {
                Text = this.ctrlScrieEmail.Text
            };

            adaugaAtasament(this.lMessage, false);

            if (pTrimite)
            {
                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, ex) => true;

                    client.Connect(this.lEmail.HostSMTP, this.lEmail.PortSMTP, false);

                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(this.lEmail.AdresaMail, this.lEmail.ParolaMail);

                    client.Send(this.lMessage);
                    client.Disconnect(true);
                }
            }
            else
            {
                this.lMessage.WriteTo("message.eml");
                MessageBox.Show("Mesajul a fost salvat");
            }

            
        }

        private void ConstruiesteColoaneAtasamenteDGV()
        {
            this.dgvListaAtasamente.IncepeConstructieColoane();

            this.dgvListaAtasamente.AdaugaColoanaText(null, null, 0, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaAtasamente.AdaugaColoanaText(null, null, 0, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaAtasamente.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriAtasamenteDGV(List<Tuple<string,Image>> pLstAtasamente)
        {
            this.dgvListaAtasamente.IncepeContructieRanduri();
            List<string> listaElem = this.lAtasamente;

            if (pLstAtasamente != null)
            {
                for (int i = 0; i < pLstAtasamente.Count; i++)
                {
                    incarcaRand(this.dgvListaAtasamente.Rows[this.dgvListaAtasamente.Rows.Add()], pLstAtasamente[i]);
                }
            }
            
            //foreach (string elem in listaElem)
            //{
            //    try
            //    {
                    
            //        //incarcaRand(this.dgvListaAtasamente.Rows[this.dgvListaAtasamente.Rows.Add()], elem);
            //    }
            //    catch (Exception ex)
            //    {
            //        GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            //    }
            //}

            this.dgvListaAtasamente.FinalizeazaContructieRanduri();

        }

        private void incarcaRand(DataGridViewRow pRand, string pElem, Icon pIcon)
        {
            pRand.Tag = pElem;
            pRand.Cells[0].Value = pIcon;
            pRand.Cells[1].Value = pElem;
        }

        private void incarcaRand(DataGridViewRow pRand, Tuple<string,Image> pLstAtasamente)
        {
            pRand.Tag = pLstAtasamente;
            pRand.Cells[0].Value = pLstAtasamente.Item1;
            pRand.Cells[1].Value = pLstAtasamente.Item2;
        }

        #endregion

        #region Metode publice



        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
            this.ctrlScrieEmail.AllowModification(this.lEcranInModificare);
        }

        #endregion


    }
}
