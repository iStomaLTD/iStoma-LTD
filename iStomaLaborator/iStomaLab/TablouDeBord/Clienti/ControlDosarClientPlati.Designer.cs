using static CDL.iStomaLab.CDefinitiiComune;

namespace iStomaLab.TablouDeBord.Clienti
{
    partial class ControlDosarClientPlati
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlDosarClientPlati));
            this.panelPlatiIncasari = new CCL.UI.Caramizi.PanelContainerCCL();
            this.lblSold = new CCL.UI.LabelPersonalizat(this.components);
            this.lblTotalIncasari = new CCL.UI.LabelPersonalizat(this.components);
            this.btnAdaugaIncasare = new CCL.UI.ButtonPersonalizat(this.components);
            this.dgvIncasari = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.lblTitluIncasari = new CCL.UI.LabelPersonalizat(this.components);
            this.panelPlatiFacturi = new CCL.UI.Caramizi.PanelContainerCCL();
            this.lblTotalFacturi = new CCL.UI.LabelPersonalizat(this.components);
            this.btnAdaugaFactura = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblTitluFacturi = new CCL.UI.LabelPersonalizat(this.components);
            this.dgvFacturi = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.ctrlDataContract = new CCL.UI.controlAlegeData();
            this.lblReprezentant = new CCL.UI.LabelPersonalizat(this.components);
            this.lblDataContract = new CCL.UI.LabelPersonalizat(this.components);
            this.cboTipReprezentant = new CCL.UI.ComboBoxPersonalizat(this.components);
            this.txtObservatiiDateFirma = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblObservatiiDateFirma = new CCL.UI.LabelPersonalizat(this.components);
            this.txtNrContract = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblNrContract = new CCL.UI.LabelPersonalizat(this.components);
            this.txtReprezentantLegal = new CCL.UI.TextBoxPersonalizat(this.components);
            this.ctrlCautareBanca = new iStomaLab.Generale.ControlCautareBanca();
            this.lblBanca = new CCL.UI.LabelPersonalizat(this.components);
            this.txtIBAN = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblIBAN = new CCL.UI.LabelPersonalizat(this.components);
            this.txtNrRegCom = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblNrRegCom = new CCL.UI.LabelPersonalizat(this.components);
            this.txtCUI = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblCUI = new CCL.UI.LabelPersonalizat(this.components);
            this.cboTipClient = new CCL.UI.ComboBoxPersonalizat(this.components);
            this.lblTip = new CCL.UI.LabelPersonalizat(this.components);
            this.txtDenumireFiscala = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblDenumireFiscala = new CCL.UI.LabelPersonalizat(this.components);
            this.lblCalitate = new CCL.UI.LabelPersonalizat(this.components);
            this.panelPlatiIncasari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncasari)).BeginInit();
            this.panelPlatiFacturi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturi)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPlatiIncasari
            // 
            this.panelPlatiIncasari.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPlatiIncasari.AutoScaleDimensions = new System.Drawing.SizeF(0F, 0F);
            this.panelPlatiIncasari.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.panelPlatiIncasari.BackColor = System.Drawing.Color.White;
            this.panelPlatiIncasari.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPlatiIncasari.Controls.Add(this.lblSold);
            this.panelPlatiIncasari.Controls.Add(this.lblTotalIncasari);
            this.panelPlatiIncasari.Controls.Add(this.btnAdaugaIncasare);
            this.panelPlatiIncasari.Controls.Add(this.dgvIncasari);
            this.panelPlatiIncasari.Controls.Add(this.lblTitluIncasari);
            this.panelPlatiIncasari.Location = new System.Drawing.Point(-1, 314);
            this.panelPlatiIncasari.Margin = new System.Windows.Forms.Padding(2);
            this.panelPlatiIncasari.Name = "panelPlatiIncasari";
            this.panelPlatiIncasari.Size = new System.Drawing.Size(539, 174);
            this.panelPlatiIncasari.TabIndex = 0;
            this.panelPlatiIncasari.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // lblSold
            // 
            this.lblSold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSold.Location = new System.Drawing.Point(2, 144);
            this.lblSold.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSold.Name = "lblSold";
            this.lblSold.Size = new System.Drawing.Size(244, 24);
            this.lblSold.TabIndex = 5;
            this.lblSold.Text = "Sold";
            this.lblSold.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSold.ToolTipText = null;
            this.lblSold.ToolTipTitle = null;
            // 
            // lblTotalIncasari
            // 
            this.lblTotalIncasari.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalIncasari.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTotalIncasari.Location = new System.Drawing.Point(230, 144);
            this.lblTotalIncasari.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalIncasari.Name = "lblTotalIncasari";
            this.lblTotalIncasari.Size = new System.Drawing.Size(302, 24);
            this.lblTotalIncasari.TabIndex = 4;
            this.lblTotalIncasari.Text = "Total incasari";
            this.lblTotalIncasari.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotalIncasari.ToolTipText = null;
            this.lblTotalIncasari.ToolTipTitle = null;
            // 
            // btnAdaugaIncasare
            // 
            this.btnAdaugaIncasare.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdaugaIncasare.Image = ((System.Drawing.Image)(resources.GetObject("btnAdaugaIncasare.Image")));
            this.btnAdaugaIncasare.Location = new System.Drawing.Point(62, 4);
            this.btnAdaugaIncasare.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdaugaIncasare.Name = "btnAdaugaIncasare";
            this.btnAdaugaIncasare.Size = new System.Drawing.Size(38, 25);
            this.btnAdaugaIncasare.TabIndex = 0;
            this.btnAdaugaIncasare.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdaugaIncasare.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdaugaIncasare.UseVisualStyleBackColor = true;
            // 
            // dgvIncasari
            // 
            this.dgvIncasari.AllowUserToAddRows = false;
            this.dgvIncasari.AllowUserToDeleteRows = false;
            this.dgvIncasari.AllowUserToResizeRows = false;
            this.dgvIncasari.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIncasari.BackgroundColor = System.Drawing.Color.White;
            this.dgvIncasari.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvIncasari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncasari.HideSelection = true;
            this.dgvIncasari.IsInReadOnlyMode = false;
            this.dgvIncasari.Location = new System.Drawing.Point(0, 34);
            this.dgvIncasari.Margin = new System.Windows.Forms.Padding(2);
            this.dgvIncasari.MultiSelect = false;
            this.dgvIncasari.Name = "dgvIncasari";
            this.dgvIncasari.ProprietateCorespunzatoare = "";
            this.dgvIncasari.RowHeadersVisible = false;
            this.dgvIncasari.RowTemplate.Height = 24;
            this.dgvIncasari.SeIncarca = false;
            this.dgvIncasari.SelectedText = "";
            this.dgvIncasari.SelectionLength = 0;
            this.dgvIncasari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIncasari.SelectionStart = 0;
            this.dgvIncasari.Size = new System.Drawing.Size(538, 107);
            this.dgvIncasari.TabIndex = 2;
            // 
            // lblTitluIncasari
            // 
            this.lblTitluIncasari.AutoSize = true;
            this.lblTitluIncasari.Location = new System.Drawing.Point(5, 10);
            this.lblTitluIncasari.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitluIncasari.Name = "lblTitluIncasari";
            this.lblTitluIncasari.Size = new System.Drawing.Size(44, 13);
            this.lblTitluIncasari.TabIndex = 0;
            this.lblTitluIncasari.Text = "Incasari";
            this.lblTitluIncasari.ToolTipText = null;
            this.lblTitluIncasari.ToolTipTitle = null;
            // 
            // panelPlatiFacturi
            // 
            this.panelPlatiFacturi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPlatiFacturi.AutoScaleDimensions = new System.Drawing.SizeF(0F, 0F);
            this.panelPlatiFacturi.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.panelPlatiFacturi.BackColor = System.Drawing.Color.White;
            this.panelPlatiFacturi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPlatiFacturi.Controls.Add(this.lblTotalFacturi);
            this.panelPlatiFacturi.Controls.Add(this.btnAdaugaFactura);
            this.panelPlatiFacturi.Controls.Add(this.lblTitluFacturi);
            this.panelPlatiFacturi.Controls.Add(this.dgvFacturi);
            this.panelPlatiFacturi.Location = new System.Drawing.Point(-1, -1);
            this.panelPlatiFacturi.Margin = new System.Windows.Forms.Padding(2);
            this.panelPlatiFacturi.Name = "panelPlatiFacturi";
            this.panelPlatiFacturi.Size = new System.Drawing.Size(539, 316);
            this.panelPlatiFacturi.TabIndex = 1;
            this.panelPlatiFacturi.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // lblTotalFacturi
            // 
            this.lblTotalFacturi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalFacturi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTotalFacturi.Location = new System.Drawing.Point(148, 287);
            this.lblTotalFacturi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalFacturi.Name = "lblTotalFacturi";
            this.lblTotalFacturi.Size = new System.Drawing.Size(387, 24);
            this.lblTotalFacturi.TabIndex = 3;
            this.lblTotalFacturi.Text = "Total facturi";
            this.lblTotalFacturi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotalFacturi.ToolTipText = null;
            this.lblTotalFacturi.ToolTipTitle = null;
            // 
            // btnAdaugaFactura
            // 
            this.btnAdaugaFactura.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdaugaFactura.Image = ((System.Drawing.Image)(resources.GetObject("btnAdaugaFactura.Image")));
            this.btnAdaugaFactura.Location = new System.Drawing.Point(62, 3);
            this.btnAdaugaFactura.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdaugaFactura.Name = "btnAdaugaFactura";
            this.btnAdaugaFactura.Size = new System.Drawing.Size(38, 25);
            this.btnAdaugaFactura.TabIndex = 0;
            this.btnAdaugaFactura.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdaugaFactura.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdaugaFactura.UseVisualStyleBackColor = true;
            // 
            // lblTitluFacturi
            // 
            this.lblTitluFacturi.AutoSize = true;
            this.lblTitluFacturi.Location = new System.Drawing.Point(5, 9);
            this.lblTitluFacturi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitluFacturi.Name = "lblTitluFacturi";
            this.lblTitluFacturi.Size = new System.Drawing.Size(39, 13);
            this.lblTitluFacturi.TabIndex = 0;
            this.lblTitluFacturi.Text = "Facturi";
            this.lblTitluFacturi.ToolTipText = null;
            this.lblTitluFacturi.ToolTipTitle = null;
            // 
            // dgvFacturi
            // 
            this.dgvFacturi.AllowUserToAddRows = false;
            this.dgvFacturi.AllowUserToDeleteRows = false;
            this.dgvFacturi.AllowUserToResizeRows = false;
            this.dgvFacturi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFacturi.BackgroundColor = System.Drawing.Color.White;
            this.dgvFacturi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvFacturi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturi.HideSelection = true;
            this.dgvFacturi.IsInReadOnlyMode = false;
            this.dgvFacturi.Location = new System.Drawing.Point(0, 33);
            this.dgvFacturi.Margin = new System.Windows.Forms.Padding(2);
            this.dgvFacturi.MultiSelect = false;
            this.dgvFacturi.Name = "dgvFacturi";
            this.dgvFacturi.ProprietateCorespunzatoare = "";
            this.dgvFacturi.RowHeadersVisible = false;
            this.dgvFacturi.RowTemplate.Height = 24;
            this.dgvFacturi.SeIncarca = false;
            this.dgvFacturi.SelectedText = "";
            this.dgvFacturi.SelectionLength = 0;
            this.dgvFacturi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturi.SelectionStart = 0;
            this.dgvFacturi.Size = new System.Drawing.Size(538, 251);
            this.dgvFacturi.TabIndex = 1;
            // 
            // ctrlDataContract
            // 
            this.ctrlDataContract.AfiseazaButonGuma = false;
            this.ctrlDataContract.AfiseazaCuOra = false;
            this.ctrlDataContract.AfiseazaCuSecunde = false;
            this.ctrlDataContract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlDataContract.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ctrlDataContract.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ctrlDataContract.BackColor = System.Drawing.Color.White;
            this.ctrlDataContract.DataAfisata = new System.DateTime(((long)(0)));
            this.ctrlDataContract.IsInReadOnlyMode = false;
            this.ctrlDataContract.Location = new System.Drawing.Point(607, 230);
            this.ctrlDataContract.Name = "ctrlDataContract";
            this.ctrlDataContract.PragInferior = new System.DateTime(((long)(0)));
            this.ctrlDataContract.PragSuperior = new System.DateTime(((long)(0)));
            this.ctrlDataContract.ProprietateCorespunzatoare = null;
            this.ctrlDataContract.Size = new System.Drawing.Size(109, 21);
            this.ctrlDataContract.TabIndex = 12;
            this.ctrlDataContract.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.ctrlDataContract.TipDeschidereCalendar = CCL.UI.CEnumerariComune.EnumTipDeschidere.StangaSus;
            // 
            // lblReprezentant
            // 
            this.lblReprezentant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReprezentant.AutoSize = true;
            this.lblReprezentant.Location = new System.Drawing.Point(544, 151);
            this.lblReprezentant.Name = "lblReprezentant";
            this.lblReprezentant.Size = new System.Drawing.Size(33, 13);
            this.lblReprezentant.TabIndex = 38;
            this.lblReprezentant.Text = "Repr.";
            this.lblReprezentant.ToolTipText = null;
            this.lblReprezentant.ToolTipTitle = null;
            // 
            // lblDataContract
            // 
            this.lblDataContract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDataContract.AutoSize = true;
            this.lblDataContract.Location = new System.Drawing.Point(544, 236);
            this.lblDataContract.Name = "lblDataContract";
            this.lblDataContract.Size = new System.Drawing.Size(60, 13);
            this.lblDataContract.TabIndex = 36;
            this.lblDataContract.Text = "Data contr.";
            this.lblDataContract.ToolTipText = null;
            this.lblDataContract.ToolTipTitle = null;
            // 
            // cboTipReprezentant
            // 
            this.cboTipReprezentant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipReprezentant.AutoCompletePersonalizat = false;
            this.cboTipReprezentant.FormattingEnabled = true;
            this.cboTipReprezentant.HideSelection = true;
            this.cboTipReprezentant.IsInReadOnlyMode = false;
            this.cboTipReprezentant.Location = new System.Drawing.Point(607, 172);
            this.cboTipReprezentant.Name = "cboTipReprezentant";
            this.cboTipReprezentant.ProprietateCorespunzatoare = null;
            this.cboTipReprezentant.Size = new System.Drawing.Size(255, 21);
            this.cboTipReprezentant.TabIndex = 10;
            this.cboTipReprezentant.TipulListei = CCL.UI.ComboBoxPersonalizat.EnumTipLista.Nespecificat;
            // 
            // txtObservatiiDateFirma
            // 
            this.txtObservatiiDateFirma.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservatiiDateFirma.CapitalizeazaPrimaLitera = false;
            this.txtObservatiiDateFirma.IsInReadOnlyMode = false;
            this.txtObservatiiDateFirma.Location = new System.Drawing.Point(547, 287);
            this.txtObservatiiDateFirma.Multiline = true;
            this.txtObservatiiDateFirma.Name = "txtObservatiiDateFirma";
            this.txtObservatiiDateFirma.ProprietateCorespunzatoare = null;
            this.txtObservatiiDateFirma.RaiseEventLaModificareProgramatica = false;
            this.txtObservatiiDateFirma.Size = new System.Drawing.Size(315, 194);
            this.txtObservatiiDateFirma.TabIndex = 13;
            this.txtObservatiiDateFirma.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtObservatiiDateFirma.TotulCuMajuscule = false;
            // 
            // lblObservatiiDateFirma
            // 
            this.lblObservatiiDateFirma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblObservatiiDateFirma.AutoSize = true;
            this.lblObservatiiDateFirma.Location = new System.Drawing.Point(544, 267);
            this.lblObservatiiDateFirma.Name = "lblObservatiiDateFirma";
            this.lblObservatiiDateFirma.Size = new System.Drawing.Size(54, 13);
            this.lblObservatiiDateFirma.TabIndex = 32;
            this.lblObservatiiDateFirma.Text = "Observatii";
            this.lblObservatiiDateFirma.ToolTipText = null;
            this.lblObservatiiDateFirma.ToolTipTitle = null;
            // 
            // txtNrContract
            // 
            this.txtNrContract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNrContract.CapitalizeazaPrimaLitera = false;
            this.txtNrContract.IsInReadOnlyMode = false;
            this.txtNrContract.Location = new System.Drawing.Point(607, 201);
            this.txtNrContract.Name = "txtNrContract";
            this.txtNrContract.ProprietateCorespunzatoare = null;
            this.txtNrContract.RaiseEventLaModificareProgramatica = false;
            this.txtNrContract.Size = new System.Drawing.Size(109, 20);
            this.txtNrContract.TabIndex = 11;
            this.txtNrContract.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtNrContract.TotulCuMajuscule = false;
            // 
            // lblNrContract
            // 
            this.lblNrContract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNrContract.AutoSize = true;
            this.lblNrContract.Location = new System.Drawing.Point(544, 205);
            this.lblNrContract.Name = "lblNrContract";
            this.lblNrContract.Size = new System.Drawing.Size(51, 13);
            this.lblNrContract.TabIndex = 28;
            this.lblNrContract.Text = "Nr. contr.";
            this.lblNrContract.ToolTipText = null;
            this.lblNrContract.ToolTipTitle = null;
            // 
            // txtReprezentantLegal
            // 
            this.txtReprezentantLegal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReprezentantLegal.CapitalizeazaPrimaLitera = false;
            this.txtReprezentantLegal.IsInReadOnlyMode = false;
            this.txtReprezentantLegal.Location = new System.Drawing.Point(607, 145);
            this.txtReprezentantLegal.Name = "txtReprezentantLegal";
            this.txtReprezentantLegal.ProprietateCorespunzatoare = null;
            this.txtReprezentantLegal.RaiseEventLaModificareProgramatica = false;
            this.txtReprezentantLegal.Size = new System.Drawing.Size(255, 20);
            this.txtReprezentantLegal.TabIndex = 9;
            this.txtReprezentantLegal.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtReprezentantLegal.TotulCuMajuscule = false;
            // 
            // ctrlCautareBanca
            // 
            this.ctrlCautareBanca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlCautareBanca.Location = new System.Drawing.Point(607, 113);
            this.ctrlCautareBanca.Name = "ctrlCautareBanca";
            this.ctrlCautareBanca.Size = new System.Drawing.Size(255, 24);
            this.ctrlCautareBanca.TabIndex = 8;
            // 
            // lblBanca
            // 
            this.lblBanca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBanca.AutoSize = true;
            this.lblBanca.Location = new System.Drawing.Point(544, 119);
            this.lblBanca.Name = "lblBanca";
            this.lblBanca.Size = new System.Drawing.Size(38, 13);
            this.lblBanca.TabIndex = 22;
            this.lblBanca.Text = "Banca";
            this.lblBanca.ToolTipText = null;
            this.lblBanca.ToolTipTitle = null;
            // 
            // txtIBAN
            // 
            this.txtIBAN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIBAN.CapitalizeazaPrimaLitera = false;
            this.txtIBAN.IsInReadOnlyMode = false;
            this.txtIBAN.Location = new System.Drawing.Point(607, 88);
            this.txtIBAN.Name = "txtIBAN";
            this.txtIBAN.ProprietateCorespunzatoare = null;
            this.txtIBAN.RaiseEventLaModificareProgramatica = false;
            this.txtIBAN.Size = new System.Drawing.Size(255, 20);
            this.txtIBAN.TabIndex = 7;
            this.txtIBAN.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtIBAN.TotulCuMajuscule = false;
            // 
            // lblIBAN
            // 
            this.lblIBAN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIBAN.AutoSize = true;
            this.lblIBAN.Location = new System.Drawing.Point(544, 92);
            this.lblIBAN.Name = "lblIBAN";
            this.lblIBAN.Size = new System.Drawing.Size(32, 13);
            this.lblIBAN.TabIndex = 20;
            this.lblIBAN.Text = "IBAN";
            this.lblIBAN.ToolTipText = null;
            this.lblIBAN.ToolTipTitle = null;
            // 
            // txtNrRegCom
            // 
            this.txtNrRegCom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNrRegCom.CapitalizeazaPrimaLitera = false;
            this.txtNrRegCom.IsInReadOnlyMode = false;
            this.txtNrRegCom.Location = new System.Drawing.Point(607, 60);
            this.txtNrRegCom.Name = "txtNrRegCom";
            this.txtNrRegCom.ProprietateCorespunzatoare = null;
            this.txtNrRegCom.RaiseEventLaModificareProgramatica = false;
            this.txtNrRegCom.Size = new System.Drawing.Size(255, 20);
            this.txtNrRegCom.TabIndex = 6;
            this.txtNrRegCom.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtNrRegCom.TotulCuMajuscule = false;
            // 
            // lblNrRegCom
            // 
            this.lblNrRegCom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNrRegCom.AutoSize = true;
            this.lblNrRegCom.Location = new System.Drawing.Point(544, 64);
            this.lblNrRegCom.Name = "lblNrRegCom";
            this.lblNrRegCom.Size = new System.Drawing.Size(57, 13);
            this.lblNrRegCom.TabIndex = 18;
            this.lblNrRegCom.Text = "Reg. Com.";
            this.lblNrRegCom.ToolTipText = null;
            this.lblNrRegCom.ToolTipTitle = null;
            // 
            // txtCUI
            // 
            this.txtCUI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCUI.CapitalizeazaPrimaLitera = false;
            this.txtCUI.IsInReadOnlyMode = false;
            this.txtCUI.Location = new System.Drawing.Point(698, 32);
            this.txtCUI.Name = "txtCUI";
            this.txtCUI.ProprietateCorespunzatoare = null;
            this.txtCUI.RaiseEventLaModificareProgramatica = false;
            this.txtCUI.Size = new System.Drawing.Size(164, 20);
            this.txtCUI.TabIndex = 5;
            this.txtCUI.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCUI.TotulCuMajuscule = false;
            // 
            // lblCUI
            // 
            this.lblCUI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCUI.AutoSize = true;
            this.lblCUI.Location = new System.Drawing.Point(667, 36);
            this.lblCUI.Name = "lblCUI";
            this.lblCUI.Size = new System.Drawing.Size(25, 13);
            this.lblCUI.TabIndex = 16;
            this.lblCUI.Text = "CUI";
            this.lblCUI.ToolTipText = null;
            this.lblCUI.ToolTipTitle = null;
            // 
            // cboTipClient
            // 
            this.cboTipClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipClient.AutoCompletePersonalizat = false;
            this.cboTipClient.FormattingEnabled = true;
            this.cboTipClient.HideSelection = true;
            this.cboTipClient.IsInReadOnlyMode = false;
            this.cboTipClient.Location = new System.Drawing.Point(607, 32);
            this.cboTipClient.Name = "cboTipClient";
            this.cboTipClient.ProprietateCorespunzatoare = null;
            this.cboTipClient.Size = new System.Drawing.Size(50, 21);
            this.cboTipClient.TabIndex = 4;
            this.cboTipClient.TipulListei = CCL.UI.ComboBoxPersonalizat.EnumTipLista.Nespecificat;
            // 
            // lblTip
            // 
            this.lblTip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(544, 36);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(22, 13);
            this.lblTip.TabIndex = 14;
            this.lblTip.Text = "Tip";
            this.lblTip.ToolTipText = null;
            this.lblTip.ToolTipTitle = null;
            // 
            // txtDenumireFiscala
            // 
            this.txtDenumireFiscala.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenumireFiscala.CapitalizeazaPrimaLitera = false;
            this.txtDenumireFiscala.IsInReadOnlyMode = false;
            this.txtDenumireFiscala.Location = new System.Drawing.Point(607, 5);
            this.txtDenumireFiscala.Name = "txtDenumireFiscala";
            this.txtDenumireFiscala.ProprietateCorespunzatoare = null;
            this.txtDenumireFiscala.RaiseEventLaModificareProgramatica = false;
            this.txtDenumireFiscala.Size = new System.Drawing.Size(255, 20);
            this.txtDenumireFiscala.TabIndex = 2;
            this.txtDenumireFiscala.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtDenumireFiscala.TotulCuMajuscule = false;
            // 
            // lblDenumireFiscala
            // 
            this.lblDenumireFiscala.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDenumireFiscala.AutoSize = true;
            this.lblDenumireFiscala.Location = new System.Drawing.Point(544, 9);
            this.lblDenumireFiscala.Name = "lblDenumireFiscala";
            this.lblDenumireFiscala.Size = new System.Drawing.Size(52, 13);
            this.lblDenumireFiscala.TabIndex = 12;
            this.lblDenumireFiscala.Text = "Den. fisc.";
            this.lblDenumireFiscala.ToolTipText = null;
            this.lblDenumireFiscala.ToolTipTitle = null;
            // 
            // lblCalitate
            // 
            this.lblCalitate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCalitate.AutoSize = true;
            this.lblCalitate.Location = new System.Drawing.Point(544, 176);
            this.lblCalitate.Name = "lblCalitate";
            this.lblCalitate.Size = new System.Drawing.Size(42, 13);
            this.lblCalitate.TabIndex = 39;
            this.lblCalitate.Text = "Calitate";
            this.lblCalitate.ToolTipText = null;
            this.lblCalitate.ToolTipTitle = null;
            // 
            // ControlDosarClientPlati
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCalitate);
            this.Controls.Add(this.ctrlDataContract);
            this.Controls.Add(this.panelPlatiIncasari);
            this.Controls.Add(this.lblReprezentant);
            this.Controls.Add(this.panelPlatiFacturi);
            this.Controls.Add(this.lblDataContract);
            this.Controls.Add(this.lblDenumireFiscala);
            this.Controls.Add(this.cboTipReprezentant);
            this.Controls.Add(this.txtDenumireFiscala);
            this.Controls.Add(this.txtObservatiiDateFirma);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.lblObservatiiDateFirma);
            this.Controls.Add(this.cboTipClient);
            this.Controls.Add(this.txtNrContract);
            this.Controls.Add(this.lblCUI);
            this.Controls.Add(this.lblNrContract);
            this.Controls.Add(this.txtCUI);
            this.Controls.Add(this.txtReprezentantLegal);
            this.Controls.Add(this.lblNrRegCom);
            this.Controls.Add(this.ctrlCautareBanca);
            this.Controls.Add(this.txtNrRegCom);
            this.Controls.Add(this.lblBanca);
            this.Controls.Add(this.lblIBAN);
            this.Controls.Add(this.txtIBAN);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ControlDosarClientPlati";
            this.Size = new System.Drawing.Size(868, 486);
            this.panelPlatiIncasari.ResumeLayout(false);
            this.panelPlatiIncasari.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncasari)).EndInit();
            this.panelPlatiFacturi.ResumeLayout(false);
            this.panelPlatiFacturi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.Caramizi.PanelContainerCCL panelPlatiIncasari;
        private CCL.UI.DataGridViewPersonalizat dgvIncasari;
        private CCL.UI.LabelPersonalizat lblTitluIncasari;
        private CCL.UI.Caramizi.PanelContainerCCL panelPlatiFacturi;
        private CCL.UI.DataGridViewPersonalizat dgvFacturi;
        private CCL.UI.LabelPersonalizat lblTitluFacturi;
        private CCL.UI.ButtonPersonalizat btnAdaugaIncasare;
        private CCL.UI.ButtonPersonalizat btnAdaugaFactura;
        private CCL.UI.LabelPersonalizat lblTotalIncasari;
        private CCL.UI.LabelPersonalizat lblTotalFacturi;
        private Generale.ControlCautareBanca ctrlCautareBanca;
        private CCL.UI.LabelPersonalizat lblBanca;
        private CCL.UI.TextBoxPersonalizat txtIBAN;
        private CCL.UI.LabelPersonalizat lblIBAN;
        private CCL.UI.TextBoxPersonalizat txtNrRegCom;
        private CCL.UI.LabelPersonalizat lblNrRegCom;
        private CCL.UI.TextBoxPersonalizat txtCUI;
        private CCL.UI.LabelPersonalizat lblCUI;
        private CCL.UI.ComboBoxPersonalizat cboTipClient;
        private CCL.UI.LabelPersonalizat lblTip;
        private CCL.UI.TextBoxPersonalizat txtDenumireFiscala;
        private CCL.UI.LabelPersonalizat lblDenumireFiscala;
        private CCL.UI.TextBoxPersonalizat txtObservatiiDateFirma;
        private CCL.UI.LabelPersonalizat lblObservatiiDateFirma;
        private CCL.UI.TextBoxPersonalizat txtNrContract;
        private CCL.UI.LabelPersonalizat lblNrContract;
        private CCL.UI.TextBoxPersonalizat txtReprezentantLegal;
        private CCL.UI.LabelPersonalizat lblReprezentant;
        private CCL.UI.LabelPersonalizat lblDataContract;
        private CCL.UI.ComboBoxPersonalizat cboTipReprezentant;
        private CCL.UI.controlAlegeData ctrlDataContract;
        private CCL.UI.LabelPersonalizat lblCalitate;
        private CCL.UI.LabelPersonalizat lblSold;
    }
}
