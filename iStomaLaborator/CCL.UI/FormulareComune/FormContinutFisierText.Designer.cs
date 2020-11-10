namespace CCL.UI.FormulareComune
{
    partial class FormContinutFisierText
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
            this.txtContinut = new CCL.UI.TextBoxPersonalizat(this.components);
            this.panelGlobal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGlobal
            // 
            this.panelGlobal.Controls.Add(this.txtContinut);
            this.panelGlobal.Size = new System.Drawing.Size(798, 454);
            // 
            // btnValidare
            // 
            this.btnValidare.Location = new System.Drawing.Point(349, 474);
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(778, 19);
            this.lblTitluEcran.Text = "FormContinutFisierText";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(777, 0);
            // 
            // txtContinut
            // 
            this.txtContinut.CapitalizeazaPrimaLitera = false;
            this.txtContinut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContinut.IsInReadOnlyMode = false;
            this.txtContinut.Location = new System.Drawing.Point(0, 0);
            this.txtContinut.Multiline = true;
            this.txtContinut.Name = "txtContinut";
            this.txtContinut.ProprietateCorespunzatoare = null;
            this.txtContinut.RaiseEventLaModificareProgramatica = false;
            this.txtContinut.Size = new System.Drawing.Size(798, 454);
            this.txtContinut.TabIndex = 0;
            this.txtContinut.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtContinut.TotulCuMajuscule = false;
            // 
            // FormContinutFisierText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "FormContinutFisierText";
            this.Text = "FormContinutFisierText";
            this.panelGlobal.ResumeLayout(false);
            this.panelGlobal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBoxPersonalizat txtContinut;
    }
}