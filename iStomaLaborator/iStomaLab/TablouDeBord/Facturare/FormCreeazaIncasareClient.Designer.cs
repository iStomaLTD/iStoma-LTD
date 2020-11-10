namespace iStomaLab.TablouDeBord.Facturare
{
    partial class FormCreeazaIncasareClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreeazaIncasareClient));
            this.ctrlValidareAnulare = new CCL.UI.Caramizi.controlValidareAnulare();
            this.txtSuma = new CCL.UI.Caramizi.MaskedTextBoxGuma();
            this.btnGuma = new CCL.UI.ButtonPersonalizat(this.components);
            this.txtInformatieUtila = new CCL.UI.MaskedTextBoxPersonalizat(this.components);
            this.lblSuma = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlLeiEuro = new CCL.UI.Caramizi.controlLeiEuro();
            this.ctrlDataOraIncasare = new CCL.UI.Caramizi.ControlDataOraGuma();
            this.lblData = new CCL.UI.LabelPersonalizat(this.components);
            this.lblModalitate = new CCL.UI.LabelPersonalizat(this.components);
            this.cboModalitateIncasare = new CCL.UI.ComboBoxPersonalizat(this.components);
            this.lblCurs = new CCL.UI.LabelPersonalizat(this.components);
            this.txtCursSchimb = new CCL.UI.MaskedTextBoxPersonalizat(this.components);
            this.dgvListaFacturi = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.lblSold = new CCL.UI.LabelPersonalizat(this.components);
            this.lblMoneda = new CCL.UI.LabelPersonalizat(this.components);
            this.txtObservatii = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblObservatii = new CCL.UI.LabelPersonalizat(this.components);
            this.txtSuma.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaFacturi)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(836, 19);
            this.lblTitluEcran.Text = "FormCreeazaIncasareClient";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(835, 0);
            // 
            // ctrlValidareAnulare
            // 
            this.ctrlValidareAnulare.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrlValidareAnulare.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulare.Location = new System.Drawing.Point(349, 467);
            this.ctrlValidareAnulare.Name = "ctrlValidareAnulare";
            this.ctrlValidareAnulare.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulare.TabIndex = 2;
            // 
            // txtSuma
            // 
            this.txtSuma.AcceptButton = null;
            this.txtSuma.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtSuma.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtSuma.BackColor = System.Drawing.Color.White;
            this.txtSuma.Controls.Add(this.btnGuma);
            this.txtSuma.Controls.Add(this.txtInformatieUtila);
            this.txtSuma.Location = new System.Drawing.Point(83, 28);
            this.txtSuma.Name = "txtSuma";
            this.txtSuma.ProprietateCorespunzatoare = null;
            this.txtSuma.Size = new System.Drawing.Size(163, 21);
            this.txtSuma.TabIndex = 14;
            this.txtSuma.Text = "0";
            this.txtSuma.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSuma.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtSuma.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.txtSuma.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSuma.ValoareDouble = 0D;
            // 
            // btnGuma
            // 
            this.btnGuma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuma.BackColor = System.Drawing.Color.Transparent;
            this.btnGuma.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGuma.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnGuma.Image = ((System.Drawing.Image)(resources.GetObject("btnGuma.Image")));
            this.btnGuma.Location = new System.Drawing.Point(172, 1);
            this.btnGuma.Name = "btnGuma";
            this.btnGuma.Size = new System.Drawing.Size(20, 20);
            this.btnGuma.TabIndex = 1;
            this.btnGuma.TabStop = false;
            this.btnGuma.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Guma;
            this.btnGuma.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnGuma.UseVisualStyleBackColor = false;
            // 
            // txtInformatieUtila
            // 
            this.txtInformatieUtila.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInformatieUtila.BackColor = System.Drawing.SystemColors.Window;
            this.txtInformatieUtila.HidePromptOnLeave = true;
            this.txtInformatieUtila.Location = new System.Drawing.Point(0, 1);
            this.txtInformatieUtila.Name = "txtInformatieUtila";
            this.txtInformatieUtila.ProprietateCorespunzatoare = null;
            this.txtInformatieUtila.Size = new System.Drawing.Size(170, 20);
            this.txtInformatieUtila.TabIndex = 0;
            this.txtInformatieUtila.Text = "0";
            this.txtInformatieUtila.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.txtInformatieUtila.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtInformatieUtila.ValoareDouble = 0D;
            // 
            // lblSuma
            // 
            this.lblSuma.AutoSize = true;
            this.lblSuma.Location = new System.Drawing.Point(21, 32);
            this.lblSuma.Name = "lblSuma";
            this.lblSuma.Size = new System.Drawing.Size(34, 13);
            this.lblSuma.TabIndex = 13;
            this.lblSuma.Text = "Suma";
            this.lblSuma.ToolTipText = null;
            this.lblSuma.ToolTipTitle = null;
            // 
            // ctrlLeiEuro
            // 
            this.ctrlLeiEuro.IsInReadOnlyMode = false;
            this.ctrlLeiEuro.Location = new System.Drawing.Point(371, 29);
            this.ctrlLeiEuro.Moneda = CDL.iStomaLab.CDefinitiiComune.EnumTipMoneda.Lei;
            this.ctrlLeiEuro.Name = "ctrlLeiEuro";
            this.ctrlLeiEuro.Size = new System.Drawing.Size(139, 24);
            this.ctrlLeiEuro.TabIndex = 15;
            // 
            // ctrlDataOraIncasare
            // 
            this.ctrlDataOraIncasare.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ctrlDataOraIncasare.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ctrlDataOraIncasare.BackColor = System.Drawing.Color.White;
            this.ctrlDataOraIncasare.DataAfisata = new System.DateTime(((long)(0)));
            this.ctrlDataOraIncasare.IsInReadOnlyMode = false;
            this.ctrlDataOraIncasare.Location = new System.Drawing.Point(83, 78);
            this.ctrlDataOraIncasare.Name = "ctrlDataOraIncasare";
            this.ctrlDataOraIncasare.PragInferior = new System.DateTime(((long)(0)));
            this.ctrlDataOraIncasare.PragSuperior = new System.DateTime(((long)(0)));
            this.ctrlDataOraIncasare.ProprietateCorespunzatoare = null;
            this.ctrlDataOraIncasare.Size = new System.Drawing.Size(188, 23);
            this.ctrlDataOraIncasare.TabIndex = 16;
            this.ctrlDataOraIncasare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.ctrlDataOraIncasare.TipDeschidereCalendar = CCL.UI.CEnumerariComune.EnumTipDeschidere.StangaSus;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(21, 83);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(30, 13);
            this.lblData.TabIndex = 17;
            this.lblData.Text = "Data";
            this.lblData.ToolTipText = null;
            this.lblData.ToolTipTitle = null;
            // 
            // lblModalitate
            // 
            this.lblModalitate.AutoSize = true;
            this.lblModalitate.Location = new System.Drawing.Point(21, 128);
            this.lblModalitate.Name = "lblModalitate";
            this.lblModalitate.Size = new System.Drawing.Size(56, 13);
            this.lblModalitate.TabIndex = 18;
            this.lblModalitate.Text = "Modalitate";
            this.lblModalitate.ToolTipText = null;
            this.lblModalitate.ToolTipTitle = null;
            // 
            // cboModalitateIncasare
            // 
            this.cboModalitateIncasare.AutoCompletePersonalizat = false;
            this.cboModalitateIncasare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModalitateIncasare.FormattingEnabled = true;
            this.cboModalitateIncasare.HideSelection = true;
            this.cboModalitateIncasare.IsInReadOnlyMode = false;
            this.cboModalitateIncasare.Location = new System.Drawing.Point(83, 124);
            this.cboModalitateIncasare.Name = "cboModalitateIncasare";
            this.cboModalitateIncasare.ProprietateCorespunzatoare = null;
            this.cboModalitateIncasare.Size = new System.Drawing.Size(197, 21);
            this.cboModalitateIncasare.TabIndex = 19;
            this.cboModalitateIncasare.TipulListei = CCL.UI.ComboBoxPersonalizat.EnumTipLista.Nespecificat;
            // 
            // lblCurs
            // 
            this.lblCurs.AutoSize = true;
            this.lblCurs.Location = new System.Drawing.Point(559, 34);
            this.lblCurs.Name = "lblCurs";
            this.lblCurs.Size = new System.Drawing.Size(28, 13);
            this.lblCurs.TabIndex = 21;
            this.lblCurs.Text = "Curs";
            this.lblCurs.ToolTipText = null;
            this.lblCurs.ToolTipTitle = null;
            // 
            // txtCursSchimb
            // 
            this.txtCursSchimb.BackColor = System.Drawing.SystemColors.Window;
            this.txtCursSchimb.Location = new System.Drawing.Point(618, 30);
            this.txtCursSchimb.Name = "txtCursSchimb";
            this.txtCursSchimb.ProprietateCorespunzatoare = null;
            this.txtCursSchimb.Size = new System.Drawing.Size(70, 20);
            this.txtCursSchimb.TabIndex = 20;
            this.txtCursSchimb.Text = "0";
            this.txtCursSchimb.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.txtCursSchimb.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCursSchimb.ValoareDouble = 0D;
            // 
            // dgvListaFacturi
            // 
            this.dgvListaFacturi.AllowUserToAddRows = false;
            this.dgvListaFacturi.AllowUserToDeleteRows = false;
            this.dgvListaFacturi.AllowUserToResizeRows = false;
            this.dgvListaFacturi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaFacturi.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaFacturi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaFacturi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaFacturi.HideSelection = true;
            this.dgvListaFacturi.IsInReadOnlyMode = false;
            this.dgvListaFacturi.Location = new System.Drawing.Point(24, 178);
            this.dgvListaFacturi.MultiSelect = false;
            this.dgvListaFacturi.Name = "dgvListaFacturi";
            this.dgvListaFacturi.ProprietateCorespunzatoare = "";
            this.dgvListaFacturi.RowHeadersVisible = false;
            this.dgvListaFacturi.SeIncarca = false;
            this.dgvListaFacturi.SelectedText = "";
            this.dgvListaFacturi.SelectionLength = 0;
            this.dgvListaFacturi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaFacturi.SelectionStart = 0;
            this.dgvListaFacturi.Size = new System.Drawing.Size(812, 268);
            this.dgvListaFacturi.TabIndex = 22;
            // 
            // lblSold
            // 
            this.lblSold.AutoSize = true;
            this.lblSold.Location = new System.Drawing.Point(21, 467);
            this.lblSold.Name = "lblSold";
            this.lblSold.Size = new System.Drawing.Size(28, 13);
            this.lblSold.TabIndex = 23;
            this.lblSold.Text = "Sold";
            this.lblSold.ToolTipText = null;
            this.lblSold.ToolTipTitle = null;
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(312, 35);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(46, 13);
            this.lblMoneda.TabIndex = 24;
            this.lblMoneda.Text = "Moneda";
            this.lblMoneda.ToolTipText = null;
            this.lblMoneda.ToolTipTitle = null;
            // 
            // txtObservatii
            // 
            this.txtObservatii.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservatii.CapitalizeazaPrimaLitera = false;
            this.txtObservatii.IsInReadOnlyMode = false;
            this.txtObservatii.Location = new System.Drawing.Point(315, 88);
            this.txtObservatii.Multiline = true;
            this.txtObservatii.Name = "txtObservatii";
            this.txtObservatii.ProprietateCorespunzatoare = null;
            this.txtObservatii.RaiseEventLaModificareProgramatica = false;
            this.txtObservatii.Size = new System.Drawing.Size(373, 62);
            this.txtObservatii.TabIndex = 26;
            this.txtObservatii.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtObservatii.TotulCuMajuscule = false;
            // 
            // lblObservatii
            // 
            this.lblObservatii.AutoSize = true;
            this.lblObservatii.Location = new System.Drawing.Point(312, 71);
            this.lblObservatii.Name = "lblObservatii";
            this.lblObservatii.Size = new System.Drawing.Size(54, 13);
            this.lblObservatii.TabIndex = 25;
            this.lblObservatii.Text = "Observatii";
            this.lblObservatii.ToolTipText = null;
            this.lblObservatii.ToolTipTitle = null;
            // 
            // FormCreeazaIncasareClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 502);
            this.Controls.Add(this.txtObservatii);
            this.Controls.Add(this.lblObservatii);
            this.Controls.Add(this.lblMoneda);
            this.Controls.Add(this.lblSold);
            this.Controls.Add(this.dgvListaFacturi);
            this.Controls.Add(this.lblCurs);
            this.Controls.Add(this.txtCursSchimb);
            this.Controls.Add(this.cboModalitateIncasare);
            this.Controls.Add(this.lblModalitate);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.ctrlDataOraIncasare);
            this.Controls.Add(this.ctrlLeiEuro);
            this.Controls.Add(this.txtSuma);
            this.Controls.Add(this.lblSuma);
            this.Controls.Add(this.ctrlValidareAnulare);
            this.Name = "FormCreeazaIncasareClient";
            this.Text = "FormCreeazaIncasareClient";
            this.Controls.SetChildIndex(this.ctrlValidareAnulare, 0);
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.lblSuma, 0);
            this.Controls.SetChildIndex(this.txtSuma, 0);
            this.Controls.SetChildIndex(this.ctrlLeiEuro, 0);
            this.Controls.SetChildIndex(this.ctrlDataOraIncasare, 0);
            this.Controls.SetChildIndex(this.lblData, 0);
            this.Controls.SetChildIndex(this.lblModalitate, 0);
            this.Controls.SetChildIndex(this.cboModalitateIncasare, 0);
            this.Controls.SetChildIndex(this.txtCursSchimb, 0);
            this.Controls.SetChildIndex(this.lblCurs, 0);
            this.Controls.SetChildIndex(this.dgvListaFacturi, 0);
            this.Controls.SetChildIndex(this.lblSold, 0);
            this.Controls.SetChildIndex(this.lblMoneda, 0);
            this.Controls.SetChildIndex(this.lblObservatii, 0);
            this.Controls.SetChildIndex(this.txtObservatii, 0);
            this.txtSuma.ResumeLayout(false);
            this.txtSuma.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaFacturi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulare;
        private CCL.UI.Caramizi.MaskedTextBoxGuma txtSuma;
        private CCL.UI.ButtonPersonalizat btnGuma;
        private CCL.UI.MaskedTextBoxPersonalizat txtInformatieUtila;
        private CCL.UI.LabelPersonalizat lblSuma;
        private CCL.UI.Caramizi.controlLeiEuro ctrlLeiEuro;
        private CCL.UI.Caramizi.ControlDataOraGuma ctrlDataOraIncasare;
        private CCL.UI.LabelPersonalizat lblData;
        private CCL.UI.LabelPersonalizat lblModalitate;
        private CCL.UI.ComboBoxPersonalizat cboModalitateIncasare;
        private CCL.UI.LabelPersonalizat lblCurs;
        private CCL.UI.MaskedTextBoxPersonalizat txtCursSchimb;
        private CCL.UI.DataGridViewPersonalizat dgvListaFacturi;
        private CCL.UI.LabelPersonalizat lblSold;
        private CCL.UI.LabelPersonalizat lblMoneda;
        private CCL.UI.TextBoxPersonalizat txtObservatii;
        private CCL.UI.LabelPersonalizat lblObservatii;
    }
}