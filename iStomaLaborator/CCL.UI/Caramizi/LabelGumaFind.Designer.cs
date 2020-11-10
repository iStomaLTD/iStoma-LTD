using ILL.iStomaLab;
using CDL.iStomaLab;
using static CDL.iStomaLab.CDefinitiiComune;

namespace CCL.UI.Caramizi
{
    partial class LabelGumaFind
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabelGumaFind));
            this.btnAfiseazaDetalii = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnGuma = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblText = new CCL.UI.LabelPersonalizat(this.components);
            this.btnCautare = new CCL.UI.ButtonPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // btnAfiseazaDetalii
            // 
            this.btnAfiseazaDetalii.BackColor = System.Drawing.SystemColors.Control;
            this.btnAfiseazaDetalii.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAfiseazaDetalii.GenulTextului = EnumSex.Barbatesc;
            this.btnAfiseazaDetalii.Image = ((System.Drawing.Image)(resources.GetObject("btnAfiseazaDetalii.Image")));
            this.btnAfiseazaDetalii.Location = new System.Drawing.Point(28, 0);
            this.btnAfiseazaDetalii.Name = "btnAfiseazaDetalii";
            this.btnAfiseazaDetalii.Selectat = false;
            this.btnAfiseazaDetalii.Size = new System.Drawing.Size(23, 19);
            this.btnAfiseazaDetalii.TabIndex = 1;
            this.btnAfiseazaDetalii.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.DetaliiPopUp;
            this.btnAfiseazaDetalii.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnAfiseazaDetalii.ToolTipMessage = "";
            this.btnAfiseazaDetalii.ToolTipTitle = "";
            this.btnAfiseazaDetalii.UseVisualStyleBackColor = true;
            this.btnAfiseazaDetalii.Click += new System.EventHandler(this.btnAfiseazaDetalii_Click);
            // 
            // btnGuma
            // 
            this.btnGuma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuma.BackColor = System.Drawing.SystemColors.Control;
            this.btnGuma.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGuma.GenulTextului = EnumSex.Barbatesc;
            this.btnGuma.Image = ((System.Drawing.Image)(resources.GetObject("btnGuma.Image")));
            this.btnGuma.Location = new System.Drawing.Point(207, 0);
            this.btnGuma.Name = "btnGuma";
            this.btnGuma.Selectat = false;
            this.btnGuma.Size = new System.Drawing.Size(23, 19);
            this.btnGuma.TabIndex = 3;
            this.btnGuma.TabStop = false;
            this.btnGuma.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Guma;
            this.btnGuma.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnGuma.ToolTipMessage = "";
            this.btnGuma.ToolTipTitle = "";
            this.btnGuma.UseVisualStyleBackColor = true;
            this.btnGuma.Click += new System.EventHandler(this.btnGuma_Click);
            // 
            // lblText
            // 
            this.lblText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblText.HideSelection = true;
            this.lblText.IsInReadOnlyMode = true;
            this.lblText.Location = new System.Drawing.Point(55, 0);
            this.lblText.Name = "lblText";
            this.lblText.ProprietateCorespunzatoare = "";
            this.lblText.SelectedText = "";
            this.lblText.SelectionLength = 0;
            this.lblText.SelectionStart = 0;
            this.lblText.Size = new System.Drawing.Size(148, 19);
            this.lblText.TabIndex = 2;
            this.lblText.Text = "...";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblText.ToolTipText = null;
            this.lblText.ToolTipTitle = null;
            this.lblText.Enter += new System.EventHandler(this.lblText_Enter);
            // 
            // btnCautare
            // 
            this.btnCautare.BackColor = System.Drawing.SystemColors.Control;
            this.btnCautare.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCautare.GenulTextului = EnumSex.Barbatesc;
            this.btnCautare.Location = new System.Drawing.Point(0, 0);
            this.btnCautare.Margin = new System.Windows.Forms.Padding(0);
            this.btnCautare.Name = "btnCautare";
            this.btnCautare.Selectat = false;
            this.btnCautare.Size = new System.Drawing.Size(23, 19);
            this.btnCautare.TabIndex = 0;
            this.btnCautare.Text = "...";
            this.btnCautare.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnCautare.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnCautare.ToolTipMessage = "";
            this.btnCautare.ToolTipTitle = "";
            this.btnCautare.UseVisualStyleBackColor = true;
            this.btnCautare.Click += new System.EventHandler(this.btnCautare_Click);
            // 
            // LabelGumaFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAfiseazaDetalii);
            this.Controls.Add(this.btnGuma);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.btnCautare);
            this.Name = "LabelGumaFind";
            this.Size = new System.Drawing.Size(231, 20);
            this.ResumeLayout(false);

        }

        #endregion

        private ButtonPersonalizat btnGuma;
        private LabelPersonalizat lblText;
        private ButtonPersonalizat btnCautare;
        private ButtonPersonalizat btnAfiseazaDetalii;
    }
}
