using ILL.iStomaLab; using CDL.iStomaLab;
namespace CCL.UI.Caramizi
{
    partial class MaskedTextBoxGuma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaskedTextBoxGuma));
            this.btnGuma = new CCL.UI.ButtonPersonalizat(this.components);
            this.txtInformatieUtila = new CCL.UI.MaskedTextBoxPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // btnGuma
            // 
            this.btnGuma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuma.BackColor = System.Drawing.Color.Transparent;
            this.btnGuma.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGuma.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnGuma.Image = ((System.Drawing.Image)(resources.GetObject("btnGuma.Image")));
            this.btnGuma.Location = new System.Drawing.Point(110, 1);
            this.btnGuma.Name = "btnGuma";
            this.btnGuma.Size = new System.Drawing.Size(20, 20);
            this.btnGuma.TabIndex = 1;
            this.btnGuma.TabStop = false;
            this.btnGuma.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Guma;
            this.btnGuma.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnGuma.UseVisualStyleBackColor = false;
            this.btnGuma.Click += new System.EventHandler(this.btnGuma_Click);
            // 
            // txtInformatieUtila
            // 
            this.txtInformatieUtila.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInformatieUtila.BackColor = System.Drawing.SystemColors.Window;
            this.txtInformatieUtila.HidePromptOnLeave = true;
            this.txtInformatieUtila.Location = new System.Drawing.Point(0, 1);
            this.txtInformatieUtila.Name = "txtInformatieUtila";
            this.txtInformatieUtila.ProprietateCorespunzatoare = null;
            this.txtInformatieUtila.Size = new System.Drawing.Size(107, 20);
            this.txtInformatieUtila.TabIndex = 0;
            this.txtInformatieUtila.Text = "0";
            this.txtInformatieUtila.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.txtInformatieUtila.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtInformatieUtila.ValoareDouble = 0D;
            this.txtInformatieUtila.AfterUpdate += new CCL.UI.MaskedTextBoxPersonalizat.ValoareModificata(this.txtInformatieUtila_AfterUpdate);
            this.txtInformatieUtila.CNPModificat += new CCL.UI.MaskedTextBoxPersonalizat.EventCNPModificat(this.txtInformatieUtila_CNPModificat);
            this.txtInformatieUtila.Enter += new System.EventHandler(this.txtInformatieUtila_Enter);
            this.txtInformatieUtila.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInformatieUtila_KeyPress);
            this.txtInformatieUtila.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtInformatieUtila_KeyUp);
            // 
            // MaskedTextBoxGuma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGuma);
            this.Controls.Add(this.txtInformatieUtila);
            this.Size = new System.Drawing.Size(134, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ButtonPersonalizat btnGuma;
        private MaskedTextBoxPersonalizat txtInformatieUtila;
    }
}
