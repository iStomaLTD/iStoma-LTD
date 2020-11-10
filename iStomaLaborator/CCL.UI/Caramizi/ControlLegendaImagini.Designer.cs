namespace CCL.UI.Caramizi
{
    partial class ControlLegendaImagini<R>
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
            this.dgvLegenda = new CCL.UI.DataGridViewPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLegenda)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLegenda
            // 
            this.dgvLegenda.AllowUserToAddRows = false;
            this.dgvLegenda.AllowUserToDeleteRows = false;
            this.dgvLegenda.AllowUserToResizeColumns = false;
            this.dgvLegenda.AllowUserToResizeRows = false;
            this.dgvLegenda.BackgroundColor = System.Drawing.Color.White;
            this.dgvLegenda.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvLegenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLegenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLegenda.HideSelection = true;
            this.dgvLegenda.IsInReadOnlyMode = false;
            this.dgvLegenda.Location = new System.Drawing.Point(0, 0);
            this.dgvLegenda.MultiSelect = false;
            this.dgvLegenda.Name = "dgvLegenda";
            this.dgvLegenda.ProprietateCorespunzatoare = "";
            this.dgvLegenda.RowHeadersVisible = false;
            this.dgvLegenda.SeIncarca = false;
            this.dgvLegenda.SelectedText = "";
            this.dgvLegenda.SelectionLength = 0;
            this.dgvLegenda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLegenda.SelectionStart = 0;
            this.dgvLegenda.Size = new System.Drawing.Size(272, 220);
            this.dgvLegenda.TabIndex = 0;
            this.dgvLegenda.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLegenda_CellMouseClick);
            // 
            // ControlLegendaImagini
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvLegenda);
            this.Name = "ControlLegendaImagini";
            this.Size = new System.Drawing.Size(272, 220);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLegenda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridViewPersonalizat dgvLegenda;
    }
}
