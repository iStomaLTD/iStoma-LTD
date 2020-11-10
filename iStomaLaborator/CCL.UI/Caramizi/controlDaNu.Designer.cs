namespace CCL.UI.Caramizi
{
    partial class controlDaNu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.chkDa = new CCL.UI.CheckBoxPersonalizat(this.components);
            this.chkNu = new CCL.UI.CheckBoxPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // chkDa
            // 
            this.chkDa.AutoSize = true;
            this.chkDa.IsInReadOnlyMode = false;
            this.chkDa.Location = new System.Drawing.Point(4, 4);
            this.chkDa.Name = "chkDa";
            this.chkDa.ProprietateCorespunzatoare = null;
            this.chkDa.Size = new System.Drawing.Size(40, 17);
            this.chkDa.TabIndex = 0;
            this.chkDa.Text = "Da";
            this.chkDa.UseVisualStyleBackColor = true;
            this.chkDa.CheckedChanged += new System.EventHandler(this.chkDa_CheckedChanged);
            // 
            // chkNu
            // 
            this.chkNu.AutoSize = true;
            this.chkNu.IsInReadOnlyMode = false;
            this.chkNu.Location = new System.Drawing.Point(66, 4);
            this.chkNu.Name = "chkNu";
            this.chkNu.ProprietateCorespunzatoare = null;
            this.chkNu.Size = new System.Drawing.Size(40, 17);
            this.chkNu.TabIndex = 1;
            this.chkNu.Text = "Nu";
            this.chkNu.UseVisualStyleBackColor = true;
            this.chkNu.CheckedChanged += new System.EventHandler(this.chkNu_CheckedChanged);
            // 
            // controlDaNu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.chkNu);
            this.Controls.Add(this.chkDa);
            this.Name = "controlDaNu";
            this.Size = new System.Drawing.Size(125, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBoxPersonalizat chkDa;
        private CheckBoxPersonalizat chkNu;
    }
}
