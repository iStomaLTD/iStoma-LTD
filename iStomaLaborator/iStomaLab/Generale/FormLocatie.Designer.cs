namespace iStomaLab.Generale
{
    partial class FormLocatie
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
            this.lblNationalitate = new CCL.UI.LabelPersonalizat(this.components);
            this.cboNationalitate = new CCL.UI.ControalePersonalizate.ComboBoxAutocomplete(this.components);
            this.lblTara = new CCL.UI.LabelPersonalizat(this.components);
            this.txtTara = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblRegiune = new CCL.UI.LabelPersonalizat(this.components);
            this.txtRegiune = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblLocalitate = new CCL.UI.LabelPersonalizat(this.components);
            this.txtLocalitate = new CCL.UI.TextBoxPersonalizat(this.components);
            this.ctrlValidareAnulareLocatie = new CCL.UI.Caramizi.controlValidareAnulare();
            this.dgvListaLocatii = new CCL.UI.DataGridViewPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaLocatii)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(374, 23);
            this.lblTitluEcran.Text = "FormLocatie";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(373, 0);
            // 
            // lblNationalitate
            // 
            this.lblNationalitate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNationalitate.AutoSize = true;
            this.lblNationalitate.Location = new System.Drawing.Point(13, 53);
            this.lblNationalitate.Name = "lblNationalitate";
            this.lblNationalitate.Size = new System.Drawing.Size(87, 17);
            this.lblNationalitate.TabIndex = 2;
            this.lblNationalitate.Text = "Nationalitate";
            this.lblNationalitate.ToolTipText = null;
            this.lblNationalitate.ToolTipTitle = null;
            // 
            // cboNationalitate
            // 
            this.cboNationalitate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboNationalitate.AutoCompletePersonalizat = false;
            this.cboNationalitate.FormattingEnabled = true;
            this.cboNationalitate.HideSelection = true;
            this.cboNationalitate.IsInReadOnlyMode = false;
            this.cboNationalitate.Location = new System.Drawing.Point(115, 49);
            this.cboNationalitate.Name = "cboNationalitate";
            this.cboNationalitate.ProprietateCorespunzatoare = null;
            this.cboNationalitate.Size = new System.Drawing.Size(277, 24);
            this.cboNationalitate.TabIndex = 3;
            this.cboNationalitate.TipulListei = CCL.UI.ComboBoxPersonalizat.EnumTipLista.Nespecificat;
            // 
            // lblTara
            // 
            this.lblTara.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTara.AutoSize = true;
            this.lblTara.Location = new System.Drawing.Point(13, 94);
            this.lblTara.Name = "lblTara";
            this.lblTara.Size = new System.Drawing.Size(38, 17);
            this.lblTara.TabIndex = 4;
            this.lblTara.Text = "Tara";
            this.lblTara.ToolTipText = null;
            this.lblTara.ToolTipTitle = null;
            // 
            // txtTara
            // 
            this.txtTara.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTara.CapitalizeazaPrimaLitera = false;
            this.txtTara.IsInReadOnlyMode = false;
            this.txtTara.Location = new System.Drawing.Point(115, 91);
            this.txtTara.Name = "txtTara";
            this.txtTara.ProprietateCorespunzatoare = null;
            this.txtTara.RaiseEventLaModificareProgramatica = false;
            this.txtTara.Size = new System.Drawing.Size(277, 22);
            this.txtTara.TabIndex = 5;
            this.txtTara.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtTara.TotulCuMajuscule = false;
            // 
            // lblRegiune
            // 
            this.lblRegiune.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegiune.AutoSize = true;
            this.lblRegiune.Location = new System.Drawing.Point(13, 139);
            this.lblRegiune.Name = "lblRegiune";
            this.lblRegiune.Size = new System.Drawing.Size(61, 17);
            this.lblRegiune.TabIndex = 6;
            this.lblRegiune.Text = "Regiune";
            this.lblRegiune.ToolTipText = null;
            this.lblRegiune.ToolTipTitle = null;
            // 
            // txtRegiune
            // 
            this.txtRegiune.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegiune.CapitalizeazaPrimaLitera = false;
            this.txtRegiune.IsInReadOnlyMode = false;
            this.txtRegiune.Location = new System.Drawing.Point(115, 136);
            this.txtRegiune.Name = "txtRegiune";
            this.txtRegiune.ProprietateCorespunzatoare = null;
            this.txtRegiune.RaiseEventLaModificareProgramatica = false;
            this.txtRegiune.Size = new System.Drawing.Size(277, 22);
            this.txtRegiune.TabIndex = 7;
            this.txtRegiune.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtRegiune.TotulCuMajuscule = false;
            // 
            // lblLocalitate
            // 
            this.lblLocalitate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLocalitate.AutoSize = true;
            this.lblLocalitate.Location = new System.Drawing.Point(13, 186);
            this.lblLocalitate.Name = "lblLocalitate";
            this.lblLocalitate.Size = new System.Drawing.Size(69, 17);
            this.lblLocalitate.TabIndex = 8;
            this.lblLocalitate.Text = "Localitate";
            this.lblLocalitate.ToolTipText = null;
            this.lblLocalitate.ToolTipTitle = null;
            // 
            // txtLocalitate
            // 
            this.txtLocalitate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocalitate.CapitalizeazaPrimaLitera = false;
            this.txtLocalitate.IsInReadOnlyMode = false;
            this.txtLocalitate.Location = new System.Drawing.Point(115, 183);
            this.txtLocalitate.Name = "txtLocalitate";
            this.txtLocalitate.ProprietateCorespunzatoare = null;
            this.txtLocalitate.RaiseEventLaModificareProgramatica = false;
            this.txtLocalitate.Size = new System.Drawing.Size(277, 22);
            this.txtLocalitate.TabIndex = 9;
            this.txtLocalitate.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtLocalitate.TotulCuMajuscule = false;
            // 
            // ctrlValidareAnulareLocatie
            // 
            this.ctrlValidareAnulareLocatie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlValidareAnulareLocatie.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulareLocatie.Location = new System.Drawing.Point(95, 230);
            this.ctrlValidareAnulareLocatie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctrlValidareAnulareLocatie.Name = "ctrlValidareAnulareLocatie";
            this.ctrlValidareAnulareLocatie.Size = new System.Drawing.Size(215, 28);
            this.ctrlValidareAnulareLocatie.TabIndex = 10;
            // 
            // dgvListaLocatii
            // 
            this.dgvListaLocatii.AllowUserToAddRows = false;
            this.dgvListaLocatii.AllowUserToDeleteRows = false;
            this.dgvListaLocatii.AllowUserToResizeRows = false;
            this.dgvListaLocatii.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaLocatii.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListaLocatii.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaLocatii.HideSelection = true;
            this.dgvListaLocatii.IsInReadOnlyMode = false;
            this.dgvListaLocatii.Location = new System.Drawing.Point(115, 80);
            this.dgvListaLocatii.MultiSelect = false;
            this.dgvListaLocatii.Name = "dgvListaLocatii";
            this.dgvListaLocatii.ProprietateCorespunzatoare = "";
            this.dgvListaLocatii.RowHeadersVisible = false;
            this.dgvListaLocatii.RowTemplate.Height = 24;
            this.dgvListaLocatii.SeIncarca = false;
            this.dgvListaLocatii.SelectedText = "";
            this.dgvListaLocatii.SelectionLength = 0;
            this.dgvListaLocatii.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaLocatii.SelectionStart = 0;
            this.dgvListaLocatii.Size = new System.Drawing.Size(277, 150);
            this.dgvListaLocatii.TabIndex = 11;
            this.dgvListaLocatii.Visible = false;
            // 
            // FormLocatie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 271);
            this.Controls.Add(this.ctrlValidareAnulareLocatie);
            this.Controls.Add(this.txtLocalitate);
            this.Controls.Add(this.lblLocalitate);
            this.Controls.Add(this.txtRegiune);
            this.Controls.Add(this.lblRegiune);
            this.Controls.Add(this.txtTara);
            this.Controls.Add(this.lblTara);
            this.Controls.Add(this.cboNationalitate);
            this.Controls.Add(this.lblNationalitate);
            this.Controls.Add(this.dgvListaLocatii);
            this.Name = "FormLocatie";
            this.Text = "FormLocatie";
            this.Controls.SetChildIndex(this.dgvListaLocatii, 0);
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.lblNationalitate, 0);
            this.Controls.SetChildIndex(this.cboNationalitate, 0);
            this.Controls.SetChildIndex(this.lblTara, 0);
            this.Controls.SetChildIndex(this.txtTara, 0);
            this.Controls.SetChildIndex(this.lblRegiune, 0);
            this.Controls.SetChildIndex(this.txtRegiune, 0);
            this.Controls.SetChildIndex(this.lblLocalitate, 0);
            this.Controls.SetChildIndex(this.txtLocalitate, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulareLocatie, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaLocatii)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.LabelPersonalizat lblNationalitate;
        private CCL.UI.ControalePersonalizate.ComboBoxAutocomplete cboNationalitate;
        private CCL.UI.LabelPersonalizat lblTara;
        private CCL.UI.TextBoxPersonalizat txtTara;
        private CCL.UI.LabelPersonalizat lblRegiune;
        private CCL.UI.TextBoxPersonalizat txtRegiune;
        private CCL.UI.LabelPersonalizat lblLocalitate;
        private CCL.UI.TextBoxPersonalizat txtLocalitate;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulareLocatie;
        private CCL.UI.DataGridViewPersonalizat dgvListaLocatii;
    }
}