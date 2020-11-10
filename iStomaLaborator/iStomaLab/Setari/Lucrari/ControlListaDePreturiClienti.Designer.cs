namespace iStomaLab.Setari.Lucrari
{
    partial class ControlListaDePreturiClienti
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
            this.dgvListaDePreturiClienti = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.txtCautaLucrare = new CCL.UI.Caramizi.TextBoxCautare();
            this.dgvListaClinici = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.txtCautareClinici = new CCL.UI.Caramizi.TextBoxCautare();
            this.lblClinica = new CCL.UI.LabelPersonalizat(this.components);
            this.btnDiscount = new CCL.UI.ButtonPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaDePreturiClienti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaClinici)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListaDePreturiClienti
            // 
            this.dgvListaDePreturiClienti.AllowUserToAddRows = false;
            this.dgvListaDePreturiClienti.AllowUserToDeleteRows = false;
            this.dgvListaDePreturiClienti.AllowUserToResizeRows = false;
            this.dgvListaDePreturiClienti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaDePreturiClienti.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaDePreturiClienti.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaDePreturiClienti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaDePreturiClienti.HideSelection = true;
            this.dgvListaDePreturiClienti.IsInReadOnlyMode = false;
            this.dgvListaDePreturiClienti.Location = new System.Drawing.Point(260, 29);
            this.dgvListaDePreturiClienti.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListaDePreturiClienti.MultiSelect = false;
            this.dgvListaDePreturiClienti.Name = "dgvListaDePreturiClienti";
            this.dgvListaDePreturiClienti.ProprietateCorespunzatoare = "";
            this.dgvListaDePreturiClienti.RowHeadersVisible = false;
            this.dgvListaDePreturiClienti.RowTemplate.Height = 24;
            this.dgvListaDePreturiClienti.SeIncarca = false;
            this.dgvListaDePreturiClienti.SelectedText = "";
            this.dgvListaDePreturiClienti.SelectionLength = 0;
            this.dgvListaDePreturiClienti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaDePreturiClienti.SelectionStart = 0;
            this.dgvListaDePreturiClienti.Size = new System.Drawing.Size(307, 393);
            this.dgvListaDePreturiClienti.TabIndex = 0;
            // 
            // txtCautaLucrare
            // 
            this.txtCautaLucrare.AcceptButton = null;
            this.txtCautaLucrare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautaLucrare.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautaLucrare.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautaLucrare.BackColor = System.Drawing.Color.White;
            this.txtCautaLucrare.CapitalizeazaPrimaLitera = false;
            this.txtCautaLucrare.IsInReadOnlyMode = false;
            this.txtCautaLucrare.Location = new System.Drawing.Point(377, 5);
            this.txtCautaLucrare.MaxLength = 32767;
            this.txtCautaLucrare.Multiline = false;
            this.txtCautaLucrare.Name = "txtCautaLucrare";
            this.txtCautaLucrare.ProprietateCorespunzatoare = null;
            this.txtCautaLucrare.RaiseEventLaModificareProgramatica = false;
            this.txtCautaLucrare.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautaLucrare.Size = new System.Drawing.Size(188, 20);
            this.txtCautaLucrare.TabIndex = 1;
            this.txtCautaLucrare.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautaLucrare.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautaLucrare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautaLucrare.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautaLucrare.UseSystemPasswordChar = false;
            // 
            // dgvListaClinici
            // 
            this.dgvListaClinici.AllowUserToAddRows = false;
            this.dgvListaClinici.AllowUserToDeleteRows = false;
            this.dgvListaClinici.AllowUserToResizeRows = false;
            this.dgvListaClinici.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvListaClinici.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaClinici.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaClinici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaClinici.HideSelection = true;
            this.dgvListaClinici.IsInReadOnlyMode = false;
            this.dgvListaClinici.Location = new System.Drawing.Point(0, 29);
            this.dgvListaClinici.MultiSelect = false;
            this.dgvListaClinici.Name = "dgvListaClinici";
            this.dgvListaClinici.ProprietateCorespunzatoare = "";
            this.dgvListaClinici.RowHeadersVisible = false;
            this.dgvListaClinici.SeIncarca = false;
            this.dgvListaClinici.SelectedText = "";
            this.dgvListaClinici.SelectionLength = 0;
            this.dgvListaClinici.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaClinici.SelectionStart = 0;
            this.dgvListaClinici.Size = new System.Drawing.Size(257, 393);
            this.dgvListaClinici.TabIndex = 2;
            // 
            // txtCautareClinici
            // 
            this.txtCautareClinici.AcceptButton = null;
            this.txtCautareClinici.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautareClinici.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautareClinici.BackColor = System.Drawing.Color.White;
            this.txtCautareClinici.CapitalizeazaPrimaLitera = false;
            this.txtCautareClinici.IsInReadOnlyMode = false;
            this.txtCautareClinici.Location = new System.Drawing.Point(2, 5);
            this.txtCautareClinici.MaxLength = 32767;
            this.txtCautareClinici.Multiline = false;
            this.txtCautareClinici.Name = "txtCautareClinici";
            this.txtCautareClinici.ProprietateCorespunzatoare = null;
            this.txtCautareClinici.RaiseEventLaModificareProgramatica = false;
            this.txtCautareClinici.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautareClinici.Size = new System.Drawing.Size(253, 20);
            this.txtCautareClinici.TabIndex = 3;
            this.txtCautareClinici.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautareClinici.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautareClinici.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautareClinici.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautareClinici.UseSystemPasswordChar = false;
            // 
            // lblClinica
            // 
            this.lblClinica.AutoSize = true;
            this.lblClinica.Location = new System.Drawing.Point(260, 9);
            this.lblClinica.Name = "lblClinica";
            this.lblClinica.Size = new System.Drawing.Size(38, 13);
            this.lblClinica.TabIndex = 4;
            this.lblClinica.Text = "Clinica";
            this.lblClinica.ToolTipText = null;
            this.lblClinica.ToolTipTitle = null;
            // 
            // btnDiscount
            // 
            this.btnDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDiscount.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnDiscount.Image = null;
            this.btnDiscount.Location = new System.Drawing.Point(343, 4);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Size = new System.Drawing.Size(30, 23);
            this.btnDiscount.TabIndex = 5;
            this.btnDiscount.Text = "%";
            this.btnDiscount.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnDiscount.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnDiscount.UseVisualStyleBackColor = true;
            // 
            // ControlListaDePreturiClienti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDiscount);
            this.Controls.Add(this.lblClinica);
            this.Controls.Add(this.txtCautareClinici);
            this.Controls.Add(this.dgvListaClinici);
            this.Controls.Add(this.txtCautaLucrare);
            this.Controls.Add(this.dgvListaDePreturiClienti);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ControlListaDePreturiClienti";
            this.Size = new System.Drawing.Size(568, 422);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaDePreturiClienti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaClinici)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.DataGridViewPersonalizat dgvListaDePreturiClienti;
        private CCL.UI.Caramizi.TextBoxCautare txtCautaLucrare;
        private CCL.UI.DataGridViewPersonalizat dgvListaClinici;
        private CCL.UI.Caramizi.TextBoxCautare txtCautareClinici;
        private CCL.UI.LabelPersonalizat lblClinica;
        private CCL.UI.ButtonPersonalizat btnDiscount;
    }
}
