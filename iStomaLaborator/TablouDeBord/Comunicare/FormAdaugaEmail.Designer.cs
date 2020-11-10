namespace iStomaLab.TablouDeBord.Comunicare
{
    partial class FormAdaugaEmail
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
            this.ctrlSetariEmail = new iStomaLab.TablouDeBord.Email.ControlAdaugaEmail();
            this.ctrlValidareAnulareEmail = new CCL.UI.Caramizi.controlValidareAnulare();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitluEcran.Size = new System.Drawing.Size(312, 19);
            this.lblTitluEcran.Text = "FormAdaugaEmail";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(312, 0);
            this.btnInchidereEcran.Margin = new System.Windows.Forms.Padding(2);
            // 
            // ctrlSetariEmail
            // 
            this.ctrlSetariEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlSetariEmail.Location = new System.Drawing.Point(3, 22);
            this.ctrlSetariEmail.Margin = new System.Windows.Forms.Padding(2);
            this.ctrlSetariEmail.Name = "ctrlSetariEmail";
            this.ctrlSetariEmail.Size = new System.Drawing.Size(329, 134);
            this.ctrlSetariEmail.TabIndex = 2;
            // 
            // ctrlValidareAnulareEmail
            // 
            this.ctrlValidareAnulareEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlValidareAnulareEmail.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulareEmail.Location = new System.Drawing.Point(84, 161);
            this.ctrlValidareAnulareEmail.Name = "ctrlValidareAnulareEmail";
            this.ctrlValidareAnulareEmail.Size = new System.Drawing.Size(171, 23);
            this.ctrlValidareAnulareEmail.TabIndex = 3;
            // 
            // FormAdaugaEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 199);
            this.Controls.Add(this.ctrlValidareAnulareEmail);
            this.Controls.Add(this.ctrlSetariEmail);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormAdaugaEmail";
            this.Text = "FormAdaugaEmail";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.ctrlSetariEmail, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulareEmail, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Email.ControlAdaugaEmail ctrlSetariEmail;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulareEmail;
    }
}