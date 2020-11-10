using static CDL.iStomaLab.CDefinitiiComune;

namespace iStomaLab.Caramizi
{
    partial class frmAfiseazaRezultatCautareTara
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAfiseazaRezultatCautareTara));
            this.panelGlobal = new CCL.UI.PanelPersonalizat(this.components);
            this.btnAnuleaza = new CCL.UI.ButtonPersonalizat(this.components);
            this.dgvLista = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.ctrlPaginatie = new CCL.UI.Caramizi.ControlPaginatie();
            this.panelGlobal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
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
            this.panelGlobal.Controls.Add(this.dgvLista);
            this.panelGlobal.Controls.Add(this.ctrlPaginatie);
            this.panelGlobal.Location = new System.Drawing.Point(0, 0);
            this.panelGlobal.Name = "panelGlobal";
            this.panelGlobal.Size = new System.Drawing.Size(304, 276);
            this.panelGlobal.TabIndex = 3;
            this.panelGlobal.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // btnAnuleaza
            // 
            this.btnAnuleaza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnuleaza.GenulTextului = EnumSex.Barbatesc;
            this.btnAnuleaza.Image = ((System.Drawing.Image)(resources.GetObject("btnAnuleaza.Image")));
            this.btnAnuleaza.Location = new System.Drawing.Point(245, 250);
            this.btnAnuleaza.Name = "btnAnuleaza";
            this.btnAnuleaza.Size = new System.Drawing.Size(56, 23);
            this.btnAnuleaza.TabIndex = 2;
            this.btnAnuleaza.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Anulare;
            this.btnAnuleaza.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAnuleaza.UseVisualStyleBackColor = true;
            this.btnAnuleaza.Click += new System.EventHandler(this.btnAnuleaza_Click);
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
            this.dgvLista.Location = new System.Drawing.Point(2, 2);
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
            this.dgvLista.TabIndex = 0;
            this.dgvLista.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLista_CellMouseClick);
            // 
            // ctrlPaginatie
            // 
            this.ctrlPaginatie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctrlPaginatie.Location = new System.Drawing.Point(0, 250);
            this.ctrlPaginatie.Name = "ctrlPaginatie";
            this.ctrlPaginatie.Size = new System.Drawing.Size(238, 23);
            this.ctrlPaginatie.TabIndex = 1;
            this.ctrlPaginatie.PaginaSchimbata += new System.EventHandler(this.ctrlPaginatie_PaginaSchimbata);
            // 
            // frmAfiseazaRezultatCautareTara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(304, 276);
            this.Controls.Add(this.panelGlobal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAfiseazaRezultatCautareTara";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmAfiseazaRezultatCautarePersoanaSauOrganizatie_Load);
            this.panelGlobal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.DataGridViewPersonalizat dgvLista;
        private CCL.UI.Caramizi.ControlPaginatie ctrlPaginatie;
        private CCL.UI.ButtonPersonalizat btnAnuleaza;
        private CCL.UI.PanelPersonalizat panelGlobal;
    }
}