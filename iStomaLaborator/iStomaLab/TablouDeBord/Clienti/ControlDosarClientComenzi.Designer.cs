using static CDL.iStomaLab.CDefinitiiComune;

namespace iStomaLab.TablouDeBord.Clienti
{
    partial class ControlDosarClientComenzi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlDosarClientComenzi));
            this.lblComenziInLucru = new CCL.UI.LabelPersonalizat(this.components);
            this.panelComenziInLucru = new CCL.UI.Caramizi.PanelContainerCCL();
            this.txtCautareInLucru = new CCL.UI.Caramizi.TextBoxCautare();
            this.btnActiviInactivi = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblNrComenziInLucru = new CCL.UI.LabelPersonalizat(this.components);
            this.btnAdaugaComandaInLucru = new CCL.UI.ButtonPersonalizat(this.components);
            this.dgvComenziInLucru = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.panelComenziTrecute = new CCL.UI.Caramizi.PanelContainerCCL();
            this.txtCautareTrecute = new CCL.UI.Caramizi.TextBoxCautare();
            this.lblNrComenziTrecute = new CCL.UI.LabelPersonalizat(this.components);
            this.dgvComenziTrecute = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.lblComenziTrecute = new CCL.UI.LabelPersonalizat(this.components);
            this.panelComenziInLucru.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComenziInLucru)).BeginInit();
            this.panelComenziTrecute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComenziTrecute)).BeginInit();
            this.SuspendLayout();
            // 
            // lblComenziInLucru
            // 
            this.lblComenziInLucru.AutoSize = true;
            this.lblComenziInLucru.Location = new System.Drawing.Point(2, 8);
            this.lblComenziInLucru.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblComenziInLucru.Name = "lblComenziInLucru";
            this.lblComenziInLucru.Size = new System.Drawing.Size(63, 13);
            this.lblComenziInLucru.TabIndex = 0;
            this.lblComenziInLucru.Text = "Nefacturate";
            this.lblComenziInLucru.ToolTipText = null;
            this.lblComenziInLucru.ToolTipTitle = null;
            // 
            // panelComenziInLucru
            // 
            this.panelComenziInLucru.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelComenziInLucru.AutoScaleDimensions = new System.Drawing.SizeF(0F, 0F);
            this.panelComenziInLucru.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.panelComenziInLucru.BackColor = System.Drawing.Color.White;
            this.panelComenziInLucru.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelComenziInLucru.Controls.Add(this.txtCautareInLucru);
            this.panelComenziInLucru.Controls.Add(this.btnActiviInactivi);
            this.panelComenziInLucru.Controls.Add(this.lblNrComenziInLucru);
            this.panelComenziInLucru.Controls.Add(this.btnAdaugaComandaInLucru);
            this.panelComenziInLucru.Controls.Add(this.dgvComenziInLucru);
            this.panelComenziInLucru.Controls.Add(this.lblComenziInLucru);
            this.panelComenziInLucru.Location = new System.Drawing.Point(-1, -2);
            this.panelComenziInLucru.Margin = new System.Windows.Forms.Padding(2);
            this.panelComenziInLucru.Name = "panelComenziInLucru";
            this.panelComenziInLucru.Size = new System.Drawing.Size(667, 248);
            this.panelComenziInLucru.TabIndex = 2;
            this.panelComenziInLucru.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // txtCautareInLucru
            // 
            this.txtCautareInLucru.AcceptButton = null;
            this.txtCautareInLucru.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautareInLucru.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautareInLucru.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautareInLucru.BackColor = System.Drawing.Color.White;
            this.txtCautareInLucru.CapitalizeazaPrimaLitera = false;
            this.txtCautareInLucru.IsInReadOnlyMode = false;
            this.txtCautareInLucru.Location = new System.Drawing.Point(433, 4);
            this.txtCautareInLucru.MaxLength = 32767;
            this.txtCautareInLucru.Multiline = false;
            this.txtCautareInLucru.Name = "txtCautareInLucru";
            this.txtCautareInLucru.ProprietateCorespunzatoare = null;
            this.txtCautareInLucru.RaiseEventLaModificareProgramatica = false;
            this.txtCautareInLucru.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautareInLucru.Size = new System.Drawing.Size(228, 20);
            this.txtCautareInLucru.TabIndex = 5;
            this.txtCautareInLucru.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautareInLucru.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautareInLucru.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautareInLucru.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautareInLucru.UseSystemPasswordChar = false;
            // 
            // btnActiviInactivi
            // 
            this.btnActiviInactivi.ForeColor = System.Drawing.Color.Black;
            this.btnActiviInactivi.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnActiviInactivi.Image = ((System.Drawing.Image)(resources.GetObject("btnActiviInactivi.Image")));
            this.btnActiviInactivi.Location = new System.Drawing.Point(143, 3);
            this.btnActiviInactivi.Name = "btnActiviInactivi";
            this.btnActiviInactivi.Size = new System.Drawing.Size(42, 23);
            this.btnActiviInactivi.TabIndex = 4;
            this.btnActiviInactivi.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.ActiviDezactivati;
            this.btnActiviInactivi.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnActiviInactivi.UseVisualStyleBackColor = true;
            // 
            // lblNrComenziInLucru
            // 
            this.lblNrComenziInLucru.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNrComenziInLucru.AutoSize = true;
            this.lblNrComenziInLucru.Location = new System.Drawing.Point(5, 228);
            this.lblNrComenziInLucru.Name = "lblNrComenziInLucru";
            this.lblNrComenziInLucru.Size = new System.Drawing.Size(92, 13);
            this.lblNrComenziInLucru.TabIndex = 3;
            this.lblNrComenziInLucru.Text = "0 comenzi in lucru";
            this.lblNrComenziInLucru.ToolTipText = null;
            this.lblNrComenziInLucru.ToolTipTitle = null;
            // 
            // btnAdaugaComandaInLucru
            // 
            this.btnAdaugaComandaInLucru.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdaugaComandaInLucru.Image = ((System.Drawing.Image)(resources.GetObject("btnAdaugaComandaInLucru.Image")));
            this.btnAdaugaComandaInLucru.Location = new System.Drawing.Point(99, 3);
            this.btnAdaugaComandaInLucru.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdaugaComandaInLucru.Name = "btnAdaugaComandaInLucru";
            this.btnAdaugaComandaInLucru.Size = new System.Drawing.Size(39, 22);
            this.btnAdaugaComandaInLucru.TabIndex = 2;
            this.btnAdaugaComandaInLucru.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdaugaComandaInLucru.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdaugaComandaInLucru.UseVisualStyleBackColor = true;
            // 
            // dgvComenziInLucru
            // 
            this.dgvComenziInLucru.AllowUserToAddRows = false;
            this.dgvComenziInLucru.AllowUserToDeleteRows = false;
            this.dgvComenziInLucru.AllowUserToResizeRows = false;
            this.dgvComenziInLucru.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvComenziInLucru.BackgroundColor = System.Drawing.Color.White;
            this.dgvComenziInLucru.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvComenziInLucru.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComenziInLucru.HideSelection = true;
            this.dgvComenziInLucru.IsInReadOnlyMode = false;
            this.dgvComenziInLucru.Location = new System.Drawing.Point(-1, 29);
            this.dgvComenziInLucru.Margin = new System.Windows.Forms.Padding(2);
            this.dgvComenziInLucru.MultiSelect = false;
            this.dgvComenziInLucru.Name = "dgvComenziInLucru";
            this.dgvComenziInLucru.ProprietateCorespunzatoare = "";
            this.dgvComenziInLucru.RowHeadersVisible = false;
            this.dgvComenziInLucru.RowTemplate.Height = 24;
            this.dgvComenziInLucru.SeIncarca = false;
            this.dgvComenziInLucru.SelectedText = "";
            this.dgvComenziInLucru.SelectionLength = 0;
            this.dgvComenziInLucru.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComenziInLucru.SelectionStart = 0;
            this.dgvComenziInLucru.Size = new System.Drawing.Size(667, 195);
            this.dgvComenziInLucru.TabIndex = 1;
            // 
            // panelComenziTrecute
            // 
            this.panelComenziTrecute.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelComenziTrecute.AutoScaleDimensions = new System.Drawing.SizeF(0F, 0F);
            this.panelComenziTrecute.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.panelComenziTrecute.BackColor = System.Drawing.Color.White;
            this.panelComenziTrecute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelComenziTrecute.Controls.Add(this.txtCautareTrecute);
            this.panelComenziTrecute.Controls.Add(this.lblNrComenziTrecute);
            this.panelComenziTrecute.Controls.Add(this.dgvComenziTrecute);
            this.panelComenziTrecute.Controls.Add(this.lblComenziTrecute);
            this.panelComenziTrecute.Location = new System.Drawing.Point(-1, 245);
            this.panelComenziTrecute.Margin = new System.Windows.Forms.Padding(2);
            this.panelComenziTrecute.Name = "panelComenziTrecute";
            this.panelComenziTrecute.Size = new System.Drawing.Size(667, 236);
            this.panelComenziTrecute.TabIndex = 3;
            this.panelComenziTrecute.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // txtCautareTrecute
            // 
            this.txtCautareTrecute.AcceptButton = null;
            this.txtCautareTrecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautareTrecute.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautareTrecute.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautareTrecute.BackColor = System.Drawing.Color.White;
            this.txtCautareTrecute.CapitalizeazaPrimaLitera = false;
            this.txtCautareTrecute.IsInReadOnlyMode = false;
            this.txtCautareTrecute.Location = new System.Drawing.Point(433, 5);
            this.txtCautareTrecute.MaxLength = 32767;
            this.txtCautareTrecute.Multiline = false;
            this.txtCautareTrecute.Name = "txtCautareTrecute";
            this.txtCautareTrecute.ProprietateCorespunzatoare = null;
            this.txtCautareTrecute.RaiseEventLaModificareProgramatica = false;
            this.txtCautareTrecute.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautareTrecute.Size = new System.Drawing.Size(228, 20);
            this.txtCautareTrecute.TabIndex = 5;
            this.txtCautareTrecute.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautareTrecute.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautareTrecute.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautareTrecute.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautareTrecute.UseSystemPasswordChar = false;
            // 
            // lblNrComenziTrecute
            // 
            this.lblNrComenziTrecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNrComenziTrecute.AutoSize = true;
            this.lblNrComenziTrecute.Location = new System.Drawing.Point(8, 216);
            this.lblNrComenziTrecute.Name = "lblNrComenziTrecute";
            this.lblNrComenziTrecute.Size = new System.Drawing.Size(91, 13);
            this.lblNrComenziTrecute.TabIndex = 4;
            this.lblNrComenziTrecute.Text = "0 comenzi trecute";
            this.lblNrComenziTrecute.ToolTipText = null;
            this.lblNrComenziTrecute.ToolTipTitle = null;
            // 
            // dgvComenziTrecute
            // 
            this.dgvComenziTrecute.AllowUserToAddRows = false;
            this.dgvComenziTrecute.AllowUserToDeleteRows = false;
            this.dgvComenziTrecute.AllowUserToResizeRows = false;
            this.dgvComenziTrecute.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvComenziTrecute.BackgroundColor = System.Drawing.Color.White;
            this.dgvComenziTrecute.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvComenziTrecute.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComenziTrecute.HideSelection = true;
            this.dgvComenziTrecute.IsInReadOnlyMode = false;
            this.dgvComenziTrecute.Location = new System.Drawing.Point(-1, 29);
            this.dgvComenziTrecute.Margin = new System.Windows.Forms.Padding(2);
            this.dgvComenziTrecute.MultiSelect = false;
            this.dgvComenziTrecute.Name = "dgvComenziTrecute";
            this.dgvComenziTrecute.ProprietateCorespunzatoare = "";
            this.dgvComenziTrecute.RowHeadersVisible = false;
            this.dgvComenziTrecute.RowTemplate.Height = 24;
            this.dgvComenziTrecute.SeIncarca = false;
            this.dgvComenziTrecute.SelectedText = "";
            this.dgvComenziTrecute.SelectionLength = 0;
            this.dgvComenziTrecute.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComenziTrecute.SelectionStart = 0;
            this.dgvComenziTrecute.Size = new System.Drawing.Size(667, 185);
            this.dgvComenziTrecute.TabIndex = 2;
            // 
            // lblComenziTrecute
            // 
            this.lblComenziTrecute.AutoSize = true;
            this.lblComenziTrecute.Location = new System.Drawing.Point(2, 9);
            this.lblComenziTrecute.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblComenziTrecute.Name = "lblComenziTrecute";
            this.lblComenziTrecute.Size = new System.Drawing.Size(52, 13);
            this.lblComenziTrecute.TabIndex = 0;
            this.lblComenziTrecute.Text = "Facturate";
            this.lblComenziTrecute.ToolTipText = null;
            this.lblComenziTrecute.ToolTipTitle = null;
            // 
            // ControlDosarClientComenzi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelComenziTrecute);
            this.Controls.Add(this.panelComenziInLucru);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ControlDosarClientComenzi";
            this.Size = new System.Drawing.Size(665, 480);
            this.panelComenziInLucru.ResumeLayout(false);
            this.panelComenziInLucru.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComenziInLucru)).EndInit();
            this.panelComenziTrecute.ResumeLayout(false);
            this.panelComenziTrecute.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComenziTrecute)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.LabelPersonalizat lblComenziInLucru;
        private CCL.UI.Caramizi.PanelContainerCCL panelComenziInLucru;
        private CCL.UI.Caramizi.PanelContainerCCL panelComenziTrecute;
        private CCL.UI.LabelPersonalizat lblComenziTrecute;
        private CCL.UI.DataGridViewPersonalizat dgvComenziInLucru;
        private CCL.UI.DataGridViewPersonalizat dgvComenziTrecute;
        private CCL.UI.ButtonPersonalizat btnAdaugaComandaInLucru;
        private CCL.UI.LabelPersonalizat lblNrComenziInLucru;
        private CCL.UI.LabelPersonalizat lblNrComenziTrecute;
        private CCL.UI.ButtonPersonalizat btnActiviInactivi;
        private CCL.UI.Caramizi.TextBoxCautare txtCautareInLucru;
        private CCL.UI.Caramizi.TextBoxCautare txtCautareTrecute;
    }
}
