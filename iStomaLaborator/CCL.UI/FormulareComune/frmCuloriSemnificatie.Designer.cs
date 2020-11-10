namespace CCL.UI.FormulareComune
{
    partial class frmCuloriSemnificatie
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
            this.dgvSemnificatieCulori = new CCL.UI.DataGridViewPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSemnificatieCulori)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(323, 19);
            this.lblTitluEcran.Text = "frmCuloriSemnificatie";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(322, 0);
            // 
            // dgvSemnificatieCulori
            // 
            this.dgvSemnificatieCulori.AllowUserToAddRows = false;
            this.dgvSemnificatieCulori.AllowUserToDeleteRows = false;
            this.dgvSemnificatieCulori.AllowUserToResizeColumns = false;
            this.dgvSemnificatieCulori.AllowUserToResizeRows = false;
            this.dgvSemnificatieCulori.BackgroundColor = System.Drawing.Color.White;
            this.dgvSemnificatieCulori.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSemnificatieCulori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSemnificatieCulori.HideSelection = true;
            this.dgvSemnificatieCulori.IsInReadOnlyMode = false;
            this.dgvSemnificatieCulori.Location = new System.Drawing.Point(1, 19);
            this.dgvSemnificatieCulori.MultiSelect = false;
            this.dgvSemnificatieCulori.Name = "dgvSemnificatieCulori";
            this.dgvSemnificatieCulori.ProprietateCorespunzatoare = "";
            this.dgvSemnificatieCulori.RowHeadersVisible = false;
            this.dgvSemnificatieCulori.SeIncarca = false;
            this.dgvSemnificatieCulori.SelectedText = "";
            this.dgvSemnificatieCulori.SelectionLength = 0;
            this.dgvSemnificatieCulori.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSemnificatieCulori.SelectionStart = 0;
            this.dgvSemnificatieCulori.Size = new System.Drawing.Size(343, 320);
            this.dgvSemnificatieCulori.TabIndex = 2;
            // 
            // frmCuloriSemnificatie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 340);
            this.Controls.Add(this.dgvSemnificatieCulori);
            this.Name = "frmCuloriSemnificatie";
            this.Text = "frmCuloriSemnificatie";
            this.Load += new System.EventHandler(this.frmCuloriSemnificatie_Load);
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.dgvSemnificatieCulori, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSemnificatieCulori)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridViewPersonalizat dgvSemnificatieCulori;
    }
}