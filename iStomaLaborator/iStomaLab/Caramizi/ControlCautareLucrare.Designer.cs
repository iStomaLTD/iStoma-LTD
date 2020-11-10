namespace iStomaLab.Caramizi
{
    partial class ControlCautareLucrare
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
            this.lgfLucrare = new CCL.UI.Caramizi.LabelGumaFind();
            this.SuspendLayout();
            // 
            // lgfLucrare
            // 
            this.lgfLucrare.AfiseazaButonCautare = true;
            this.lgfLucrare.AfiseazaButonDetalii = false;
            this.lgfLucrare.AfiseazaButonGuma = true;
            this.lgfLucrare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lgfLucrare.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.lgfLucrare.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.lgfLucrare.BackColor = System.Drawing.Color.White;
            this.lgfLucrare.FolosesteToString = false;
            this.lgfLucrare.IsInReadOnlyMode = false;
            this.lgfLucrare.Location = new System.Drawing.Point(0, 0);
            this.lgfLucrare.Name = "lgfLucrare";
            this.lgfLucrare.ObiectAfisajCorespunzator = null;
            this.lgfLucrare.ObiectCorespunzator = null;
            this.lgfLucrare.ProprietateCorespunzatoare = null;
            this.lgfLucrare.Size = new System.Drawing.Size(249, 21);
            this.lgfLucrare.TabIndex = 0;
            this.lgfLucrare.Text = "...";
            this.lgfLucrare.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lgfLucrare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.lgfLucrare.ToolTipText = null;
            this.lgfLucrare.ToolTipTitle = null;
            // 
            // ControlCautareLucrare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lgfLucrare);
            this.Name = "ControlCautareLucrare";
            this.Size = new System.Drawing.Size(251, 22);
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.Caramizi.LabelGumaFind lgfLucrare;
    }
}
