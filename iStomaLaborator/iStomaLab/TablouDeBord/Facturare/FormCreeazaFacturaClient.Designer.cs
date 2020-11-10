namespace iStomaLab.TablouDeBord.Facturare
{
    partial class FormCreeazaFacturaClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreeazaFacturaClient));
            this.ctrlValidareAnulare = new CCL.UI.Caramizi.controlValidareAnulare();
            this.dgvLista = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.lblLucrari = new CCL.UI.LabelPersonalizat(this.components);
            this.lblData = new CCL.UI.LabelPersonalizat(this.components);
            this.lblObservatii = new CCL.UI.LabelPersonalizat(this.components);
            this.txtObservatii = new CCL.UI.TextBoxPersonalizat(this.components);
            this.ctrlDataOraFactura = new CCL.UI.Caramizi.ControlDataOraGuma();
            this.lblTotal = new CCL.UI.LabelPersonalizat(this.components);
            this.txtTotal = new CCL.UI.Caramizi.MaskedTextBoxGuma();
            this.txtCursSchimb = new CCL.UI.MaskedTextBoxPersonalizat(this.components);
            this.lblCurs = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlMoneda = new CCL.UI.Caramizi.controlLeiEuro();
            this.lblMoneda = new CCL.UI.LabelPersonalizat(this.components);
            this.lblSerieNr = new CCL.UI.LabelPersonalizat(this.components);
            this.txtSerieFactura = new CCL.UI.TextBoxPersonalizat(this.components);
            this.txtNumarFactura = new CCL.UI.MaskedTextBoxPersonalizat(this.components);
            this.lblSeparatorSerieNumarFactura = new CCL.UI.LabelPersonalizat(this.components);
            this.btnImprima = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnAdauga = new CCL.UI.ButtonPersonalizat(this.components);
            this.txtCautare = new CCL.UI.Caramizi.TextBoxCautare();
            this.btnFiscalizeaza = new CCL.UI.ButtonPersonalizat(this.components);
            this.cboTip = new CCL.UI.ComboBoxPersonalizat(this.components);
            this.lblTip = new CCL.UI.LabelPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(878, 19);
            this.lblTitluEcran.Text = "FormCreeazaFacturaClient";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(877, 0);
            // 
            // ctrlValidareAnulare
            // 
            this.ctrlValidareAnulare.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrlValidareAnulare.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulare.Location = new System.Drawing.Point(370, 568);
            this.ctrlValidareAnulare.Name = "ctrlValidareAnulare";
            this.ctrlValidareAnulare.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulare.TabIndex = 2;
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.AllowUserToDeleteRows = false;
            this.dgvLista.AllowUserToResizeRows = false;
            this.dgvLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLista.BackgroundColor = System.Drawing.Color.White;
            this.dgvLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.HideSelection = true;
            this.dgvLista.IsInReadOnlyMode = false;
            this.dgvLista.Location = new System.Drawing.Point(3, 149);
            this.dgvLista.MultiSelect = false;
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ProprietateCorespunzatoare = "";
            this.dgvLista.RowHeadersVisible = false;
            this.dgvLista.SeIncarca = false;
            this.dgvLista.SelectedText = "";
            this.dgvLista.SelectionLength = 0;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLista.SelectionStart = 0;
            this.dgvLista.Size = new System.Drawing.Size(895, 412);
            this.dgvLista.TabIndex = 3;
            // 
            // lblLucrari
            // 
            this.lblLucrari.AutoSize = true;
            this.lblLucrari.Location = new System.Drawing.Point(6, 125);
            this.lblLucrari.Name = "lblLucrari";
            this.lblLucrari.Size = new System.Drawing.Size(39, 13);
            this.lblLucrari.TabIndex = 4;
            this.lblLucrari.Text = "Lucrari";
            this.lblLucrari.ToolTipText = null;
            this.lblLucrari.ToolTipTitle = null;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(6, 61);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(30, 13);
            this.lblData.TabIndex = 6;
            this.lblData.Text = "Data";
            this.lblData.ToolTipText = null;
            this.lblData.ToolTipTitle = null;
            // 
            // lblObservatii
            // 
            this.lblObservatii.AutoSize = true;
            this.lblObservatii.Location = new System.Drawing.Point(519, 29);
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
            this.txtObservatii.Location = new System.Drawing.Point(522, 46);
            this.txtObservatii.Multiline = true;
            this.txtObservatii.Name = "txtObservatii";
            this.txtObservatii.ProprietateCorespunzatoare = null;
            this.txtObservatii.RaiseEventLaModificareProgramatica = false;
            this.txtObservatii.Size = new System.Drawing.Size(373, 62);
            this.txtObservatii.TabIndex = 8;
            this.txtObservatii.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtObservatii.TotulCuMajuscule = false;
            // 
            // ctrlDataOraFactura
            // 
            this.ctrlDataOraFactura.AfiseazaButonGuma = false;
            this.ctrlDataOraFactura.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ctrlDataOraFactura.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ctrlDataOraFactura.BackColor = System.Drawing.Color.White;
            this.ctrlDataOraFactura.DataAfisata = new System.DateTime(((long)(0)));
            this.ctrlDataOraFactura.IsInReadOnlyMode = false;
            this.ctrlDataOraFactura.Location = new System.Drawing.Point(68, 56);
            this.ctrlDataOraFactura.Name = "ctrlDataOraFactura";
            this.ctrlDataOraFactura.PragInferior = new System.DateTime(((long)(0)));
            this.ctrlDataOraFactura.PragSuperior = new System.DateTime(((long)(0)));
            this.ctrlDataOraFactura.ProprietateCorespunzatoare = null;
            this.ctrlDataOraFactura.Size = new System.Drawing.Size(191, 23);
            this.ctrlDataOraFactura.TabIndex = 10;
            this.ctrlDataOraFactura.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.ctrlDataOraFactura.TipDeschidereCalendar = CCL.UI.CEnumerariComune.EnumTipDeschidere.StangaSus;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(6, 91);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(31, 13);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "Total";
            this.lblTotal.ToolTipText = null;
            this.lblTotal.ToolTipTitle = null;
            // 
            // txtTotal
            // 
            this.txtTotal.AcceptButton = null;
            this.txtTotal.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtTotal.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.Location = new System.Drawing.Point(68, 87);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ProprietateCorespunzatoare = null;
            this.txtTotal.Size = new System.Drawing.Size(163, 21);
            this.txtTotal.TabIndex = 12;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTotal.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtTotal.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.txtTotal.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotal.ValoareDouble = 0D;
            // 
            // txtCursSchimb
            // 
            this.txtCursSchimb.BackColor = System.Drawing.SystemColors.Window;
            this.txtCursSchimb.Location = new System.Drawing.Point(332, 84);
            this.txtCursSchimb.Name = "txtCursSchimb";
            this.txtCursSchimb.ProprietateCorespunzatoare = null;
            this.txtCursSchimb.Size = new System.Drawing.Size(70, 20);
            this.txtCursSchimb.TabIndex = 13;
            this.txtCursSchimb.Text = "0";
            this.txtCursSchimb.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.txtCursSchimb.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCursSchimb.ValoareDouble = 0D;
            // 
            // lblCurs
            // 
            this.lblCurs.AutoSize = true;
            this.lblCurs.Location = new System.Drawing.Point(277, 88);
            this.lblCurs.Name = "lblCurs";
            this.lblCurs.Size = new System.Drawing.Size(28, 13);
            this.lblCurs.TabIndex = 14;
            this.lblCurs.Text = "Curs";
            this.lblCurs.ToolTipText = null;
            this.lblCurs.ToolTipTitle = null;
            // 
            // ctrlMoneda
            // 
            this.ctrlMoneda.IsInReadOnlyMode = false;
            this.ctrlMoneda.Location = new System.Drawing.Point(332, 55);
            this.ctrlMoneda.Moneda = CDL.iStomaLab.CDefinitiiComune.EnumTipMoneda.Lei;
            this.ctrlMoneda.Name = "ctrlMoneda";
            this.ctrlMoneda.Size = new System.Drawing.Size(139, 24);
            this.ctrlMoneda.TabIndex = 15;
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(277, 61);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(46, 13);
            this.lblMoneda.TabIndex = 16;
            this.lblMoneda.Text = "Moneda";
            this.lblMoneda.ToolTipText = null;
            this.lblMoneda.ToolTipTitle = null;
            // 
            // lblSerieNr
            // 
            this.lblSerieNr.AutoSize = true;
            this.lblSerieNr.Location = new System.Drawing.Point(277, 29);
            this.lblSerieNr.Name = "lblSerieNr";
            this.lblSerieNr.Size = new System.Drawing.Size(45, 13);
            this.lblSerieNr.TabIndex = 17;
            this.lblSerieNr.Text = "Serie-Nr";
            this.lblSerieNr.ToolTipText = null;
            this.lblSerieNr.ToolTipTitle = null;
            // 
            // txtSerieFactura
            // 
            this.txtSerieFactura.CapitalizeazaPrimaLitera = false;
            this.txtSerieFactura.IsInReadOnlyMode = false;
            this.txtSerieFactura.Location = new System.Drawing.Point(332, 25);
            this.txtSerieFactura.Name = "txtSerieFactura";
            this.txtSerieFactura.ProprietateCorespunzatoare = null;
            this.txtSerieFactura.RaiseEventLaModificareProgramatica = false;
            this.txtSerieFactura.Size = new System.Drawing.Size(51, 20);
            this.txtSerieFactura.TabIndex = 18;
            this.txtSerieFactura.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtSerieFactura.TotulCuMajuscule = false;
            // 
            // txtNumarFactura
            // 
            this.txtNumarFactura.BackColor = System.Drawing.SystemColors.Window;
            this.txtNumarFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumarFactura.Location = new System.Drawing.Point(404, 25);
            this.txtNumarFactura.Name = "txtNumarFactura";
            this.txtNumarFactura.ProprietateCorespunzatoare = null;
            this.txtNumarFactura.Size = new System.Drawing.Size(91, 20);
            this.txtNumarFactura.TabIndex = 19;
            this.txtNumarFactura.Text = "0";
            this.txtNumarFactura.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.txtNumarFactura.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNumarFactura.ValoareDouble = 0D;
            // 
            // lblSeparatorSerieNumarFactura
            // 
            this.lblSeparatorSerieNumarFactura.AutoSize = true;
            this.lblSeparatorSerieNumarFactura.Location = new System.Drawing.Point(390, 29);
            this.lblSeparatorSerieNumarFactura.Name = "lblSeparatorSerieNumarFactura";
            this.lblSeparatorSerieNumarFactura.Size = new System.Drawing.Size(10, 13);
            this.lblSeparatorSerieNumarFactura.TabIndex = 20;
            this.lblSeparatorSerieNumarFactura.Text = "-";
            this.lblSeparatorSerieNumarFactura.ToolTipText = null;
            this.lblSeparatorSerieNumarFactura.ToolTipTitle = null;
            // 
            // btnImprima
            // 
            this.btnImprima.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprima.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnImprima.Image = ((System.Drawing.Image)(resources.GetObject("btnImprima.Image")));
            this.btnImprima.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprima.Location = new System.Drawing.Point(858, 120);
            this.btnImprima.Name = "btnImprima";
            this.btnImprima.Size = new System.Drawing.Size(37, 23);
            this.btnImprima.TabIndex = 21;
            this.btnImprima.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Print;
            this.btnImprima.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnImprima.UseVisualStyleBackColor = true;
            // 
            // btnAdauga
            // 
            this.btnAdauga.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdauga.Image = ((System.Drawing.Image)(resources.GetObject("btnAdauga.Image")));
            this.btnAdauga.Location = new System.Drawing.Point(68, 120);
            this.btnAdauga.Name = "btnAdauga";
            this.btnAdauga.Size = new System.Drawing.Size(41, 23);
            this.btnAdauga.TabIndex = 22;
            this.btnAdauga.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdauga.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdauga.UseVisualStyleBackColor = true;
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
            this.txtCautare.Location = new System.Drawing.Point(522, 121);
            this.txtCautare.MaxLength = 32767;
            this.txtCautare.Multiline = false;
            this.txtCautare.Name = "txtCautare";
            this.txtCautare.ProprietateCorespunzatoare = null;
            this.txtCautare.RaiseEventLaModificareProgramatica = false;
            this.txtCautare.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautare.Size = new System.Drawing.Size(330, 20);
            this.txtCautare.TabIndex = 23;
            this.txtCautare.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautare.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautare.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautare.UseSystemPasswordChar = false;
            // 
            // btnFiscalizeaza
            // 
            this.btnFiscalizeaza.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFiscalizeaza.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnFiscalizeaza.Image = null;
            this.btnFiscalizeaza.Location = new System.Drawing.Point(280, 120);
            this.btnFiscalizeaza.Name = "btnFiscalizeaza";
            this.btnFiscalizeaza.Size = new System.Drawing.Size(191, 23);
            this.btnFiscalizeaza.TabIndex = 24;
            this.btnFiscalizeaza.Text = "Fiscalizeaza";
            this.btnFiscalizeaza.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnFiscalizeaza.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnFiscalizeaza.UseVisualStyleBackColor = true;
            // 
            // cboTip
            // 
            this.cboTip.AutoCompletePersonalizat = false;
            this.cboTip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTip.FormattingEnabled = true;
            this.cboTip.HideSelection = true;
            this.cboTip.IsInReadOnlyMode = false;
            this.cboTip.Location = new System.Drawing.Point(68, 25);
            this.cboTip.Name = "cboTip";
            this.cboTip.ProprietateCorespunzatoare = null;
            this.cboTip.Size = new System.Drawing.Size(163, 21);
            this.cboTip.TabIndex = 25;
            this.cboTip.TipulListei = CCL.UI.ComboBoxPersonalizat.EnumTipLista.Nespecificat;
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(6, 29);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(22, 13);
            this.lblTip.TabIndex = 26;
            this.lblTip.Text = "Tip";
            this.lblTip.ToolTipText = null;
            this.lblTip.ToolTipTitle = null;
            // 
            // FormCreeazaFacturaClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.cboTip);
            this.Controls.Add(this.btnFiscalizeaza);
            this.Controls.Add(this.btnAdauga);
            this.Controls.Add(this.btnImprima);
            this.Controls.Add(this.lblSeparatorSerieNumarFactura);
            this.Controls.Add(this.txtNumarFactura);
            this.Controls.Add(this.txtSerieFactura);
            this.Controls.Add(this.lblSerieNr);
            this.Controls.Add(this.lblMoneda);
            this.Controls.Add(this.ctrlMoneda);
            this.Controls.Add(this.lblCurs);
            this.Controls.Add(this.txtCursSchimb);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.ctrlDataOraFactura);
            this.Controls.Add(this.txtObservatii);
            this.Controls.Add(this.lblObservatii);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.lblLucrari);
            this.Controls.Add(this.dgvLista);
            this.Controls.Add(this.ctrlValidareAnulare);
            this.Controls.Add(this.txtCautare);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "FormCreeazaFacturaClient";
            this.Text = "FormCreeazaFacturaClient";
            this.Controls.SetChildIndex(this.txtCautare, 0);
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulare, 0);
            this.Controls.SetChildIndex(this.dgvLista, 0);
            this.Controls.SetChildIndex(this.lblLucrari, 0);
            this.Controls.SetChildIndex(this.lblData, 0);
            this.Controls.SetChildIndex(this.lblObservatii, 0);
            this.Controls.SetChildIndex(this.txtObservatii, 0);
            this.Controls.SetChildIndex(this.ctrlDataOraFactura, 0);
            this.Controls.SetChildIndex(this.lblTotal, 0);
            this.Controls.SetChildIndex(this.txtTotal, 0);
            this.Controls.SetChildIndex(this.txtCursSchimb, 0);
            this.Controls.SetChildIndex(this.lblCurs, 0);
            this.Controls.SetChildIndex(this.ctrlMoneda, 0);
            this.Controls.SetChildIndex(this.lblMoneda, 0);
            this.Controls.SetChildIndex(this.lblSerieNr, 0);
            this.Controls.SetChildIndex(this.txtSerieFactura, 0);
            this.Controls.SetChildIndex(this.txtNumarFactura, 0);
            this.Controls.SetChildIndex(this.lblSeparatorSerieNumarFactura, 0);
            this.Controls.SetChildIndex(this.btnImprima, 0);
            this.Controls.SetChildIndex(this.btnAdauga, 0);
            this.Controls.SetChildIndex(this.btnFiscalizeaza, 0);
            this.Controls.SetChildIndex(this.cboTip, 0);
            this.Controls.SetChildIndex(this.lblTip, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulare;
        private CCL.UI.DataGridViewPersonalizat dgvLista;
        private CCL.UI.LabelPersonalizat lblLucrari;
        private CCL.UI.LabelPersonalizat lblData;
        private CCL.UI.LabelPersonalizat lblObservatii;
        private CCL.UI.TextBoxPersonalizat txtObservatii;
        private CCL.UI.Caramizi.ControlDataOraGuma ctrlDataOraFactura;
        private CCL.UI.LabelPersonalizat lblTotal;
        private CCL.UI.Caramizi.MaskedTextBoxGuma txtTotal;
        private CCL.UI.MaskedTextBoxPersonalizat txtCursSchimb;
        private CCL.UI.LabelPersonalizat lblCurs;
        private CCL.UI.Caramizi.controlLeiEuro ctrlMoneda;
        private CCL.UI.LabelPersonalizat lblMoneda;
        private CCL.UI.LabelPersonalizat lblSerieNr;
        private CCL.UI.TextBoxPersonalizat txtSerieFactura;
        private CCL.UI.MaskedTextBoxPersonalizat txtNumarFactura;
        private CCL.UI.LabelPersonalizat lblSeparatorSerieNumarFactura;
        private CCL.UI.ButtonPersonalizat btnImprima;
        private CCL.UI.ButtonPersonalizat btnAdauga;
        private CCL.UI.Caramizi.TextBoxCautare txtCautare;
        private CCL.UI.ButtonPersonalizat btnFiscalizeaza;
        private CCL.UI.ComboBoxPersonalizat cboTip;
        private CCL.UI.LabelPersonalizat lblTip;
    }
}