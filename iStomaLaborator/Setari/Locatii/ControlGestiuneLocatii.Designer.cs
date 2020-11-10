namespace iStomaLab.Setari.Locatii
{
    partial class ControlGestiuneLocatii
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
            this.ctrlListaLocatii = new iStomaLab.Setari.Locatii.ControlListaLocatii();
            this.SuspendLayout();
            // 
            // ctrlListaLocatii
            // 
            this.ctrlListaLocatii.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlListaLocatii.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctrlListaLocatii.Location = new System.Drawing.Point(0, 0);
            this.ctrlListaLocatii.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctrlListaLocatii.Name = "ctrlListaLocatii";
            this.ctrlListaLocatii.Size = new System.Drawing.Size(747, 544);
            this.ctrlListaLocatii.TabIndex = 0;
            // 
            // ControlGestiuneLocatii
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlListaLocatii);
            this.Name = "ControlGestiuneLocatii";
            this.Size = new System.Drawing.Size(747, 547);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlListaLocatii ctrlListaLocatii;
    }
}
