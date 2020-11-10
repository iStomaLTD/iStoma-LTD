namespace CCL.UI
{
    partial class frmCautare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCautare));
            this.panelPersonalizat1 = new CCL.UI.PanelPersonalizat(this.components);
            this.panelGlobal = new CCL.UI.PanelPersonalizat(this.components);
            this.lblCauta = new CCL.UI.LabelPersonalizat(this.components);
            this.lblRezultat = new CCL.UI.LabelPersonalizat(this.components);
            this.txtCauta = new CCL.UI.Caramizi.TextBoxGuma();
            this.btnInapoi = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnInainte = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnValidare = new CCL.UI.ButtonPersonalizat(this.components);
            this.panelPersonalizat1.SuspendLayout();
            this.panelGlobal.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(292, 19);
            this.lblTitluEcran.Text = "Caută";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(291, 0);
            // 
            // panelPersonalizat1
            // 
            this.panelPersonalizat1.BackColor = System.Drawing.Color.Transparent;
            this.panelPersonalizat1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPersonalizat1.Controls.Add(this.panelGlobal);
            this.panelPersonalizat1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPersonalizat1.Location = new System.Drawing.Point(0, 0);
            this.panelPersonalizat1.Name = "panelPersonalizat1";
            this.panelPersonalizat1.Size = new System.Drawing.Size(314, 83);
            this.panelPersonalizat1.TabIndex = 1;
            this.panelPersonalizat1.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // panelGlobal
            // 
            this.panelGlobal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGlobal.BackColor = System.Drawing.Color.Linen;
            this.panelGlobal.Controls.Add(this.btnValidare);
            this.panelGlobal.Controls.Add(this.lblCauta);
            this.panelGlobal.Controls.Add(this.lblRezultat);
            this.panelGlobal.Controls.Add(this.txtCauta);
            this.panelGlobal.Controls.Add(this.btnInapoi);
            this.panelGlobal.Controls.Add(this.btnInainte);
            this.panelGlobal.Location = new System.Drawing.Point(1, 17);
            this.panelGlobal.Name = "panelGlobal";
            this.panelGlobal.Size = new System.Drawing.Size(311, 64);
            this.panelGlobal.TabIndex = 7;
            this.panelGlobal.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Tab;
            // 
            // lblCauta
            // 
            this.lblCauta.Location = new System.Drawing.Point(3, 10);
            this.lblCauta.Name = "lblCauta";
            this.lblCauta.Size = new System.Drawing.Size(65, 13);
            this.lblCauta.TabIndex = 6;
            this.lblCauta.Text = "Caută";
            this.lblCauta.ToolTipText = null;
            this.lblCauta.ToolTipTitle = null;
            // 
            // lblRezultat
            // 
            this.lblRezultat.AutoSize = true;
            this.lblRezultat.Location = new System.Drawing.Point(93, 39);
            this.lblRezultat.Name = "lblRezultat";
            this.lblRezultat.Size = new System.Drawing.Size(24, 13);
            this.lblRezultat.TabIndex = 3;
            this.lblRezultat.Text = "2/6";
            this.lblRezultat.ToolTipText = null;
            this.lblRezultat.ToolTipTitle = null;
            // 
            // txtCauta
            // 
            this.txtCauta.AcceptButton = null;
            this.txtCauta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCauta.IsInReadOnlyMode = false;
            this.txtCauta.Location = new System.Drawing.Point(71, 6);
            this.txtCauta.MaxLength = 32767;
            this.txtCauta.Multiline = false;
            this.txtCauta.Name = "txtCauta";
            this.txtCauta.ProprietateCorespunzatoare = null;
            this.txtCauta.RaiseEventLaModificareProgramatica = false;
            this.txtCauta.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCauta.Size = new System.Drawing.Size(235, 22);
            this.txtCauta.TabIndex = 0;
            this.txtCauta.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCauta.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCauta.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCauta.UseSystemPasswordChar = false;
            this.txtCauta.CerereUpdate += new CCL.UI.CEvenimente.ZonaModificata(this.txtCauta_CerereUpdate);
            this.txtCauta.KeyUpPersonalizat += new System.Windows.Forms.KeyEventHandler(this.txtCauta_KeyUpPersonalizat);
            // 
            // btnInapoi
            // 
            this.btnInapoi.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnInapoi.Image = ((System.Drawing.Image)(resources.GetObject("btnInapoi.Image")));
            this.btnInapoi.Location = new System.Drawing.Point(3, 33);
            this.btnInapoi.Name = "btnInapoi";
            this.btnInapoi.Size = new System.Drawing.Size(39, 25);
            this.btnInapoi.TabIndex = 4;
            this.btnInapoi.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Stanga;
            this.btnInapoi.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnInapoi.UseVisualStyleBackColor = true;
            this.btnInapoi.Click += new System.EventHandler(this.btnInapoi_Click);
            // 
            // btnInainte
            // 
            this.btnInainte.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnInainte.Image = ((System.Drawing.Image)(resources.GetObject("btnInainte.Image")));
            this.btnInainte.Location = new System.Drawing.Point(48, 33);
            this.btnInainte.Name = "btnInainte";
            this.btnInainte.Size = new System.Drawing.Size(39, 25);
            this.btnInainte.TabIndex = 5;
            this.btnInainte.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Dreapta;
            this.btnInainte.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnInainte.UseVisualStyleBackColor = true;
            this.btnInainte.Click += new System.EventHandler(this.btnInainte_Click);
            // 
            // btnValidare
            // 
            this.btnValidare.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnValidare.Image = ((System.Drawing.Image)(resources.GetObject("btnValidare.Image")));
            this.btnValidare.Location = new System.Drawing.Point(267, 33);
            this.btnValidare.Name = "btnValidare";
            this.btnValidare.Size = new System.Drawing.Size(39, 25);
            this.btnValidare.TabIndex = 7;
            this.btnValidare.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Validare;
            this.btnValidare.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnValidare.UseVisualStyleBackColor = true;
            this.btnValidare.Click += new System.EventHandler(this.btnValidare_Click);
            // 
            // frmCautare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = null;
            this.ClientSize = new System.Drawing.Size(314, 83);
            this.Controls.Add(this.panelPersonalizat1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCautare";
            this.ShowIcon = false;
            this.Text = "Caută";
            this.Shown += new System.EventHandler(this.frmCautare_Shown);
            this.Controls.SetChildIndex(this.panelPersonalizat1, 0);
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.panelPersonalizat1.ResumeLayout(false);
            this.panelGlobal.ResumeLayout(false);
            this.panelGlobal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.Caramizi.TextBoxGuma txtCauta;
        private PanelPersonalizat panelPersonalizat1;
        private LabelPersonalizat lblRezultat;
        private ButtonPersonalizat btnInapoi;
        private ButtonPersonalizat btnInainte;
        private LabelPersonalizat lblCauta;
        private PanelPersonalizat panelGlobal;
        private ButtonPersonalizat btnValidare;
    }
}