namespace iStomaLab.Caramizi
{
    partial class ControlCautareEtapa
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
            this.cboListaEtape = new CCL.UI.ComboBoxPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // cboListaEtape
            // 
            this.cboListaEtape.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboListaEtape.AutoCompletePersonalizat = false;
            this.cboListaEtape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboListaEtape.FormattingEnabled = true;
            this.cboListaEtape.HideSelection = true;
            this.cboListaEtape.IsInReadOnlyMode = false;
            this.cboListaEtape.Location = new System.Drawing.Point(1, 1);
            this.cboListaEtape.Name = "cboListaEtape";
            this.cboListaEtape.ProprietateCorespunzatoare = null;
            this.cboListaEtape.Size = new System.Drawing.Size(185, 21);
            this.cboListaEtape.TabIndex = 2;
            this.cboListaEtape.TipulListei = CCL.UI.ComboBoxPersonalizat.EnumTipLista.Nespecificat;
            // 
            // ControlCautareEtapa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboListaEtape);
            this.Name = "ControlCautareEtapa";
            this.Size = new System.Drawing.Size(187, 23);
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.ComboBoxPersonalizat cboListaEtape;
    }
}
