namespace iStomaLab.Setari.Personal
{
    partial class ControlUtilizatorPontaj
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
            this.dgvListaPontaj = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.btnPontajDetalii = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnPontajRezumat = new CCL.UI.ButtonPersonalizat(this.components);
            this.ctrlPerioada = new iStomaLab.Caramizi.ControlPerioada();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPontaj)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListaPontaj
            // 
            this.dgvListaPontaj.AllowUserToAddRows = false;
            this.dgvListaPontaj.AllowUserToDeleteRows = false;
            this.dgvListaPontaj.AllowUserToResizeRows = false;
            this.dgvListaPontaj.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaPontaj.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaPontaj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaPontaj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaPontaj.HideSelection = true;
            this.dgvListaPontaj.IsInReadOnlyMode = false;
            this.dgvListaPontaj.Location = new System.Drawing.Point(1, 95);
            this.dgvListaPontaj.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListaPontaj.MultiSelect = false;
            this.dgvListaPontaj.Name = "dgvListaPontaj";
            this.dgvListaPontaj.ProprietateCorespunzatoare = "";
            this.dgvListaPontaj.RowHeadersVisible = false;
            this.dgvListaPontaj.RowTemplate.Height = 24;
            this.dgvListaPontaj.SeIncarca = false;
            this.dgvListaPontaj.SelectedText = "";
            this.dgvListaPontaj.SelectionLength = 0;
            this.dgvListaPontaj.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaPontaj.SelectionStart = 0;
            this.dgvListaPontaj.Size = new System.Drawing.Size(747, 347);
            this.dgvListaPontaj.TabIndex = 2;
            // 
            // btnPontajDetalii
            // 
            this.btnPontajDetalii.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPontajDetalii.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPontajDetalii.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnPontajDetalii.Image = null;
            this.btnPontajDetalii.Location = new System.Drawing.Point(630, 72);
            this.btnPontajDetalii.Margin = new System.Windows.Forms.Padding(2);
            this.btnPontajDetalii.Name = "btnPontajDetalii";
            this.btnPontajDetalii.Size = new System.Drawing.Size(56, 19);
            this.btnPontajDetalii.TabIndex = 3;
            this.btnPontajDetalii.Text = "Detalii";
            this.btnPontajDetalii.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnPontajDetalii.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnPontajDetalii.UseVisualStyleBackColor = true;
            // 
            // btnPontajRezumat
            // 
            this.btnPontajRezumat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPontajRezumat.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPontajRezumat.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnPontajRezumat.Image = null;
            this.btnPontajRezumat.Location = new System.Drawing.Point(691, 72);
            this.btnPontajRezumat.Margin = new System.Windows.Forms.Padding(2);
            this.btnPontajRezumat.Name = "btnPontajRezumat";
            this.btnPontajRezumat.Size = new System.Drawing.Size(56, 19);
            this.btnPontajRezumat.TabIndex = 4;
            this.btnPontajRezumat.Text = "Rezumat";
            this.btnPontajRezumat.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnPontajRezumat.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnPontajRezumat.UseVisualStyleBackColor = true;
            // 
            // ctrlPerioada
            // 
            this.ctrlPerioada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlPerioada.Location = new System.Drawing.Point(1, 0);
            this.ctrlPerioada.Name = "ctrlPerioada";
            this.ctrlPerioada.Size = new System.Drawing.Size(745, 65);
            this.ctrlPerioada.TabIndex = 16;
            // 
            // ControlUtilizatorPontaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlPerioada);
            this.Controls.Add(this.btnPontajRezumat);
            this.Controls.Add(this.btnPontajDetalii);
            this.Controls.Add(this.dgvListaPontaj);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ControlUtilizatorPontaj";
            this.Size = new System.Drawing.Size(749, 443);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPontaj)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CCL.UI.DataGridViewPersonalizat dgvListaPontaj;
        private CCL.UI.ButtonPersonalizat btnPontajDetalii;
        private CCL.UI.ButtonPersonalizat btnPontajRezumat;
        private Caramizi.ControlPerioada ctrlPerioada;
    }
}
