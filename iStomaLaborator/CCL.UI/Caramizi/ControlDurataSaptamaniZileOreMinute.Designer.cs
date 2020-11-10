namespace CCL.UI.Caramizi
{
    partial class ControlDurataSaptamaniZileOreMinute
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.flpOptiuniDurata = new CCL.UI.FlowLayoutPanelPersonalizat();
            this.rbSaptamani = new CCL.UI.RadioButtonPersonalizat();
            this.rbZile = new CCL.UI.RadioButtonPersonalizat();
            this.rbOre = new CCL.UI.RadioButtonPersonalizat();
            this.rbMinute = new CCL.UI.RadioButtonPersonalizat();
            this.txtDurata = new CCL.UI.Caramizi.MaskedTextBoxGuma();
            this.flpOptiuniDurata.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpOptiuniDurata
            // 
            this.flpOptiuniDurata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpOptiuniDurata.Controls.Add(this.rbSaptamani);
            this.flpOptiuniDurata.Controls.Add(this.rbZile);
            this.flpOptiuniDurata.Controls.Add(this.rbOre);
            this.flpOptiuniDurata.Controls.Add(this.rbMinute);
            this.flpOptiuniDurata.Location = new System.Drawing.Point(107, 0);
            this.flpOptiuniDurata.Name = "flpOptiuniDurata";
            this.flpOptiuniDurata.Size = new System.Drawing.Size(244, 23);
            this.flpOptiuniDurata.TabIndex = 1;
            // 
            // rbSaptamani
            // 
            this.rbSaptamani.AutoSize = true;
            this.rbSaptamani.Location = new System.Drawing.Point(3, 3);
            this.rbSaptamani.Name = "rbSaptamani";
            this.rbSaptamani.Size = new System.Drawing.Size(75, 17);
            this.rbSaptamani.TabIndex = 0;
            this.rbSaptamani.TabStop = true;
            this.rbSaptamani.Text = "Săptămâni";
            this.rbSaptamani.UseVisualStyleBackColor = true;
            this.rbSaptamani.CheckedChanged += new System.EventHandler(this.rbSaptamani_CheckedChanged);
            // 
            // rbZile
            // 
            this.rbZile.AutoSize = true;
            this.rbZile.Location = new System.Drawing.Point(84, 3);
            this.rbZile.Name = "rbZile";
            this.rbZile.Size = new System.Drawing.Size(42, 17);
            this.rbZile.TabIndex = 1;
            this.rbZile.TabStop = true;
            this.rbZile.Text = "Zile";
            this.rbZile.UseVisualStyleBackColor = true;
            this.rbZile.CheckedChanged += new System.EventHandler(this.rbZile_CheckedChanged);
            // 
            // rbOre
            // 
            this.rbOre.AutoSize = true;
            this.rbOre.Location = new System.Drawing.Point(132, 3);
            this.rbOre.Name = "rbOre";
            this.rbOre.Size = new System.Drawing.Size(42, 17);
            this.rbOre.TabIndex = 2;
            this.rbOre.TabStop = true;
            this.rbOre.Text = "Ore";
            this.rbOre.UseVisualStyleBackColor = true;
            this.rbOre.CheckedChanged += new System.EventHandler(this.rbOre_CheckedChanged);
            // 
            // rbMinute
            // 
            this.rbMinute.AutoSize = true;
            this.rbMinute.Location = new System.Drawing.Point(180, 3);
            this.rbMinute.Name = "rbMinute";
            this.rbMinute.Size = new System.Drawing.Size(57, 17);
            this.rbMinute.TabIndex = 3;
            this.rbMinute.TabStop = true;
            this.rbMinute.Text = "Minute";
            this.rbMinute.UseVisualStyleBackColor = true;
            this.rbMinute.CheckedChanged += new System.EventHandler(this.rbMinute_CheckedChanged);
            // 
            // txtDurata
            // 
            this.txtDurata.AcceptButton = null;
            this.txtDurata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDurata.IsInReadOnlyMode = false;
            this.txtDurata.Location = new System.Drawing.Point(0, 0);
            this.txtDurata.MaxLength = 32767;
            this.txtDurata.Name = "txtDurata";
            this.txtDurata.ProprietateCorespunzatoare = null;
            this.txtDurata.Size = new System.Drawing.Size(103, 24);
            this.txtDurata.TabIndex = 0;
            this.txtDurata.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.txtDurata.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDurata.ValoareIntreaga = 0;
            this.txtDurata.CerereUpdate += new CCL.UI.CEvenimente.ZonaModificata(this.txtDurata_CerereUpdate);
            // 
            // ControlDurataSaptamaniZileOreMinute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpOptiuniDurata);
            this.Controls.Add(this.txtDurata);
            this.Name = "ControlDurataSaptamaniZileOreMinute";
            this.Size = new System.Drawing.Size(350, 23);
            this.flpOptiuniDurata.ResumeLayout(false);
            this.flpOptiuniDurata.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaskedTextBoxGuma txtDurata;
        private FlowLayoutPanelPersonalizat flpOptiuniDurata;
        private RadioButtonPersonalizat rbSaptamani;
        private RadioButtonPersonalizat rbZile;
        private RadioButtonPersonalizat rbOre;
        private RadioButtonPersonalizat rbMinute;
    }
}
