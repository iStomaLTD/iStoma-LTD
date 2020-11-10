namespace iStomaLab.Imprimare
{
    partial class FormImprimaWebBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImprimaWebBrowser));
            this.chkImprimaLogo = new CCL.UI.CheckBoxPersonalizat(this.components);
            this.btnImprima = new CCL.UI.ButtonPersonalizat(this.components);
            this.wbContinut = new CCL.UI.ControalePersonalizate.WebBrowserJS(this.components);
            this.ctrlValidareAnulare = new CCL.UI.Caramizi.controlValidareAnulare();
            this.btnTrimitePeMail = new CCL.UI.ButtonPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(778, 19);
            this.lblTitluEcran.Text = "FormImprimaWebBrowser";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(777, 0);
            // 
            // chkImprimaLogo
            // 
            this.chkImprimaLogo.AutoSize = true;
            this.chkImprimaLogo.IsInReadOnlyMode = false;
            this.chkImprimaLogo.Location = new System.Drawing.Point(6, 26);
            this.chkImprimaLogo.Name = "chkImprimaLogo";
            this.chkImprimaLogo.ProprietateCorespunzatoare = null;
            this.chkImprimaLogo.Size = new System.Drawing.Size(85, 17);
            this.chkImprimaLogo.TabIndex = 2;
            this.chkImprimaLogo.Text = "Imprima logo";
            this.chkImprimaLogo.UseVisualStyleBackColor = true;
            // 
            // btnImprima
            // 
            this.btnImprima.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprima.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnImprima.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprima.Location = new System.Drawing.Point(688, 23);
            this.btnImprima.Name = "btnImprima";
            this.btnImprima.Size = new System.Drawing.Size(104, 23);
            this.btnImprima.TabIndex = 3;
            this.btnImprima.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Print;
            this.btnImprima.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnImprima.UseVisualStyleBackColor = true;
            // 
            // wbContinut
            // 
            this.wbContinut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbContinut.HideSelection = true;
            this.wbContinut.IsInReadOnlyMode = false;
            this.wbContinut.Location = new System.Drawing.Point(5, 52);
            this.wbContinut.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbContinut.Name = "wbContinut";
            this.wbContinut.ProprietateCorespunzatoare = null;
            this.wbContinut.SelectedText = null;
            this.wbContinut.Size = new System.Drawing.Size(790, 508);
            this.wbContinut.TabIndex = 4;
            // 
            // ctrlValidareAnulare
            // 
            this.ctrlValidareAnulare.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrlValidareAnulare.BackColor = System.Drawing.SystemColors.Control;
            this.ctrlValidareAnulare.Location = new System.Drawing.Point(320, 568);
            this.ctrlValidareAnulare.Name = "ctrlValidareAnulare";
            this.ctrlValidareAnulare.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulare.TabIndex = 5;
            // 
            // btnTrimitePeMail
            // 
            this.btnTrimitePeMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTrimitePeMail.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnTrimitePeMail.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTrimitePeMail.Location = new System.Drawing.Point(578, 23);
            this.btnTrimitePeMail.Name = "btnTrimitePeMail";
            this.btnTrimitePeMail.Size = new System.Drawing.Size(104, 23);
            this.btnTrimitePeMail.TabIndex = 6;
            this.btnTrimitePeMail.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Email;
            this.btnTrimitePeMail.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnTrimitePeMail.UseVisualStyleBackColor = true;
            // 
            // FormImprimaWebBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnTrimitePeMail);
            this.Controls.Add(this.ctrlValidareAnulare);
            this.Controls.Add(this.wbContinut);
            this.Controls.Add(this.btnImprima);
            this.Controls.Add(this.chkImprimaLogo);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormImprimaWebBrowser";
            this.Text = "FormImprimaWebBrowser";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.chkImprimaLogo, 0);
            this.Controls.SetChildIndex(this.btnImprima, 0);
            this.Controls.SetChildIndex(this.wbContinut, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulare, 0);
            this.Controls.SetChildIndex(this.btnTrimitePeMail, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.CheckBoxPersonalizat chkImprimaLogo;
        private CCL.UI.ButtonPersonalizat btnImprima;
        private CCL.UI.ControalePersonalizate.WebBrowserJS wbContinut;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulare;
        private CCL.UI.ButtonPersonalizat btnTrimitePeMail;
    }
}