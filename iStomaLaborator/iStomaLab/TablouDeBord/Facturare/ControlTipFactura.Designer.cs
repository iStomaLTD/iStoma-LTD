namespace iStomaLab.TablouDeBord.Facturare
{
    partial class ControlTipFactura
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
            this.cboTipFactura = new CCL.UI.ComboBoxPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // cboTipFactura
            // 
            this.cboTipFactura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipFactura.AutoCompletePersonalizat = false;
            this.cboTipFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipFactura.FormattingEnabled = true;
            this.cboTipFactura.HideSelection = true;
            this.cboTipFactura.IsInReadOnlyMode = false;
            this.cboTipFactura.Location = new System.Drawing.Point(1, 1);
            this.cboTipFactura.Name = "cboTipFactura";
            this.cboTipFactura.ProprietateCorespunzatoare = null;
            this.cboTipFactura.Size = new System.Drawing.Size(139, 21);
            this.cboTipFactura.TabIndex = 0;
            this.cboTipFactura.TipulListei = CCL.UI.ComboBoxPersonalizat.EnumTipLista.Nespecificat;
            // 
            // ControlTipFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboTipFactura);
            this.Name = "ControlTipFactura";
            this.Size = new System.Drawing.Size(141, 23);
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.ComboBoxPersonalizat cboTipFactura;
    }
}
