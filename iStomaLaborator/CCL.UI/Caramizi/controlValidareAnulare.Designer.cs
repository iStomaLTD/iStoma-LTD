namespace CCL.UI.Caramizi
{
    partial class controlValidareAnulare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(controlValidareAnulare));
            this.btnValidare = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnAnulare = new CCL.UI.ButtonPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // btnValidare
            // 
            this.btnValidare.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnValidare.Image = ((System.Drawing.Image)(resources.GetObject("btnValidare.Image")));
            this.btnValidare.Location = new System.Drawing.Point(0, 0);
            this.btnValidare.Name = "btnValidare";
            this.btnValidare.Size = new System.Drawing.Size(75, 23);
            this.btnValidare.TabIndex = 0;
            this.btnValidare.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Validare;
            this.btnValidare.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnValidare.UseVisualStyleBackColor = true;
            this.btnValidare.Click += new System.EventHandler(this.btnValidare_Click);
            // 
            // btnAnulare
            // 
            this.btnAnulare.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAnulare.Image = ((System.Drawing.Image)(resources.GetObject("btnAnulare.Image")));
            this.btnAnulare.Location = new System.Drawing.Point(85, 0);
            this.btnAnulare.Name = "btnAnulare";
            this.btnAnulare.Size = new System.Drawing.Size(75, 23);
            this.btnAnulare.TabIndex = 1;
            this.btnAnulare.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Anulare;
            this.btnAnulare.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAnulare.UseVisualStyleBackColor = true;
            this.btnAnulare.Click += new System.EventHandler(this.btnAnulare_Click);
            // 
            // controlValidareAnulare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAnulare);
            this.Controls.Add(this.btnValidare);
            this.Name = "controlValidareAnulare";
            this.Size = new System.Drawing.Size(161, 23);
            this.ResumeLayout(false);

        }

        #endregion

        private ButtonPersonalizat btnValidare;
        private ButtonPersonalizat btnAnulare;
    }
}
