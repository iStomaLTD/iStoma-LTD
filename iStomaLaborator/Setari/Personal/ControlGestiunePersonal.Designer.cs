namespace iStomaLab.Setari.Personal
{
    partial class ControlGestiunePersonal
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
            this.ctrlListaUtilizatori = new iStomaLab.Setari.Personal.ControlListaUtilizatori();
            this.SuspendLayout();
            // 
            // ctrlListaUtilizatori
            // 
            this.ctrlListaUtilizatori.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlListaUtilizatori.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctrlListaUtilizatori.Location = new System.Drawing.Point(2, 4);
            this.ctrlListaUtilizatori.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctrlListaUtilizatori.Name = "ctrlListaUtilizatori";
            this.ctrlListaUtilizatori.Size = new System.Drawing.Size(792, 637);
            this.ctrlListaUtilizatori.TabIndex = 0;
            // 
            // ControlGestiunePersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.ctrlListaUtilizatori);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ControlGestiunePersonal";
            this.Size = new System.Drawing.Size(801, 645);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlListaUtilizatori ctrlListaUtilizatori;
    }
}
