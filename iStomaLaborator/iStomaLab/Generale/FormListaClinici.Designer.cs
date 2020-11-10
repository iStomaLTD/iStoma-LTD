namespace iStomaLab.Generale
{
    partial class FormListaClinici
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtCautaClinica = new CCL.UI.Caramizi.TextBoxCautare();
            this.dgvListaClinici = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.ctrlValidareAnulare = new CCL.UI.Caramizi.controlValidareAnulare();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaClinici)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(410, 19);
            this.lblTitluEcran.TabIndex = 3;
            this.lblTitluEcran.Text = "FormListaClinici";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(409, 0);
            this.btnInchidereEcran.TabIndex = 4;
            // 
            // txtCautaClinica
            // 
            this.txtCautaClinica.AcceptButton = null;
            this.txtCautaClinica.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautaClinica.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautaClinica.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautaClinica.BackColor = System.Drawing.Color.White;
            this.txtCautaClinica.CapitalizeazaPrimaLitera = false;
            this.txtCautaClinica.IsInReadOnlyMode = false;
            this.txtCautaClinica.Location = new System.Drawing.Point(214, 25);
            this.txtCautaClinica.MaxLength = 32767;
            this.txtCautaClinica.Multiline = false;
            this.txtCautaClinica.Name = "txtCautaClinica";
            this.txtCautaClinica.ProprietateCorespunzatoare = null;
            this.txtCautaClinica.RaiseEventLaModificareProgramatica = false;
            this.txtCautaClinica.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautaClinica.Size = new System.Drawing.Size(207, 20);
            this.txtCautaClinica.TabIndex = 0;
            this.txtCautaClinica.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautaClinica.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautaClinica.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautaClinica.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautaClinica.UseSystemPasswordChar = false;
            // 
            // dgvListaClinici
            // 
            this.dgvListaClinici.AllowUserToAddRows = false;
            this.dgvListaClinici.AllowUserToDeleteRows = false;
            this.dgvListaClinici.AllowUserToResizeRows = false;
            this.dgvListaClinici.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaClinici.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaClinici.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListaClinici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaClinici.HideSelection = true;
            this.dgvListaClinici.IsInReadOnlyMode = false;
            this.dgvListaClinici.Location = new System.Drawing.Point(5, 51);
            this.dgvListaClinici.MultiSelect = false;
            this.dgvListaClinici.Name = "dgvListaClinici";
            this.dgvListaClinici.ProprietateCorespunzatoare = "";
            this.dgvListaClinici.RowHeadersVisible = false;
            this.dgvListaClinici.SeIncarca = false;
            this.dgvListaClinici.SelectedText = "";
            this.dgvListaClinici.SelectionLength = 0;
            this.dgvListaClinici.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaClinici.SelectionStart = 0;
            this.dgvListaClinici.Size = new System.Drawing.Size(423, 276);
            this.dgvListaClinici.TabIndex = 1;
            // 
            // ctrlValidareAnulare
            // 
            this.ctrlValidareAnulare.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrlValidareAnulare.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulare.Location = new System.Drawing.Point(137, 333);
            this.ctrlValidareAnulare.Name = "ctrlValidareAnulare";
            this.ctrlValidareAnulare.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulare.TabIndex = 2;
            // 
            // FormListaClinici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 362);
            this.Controls.Add(this.ctrlValidareAnulare);
            this.Controls.Add(this.dgvListaClinici);
            this.Controls.Add(this.txtCautaClinica);
            this.MinimumSize = new System.Drawing.Size(432, 362);
            this.Name = "FormListaClinici";
            this.Text = "FormListaClinici";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.txtCautaClinica, 0);
            this.Controls.SetChildIndex(this.dgvListaClinici, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulare, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaClinici)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.Caramizi.TextBoxCautare txtCautaClinica;
        private CCL.UI.DataGridViewPersonalizat dgvListaClinici;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulare;
    }
}