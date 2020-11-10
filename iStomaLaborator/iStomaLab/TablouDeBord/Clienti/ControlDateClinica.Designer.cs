namespace iStomaLab.TablouDeBord.Clienti
{
    partial class ControlDateClinica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlDateClinica));
            this.panelDateClinica = new CCL.UI.PanelPersonalizat(this.components);
            this.panelMediciSiCabinete = new CCL.UI.PanelPersonalizat(this.components);
            this.btnMedici = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblTotal = new CCL.UI.LabelPersonalizat(this.components);
            this.txtCauta = new CCL.UI.Caramizi.TextBoxCautare();
            this.btnCabinete = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnActiviInactivi = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblTitlu = new CCL.UI.LabelPersonalizat(this.components);
            this.btnAdauga = new CCL.UI.ButtonPersonalizat(this.components);
            this.dgvLista = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.panelIdentificare = new CCL.UI.PanelPersonalizat(this.components);
            this.lblDenumire = new CCL.UI.LabelPersonalizat(this.components);
            this.txtDenumire = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblTelefonMobil = new CCL.UI.LabelPersonalizat(this.components);
            this.txtTelefonMobil = new CCL.UI.MaskedTextBoxPersonalizat(this.components);
            this.lblTelefonFix = new CCL.UI.LabelPersonalizat(this.components);
            this.txtTelefonFix = new CCL.UI.MaskedTextBoxPersonalizat(this.components);
            this.lblEmail = new CCL.UI.LabelPersonalizat(this.components);
            this.txtEmail = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblWebSite = new CCL.UI.LabelPersonalizat(this.components);
            this.txtObservatiiDateClinica = new CCL.UI.TextBoxPersonalizat(this.components);
            this.txtWebsite = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblObservatiiDateClinica = new CCL.UI.LabelPersonalizat(this.components);
            this.lblRecomandant = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlCautareRecomandant = new iStomaLab.Generale.ControlCautareRecomandant();
            this.panelDateClinica.SuspendLayout();
            this.panelMediciSiCabinete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.panelIdentificare.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDateClinica
            // 
            this.panelDateClinica.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDateClinica.BackColor = System.Drawing.Color.White;
            this.panelDateClinica.Controls.Add(this.panelMediciSiCabinete);
            this.panelDateClinica.Controls.Add(this.panelIdentificare);
            this.panelDateClinica.Location = new System.Drawing.Point(-2, -1);
            this.panelDateClinica.Name = "panelDateClinica";
            this.panelDateClinica.Size = new System.Drawing.Size(760, 454);
            this.panelDateClinica.TabIndex = 0;
            this.panelDateClinica.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // panelMediciSiCabinete
            // 
            this.panelMediciSiCabinete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMediciSiCabinete.BackColor = System.Drawing.Color.White;
            this.panelMediciSiCabinete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMediciSiCabinete.Controls.Add(this.btnMedici);
            this.panelMediciSiCabinete.Controls.Add(this.lblTotal);
            this.panelMediciSiCabinete.Controls.Add(this.txtCauta);
            this.panelMediciSiCabinete.Controls.Add(this.btnCabinete);
            this.panelMediciSiCabinete.Controls.Add(this.btnActiviInactivi);
            this.panelMediciSiCabinete.Controls.Add(this.lblTitlu);
            this.panelMediciSiCabinete.Controls.Add(this.btnAdauga);
            this.panelMediciSiCabinete.Controls.Add(this.dgvLista);
            this.panelMediciSiCabinete.Location = new System.Drawing.Point(1, -1);
            this.panelMediciSiCabinete.Name = "panelMediciSiCabinete";
            this.panelMediciSiCabinete.Size = new System.Drawing.Size(392, 455);
            this.panelMediciSiCabinete.TabIndex = 0;
            this.panelMediciSiCabinete.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // btnMedici
            // 
            this.btnMedici.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMedici.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnMedici.Image = null;
            this.btnMedici.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMedici.Location = new System.Drawing.Point(3, 5);
            this.btnMedici.Name = "btnMedici";
            this.btnMedici.Size = new System.Drawing.Size(101, 23);
            this.btnMedici.TabIndex = 3;
            this.btnMedici.Text = "Medici";
            this.btnMedici.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMedici.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Bascula;
            this.btnMedici.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnMedici.UseVisualStyleBackColor = true;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(5, 435);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(31, 13);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "Total";
            this.lblTotal.ToolTipText = null;
            this.lblTotal.ToolTipTitle = null;
            // 
            // txtCauta
            // 
            this.txtCauta.AcceptButton = null;
            this.txtCauta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCauta.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCauta.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCauta.BackColor = System.Drawing.Color.White;
            this.txtCauta.CapitalizeazaPrimaLitera = false;
            this.txtCauta.IsInReadOnlyMode = false;
            this.txtCauta.Location = new System.Drawing.Point(172, 34);
            this.txtCauta.MaxLength = 32767;
            this.txtCauta.Multiline = false;
            this.txtCauta.Name = "txtCauta";
            this.txtCauta.ProprietateCorespunzatoare = null;
            this.txtCauta.RaiseEventLaModificareProgramatica = false;
            this.txtCauta.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCauta.Size = new System.Drawing.Size(209, 20);
            this.txtCauta.TabIndex = 0;
            this.txtCauta.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCauta.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCauta.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCauta.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCauta.UseSystemPasswordChar = false;
            // 
            // btnCabinete
            // 
            this.btnCabinete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCabinete.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnCabinete.Image = null;
            this.btnCabinete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCabinete.Location = new System.Drawing.Point(110, 5);
            this.btnCabinete.Name = "btnCabinete";
            this.btnCabinete.Size = new System.Drawing.Size(101, 23);
            this.btnCabinete.TabIndex = 4;
            this.btnCabinete.Text = "Cabinete";
            this.btnCabinete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCabinete.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Bascula;
            this.btnCabinete.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnCabinete.UseVisualStyleBackColor = true;
            // 
            // btnActiviInactivi
            // 
            this.btnActiviInactivi.ForeColor = System.Drawing.Color.Black;
            this.btnActiviInactivi.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnActiviInactivi.Image = ((System.Drawing.Image)(resources.GetObject("btnActiviInactivi.Image")));
            this.btnActiviInactivi.Location = new System.Drawing.Point(107, 33);
            this.btnActiviInactivi.Name = "btnActiviInactivi";
            this.btnActiviInactivi.Size = new System.Drawing.Size(45, 23);
            this.btnActiviInactivi.TabIndex = 2;
            this.btnActiviInactivi.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.ActiviDezactivati;
            this.btnActiviInactivi.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnActiviInactivi.UseVisualStyleBackColor = true;
            // 
            // lblTitlu
            // 
            this.lblTitlu.AutoSize = true;
            this.lblTitlu.Location = new System.Drawing.Point(4, 38);
            this.lblTitlu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitlu.Name = "lblTitlu";
            this.lblTitlu.Size = new System.Drawing.Size(38, 13);
            this.lblTitlu.TabIndex = 7;
            this.lblTitlu.Text = "Medici";
            this.lblTitlu.ToolTipText = null;
            this.lblTitlu.ToolTipTitle = null;
            // 
            // btnAdauga
            // 
            this.btnAdauga.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdauga.Image = ((System.Drawing.Image)(resources.GetObject("btnAdauga.Image")));
            this.btnAdauga.Location = new System.Drawing.Point(56, 33);
            this.btnAdauga.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdauga.Name = "btnAdauga";
            this.btnAdauga.Size = new System.Drawing.Size(45, 23);
            this.btnAdauga.TabIndex = 1;
            this.btnAdauga.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdauga.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdauga.UseVisualStyleBackColor = true;
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
            this.dgvLista.Location = new System.Drawing.Point(3, 60);
            this.dgvLista.Margin = new System.Windows.Forms.Padding(2);
            this.dgvLista.MultiSelect = false;
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ProprietateCorespunzatoare = "";
            this.dgvLista.RowHeadersVisible = false;
            this.dgvLista.RowTemplate.Height = 24;
            this.dgvLista.SeIncarca = false;
            this.dgvLista.SelectedText = "";
            this.dgvLista.SelectionLength = 0;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLista.SelectionStart = 0;
            this.dgvLista.Size = new System.Drawing.Size(378, 371);
            this.dgvLista.TabIndex = 5;
            // 
            // panelIdentificare
            // 
            this.panelIdentificare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelIdentificare.BackColor = System.Drawing.Color.White;
            this.panelIdentificare.Controls.Add(this.lblDenumire);
            this.panelIdentificare.Controls.Add(this.txtDenumire);
            this.panelIdentificare.Controls.Add(this.lblTelefonMobil);
            this.panelIdentificare.Controls.Add(this.txtTelefonMobil);
            this.panelIdentificare.Controls.Add(this.lblTelefonFix);
            this.panelIdentificare.Controls.Add(this.txtTelefonFix);
            this.panelIdentificare.Controls.Add(this.lblEmail);
            this.panelIdentificare.Controls.Add(this.txtEmail);
            this.panelIdentificare.Controls.Add(this.lblWebSite);
            this.panelIdentificare.Controls.Add(this.txtObservatiiDateClinica);
            this.panelIdentificare.Controls.Add(this.txtWebsite);
            this.panelIdentificare.Controls.Add(this.lblObservatiiDateClinica);
            this.panelIdentificare.Controls.Add(this.lblRecomandant);
            this.panelIdentificare.Controls.Add(this.ctrlCautareRecomandant);
            this.panelIdentificare.Location = new System.Drawing.Point(392, 0);
            this.panelIdentificare.Name = "panelIdentificare";
            this.panelIdentificare.Size = new System.Drawing.Size(368, 454);
            this.panelIdentificare.TabIndex = 1;
            this.panelIdentificare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
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
            // txtDenumire
            // 
            this.txtDenumire.CapitalizeazaPrimaLitera = false;
            this.txtDenumire.IsInReadOnlyMode = false;
            this.txtDenumire.Location = new System.Drawing.Point(86, 5);
            this.txtDenumire.Name = "txtDenumire";
            this.txtDenumire.ProprietateCorespunzatoare = null;
            this.txtDenumire.RaiseEventLaModificareProgramatica = false;
            this.txtDenumire.Size = new System.Drawing.Size(274, 20);
            this.txtDenumire.TabIndex = 0;
            this.txtDenumire.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtDenumire.TotulCuMajuscule = false;
            // 
            // lblTelefonMobil
            // 
            this.lblTelefonMobil.AutoSize = true;
            this.lblTelefonMobil.Location = new System.Drawing.Point(6, 38);
            this.lblTelefonMobil.Name = "lblTelefonMobil";
            this.lblTelefonMobil.Size = new System.Drawing.Size(70, 13);
            this.lblTelefonMobil.TabIndex = 8;
            this.lblTelefonMobil.Text = "Telefon mobil";
            this.lblTelefonMobil.ToolTipText = null;
            this.lblTelefonMobil.ToolTipTitle = null;
            // 
            // txtTelefonMobil
            // 
            this.txtTelefonMobil.BackColor = System.Drawing.SystemColors.Window;
            this.txtTelefonMobil.Location = new System.Drawing.Point(86, 34);
            this.txtTelefonMobil.Name = "txtTelefonMobil";
            this.txtTelefonMobil.ProprietateCorespunzatoare = null;
            this.txtTelefonMobil.Size = new System.Drawing.Size(274, 20);
            this.txtTelefonMobil.TabIndex = 1;
            this.txtTelefonMobil.Text = "0";
            this.txtTelefonMobil.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.txtTelefonMobil.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTelefonMobil.ValoareDouble = 0D;
            // 
            // lblTelefonFix
            // 
            this.lblTelefonFix.AutoSize = true;
            this.lblTelefonFix.Location = new System.Drawing.Point(6, 67);
            this.lblTelefonFix.Name = "lblTelefonFix";
            this.lblTelefonFix.Size = new System.Drawing.Size(56, 13);
            this.lblTelefonFix.TabIndex = 9;
            this.lblTelefonFix.Text = "Telefon fix";
            this.lblTelefonFix.ToolTipText = null;
            this.lblTelefonFix.ToolTipTitle = null;
            // 
            // txtTelefonFix
            // 
            this.txtTelefonFix.BackColor = System.Drawing.SystemColors.Window;
            this.txtTelefonFix.Location = new System.Drawing.Point(86, 63);
            this.txtTelefonFix.Name = "txtTelefonFix";
            this.txtTelefonFix.ProprietateCorespunzatoare = null;
            this.txtTelefonFix.Size = new System.Drawing.Size(274, 20);
            this.txtTelefonFix.TabIndex = 2;
            this.txtTelefonFix.Text = "0";
            this.txtTelefonFix.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.txtTelefonFix.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTelefonFix.ValoareDouble = 0D;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(6, 96);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Email";
            this.lblEmail.ToolTipText = null;
            this.lblEmail.ToolTipTitle = null;
            // 
            // txtEmail
            // 
            this.txtEmail.CapitalizeazaPrimaLitera = false;
            this.txtEmail.IsInReadOnlyMode = false;
            this.txtEmail.Location = new System.Drawing.Point(86, 92);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ProprietateCorespunzatoare = null;
            this.txtEmail.RaiseEventLaModificareProgramatica = false;
            this.txtEmail.Size = new System.Drawing.Size(274, 20);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.AdresaMail;
            this.txtEmail.TotulCuMajuscule = false;
            // 
            // lblWebSite
            // 
            this.lblWebSite.AutoSize = true;
            this.lblWebSite.Location = new System.Drawing.Point(6, 122);
            this.lblWebSite.Name = "lblWebSite";
            this.lblWebSite.Size = new System.Drawing.Size(46, 13);
            this.lblWebSite.TabIndex = 11;
            this.lblWebSite.Text = "Website";
            this.lblWebSite.ToolTipText = null;
            this.lblWebSite.ToolTipTitle = null;
            // 
            // txtObservatiiDateClinica
            // 
            this.txtObservatiiDateClinica.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtObservatiiDateClinica.CapitalizeazaPrimaLitera = false;
            this.txtObservatiiDateClinica.IsInReadOnlyMode = false;
            this.txtObservatiiDateClinica.Location = new System.Drawing.Point(9, 199);
            this.txtObservatiiDateClinica.Multiline = true;
            this.txtObservatiiDateClinica.Name = "txtObservatiiDateClinica";
            this.txtObservatiiDateClinica.ProprietateCorespunzatoare = null;
            this.txtObservatiiDateClinica.RaiseEventLaModificareProgramatica = false;
            this.txtObservatiiDateClinica.Size = new System.Drawing.Size(351, 249);
            this.txtObservatiiDateClinica.TabIndex = 6;
            this.txtObservatiiDateClinica.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtObservatiiDateClinica.TotulCuMajuscule = false;
            // 
            // txtWebsite
            // 
            this.txtWebsite.CapitalizeazaPrimaLitera = false;
            this.txtWebsite.IsInReadOnlyMode = false;
            this.txtWebsite.Location = new System.Drawing.Point(86, 122);
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.ProprietateCorespunzatoare = null;
            this.txtWebsite.RaiseEventLaModificareProgramatica = false;
            this.txtWebsite.Size = new System.Drawing.Size(274, 20);
            this.txtWebsite.TabIndex = 4;
            this.txtWebsite.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtWebsite.TotulCuMajuscule = false;
            // 
            // lblObservatiiDateClinica
            // 
            this.lblObservatiiDateClinica.AutoSize = true;
            this.lblObservatiiDateClinica.Location = new System.Drawing.Point(9, 181);
            this.lblObservatiiDateClinica.Name = "lblObservatiiDateClinica";
            this.lblObservatiiDateClinica.Size = new System.Drawing.Size(54, 13);
            this.lblObservatiiDateClinica.TabIndex = 13;
            this.lblObservatiiDateClinica.Text = "Observatii";
            this.lblObservatiiDateClinica.ToolTipText = null;
            this.lblObservatiiDateClinica.ToolTipTitle = null;
            // 
            // lblRecomandant
            // 
            this.lblRecomandant.AutoSize = true;
            this.lblRecomandant.Location = new System.Drawing.Point(6, 154);
            this.lblRecomandant.Name = "lblRecomandant";
            this.lblRecomandant.Size = new System.Drawing.Size(74, 13);
            this.lblRecomandant.TabIndex = 12;
            this.lblRecomandant.Text = "Recomandant";
            this.lblRecomandant.ToolTipText = null;
            this.lblRecomandant.ToolTipTitle = null;
            // 
            // ctrlCautareRecomandant
            // 
            this.ctrlCautareRecomandant.Location = new System.Drawing.Point(86, 148);
            this.ctrlCautareRecomandant.Name = "ctrlCautareRecomandant";
            this.ctrlCautareRecomandant.Size = new System.Drawing.Size(274, 25);
            this.ctrlCautareRecomandant.TabIndex = 5;
            // 
            // ControlDateClinica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelDateClinica);
            this.Name = "ControlDateClinica";
            this.Size = new System.Drawing.Size(756, 451);
            this.panelDateClinica.ResumeLayout(false);
            this.panelMediciSiCabinete.ResumeLayout(false);
            this.panelMediciSiCabinete.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.panelIdentificare.ResumeLayout(false);
            this.panelIdentificare.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private CCL.UI.PanelPersonalizat panelDateClinica;
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
        private CCL.UI.LabelPersonalizat lblObservatiiDateClinica;
        private CCL.UI.ButtonPersonalizat btnCabinete;
        private CCL.UI.ButtonPersonalizat btnMedici;
        private CCL.UI.ButtonPersonalizat btnActiviInactivi;
        private CCL.UI.LabelPersonalizat lblTotal;
        private CCL.UI.DataGridViewPersonalizat dgvLista;
        private CCL.UI.ButtonPersonalizat btnAdauga;
        private CCL.UI.LabelPersonalizat lblTitlu;
        private CCL.UI.Caramizi.TextBoxCautare txtCauta;
        private CCL.UI.PanelPersonalizat panelIdentificare;
        private CCL.UI.PanelPersonalizat panelMediciSiCabinete;
    }
}
