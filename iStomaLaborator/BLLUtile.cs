using BLL.iStomaLab.Email;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iStomaLab
{
    public class BLLUtile
    {
        #region MailKit Inbox

        public class StructMailKitInbox
        {
            private int _lCount;
            private bool _lHasValue;
            private MessageFlags _lFlag;
            private InternetAddressList _lFrom;
            private string _lSubiect;
            private string _lData;
            private string _lHtlmBody;
            private string _lTo;
            private List<MimeEntity> _lCuAtasament;
            private IEnumerable<MimeEntity> _lCuAtasamentBody;
            private List<BodyPartBasic> _lAtasamenteFinal;
            private List<InternetAddress> _lBCC;
            private BodyPart _lBody;
            private string _lbody2;
            private IEnumerable<MimeEntity> _lBodyParts;
            private List<InternetAddress> _lCC;
            private List<Header> _lHeaders;
            private string _lImportance;
            private string _lInReplyTo;
            private string _lMessageID;
            private string _lTextBody;
            private string _lMimeVersion;
            private string _lPriority;
            private List<string> _lReferences;
            private List<InternetAddress> _lReplyTo;
            private List<InternetAddress> _lResentBcc;
            private List<InternetAddress> _lResentCC;
            private DateTimeOffset _lResentDate;
            private List<InternetAddress> _lResentFrom;
            private string _lResentMessageId;
            private List<InternetAddress> _lResentReplyTo;
            private MailboxAddress _lResentSender;
            private List<InternetAddress> _lResentTo;
            private MailboxAddress _lSender;
            private string _lXPriority;
            private UniqueId _lUniqueId;



            public static List<StructMailKitInbox> getListaEmailuri(IEnumerable<IMessageSummary> summaries)
            {
                List<StructMailKitInbox> subject = new List<StructMailKitInbox>();

                foreach (var message in summaries)
                {
                    List<BodyPartBasic> listaAtasamente = new List<BodyPartBasic>();

                    foreach (var attach in message.BodyParts)
                    {
                        var a6 = attach.ContentTransferEncoding;
                        var a7 = attach.ContentType;
                        var a8 = attach.FileName;
                        var a9 = attach.IsAttachment;
                        var a10 = attach.Octets;
                        var a11 = attach.PartSpecifier;

                        if (!string.IsNullOrEmpty(attach.FileName) && string.IsNullOrEmpty(attach.ContentId))
                        {
                            listaAtasamente.Add(attach);
                        }
                    }

                    //var varanother3 = message.BodyParts;
                    //var another4 = message.Fields;
                    var another5 = message.Flags.HasValue;
                    var another6 = message.Flags.Value;
                    //var another8 = message.GMailLabels;
                    //var another9 = message.GMailMessageId.HasValue;
                    //var another91 = message.GMailMessageId.Value;
                    //var another10 = message.GMailThreadId.HasValue;
                    //var another101 = message.GMailThreadId.Value;
                    //var another11 = message.Headers;
                    //var another12 = message.HtmlBody;
                    //var another13 = message.Index;
                    //var another14 = message.InternalDate;
                    //var another15 = message.IsReply;
                    //var another16 = message.ModSeq;
                    //var another17 = message.NormalizedSubject;
                    //var another18 = message.References;
                    //uint? another19 = message.Size;
                    //var another20 = message.TextBody;
                    //var another21 = message.UniqueId;
                    //var another22 = message.UserFlags;
                    //var another23 = message.Envelope.Bcc;
                    //var another24 = message.Envelope.Cc;
                    //var another25 = message.Envelope.Date;
                    //var another26 = message.Envelope.From;
                    //var another27 = message.Envelope.InReplyTo;
                    //var another28 = message.Envelope.MessageId;
                    //var another29 = message.Envelope.ReplyTo;
                    //var another30 = message.Envelope.Sender;
                    //var another31 = message.Envelope.Subject;
                    //var another32 = message.Envelope.To;
                    message.Envelope.To.ToString();

                    subject.Add(new StructMailKitInbox(message.Envelope.From, message.Envelope.Subject, getData(message.Date), message.Envelope.Cc.ToString(), listaAtasamente, message.UniqueId, message.Body, message.Flags.HasValue, message.Flags.Value));
                }
                return subject;
            }

            public static string getData(DateTimeOffset date)
            {
                return date.ToString("dd.MM.yyyy");
            }

            public StructMailKitInbox(InternetAddressList psFrom, string psSubiect, string psData, string psTo, List<BodyPartBasic> psAtasament, UniqueId psUniqueId, BodyPart psBody, bool psHasValue, MessageFlags psFlag)
            {
                this._lFrom = psFrom;
                this._lSubiect = psSubiect;
                this._lData = psData;
                this._lTo = psTo;
                this._lAtasamenteFinal = psAtasament;
                this._lUniqueId = psUniqueId;
                this._lBody = psBody;
                this._lHasValue = psHasValue;
                this._lFlag = psFlag;
            }

            public static IEnumerable<MimeEntity> getAtasamente(bool esteInInbox, SpecialFolder pFolderPath, BEmail pEmail, UniqueId pUniqueId)
            {
                IEnumerable<MimeEntity> atasament = null;
                using (ImapClient client = new ImapClient())
                {
                    try
                    {
                        client.Connect(pEmail.HostIMAP, pEmail.PortIMAP, SecureSocketOptions.SslOnConnect);
                        client.Authenticate(pEmail.AdresaMail, pEmail.ParolaMail);
                        if (esteInInbox)
                        {
                            client.Inbox.Open(FolderAccess.ReadWrite);
                            var inbox = client.Inbox;
                            var listaAtasamente = inbox.GetMessage(pUniqueId).Attachments;
                            atasament = listaAtasamente;
                        }
                        else
                        {
                            client.GetFolder(pFolderPath).Open(FolderAccess.ReadOnly);
                            var listaAtasamente = client.GetFolder(pFolderPath).GetMessage(pUniqueId).Attachments;
                            atasament = listaAtasamente;
                        }

                        client.Disconnect(true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                return atasament;
            }

            public InternetAddressList From
            {
                get { return this._lFrom; }
            }

            public string Subiect
            {
                get { return this._lSubiect; }
            }

            public string Data
            {
                get { return this._lData; }
            }

            public string HtlmBody
            {
                get { return this._lHtlmBody; }
            }

            public string To
            {
                get { return this._lTo; }
            }

            public List<MimeEntity> CuAtasament
            {
                get { return this._lCuAtasament; }
            }

            public List<BodyPartBasic> AtasamenteFinal
            {
                get { return this._lAtasamenteFinal; }
            }

            public IEnumerable<MimeEntity> CUAtasamentBody
            {
                get { return this._lCuAtasamentBody; }
            }

            public List<InternetAddress> BCC
            {
                get { return this._lBCC; }
            }

            public BodyPart Body
            {
                get { return this._lBody; }
            }

            public IEnumerable<MimeEntity> BodyParts
            {
                get { return this._lBodyParts; }
            }

            public List<InternetAddress> CC
            {
                get { return this._lCC; }
            }

            public List<Header> Headers
            {
                get { return this._lHeaders; }
            }

            public string Importance
            {
                get { return this._lImportance; }
            }

            public string InReplyTo
            {
                get { return this._lInReplyTo; }
            }

            public string MessageId
            {
                get { return this._lMessageID; }
            }

            public string TextBody
            {
                get { return this._lTextBody; }
            }

            public string MimeVersion
            {
                get { return this._lMimeVersion; }
            }

            public string Priority
            {
                get { return this._lPriority; }
            }

            public List<string> References
            {
                get { return this._lReferences; }
            }

            public List<InternetAddress> ReplyTo
            {
                get { return this._lReplyTo; }
            }

            public List<InternetAddress> ResentBCC
            {
                get { return this._lResentBcc; }
            }

            public List<InternetAddress> ResentCC
            {
                get { return this._lResentCC; }
            }

            public DateTimeOffset ResentDate
            {
                get { return this._lResentDate; }
            }

            public List<InternetAddress> ResentFrom
            {
                get { return this._lResentFrom; }
            }

            public string ResentMessageId
            {
                get { return this._lResentMessageId; }
            }

            public List<InternetAddress> ResentReplyTo
            {
                get { return this._lResentReplyTo; }
            }

            public MailboxAddress ResentSender
            {
                get { return this._lResentSender; }
            }

            public List<InternetAddress> ResentTo
            {
                get { return this._lResentTo; }
            }

            public MailboxAddress Sender
            {
                get { return this._lSender; }
            }

            public string XPriority
            {
                get { return this._lXPriority; }
            }

            public UniqueId UniqueId
            {
                get { return this._lUniqueId; }
            }

            public bool HasValue
            {
                get { return this._lHasValue; }
            }

            public MessageFlags Flag
            {
                get { return this._lFlag; }
            }
        }

        #endregion

        #region MessageInfo
        public class MessageInfo
        {
            public readonly IMessageSummary Summary;
            public MessageFlags Flags;

            public MessageInfo(IMessageSummary summary)
            {
                Summary = summary;

                if (summary.Flags.HasValue)
                    Flags = summary.Flags.Value;
            }
        }
        #endregion

        #region MultipartRelatedImageContext

        public class MultipartRelatedImageContext
        {
            readonly MultipartRelated related;

            public MultipartRelatedImageContext(MultipartRelated related)
            {
                this.related = related;
            }

            string GetDataUri(MimePart attachment)
            {
                using (var memory = new MemoryStream())
                {
                    attachment.ContentObject.DecodeTo(memory);
                    var buffer = memory.GetBuffer();
                    var length = (int)memory.Length;
                    var base64 = Convert.ToBase64String(buffer, 0, length);

                    return string.Format("data:{0};base64,{1}", attachment.ContentType.MimeType, base64);
                }
            }

            public void HtmlTagCallback(HtmlTagContext ctx, HtmlWriter htmlWriter)
            {
                if (ctx.TagId != HtmlTagId.Image || ctx.IsEndTag)
                {
                    ctx.WriteTag(htmlWriter, true);
                    return;
                }

                ctx.WriteTag(htmlWriter, false);

                foreach (var attribute in ctx.Attributes)
                {
                    if (attribute.Id == HtmlAttributeId.Src)
                    {
                        int index;
                        Uri uri;

                        if (Uri.IsWellFormedUriString(attribute.Value, UriKind.Absolute))
                            uri = new Uri(attribute.Value, UriKind.Absolute);
                        else
                            uri = new Uri(attribute.Value, UriKind.Relative);

                        if ((index = related.IndexOf(uri)) != -1)
                        {
                            var attachment = related[index] as MimePart;

                            if (attachment == null)
                            {
                                htmlWriter.WriteAttribute(attribute);
                                continue;
                            }

                            var data = GetDataUri(attachment);

                            htmlWriter.WriteAttributeName(attribute.Name);
                            htmlWriter.WriteAttributeValue(data);
                        }
                        else
                        {
                            htmlWriter.WriteAttribute(attribute);
                        }
                    }
                }
            }
        }

        #endregion

    }
}
