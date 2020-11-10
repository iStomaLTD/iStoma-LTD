namespace iStomaLab.Setari.Liste.Localitati
{
    partial class FormAdaugaLocalitate
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
            this.ctrlAdaugaLocalitate = new iStomaLab.Setari.Liste.Localitati.ControlAdaugaLocalitate();
            this.ctrlValidareAnulareLocalitate = new CCL.UI.Caramizi.controlValidareAnulare();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(367, 23);
            this.lblTitluEcran.Text = "FormAdaugaLocalitate";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(366, 0);
            // 
            // ctrlAdaugaLocalitate
            // 
            this.ctrlAdaugaLocalitate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlAdaugaLocalitate.Location = new System.Drawing.Point(4, 31);
            this.ctrlAdaugaLocalitate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctrlAdaugaLocalitate.Name = "ctrlAdaugaLocalitate";
            this.ctrlAdaugaLocalitate.Size = new System.Drawing.Size(386, 126);
            this.ctrlAdaugaLocalitate.TabIndex = 2;
            // 
            // ctrlValidareAnulareLocalitate
            // 
            this.ctrlValidareAnulareLocalitate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlValidareAnulareLocalitate.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulareLocalitate.Location = new System.Drawing.Point(98, 169);
            this.ctrlValidareAnulareLocalitate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctrlValidareAnulareLocalitate.Name = "ctrlValidareAnulareLocalitate";
            this.ctrlValidareAnulareLocalitate.Size = new System.Drawing.Size(215, 28);
            this.ctrlValidareAnulareLocalitate.TabIndex = 3;
            // 
            // FormAdaugaLocalitate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 210);
            this.Controls.Add(this.ctrlValidareAnulareLocalitate);
            this.Controls.Add(this.ctrlAdaugaLocalitate);
            this.Name = "FormAdaugaLocalitate";
            this.Text = "FormAdaugaLocalitate";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.ctrlAdaugaLocalitate, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulareLocalitate, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlAdaugaLocalitate ctrlAdaugaLocalitate;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulareLocalitate;
    }
}