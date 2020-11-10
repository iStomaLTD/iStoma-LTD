namespace iStomaLab.Generale
{
    partial class FormSetariEmail
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
            this.lblAdresaEmail = new CCL.UI.LabelPersonalizat(this.components);
            this.txtAdresaMail = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblServerSMTP = new CCL.UI.LabelPersonalizat(this.components);
            this.txtServerSMTP = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblPortSMTP = new CCL.UI.LabelPersonalizat(this.components);
            this.txtPortSMTP = new CCL.UI.MaskedTextBoxPersonalizat(this.components);
            this.lblServerIMAP = new CCL.UI.LabelPersonalizat(this.components);
            this.txtServerIMAP = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblPortIMAP = new CCL.UI.LabelPersonalizat(this.components);
            this.txtPortIMAP = new CCL.UI.MaskedTextBoxPersonalizat(this.components);
            this.chkSSL = new CCL.UI.CheckBoxPersonalizat(this.components);
            this.ctrlValidareAnulareSetariEmail = new CCL.UI.Caramizi.controlValidareAnulare();
            this.lblUtilizator = new CCL.UI.LabelPersonalizat(this.components);
            this.txtUtilizator = new CCL.UI.TextBoxPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(332, 19);
            this.lblTitluEcran.Text = "FormSetariEmail";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(331, 0);
            // 
            // lblAdresaEmail
            // 
            this.lblAdresaEmail.AutoSize = true;
            this.lblAdresaEmail.Location = new System.Drawing.Point(25, 54);
            this.lblAdresaEmail.Name = "lblAdresaEmail";
            this.lblAdresaEmail.Size = new System.Drawing.Size(61, 13);
            this.lblAdresaEmail.TabIndex = 2;
            this.lblAdresaEmail.Text = "Adresa mail";
            this.lblAdresaEmail.ToolTipText = null;
            this.lblAdresaEmail.ToolTipTitle = null;
            // 
            // txtAdresaMail
            // 
            this.txtAdresaMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdresaMail.CapitalizeazaPrimaLitera = false;
            this.txtAdresaMail.IsInReadOnlyMode = false;
            this.txtAdresaMail.Location = new System.Drawing.Point(98, 50);
            this.txtAdresaMail.Name = "txtAdresaMail";
            this.txtAdresaMail.ProprietateCorespunzatoare = null;
            this.txtAdresaMail.RaiseEventLaModificareProgramatica = false;
            this.txtAdresaMail.Size = new System.Drawing.Size(233, 20);
            this.txtAdresaMail.TabIndex = 3;
            this.txtAdresaMail.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtAdresaMail.TotulCuMajuscule = false;
            // 
            // lblServerSMTP
            // 
            this.lblServerSMTP.AutoSize = true;
            this.lblServerSMTP.Location = new System.Drawing.Point(25, 114);
            this.lblServerSMTP.Name = "lblServerSMTP";
            this.lblServerSMTP.Size = new System.Drawing.Size(71, 13);
            this.lblServerSMTP.TabIndex = 4;
            this.lblServerSMTP.Text = "Server SMTP";
            this.lblServerSMTP.ToolTipText = null;
            this.lblServerSMTP.ToolTipTitle = null;
            // 
            // txtServerSMTP
            // 
            this.txtServerSMTP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerSMTP.CapitalizeazaPrimaLitera = false;
            this.txtServerSMTP.IsInReadOnlyMode = false;
            this.txtServerSMTP.Location = new System.Drawing.Point(98, 110);
            this.txtServerSMTP.Name = "txtServerSMTP";
            this.txtServerSMTP.ProprietateCorespunzatoare = null;
            this.txtServerSMTP.RaiseEventLaModificareProgramatica = false;
            this.txtServerSMTP.Size = new System.Drawing.Size(233, 20);
            this.txtServerSMTP.TabIndex = 5;
            this.txtServerSMTP.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtServerSMTP.TotulCuMajuscule = false;
            // 
            // lblPortSMTP
            // 
            this.lblPortSMTP.AutoSize = true;
            this.lblPortSMTP.Location = new System.Drawing.Point(25, 144);
            this.lblPortSMTP.Name = "lblPortSMTP";
            this.lblPortSMTP.Size = new System.Drawing.Size(59, 13);
            this.lblPortSMTP.TabIndex = 6;
            this.lblPortSMTP.Text = "Port SMTP";
            this.lblPortSMTP.ToolTipText = null;
            this.lblPortSMTP.ToolTipTitle = null;
            // 
            // txtPortSMTP
            // 
            this.txtPortSMTP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPortSMTP.BackColor = System.Drawing.SystemColors.Window;
            this.txtPortSMTP.Location = new System.Drawing.Point(98, 140);
            this.txtPortSMTP.Name = "txtPortSMTP";
            this.txtPortSMTP.ProprietateCorespunzatoare = null;
            this.txtPortSMTP.Size = new System.Drawing.Size(233, 20);
            this.txtPortSMTP.TabIndex = 7;
            this.txtPortSMTP.Text = "0";
            this.txtPortSMTP.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.txtPortSMTP.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPortSMTP.ValoareDouble = 0D;
            // 
            // lblServerIMAP
            // 
            this.lblServerIMAP.AutoSize = true;
            this.lblServerIMAP.Location = new System.Drawing.Point(25, 174);
            this.lblServerIMAP.Name = "lblServerIMAP";
            this.lblServerIMAP.Size = new System.Drawing.Size(67, 13);
            this.lblServerIMAP.TabIndex = 8;
            this.lblServerIMAP.Text = "Server IMAP";
            this.lblServerIMAP.ToolTipText = null;
            this.lblServerIMAP.ToolTipTitle = null;
            // 
            // txtServerIMAP
            // 
            this.txtServerIMAP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerIMAP.CapitalizeazaPrimaLitera = false;
            this.txtServerIMAP.IsInReadOnlyMode = false;
            this.txtServerIMAP.Location = new System.Drawing.Point(98, 170);
            this.txtServerIMAP.Name = "txtServerIMAP";
            this.txtServerIMAP.ProprietateCorespunzatoare = null;
            this.txtServerIMAP.RaiseEventLaModificareProgramatica = false;
            this.txtServerIMAP.Size = new System.Drawing.Size(233, 20);
            this.txtServerIMAP.TabIndex = 9;
            this.txtServerIMAP.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtServerIMAP.TotulCuMajuscule = false;
            // 
            // lblPortIMAP
            // 
            this.lblPortIMAP.AutoSize = true;
            this.lblPortIMAP.Location = new System.Drawing.Point(25, 204);
            this.lblPortIMAP.Name = "lblPortIMAP";
            this.lblPortIMAP.Size = new System.Drawing.Size(55, 13);
            this.lblPortIMAP.TabIndex = 10;
            this.lblPortIMAP.Text = "Port IMAP";
            this.lblPortIMAP.ToolTipText = null;
            this.lblPortIMAP.ToolTipTitle = null;
            // 
            // txtPortIMAP
            // 
            this.txtPortIMAP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPortIMAP.BackColor = System.Drawing.SystemColors.Window;
            this.txtPortIMAP.Location = new System.Drawing.Point(98, 200);
            this.txtPortIMAP.Name = "txtPortIMAP";
            this.txtPortIMAP.ProprietateCorespunzatoare = null;
            this.txtPortIMAP.Size = new System.Drawing.Size(233, 20);
            this.txtPortIMAP.TabIndex = 11;
            this.txtPortIMAP.Text = "0";
            this.txtPortIMAP.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.txtPortIMAP.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPortIMAP.ValoareDouble = 0D;
            // 
            // chkSSL
            // 
            this.chkSSL.AutoSize = true;
            this.chkSSL.IsInReadOnlyMode = false;
            this.chkSSL.Location = new System.Drawing.Point(25, 234);
            this.chkSSL.Name = "chkSSL";
            this.chkSSL.ProprietateCorespunzatoare = null;
            this.chkSSL.Size = new System.Drawing.Size(46, 17);
            this.chkSSL.TabIndex = 12;
            this.chkSSL.Text = "SSL";
            this.chkSSL.UseVisualStyleBackColor = true;
            // 
            // ctrlValidareAnulareSetariEmail
            // 
            this.ctrlValidareAnulareSetariEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlValidareAnulareSetariEmail.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulareSetariEmail.Location = new System.Drawing.Point(102, 262);
            this.ctrlValidareAnulareSetariEmail.Name = "ctrlValidareAnulareSetariEmail";
            this.ctrlValidareAnulareSetariEmail.Size = new System.Drawing.Size(163, 23);
            this.ctrlValidareAnulareSetariEmail.TabIndex = 13;
            // 
            // lblUtilizator
            // 
            this.lblUtilizator.AutoSize = true;
            this.lblUtilizator.Location = new System.Drawing.Point(25, 84);
            this.lblUtilizator.Name = "lblUtilizator";
            this.lblUtilizator.Size = new System.Drawing.Size(47, 13);
            this.lblUtilizator.TabIndex = 14;
            this.lblUtilizator.Text = "Utilizator";
            this.lblUtilizator.ToolTipText = null;
            this.lblUtilizator.ToolTipTitle = null;
            // 
            // txtUtilizator
            // 
            this.txtUtilizator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUtilizator.CapitalizeazaPrimaLitera = false;
            this.txtUtilizator.IsInReadOnlyMode = false;
            this.txtUtilizator.Location = new System.Drawing.Point(98, 80);
            this.txtUtilizator.Name = "txtUtilizator";
            this.txtUtilizator.ProprietateCorespunzatoare = null;
            this.txtUtilizator.RaiseEventLaModificareProgramatica = false;
            this.txtUtilizator.Size = new System.Drawing.Size(233, 20);
            this.txtUtilizator.TabIndex = 15;
            this.txtUtilizator.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtUtilizator.TotulCuMajuscule = false;
            // 
            // FormSetariEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 297);
            this.Controls.Add(this.txtUtilizator);
            this.Controls.Add(this.lblUtilizator);
            this.Controls.Add(this.ctrlValidareAnulareSetariEmail);
            this.Controls.Add(this.chkSSL);
            this.Controls.Add(this.txtPortIMAP);
            this.Controls.Add(this.lblPortIMAP);
            this.Controls.Add(this.txtServerIMAP);
            this.Controls.Add(this.lblServerIMAP);
            this.Controls.Add(this.txtPortSMTP);
            this.Controls.Add(this.lblPortSMTP);
            this.Controls.Add(this.txtServerSMTP);
            this.Controls.Add(this.lblServerSMTP);
            this.Controls.Add(this.txtAdresaMail);
            this.Controls.Add(this.lblAdresaEmail);
            this.Name = "FormSetariEmail";
            this.Text = "FormSetariEmail";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.lblAdresaEmail, 0);
            this.Controls.SetChildIndex(this.txtAdresaMail, 0);
            this.Controls.SetChildIndex(this.lblServerSMTP, 0);
            this.Controls.SetChildIndex(this.txtServerSMTP, 0);
            this.Controls.SetChildIndex(this.lblPortSMTP, 0);
            this.Controls.SetChildIndex(this.txtPortSMTP, 0);
            this.Controls.SetChildIndex(this.lblServerIMAP, 0);
            this.Controls.SetChildIndex(this.txtServerIMAP, 0);
            this.Controls.SetChildIndex(this.lblPortIMAP, 0);
            this.Controls.SetChildIndex(this.txtPortIMAP, 0);
            this.Controls.SetChildIndex(this.chkSSL, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulareSetariEmail, 0);
            this.Controls.SetChildIndex(this.lblUtilizator, 0);
            this.Controls.SetChildIndex(this.txtUtilizator, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.LabelPersonalizat lblAdresaEmail;
        private CCL.UI.TextBoxPersonalizat txtAdresaMail;
        private CCL.UI.LabelPersonalizat lblServerSMTP;
        private CCL.UI.TextBoxPersonalizat txtServerSMTP;
        private CCL.UI.LabelPersonalizat lblPortSMTP;
        private CCL.UI.MaskedTextBoxPersonalizat txtPortSMTP;
        private CCL.UI.LabelPersonalizat lblServerIMAP;
        private CCL.UI.TextBoxPersonalizat txtServerIMAP;
        private CCL.UI.LabelPersonalizat lblPortIMAP;
        private CCL.UI.MaskedTextBoxPersonalizat txtPortIMAP;
        private CCL.UI.CheckBoxPersonalizat chkSSL;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulareSetariEmail;
        private CCL.UI.LabelPersonalizat lblUtilizator;
        private CCL.UI.TextBoxPersonalizat txtUtilizator;
    }
}