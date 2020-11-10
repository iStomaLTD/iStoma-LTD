namespace iStomaLab.TablouDeBord.Clienti
{
    partial class FormDetaliuClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetaliuClient));
            this.ctrlValidareAnulareClient = new CCL.UI.Caramizi.controlValidareAnulare();
            this.cboTipClient = new CCL.UI.ComboBoxPersonalizat(this.components);
            this.lblTipClient = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlRecomandant = new iStomaLab.Generale.ControlCautareRecomandant();
            this.lblRecomandant = new CCL.UI.LabelPersonalizat(this.components);
            this.textBoxPersonalizat2 = new CCL.UI.TextBoxPersonalizat(this.components);
            this.labelPersonalizat2 = new CCL.UI.LabelPersonalizat(this.components);
            this.labelPersonalizat3 = new CCL.UI.LabelPersonalizat(this.components);
            this.textBoxPersonalizat1 = new CCL.UI.TextBoxPersonalizat(this.components);
            this.labelPersonalizat1 = new CCL.UI.LabelPersonalizat(this.components);
            this.txtFaxClient = new CCL.UI.MaskedTextBoxPersonalizat(this.components);
            this.txtTelefonFixClient = new CCL.UI.MaskedTextBoxPersonalizat(this.components);
            this.txtTelefonMobilClient = new CCL.UI.MaskedTextBoxPersonalizat(this.components);
            this.txtObservatiiClient = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblObservatiiClient = new CCL.UI.LabelPersonalizat(this.components);
            this.txtSkypeClient = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblSkypeClient = new CCL.UI.LabelPersonalizat(this.components);
            this.lblFaxClient = new CCL.UI.LabelPersonalizat(this.components);
            this.txtPaginaWebClient = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblPaginaWebClient = new CCL.UI.LabelPersonalizat(this.components);
            this.txtRegComClient = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblRegComClient = new CCL.UI.LabelPersonalizat(this.components);
            this.txtEmailClient = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblEmailClient = new CCL.UI.LabelPersonalizat(this.components);
            this.lblTelefonFixClient = new CCL.UI.LabelPersonalizat(this.components);
            this.lblTelefonMobilClient = new CCL.UI.LabelPersonalizat(this.components);
            this.txtCUIClient = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblCUIClient = new CCL.UI.LabelPersonalizat(this.components);
            this.txtDenumireFiscalaClient = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblDenumireFiscalaClient = new CCL.UI.LabelPersonalizat(this.components);
            this.txtDenumireClient = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblDenumireClient = new CCL.UI.LabelPersonalizat(this.components);
            this.panelPersonalizat1 = new CCL.UI.PanelPersonalizat(this.components);
            this.txtAdresaClient = new CCL.UI.TextBoxPersonalizat(this.components);
            this.btnSediuClient = new CCL.UI.ButtonPersonalizat(this.components);
            this.panelPersonalizat1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitluEcran.Size = new System.Drawing.Size(492, 19);
            this.lblTitluEcran.TabIndex = 16;
            this.lblTitluEcran.Text = "FormDetaliuClient";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(491, 0);
            this.btnInchidereEcran.Margin = new System.Windows.Forms.Padding(2);
            this.btnInchidereEcran.TabIndex = 17;
            // 
            // ctrlValidareAnulareClient
            // 
            this.ctrlValidareAnulareClient.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrlValidareAnulareClient.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulareClient.Location = new System.Drawing.Point(174, 476);
            this.ctrlValidareAnulareClient.Name = "ctrlValidareAnulareClient";
            this.ctrlValidareAnulareClient.Size = new System.Drawing.Size(162, 23);
            this.ctrlValidareAnulareClient.TabIndex = 1;
            // 
            // cboTipClient
            // 
            this.cboTipClient.AutoCompletePersonalizat = false;
            this.cboTipClient.FormattingEnabled = true;
            this.cboTipClient.HideSelection = true;
            this.cboTipClient.IsInReadOnlyMode = false;
            this.cboTipClient.Location = new System.Drawing.Point(375, 428);
            this.cboTipClient.Name = "cboTipClient";
            this.cboTipClient.ProprietateCorespunzatoare = null;
            this.cboTipClient.Size = new System.Drawing.Size(121, 21);
            this.cboTipClient.TabIndex = 14;
            this.cboTipClient.TipulListei = CCL.UI.ComboBoxPersonalizat.EnumTipLista.Nespecificat;
            // 
            // lblTipClient
            // 
            this.lblTipClient.AutoSize = true;
            this.lblTipClient.Location = new System.Drawing.Point(319, 431);
            this.lblTipClient.Name = "lblTipClient";
            this.lblTipClient.Size = new System.Drawing.Size(50, 13);
            this.lblTipClient.TabIndex = 34;
            this.lblTipClient.Text = "Tip client";
            this.lblTipClient.ToolTipText = null;
            this.lblTipClient.ToolTipTitle = null;
            // 
            // ctrlRecomandant
            // 
            this.ctrlRecomandant.BackColor = System.Drawing.Color.Transparent;
            this.ctrlRecomandant.Location = new System.Drawing.Point(93, 426);
            this.ctrlRecomandant.Name = "ctrlRecomandant";
            this.ctrlRecomandant.Size = new System.Drawing.Size(209, 23);
            this.ctrlRecomandant.TabIndex = 13;
            // 
            // lblRecomandant
            // 
            this.lblRecomandant.AutoSize = true;
            this.lblRecomandant.Location = new System.Drawing.Point(17, 428);
            this.lblRecomandant.Name = "lblRecomandant";
            this.lblRecomandant.Size = new System.Drawing.Size(74, 13);
            this.lblRecomandant.TabIndex = 33;
            this.lblRecomandant.Text = "Recomandant";
            this.lblRecomandant.ToolTipText = null;
            this.lblRecomandant.ToolTipTitle = null;
            // 
            // textBoxPersonalizat2
            // 
            this.textBoxPersonalizat2.CapitalizeazaPrimaLitera = false;
            this.textBoxPersonalizat2.IsInReadOnlyMode = false;
            this.textBoxPersonalizat2.Location = new System.Drawing.Point(58, 118);
            this.textBoxPersonalizat2.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPersonalizat2.Name = "textBoxPersonalizat2";
            this.textBoxPersonalizat2.ProprietateCorespunzatoare = null;
            this.textBoxPersonalizat2.RaiseEventLaModificareProgramatica = false;
            this.textBoxPersonalizat2.Size = new System.Drawing.Size(438, 20);
            this.textBoxPersonalizat2.TabIndex = 3;
            this.textBoxPersonalizat2.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.textBoxPersonalizat2.TotulCuMajuscule = false;
            // 
            // labelPersonalizat2
            // 
            this.labelPersonalizat2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPersonalizat2.AutoSize = true;
            this.labelPersonalizat2.Location = new System.Drawing.Point(14, 122);
            this.labelPersonalizat2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPersonalizat2.Name = "labelPersonalizat2";
            this.labelPersonalizat2.Size = new System.Drawing.Size(38, 13);
            this.labelPersonalizat2.TabIndex = 21;
            this.labelPersonalizat2.Text = "Banca";
            this.labelPersonalizat2.ToolTipText = null;
            this.labelPersonalizat2.ToolTipTitle = null;
            // 
            // labelPersonalizat3
            // 
            this.labelPersonalizat3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPersonalizat3.AutoSize = true;
            this.labelPersonalizat3.BackColor = System.Drawing.Color.Transparent;
            this.labelPersonalizat3.Location = new System.Drawing.Point(24, 147);
            this.labelPersonalizat3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPersonalizat3.Name = "labelPersonalizat3";
            this.labelPersonalizat3.Size = new System.Drawing.Size(64, 13);
            this.labelPersonalizat3.TabIndex = 22;
            this.labelPersonalizat3.Text = "Sediu social";
            this.labelPersonalizat3.ToolTipText = null;
            this.labelPersonalizat3.ToolTipTitle = null;
            // 
            // textBoxPersonalizat1
            // 
            this.textBoxPersonalizat1.CapitalizeazaPrimaLitera = false;
            this.textBoxPersonalizat1.IsInReadOnlyMode = false;
            this.textBoxPersonalizat1.Location = new System.Drawing.Point(53, 91);
            this.textBoxPersonalizat1.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPersonalizat1.Name = "textBoxPersonalizat1";
            this.textBoxPersonalizat1.ProprietateCorespunzatoare = null;
            this.textBoxPersonalizat1.RaiseEventLaModificareProgramatica = false;
            this.textBoxPersonalizat1.Size = new System.Drawing.Size(443, 20);
            this.textBoxPersonalizat1.TabIndex = 2;
            this.textBoxPersonalizat1.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.textBoxPersonalizat1.TotulCuMajuscule = false;
            // 
            // labelPersonalizat1
            // 
            this.labelPersonalizat1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPersonalizat1.AutoSize = true;
            this.labelPersonalizat1.Location = new System.Drawing.Point(14, 91);
            this.labelPersonalizat1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPersonalizat1.Name = "labelPersonalizat1";
            this.labelPersonalizat1.Size = new System.Drawing.Size(32, 13);
            this.labelPersonalizat1.TabIndex = 20;
            this.labelPersonalizat1.Text = "IBAN";
            this.labelPersonalizat1.ToolTipText = null;
            this.labelPersonalizat1.ToolTipTitle = null;
            // 
            // txtFaxClient
            // 
            this.txtFaxClient.BackColor = System.Drawing.SystemColors.Window;
            this.txtFaxClient.Location = new System.Drawing.Point(53, 320);
            this.txtFaxClient.Margin = new System.Windows.Forms.Padding(2);
            this.txtFaxClient.Name = "txtFaxClient";
            this.txtFaxClient.ProprietateCorespunzatoare = null;
            this.txtFaxClient.Size = new System.Drawing.Size(179, 20);
            this.txtFaxClient.TabIndex = 10;
            this.txtFaxClient.Text = "0";
            this.txtFaxClient.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.txtFaxClient.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtFaxClient.ValoareDouble = 0D;
            // 
            // txtTelefonFixClient
            // 
            this.txtTelefonFixClient.BackColor = System.Drawing.SystemColors.Window;
            this.txtTelefonFixClient.Location = new System.Drawing.Point(313, 287);
            this.txtTelefonFixClient.Margin = new System.Windows.Forms.Padding(2);
            this.txtTelefonFixClient.Name = "txtTelefonFixClient";
            this.txtTelefonFixClient.ProprietateCorespunzatoare = null;
            this.txtTelefonFixClient.Size = new System.Drawing.Size(182, 20);
            this.txtTelefonFixClient.TabIndex = 9;
            this.txtTelefonFixClient.Text = "0";
            this.txtTelefonFixClient.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.txtTelefonFixClient.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTelefonFixClient.ValoareDouble = 0D;
            // 
            // txtTelefonMobilClient
            // 
            this.txtTelefonMobilClient.BackColor = System.Drawing.SystemColors.Window;
            this.txtTelefonMobilClient.Location = new System.Drawing.Point(53, 287);
            this.txtTelefonMobilClient.Margin = new System.Windows.Forms.Padding(2);
            this.txtTelefonMobilClient.Name = "txtTelefonMobilClient";
            this.txtTelefonMobilClient.ProprietateCorespunzatoare = null;
            this.txtTelefonMobilClient.Size = new System.Drawing.Size(179, 20);
            this.txtTelefonMobilClient.TabIndex = 8;
            this.txtTelefonMobilClient.Text = "0";
            this.txtTelefonMobilClient.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.txtTelefonMobilClient.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTelefonMobilClient.ValoareDouble = 0D;
            // 
            // txtObservatiiClient
            // 
            this.txtObservatiiClient.CapitalizeazaPrimaLitera = false;
            this.txtObservatiiClient.IsInReadOnlyMode = false;
            this.txtObservatiiClient.Location = new System.Drawing.Point(17, 360);
            this.txtObservatiiClient.Margin = new System.Windows.Forms.Padding(2);
            this.txtObservatiiClient.Multiline = true;
            this.txtObservatiiClient.Name = "txtObservatiiClient";
            this.txtObservatiiClient.ProprietateCorespunzatoare = null;
            this.txtObservatiiClient.RaiseEventLaModificareProgramatica = false;
            this.txtObservatiiClient.Size = new System.Drawing.Size(479, 62);
            this.txtObservatiiClient.TabIndex = 12;
            this.txtObservatiiClient.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtObservatiiClient.TotulCuMajuscule = false;
            // 
            // lblObservatiiClient
            // 
            this.lblObservatiiClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblObservatiiClient.AutoSize = true;
            this.lblObservatiiClient.Location = new System.Drawing.Point(15, 343);
            this.lblObservatiiClient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblObservatiiClient.Name = "lblObservatiiClient";
            this.lblObservatiiClient.Size = new System.Drawing.Size(54, 13);
            this.lblObservatiiClient.TabIndex = 32;
            this.lblObservatiiClient.Text = "Observatii";
            this.lblObservatiiClient.ToolTipText = null;
            this.lblObservatiiClient.ToolTipTitle = null;
            // 
            // txtSkypeClient
            // 
            this.txtSkypeClient.CapitalizeazaPrimaLitera = false;
            this.txtSkypeClient.IsInReadOnlyMode = false;
            this.txtSkypeClient.Location = new System.Drawing.Point(313, 320);
            this.txtSkypeClient.Margin = new System.Windows.Forms.Padding(2);
            this.txtSkypeClient.Name = "txtSkypeClient";
            this.txtSkypeClient.ProprietateCorespunzatoare = null;
            this.txtSkypeClient.RaiseEventLaModificareProgramatica = false;
            this.txtSkypeClient.Size = new System.Drawing.Size(182, 20);
            this.txtSkypeClient.TabIndex = 11;
            this.txtSkypeClient.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtSkypeClient.TotulCuMajuscule = false;
            // 
            // lblSkypeClient
            // 
            this.lblSkypeClient.AutoSize = true;
            this.lblSkypeClient.Location = new System.Drawing.Point(246, 320);
            this.lblSkypeClient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSkypeClient.Name = "lblSkypeClient";
            this.lblSkypeClient.Size = new System.Drawing.Size(37, 13);
            this.lblSkypeClient.TabIndex = 31;
            this.lblSkypeClient.Text = "Skype";
            this.lblSkypeClient.ToolTipText = null;
            this.lblSkypeClient.ToolTipTitle = null;
            // 
            // lblFaxClient
            // 
            this.lblFaxClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFaxClient.AutoSize = true;
            this.lblFaxClient.Location = new System.Drawing.Point(15, 320);
            this.lblFaxClient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFaxClient.Name = "lblFaxClient";
            this.lblFaxClient.Size = new System.Drawing.Size(24, 13);
            this.lblFaxClient.TabIndex = 30;
            this.lblFaxClient.Text = "Fax";
            this.lblFaxClient.ToolTipText = null;
            this.lblFaxClient.ToolTipTitle = null;
            // 
            // txtPaginaWebClient
            // 
            this.txtPaginaWebClient.CapitalizeazaPrimaLitera = false;
            this.txtPaginaWebClient.IsInReadOnlyMode = false;
            this.txtPaginaWebClient.Location = new System.Drawing.Point(313, 246);
            this.txtPaginaWebClient.Margin = new System.Windows.Forms.Padding(2);
            this.txtPaginaWebClient.Name = "txtPaginaWebClient";
            this.txtPaginaWebClient.ProprietateCorespunzatoare = null;
            this.txtPaginaWebClient.RaiseEventLaModificareProgramatica = false;
            this.txtPaginaWebClient.Size = new System.Drawing.Size(182, 20);
            this.txtPaginaWebClient.TabIndex = 7;
            this.txtPaginaWebClient.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtPaginaWebClient.TotulCuMajuscule = false;
            // 
            // lblPaginaWebClient
            // 
            this.lblPaginaWebClient.AutoSize = true;
            this.lblPaginaWebClient.Location = new System.Drawing.Point(245, 249);
            this.lblPaginaWebClient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPaginaWebClient.Name = "lblPaginaWebClient";
            this.lblPaginaWebClient.Size = new System.Drawing.Size(63, 13);
            this.lblPaginaWebClient.TabIndex = 27;
            this.lblPaginaWebClient.Text = "Pagina web";
            this.lblPaginaWebClient.ToolTipText = null;
            this.lblPaginaWebClient.ToolTipTitle = null;
            // 
            // txtRegComClient
            // 
            this.txtRegComClient.CapitalizeazaPrimaLitera = false;
            this.txtRegComClient.IsInReadOnlyMode = false;
            this.txtRegComClient.Location = new System.Drawing.Point(313, 215);
            this.txtRegComClient.Margin = new System.Windows.Forms.Padding(2);
            this.txtRegComClient.Name = "txtRegComClient";
            this.txtRegComClient.ProprietateCorespunzatoare = null;
            this.txtRegComClient.RaiseEventLaModificareProgramatica = false;
            this.txtRegComClient.Size = new System.Drawing.Size(182, 20);
            this.txtRegComClient.TabIndex = 5;
            this.txtRegComClient.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtRegComClient.TotulCuMajuscule = false;
            // 
            // lblRegComClient
            // 
            this.lblRegComClient.AutoSize = true;
            this.lblRegComClient.Location = new System.Drawing.Point(245, 219);
            this.lblRegComClient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegComClient.Name = "lblRegComClient";
            this.lblRegComClient.Size = new System.Drawing.Size(57, 13);
            this.lblRegComClient.TabIndex = 25;
            this.lblRegComClient.Text = "Reg. Com.";
            this.lblRegComClient.ToolTipText = null;
            this.lblRegComClient.ToolTipTitle = null;
            // 
            // txtEmailClient
            // 
            this.txtEmailClient.CapitalizeazaPrimaLitera = false;
            this.txtEmailClient.IsInReadOnlyMode = false;
            this.txtEmailClient.Location = new System.Drawing.Point(53, 249);
            this.txtEmailClient.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmailClient.Name = "txtEmailClient";
            this.txtEmailClient.ProprietateCorespunzatoare = null;
            this.txtEmailClient.RaiseEventLaModificareProgramatica = false;
            this.txtEmailClient.Size = new System.Drawing.Size(179, 20);
            this.txtEmailClient.TabIndex = 6;
            this.txtEmailClient.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.AdresaMail;
            this.txtEmailClient.TotulCuMajuscule = false;
            // 
            // lblEmailClient
            // 
            this.lblEmailClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmailClient.AutoSize = true;
            this.lblEmailClient.Location = new System.Drawing.Point(14, 251);
            this.lblEmailClient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmailClient.Name = "lblEmailClient";
            this.lblEmailClient.Size = new System.Drawing.Size(32, 13);
            this.lblEmailClient.TabIndex = 26;
            this.lblEmailClient.Text = "Email";
            this.lblEmailClient.ToolTipText = null;
            this.lblEmailClient.ToolTipTitle = null;
            // 
            // lblTelefonFixClient
            // 
            this.lblTelefonFixClient.AutoSize = true;
            this.lblTelefonFixClient.Location = new System.Drawing.Point(246, 287);
            this.lblTelefonFixClient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTelefonFixClient.Name = "lblTelefonFixClient";
            this.lblTelefonFixClient.Size = new System.Drawing.Size(56, 13);
            this.lblTelefonFixClient.TabIndex = 29;
            this.lblTelefonFixClient.Text = "Telefon fix";
            this.lblTelefonFixClient.ToolTipText = null;
            this.lblTelefonFixClient.ToolTipTitle = null;
            // 
            // lblTelefonMobilClient
            // 
            this.lblTelefonMobilClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTelefonMobilClient.AutoSize = true;
            this.lblTelefonMobilClient.Location = new System.Drawing.Point(15, 287);
            this.lblTelefonMobilClient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTelefonMobilClient.Name = "lblTelefonMobilClient";
            this.lblTelefonMobilClient.Size = new System.Drawing.Size(32, 13);
            this.lblTelefonMobilClient.TabIndex = 28;
            this.lblTelefonMobilClient.Text = "Mobil";
            this.lblTelefonMobilClient.ToolTipText = null;
            this.lblTelefonMobilClient.ToolTipTitle = null;
            // 
            // txtCUIClient
            // 
            this.txtCUIClient.CapitalizeazaPrimaLitera = false;
            this.txtCUIClient.IsInReadOnlyMode = false;
            this.txtCUIClient.Location = new System.Drawing.Point(53, 216);
            this.txtCUIClient.Margin = new System.Windows.Forms.Padding(2);
            this.txtCUIClient.Name = "txtCUIClient";
            this.txtCUIClient.ProprietateCorespunzatoare = null;
            this.txtCUIClient.RaiseEventLaModificareProgramatica = false;
            this.txtCUIClient.Size = new System.Drawing.Size(179, 20);
            this.txtCUIClient.TabIndex = 4;
            this.txtCUIClient.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCUIClient.TotulCuMajuscule = false;
            // 
            // lblCUIClient
            // 
            this.lblCUIClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCUIClient.AutoSize = true;
            this.lblCUIClient.Location = new System.Drawing.Point(14, 219);
            this.lblCUIClient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCUIClient.Name = "lblCUIClient";
            this.lblCUIClient.Size = new System.Drawing.Size(25, 13);
            this.lblCUIClient.TabIndex = 24;
            this.lblCUIClient.Text = "CUI";
            this.lblCUIClient.ToolTipText = null;
            this.lblCUIClient.ToolTipTitle = null;
            // 
            // txtDenumireFiscalaClient
            // 
            this.txtDenumireFiscalaClient.CapitalizeazaPrimaLitera = false;
            this.txtDenumireFiscalaClient.IsInReadOnlyMode = false;
            this.txtDenumireFiscalaClient.Location = new System.Drawing.Point(113, 59);
            this.txtDenumireFiscalaClient.Margin = new System.Windows.Forms.Padding(2);
            this.txtDenumireFiscalaClient.Name = "txtDenumireFiscalaClient";
            this.txtDenumireFiscalaClient.ProprietateCorespunzatoare = null;
            this.txtDenumireFiscalaClient.RaiseEventLaModificareProgramatica = false;
            this.txtDenumireFiscalaClient.Size = new System.Drawing.Size(382, 20);
            this.txtDenumireFiscalaClient.TabIndex = 1;
            this.txtDenumireFiscalaClient.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtDenumireFiscalaClient.TotulCuMajuscule = false;
            // 
            // lblDenumireFiscalaClient
            // 
            this.lblDenumireFiscalaClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDenumireFiscalaClient.AutoSize = true;
            this.lblDenumireFiscalaClient.Location = new System.Drawing.Point(14, 62);
            this.lblDenumireFiscalaClient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDenumireFiscalaClient.Name = "lblDenumireFiscalaClient";
            this.lblDenumireFiscalaClient.Size = new System.Drawing.Size(85, 13);
            this.lblDenumireFiscalaClient.TabIndex = 19;
            this.lblDenumireFiscalaClient.Text = "Denumire fiscala";
            this.lblDenumireFiscalaClient.ToolTipText = null;
            this.lblDenumireFiscalaClient.ToolTipTitle = null;
            // 
            // txtDenumireClient
            // 
            this.txtDenumireClient.CapitalizeazaPrimaLitera = false;
            this.txtDenumireClient.IsInReadOnlyMode = false;
            this.txtDenumireClient.Location = new System.Drawing.Point(77, 31);
            this.txtDenumireClient.Margin = new System.Windows.Forms.Padding(2);
            this.txtDenumireClient.Name = "txtDenumireClient";
            this.txtDenumireClient.ProprietateCorespunzatoare = null;
            this.txtDenumireClient.RaiseEventLaModificareProgramatica = false;
            this.txtDenumireClient.Size = new System.Drawing.Size(418, 20);
            this.txtDenumireClient.TabIndex = 0;
            this.txtDenumireClient.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtDenumireClient.TotulCuMajuscule = false;
            // 
            // lblDenumireClient
            // 
            this.lblDenumireClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDenumireClient.AutoSize = true;
            this.lblDenumireClient.Location = new System.Drawing.Point(14, 31);
            this.lblDenumireClient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDenumireClient.Name = "lblDenumireClient";
            this.lblDenumireClient.Size = new System.Drawing.Size(52, 13);
            this.lblDenumireClient.TabIndex = 18;
            this.lblDenumireClient.Text = "Denumire";
            this.lblDenumireClient.ToolTipText = null;
            this.lblDenumireClient.ToolTipTitle = null;
            // 
            // panelPersonalizat1
            // 
            this.panelPersonalizat1.BackColor = System.Drawing.Color.White;
            this.panelPersonalizat1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPersonalizat1.Controls.Add(this.txtAdresaClient);
            this.panelPersonalizat1.Controls.Add(this.btnSediuClient);
            this.panelPersonalizat1.Location = new System.Drawing.Point(17, 153);
            this.panelPersonalizat1.Name = "panelPersonalizat1";
            this.panelPersonalizat1.Size = new System.Drawing.Size(479, 43);
            this.panelPersonalizat1.TabIndex = 23;
            this.panelPersonalizat1.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // txtAdresaClient
            // 
            this.txtAdresaClient.CapitalizeazaPrimaLitera = false;
            this.txtAdresaClient.IsInReadOnlyMode = false;
            this.txtAdresaClient.Location = new System.Drawing.Point(3, 12);
            this.txtAdresaClient.Margin = new System.Windows.Forms.Padding(2);
            this.txtAdresaClient.Name = "txtAdresaClient";
            this.txtAdresaClient.ProprietateCorespunzatoare = null;
            this.txtAdresaClient.RaiseEventLaModificareProgramatica = false;
            this.txtAdresaClient.Size = new System.Drawing.Size(446, 20);
            this.txtAdresaClient.TabIndex = 1;
            this.txtAdresaClient.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtAdresaClient.TotulCuMajuscule = false;
            // 
            // btnSediuClient
            // 
            this.btnSediuClient.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnSediuClient.Image = ((System.Drawing.Image)(resources.GetObject("btnSediuClient.Image")));
            this.btnSediuClient.Location = new System.Drawing.Point(453, 13);
            this.btnSediuClient.Margin = new System.Windows.Forms.Padding(2);
            this.btnSediuClient.Name = "btnSediuClient";
            this.btnSediuClient.Size = new System.Drawing.Size(22, 19);
            this.btnSediuClient.TabIndex = 0;
            this.btnSediuClient.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.DetaliiPopUp;
            this.btnSediuClient.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnSediuClient.UseVisualStyleBackColor = true;
            // 
            // FormDetaliuClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 511);
            this.Controls.Add(this.cboTipClient);
            this.Controls.Add(this.lblTipClient);
            this.Controls.Add(this.ctrlRecomandant);
            this.Controls.Add(this.lblRecomandant);
            this.Controls.Add(this.textBoxPersonalizat2);
            this.Controls.Add(this.labelPersonalizat2);
            this.Controls.Add(this.labelPersonalizat3);
            this.Controls.Add(this.textBoxPersonalizat1);
            this.Controls.Add(this.labelPersonalizat1);
            this.Controls.Add(this.txtFaxClient);
            this.Controls.Add(this.txtTelefonFixClient);
            this.Controls.Add(this.txtTelefonMobilClient);
            this.Controls.Add(this.txtObservatiiClient);
            this.Controls.Add(this.lblObservatiiClient);
            this.Controls.Add(this.txtSkypeClient);
            this.Controls.Add(this.lblSkypeClient);
            this.Controls.Add(this.lblFaxClient);
            this.Controls.Add(this.txtPaginaWebClient);
            this.Controls.Add(this.lblPaginaWebClient);
            this.Controls.Add(this.txtRegComClient);
            this.Controls.Add(this.lblRegComClient);
            this.Controls.Add(this.txtEmailClient);
            this.Controls.Add(this.lblEmailClient);
            this.Controls.Add(this.lblTelefonFixClient);
            this.Controls.Add(this.lblTelefonMobilClient);
            this.Controls.Add(this.txtCUIClient);
            this.Controls.Add(this.lblCUIClient);
            this.Controls.Add(this.txtDenumireFiscalaClient);
            this.Controls.Add(this.lblDenumireFiscalaClient);
            this.Controls.Add(this.txtDenumireClient);
            this.Controls.Add(this.lblDenumireClient);
            this.Controls.Add(this.panelPersonalizat1);
            this.Controls.Add(this.ctrlValidareAnulareClient);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormDetaliuClient";
            this.Text = "FormDetaliuClient";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulareClient, 0);
            this.Controls.SetChildIndex(this.panelPersonalizat1, 0);
            this.Controls.SetChildIndex(this.lblDenumireClient, 0);
            this.Controls.SetChildIndex(this.txtDenumireClient, 0);
            this.Controls.SetChildIndex(this.lblDenumireFiscalaClient, 0);
            this.Controls.SetChildIndex(this.txtDenumireFiscalaClient, 0);
            this.Controls.SetChildIndex(this.lblCUIClient, 0);
            this.Controls.SetChildIndex(this.txtCUIClient, 0);
            this.Controls.SetChildIndex(this.lblTelefonMobilClient, 0);
            this.Controls.SetChildIndex(this.lblTelefonFixClient, 0);
            this.Controls.SetChildIndex(this.lblEmailClient, 0);
            this.Controls.SetChildIndex(this.txtEmailClient, 0);
            this.Controls.SetChildIndex(this.lblRegComClient, 0);
            this.Controls.SetChildIndex(this.txtRegComClient, 0);
            this.Controls.SetChildIndex(this.lblPaginaWebClient, 0);
            this.Controls.SetChildIndex(this.txtPaginaWebClient, 0);
            this.Controls.SetChildIndex(this.lblFaxClient, 0);
            this.Controls.SetChildIndex(this.lblSkypeClient, 0);
            this.Controls.SetChildIndex(this.txtSkypeClient, 0);
            this.Controls.SetChildIndex(this.lblObservatiiClient, 0);
            this.Controls.SetChildIndex(this.txtObservatiiClient, 0);
            this.Controls.SetChildIndex(this.txtTelefonMobilClient, 0);
            this.Controls.SetChildIndex(this.txtTelefonFixClient, 0);
            this.Controls.SetChildIndex(this.txtFaxClient, 0);
            this.Controls.SetChildIndex(this.labelPersonalizat1, 0);
            this.Controls.SetChildIndex(this.textBoxPersonalizat1, 0);
            this.Controls.SetChildIndex(this.labelPersonalizat3, 0);
            this.Controls.SetChildIndex(this.labelPersonalizat2, 0);
            this.Controls.SetChildIndex(this.textBoxPersonalizat2, 0);
            this.Controls.SetChildIndex(this.lblRecomandant, 0);
            this.Controls.SetChildIndex(this.ctrlRecomandant, 0);
            this.Controls.SetChildIndex(this.lblTipClient, 0);
            this.Controls.SetChildIndex(this.cboTipClient, 0);
            this.panelPersonalizat1.ResumeLayout(false);
            this.panelPersonalizat1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulareClient;
        private CCL.UI.ComboBoxPersonalizat cboTipClient;
        private CCL.UI.LabelPersonalizat lblTipClient;
        private Generale.ControlCautareRecomandant ctrlRecomandant;
        private CCL.UI.LabelPersonalizat lblRecomandant;
        private CCL.UI.TextBoxPersonalizat textBoxPersonalizat2;
        private CCL.UI.LabelPersonalizat labelPersonalizat2;
        private CCL.UI.LabelPersonalizat labelPersonalizat3;
        private CCL.UI.TextBoxPersonalizat textBoxPersonalizat1;
        private CCL.UI.LabelPersonalizat labelPersonalizat1;
        private CCL.UI.MaskedTextBoxPersonalizat txtFaxClient;
        private CCL.UI.MaskedTextBoxPersonalizat txtTelefonFixClient;
        private CCL.UI.MaskedTextBoxPersonalizat txtTelefonMobilClient;
        private CCL.UI.TextBoxPersonalizat txtObservatiiClient;
        private CCL.UI.LabelPersonalizat lblObservatiiClient;
        private CCL.UI.TextBoxPersonalizat txtSkypeClient;
        private CCL.UI.LabelPersonalizat lblSkypeClient;
        private CCL.UI.LabelPersonalizat lblFaxClient;
        private CCL.UI.TextBoxPersonalizat txtPaginaWebClient;
        private CCL.UI.LabelPersonalizat lblPaginaWebClient;
        private CCL.UI.TextBoxPersonalizat txtRegComClient;
        private CCL.UI.LabelPersonalizat lblRegComClient;
        private CCL.UI.TextBoxPersonalizat txtEmailClient;
        private CCL.UI.LabelPersonalizat lblEmailClient;
        private CCL.UI.LabelPersonalizat lblTelefonFixClient;
        private CCL.UI.LabelPersonalizat lblTelefonMobilClient;
        private CCL.UI.TextBoxPersonalizat txtCUIClient;
        private CCL.UI.LabelPersonalizat lblCUIClient;
        private CCL.UI.TextBoxPersonalizat txtDenumireFiscalaClient;
        private CCL.UI.LabelPersonalizat lblDenumireFiscalaClient;
        private CCL.UI.TextBoxPersonalizat txtDenumireClient;
        private CCL.UI.LabelPersonalizat lblDenumireClient;
        private CCL.UI.PanelPersonalizat panelPersonalizat1;
        private CCL.UI.TextBoxPersonalizat txtAdresaClient;
        private CCL.UI.ButtonPersonalizat btnSediuClient;
    }
}