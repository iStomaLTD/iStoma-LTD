namespace CCL.UI.Caramizi
{
    partial class controlValoareMonetara
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
            this.ctrlLeiEUR = new CCL.UI.Caramizi.controlLeiEuro();
            this.txtValoare = new CCL.UI.Caramizi.MaskedTextBoxGuma();
            this.SuspendLayout();
            // 
            // ctrlLeiEUR
            // 
            this.ctrlLeiEUR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlLeiEUR.IsInReadOnlyMode = false;
            this.ctrlLeiEUR.Location = new System.Drawing.Point(141, 0);
            this.ctrlLeiEUR.Moneda = CDL.iStomaLab.CDefinitiiComune.EnumTipMoneda.Lei;
            this.ctrlLeiEUR.Name = "ctrlLeiEUR";
            this.ctrlLeiEUR.Size = new System.Drawing.Size(112, 24);
            this.ctrlLeiEUR.TabIndex = 1;
            this.ctrlLeiEUR.MonedaSchimbata += new System.EventHandler(this.ctrlLeiEUR_MonedaSchimbata);
            // 
            // txtValoare
            // 
            this.txtValoare.AcceptButton = null;
            this.txtValoare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValoare.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtValoare.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtValoare.BackColor = System.Drawing.SystemColors.Control;
            this.txtValoare.Location = new System.Drawing.Point(0, 2);
            this.txtValoare.Name = "txtValoare";
            this.txtValoare.ProprietateCorespunzatoare = null;
            this.txtValoare.Size = new System.Drawing.Size(134, 21);
            this.txtValoare.TabIndex = 0;
            this.txtValoare.Text = "0";
            this.txtValoare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtValoare.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.txtValoare.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtValoare.ValoareDouble = 0D;
            this.txtValoare.CerereUpdate += new CCL.UI.CEvenimente.ZonaModificata(this.txtValoare_CerereUpdate);
            this.txtValoare.KeyUpPersonalizat += new System.Windows.Forms.KeyEventHandler(this.txtValoare_KeyUpPersonalizat);
            // 
            // controlValoareMonetara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlLeiEUR);
            this.Controls.Add(this.txtValoare);
            this.Name = "controlValoareMonetara";
            this.Size = new System.Drawing.Size(254, 24);
            this.ResumeLayout(false);

        }

        #endregion

        private MaskedTextBoxGuma txtValoare;
        private controlLeiEuro ctrlLeiEUR;
    }
}
