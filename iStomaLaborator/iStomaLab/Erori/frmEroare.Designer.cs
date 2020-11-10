namespace iStomaLab.Erori
{
    partial class frmEroare
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
            this.txtEroare = new CCL.UI.TextBoxPersonalizat(this.components);
            this.ctrlValidareAnulare = new CCL.UI.Caramizi.controlValidareAnulare();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(546, 19);
            this.lblTitluEcran.Text = "frmEroare";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(545, 0);
            // 
            // txtEroare
            // 
            this.txtEroare.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEroare.CapitalizeazaPrimaLitera = false;
            this.txtEroare.IsInReadOnlyMode = false;
            this.txtEroare.Location = new System.Drawing.Point(3, 23);
            this.txtEroare.Multiline = true;
            this.txtEroare.Name = "txtEroare";
            this.txtEroare.ProprietateCorespunzatoare = null;
            this.txtEroare.RaiseEventLaModificareProgramatica = false;
            this.txtEroare.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEroare.Size = new System.Drawing.Size(561, 220);
            this.txtEroare.TabIndex = 2;
            this.txtEroare.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtEroare.TotulCuMajuscule = false;
            // 
            // ctrlValidareAnulare
            // 
            this.ctrlValidareAnulare.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrlValidareAnulare.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulare.Location = new System.Drawing.Point(204, 250);
            this.ctrlValidareAnulare.Name = "ctrlValidareAnulare";
            this.ctrlValidareAnulare.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulare.TabIndex = 3;
            // 
            // frmEroare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 279);
            this.Controls.Add(this.ctrlValidareAnulare);
            this.Controls.Add(this.txtEroare);
            this.MinimumSize = new System.Drawing.Size(568, 279);
            this.Name = "frmEroare";
            this.Text = "frmEroare";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.txtEroare, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulare, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.TextBoxPersonalizat txtEroare;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulare;
    }
}