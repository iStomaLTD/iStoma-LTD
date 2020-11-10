namespace CCL.UI.Caramizi
{
    partial class TextBoxGumaFind
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
            this.btnFind = new CCL.UI.ButtonPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // txtInformatieUtila
            // 
            this.txtInformatieUtila.Location = new System.Drawing.Point(25, 0);
            this.txtInformatieUtila.Size = new System.Drawing.Size(174, 20);
            this.txtInformatieUtila.TabIndex = 2;
            // 
            // btnGuma
            // 
            this.btnGuma.Location = new System.Drawing.Point(201, 0);
            this.btnGuma.Size = new System.Drawing.Size(23, 20);
            this.btnGuma.TabStop = false;
            // 
            // btnFind
            // 
            this.btnFind.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFind.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnFind.Image = null;
            this.btnFind.Location = new System.Drawing.Point(0, 0);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(23, 20);
            this.btnFind.TabIndex = 1;
            this.btnFind.Text = "...";
            this.btnFind.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Cautare;
            this.btnFind.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // TextBoxGumaFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFind);
            this.Name = "TextBoxGumaFind";
            this.Size = new System.Drawing.Size(225, 20);
            this.Controls.SetChildIndex(this.btnGuma, 0);
            this.Controls.SetChildIndex(this.txtInformatieUtila, 0);
            this.Controls.SetChildIndex(this.btnFind, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ButtonPersonalizat btnFind;
    }
}
