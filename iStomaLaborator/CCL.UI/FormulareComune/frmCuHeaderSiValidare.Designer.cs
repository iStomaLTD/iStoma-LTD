namespace CCL.UI.FormulareComune
{
    partial class frmCuHeaderSiValidare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCuHeaderSiValidare));
            this.panelGlobal = new CCL.UI.PanelPersonalizat(this.components);
            this.btnValidare = new CCL.UI.ButtonPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // panelGlobal
            // 
            this.panelGlobal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGlobal.BackColor = System.Drawing.Color.Linen;
            this.panelGlobal.Location = new System.Drawing.Point(1, 18);
            this.panelGlobal.Name = "panelGlobal";
            this.panelGlobal.Size = new System.Drawing.Size(282, 222);
            this.panelGlobal.TabIndex = 2;
            this.panelGlobal.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // btnValidare
            // 
            this.btnValidare.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnValidare.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnValidare.Image = ((System.Drawing.Image)(resources.GetObject("btnValidare.Image")));
            this.btnValidare.Location = new System.Drawing.Point(91, 242);
            this.btnValidare.Name = "btnValidare";
            this.btnValidare.Size = new System.Drawing.Size(102, 23);
            this.btnValidare.TabIndex = 3;
            this.btnValidare.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Validare;
            this.btnValidare.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnValidare.UseVisualStyleBackColor = true;
            // 
            // frmCuHeaderSiValidare
            // 
            this.AcceptButton = this.btnValidare;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 268);
            this.Controls.Add(this.btnValidare);
            this.Controls.Add(this.panelGlobal);
            this.Name = "frmCuHeaderSiValidare";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.panelGlobal, 0);
            this.Controls.SetChildIndex(this.btnValidare, 0);
            this.ResumeLayout(false);

        }

        #endregion

        protected PanelPersonalizat panelGlobal;
        protected ButtonPersonalizat btnValidare;
    }
}