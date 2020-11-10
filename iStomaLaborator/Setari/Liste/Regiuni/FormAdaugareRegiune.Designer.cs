namespace iStomaLab.Setari.Liste.Regiuni
{
    partial class FormAdaugareRegiune
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
            this.ctrlAdaugareRegiune = new iStomaLab.Setari.Liste.Regiuni.ControlAdaugareRegiune();
            this.ctrlValidareAnulareRegiune = new CCL.UI.Caramizi.controlValidareAnulare();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Text = "FormAdaugareRegiune";
            // 
            // ctrlAdaugareRegiune
            // 
            this.ctrlAdaugareRegiune.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlAdaugareRegiune.Location = new System.Drawing.Point(12, 31);
            this.ctrlAdaugareRegiune.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctrlAdaugareRegiune.Name = "ctrlAdaugareRegiune";
            this.ctrlAdaugareRegiune.Size = new System.Drawing.Size(354, 180);
            this.ctrlAdaugareRegiune.TabIndex = 2;
            // 
            // ctrlValidareAnulareRegiune
            // 
            this.ctrlValidareAnulareRegiune.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlValidareAnulareRegiune.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulareRegiune.Location = new System.Drawing.Point(89, 219);
            this.ctrlValidareAnulareRegiune.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctrlValidareAnulareRegiune.Name = "ctrlValidareAnulareRegiune";
            this.ctrlValidareAnulareRegiune.Size = new System.Drawing.Size(215, 28);
            this.ctrlValidareAnulareRegiune.TabIndex = 3;
            // 
            // FormAdaugareRegiune
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 261);
            this.Controls.Add(this.ctrlValidareAnulareRegiune);
            this.Controls.Add(this.ctrlAdaugareRegiune);
            this.Name = "FormAdaugareRegiune";
            this.Text = "FormAdaugareRegiune";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.ctrlAdaugareRegiune, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulareRegiune, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlAdaugareRegiune ctrlAdaugareRegiune;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulareRegiune;
    }
}