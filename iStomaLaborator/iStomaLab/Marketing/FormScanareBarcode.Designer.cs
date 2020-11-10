namespace iStomaLab.Marketing
{
    partial class FormScanareBarcode
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
            this.txtCodDeBare = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblIndicatie = new CCL.UI.LabelPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(565, 19);
            this.lblTitluEcran.Text = "FormScanareBarcode";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(564, 0);
            // 
            // txtCodDeBare
            // 
            this.txtCodDeBare.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodDeBare.CapitalizeazaPrimaLitera = false;
            this.txtCodDeBare.IsInReadOnlyMode = false;
            this.txtCodDeBare.Location = new System.Drawing.Point(154, 90);
            this.txtCodDeBare.Name = "txtCodDeBare";
            this.txtCodDeBare.ProprietateCorespunzatoare = null;
            this.txtCodDeBare.RaiseEventLaModificareProgramatica = false;
            this.txtCodDeBare.Size = new System.Drawing.Size(287, 20);
            this.txtCodDeBare.TabIndex = 2;
            this.txtCodDeBare.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCodDeBare.TotulCuMajuscule = false;
            // 
            // lblIndicatie
            // 
            this.lblIndicatie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIndicatie.AutoSize = true;
            this.lblIndicatie.Location = new System.Drawing.Point(203, 55);
            this.lblIndicatie.Name = "lblIndicatie";
            this.lblIndicatie.Size = new System.Drawing.Size(182, 13);
            this.lblIndicatie.TabIndex = 3;
            this.lblIndicatie.Text = "Scanati codul de bare de pe eticheta";
            this.lblIndicatie.ToolTipText = null;
            this.lblIndicatie.ToolTipTitle = null;
            // 
            // FormScanareBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 162);
            this.Controls.Add(this.lblIndicatie);
            this.Controls.Add(this.txtCodDeBare);
            this.Name = "FormScanareBarcode";
            this.Text = "FormScanareBarcode";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.txtCodDeBare, 0);
            this.Controls.SetChildIndex(this.lblIndicatie, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.TextBoxPersonalizat txtCodDeBare;
        private CCL.UI.LabelPersonalizat lblIndicatie;
    }
}