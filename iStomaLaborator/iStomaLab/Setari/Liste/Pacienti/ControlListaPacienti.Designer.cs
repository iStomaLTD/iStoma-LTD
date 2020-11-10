namespace iStomaLab.Setari.Liste.Pacienti
{
    partial class ControlListaPacienti
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlListaPacienti));
            this.dgvListaPacienti = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.lblPacienti = new CCL.UI.LabelPersonalizat(this.components);
            this.lblNrPacienti = new CCL.UI.LabelPersonalizat(this.components);
            this.btnAdaugaPacienti = new CCL.UI.ButtonPersonalizat(this.components);
            this.txtCautarePacienti = new CCL.UI.Caramizi.TextBoxCautare();
            this.btnActivInactiv = new CCL.UI.ButtonPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPacienti)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListaPacienti
            // 
            this.dgvListaPacienti.AllowUserToAddRows = false;
            this.dgvListaPacienti.AllowUserToDeleteRows = false;
            this.dgvListaPacienti.AllowUserToResizeRows = false;
            this.dgvListaPacienti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaPacienti.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaPacienti.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaPacienti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaPacienti.HideSelection = true;
            this.dgvListaPacienti.IsInReadOnlyMode = false;
            this.dgvListaPacienti.Location = new System.Drawing.Point(3, 31);
            this.dgvListaPacienti.MultiSelect = false;
            this.dgvListaPacienti.Name = "dgvListaPacienti";
            this.dgvListaPacienti.ProprietateCorespunzatoare = "";
            this.dgvListaPacienti.RowHeadersVisible = false;
            this.dgvListaPacienti.SeIncarca = false;
            this.dgvListaPacienti.SelectedText = "";
            this.dgvListaPacienti.SelectionLength = 0;
            this.dgvListaPacienti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaPacienti.SelectionStart = 0;
            this.dgvListaPacienti.Size = new System.Drawing.Size(587, 285);
            this.dgvListaPacienti.TabIndex = 1;
            // 
            // lblPacienti
            // 
            this.lblPacienti.AutoSize = true;
            this.lblPacienti.Location = new System.Drawing.Point(4, 10);
            this.lblPacienti.Name = "lblPacienti";
            this.lblPacienti.Size = new System.Drawing.Size(43, 13);
            this.lblPacienti.TabIndex = 1;
            this.lblPacienti.Text = "Pacient";
            this.lblPacienti.ToolTipText = null;
            this.lblPacienti.ToolTipTitle = null;
            // 
            // lblNrPacienti
            // 
            this.lblNrPacienti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNrPacienti.AutoSize = true;
            this.lblNrPacienti.Location = new System.Drawing.Point(3, 318);
            this.lblNrPacienti.Name = "lblNrPacienti";
            this.lblNrPacienti.Size = new System.Drawing.Size(58, 13);
            this.lblNrPacienti.TabIndex = 2;
            this.lblNrPacienti.Text = "Nr.pacienti";
            this.lblNrPacienti.ToolTipText = null;
            this.lblNrPacienti.ToolTipTitle = null;
            // 
            // btnAdaugaPacienti
            // 
            this.btnAdaugaPacienti.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdaugaPacienti.Image = ((System.Drawing.Image)(resources.GetObject("btnAdaugaPacienti.Image")));
            this.btnAdaugaPacienti.Location = new System.Drawing.Point(46, 5);
            this.btnAdaugaPacienti.Name = "btnAdaugaPacienti";
            this.btnAdaugaPacienti.Size = new System.Drawing.Size(42, 23);
            this.btnAdaugaPacienti.TabIndex = 3;
            this.btnAdaugaPacienti.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdaugaPacienti.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdaugaPacienti.UseVisualStyleBackColor = true;
            this.btnAdaugaPacienti.Click += new System.EventHandler(this.BtnAdaugaPacienti_Click);
            // 
            // txtCautarePacienti
            // 
            this.txtCautarePacienti.AcceptButton = null;
            this.txtCautarePacienti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautarePacienti.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautarePacienti.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautarePacienti.BackColor = System.Drawing.Color.White;
            this.txtCautarePacienti.CapitalizeazaPrimaLitera = false;
            this.txtCautarePacienti.IsInReadOnlyMode = false;
            this.txtCautarePacienti.Location = new System.Drawing.Point(326, 5);
            this.txtCautarePacienti.MaxLength = 32767;
            this.txtCautarePacienti.Multiline = false;
            this.txtCautarePacienti.Name = "txtCautarePacienti";
            this.txtCautarePacienti.ProprietateCorespunzatoare = null;
            this.txtCautarePacienti.RaiseEventLaModificareProgramatica = false;
            this.txtCautarePacienti.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautarePacienti.Size = new System.Drawing.Size(264, 20);
            this.txtCautarePacienti.TabIndex = 0;
            this.txtCautarePacienti.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautarePacienti.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautarePacienti.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautarePacienti.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautarePacienti.UseSystemPasswordChar = false;
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
            // ControlListaPacienti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnActivInactiv);
            this.Controls.Add(this.txtCautarePacienti);
            this.Controls.Add(this.btnAdaugaPacienti);
            this.Controls.Add(this.lblNrPacienti);
            this.Controls.Add(this.lblPacienti);
            this.Controls.Add(this.dgvListaPacienti);
            this.Name = "ControlListaPacienti";
            this.Size = new System.Drawing.Size(593, 334);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPacienti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.DataGridViewPersonalizat dgvListaPacienti;
        private CCL.UI.LabelPersonalizat lblPacienti;
        private CCL.UI.LabelPersonalizat lblNrPacienti;
        private CCL.UI.ButtonPersonalizat btnAdaugaPacienti;
        private CCL.UI.Caramizi.TextBoxCautare txtCautarePacienti;
        private CCL.UI.ButtonPersonalizat btnActivInactiv;
    }
}
