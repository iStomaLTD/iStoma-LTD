namespace CCL.UI.FormulareComune
{
    partial class frmInputBox
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
            this.txtContinut = new CCL.UI.Caramizi.TextBoxGuma();
            this.panelValoareMonetara = new CCL.UI.PanelPersonalizat(this.components);
            this.VMctrlMoneda = new CCL.UI.Caramizi.controlLeiEuro();
            this.VMlblValoare = new CCL.UI.LabelPersonalizat(this.components);
            this.VMtxtValoare = new CCL.UI.Caramizi.MaskedTextBoxGuma();
            this.panelParola = new CCL.UI.PanelPersonalizat(this.components);
            this.PRLchkAfiseazaCaracterele = new CCL.UI.CheckBoxPersonalizat(this.components);
            this.PRLtxtParola = new CCL.UI.TextBoxPersonalizat(this.components);
            this.PRLlblParola = new CCL.UI.LabelPersonalizat(this.components);
            this.panelTextSimplu = new CCL.UI.PanelPersonalizat(this.components);
            this.lblDenumireTextSimplu = new CCL.UI.LabelPersonalizat(this.components);
            this.txtNumeric = new CCL.UI.Caramizi.MaskedTextBoxGuma();
            this.txtSimplu = new CCL.UI.Caramizi.TextBoxGuma();
            this.panelData = new CCL.UI.PanelPersonalizat(this.components);
            this.DATctrlData = new CCL.UI.Caramizi.ControlDataOraGuma();
            this.DATlblData = new CCL.UI.LabelPersonalizat(this.components);
            this.panelGlobal.SuspendLayout();
            this.panelValoareMonetara.SuspendLayout();
            this.panelParola.SuspendLayout();
            this.panelTextSimplu.SuspendLayout();
            this.panelData.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGlobal
            // 
            this.panelGlobal.BackColor = System.Drawing.SystemColors.Control;
            this.panelGlobal.Controls.Add(this.panelData);
            this.panelGlobal.Controls.Add(this.txtContinut);
            this.panelGlobal.Controls.Add(this.panelValoareMonetara);
            this.panelGlobal.Controls.Add(this.panelTextSimplu);
            this.panelGlobal.Controls.Add(this.panelParola);
            this.panelGlobal.Location = new System.Drawing.Point(1, 19);
            this.panelGlobal.Size = new System.Drawing.Size(575, 48);
            this.panelGlobal.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // btnValidare
            // 
            this.btnValidare.Location = new System.Drawing.Point(225, 69);
            this.btnValidare.Size = new System.Drawing.Size(127, 23);
            this.btnValidare.Click += new System.EventHandler(this.btnValidare_Click);
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(555, 19);
            this.lblTitluEcran.Text = "frmInputBox";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(554, 0);
            // 
            // txtContinut
            // 
            this.txtContinut.AcceptButton = null;
            this.txtContinut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContinut.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtContinut.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtContinut.BackColor = System.Drawing.SystemColors.Control;
            this.txtContinut.IsInReadOnlyMode = false;
            this.txtContinut.Location = new System.Drawing.Point(12, 5);
            this.txtContinut.MaxLength = 32767;
            this.txtContinut.Multiline = true;
            this.txtContinut.Name = "txtContinut";
            this.txtContinut.ProprietateCorespunzatoare = null;
            this.txtContinut.RaiseEventLaModificareProgramatica = false;
            this.txtContinut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContinut.Size = new System.Drawing.Size(552, 36);
            this.txtContinut.TabIndex = 0;
            this.txtContinut.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtContinut.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtContinut.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtContinut.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtContinut.UseSystemPasswordChar = false;
            this.txtContinut.Visible = false;
            // 
            // panelValoareMonetara
            // 
            this.panelValoareMonetara.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelValoareMonetara.BackColor = System.Drawing.SystemColors.Control;
            this.panelValoareMonetara.Controls.Add(this.VMctrlMoneda);
            this.panelValoareMonetara.Controls.Add(this.VMlblValoare);
            this.panelValoareMonetara.Controls.Add(this.VMtxtValoare);
            this.panelValoareMonetara.Location = new System.Drawing.Point(0, 0);
            this.panelValoareMonetara.Name = "panelValoareMonetara";
            this.panelValoareMonetara.Size = new System.Drawing.Size(575, 48);
            this.panelValoareMonetara.TabIndex = 1;
            this.panelValoareMonetara.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.panelValoareMonetara.Visible = false;
            // 
            // VMctrlMoneda
            // 
            this.VMctrlMoneda.IsInReadOnlyMode = false;
            this.VMctrlMoneda.Location = new System.Drawing.Point(332, 10);
            this.VMctrlMoneda.Moneda = CDL.iStomaLab.CDefinitiiComune.EnumTipMoneda.Lei;
            this.VMctrlMoneda.Name = "VMctrlMoneda";
            this.VMctrlMoneda.Size = new System.Drawing.Size(139, 24);
            this.VMctrlMoneda.TabIndex = 2;
            // 
            // VMlblValoare
            // 
            this.VMlblValoare.AutoSize = true;
            this.VMlblValoare.Location = new System.Drawing.Point(93, 16);
            this.VMlblValoare.Name = "VMlblValoare";
            this.VMlblValoare.Size = new System.Drawing.Size(43, 13);
            this.VMlblValoare.TabIndex = 1;
            this.VMlblValoare.Text = "Valoare";
            this.VMlblValoare.ToolTipText = null;
            this.VMlblValoare.ToolTipTitle = null;
            // 
            // VMtxtValoare
            // 
            this.VMtxtValoare.AcceptButton = null;
            this.VMtxtValoare.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.VMtxtValoare.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.VMtxtValoare.BackColor = System.Drawing.SystemColors.Control;
            this.VMtxtValoare.Location = new System.Drawing.Point(191, 12);
            this.VMtxtValoare.MaxLength = 32767;
            this.VMtxtValoare.Name = "VMtxtValoare";
            this.VMtxtValoare.ProprietateCorespunzatoare = null;
            this.VMtxtValoare.Size = new System.Drawing.Size(134, 21);
            this.VMtxtValoare.TabIndex = 0;
            this.VMtxtValoare.Text = "0";
            this.VMtxtValoare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.VMtxtValoare.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.VMtxtValoare.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.VMtxtValoare.ValoareDouble = 0D;
            // 
            // panelParola
            // 
            this.panelParola.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelParola.BackColor = System.Drawing.SystemColors.Control;
            this.panelParola.Controls.Add(this.PRLchkAfiseazaCaracterele);
            this.panelParola.Controls.Add(this.PRLtxtParola);
            this.panelParola.Controls.Add(this.PRLlblParola);
            this.panelParola.Location = new System.Drawing.Point(0, 0);
            this.panelParola.Name = "panelParola";
            this.panelParola.Size = new System.Drawing.Size(575, 48);
            this.panelParola.TabIndex = 4;
            this.panelParola.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.panelParola.Visible = false;
            // 
            // PRLchkAfiseazaCaracterele
            // 
            this.PRLchkAfiseazaCaracterele.AutoSize = true;
            this.PRLchkAfiseazaCaracterele.IsInReadOnlyMode = false;
            this.PRLchkAfiseazaCaracterele.Location = new System.Drawing.Point(420, 13);
            this.PRLchkAfiseazaCaracterele.Name = "PRLchkAfiseazaCaracterele";
            this.PRLchkAfiseazaCaracterele.ProprietateCorespunzatoare = null;
            this.PRLchkAfiseazaCaracterele.Size = new System.Drawing.Size(66, 17);
            this.PRLchkAfiseazaCaracterele.TabIndex = 2;
            this.PRLchkAfiseazaCaracterele.Text = "Afiseaza";
            this.PRLchkAfiseazaCaracterele.UseVisualStyleBackColor = true;
            this.PRLchkAfiseazaCaracterele.CheckedChanged += new System.EventHandler(this.PRLchkAfiseazaCaracterele_CheckedChanged);
            // 
            // PRLtxtParola
            // 
            this.PRLtxtParola.CapitalizeazaPrimaLitera = false;
            this.PRLtxtParola.IsInReadOnlyMode = false;
            this.PRLtxtParola.Location = new System.Drawing.Point(215, 11);
            this.PRLtxtParola.MaxLength = 50;
            this.PRLtxtParola.Name = "PRLtxtParola";
            this.PRLtxtParola.ProprietateCorespunzatoare = null;
            this.PRLtxtParola.RaiseEventLaModificareProgramatica = false;
            this.PRLtxtParola.Size = new System.Drawing.Size(198, 20);
            this.PRLtxtParola.TabIndex = 1;
            this.PRLtxtParola.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.PRLtxtParola.TotulCuMajuscule = false;
            this.PRLtxtParola.UseSystemPasswordChar = true;
            // 
            // PRLlblParola
            // 
            this.PRLlblParola.Location = new System.Drawing.Point(45, 11);
            this.PRLlblParola.Name = "PRLlblParola";
            this.PRLlblParola.Size = new System.Drawing.Size(164, 20);
            this.PRLlblParola.TabIndex = 0;
            this.PRLlblParola.Text = "Parola";
            this.PRLlblParola.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PRLlblParola.ToolTipText = null;
            this.PRLlblParola.ToolTipTitle = null;
            // 
            // panelTextSimplu
            // 
            this.panelTextSimplu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTextSimplu.BackColor = System.Drawing.SystemColors.Control;
            this.panelTextSimplu.Controls.Add(this.lblDenumireTextSimplu);
            this.panelTextSimplu.Controls.Add(this.txtNumeric);
            this.panelTextSimplu.Controls.Add(this.txtSimplu);
            this.panelTextSimplu.Location = new System.Drawing.Point(0, 0);
            this.panelTextSimplu.Name = "panelTextSimplu";
            this.panelTextSimplu.Size = new System.Drawing.Size(575, 48);
            this.panelTextSimplu.TabIndex = 5;
            this.panelTextSimplu.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.panelTextSimplu.Visible = false;
            // 
            // lblDenumireTextSimplu
            // 
            this.lblDenumireTextSimplu.AutoSize = true;
            this.lblDenumireTextSimplu.Location = new System.Drawing.Point(11, 13);
            this.lblDenumireTextSimplu.Name = "lblDenumireTextSimplu";
            this.lblDenumireTextSimplu.Size = new System.Drawing.Size(52, 13);
            this.lblDenumireTextSimplu.TabIndex = 0;
            this.lblDenumireTextSimplu.Text = "Denumire";
            this.lblDenumireTextSimplu.ToolTipText = null;
            this.lblDenumireTextSimplu.ToolTipTitle = null;
            // 
            // txtNumeric
            // 
            this.txtNumeric.AcceptButton = null;
            this.txtNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumeric.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtNumeric.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtNumeric.BackColor = System.Drawing.SystemColors.Control;
            this.txtNumeric.Location = new System.Drawing.Point(110, 9);
            this.txtNumeric.MaxLength = 32767;
            this.txtNumeric.Name = "txtNumeric";
            this.txtNumeric.ProprietateCorespunzatoare = null;
            this.txtNumeric.Size = new System.Drawing.Size(459, 28);
            this.txtNumeric.TabIndex = 2;
            this.txtNumeric.Text = "0";
            this.txtNumeric.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtNumeric.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.txtNumeric.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNumeric.ValoareDouble = 0D;
            // 
            // txtSimplu
            // 
            this.txtSimplu.AcceptButton = null;
            this.txtSimplu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSimplu.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtSimplu.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtSimplu.BackColor = System.Drawing.SystemColors.Control;
            this.txtSimplu.CapitalizeazaPrimaLitera = false;
            this.txtSimplu.IsInReadOnlyMode = false;
            this.txtSimplu.Location = new System.Drawing.Point(110, 9);
            this.txtSimplu.MaxLength = 50;
            this.txtSimplu.Multiline = false;
            this.txtSimplu.Name = "txtSimplu";
            this.txtSimplu.ProprietateCorespunzatoare = null;
            this.txtSimplu.RaiseEventLaModificareProgramatica = false;
            this.txtSimplu.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSimplu.Size = new System.Drawing.Size(459, 20);
            this.txtSimplu.TabIndex = 1;
            this.txtSimplu.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtSimplu.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtSimplu.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtSimplu.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtSimplu.UseSystemPasswordChar = false;
            this.txtSimplu.UtilizeazaButonGuma = false;
            // 
            // panelData
            // 
            this.panelData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelData.BackColor = System.Drawing.SystemColors.Control;
            this.panelData.Controls.Add(this.DATctrlData);
            this.panelData.Controls.Add(this.DATlblData);
            this.panelData.Location = new System.Drawing.Point(0, 0);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(575, 48);
            this.panelData.TabIndex = 4;
            this.panelData.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.panelData.Visible = false;
            // 
            // DATctrlData
            // 
            this.DATctrlData.AfiseazaButonGuma = false;
            this.DATctrlData.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.DATctrlData.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DATctrlData.BackColor = System.Drawing.SystemColors.Control;
            this.DATctrlData.DataAfisata = new System.DateTime(((long)(0)));
            this.DATctrlData.IsInReadOnlyMode = false;
            this.DATctrlData.Location = new System.Drawing.Point(244, 15);
            this.DATctrlData.Name = "DATctrlData";
            this.DATctrlData.PragInferior = new System.DateTime(((long)(0)));
            this.DATctrlData.PragSuperior = new System.DateTime(((long)(0)));
            this.DATctrlData.ProprietateCorespunzatoare = null;
            this.DATctrlData.Size = new System.Drawing.Size(191, 23);
            this.DATctrlData.TabIndex = 1;
            this.DATctrlData.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.DATctrlData.TipDeschidereCalendar = CCL.UI.CEnumerariComune.EnumTipDeschidere.DreaptaJos;
            // 
            // DATlblData
            // 
            this.DATlblData.AutoSize = true;
            this.DATlblData.Location = new System.Drawing.Point(164, 19);
            this.DATlblData.Name = "DATlblData";
            this.DATlblData.Size = new System.Drawing.Size(30, 13);
            this.DATlblData.TabIndex = 0;
            this.DATlblData.Text = "Data";
            this.DATlblData.ToolTipText = null;
            this.DATlblData.ToolTipTitle = null;
            // 
            // frmInputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 95);
            this.Name = "frmInputBox";
            this.Text = "frmInputBox";
            this.Load += new System.EventHandler(this.frmInputBox_Load);
            this.Shown += new System.EventHandler(this.frmInputBox_Shown);
            this.panelGlobal.ResumeLayout(false);
            this.panelValoareMonetara.ResumeLayout(false);
            this.panelValoareMonetara.PerformLayout();
            this.panelParola.ResumeLayout(false);
            this.panelParola.PerformLayout();
            this.panelTextSimplu.ResumeLayout(false);
            this.panelTextSimplu.PerformLayout();
            this.panelData.ResumeLayout(false);
            this.panelData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Caramizi.TextBoxGuma txtContinut;
        private PanelPersonalizat panelValoareMonetara;
        private LabelPersonalizat VMlblValoare;
        private Caramizi.MaskedTextBoxGuma VMtxtValoare;
        private PanelPersonalizat panelParola;
        private TextBoxPersonalizat PRLtxtParola;
        private LabelPersonalizat PRLlblParola;
        private CheckBoxPersonalizat PRLchkAfiseazaCaracterele;
        private PanelPersonalizat panelTextSimplu;
        private Caramizi.TextBoxGuma txtSimplu;
        private LabelPersonalizat lblDenumireTextSimplu;
        private Caramizi.MaskedTextBoxGuma txtNumeric;
        private Caramizi.controlLeiEuro VMctrlMoneda;
        private PanelPersonalizat panelData;
        private Caramizi.ControlDataOraGuma DATctrlData;
        private LabelPersonalizat DATlblData;
    }
}