namespace iStomaLab.TablouDeBord.Clienti
{
    partial class ControlDosarClientCabinete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlDosarClientCabinete));
            this.lblCabinete = new CCL.UI.LabelPersonalizat(this.components);
            this.txtCautaCabinet = new CCL.UI.Caramizi.TextBoxCautare();
            this.dgvListaCabinete = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.lblNrCabinete = new CCL.UI.LabelPersonalizat(this.components);
            this.btnAdaugaCabinet = new CCL.UI.ButtonPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaCabinete)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCabinete
            // 
            this.lblCabinete.AutoSize = true;
            this.lblCabinete.Location = new System.Drawing.Point(4, 11);
            this.lblCabinete.Name = "lblCabinete";
            this.lblCabinete.Size = new System.Drawing.Size(49, 13);
            this.lblCabinete.TabIndex = 0;
            this.lblCabinete.Text = "Cabinete";
            this.lblCabinete.ToolTipText = null;
            this.lblCabinete.ToolTipTitle = null;
            // 
            // txtCautaCabinet
            // 
            this.txtCautaCabinet.AcceptButton = null;
            this.txtCautaCabinet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautaCabinet.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautaCabinet.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautaCabinet.BackColor = System.Drawing.Color.White;
            this.txtCautaCabinet.CapitalizeazaPrimaLitera = false;
            this.txtCautaCabinet.IsInReadOnlyMode = false;
            this.txtCautaCabinet.Location = new System.Drawing.Point(253, 7);
            this.txtCautaCabinet.MaxLength = 32767;
            this.txtCautaCabinet.Multiline = false;
            this.txtCautaCabinet.Name = "txtCautaCabinet";
            this.txtCautaCabinet.ProprietateCorespunzatoare = null;
            this.txtCautaCabinet.RaiseEventLaModificareProgramatica = false;
            this.txtCautaCabinet.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautaCabinet.Size = new System.Drawing.Size(417, 20);
            this.txtCautaCabinet.TabIndex = 1;
            this.txtCautaCabinet.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautaCabinet.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautaCabinet.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautaCabinet.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautaCabinet.UseSystemPasswordChar = false;
            // 
            // dgvListaCabinete
            // 
            this.dgvListaCabinete.AllowUserToAddRows = false;
            this.dgvListaCabinete.AllowUserToDeleteRows = false;
            this.dgvListaCabinete.AllowUserToResizeRows = false;
            this.dgvListaCabinete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaCabinete.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaCabinete.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaCabinete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaCabinete.HideSelection = true;
            this.dgvListaCabinete.IsInReadOnlyMode = false;
            this.dgvListaCabinete.Location = new System.Drawing.Point(2, 34);
            this.dgvListaCabinete.MultiSelect = false;
            this.dgvListaCabinete.Name = "dgvListaCabinete";
            this.dgvListaCabinete.ProprietateCorespunzatoare = "";
            this.dgvListaCabinete.RowHeadersVisible = false;
            this.dgvListaCabinete.SeIncarca = false;
            this.dgvListaCabinete.SelectedText = "";
            this.dgvListaCabinete.SelectionLength = 0;
            this.dgvListaCabinete.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaCabinete.SelectionStart = 0;
            this.dgvListaCabinete.Size = new System.Drawing.Size(668, 371);
            this.dgvListaCabinete.TabIndex = 2;
            // 
            // lblNrCabinete
            // 
            this.lblNrCabinete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNrCabinete.AutoSize = true;
            this.lblNrCabinete.Location = new System.Drawing.Point(7, 410);
            this.lblNrCabinete.Name = "lblNrCabinete";
            this.lblNrCabinete.Size = new System.Drawing.Size(65, 13);
            this.lblNrCabinete.TabIndex = 3;
            this.lblNrCabinete.Text = "Nr. cabinete";
            this.lblNrCabinete.ToolTipText = null;
            this.lblNrCabinete.ToolTipTitle = null;
            // 
            // btnAdaugaCabinet
            // 
            this.btnAdaugaCabinet.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdaugaCabinet.Image = ((System.Drawing.Image)(resources.GetObject("btnAdaugaCabinet.Image")));
            this.btnAdaugaCabinet.Location = new System.Drawing.Point(55, 6);
            this.btnAdaugaCabinet.Name = "btnAdaugaCabinet";
            this.btnAdaugaCabinet.Size = new System.Drawing.Size(43, 23);
            this.btnAdaugaCabinet.TabIndex = 4;
            this.btnAdaugaCabinet.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdaugaCabinet.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdaugaCabinet.UseVisualStyleBackColor = true;
            // 
            // ControlDosarClientCabinete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAdaugaCabinet);
            this.Controls.Add(this.lblNrCabinete);
            this.Controls.Add(this.dgvListaCabinete);
            this.Controls.Add(this.txtCautaCabinet);
            this.Controls.Add(this.lblCabinete);
            this.Name = "ControlDosarClientCabinete";
            this.Size = new System.Drawing.Size(673, 428);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaCabinete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.LabelPersonalizat lblCabinete;
        private CCL.UI.Caramizi.TextBoxCautare txtCautaCabinet;
        private CCL.UI.DataGridViewPersonalizat dgvListaCabinete;
        private CCL.UI.LabelPersonalizat lblNrCabinete;
        private CCL.UI.ButtonPersonalizat btnAdaugaCabinet;
    }
}
