namespace iStomaLab.Caramizi
{
    partial class ControlCautareDupaTextClinica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlCautareDupaTextClinica));
            this.txtCautare = new CCL.UI.Caramizi.TextBoxCautare();
            this.lblDenumire = new CCL.UI.LabelPersonalizat(this.components);
            this.btnSterge = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnDeschide = new CCL.UI.ButtonPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // txtCautare
            // 
            this.txtCautare.AcceptButton = null;
            this.txtCautare.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautare.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautare.BackColor = System.Drawing.Color.White;
            this.txtCautare.CapitalizeazaPrimaLitera = false;
            this.txtCautare.IsInReadOnlyMode = false;
            this.txtCautare.Location = new System.Drawing.Point(151, 2);
            this.txtCautare.MaxLength = 32767;
            this.txtCautare.Multiline = false;
            this.txtCautare.Name = "txtCautare";
            this.txtCautare.ProprietateCorespunzatoare = null;
            this.txtCautare.RaiseEventLaModificareProgramatica = false;
            this.txtCautare.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautare.Size = new System.Drawing.Size(136, 20);
            this.txtCautare.TabIndex = 0;
            this.txtCautare.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautare.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautare.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautare.UseSystemPasswordChar = false;
            this.txtCautare.UtilizeazaButonGuma = false;
            this.txtCautare.Visible = false;
            // 
            // lblDenumire
            // 
            this.lblDenumire.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDenumire.Location = new System.Drawing.Point(28, 2);
            this.lblDenumire.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.lblDenumire.MinimumSize = new System.Drawing.Size(50, 21);
            this.lblDenumire.Name = "lblDenumire";
            this.lblDenumire.Size = new System.Drawing.Size(95, 21);
            this.lblDenumire.TabIndex = 2;
            this.lblDenumire.Text = "Botorogeanu";
            this.lblDenumire.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDenumire.ToolTipText = null;
            this.lblDenumire.ToolTipTitle = null;
            this.lblDenumire.Visible = false;
            // 
            // btnSterge
            // 
            this.btnSterge.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSterge.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnSterge.Image = ((System.Drawing.Image)(resources.GetObject("btnSterge.Image")));
            this.btnSterge.Location = new System.Drawing.Point(126, 2);
            this.btnSterge.Name = "btnSterge";
            this.btnSterge.Size = new System.Drawing.Size(22, 21);
            this.btnSterge.TabIndex = 3;
            this.btnSterge.TabStop = false;
            this.btnSterge.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Guma;
            this.btnSterge.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnSterge.UseVisualStyleBackColor = true;
            this.btnSterge.Visible = false;
            // 
            // btnDeschide
            // 
            this.btnDeschide.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeschide.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnDeschide.Image = null;
            this.btnDeschide.Location = new System.Drawing.Point(3, 2);
            this.btnDeschide.Name = "btnDeschide";
            this.btnDeschide.Size = new System.Drawing.Size(22, 21);
            this.btnDeschide.TabIndex = 1;
            this.btnDeschide.TabStop = false;
            this.btnDeschide.Text = "...";
            this.btnDeschide.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Cautare;
            this.btnDeschide.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnDeschide.UseVisualStyleBackColor = true;
            // 
            // ControlCautareDupaTextClinica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDeschide);
            this.Controls.Add(this.txtCautare);
            this.Controls.Add(this.lblDenumire);
            this.Controls.Add(this.btnSterge);
            this.Name = "ControlCautareDupaTextClinica";
            this.Size = new System.Drawing.Size(290, 24);
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.Caramizi.TextBoxCautare txtCautare;
        private CCL.UI.LabelPersonalizat lblDenumire;
        private CCL.UI.ButtonPersonalizat btnSterge;
        private CCL.UI.ButtonPersonalizat btnDeschide;
    }
}
