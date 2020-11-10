namespace iStomaLab.TablouDeBord.Clienti
{
    partial class FormDetaliuCabinet
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
            this.lblDenumire = new CCL.UI.LabelPersonalizat(this.components);
            this.txtDenumire = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblAdresa = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlValidareAnulare = new CCL.UI.Caramizi.controlValidareAnulare();
            this.ctrlAdresaLiniara = new iStomaLab.Generale.ControlAdresaLiniara();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(463, 19);
            this.lblTitluEcran.Text = "FormDetaliuCabinet";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(462, 0);
            // 
            // lblDenumire
            // 
            this.lblDenumire.AutoSize = true;
            this.lblDenumire.Location = new System.Drawing.Point(13, 39);
            this.lblDenumire.Name = "lblDenumire";
            this.lblDenumire.Size = new System.Drawing.Size(52, 13);
            this.lblDenumire.TabIndex = 2;
            this.lblDenumire.Text = "Denumire";
            this.lblDenumire.ToolTipText = null;
            this.lblDenumire.ToolTipTitle = null;
            // 
            // txtDenumire
            // 
            this.txtDenumire.CapitalizeazaPrimaLitera = false;
            this.txtDenumire.IsInReadOnlyMode = false;
            this.txtDenumire.Location = new System.Drawing.Point(72, 35);
            this.txtDenumire.Name = "txtDenumire";
            this.txtDenumire.ProprietateCorespunzatoare = null;
            this.txtDenumire.RaiseEventLaModificareProgramatica = false;
            this.txtDenumire.Size = new System.Drawing.Size(404, 20);
            this.txtDenumire.TabIndex = 3;
            this.txtDenumire.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtDenumire.TotulCuMajuscule = false;
            // 
            // lblAdresa
            // 
            this.lblAdresa.AutoSize = true;
            this.lblAdresa.Location = new System.Drawing.Point(16, 63);
            this.lblAdresa.Name = "lblAdresa";
            this.lblAdresa.Size = new System.Drawing.Size(40, 13);
            this.lblAdresa.TabIndex = 34;
            this.lblAdresa.Text = "Adresa";
            this.lblAdresa.ToolTipText = null;
            this.lblAdresa.ToolTipTitle = null;
            // 
            // ctrlValidareAnulare
            // 
            this.ctrlValidareAnulare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlValidareAnulare.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulare.Location = new System.Drawing.Point(165, 117);
            this.ctrlValidareAnulare.Name = "ctrlValidareAnulare";
            this.ctrlValidareAnulare.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulare.TabIndex = 35;
            // 
            // ctrlAdresaLiniara
            // 
            this.ctrlAdresaLiniara.Location = new System.Drawing.Point(16, 79);
            this.ctrlAdresaLiniara.Name = "ctrlAdresaLiniara";
            this.ctrlAdresaLiniara.Size = new System.Drawing.Size(460, 20);
            this.ctrlAdresaLiniara.TabIndex = 36;
            // 
            // FormDetaliuCabinet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 150);
            this.Controls.Add(this.ctrlAdresaLiniara);
            this.Controls.Add(this.ctrlValidareAnulare);
            this.Controls.Add(this.lblAdresa);
            this.Controls.Add(this.txtDenumire);
            this.Controls.Add(this.lblDenumire);
            this.Name = "FormDetaliuCabinet";
            this.Text = "FormDetaliuCabinet";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.lblDenumire, 0);
            this.Controls.SetChildIndex(this.txtDenumire, 0);
            this.Controls.SetChildIndex(this.lblAdresa, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulare, 0);
            this.Controls.SetChildIndex(this.ctrlAdresaLiniara, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.LabelPersonalizat lblDenumire;
        private CCL.UI.TextBoxPersonalizat txtDenumire;
        private CCL.UI.LabelPersonalizat lblAdresa;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulare;
        private Generale.ControlAdresaLiniara ctrlAdresaLiniara;
    }
}