namespace iStomaLab.Setari.Liste.Banci
{
    partial class ControlListaBanci
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlListaBanci));
            this.dgvListaBanci = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.lblBanci = new CCL.UI.LabelPersonalizat(this.components);
            this.lblNrBanci = new CCL.UI.LabelPersonalizat(this.components);
            this.btnAdaugaBanca = new CCL.UI.ButtonPersonalizat(this.components);
            this.txtCautareBanca = new CCL.UI.Caramizi.TextBoxCautare();
            this.btnActivInactiv = new CCL.UI.ButtonPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaBanci)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListaBanci
            // 
            this.dgvListaBanci.AllowUserToAddRows = false;
            this.dgvListaBanci.AllowUserToDeleteRows = false;
            this.dgvListaBanci.AllowUserToResizeRows = false;
            this.dgvListaBanci.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaBanci.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaBanci.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaBanci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaBanci.HideSelection = true;
            this.dgvListaBanci.IsInReadOnlyMode = false;
            this.dgvListaBanci.Location = new System.Drawing.Point(3, 31);
            this.dgvListaBanci.MultiSelect = false;
            this.dgvListaBanci.Name = "dgvListaBanci";
            this.dgvListaBanci.ProprietateCorespunzatoare = "";
            this.dgvListaBanci.RowHeadersVisible = false;
            this.dgvListaBanci.SeIncarca = false;
            this.dgvListaBanci.SelectedText = "";
            this.dgvListaBanci.SelectionLength = 0;
            this.dgvListaBanci.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaBanci.SelectionStart = 0;
            this.dgvListaBanci.Size = new System.Drawing.Size(556, 330);
            this.dgvListaBanci.TabIndex = 1;
            // 
            // lblBanci
            // 
            this.lblBanci.AutoSize = true;
            this.lblBanci.Location = new System.Drawing.Point(4, 10);
            this.lblBanci.Name = "lblBanci";
            this.lblBanci.Size = new System.Drawing.Size(34, 13);
            this.lblBanci.TabIndex = 1;
            this.lblBanci.Text = "Banci";
            this.lblBanci.ToolTipText = null;
            this.lblBanci.ToolTipTitle = null;
            // 
            // lblNrBanci
            // 
            this.lblNrBanci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNrBanci.AutoSize = true;
            this.lblNrBanci.Location = new System.Drawing.Point(4, 366);
            this.lblNrBanci.Name = "lblNrBanci";
            this.lblNrBanci.Size = new System.Drawing.Size(47, 13);
            this.lblNrBanci.TabIndex = 2;
            this.lblNrBanci.Text = "Nr banci";
            this.lblNrBanci.ToolTipText = null;
            this.lblNrBanci.ToolTipTitle = null;
            // 
            // btnAdaugaBanca
            // 
            this.btnAdaugaBanca.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdaugaBanca.Image = ((System.Drawing.Image)(resources.GetObject("btnAdaugaBanca.Image")));
            this.btnAdaugaBanca.Location = new System.Drawing.Point(44, 5);
            this.btnAdaugaBanca.Name = "btnAdaugaBanca";
            this.btnAdaugaBanca.Size = new System.Drawing.Size(42, 23);
            this.btnAdaugaBanca.TabIndex = 3;
            this.btnAdaugaBanca.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdaugaBanca.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdaugaBanca.UseVisualStyleBackColor = true;
            // 
            // txtCautareBanca
            // 
            this.txtCautareBanca.AcceptButton = null;
            this.txtCautareBanca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautareBanca.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautareBanca.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautareBanca.BackColor = System.Drawing.Color.White;
            this.txtCautareBanca.CapitalizeazaPrimaLitera = false;
            this.txtCautareBanca.IsInReadOnlyMode = false;
            this.txtCautareBanca.Location = new System.Drawing.Point(295, 5);
            this.txtCautareBanca.MaxLength = 32767;
            this.txtCautareBanca.Multiline = false;
            this.txtCautareBanca.Name = "txtCautareBanca";
            this.txtCautareBanca.ProprietateCorespunzatoare = null;
            this.txtCautareBanca.RaiseEventLaModificareProgramatica = false;
            this.txtCautareBanca.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautareBanca.Size = new System.Drawing.Size(264, 20);
            this.txtCautareBanca.TabIndex = 0;
            this.txtCautareBanca.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautareBanca.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautareBanca.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautareBanca.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautareBanca.UseSystemPasswordChar = false;
            // 
            // btnActivInactiv
            // 
            this.btnActivInactiv.ForeColor = System.Drawing.Color.Black;
            this.btnActivInactiv.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnActivInactiv.Image = ((System.Drawing.Image)(resources.GetObject("btnActivInactiv.Image")));
            this.btnActivInactiv.Location = new System.Drawing.Point(93, 5);
            this.btnActivInactiv.Name = "btnActivInactiv";
            this.btnActivInactiv.Size = new System.Drawing.Size(42, 23);
            this.btnActivInactiv.TabIndex = 5;
            this.btnActivInactiv.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.ActiviDezactivati;
            this.btnActivInactiv.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnActivInactiv.UseVisualStyleBackColor = true;
            // 
            // ControlListaBanci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnActivInactiv);
            this.Controls.Add(this.txtCautareBanca);
            this.Controls.Add(this.btnAdaugaBanca);
            this.Controls.Add(this.lblNrBanci);
            this.Controls.Add(this.lblBanci);
            this.Controls.Add(this.dgvListaBanci);
            this.Name = "ControlListaBanci";
            this.Size = new System.Drawing.Size(562, 384);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaBanci)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.DataGridViewPersonalizat dgvListaBanci;
        private CCL.UI.LabelPersonalizat lblBanci;
        private CCL.UI.LabelPersonalizat lblNrBanci;
        private CCL.UI.ButtonPersonalizat btnAdaugaBanca;
        private CCL.UI.Caramizi.TextBoxCautare txtCautareBanca;
        private CCL.UI.ButtonPersonalizat btnActivInactiv;
    }
}
