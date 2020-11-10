namespace iStomaLab.Caramizi
{
    partial class ControlCautaTehnician
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
            this.lgfTehnician = new CCL.UI.Caramizi.LabelGumaFind();
            this.SuspendLayout();
            // 
            // lgfTehnician
            // 
            this.lgfTehnician.AfiseazaButonCautare = true;
            this.lgfTehnician.AfiseazaButonDetalii = false;
            this.lgfTehnician.AfiseazaButonGuma = true;
            this.lgfTehnician.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lgfTehnician.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.lgfTehnician.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.lgfTehnician.BackColor = System.Drawing.Color.White;
            this.lgfTehnician.FolosesteToString = false;
            this.lgfTehnician.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lgfTehnician.IsInReadOnlyMode = false;
            this.lgfTehnician.Location = new System.Drawing.Point(1, 1);
            this.lgfTehnician.Name = "lgfTehnician";
            this.lgfTehnician.ObiectAfisajCorespunzator = null;
            this.lgfTehnician.ObiectCorespunzator = null;
            this.lgfTehnician.ProprietateCorespunzatoare = null;
            this.lgfTehnician.Size = new System.Drawing.Size(247, 21);
            this.lgfTehnician.TabIndex = 35;
            this.lgfTehnician.Text = "...";
            this.lgfTehnician.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lgfTehnician.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.lgfTehnician.ToolTipText = null;
            this.lgfTehnician.ToolTipTitle = null;
            // 
            // ControlCautaTehnician
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lgfTehnician);
            this.Name = "ControlCautaTehnician";
            this.Size = new System.Drawing.Size(249, 23);
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.Caramizi.LabelGumaFind lgfTehnician;
    }
}
