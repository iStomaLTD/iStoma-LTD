namespace iStomaLab.Setari.Liste.Localitati
{
    partial class ControlAdaugaLocalitate
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
            this.lblDenumireLocalitate = new CCL.UI.LabelPersonalizat(this.components);
            this.txtDenumireLocalitate = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblRegiuneLocalitate = new CCL.UI.LabelPersonalizat(this.components);
            this.txtTipLocalitate = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblTipLocalitate = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlRegiune = new iStomaLab.Caramizi.ControlCautareRegiune();
            this.SuspendLayout();
            // 
            // lblDenumireLocalitate
            // 
            this.lblDenumireLocalitate.AutoSize = true;
            this.lblDenumireLocalitate.Location = new System.Drawing.Point(16, 16);
            this.lblDenumireLocalitate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDenumireLocalitate.Name = "lblDenumireLocalitate";
            this.lblDenumireLocalitate.Size = new System.Drawing.Size(53, 13);
            this.lblDenumireLocalitate.TabIndex = 0;
            this.lblDenumireLocalitate.Text = "Localitate";
            this.lblDenumireLocalitate.ToolTipText = null;
            this.lblDenumireLocalitate.ToolTipTitle = null;
            // 
            // txtDenumireLocalitate
            // 
            this.txtDenumireLocalitate.CapitalizeazaPrimaLitera = false;
            this.txtDenumireLocalitate.IsInReadOnlyMode = false;
            this.txtDenumireLocalitate.Location = new System.Drawing.Point(94, 14);
            this.txtDenumireLocalitate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDenumireLocalitate.Name = "txtDenumireLocalitate";
            this.txtDenumireLocalitate.ProprietateCorespunzatoare = null;
            this.txtDenumireLocalitate.RaiseEventLaModificareProgramatica = false;
            this.txtDenumireLocalitate.Size = new System.Drawing.Size(190, 20);
            this.txtDenumireLocalitate.TabIndex = 1;
            this.txtDenumireLocalitate.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtDenumireLocalitate.TotulCuMajuscule = false;
            // 
            // lblRegiuneLocalitate
            // 
            this.lblRegiuneLocalitate.AutoSize = true;
            this.lblRegiuneLocalitate.Location = new System.Drawing.Point(16, 47);
            this.lblRegiuneLocalitate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegiuneLocalitate.Name = "lblRegiuneLocalitate";
            this.lblRegiuneLocalitate.Size = new System.Drawing.Size(47, 13);
            this.lblRegiuneLocalitate.TabIndex = 2;
            this.lblRegiuneLocalitate.Text = "Regiune";
            this.lblRegiuneLocalitate.ToolTipText = null;
            this.lblRegiuneLocalitate.ToolTipTitle = null;
            // 
            // txtTipLocalitate
            // 
            this.txtTipLocalitate.CapitalizeazaPrimaLitera = false;
            this.txtTipLocalitate.IsInReadOnlyMode = false;
            this.txtTipLocalitate.Location = new System.Drawing.Point(94, 72);
            this.txtTipLocalitate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTipLocalitate.Name = "txtTipLocalitate";
            this.txtTipLocalitate.ProprietateCorespunzatoare = null;
            this.txtTipLocalitate.RaiseEventLaModificareProgramatica = false;
            this.txtTipLocalitate.Size = new System.Drawing.Size(190, 20);
            this.txtTipLocalitate.TabIndex = 5;
            this.txtTipLocalitate.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtTipLocalitate.TotulCuMajuscule = false;
            // 
            // lblTipLocalitate
            // 
            this.lblTipLocalitate.AutoSize = true;
            this.lblTipLocalitate.Location = new System.Drawing.Point(16, 75);
            this.lblTipLocalitate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTipLocalitate.Name = "lblTipLocalitate";
            this.lblTipLocalitate.Size = new System.Drawing.Size(22, 13);
            this.lblTipLocalitate.TabIndex = 4;
            this.lblTipLocalitate.Text = "Tip";
            this.lblTipLocalitate.ToolTipText = null;
            this.lblTipLocalitate.ToolTipTitle = null;
            // 
            // ctrlRegiune
            // 
            this.ctrlRegiune.Location = new System.Drawing.Point(94, 42);
            this.ctrlRegiune.Name = "ctrlRegiune";
            this.ctrlRegiune.Size = new System.Drawing.Size(190, 22);
            this.ctrlRegiune.TabIndex = 6;
            // 
            // ControlAdaugaLocalitate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlRegiune);
            this.Controls.Add(this.txtTipLocalitate);
            this.Controls.Add(this.lblTipLocalitate);
            this.Controls.Add(this.lblRegiuneLocalitate);
            this.Controls.Add(this.txtDenumireLocalitate);
            this.Controls.Add(this.lblDenumireLocalitate);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ControlAdaugaLocalitate";
            this.Size = new System.Drawing.Size(300, 106);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.LabelPersonalizat lblDenumireLocalitate;
        private CCL.UI.TextBoxPersonalizat txtDenumireLocalitate;
        private CCL.UI.LabelPersonalizat lblRegiuneLocalitate;
        private CCL.UI.TextBoxPersonalizat txtTipLocalitate;
        private CCL.UI.LabelPersonalizat lblTipLocalitate;
        private Caramizi.ControlCautareRegiune ctrlRegiune;
    }
}
