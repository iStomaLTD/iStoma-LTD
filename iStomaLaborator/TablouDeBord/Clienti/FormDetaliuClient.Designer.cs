namespace iStomaLab.TablouDeBord.Clienti
{
    partial class FormDetaliuClient
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
            this.ctrlValidareAnulareClient = new CCL.UI.Caramizi.controlValidareAnulare();
            this.ctrlDetaliuClient = new iStomaLab.TablouDeBord.Clienti.ControlDetaliuClient();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitluEcran.Size = new System.Drawing.Size(492, 19);
            this.lblTitluEcran.TabIndex = 2;
            this.lblTitluEcran.Text = "FormDetaliuClient";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(491, 0);
            this.btnInchidereEcran.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnInchidereEcran.TabIndex = 3;
            // 
            // ctrlValidareAnulareClient
            // 
            this.ctrlValidareAnulareClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlValidareAnulareClient.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulareClient.Location = new System.Drawing.Point(174, 476);
            this.ctrlValidareAnulareClient.Name = "ctrlValidareAnulareClient";
            this.ctrlValidareAnulareClient.Size = new System.Drawing.Size(162, 23);
            this.ctrlValidareAnulareClient.TabIndex = 1;
            // 
            // ctrlDetaliuClient
            // 
            this.ctrlDetaliuClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlDetaliuClient.Location = new System.Drawing.Point(3, 25);
            this.ctrlDetaliuClient.Name = "ctrlDetaliuClient";
            this.ctrlDetaliuClient.Size = new System.Drawing.Size(506, 441);
            this.ctrlDetaliuClient.TabIndex = 0;
            // 
            // FormDetaliuClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 511);
            this.Controls.Add(this.ctrlDetaliuClient);
            this.Controls.Add(this.ctrlValidareAnulareClient);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormDetaliuClient";
            this.Text = "FormDetaliuClient";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulareClient, 0);
            this.Controls.SetChildIndex(this.ctrlDetaliuClient, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulareClient;
        private Clienti.ControlDetaliuClient ctrlDetaliuClient;
    }
}