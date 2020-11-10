namespace iStomaLab.Setari.Liste.Categorii
{
    partial class FormDetaliiCategorie
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
            this.ctrlDetaliiCategorie = new iStomaLab.Setari.Liste.Categorii.ControlDetaliiCategorie();
            this.ctrlValidareAnulareCategorie = new CCL.UI.Caramizi.controlValidareAnulare();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(496, 23);
            this.lblTitluEcran.Text = "FormDetaliiCategorie";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(495, 0);
            // 
            // ctrlDetaliiCategorie
            // 
            this.ctrlDetaliiCategorie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlDetaliiCategorie.Location = new System.Drawing.Point(3, 27);
            this.ctrlDetaliiCategorie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctrlDetaliiCategorie.Name = "ctrlDetaliiCategorie";
            this.ctrlDetaliiCategorie.Size = new System.Drawing.Size(510, 124);
            this.ctrlDetaliiCategorie.TabIndex = 2;
            // 
            // ctrlValidareAnulareCategorie
            // 
            this.ctrlValidareAnulareCategorie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlValidareAnulareCategorie.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulareCategorie.Location = new System.Drawing.Point(163, 169);
            this.ctrlValidareAnulareCategorie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctrlValidareAnulareCategorie.Name = "ctrlValidareAnulareCategorie";
            this.ctrlValidareAnulareCategorie.Size = new System.Drawing.Size(215, 28);
            this.ctrlValidareAnulareCategorie.TabIndex = 3;
            // 
            // FormDetaliiCategorie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 210);
            this.Controls.Add(this.ctrlValidareAnulareCategorie);
            this.Controls.Add(this.ctrlDetaliiCategorie);
            this.Name = "FormDetaliiCategorie";
            this.Text = "FormDetaliiCategorie";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.ctrlDetaliiCategorie, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulareCategorie, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlDetaliiCategorie ctrlDetaliiCategorie;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulareCategorie;
    }
}