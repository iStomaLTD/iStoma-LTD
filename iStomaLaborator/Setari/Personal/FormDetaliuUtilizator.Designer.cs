namespace iStomaLab.Setari.Personal
{
    partial class FormDetaliuUtilizator
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
            this.ctrlValidareAnulare = new CCL.UI.Caramizi.controlValidareAnulare();
            this.ctrlDetaliuUtilizator = new iStomaLab.Setari.Personal.ControlDetaliuUtilizator();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitluEcran.Size = new System.Drawing.Size(747, 19);
            this.lblTitluEcran.Text = "FormDetaliuUtilizator";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(746, 0);
            this.btnInchidereEcran.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            // 
            // ctrlValidareAnulare
            // 
            this.ctrlValidareAnulare.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrlValidareAnulare.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulare.Location = new System.Drawing.Point(304, 543);
            this.ctrlValidareAnulare.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctrlValidareAnulare.Name = "ctrlValidareAnulare";
            this.ctrlValidareAnulare.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulare.TabIndex = 2;
            // 
            // ctrlDetaliuUtilizator
            // 
            this.ctrlDetaliuUtilizator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlDetaliuUtilizator.Location = new System.Drawing.Point(20, 28);
            this.ctrlDetaliuUtilizator.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctrlDetaliuUtilizator.Name = "ctrlDetaliuUtilizator";
            this.ctrlDetaliuUtilizator.Size = new System.Drawing.Size(736, 493);
            this.ctrlDetaliuUtilizator.TabIndex = 0;
            // 
            // FormDetaliuUtilizator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 577);
            this.Controls.Add(this.ctrlDetaliuUtilizator);
            this.Controls.Add(this.ctrlValidareAnulare);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "FormDetaliuUtilizator";
            this.Text = "FormDetaliuUtilizator";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulare, 0);
            this.Controls.SetChildIndex(this.ctrlDetaliuUtilizator, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulare;
        private ControlDetaliuUtilizator ctrlDetaliuUtilizator;
    }
}