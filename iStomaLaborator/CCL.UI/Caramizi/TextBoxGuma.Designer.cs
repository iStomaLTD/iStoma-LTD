using ILL.iStomaLab;
using CDL.iStomaLab;
namespace CCL.UI.Caramizi
{
    partial class TextBoxGuma
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
            if (!base.IsDisposed)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextBoxGuma));
            this.txtInformatieUtila = new CCL.UI.TextBoxPersonalizat(this.components);
            this.btnGuma = new CCL.UI.ButtonPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // txtInformatieUtila
            // 
            this.txtInformatieUtila.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInformatieUtila.CapitalizeazaPrimaLitera = false;
            this.txtInformatieUtila.IsInReadOnlyMode = false;
            this.txtInformatieUtila.Location = new System.Drawing.Point(0, 0);
            this.txtInformatieUtila.Name = "txtInformatieUtila";
            this.txtInformatieUtila.ProprietateCorespunzatoare = null;
            this.txtInformatieUtila.RaiseEventLaModificareProgramatica = false;
            this.txtInformatieUtila.Size = new System.Drawing.Size(109, 20);
            this.txtInformatieUtila.TabIndex = 0;
            this.txtInformatieUtila.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtInformatieUtila.TotulCuMajuscule = false;
            this.txtInformatieUtila.AfterUpdate += new CCL.UI.TextBoxPersonalizat.ValoareModificata(this.txtInformatieUtila_AfterUpdate);
            this.txtInformatieUtila.Enter += new System.EventHandler(this.txtInformatieUtila_Enter);
            this.txtInformatieUtila.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtInformatieUtila_KeyUp);
            // 
            // btnGuma
            // 
            this.btnGuma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuma.BackColor = System.Drawing.Color.Transparent;
            this.btnGuma.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGuma.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnGuma.Image = ((System.Drawing.Image)(resources.GetObject("btnGuma.Image")));
            this.btnGuma.Location = new System.Drawing.Point(111, 0);
            this.btnGuma.Name = "btnGuma";
            this.btnGuma.Size = new System.Drawing.Size(20, 20);
            this.btnGuma.TabIndex = 3;
            this.btnGuma.TabStop = false;
            this.btnGuma.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Guma;
            this.btnGuma.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnGuma.UseVisualStyleBackColor = false;
            this.btnGuma.Click += new System.EventHandler(this.btnGuma_Click);
            // 
            // TextBoxGuma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtInformatieUtila);
            this.Controls.Add(this.btnGuma);
            this.Size = new System.Drawing.Size(134, 20);
            this.Enter += new System.EventHandler(this.TextBoxGuma_Enter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected TextBoxPersonalizat txtInformatieUtila;
        protected ButtonPersonalizat btnGuma;
    }
}
