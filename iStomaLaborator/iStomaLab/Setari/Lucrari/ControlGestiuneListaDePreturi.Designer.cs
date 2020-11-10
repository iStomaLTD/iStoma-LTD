namespace iStomaLab.Setari.Lucrari
{
    partial class ControlGestiuneListaDePreturi
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
            this.tsMeniuLucrari = new CCL.UI.ControalePersonalizate.ToolStripPersonalizat();
            this.mnuBtnPreturiStandard = new System.Windows.Forms.ToolStripButton();
            this.mnuBtnPreturiClienti = new System.Windows.Forms.ToolStripButton();
            this.mnuBtnEtape = new System.Windows.Forms.ToolStripButton();
            this.panelOptiunePret = new CCL.UI.PanelPersonalizat(this.components);
            this.tsMeniuLucrari.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMeniuLucrari
            // 
            this.tsMeniuLucrari.BackColor = System.Drawing.SystemColors.Control;
            this.tsMeniuLucrari.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMeniuLucrari.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMeniuLucrari.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBtnPreturiStandard,
            this.mnuBtnPreturiClienti,
            this.mnuBtnEtape});
            this.tsMeniuLucrari.Location = new System.Drawing.Point(0, 0);
            this.tsMeniuLucrari.Name = "tsMeniuLucrari";
            this.tsMeniuLucrari.Size = new System.Drawing.Size(606, 42);
            this.tsMeniuLucrari.TabIndex = 1;
            // 
            // mnuBtnPreturiStandard
            // 
            this.mnuBtnPreturiStandard.Image = global::iStomaLab.Properties.Resources.dinte;
            this.mnuBtnPreturiStandard.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.mnuBtnPreturiStandard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnPreturiStandard.Name = "mnuBtnPreturiStandard";
            this.mnuBtnPreturiStandard.Size = new System.Drawing.Size(95, 39);
            this.mnuBtnPreturiStandard.Text = "Preturi standard";
            this.mnuBtnPreturiStandard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // mnuBtnPreturiClienti
            // 
            this.mnuBtnPreturiClienti.Image = global::iStomaLab.Properties.Resources.Barter;
            this.mnuBtnPreturiClienti.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnPreturiClienti.Name = "mnuBtnPreturiClienti";
            this.mnuBtnPreturiClienti.Size = new System.Drawing.Size(81, 39);
            this.mnuBtnPreturiClienti.Text = "Preturi clienti";
            this.mnuBtnPreturiClienti.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // mnuBtnEtape
            // 
            this.mnuBtnEtape.Image = global::iStomaLab.Properties.Resources.planDeTratament;
            this.mnuBtnEtape.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnEtape.Name = "mnuBtnEtape";
            this.mnuBtnEtape.Size = new System.Drawing.Size(40, 39);
            this.mnuBtnEtape.Text = "Etape";
            this.mnuBtnEtape.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // panelOptiunePret
            // 
            this.panelOptiunePret.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOptiunePret.BackColor = System.Drawing.Color.White;
            this.panelOptiunePret.Location = new System.Drawing.Point(1, 41);
            this.panelOptiunePret.Margin = new System.Windows.Forms.Padding(2);
            this.panelOptiunePret.Name = "panelOptiunePret";
            this.panelOptiunePret.Size = new System.Drawing.Size(605, 436);
            this.panelOptiunePret.TabIndex = 2;
            this.panelOptiunePret.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // ControlGestiuneListaDePreturi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelOptiunePret);
            this.Controls.Add(this.tsMeniuLucrari);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ControlGestiuneListaDePreturi";
            this.Size = new System.Drawing.Size(606, 477);
            this.tsMeniuLucrari.ResumeLayout(false);
            this.tsMeniuLucrari.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CCL.UI.ControalePersonalizate.ToolStripPersonalizat tsMeniuLucrari;
        private System.Windows.Forms.ToolStripButton mnuBtnPreturiStandard;
        private System.Windows.Forms.ToolStripButton mnuBtnPreturiClienti;
        private System.Windows.Forms.ToolStripButton mnuBtnEtape;
        private CCL.UI.PanelPersonalizat panelOptiunePret;
    }
}
