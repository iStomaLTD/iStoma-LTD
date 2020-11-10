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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListaLucrari));
            this.ctrlValidareAnulare = new CCL.UI.Caramizi.controlValidareAnulare();
            this.txtCautaLucrare = new CCL.UI.Caramizi.TextBoxCautare();
            this.dgvListaLucrari = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.panelListaLucrari = new CCL.UI.PanelPersonalizat(this.components);
            this.tgvListaCategorii = new CCL.UI.TGV.TreeGridView();
            this.btnFiltreOrizontala = new iStomaLab.Caramizi.ButonFiltreOrizontala();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaLucrari)).BeginInit();
            this.panelListaLucrari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tgvListaCategorii)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(775, 19);
            this.lblTitluEcran.TabIndex = 2;
            this.lblTitluEcran.Text = "FormListaLucrari";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(774, 0);
            this.btnInchidereEcran.TabIndex = 3;
            // 
            // ctrlValidareAnulare
            // 
            this.ctrlValidareAnulare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlValidareAnulare.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulare.Location = new System.Drawing.Point(307, 507);
            this.ctrlValidareAnulare.Name = "ctrlValidareAnulare";
            this.ctrlValidareAnulare.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulare.TabIndex = 1;
            // 
            // txtCautaLucrare
            // 
            this.txtCautaLucrare.AcceptButton = null;
            this.txtCautaLucrare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautaLucrare.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautaLucrare.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautaLucrare.BackColor = System.Drawing.Color.White;
            this.txtCautaLucrare.CapitalizeazaPrimaLitera = false;
            this.txtCautaLucrare.IsInReadOnlyMode = false;
            this.txtCautaLucrare.Location = new System.Drawing.Point(596, 23);
            this.txtCautaLucrare.MaxLength = 32767;
            this.txtCautaLucrare.Multiline = false;
            this.txtCautaLucrare.Name = "txtCautaLucrare";
            this.txtCautaLucrare.ProprietateCorespunzatoare = null;
            this.txtCautaLucrare.RaiseEventLaModificareProgramatica = false;
            this.txtCautaLucrare.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautaLucrare.Size = new System.Drawing.Size(196, 20);
            this.txtCautaLucrare.TabIndex = 0;
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
            this.dgvListaLucrari.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaLucrari.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaLucrari.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaLucrari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaLucrari.HideSelection = true;
            this.dgvListaLucrari.IsInReadOnlyMode = false;
            this.dgvListaLucrari.Location = new System.Drawing.Point(366, 0);
            this.dgvListaLucrari.MultiSelect = false;
            this.dgvListaLucrari.Name = "dgvListaLucrari";
            this.dgvListaLucrari.ProprietateCorespunzatoare = "";
            this.dgvListaLucrari.RowHeadersVisible = false;
            this.dgvListaLucrari.SeIncarca = false;
            this.dgvListaLucrari.SelectedText = "";
            this.dgvListaLucrari.SelectionLength = 0;
            this.dgvListaLucrari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaLucrari.SelectionStart = 0;
            this.dgvListaLucrari.Size = new System.Drawing.Size(425, 453);
            this.dgvListaLucrari.TabIndex = 1;
            // 
            // panelListaLucrari
            // 
            this.panelListaLucrari.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelListaLucrari.BackColor = System.Drawing.Color.White;
            this.panelListaLucrari.Controls.Add(this.tgvListaCategorii);
            this.panelListaLucrari.Controls.Add(this.dgvListaLucrari);
            this.panelListaLucrari.Location = new System.Drawing.Point(2, 49);
            this.panelListaLucrari.Name = "panelListaLucrari";
            this.panelListaLucrari.Size = new System.Drawing.Size(792, 454);
            this.panelListaLucrari.TabIndex = 4;
            this.panelListaLucrari.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // tgvListaCategorii
            // 
            this.tgvListaCategorii.AllowUserToAddRows = false;
            this.tgvListaCategorii.AllowUserToDeleteRows = false;
            this.tgvListaCategorii.AllowUserToResizeRows = false;
            this.tgvListaCategorii.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tgvListaCategorii.BackgroundColor = System.Drawing.Color.White;
            this.tgvListaCategorii.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tgvListaCategorii.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tgvListaCategorii.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tgvListaCategorii.HideSelection = true;
            this.tgvListaCategorii.ImageList = null;
            this.tgvListaCategorii.IsInReadOnlyMode = false;
            this.tgvListaCategorii.Location = new System.Drawing.Point(1, 0);
            this.tgvListaCategorii.MultiSelect = false;
            this.tgvListaCategorii.Name = "tgvListaCategorii";
            this.tgvListaCategorii.ProprietateCorespunzatoare = "";
            this.tgvListaCategorii.RowHeadersVisible = false;
            this.tgvListaCategorii.SeIncarca = false;
            this.tgvListaCategorii.SelectedText = "";
            this.tgvListaCategorii.SelectionLength = 0;
            this.tgvListaCategorii.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tgvListaCategorii.SelectionStart = 0;
            this.tgvListaCategorii.Size = new System.Drawing.Size(357, 453);
            this.tgvListaCategorii.TabIndex = 0;
            // 
            // btnFiltreOrizontala
            // 
            this.btnFiltreOrizontala.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnFiltreOrizontala.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltreOrizontala.Image")));
            this.btnFiltreOrizontala.Location = new System.Drawing.Point(7, 22);
            this.btnFiltreOrizontala.Name = "btnFiltreOrizontala";
            this.btnFiltreOrizontala.Size = new System.Drawing.Size(45, 23);
            this.btnFiltreOrizontala.TabIndex = 5;
            this.btnFiltreOrizontala.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.GestiuneFiltreOrizontala;
            this.btnFiltreOrizontala.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnFiltreOrizontala.UseVisualStyleBackColor = true;
            // 
            // FormListaLucrari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 536);
            this.Controls.Add(this.btnFiltreOrizontala);
            this.Controls.Add(this.panelListaLucrari);
            this.Controls.Add(this.txtCautaLucrare);
            this.Controls.Add(this.ctrlValidareAnulare);
            this.Name = "FormListaLucrari";
            this.Text = "FormListaLucrari";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulare, 0);
            this.Controls.SetChildIndex(this.txtCautaLucrare, 0);
            this.Controls.SetChildIndex(this.panelListaLucrari, 0);
            this.Controls.SetChildIndex(this.btnFiltreOrizontala, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaLucrari)).EndInit();
            this.panelListaLucrari.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tgvListaCategorii)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulare;
        private CCL.UI.Caramizi.TextBoxCautare txtCautaLucrare;
        private CCL.UI.DataGridViewPersonalizat dgvListaLucrari;
        private CCL.UI.PanelPersonalizat panelListaLucrari;
        private CCL.UI.TGV.TreeGridView tgvListaCategorii;
        private Caramizi.ButonFiltreOrizontala btnFiltreOrizontala;
    }
}