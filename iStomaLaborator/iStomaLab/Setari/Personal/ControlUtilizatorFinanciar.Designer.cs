namespace iStomaLab.Setari.Personal
{
    partial class ControlUtilizatorFinanciar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlUtilizatorFinanciar));
            this.btnAdaugaVenit = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblTitlu = new CCL.UI.LabelPersonalizat(this.components);
            this.dgvListaVenituri = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.lblTotalVenituri = new CCL.UI.LabelPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaVenituri)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdaugaVenit
            // 
            this.btnAdaugaVenit.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdaugaVenit.Image = ((System.Drawing.Image)(resources.GetObject("btnAdaugaVenit.Image")));
            this.btnAdaugaVenit.Location = new System.Drawing.Point(62, 3);
            this.btnAdaugaVenit.Name = "btnAdaugaVenit";
            this.btnAdaugaVenit.Size = new System.Drawing.Size(42, 23);
            this.btnAdaugaVenit.TabIndex = 2;
            this.btnAdaugaVenit.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdaugaVenit.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdaugaVenit.UseVisualStyleBackColor = true;
            // 
            // lblTitlu
            // 
            this.lblTitlu.AutoSize = true;
            this.lblTitlu.Location = new System.Drawing.Point(4, 8);
            this.lblTitlu.Name = "lblTitlu";
            this.lblTitlu.Size = new System.Drawing.Size(42, 13);
            this.lblTitlu.TabIndex = 3;
            this.lblTitlu.Text = "Venituri";
            this.lblTitlu.ToolTipText = null;
            this.lblTitlu.ToolTipTitle = null;
            // 
            // dgvListaVenituri
            // 
            this.dgvListaVenituri.AllowUserToAddRows = false;
            this.dgvListaVenituri.AllowUserToDeleteRows = false;
            this.dgvListaVenituri.AllowUserToResizeRows = false;
            this.dgvListaVenituri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaVenituri.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaVenituri.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaVenituri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaVenituri.HideSelection = true;
            this.dgvListaVenituri.IsInReadOnlyMode = false;
            this.dgvListaVenituri.Location = new System.Drawing.Point(1, 32);
            this.dgvListaVenituri.MultiSelect = false;
            this.dgvListaVenituri.Name = "dgvListaVenituri";
            this.dgvListaVenituri.ProprietateCorespunzatoare = "";
            this.dgvListaVenituri.RowHeadersVisible = false;
            this.dgvListaVenituri.SeIncarca = false;
            this.dgvListaVenituri.SelectedText = "";
            this.dgvListaVenituri.SelectionLength = 0;
            this.dgvListaVenituri.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaVenituri.SelectionStart = 0;
            this.dgvListaVenituri.Size = new System.Drawing.Size(720, 418);
            this.dgvListaVenituri.TabIndex = 4;
            // 
            // lblTotalVenituri
            // 
            this.lblTotalVenituri.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalVenituri.AutoSize = true;
            this.lblTotalVenituri.Location = new System.Drawing.Point(3, 453);
            this.lblTotalVenituri.Name = "lblTotalVenituri";
            this.lblTotalVenituri.Size = new System.Drawing.Size(43, 13);
            this.lblTotalVenituri.TabIndex = 5;
            this.lblTotalVenituri.Text = "Nr elem";
            this.lblTotalVenituri.ToolTipText = null;
            this.lblTotalVenituri.ToolTipTitle = null;
            // 
            // ControlUtilizatorFinanciar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTotalVenituri);
            this.Controls.Add(this.dgvListaVenituri);
            this.Controls.Add(this.lblTitlu);
            this.Controls.Add(this.btnAdaugaVenit);
            this.Name = "ControlUtilizatorFinanciar";
            this.Size = new System.Drawing.Size(721, 470);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaVenituri)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.ButtonPersonalizat btnAdaugaVenit;
        private CCL.UI.LabelPersonalizat lblTitlu;
        private CCL.UI.DataGridViewPersonalizat dgvListaVenituri;
        private CCL.UI.LabelPersonalizat lblTotalVenituri;
    }
}
