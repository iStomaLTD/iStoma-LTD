namespace iStomaLab.Caramizi
{
    partial class ControlCautareCabinetClinica
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
            this.cboListaCabineteClinica = new CCL.UI.ComboBoxPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // cboListaCabineteClinica
            // 
            this.cboListaCabineteClinica.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboListaCabineteClinica.AutoCompletePersonalizat = false;
            this.cboListaCabineteClinica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboListaCabineteClinica.FormattingEnabled = true;
            this.cboListaCabineteClinica.HideSelection = true;
            this.cboListaCabineteClinica.IsInReadOnlyMode = false;
            this.cboListaCabineteClinica.Location = new System.Drawing.Point(1, 1);
            this.cboListaCabineteClinica.Name = "cboListaCabineteClinica";
            this.cboListaCabineteClinica.ProprietateCorespunzatoare = null;
            this.cboListaCabineteClinica.Size = new System.Drawing.Size(186, 21);
            this.cboListaCabineteClinica.TabIndex = 0;
            this.cboListaCabineteClinica.TipulListei = CCL.UI.ComboBoxPersonalizat.EnumTipLista.Nespecificat;
            // 
            // ControlCautareCabinetClinica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboListaCabineteClinica);
            this.Name = "ControlCautareCabinetClinica";
            this.Size = new System.Drawing.Size(188, 23);
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.ComboBoxPersonalizat cboListaCabineteClinica;
    }
}
