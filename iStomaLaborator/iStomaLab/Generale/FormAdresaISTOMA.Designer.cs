namespace iStomaLab.Generale
{
    partial class FormAdresaISTOMA
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlAdresa = new iStomaLab.Generale.ControlAdresaISTOMA();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(558, 19);
            this.lblTitluEcran.Text = "FormAdresaISTOMA";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(557, 0);
            // 
            // ctrlAdresa
            // 
            this.ctrlAdresa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlAdresa.BackColor = System.Drawing.Color.Gainsboro;
            this.ctrlAdresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlAdresa.Location = new System.Drawing.Point(0, 19);
            this.ctrlAdresa.MinimumSize = new System.Drawing.Size(575, 283);
            this.ctrlAdresa.Name = "ctrlAdresa";
            this.ctrlAdresa.Size = new System.Drawing.Size(580, 290);
            this.ctrlAdresa.TabIndex = 2;
            // 
            // FormAdresaISTOMA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 309);
            this.Controls.Add(this.ctrlAdresa);
            this.Name = "FormAdresaISTOMA";
            this.Text = "FormAdresaISTOMA";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.ctrlAdresa, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlAdresaISTOMA ctrlAdresa;
    }
}