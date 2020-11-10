namespace iStomaLab.TablouDeBord
{
    partial class ControlTablouDeBord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlTablouDeBord));
            this.dgvListaComenzi = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.lblComenziInLucru = new CCL.UI.LabelPersonalizat(this.components);
            this.btnAdaugareComanda = new CCL.UI.ButtonPersonalizat(this.components);
            this.ctrlPerioada = new iStomaLab.Caramizi.ControlPerioada();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaComenzi)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListaComenzi
            // 
            this.dgvListaComenzi.AllowUserToAddRows = false;
            this.dgvListaComenzi.AllowUserToDeleteRows = false;
            this.dgvListaComenzi.AllowUserToResizeRows = false;
            this.dgvListaComenzi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaComenzi.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaComenzi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaComenzi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaComenzi.HideSelection = true;
            this.dgvListaComenzi.IsInReadOnlyMode = false;
            this.dgvListaComenzi.Location = new System.Drawing.Point(3, 117);
            this.dgvListaComenzi.MultiSelect = false;
            this.dgvListaComenzi.Name = "dgvListaComenzi";
            this.dgvListaComenzi.ProprietateCorespunzatoare = "";
            this.dgvListaComenzi.RowHeadersVisible = false;
            this.dgvListaComenzi.SeIncarca = false;
            this.dgvListaComenzi.SelectedText = "";
            this.dgvListaComenzi.SelectionLength = 0;
            this.dgvListaComenzi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaComenzi.SelectionStart = 0;
            this.dgvListaComenzi.Size = new System.Drawing.Size(738, 136);
            this.dgvListaComenzi.TabIndex = 0;
            // 
            // lblComenziInLucru
            // 
            this.lblComenziInLucru.AutoSize = true;
            this.lblComenziInLucru.Location = new System.Drawing.Point(7, 98);
            this.lblComenziInLucru.Name = "lblComenziInLucru";
            this.lblComenziInLucru.Size = new System.Drawing.Size(84, 13);
            this.lblComenziInLucru.TabIndex = 1;
            this.lblComenziInLucru.Text = "Comenzi in lucru";
            this.lblComenziInLucru.ToolTipText = null;
            this.lblComenziInLucru.ToolTipTitle = null;
            // 
            // btnAdaugareComanda
            // 
            this.btnAdaugareComanda.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdaugareComanda.Image = ((System.Drawing.Image)(resources.GetObject("btnAdaugareComanda.Image")));
            this.btnAdaugareComanda.Location = new System.Drawing.Point(93, 91);
            this.btnAdaugareComanda.Name = "btnAdaugareComanda";
            this.btnAdaugareComanda.Size = new System.Drawing.Size(38, 23);
            this.btnAdaugareComanda.TabIndex = 2;
            this.btnAdaugareComanda.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdaugareComanda.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdaugareComanda.UseVisualStyleBackColor = true;
            // 
            // ctrlPerioada
            // 
            this.ctrlPerioada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlPerioada.Location = new System.Drawing.Point(0, 0);
            this.ctrlPerioada.Name = "ctrlPerioada";
            this.ctrlPerioada.Size = new System.Drawing.Size(743, 65);
            this.ctrlPerioada.TabIndex = 3;
            // 
            // ControlTablouDeBord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlPerioada);
            this.Controls.Add(this.btnAdaugareComanda);
            this.Controls.Add(this.lblComenziInLucru);
            this.Controls.Add(this.dgvListaComenzi);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ControlTablouDeBord";
            this.Size = new System.Drawing.Size(744, 428);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaComenzi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.DataGridViewPersonalizat dgvListaComenzi;
        private CCL.UI.LabelPersonalizat lblComenziInLucru;
        private CCL.UI.ButtonPersonalizat btnAdaugareComanda;
        private Caramizi.ControlPerioada ctrlPerioada;
    }
}
