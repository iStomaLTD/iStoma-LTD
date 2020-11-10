namespace CCL.UI.Caramizi
{
    partial class controlGestiuneText
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
            this.txtTextSimplu = new CCL.UI.Caramizi.TextBoxGuma();
            this.ctrlEditorHTML = new CCL.UI.Caramizi.HTML.ControlEditorHTML();
            this.ctrlSMS = new CCL.UI.Caramizi.ControlSMS();
            this.SuspendLayout();
            // 
            // txtTextSimplu
            // 
            this.txtTextSimplu.AcceptButton = null;
            this.txtTextSimplu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTextSimplu.IsInReadOnlyMode = false;
            this.txtTextSimplu.Location = new System.Drawing.Point(-1, 0);
            this.txtTextSimplu.MaxLength = 32767;
            this.txtTextSimplu.Multiline = true;
            this.txtTextSimplu.Name = "txtTextSimplu";
            this.txtTextSimplu.ProprietateCorespunzatoare = null;
            this.txtTextSimplu.RaiseEventLaModificareProgramatica = false;
            this.txtTextSimplu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTextSimplu.Size = new System.Drawing.Size(533, 191);
            this.txtTextSimplu.TabIndex = 0;
            this.txtTextSimplu.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtTextSimplu.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtTextSimplu.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtTextSimplu.UseSystemPasswordChar = false;
            this.txtTextSimplu.Visible = false;
            // 
            // ctrlEditorHTML
            // 
            this.ctrlEditorHTML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlEditorHTML.IsContextMenuEnabled = false;
            this.ctrlEditorHTML.Location = new System.Drawing.Point(0, 0);
            this.ctrlEditorHTML.MinimumSize = new System.Drawing.Size(900, 530);
            this.ctrlEditorHTML.Name = "ctrlEditorHTML";
            this.ctrlEditorHTML.Size = new System.Drawing.Size(900, 530);
            this.ctrlEditorHTML.TabIndex = 1;
            this.ctrlEditorHTML.Visible = false;
            // 
            // ctrlSMS
            // 
            this.ctrlSMS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlSMS.Location = new System.Drawing.Point(0, 0);
            this.ctrlSMS.Name = "ctrlSMS";
            this.ctrlSMS.Size = new System.Drawing.Size(533, 191);
            this.ctrlSMS.TabIndex = 2;
            this.ctrlSMS.Visible = false;
            // 
            // controlGestiuneText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlSMS);
            this.Controls.Add(this.ctrlEditorHTML);
            this.Controls.Add(this.txtTextSimplu);
            this.Name = "controlGestiuneText";
            this.Size = new System.Drawing.Size(533, 191);
            this.ResumeLayout(false);

        }

        #endregion

        private TextBoxGuma txtTextSimplu;
        private HTML.ControlEditorHTML ctrlEditorHTML;
        private ControlSMS ctrlSMS;

    }
}
