using ILL.iStomaLab; using CDL.iStomaLab;
namespace CCL.UI
{
    partial class controlAlegeData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(controlAlegeData));
            this.btnGuma = new CCL.UI.ButtonPersonalizat(this.components);
            this.txtData = new CCL.UI.MaskedTextBoxPersonalizat(this.components);
            this.btnAlegeData = new CCL.UI.ButtonPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // btnGuma
            // 
            this.btnGuma.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuma.BackColor = System.Drawing.SystemColors.Control;
            this.btnGuma.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGuma.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnGuma.Image = ((System.Drawing.Image)(resources.GetObject("btnGuma.Image")));
            this.btnGuma.Location = new System.Drawing.Point(145, 1);
            this.btnGuma.Name = "btnGuma";
            this.btnGuma.Selectat = false;
            this.btnGuma.Size = new System.Drawing.Size(23, 19);
            this.btnGuma.TabIndex = 3;
            this.btnGuma.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Guma;
            this.btnGuma.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnGuma.ToolTipMessage = "";
            this.btnGuma.ToolTipTitle = "";
            this.btnGuma.UseVisualStyleBackColor = true;
            this.btnGuma.Click += new System.EventHandler(this.btnGuma_Click);
            // 
            // txtData
            // 
            this.txtData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtData.BackColor = System.Drawing.SystemColors.Window;
            this.txtData.IsInReadOnlyMode = false;
            this.txtData.Location = new System.Drawing.Point(0, 1);
            this.txtData.Mask = "##-##-#### ##:##";
            this.txtData.Name = "txtData";
            this.txtData.ProprietateCorespunzatoare = null;
            this.txtData.Size = new System.Drawing.Size(118, 20);
            this.txtData.TabIndex = 1;
            this.txtData.Text = "130219831313";
            this.txtData.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.txtData.AfterUpdate += new CCL.UI.MaskedTextBoxPersonalizat.ValoareModificata(this.txtData_AfterUpdate);
            this.txtData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtData_MouseClick);
            this.txtData.Enter += new System.EventHandler(this.txtData_Enter);
            // 
            // btnAlegeData
            // 
            this.btnAlegeData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlegeData.BackColor = System.Drawing.SystemColors.Control;
            this.btnAlegeData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlegeData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAlegeData.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAlegeData.Image = ((System.Drawing.Image)(resources.GetObject("btnAlegeData.Image")));
            this.btnAlegeData.Location = new System.Drawing.Point(120, 1);
            this.btnAlegeData.Name = "btnAlegeData";
            this.btnAlegeData.Selectat = false;
            this.btnAlegeData.Size = new System.Drawing.Size(23, 19);
            this.btnAlegeData.TabIndex = 2;
            this.btnAlegeData.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAlegeData.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Calendar;
            this.btnAlegeData.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnAlegeData.ToolTipMessage = "";
            this.btnAlegeData.ToolTipTitle = "";
            this.btnAlegeData.UseVisualStyleBackColor = false;
            this.btnAlegeData.Click += new System.EventHandler(this.btnAlegeData_Click);
            this.btnAlegeData.Enter += new System.EventHandler(this.btnAlegeData_Enter);
            // 
            // controlAlegeData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGuma);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.btnAlegeData);
            this.Name = "controlAlegeData";
            this.Size = new System.Drawing.Size(169, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ButtonPersonalizat btnAlegeData;
        private MaskedTextBoxPersonalizat txtData;
        private ButtonPersonalizat btnGuma;
    }
}
