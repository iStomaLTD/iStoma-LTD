namespace iStomaLab.Caramizi
{
    partial class ControlCautarePacient
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
            this.lgfPacient = new CCL.UI.Caramizi.LabelGumaFind();
            this.SuspendLayout();
            // 
            // lgfClinica
            // 
            this.lgfPacient.AfiseazaButonCautare = true;
            this.lgfPacient.AfiseazaButonDetalii = false;
            this.lgfPacient.AfiseazaButonGuma = true;
            this.lgfPacient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lgfPacient.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.lgfPacient.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.lgfPacient.BackColor = System.Drawing.Color.White;
            this.lgfPacient.FolosesteToString = false;
            this.lgfPacient.IsInReadOnlyMode = false;
            this.lgfPacient.Location = new System.Drawing.Point(0, 0);
            this.lgfPacient.Name = "lgfPacient";
            this.lgfPacient.ObiectAfisajCorespunzator = null;
            this.lgfPacient.ObiectCorespunzator = null;
            this.lgfPacient.ProprietateCorespunzatoare = null;
            this.lgfPacient.Size = new System.Drawing.Size(234, 20);
            this.lgfPacient.TabIndex = 0;
            this.lgfPacient.Text = "...";
            this.lgfPacient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lgfPacient.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.lgfPacient.ToolTipText = null;
            this.lgfPacient.ToolTipTitle = null;
            // 
            // ControlCautarePacient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lgfClinica);
            this.Name = "ControlCautarePacient";
            this.Size = new System.Drawing.Size(236, 21);
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.Caramizi.LabelGumaFind lgfPacient;
    }
}
