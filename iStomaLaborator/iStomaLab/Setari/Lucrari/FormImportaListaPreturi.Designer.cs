namespace iStomaLab.Setari.Lucrari
{
    partial class FormImportaListaPreturi
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
            this.dgvListaImportPreturi = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.ctrlValidareAnulare = new CCL.UI.Caramizi.controlValidareAnulare();
            this.txtCautare = new CCL.UI.Caramizi.TextBoxCautare();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaImportPreturi)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(634, 19);
            this.lblTitluEcran.TabIndex = 3;
            this.lblTitluEcran.Text = "FormImportaListaPreturi";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(633, 0);
            this.btnInchidereEcran.TabIndex = 4;
            // 
            // dgvListaImportPreturi
            // 
            this.dgvListaImportPreturi.AllowUserToAddRows = false;
            this.dgvListaImportPreturi.AllowUserToDeleteRows = false;
            this.dgvListaImportPreturi.AllowUserToResizeRows = false;
            this.dgvListaImportPreturi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaImportPreturi.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaImportPreturi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaImportPreturi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaImportPreturi.HideSelection = true;
            this.dgvListaImportPreturi.IsInReadOnlyMode = false;
            this.dgvListaImportPreturi.Location = new System.Drawing.Point(5, 49);
            this.dgvListaImportPreturi.MultiSelect = false;
            this.dgvListaImportPreturi.Name = "dgvListaImportPreturi";
            this.dgvListaImportPreturi.ProprietateCorespunzatoare = "";
            this.dgvListaImportPreturi.RowHeadersVisible = false;
            this.dgvListaImportPreturi.SeIncarca = false;
            this.dgvListaImportPreturi.SelectedText = "";
            this.dgvListaImportPreturi.SelectionLength = 0;
            this.dgvListaImportPreturi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaImportPreturi.SelectionStart = 0;
            this.dgvListaImportPreturi.Size = new System.Drawing.Size(645, 396);
            this.dgvListaImportPreturi.TabIndex = 1;
            // 
            // ctrlValidareAnulare
            // 
            this.ctrlValidareAnulare.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrlValidareAnulare.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulare.Location = new System.Drawing.Point(248, 452);
            this.ctrlValidareAnulare.Name = "ctrlValidareAnulare";
            this.ctrlValidareAnulare.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulare.TabIndex = 2;
            // 
            // txtCautare
            // 
            this.txtCautare.AcceptButton = null;
            this.txtCautare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautare.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautare.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautare.BackColor = System.Drawing.Color.White;
            this.txtCautare.CapitalizeazaPrimaLitera = false;
            this.txtCautare.IsInReadOnlyMode = false;
            this.txtCautare.Location = new System.Drawing.Point(415, 24);
            this.txtCautare.MaxLength = 32767;
            this.txtCautare.Multiline = false;
            this.txtCautare.Name = "txtCautare";
            this.txtCautare.ProprietateCorespunzatoare = null;
            this.txtCautare.RaiseEventLaModificareProgramatica = false;
            this.txtCautare.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautare.Size = new System.Drawing.Size(235, 20);
            this.txtCautare.TabIndex = 0;
            this.txtCautare.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautare.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautare.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautare.UseSystemPasswordChar = false;
            // 
            // FormImportaListaPreturi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 483);
            this.Controls.Add(this.txtCautare);
            this.Controls.Add(this.ctrlValidareAnulare);
            this.Controls.Add(this.dgvListaImportPreturi);
            this.MinimumSize = new System.Drawing.Size(656, 483);
            this.Name = "FormImportaListaPreturi";
            this.Text = "FormImportaListaPreturi";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.dgvListaImportPreturi, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulare, 0);
            this.Controls.SetChildIndex(this.txtCautare, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaImportPreturi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.DataGridViewPersonalizat dgvListaImportPreturi;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulare;
        private CCL.UI.Caramizi.TextBoxCautare txtCautare;
    }
}