namespace iStomaLab.Setari.Personal
{
    partial class FormImportPersonal
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
            this.dgvListaImportPersonal = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.ctrlValidareAnulare = new CCL.UI.Caramizi.controlValidareAnulare();
            this.txtCautare = new CCL.UI.Caramizi.TextBoxCautare();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaImportPersonal)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(631, 19);
            this.lblTitluEcran.TabIndex = 3;
            this.lblTitluEcran.Text = "FormImportPersonal";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(630, 0);
            this.btnInchidereEcran.TabIndex = 4;
            // 
            // dgvListaImportPersonal
            // 
            this.dgvListaImportPersonal.AllowUserToAddRows = false;
            this.dgvListaImportPersonal.AllowUserToDeleteRows = false;
            this.dgvListaImportPersonal.AllowUserToResizeRows = false;
            this.dgvListaImportPersonal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaImportPersonal.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaImportPersonal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaImportPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaImportPersonal.HideSelection = true;
            this.dgvListaImportPersonal.IsInReadOnlyMode = false;
            this.dgvListaImportPersonal.Location = new System.Drawing.Point(4, 50);
            this.dgvListaImportPersonal.MultiSelect = false;
            this.dgvListaImportPersonal.Name = "dgvListaImportPersonal";
            this.dgvListaImportPersonal.ProprietateCorespunzatoare = "";
            this.dgvListaImportPersonal.RowHeadersVisible = false;
            this.dgvListaImportPersonal.SeIncarca = false;
            this.dgvListaImportPersonal.SelectedText = "";
            this.dgvListaImportPersonal.SelectionLength = 0;
            this.dgvListaImportPersonal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaImportPersonal.SelectionStart = 0;
            this.dgvListaImportPersonal.Size = new System.Drawing.Size(643, 413);
            this.dgvListaImportPersonal.TabIndex = 1;
            // 
            // ctrlValidareAnulare
            // 
            this.ctrlValidareAnulare.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrlValidareAnulare.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulare.Location = new System.Drawing.Point(246, 471);
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
            this.txtCautare.Location = new System.Drawing.Point(428, 24);
            this.txtCautare.MaxLength = 32767;
            this.txtCautare.Multiline = false;
            this.txtCautare.Name = "txtCautare";
            this.txtCautare.ProprietateCorespunzatoare = null;
            this.txtCautare.RaiseEventLaModificareProgramatica = false;
            this.txtCautare.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautare.Size = new System.Drawing.Size(219, 20);
            this.txtCautare.TabIndex = 0;
            this.txtCautare.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautare.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautare.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautare.UseSystemPasswordChar = false;
            // 
            // FormImportPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 503);
            this.Controls.Add(this.txtCautare);
            this.Controls.Add(this.ctrlValidareAnulare);
            this.Controls.Add(this.dgvListaImportPersonal);
            this.MinimumSize = new System.Drawing.Size(653, 503);
            this.Name = "FormImportPersonal";
            this.Text = "FormImportPersonal";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.dgvListaImportPersonal, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulare, 0);
            this.Controls.SetChildIndex(this.txtCautare, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaImportPersonal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.DataGridViewPersonalizat dgvListaImportPersonal;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulare;
        private CCL.UI.Caramizi.TextBoxCautare txtCautare;
    }
}