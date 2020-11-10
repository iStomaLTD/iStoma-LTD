namespace CCL.UI.Caramizi
{
    partial class ControlSelectieAn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlSelectieAn));
            this.btnInainte = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnInapoi = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblAn = new CCL.UI.LabelPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // btnInainte
            // 
            this.btnInainte.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnInainte.Image = ((System.Drawing.Image)(resources.GetObject("btnInainte.Image")));
            this.btnInainte.Location = new System.Drawing.Point(2, 2);
            this.btnInainte.Name = "btnInainte";
            this.btnInainte.Size = new System.Drawing.Size(30, 23);
            this.btnInainte.TabIndex = 0;
            this.btnInainte.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Stanga;
            this.btnInainte.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnInainte.UseVisualStyleBackColor = true;
            // 
            // btnInapoi
            // 
            this.btnInapoi.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnInapoi.Image = ((System.Drawing.Image)(resources.GetObject("btnInapoi.Image")));
            this.btnInapoi.Location = new System.Drawing.Point(101, 2);
            this.btnInapoi.Name = "btnInapoi";
            this.btnInapoi.Size = new System.Drawing.Size(30, 23);
            this.btnInapoi.TabIndex = 1;
            this.btnInapoi.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Dreapta;
            this.btnInapoi.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnInapoi.UseVisualStyleBackColor = true;
            // 
            // lblAn
            // 
            this.lblAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAn.Location = new System.Drawing.Point(39, 2);
            this.lblAn.Name = "lblAn";
            this.lblAn.Size = new System.Drawing.Size(56, 23);
            this.lblAn.TabIndex = 2;
            this.lblAn.Text = "1983";
            this.lblAn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAn.ToolTipText = null;
            this.lblAn.ToolTipTitle = null;
            // 
            // ControlSelectieAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblAn);
            this.Controls.Add(this.btnInapoi);
            this.Controls.Add(this.btnInainte);
            this.Size = new System.Drawing.Size(133, 27);
            this.ResumeLayout(false);

        }

        #endregion

        private ButtonPersonalizat btnInainte;
        private ButtonPersonalizat btnInapoi;
        private LabelPersonalizat lblAn;
    }
}
