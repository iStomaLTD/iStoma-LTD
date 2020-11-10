namespace CCL.UI.FormulareComune
{
    partial class frmAjustarePret
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
            this.lblPretVechi = new CCL.UI.LabelPersonalizat(this.components);
            this.lblAjustare = new CCL.UI.LabelPersonalizat(this.components);
            this.lblValoare = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlValidareAnulare = new CCL.UI.Caramizi.controlValidareAnulare();
            this.lblValoareVeche = new CCL.UI.LabelPersonalizat(this.components);
            this.lblSimbolProcent = new CCL.UI.LabelPersonalizat(this.components);
            this.txtAjustare = new CCL.UI.Caramizi.MaskedTextBoxGuma();
            this.txtPret = new CCL.UI.Caramizi.MaskedTextBoxGuma();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(426, 19);
            this.lblTitluEcran.Text = "frmAjustarePret";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(425, 0);
            // 
            // lblPretVechi
            // 
            this.lblPretVechi.Location = new System.Drawing.Point(8, 27);
            this.lblPretVechi.Name = "lblPretVechi";
            this.lblPretVechi.Size = new System.Drawing.Size(92, 13);
            this.lblPretVechi.TabIndex = 4;
            this.lblPretVechi.Text = "Preț vechi";
            this.lblPretVechi.ToolTipText = null;
            this.lblPretVechi.ToolTipTitle = null;
            // 
            // lblAjustare
            // 
            this.lblAjustare.Location = new System.Drawing.Point(8, 59);
            this.lblAjustare.Name = "lblAjustare";
            this.lblAjustare.Size = new System.Drawing.Size(92, 13);
            this.lblAjustare.TabIndex = 5;
            this.lblAjustare.Text = "Ajustare";
            this.lblAjustare.ToolTipText = null;
            this.lblAjustare.ToolTipTitle = null;
            // 
            // lblValoare
            // 
            this.lblValoare.Location = new System.Drawing.Point(8, 90);
            this.lblValoare.Name = "lblValoare";
            this.lblValoare.Size = new System.Drawing.Size(92, 13);
            this.lblValoare.TabIndex = 6;
            this.lblValoare.Text = "Preț ajustat";
            this.lblValoare.ToolTipText = null;
            this.lblValoare.ToolTipTitle = null;
            // 
            // ctrlValidareAnulare
            // 
            this.ctrlValidareAnulare.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrlValidareAnulare.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulare.Location = new System.Drawing.Point(144, 128);
            this.ctrlValidareAnulare.Name = "ctrlValidareAnulare";
            this.ctrlValidareAnulare.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulare.TabIndex = 2;
            this.ctrlValidareAnulare.Validare += new System.EventHandler(this.ctrlValidareAnulare_Validare);
            this.ctrlValidareAnulare.Anulare += new System.EventHandler(this.ctrlValidareAnulare_Anulare);
            // 
            // lblValoareVeche
            // 
            this.lblValoareVeche.Location = new System.Drawing.Point(106, 27);
            this.lblValoareVeche.Name = "lblValoareVeche";
            this.lblValoareVeche.Size = new System.Drawing.Size(92, 13);
            this.lblValoareVeche.TabIndex = 3;
            this.lblValoareVeche.Text = "Pret vechi";
            this.lblValoareVeche.ToolTipText = null;
            this.lblValoareVeche.ToolTipTitle = null;
            // 
            // lblSimbolProcent
            // 
            this.lblSimbolProcent.AutoSize = true;
            this.lblSimbolProcent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSimbolProcent.Location = new System.Drawing.Point(181, 58);
            this.lblSimbolProcent.Name = "lblSimbolProcent";
            this.lblSimbolProcent.Size = new System.Drawing.Size(20, 17);
            this.lblSimbolProcent.TabIndex = 8;
            this.lblSimbolProcent.Text = "%";
            this.lblSimbolProcent.ToolTipText = null;
            this.lblSimbolProcent.ToolTipTitle = null;
            // 
            // txtAjustare
            // 
            this.txtAjustare.AcceptButton = null;
            this.txtAjustare.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtAjustare.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtAjustare.BackColor = System.Drawing.SystemColors.Control;
            this.txtAjustare.Location = new System.Drawing.Point(106, 55);
            this.txtAjustare.Name = "txtAjustare";
            this.txtAjustare.ProprietateCorespunzatoare = null;
            this.txtAjustare.Size = new System.Drawing.Size(71, 23);
            this.txtAjustare.TabIndex = 0;
            this.txtAjustare.Text = "0";
            this.txtAjustare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtAjustare.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.txtAjustare.UtilizeazaButonGuma = false;
            this.txtAjustare.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAjustare.ValoareDouble = 0D;
            this.txtAjustare.KeyUpPersonalizat += new System.Windows.Forms.KeyEventHandler(this.txtAjustare_KeyUpPersonalizat);
            // 
            // txtPret
            // 
            this.txtPret.AcceptButton = null;
            this.txtPret.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtPret.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtPret.BackColor = System.Drawing.SystemColors.Control;
            this.txtPret.Location = new System.Drawing.Point(106, 86);
            this.txtPret.Name = "txtPret";
            this.txtPret.ProprietateCorespunzatoare = null;
            this.txtPret.Size = new System.Drawing.Size(168, 24);
            this.txtPret.TabIndex = 1;
            this.txtPret.Text = "0";
            this.txtPret.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtPret.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.txtPret.UtilizeazaButonGuma = false;
            this.txtPret.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPret.ValoareDouble = 0D;
            this.txtPret.KeyUpPersonalizat += new System.Windows.Forms.KeyEventHandler(this.txtPret_KeyUpPersonalizat);
            // 
            // frmAjustarePret
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(448, 163);
            this.Controls.Add(this.txtPret);
            this.Controls.Add(this.lblSimbolProcent);
            this.Controls.Add(this.lblValoareVeche);
            this.Controls.Add(this.ctrlValidareAnulare);
            this.Controls.Add(this.lblValoare);
            this.Controls.Add(this.lblAjustare);
            this.Controls.Add(this.lblPretVechi);
            this.Controls.Add(this.txtAjustare);
            this.MinimumSize = new System.Drawing.Size(448, 163);
            this.Name = "frmAjustarePret";
            this.Text = "frmAjustarePret";
            this.Load += new System.EventHandler(this.frmAjustarePret_Load);
            this.Controls.SetChildIndex(this.txtAjustare, 0);
            this.Controls.SetChildIndex(this.lblPretVechi, 0);
            this.Controls.SetChildIndex(this.lblAjustare, 0);
            this.Controls.SetChildIndex(this.lblValoare, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulare, 0);
            this.Controls.SetChildIndex(this.lblValoareVeche, 0);
            this.Controls.SetChildIndex(this.lblSimbolProcent, 0);
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.txtPret, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LabelPersonalizat lblPretVechi;
        private LabelPersonalizat lblAjustare;
        private LabelPersonalizat lblValoare;
        private Caramizi.controlValidareAnulare ctrlValidareAnulare;
        private LabelPersonalizat lblValoareVeche;
        private LabelPersonalizat lblSimbolProcent;
        private Caramizi.MaskedTextBoxGuma txtAjustare;
        private Caramizi.MaskedTextBoxGuma txtPret;
    }
}