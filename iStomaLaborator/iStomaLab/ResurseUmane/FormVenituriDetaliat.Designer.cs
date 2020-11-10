namespace iStomaLab.ResurseUmane
{
    partial class FormVenituriDetaliat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVenituriDetaliat));
            this.txtCautare = new CCL.UI.Caramizi.TextBoxCautare();
            this.dgvListaDetaliat = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.ctrlValidareAnulare = new CCL.UI.Caramizi.controlValidareAnulare();
            this.lblTotal = new CCL.UI.LabelPersonalizat(this.components);
            this.btnVizibilitateZonaRezumat = new iStomaLab.Caramizi.ButonFiltreVerticala();
            this.splitContainer = new CCL.UI.SplitContainerPersonalizat(this.components);
            this.panelZonaRezumat = new CCL.UI.PanelPersonalizat(this.components);
            this.splitZonaRezumat = new CCL.UI.SplitContainerPersonalizat(this.components);
            this.ctrlRezumatClienti = new iStomaLab.Caramizi.ControlRezumatDGV();
            this.splitSubzonaRezumat = new CCL.UI.SplitContainerPersonalizat(this.components);
            this.ctrlRezumatLucrari = new iStomaLab.Caramizi.ControlRezumatDGV();
            this.ctrlRezumatEtape = new iStomaLab.Caramizi.ControlRezumatDGV();
            this.btnImprimare = new CCL.UI.ButtonPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaDetaliat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panelZonaRezumat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitZonaRezumat)).BeginInit();
            this.splitZonaRezumat.Panel1.SuspendLayout();
            this.splitZonaRezumat.Panel2.SuspendLayout();
            this.splitZonaRezumat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitSubzonaRezumat)).BeginInit();
            this.splitSubzonaRezumat.Panel1.SuspendLayout();
            this.splitSubzonaRezumat.Panel2.SuspendLayout();
            this.splitSubzonaRezumat.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(878, 19);
            this.lblTitluEcran.Text = "FormVenituriDetaliat";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(877, 0);
            // 
            // txtCautare
            // 
            this.txtCautare.AcceptButton = null;
            this.txtCautare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautare.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautare.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautare.BackColor = System.Drawing.Color.White;
            this.txtCautare.CapitalizeazaPrimaLitera = false;
            this.txtCautare.IsInReadOnlyMode = false;
            this.txtCautare.Location = new System.Drawing.Point(580, 5);
            this.txtCautare.MaxLength = 32767;
            this.txtCautare.Multiline = false;
            this.txtCautare.Name = "txtCautare";
            this.txtCautare.ProprietateCorespunzatoare = null;
            this.txtCautare.RaiseEventLaModificareProgramatica = false;
            this.txtCautare.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautare.Size = new System.Drawing.Size(256, 20);
            this.txtCautare.TabIndex = 2;
            this.txtCautare.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautare.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautare.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautare.UseSystemPasswordChar = false;
            // 
            // dgvListaDetaliat
            // 
            this.dgvListaDetaliat.AllowUserToAddRows = false;
            this.dgvListaDetaliat.AllowUserToDeleteRows = false;
            this.dgvListaDetaliat.AllowUserToResizeRows = false;
            this.dgvListaDetaliat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaDetaliat.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaDetaliat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaDetaliat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaDetaliat.HideSelection = true;
            this.dgvListaDetaliat.IsInReadOnlyMode = false;
            this.dgvListaDetaliat.Location = new System.Drawing.Point(3, 29);
            this.dgvListaDetaliat.MultiSelect = false;
            this.dgvListaDetaliat.Name = "dgvListaDetaliat";
            this.dgvListaDetaliat.ProprietateCorespunzatoare = "";
            this.dgvListaDetaliat.RowHeadersVisible = false;
            this.dgvListaDetaliat.SeIncarca = false;
            this.dgvListaDetaliat.SelectedText = "";
            this.dgvListaDetaliat.SelectionLength = 0;
            this.dgvListaDetaliat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaDetaliat.SelectionStart = 0;
            this.dgvListaDetaliat.Size = new System.Drawing.Size(880, 268);
            this.dgvListaDetaliat.TabIndex = 3;
            // 
            // ctrlValidareAnulare
            // 
            this.ctrlValidareAnulare.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrlValidareAnulare.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulare.Location = new System.Drawing.Point(375, 570);
            this.ctrlValidareAnulare.Name = "ctrlValidareAnulare";
            this.ctrlValidareAnulare.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulare.TabIndex = 4;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTotal.Location = new System.Drawing.Point(82, 308);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(31, 13);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "Total";
            this.lblTotal.ToolTipText = null;
            this.lblTotal.ToolTipTitle = null;
            // 
            // btnVizibilitateZonaRezumat
            // 
            this.btnVizibilitateZonaRezumat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVizibilitateZonaRezumat.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnVizibilitateZonaRezumat.Image = ((System.Drawing.Image)(resources.GetObject("btnVizibilitateZonaRezumat.Image")));
            this.btnVizibilitateZonaRezumat.Location = new System.Drawing.Point(3, 303);
            this.btnVizibilitateZonaRezumat.Name = "btnVizibilitateZonaRezumat";
            this.btnVizibilitateZonaRezumat.Size = new System.Drawing.Size(75, 23);
            this.btnVizibilitateZonaRezumat.TabIndex = 14;
            this.btnVizibilitateZonaRezumat.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.GestiuneFiltreVerticala;
            this.btnVizibilitateZonaRezumat.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnVizibilitateZonaRezumat.UseVisualStyleBackColor = true;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(5, 22);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.btnImprimare);
            this.splitContainer.Panel1.Controls.Add(this.txtCautare);
            this.splitContainer.Panel1.Controls.Add(this.dgvListaDetaliat);
            this.splitContainer.Panel1.Controls.Add(this.btnVizibilitateZonaRezumat);
            this.splitContainer.Panel1.Controls.Add(this.lblTotal);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panelZonaRezumat);
            this.splitContainer.Size = new System.Drawing.Size(889, 542);
            this.splitContainer.SplitterDistance = 329;
            this.splitContainer.TabIndex = 19;
            // 
            // panelZonaRezumat
            // 
            this.panelZonaRezumat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelZonaRezumat.BackColor = System.Drawing.Color.White;
            this.panelZonaRezumat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelZonaRezumat.Controls.Add(this.splitZonaRezumat);
            this.panelZonaRezumat.Location = new System.Drawing.Point(0, 3);
            this.panelZonaRezumat.Name = "panelZonaRezumat";
            this.panelZonaRezumat.Size = new System.Drawing.Size(885, 203);
            this.panelZonaRezumat.TabIndex = 18;
            this.panelZonaRezumat.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // splitZonaRezumat
            // 
            this.splitZonaRezumat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitZonaRezumat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitZonaRezumat.IsSplitterFixed = true;
            this.splitZonaRezumat.Location = new System.Drawing.Point(-1, 3);
            this.splitZonaRezumat.Name = "splitZonaRezumat";
            // 
            // splitZonaRezumat.Panel1
            // 
            this.splitZonaRezumat.Panel1.Controls.Add(this.ctrlRezumatClienti);
            // 
            // splitZonaRezumat.Panel2
            // 
            this.splitZonaRezumat.Panel2.Controls.Add(this.splitSubzonaRezumat);
            this.splitZonaRezumat.Size = new System.Drawing.Size(885, 199);
            this.splitZonaRezumat.SplitterDistance = 284;
            this.splitZonaRezumat.TabIndex = 14;
            // 
            // ctrlRezumatClienti
            // 
            this.ctrlRezumatClienti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlRezumatClienti.Location = new System.Drawing.Point(0, 0);
            this.ctrlRezumatClienti.Name = "ctrlRezumatClienti";
            this.ctrlRezumatClienti.Size = new System.Drawing.Size(282, 197);
            this.ctrlRezumatClienti.TabIndex = 0;
            // 
            // splitSubzonaRezumat
            // 
            this.splitSubzonaRezumat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitSubzonaRezumat.IsSplitterFixed = true;
            this.splitSubzonaRezumat.Location = new System.Drawing.Point(0, 0);
            this.splitSubzonaRezumat.Name = "splitSubzonaRezumat";
            // 
            // splitSubzonaRezumat.Panel1
            // 
            this.splitSubzonaRezumat.Panel1.Controls.Add(this.ctrlRezumatLucrari);
            // 
            // splitSubzonaRezumat.Panel2
            // 
            this.splitSubzonaRezumat.Panel2.Controls.Add(this.ctrlRezumatEtape);
            this.splitSubzonaRezumat.Size = new System.Drawing.Size(595, 197);
            this.splitSubzonaRezumat.SplitterDistance = 305;
            this.splitSubzonaRezumat.TabIndex = 0;
            // 
            // ctrlRezumatLucrari
            // 
            this.ctrlRezumatLucrari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlRezumatLucrari.Location = new System.Drawing.Point(0, 0);
            this.ctrlRezumatLucrari.Name = "ctrlRezumatLucrari";
            this.ctrlRezumatLucrari.Size = new System.Drawing.Size(305, 197);
            this.ctrlRezumatLucrari.TabIndex = 0;
            // 
            // ctrlRezumatEtape
            // 
            this.ctrlRezumatEtape.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlRezumatEtape.Location = new System.Drawing.Point(0, 0);
            this.ctrlRezumatEtape.Name = "ctrlRezumatEtape";
            this.ctrlRezumatEtape.Size = new System.Drawing.Size(286, 197);
            this.ctrlRezumatEtape.TabIndex = 0;
            // 
            // btnImprimare
            // 
            this.btnImprimare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimare.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnImprimare.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimare.Image")));
            this.btnImprimare.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimare.Location = new System.Drawing.Point(846, 4);
            this.btnImprimare.Name = "btnImprimare";
            this.btnImprimare.Size = new System.Drawing.Size(37, 23);
            this.btnImprimare.TabIndex = 22;
            this.btnImprimare.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Print;
            this.btnImprimare.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnImprimare.UseVisualStyleBackColor = true;
            // 
            // FormVenituriDetaliat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.ctrlValidareAnulare);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "FormVenituriDetaliat";
            this.Text = "FormVenituriDetaliat";
            this.Controls.SetChildIndex(this.ctrlValidareAnulare, 0);
            this.Controls.SetChildIndex(this.splitContainer, 0);
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaDetaliat)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panelZonaRezumat.ResumeLayout(false);
            this.splitZonaRezumat.Panel1.ResumeLayout(false);
            this.splitZonaRezumat.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitZonaRezumat)).EndInit();
            this.splitZonaRezumat.ResumeLayout(false);
            this.splitSubzonaRezumat.Panel1.ResumeLayout(false);
            this.splitSubzonaRezumat.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitSubzonaRezumat)).EndInit();
            this.splitSubzonaRezumat.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.Caramizi.TextBoxCautare txtCautare;
        private CCL.UI.DataGridViewPersonalizat dgvListaDetaliat;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulare;
        private CCL.UI.LabelPersonalizat lblTotal;
        private Caramizi.ButonFiltreVerticala btnVizibilitateZonaRezumat;
        private CCL.UI.SplitContainerPersonalizat splitContainer;
        private CCL.UI.PanelPersonalizat panelZonaRezumat;
        private CCL.UI.SplitContainerPersonalizat splitZonaRezumat;
        private Caramizi.ControlRezumatDGV ctrlRezumatClienti;
        private CCL.UI.SplitContainerPersonalizat splitSubzonaRezumat;
        private Caramizi.ControlRezumatDGV ctrlRezumatLucrari;
        private Caramizi.ControlRezumatDGV ctrlRezumatEtape;
        private CCL.UI.ButtonPersonalizat btnImprimare;
    }
}