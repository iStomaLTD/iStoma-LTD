namespace iStomaLab.Setari.Liste
{
    partial class ControlGestiuneListe
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
            this.panelListe = new CCL.UI.Caramizi.PanelContainerCCL();
            this.dgvListe = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.txtCautareListe = new CCL.UI.Caramizi.TextBoxCautare();
            this.panelDetaliiLista = new CCL.UI.Caramizi.PanelContainerCCL();
            this.panelListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListe)).BeginInit();
            this.SuspendLayout();
            // 
            // panelListe
            // 
            this.panelListe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelListe.AutoScaleDimensions = new System.Drawing.SizeF(0F, 0F);
            this.panelListe.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.panelListe.BackColor = System.Drawing.Color.White;
            this.panelListe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelListe.Controls.Add(this.dgvListe);
            this.panelListe.Controls.Add(this.txtCautareListe);
            this.panelListe.Location = new System.Drawing.Point(-2, -2);
            this.panelListe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelListe.Name = "panelListe";
            this.panelListe.Size = new System.Drawing.Size(234, 547);
            this.panelListe.TabIndex = 0;
            this.panelListe.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.MeniuStanga;
            // 
            // dgvListe
            // 
            this.dgvListe.AllowUserToAddRows = false;
            this.dgvListe.AllowUserToDeleteRows = false;
            this.dgvListe.AllowUserToResizeRows = false;
            this.dgvListe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvListe.BackgroundColor = System.Drawing.Color.White;
            this.dgvListe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListe.HideSelection = true;
            this.dgvListe.IsInReadOnlyMode = false;
            this.dgvListe.Location = new System.Drawing.Point(0, 38);
            this.dgvListe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvListe.MultiSelect = false;
            this.dgvListe.Name = "dgvListe";
            this.dgvListe.ProprietateCorespunzatoare = "";
            this.dgvListe.RowHeadersVisible = false;
            this.dgvListe.RowTemplate.Height = 24;
            this.dgvListe.SeIncarca = false;
            this.dgvListe.SelectedText = "";
            this.dgvListe.SelectionLength = 0;
            this.dgvListe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListe.SelectionStart = 0;
            this.dgvListe.Size = new System.Drawing.Size(234, 506);
            this.dgvListe.TabIndex = 2;
            // 
            // txtCautareListe
            // 
            this.txtCautareListe.AcceptButton = null;
            this.txtCautareListe.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautareListe.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautareListe.BackColor = System.Drawing.Color.Transparent;
            this.txtCautareListe.CapitalizeazaPrimaLitera = false;
            this.txtCautareListe.IsInReadOnlyMode = false;
            this.txtCautareListe.Location = new System.Drawing.Point(2, 11);
            this.txtCautareListe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCautareListe.MaxLength = 32767;
            this.txtCautareListe.Multiline = false;
            this.txtCautareListe.Name = "txtCautareListe";
            this.txtCautareListe.ProprietateCorespunzatoare = null;
            this.txtCautareListe.RaiseEventLaModificareProgramatica = false;
            this.txtCautareListe.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautareListe.Size = new System.Drawing.Size(228, 23);
            this.txtCautareListe.TabIndex = 1;
            this.txtCautareListe.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautareListe.TextBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCautareListe.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.MeniuStanga;
            this.txtCautareListe.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautareListe.UseSystemPasswordChar = false;
            // 
            // panelDetaliiLista
            // 
            this.panelDetaliiLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDetaliiLista.AutoScaleDimensions = new System.Drawing.SizeF(0F, 0F);
            this.panelDetaliiLista.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.panelDetaliiLista.BackColor = System.Drawing.Color.White;
            this.panelDetaliiLista.Location = new System.Drawing.Point(235, 0);
            this.panelDetaliiLista.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelDetaliiLista.Name = "panelDetaliiLista";
            this.panelDetaliiLista.Size = new System.Drawing.Size(531, 544);
            this.panelDetaliiLista.TabIndex = 1;
            this.panelDetaliiLista.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.MeniuStanga;
            // 
            // ControlGestiuneListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelDetaliiLista);
            this.Controls.Add(this.panelListe);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ControlGestiuneListe";
            this.Size = new System.Drawing.Size(766, 542);
            this.panelListe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.Caramizi.PanelContainerCCL panelListe;
        private CCL.UI.Caramizi.TextBoxCautare txtCautareListe;
        private CCL.UI.Caramizi.PanelContainerCCL panelDetaliiLista;
        private CCL.UI.DataGridViewPersonalizat dgvListe;
    }
}
