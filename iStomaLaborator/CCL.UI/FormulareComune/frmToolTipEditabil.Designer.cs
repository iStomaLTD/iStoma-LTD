namespace CCL.UI.FormulareComune
{
    partial class frmToolTipEditabil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmToolTipEditabil));
            this.timerInchidere = new System.Windows.Forms.Timer(this.components);
            this.timerDeschidere = new System.Windows.Forms.Timer(this.components);
            this.panelTextMultilinie = new CCL.UI.PanelPersonalizat(this.components);
            this.btnSalveaza = new CCL.UI.ButtonPersonalizat(this.components);
            this.txtContinut = new CCL.UI.Caramizi.TextBoxGuma();
            this.lblTitlu = new CCL.UI.LabelPersonalizat(this.components);
            this.picSus = new CCL.UI.PictureBoxPersonalizat(this.components);
            this.labelPersonalizat1 = new CCL.UI.LabelPersonalizat(this.components);
            this.btnSterge = new CCL.UI.ButtonPersonalizat(this.components);
            this.panelTextMultilinie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSus)).BeginInit();
            this.SuspendLayout();
            // 
            // timerInchidere
            // 
            this.timerInchidere.Interval = 500;
            this.timerInchidere.Tick += new System.EventHandler(this.timerInchidere_Tick);
            // 
            // timerDeschidere
            // 
            this.timerDeschidere.Interval = 500;
            this.timerDeschidere.Tick += new System.EventHandler(this.timerDeschidere_Tick);
            // 
            // panelTextMultilinie
            // 
            this.panelTextMultilinie.BackColor = System.Drawing.SystemColors.Control;
            this.panelTextMultilinie.Controls.Add(this.btnSterge);
            this.panelTextMultilinie.Controls.Add(this.btnSalveaza);
            this.panelTextMultilinie.Controls.Add(this.txtContinut);
            this.panelTextMultilinie.Controls.Add(this.lblTitlu);
            this.panelTextMultilinie.Location = new System.Drawing.Point(14, 19);
            this.panelTextMultilinie.Name = "panelTextMultilinie";
            this.panelTextMultilinie.Size = new System.Drawing.Size(319, 171);
            this.panelTextMultilinie.TabIndex = 2;
            this.panelTextMultilinie.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.panelTextMultilinie.Visible = false;
            this.panelTextMultilinie.Enter += new System.EventHandler(this.panelDetalii_Enter);
            this.panelTextMultilinie.MouseEnter += new System.EventHandler(this.panelDetalii_MouseEnter);
            // 
            // btnSalveaza
            // 
            this.btnSalveaza.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnSalveaza.Image = ((System.Drawing.Image)(resources.GetObject("btnSalveaza.Image")));
            this.btnSalveaza.Location = new System.Drawing.Point(122, 146);
            this.btnSalveaza.Name = "btnSalveaza";
            this.btnSalveaza.Size = new System.Drawing.Size(75, 23);
            this.btnSalveaza.TabIndex = 7;
            this.btnSalveaza.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Validare;
            this.btnSalveaza.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnSalveaza.UseVisualStyleBackColor = true;
            this.btnSalveaza.Click += new System.EventHandler(this.btnSalveaza_Click);
            // 
            // txtContinut
            // 
            this.txtContinut.AcceptButton = null;
            this.txtContinut.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtContinut.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtContinut.IsInReadOnlyMode = true;
            this.txtContinut.Location = new System.Drawing.Point(4, 41);
            this.txtContinut.MaxLength = 32767;
            this.txtContinut.Multiline = true;
            this.txtContinut.Name = "txtContinut";
            this.txtContinut.ProprietateCorespunzatoare = null;
            this.txtContinut.RaiseEventLaModificareProgramatica = false;
            this.txtContinut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContinut.Size = new System.Drawing.Size(312, 100);
            this.txtContinut.TabIndex = 6;
            this.txtContinut.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtContinut.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtContinut.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtContinut.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtContinut.UseSystemPasswordChar = false;
            // 
            // lblTitlu
            // 
            this.lblTitlu.AutoSize = true;
            this.lblTitlu.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitlu.Location = new System.Drawing.Point(3, 7);
            this.lblTitlu.Name = "lblTitlu";
            this.lblTitlu.Size = new System.Drawing.Size(190, 22);
            this.lblTitlu.TabIndex = 0;
            this.lblTitlu.Text = "Duminica - 13/02/1983";
            this.lblTitlu.ToolTipText = null;
            this.lblTitlu.ToolTipTitle = null;
            // 
            // picSus
            // 
            this.picSus.BackColor = System.Drawing.Color.Transparent;
            this.picSus.ContinutToolTip = null;
            this.picSus.IcoanaToolTip = System.Windows.Forms.ToolTipIcon.Info;
            this.picSus.Image = global::CCL.UI.Properties.Resources.ToolTipChenar;
            this.picSus.Location = new System.Drawing.Point(0, 0);
            this.picSus.Name = "picSus";
            this.picSus.Size = new System.Drawing.Size(350, 200);
            this.picSus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSus.TabIndex = 1;
            this.picSus.TabStop = false;
            this.picSus.TitluToolTip = "";
            this.picSus.UtilizamToolTip = false;
            this.picSus.MouseEnter += new System.EventHandler(this.picSus_MouseEnter);
            this.picSus.MouseLeave += new System.EventHandler(this.picSus_MouseLeave);
            // 
            // labelPersonalizat1
            // 
            this.labelPersonalizat1.AutoSize = true;
            this.labelPersonalizat1.Location = new System.Drawing.Point(7, 30);
            this.labelPersonalizat1.Name = "labelPersonalizat1";
            this.labelPersonalizat1.Size = new System.Drawing.Size(142, 13);
            this.labelPersonalizat1.TabIndex = 2;
            this.labelPersonalizat1.Text = "Sedinta astazi 18:30 = 19:40";
            this.labelPersonalizat1.ToolTipText = null;
            this.labelPersonalizat1.ToolTipTitle = null;
            // 
            // btnSterge
            // 
            this.btnSterge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSterge.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnSterge.Image = ((System.Drawing.Image)(resources.GetObject("btnSterge.Image")));
            this.btnSterge.Location = new System.Drawing.Point(282, 146);
            this.btnSterge.Name = "btnSterge";
            this.btnSterge.Size = new System.Drawing.Size(34, 23);
            this.btnSterge.TabIndex = 8;
            this.btnSterge.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Stergere;
            this.btnSterge.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnSterge.UseVisualStyleBackColor = true;
            this.btnSterge.Click += new System.EventHandler(this.btnSterge_Click);
            // 
            // frmToolTipEditabil
            // 
            this.AcceptButton = this.btnSalveaza;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(350, 200);
            this.Controls.Add(this.panelTextMultilinie);
            this.Controls.Add(this.picSus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmToolTipEditabil";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmToolTipPacientAgenda";
            this.TransparencyKey = System.Drawing.Color.DarkSeaGreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmToolTipPacientAgenda_FormClosing);
            this.panelTextMultilinie.ResumeLayout(false);
            this.panelTextMultilinie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.PictureBoxPersonalizat picSus;
        private System.Windows.Forms.Timer timerInchidere;
        private System.Windows.Forms.Timer timerDeschidere;
        private CCL.UI.LabelPersonalizat labelPersonalizat1;
        private CCL.UI.PanelPersonalizat panelTextMultilinie;
        private CCL.UI.LabelPersonalizat lblTitlu;
        private CCL.UI.Caramizi.TextBoxGuma txtContinut;
        private ButtonPersonalizat btnSalveaza;
        private ButtonPersonalizat btnSterge;
    }
}