namespace iStomaLab.Setari.Liste.Categorii
{
    partial class FormDetaliiCategorie
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
            this.ctrlValidareAnulareCategorie = new CCL.UI.Caramizi.controlValidareAnulare();
            this.ctrlCategorieCuloare = new CCL.UI.Caramizi.controlGestiuneCuloare();
            this.txtCategorieDenumire = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblCategorieCuloare = new CCL.UI.LabelPersonalizat(this.components);
            this.lblCategorieDenumire = new CCL.UI.LabelPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitluEcran.Size = new System.Drawing.Size(372, 19);
            this.lblTitluEcran.TabIndex = 2;
            this.lblTitluEcran.Text = "FormDetaliiCategorie";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(371, 0);
            this.btnInchidereEcran.Margin = new System.Windows.Forms.Padding(2);
            this.btnInchidereEcran.TabIndex = 3;
            // 
            // ctrlValidareAnulareCategorie
            // 
            this.ctrlValidareAnulareCategorie.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrlValidareAnulareCategorie.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulareCategorie.Location = new System.Drawing.Point(122, 137);
            this.ctrlValidareAnulareCategorie.Name = "ctrlValidareAnulareCategorie";
            this.ctrlValidareAnulareCategorie.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulareCategorie.TabIndex = 1;
            // 
            // ctrlCategorieCuloare
            // 
            this.ctrlCategorieCuloare.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ctrlCategorieCuloare.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ctrlCategorieCuloare.BackColor = System.Drawing.Color.Red;
            this.ctrlCategorieCuloare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlCategorieCuloare.Location = new System.Drawing.Point(82, 70);
            this.ctrlCategorieCuloare.Name = "ctrlCategorieCuloare";
            this.ctrlCategorieCuloare.Size = new System.Drawing.Size(33, 24);
            this.ctrlCategorieCuloare.TabIndex = 6;
            this.ctrlCategorieCuloare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // txtCategorieDenumire
            // 
            this.txtCategorieDenumire.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCategorieDenumire.CapitalizeazaPrimaLitera = false;
            this.txtCategorieDenumire.IsInReadOnlyMode = false;
            this.txtCategorieDenumire.Location = new System.Drawing.Point(82, 40);
            this.txtCategorieDenumire.Margin = new System.Windows.Forms.Padding(2);
            this.txtCategorieDenumire.Name = "txtCategorieDenumire";
            this.txtCategorieDenumire.ProprietateCorespunzatoare = null;
            this.txtCategorieDenumire.RaiseEventLaModificareProgramatica = false;
            this.txtCategorieDenumire.Size = new System.Drawing.Size(296, 20);
            this.txtCategorieDenumire.TabIndex = 5;
            this.txtCategorieDenumire.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCategorieDenumire.TotulCuMajuscule = false;
            // 
            // lblCategorieCuloare
            // 
            this.lblCategorieCuloare.AutoSize = true;
            this.lblCategorieCuloare.Location = new System.Drawing.Point(18, 76);
            this.lblCategorieCuloare.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCategorieCuloare.Name = "lblCategorieCuloare";
            this.lblCategorieCuloare.Size = new System.Drawing.Size(43, 13);
            this.lblCategorieCuloare.TabIndex = 8;
            this.lblCategorieCuloare.Text = "Culoare";
            this.lblCategorieCuloare.ToolTipText = null;
            this.lblCategorieCuloare.ToolTipTitle = null;
            // 
            // lblCategorieDenumire
            // 
            this.lblCategorieDenumire.AutoSize = true;
            this.lblCategorieDenumire.Location = new System.Drawing.Point(18, 44);
            this.lblCategorieDenumire.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCategorieDenumire.Name = "lblCategorieDenumire";
            this.lblCategorieDenumire.Size = new System.Drawing.Size(52, 13);
            this.lblCategorieDenumire.TabIndex = 7;
            this.lblCategorieDenumire.Text = "Denumire";
            this.lblCategorieDenumire.ToolTipText = null;
            this.lblCategorieDenumire.ToolTipTitle = null;
            // 
            // FormDetaliiCategorie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 171);
            this.Controls.Add(this.ctrlCategorieCuloare);
            this.Controls.Add(this.txtCategorieDenumire);
            this.Controls.Add(this.lblCategorieCuloare);
            this.Controls.Add(this.lblCategorieDenumire);
            this.Controls.Add(this.ctrlValidareAnulareCategorie);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(394, 171);
            this.Name = "FormDetaliiCategorie";
            this.Text = "FormDetaliiCategorie";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulareCategorie, 0);
            this.Controls.SetChildIndex(this.lblCategorieDenumire, 0);
            this.Controls.SetChildIndex(this.lblCategorieCuloare, 0);
            this.Controls.SetChildIndex(this.txtCategorieDenumire, 0);
            this.Controls.SetChildIndex(this.ctrlCategorieCuloare, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulareCategorie;
        private CCL.UI.Caramizi.controlGestiuneCuloare ctrlCategorieCuloare;
        private CCL.UI.TextBoxPersonalizat txtCategorieDenumire;
        private CCL.UI.LabelPersonalizat lblCategorieCuloare;
        private CCL.UI.LabelPersonalizat lblCategorieDenumire;
    }
}