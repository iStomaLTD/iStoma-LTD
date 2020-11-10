namespace iStomaLab.Setari.Lucrari
{
    partial class ControlEtape
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlEtape));
            this.btnAdaugareEtapa = new CCL.UI.ButtonPersonalizat(this.components);
            this.dgvListaEtape = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.lblEtape = new CCL.UI.LabelPersonalizat(this.components);
            this.txtCautaEtapa = new CCL.UI.Caramizi.TextBoxCautare();
            this.lblTotalEtape = new CCL.UI.LabelPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaEtape)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdaugareEtapa
            // 
            this.btnAdaugareEtapa.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdaugareEtapa.Image = ((System.Drawing.Image)(resources.GetObject("btnAdaugareEtapa.Image")));
            this.btnAdaugareEtapa.Location = new System.Drawing.Point(50, 11);
            this.btnAdaugareEtapa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdaugareEtapa.Name = "btnAdaugareEtapa";
            this.btnAdaugareEtapa.Size = new System.Drawing.Size(40, 19);
            this.btnAdaugareEtapa.TabIndex = 0;
            this.btnAdaugareEtapa.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdaugareEtapa.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdaugareEtapa.UseVisualStyleBackColor = true;
            // 
            // dgvListaEtape
            // 
            this.dgvListaEtape.AllowUserToAddRows = false;
            this.dgvListaEtape.AllowUserToDeleteRows = false;
            this.dgvListaEtape.AllowUserToResizeRows = false;
            this.dgvListaEtape.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaEtape.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaEtape.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaEtape.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaEtape.HideSelection = true;
            this.dgvListaEtape.IsInReadOnlyMode = false;
            this.dgvListaEtape.Location = new System.Drawing.Point(1, 34);
            this.dgvListaEtape.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvListaEtape.MultiSelect = false;
            this.dgvListaEtape.Name = "dgvListaEtape";
            this.dgvListaEtape.ProprietateCorespunzatoare = "";
            this.dgvListaEtape.RowHeadersVisible = false;
            this.dgvListaEtape.RowTemplate.Height = 24;
            this.dgvListaEtape.SeIncarca = false;
            this.dgvListaEtape.SelectedText = "";
            this.dgvListaEtape.SelectionLength = 0;
            this.dgvListaEtape.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaEtape.SelectionStart = 0;
            this.dgvListaEtape.Size = new System.Drawing.Size(516, 382);
            this.dgvListaEtape.TabIndex = 1;
            // 
            // lblEtape
            // 
            this.lblEtape.AutoSize = true;
            this.lblEtape.Location = new System.Drawing.Point(11, 13);
            this.lblEtape.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEtape.Name = "lblEtape";
            this.lblEtape.Size = new System.Drawing.Size(35, 13);
            this.lblEtape.TabIndex = 2;
            this.lblEtape.Text = "Etape";
            this.lblEtape.ToolTipText = null;
            this.lblEtape.ToolTipTitle = null;
            // 
            // txtCautaEtapa
            // 
            this.txtCautaEtapa.AcceptButton = null;
            this.txtCautaEtapa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautaEtapa.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautaEtapa.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautaEtapa.BackColor = System.Drawing.Color.White;
            this.txtCautaEtapa.CapitalizeazaPrimaLitera = false;
            this.txtCautaEtapa.IsInReadOnlyMode = false;
            this.txtCautaEtapa.Location = new System.Drawing.Point(216, 10);
            this.txtCautaEtapa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCautaEtapa.MaxLength = 32767;
            this.txtCautaEtapa.Multiline = false;
            this.txtCautaEtapa.Name = "txtCautaEtapa";
            this.txtCautaEtapa.ProprietateCorespunzatoare = null;
            this.txtCautaEtapa.RaiseEventLaModificareProgramatica = false;
            this.txtCautaEtapa.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautaEtapa.Size = new System.Drawing.Size(297, 20);
            this.txtCautaEtapa.TabIndex = 3;
            this.txtCautaEtapa.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautaEtapa.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautaEtapa.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautaEtapa.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautaEtapa.UseSystemPasswordChar = false;
            // 
            // lblTotalEtape
            // 
            this.lblTotalEtape.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalEtape.AutoSize = true;
            this.lblTotalEtape.Location = new System.Drawing.Point(11, 419);
            this.lblTotalEtape.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalEtape.Name = "lblTotalEtape";
            this.lblTotalEtape.Size = new System.Drawing.Size(43, 13);
            this.lblTotalEtape.TabIndex = 4;
            this.lblTotalEtape.Text = "0 etape";
            this.lblTotalEtape.ToolTipText = null;
            this.lblTotalEtape.ToolTipTitle = null;
            // 
            // ControlEtape
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTotalEtape);
            this.Controls.Add(this.txtCautaEtapa);
            this.Controls.Add(this.lblEtape);
            this.Controls.Add(this.dgvListaEtape);
            this.Controls.Add(this.btnAdaugareEtapa);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ControlEtape";
            this.Size = new System.Drawing.Size(518, 440);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaEtape)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.ButtonPersonalizat btnAdaugareEtapa;
        private CCL.UI.DataGridViewPersonalizat dgvListaEtape;
        private CCL.UI.LabelPersonalizat lblEtape;
        private CCL.UI.Caramizi.TextBoxCautare txtCautaEtapa;
        private CCL.UI.LabelPersonalizat lblTotalEtape;
    }
}
