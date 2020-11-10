using CCL.UI;

namespace iStomaLab.Imprimare
{
    partial class frmImprimareDGV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImprimareDGV));
            this.txtTitlu = new CCL.UI.Caramizi.TextBoxGuma();
            this.chkTitluPeFiecarePagina = new CCL.UI.CheckBoxPersonalizat(this.components);
            this.chkNumarPagina = new CCL.UI.CheckBoxPersonalizat(this.components);
            this.btnSchimbaPaleta = new CCL.UI.ButtonPersonalizat(this.components);
            this.chkTitlu = new CCL.UI.CheckBoxPersonalizat(this.components);
            this.chkCentrat = new CCL.UI.CheckBoxPersonalizat(this.components);
            this.btnJos = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnSus = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnImprima = new CCL.UI.ButtonPersonalizat(this.components);
            this.lvColoane = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.btnDeselecteaza = new CCL.UI.ButtonPersonalizat(this.components);
            this.chkImprimaCuLogo = new CCL.UI.CheckBoxPersonalizat(this.components);
            this.txtHeader = new CCL.UI.TextBoxCuEticheta(this.components);
            this.txtFooter = new CCL.UI.TextBoxCuEticheta(this.components);
            this.btnAstazi = new CCL.UI.ButtonPersonalizat(this.components);
            this.chkClasic = new CCL.UI.CheckBoxPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lvColoane)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(667, 19);
            this.lblTitluEcran.Text = "";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(666, 0);
            // 
            // txtTitlu
            // 
            this.txtTitlu.AcceptButton = null;
            this.txtTitlu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitlu.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtTitlu.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtTitlu.BackColor = System.Drawing.Color.White;
            this.txtTitlu.IsInReadOnlyMode = false;
            this.txtTitlu.Location = new System.Drawing.Point(105, 25);
            this.txtTitlu.MaxLength = 32767;
            this.txtTitlu.Multiline = false;
            this.txtTitlu.Name = "txtTitlu";
            this.txtTitlu.ProprietateCorespunzatoare = null;
            this.txtTitlu.RaiseEventLaModificareProgramatica = false;
            this.txtTitlu.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTitlu.Size = new System.Drawing.Size(417, 20);
            this.txtTitlu.TabIndex = 0;
            this.txtTitlu.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtTitlu.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtTitlu.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtTitlu.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtTitlu.UseSystemPasswordChar = false;
            // 
            // chkTitluPeFiecarePagina
            // 
            this.chkTitluPeFiecarePagina.AutoSize = true;
            this.chkTitluPeFiecarePagina.IsInReadOnlyMode = false;
            this.chkTitluPeFiecarePagina.Location = new System.Drawing.Point(116, 51);
            this.chkTitluPeFiecarePagina.Name = "chkTitluPeFiecarePagina";
            this.chkTitluPeFiecarePagina.ProprietateCorespunzatoare = null;
            this.chkTitluPeFiecarePagina.Size = new System.Drawing.Size(109, 17);
            this.chkTitluPeFiecarePagina.TabIndex = 2;
            this.chkTitluPeFiecarePagina.Text = "Pe fiecare pagina";
            this.chkTitluPeFiecarePagina.UseVisualStyleBackColor = true;
            // 
            // chkNumarPagina
            // 
            this.chkNumarPagina.AutoSize = true;
            this.chkNumarPagina.IsInReadOnlyMode = false;
            this.chkNumarPagina.Location = new System.Drawing.Point(7, 98);
            this.chkNumarPagina.Name = "chkNumarPagina";
            this.chkNumarPagina.ProprietateCorespunzatoare = null;
            this.chkNumarPagina.Size = new System.Drawing.Size(139, 17);
            this.chkNumarPagina.TabIndex = 4;
            this.chkNumarPagina.Text = "Afiseaza numarul paginii";
            this.chkNumarPagina.UseVisualStyleBackColor = true;
            // 
            // btnSchimbaPaleta
            // 
            this.btnSchimbaPaleta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSchimbaPaleta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSchimbaPaleta.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnSchimbaPaleta.Image = null;
            this.btnSchimbaPaleta.Location = new System.Drawing.Point(607, 67);
            this.btnSchimbaPaleta.Name = "btnSchimbaPaleta";
            this.btnSchimbaPaleta.Size = new System.Drawing.Size(75, 27);
            this.btnSchimbaPaleta.TabIndex = 8;
            this.btnSchimbaPaleta.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnSchimbaPaleta.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnSchimbaPaleta.UseVisualStyleBackColor = true;
            this.btnSchimbaPaleta.Click += new System.EventHandler(this.btnSchimbaPaleta_Click);
            // 
            // chkTitlu
            // 
            this.chkTitlu.Checked = true;
            this.chkTitlu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTitlu.IsInReadOnlyMode = false;
            this.chkTitlu.Location = new System.Drawing.Point(7, 25);
            this.chkTitlu.Name = "chkTitlu";
            this.chkTitlu.ProprietateCorespunzatoare = null;
            this.chkTitlu.Size = new System.Drawing.Size(92, 20);
            this.chkTitlu.TabIndex = 1;
            this.chkTitlu.Text = "Titlu";
            this.chkTitlu.UseVisualStyleBackColor = true;
            // 
            // chkCentrat
            // 
            this.chkCentrat.AutoSize = true;
            this.chkCentrat.IsInReadOnlyMode = false;
            this.chkCentrat.Location = new System.Drawing.Point(7, 75);
            this.chkCentrat.Name = "chkCentrat";
            this.chkCentrat.ProprietateCorespunzatoare = null;
            this.chkCentrat.Size = new System.Drawing.Size(60, 17);
            this.chkCentrat.TabIndex = 3;
            this.chkCentrat.Text = "Centrat";
            this.chkCentrat.UseVisualStyleBackColor = true;
            // 
            // btnJos
            // 
            this.btnJos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJos.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnJos.Location = new System.Drawing.Point(607, 218);
            this.btnJos.Name = "btnJos";
            this.btnJos.Size = new System.Drawing.Size(75, 40);
            this.btnJos.TabIndex = 10;
            this.btnJos.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Jos;
            this.btnJos.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnJos.UseVisualStyleBackColor = true;
            this.btnJos.Click += new System.EventHandler(this.btnJos_Click);
            // 
            // btnSus
            // 
            this.btnSus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSus.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnSus.Location = new System.Drawing.Point(607, 162);
            this.btnSus.Name = "btnSus";
            this.btnSus.Size = new System.Drawing.Size(75, 40);
            this.btnSus.TabIndex = 9;
            this.btnSus.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Sus;
            this.btnSus.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnSus.UseVisualStyleBackColor = true;
            this.btnSus.Click += new System.EventHandler(this.btnSus_Click);
            // 
            // btnImprima
            // 
            this.btnImprima.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprima.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnImprima.Location = new System.Drawing.Point(607, 21);
            this.btnImprima.Name = "btnImprima";
            this.btnImprima.Size = new System.Drawing.Size(75, 41);
            this.btnImprima.TabIndex = 7;
            this.btnImprima.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Print;
            this.btnImprima.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnImprima.UseVisualStyleBackColor = true;
            this.btnImprima.Click += new System.EventHandler(this.btnImprima_Click);
            // 
            // lvColoane
            // 
            this.lvColoane.AllowUserToAddRows = false;
            this.lvColoane.AllowUserToDeleteRows = false;
            this.lvColoane.AllowUserToResizeRows = false;
            this.lvColoane.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvColoane.BackgroundColor = System.Drawing.Color.White;
            this.lvColoane.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lvColoane.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lvColoane.HideSelection = true;
            this.lvColoane.IsInReadOnlyMode = false;
            this.lvColoane.Location = new System.Drawing.Point(7, 127);
            this.lvColoane.MultiSelect = false;
            this.lvColoane.Name = "lvColoane";
            this.lvColoane.ProprietateCorespunzatoare = "";
            this.lvColoane.RowHeadersVisible = false;
            this.lvColoane.SeIncarca = false;
            this.lvColoane.SelectedText = "";
            this.lvColoane.SelectionLength = 0;
            this.lvColoane.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lvColoane.SelectionStart = 0;
            this.lvColoane.Size = new System.Drawing.Size(593, 419);
            this.lvColoane.TabIndex = 11;
            // 
            // btnDeselecteaza
            // 
            this.btnDeselecteaza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeselecteaza.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeselecteaza.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnDeselecteaza.Image = null;
            this.btnDeselecteaza.Location = new System.Drawing.Point(485, 96);
            this.btnDeselecteaza.Name = "btnDeselecteaza";
            this.btnDeselecteaza.Size = new System.Drawing.Size(115, 27);
            this.btnDeselecteaza.TabIndex = 12;
            this.btnDeselecteaza.Text = "Deselecteaza";
            this.btnDeselecteaza.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnDeselecteaza.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnDeselecteaza.UseVisualStyleBackColor = true;
            // 
            // chkImprimaCuLogo
            // 
            this.chkImprimaCuLogo.AutoSize = true;
            this.chkImprimaCuLogo.Checked = true;
            this.chkImprimaCuLogo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImprimaCuLogo.IsInReadOnlyMode = false;
            this.chkImprimaCuLogo.Location = new System.Drawing.Point(316, 51);
            this.chkImprimaCuLogo.Name = "chkImprimaCuLogo";
            this.chkImprimaCuLogo.ProprietateCorespunzatoare = null;
            this.chkImprimaCuLogo.Size = new System.Drawing.Size(50, 17);
            this.chkImprimaCuLogo.TabIndex = 13;
            this.chkImprimaCuLogo.Text = "Logo";
            this.chkImprimaCuLogo.UseVisualStyleBackColor = true;
            // 
            // txtHeader
            // 
            this.txtHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeader.CapitalizeazaPrimaLitera = false;
            this.txtHeader.ForeColor = System.Drawing.Color.Gray;
            this.txtHeader.IsInReadOnlyMode = false;
            this.txtHeader.Location = new System.Drawing.Point(7, 552);
            this.txtHeader.Name = "txtHeader";
            this.txtHeader.ProprietateCorespunzatoare = null;
            this.txtHeader.RaiseEventLaModificareProgramatica = false;
            this.txtHeader.Size = new System.Drawing.Size(676, 20);
            this.txtHeader.TabIndex = 14;
            this.txtHeader.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtHeader.TotulCuMajuscule = false;
            // 
            // txtFooter
            // 
            this.txtFooter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFooter.CapitalizeazaPrimaLitera = false;
            this.txtFooter.ForeColor = System.Drawing.Color.Gray;
            this.txtFooter.IsInReadOnlyMode = false;
            this.txtFooter.Location = new System.Drawing.Point(7, 578);
            this.txtFooter.Name = "txtFooter";
            this.txtFooter.ProprietateCorespunzatoare = null;
            this.txtFooter.RaiseEventLaModificareProgramatica = false;
            this.txtFooter.Size = new System.Drawing.Size(676, 20);
            this.txtFooter.TabIndex = 15;
            this.txtFooter.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtFooter.TotulCuMajuscule = false;
            // 
            // btnAstazi
            // 
            this.btnAstazi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAstazi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAstazi.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAstazi.Image = null;
            this.btnAstazi.Location = new System.Drawing.Point(528, 21);
            this.btnAstazi.Name = "btnAstazi";
            this.btnAstazi.Size = new System.Drawing.Size(73, 27);
            this.btnAstazi.TabIndex = 16;
            this.btnAstazi.Text = "Astazi";
            this.btnAstazi.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnAstazi.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAstazi.UseVisualStyleBackColor = true;
            this.btnAstazi.Click += new System.EventHandler(this.btnAstazi_Click);
            // 
            // chkClasic
            // 
            this.chkClasic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkClasic.AutoSize = true;
            this.chkClasic.Checked = true;
            this.chkClasic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClasic.IsInReadOnlyMode = false;
            this.chkClasic.Location = new System.Drawing.Point(608, 101);
            this.chkClasic.Name = "chkClasic";
            this.chkClasic.ProprietateCorespunzatoare = null;
            this.chkClasic.Size = new System.Drawing.Size(54, 17);
            this.chkClasic.TabIndex = 17;
            this.chkClasic.Text = "Clasic";
            this.chkClasic.UseVisualStyleBackColor = true;
            // 
            // frmImprimareDGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 600);
            this.Controls.Add(this.chkClasic);
            this.Controls.Add(this.btnAstazi);
            this.Controls.Add(this.txtFooter);
            this.Controls.Add(this.txtHeader);
            this.Controls.Add(this.chkImprimaCuLogo);
            this.Controls.Add(this.btnDeselecteaza);
            this.Controls.Add(this.lvColoane);
            this.Controls.Add(this.chkTitluPeFiecarePagina);
            this.Controls.Add(this.chkNumarPagina);
            this.Controls.Add(this.btnSchimbaPaleta);
            this.Controls.Add(this.chkTitlu);
            this.Controls.Add(this.chkCentrat);
            this.Controls.Add(this.txtTitlu);
            this.Controls.Add(this.btnJos);
            this.Controls.Add(this.btnImprima);
            this.Controls.Add(this.btnSus);
            this.MinimumSize = new System.Drawing.Size(689, 600);
            this.Name = "frmImprimareDGV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TipDeschidere = CCL.UI.CEnumerariComune.EnumTipDeschidere.CentrulEcranului;
            this.Load += new System.EventHandler(this.frmImprimareDGV_Load);
            this.Controls.SetChildIndex(this.btnSus, 0);
            this.Controls.SetChildIndex(this.btnImprima, 0);
            this.Controls.SetChildIndex(this.btnJos, 0);
            this.Controls.SetChildIndex(this.txtTitlu, 0);
            this.Controls.SetChildIndex(this.chkCentrat, 0);
            this.Controls.SetChildIndex(this.chkTitlu, 0);
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnSchimbaPaleta, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.chkNumarPagina, 0);
            this.Controls.SetChildIndex(this.chkTitluPeFiecarePagina, 0);
            this.Controls.SetChildIndex(this.lvColoane, 0);
            this.Controls.SetChildIndex(this.btnDeselecteaza, 0);
            this.Controls.SetChildIndex(this.chkImprimaCuLogo, 0);
            this.Controls.SetChildIndex(this.txtHeader, 0);
            this.Controls.SetChildIndex(this.txtFooter, 0);
            this.Controls.SetChildIndex(this.btnAstazi, 0);
            this.Controls.SetChildIndex(this.chkClasic, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lvColoane)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.Caramizi.TextBoxGuma txtTitlu;
        private ButtonPersonalizat btnImprima;
        private ButtonPersonalizat btnJos;
        private ButtonPersonalizat btnSus;
        private CheckBoxPersonalizat chkCentrat;
        private CheckBoxPersonalizat chkTitlu;
        private ButtonPersonalizat btnSchimbaPaleta;
        private CheckBoxPersonalizat chkNumarPagina;
        private CheckBoxPersonalizat chkTitluPeFiecarePagina;
        private DataGridViewPersonalizat lvColoane;
        private ButtonPersonalizat btnDeselecteaza;
        private CheckBoxPersonalizat chkImprimaCuLogo;
        private TextBoxCuEticheta txtHeader;
        private TextBoxCuEticheta txtFooter;
        private ButtonPersonalizat btnAstazi;
        private CheckBoxPersonalizat chkClasic;
    }
}