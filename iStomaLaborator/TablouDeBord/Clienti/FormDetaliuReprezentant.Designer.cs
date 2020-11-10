namespace iStomaLab.TablouDeBord.Clienti
{
    partial class FormDetaliuReprezentant
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
            this.ctrlDetaliuReprezentant = new iStomaLab.TablouDeBord.Clienti.ControlDetaliuReprezentant();
            this.ctrlValidareAnulareReprezentant = new CCL.UI.Caramizi.controlValidareAnulare();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(751, 23);
            this.lblTitluEcran.Text = "FormDetaliuReprezentant";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(750, 0);
            // 
            // ctrlDetaliuReprezentant
            // 
            this.ctrlDetaliuReprezentant.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlDetaliuReprezentant.Location = new System.Drawing.Point(13, 27);
            this.ctrlDetaliuReprezentant.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctrlDetaliuReprezentant.Name = "ctrlDetaliuReprezentant";
            this.ctrlDetaliuReprezentant.Size = new System.Drawing.Size(758, 531);
            this.ctrlDetaliuReprezentant.TabIndex = 2;
            // 
            // ctrlValidareAnulareReprezentant
            // 
            this.ctrlValidareAnulareReprezentant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlValidareAnulareReprezentant.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulareReprezentant.Location = new System.Drawing.Point(284, 576);
            this.ctrlValidareAnulareReprezentant.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctrlValidareAnulareReprezentant.Name = "ctrlValidareAnulareReprezentant";
            this.ctrlValidareAnulareReprezentant.Size = new System.Drawing.Size(215, 28);
            this.ctrlValidareAnulareReprezentant.TabIndex = 3;
            // 
            // FormDetaliuReprezentant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 617);
            this.Controls.Add(this.ctrlValidareAnulareReprezentant);
            this.Controls.Add(this.ctrlDetaliuReprezentant);
            this.Name = "FormDetaliuReprezentant";
            this.Text = "FormDetaliuReprezentant";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.ctrlDetaliuReprezentant, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulareReprezentant, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlDetaliuReprezentant ctrlDetaliuReprezentant;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulareReprezentant;
    }
}