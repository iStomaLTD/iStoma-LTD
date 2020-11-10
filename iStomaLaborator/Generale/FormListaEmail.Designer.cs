namespace iStomaLab.Generale
{
    partial class FormListaEmail
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
            this.dgvListaEmail = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.panelGlobal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaEmail)).BeginInit();
            this.SuspendLayout();
            // 
            // panelGlobal
            // 
            this.panelGlobal.Controls.Add(this.dgvListaEmail);
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Text = "FormDGVcs";
            // 
            // dgvListaEmail
            // 
            this.dgvListaEmail.AllowUserToAddRows = false;
            this.dgvListaEmail.AllowUserToDeleteRows = false;
            this.dgvListaEmail.AllowUserToResizeRows = false;
            this.dgvListaEmail.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaEmail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaEmail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaEmail.HideSelection = true;
            this.dgvListaEmail.IsInReadOnlyMode = false;
            this.dgvListaEmail.Location = new System.Drawing.Point(3, 8);
            this.dgvListaEmail.MultiSelect = false;
            this.dgvListaEmail.Name = "dgvListaEmail";
            this.dgvListaEmail.ProprietateCorespunzatoare = "";
            this.dgvListaEmail.RowHeadersVisible = false;
            this.dgvListaEmail.SeIncarca = false;
            this.dgvListaEmail.SelectedText = "";
            this.dgvListaEmail.SelectionLength = 0;
            this.dgvListaEmail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaEmail.SelectionStart = 0;
            this.dgvListaEmail.Size = new System.Drawing.Size(370, 261);
            this.dgvListaEmail.TabIndex = 0;
            // 
            // FormDGVcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 330);
            this.Name = "FormDGVcs";
            this.Text = "FormDGVcs";
            this.panelGlobal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaEmail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.DataGridViewPersonalizat dgvListaEmail;
    }
}