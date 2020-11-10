using static CDL.iStomaLab.CDefinitiiComune;

namespace iStomaLab.TablouDeBord.Clienti
{
    partial class FormDosarClient
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
            CCL.UI.ControalePersonalizate.ToolStripPersonalizat tsDosarClient;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDosarClient));
            this.mnuBtnClientDate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBtnClientComenzi = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBtnClientPlati = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBtnClientListaPreturi = new System.Windows.Forms.ToolStripButton();
            this.panelDosarClient = new CCL.UI.Caramizi.PanelContainerCCL();
            tsDosarClient = new CCL.UI.ControalePersonalizate.ToolStripPersonalizat();
            tsDosarClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitluEcran.Size = new System.Drawing.Size(1079, 19);
            this.lblTitluEcran.Text = "FormDosarClient";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(1076, 0);
            this.btnInchidereEcran.Margin = new System.Windows.Forms.Padding(2);
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
            this.mnuBtnClientDate,
            this.toolStripSeparator1,
            this.mnuBtnClientComenzi,
            this.toolStripSeparator6,
            this.mnuBtnClientPlati,
            this.toolStripSeparator2,
            this.mnuBtnClientListaPreturi});
            tsDosarClient.Location = new System.Drawing.Point(1, 19);
            tsDosarClient.Name = "tsDosarClient";
            tsDosarClient.Padding = new System.Windows.Forms.Padding(0);
            tsDosarClient.Size = new System.Drawing.Size(1098, 38);
            tsDosarClient.Stretch = true;
            tsDosarClient.TabIndex = 3;
            tsDosarClient.Text = "toolStripPersonalizat1";
            // 
            // mnuBtnClientDate
            // 
            this.mnuBtnClientDate.Image = global::iStomaLab.Properties.Resources.person;
            this.mnuBtnClientDate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuBtnClientDate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnClientDate.Name = "mnuBtnClientDate";
            this.mnuBtnClientDate.Size = new System.Drawing.Size(35, 35);
            this.mnuBtnClientDate.Text = "Date";
            this.mnuBtnClientDate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // mnuBtnClientComenzi
            // 
            this.mnuBtnClientComenzi.Image = global::iStomaLab.Properties.Resources.planDeTratament;
            this.mnuBtnClientComenzi.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuBtnClientComenzi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnClientComenzi.Name = "mnuBtnClientComenzi";
            this.mnuBtnClientComenzi.Size = new System.Drawing.Size(58, 35);
            this.mnuBtnClientComenzi.Text = "Comenzi";
            this.mnuBtnClientComenzi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 38);
            // 
            // mnuBtnClientPlati
            // 
            this.mnuBtnClientPlati.Image = ((System.Drawing.Image)(resources.GetObject("mnuBtnClientPlati.Image")));
            this.mnuBtnClientPlati.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuBtnClientPlati.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnClientPlati.Name = "mnuBtnClientPlati";
            this.mnuBtnClientPlati.Size = new System.Drawing.Size(34, 35);
            this.mnuBtnClientPlati.Text = "Plati";
            this.mnuBtnClientPlati.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // mnuBtnClientListaPreturi
            // 
            this.mnuBtnClientListaPreturi.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuBtnClientListaPreturi.Image = global::iStomaLab.Properties.Resources.Barter;
            this.mnuBtnClientListaPreturi.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuBtnClientListaPreturi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnClientListaPreturi.Name = "mnuBtnClientListaPreturi";
            this.mnuBtnClientListaPreturi.Size = new System.Drawing.Size(73, 35);
            this.mnuBtnClientListaPreturi.Text = "Lista preturi";
            this.mnuBtnClientListaPreturi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // panelDosarClient
            // 
            this.panelDosarClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDosarClient.AutoScaleDimensions = new System.Drawing.SizeF(0F, 0F);
            this.panelDosarClient.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.panelDosarClient.BackColor = System.Drawing.Color.White;
            this.panelDosarClient.Location = new System.Drawing.Point(2, 58);
            this.panelDosarClient.Margin = new System.Windows.Forms.Padding(2);
            this.panelDosarClient.Name = "panelDosarClient";
            this.panelDosarClient.Size = new System.Drawing.Size(1096, 628);
            this.panelDosarClient.TabIndex = 2;
            this.panelDosarClient.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // FormDosarClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1100, 688);
            this.Controls.Add(tsDosarClient);
            this.Controls.Add(this.panelDosarClient);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormDosarClient";
            this.PermiteDeplasareaEcranului = true;
            this.PermiteMaximizareaEcranului = true;
            this.Text = "FormDosarClient";
            this.TipDeschidere = CCL.UI.CEnumerariComune.EnumTipDeschidere.CentrulEcranului;
            this.Controls.SetChildIndex(this.panelDosarClient, 0);
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(tsDosarClient, 0);
            tsDosarClient.ResumeLayout(false);
            tsDosarClient.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.Caramizi.PanelContainerCCL panelDosarClient;
        private System.Windows.Forms.ToolStripButton mnuBtnClientDate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton mnuBtnClientComenzi;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton mnuBtnClientPlati;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton mnuBtnClientListaPreturi;
    }
}