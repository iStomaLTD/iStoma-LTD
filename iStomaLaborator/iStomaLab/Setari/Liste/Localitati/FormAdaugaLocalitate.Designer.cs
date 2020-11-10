namespace iStomaLab.Setari.Liste.Localitati
{
    partial class FormAdaugaLocalitate
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
            this.ctrlValidareAnulareLocalitate = new CCL.UI.Caramizi.controlValidareAnulare();
            this.ctrlRegiune = new iStomaLab.Caramizi.ControlCautareRegiune();
            this.txtTipLocalitate = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblTipLocalitate = new CCL.UI.LabelPersonalizat(this.components);
            this.lblRegiuneLocalitate = new CCL.UI.LabelPersonalizat(this.components);
            this.txtDenumireLocalitate = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblDenumireLocalitate = new CCL.UI.LabelPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitluEcran.Size = new System.Drawing.Size(275, 19);
            this.lblTitluEcran.TabIndex = 2;
            this.lblTitluEcran.Text = "FormAdaugaLocalitate";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(274, 0);
            this.btnInchidereEcran.Margin = new System.Windows.Forms.Padding(2);
            this.btnInchidereEcran.TabIndex = 3;
            // 
            // ctrlValidareAnulareLocalitate
            // 
            this.ctrlValidareAnulareLocalitate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrlValidareAnulareLocalitate.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulareLocalitate.Location = new System.Drawing.Point(74, 137);
            this.ctrlValidareAnulareLocalitate.Name = "ctrlValidareAnulareLocalitate";
            this.ctrlValidareAnulareLocalitate.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulareLocalitate.TabIndex = 1;
            // 
            // ctrlRegiune
            // 
            this.ctrlRegiune.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlRegiune.Location = new System.Drawing.Point(93, 64);
            this.ctrlRegiune.Name = "ctrlRegiune";
            this.ctrlRegiune.Size = new System.Drawing.Size(190, 22);
            this.ctrlRegiune.TabIndex = 7;
            // 
            // txtTipLocalitate
            // 
            this.txtTipLocalitate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTipLocalitate.CapitalizeazaPrimaLitera = false;
            this.txtTipLocalitate.IsInReadOnlyMode = false;
            this.txtTipLocalitate.Location = new System.Drawing.Point(93, 94);
            this.txtTipLocalitate.Margin = new System.Windows.Forms.Padding(2);
            this.txtTipLocalitate.Name = "txtTipLocalitate";
            this.txtTipLocalitate.ProprietateCorespunzatoare = null;
            this.txtTipLocalitate.RaiseEventLaModificareProgramatica = false;
            this.txtTipLocalitate.Size = new System.Drawing.Size(190, 20);
            this.txtTipLocalitate.TabIndex = 8;
            this.txtTipLocalitate.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtTipLocalitate.TotulCuMajuscule = false;
            // 
            // lblTipLocalitate
            // 
            this.lblTipLocalitate.AutoSize = true;
            this.lblTipLocalitate.Location = new System.Drawing.Point(15, 97);
            this.lblTipLocalitate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTipLocalitate.Name = "lblTipLocalitate";
            this.lblTipLocalitate.Size = new System.Drawing.Size(22, 13);
            this.lblTipLocalitate.TabIndex = 11;
            this.lblTipLocalitate.Text = "Tip";
            this.lblTipLocalitate.ToolTipText = null;
            this.lblTipLocalitate.ToolTipTitle = null;
            // 
            // lblRegiuneLocalitate
            // 
            this.lblRegiuneLocalitate.AutoSize = true;
            this.lblRegiuneLocalitate.Location = new System.Drawing.Point(15, 69);
            this.lblRegiuneLocalitate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegiuneLocalitate.Name = "lblRegiuneLocalitate";
            this.lblRegiuneLocalitate.Size = new System.Drawing.Size(47, 13);
            this.lblRegiuneLocalitate.TabIndex = 10;
            this.lblRegiuneLocalitate.Text = "Regiune";
            this.lblRegiuneLocalitate.ToolTipText = null;
            this.lblRegiuneLocalitate.ToolTipTitle = null;
            // 
            // txtDenumireLocalitate
            // 
            this.txtDenumireLocalitate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenumireLocalitate.CapitalizeazaPrimaLitera = false;
            this.txtDenumireLocalitate.IsInReadOnlyMode = false;
            this.txtDenumireLocalitate.Location = new System.Drawing.Point(93, 36);
            this.txtDenumireLocalitate.Margin = new System.Windows.Forms.Padding(2);
            this.txtDenumireLocalitate.Name = "txtDenumireLocalitate";
            this.txtDenumireLocalitate.ProprietateCorespunzatoare = null;
            this.txtDenumireLocalitate.RaiseEventLaModificareProgramatica = false;
            this.txtDenumireLocalitate.Size = new System.Drawing.Size(190, 20);
            this.txtDenumireLocalitate.TabIndex = 6;
            this.txtDenumireLocalitate.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtDenumireLocalitate.TotulCuMajuscule = false;
            // 
            // lblDenumireLocalitate
            // 
            this.lblDenumireLocalitate.AutoSize = true;
            this.lblDenumireLocalitate.Location = new System.Drawing.Point(15, 38);
            this.lblDenumireLocalitate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDenumireLocalitate.Name = "lblDenumireLocalitate";
            this.lblDenumireLocalitate.Size = new System.Drawing.Size(53, 13);
            this.lblDenumireLocalitate.TabIndex = 9;
            this.lblDenumireLocalitate.Text = "Localitate";
            this.lblDenumireLocalitate.ToolTipText = null;
            this.lblDenumireLocalitate.ToolTipTitle = null;
            // 
            // FormAdaugaLocalitate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 171);
            this.Controls.Add(this.ctrlRegiune);
            this.Controls.Add(this.txtTipLocalitate);
            this.Controls.Add(this.lblTipLocalitate);
            this.Controls.Add(this.lblRegiuneLocalitate);
            this.Controls.Add(this.txtDenumireLocalitate);
            this.Controls.Add(this.lblDenumireLocalitate);
            this.Controls.Add(this.ctrlValidareAnulareLocalitate);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(298, 171);
            this.Name = "FormAdaugaLocalitate";
            this.Text = "FormAdaugaLocalitate";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulareLocalitate, 0);
            this.Controls.SetChildIndex(this.lblDenumireLocalitate, 0);
            this.Controls.SetChildIndex(this.txtDenumireLocalitate, 0);
            this.Controls.SetChildIndex(this.lblRegiuneLocalitate, 0);
            this.Controls.SetChildIndex(this.lblTipLocalitate, 0);
            this.Controls.SetChildIndex(this.txtTipLocalitate, 0);
            this.Controls.SetChildIndex(this.ctrlRegiune, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulareLocalitate;
        private Caramizi.ControlCautareRegiune ctrlRegiune;
        private CCL.UI.TextBoxPersonalizat txtTipLocalitate;
        private CCL.UI.LabelPersonalizat lblTipLocalitate;
        private CCL.UI.LabelPersonalizat lblRegiuneLocalitate;
        private CCL.UI.TextBoxPersonalizat txtDenumireLocalitate;
        private CCL.UI.LabelPersonalizat lblDenumireLocalitate;
    }
}