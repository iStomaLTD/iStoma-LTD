namespace iStomaLab.TablouDeBord.Clienti
{
    partial class ControlDosarClientReprezentanti
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlDosarClientReprezentanti));
            this.lblReprezentanti = new CCL.UI.LabelPersonalizat(this.components);
            this.btnAdaugaReprezentant = new CCL.UI.ButtonPersonalizat(this.components);
            this.dgvListaReprezentanti = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.lblTotalReprezentanti = new CCL.UI.LabelPersonalizat(this.components);
            this.txtCautaReprezentant = new CCL.UI.Caramizi.TextBoxCautare();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaReprezentanti)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReprezentanti
            // 
            this.lblReprezentanti.AutoSize = true;
            this.lblReprezentanti.Location = new System.Drawing.Point(2, 11);
            this.lblReprezentanti.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReprezentanti.Name = "lblReprezentanti";
            this.lblReprezentanti.Size = new System.Drawing.Size(73, 13);
            this.lblReprezentanti.TabIndex = 0;
            this.lblReprezentanti.Text = "Reprezentanti";
            this.lblReprezentanti.ToolTipText = null;
            this.lblReprezentanti.ToolTipTitle = null;
            // 
            // btnAdaugaReprezentant
            // 
            this.btnAdaugaReprezentant.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdaugaReprezentant.Image = ((System.Drawing.Image)(resources.GetObject("btnAdaugaReprezentant.Image")));
            this.btnAdaugaReprezentant.Location = new System.Drawing.Point(79, 5);
            this.btnAdaugaReprezentant.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdaugaReprezentant.Name = "btnAdaugaReprezentant";
            this.btnAdaugaReprezentant.Size = new System.Drawing.Size(35, 24);
            this.btnAdaugaReprezentant.TabIndex = 1;
            this.btnAdaugaReprezentant.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdaugaReprezentant.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdaugaReprezentant.UseVisualStyleBackColor = true;
            // 
            // dgvListaReprezentanti
            // 
            this.dgvListaReprezentanti.AllowUserToAddRows = false;
            this.dgvListaReprezentanti.AllowUserToDeleteRows = false;
            this.dgvListaReprezentanti.AllowUserToResizeRows = false;
            this.dgvListaReprezentanti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaReprezentanti.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaReprezentanti.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaReprezentanti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaReprezentanti.HideSelection = true;
            this.dgvListaReprezentanti.IsInReadOnlyMode = false;
            this.dgvListaReprezentanti.Location = new System.Drawing.Point(1, 35);
            this.dgvListaReprezentanti.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvListaReprezentanti.MultiSelect = false;
            this.dgvListaReprezentanti.Name = "dgvListaReprezentanti";
            this.dgvListaReprezentanti.ProprietateCorespunzatoare = "";
            this.dgvListaReprezentanti.RowHeadersVisible = false;
            this.dgvListaReprezentanti.RowTemplate.Height = 24;
            this.dgvListaReprezentanti.SeIncarca = false;
            this.dgvListaReprezentanti.SelectedText = "";
            this.dgvListaReprezentanti.SelectionLength = 0;
            this.dgvListaReprezentanti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaReprezentanti.SelectionStart = 0;
            this.dgvListaReprezentanti.Size = new System.Drawing.Size(610, 396);
            this.dgvListaReprezentanti.TabIndex = 3;
            // 
            // lblTotalReprezentanti
            // 
            this.lblTotalReprezentanti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalReprezentanti.AutoSize = true;
            this.lblTotalReprezentanti.Location = new System.Drawing.Point(15, 435);
            this.lblTotalReprezentanti.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalReprezentanti.Name = "lblTotalReprezentanti";
            this.lblTotalReprezentanti.Size = new System.Drawing.Size(31, 13);
            this.lblTotalReprezentanti.TabIndex = 4;
            this.lblTotalReprezentanti.Text = "Total";
            this.lblTotalReprezentanti.ToolTipText = null;
            this.lblTotalReprezentanti.ToolTipTitle = null;
            // 
            // txtCautaReprezentant
            // 
            this.txtCautaReprezentant.AcceptButton = null;
            this.txtCautaReprezentant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautaReprezentant.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautaReprezentant.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautaReprezentant.CapitalizeazaPrimaLitera = false;
            this.txtCautaReprezentant.IsInReadOnlyMode = false;
            this.txtCautaReprezentant.Location = new System.Drawing.Point(285, 7);
            this.txtCautaReprezentant.MaxLength = 32767;
            this.txtCautaReprezentant.Multiline = false;
            this.txtCautaReprezentant.Name = "txtCautaReprezentant";
            this.txtCautaReprezentant.ProprietateCorespunzatoare = null;
            this.txtCautaReprezentant.RaiseEventLaModificareProgramatica = false;
            this.txtCautaReprezentant.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautaReprezentant.Size = new System.Drawing.Size(324, 20);
            this.txtCautaReprezentant.TabIndex = 5;
            this.txtCautaReprezentant.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautaReprezentant.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautaReprezentant.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautaReprezentant.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautaReprezentant.UseSystemPasswordChar = false;
            // 
            // ControlDosarClientReprezentanti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCautaReprezentant);
            this.Controls.Add(this.lblTotalReprezentanti);
            this.Controls.Add(this.dgvListaReprezentanti);
            this.Controls.Add(this.btnAdaugaReprezentant);
            this.Controls.Add(this.lblReprezentanti);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ControlDosarClientReprezentanti";
            this.Size = new System.Drawing.Size(612, 454);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaReprezentanti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.LabelPersonalizat lblReprezentanti;
        private CCL.UI.ButtonPersonalizat btnAdaugaReprezentant;
        private CCL.UI.DataGridViewPersonalizat dgvListaReprezentanti;
        private CCL.UI.LabelPersonalizat lblTotalReprezentanti;
        private CCL.UI.Caramizi.TextBoxCautare txtCautaReprezentant;
    }
}
