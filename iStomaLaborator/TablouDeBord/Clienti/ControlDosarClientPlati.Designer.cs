namespace iStomaLab.TablouDeBord.Clienti
{
    partial class ControlDosarClientPlati
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlDosarClientPlati));
            this.panelPlatiIncasari = new CCL.UI.Caramizi.PanelContainerCCL();
            this.lblPlatiTotalIncasari = new CCL.UI.LabelPersonalizat(this.components);
            this.buttonPersonalizat2 = new CCL.UI.ButtonPersonalizat(this.components);
            this.dgvPlatiIncasari = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.lblPlatiIncasari = new CCL.UI.LabelPersonalizat(this.components);
            this.panelPlatiFacturi = new CCL.UI.Caramizi.PanelContainerCCL();
            this.lblPlatiTotalFacturi = new CCL.UI.LabelPersonalizat(this.components);
            this.btnAdaugaFactura = new CCL.UI.ButtonPersonalizat(this.components);
            this.dgvPlatiFacturi = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.lblPlatiFacturi = new CCL.UI.LabelPersonalizat(this.components);
            this.panelPlatiIncasari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlatiIncasari)).BeginInit();
            this.panelPlatiFacturi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlatiFacturi)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPlatiIncasari
            // 
            this.panelPlatiIncasari.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPlatiIncasari.AutoScaleDimensions = new System.Drawing.SizeF(0F, 0F);
            this.panelPlatiIncasari.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.panelPlatiIncasari.BackColor = System.Drawing.Color.White;
            this.panelPlatiIncasari.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPlatiIncasari.Controls.Add(this.lblPlatiTotalIncasari);
            this.panelPlatiIncasari.Controls.Add(this.buttonPersonalizat2);
            this.panelPlatiIncasari.Controls.Add(this.dgvPlatiIncasari);
            this.panelPlatiIncasari.Controls.Add(this.lblPlatiIncasari);
            this.panelPlatiIncasari.Location = new System.Drawing.Point(-1, 326);
            this.panelPlatiIncasari.Name = "panelPlatiIncasari";
            this.panelPlatiIncasari.Size = new System.Drawing.Size(754, 321);
            this.panelPlatiIncasari.TabIndex = 5;
            this.panelPlatiIncasari.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // lblPlatiTotalIncasari
            // 
            this.lblPlatiTotalIncasari.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPlatiTotalIncasari.AutoSize = true;
            this.lblPlatiTotalIncasari.Location = new System.Drawing.Point(7, 296);
            this.lblPlatiTotalIncasari.Name = "lblPlatiTotalIncasari";
            this.lblPlatiTotalIncasari.Size = new System.Drawing.Size(93, 17);
            this.lblPlatiTotalIncasari.TabIndex = 4;
            this.lblPlatiTotalIncasari.Text = "Total incasari";
            this.lblPlatiTotalIncasari.ToolTipText = null;
            this.lblPlatiTotalIncasari.ToolTipTitle = null;
            // 
            // buttonPersonalizat2
            // 
            this.buttonPersonalizat2.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.buttonPersonalizat2.Image = ((System.Drawing.Image)(resources.GetObject("buttonPersonalizat2.Image")));
            this.buttonPersonalizat2.Location = new System.Drawing.Point(60, 6);
            this.buttonPersonalizat2.Name = "buttonPersonalizat2";
            this.buttonPersonalizat2.Size = new System.Drawing.Size(54, 23);
            this.buttonPersonalizat2.TabIndex = 3;
            this.buttonPersonalizat2.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.buttonPersonalizat2.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.buttonPersonalizat2.UseVisualStyleBackColor = true;
            // 
            // dgvPlatiIncasari
            // 
            this.dgvPlatiIncasari.AllowUserToAddRows = false;
            this.dgvPlatiIncasari.AllowUserToDeleteRows = false;
            this.dgvPlatiIncasari.AllowUserToResizeRows = false;
            this.dgvPlatiIncasari.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPlatiIncasari.BackgroundColor = System.Drawing.Color.White;
            this.dgvPlatiIncasari.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPlatiIncasari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlatiIncasari.HideSelection = true;
            this.dgvPlatiIncasari.IsInReadOnlyMode = false;
            this.dgvPlatiIncasari.Location = new System.Drawing.Point(4, 37);
            this.dgvPlatiIncasari.MultiSelect = false;
            this.dgvPlatiIncasari.Name = "dgvPlatiIncasari";
            this.dgvPlatiIncasari.ProprietateCorespunzatoare = "";
            this.dgvPlatiIncasari.RowHeadersVisible = false;
            this.dgvPlatiIncasari.RowTemplate.Height = 24;
            this.dgvPlatiIncasari.SeIncarca = false;
            this.dgvPlatiIncasari.SelectedText = "";
            this.dgvPlatiIncasari.SelectionLength = 0;
            this.dgvPlatiIncasari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlatiIncasari.SelectionStart = 0;
            this.dgvPlatiIncasari.Size = new System.Drawing.Size(742, 257);
            this.dgvPlatiIncasari.TabIndex = 2;
            // 
            // lblPlatiIncasari
            // 
            this.lblPlatiIncasari.AutoSize = true;
            this.lblPlatiIncasari.Location = new System.Drawing.Point(3, 9);
            this.lblPlatiIncasari.Name = "lblPlatiIncasari";
            this.lblPlatiIncasari.Size = new System.Drawing.Size(57, 17);
            this.lblPlatiIncasari.TabIndex = 0;
            this.lblPlatiIncasari.Text = "Incasari";
            this.lblPlatiIncasari.ToolTipText = null;
            this.lblPlatiIncasari.ToolTipTitle = null;
            // 
            // panelPlatiFacturi
            // 
            this.panelPlatiFacturi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPlatiFacturi.AutoScaleDimensions = new System.Drawing.SizeF(0F, 0F);
            this.panelPlatiFacturi.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.panelPlatiFacturi.BackColor = System.Drawing.Color.White;
            this.panelPlatiFacturi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPlatiFacturi.Controls.Add(this.lblPlatiTotalFacturi);
            this.panelPlatiFacturi.Controls.Add(this.btnAdaugaFactura);
            this.panelPlatiFacturi.Controls.Add(this.dgvPlatiFacturi);
            this.panelPlatiFacturi.Controls.Add(this.lblPlatiFacturi);
            this.panelPlatiFacturi.Location = new System.Drawing.Point(-1, -1);
            this.panelPlatiFacturi.Name = "panelPlatiFacturi";
            this.panelPlatiFacturi.Size = new System.Drawing.Size(754, 321);
            this.panelPlatiFacturi.TabIndex = 4;
            this.panelPlatiFacturi.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // lblPlatiTotalFacturi
            // 
            this.lblPlatiTotalFacturi.AutoSize = true;
            this.lblPlatiTotalFacturi.Location = new System.Drawing.Point(7, 301);
            this.lblPlatiTotalFacturi.Name = "lblPlatiTotalFacturi";
            this.lblPlatiTotalFacturi.Size = new System.Drawing.Size(83, 17);
            this.lblPlatiTotalFacturi.TabIndex = 3;
            this.lblPlatiTotalFacturi.Text = "Total facturi";
            this.lblPlatiTotalFacturi.ToolTipText = null;
            this.lblPlatiTotalFacturi.ToolTipTitle = null;
            // 
            // btnAdaugaFactura
            // 
            this.btnAdaugaFactura.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdaugaFactura.Image = ((System.Drawing.Image)(resources.GetObject("btnAdaugaFactura.Image")));
            this.btnAdaugaFactura.Location = new System.Drawing.Point(61, 4);
            this.btnAdaugaFactura.Name = "btnAdaugaFactura";
            this.btnAdaugaFactura.Size = new System.Drawing.Size(54, 23);
            this.btnAdaugaFactura.TabIndex = 2;
            this.btnAdaugaFactura.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdaugaFactura.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdaugaFactura.UseVisualStyleBackColor = true;
            // 
            // dgvPlatiFacturi
            // 
            this.dgvPlatiFacturi.AllowUserToAddRows = false;
            this.dgvPlatiFacturi.AllowUserToDeleteRows = false;
            this.dgvPlatiFacturi.AllowUserToResizeRows = false;
            this.dgvPlatiFacturi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPlatiFacturi.BackgroundColor = System.Drawing.Color.White;
            this.dgvPlatiFacturi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPlatiFacturi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlatiFacturi.HideSelection = true;
            this.dgvPlatiFacturi.IsInReadOnlyMode = false;
            this.dgvPlatiFacturi.Location = new System.Drawing.Point(4, 34);
            this.dgvPlatiFacturi.MultiSelect = false;
            this.dgvPlatiFacturi.Name = "dgvPlatiFacturi";
            this.dgvPlatiFacturi.ProprietateCorespunzatoare = "";
            this.dgvPlatiFacturi.RowHeadersVisible = false;
            this.dgvPlatiFacturi.RowTemplate.Height = 24;
            this.dgvPlatiFacturi.SeIncarca = false;
            this.dgvPlatiFacturi.SelectedText = "";
            this.dgvPlatiFacturi.SelectionLength = 0;
            this.dgvPlatiFacturi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlatiFacturi.SelectionStart = 0;
            this.dgvPlatiFacturi.Size = new System.Drawing.Size(743, 265);
            this.dgvPlatiFacturi.TabIndex = 1;
            // 
            // lblPlatiFacturi
            // 
            this.lblPlatiFacturi.AutoSize = true;
            this.lblPlatiFacturi.Location = new System.Drawing.Point(7, 7);
            this.lblPlatiFacturi.Name = "lblPlatiFacturi";
            this.lblPlatiFacturi.Size = new System.Drawing.Size(51, 17);
            this.lblPlatiFacturi.TabIndex = 0;
            this.lblPlatiFacturi.Text = "Facturi";
            this.lblPlatiFacturi.ToolTipText = null;
            this.lblPlatiFacturi.ToolTipTitle = null;
            // 
            // ControlDosarClientPlati
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelPlatiIncasari);
            this.Controls.Add(this.panelPlatiFacturi);
            this.Name = "ControlDosarClientPlati";
            this.Size = new System.Drawing.Size(752, 643);
            this.panelPlatiIncasari.ResumeLayout(false);
            this.panelPlatiIncasari.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlatiIncasari)).EndInit();
            this.panelPlatiFacturi.ResumeLayout(false);
            this.panelPlatiFacturi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlatiFacturi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.Caramizi.PanelContainerCCL panelPlatiIncasari;
        private CCL.UI.DataGridViewPersonalizat dgvPlatiIncasari;
        private CCL.UI.LabelPersonalizat lblPlatiIncasari;
        private CCL.UI.Caramizi.PanelContainerCCL panelPlatiFacturi;
        private CCL.UI.DataGridViewPersonalizat dgvPlatiFacturi;
        private CCL.UI.LabelPersonalizat lblPlatiFacturi;
        private CCL.UI.ButtonPersonalizat buttonPersonalizat2;
        private CCL.UI.ButtonPersonalizat btnAdaugaFactura;
        private CCL.UI.LabelPersonalizat lblPlatiTotalIncasari;
        private CCL.UI.LabelPersonalizat lblPlatiTotalFacturi;
    }
}
