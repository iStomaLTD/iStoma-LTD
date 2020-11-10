namespace iStomaLab.TablouDeBord.Clienti
{
    partial class FormCreareClient
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
            this.ctrlValidareAnulare = new CCL.UI.Caramizi.controlValidareAnulare();
            this.panelDateClinica = new CCL.UI.PanelPersonalizat(this.components);
            this.ctrlAgent = new iStomaLab.Caramizi.ControlCautaTehnician();
            this.lblAgent = new CCL.UI.LabelPersonalizat(this.components);
            this.lblObservatiiDateClinica = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlCautareRecomandant = new iStomaLab.Generale.ControlCautareRecomandant();
            this.lblRecomandant = new CCL.UI.LabelPersonalizat(this.components);
            this.txtWebsite = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblWebSite = new CCL.UI.LabelPersonalizat(this.components);
            this.txtEmail = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblEmail = new CCL.UI.LabelPersonalizat(this.components);
            this.txtTelefonFix = new CCL.UI.MaskedTextBoxPersonalizat(this.components);
            this.lblTelefonFix = new CCL.UI.LabelPersonalizat(this.components);
            this.txtTelefonMobil = new CCL.UI.MaskedTextBoxPersonalizat(this.components);
            this.lblTelefonMobil = new CCL.UI.LabelPersonalizat(this.components);
            this.txtDenumire = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblDenumire = new CCL.UI.LabelPersonalizat(this.components);
            this.txtObservatiiDateClinica = new CCL.UI.TextBoxPersonalizat(this.components);
            this.panelDateFirma = new CCL.UI.PanelPersonalizat(this.components);
            this.txtObservatiiDateFirma = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblObservatiiDateFirma = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlAlegeDataContract = new CCL.UI.controlAlegeData();
            this.lblDataContract = new CCL.UI.LabelPersonalizat(this.components);
            this.txtNrContract = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblNrContract = new CCL.UI.LabelPersonalizat(this.components);
            this.cboCalitateReprezentant = new CCL.UI.ComboBoxPersonalizat(this.components);
            this.lblInCalitateDe = new CCL.UI.LabelPersonalizat(this.components);
            this.txtReprezentantLegal = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblReprezentantLegal = new CCL.UI.LabelPersonalizat(this.components);
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
            this.panelDateClinica.SuspendLayout();
            this.panelDateFirma.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(377, 19);
            this.lblTitluEcran.TabIndex = 2;
            this.lblTitluEcran.Text = "FormCreareClient";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(376, 0);
            this.btnInchidereEcran.TabIndex = 3;
            // 
            // ctrlValidareAnulare
            // 
            this.ctrlValidareAnulare.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrlValidareAnulare.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulare.Location = new System.Drawing.Point(120, 546);
            this.ctrlValidareAnulare.Name = "ctrlValidareAnulare";
            this.ctrlValidareAnulare.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulare.TabIndex = 1;
            // 
            // panelDateClinica
            // 
            this.panelDateClinica.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDateClinica.BackColor = System.Drawing.Color.White;
            this.panelDateClinica.Controls.Add(this.ctrlAgent);
            this.panelDateClinica.Controls.Add(this.lblAgent);
            this.panelDateClinica.Controls.Add(this.lblObservatiiDateClinica);
            this.panelDateClinica.Controls.Add(this.ctrlCautareRecomandant);
            this.panelDateClinica.Controls.Add(this.lblRecomandant);
            this.panelDateClinica.Controls.Add(this.txtWebsite);
            this.panelDateClinica.Controls.Add(this.lblWebSite);
            this.panelDateClinica.Controls.Add(this.txtEmail);
            this.panelDateClinica.Controls.Add(this.lblEmail);
            this.panelDateClinica.Controls.Add(this.txtTelefonFix);
            this.panelDateClinica.Controls.Add(this.lblTelefonFix);
            this.panelDateClinica.Controls.Add(this.txtTelefonMobil);
            this.panelDateClinica.Controls.Add(this.lblTelefonMobil);
            this.panelDateClinica.Controls.Add(this.txtDenumire);
            this.panelDateClinica.Controls.Add(this.lblDenumire);
            this.panelDateClinica.Controls.Add(this.txtObservatiiDateClinica);
            this.panelDateClinica.Location = new System.Drawing.Point(3, 23);
            this.panelDateClinica.Name = "panelDateClinica";
            this.panelDateClinica.Size = new System.Drawing.Size(392, 522);
            this.panelDateClinica.TabIndex = 0;
            this.panelDateClinica.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // ctrlAgent
            // 
            this.ctrlAgent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlAgent.Location = new System.Drawing.Point(83, 198);
            this.ctrlAgent.Name = "ctrlAgent";
            this.ctrlAgent.Size = new System.Drawing.Size(303, 23);
            this.ctrlAgent.TabIndex = 6;
            // 
            // lblAgent
            // 
            this.lblAgent.AutoSize = true;
            this.lblAgent.Location = new System.Drawing.Point(6, 203);
            this.lblAgent.Name = "lblAgent";
            this.lblAgent.Size = new System.Drawing.Size(35, 13);
            this.lblAgent.TabIndex = 13;
            this.lblAgent.Text = "Agent";
            this.lblAgent.ToolTipText = null;
            this.lblAgent.ToolTipTitle = null;
            // 
            // lblObservatiiDateClinica
            // 
            this.lblObservatiiDateClinica.AutoSize = true;
            this.lblObservatiiDateClinica.Location = new System.Drawing.Point(6, 234);
            this.lblObservatiiDateClinica.Name = "lblObservatiiDateClinica";
            this.lblObservatiiDateClinica.Size = new System.Drawing.Size(54, 13);
            this.lblObservatiiDateClinica.TabIndex = 12;
            this.lblObservatiiDateClinica.Text = "Observatii";
            this.lblObservatiiDateClinica.ToolTipText = null;
            this.lblObservatiiDateClinica.ToolTipTitle = null;
            // 
            // ctrlCautareRecomandant
            // 
            this.ctrlCautareRecomandant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlCautareRecomandant.Location = new System.Drawing.Point(83, 164);
            this.ctrlCautareRecomandant.Name = "ctrlCautareRecomandant";
            this.ctrlCautareRecomandant.Size = new System.Drawing.Size(303, 25);
            this.ctrlCautareRecomandant.TabIndex = 5;
            // 
            // lblRecomandant
            // 
            this.lblRecomandant.AutoSize = true;
            this.lblRecomandant.Location = new System.Drawing.Point(6, 170);
            this.lblRecomandant.Name = "lblRecomandant";
            this.lblRecomandant.Size = new System.Drawing.Size(74, 13);
            this.lblRecomandant.TabIndex = 11;
            this.lblRecomandant.Text = "Recomandant";
            this.lblRecomandant.ToolTipText = null;
            this.lblRecomandant.ToolTipTitle = null;
            // 
            // txtWebsite
            // 
            this.txtWebsite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWebsite.CapitalizeazaPrimaLitera = false;
            this.txtWebsite.IsInReadOnlyMode = false;
            this.txtWebsite.Location = new System.Drawing.Point(83, 134);
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.ProprietateCorespunzatoare = null;
            this.txtWebsite.RaiseEventLaModificareProgramatica = false;
            this.txtWebsite.Size = new System.Drawing.Size(303, 20);
            this.txtWebsite.TabIndex = 4;
            this.txtWebsite.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtWebsite.TotulCuMajuscule = false;
            // 
            // lblWebSite
            // 
            this.lblWebSite.AutoSize = true;
            this.lblWebSite.Location = new System.Drawing.Point(6, 134);
            this.lblWebSite.Name = "lblWebSite";
            this.lblWebSite.Size = new System.Drawing.Size(46, 13);
            this.lblWebSite.TabIndex = 10;
            this.lblWebSite.Text = "Website";
            this.lblWebSite.ToolTipText = null;
            this.lblWebSite.ToolTipTitle = null;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.CapitalizeazaPrimaLitera = false;
            this.txtEmail.IsInReadOnlyMode = false;
            this.txtEmail.Location = new System.Drawing.Point(83, 100);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ProprietateCorespunzatoare = null;
            this.txtEmail.RaiseEventLaModificareProgramatica = false;
            this.txtEmail.Size = new System.Drawing.Size(303, 20);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.AdresaMail;
            this.txtEmail.TotulCuMajuscule = false;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(6, 104);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "Email";
            this.lblEmail.ToolTipText = null;
            this.lblEmail.ToolTipTitle = null;
            // 
            // txtTelefonFix
            // 
            this.txtTelefonFix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelefonFix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.txtTelefonFix.Location = new System.Drawing.Point(83, 69);
            this.txtTelefonFix.Name = "txtTelefonFix";
            this.txtTelefonFix.ProprietateCorespunzatoare = null;
            this.txtTelefonFix.Size = new System.Drawing.Size(303, 20);
            this.txtTelefonFix.TabIndex = 2;
            this.txtTelefonFix.Text = "0";
            this.txtTelefonFix.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Telefon;
            this.txtTelefonFix.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTelefonFix.ValoareDouble = 0D;
            // 
            // lblTelefonFix
            // 
            this.lblTelefonFix.AutoSize = true;
            this.lblTelefonFix.Location = new System.Drawing.Point(6, 73);
            this.lblTelefonFix.Name = "lblTelefonFix";
            this.lblTelefonFix.Size = new System.Drawing.Size(56, 13);
            this.lblTelefonFix.TabIndex = 4;
            this.lblTelefonFix.Text = "Telefon fix";
            this.lblTelefonFix.ToolTipText = null;
            this.lblTelefonFix.ToolTipTitle = null;
            // 
            // txtTelefonMobil
            // 
            this.txtTelefonMobil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelefonMobil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.txtTelefonMobil.Location = new System.Drawing.Point(83, 37);
            this.txtTelefonMobil.Name = "txtTelefonMobil";
            this.txtTelefonMobil.ProprietateCorespunzatoare = null;
            this.txtTelefonMobil.Size = new System.Drawing.Size(303, 20);
            this.txtTelefonMobil.TabIndex = 1;
            this.txtTelefonMobil.Text = "0";
            this.txtTelefonMobil.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Telefon;
            this.txtTelefonMobil.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTelefonMobil.ValoareDouble = 0D;
            // 
            // lblTelefonMobil
            // 
            this.lblTelefonMobil.AutoSize = true;
            this.lblTelefonMobil.Location = new System.Drawing.Point(6, 41);
            this.lblTelefonMobil.Name = "lblTelefonMobil";
            this.lblTelefonMobil.Size = new System.Drawing.Size(70, 13);
            this.lblTelefonMobil.TabIndex = 8;
            this.lblTelefonMobil.Text = "Telefon mobil";
            this.lblTelefonMobil.ToolTipText = null;
            this.lblTelefonMobil.ToolTipTitle = null;
            // 
            // txtDenumire
            // 
            this.txtDenumire.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenumire.CapitalizeazaPrimaLitera = false;
            this.txtDenumire.IsInReadOnlyMode = false;
            this.txtDenumire.Location = new System.Drawing.Point(83, 5);
            this.txtDenumire.Name = "txtDenumire";
            this.txtDenumire.ProprietateCorespunzatoare = null;
            this.txtDenumire.RaiseEventLaModificareProgramatica = false;
            this.txtDenumire.Size = new System.Drawing.Size(303, 20);
            this.txtDenumire.TabIndex = 0;
            this.txtDenumire.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtDenumire.TotulCuMajuscule = false;
            // 
            // lblDenumire
            // 
            this.lblDenumire.AutoSize = true;
            this.lblDenumire.Location = new System.Drawing.Point(6, 9);
            this.lblDenumire.Name = "lblDenumire";
            this.lblDenumire.Size = new System.Drawing.Size(52, 13);
            this.lblDenumire.TabIndex = 7;
            this.lblDenumire.Text = "Denumire";
            this.lblDenumire.ToolTipText = null;
            this.lblDenumire.ToolTipTitle = null;
            // 
            // txtObservatiiDateClinica
            // 
            this.txtObservatiiDateClinica.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservatiiDateClinica.CapitalizeazaPrimaLitera = false;
            this.txtObservatiiDateClinica.IsInReadOnlyMode = false;
            this.txtObservatiiDateClinica.Location = new System.Drawing.Point(6, 252);
            this.txtObservatiiDateClinica.Multiline = true;
            this.txtObservatiiDateClinica.Name = "txtObservatiiDateClinica";
            this.txtObservatiiDateClinica.ProprietateCorespunzatoare = null;
            this.txtObservatiiDateClinica.RaiseEventLaModificareProgramatica = false;
            this.txtObservatiiDateClinica.Size = new System.Drawing.Size(380, 260);
            this.txtObservatiiDateClinica.TabIndex = 7;
            this.txtObservatiiDateClinica.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtObservatiiDateClinica.TotulCuMajuscule = false;
            // 
            // panelDateFirma
            // 
            this.panelDateFirma.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDateFirma.BackColor = System.Drawing.Color.White;
            this.panelDateFirma.Controls.Add(this.txtObservatiiDateFirma);
            this.panelDateFirma.Controls.Add(this.lblObservatiiDateFirma);
            this.panelDateFirma.Controls.Add(this.ctrlAlegeDataContract);
            this.panelDateFirma.Controls.Add(this.lblDataContract);
            this.panelDateFirma.Controls.Add(this.txtNrContract);
            this.panelDateFirma.Controls.Add(this.lblNrContract);
            this.panelDateFirma.Controls.Add(this.cboCalitateReprezentant);
            this.panelDateFirma.Controls.Add(this.lblInCalitateDe);
            this.panelDateFirma.Controls.Add(this.txtReprezentantLegal);
            this.panelDateFirma.Controls.Add(this.lblReprezentantLegal);
            this.panelDateFirma.Controls.Add(this.ctrlCautareBanca);
            this.panelDateFirma.Controls.Add(this.lblBanca);
            this.panelDateFirma.Controls.Add(this.txtIBAN);
            this.panelDateFirma.Controls.Add(this.lblIBAN);
            this.panelDateFirma.Controls.Add(this.txtNrRegCom);
            this.panelDateFirma.Controls.Add(this.lblNrRegCom);
            this.panelDateFirma.Controls.Add(this.txtCUI);
            this.panelDateFirma.Controls.Add(this.lblCUI);
            this.panelDateFirma.Controls.Add(this.cboTipClient);
            this.panelDateFirma.Controls.Add(this.lblTip);
            this.panelDateFirma.Controls.Add(this.txtDenumireFiscala);
            this.panelDateFirma.Controls.Add(this.lblDenumireFiscala);
            this.panelDateFirma.Location = new System.Drawing.Point(4, 25);
            this.panelDateFirma.Name = "panelDateFirma";
            this.panelDateFirma.Size = new System.Drawing.Size(390, 518);
            this.panelDateFirma.TabIndex = 16;
            this.panelDateFirma.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // txtObservatiiDateFirma
            // 
            this.txtObservatiiDateFirma.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservatiiDateFirma.CapitalizeazaPrimaLitera = false;
            this.txtObservatiiDateFirma.IsInReadOnlyMode = false;
            this.txtObservatiiDateFirma.Location = new System.Drawing.Point(7, 392);
            this.txtObservatiiDateFirma.Multiline = true;
            this.txtObservatiiDateFirma.Name = "txtObservatiiDateFirma";
            this.txtObservatiiDateFirma.ProprietateCorespunzatoare = null;
            this.txtObservatiiDateFirma.RaiseEventLaModificareProgramatica = false;
            this.txtObservatiiDateFirma.Size = new System.Drawing.Size(377, 117);
            this.txtObservatiiDateFirma.TabIndex = 21;
            this.txtObservatiiDateFirma.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtObservatiiDateFirma.TotulCuMajuscule = false;
            // 
            // lblObservatiiDateFirma
            // 
            this.lblObservatiiDateFirma.AutoSize = true;
            this.lblObservatiiDateFirma.Location = new System.Drawing.Point(7, 365);
            this.lblObservatiiDateFirma.Name = "lblObservatiiDateFirma";
            this.lblObservatiiDateFirma.Size = new System.Drawing.Size(54, 13);
            this.lblObservatiiDateFirma.TabIndex = 20;
            this.lblObservatiiDateFirma.Text = "Observatii";
            this.lblObservatiiDateFirma.ToolTipText = null;
            this.lblObservatiiDateFirma.ToolTipTitle = null;
            // 
            // ctrlAlegeDataContract
            // 
            this.ctrlAlegeDataContract.AfiseazaButonGuma = false;
            this.ctrlAlegeDataContract.AfiseazaCuOra = false;
            this.ctrlAlegeDataContract.AfiseazaCuSecunde = false;
            this.ctrlAlegeDataContract.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ctrlAlegeDataContract.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ctrlAlegeDataContract.BackColor = System.Drawing.Color.White;
            this.ctrlAlegeDataContract.DataAfisata = new System.DateTime(((long)(0)));
            this.ctrlAlegeDataContract.IsInReadOnlyMode = false;
            this.ctrlAlegeDataContract.Location = new System.Drawing.Point(91, 323);
            this.ctrlAlegeDataContract.Name = "ctrlAlegeDataContract";
            this.ctrlAlegeDataContract.PragInferior = new System.DateTime(((long)(0)));
            this.ctrlAlegeDataContract.PragSuperior = new System.DateTime(((long)(0)));
            this.ctrlAlegeDataContract.ProprietateCorespunzatoare = null;
            this.ctrlAlegeDataContract.Size = new System.Drawing.Size(134, 21);
            this.ctrlAlegeDataContract.TabIndex = 19;
            this.ctrlAlegeDataContract.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.ctrlAlegeDataContract.TipDeschidereCalendar = CCL.UI.CEnumerariComune.EnumTipDeschidere.StangaSus;
            // 
            // lblDataContract
            // 
            this.lblDataContract.AutoSize = true;
            this.lblDataContract.Location = new System.Drawing.Point(7, 327);
            this.lblDataContract.Name = "lblDataContract";
            this.lblDataContract.Size = new System.Drawing.Size(72, 13);
            this.lblDataContract.TabIndex = 18;
            this.lblDataContract.Text = "Data contract";
            this.lblDataContract.ToolTipText = null;
            this.lblDataContract.ToolTipTitle = null;
            // 
            // txtNrContract
            // 
            this.txtNrContract.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNrContract.CapitalizeazaPrimaLitera = false;
            this.txtNrContract.IsInReadOnlyMode = false;
            this.txtNrContract.Location = new System.Drawing.Point(91, 293);
            this.txtNrContract.Name = "txtNrContract";
            this.txtNrContract.ProprietateCorespunzatoare = null;
            this.txtNrContract.RaiseEventLaModificareProgramatica = false;
            this.txtNrContract.Size = new System.Drawing.Size(293, 20);
            this.txtNrContract.TabIndex = 17;
            this.txtNrContract.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtNrContract.TotulCuMajuscule = false;
            // 
            // lblNrContract
            // 
            this.lblNrContract.AutoSize = true;
            this.lblNrContract.Location = new System.Drawing.Point(7, 297);
            this.lblNrContract.Name = "lblNrContract";
            this.lblNrContract.Size = new System.Drawing.Size(63, 13);
            this.lblNrContract.TabIndex = 16;
            this.lblNrContract.Text = "Nr. contract";
            this.lblNrContract.ToolTipText = null;
            this.lblNrContract.ToolTipTitle = null;
            // 
            // cboCalitateReprezentant
            // 
            this.cboCalitateReprezentant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCalitateReprezentant.AutoCompletePersonalizat = false;
            this.cboCalitateReprezentant.FormattingEnabled = true;
            this.cboCalitateReprezentant.HideSelection = true;
            this.cboCalitateReprezentant.IsInReadOnlyMode = false;
            this.cboCalitateReprezentant.Location = new System.Drawing.Point(91, 262);
            this.cboCalitateReprezentant.Name = "cboCalitateReprezentant";
            this.cboCalitateReprezentant.ProprietateCorespunzatoare = null;
            this.cboCalitateReprezentant.Size = new System.Drawing.Size(293, 21);
            this.cboCalitateReprezentant.TabIndex = 15;
            this.cboCalitateReprezentant.TipulListei = CCL.UI.ComboBoxPersonalizat.EnumTipLista.Nespecificat;
            // 
            // lblInCalitateDe
            // 
            this.lblInCalitateDe.AutoSize = true;
            this.lblInCalitateDe.Location = new System.Drawing.Point(7, 266);
            this.lblInCalitateDe.Name = "lblInCalitateDe";
            this.lblInCalitateDe.Size = new System.Drawing.Size(68, 13);
            this.lblInCalitateDe.TabIndex = 14;
            this.lblInCalitateDe.Text = "In calitate de";
            this.lblInCalitateDe.ToolTipText = null;
            this.lblInCalitateDe.ToolTipTitle = null;
            // 
            // txtReprezentantLegal
            // 
            this.txtReprezentantLegal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReprezentantLegal.CapitalizeazaPrimaLitera = false;
            this.txtReprezentantLegal.IsInReadOnlyMode = false;
            this.txtReprezentantLegal.Location = new System.Drawing.Point(7, 229);
            this.txtReprezentantLegal.Name = "txtReprezentantLegal";
            this.txtReprezentantLegal.ProprietateCorespunzatoare = null;
            this.txtReprezentantLegal.RaiseEventLaModificareProgramatica = false;
            this.txtReprezentantLegal.Size = new System.Drawing.Size(377, 20);
            this.txtReprezentantLegal.TabIndex = 13;
            this.txtReprezentantLegal.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtReprezentantLegal.TotulCuMajuscule = false;
            // 
            // lblReprezentantLegal
            // 
            this.lblReprezentantLegal.AutoSize = true;
            this.lblReprezentantLegal.Location = new System.Drawing.Point(7, 206);
            this.lblReprezentantLegal.Name = "lblReprezentantLegal";
            this.lblReprezentantLegal.Size = new System.Drawing.Size(96, 13);
            this.lblReprezentantLegal.TabIndex = 12;
            this.lblReprezentantLegal.Text = "Reprezentant legal";
            this.lblReprezentantLegal.ToolTipText = null;
            this.lblReprezentantLegal.ToolTipTitle = null;
            // 
            // ctrlCautareBanca
            // 
            this.ctrlCautareBanca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlCautareBanca.Location = new System.Drawing.Point(67, 169);
            this.ctrlCautareBanca.Name = "ctrlCautareBanca";
            this.ctrlCautareBanca.Size = new System.Drawing.Size(317, 24);
            this.ctrlCautareBanca.TabIndex = 11;
            // 
            // lblBanca
            // 
            this.lblBanca.AutoSize = true;
            this.lblBanca.Location = new System.Drawing.Point(7, 175);
            this.lblBanca.Name = "lblBanca";
            this.lblBanca.Size = new System.Drawing.Size(38, 13);
            this.lblBanca.TabIndex = 10;
            this.lblBanca.Text = "Banca";
            this.lblBanca.ToolTipText = null;
            this.lblBanca.ToolTipTitle = null;
            // 
            // txtIBAN
            // 
            this.txtIBAN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIBAN.CapitalizeazaPrimaLitera = false;
            this.txtIBAN.IsInReadOnlyMode = false;
            this.txtIBAN.Location = new System.Drawing.Point(67, 140);
            this.txtIBAN.Name = "txtIBAN";
            this.txtIBAN.ProprietateCorespunzatoare = null;
            this.txtIBAN.RaiseEventLaModificareProgramatica = false;
            this.txtIBAN.Size = new System.Drawing.Size(317, 20);
            this.txtIBAN.TabIndex = 9;
            this.txtIBAN.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtIBAN.TotulCuMajuscule = false;
            // 
            // lblIBAN
            // 
            this.lblIBAN.AutoSize = true;
            this.lblIBAN.Location = new System.Drawing.Point(7, 144);
            this.lblIBAN.Name = "lblIBAN";
            this.lblIBAN.Size = new System.Drawing.Size(32, 13);
            this.lblIBAN.TabIndex = 8;
            this.lblIBAN.Text = "IBAN";
            this.lblIBAN.ToolTipText = null;
            this.lblIBAN.ToolTipTitle = null;
            // 
            // txtNrRegCom
            // 
            this.txtNrRegCom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNrRegCom.CapitalizeazaPrimaLitera = false;
            this.txtNrRegCom.IsInReadOnlyMode = false;
            this.txtNrRegCom.Location = new System.Drawing.Point(67, 105);
            this.txtNrRegCom.Name = "txtNrRegCom";
            this.txtNrRegCom.ProprietateCorespunzatoare = null;
            this.txtNrRegCom.RaiseEventLaModificareProgramatica = false;
            this.txtNrRegCom.Size = new System.Drawing.Size(317, 20);
            this.txtNrRegCom.TabIndex = 7;
            this.txtNrRegCom.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtNrRegCom.TotulCuMajuscule = false;
            // 
            // lblNrRegCom
            // 
            this.lblNrRegCom.AutoSize = true;
            this.lblNrRegCom.Location = new System.Drawing.Point(7, 109);
            this.lblNrRegCom.Name = "lblNrRegCom";
            this.lblNrRegCom.Size = new System.Drawing.Size(57, 13);
            this.lblNrRegCom.TabIndex = 6;
            this.lblNrRegCom.Text = "Reg. Com.";
            this.lblNrRegCom.ToolTipText = null;
            this.lblNrRegCom.ToolTipTitle = null;
            // 
            // txtCUI
            // 
            this.txtCUI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCUI.CapitalizeazaPrimaLitera = false;
            this.txtCUI.IsInReadOnlyMode = false;
            this.txtCUI.Location = new System.Drawing.Point(67, 73);
            this.txtCUI.Name = "txtCUI";
            this.txtCUI.ProprietateCorespunzatoare = null;
            this.txtCUI.RaiseEventLaModificareProgramatica = false;
            this.txtCUI.Size = new System.Drawing.Size(317, 20);
            this.txtCUI.TabIndex = 5;
            this.txtCUI.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCUI.TotulCuMajuscule = false;
            // 
            // lblCUI
            // 
            this.lblCUI.AutoSize = true;
            this.lblCUI.Location = new System.Drawing.Point(7, 77);
            this.lblCUI.Name = "lblCUI";
            this.lblCUI.Size = new System.Drawing.Size(25, 13);
            this.lblCUI.TabIndex = 4;
            this.lblCUI.Text = "CUI";
            this.lblCUI.ToolTipText = null;
            this.lblCUI.ToolTipTitle = null;
            // 
            // cboTipClient
            // 
            this.cboTipClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipClient.AutoCompletePersonalizat = false;
            this.cboTipClient.FormattingEnabled = true;
            this.cboTipClient.HideSelection = true;
            this.cboTipClient.IsInReadOnlyMode = false;
            this.cboTipClient.Location = new System.Drawing.Point(67, 40);
            this.cboTipClient.Name = "cboTipClient";
            this.cboTipClient.ProprietateCorespunzatoare = null;
            this.cboTipClient.Size = new System.Drawing.Size(317, 21);
            this.cboTipClient.TabIndex = 3;
            this.cboTipClient.TipulListei = CCL.UI.ComboBoxPersonalizat.EnumTipLista.Nespecificat;
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(7, 44);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(22, 13);
            this.lblTip.TabIndex = 0;
            this.lblTip.Text = "Tip";
            this.lblTip.ToolTipText = null;
            this.lblTip.ToolTipTitle = null;
            // 
            // txtDenumireFiscala
            // 
            this.txtDenumireFiscala.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenumireFiscala.CapitalizeazaPrimaLitera = false;
            this.txtDenumireFiscala.IsInReadOnlyMode = false;
            this.txtDenumireFiscala.Location = new System.Drawing.Point(91, 8);
            this.txtDenumireFiscala.Name = "txtDenumireFiscala";
            this.txtDenumireFiscala.ProprietateCorespunzatoare = null;
            this.txtDenumireFiscala.RaiseEventLaModificareProgramatica = false;
            this.txtDenumireFiscala.Size = new System.Drawing.Size(293, 20);
            this.txtDenumireFiscala.TabIndex = 1;
            this.txtDenumireFiscala.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtDenumireFiscala.TotulCuMajuscule = false;
            // 
            // lblDenumireFiscala
            // 
            this.lblDenumireFiscala.AutoSize = true;
            this.lblDenumireFiscala.Location = new System.Drawing.Point(7, 12);
            this.lblDenumireFiscala.Name = "lblDenumireFiscala";
            this.lblDenumireFiscala.Size = new System.Drawing.Size(85, 13);
            this.lblDenumireFiscala.TabIndex = 0;
            this.lblDenumireFiscala.Text = "Denumire fiscala";
            this.lblDenumireFiscala.ToolTipText = null;
            this.lblDenumireFiscala.ToolTipTitle = null;
            // 
            // FormCreareClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 578);
            this.Controls.Add(this.panelDateFirma);
            this.Controls.Add(this.ctrlValidareAnulare);
            this.Controls.Add(this.panelDateClinica);
            this.Name = "FormCreareClient";
            this.Text = "FormCreareClient";
            this.Controls.SetChildIndex(this.panelDateClinica, 0);
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulare, 0);
            this.Controls.SetChildIndex(this.panelDateFirma, 0);
            this.panelDateClinica.ResumeLayout(false);
            this.panelDateClinica.PerformLayout();
            this.panelDateFirma.ResumeLayout(false);
            this.panelDateFirma.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulare;
        private CCL.UI.PanelPersonalizat panelDateClinica;
        private Caramizi.ControlCautaTehnician ctrlAgent;
        private CCL.UI.LabelPersonalizat lblAgent;
        private CCL.UI.LabelPersonalizat lblObservatiiDateClinica;
        private Generale.ControlCautareRecomandant ctrlCautareRecomandant;
        private CCL.UI.LabelPersonalizat lblRecomandant;
        private CCL.UI.TextBoxPersonalizat txtWebsite;
        private CCL.UI.LabelPersonalizat lblWebSite;
        private CCL.UI.TextBoxPersonalizat txtEmail;
        private CCL.UI.LabelPersonalizat lblEmail;
        private CCL.UI.MaskedTextBoxPersonalizat txtTelefonFix;
        private CCL.UI.LabelPersonalizat lblTelefonFix;
        private CCL.UI.MaskedTextBoxPersonalizat txtTelefonMobil;
        private CCL.UI.LabelPersonalizat lblTelefonMobil;
        private CCL.UI.TextBoxPersonalizat txtDenumire;
        private CCL.UI.LabelPersonalizat lblDenumire;
        private CCL.UI.TextBoxPersonalizat txtObservatiiDateClinica;
        private CCL.UI.PanelPersonalizat panelDateFirma;
        private CCL.UI.TextBoxPersonalizat txtObservatiiDateFirma;
        private CCL.UI.LabelPersonalizat lblObservatiiDateFirma;
        private CCL.UI.controlAlegeData ctrlAlegeDataContract;
        private CCL.UI.LabelPersonalizat lblDataContract;
        private CCL.UI.TextBoxPersonalizat txtNrContract;
        private CCL.UI.LabelPersonalizat lblNrContract;
        private CCL.UI.ComboBoxPersonalizat cboCalitateReprezentant;
        private CCL.UI.LabelPersonalizat lblInCalitateDe;
        private CCL.UI.TextBoxPersonalizat txtReprezentantLegal;
        private CCL.UI.LabelPersonalizat lblReprezentantLegal;
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
    }
}