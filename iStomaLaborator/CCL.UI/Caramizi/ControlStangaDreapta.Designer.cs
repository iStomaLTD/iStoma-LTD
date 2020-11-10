namespace CCL.UI.Caramizi
{
    partial class ControlStangaDreapta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlStangaDreapta));
            this.btnStanga = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnDreapta = new CCL.UI.ButtonPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // btnStanga
            // 
            this.btnStanga.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnStanga.Image = ((System.Drawing.Image)(resources.GetObject("btnStanga.Image")));
            this.btnStanga.Location = new System.Drawing.Point(0, 0);
            this.btnStanga.Name = "btnStanga";
            this.btnStanga.Size = new System.Drawing.Size(57, 23);
            this.btnStanga.TabIndex = 0;
            this.btnStanga.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Stanga;
            this.btnStanga.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnStanga.UseVisualStyleBackColor = true;
            this.btnStanga.Click += new System.EventHandler(this.btnStanga_Click);
            // 
            // btnDreapta
            // 
            this.btnDreapta.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnDreapta.Image = ((System.Drawing.Image)(resources.GetObject("btnDreapta.Image")));
            this.btnDreapta.Location = new System.Drawing.Point(63, 0);
            this.btnDreapta.Name = "btnDreapta";
            this.btnDreapta.Size = new System.Drawing.Size(57, 23);
            this.btnDreapta.TabIndex = 1;
            this.btnDreapta.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Dreapta;
            this.btnDreapta.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnDreapta.UseVisualStyleBackColor = true;
            this.btnDreapta.Click += new System.EventHandler(this.btnDreapta_Click);
            // 
            // ControlStangaDreapta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDreapta);
            this.Controls.Add(this.btnStanga);
            this.Name = "ControlStangaDreapta";
            this.Size = new System.Drawing.Size(121, 24);
            this.ResumeLayout(false);

        }

        #endregion

        private ButtonPersonalizat btnStanga;
        private ButtonPersonalizat btnDreapta;
    }
}
