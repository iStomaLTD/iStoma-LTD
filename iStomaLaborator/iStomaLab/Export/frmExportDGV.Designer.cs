using CCL.UI;

namespace iStomaLab.Export
{
    partial class frmExportDGV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExportDGV));
            this.btnJos = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnSus = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblColoane = new CCL.UI.LabelPersonalizat(this.components);
            this.btnExporta = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblSeparator = new CCL.UI.LabelPersonalizat(this.components);
            this.rbVirgula = new CCL.UI.RadioButtonPersonalizat(this.components);
            this.rbPunctVirgula = new CCL.UI.RadioButtonPersonalizat(this.components);
            this.btnDeselecteaza = new CCL.UI.ButtonPersonalizat(this.components);
            this.lvColoane = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.panelModExport = new CCL.UI.PanelPersonalizat(this.components);
            this.panelSeparatorCSV = new CCL.UI.PanelPersonalizat(this.components);
            this.rbCSV = new CCL.UI.RadioButtonPersonalizat(this.components);
            this.rbExportExcel = new CCL.UI.RadioButtonPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lvColoane)).BeginInit();
            this.panelModExport.SuspendLayout();
            this.panelSeparatorCSV.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(475, 19);
            this.lblTitluEcran.Text = "";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(474, 0);
            // 
            // btnJos
            // 
            this.btnJos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJos.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnJos.Location = new System.Drawing.Point(416, 218);
            this.btnJos.Name = "btnJos";
            this.btnJos.Size = new System.Drawing.Size(75, 40);
            this.btnJos.TabIndex = 4;
            this.btnJos.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Jos;
            this.btnJos.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnJos.UseVisualStyleBackColor = true;
            this.btnJos.Click += new System.EventHandler(this.btnJos_Click);
            // 
            // btnSus
            // 
            this.btnSus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSus.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnSus.Location = new System.Drawing.Point(416, 162);
            this.btnSus.Name = "btnSus";
            this.btnSus.Size = new System.Drawing.Size(75, 40);
            this.btnSus.TabIndex = 3;
            this.btnSus.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Sus;
            this.btnSus.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnSus.UseVisualStyleBackColor = true;
            this.btnSus.Click += new System.EventHandler(this.btnSus_Click);
            // 
            // lblColoane
            // 
            this.lblColoane.Location = new System.Drawing.Point(5, 26);
            this.lblColoane.Name = "lblColoane";
            this.lblColoane.Size = new System.Drawing.Size(254, 15);
            this.lblColoane.TabIndex = 2;
            this.lblColoane.Text = "Coloane";
            this.lblColoane.ToolTipText = null;
            this.lblColoane.ToolTipTitle = null;
            // 
            // btnExporta
            // 
            this.btnExporta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExporta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExporta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnExporta.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnExporta.Location = new System.Drawing.Point(416, 48);
            this.btnExporta.Name = "btnExporta";
            this.btnExporta.Size = new System.Drawing.Size(75, 36);
            this.btnExporta.TabIndex = 0;
            this.btnExporta.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Validare;
            this.btnExporta.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnExporta.UseVisualStyleBackColor = true;
            this.btnExporta.Click += new System.EventHandler(this.btnExporta_Click);
            // 
            // lblSeparator
            // 
            this.lblSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSeparator.AutoSize = true;
            this.lblSeparator.Location = new System.Drawing.Point(5, 9);
            this.lblSeparator.Name = "lblSeparator";
            this.lblSeparator.Size = new System.Drawing.Size(53, 13);
            this.lblSeparator.TabIndex = 5;
            this.lblSeparator.Text = "Separator";
            this.lblSeparator.ToolTipText = null;
            this.lblSeparator.ToolTipTitle = null;
            // 
            // rbVirgula
            // 
            this.rbVirgula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbVirgula.AutoSize = true;
            this.rbVirgula.Checked = true;
            this.rbVirgula.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbVirgula.Location = new System.Drawing.Point(22, 32);
            this.rbVirgula.Name = "rbVirgula";
            this.rbVirgula.Size = new System.Drawing.Size(33, 26);
            this.rbVirgula.TabIndex = 6;
            this.rbVirgula.TabStop = true;
            this.rbVirgula.Text = ",";
            this.rbVirgula.UseVisualStyleBackColor = true;
            // 
            // rbPunctVirgula
            // 
            this.rbPunctVirgula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbPunctVirgula.AutoSize = true;
            this.rbPunctVirgula.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPunctVirgula.Location = new System.Drawing.Point(22, 64);
            this.rbPunctVirgula.Name = "rbPunctVirgula";
            this.rbPunctVirgula.Size = new System.Drawing.Size(33, 26);
            this.rbPunctVirgula.TabIndex = 7;
            this.rbPunctVirgula.Text = ";";
            this.rbPunctVirgula.UseVisualStyleBackColor = true;
            // 
            // btnDeselecteaza
            // 
            this.btnDeselecteaza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeselecteaza.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeselecteaza.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnDeselecteaza.Image = null;
            this.btnDeselecteaza.Location = new System.Drawing.Point(295, 22);
            this.btnDeselecteaza.Name = "btnDeselecteaza";
            this.btnDeselecteaza.Size = new System.Drawing.Size(115, 23);
            this.btnDeselecteaza.TabIndex = 8;
            this.btnDeselecteaza.Text = "Deselecteaza";
            this.btnDeselecteaza.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnDeselecteaza.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnDeselecteaza.UseVisualStyleBackColor = true;
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
            this.lvColoane.Location = new System.Drawing.Point(3, 48);
            this.lvColoane.MultiSelect = false;
            this.lvColoane.Name = "lvColoane";
            this.lvColoane.ProprietateCorespunzatoare = "";
            this.lvColoane.RowHeadersVisible = false;
            this.lvColoane.SeIncarca = false;
            this.lvColoane.SelectedText = "";
            this.lvColoane.SelectionLength = 0;
            this.lvColoane.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lvColoane.SelectionStart = 0;
            this.lvColoane.Size = new System.Drawing.Size(407, 547);
            this.lvColoane.TabIndex = 9;
            // 
            // panelModExport
            // 
            this.panelModExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelModExport.BackColor = System.Drawing.Color.White;
            this.panelModExport.Controls.Add(this.panelSeparatorCSV);
            this.panelModExport.Controls.Add(this.rbCSV);
            this.panelModExport.Controls.Add(this.rbExportExcel);
            this.panelModExport.Location = new System.Drawing.Point(413, 273);
            this.panelModExport.Name = "panelModExport";
            this.panelModExport.Size = new System.Drawing.Size(81, 201);
            this.panelModExport.TabIndex = 10;
            this.panelModExport.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // panelSeparatorCSV
            // 
            this.panelSeparatorCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSeparatorCSV.BackColor = System.Drawing.Color.White;
            this.panelSeparatorCSV.Controls.Add(this.lblSeparator);
            this.panelSeparatorCSV.Controls.Add(this.rbVirgula);
            this.panelSeparatorCSV.Controls.Add(this.rbPunctVirgula);
            this.panelSeparatorCSV.Location = new System.Drawing.Point(1, 62);
            this.panelSeparatorCSV.Name = "panelSeparatorCSV";
            this.panelSeparatorCSV.Size = new System.Drawing.Size(79, 138);
            this.panelSeparatorCSV.TabIndex = 9;
            this.panelSeparatorCSV.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.panelSeparatorCSV.Visible = false;
            // 
            // rbCSV
            // 
            this.rbCSV.AutoSize = true;
            this.rbCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCSV.Location = new System.Drawing.Point(6, 39);
            this.rbCSV.Name = "rbCSV";
            this.rbCSV.Size = new System.Drawing.Size(46, 17);
            this.rbCSV.TabIndex = 8;
            this.rbCSV.Text = "CSV";
            this.rbCSV.UseVisualStyleBackColor = true;
            // 
            // rbExportExcel
            // 
            this.rbExportExcel.AutoSize = true;
            this.rbExportExcel.Checked = true;
            this.rbExportExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbExportExcel.Location = new System.Drawing.Point(6, 12);
            this.rbExportExcel.Name = "rbExportExcel";
            this.rbExportExcel.Size = new System.Drawing.Size(51, 17);
            this.rbExportExcel.TabIndex = 7;
            this.rbExportExcel.TabStop = true;
            this.rbExportExcel.Text = "Excel";
            this.rbExportExcel.UseVisualStyleBackColor = true;
            // 
            // frmExportDGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 600);
            this.Controls.Add(this.lvColoane);
            this.Controls.Add(this.btnDeselecteaza);
            this.Controls.Add(this.btnJos);
            this.Controls.Add(this.btnSus);
            this.Controls.Add(this.lblColoane);
            this.Controls.Add(this.btnExporta);
            this.Controls.Add(this.panelModExport);
            this.MinimumSize = new System.Drawing.Size(497, 600);
            this.Name = "frmExportDGV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TipDeschidere = CCL.UI.CEnumerariComune.EnumTipDeschidere.CentrulEcranului;
            this.Load += new System.EventHandler(this.frmImprimareDGV_Load);
            this.Controls.SetChildIndex(this.panelModExport, 0);
            this.Controls.SetChildIndex(this.btnExporta, 0);
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.lblColoane, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.btnSus, 0);
            this.Controls.SetChildIndex(this.btnJos, 0);
            this.Controls.SetChildIndex(this.btnDeselecteaza, 0);
            this.Controls.SetChildIndex(this.lvColoane, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lvColoane)).EndInit();
            this.panelModExport.ResumeLayout(false);
            this.panelModExport.PerformLayout();
            this.panelSeparatorCSV.ResumeLayout(false);
            this.panelSeparatorCSV.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ButtonPersonalizat btnExporta;
        private ButtonPersonalizat btnJos;
        private ButtonPersonalizat btnSus;
        private LabelPersonalizat lblColoane;
        private LabelPersonalizat lblSeparator;
        private RadioButtonPersonalizat rbVirgula;
        private RadioButtonPersonalizat rbPunctVirgula;
        private ButtonPersonalizat btnDeselecteaza;
        private DataGridViewPersonalizat lvColoane;
        private PanelPersonalizat panelModExport;
        private RadioButtonPersonalizat rbCSV;
        private RadioButtonPersonalizat rbExportExcel;
        private PanelPersonalizat panelSeparatorCSV;
    }
}