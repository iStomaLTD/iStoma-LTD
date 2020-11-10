namespace iStomaLab.Caramizi
{
    partial class controlCreare
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
            this.lblDataCreare = new CCL.UI.LabelPersonalizat(this.components);
            this.lblNumeUtilizator = new CCL.UI.LabelPersonalizat(this.components);
            this.txtDataCreare = new CCL.UI.Caramizi.TextBoxGuma();
            this.btnAccesIstoric = new CCL.UI.ButtonPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // lblDataCreare
            // 
            this.lblDataCreare.AutoSize = true;
            this.lblDataCreare.Location = new System.Drawing.Point(3, 9);
            this.lblDataCreare.Name = "lblDataCreare";
            this.lblDataCreare.Size = new System.Drawing.Size(78, 13);
            this.lblDataCreare.TabIndex = 0;
            this.lblDataCreare.Text = "Data de creare";
            this.lblDataCreare.ToolTipText = null;
            this.lblDataCreare.ToolTipTitle = null;
            // 
            // lblNumeUtilizator
            // 
            this.lblNumeUtilizator.AutoSize = true;
            this.lblNumeUtilizator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumeUtilizator.Location = new System.Drawing.Point(3, 34);
            this.lblNumeUtilizator.Name = "lblNumeUtilizator";
            this.lblNumeUtilizator.Size = new System.Drawing.Size(135, 13);
            this.lblNumeUtilizator.TabIndex = 2;
            this.lblNumeUtilizator.Text = "Botorogeanu Ionut Richard";
            this.lblNumeUtilizator.ToolTipText = null;
            this.lblNumeUtilizator.ToolTipTitle = null;
            // 
            // txtDataCreare
            // 
            this.txtDataCreare.AcceptButton = null;
            this.txtDataCreare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataCreare.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtDataCreare.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtDataCreare.IsInReadOnlyMode = true;
            this.txtDataCreare.Location = new System.Drawing.Point(93, 5);
            this.txtDataCreare.MaxLength = 32767;
            this.txtDataCreare.Multiline = false;
            this.txtDataCreare.Name = "txtDataCreare";
            this.txtDataCreare.ProprietateCorespunzatoare = null;
            this.txtDataCreare.RaiseEventLaModificareProgramatica = false;
            this.txtDataCreare.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDataCreare.Size = new System.Drawing.Size(109, 20);
            this.txtDataCreare.TabIndex = 1;
            this.txtDataCreare.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtDataCreare.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtDataCreare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtDataCreare.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtDataCreare.UseSystemPasswordChar = false;
            this.txtDataCreare.UtilizeazaButonGuma = false;
            // 
            // btnAccesIstoric
            // 
            this.btnAccesIstoric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccesIstoric.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAccesIstoric.Image = null;
            this.btnAccesIstoric.Location = new System.Drawing.Point(179, 29);
            this.btnAccesIstoric.Name = "btnAccesIstoric";
            this.btnAccesIstoric.Size = new System.Drawing.Size(23, 23);
            this.btnAccesIstoric.TabIndex = 3;
            this.btnAccesIstoric.Text = "H";
            this.btnAccesIstoric.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Istoric;
            this.btnAccesIstoric.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAccesIstoric.UseVisualStyleBackColor = true;
            this.btnAccesIstoric.Visible = false;
            // 
            // controlCreare
            // 
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnAccesIstoric);
            this.Controls.Add(this.txtDataCreare);
            this.Controls.Add(this.lblNumeUtilizator);
            this.Controls.Add(this.lblDataCreare);
            this.Name = "controlCreare";
            this.Size = new System.Drawing.Size(206, 55);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.LabelPersonalizat lblDataCreare;
        private CCL.UI.LabelPersonalizat lblNumeUtilizator;
        private CCL.UI.Caramizi.TextBoxGuma txtDataCreare;
        private CCL.UI.ButtonPersonalizat btnAccesIstoric;
    }
}
