namespace iStomaLab.TablouDeBord
{
    partial class ControlFactura
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
            this.lblPacient = new CCL.UI.LabelPersonalizat(this.components);
            this.txtPacient = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblMedic = new CCL.UI.LabelPersonalizat(this.components);
            this.txtCautaMedic = new CCL.UI.Caramizi.TextBoxGumaFind();
            this.lblTip = new CCL.UI.LabelPersonalizat(this.components);
            this.cboTip = new CCL.UI.ComboBoxPersonalizat(this.components);
            this.lblData = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlDataOra = new CCL.UI.Caramizi.ControlDataOraGuma();
            this.lblMoneda = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlLeiEuro = new CCL.UI.Caramizi.controlLeiEuro();
            this.lblTotal = new CCL.UI.LabelPersonalizat(this.components);
            this.txtDenumireFiscala = new CCL.UI.TextBoxPersonalizat(this.components);
            this.txtNrInregistrare = new CCL.UI.TextBoxPersonalizat(this.components);
            this.txtIban = new CCL.UI.TextBoxPersonalizat(this.components);
            this.ctrlCautareBanca = new iStomaLab.Generale.ControlCautareBanca();
            this.ctrllAdresaClinica = new iStomaLab.Generale.ControlAdresaLiniara();
            this.lblTehnician = new CCL.UI.LabelPersonalizat(this.components);
            this.textBoxGumaFind1 = new CCL.UI.Caramizi.TextBoxGumaFind();
            this.dgvListaLucrari = new CCL.UI.DataGridViewPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaLucrari)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPacient
            // 
            this.lblPacient.AutoSize = true;
            this.lblPacient.Location = new System.Drawing.Point(11, 15);
            this.lblPacient.Name = "lblPacient";
            this.lblPacient.Size = new System.Drawing.Size(43, 13);
            this.lblPacient.TabIndex = 0;
            this.lblPacient.Text = "Pacient";
            this.lblPacient.ToolTipText = null;
            this.lblPacient.ToolTipTitle = null;
            // 
            // txtPacient
            // 
            this.txtPacient.CapitalizeazaPrimaLitera = false;
            this.txtPacient.IsInReadOnlyMode = false;
            this.txtPacient.Location = new System.Drawing.Point(65, 11);
            this.txtPacient.Name = "txtPacient";
            this.txtPacient.ProprietateCorespunzatoare = null;
            this.txtPacient.RaiseEventLaModificareProgramatica = false;
            this.txtPacient.ReadOnly = true;
            this.txtPacient.Size = new System.Drawing.Size(246, 20);
            this.txtPacient.TabIndex = 1;
            this.txtPacient.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtPacient.TotulCuMajuscule = false;
            // 
            // lblMedic
            // 
            this.lblMedic.AutoSize = true;
            this.lblMedic.Location = new System.Drawing.Point(11, 44);
            this.lblMedic.Name = "lblMedic";
            this.lblMedic.Size = new System.Drawing.Size(36, 13);
            this.lblMedic.TabIndex = 2;
            this.lblMedic.Text = "Medic";
            this.lblMedic.ToolTipText = null;
            this.lblMedic.ToolTipTitle = null;
            // 
            // txtCautaMedic
            // 
            this.txtCautaMedic.AcceptButton = null;
            this.txtCautaMedic.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautaMedic.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautaMedic.BackColor = System.Drawing.Color.White;
            this.txtCautaMedic.IsInReadOnlyMode = false;
            this.txtCautaMedic.Location = new System.Drawing.Point(65, 40);
            this.txtCautaMedic.MaxLength = 32767;
            this.txtCautaMedic.Multiline = false;
            this.txtCautaMedic.Name = "txtCautaMedic";
            this.txtCautaMedic.ProprietateCorespunzatoare = null;
            this.txtCautaMedic.RaiseEventLaModificareProgramatica = false;
            this.txtCautaMedic.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautaMedic.Size = new System.Drawing.Size(246, 20);
            this.txtCautaMedic.TabIndex = 3;
            this.txtCautaMedic.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautaMedic.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautaMedic.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautaMedic.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautaMedic.UseSystemPasswordChar = false;
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(11, 99);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(22, 13);
            this.lblTip.TabIndex = 4;
            this.lblTip.Text = "Tip";
            this.lblTip.ToolTipText = null;
            this.lblTip.ToolTipTitle = null;
            // 
            // cboTip
            // 
            this.cboTip.AutoCompletePersonalizat = false;
            this.cboTip.FormattingEnabled = true;
            this.cboTip.HideSelection = true;
            this.cboTip.IsInReadOnlyMode = false;
            this.cboTip.Location = new System.Drawing.Point(65, 95);
            this.cboTip.Name = "cboTip";
            this.cboTip.ProprietateCorespunzatoare = null;
            this.cboTip.Size = new System.Drawing.Size(246, 21);
            this.cboTip.TabIndex = 5;
            this.cboTip.TipulListei = CCL.UI.ComboBoxPersonalizat.EnumTipLista.Nespecificat;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(11, 132);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(30, 13);
            this.lblData.TabIndex = 6;
            this.lblData.Text = "Data";
            this.lblData.ToolTipText = null;
            this.lblData.ToolTipTitle = null;
            // 
            // ctrlDataOra
            // 
            this.ctrlDataOra.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ctrlDataOra.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ctrlDataOra.BackColor = System.Drawing.Color.White;
            this.ctrlDataOra.DataAfisata = new System.DateTime(((long)(0)));
            this.ctrlDataOra.IsInReadOnlyMode = false;
            this.ctrlDataOra.Location = new System.Drawing.Point(65, 127);
            this.ctrlDataOra.Name = "ctrlDataOra";
            this.ctrlDataOra.PragInferior = new System.DateTime(((long)(0)));
            this.ctrlDataOra.PragSuperior = new System.DateTime(((long)(0)));
            this.ctrlDataOra.ProprietateCorespunzatoare = null;
            this.ctrlDataOra.Size = new System.Drawing.Size(172, 23);
            this.ctrlDataOra.TabIndex = 7;
            this.ctrlDataOra.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.ctrlDataOra.TipDeschidereCalendar = CCL.UI.CEnumerariComune.EnumTipDeschidere.StangaSus;
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(11, 166);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(46, 13);
            this.lblMoneda.TabIndex = 8;
            this.lblMoneda.Text = "Moneda";
            this.lblMoneda.ToolTipText = null;
            this.lblMoneda.ToolTipTitle = null;
            // 
            // ctrlLeiEuro
            // 
            this.ctrlLeiEuro.IsInReadOnlyMode = false;
            this.ctrlLeiEuro.Location = new System.Drawing.Point(65, 160);
            this.ctrlLeiEuro.Moneda = CDL.iStomaLab.CDefinitiiComune.EnumTipMoneda.Lei;
            this.ctrlLeiEuro.Name = "ctrlLeiEuro";
            this.ctrlLeiEuro.Size = new System.Drawing.Size(139, 24);
            this.ctrlLeiEuro.TabIndex = 9;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTotal.Location = new System.Drawing.Point(11, 418);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(44, 20);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "Total";
            this.lblTotal.ToolTipText = null;
            this.lblTotal.ToolTipTitle = null;
            // 
            // txtDenumireFiscala
            // 
            this.txtDenumireFiscala.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenumireFiscala.CapitalizeazaPrimaLitera = false;
            this.txtDenumireFiscala.IsInReadOnlyMode = false;
            this.txtDenumireFiscala.Location = new System.Drawing.Point(423, 11);
            this.txtDenumireFiscala.Name = "txtDenumireFiscala";
            this.txtDenumireFiscala.ProprietateCorespunzatoare = null;
            this.txtDenumireFiscala.RaiseEventLaModificareProgramatica = false;
            this.txtDenumireFiscala.Size = new System.Drawing.Size(264, 20);
            this.txtDenumireFiscala.TabIndex = 11;
            this.txtDenumireFiscala.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtDenumireFiscala.TotulCuMajuscule = false;
            // 
            // txtNrInregistrare
            // 
            this.txtNrInregistrare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNrInregistrare.CapitalizeazaPrimaLitera = false;
            this.txtNrInregistrare.IsInReadOnlyMode = false;
            this.txtNrInregistrare.Location = new System.Drawing.Point(423, 40);
            this.txtNrInregistrare.Name = "txtNrInregistrare";
            this.txtNrInregistrare.ProprietateCorespunzatoare = null;
            this.txtNrInregistrare.RaiseEventLaModificareProgramatica = false;
            this.txtNrInregistrare.Size = new System.Drawing.Size(264, 20);
            this.txtNrInregistrare.TabIndex = 12;
            this.txtNrInregistrare.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtNrInregistrare.TotulCuMajuscule = false;
            // 
            // txtIban
            // 
            this.txtIban.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIban.CapitalizeazaPrimaLitera = false;
            this.txtIban.IsInReadOnlyMode = false;
            this.txtIban.Location = new System.Drawing.Point(423, 69);
            this.txtIban.Name = "txtIban";
            this.txtIban.ProprietateCorespunzatoare = null;
            this.txtIban.RaiseEventLaModificareProgramatica = false;
            this.txtIban.Size = new System.Drawing.Size(264, 20);
            this.txtIban.TabIndex = 13;
            this.txtIban.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtIban.TotulCuMajuscule = false;
            // 
            // ctrlCautareBanca
            // 
            this.ctrlCautareBanca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlCautareBanca.Location = new System.Drawing.Point(422, 93);
            this.ctrlCautareBanca.Name = "ctrlCautareBanca";
            this.ctrlCautareBanca.Size = new System.Drawing.Size(265, 24);
            this.ctrlCautareBanca.TabIndex = 14;
            // 
            // ctrllAdresaClinica
            // 
            this.ctrllAdresaClinica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrllAdresaClinica.Location = new System.Drawing.Point(423, 128);
            this.ctrllAdresaClinica.Name = "ctrllAdresaClinica";
            this.ctrllAdresaClinica.Size = new System.Drawing.Size(264, 20);
            this.ctrllAdresaClinica.TabIndex = 15;
            // 
            // lblTehnician
            // 
            this.lblTehnician.AutoSize = true;
            this.lblTehnician.Location = new System.Drawing.Point(11, 73);
            this.lblTehnician.Name = "lblTehnician";
            this.lblTehnician.Size = new System.Drawing.Size(54, 13);
            this.lblTehnician.TabIndex = 16;
            this.lblTehnician.Text = "Tehnician";
            this.lblTehnician.ToolTipText = null;
            this.lblTehnician.ToolTipTitle = null;
            // 
            // textBoxGumaFind1
            // 
            this.textBoxGumaFind1.AcceptButton = null;
            this.textBoxGumaFind1.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.textBoxGumaFind1.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.textBoxGumaFind1.IsInReadOnlyMode = false;
            this.textBoxGumaFind1.Location = new System.Drawing.Point(65, 69);
            this.textBoxGumaFind1.MaxLength = 32767;
            this.textBoxGumaFind1.Multiline = false;
            this.textBoxGumaFind1.Name = "textBoxGumaFind1";
            this.textBoxGumaFind1.ProprietateCorespunzatoare = null;
            this.textBoxGumaFind1.RaiseEventLaModificareProgramatica = false;
            this.textBoxGumaFind1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxGumaFind1.Size = new System.Drawing.Size(246, 20);
            this.textBoxGumaFind1.TabIndex = 17;
            this.textBoxGumaFind1.TextBackColor = System.Drawing.SystemColors.Window;
            this.textBoxGumaFind1.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textBoxGumaFind1.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.textBoxGumaFind1.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.textBoxGumaFind1.UseSystemPasswordChar = false;
            // 
            // dgvListaLucrari
            // 
            this.dgvListaLucrari.AllowUserToAddRows = false;
            this.dgvListaLucrari.AllowUserToDeleteRows = false;
            this.dgvListaLucrari.AllowUserToResizeRows = false;
            this.dgvListaLucrari.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaLucrari.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaLucrari.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaLucrari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaLucrari.HideSelection = true;
            this.dgvListaLucrari.IsInReadOnlyMode = false;
            this.dgvListaLucrari.Location = new System.Drawing.Point(11, 209);
            this.dgvListaLucrari.MultiSelect = false;
            this.dgvListaLucrari.Name = "dgvListaLucrari";
            this.dgvListaLucrari.ProprietateCorespunzatoare = "";
            this.dgvListaLucrari.RowHeadersVisible = false;
            this.dgvListaLucrari.SeIncarca = false;
            this.dgvListaLucrari.SelectedText = "";
            this.dgvListaLucrari.SelectionLength = 0;
            this.dgvListaLucrari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaLucrari.SelectionStart = 0;
            this.dgvListaLucrari.Size = new System.Drawing.Size(676, 150);
            this.dgvListaLucrari.TabIndex = 18;
            // 
            // ControlFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvListaLucrari);
            this.Controls.Add(this.textBoxGumaFind1);
            this.Controls.Add(this.lblTehnician);
            this.Controls.Add(this.ctrllAdresaClinica);
            this.Controls.Add(this.ctrlCautareBanca);
            this.Controls.Add(this.txtIban);
            this.Controls.Add(this.txtNrInregistrare);
            this.Controls.Add(this.txtDenumireFiscala);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.ctrlLeiEuro);
            this.Controls.Add(this.lblMoneda);
            this.Controls.Add(this.ctrlDataOra);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.cboTip);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.txtCautaMedic);
            this.Controls.Add(this.lblMedic);
            this.Controls.Add(this.txtPacient);
            this.Controls.Add(this.lblPacient);
            this.MaximumSize = new System.Drawing.Size(695, 449);
            this.MinimumSize = new System.Drawing.Size(695, 449);
            this.Name = "ControlFactura";
            this.Size = new System.Drawing.Size(695, 449);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaLucrari)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.LabelPersonalizat lblPacient;
        private CCL.UI.TextBoxPersonalizat txtPacient;
        private CCL.UI.LabelPersonalizat lblMedic;
        private CCL.UI.Caramizi.TextBoxGumaFind txtCautaMedic;
        private CCL.UI.LabelPersonalizat lblTip;
        private CCL.UI.ComboBoxPersonalizat cboTip;
        private CCL.UI.LabelPersonalizat lblData;
        private CCL.UI.Caramizi.ControlDataOraGuma ctrlDataOra;
        private CCL.UI.LabelPersonalizat lblMoneda;
        private CCL.UI.Caramizi.controlLeiEuro ctrlLeiEuro;
        private CCL.UI.LabelPersonalizat lblTotal;
        private CCL.UI.TextBoxPersonalizat txtDenumireFiscala;
        private CCL.UI.TextBoxPersonalizat txtNrInregistrare;
        private CCL.UI.TextBoxPersonalizat txtIban;
        private Generale.ControlCautareBanca ctrlCautareBanca;
        private Generale.ControlAdresaLiniara ctrllAdresaClinica;
        private CCL.UI.LabelPersonalizat lblTehnician;
        private CCL.UI.Caramizi.TextBoxGumaFind textBoxGumaFind1;
        private CCL.UI.DataGridViewPersonalizat dgvListaLucrari;
    }
}
