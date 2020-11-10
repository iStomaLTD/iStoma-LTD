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
using CCL.UI;
using BLL.iStomaLab;
using iStomaLab.TablouDeBord.Comunicare;
using BLL.iStomaLab.Email;
using MimeKit;
using System.IO;
using MailKit;
using MimeKit.Text;
using static iStomaLab.BLLUtile;
using CCL.UI.ControaleSpecializate;

namespace iStomaLab.TablouDeBord.Email
{
    public partial class ControlInbox : UserControlPersonalizat
    {

        #region Declaratii generale

        private BEmail lEmail = null;
        private IMailFolder lMailFolder;


        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colStar,
            colSender,
            colSubiect,
            colData,
            colAttachment,
            colFlag,
            colNotita,
            colRecall
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlInbox()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                adaugaHandlere();
                initTextML();
            }

            seteazaVizibilitateAtasamente(null);
            this.txtCautareEmail.Goleste();
        }

        private void adaugaHandlere()
        {
            this.dgvEmail.SelectionChanged += DgvEmail_SelectionChanged;
            this.txtCautareEmail.CerereUpdate += TxtCautareEmail_CerereUpdate;
            this.dgvEmail.EditareLinie += DgvEmail_EditareLinie;
            this.btnInboxSalveazaAtasamente.Click += BtnInboxSalveazaAtasamente_Click;
            this.mnuEmailWrite.Click += MnuEmailWrite_Click;
            this.mnuEmailRefresh.Click += MnuEmailRefresh_Click;
        }

        private void initTextML()
        {

        }

        public void Initializeaza(BEmail pEmail, IEnumerable<IMessageSummary> pSummaries, IMailFolder pMailFolder)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.lEmail = pEmail;
            this.lMailFolder = pMailFolder;

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV(pSummaries);

            finalizeazaIncarcarea();
        }

        public void Initializeaza(BEmail pEmail)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.lEmail = pEmail;

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void MnuEmailRefresh_Click(object sender, EventArgs e)
        {

        }

        private void MnuEmailWrite_Click(object sender, EventArgs e)
        {
            FormScrieEmail.Afiseaza(this.GetFormParinte(), null);
        }

        private void BtnInboxSalveazaAtasamente_Click(object sender, EventArgs e)
        {
            BLLUtile.StructMailKitInbox email = this.dgvEmail.Rows[this.dgvEmail.CurrentCell.RowIndex].Tag as BLLUtile.StructMailKitInbox;
            if (email != null)
            {
                SalveazaAtasamente(email);
            }
        }

        private void TxtCautareEmail_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvEmail.FiltreazaDupaText(this.txtCautareEmail.Text);
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

        private void DgvEmail_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                incepeIncarcarea();
                BLLUtile.StructMailKitInbox email = this.dgvEmail.Rows[this.dgvEmail.CurrentCell.RowIndex].Tag as BLLUtile.StructMailKitInbox;
                if (email != null)
                {
                    incarcaMailInWebBrowser(this.lMailFolder, email);
                    //if (email.HasValue && email.Flag == MessageFlags.Seen)
                    //{
                    //    this.lMailFolder.AddFlags(email.UniqueId, MessageFlags.Seen, true);
                    //}

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

        private void DgvEmail_EditareLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BLLUtile.StructMailKitInbox email = this.dgvEmail.Rows[pIndexRand].Tag as BLLUtile.StructMailKitInbox;

                if (email != null)
                {
                    if (FormDetaliuEmail.Afiseaza(this.GetFormParinte(), email, this.lMailFolder, email.UniqueId, email.Body))
                    {
                        // incarcaRand(this.dgvEmail.Rows[pIndexRand], email);
                    }

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

        private SpecialFolder getSpecialFolder()
        {
            SpecialFolder folder = SpecialFolder.Sent;

            switch (this.lMailFolder.UidValidity)
            {
                case 11:
                    folder = SpecialFolder.All;
                    break;
                case 1:
                    folder = SpecialFolder.Archive;
                    break;
                case 6:
                    folder = SpecialFolder.Drafts;
                    break;
                case 9:
                    folder = SpecialFolder.Flagged;
                    break;
                case 3:
                    folder = SpecialFolder.Junk;
                    break;
                case 5:
                    folder = SpecialFolder.Sent;
                    break;
                case 2:
                    folder = SpecialFolder.Trash;
                    break;
            }

            return folder;
        }

        private void SalveazaAtasamente(BLLUtile.StructMailKitInbox pEmail)
        {
            var listaAtasamente = StructMailKitInbox.getAtasamente(this.lMailFolder.UidValidity == 1, getSpecialFolder(), this.lEmail, pEmail.UniqueId);
            if (listaAtasamente != null)
            {
                foreach (var attachment in listaAtasamente)
                {
                    SaveFileDialog savefile = new SaveFileDialog();
                    savefile.FileName = attachment.ContentType.Name;

                    if (savefile.ShowDialog() == DialogResult.OK)
                    {
                        using (var stream = File.Create(savefile.FileName))
                        {
                            if (attachment is MessagePart)
                            {
                                var part = (MessagePart)attachment;

                                part.Message.WriteTo(stream);
                            }
                            else
                            {
                                var part = (MimePart)attachment;

                                part.ContentObject.DecodeTo(stream);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Atasamentul nu poate fi salvat!");
            }

        }

        private void seteazaVizibilitateAtasamente(BLLUtile.StructMailKitInbox pEmail)
        {
            if (pEmail != null && pEmail.AtasamenteFinal.Count > 0)
            {
                this.lblInboxNrAtasamente.Visible = true;
                this.btnInboxSalveazaAtasamente.Visible = true;
                this.lblInboxNrAtasamente.Text = pEmail.AtasamenteFinal.Count + " atasamente";
            }
            else
            {
                this.lblInboxNrAtasamente.Visible = false;
                this.btnInboxSalveazaAtasamente.Visible = false;
            }
        }

        private void incarcaMailInWebBrowser(IMailFolder pFolder, BLLUtile.StructMailKitInbox pEmail)
        {
            Render(pFolder, pEmail.UniqueId, pEmail.Body, this.wbEmail);
            seteazaVizibilitateAtasamente(pEmail);
        }

        private static async void RenderText(IMailFolder folder, UniqueId uid, BodyPartText bodyPart, WebBrowserEditabil pWebBrowser)
        {
            var entity = await folder.GetBodyPartAsync(uid, bodyPart);

            RenderText((TextPart)entity, pWebBrowser);
        }

        public static async void RenderMultipartRelated(IMailFolder folder, UniqueId uid, BodyPartMultipart bodyPart, WebBrowserEditabil pWebBrowser)
        {
            var related = await folder.GetBodyPartAsync(uid, bodyPart) as MultipartRelated;

            RenderMultipartRelated(related, pWebBrowser);
        }

        public static void RenderMultipartRelated(MultipartRelated related, WebBrowserEditabil pWebBrowser)
        {
            var root = related.Root;
            var multipart = root as Multipart;
            var text = root as TextPart;

            if (multipart != null)
            {
                for (int i = multipart.Count; i > 0; i--)
                {
                    var body = multipart[i - 1] as TextPart;

                    if (body == null)
                        continue;

                    if (body.ContentType.IsMimeType("text", "html"))
                    {
                        text = body;
                        break;
                    }

                    if (text == null)
                        text = body;
                }
            }
            if (text != null)
            {
                if (text.ContentType.IsMimeType("text", "html"))
                {
                    var ctx = new MultipartRelatedImageContext(related);
                    var converter = new HtmlToHtml() { HtmlTagCallback = ctx.HtmlTagCallback };
                    var html = converter.Convert(text.Text);

                    pWebBrowser.DocumentText = html;
                }
                else
                {
                    RenderText(text, pWebBrowser);
                }
            }
            else
            {
                return;
            }
        }

        static void RenderText(TextPart text, WebBrowserEditabil pWebBrowser)
        {
            string html;

            if (text.IsHtml)
            {
                html = text.Text;
            }
            else if (text.IsFlowed)
            {
                var converter = new FlowedToHtml();
                string delsp;

                if (!text.ContentType.Parameters.TryGetValue("delsp", out delsp))
                    delsp = "no";

                if (string.Compare(delsp, "yes", StringComparison.OrdinalIgnoreCase) == 0)
                    converter.DeleteSpace = true;

                html = converter.Convert(text.Text);
            }
            else
            {
                html = new TextToHtml().Convert(text.Text);
            }

            pWebBrowser.DocumentText = html;
        }

        private void ConstruiesteColoaneDGV()
        {
            this.dgvEmail.IncepeConstructieColoane();

            this.dgvEmail.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.DeschideClasic);

            this.dgvEmail.AdaugaColoanaImagine(EnumColoaneDGV.colAttachment.ToString(), "📎", null, 30, false);

            this.dgvEmail.AdaugaColoanaText(EnumColoaneDGV.colSender.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Sender), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvEmail.AdaugaColoanaText(EnumColoaneDGV.colSubiect.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Subiect), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvEmail.AdaugaColoanaText(EnumColoaneDGV.colData.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Data), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvEmail.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV(IEnumerable<IMessageSummary> summaries)
        {
            this.dgvEmail.IncepeContructieRanduri();

            List<BLLUtile.StructMailKitInbox> listaElem = BLLUtile.StructMailKitInbox.getListaEmailuri(summaries);

            foreach (var elem in listaElem)
            {
                //incarcaRand(this.dgvEmail.Rows[this.dgvEmail.Rows.Add()], elem);
            }

            this.dgvEmail.FinalizeazaContructieRanduri();

        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvEmail.IncepeContructieRanduri();

            var listaEmailuriExtrase = BEmailuriExtrase.GetListByParamIdEmail(this.lEmail.Id, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

            foreach (var elem in listaEmailuriExtrase)
            {
                incarcaRand(this.dgvEmail.Rows[this.dgvEmail.Rows.Add()], elem);
            }

            this.dgvEmail.FinalizeazaContructieRanduri();

        }

        private void incarcaRand(DataGridViewRow pRand, BEmailuriExtrase pElem)
        {
            pRand.Tag = pElem;
            DataGridViewPersonalizat.InitCelulaDeschideClasic(pRand);
            if (pElem.NumarAtasamente != 0)
            {
                DataGridViewPersonalizat.initCelulaImagine(pRand, EnumColoaneDGV.colAttachment.ToString(), (System.Drawing.Image)Properties.Resources.attachment);
            }
            else
            {
                DataGridViewPersonalizat.initCelulaImagine(pRand, EnumColoaneDGV.colAttachment.ToString(), new Bitmap(1, 1));
            }

            pRand.Cells[EnumColoaneDGV.colSender.ToString()].Value = pElem.Expeditor;
            pRand.Cells[EnumColoaneDGV.colSubiect.ToString()].Value = pElem.Subiect;
            pRand.Cells[EnumColoaneDGV.colData.ToString()].Value = pElem.DataServer;
        }

        #endregion

        #region Metode publice


        public static void Render(IMailFolder folder, UniqueId uid, BodyPart body, WebBrowserEditabil pWebBrowser)
        {
            var multipart = body as BodyPartMultipart;

            if (multipart != null && body.ContentType.IsMimeType("multipart", "related"))
            {
                RenderMultipartRelated(folder, uid, multipart, pWebBrowser);
                return;
            }

            var text = body as BodyPartText;

            if (multipart != null)
            {
                if (multipart.ContentType.IsMimeType("multipart", "alternative"))
                {
                    for (int i = multipart.BodyParts.Count; i > 0; i--)
                    {
                        var multi = multipart.BodyParts[i - 1] as BodyPartMultipart;

                        if (multi != null && multi.ContentType.IsMimeType("multipart", "related"))
                        {
                            if (multi.BodyParts.Count == 0)
                                continue;

                            var start = multi.ContentType.Parameters["start"];
                            var root = multi.BodyParts[0];

                            if (!string.IsNullOrEmpty(start))
                            {
                                root = multi.BodyParts.OfType<BodyPartText>().FirstOrDefault(x => x.ContentId == start);
                            }

                            if (root != null && root.ContentType.IsMimeType("text", "html"))
                            {
                                Render(folder, uid, multi, pWebBrowser);
                                return;
                            }

                            continue;
                        }

                        text = multipart.BodyParts[i - 1] as BodyPartText;

                        if (text != null)
                        {
                            RenderText(folder, uid, text, pWebBrowser);
                            return;
                        }
                    }
                }
                else if (multipart.BodyParts.Count > 0)
                {
                    Render(folder, uid, multipart.BodyParts[0], pWebBrowser);
                }
            }
            else if (text != null)
            {
                RenderText(folder, uid, text, pWebBrowser);
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
