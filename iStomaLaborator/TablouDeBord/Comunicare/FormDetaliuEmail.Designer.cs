namespace iStomaLab.TablouDeBord.Comunicare
{
    partial class FormDetaliuEmail
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
            this.ctrlDetaliuEmail = new iStomaLab.TablouDeBord.Comunicare.ControlDetaliuEmail();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(1142, 23);
            this.lblTitluEcran.Text = "FormDetaliuEmail";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(1141, 0);
            // 
            // ctrlDetaliuEmail
            // 
            this.ctrlDetaliuEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlDetaliuEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlDetaliuEmail.Location = new System.Drawing.Point(1, 27);
            this.ctrlDetaliuEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctrlDetaliuEmail.Name = "ctrlDetaliuEmail";
            this.ctrlDetaliuEmail.Size = new System.Drawing.Size(1170, 739);
            this.ctrlDetaliuEmail.TabIndex = 2;
            // 
            // FormDetaliuEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 779);
            this.Controls.Add(this.ctrlDetaliuEmail);
            this.Name = "FormDetaliuEmail";
            this.PermiteDeplasareaEcranului = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDetaliuEmail";
            this.TipDeschidere = CCL.UI.CEnumerariComune.EnumTipDeschidere.CentrulEcranului;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.ctrlDetaliuEmail, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlDetaliuEmail ctrlDetaliuEmail;
    }
}