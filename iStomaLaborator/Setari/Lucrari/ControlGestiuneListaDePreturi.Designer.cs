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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlGestiuneListaDePreturi));
            this.toolStripPersonalizat1 = new CCL.UI.ControalePersonalizate.ToolStripPersonalizat();
            this.mnuBtnPreturiStandard = new System.Windows.Forms.ToolStripButton();
            this.mnuBtnPreturiClienti = new System.Windows.Forms.ToolStripButton();
            this.mnuBtnEtape = new System.Windows.Forms.ToolStripButton();
            this.panelOptiunePret = new CCL.UI.PanelPersonalizat(this.components);
            this.toolStripPersonalizat1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripPersonalizat1
            // 
            this.toolStripPersonalizat1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripPersonalizat1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripPersonalizat1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripPersonalizat1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBtnPreturiStandard,
            this.mnuBtnPreturiClienti,
            this.mnuBtnEtape});
            this.toolStripPersonalizat1.Location = new System.Drawing.Point(0, 0);
            this.toolStripPersonalizat1.Name = "toolStripPersonalizat1";
            this.toolStripPersonalizat1.Size = new System.Drawing.Size(808, 47);
            this.toolStripPersonalizat1.TabIndex = 1;
            this.toolStripPersonalizat1.Text = "toolStripPersonalizat1";
            // 
            // mnuBtnPreturiStandard
            // 
            this.mnuBtnPreturiStandard.Image = ((System.Drawing.Image)(resources.GetObject("mnuBtnPreturiStandard.Image")));
            this.mnuBtnPreturiStandard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnPreturiStandard.Name = "mnuBtnPreturiStandard";
            this.mnuBtnPreturiStandard.Size = new System.Drawing.Size(118, 44);
            this.mnuBtnPreturiStandard.Text = "Preturi standard";
            this.mnuBtnPreturiStandard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // mnuBtnPreturiClienti
            // 
            this.mnuBtnPreturiClienti.Image = ((System.Drawing.Image)(resources.GetObject("mnuBtnPreturiClienti.Image")));
            this.mnuBtnPreturiClienti.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnPreturiClienti.Name = "mnuBtnPreturiClienti";
            this.mnuBtnPreturiClienti.Size = new System.Drawing.Size(100, 44);
            this.mnuBtnPreturiClienti.Text = "Preturi clienti";
            this.mnuBtnPreturiClienti.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // mnuBtnEtape
            // 
            this.mnuBtnEtape.Image = ((System.Drawing.Image)(resources.GetObject("mnuBtnEtape.Image")));
            this.mnuBtnEtape.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnEtape.Name = "mnuBtnEtape";
            this.mnuBtnEtape.Size = new System.Drawing.Size(51, 44);
            this.mnuBtnEtape.Text = "Etape";
            this.mnuBtnEtape.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // panelOptiunePret
            // 
            this.panelOptiunePret.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOptiunePret.BackColor = System.Drawing.Color.White;
            this.panelOptiunePret.Location = new System.Drawing.Point(1, 50);
            this.panelOptiunePret.Name = "panelOptiunePret";
            this.panelOptiunePret.Size = new System.Drawing.Size(807, 537);
            this.panelOptiunePret.TabIndex = 2;
            this.panelOptiunePret.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // ControlGestiuneListaDePreturi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelOptiunePret);
            this.Controls.Add(this.toolStripPersonalizat1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ControlGestiuneListaDePreturi";
            this.Size = new System.Drawing.Size(808, 587);
            this.toolStripPersonalizat1.ResumeLayout(false);
            this.toolStripPersonalizat1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CCL.UI.ControalePersonalizate.ToolStripPersonalizat toolStripPersonalizat1;
        private System.Windows.Forms.ToolStripButton mnuBtnPreturiStandard;
        private System.Windows.Forms.ToolStripButton mnuBtnPreturiClienti;
        private System.Windows.Forms.ToolStripButton mnuBtnEtape;
        private CCL.UI.PanelPersonalizat panelOptiunePret;
    }
}
