namespace iStomaLab.Setari.Lucrari
{
    partial class FormDetaliuLucrare
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
            this.ctrlDetaliuLucrare = new iStomaLab.Setari.Lucrari.ControlDetaliuLucrare();
            this.ctrlValidareAnulareLucrare = new CCL.UI.Caramizi.controlValidareAnulare();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Location = new System.Drawing.Point(-3, 0);
            this.lblTitluEcran.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitluEcran.Size = new System.Drawing.Size(530, 19);
            this.lblTitluEcran.Text = "FormDetaliuLucrare";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(526, 0);
            this.btnInchidereEcran.Margin = new System.Windows.Forms.Padding(2);
            // 
            // ctrlDetaliuLucrare
            // 
            this.ctrlDetaliuLucrare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlDetaliuLucrare.Location = new System.Drawing.Point(2, 21);
            this.ctrlDetaliuLucrare.Margin = new System.Windows.Forms.Padding(2);
            this.ctrlDetaliuLucrare.Name = "ctrlDetaliuLucrare";
            this.ctrlDetaliuLucrare.Size = new System.Drawing.Size(538, 379);
            this.ctrlDetaliuLucrare.TabIndex = 2;
            // 
            // ctrlValidareAnulareLucrare
            // 
            this.ctrlValidareAnulareLucrare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlValidareAnulareLucrare.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulareLucrare.Location = new System.Drawing.Point(194, 402);
            this.ctrlValidareAnulareLucrare.Name = "ctrlValidareAnulareLucrare";
            this.ctrlValidareAnulareLucrare.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulareLucrare.TabIndex = 3;
            // 
            // FormDetaliuLucrare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 433);
            this.Controls.Add(this.ctrlValidareAnulareLucrare);
            this.Controls.Add(this.ctrlDetaliuLucrare);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormDetaliuLucrare";
            this.Text = "FormDetaliuLucrare";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.ctrlDetaliuLucrare, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulareLucrare, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlDetaliuLucrare ctrlDetaliuLucrare;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulareLucrare;
    }
}