namespace iStomaLab.Caramizi
{
    partial class ControlSex
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
            this.chkSexF = new CCL.UI.CheckBoxPersonalizat(this.components);
            this.chkSexM = new CCL.UI.CheckBoxPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // chkSexF
            // 
            this.chkSexF.AutoSize = true;
            this.chkSexF.IsInReadOnlyMode = false;
            this.chkSexF.Location = new System.Drawing.Point(44, 3);
            this.chkSexF.Name = "chkSexF";
            this.chkSexF.ProprietateCorespunzatoare = null;
            this.chkSexF.Size = new System.Drawing.Size(32, 17);
            this.chkSexF.TabIndex = 13;
            this.chkSexF.Text = "F";
            this.chkSexF.UseVisualStyleBackColor = true;
            // 
            // chkSexM
            // 
            this.chkSexM.AutoSize = true;
            this.chkSexM.IsInReadOnlyMode = false;
            this.chkSexM.Location = new System.Drawing.Point(3, 3);
            this.chkSexM.Name = "chkSexM";
            this.chkSexM.ProprietateCorespunzatoare = null;
            this.chkSexM.Size = new System.Drawing.Size(35, 17);
            this.chkSexM.TabIndex = 12;
            this.chkSexM.Text = "M";
            this.chkSexM.UseVisualStyleBackColor = true;
            // 
            // ControlSex
            // 
            this.Controls.Add(this.chkSexF);
            this.Controls.Add(this.chkSexM);
            this.Name = "ControlSex";
            this.Size = new System.Drawing.Size(80, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.CheckBoxPersonalizat chkSexF;
        private CCL.UI.CheckBoxPersonalizat chkSexM;
    }
}
