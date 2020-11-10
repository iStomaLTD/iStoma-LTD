namespace iStomaLab.Rapoarte
{
    partial class ControlRaportComenzi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlRaportComenzi));
            this.ctrlPerioada = new iStomaLab.Caramizi.ControlPerioada();
            this.dgvLista = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.lblClinica = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlCautareDupaTextClinica = new iStomaLab.Caramizi.ControlCautareDupaTextClinica();
            this.lblTotal = new CCL.UI.LabelPersonalizat(this.components);
            this.txtCautaComanda = new CCL.UI.Caramizi.TextBoxCautare();
            this.btnVizibilitateZonaRezumat = new iStomaLab.Caramizi.ButonFiltreVerticala();
            this.panelZonaRezumat = new CCL.UI.PanelPersonalizat(this.components);
            this.splitZonaRezumat = new CCL.UI.SplitContainerPersonalizat(this.components);
            this.lblLucrare = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlCautareDupaTextLucrare = new iStomaLab.Caramizi.ControlCautareDupaTextLucrare();
            this.lblCauta = new CCL.UI.LabelPersonalizat(this.components);
            this.splitContainer = new CCL.UI.SplitContainerPersonalizat(this.components);
            this.ctrlRezumatLucrari = new iStomaLab.Caramizi.ControlRezumatDGV();
            this.ctrlRezumatClinici = new iStomaLab.Caramizi.ControlRezumatDGV();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.panelZonaRezumat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitZonaRezumat)).BeginInit();
            this.splitZonaRezumat.Panel1.SuspendLayout();
            this.splitZonaRezumat.Panel2.SuspendLayout();
            this.splitZonaRezumat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlPerioada
            // 
            this.ctrlPerioada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlPerioada.Location = new System.Drawing.Point(3, 2);
            this.ctrlPerioada.Name = "ctrlPerioada";
            this.ctrlPerioada.Size = new System.Drawing.Size(898, 57);
            this.ctrlPerioada.TabIndex = 0;
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
            this.dgvLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.HideSelection = true;
            this.dgvLista.IsInReadOnlyMode = false;
            this.dgvLista.Location = new System.Drawing.Point(6, 92);
            this.dgvLista.MultiSelect = false;
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ProprietateCorespunzatoare = "";
            this.dgvLista.RowHeadersVisible = false;
            this.dgvLista.SeIncarca = false;
            this.dgvLista.SelectedText = "";
            this.dgvLista.SelectionLength = 0;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLista.SelectionStart = 0;
            this.dgvLista.Size = new System.Drawing.Size(891, 226);
            this.dgvLista.TabIndex = 1;
            // 
            // lblClinica
            // 
            this.lblClinica.AutoSize = true;
            this.lblClinica.Location = new System.Drawing.Point(3, 70);
            this.lblClinica.Name = "lblClinica";
            this.lblClinica.Size = new System.Drawing.Size(38, 13);
            this.lblClinica.TabIndex = 3;
            this.lblClinica.Text = "Clinica";
            this.lblClinica.ToolTipText = null;
            this.lblClinica.ToolTipTitle = null;
            // 
            // ctrlCautareDupaTextClinica
            // 
            this.ctrlCautareDupaTextClinica.Location = new System.Drawing.Point(68, 64);
            this.ctrlCautareDupaTextClinica.Name = "ctrlCautareDupaTextClinica";
            this.ctrlCautareDupaTextClinica.Size = new System.Drawing.Size(226, 24);
            this.ctrlCautareDupaTextClinica.TabIndex = 4;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(87, 325);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(46, 20);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "Total";
            this.lblTotal.ToolTipText = null;
            this.lblTotal.ToolTipTitle = null;
            // 
            // txtCautaComanda
            // 
            this.txtCautaComanda.AcceptButton = null;
            this.txtCautaComanda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautaComanda.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautaComanda.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautaComanda.BackColor = System.Drawing.Color.White;
            this.txtCautaComanda.CapitalizeazaPrimaLitera = false;
            this.txtCautaComanda.IsInReadOnlyMode = false;
            this.txtCautaComanda.Location = new System.Drawing.Point(713, 68);
            this.txtCautaComanda.MaxLength = 32767;
            this.txtCautaComanda.Multiline = false;
            this.txtCautaComanda.Name = "txtCautaComanda";
            this.txtCautaComanda.ProprietateCorespunzatoare = null;
            this.txtCautaComanda.RaiseEventLaModificareProgramatica = false;
            this.txtCautaComanda.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautaComanda.Size = new System.Drawing.Size(180, 20);
            this.txtCautaComanda.TabIndex = 6;
            this.txtCautaComanda.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautaComanda.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautaComanda.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautaComanda.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautaComanda.UseSystemPasswordChar = false;
            // 
            // btnVizibilitateZonaRezumat
            // 
            this.btnVizibilitateZonaRezumat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVizibilitateZonaRezumat.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnVizibilitateZonaRezumat.Image = ((System.Drawing.Image)(resources.GetObject("btnVizibilitateZonaRezumat.Image")));
            this.btnVizibilitateZonaRezumat.Location = new System.Drawing.Point(6, 324);
            this.btnVizibilitateZonaRezumat.Name = "btnVizibilitateZonaRezumat";
            this.btnVizibilitateZonaRezumat.Size = new System.Drawing.Size(75, 23);
            this.btnVizibilitateZonaRezumat.TabIndex = 12;
            this.btnVizibilitateZonaRezumat.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.GestiuneFiltreVerticala;
            this.btnVizibilitateZonaRezumat.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnVizibilitateZonaRezumat.UseVisualStyleBackColor = true;
            // 
            // panelZonaRezumat
            // 
            this.panelZonaRezumat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelZonaRezumat.BackColor = System.Drawing.Color.White;
            this.panelZonaRezumat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelZonaRezumat.Controls.Add(this.splitZonaRezumat);
            this.panelZonaRezumat.Location = new System.Drawing.Point(7, 3);
            this.panelZonaRezumat.Name = "panelZonaRezumat";
            this.panelZonaRezumat.Size = new System.Drawing.Size(891, 192);
            this.panelZonaRezumat.TabIndex = 13;
            this.panelZonaRezumat.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // splitZonaRezumat
            // 
            this.splitZonaRezumat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitZonaRezumat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitZonaRezumat.IsSplitterFixed = true;
            this.splitZonaRezumat.Location = new System.Drawing.Point(-1, -1);
            this.splitZonaRezumat.Name = "splitZonaRezumat";
            // 
            // splitZonaRezumat.Panel1
            // 
            this.splitZonaRezumat.Panel1.Controls.Add(this.ctrlRezumatClinici);
            // 
            // splitZonaRezumat.Panel2
            // 
            this.splitZonaRezumat.Panel2.Controls.Add(this.ctrlRezumatLucrari);
            this.splitZonaRezumat.Size = new System.Drawing.Size(891, 192);
            this.splitZonaRezumat.SplitterDistance = 444;
            this.splitZonaRezumat.TabIndex = 14;
            // 
            // lblLucrare
            // 
            this.lblLucrare.AutoSize = true;
            this.lblLucrare.Location = new System.Drawing.Point(326, 69);
            this.lblLucrare.Name = "lblLucrare";
            this.lblLucrare.Size = new System.Drawing.Size(43, 13);
            this.lblLucrare.TabIndex = 7;
            this.lblLucrare.Text = "Lucrare";
            this.lblLucrare.ToolTipText = null;
            this.lblLucrare.ToolTipTitle = null;
            // 
            // ctrlCautareDupaTextLucrare
            // 
            this.ctrlCautareDupaTextLucrare.Location = new System.Drawing.Point(391, 63);
            this.ctrlCautareDupaTextLucrare.Name = "ctrlCautareDupaTextLucrare";
            this.ctrlCautareDupaTextLucrare.Size = new System.Drawing.Size(226, 25);
            this.ctrlCautareDupaTextLucrare.TabIndex = 14;
            // 
            // lblCauta
            // 
            this.lblCauta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCauta.AutoSize = true;
            this.lblCauta.Location = new System.Drawing.Point(655, 72);
            this.lblCauta.Name = "lblCauta";
            this.lblCauta.Size = new System.Drawing.Size(35, 13);
            this.lblCauta.TabIndex = 15;
            this.lblCauta.Text = "Cauta";
            this.lblCauta.ToolTipText = null;
            this.lblCauta.ToolTipTitle = null;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(-1, -1);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.dgvLista);
            this.splitContainer.Panel1.Controls.Add(this.lblCauta);
            this.splitContainer.Panel1.Controls.Add(this.btnVizibilitateZonaRezumat);
            this.splitContainer.Panel1.Controls.Add(this.ctrlCautareDupaTextLucrare);
            this.splitContainer.Panel1.Controls.Add(this.ctrlPerioada);
            this.splitContainer.Panel1.Controls.Add(this.lblLucrare);
            this.splitContainer.Panel1.Controls.Add(this.lblClinica);
            this.splitContainer.Panel1.Controls.Add(this.txtCautaComanda);
            this.splitContainer.Panel1.Controls.Add(this.ctrlCautareDupaTextClinica);
            this.splitContainer.Panel1.Controls.Add(this.lblTotal);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panelZonaRezumat);
            this.splitContainer.Size = new System.Drawing.Size(902, 553);
            this.splitContainer.SplitterDistance = 350;
            this.splitContainer.TabIndex = 16;
            // 
            // ctrlRezumatLucrari
            // 
            this.ctrlRezumatLucrari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlRezumatLucrari.Location = new System.Drawing.Point(0, 0);
            this.ctrlRezumatLucrari.Name = "ctrlRezumatLucrari";
            this.ctrlRezumatLucrari.Size = new System.Drawing.Size(441, 190);
            this.ctrlRezumatLucrari.TabIndex = 0;
            // 
            // ctrlRezumatClinici
            // 
            this.ctrlRezumatClinici.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlRezumatClinici.Location = new System.Drawing.Point(0, 0);
            this.ctrlRezumatClinici.Name = "ctrlRezumatClinici";
            this.ctrlRezumatClinici.Size = new System.Drawing.Size(442, 190);
            this.ctrlRezumatClinici.TabIndex = 0;
            // 
            // ControlRaportComenzi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "ControlRaportComenzi";
            this.Size = new System.Drawing.Size(900, 551);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.panelZonaRezumat.ResumeLayout(false);
            this.splitZonaRezumat.Panel1.ResumeLayout(false);
            this.splitZonaRezumat.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitZonaRezumat)).EndInit();
            this.splitZonaRezumat.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Caramizi.ControlPerioada ctrlPerioada;
        private CCL.UI.DataGridViewPersonalizat dgvLista;
        private CCL.UI.LabelPersonalizat lblClinica;
        private Caramizi.ControlCautareDupaTextClinica ctrlCautareDupaTextClinica;
        private CCL.UI.LabelPersonalizat lblTotal;
        private CCL.UI.Caramizi.TextBoxCautare txtCautaComanda;
        private Caramizi.ButonFiltreVerticala btnVizibilitateZonaRezumat;
        private CCL.UI.PanelPersonalizat panelZonaRezumat;
        private CCL.UI.LabelPersonalizat lblLucrare;
        private Caramizi.ControlCautareDupaTextLucrare ctrlCautareDupaTextLucrare;
        private CCL.UI.LabelPersonalizat lblCauta;
        private CCL.UI.SplitContainerPersonalizat splitZonaRezumat;
        private CCL.UI.SplitContainerPersonalizat splitContainer;
        private Caramizi.ControlRezumatDGV ctrlRezumatLucrari;
        private Caramizi.ControlRezumatDGV ctrlRezumatClinici;
    }
}
