namespace iStomaLab.Marketing
{
    partial class ControlMarketingTrimitereEmail
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
            this.lblTitlu = new CCL.UI.LabelPersonalizat(this.components);
            this.lblTemplate = new CCL.UI.LabelPersonalizat(this.components);
            this.cmbTemplate = new CCL.UI.ComboBoxPersonalizat(this.components);
            this.btnSave = new CCL.UI.ButtonPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // lblTitlu
            // 
            this.lblTitlu.AutoSize = true;
            this.lblTitlu.Location = new System.Drawing.Point(3, 4);
            this.lblTitlu.Name = "lblTitlu";
            this.lblTitlu.Size = new System.Drawing.Size(74, 13);
            this.lblTitlu.TabIndex = 1;
            this.lblTitlu.Text = "Trimitere email";
            this.lblTitlu.ToolTipText = null;
            this.lblTitlu.ToolTipTitle = null;
            // 
            // lblTemplate
            // 
            this.lblTemplate.AutoSize = true;
            this.lblTemplate.Location = new System.Drawing.Point(6, 25);
            this.lblTemplate.Name = "lblTemplate";
            this.lblTemplate.Size = new System.Drawing.Size(51, 13);
            this.lblTemplate.TabIndex = 2;
            this.lblTemplate.Text = "Template";
            this.lblTemplate.ToolTipText = null;
            this.lblTemplate.ToolTipTitle = null;
            // 
            // cmbTemplate
            // 
            this.cmbTemplate.AutoCompletePersonalizat = false;
            this.cmbTemplate.FormattingEnabled = true;
            this.cmbTemplate.HideSelection = true;
            this.cmbTemplate.IsInReadOnlyMode = false;
            this.cmbTemplate.Location = new System.Drawing.Point(79, 25);
            this.cmbTemplate.Name = "cmbTemplate";
            this.cmbTemplate.ProprietateCorespunzatoare = null;
            this.cmbTemplate.Size = new System.Drawing.Size(158, 21);
            this.cmbTemplate.TabIndex = 3;
            this.cmbTemplate.TipulListei = CCL.UI.ComboBoxPersonalizat.EnumTipLista.Nespecificat;
            // 
            // btnSave
            // 
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSave.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnSave.Image = null;
            this.btnSave.Location = new System.Drawing.Point(244, 22);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Salveaza";
            this.btnSave.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnSave.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // ControlMarketingTrimitereEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbTemplate);
            this.Controls.Add(this.lblTemplate);
            this.Controls.Add(this.lblTitlu);
            this.Name = "ControlMarketingTrimitereEmail";
            this.Size = new System.Drawing.Size(540, 450);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.LabelPersonalizat lblTitlu;
        private CCL.UI.LabelPersonalizat lblTemplate;
        private CCL.UI.ComboBoxPersonalizat cmbTemplate;
        private CCL.UI.ButtonPersonalizat btnSave;
    }
}
