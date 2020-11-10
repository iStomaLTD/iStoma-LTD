namespace iStomaLab.Generale
{
    partial class FormExtrageEmailuri
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
            this.components = new System.ComponentModel.Container();
            this.pbIncarcaEmailuri = new System.Windows.Forms.ProgressBar();
            this.lblInfoIncarcaEmailuri = new CCL.UI.LabelPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Text = "FormExtrageEmailuri";
            // 
            // pbIncarcaEmailuri
            // 
            this.pbIncarcaEmailuri.Location = new System.Drawing.Point(26, 105);
            this.pbIncarcaEmailuri.Name = "pbIncarcaEmailuri";
            this.pbIncarcaEmailuri.Size = new System.Drawing.Size(236, 23);
            this.pbIncarcaEmailuri.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbIncarcaEmailuri.TabIndex = 2;
            // 
            // lblInfoIncarcaEmailuri
            // 
            this.lblInfoIncarcaEmailuri.AutoSize = true;
            this.lblInfoIncarcaEmailuri.Location = new System.Drawing.Point(90, 45);
            this.lblInfoIncarcaEmailuri.Name = "lblInfoIncarcaEmailuri";
            this.lblInfoIncarcaEmailuri.Size = new System.Drawing.Size(104, 13);
            this.lblInfoIncarcaEmailuri.TabIndex = 3;
            this.lblInfoIncarcaEmailuri.Text = "Va rugam asteptati...";
            this.lblInfoIncarcaEmailuri.ToolTipText = null;
            this.lblInfoIncarcaEmailuri.ToolTipTitle = null;
            // 
            // FormExtrageEmailuri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 177);
            this.Controls.Add(this.lblInfoIncarcaEmailuri);
            this.Controls.Add(this.pbIncarcaEmailuri);
            this.Name = "FormExtrageEmailuri";
            this.Text = "FormExtrageEmailuri";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.pbIncarcaEmailuri, 0);
            this.Controls.SetChildIndex(this.lblInfoIncarcaEmailuri, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbIncarcaEmailuri;
        private CCL.UI.LabelPersonalizat lblInfoIncarcaEmailuri;
    }
}