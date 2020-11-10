namespace iStomaLab.Setari.Liste.Categorii
{
    partial class ControlDetaliiCategorie
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
            this.lblCategorieDenumire = new CCL.UI.LabelPersonalizat(this.components);
            this.lblCategorieCuloare = new CCL.UI.LabelPersonalizat(this.components);
            this.txtCategorieDenumire = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblCategorieSelectata = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlCategorieCuloare = new CCL.UI.Caramizi.controlGestiuneCuloare();
            this.SuspendLayout();
            // 
            // lblCategorieDenumire
            // 
            this.lblCategorieDenumire.AutoSize = true;
            this.lblCategorieDenumire.Location = new System.Drawing.Point(16, 41);
            this.lblCategorieDenumire.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCategorieDenumire.Name = "lblCategorieDenumire";
            this.lblCategorieDenumire.Size = new System.Drawing.Size(52, 13);
            this.lblCategorieDenumire.TabIndex = 0;
            this.lblCategorieDenumire.Text = "Denumire";
            this.lblCategorieDenumire.ToolTipText = null;
            this.lblCategorieDenumire.ToolTipTitle = null;
            // 
            // lblCategorieCuloare
            // 
            this.lblCategorieCuloare.AutoSize = true;
            this.lblCategorieCuloare.Location = new System.Drawing.Point(16, 72);
            this.lblCategorieCuloare.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCategorieCuloare.Name = "lblCategorieCuloare";
            this.lblCategorieCuloare.Size = new System.Drawing.Size(43, 13);
            this.lblCategorieCuloare.TabIndex = 1;
            this.lblCategorieCuloare.Text = "Culoare";
            this.lblCategorieCuloare.ToolTipText = null;
            this.lblCategorieCuloare.ToolTipTitle = null;
            // 
            // txtCategorieDenumire
            // 
            this.txtCategorieDenumire.CapitalizeazaPrimaLitera = false;
            this.txtCategorieDenumire.IsInReadOnlyMode = false;
            this.txtCategorieDenumire.Location = new System.Drawing.Point(80, 41);
            this.txtCategorieDenumire.Margin = new System.Windows.Forms.Padding(2);
            this.txtCategorieDenumire.Name = "txtCategorieDenumire";
            this.txtCategorieDenumire.ProprietateCorespunzatoare = null;
            this.txtCategorieDenumire.RaiseEventLaModificareProgramatica = false;
            this.txtCategorieDenumire.Size = new System.Drawing.Size(285, 20);
            this.txtCategorieDenumire.TabIndex = 2;
            this.txtCategorieDenumire.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCategorieDenumire.TotulCuMajuscule = false;
            // 
            // lblCategorieSelectata
            // 
            this.lblCategorieSelectata.AutoSize = true;
            this.lblCategorieSelectata.Location = new System.Drawing.Point(16, 17);
            this.lblCategorieSelectata.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCategorieSelectata.Name = "lblCategorieSelectata";
            this.lblCategorieSelectata.Size = new System.Drawing.Size(98, 13);
            this.lblCategorieSelectata.TabIndex = 4;
            this.lblCategorieSelectata.Text = "Categorie selectata";
            this.lblCategorieSelectata.ToolTipText = null;
            this.lblCategorieSelectata.ToolTipTitle = null;
            // 
            // ctrlCategorieCuloare
            // 
            this.ctrlCategorieCuloare.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ctrlCategorieCuloare.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ctrlCategorieCuloare.BackColor = System.Drawing.Color.Red;
            this.ctrlCategorieCuloare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlCategorieCuloare.Location = new System.Drawing.Point(80, 72);
            this.ctrlCategorieCuloare.Name = "ctrlCategorieCuloare";
            this.ctrlCategorieCuloare.Size = new System.Drawing.Size(23, 22);
            this.ctrlCategorieCuloare.TabIndex = 5;
            this.ctrlCategorieCuloare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // ControlDetaliiCategorie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlCategorieCuloare);
            this.Controls.Add(this.lblCategorieSelectata);
            this.Controls.Add(this.txtCategorieDenumire);
            this.Controls.Add(this.lblCategorieCuloare);
            this.Controls.Add(this.lblCategorieDenumire);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ControlDetaliiCategorie";
            this.Size = new System.Drawing.Size(374, 117);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.LabelPersonalizat lblCategorieDenumire;
        private CCL.UI.LabelPersonalizat lblCategorieCuloare;
        private CCL.UI.TextBoxPersonalizat txtCategorieDenumire;
        private CCL.UI.LabelPersonalizat lblCategorieSelectata;
        private CCL.UI.Caramizi.controlGestiuneCuloare ctrlCategorieCuloare;
    }
}
