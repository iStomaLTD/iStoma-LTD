namespace iStomaLab.Setari.Locatii
{
    partial class ControlListaLocatii
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlListaLocatii));
            this.btnAdaugaLocatie = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblTotalLocatii = new CCL.UI.LabelPersonalizat(this.components);
            this.dgvListaLocatii = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.lblTitluListaLocatii = new CCL.UI.LabelPersonalizat(this.components);
            this.txtCautaLocatie = new CCL.UI.Caramizi.TextBoxCautare();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaLocatii)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdaugaLocatie
            // 
            this.btnAdaugaLocatie.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdaugaLocatie.Image = ((System.Drawing.Image)(resources.GetObject("btnAdaugaLocatie.Image")));
            this.btnAdaugaLocatie.Location = new System.Drawing.Point(68, 8);
            this.btnAdaugaLocatie.Name = "btnAdaugaLocatie";
            this.btnAdaugaLocatie.Size = new System.Drawing.Size(38, 23);
            this.btnAdaugaLocatie.TabIndex = 4;
            this.btnAdaugaLocatie.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdaugaLocatie.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdaugaLocatie.UseVisualStyleBackColor = true;
            // 
            // lblTotalLocatii
            // 
            this.lblTotalLocatii.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalLocatii.AutoSize = true;
            this.lblTotalLocatii.Location = new System.Drawing.Point(16, 431);
            this.lblTotalLocatii.Name = "lblTotalLocatii";
            this.lblTotalLocatii.Size = new System.Drawing.Size(31, 13);
            this.lblTotalLocatii.TabIndex = 3;
            this.lblTotalLocatii.Text = "Total";
            this.lblTotalLocatii.ToolTipText = null;
            this.lblTotalLocatii.ToolTipTitle = null;
            // 
            // dgvListaLocatii
            // 
            this.dgvListaLocatii.AllowUserToAddRows = false;
            this.dgvListaLocatii.AllowUserToDeleteRows = false;
            this.dgvListaLocatii.AllowUserToResizeRows = false;
            this.dgvListaLocatii.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaLocatii.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaLocatii.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaLocatii.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaLocatii.HideSelection = true;
            this.dgvListaLocatii.IsInReadOnlyMode = false;
            this.dgvListaLocatii.Location = new System.Drawing.Point(1, 36);
            this.dgvListaLocatii.MultiSelect = false;
            this.dgvListaLocatii.Name = "dgvListaLocatii";
            this.dgvListaLocatii.ProprietateCorespunzatoare = "";
            this.dgvListaLocatii.RowHeadersVisible = false;
            this.dgvListaLocatii.RowTemplate.Height = 24;
            this.dgvListaLocatii.SeIncarca = false;
            this.dgvListaLocatii.SelectedText = "";
            this.dgvListaLocatii.SelectionLength = 0;
            this.dgvListaLocatii.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaLocatii.SelectionStart = 0;
            this.dgvListaLocatii.Size = new System.Drawing.Size(628, 391);
            this.dgvListaLocatii.TabIndex = 2;
            // 
            // lblTitluListaLocatii
            // 
            this.lblTitluListaLocatii.AutoSize = true;
            this.lblTitluListaLocatii.Location = new System.Drawing.Point(3, 13);
            this.lblTitluListaLocatii.Name = "lblTitluListaLocatii";
            this.lblTitluListaLocatii.Size = new System.Drawing.Size(59, 13);
            this.lblTitluListaLocatii.TabIndex = 0;
            this.lblTitluListaLocatii.Text = "Lista locatii";
            this.lblTitluListaLocatii.ToolTipText = null;
            this.lblTitluListaLocatii.ToolTipTitle = null;
            // 
            // txtCautaLocatie
            // 
            this.txtCautaLocatie.AcceptButton = null;
            this.txtCautaLocatie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautaLocatie.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautaLocatie.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautaLocatie.BackColor = System.Drawing.Color.Transparent;
            this.txtCautaLocatie.CapitalizeazaPrimaLitera = false;
            this.txtCautaLocatie.IsInReadOnlyMode = false;
            this.txtCautaLocatie.Location = new System.Drawing.Point(320, 7);
            this.txtCautaLocatie.MaxLength = 32767;
            this.txtCautaLocatie.Multiline = false;
            this.txtCautaLocatie.Name = "txtCautaLocatie";
            this.txtCautaLocatie.ProprietateCorespunzatoare = null;
            this.txtCautaLocatie.RaiseEventLaModificareProgramatica = false;
            this.txtCautaLocatie.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautaLocatie.Size = new System.Drawing.Size(302, 25);
            this.txtCautaLocatie.TabIndex = 7;
            this.txtCautaLocatie.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautaLocatie.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautaLocatie.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautaLocatie.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautaLocatie.UseSystemPasswordChar = false;
            // 
            // ControlListaLocatii
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.txtCautaLocatie);
            this.Controls.Add(this.btnAdaugaLocatie);
            this.Controls.Add(this.lblTotalLocatii);
            this.Controls.Add(this.dgvListaLocatii);
            this.Controls.Add(this.lblTitluListaLocatii);
            this.Name = "ControlListaLocatii";
            this.Size = new System.Drawing.Size(629, 450);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaLocatii)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.LabelPersonalizat lblTitluListaLocatii;
        private CCL.UI.DataGridViewPersonalizat dgvListaLocatii;
        private CCL.UI.LabelPersonalizat lblTotalLocatii;
        private CCL.UI.ButtonPersonalizat btnAdaugaLocatie;
        private CCL.UI.Caramizi.TextBoxCautare txtCautaLocatie;
    }
}
