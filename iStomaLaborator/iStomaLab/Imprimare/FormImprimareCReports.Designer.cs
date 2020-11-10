namespace iStomaLab.Imprimare
{
    partial class FormImprimareCReports
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
            this.crvImprimare = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(1082, 19);
            this.lblTitluEcran.Text = "FormImprimareCReports";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(1059, 0);
            // 
            // crvImprimare
            // 
            this.crvImprimare.ActiveViewIndex = -1;
            this.crvImprimare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvImprimare.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvImprimare.Location = new System.Drawing.Point(0, 20);
            this.crvImprimare.Name = "crvImprimare";
            this.crvImprimare.Size = new System.Drawing.Size(1082, 584);
            this.crvImprimare.TabIndex = 0;
            // 
            // FormImprimareCReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 605);
            this.Controls.Add(this.crvImprimare);
            this.MaximumSize = new System.Drawing.Size(1082, 605);
            this.Name = "FormImprimareCReports";
            this.Text = "FormImprimareCReports";
            this.Controls.SetChildIndex(this.crvImprimare, 0);
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvImprimare;
    }
}