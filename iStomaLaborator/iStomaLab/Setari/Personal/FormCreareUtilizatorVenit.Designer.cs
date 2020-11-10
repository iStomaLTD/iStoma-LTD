namespace iStomaLab.Setari.Personal
{
    partial class FormCreareUtilizatorVenit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreareUtilizatorVenit));
            this.lblTipVenit = new CCL.UI.LabelPersonalizat(this.components);
            this.cboTipVenit = new CCL.UI.ComboBoxPersonalizat(this.components);
            this.dgvListaVenituriEtape = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.ctrlValidareAnulareVenit = new CCL.UI.Caramizi.controlValidareAnulare();
            this.btnAnulare = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnValidare = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblSalariu = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlAlegeDataInceput = new CCL.UI.controlAlegeData();
            this.lblDataInceput = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlAlegeDataFinal = new CCL.UI.controlAlegeData();
            this.lblDataSfarsit = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlSalariu = new CCL.UI.Caramizi.controlValoareMonetara();
            this.lblObservatii = new CCL.UI.LabelPersonalizat(this.components);
            this.txtObservatii = new CCL.UI.TextBoxPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaVenituriEtape)).BeginInit();
            this.ctrlValidareAnulareVenit.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(778, 19);
            this.lblTitluEcran.Text = "FormCreareUtilizatorVenit";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(777, 0);
            // 
            // lblTipVenit
            // 
            this.lblTipVenit.AutoSize = true;
            this.lblTipVenit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTipVenit.Location = new System.Drawing.Point(12, 36);
            this.lblTipVenit.Name = "lblTipVenit";
            this.lblTipVenit.Size = new System.Drawing.Size(48, 13);
            this.lblTipVenit.TabIndex = 9;
            this.lblTipVenit.Text = "Tip venit";
            this.lblTipVenit.ToolTipText = null;
            this.lblTipVenit.ToolTipTitle = null;
            // 
            // cboTipVenit
            // 
            this.cboTipVenit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipVenit.AutoCompletePersonalizat = false;
            this.cboTipVenit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipVenit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cboTipVenit.FormattingEnabled = true;
            this.cboTipVenit.HideSelection = true;
            this.cboTipVenit.IsInReadOnlyMode = false;
            this.cboTipVenit.Location = new System.Drawing.Point(79, 32);
            this.cboTipVenit.Name = "cboTipVenit";
            this.cboTipVenit.ProprietateCorespunzatoare = null;
            this.cboTipVenit.Size = new System.Drawing.Size(212, 21);
            this.cboTipVenit.TabIndex = 10;
            this.cboTipVenit.TipulListei = CCL.UI.ComboBoxPersonalizat.EnumTipLista.Nespecificat;
            // 
            // dgvListaVenituriEtape
            // 
            this.dgvListaVenituriEtape.AllowUserToAddRows = false;
            this.dgvListaVenituriEtape.AllowUserToDeleteRows = false;
            this.dgvListaVenituriEtape.AllowUserToResizeRows = false;
            this.dgvListaVenituriEtape.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaVenituriEtape.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaVenituriEtape.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaVenituriEtape.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaVenituriEtape.HideSelection = true;
            this.dgvListaVenituriEtape.IsInReadOnlyMode = false;
            this.dgvListaVenituriEtape.Location = new System.Drawing.Point(3, 127);
            this.dgvListaVenituriEtape.MultiSelect = false;
            this.dgvListaVenituriEtape.Name = "dgvListaVenituriEtape";
            this.dgvListaVenituriEtape.ProprietateCorespunzatoare = "";
            this.dgvListaVenituriEtape.RowHeadersVisible = false;
            this.dgvListaVenituriEtape.SeIncarca = false;
            this.dgvListaVenituriEtape.SelectedText = "";
            this.dgvListaVenituriEtape.SelectionLength = 0;
            this.dgvListaVenituriEtape.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaVenituriEtape.SelectionStart = 0;
            this.dgvListaVenituriEtape.Size = new System.Drawing.Size(794, 282);
            this.dgvListaVenituriEtape.TabIndex = 11;
            // 
            // ctrlValidareAnulareVenit
            // 
            this.ctrlValidareAnulareVenit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrlValidareAnulareVenit.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulareVenit.Controls.Add(this.btnAnulare);
            this.ctrlValidareAnulareVenit.Controls.Add(this.btnValidare);
            this.ctrlValidareAnulareVenit.Location = new System.Drawing.Point(320, 415);
            this.ctrlValidareAnulareVenit.Name = "ctrlValidareAnulareVenit";
            this.ctrlValidareAnulareVenit.Size = new System.Drawing.Size(163, 23);
            this.ctrlValidareAnulareVenit.TabIndex = 12;
            // 
            // btnAnulare
            // 
            this.btnAnulare.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAnulare.Image = ((System.Drawing.Image)(resources.GetObject("btnAnulare.Image")));
            this.btnAnulare.Location = new System.Drawing.Point(85, 0);
            this.btnAnulare.Name = "btnAnulare";
            this.btnAnulare.Size = new System.Drawing.Size(75, 23);
            this.btnAnulare.TabIndex = 1;
            this.btnAnulare.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Anulare;
            this.btnAnulare.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAnulare.UseVisualStyleBackColor = true;
            // 
            // btnValidare
            // 
            this.btnValidare.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnValidare.Image = ((System.Drawing.Image)(resources.GetObject("btnValidare.Image")));
            this.btnValidare.Location = new System.Drawing.Point(0, 0);
            this.btnValidare.Name = "btnValidare";
            this.btnValidare.Size = new System.Drawing.Size(75, 23);
            this.btnValidare.TabIndex = 0;
            this.btnValidare.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Validare;
            this.btnValidare.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnValidare.UseVisualStyleBackColor = true;
            // 
            // lblSalariu
            // 
            this.lblSalariu.AutoSize = true;
            this.lblSalariu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSalariu.Location = new System.Drawing.Point(12, 86);
            this.lblSalariu.Name = "lblSalariu";
            this.lblSalariu.Size = new System.Drawing.Size(63, 13);
            this.lblSalariu.TabIndex = 13;
            this.lblSalariu.Text = "Salariu (net)";
            this.lblSalariu.ToolTipText = null;
            this.lblSalariu.ToolTipTitle = null;
            // 
            // ctrlAlegeDataInceput
            // 
            this.ctrlAlegeDataInceput.AfiseazaButonGuma = false;
            this.ctrlAlegeDataInceput.AfiseazaCuOra = false;
            this.ctrlAlegeDataInceput.AfiseazaCuSecunde = false;
            this.ctrlAlegeDataInceput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlAlegeDataInceput.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ctrlAlegeDataInceput.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ctrlAlegeDataInceput.BackColor = System.Drawing.Color.White;
            this.ctrlAlegeDataInceput.DataAfisata = new System.DateTime(((long)(0)));
            this.ctrlAlegeDataInceput.IsInReadOnlyMode = false;
            this.ctrlAlegeDataInceput.Location = new System.Drawing.Point(377, 32);
            this.ctrlAlegeDataInceput.Name = "ctrlAlegeDataInceput";
            this.ctrlAlegeDataInceput.PragInferior = new System.DateTime(((long)(0)));
            this.ctrlAlegeDataInceput.PragSuperior = new System.DateTime(((long)(0)));
            this.ctrlAlegeDataInceput.ProprietateCorespunzatoare = null;
            this.ctrlAlegeDataInceput.Size = new System.Drawing.Size(114, 21);
            this.ctrlAlegeDataInceput.TabIndex = 21;
            this.ctrlAlegeDataInceput.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.ctrlAlegeDataInceput.TipDeschidereCalendar = CCL.UI.CEnumerariComune.EnumTipDeschidere.StangaSus;
            // 
            // lblDataInceput
            // 
            this.lblDataInceput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDataInceput.AutoSize = true;
            this.lblDataInceput.Location = new System.Drawing.Point(317, 36);
            this.lblDataInceput.Name = "lblDataInceput";
            this.lblDataInceput.Size = new System.Drawing.Size(32, 13);
            this.lblDataInceput.TabIndex = 20;
            this.lblDataInceput.Text = "De la";
            this.lblDataInceput.ToolTipText = null;
            this.lblDataInceput.ToolTipTitle = null;
            // 
            // ctrlAlegeDataFinal
            // 
            this.ctrlAlegeDataFinal.AfiseazaButonGuma = false;
            this.ctrlAlegeDataFinal.AfiseazaCuOra = false;
            this.ctrlAlegeDataFinal.AfiseazaCuSecunde = false;
            this.ctrlAlegeDataFinal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlAlegeDataFinal.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ctrlAlegeDataFinal.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ctrlAlegeDataFinal.BackColor = System.Drawing.Color.White;
            this.ctrlAlegeDataFinal.DataAfisata = new System.DateTime(((long)(0)));
            this.ctrlAlegeDataFinal.IsInReadOnlyMode = false;
            this.ctrlAlegeDataFinal.Location = new System.Drawing.Point(591, 32);
            this.ctrlAlegeDataFinal.Name = "ctrlAlegeDataFinal";
            this.ctrlAlegeDataFinal.PragInferior = new System.DateTime(((long)(0)));
            this.ctrlAlegeDataFinal.PragSuperior = new System.DateTime(((long)(0)));
            this.ctrlAlegeDataFinal.ProprietateCorespunzatoare = null;
            this.ctrlAlegeDataFinal.Size = new System.Drawing.Size(114, 21);
            this.ctrlAlegeDataFinal.TabIndex = 23;
            this.ctrlAlegeDataFinal.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.ctrlAlegeDataFinal.TipDeschidereCalendar = CCL.UI.CEnumerariComune.EnumTipDeschidere.StangaSus;
            // 
            // lblDataSfarsit
            // 
            this.lblDataSfarsit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDataSfarsit.AutoSize = true;
            this.lblDataSfarsit.Location = new System.Drawing.Point(519, 36);
            this.lblDataSfarsit.Name = "lblDataSfarsit";
            this.lblDataSfarsit.Size = new System.Drawing.Size(43, 13);
            this.lblDataSfarsit.TabIndex = 22;
            this.lblDataSfarsit.Text = "Pana la";
            this.lblDataSfarsit.ToolTipText = null;
            this.lblDataSfarsit.ToolTipTitle = null;
            // 
            // ctrlSalariu
            // 
            this.ctrlSalariu.IsInReadOnlyMode = false;
            this.ctrlSalariu.Location = new System.Drawing.Point(79, 79);
            this.ctrlSalariu.Name = "ctrlSalariu";
            this.ctrlSalariu.Size = new System.Drawing.Size(224, 24);
            this.ctrlSalariu.TabIndex = 24;
            this.ctrlSalariu.Valoare = 0D;
            // 
            // lblObservatii
            // 
            this.lblObservatii.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblObservatii.AutoSize = true;
            this.lblObservatii.Location = new System.Drawing.Point(317, 86);
            this.lblObservatii.Name = "lblObservatii";
            this.lblObservatii.Size = new System.Drawing.Size(54, 13);
            this.lblObservatii.TabIndex = 25;
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
            this.txtObservatii.Location = new System.Drawing.Point(377, 68);
            this.txtObservatii.Multiline = true;
            this.txtObservatii.Name = "txtObservatii";
            this.txtObservatii.ProprietateCorespunzatoare = null;
            this.txtObservatii.RaiseEventLaModificareProgramatica = false;
            this.txtObservatii.Size = new System.Drawing.Size(328, 55);
            this.txtObservatii.TabIndex = 26;
            this.txtObservatii.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtObservatii.TotulCuMajuscule = false;
            // 
            // FormCreareUtilizatorVenit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtObservatii);
            this.Controls.Add(this.lblObservatii);
            this.Controls.Add(this.ctrlSalariu);
            this.Controls.Add(this.ctrlAlegeDataFinal);
            this.Controls.Add(this.lblDataSfarsit);
            this.Controls.Add(this.ctrlAlegeDataInceput);
            this.Controls.Add(this.lblDataInceput);
            this.Controls.Add(this.lblSalariu);
            this.Controls.Add(this.ctrlValidareAnulareVenit);
            this.Controls.Add(this.dgvListaVenituriEtape);
            this.Controls.Add(this.cboTipVenit);
            this.Controls.Add(this.lblTipVenit);
            this.Name = "FormCreareUtilizatorVenit";
            this.Text = "FormCreareUtilizatorVenit";
            this.Controls.SetChildIndex(this.lblTipVenit, 0);
            this.Controls.SetChildIndex(this.cboTipVenit, 0);
            this.Controls.SetChildIndex(this.dgvListaVenituriEtape, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulareVenit, 0);
            this.Controls.SetChildIndex(this.lblSalariu, 0);
            this.Controls.SetChildIndex(this.lblDataInceput, 0);
            this.Controls.SetChildIndex(this.ctrlAlegeDataInceput, 0);
            this.Controls.SetChildIndex(this.lblDataSfarsit, 0);
            this.Controls.SetChildIndex(this.ctrlAlegeDataFinal, 0);
            this.Controls.SetChildIndex(this.ctrlSalariu, 0);
            this.Controls.SetChildIndex(this.lblObservatii, 0);
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.txtObservatii, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaVenituriEtape)).EndInit();
            this.ctrlValidareAnulareVenit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.LabelPersonalizat lblTipVenit;
        private CCL.UI.ComboBoxPersonalizat cboTipVenit;
        private CCL.UI.DataGridViewPersonalizat dgvListaVenituriEtape;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulareVenit;
        private CCL.UI.ButtonPersonalizat btnAnulare;
        private CCL.UI.ButtonPersonalizat btnValidare;
        private CCL.UI.LabelPersonalizat lblSalariu;
        private CCL.UI.controlAlegeData ctrlAlegeDataInceput;
        private CCL.UI.LabelPersonalizat lblDataInceput;
        private CCL.UI.controlAlegeData ctrlAlegeDataFinal;
        private CCL.UI.LabelPersonalizat lblDataSfarsit;
        private CCL.UI.Caramizi.controlValoareMonetara ctrlSalariu;
        private CCL.UI.LabelPersonalizat lblObservatii;
        private CCL.UI.TextBoxPersonalizat txtObservatii;
    }
}