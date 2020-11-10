namespace iStomaLab.Generale
{
    partial class ControlAdresaLiniara
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
            this.lgfDomiciliatIn = new CCL.UI.Caramizi.LabelGumaFind();
            this.SuspendLayout();
            // 
            // lgfDomiciliatIn
            // 
            this.lgfDomiciliatIn.AfiseazaButonCautare = true;
            this.lgfDomiciliatIn.AfiseazaButonDetalii = true;
            this.lgfDomiciliatIn.AfiseazaButonGuma = false;
            this.lgfDomiciliatIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lgfDomiciliatIn.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.lgfDomiciliatIn.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.lgfDomiciliatIn.BackColor = System.Drawing.SystemColors.Control;
            this.lgfDomiciliatIn.FolosesteToString = false;
            this.lgfDomiciliatIn.IsInReadOnlyMode = false;
            this.lgfDomiciliatIn.Location = new System.Drawing.Point(0, 0);
            this.lgfDomiciliatIn.Name = "lgfDomiciliatIn";
            this.lgfDomiciliatIn.ObiectAfisajCorespunzator = null;
            this.lgfDomiciliatIn.ObiectCorespunzator = null;
            this.lgfDomiciliatIn.ProprietateCorespunzatoare = null;
            this.lgfDomiciliatIn.Size = new System.Drawing.Size(379, 20);
            this.lgfDomiciliatIn.TabIndex = 18;
            this.lgfDomiciliatIn.Text = "labelGumaFind1";
            this.lgfDomiciliatIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lgfDomiciliatIn.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.lgfDomiciliatIn.ToolTipText = null;
            this.lgfDomiciliatIn.ToolTipTitle = null;
            this.lgfDomiciliatIn.AfiseazaDetaliiObiectAtasat += new CCL.UI.CEvenimente.EventDeschideEcranCautare(this.lgfDomiciliatIn_AfiseazaDetaliiObiectAtasat);
            // 
            // ControlAdresaLiniara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lgfDomiciliatIn);
            this.Name = "ControlAdresaLiniara";
            this.Size = new System.Drawing.Size(379, 20);
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.Caramizi.LabelGumaFind lgfDomiciliatIn;
    }
}
