namespace iStomaLab.Setari.Liste.Banci
{
    partial class FormDetaliiBanca
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
            this.ctrlValidareAnulareBanca = new CCL.UI.Caramizi.controlValidareAnulare();
            this.txtInfoSuplimentare = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblInfoSuplimentare = new CCL.UI.LabelPersonalizat(this.components);
            this.txtDenumireBanca = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblDenumire = new CCL.UI.LabelPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(265, 19);
            this.lblTitluEcran.TabIndex = 2;
            this.lblTitluEcran.Text = "FormDetaliiBanca";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(264, 0);
            this.btnInchidereEcran.TabIndex = 3;
            // 
            // ctrlValidareAnulareBanca
            // 
            this.ctrlValidareAnulareBanca.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrlValidareAnulareBanca.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulareBanca.Location = new System.Drawing.Point(66, 227);
            this.ctrlValidareAnulareBanca.Name = "ctrlValidareAnulareBanca";
            this.ctrlValidareAnulareBanca.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulareBanca.TabIndex = 1;
            // 
            // txtInfoSuplimentare
            // 
            this.txtInfoSuplimentare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfoSuplimentare.CapitalizeazaPrimaLitera = false;
            this.txtInfoSuplimentare.IsInReadOnlyMode = false;
            this.txtInfoSuplimentare.Location = new System.Drawing.Point(13, 99);
            this.txtInfoSuplimentare.Multiline = true;
            this.txtInfoSuplimentare.Name = "txtInfoSuplimentare";
            this.txtInfoSuplimentare.ProprietateCorespunzatoare = null;
            this.txtInfoSuplimentare.RaiseEventLaModificareProgramatica = false;
            this.txtInfoSuplimentare.Size = new System.Drawing.Size(260, 107);
            this.txtInfoSuplimentare.TabIndex = 5;
            this.txtInfoSuplimentare.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtInfoSuplimentare.TotulCuMajuscule = false;
            // 
            // lblInfoSuplimentare
            // 
            this.lblInfoSuplimentare.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInfoSuplimentare.AutoSize = true;
            this.lblInfoSuplimentare.Location = new System.Drawing.Point(13, 77);
            this.lblInfoSuplimentare.Name = "lblInfoSuplimentare";
            this.lblInfoSuplimentare.Size = new System.Drawing.Size(111, 13);
            this.lblInfoSuplimentare.TabIndex = 7;
            this.lblInfoSuplimentare.Text = "Informatii suplimentare";
            this.lblInfoSuplimentare.ToolTipText = null;
            this.lblInfoSuplimentare.ToolTipTitle = null;
            // 
            // txtDenumireBanca
            // 
            this.txtDenumireBanca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenumireBanca.CapitalizeazaPrimaLitera = false;
            this.txtDenumireBanca.IsInReadOnlyMode = false;
            this.txtDenumireBanca.Location = new System.Drawing.Point(71, 33);
            this.txtDenumireBanca.Name = "txtDenumireBanca";
            this.txtDenumireBanca.ProprietateCorespunzatoare = null;
            this.txtDenumireBanca.RaiseEventLaModificareProgramatica = false;
            this.txtDenumireBanca.Size = new System.Drawing.Size(202, 20);
            this.txtDenumireBanca.TabIndex = 4;
            this.txtDenumireBanca.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtDenumireBanca.TotulCuMajuscule = false;
            // 
            // lblDenumire
            // 
            this.lblDenumire.AutoSize = true;
            this.lblDenumire.Location = new System.Drawing.Point(13, 37);
            this.lblDenumire.Name = "lblDenumire";
            this.lblDenumire.Size = new System.Drawing.Size(52, 13);
            this.lblDenumire.TabIndex = 6;
            this.lblDenumire.Text = "Denumire";
            this.lblDenumire.ToolTipText = null;
            this.lblDenumire.ToolTipTitle = null;
            // 
            // FormDetaliiBanca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 262);
            this.Controls.Add(this.txtInfoSuplimentare);
            this.Controls.Add(this.lblInfoSuplimentare);
            this.Controls.Add(this.txtDenumireBanca);
            this.Controls.Add(this.lblDenumire);
            this.Controls.Add(this.ctrlValidareAnulareBanca);
            this.MinimumSize = new System.Drawing.Size(287, 262);
            this.Name = "FormDetaliiBanca";
            this.Text = "FormDetaliiBanca";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulareBanca, 0);
            this.Controls.SetChildIndex(this.lblDenumire, 0);
            this.Controls.SetChildIndex(this.txtDenumireBanca, 0);
            this.Controls.SetChildIndex(this.lblInfoSuplimentare, 0);
            this.Controls.SetChildIndex(this.txtInfoSuplimentare, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulareBanca;
        private CCL.UI.TextBoxPersonalizat txtInfoSuplimentare;
        private CCL.UI.LabelPersonalizat lblInfoSuplimentare;
        private CCL.UI.TextBoxPersonalizat txtDenumireBanca;
        private CCL.UI.LabelPersonalizat lblDenumire;
    }
}