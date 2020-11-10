namespace iStomaLab.Caramizi
{
    partial class ControlCautareMedicClinica
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
            this.cboListaMediciClinica = new CCL.UI.ComboBoxPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // cboListaMediciClinica
            // 
            this.cboListaMediciClinica.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboListaMediciClinica.AutoCompletePersonalizat = false;
            this.cboListaMediciClinica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboListaMediciClinica.FormattingEnabled = true;
            this.cboListaMediciClinica.HideSelection = true;
            this.cboListaMediciClinica.IsInReadOnlyMode = false;
            this.cboListaMediciClinica.Location = new System.Drawing.Point(1, 1);
            this.cboListaMediciClinica.Name = "cboListaMediciClinica";
            this.cboListaMediciClinica.ProprietateCorespunzatoare = null;
            this.cboListaMediciClinica.Size = new System.Drawing.Size(186, 21);
            this.cboListaMediciClinica.TabIndex = 1;
            this.cboListaMediciClinica.TipulListei = CCL.UI.ComboBoxPersonalizat.EnumTipLista.Nespecificat;
            // 
            // UControlCautareMedicClinica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboListaMediciClinica);
            this.Name = "UControlCautareMedicClinica";
            this.Size = new System.Drawing.Size(188, 23);
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.ComboBoxPersonalizat cboListaMediciClinica;
    }
}
