namespace iStomaLab.Caramizi
{
    partial class ControlCautareClinica
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
            this.lgfClinica = new CCL.UI.Caramizi.LabelGumaFind();
            this.SuspendLayout();
            // 
            // lgfClinica
            // 
            this.lgfClinica.AfiseazaButonCautare = true;
            this.lgfClinica.AfiseazaButonDetalii = false;
            this.lgfClinica.AfiseazaButonGuma = true;
            this.lgfClinica.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lgfClinica.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.lgfClinica.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.lgfClinica.BackColor = System.Drawing.Color.White;
            this.lgfClinica.FolosesteToString = false;
            this.lgfClinica.IsInReadOnlyMode = false;
            this.lgfClinica.Location = new System.Drawing.Point(0, 0);
            this.lgfClinica.Name = "lgfClinica";
            this.lgfClinica.ObiectAfisajCorespunzator = null;
            this.lgfClinica.ObiectCorespunzator = null;
            this.lgfClinica.ProprietateCorespunzatoare = null;
            this.lgfClinica.Size = new System.Drawing.Size(234, 20);
            this.lgfClinica.TabIndex = 0;
            this.lgfClinica.Text = "...";
            this.lgfClinica.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lgfClinica.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.lgfClinica.ToolTipText = null;
            this.lgfClinica.ToolTipTitle = null;
            // 
            // ControlCautareClinica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lgfClinica);
            this.Name = "ControlCautareClinica";
            this.Size = new System.Drawing.Size(236, 21);
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.Caramizi.LabelGumaFind lgfClinica;
    }
}
