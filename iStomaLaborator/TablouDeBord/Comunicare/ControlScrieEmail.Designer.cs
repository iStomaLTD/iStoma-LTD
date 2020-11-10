namespace iStomaLab.TablouDeBord.Comunicare
{
    partial class ControlScrieEmail
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblFrom = new CCL.UI.Caramizi.LabelGumaFind();
            this.dgvListaAtasamente = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.txtScrieEmailSubiect = new CCL.UI.Caramizi.TextBoxGuma();
            this.ctrlScrieEmail = new CCL.UI.Caramizi.HTML.ControlEditorHTML();
            this.txtScrieEmailTo = new CCL.UI.Caramizi.TextBoxGuma();
            this.lblScrieEmailSubiect = new CCL.UI.LabelPersonalizat(this.components);
            this.lblScrieEmailTo = new CCL.UI.LabelPersonalizat(this.components);
            this.lblScrieEmailFrom = new CCL.UI.LabelPersonalizat(this.components);
            this.tsMeniuScrieEmail = new CCL.UI.ControalePersonalizate.ToolStripPersonalizat();
            this.mnuScrieEmailTrimite = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuScrieEmailAttach = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuScrieEmailSave = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaAtasamente)).BeginInit();
            this.tsMeniuScrieEmail.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFrom
            // 
            this.lblFrom.AfiseazaButonCautare = true;
            this.lblFrom.AfiseazaButonDetalii = false;
            this.lblFrom.AfiseazaButonGuma = true;
            this.lblFrom.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.lblFrom.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.lblFrom.BackColor = System.Drawing.Color.White;
            this.lblFrom.FolosesteToString = false;
            this.lblFrom.IsInReadOnlyMode = false;
            this.lblFrom.Location = new System.Drawing.Point(91, 64);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.ObiectAfisajCorespunzator = null;
            this.lblFrom.ObiectCorespunzator = null;
            this.lblFrom.ProprietateCorespunzatoare = null;
            this.lblFrom.Size = new System.Drawing.Size(717, 24);
            this.lblFrom.TabIndex = 12;
            this.lblFrom.Text = "...";
            this.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFrom.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.lblFrom.ToolTipText = null;
            this.lblFrom.ToolTipTitle = null;
            // 
            // dgvListaAtasamente
            // 
            this.dgvListaAtasamente.AllowUserToAddRows = false;
            this.dgvListaAtasamente.AllowUserToDeleteRows = false;
            this.dgvListaAtasamente.AllowUserToResizeRows = false;
            this.dgvListaAtasamente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaAtasamente.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaAtasamente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaAtasamente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaAtasamente.HideSelection = true;
            this.dgvListaAtasamente.IsInReadOnlyMode = false;
            this.dgvListaAtasamente.Location = new System.Drawing.Point(814, 50);
            this.dgvListaAtasamente.MultiSelect = false;
            this.dgvListaAtasamente.Name = "dgvListaAtasamente";
            this.dgvListaAtasamente.ProprietateCorespunzatoare = "";
            this.dgvListaAtasamente.RowHeadersVisible = false;
            this.dgvListaAtasamente.RowTemplate.Height = 24;
            this.dgvListaAtasamente.SeIncarca = false;
            this.dgvListaAtasamente.SelectedText = "";
            this.dgvListaAtasamente.SelectionLength = 0;
            this.dgvListaAtasamente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaAtasamente.SelectionStart = 0;
            this.dgvListaAtasamente.Size = new System.Drawing.Size(394, 103);
            this.dgvListaAtasamente.TabIndex = 11;
            // 
            // txtScrieEmailSubiect
            // 
            this.txtScrieEmailSubiect.AcceptButton = null;
            this.txtScrieEmailSubiect.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtScrieEmailSubiect.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtScrieEmailSubiect.BackColor = System.Drawing.Color.Transparent;
            this.txtScrieEmailSubiect.CapitalizeazaPrimaLitera = false;
            this.txtScrieEmailSubiect.IsInReadOnlyMode = false;
            this.txtScrieEmailSubiect.Location = new System.Drawing.Point(91, 127);
            this.txtScrieEmailSubiect.MaxLength = 32767;
            this.txtScrieEmailSubiect.Multiline = false;
            this.txtScrieEmailSubiect.Name = "txtScrieEmailSubiect";
            this.txtScrieEmailSubiect.ProprietateCorespunzatoare = null;
            this.txtScrieEmailSubiect.RaiseEventLaModificareProgramatica = false;
            this.txtScrieEmailSubiect.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtScrieEmailSubiect.Size = new System.Drawing.Size(717, 26);
            this.txtScrieEmailSubiect.TabIndex = 9;
            this.txtScrieEmailSubiect.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtScrieEmailSubiect.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtScrieEmailSubiect.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtScrieEmailSubiect.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtScrieEmailSubiect.UseSystemPasswordChar = false;
            // 
            // ctrlScrieEmail
            // 
            this.ctrlScrieEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlScrieEmail.IsContextMenuEnabled = false;
            this.ctrlScrieEmail.Location = new System.Drawing.Point(8, 157);
            this.ctrlScrieEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctrlScrieEmail.MinimumSize = new System.Drawing.Size(1200, 652);
            this.ctrlScrieEmail.Name = "ctrlScrieEmail";
            this.ctrlScrieEmail.Size = new System.Drawing.Size(1200, 652);
            this.ctrlScrieEmail.TabIndex = 8;
            // 
            // txtScrieEmailTo
            // 
            this.txtScrieEmailTo.AcceptButton = null;
            this.txtScrieEmailTo.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtScrieEmailTo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtScrieEmailTo.BackColor = System.Drawing.Color.White;
            this.txtScrieEmailTo.CapitalizeazaPrimaLitera = false;
            this.txtScrieEmailTo.IsInReadOnlyMode = false;
            this.txtScrieEmailTo.Location = new System.Drawing.Point(91, 94);
            this.txtScrieEmailTo.MaxLength = 32767;
            this.txtScrieEmailTo.Multiline = false;
            this.txtScrieEmailTo.Name = "txtScrieEmailTo";
            this.txtScrieEmailTo.ProprietateCorespunzatoare = null;
            this.txtScrieEmailTo.RaiseEventLaModificareProgramatica = false;
            this.txtScrieEmailTo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtScrieEmailTo.Size = new System.Drawing.Size(717, 25);
            this.txtScrieEmailTo.TabIndex = 6;
            this.txtScrieEmailTo.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtScrieEmailTo.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtScrieEmailTo.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtScrieEmailTo.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtScrieEmailTo.UseSystemPasswordChar = false;
            // 
            // lblScrieEmailSubiect
            // 
            this.lblScrieEmailSubiect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScrieEmailSubiect.AutoSize = true;
            this.lblScrieEmailSubiect.Location = new System.Drawing.Point(25, 133);
            this.lblScrieEmailSubiect.Name = "lblScrieEmailSubiect";
            this.lblScrieEmailSubiect.Size = new System.Drawing.Size(55, 17);
            this.lblScrieEmailSubiect.TabIndex = 4;
            this.lblScrieEmailSubiect.Text = "Subiect";
            this.lblScrieEmailSubiect.ToolTipText = null;
            this.lblScrieEmailSubiect.ToolTipTitle = null;
            // 
            // lblScrieEmailTo
            // 
            this.lblScrieEmailTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScrieEmailTo.AutoSize = true;
            this.lblScrieEmailTo.Location = new System.Drawing.Point(25, 102);
            this.lblScrieEmailTo.Name = "lblScrieEmailTo";
            this.lblScrieEmailTo.Size = new System.Drawing.Size(25, 17);
            this.lblScrieEmailTo.TabIndex = 3;
            this.lblScrieEmailTo.Text = "To";
            this.lblScrieEmailTo.ToolTipText = null;
            this.lblScrieEmailTo.ToolTipTitle = null;
            // 
            // lblScrieEmailFrom
            // 
            this.lblScrieEmailFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScrieEmailFrom.AutoSize = true;
            this.lblScrieEmailFrom.Location = new System.Drawing.Point(25, 67);
            this.lblScrieEmailFrom.Name = "lblScrieEmailFrom";
            this.lblScrieEmailFrom.Size = new System.Drawing.Size(40, 17);
            this.lblScrieEmailFrom.TabIndex = 2;
            this.lblScrieEmailFrom.Text = "From";
            this.lblScrieEmailFrom.ToolTipText = null;
            this.lblScrieEmailFrom.ToolTipTitle = null;
            // 
            // tsMeniuScrieEmail
            // 
            this.tsMeniuScrieEmail.BackColor = System.Drawing.SystemColors.Control;
            this.tsMeniuScrieEmail.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMeniuScrieEmail.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMeniuScrieEmail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuScrieEmailTrimite,
            this.toolStripSeparator1,
            this.mnuScrieEmailAttach,
            this.toolStripSeparator2,
            this.mnuScrieEmailSave});
            this.tsMeniuScrieEmail.Location = new System.Drawing.Point(0, 0);
            this.tsMeniuScrieEmail.Name = "tsMeniuScrieEmail";
            this.tsMeniuScrieEmail.Size = new System.Drawing.Size(1213, 47);
            this.tsMeniuScrieEmail.TabIndex = 1;
            this.tsMeniuScrieEmail.Text = "toolStripPersonalizat1";
            // 
            // mnuScrieEmailTrimite
            // 
            this.mnuScrieEmailTrimite.Image = global::iStomaLab.Properties.Resources.paper_plane1;
            this.mnuScrieEmailTrimite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuScrieEmailTrimite.Name = "mnuScrieEmailTrimite";
            this.mnuScrieEmailTrimite.Size = new System.Drawing.Size(59, 44);
            this.mnuScrieEmailTrimite.Text = "Trimite";
            this.mnuScrieEmailTrimite.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 47);
            // 
            // mnuScrieEmailAttach
            // 
            this.mnuScrieEmailAttach.Image = global::iStomaLab.Properties.Resources.attachment;
            this.mnuScrieEmailAttach.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuScrieEmailAttach.Name = "mnuScrieEmailAttach";
            this.mnuScrieEmailAttach.Size = new System.Drawing.Size(56, 44);
            this.mnuScrieEmailAttach.Text = "Attach";
            this.mnuScrieEmailAttach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 47);
            // 
            // mnuScrieEmailSave
            // 
            this.mnuScrieEmailSave.Image = global::iStomaLab.Properties.Resources.unread;
            this.mnuScrieEmailSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuScrieEmailSave.Name = "mnuScrieEmailSave";
            this.mnuScrieEmailSave.Size = new System.Drawing.Size(44, 44);
            this.mnuScrieEmailSave.Text = "Save";
            this.mnuScrieEmailSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // ControlScrieEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.dgvListaAtasamente);
            this.Controls.Add(this.txtScrieEmailSubiect);
            this.Controls.Add(this.ctrlScrieEmail);
            this.Controls.Add(this.txtScrieEmailTo);
            this.Controls.Add(this.lblScrieEmailSubiect);
            this.Controls.Add(this.lblScrieEmailTo);
            this.Controls.Add(this.lblScrieEmailFrom);
            this.Controls.Add(this.tsMeniuScrieEmail);
            this.Name = "ControlScrieEmail";
            this.Size = new System.Drawing.Size(1213, 819);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaAtasamente)).EndInit();
            this.tsMeniuScrieEmail.ResumeLayout(false);
            this.tsMeniuScrieEmail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.ControalePersonalizate.ToolStripPersonalizat tsMeniuScrieEmail;
        private System.Windows.Forms.ToolStripButton mnuScrieEmailTrimite;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton mnuScrieEmailAttach;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton mnuScrieEmailSave;
        private CCL.UI.LabelPersonalizat lblScrieEmailFrom;
        private CCL.UI.LabelPersonalizat lblScrieEmailTo;
        private CCL.UI.LabelPersonalizat lblScrieEmailSubiect;
        private CCL.UI.Caramizi.TextBoxGuma txtScrieEmailTo;
        private CCL.UI.Caramizi.HTML.ControlEditorHTML ctrlScrieEmail;
        private CCL.UI.Caramizi.TextBoxGuma txtScrieEmailSubiect;
        private CCL.UI.DataGridViewPersonalizat dgvListaAtasamente;
        private CCL.UI.Caramizi.LabelGumaFind lblFrom;
    }
}
