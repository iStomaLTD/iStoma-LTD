namespace iStomaLab.TablouDeBord.Clienti
{
    partial class FormCreareReprezentant
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
            this.ctrlValidareAnulare = new CCL.UI.Caramizi.controlValidareAnulare();
            this.ctrlCautaClinica = new iStomaLab.Caramizi.ControlCautareDupaTextClinica();
            this.lblClinica = new CCL.UI.LabelPersonalizat(this.components);
            this.txtTelefon = new CCL.UI.MaskedTextBoxPersonalizat(this.components);
            this.lblTelefon = new CCL.UI.LabelPersonalizat(this.components);
            this.txtPrenume = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblPrenume = new CCL.UI.LabelPersonalizat(this.components);
            this.txtNume = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblNume = new CCL.UI.LabelPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(416, 19);
            this.lblTitluEcran.TabIndex = 5;
            this.lblTitluEcran.Text = "FormCreareReprezentant";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(415, 0);
            this.btnInchidereEcran.TabIndex = 6;
            // 
            // ctrlValidareAnulare
            // 
            this.ctrlValidareAnulare.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrlValidareAnulare.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulare.Location = new System.Drawing.Point(139, 163);
            this.ctrlValidareAnulare.Name = "ctrlValidareAnulare";
            this.ctrlValidareAnulare.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulare.TabIndex = 4;
            // 
            // ctrlCautaClinica
            // 
            this.ctrlCautaClinica.Location = new System.Drawing.Point(79, 26);
            this.ctrlCautaClinica.Name = "ctrlCautaClinica";
            this.ctrlCautaClinica.Size = new System.Drawing.Size(337, 24);
            this.ctrlCautaClinica.TabIndex = 0;
            // 
            // lblClinica
            // 
            this.lblClinica.AutoSize = true;
            this.lblClinica.Location = new System.Drawing.Point(22, 32);
            this.lblClinica.Name = "lblClinica";
            this.lblClinica.Size = new System.Drawing.Size(38, 13);
            this.lblClinica.TabIndex = 7;
            this.lblClinica.Text = "Clinica";
            this.lblClinica.ToolTipText = null;
            this.lblClinica.ToolTipTitle = null;
            // 
            // txtTelefon
            // 
            this.txtTelefon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelefon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.txtTelefon.Location = new System.Drawing.Point(81, 134);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.ProprietateCorespunzatoare = null;
            this.txtTelefon.Size = new System.Drawing.Size(335, 20);
            this.txtTelefon.TabIndex = 3;
            this.txtTelefon.Text = "0";
            this.txtTelefon.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Telefon;
            this.txtTelefon.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTelefon.ValoareDouble = 0D;
            // 
            // lblTelefon
            // 
            this.lblTelefon.AutoSize = true;
            this.lblTelefon.Location = new System.Drawing.Point(22, 138);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(43, 13);
            this.lblTelefon.TabIndex = 10;
            this.lblTelefon.Text = "Telefon";
            this.lblTelefon.ToolTipText = null;
            this.lblTelefon.ToolTipTitle = null;
            // 
            // txtPrenume
            // 
            this.txtPrenume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrenume.CapitalizeazaPrimaLitera = false;
            this.txtPrenume.IsInReadOnlyMode = false;
            this.txtPrenume.Location = new System.Drawing.Point(81, 97);
            this.txtPrenume.Name = "txtPrenume";
            this.txtPrenume.ProprietateCorespunzatoare = null;
            this.txtPrenume.RaiseEventLaModificareProgramatica = false;
            this.txtPrenume.Size = new System.Drawing.Size(335, 20);
            this.txtPrenume.TabIndex = 2;
            this.txtPrenume.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtPrenume.TotulCuMajuscule = false;
            // 
            // lblPrenume
            // 
            this.lblPrenume.AutoSize = true;
            this.lblPrenume.Location = new System.Drawing.Point(22, 101);
            this.lblPrenume.Name = "lblPrenume";
            this.lblPrenume.Size = new System.Drawing.Size(49, 13);
            this.lblPrenume.TabIndex = 9;
            this.lblPrenume.Text = "Prenume";
            this.lblPrenume.ToolTipText = null;
            this.lblPrenume.ToolTipTitle = null;
            // 
            // txtNume
            // 
            this.txtNume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNume.CapitalizeazaPrimaLitera = false;
            this.txtNume.IsInReadOnlyMode = false;
            this.txtNume.Location = new System.Drawing.Point(81, 63);
            this.txtNume.Name = "txtNume";
            this.txtNume.ProprietateCorespunzatoare = null;
            this.txtNume.RaiseEventLaModificareProgramatica = false;
            this.txtNume.Size = new System.Drawing.Size(335, 20);
            this.txtNume.TabIndex = 1;
            this.txtNume.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtNume.TotulCuMajuscule = false;
            // 
            // lblNume
            // 
            this.lblNume.AutoSize = true;
            this.lblNume.Location = new System.Drawing.Point(22, 67);
            this.lblNume.Name = "lblNume";
            this.lblNume.Size = new System.Drawing.Size(35, 13);
            this.lblNume.TabIndex = 8;
            this.lblNume.Text = "Nume";
            this.lblNume.ToolTipText = null;
            this.lblNume.ToolTipTitle = null;
            // 
            // FormCreareReprezentant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 192);
            this.Controls.Add(this.ctrlCautaClinica);
            this.Controls.Add(this.lblClinica);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.lblTelefon);
            this.Controls.Add(this.txtPrenume);
            this.Controls.Add(this.lblPrenume);
            this.Controls.Add(this.txtNume);
            this.Controls.Add(this.lblNume);
            this.Controls.Add(this.ctrlValidareAnulare);
            this.MinimumSize = new System.Drawing.Size(438, 192);
            this.Name = "FormCreareReprezentant";
            this.Text = "FormCreareReprezentant";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulare, 0);
            this.Controls.SetChildIndex(this.lblNume, 0);
            this.Controls.SetChildIndex(this.txtNume, 0);
            this.Controls.SetChildIndex(this.lblPrenume, 0);
            this.Controls.SetChildIndex(this.txtPrenume, 0);
            this.Controls.SetChildIndex(this.lblTelefon, 0);
            this.Controls.SetChildIndex(this.txtTelefon, 0);
            this.Controls.SetChildIndex(this.lblClinica, 0);
            this.Controls.SetChildIndex(this.ctrlCautaClinica, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulare;
        private Caramizi.ControlCautareDupaTextClinica ctrlCautaClinica;
        private CCL.UI.LabelPersonalizat lblClinica;
        private CCL.UI.MaskedTextBoxPersonalizat txtTelefon;
        private CCL.UI.LabelPersonalizat lblTelefon;
        private CCL.UI.TextBoxPersonalizat txtPrenume;
        private CCL.UI.LabelPersonalizat lblPrenume;
        private CCL.UI.TextBoxPersonalizat txtNume;
        private CCL.UI.LabelPersonalizat lblNume;
    }
}