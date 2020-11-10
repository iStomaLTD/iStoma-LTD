namespace iStomaLab.Setari.Personal
{
    partial class ControlUtilizatorEtape
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
            this.dgvListaEtape = new CCL.UI.DataGridViewPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaEtape)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListaEtape
            // 
            this.dgvListaEtape.AllowUserToAddRows = false;
            this.dgvListaEtape.AllowUserToDeleteRows = false;
            this.dgvListaEtape.AllowUserToResizeRows = false;
            this.dgvListaEtape.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaEtape.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaEtape.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaEtape.HideSelection = true;
            this.dgvListaEtape.IsInReadOnlyMode = false;
            this.dgvListaEtape.Location = new System.Drawing.Point(3, 25);
            this.dgvListaEtape.MultiSelect = false;
            this.dgvListaEtape.Name = "dgvListaEtape";
            this.dgvListaEtape.ProprietateCorespunzatoare = "";
            this.dgvListaEtape.RowHeadersVisible = false;
            this.dgvListaEtape.SeIncarca = false;
            this.dgvListaEtape.SelectedText = "";
            this.dgvListaEtape.SelectionLength = 0;
            this.dgvListaEtape.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaEtape.SelectionStart = 0;
            this.dgvListaEtape.Size = new System.Drawing.Size(572, 371);
            this.dgvListaEtape.TabIndex = 0;
            // 
            // ControlUtilizatorEtape
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvListaEtape);
            this.Name = "ControlUtilizatorEtape";
            this.Size = new System.Drawing.Size(578, 399);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaEtape)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.DataGridViewPersonalizat dgvListaEtape;
    }
}
