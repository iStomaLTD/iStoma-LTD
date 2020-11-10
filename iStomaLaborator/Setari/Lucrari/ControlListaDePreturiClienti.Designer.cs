namespace iStomaLab.Setari.Lucrari
{
    partial class ControlListaDePreturiClienti
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
            this.txtCautaLucrare = new CCL.UI.Caramizi.TextBoxCautare();
            this.dgvListaDePreturiClienti = new CCL.UI.DataGridViewPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaDePreturiClienti)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCautaLucrare
            // 
            this.txtCautaLucrare.AcceptButton = null;
            this.txtCautaLucrare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautaLucrare.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautaLucrare.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautaLucrare.BackColor = System.Drawing.Color.White;
            this.txtCautaLucrare.CapitalizeazaPrimaLitera = false;
            this.txtCautaLucrare.IsInReadOnlyMode = false;
            this.txtCautaLucrare.Location = new System.Drawing.Point(306, 13);
            this.txtCautaLucrare.MaxLength = 32767;
            this.txtCautaLucrare.Multiline = false;
            this.txtCautaLucrare.Name = "txtCautaLucrare";
            this.txtCautaLucrare.ProprietateCorespunzatoare = null;
            this.txtCautaLucrare.RaiseEventLaModificareProgramatica = false;
            this.txtCautaLucrare.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautaLucrare.Size = new System.Drawing.Size(449, 25);
            this.txtCautaLucrare.TabIndex = 1;
            this.txtCautaLucrare.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautaLucrare.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautaLucrare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautaLucrare.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautaLucrare.UseSystemPasswordChar = false;
            // 
            // dgvListaDePreturiClienti
            // 
            this.dgvListaDePreturiClienti.AllowUserToAddRows = false;
            this.dgvListaDePreturiClienti.AllowUserToDeleteRows = false;
            this.dgvListaDePreturiClienti.AllowUserToResizeRows = false;
            this.dgvListaDePreturiClienti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaDePreturiClienti.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaDePreturiClienti.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaDePreturiClienti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaDePreturiClienti.HideSelection = true;
            this.dgvListaDePreturiClienti.IsInReadOnlyMode = false;
            this.dgvListaDePreturiClienti.Location = new System.Drawing.Point(4, 44);
            this.dgvListaDePreturiClienti.MultiSelect = false;
            this.dgvListaDePreturiClienti.Name = "dgvListaDePreturiClienti";
            this.dgvListaDePreturiClienti.ProprietateCorespunzatoare = "";
            this.dgvListaDePreturiClienti.RowHeadersVisible = false;
            this.dgvListaDePreturiClienti.RowTemplate.Height = 24;
            this.dgvListaDePreturiClienti.SeIncarca = false;
            this.dgvListaDePreturiClienti.SelectedText = "";
            this.dgvListaDePreturiClienti.SelectionLength = 0;
            this.dgvListaDePreturiClienti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaDePreturiClienti.SelectionStart = 0;
            this.dgvListaDePreturiClienti.Size = new System.Drawing.Size(751, 457);
            this.dgvListaDePreturiClienti.TabIndex = 0;
            // 
            // ControlListaDePreturiClienti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCautaLucrare);
            this.Controls.Add(this.dgvListaDePreturiClienti);
            this.Name = "ControlListaDePreturiClienti";
            this.Size = new System.Drawing.Size(758, 519);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaDePreturiClienti)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.DataGridViewPersonalizat dgvListaDePreturiClienti;
        private CCL.UI.Caramizi.TextBoxCautare txtCautaLucrare;
    }
}
