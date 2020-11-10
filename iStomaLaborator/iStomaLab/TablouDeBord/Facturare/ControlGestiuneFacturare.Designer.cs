namespace iStomaLab.TablouDeBord.Facturare
{
    partial class ControlGestiuneFacturare
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
            CCL.UI.ControalePersonalizate.ToolStripPersonalizat tsDosarClient;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlGestiuneFacturare));
            this.mnuBtnLucrariNefacturate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBtnFacturiEmise = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBtnIncasari = new System.Windows.Forms.ToolStripButton();
            this.panelFacturare = new CCL.UI.PanelPersonalizat(this.components);
            tsDosarClient = new CCL.UI.ControalePersonalizate.ToolStripPersonalizat();
            tsDosarClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsDosarClient
            // 
            tsDosarClient.AllowMerge = false;
            tsDosarClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tsDosarClient.AutoSize = false;
            tsDosarClient.BackColor = System.Drawing.SystemColors.Control;
            tsDosarClient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            tsDosarClient.Dock = System.Windows.Forms.DockStyle.None;
            tsDosarClient.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            tsDosarClient.ImageScalingSize = new System.Drawing.Size(20, 20);
            tsDosarClient.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBtnLucrariNefacturate,
            this.toolStripSeparator1,
            this.mnuBtnFacturiEmise,
            this.toolStripSeparator6,
            this.mnuBtnIncasari});
            tsDosarClient.Location = new System.Drawing.Point(0, 0);
            tsDosarClient.Name = "tsDosarClient";
            tsDosarClient.Padding = new System.Windows.Forms.Padding(0);
            tsDosarClient.Size = new System.Drawing.Size(743, 38);
            tsDosarClient.Stretch = true;
            tsDosarClient.TabIndex = 4;
            tsDosarClient.Text = "toolStripPersonalizat1";
            // 
            // mnuBtnLucrariNefacturate
            // 
            this.mnuBtnLucrariNefacturate.Image = global::iStomaLab.Properties.Resources.dinte;
            this.mnuBtnLucrariNefacturate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuBtnLucrariNefacturate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnLucrariNefacturate.Name = "mnuBtnLucrariNefacturate";
            this.mnuBtnLucrariNefacturate.Size = new System.Drawing.Size(110, 35);
            this.mnuBtnLucrariNefacturate.Text = "Lucrari nefacturate";
            this.mnuBtnLucrariNefacturate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // mnuBtnFacturiEmise
            // 
            this.mnuBtnFacturiEmise.Image = global::iStomaLab.Properties.Resources.planDeTratament;
            this.mnuBtnFacturiEmise.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuBtnFacturiEmise.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnFacturiEmise.Name = "mnuBtnFacturiEmise";
            this.mnuBtnFacturiEmise.Size = new System.Drawing.Size(81, 35);
            this.mnuBtnFacturiEmise.Text = "Facturi emise";
            this.mnuBtnFacturiEmise.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 38);
            // 
            // mnuBtnIncasari
            // 
            this.mnuBtnIncasari.Image = ((System.Drawing.Image)(resources.GetObject("mnuBtnIncasari.Image")));
            this.mnuBtnIncasari.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuBtnIncasari.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnIncasari.Name = "mnuBtnIncasari";
            this.mnuBtnIncasari.Size = new System.Drawing.Size(51, 35);
            this.mnuBtnIncasari.Text = "Incasari";
            this.mnuBtnIncasari.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // panelFacturare
            // 
            this.panelFacturare.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFacturare.BackColor = System.Drawing.Color.White;
            this.panelFacturare.Location = new System.Drawing.Point(-1, 41);
            this.panelFacturare.Name = "panelFacturare";
            this.panelFacturare.Size = new System.Drawing.Size(745, 445);
            this.panelFacturare.TabIndex = 5;
            this.panelFacturare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // ControlGestiuneFacturare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(tsDosarClient);
            this.Controls.Add(this.panelFacturare);
            this.Name = "ControlGestiuneFacturare";
            this.Size = new System.Drawing.Size(743, 485);
            tsDosarClient.ResumeLayout(false);
            tsDosarClient.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton mnuBtnLucrariNefacturate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton mnuBtnFacturiEmise;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton mnuBtnIncasari;
        private CCL.UI.PanelPersonalizat panelFacturare;
    }
}
