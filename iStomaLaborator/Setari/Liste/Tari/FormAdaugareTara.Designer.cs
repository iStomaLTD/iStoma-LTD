namespace iStomaLab.Setari.Liste.Tari
{
    partial class FormAdaugareTara
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
            this.ctrlAdaugareTara = new iStomaLab.Setari.Liste.Tari.ControlAdaugareTara();
            this.ctrlValidareAnulareTara = new CCL.UI.Caramizi.controlValidareAnulare();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(403, 23);
            this.lblTitluEcran.Text = "FormAdaugareTara";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(402, 0);
            // 
            // ctrlAdaugareTara
            // 
            this.ctrlAdaugareTara.Location = new System.Drawing.Point(28, 27);
            this.ctrlAdaugareTara.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctrlAdaugareTara.Name = "ctrlAdaugareTara";
            this.ctrlAdaugareTara.Size = new System.Drawing.Size(375, 244);
            this.ctrlAdaugareTara.TabIndex = 2;
            // 
            // ctrlValidareAnulareTara
            // 
            this.ctrlValidareAnulareTara.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulareTara.Location = new System.Drawing.Point(117, 291);
            this.ctrlValidareAnulareTara.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctrlValidareAnulareTara.Name = "ctrlValidareAnulareTara";
            this.ctrlValidareAnulareTara.Size = new System.Drawing.Size(215, 28);
            this.ctrlValidareAnulareTara.TabIndex = 3;
            // 
            // FormAdaugareTara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 345);
            this.Controls.Add(this.ctrlValidareAnulareTara);
            this.Controls.Add(this.ctrlAdaugareTara);
            this.Name = "FormAdaugareTara";
            this.Text = "FormAdaugareTara";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.ctrlAdaugareTara, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulareTara, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlAdaugareTara ctrlAdaugareTara;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulareTara;
    }
}