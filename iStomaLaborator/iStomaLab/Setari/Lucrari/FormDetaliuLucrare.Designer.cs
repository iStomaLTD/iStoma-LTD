namespace iStomaLab.Setari.Lucrari
{
    partial class FormDetaliuLucrare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetaliuLucrare));
            this.ctrlValidareAnulareLucrare = new CCL.UI.Caramizi.controlValidareAnulare();
            this.lblPret = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlValoareMonetara = new CCL.UI.Caramizi.controlValoareMonetara();
            this.dgvListaEtapaAdaugate = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.btnAdaugaEtapa = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblAdaugaEtapa = new CCL.UI.LabelPersonalizat(this.components);
            this.lblCautaSubcategorieLucrare = new CCL.UI.Caramizi.LabelGumaFind();
            this.lblSubcategorieLucrare = new CCL.UI.LabelPersonalizat(this.components);
            this.txtTermenMediuLucrare = new CCL.UI.MaskedTextBoxPersonalizat(this.components);
            this.lblCautaCategorieLucrare = new CCL.UI.Caramizi.LabelGumaFind();
            this.lblCategorieLucrare = new CCL.UI.LabelPersonalizat(this.components);
            this.lblZileLucrare = new CCL.UI.LabelPersonalizat(this.components);
            this.lblTermenMediuLucrare = new CCL.UI.LabelPersonalizat(this.components);
            this.txtCodLucrare = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblCodLucrare = new CCL.UI.LabelPersonalizat(this.components);
            this.txtPrescurtareLucrare = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblPrescurtareLucrare = new CCL.UI.LabelPersonalizat(this.components);
            this.txtDenumireLucrare = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblDenumireLucrare = new CCL.UI.LabelPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaEtapaAdaugate)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Location = new System.Drawing.Point(-3, 0);
            this.lblTitluEcran.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitluEcran.Size = new System.Drawing.Size(530, 19);
            this.lblTitluEcran.TabIndex = 10;
            this.lblTitluEcran.Text = "FormDetaliuLucrare";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(526, 0);
            this.btnInchidereEcran.Margin = new System.Windows.Forms.Padding(2);
            this.btnInchidereEcran.TabIndex = 11;
            // 
            // ctrlValidareAnulareLucrare
            // 
            this.ctrlValidareAnulareLucrare.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrlValidareAnulareLucrare.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulareLucrare.Location = new System.Drawing.Point(194, 402);
            this.ctrlValidareAnulareLucrare.Name = "ctrlValidareAnulareLucrare";
            this.ctrlValidareAnulareLucrare.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulareLucrare.TabIndex = 9;
            // 
            // lblPret
            // 
            this.lblPret.AutoSize = true;
            this.lblPret.Location = new System.Drawing.Point(18, 59);
            this.lblPret.Name = "lblPret";
            this.lblPret.Size = new System.Drawing.Size(26, 13);
            this.lblPret.TabIndex = 13;
            this.lblPret.Text = "Pret";
            this.lblPret.ToolTipText = null;
            this.lblPret.ToolTipTitle = null;
            // 
            // ctrlValoareMonetara
            // 
            this.ctrlValoareMonetara.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlValoareMonetara.IsInReadOnlyMode = false;
            this.ctrlValoareMonetara.Location = new System.Drawing.Point(94, 53);
            this.ctrlValoareMonetara.Name = "ctrlValoareMonetara";
            this.ctrlValoareMonetara.Size = new System.Drawing.Size(214, 24);
            this.ctrlValoareMonetara.TabIndex = 1;
            this.ctrlValoareMonetara.Valoare = 0D;
            // 
            // dgvListaEtapaAdaugate
            // 
            this.dgvListaEtapaAdaugate.AllowUserToAddRows = false;
            this.dgvListaEtapaAdaugate.AllowUserToDeleteRows = false;
            this.dgvListaEtapaAdaugate.AllowUserToResizeRows = false;
            this.dgvListaEtapaAdaugate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaEtapaAdaugate.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaEtapaAdaugate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaEtapaAdaugate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaEtapaAdaugate.HideSelection = true;
            this.dgvListaEtapaAdaugate.IsInReadOnlyMode = false;
            this.dgvListaEtapaAdaugate.Location = new System.Drawing.Point(10, 219);
            this.dgvListaEtapaAdaugate.MultiSelect = false;
            this.dgvListaEtapaAdaugate.Name = "dgvListaEtapaAdaugate";
            this.dgvListaEtapaAdaugate.ProprietateCorespunzatoare = "";
            this.dgvListaEtapaAdaugate.RowHeadersVisible = false;
            this.dgvListaEtapaAdaugate.SeIncarca = false;
            this.dgvListaEtapaAdaugate.SelectedText = "";
            this.dgvListaEtapaAdaugate.SelectionLength = 0;
            this.dgvListaEtapaAdaugate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaEtapaAdaugate.SelectionStart = 0;
            this.dgvListaEtapaAdaugate.Size = new System.Drawing.Size(533, 169);
            this.dgvListaEtapaAdaugate.TabIndex = 8;
            // 
            // btnAdaugaEtapa
            // 
            this.btnAdaugaEtapa.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdaugaEtapa.Image = ((System.Drawing.Image)(resources.GetObject("btnAdaugaEtapa.Image")));
            this.btnAdaugaEtapa.Location = new System.Drawing.Point(94, 192);
            this.btnAdaugaEtapa.Name = "btnAdaugaEtapa";
            this.btnAdaugaEtapa.Size = new System.Drawing.Size(40, 21);
            this.btnAdaugaEtapa.TabIndex = 7;
            this.btnAdaugaEtapa.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdaugaEtapa.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdaugaEtapa.UseVisualStyleBackColor = true;
            // 
            // lblAdaugaEtapa
            // 
            this.lblAdaugaEtapa.AutoSize = true;
            this.lblAdaugaEtapa.Location = new System.Drawing.Point(18, 196);
            this.lblAdaugaEtapa.Name = "lblAdaugaEtapa";
            this.lblAdaugaEtapa.Size = new System.Drawing.Size(74, 13);
            this.lblAdaugaEtapa.TabIndex = 20;
            this.lblAdaugaEtapa.Text = "Adauga etapa";
            this.lblAdaugaEtapa.ToolTipText = null;
            this.lblAdaugaEtapa.ToolTipTitle = null;
            // 
            // lblCautaSubcategorieLucrare
            // 
            this.lblCautaSubcategorieLucrare.AfiseazaButonCautare = true;
            this.lblCautaSubcategorieLucrare.AfiseazaButonDetalii = false;
            this.lblCautaSubcategorieLucrare.AfiseazaButonGuma = true;
            this.lblCautaSubcategorieLucrare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCautaSubcategorieLucrare.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.lblCautaSubcategorieLucrare.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.lblCautaSubcategorieLucrare.BackColor = System.Drawing.Color.White;
            this.lblCautaSubcategorieLucrare.FolosesteToString = false;
            this.lblCautaSubcategorieLucrare.IsInReadOnlyMode = false;
            this.lblCautaSubcategorieLucrare.Location = new System.Drawing.Point(94, 154);
            this.lblCautaSubcategorieLucrare.Margin = new System.Windows.Forms.Padding(2);
            this.lblCautaSubcategorieLucrare.Name = "lblCautaSubcategorieLucrare";
            this.lblCautaSubcategorieLucrare.ObiectAfisajCorespunzator = null;
            this.lblCautaSubcategorieLucrare.ObiectCorespunzator = null;
            this.lblCautaSubcategorieLucrare.ProprietateCorespunzatoare = null;
            this.lblCautaSubcategorieLucrare.Size = new System.Drawing.Size(441, 19);
            this.lblCautaSubcategorieLucrare.TabIndex = 6;
            this.lblCautaSubcategorieLucrare.Text = "...";
            this.lblCautaSubcategorieLucrare.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCautaSubcategorieLucrare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.lblCautaSubcategorieLucrare.ToolTipText = null;
            this.lblCautaSubcategorieLucrare.ToolTipTitle = null;
            // 
            // lblSubcategorieLucrare
            // 
            this.lblSubcategorieLucrare.AutoSize = true;
            this.lblSubcategorieLucrare.Location = new System.Drawing.Point(18, 159);
            this.lblSubcategorieLucrare.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubcategorieLucrare.Name = "lblSubcategorieLucrare";
            this.lblSubcategorieLucrare.Size = new System.Drawing.Size(70, 13);
            this.lblSubcategorieLucrare.TabIndex = 19;
            this.lblSubcategorieLucrare.Text = "Subcategorie";
            this.lblSubcategorieLucrare.ToolTipText = null;
            this.lblSubcategorieLucrare.ToolTipTitle = null;
            // 
            // txtTermenMediuLucrare
            // 
            this.txtTermenMediuLucrare.BackColor = System.Drawing.SystemColors.Window;
            this.txtTermenMediuLucrare.Location = new System.Drawing.Point(94, 88);
            this.txtTermenMediuLucrare.Margin = new System.Windows.Forms.Padding(2);
            this.txtTermenMediuLucrare.Name = "txtTermenMediuLucrare";
            this.txtTermenMediuLucrare.ProprietateCorespunzatoare = null;
            this.txtTermenMediuLucrare.Size = new System.Drawing.Size(36, 20);
            this.txtTermenMediuLucrare.TabIndex = 3;
            this.txtTermenMediuLucrare.Text = "0";
            this.txtTermenMediuLucrare.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.txtTermenMediuLucrare.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTermenMediuLucrare.ValoareDouble = 0D;
            // 
            // lblCautaCategorieLucrare
            // 
            this.lblCautaCategorieLucrare.AfiseazaButonCautare = true;
            this.lblCautaCategorieLucrare.AfiseazaButonDetalii = false;
            this.lblCautaCategorieLucrare.AfiseazaButonGuma = true;
            this.lblCautaCategorieLucrare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCautaCategorieLucrare.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.lblCautaCategorieLucrare.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.lblCautaCategorieLucrare.BackColor = System.Drawing.Color.White;
            this.lblCautaCategorieLucrare.FolosesteToString = false;
            this.lblCautaCategorieLucrare.IsInReadOnlyMode = false;
            this.lblCautaCategorieLucrare.Location = new System.Drawing.Point(94, 125);
            this.lblCautaCategorieLucrare.Margin = new System.Windows.Forms.Padding(2);
            this.lblCautaCategorieLucrare.Name = "lblCautaCategorieLucrare";
            this.lblCautaCategorieLucrare.ObiectAfisajCorespunzator = null;
            this.lblCautaCategorieLucrare.ObiectCorespunzator = null;
            this.lblCautaCategorieLucrare.ProprietateCorespunzatoare = null;
            this.lblCautaCategorieLucrare.Size = new System.Drawing.Size(441, 19);
            this.lblCautaCategorieLucrare.TabIndex = 5;
            this.lblCautaCategorieLucrare.Text = "...";
            this.lblCautaCategorieLucrare.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCautaCategorieLucrare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.lblCautaCategorieLucrare.ToolTipText = null;
            this.lblCautaCategorieLucrare.ToolTipTitle = null;
            // 
            // lblCategorieLucrare
            // 
            this.lblCategorieLucrare.AutoSize = true;
            this.lblCategorieLucrare.Location = new System.Drawing.Point(18, 128);
            this.lblCategorieLucrare.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCategorieLucrare.Name = "lblCategorieLucrare";
            this.lblCategorieLucrare.Size = new System.Drawing.Size(52, 13);
            this.lblCategorieLucrare.TabIndex = 18;
            this.lblCategorieLucrare.Text = "Categorie";
            this.lblCategorieLucrare.ToolTipText = null;
            this.lblCategorieLucrare.ToolTipTitle = null;
            // 
            // lblZileLucrare
            // 
            this.lblZileLucrare.AutoSize = true;
            this.lblZileLucrare.Location = new System.Drawing.Point(134, 92);
            this.lblZileLucrare.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblZileLucrare.Name = "lblZileLucrare";
            this.lblZileLucrare.Size = new System.Drawing.Size(22, 13);
            this.lblZileLucrare.TabIndex = 16;
            this.lblZileLucrare.Text = "zile";
            this.lblZileLucrare.ToolTipText = null;
            this.lblZileLucrare.ToolTipTitle = null;
            // 
            // lblTermenMediuLucrare
            // 
            this.lblTermenMediuLucrare.AutoSize = true;
            this.lblTermenMediuLucrare.Location = new System.Drawing.Point(18, 92);
            this.lblTermenMediuLucrare.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTermenMediuLucrare.Name = "lblTermenMediuLucrare";
            this.lblTermenMediuLucrare.Size = new System.Drawing.Size(74, 13);
            this.lblTermenMediuLucrare.TabIndex = 15;
            this.lblTermenMediuLucrare.Text = "Termen mediu";
            this.lblTermenMediuLucrare.ToolTipText = null;
            this.lblTermenMediuLucrare.ToolTipTitle = null;
            // 
            // txtCodLucrare
            // 
            this.txtCodLucrare.CapitalizeazaPrimaLitera = false;
            this.txtCodLucrare.IsInReadOnlyMode = false;
            this.txtCodLucrare.Location = new System.Drawing.Point(376, 55);
            this.txtCodLucrare.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodLucrare.Name = "txtCodLucrare";
            this.txtCodLucrare.ProprietateCorespunzatoare = null;
            this.txtCodLucrare.RaiseEventLaModificareProgramatica = false;
            this.txtCodLucrare.Size = new System.Drawing.Size(159, 20);
            this.txtCodLucrare.TabIndex = 2;
            this.txtCodLucrare.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCodLucrare.TotulCuMajuscule = false;
            // 
            // lblCodLucrare
            // 
            this.lblCodLucrare.AutoSize = true;
            this.lblCodLucrare.Location = new System.Drawing.Point(346, 59);
            this.lblCodLucrare.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCodLucrare.Name = "lblCodLucrare";
            this.lblCodLucrare.Size = new System.Drawing.Size(26, 13);
            this.lblCodLucrare.TabIndex = 14;
            this.lblCodLucrare.Text = "Cod";
            this.lblCodLucrare.ToolTipText = null;
            this.lblCodLucrare.ToolTipTitle = null;
            // 
            // txtPrescurtareLucrare
            // 
            this.txtPrescurtareLucrare.CapitalizeazaPrimaLitera = false;
            this.txtPrescurtareLucrare.IsInReadOnlyMode = false;
            this.txtPrescurtareLucrare.Location = new System.Drawing.Point(376, 88);
            this.txtPrescurtareLucrare.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrescurtareLucrare.Name = "txtPrescurtareLucrare";
            this.txtPrescurtareLucrare.ProprietateCorespunzatoare = null;
            this.txtPrescurtareLucrare.RaiseEventLaModificareProgramatica = false;
            this.txtPrescurtareLucrare.Size = new System.Drawing.Size(159, 20);
            this.txtPrescurtareLucrare.TabIndex = 4;
            this.txtPrescurtareLucrare.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtPrescurtareLucrare.TotulCuMajuscule = false;
            // 
            // lblPrescurtareLucrare
            // 
            this.lblPrescurtareLucrare.AutoSize = true;
            this.lblPrescurtareLucrare.Location = new System.Drawing.Point(311, 92);
            this.lblPrescurtareLucrare.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrescurtareLucrare.Name = "lblPrescurtareLucrare";
            this.lblPrescurtareLucrare.Size = new System.Drawing.Size(61, 13);
            this.lblPrescurtareLucrare.TabIndex = 17;
            this.lblPrescurtareLucrare.Text = "Prescurtare";
            this.lblPrescurtareLucrare.ToolTipText = null;
            this.lblPrescurtareLucrare.ToolTipTitle = null;
            // 
            // txtDenumireLucrare
            // 
            this.txtDenumireLucrare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenumireLucrare.CapitalizeazaPrimaLitera = false;
            this.txtDenumireLucrare.IsInReadOnlyMode = false;
            this.txtDenumireLucrare.Location = new System.Drawing.Point(94, 23);
            this.txtDenumireLucrare.Margin = new System.Windows.Forms.Padding(2);
            this.txtDenumireLucrare.Name = "txtDenumireLucrare";
            this.txtDenumireLucrare.ProprietateCorespunzatoare = null;
            this.txtDenumireLucrare.RaiseEventLaModificareProgramatica = false;
            this.txtDenumireLucrare.Size = new System.Drawing.Size(441, 20);
            this.txtDenumireLucrare.TabIndex = 0;
            this.txtDenumireLucrare.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtDenumireLucrare.TotulCuMajuscule = false;
            // 
            // lblDenumireLucrare
            // 
            this.lblDenumireLucrare.AutoSize = true;
            this.lblDenumireLucrare.Location = new System.Drawing.Point(18, 27);
            this.lblDenumireLucrare.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDenumireLucrare.Name = "lblDenumireLucrare";
            this.lblDenumireLucrare.Size = new System.Drawing.Size(52, 13);
            this.lblDenumireLucrare.TabIndex = 12;
            this.lblDenumireLucrare.Text = "Denumire";
            this.lblDenumireLucrare.ToolTipText = null;
            this.lblDenumireLucrare.ToolTipTitle = null;
            // 
            // FormDetaliuLucrare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 433);
            this.Controls.Add(this.lblPret);
            this.Controls.Add(this.ctrlValoareMonetara);
            this.Controls.Add(this.dgvListaEtapaAdaugate);
            this.Controls.Add(this.btnAdaugaEtapa);
            this.Controls.Add(this.lblAdaugaEtapa);
            this.Controls.Add(this.lblCautaSubcategorieLucrare);
            this.Controls.Add(this.lblSubcategorieLucrare);
            this.Controls.Add(this.txtTermenMediuLucrare);
            this.Controls.Add(this.lblCautaCategorieLucrare);
            this.Controls.Add(this.lblCategorieLucrare);
            this.Controls.Add(this.lblZileLucrare);
            this.Controls.Add(this.lblTermenMediuLucrare);
            this.Controls.Add(this.txtCodLucrare);
            this.Controls.Add(this.lblCodLucrare);
            this.Controls.Add(this.txtPrescurtareLucrare);
            this.Controls.Add(this.lblPrescurtareLucrare);
            this.Controls.Add(this.txtDenumireLucrare);
            this.Controls.Add(this.lblDenumireLucrare);
            this.Controls.Add(this.ctrlValidareAnulareLucrare);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(549, 433);
            this.Name = "FormDetaliuLucrare";
            this.Text = "FormDetaliuLucrare";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulareLucrare, 0);
            this.Controls.SetChildIndex(this.lblDenumireLucrare, 0);
            this.Controls.SetChildIndex(this.txtDenumireLucrare, 0);
            this.Controls.SetChildIndex(this.lblPrescurtareLucrare, 0);
            this.Controls.SetChildIndex(this.txtPrescurtareLucrare, 0);
            this.Controls.SetChildIndex(this.lblCodLucrare, 0);
            this.Controls.SetChildIndex(this.txtCodLucrare, 0);
            this.Controls.SetChildIndex(this.lblTermenMediuLucrare, 0);
            this.Controls.SetChildIndex(this.lblZileLucrare, 0);
            this.Controls.SetChildIndex(this.lblCategorieLucrare, 0);
            this.Controls.SetChildIndex(this.lblCautaCategorieLucrare, 0);
            this.Controls.SetChildIndex(this.txtTermenMediuLucrare, 0);
            this.Controls.SetChildIndex(this.lblSubcategorieLucrare, 0);
            this.Controls.SetChildIndex(this.lblCautaSubcategorieLucrare, 0);
            this.Controls.SetChildIndex(this.lblAdaugaEtapa, 0);
            this.Controls.SetChildIndex(this.btnAdaugaEtapa, 0);
            this.Controls.SetChildIndex(this.dgvListaEtapaAdaugate, 0);
            this.Controls.SetChildIndex(this.ctrlValoareMonetara, 0);
            this.Controls.SetChildIndex(this.lblPret, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaEtapaAdaugate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulareLucrare;
        private CCL.UI.LabelPersonalizat lblPret;
        private CCL.UI.Caramizi.controlValoareMonetara ctrlValoareMonetara;
        private CCL.UI.DataGridViewPersonalizat dgvListaEtapaAdaugate;
        private CCL.UI.ButtonPersonalizat btnAdaugaEtapa;
        private CCL.UI.LabelPersonalizat lblAdaugaEtapa;
        private CCL.UI.Caramizi.LabelGumaFind lblCautaSubcategorieLucrare;
        private CCL.UI.LabelPersonalizat lblSubcategorieLucrare;
        private CCL.UI.MaskedTextBoxPersonalizat txtTermenMediuLucrare;
        private CCL.UI.Caramizi.LabelGumaFind lblCautaCategorieLucrare;
        private CCL.UI.LabelPersonalizat lblCategorieLucrare;
        private CCL.UI.LabelPersonalizat lblZileLucrare;
        private CCL.UI.LabelPersonalizat lblTermenMediuLucrare;
        private CCL.UI.TextBoxPersonalizat txtCodLucrare;
        private CCL.UI.LabelPersonalizat lblCodLucrare;
        private CCL.UI.TextBoxPersonalizat txtPrescurtareLucrare;
        private CCL.UI.LabelPersonalizat lblPrescurtareLucrare;
        private CCL.UI.TextBoxPersonalizat txtDenumireLucrare;
        private CCL.UI.LabelPersonalizat lblDenumireLucrare;
    }
}