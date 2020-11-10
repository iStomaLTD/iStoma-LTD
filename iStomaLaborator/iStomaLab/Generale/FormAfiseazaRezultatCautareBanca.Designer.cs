namespace iStomaLab.Generale
{
    partial class FormAfiseazaRezultatCautareBanca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAfiseazaRezultatCautareProfesie));
            this.panelGlobal = new CCL.UI.PanelPersonalizat(this.components);
            this.dgvLista = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.ctrlPaginatie = new CCL.UI.Caramizi.ControlPaginatie();
            this.lblNrPagina = new CCL.UI.LabelPersonalizat(this.components);
            this.btnListaCompleta = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnDreapta = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnStanga = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnAnuleaza = new CCL.UI.ButtonPersonalizat(this.components);
            this.panelGlobal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.ctrlPaginatie.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGlobal
            // 
            this.panelGlobal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGlobal.BackColor = System.Drawing.Color.White;
            this.panelGlobal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGlobal.Controls.Add(this.btnAnuleaza);
            this.panelGlobal.Controls.Add(this.ctrlPaginatie);
            this.panelGlobal.Controls.Add(this.dgvLista);
            this.panelGlobal.Location = new System.Drawing.Point(0, 0);
            this.panelGlobal.Name = "panelGlobal";
            this.panelGlobal.Size = new System.Drawing.Size(304, 276);
            this.panelGlobal.TabIndex = 7;
            this.panelGlobal.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.AllowUserToDeleteRows = false;
            this.dgvLista.AllowUserToResizeRows = false;
            this.dgvLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLista.BackgroundColor = System.Drawing.Color.White;
            this.dgvLista.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.HideSelection = true;
            this.dgvLista.IsInReadOnlyMode = false;
            this.dgvLista.Location = new System.Drawing.Point(2, 1);
            this.dgvLista.MultiSelect = false;
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ProprietateCorespunzatoare = "";
            this.dgvLista.RowHeadersVisible = false;
            this.dgvLista.SeIncarca = false;
            this.dgvLista.SelectedText = "";
            this.dgvLista.SelectionLength = 0;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLista.SelectionStart = 0;
            this.dgvLista.Size = new System.Drawing.Size(298, 245);
            this.dgvLista.TabIndex = 4;
            // 
            // ctrlPaginatie
            // 
            this.ctrlPaginatie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctrlPaginatie.Controls.Add(this.lblNrPagina);
            this.ctrlPaginatie.Controls.Add(this.btnListaCompleta);
            this.ctrlPaginatie.Controls.Add(this.btnDreapta);
            this.ctrlPaginatie.Controls.Add(this.btnStanga);
            this.ctrlPaginatie.Location = new System.Drawing.Point(2, 249);
            this.ctrlPaginatie.Name = "ctrlPaginatie";
            this.ctrlPaginatie.Size = new System.Drawing.Size(238, 23);
            this.ctrlPaginatie.TabIndex = 5;
            // 
            // lblNrPagina
            // 
            this.lblNrPagina.Location = new System.Drawing.Point(33, 0);
            this.lblNrPagina.Name = "lblNrPagina";
            this.lblNrPagina.Size = new System.Drawing.Size(39, 23);
            this.lblNrPagina.TabIndex = 3;
            this.lblNrPagina.Text = "19/33";
            this.lblNrPagina.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNrPagina.ToolTipText = null;
            this.lblNrPagina.ToolTipTitle = null;
            // 
            // btnListaCompleta
            // 
            this.btnListaCompleta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListaCompleta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnListaCompleta.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnListaCompleta.Image = null;
            this.btnListaCompleta.Location = new System.Drawing.Point(110, 0);
            this.btnListaCompleta.Name = "btnListaCompleta";
            this.btnListaCompleta.Size = new System.Drawing.Size(75, 23);
            this.btnListaCompleta.TabIndex = 2;
            this.btnListaCompleta.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnListaCompleta.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnListaCompleta.UseVisualStyleBackColor = true;
            // 
            // btnDreapta
            // 
            this.btnDreapta.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnDreapta.Image = ((System.Drawing.Image)(resources.GetObject("btnDreapta.Image")));
            this.btnDreapta.Location = new System.Drawing.Point(75, 0);
            this.btnDreapta.Name = "btnDreapta";
            this.btnDreapta.Size = new System.Drawing.Size(29, 23);
            this.btnDreapta.TabIndex = 1;
            this.btnDreapta.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Dreapta;
            this.btnDreapta.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnDreapta.UseVisualStyleBackColor = true;
            // 
            // btnStanga
            // 
            this.btnStanga.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnStanga.Image = ((System.Drawing.Image)(resources.GetObject("btnStanga.Image")));
            this.btnStanga.Location = new System.Drawing.Point(1, 0);
            this.btnStanga.Name = "btnStanga";
            this.btnStanga.Size = new System.Drawing.Size(29, 23);
            this.btnStanga.TabIndex = 0;
            this.btnStanga.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Stanga;
            this.btnStanga.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnStanga.UseVisualStyleBackColor = true;
            // 
            // btnAnuleaza
            // 
            this.btnAnuleaza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnuleaza.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAnuleaza.Image = ((System.Drawing.Image)(resources.GetObject("btnAnuleaza.Image")));
            this.btnAnuleaza.Location = new System.Drawing.Point(244, 249);
            this.btnAnuleaza.Name = "btnAnuleaza";
            this.btnAnuleaza.Size = new System.Drawing.Size(56, 23);
            this.btnAnuleaza.TabIndex = 6;
            this.btnAnuleaza.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Anulare;
            this.btnAnuleaza.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAnuleaza.UseVisualStyleBackColor = true;
            // 
            // frmAfiseazaRezultatCautareProfesie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(304, 276);
            this.Controls.Add(this.panelGlobal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAfiseazaRezultatCautareProfesie";
            this.ShowInTaskbar = false;
            this.Text = "frmAfiseazaRezultatCautareProfesie";
            this.panelGlobal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.ctrlPaginatie.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.PanelPersonalizat panelGlobal;
        private CCL.UI.DataGridViewPersonalizat dgvLista;
        private CCL.UI.Caramizi.ControlPaginatie ctrlPaginatie;
        private CCL.UI.LabelPersonalizat lblNrPagina;
        private CCL.UI.ButtonPersonalizat btnListaCompleta;
        private CCL.UI.ButtonPersonalizat btnDreapta;
        private CCL.UI.ButtonPersonalizat btnStanga;
        private CCL.UI.ButtonPersonalizat btnAnuleaza;
    }
}