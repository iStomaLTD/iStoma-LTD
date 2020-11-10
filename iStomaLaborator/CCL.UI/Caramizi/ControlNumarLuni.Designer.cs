namespace CCL.UI.Caramizi
{
    partial class ControlNumarLuni
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
            this.lblLuni = new CCL.UI.LabelPersonalizat(this.components);
            this.txtNrLuni = new CCL.UI.Caramizi.TextBoxCautare();
            this.SuspendLayout();
            // 
            // lblLuni
            // 
            this.lblLuni.AutoSize = true;
            this.lblLuni.Location = new System.Drawing.Point(75, 5);
            this.lblLuni.Name = "lblLuni";
            this.lblLuni.Size = new System.Drawing.Size(23, 13);
            this.lblLuni.TabIndex = 10;
            this.lblLuni.Text = "luni";
            this.lblLuni.ToolTipText = null;
            this.lblLuni.ToolTipTitle = null;
            // 
            // txtNrLuni
            // 
            this.txtNrLuni.AcceptButton = null;
            this.txtNrLuni.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtNrLuni.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtNrLuni.BackColor = System.Drawing.SystemColors.Control;
            this.txtNrLuni.IsInReadOnlyMode = false;
            this.txtNrLuni.Location = new System.Drawing.Point(3, 1);
            this.txtNrLuni.MaxLength = 32767;
            this.txtNrLuni.Multiline = false;
            this.txtNrLuni.Name = "txtNrLuni";
            this.txtNrLuni.ProprietateCorespunzatoare = null;
            this.txtNrLuni.RaiseEventLaModificareProgramatica = false;
            this.txtNrLuni.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNrLuni.Size = new System.Drawing.Size(66, 20);
            this.txtNrLuni.TabIndex = 11;
            this.txtNrLuni.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtNrLuni.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtNrLuni.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtNrLuni.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtNrLuni.UseSystemPasswordChar = false;
            this.txtNrLuni.UtilizeazaButonGuma = false;
            // 
            // ControlNumarLuni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblLuni);
            this.Controls.Add(this.txtNrLuni);
            this.MinimumSize = new System.Drawing.Size(108, 23);
            this.Name = "ControlNumarLuni";
            this.Size = new System.Drawing.Size(108, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LabelPersonalizat lblLuni;
        private TextBoxCautare txtNrLuni;
    }
}
