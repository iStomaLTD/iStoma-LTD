namespace iStomaLab.TablouDeBord.Comunicare
{
    partial class FormScrieEmail
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
            this.ctrlScrieEmail = new iStomaLab.TablouDeBord.Comunicare.ControlScrieEmail();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitluEcran.Size = new System.Drawing.Size(856, 19);
            this.lblTitluEcran.Text = "FormScrieEmail";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(856, 0);
            this.btnInchidereEcran.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            // 
            // ctrlScrieEmail
            // 
            this.ctrlScrieEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlScrieEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlScrieEmail.Location = new System.Drawing.Point(1, 19);
            this.ctrlScrieEmail.Name = "ctrlScrieEmail";
            this.ctrlScrieEmail.Size = new System.Drawing.Size(878, 475);
            this.ctrlScrieEmail.TabIndex = 2;
            // 
            // FormScrieEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 494);
            this.Controls.Add(this.ctrlScrieEmail);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormScrieEmail";
            this.ShowInTaskbar = true;
            this.Text = "FormScrieEmail";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.ctrlScrieEmail, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlScrieEmail ctrlScrieEmail;
    }
}