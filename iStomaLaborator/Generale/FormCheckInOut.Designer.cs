namespace iStomaLab.Generale
{
    partial class FormCheckInOut
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
            this.lblOraActuala = new CCL.UI.LabelPersonalizat(this.components);
            this.lblUtilizator = new CCL.UI.LabelPersonalizat(this.components);
            this.lblGasesteUtilizator = new CCL.UI.Caramizi.LabelGumaFind();
            this.lblTip = new CCL.UI.LabelPersonalizat(this.components);
            this.cboTip = new CCL.UI.ComboBoxPersonalizat(this.components);
            this.lblObservatii = new CCL.UI.LabelPersonalizat(this.components);
            this.txtObservatii = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblAstazi = new CCL.UI.LabelPersonalizat(this.components);
            this.dgvListaCheckAstazi = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.lblUltimulCheck = new CCL.UI.LabelPersonalizat(this.components);
            this.lblDurata = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlValidareAnulareCheck = new CCL.UI.Caramizi.controlValidareAnulare();
            this.panelDetaliiCheck = new CCL.UI.PanelPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaCheckAstazi)).BeginInit();
            this.panelDetaliiCheck.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitluEcran.Size = new System.Drawing.Size(472, 19);
            this.lblTitluEcran.Text = "FormCheckInOut";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(471, 0);
            this.btnInchidereEcran.Margin = new System.Windows.Forms.Padding(2);
            // 
            // lblOraActuala
            // 
            this.lblOraActuala.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOraActuala.AutoSize = true;
            this.lblOraActuala.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblOraActuala.Location = new System.Drawing.Point(208, 32);
            this.lblOraActuala.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOraActuala.Name = "lblOraActuala";
            this.lblOraActuala.Size = new System.Drawing.Size(66, 26);
            this.lblOraActuala.TabIndex = 2;
            this.lblOraActuala.Text = "15:03";
            this.lblOraActuala.ToolTipText = null;
            this.lblOraActuala.ToolTipTitle = null;
            // 
            // lblUtilizator
            // 
            this.lblUtilizator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUtilizator.AutoSize = true;
            this.lblUtilizator.Location = new System.Drawing.Point(11, 80);
            this.lblUtilizator.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUtilizator.Name = "lblUtilizator";
            this.lblUtilizator.Size = new System.Drawing.Size(47, 13);
            this.lblUtilizator.TabIndex = 3;
            this.lblUtilizator.Text = "Utilizator";
            this.lblUtilizator.ToolTipText = null;
            this.lblUtilizator.ToolTipTitle = null;
            // 
            // lblGasesteUtilizator
            // 
            this.lblGasesteUtilizator.AfiseazaButonCautare = true;
            this.lblGasesteUtilizator.AfiseazaButonDetalii = false;
            this.lblGasesteUtilizator.AfiseazaButonGuma = true;
            this.lblGasesteUtilizator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGasesteUtilizator.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.lblGasesteUtilizator.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.lblGasesteUtilizator.BackColor = System.Drawing.Color.White;
            this.lblGasesteUtilizator.FolosesteToString = false;
            this.lblGasesteUtilizator.IsInReadOnlyMode = false;
            this.lblGasesteUtilizator.Location = new System.Drawing.Point(74, 75);
            this.lblGasesteUtilizator.Margin = new System.Windows.Forms.Padding(2);
            this.lblGasesteUtilizator.Name = "lblGasesteUtilizator";
            this.lblGasesteUtilizator.ObiectAfisajCorespunzator = null;
            this.lblGasesteUtilizator.ObiectCorespunzator = null;
            this.lblGasesteUtilizator.ProprietateCorespunzatoare = null;
            this.lblGasesteUtilizator.Size = new System.Drawing.Size(409, 19);
            this.lblGasesteUtilizator.TabIndex = 4;
            this.lblGasesteUtilizator.Text = "...";
            this.lblGasesteUtilizator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGasesteUtilizator.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.lblGasesteUtilizator.ToolTipText = null;
            this.lblGasesteUtilizator.ToolTipTitle = null;
            // 
            // lblTip
            // 
            this.lblTip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(11, 34);
            this.lblTip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(22, 13);
            this.lblTip.TabIndex = 5;
            this.lblTip.Text = "Tip";
            this.lblTip.ToolTipText = null;
            this.lblTip.ToolTipTitle = null;
            // 
            // cboTip
            // 
            this.cboTip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTip.AutoCompletePersonalizat = false;
            this.cboTip.FormattingEnabled = true;
            this.cboTip.HideSelection = true;
            this.cboTip.IsInReadOnlyMode = false;
            this.cboTip.Location = new System.Drawing.Point(65, 34);
            this.cboTip.Margin = new System.Windows.Forms.Padding(2);
            this.cboTip.Name = "cboTip";
            this.cboTip.ProprietateCorespunzatoare = null;
            this.cboTip.Size = new System.Drawing.Size(411, 21);
            this.cboTip.TabIndex = 6;
            this.cboTip.TipulListei = CCL.UI.ComboBoxPersonalizat.EnumTipLista.Nespecificat;
            // 
            // lblObservatii
            // 
            this.lblObservatii.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblObservatii.AutoSize = true;
            this.lblObservatii.Location = new System.Drawing.Point(11, 63);
            this.lblObservatii.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblObservatii.Name = "lblObservatii";
            this.lblObservatii.Size = new System.Drawing.Size(54, 13);
            this.lblObservatii.TabIndex = 7;
            this.lblObservatii.Text = "Observatii";
            this.lblObservatii.ToolTipText = null;
            this.lblObservatii.ToolTipTitle = null;
            // 
            // txtObservatii
            // 
            this.txtObservatii.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservatii.CapitalizeazaPrimaLitera = false;
            this.txtObservatii.IsInReadOnlyMode = false;
            this.txtObservatii.Location = new System.Drawing.Point(65, 63);
            this.txtObservatii.Margin = new System.Windows.Forms.Padding(2);
            this.txtObservatii.Multiline = true;
            this.txtObservatii.Name = "txtObservatii";
            this.txtObservatii.ProprietateCorespunzatoare = null;
            this.txtObservatii.RaiseEventLaModificareProgramatica = false;
            this.txtObservatii.Size = new System.Drawing.Size(411, 110);
            this.txtObservatii.TabIndex = 8;
            this.txtObservatii.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtObservatii.TotulCuMajuscule = false;
            // 
            // lblAstazi
            // 
            this.lblAstazi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAstazi.AutoSize = true;
            this.lblAstazi.Location = new System.Drawing.Point(11, 177);
            this.lblAstazi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAstazi.Name = "lblAstazi";
            this.lblAstazi.Size = new System.Drawing.Size(35, 13);
            this.lblAstazi.TabIndex = 9;
            this.lblAstazi.Text = "Astazi";
            this.lblAstazi.ToolTipText = null;
            this.lblAstazi.ToolTipTitle = null;
            // 
            // dgvListaCheckAstazi
            // 
            this.dgvListaCheckAstazi.AllowUserToAddRows = false;
            this.dgvListaCheckAstazi.AllowUserToDeleteRows = false;
            this.dgvListaCheckAstazi.AllowUserToResizeRows = false;
            this.dgvListaCheckAstazi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaCheckAstazi.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaCheckAstazi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaCheckAstazi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaCheckAstazi.HideSelection = true;
            this.dgvListaCheckAstazi.IsInReadOnlyMode = false;
            this.dgvListaCheckAstazi.Location = new System.Drawing.Point(65, 177);
            this.dgvListaCheckAstazi.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListaCheckAstazi.MultiSelect = false;
            this.dgvListaCheckAstazi.Name = "dgvListaCheckAstazi";
            this.dgvListaCheckAstazi.ProprietateCorespunzatoare = "";
            this.dgvListaCheckAstazi.RowHeadersVisible = false;
            this.dgvListaCheckAstazi.RowTemplate.Height = 24;
            this.dgvListaCheckAstazi.SeIncarca = false;
            this.dgvListaCheckAstazi.SelectedText = "";
            this.dgvListaCheckAstazi.SelectionLength = 0;
            this.dgvListaCheckAstazi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaCheckAstazi.SelectionStart = 0;
            this.dgvListaCheckAstazi.Size = new System.Drawing.Size(410, 122);
            this.dgvListaCheckAstazi.TabIndex = 10;
            // 
            // lblUltimulCheck
            // 
            this.lblUltimulCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUltimulCheck.AutoSize = true;
            this.lblUltimulCheck.Location = new System.Drawing.Point(63, 8);
            this.lblUltimulCheck.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUltimulCheck.Name = "lblUltimulCheck";
            this.lblUltimulCheck.Size = new System.Drawing.Size(71, 13);
            this.lblUltimulCheck.TabIndex = 11;
            this.lblUltimulCheck.Text = "Ultimul check";
            this.lblUltimulCheck.ToolTipText = null;
            this.lblUltimulCheck.ToolTipTitle = null;
            // 
            // lblDurata
            // 
            this.lblDurata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDurata.AutoSize = true;
            this.lblDurata.Location = new System.Drawing.Point(346, 8);
            this.lblDurata.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDurata.Name = "lblDurata";
            this.lblDurata.Size = new System.Drawing.Size(39, 13);
            this.lblDurata.TabIndex = 12;
            this.lblDurata.Text = "Durata";
            this.lblDurata.ToolTipText = null;
            this.lblDurata.ToolTipTitle = null;
            // 
            // ctrlValidareAnulareCheck
            // 
            this.ctrlValidareAnulareCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlValidareAnulareCheck.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulareCheck.Location = new System.Drawing.Point(172, 422);
            this.ctrlValidareAnulareCheck.Name = "ctrlValidareAnulareCheck";
            this.ctrlValidareAnulareCheck.Size = new System.Drawing.Size(170, 24);
            this.ctrlValidareAnulareCheck.TabIndex = 13;
            // 
            // panelDetaliiCheck
            // 
            this.panelDetaliiCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDetaliiCheck.BackColor = System.Drawing.Color.White;
            this.panelDetaliiCheck.Controls.Add(this.lblUltimulCheck);
            this.panelDetaliiCheck.Controls.Add(this.lblTip);
            this.panelDetaliiCheck.Controls.Add(this.dgvListaCheckAstazi);
            this.panelDetaliiCheck.Controls.Add(this.lblAstazi);
            this.panelDetaliiCheck.Controls.Add(this.lblDurata);
            this.panelDetaliiCheck.Controls.Add(this.cboTip);
            this.panelDetaliiCheck.Controls.Add(this.txtObservatii);
            this.panelDetaliiCheck.Controls.Add(this.lblObservatii);
            this.panelDetaliiCheck.Location = new System.Drawing.Point(9, 98);
            this.panelDetaliiCheck.Margin = new System.Windows.Forms.Padding(2);
            this.panelDetaliiCheck.Name = "panelDetaliiCheck";
            this.panelDetaliiCheck.Size = new System.Drawing.Size(478, 315);
            this.panelDetaliiCheck.TabIndex = 14;
            this.panelDetaliiCheck.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // FormCheckInOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 457);
            this.Controls.Add(this.panelDetaliiCheck);
            this.Controls.Add(this.ctrlValidareAnulareCheck);
            this.Controls.Add(this.lblGasesteUtilizator);
            this.Controls.Add(this.lblUtilizator);
            this.Controls.Add(this.lblOraActuala);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormCheckInOut";
            this.Text = "FormCheckInOut";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.lblOraActuala, 0);
            this.Controls.SetChildIndex(this.lblUtilizator, 0);
            this.Controls.SetChildIndex(this.lblGasesteUtilizator, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulareCheck, 0);
            this.Controls.SetChildIndex(this.panelDetaliiCheck, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaCheckAstazi)).EndInit();
            this.panelDetaliiCheck.ResumeLayout(false);
            this.panelDetaliiCheck.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.LabelPersonalizat lblOraActuala;
        private CCL.UI.LabelPersonalizat lblUtilizator;
        private CCL.UI.Caramizi.LabelGumaFind lblGasesteUtilizator;
        private CCL.UI.LabelPersonalizat lblTip;
        private CCL.UI.ComboBoxPersonalizat cboTip;
        private CCL.UI.LabelPersonalizat lblObservatii;
        private CCL.UI.TextBoxPersonalizat txtObservatii;
        private CCL.UI.LabelPersonalizat lblAstazi;
        private CCL.UI.DataGridViewPersonalizat dgvListaCheckAstazi;
        private CCL.UI.LabelPersonalizat lblUltimulCheck;
        private CCL.UI.LabelPersonalizat lblDurata;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulareCheck;
        private CCL.UI.PanelPersonalizat panelDetaliiCheck;
    }
}