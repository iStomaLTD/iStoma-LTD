namespace iStomaLab.Generale
{
    partial class FormListaLucrari
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
            this.ctrlValidareAnulare = new CCL.UI.Caramizi.controlValidareAnulare();
            this.txtCautaLucrare = new CCL.UI.Caramizi.TextBoxCautare();
            this.dgvListaLucrari = new CCL.UI.DataGridViewPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaLucrari)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(643, 19);
            this.lblTitluEcran.Text = "FormListaLucrari";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(642, 0);
            // 
            // ctrlValidareAnulare
            // 
            this.ctrlValidareAnulare.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulare.Location = new System.Drawing.Point(258, 408);
            this.ctrlValidareAnulare.Name = "ctrlValidareAnulare";
            this.ctrlValidareAnulare.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulare.TabIndex = 3;
            // 
            // txtCautaLucrare
            // 
            this.txtCautaLucrare.AcceptButton = null;
            this.txtCautaLucrare.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautaLucrare.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautaLucrare.CapitalizeazaPrimaLitera = false;
            this.txtCautaLucrare.IsInReadOnlyMode = false;
            this.txtCautaLucrare.Location = new System.Drawing.Point(13, 23);
            this.txtCautaLucrare.MaxLength = 32767;
            this.txtCautaLucrare.Multiline = false;
            this.txtCautaLucrare.Name = "txtCautaLucrare";
            this.txtCautaLucrare.ProprietateCorespunzatoare = null;
            this.txtCautaLucrare.RaiseEventLaModificareProgramatica = false;
            this.txtCautaLucrare.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautaLucrare.Size = new System.Drawing.Size(640, 20);
            this.txtCautaLucrare.TabIndex = 4;
            this.txtCautaLucrare.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautaLucrare.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautaLucrare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautaLucrare.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautaLucrare.UseSystemPasswordChar = false;
            // 
            // dgvListaLucrari
            // 
            this.dgvListaLucrari.AllowUserToAddRows = false;
            this.dgvListaLucrari.AllowUserToDeleteRows = false;
            this.dgvListaLucrari.AllowUserToResizeRows = false;
            this.dgvListaLucrari.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaLucrari.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaLucrari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaLucrari.HideSelection = true;
            this.dgvListaLucrari.IsInReadOnlyMode = false;
            this.dgvListaLucrari.Location = new System.Drawing.Point(1, 49);
            this.dgvListaLucrari.MultiSelect = false;
            this.dgvListaLucrari.Name = "dgvListaLucrari";
            this.dgvListaLucrari.ProprietateCorespunzatoare = "";
            this.dgvListaLucrari.RowHeadersVisible = false;
            this.dgvListaLucrari.SeIncarca = false;
            this.dgvListaLucrari.SelectedText = "";
            this.dgvListaLucrari.SelectionLength = 0;
            this.dgvListaLucrari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaLucrari.SelectionStart = 0;
            this.dgvListaLucrari.Size = new System.Drawing.Size(664, 352);
            this.dgvListaLucrari.TabIndex = 5;
            // 
            // FormListaLucrari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 438);
            this.Controls.Add(this.dgvListaLucrari);
            this.Controls.Add(this.txtCautaLucrare);
            this.Controls.Add(this.ctrlValidareAnulare);
            this.Name = "FormListaLucrari";
            this.Text = "FormListaLucrari";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulare, 0);
            this.Controls.SetChildIndex(this.txtCautaLucrare, 0);
            this.Controls.SetChildIndex(this.dgvListaLucrari, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaLucrari)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulare;
        private CCL.UI.Caramizi.TextBoxCautare txtCautaLucrare;
        private CCL.UI.DataGridViewPersonalizat dgvListaLucrari;
    }
}