namespace iStomaLab.TablouDeBord.Clienti
{
    partial class FormDetaliuComanda
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
            this.ctrlDetaliuClientComanda = new iStomaLab.TablouDeBord.Clienti.ControlDetaliuClientComanda();
            this.ctrlValidareAnulareComanda = new CCL.UI.Caramizi.controlValidareAnulare();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitluEcran.Size = new System.Drawing.Size(870, 19);
            this.lblTitluEcran.Text = "FormDetaliuComanda";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(869, 0);
            this.btnInchidereEcran.Margin = new System.Windows.Forms.Padding(2);
            // 
            // ctrlDetaliuClientComanda
            // 
            this.ctrlDetaliuClientComanda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlDetaliuClientComanda.Location = new System.Drawing.Point(3, 20);
            this.ctrlDetaliuClientComanda.Margin = new System.Windows.Forms.Padding(2);
            this.ctrlDetaliuClientComanda.Name = "ctrlDetaliuClientComanda";
            this.ctrlDetaliuClientComanda.Size = new System.Drawing.Size(880, 363);
            this.ctrlDetaliuClientComanda.TabIndex = 2;
            // 
            // ctrlValidareAnulareComanda
            // 
            this.ctrlValidareAnulareComanda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlValidareAnulareComanda.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulareComanda.Location = new System.Drawing.Point(367, 401);
            this.ctrlValidareAnulareComanda.Name = "ctrlValidareAnulareComanda";
            this.ctrlValidareAnulareComanda.Size = new System.Drawing.Size(168, 23);
            this.ctrlValidareAnulareComanda.TabIndex = 3;
            // 
            // FormDetaliuComanda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 436);
            this.Controls.Add(this.ctrlValidareAnulareComanda);
            this.Controls.Add(this.ctrlDetaliuClientComanda);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormDetaliuComanda";
            this.Text = "FormDetaliuComanda";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.ctrlDetaliuClientComanda, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulareComanda, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlDetaliuClientComanda ctrlDetaliuClientComanda;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulareComanda;
    }
}