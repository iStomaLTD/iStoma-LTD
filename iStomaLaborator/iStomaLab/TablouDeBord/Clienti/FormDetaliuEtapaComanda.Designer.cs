namespace iStomaLab.TablouDeBord.Clienti
{
    partial class FormDetaliuEtapaComanda
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
            this.lblTehnician = new CCL.UI.LabelPersonalizat(this.components);
            this.lblGumaFindTehnician = new CCL.UI.Caramizi.LabelGumaFind();
            this.lblDataInceput = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlDataOraInceput = new CCL.UI.Caramizi.ControlDataOraGuma();
            this.lblDataFinal = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlDataOraFinal = new CCL.UI.Caramizi.ControlDataOraGuma();
            this.lblObservatii = new CCL.UI.LabelPersonalizat(this.components);
            this.txtObservatii = new CCL.UI.TextBoxPersonalizat(this.components);
            this.ctrlValidareAnulare = new CCL.UI.Caramizi.controlValidareAnulare();
            this.lblStatus = new CCL.UI.LabelPersonalizat(this.components);
            this.cboStatus = new CCL.UI.ComboBoxPersonalizat(this.components);
            this.chkRefacere = new CCL.UI.CheckBoxPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(374, 19);
            this.lblTitluEcran.TabIndex = 12;
            this.lblTitluEcran.Text = "FormDetaliuEtapaComanda";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(373, 0);
            this.btnInchidereEcran.TabIndex = 13;
            // 
            // lblTehnician
            // 
            this.lblTehnician.AutoSize = true;
            this.lblTehnician.Location = new System.Drawing.Point(25, 38);
            this.lblTehnician.Name = "lblTehnician";
            this.lblTehnician.Size = new System.Drawing.Size(54, 13);
            this.lblTehnician.TabIndex = 6;
            this.lblTehnician.Text = "Tehnician";
            this.lblTehnician.ToolTipText = null;
            this.lblTehnician.ToolTipTitle = null;
            // 
            // lblGumaFindTehnician
            // 
            this.lblGumaFindTehnician.AfiseazaButonCautare = true;
            this.lblGumaFindTehnician.AfiseazaButonDetalii = false;
            this.lblGumaFindTehnician.AfiseazaButonGuma = true;
            this.lblGumaFindTehnician.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGumaFindTehnician.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.lblGumaFindTehnician.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.lblGumaFindTehnician.BackColor = System.Drawing.Color.White;
            this.lblGumaFindTehnician.FolosesteToString = false;
            this.lblGumaFindTehnician.IsInReadOnlyMode = false;
            this.lblGumaFindTehnician.Location = new System.Drawing.Point(93, 34);
            this.lblGumaFindTehnician.Name = "lblGumaFindTehnician";
            this.lblGumaFindTehnician.ObiectAfisajCorespunzator = null;
            this.lblGumaFindTehnician.ObiectCorespunzator = null;
            this.lblGumaFindTehnician.ProprietateCorespunzatoare = null;
            this.lblGumaFindTehnician.Size = new System.Drawing.Size(284, 20);
            this.lblGumaFindTehnician.TabIndex = 0;
            this.lblGumaFindTehnician.Text = "labelGumaFind1";
            this.lblGumaFindTehnician.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGumaFindTehnician.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.lblGumaFindTehnician.ToolTipText = null;
            this.lblGumaFindTehnician.ToolTipTitle = null;
            // 
            // lblDataInceput
            // 
            this.lblDataInceput.AutoSize = true;
            this.lblDataInceput.Location = new System.Drawing.Point(25, 74);
            this.lblDataInceput.Name = "lblDataInceput";
            this.lblDataInceput.Size = new System.Drawing.Size(68, 13);
            this.lblDataInceput.TabIndex = 7;
            this.lblDataInceput.Text = "Data inceput";
            this.lblDataInceput.ToolTipText = null;
            this.lblDataInceput.ToolTipTitle = null;
            // 
            // ctrlDataOraInceput
            // 
            this.ctrlDataOraInceput.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ctrlDataOraInceput.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ctrlDataOraInceput.BackColor = System.Drawing.Color.White;
            this.ctrlDataOraInceput.DataAfisata = new System.DateTime(((long)(0)));
            this.ctrlDataOraInceput.IsInReadOnlyMode = false;
            this.ctrlDataOraInceput.Location = new System.Drawing.Point(93, 69);
            this.ctrlDataOraInceput.Name = "ctrlDataOraInceput";
            this.ctrlDataOraInceput.PragInferior = new System.DateTime(((long)(0)));
            this.ctrlDataOraInceput.PragSuperior = new System.DateTime(((long)(0)));
            this.ctrlDataOraInceput.ProprietateCorespunzatoare = null;
            this.ctrlDataOraInceput.Size = new System.Drawing.Size(181, 23);
            this.ctrlDataOraInceput.TabIndex = 1;
            this.ctrlDataOraInceput.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.ctrlDataOraInceput.TipDeschidereCalendar = CCL.UI.CEnumerariComune.EnumTipDeschidere.StangaSus;
            // 
            // lblDataFinal
            // 
            this.lblDataFinal.AutoSize = true;
            this.lblDataFinal.Location = new System.Drawing.Point(25, 112);
            this.lblDataFinal.Name = "lblDataFinal";
            this.lblDataFinal.Size = new System.Drawing.Size(52, 13);
            this.lblDataFinal.TabIndex = 8;
            this.lblDataFinal.Text = "Data final";
            this.lblDataFinal.ToolTipText = null;
            this.lblDataFinal.ToolTipTitle = null;
            // 
            // ctrlDataOraFinal
            // 
            this.ctrlDataOraFinal.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ctrlDataOraFinal.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ctrlDataOraFinal.BackColor = System.Drawing.Color.White;
            this.ctrlDataOraFinal.DataAfisata = new System.DateTime(((long)(0)));
            this.ctrlDataOraFinal.IsInReadOnlyMode = false;
            this.ctrlDataOraFinal.Location = new System.Drawing.Point(93, 107);
            this.ctrlDataOraFinal.Name = "ctrlDataOraFinal";
            this.ctrlDataOraFinal.PragInferior = new System.DateTime(((long)(0)));
            this.ctrlDataOraFinal.PragSuperior = new System.DateTime(((long)(0)));
            this.ctrlDataOraFinal.ProprietateCorespunzatoare = null;
            this.ctrlDataOraFinal.Size = new System.Drawing.Size(181, 23);
            this.ctrlDataOraFinal.TabIndex = 2;
            this.ctrlDataOraFinal.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.ctrlDataOraFinal.TipDeschidereCalendar = CCL.UI.CEnumerariComune.EnumTipDeschidere.StangaSus;
            // 
            // lblObservatii
            // 
            this.lblObservatii.AutoSize = true;
            this.lblObservatii.Location = new System.Drawing.Point(25, 173);
            this.lblObservatii.Name = "lblObservatii";
            this.lblObservatii.Size = new System.Drawing.Size(54, 13);
            this.lblObservatii.TabIndex = 10;
            this.lblObservatii.Text = "Observatii";
            this.lblObservatii.ToolTipText = null;
            this.lblObservatii.ToolTipTitle = null;
            // 
            // txtObservatii
            // 
            this.txtObservatii.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservatii.CapitalizeazaPrimaLitera = false;
            this.txtObservatii.IsInReadOnlyMode = false;
            this.txtObservatii.Location = new System.Drawing.Point(22, 196);
            this.txtObservatii.Multiline = true;
            this.txtObservatii.Name = "txtObservatii";
            this.txtObservatii.ProprietateCorespunzatoare = null;
            this.txtObservatii.RaiseEventLaModificareProgramatica = false;
            this.txtObservatii.Size = new System.Drawing.Size(355, 77);
            this.txtObservatii.TabIndex = 5;
            this.txtObservatii.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtObservatii.TotulCuMajuscule = false;
            // 
            // ctrlValidareAnulare
            // 
            this.ctrlValidareAnulare.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrlValidareAnulare.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulare.Location = new System.Drawing.Point(119, 283);
            this.ctrlValidareAnulare.Name = "ctrlValidareAnulare";
            this.ctrlValidareAnulare.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulare.TabIndex = 11;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(25, 144);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Status";
            this.lblStatus.ToolTipText = null;
            this.lblStatus.ToolTipTitle = null;
            // 
            // cboStatus
            // 
            this.cboStatus.AutoCompletePersonalizat = false;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.HideSelection = true;
            this.cboStatus.IsInReadOnlyMode = false;
            this.cboStatus.Location = new System.Drawing.Point(93, 140);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.ProprietateCorespunzatoare = null;
            this.cboStatus.Size = new System.Drawing.Size(181, 21);
            this.cboStatus.TabIndex = 3;
            this.cboStatus.TipulListei = CCL.UI.ComboBoxPersonalizat.EnumTipLista.Nespecificat;
            // 
            // chkRefacere
            // 
            this.chkRefacere.AutoSize = true;
            this.chkRefacere.IsInReadOnlyMode = false;
            this.chkRefacere.Location = new System.Drawing.Point(304, 142);
            this.chkRefacere.Name = "chkRefacere";
            this.chkRefacere.ProprietateCorespunzatoare = null;
            this.chkRefacere.Size = new System.Drawing.Size(70, 17);
            this.chkRefacere.TabIndex = 4;
            this.chkRefacere.Text = "Refacere";
            this.chkRefacere.UseVisualStyleBackColor = true;
            // 
            // FormDetaliuEtapaComanda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 315);
            this.Controls.Add(this.chkRefacere);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.ctrlValidareAnulare);
            this.Controls.Add(this.txtObservatii);
            this.Controls.Add(this.lblObservatii);
            this.Controls.Add(this.ctrlDataOraFinal);
            this.Controls.Add(this.lblDataFinal);
            this.Controls.Add(this.ctrlDataOraInceput);
            this.Controls.Add(this.lblDataInceput);
            this.Controls.Add(this.lblGumaFindTehnician);
            this.Controls.Add(this.lblTehnician);
            this.Name = "FormDetaliuEtapaComanda";
            this.Text = "FormDetaliuEtapaComanda";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.lblTehnician, 0);
            this.Controls.SetChildIndex(this.lblGumaFindTehnician, 0);
            this.Controls.SetChildIndex(this.lblDataInceput, 0);
            this.Controls.SetChildIndex(this.ctrlDataOraInceput, 0);
            this.Controls.SetChildIndex(this.lblDataFinal, 0);
            this.Controls.SetChildIndex(this.ctrlDataOraFinal, 0);
            this.Controls.SetChildIndex(this.lblObservatii, 0);
            this.Controls.SetChildIndex(this.txtObservatii, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulare, 0);
            this.Controls.SetChildIndex(this.lblStatus, 0);
            this.Controls.SetChildIndex(this.cboStatus, 0);
            this.Controls.SetChildIndex(this.chkRefacere, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.LabelPersonalizat lblTehnician;
        private CCL.UI.Caramizi.LabelGumaFind lblGumaFindTehnician;
        private CCL.UI.LabelPersonalizat lblDataInceput;
        private CCL.UI.Caramizi.ControlDataOraGuma ctrlDataOraInceput;
        private CCL.UI.LabelPersonalizat lblDataFinal;
        private CCL.UI.Caramizi.ControlDataOraGuma ctrlDataOraFinal;
        private CCL.UI.LabelPersonalizat lblObservatii;
        private CCL.UI.TextBoxPersonalizat txtObservatii;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulare;
        private CCL.UI.LabelPersonalizat lblStatus;
        private CCL.UI.ComboBoxPersonalizat cboStatus;
        private CCL.UI.CheckBoxPersonalizat chkRefacere;
    }
}