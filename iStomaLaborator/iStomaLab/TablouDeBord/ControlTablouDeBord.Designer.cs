namespace iStomaLab.TablouDeBord
{
    partial class ControlTablouDeBord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlTablouDeBord));
            this.btnArataAdaugareRapida = new iStomaLab.Caramizi.ButonFiltreVerticala();
            this.panelZonaAdaugare = new CCL.UI.PanelPersonalizat(this.components);
            this.txtADNrElemente = new CCL.UI.MaskedTextBoxPersonalizat(this.components);
            this.lblADNrElemente = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlADCautaTehnician = new iStomaLab.Caramizi.ControlCautaTehnician();
            this.ctrlADCautareEtapa = new iStomaLab.Caramizi.ControlCautareEtapa();
            this.ctrlADCautareLucrare = new iStomaLab.Caramizi.ControlCautareLucrare();
            this.txtADCuloare = new CCL.UI.TextBoxPersonalizat(this.components);
            this.ctrlADDataOraPrimire = new CCL.UI.Caramizi.ControlDataOraGuma();
            this.txtADPacient = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblADCuloare = new CCL.UI.LabelPersonalizat(this.components);
            this.lblADPacient = new CCL.UI.LabelPersonalizat(this.components);
            this.btnGoleste = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnAdaugaLucrareRapida = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblADEtapa = new CCL.UI.LabelPersonalizat(this.components);
            this.lblADTehnician = new CCL.UI.LabelPersonalizat(this.components);
            this.lblADLucrare = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlADCautareMedicClinica = new iStomaLab.Caramizi.ControlCautareMedicClinica();
            this.lblADMedic = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlADCautareCabinetClinica = new iStomaLab.Caramizi.ControlCautareCabinetClinica();
            this.lblAdCabinet = new CCL.UI.LabelPersonalizat(this.components);
            this.lblADClinica = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlADCautareClinica = new iStomaLab.Caramizi.ControlCautareClinica();
            this.panelOptiuni = new CCL.UI.ControaleSpecializate.PanelOptiuni();
            this.ctrlDataInteres = new iStomaLab.TablouDeBord.ControlDataInteresLucrari();
            this.btnSchimbaEtapa = new CCL.UI.ControaleSpecializate.ButonOptiunePanelOptiuni();
            this.btnInchidePanelOptiuni = new CCL.UI.ControaleSpecializate.ButonInchidePanelOptiuni();
            this.btnOptiuni = new CCL.UI.ControaleSpecializate.ButonMaiMulte();
            this.btnActivDezactivat = new CCL.UI.ButtonPersonalizat(this.components);
            this.txtCautaComanda = new CCL.UI.Caramizi.TextBoxCautare();
            this.ctrlPerioada = new iStomaLab.Caramizi.ControlPerioada();
            this.btnAdaugareComanda = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblComenziInLucru = new CCL.UI.LabelPersonalizat(this.components);
            this.dgvListaComenzi = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.lblTotal = new CCL.UI.LabelPersonalizat(this.components);
            this.lblCauta = new CCL.UI.LabelPersonalizat(this.components);
            this.panelColoanaFiltrare = new CCL.UI.FlowLayoutPanelPersonalizat(this.components);
            this.rbTot = new CCL.UI.RadioButtonPersonalizat(this.components);
            this.rbClinica = new CCL.UI.RadioButtonPersonalizat(this.components);
            this.rbMedic = new CCL.UI.RadioButtonPersonalizat(this.components);
            this.rbPacient = new CCL.UI.RadioButtonPersonalizat(this.components);
            this.rbTehnician = new CCL.UI.RadioButtonPersonalizat(this.components);
            this.panelZonaAdaugare.SuspendLayout();
            this.panelOptiuni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaComenzi)).BeginInit();
            this.panelColoanaFiltrare.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnArataAdaugareRapida
            // 
            this.btnArataAdaugareRapida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArataAdaugareRapida.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnArataAdaugareRapida.Image = ((System.Drawing.Image)(resources.GetObject("btnArataAdaugareRapida.Image")));
            this.btnArataAdaugareRapida.Location = new System.Drawing.Point(971, 317);
            this.btnArataAdaugareRapida.Name = "btnArataAdaugareRapida";
            this.btnArataAdaugareRapida.Size = new System.Drawing.Size(32, 19);
            this.btnArataAdaugareRapida.TabIndex = 12;
            this.btnArataAdaugareRapida.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.GestiuneFiltreVerticala;
            this.btnArataAdaugareRapida.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnArataAdaugareRapida.UseVisualStyleBackColor = true;
            // 
            // panelZonaAdaugare
            // 
            this.panelZonaAdaugare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelZonaAdaugare.BackColor = System.Drawing.Color.White;
            this.panelZonaAdaugare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelZonaAdaugare.Controls.Add(this.txtADNrElemente);
            this.panelZonaAdaugare.Controls.Add(this.lblADNrElemente);
            this.panelZonaAdaugare.Controls.Add(this.ctrlADCautaTehnician);
            this.panelZonaAdaugare.Controls.Add(this.ctrlADCautareEtapa);
            this.panelZonaAdaugare.Controls.Add(this.ctrlADCautareLucrare);
            this.panelZonaAdaugare.Controls.Add(this.txtADCuloare);
            this.panelZonaAdaugare.Controls.Add(this.ctrlADDataOraPrimire);
            this.panelZonaAdaugare.Controls.Add(this.txtADPacient);
            this.panelZonaAdaugare.Controls.Add(this.lblADCuloare);
            this.panelZonaAdaugare.Controls.Add(this.lblADPacient);
            this.panelZonaAdaugare.Controls.Add(this.btnGoleste);
            this.panelZonaAdaugare.Controls.Add(this.btnAdaugaLucrareRapida);
            this.panelZonaAdaugare.Controls.Add(this.lblADEtapa);
            this.panelZonaAdaugare.Controls.Add(this.lblADTehnician);
            this.panelZonaAdaugare.Controls.Add(this.lblADLucrare);
            this.panelZonaAdaugare.Controls.Add(this.ctrlADCautareMedicClinica);
            this.panelZonaAdaugare.Controls.Add(this.lblADMedic);
            this.panelZonaAdaugare.Controls.Add(this.ctrlADCautareCabinetClinica);
            this.panelZonaAdaugare.Controls.Add(this.lblAdCabinet);
            this.panelZonaAdaugare.Controls.Add(this.lblADClinica);
            this.panelZonaAdaugare.Controls.Add(this.ctrlADCautareClinica);
            this.panelZonaAdaugare.Location = new System.Drawing.Point(-1, 338);
            this.panelZonaAdaugare.Name = "panelZonaAdaugare";
            this.panelZonaAdaugare.Size = new System.Drawing.Size(1008, 91);
            this.panelZonaAdaugare.TabIndex = 11;
            this.panelZonaAdaugare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // txtADNrElemente
            // 
            this.txtADNrElemente.BackColor = System.Drawing.SystemColors.Window;
            this.txtADNrElemente.Location = new System.Drawing.Point(705, 8);
            this.txtADNrElemente.Name = "txtADNrElemente";
            this.txtADNrElemente.ProprietateCorespunzatoare = null;
            this.txtADNrElemente.Size = new System.Drawing.Size(49, 20);
            this.txtADNrElemente.TabIndex = 21;
            this.txtADNrElemente.Text = "0";
            this.txtADNrElemente.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.txtADNrElemente.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtADNrElemente.ValoareDouble = 0D;
            // 
            // lblADNrElemente
            // 
            this.lblADNrElemente.AutoSize = true;
            this.lblADNrElemente.Location = new System.Drawing.Point(656, 10);
            this.lblADNrElemente.Name = "lblADNrElemente";
            this.lblADNrElemente.Size = new System.Drawing.Size(49, 13);
            this.lblADNrElemente.TabIndex = 20;
            this.lblADNrElemente.Text = "Nr. elem.";
            this.lblADNrElemente.ToolTipText = null;
            this.lblADNrElemente.ToolTipTitle = null;
            // 
            // ctrlADCautaTehnician
            // 
            this.ctrlADCautaTehnician.Location = new System.Drawing.Point(373, 61);
            this.ctrlADCautaTehnician.Name = "ctrlADCautaTehnician";
            this.ctrlADCautaTehnician.Size = new System.Drawing.Size(251, 23);
            this.ctrlADCautaTehnician.TabIndex = 5;
            // 
            // ctrlADCautareEtapa
            // 
            this.ctrlADCautareEtapa.Location = new System.Drawing.Point(373, 33);
            this.ctrlADCautareEtapa.Name = "ctrlADCautareEtapa";
            this.ctrlADCautareEtapa.Size = new System.Drawing.Size(251, 23);
            this.ctrlADCautareEtapa.TabIndex = 4;
            // 
            // ctrlADCautareLucrare
            // 
            this.ctrlADCautareLucrare.Location = new System.Drawing.Point(373, 5);
            this.ctrlADCautareLucrare.Name = "ctrlADCautareLucrare";
            this.ctrlADCautareLucrare.Size = new System.Drawing.Size(251, 22);
            this.ctrlADCautareLucrare.TabIndex = 3;
            // 
            // txtADCuloare
            // 
            this.txtADCuloare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtADCuloare.CapitalizeazaPrimaLitera = false;
            this.txtADCuloare.IsInReadOnlyMode = false;
            this.txtADCuloare.Location = new System.Drawing.Point(705, 35);
            this.txtADCuloare.Name = "txtADCuloare";
            this.txtADCuloare.ProprietateCorespunzatoare = null;
            this.txtADCuloare.RaiseEventLaModificareProgramatica = false;
            this.txtADCuloare.Size = new System.Drawing.Size(200, 20);
            this.txtADCuloare.TabIndex = 6;
            this.txtADCuloare.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtADCuloare.TotulCuMajuscule = false;
            // 
            // ctrlADDataOraPrimire
            // 
            this.ctrlADDataOraPrimire.AfiseazaButonGuma = false;
            this.ctrlADDataOraPrimire.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlADDataOraPrimire.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ctrlADDataOraPrimire.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ctrlADDataOraPrimire.BackColor = System.Drawing.Color.White;
            this.ctrlADDataOraPrimire.DataAfisata = new System.DateTime(((long)(0)));
            this.ctrlADDataOraPrimire.IsInReadOnlyMode = false;
            this.ctrlADDataOraPrimire.Location = new System.Drawing.Point(752, 5);
            this.ctrlADDataOraPrimire.Name = "ctrlADDataOraPrimire";
            this.ctrlADDataOraPrimire.PragInferior = new System.DateTime(((long)(0)));
            this.ctrlADDataOraPrimire.PragSuperior = new System.DateTime(((long)(0)));
            this.ctrlADDataOraPrimire.ProprietateCorespunzatoare = null;
            this.ctrlADDataOraPrimire.Size = new System.Drawing.Size(181, 23);
            this.ctrlADDataOraPrimire.TabIndex = 8;
            this.ctrlADDataOraPrimire.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.ctrlADDataOraPrimire.TipDeschidereCalendar = CCL.UI.CEnumerariComune.EnumTipDeschidere.StangaSus;
            // 
            // txtADPacient
            // 
            this.txtADPacient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtADPacient.CapitalizeazaPrimaLitera = false;
            this.txtADPacient.IsInReadOnlyMode = false;
            this.txtADPacient.Location = new System.Drawing.Point(705, 63);
            this.txtADPacient.Name = "txtADPacient";
            this.txtADPacient.ProprietateCorespunzatoare = null;
            this.txtADPacient.RaiseEventLaModificareProgramatica = false;
            this.txtADPacient.Size = new System.Drawing.Size(200, 20);
            this.txtADPacient.TabIndex = 7;
            this.txtADPacient.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtADPacient.TotulCuMajuscule = false;
            // 
            // lblADCuloare
            // 
            this.lblADCuloare.AutoSize = true;
            this.lblADCuloare.Location = new System.Drawing.Point(656, 39);
            this.lblADCuloare.Name = "lblADCuloare";
            this.lblADCuloare.Size = new System.Drawing.Size(43, 13);
            this.lblADCuloare.TabIndex = 17;
            this.lblADCuloare.Text = "Culoare";
            this.lblADCuloare.ToolTipText = null;
            this.lblADCuloare.ToolTipTitle = null;
            // 
            // lblADPacient
            // 
            this.lblADPacient.AutoSize = true;
            this.lblADPacient.Location = new System.Drawing.Point(656, 67);
            this.lblADPacient.Name = "lblADPacient";
            this.lblADPacient.Size = new System.Drawing.Size(43, 13);
            this.lblADPacient.TabIndex = 18;
            this.lblADPacient.Text = "Pacient";
            this.lblADPacient.ToolTipText = null;
            this.lblADPacient.ToolTipTitle = null;
            // 
            // btnGoleste
            // 
            this.btnGoleste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGoleste.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGoleste.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnGoleste.Image = ((System.Drawing.Image)(resources.GetObject("btnGoleste.Image")));
            this.btnGoleste.Location = new System.Drawing.Point(936, 6);
            this.btnGoleste.Name = "btnGoleste";
            this.btnGoleste.Size = new System.Drawing.Size(64, 22);
            this.btnGoleste.TabIndex = 10;
            this.btnGoleste.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Guma;
            this.btnGoleste.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnGoleste.UseVisualStyleBackColor = true;
            // 
            // btnAdaugaLucrareRapida
            // 
            this.btnAdaugaLucrareRapida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdaugaLucrareRapida.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdaugaLucrareRapida.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdaugaLucrareRapida.Image = ((System.Drawing.Image)(resources.GetObject("btnAdaugaLucrareRapida.Image")));
            this.btnAdaugaLucrareRapida.Location = new System.Drawing.Point(936, 34);
            this.btnAdaugaLucrareRapida.Name = "btnAdaugaLucrareRapida";
            this.btnAdaugaLucrareRapida.Size = new System.Drawing.Size(64, 50);
            this.btnAdaugaLucrareRapida.TabIndex = 9;
            this.btnAdaugaLucrareRapida.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Validare;
            this.btnAdaugaLucrareRapida.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdaugaLucrareRapida.UseVisualStyleBackColor = true;
            // 
            // lblADEtapa
            // 
            this.lblADEtapa.AutoSize = true;
            this.lblADEtapa.Location = new System.Drawing.Point(314, 38);
            this.lblADEtapa.Name = "lblADEtapa";
            this.lblADEtapa.Size = new System.Drawing.Size(35, 13);
            this.lblADEtapa.TabIndex = 15;
            this.lblADEtapa.Text = "Etapa";
            this.lblADEtapa.ToolTipText = null;
            this.lblADEtapa.ToolTipTitle = null;
            // 
            // lblADTehnician
            // 
            this.lblADTehnician.AutoSize = true;
            this.lblADTehnician.Location = new System.Drawing.Point(314, 66);
            this.lblADTehnician.Name = "lblADTehnician";
            this.lblADTehnician.Size = new System.Drawing.Size(54, 13);
            this.lblADTehnician.TabIndex = 16;
            this.lblADTehnician.Text = "Tehnician";
            this.lblADTehnician.ToolTipText = null;
            this.lblADTehnician.ToolTipTitle = null;
            // 
            // lblADLucrare
            // 
            this.lblADLucrare.AutoSize = true;
            this.lblADLucrare.Location = new System.Drawing.Point(314, 10);
            this.lblADLucrare.Name = "lblADLucrare";
            this.lblADLucrare.Size = new System.Drawing.Size(43, 13);
            this.lblADLucrare.TabIndex = 14;
            this.lblADLucrare.Text = "Lucrare";
            this.lblADLucrare.ToolTipText = null;
            this.lblADLucrare.ToolTipTitle = null;
            // 
            // ctrlADCautareMedicClinica
            // 
            this.ctrlADCautareMedicClinica.Location = new System.Drawing.Point(56, 33);
            this.ctrlADCautareMedicClinica.Name = "ctrlADCautareMedicClinica";
            this.ctrlADCautareMedicClinica.Size = new System.Drawing.Size(236, 23);
            this.ctrlADCautareMedicClinica.TabIndex = 1;
            // 
            // lblADMedic
            // 
            this.lblADMedic.AutoSize = true;
            this.lblADMedic.Location = new System.Drawing.Point(6, 38);
            this.lblADMedic.Name = "lblADMedic";
            this.lblADMedic.Size = new System.Drawing.Size(36, 13);
            this.lblADMedic.TabIndex = 12;
            this.lblADMedic.Text = "Medic";
            this.lblADMedic.ToolTipText = null;
            this.lblADMedic.ToolTipTitle = null;
            // 
            // ctrlADCautareCabinetClinica
            // 
            this.ctrlADCautareCabinetClinica.Location = new System.Drawing.Point(56, 61);
            this.ctrlADCautareCabinetClinica.Name = "ctrlADCautareCabinetClinica";
            this.ctrlADCautareCabinetClinica.Size = new System.Drawing.Size(236, 23);
            this.ctrlADCautareCabinetClinica.TabIndex = 2;
            // 
            // lblAdCabinet
            // 
            this.lblAdCabinet.AutoSize = true;
            this.lblAdCabinet.Location = new System.Drawing.Point(6, 66);
            this.lblAdCabinet.Name = "lblAdCabinet";
            this.lblAdCabinet.Size = new System.Drawing.Size(43, 13);
            this.lblAdCabinet.TabIndex = 13;
            this.lblAdCabinet.Text = "Cabinet";
            this.lblAdCabinet.ToolTipText = null;
            this.lblAdCabinet.ToolTipTitle = null;
            // 
            // lblADClinica
            // 
            this.lblADClinica.AutoSize = true;
            this.lblADClinica.Location = new System.Drawing.Point(6, 10);
            this.lblADClinica.Name = "lblADClinica";
            this.lblADClinica.Size = new System.Drawing.Size(38, 13);
            this.lblADClinica.TabIndex = 11;
            this.lblADClinica.Text = "Clinica";
            this.lblADClinica.ToolTipText = null;
            this.lblADClinica.ToolTipTitle = null;
            // 
            // ctrlADCautareClinica
            // 
            this.ctrlADCautareClinica.Location = new System.Drawing.Point(56, 6);
            this.ctrlADCautareClinica.Name = "ctrlADCautareClinica";
            this.ctrlADCautareClinica.Size = new System.Drawing.Size(236, 21);
            this.ctrlADCautareClinica.TabIndex = 0;
            // 
            // panelOptiuni
            // 
            this.panelOptiuni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOptiuni.BackColor = System.Drawing.Color.White;
            this.panelOptiuni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOptiuni.Controls.Add(this.ctrlDataInteres);
            this.panelOptiuni.Controls.Add(this.btnSchimbaEtapa);
            this.panelOptiuni.Controls.Add(this.btnInchidePanelOptiuni);
            this.panelOptiuni.Location = new System.Drawing.Point(762, 87);
            this.panelOptiuni.Name = "panelOptiuni";
            this.panelOptiuni.Size = new System.Drawing.Size(243, 156);
            this.panelOptiuni.TabIndex = 8;
            this.panelOptiuni.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.panelOptiuni.Visible = false;
            // 
            // ctrlDataInteres
            // 
            this.ctrlDataInteres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlDataInteres.Location = new System.Drawing.Point(0, 27);
            this.ctrlDataInteres.Name = "ctrlDataInteres";
            this.ctrlDataInteres.Size = new System.Drawing.Size(245, 86);
            this.ctrlDataInteres.TabIndex = 2;
            // 
            // btnSchimbaEtapa
            // 
            this.btnSchimbaEtapa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSchimbaEtapa.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSchimbaEtapa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSchimbaEtapa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSchimbaEtapa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSchimbaEtapa.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSchimbaEtapa.Location = new System.Drawing.Point(-1, 128);
            this.btnSchimbaEtapa.Name = "btnSchimbaEtapa";
            this.btnSchimbaEtapa.Size = new System.Drawing.Size(244, 27);
            this.btnSchimbaEtapa.TabIndex = 1;
            this.btnSchimbaEtapa.Text = "Schimba etapa";
            this.btnSchimbaEtapa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSchimbaEtapa.UseVisualStyleBackColor = true;
            // 
            // btnInchidePanelOptiuni
            // 
            this.btnInchidePanelOptiuni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInchidePanelOptiuni.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnInchidePanelOptiuni.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInchidePanelOptiuni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInchidePanelOptiuni.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInchidePanelOptiuni.Location = new System.Drawing.Point(209, 0);
            this.btnInchidePanelOptiuni.Name = "btnInchidePanelOptiuni";
            this.btnInchidePanelOptiuni.Size = new System.Drawing.Size(34, 23);
            this.btnInchidePanelOptiuni.TabIndex = 0;
            this.btnInchidePanelOptiuni.TabStop = false;
            this.btnInchidePanelOptiuni.Text = "X";
            this.btnInchidePanelOptiuni.UseVisualStyleBackColor = true;
            // 
            // btnOptiuni
            // 
            this.btnOptiuni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptiuni.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOptiuni.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnOptiuni.Image = ((System.Drawing.Image)(resources.GetObject("btnOptiuni.Image")));
            this.btnOptiuni.Location = new System.Drawing.Point(972, 60);
            this.btnOptiuni.Name = "btnOptiuni";
            this.btnOptiuni.Size = new System.Drawing.Size(31, 24);
            this.btnOptiuni.TabIndex = 7;
            this.btnOptiuni.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.MaiMulte;
            this.btnOptiuni.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnOptiuni.UseVisualStyleBackColor = true;
            // 
            // btnActivDezactivat
            // 
            this.btnActivDezactivat.ForeColor = System.Drawing.Color.Black;
            this.btnActivDezactivat.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnActivDezactivat.Image = ((System.Drawing.Image)(resources.GetObject("btnActivDezactivat.Image")));
            this.btnActivDezactivat.Location = new System.Drawing.Point(102, 59);
            this.btnActivDezactivat.Name = "btnActivDezactivat";
            this.btnActivDezactivat.Size = new System.Drawing.Size(40, 25);
            this.btnActivDezactivat.TabIndex = 6;
            this.btnActivDezactivat.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.ActiviDezactivati;
            this.btnActivDezactivat.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnActivDezactivat.UseVisualStyleBackColor = true;
            // 
            // txtCautaComanda
            // 
            this.txtCautaComanda.AcceptButton = null;
            this.txtCautaComanda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautaComanda.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautaComanda.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautaComanda.BackColor = System.Drawing.Color.White;
            this.txtCautaComanda.CapitalizeazaPrimaLitera = false;
            this.txtCautaComanda.IsInReadOnlyMode = false;
            this.txtCautaComanda.Location = new System.Drawing.Point(371, 62);
            this.txtCautaComanda.MaxLength = 32767;
            this.txtCautaComanda.Multiline = false;
            this.txtCautaComanda.Name = "txtCautaComanda";
            this.txtCautaComanda.ProprietateCorespunzatoare = null;
            this.txtCautaComanda.RaiseEventLaModificareProgramatica = false;
            this.txtCautaComanda.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautaComanda.Size = new System.Drawing.Size(223, 20);
            this.txtCautaComanda.TabIndex = 4;
            this.txtCautaComanda.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautaComanda.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautaComanda.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautaComanda.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautaComanda.UseSystemPasswordChar = false;
            // 
            // ctrlPerioada
            // 
            this.ctrlPerioada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlPerioada.Location = new System.Drawing.Point(1, -1);
            this.ctrlPerioada.Name = "ctrlPerioada";
            this.ctrlPerioada.Size = new System.Drawing.Size(1005, 56);
            this.ctrlPerioada.TabIndex = 3;
            // 
            // btnAdaugareComanda
            // 
            this.btnAdaugareComanda.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdaugareComanda.Image = ((System.Drawing.Image)(resources.GetObject("btnAdaugareComanda.Image")));
            this.btnAdaugareComanda.Location = new System.Drawing.Point(56, 59);
            this.btnAdaugareComanda.Name = "btnAdaugareComanda";
            this.btnAdaugareComanda.Size = new System.Drawing.Size(40, 25);
            this.btnAdaugareComanda.TabIndex = 2;
            this.btnAdaugareComanda.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdaugareComanda.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdaugareComanda.UseVisualStyleBackColor = true;
            // 
            // lblComenziInLucru
            // 
            this.lblComenziInLucru.AutoSize = true;
            this.lblComenziInLucru.Location = new System.Drawing.Point(3, 65);
            this.lblComenziInLucru.Name = "lblComenziInLucru";
            this.lblComenziInLucru.Size = new System.Drawing.Size(47, 13);
            this.lblComenziInLucru.TabIndex = 1;
            this.lblComenziInLucru.Text = "Comenzi";
            this.lblComenziInLucru.ToolTipText = null;
            this.lblComenziInLucru.ToolTipTitle = null;
            // 
            // dgvListaComenzi
            // 
            this.dgvListaComenzi.AllowUserToAddRows = false;
            this.dgvListaComenzi.AllowUserToDeleteRows = false;
            this.dgvListaComenzi.AllowUserToResizeRows = false;
            this.dgvListaComenzi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaComenzi.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaComenzi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaComenzi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaComenzi.HideSelection = true;
            this.dgvListaComenzi.IsInReadOnlyMode = false;
            this.dgvListaComenzi.Location = new System.Drawing.Point(-1, 87);
            this.dgvListaComenzi.MultiSelect = false;
            this.dgvListaComenzi.Name = "dgvListaComenzi";
            this.dgvListaComenzi.ProprietateCorespunzatoare = "";
            this.dgvListaComenzi.RowHeadersVisible = false;
            this.dgvListaComenzi.SeIncarca = false;
            this.dgvListaComenzi.SelectedText = "";
            this.dgvListaComenzi.SelectionLength = 0;
            this.dgvListaComenzi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaComenzi.SelectionStart = 0;
            this.dgvListaComenzi.Size = new System.Drawing.Size(1008, 227);
            this.dgvListaComenzi.TabIndex = 0;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(3, 319);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(31, 13);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "Total";
            this.lblTotal.ToolTipText = null;
            this.lblTotal.ToolTipTitle = null;
            // 
            // lblCauta
            // 
            this.lblCauta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCauta.AutoSize = true;
            this.lblCauta.Location = new System.Drawing.Point(330, 66);
            this.lblCauta.Name = "lblCauta";
            this.lblCauta.Size = new System.Drawing.Size(35, 13);
            this.lblCauta.TabIndex = 13;
            this.lblCauta.Text = "Cauta";
            this.lblCauta.ToolTipText = null;
            this.lblCauta.ToolTipTitle = null;
            // 
            // panelColoanaFiltrare
            // 
            this.panelColoanaFiltrare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelColoanaFiltrare.BackColor = System.Drawing.Color.White;
            this.panelColoanaFiltrare.Controls.Add(this.rbTot);
            this.panelColoanaFiltrare.Controls.Add(this.rbClinica);
            this.panelColoanaFiltrare.Controls.Add(this.rbMedic);
            this.panelColoanaFiltrare.Controls.Add(this.rbPacient);
            this.panelColoanaFiltrare.Controls.Add(this.rbTehnician);
            this.panelColoanaFiltrare.Location = new System.Drawing.Point(600, 61);
            this.panelColoanaFiltrare.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.panelColoanaFiltrare.Name = "panelColoanaFiltrare";
            this.panelColoanaFiltrare.Size = new System.Drawing.Size(344, 25);
            this.panelColoanaFiltrare.TabIndex = 14;
            // 
            // rbTot
            // 
            this.rbTot.AutoSize = true;
            this.rbTot.Checked = true;
            this.rbTot.Location = new System.Drawing.Point(3, 3);
            this.rbTot.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.rbTot.Name = "rbTot";
            this.rbTot.Size = new System.Drawing.Size(41, 17);
            this.rbTot.TabIndex = 0;
            this.rbTot.TabStop = true;
            this.rbTot.Text = "Tot";
            this.rbTot.UseVisualStyleBackColor = true;
            // 
            // rbClinica
            // 
            this.rbClinica.AutoSize = true;
            this.rbClinica.Location = new System.Drawing.Point(54, 3);
            this.rbClinica.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.rbClinica.Name = "rbClinica";
            this.rbClinica.Size = new System.Drawing.Size(56, 17);
            this.rbClinica.TabIndex = 1;
            this.rbClinica.Text = "Clinica";
            this.rbClinica.UseVisualStyleBackColor = true;
            // 
            // rbMedic
            // 
            this.rbMedic.AutoSize = true;
            this.rbMedic.Location = new System.Drawing.Point(120, 3);
            this.rbMedic.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.rbMedic.Name = "rbMedic";
            this.rbMedic.Size = new System.Drawing.Size(54, 17);
            this.rbMedic.TabIndex = 3;
            this.rbMedic.Text = "Medic";
            this.rbMedic.UseVisualStyleBackColor = true;
            // 
            // rbPacient
            // 
            this.rbPacient.AutoSize = true;
            this.rbPacient.Location = new System.Drawing.Point(184, 3);
            this.rbPacient.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.rbPacient.Name = "rbPacient";
            this.rbPacient.Size = new System.Drawing.Size(61, 17);
            this.rbPacient.TabIndex = 4;
            this.rbPacient.Text = "Pacient";
            this.rbPacient.UseVisualStyleBackColor = true;
            // 
            // rbTehnician
            // 
            this.rbTehnician.AutoSize = true;
            this.rbTehnician.Location = new System.Drawing.Point(255, 3);
            this.rbTehnician.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.rbTehnician.Name = "rbTehnician";
            this.rbTehnician.Size = new System.Drawing.Size(72, 17);
            this.rbTehnician.TabIndex = 2;
            this.rbTehnician.Text = "Tehnician";
            this.rbTehnician.UseVisualStyleBackColor = true;
            // 
            // ControlTablouDeBord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelColoanaFiltrare);
            this.Controls.Add(this.lblCauta);
            this.Controls.Add(this.btnArataAdaugareRapida);
            this.Controls.Add(this.panelZonaAdaugare);
            this.Controls.Add(this.panelOptiuni);
            this.Controls.Add(this.btnOptiuni);
            this.Controls.Add(this.btnActivDezactivat);
            this.Controls.Add(this.txtCautaComanda);
            this.Controls.Add(this.btnAdaugareComanda);
            this.Controls.Add(this.lblComenziInLucru);
            this.Controls.Add(this.dgvListaComenzi);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.ctrlPerioada);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ControlTablouDeBord";
            this.Size = new System.Drawing.Size(1006, 428);
            this.panelZonaAdaugare.ResumeLayout(false);
            this.panelZonaAdaugare.PerformLayout();
            this.panelOptiuni.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaComenzi)).EndInit();
            this.panelColoanaFiltrare.ResumeLayout(false);
            this.panelColoanaFiltrare.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            // btnDiscount
            // 
           /* this.btnDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDiscount.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnDiscount.Image = null;
            this.btnDiscount.Location = new System.Drawing.Point(343, 4);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Size = new System.Drawing.Size(30, 23);
            this.btnDiscount.TabIndex = 5;
            this.btnDiscount.Text = "%";
            this.btnDiscount.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnDiscount.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnDiscount.UseVisualStyleBackColor = true;*/

        }

        #endregion

        private CCL.UI.DataGridViewPersonalizat dgvListaComenzi;
        private CCL.UI.LabelPersonalizat lblComenziInLucru;
        private CCL.UI.ButtonPersonalizat btnAdaugareComanda;
        private Caramizi.ControlPerioada ctrlPerioada;
        private CCL.UI.Caramizi.TextBoxCautare txtCautaComanda;
        private CCL.UI.LabelPersonalizat lblTotal;
        private CCL.UI.ButtonPersonalizat btnActivDezactivat;
        private CCL.UI.ControaleSpecializate.ButonMaiMulte btnOptiuni;
        private CCL.UI.ControaleSpecializate.PanelOptiuni panelOptiuni;
        private CCL.UI.ControaleSpecializate.ButonInchidePanelOptiuni btnInchidePanelOptiuni;
        private CCL.UI.ControaleSpecializate.ButonOptiunePanelOptiuni btnSchimbaEtapa;
        private CCL.UI.PanelPersonalizat panelZonaAdaugare;
        private Caramizi.ControlCautareClinica ctrlADCautareClinica;
        private CCL.UI.LabelPersonalizat lblADClinica;
        private CCL.UI.LabelPersonalizat lblAdCabinet;
        private Caramizi.ControlCautareCabinetClinica ctrlADCautareCabinetClinica;
        private Caramizi.ControlCautareMedicClinica ctrlADCautareMedicClinica;
        private CCL.UI.LabelPersonalizat lblADMedic;
        private CCL.UI.LabelPersonalizat lblADEtapa;
        private CCL.UI.LabelPersonalizat lblADTehnician;
        private CCL.UI.LabelPersonalizat lblADLucrare;
        private CCL.UI.TextBoxPersonalizat txtADPacient;
        private CCL.UI.LabelPersonalizat lblADCuloare;
        private CCL.UI.LabelPersonalizat lblADPacient;
        private CCL.UI.ButtonPersonalizat btnGoleste;
        private CCL.UI.ButtonPersonalizat btnAdaugaLucrareRapida;
        private CCL.UI.Caramizi.ControlDataOraGuma ctrlADDataOraPrimire;
        private CCL.UI.TextBoxPersonalizat txtADCuloare;
        private Caramizi.ControlCautareLucrare ctrlADCautareLucrare;
        private Caramizi.ControlCautaTehnician ctrlADCautaTehnician;
        private Caramizi.ControlCautareEtapa ctrlADCautareEtapa;
        private CCL.UI.MaskedTextBoxPersonalizat txtADNrElemente;
        private CCL.UI.LabelPersonalizat lblADNrElemente;
        private Caramizi.ButonFiltreVerticala btnArataAdaugareRapida;
        private ControlDataInteresLucrari ctrlDataInteres;
        private CCL.UI.LabelPersonalizat lblCauta;
        private CCL.UI.FlowLayoutPanelPersonalizat panelColoanaFiltrare;
        private CCL.UI.RadioButtonPersonalizat rbTot;
        private CCL.UI.RadioButtonPersonalizat rbClinica;
        private CCL.UI.RadioButtonPersonalizat rbMedic;
        private CCL.UI.RadioButtonPersonalizat rbPacient;
        private CCL.UI.RadioButtonPersonalizat rbTehnician;
    }
}
