namespace iStomaLab.ServiciiExterne
{
    partial class FormCursBNR
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.chkEuAlegCursulDeSchimb = new CCL.UI.CheckBoxPersonalizat(this.components);
            this.ctrlValidareAnulare = new CCL.UI.Caramizi.controlValidareAnulare();
            this.lblCursSchimb = new CCL.UI.LabelPersonalizat(this.components);
            this.txtCursSchimb = new CCL.UI.MaskedTextBoxPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(238, 19);
            this.lblTitluEcran.Text = "FormCursBNR";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(237, 0);
            // 
            // chkEuAlegCursulDeSchimb
            // 
            this.chkEuAlegCursulDeSchimb.AutoSize = true;
            this.chkEuAlegCursulDeSchimb.IsInReadOnlyMode = false;
            this.chkEuAlegCursulDeSchimb.Location = new System.Drawing.Point(12, 35);
            this.chkEuAlegCursulDeSchimb.Name = "chkEuAlegCursulDeSchimb";
            this.chkEuAlegCursulDeSchimb.ProprietateCorespunzatoare = null;
            this.chkEuAlegCursulDeSchimb.Size = new System.Drawing.Size(144, 17);
            this.chkEuAlegCursulDeSchimb.TabIndex = 2;
            this.chkEuAlegCursulDeSchimb.Text = "Eu aleg cursul de schimb";
            this.chkEuAlegCursulDeSchimb.UseVisualStyleBackColor = true;
            // 
            // ctrlValidareAnulare
            // 
            this.ctrlValidareAnulare.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrlValidareAnulare.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulare.Location = new System.Drawing.Point(50, 125);
            this.ctrlValidareAnulare.Name = "ctrlValidareAnulare";
            this.ctrlValidareAnulare.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulare.TabIndex = 3;
            // 
            // lblCursSchimb
            // 
            this.lblCursSchimb.AutoSize = true;
            this.lblCursSchimb.Location = new System.Drawing.Point(45, 69);
            this.lblCursSchimb.Name = "lblCursSchimb";
            this.lblCursSchimb.Size = new System.Drawing.Size(64, 13);
            this.lblCursSchimb.TabIndex = 4;
            this.lblCursSchimb.Text = "Curs schimb";
            this.lblCursSchimb.ToolTipText = null;
            this.lblCursSchimb.ToolTipTitle = null;
            // 
            // txtCursSchimb
            // 
            this.txtCursSchimb.BackColor = System.Drawing.SystemColors.Window;
            this.txtCursSchimb.Location = new System.Drawing.Point(115, 66);
            this.txtCursSchimb.Name = "txtCursSchimb";
            this.txtCursSchimb.ProprietateCorespunzatoare = null;
            this.txtCursSchimb.Size = new System.Drawing.Size(100, 20);
            this.txtCursSchimb.TabIndex = 5;
            this.txtCursSchimb.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.txtCursSchimb.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCursSchimb.ValoareDouble = 0D;
            // 
            // FormCursBNR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 160);
            this.Controls.Add(this.txtCursSchimb);
            this.Controls.Add(this.lblCursSchimb);
            this.Controls.Add(this.ctrlValidareAnulare);
            this.Controls.Add(this.chkEuAlegCursulDeSchimb);
            this.MinimumSize = new System.Drawing.Size(260, 160);
            this.Name = "FormCursBNR";
            this.Text = "FormCursBNR";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.chkEuAlegCursulDeSchimb, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulare, 0);
            this.Controls.SetChildIndex(this.lblCursSchimb, 0);
            this.Controls.SetChildIndex(this.txtCursSchimb, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.CheckBoxPersonalizat chkEuAlegCursulDeSchimb;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulare;
        private CCL.UI.LabelPersonalizat lblCursSchimb;
        private CCL.UI.MaskedTextBoxPersonalizat txtCursSchimb;
    }
}