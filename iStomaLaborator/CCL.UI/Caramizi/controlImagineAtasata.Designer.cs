namespace CCL.UI.Caramizi
{
    partial class controlImagineAtasata
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(controlImagineAtasata));
            this.picPoza = new CCL.UI.PictureBoxPersonalizat(this.components);
            this.btnCautaPoza = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnStergeImagine = new CCL.UI.ButtonPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picPoza)).BeginInit();
            this.SuspendLayout();
            // 
            // picPoza
            // 
            this.picPoza.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picPoza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPoza.ContinutToolTip = null;
            this.picPoza.IcoanaToolTip = System.Windows.Forms.ToolTipIcon.Info;
            this.picPoza.Location = new System.Drawing.Point(0, 0);
            this.picPoza.Name = "picPoza";
            this.picPoza.Size = new System.Drawing.Size(83, 97);
            this.picPoza.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPoza.TabIndex = 0;
            this.picPoza.TabStop = false;
            this.picPoza.TitluToolTip = "";
            this.picPoza.UtilizamToolTip = false;
            this.picPoza.Paint += new System.Windows.Forms.PaintEventHandler(this.picPoza_Paint);
            this.picPoza.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picPoza_MouseClick);
            this.picPoza.MouseEnter += new System.EventHandler(this.picPoza_MouseEnter);
            this.picPoza.MouseLeave += new System.EventHandler(this.picPoza_MouseLeave);
            // 
            // btnCautaPoza
            // 
            this.btnCautaPoza.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCautaPoza.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCautaPoza.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnCautaPoza.Image = ((System.Drawing.Image)(resources.GetObject("btnCautaPoza.Image")));
            this.btnCautaPoza.Location = new System.Drawing.Point(2, 100);
            this.btnCautaPoza.Name = "btnCautaPoza";
            this.btnCautaPoza.Size = new System.Drawing.Size(38, 24);
            this.btnCautaPoza.TabIndex = 1;
            this.btnCautaPoza.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Deschide;
            this.btnCautaPoza.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnCautaPoza.UseVisualStyleBackColor = true;
            this.btnCautaPoza.Click += new System.EventHandler(this.btnCautaPoza_Click);
            // 
            // btnStergeImagine
            // 
            this.btnStergeImagine.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnStergeImagine.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnStergeImagine.Image = ((System.Drawing.Image)(resources.GetObject("btnStergeImagine.Image")));
            this.btnStergeImagine.Location = new System.Drawing.Point(44, 100);
            this.btnStergeImagine.Name = "btnStergeImagine";
            this.btnStergeImagine.Size = new System.Drawing.Size(38, 24);
            this.btnStergeImagine.TabIndex = 2;
            this.btnStergeImagine.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Stergere;
            this.btnStergeImagine.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnStergeImagine.UseVisualStyleBackColor = true;
            this.btnStergeImagine.Click += new System.EventHandler(this.btnStergeImagine_Click);
            // 
            // controlImagineAtasata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnStergeImagine);
            this.Controls.Add(this.btnCautaPoza);
            this.Controls.Add(this.picPoza);
            this.Name = "controlImagineAtasata";
            this.Size = new System.Drawing.Size(83, 126);
            ((System.ComponentModel.ISupportInitialize)(this.picPoza)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBoxPersonalizat picPoza;
        private ButtonPersonalizat btnCautaPoza;
        private ButtonPersonalizat btnStergeImagine;
    }
}
