namespace iStomaLab.TablouDeBord.Clienti
{
    partial class FormImportaClienti
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
            this.dgvListaImportClienti = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.ctrlValidareAnulare = new CCL.UI.Caramizi.controlValidareAnulare();
            this.txtCautaClienti = new CCL.UI.Caramizi.TextBoxCautare();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaImportClienti)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(600, 19);
            this.lblTitluEcran.TabIndex = 3;
            this.lblTitluEcran.Text = "FormImportaClienti";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(599, 0);
            this.btnInchidereEcran.TabIndex = 4;
            // 
            // dgvListaImportClienti
            // 
            this.dgvListaImportClienti.AllowUserToAddRows = false;
            this.dgvListaImportClienti.AllowUserToDeleteRows = false;
            this.dgvListaImportClienti.AllowUserToResizeRows = false;
            this.dgvListaImportClienti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaImportClienti.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaImportClienti.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaImportClienti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaImportClienti.HideSelection = true;
            this.dgvListaImportClienti.IsInReadOnlyMode = false;
            this.dgvListaImportClienti.Location = new System.Drawing.Point(5, 49);
            this.dgvListaImportClienti.MultiSelect = false;
            this.dgvListaImportClienti.Name = "dgvListaImportClienti";
            this.dgvListaImportClienti.ProprietateCorespunzatoare = "";
            this.dgvListaImportClienti.RowHeadersVisible = false;
            this.dgvListaImportClienti.SeIncarca = false;
            this.dgvListaImportClienti.SelectedText = "";
            this.dgvListaImportClienti.SelectionLength = 0;
            this.dgvListaImportClienti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaImportClienti.SelectionStart = 0;
            this.dgvListaImportClienti.Size = new System.Drawing.Size(611, 390);
            this.dgvListaImportClienti.TabIndex = 1;
            // 
            // ctrlValidareAnulare
            // 
            this.ctrlValidareAnulare.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrlValidareAnulare.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulare.Location = new System.Drawing.Point(231, 446);
            this.ctrlValidareAnulare.Name = "ctrlValidareAnulare";
            this.ctrlValidareAnulare.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulare.TabIndex = 2;
            // 
            // txtCautaClienti
            // 
            this.txtCautaClienti.AcceptButton = null;
            this.txtCautaClienti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautaClienti.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautaClienti.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautaClienti.BackColor = System.Drawing.Color.White;
            this.txtCautaClienti.CapitalizeazaPrimaLitera = false;
            this.txtCautaClienti.IsInReadOnlyMode = false;
            this.txtCautaClienti.Location = new System.Drawing.Point(395, 23);
            this.txtCautaClienti.MaxLength = 32767;
            this.txtCautaClienti.Multiline = false;
            this.txtCautaClienti.Name = "txtCautaClienti";
            this.txtCautaClienti.ProprietateCorespunzatoare = null;
            this.txtCautaClienti.RaiseEventLaModificareProgramatica = false;
            this.txtCautaClienti.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautaClienti.Size = new System.Drawing.Size(221, 20);
            this.txtCautaClienti.TabIndex = 0;
            this.txtCautaClienti.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautaClienti.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautaClienti.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautaClienti.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautaClienti.UseSystemPasswordChar = false;
            // 
            // FormImportaClienti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 478);
            this.Controls.Add(this.txtCautaClienti);
            this.Controls.Add(this.ctrlValidareAnulare);
            this.Controls.Add(this.dgvListaImportClienti);
            this.MinimumSize = new System.Drawing.Size(622, 478);
            this.Name = "FormImportaClienti";
            this.Text = "FormImportaClienti";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.dgvListaImportClienti, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulare, 0);
            this.Controls.SetChildIndex(this.txtCautaClienti, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaImportClienti)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.DataGridViewPersonalizat dgvListaImportClienti;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulare;
        private CCL.UI.Caramizi.TextBoxCautare txtCautaClienti;
    }
}