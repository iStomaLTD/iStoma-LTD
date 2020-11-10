namespace iStomaLab.Setari.Locatii
{
    partial class FormDetaliuLocatie
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
            this.ctrlDetaliuLocatie = new iStomaLab.Setari.Locatii.ControlDetaliuLocatie();
            this.ctrlValidareAnulareLocatie = new CCL.UI.Caramizi.controlValidareAnulare();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitluEcran.Size = new System.Drawing.Size(639, 19);
            this.lblTitluEcran.Text = "FormDetaliuLocatie";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(638, 0);
            this.btnInchidereEcran.Margin = new System.Windows.Forms.Padding(2);
            // 
            // ctrlDetaliuLocatie
            // 
            this.ctrlDetaliuLocatie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlDetaliuLocatie.Location = new System.Drawing.Point(4, 22);
            this.ctrlDetaliuLocatie.Margin = new System.Windows.Forms.Padding(2);
            this.ctrlDetaliuLocatie.Name = "ctrlDetaliuLocatie";
            this.ctrlDetaliuLocatie.Size = new System.Drawing.Size(647, 568);
            this.ctrlDetaliuLocatie.TabIndex = 2;
            // 
            // ctrlValidareAnulareLocatie
            // 
            this.ctrlValidareAnulareLocatie.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrlValidareAnulareLocatie.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulareLocatie.Location = new System.Drawing.Point(256, 599);
            this.ctrlValidareAnulareLocatie.Name = "ctrlValidareAnulareLocatie";
            this.ctrlValidareAnulareLocatie.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulareLocatie.TabIndex = 3;
            // 
            // FormDetaliuLocatie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 634);
            this.Controls.Add(this.ctrlValidareAnulareLocatie);
            this.Controls.Add(this.ctrlDetaliuLocatie);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormDetaliuLocatie";
            this.Text = "FormDetaliuLocatie";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.ctrlDetaliuLocatie, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulareLocatie, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlDetaliuLocatie ctrlDetaliuLocatie;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulareLocatie;
    }
}