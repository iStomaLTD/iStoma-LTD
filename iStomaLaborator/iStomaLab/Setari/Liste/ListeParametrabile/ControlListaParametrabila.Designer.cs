namespace iStomaLab.Setari.Liste.ListeParametrabile
{
    partial class ControlListaParametrabila
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlListaParametrabila));
            this.lblTotalLista = new CCL.UI.LabelPersonalizat(this.components);
            this.txtCautareLista = new CCL.UI.Caramizi.TextBoxCautare();
            this.btnAdaugare = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblTitluLista = new CCL.UI.LabelPersonalizat(this.components);
            this.dgvListaParametrabila = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.btnActiviInactivi = new CCL.UI.ButtonPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaParametrabila)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotalLista
            // 
            this.lblTotalLista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalLista.AutoSize = true;
            this.lblTotalLista.Location = new System.Drawing.Point(3, 432);
            this.lblTotalLista.Name = "lblTotalLista";
            this.lblTotalLista.Size = new System.Drawing.Size(31, 13);
            this.lblTotalLista.TabIndex = 4;
            this.lblTotalLista.Text = "Total";
            this.lblTotalLista.ToolTipText = null;
            this.lblTotalLista.ToolTipTitle = null;
            // 
            // txtCautareLista
            // 
            this.txtCautareLista.AcceptButton = null;
            this.txtCautareLista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautareLista.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautareLista.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautareLista.BackColor = System.Drawing.Color.White;
            this.txtCautareLista.CapitalizeazaPrimaLitera = false;
            this.txtCautareLista.IsInReadOnlyMode = false;
            this.txtCautareLista.Location = new System.Drawing.Point(392, 6);
            this.txtCautareLista.MaxLength = 32767;
            this.txtCautareLista.Multiline = false;
            this.txtCautareLista.Name = "txtCautareLista";
            this.txtCautareLista.ProprietateCorespunzatoare = null;
            this.txtCautareLista.RaiseEventLaModificareProgramatica = false;
            this.txtCautareLista.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautareLista.Size = new System.Drawing.Size(261, 21);
            this.txtCautareLista.TabIndex = 3;
            this.txtCautareLista.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautareLista.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautareLista.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautareLista.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautareLista.UseSystemPasswordChar = false;
            // 
            // btnAdaugare
            // 
            this.btnAdaugare.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdaugare.Image = ((System.Drawing.Image)(resources.GetObject("btnAdaugare.Image")));
            this.btnAdaugare.Location = new System.Drawing.Point(38, 5);
            this.btnAdaugare.Name = "btnAdaugare";
            this.btnAdaugare.Size = new System.Drawing.Size(48, 23);
            this.btnAdaugare.TabIndex = 2;
            this.btnAdaugare.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdaugare.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdaugare.UseVisualStyleBackColor = true;
            // 
            // lblTitluLista
            // 
            this.lblTitluLista.AutoSize = true;
            this.lblTitluLista.Location = new System.Drawing.Point(3, 10);
            this.lblTitluLista.Name = "lblTitluLista";
            this.lblTitluLista.Size = new System.Drawing.Size(29, 13);
            this.lblTitluLista.TabIndex = 1;
            this.lblTitluLista.Text = "Lista";
            this.lblTitluLista.ToolTipText = null;
            this.lblTitluLista.ToolTipTitle = null;
            // 
            // dgvListaParametrabila
            // 
            this.dgvListaParametrabila.AllowUserToAddRows = false;
            this.dgvListaParametrabila.AllowUserToDeleteRows = false;
            this.dgvListaParametrabila.AllowUserToResizeRows = false;
            this.dgvListaParametrabila.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaParametrabila.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaParametrabila.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaParametrabila.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaParametrabila.HideSelection = true;
            this.dgvListaParametrabila.IsInReadOnlyMode = false;
            this.dgvListaParametrabila.Location = new System.Drawing.Point(1, 34);
            this.dgvListaParametrabila.MultiSelect = false;
            this.dgvListaParametrabila.Name = "dgvListaParametrabila";
            this.dgvListaParametrabila.ProprietateCorespunzatoare = "";
            this.dgvListaParametrabila.RowHeadersVisible = false;
            this.dgvListaParametrabila.SeIncarca = false;
            this.dgvListaParametrabila.SelectedText = "";
            this.dgvListaParametrabila.SelectionLength = 0;
            this.dgvListaParametrabila.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaParametrabila.SelectionStart = 0;
            this.dgvListaParametrabila.Size = new System.Drawing.Size(652, 394);
            this.dgvListaParametrabila.TabIndex = 0;
            // 
            // btnActiviInactivi
            // 
            this.btnActiviInactivi.ForeColor = System.Drawing.Color.Black;
            this.btnActiviInactivi.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnActiviInactivi.Image = ((System.Drawing.Image)(resources.GetObject("btnActiviInactivi.Image")));
            this.btnActiviInactivi.Location = new System.Drawing.Point(92, 5);
            this.btnActiviInactivi.Name = "btnActiviInactivi";
            this.btnActiviInactivi.Size = new System.Drawing.Size(49, 23);
            this.btnActiviInactivi.TabIndex = 5;
            this.btnActiviInactivi.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.ActiviDezactivati;
            this.btnActiviInactivi.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnActiviInactivi.UseVisualStyleBackColor = true;
            // 
            // ControlListaParametrabila
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnActiviInactivi);
            this.Controls.Add(this.lblTotalLista);
            this.Controls.Add(this.txtCautareLista);
            this.Controls.Add(this.btnAdaugare);
            this.Controls.Add(this.lblTitluLista);
            this.Controls.Add(this.dgvListaParametrabila);
            this.MinimumSize = new System.Drawing.Size(654, 445);
            this.Name = "ControlListaParametrabila";
            this.Size = new System.Drawing.Size(654, 445);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaParametrabila)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.DataGridViewPersonalizat dgvListaParametrabila;
        private CCL.UI.LabelPersonalizat lblTitluLista;
        private CCL.UI.ButtonPersonalizat btnAdaugare;
        private CCL.UI.Caramizi.TextBoxCautare txtCautareLista;
        private CCL.UI.LabelPersonalizat lblTotalLista;
        private CCL.UI.ButtonPersonalizat btnActiviInactivi;
    }
}
