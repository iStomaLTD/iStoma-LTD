namespace iStomaLab.Generale
{
    partial class FormListaUtilizatori
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
            this.dgvListaUtilizatori = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.txtCautaUtilizator = new CCL.UI.Caramizi.TextBoxCautare();
            this.panelGlobal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaUtilizatori)).BeginInit();
            this.SuspendLayout();
            // 
            // panelGlobal
            // 
            this.panelGlobal.Controls.Add(this.txtCautaUtilizator);
            this.panelGlobal.Controls.Add(this.dgvListaUtilizatori);
            // 
            // btnValidare
            // 
            this.btnValidare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Text = "FormListaUtilizatori";
            // 
            // dgvListaUtilizatori
            // 
            this.dgvListaUtilizatori.AllowUserToAddRows = false;
            this.dgvListaUtilizatori.AllowUserToDeleteRows = false;
            this.dgvListaUtilizatori.AllowUserToResizeRows = false;
            this.dgvListaUtilizatori.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaUtilizatori.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaUtilizatori.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaUtilizatori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaUtilizatori.HideSelection = true;
            this.dgvListaUtilizatori.IsInReadOnlyMode = false;
            this.dgvListaUtilizatori.Location = new System.Drawing.Point(3, 29);
            this.dgvListaUtilizatori.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvListaUtilizatori.MultiSelect = false;
            this.dgvListaUtilizatori.Name = "dgvListaUtilizatori";
            this.dgvListaUtilizatori.ProprietateCorespunzatoare = "";
            this.dgvListaUtilizatori.RowHeadersVisible = false;
            this.dgvListaUtilizatori.RowTemplate.Height = 24;
            this.dgvListaUtilizatori.SeIncarca = false;
            this.dgvListaUtilizatori.SelectedText = "";
            this.dgvListaUtilizatori.SelectionLength = 0;
            this.dgvListaUtilizatori.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaUtilizatori.SelectionStart = 0;
            this.dgvListaUtilizatori.Size = new System.Drawing.Size(277, 189);
            this.dgvListaUtilizatori.TabIndex = 1;
            // 
            // txtCautaUtilizator
            // 
            this.txtCautaUtilizator.AcceptButton = null;
            this.txtCautaUtilizator.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautaUtilizator.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautaUtilizator.CapitalizeazaPrimaLitera = false;
            this.txtCautaUtilizator.IsInReadOnlyMode = false;
            this.txtCautaUtilizator.Location = new System.Drawing.Point(3, 5);
            this.txtCautaUtilizator.MaxLength = 32767;
            this.txtCautaUtilizator.Multiline = false;
            this.txtCautaUtilizator.Name = "txtCautaUtilizator";
            this.txtCautaUtilizator.ProprietateCorespunzatoare = null;
            this.txtCautaUtilizator.RaiseEventLaModificareProgramatica = false;
            this.txtCautaUtilizator.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautaUtilizator.Size = new System.Drawing.Size(276, 20);
            this.txtCautaUtilizator.TabIndex = 2;
            this.txtCautaUtilizator.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautaUtilizator.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautaUtilizator.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautaUtilizator.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautaUtilizator.UseSystemPasswordChar = false;
            // 
            // FormListaUtilizatori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 268);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormListaUtilizatori";
            this.Text = "FormListaUtilizatori";
            this.panelGlobal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaUtilizatori)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CCL.UI.DataGridViewPersonalizat dgvListaUtilizatori;
        private CCL.UI.Caramizi.TextBoxCautare txtCautaUtilizator;
    }
}