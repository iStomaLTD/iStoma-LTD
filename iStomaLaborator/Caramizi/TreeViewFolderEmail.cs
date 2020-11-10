using BLL.iStomaLab.Email;
using MailKit;
using MailKit.Net.Imap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iStomaLab.Caramizi
{
    [ToolboxItem(true)]
    public partial class TreeViewFolderEmail : TreeView
    {
        public static ImapClient Client = new ImapClient();
        readonly Dictionary<IMailFolder, TreeNode> map = new Dictionary<IMailFolder, TreeNode>();

        public TreeViewFolderEmail()
        {
            ImageList = new ImageList();
            ImageList.Images.Add("folder", (System.Drawing.Image)Properties.Resources.archive);
            ImageList.Images.Add("inbox", (System.Drawing.Image)Properties.Resources.inbox);
            ImageList.Images.Add("archive", (System.Drawing.Image)Properties.Resources.archive);
            ImageList.Images.Add("drafts", (System.Drawing.Image)Properties.Resources.archive);
            ImageList.Images.Add("important", (System.Drawing.Image)Properties.Resources.archive);
            ImageList.Images.Add("junk", (System.Drawing.Image)Properties.Resources.archive);
            ImageList.Images.Add("sent", (System.Drawing.Image)Properties.Resources.archive);
            ImageList.Images.Add("trash-empty", (System.Drawing.Image)Properties.Resources.trash_empty);
            ImageList.Images.Add("trash-full", (System.Drawing.Image)Properties.Resources.archive);
        }

        static bool CheckFolderForChildren(IMailFolder folder, ImapClient pClient)
        {
            Client = pClient;

            if (Client.Capabilities.HasFlag(ImapCapabilities.Children))
            {
                if (folder.Attributes.HasFlag(FolderAttributes.HasChildren))
                    return true;
            }
            else if (!folder.Attributes.HasFlag(FolderAttributes.NoInferiors))
            {
                return true;
            }

            return false;
        }

        void UpdateFolderNode(IMailFolder folder)
        {
            var node = map[folder];

            if (folder.Unread > 0)
            {
                node.Text = string.Format("{0} ({1})", folder.Name, folder.Unread);
                node.NodeFont = new Font(node.NodeFont, FontStyle.Bold);
            }
            else
            {
                node.NodeFont = new Font(node.NodeFont, FontStyle.Regular);
                node.Text = folder.Name;
            }

            if (folder.Attributes.HasFlag(FolderAttributes.Trash))
                node.SelectedImageKey = node.ImageKey = folder.Count > 0 ? "archive" : "archive";
        }

        delegate void UpdateFolderNodeDelegate(IMailFolder folder);

        TreeNode CreateFolderNode(IMailFolder folder, ImapClient pClient)
        {
            Client = pClient;
            var node = new TreeNode(folder.Name) { Tag = folder, ToolTipText = folder.FullName };

            node.NodeFont = new Font(Font, FontStyle.Regular);

            if (folder == Client.Inbox)
                node.SelectedImageKey = node.ImageKey = "inbox";
            else if (folder.Attributes.HasFlag(FolderAttributes.Archive))
                node.SelectedImageKey = node.ImageKey = "archive";
            else if (folder.Attributes.HasFlag(FolderAttributes.Drafts))
                node.SelectedImageKey = node.ImageKey = "drafts";
            else if (folder.Attributes.HasFlag(FolderAttributes.Flagged))
                node.SelectedImageKey = node.ImageKey = "important";
            else if (folder.Attributes.HasFlag(FolderAttributes.Junk))
                node.SelectedImageKey = node.ImageKey = "junk";
            else if (folder.Attributes.HasFlag(FolderAttributes.Sent))
                node.SelectedImageKey = node.ImageKey = "sent";
            else if (folder.Attributes.HasFlag(FolderAttributes.Trash))
                node.SelectedImageKey = node.ImageKey = folder.Count > 0 ? "archive" : "archive";
            else
                node.SelectedImageKey = node.ImageKey = "folder";

            if (CheckFolderForChildren(folder,Client))
                node.Nodes.Add("Loading...");

            return node;
        }

        void LoadChildFolders(IMailFolder folder, IEnumerable<IMailFolder> children, ImapClient pClient)
        {
            TreeNodeCollection nodes;
            TreeNode node;

            Client = pClient;

            if (map.TryGetValue(folder, out node))
            {
                nodes = node.Nodes;
                nodes.Clear();
            }
            else
            {
                nodes = Nodes;
            }

            //nodes.Add(pEmail.AdresaMail);

            foreach (var child in children)
            {
                node = CreateFolderNode(child,Client);
                map[child] = node;
                nodes.Add(node);

                // Note: because we are using the *Async() methods, these events will fire
                // in another thread so we'll have to proxy them back to the main thread.
                child.MessageFlagsChanged += UpdateUnreadCount_TaskThread;
                child.CountChanged += UpdateUnreadCount_TaskThread;

                if (!child.Attributes.HasFlag(FolderAttributes.NonExistent) && !child.Attributes.HasFlag(FolderAttributes.NoSelect))
                {
                    child.StatusAsync(StatusItems.Unread).ContinueWith(task => {
                        Invoke(new UpdateFolderNodeDelegate(UpdateFolderNode), child);
                    });
                }
            }
        }

        async void LoadChildFolders(IMailFolder folder, ImapClient pClient)
        {
            Client = pClient;
            var children = await folder.GetSubfoldersAsync();

            LoadChildFolders(folder, children, Client);
        }

        public void LoadFolders(ImapClient pClient)
        {
            try
            {
                var personal = pClient.GetFolder(pClient.PersonalNamespaces[0]);

                PathSeparator = personal.DirectorySeparator.ToString();

                LoadChildFolders(personal, pClient);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        async void UpdateUnreadCount(object sender, EventArgs e)
        {
            var folder = (IMailFolder)sender;

            await folder.StatusAsync(StatusItems.Unread);
            UpdateFolderNode(folder);
        }

        void UpdateUnreadCount_TaskThread(object sender, EventArgs e)
        {
            // proxy to the main thread
            Invoke(new EventHandler<EventArgs>(UpdateUnreadCount), sender, e);
        }

        protected override void OnBeforeExpand(TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Tag == null)
            {
                // this folder has never been expanded before...
                var folder = (IMailFolder)e.Node.Tag;

                LoadChildFolders(folder, Client);
            }

            base.OnBeforeExpand(e);
        }

        protected override void OnBeforeSelect(TreeViewCancelEventArgs e)
        {
            var folder = (IMailFolder)e.Node.Tag;

            // don't allow the user to select a folder with the \NoSelect or \NonExistent attribute
            if (folder == null || folder.Attributes.HasFlag(FolderAttributes.NoSelect) ||
                folder.Attributes.HasFlag(FolderAttributes.NonExistent))
            {
                e.Cancel = true;
                return;
            }

            base.OnBeforeSelect(e);
        }

        public event EventHandler<FolderSelectedEventArgs> FolderSelected;

        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            var handler = FolderSelected;

            if (handler != null)
                handler(this, new FolderSelectedEventArgs((IMailFolder)e.Node.Tag));

            base.OnAfterSelect(e);
        }

        public class FolderSelectedEventArgs : EventArgs
        {
            public FolderSelectedEventArgs(IMailFolder folder)
            {
                Folder = folder;
            }

            public IMailFolder Folder
            {
                get; private set;
            }
        }
    }
}
