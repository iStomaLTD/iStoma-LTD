namespace CCL.UI.Caramizi
{
    partial class controlLeiEuro
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
            this.rbLei = new CCL.UI.RadioButtonPersonalizat(this.components);
            this.rbEuro = new CCL.UI.RadioButtonPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // rbLei
            // 
            this.rbLei.AutoSize = true;
            this.rbLei.Location = new System.Drawing.Point(4, 4);
            this.rbLei.Name = "rbLei";
            this.rbLei.Size = new System.Drawing.Size(41, 17);
            this.rbLei.TabIndex = 0;
            this.rbLei.TabStop = true;
            this.rbLei.Text = "LEI";
            this.rbLei.UseVisualStyleBackColor = true;
            this.rbLei.CheckedChanged += new System.EventHandler(this.rbLei_CheckedChanged);
            // 
            // rbEuro
            // 
            this.rbEuro.AutoSize = true;
            this.rbEuro.Location = new System.Drawing.Point(63, 4);
            this.rbEuro.Name = "rbEuro";
            this.rbEuro.Size = new System.Drawing.Size(48, 17);
            this.rbEuro.TabIndex = 1;
            this.rbEuro.TabStop = true;
            this.rbEuro.Text = "EUR";
            this.rbEuro.UseVisualStyleBackColor = true;
            this.rbEuro.CheckedChanged += new System.EventHandler(this.rbEuro_CheckedChanged);
            // 
            // controlLeiEuro
            // 
            this.Controls.Add(this.rbLei);
            this.Controls.Add(this.rbEuro);
            this.Name = "controlLeiEuro";
            this.Size = new System.Drawing.Size(139, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RadioButtonPersonalizat rbLei;
        private RadioButtonPersonalizat rbEuro;
    }
}
