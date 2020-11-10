namespace CCL.UI.FormulareComune
{
    partial class frmAfisareControl
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
            this.panelGlobal = new CCL.UI.PanelPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Text = "frmAfisareControl";
            // 
            // panelGlobal
            // 
            this.panelGlobal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGlobal.BackColor = System.Drawing.Color.Linen;
            this.panelGlobal.Location = new System.Drawing.Point(1, 19);
            this.panelGlobal.Name = "panelGlobal";
            this.panelGlobal.Size = new System.Drawing.Size(282, 242);
            this.panelGlobal.TabIndex = 2;
            this.panelGlobal.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Tab;
            // 
            // frmAfisareControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.panelGlobal);
            this.Name = "frmAfisareControl";
            this.Text = "frmAfisareControl";
            this.Shown += new System.EventHandler(this.frmAfisareControl_Shown);
            this.SizeChanged += new System.EventHandler(this.frmAfisareControl_SizeChanged);
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.panelGlobal, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private PanelPersonalizat panelGlobal;
    }
}