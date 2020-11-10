namespace iStomaLab.Setari.Lucrari
{
    partial class FormAdaugareEtapa
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
            this.lblDenumireEtapa = new CCL.UI.LabelPersonalizat(this.components);
            this.txtDenumireEtapa = new CCL.UI.TextBoxPersonalizat(this.components);
            this.ctrlValidareAnulareEtapa = new CCL.UI.Caramizi.controlValidareAnulare();
            this.lblDurataEtapa = new CCL.UI.LabelPersonalizat(this.components);
            this.txtMinuteEtapa = new CCL.UI.MaskedTextBoxPersonalizat(this.components);
            this.lblMinuteEtapa = new CCL.UI.LabelPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(465, 19);
            this.lblTitluEcran.TabIndex = 6;
            this.lblTitluEcran.Text = "FormAdaugareEtapa";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(464, 0);
            this.btnInchidereEcran.TabIndex = 7;
            // 
            // lblDenumireEtapa
            // 
            this.lblDenumireEtapa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDenumireEtapa.AutoSize = true;
            this.lblDenumireEtapa.Location = new System.Drawing.Point(10, 35);
            this.lblDenumireEtapa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDenumireEtapa.Name = "lblDenumireEtapa";
            this.lblDenumireEtapa.Size = new System.Drawing.Size(52, 13);
            this.lblDenumireEtapa.TabIndex = 3;
            this.lblDenumireEtapa.Text = "Denumire";
            this.lblDenumireEtapa.ToolTipText = null;
            this.lblDenumireEtapa.ToolTipTitle = null;
            // 
            // txtDenumireEtapa
            // 
            this.txtDenumireEtapa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenumireEtapa.CapitalizeazaPrimaLitera = false;
            this.txtDenumireEtapa.IsInReadOnlyMode = false;
            this.txtDenumireEtapa.Location = new System.Drawing.Point(77, 35);
            this.txtDenumireEtapa.Margin = new System.Windows.Forms.Padding(2);
            this.txtDenumireEtapa.Name = "txtDenumireEtapa";
            this.txtDenumireEtapa.ProprietateCorespunzatoare = null;
            this.txtDenumireEtapa.RaiseEventLaModificareProgramatica = false;
            this.txtDenumireEtapa.Size = new System.Drawing.Size(402, 20);
            this.txtDenumireEtapa.TabIndex = 0;
            this.txtDenumireEtapa.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtDenumireEtapa.TotulCuMajuscule = false;
            // 
            // ctrlValidareAnulareEtapa
            // 
            this.ctrlValidareAnulareEtapa.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrlValidareAnulareEtapa.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulareEtapa.Location = new System.Drawing.Point(169, 95);
            this.ctrlValidareAnulareEtapa.Name = "ctrlValidareAnulareEtapa";
            this.ctrlValidareAnulareEtapa.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulareEtapa.TabIndex = 2;
            // 
            // lblDurataEtapa
            // 
            this.lblDurataEtapa.AutoSize = true;
            this.lblDurataEtapa.Location = new System.Drawing.Point(12, 66);
            this.lblDurataEtapa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDurataEtapa.Name = "lblDurataEtapa";
            this.lblDurataEtapa.Size = new System.Drawing.Size(39, 13);
            this.lblDurataEtapa.TabIndex = 4;
            this.lblDurataEtapa.Text = "Durata";
            this.lblDurataEtapa.ToolTipText = null;
            this.lblDurataEtapa.ToolTipTitle = null;
            // 
            // txtMinuteEtapa
            // 
            this.txtMinuteEtapa.BackColor = System.Drawing.SystemColors.Window;
            this.txtMinuteEtapa.Location = new System.Drawing.Point(77, 61);
            this.txtMinuteEtapa.Margin = new System.Windows.Forms.Padding(2);
            this.txtMinuteEtapa.Name = "txtMinuteEtapa";
            this.txtMinuteEtapa.ProprietateCorespunzatoare = null;
            this.txtMinuteEtapa.Size = new System.Drawing.Size(76, 20);
            this.txtMinuteEtapa.TabIndex = 1;
            this.txtMinuteEtapa.Text = "0";
            this.txtMinuteEtapa.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.txtMinuteEtapa.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMinuteEtapa.ValoareDouble = 0D;
            // 
            // lblMinuteEtapa
            // 
            this.lblMinuteEtapa.AutoSize = true;
            this.lblMinuteEtapa.Location = new System.Drawing.Point(157, 66);
            this.lblMinuteEtapa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMinuteEtapa.Name = "lblMinuteEtapa";
            this.lblMinuteEtapa.Size = new System.Drawing.Size(38, 13);
            this.lblMinuteEtapa.TabIndex = 5;
            this.lblMinuteEtapa.Text = "minute";
            this.lblMinuteEtapa.ToolTipText = null;
            this.lblMinuteEtapa.ToolTipTitle = null;
            // 
            // FormAdaugareEtapa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 129);
            this.Controls.Add(this.lblMinuteEtapa);
            this.Controls.Add(this.txtMinuteEtapa);
            this.Controls.Add(this.lblDurataEtapa);
            this.Controls.Add(this.ctrlValidareAnulareEtapa);
            this.Controls.Add(this.txtDenumireEtapa);
            this.Controls.Add(this.lblDenumireEtapa);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(487, 129);
            this.Name = "FormAdaugareEtapa";
            this.Text = "FormAdaugareEtapa";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.lblDenumireEtapa, 0);
            this.Controls.SetChildIndex(this.txtDenumireEtapa, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulareEtapa, 0);
            this.Controls.SetChildIndex(this.lblDurataEtapa, 0);
            this.Controls.SetChildIndex(this.txtMinuteEtapa, 0);
            this.Controls.SetChildIndex(this.lblMinuteEtapa, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.LabelPersonalizat lblDenumireEtapa;
        private CCL.UI.TextBoxPersonalizat txtDenumireEtapa;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulareEtapa;
        private CCL.UI.LabelPersonalizat lblDurataEtapa;
        private CCL.UI.MaskedTextBoxPersonalizat txtMinuteEtapa;
        private CCL.UI.LabelPersonalizat lblMinuteEtapa;
    }
}