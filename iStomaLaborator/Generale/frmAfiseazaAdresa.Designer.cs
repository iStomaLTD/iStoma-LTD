namespace iStomaLab.Generale
{
    partial class frmAfiseazaAdresa
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
            this.ctrlAdresa = new iStomaLab.Generale.ControlAdresaISTOMA();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(608, 19);
            this.lblTitluEcran.Text = "frmAfiseazaAdresa";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(607, 0);
            // 
            // ctrlAdresa
            // 
            this.ctrlAdresa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlAdresa.BackColor = System.Drawing.SystemColors.Control;
            this.ctrlAdresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlAdresa.Location = new System.Drawing.Point(2, 20);
            this.ctrlAdresa.MinimumSize = new System.Drawing.Size(575, 283);
            this.ctrlAdresa.Name = "ctrlAdresa";
            this.ctrlAdresa.Size = new System.Drawing.Size(626, 311);
            this.ctrlAdresa.TabIndex = 2;
            // 
            // frmAfiseazaAdresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 333);
            this.Controls.Add(this.ctrlAdresa);
            this.Name = "frmAfiseazaAdresa";
            this.Text = "frmAfiseazaAdresa";
            this.Load += new System.EventHandler(this.frmAfiseazaAdresa_Load);
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.ctrlAdresa, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlAdresaISTOMA ctrlAdresa;
    }
}