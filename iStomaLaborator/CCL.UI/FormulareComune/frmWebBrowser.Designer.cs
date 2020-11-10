namespace CCL.UI
{
    partial class frmWebBrowser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWebBrowser));
            this.wbBrowser = new CCL.UI.ControaleSpecializate.WebBrowserJS(this.components);
            this.btnSalveazaImaginea = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnLinkToFacebook = new CCL.UI.ButtonPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(862, 19);
            this.lblTitluEcran.Text = "iStoma - Aplicația medicilor eficienți";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(861, 0);
            // 
            // wbBrowser
            // 
            this.wbBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbBrowser.HideSelection = true;
            this.wbBrowser.IsInReadOnlyMode = false;
            this.wbBrowser.IsWebBrowserContextMenuEnabled = false;
            this.wbBrowser.Location = new System.Drawing.Point(1, 19);
            this.wbBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbBrowser.Name = "wbBrowser";
            this.wbBrowser.ProprietateCorespunzatoare = null;
            this.wbBrowser.ScriptErrorsSuppressed = true;
            this.wbBrowser.SelectedText = null;
            this.wbBrowser.Size = new System.Drawing.Size(882, 544);
            this.wbBrowser.TabIndex = 0;
            this.wbBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbBrowser_DocumentCompleted);
            this.wbBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.wbBrowser_Navigating);
            // 
            // btnSalveazaImaginea
            // 
            this.btnSalveazaImaginea.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnSalveazaImaginea.Image = ((System.Drawing.Image)(resources.GetObject("btnSalveazaImaginea.Image")));
            this.btnSalveazaImaginea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalveazaImaginea.Location = new System.Drawing.Point(18, 0);
            this.btnSalveazaImaginea.Name = "btnSalveazaImaginea";
            this.btnSalveazaImaginea.Size = new System.Drawing.Size(144, 19);
            this.btnSalveazaImaginea.TabIndex = 2;
            this.btnSalveazaImaginea.Text = "Salvează imaginea";
            this.btnSalveazaImaginea.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Salvare;
            this.btnSalveazaImaginea.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnSalveazaImaginea.UseVisualStyleBackColor = true;
            this.btnSalveazaImaginea.Click += new System.EventHandler(this.btnSalveazaImaginea_Click);
            // 
            // btnLinkToFacebook
            // 
            this.btnLinkToFacebook.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnLinkToFacebook.Image = global::CCL.UI.Properties.Resources.Text_link;
            this.btnLinkToFacebook.Location = new System.Drawing.Point(169, 0);
            this.btnLinkToFacebook.Name = "btnLinkToFacebook";
            this.btnLinkToFacebook.Size = new System.Drawing.Size(50, 19);
            this.btnLinkToFacebook.TabIndex = 3;
            this.btnLinkToFacebook.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnLinkToFacebook.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnLinkToFacebook.UseVisualStyleBackColor = true;
            this.btnLinkToFacebook.Click += new System.EventHandler(this.btnLinkToFacebook_Click);
            // 
            // frmWebBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 564);
            this.Controls.Add(this.btnLinkToFacebook);
            this.Controls.Add(this.btnSalveazaImaginea);
            this.Controls.Add(this.wbBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(884, 564);
            this.Name = "frmWebBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iStoma - Aplicația medicilor eficienți";
            this.Load += new System.EventHandler(this.frmWebBrowser_Load);
            this.Controls.SetChildIndex(this.wbBrowser, 0);
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.btnSalveazaImaginea, 0);
            this.Controls.SetChildIndex(this.btnLinkToFacebook, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.ControaleSpecializate.WebBrowserJS wbBrowser;
        private ButtonPersonalizat btnSalveazaImaginea;
        private ButtonPersonalizat btnLinkToFacebook;
    }
}