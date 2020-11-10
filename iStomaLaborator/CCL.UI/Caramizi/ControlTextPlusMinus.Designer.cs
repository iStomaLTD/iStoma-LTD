namespace CCL.UI.Caramizi
{
    partial class ControlTextPlusMinus
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
            this.txtValoare = new CCL.UI.MaskedTextBoxPersonalizat(this.components);
            this.btnPlus = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnMinus = new CCL.UI.ButtonPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // txtValoare
            // 
            this.txtValoare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValoare.BackColor = System.Drawing.SystemColors.Window;
            this.txtValoare.Location = new System.Drawing.Point(0, 1);
            this.txtValoare.Name = "txtValoare";
            this.txtValoare.ProprietateCorespunzatoare = null;
            this.txtValoare.Size = new System.Drawing.Size(32, 20);
            this.txtValoare.TabIndex = 0;
            this.txtValoare.Text = "0.00";
            this.txtValoare.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.txtValoare.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtValoare.ValoareDouble = 0D;
            this.txtValoare.AfterUpdate += new CCL.UI.MaskedTextBoxPersonalizat.ValoareModificata(this.txtValoare_AfterUpdate);
            // 
            // btnPlus
            // 
            this.btnPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPlus.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnPlus.Image = global::CCL.UI.Properties.Resources.plus;
            this.btnPlus.Location = new System.Drawing.Point(36, 1);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(26, 20);
            this.btnPlus.TabIndex = 1;
            this.btnPlus.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnPlus.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMinus.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnMinus.Image = global::CCL.UI.Properties.Resources.minus;
            this.btnMinus.Location = new System.Drawing.Point(66, 1);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(26, 20);
            this.btnMinus.TabIndex = 2;
            this.btnMinus.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnMinus.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // ControlTextPlusMinus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.txtValoare);
            this.MinimumSize = new System.Drawing.Size(94, 22);
            this.Name = "ControlTextPlusMinus";
            this.Size = new System.Drawing.Size(94, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaskedTextBoxPersonalizat txtValoare;
        private ButtonPersonalizat btnPlus;
        private ButtonPersonalizat btnMinus;
    }
}
