namespace iStomaLab.Setari.Lucrari
{
    partial class ControlListaDePreturi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlListaDePreturi));
            this.lblTotalListaPreturi = new CCL.UI.LabelPersonalizat(this.components);
            this.dgvListaPreturi = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.btnAdaugareLucrare = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblTitluListaDePreturi = new CCL.UI.LabelPersonalizat(this.components);
            this.txtCautareLucrare = new CCL.UI.Caramizi.TextBoxCautare();
            this.btnActiviInactivi = new CCL.UI.ButtonPersonalizat(this.components);
            this.panelOptiuni = new CCL.UI.PanelPersonalizat(this.components);
            this.btnImporta = new System.Windows.Forms.Button();
            this.btnInchidePanel = new System.Windows.Forms.Button();
            this.btnMeniu = new CCL.UI.ButtonPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPreturi)).BeginInit();
            this.panelOptiuni.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTotalListaPreturi
            // 
            this.lblTotalListaPreturi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalListaPreturi.AutoSize = true;
            this.lblTotalListaPreturi.Location = new System.Drawing.Point(2, 422);
            this.lblTotalListaPreturi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalListaPreturi.Name = "lblTotalListaPreturi";
            this.lblTotalListaPreturi.Size = new System.Drawing.Size(31, 13);
            this.lblTotalListaPreturi.TabIndex = 4;
            this.lblTotalListaPreturi.Text = "Total";
            this.lblTotalListaPreturi.ToolTipText = null;
            this.lblTotalListaPreturi.ToolTipTitle = null;
            // 
            // dgvListaPreturi
            // 
            this.dgvListaPreturi.AllowUserToAddRows = false;
            this.dgvListaPreturi.AllowUserToDeleteRows = false;
            this.dgvListaPreturi.AllowUserToResizeRows = false;
            this.dgvListaPreturi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaPreturi.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaPreturi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaPreturi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaPreturi.HideSelection = true;
            this.dgvListaPreturi.IsInReadOnlyMode = false;
            this.dgvListaPreturi.Location = new System.Drawing.Point(0, 34);
            this.dgvListaPreturi.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListaPreturi.MultiSelect = false;
            this.dgvListaPreturi.Name = "dgvListaPreturi";
            this.dgvListaPreturi.ProprietateCorespunzatoare = "";
            this.dgvListaPreturi.RowHeadersVisible = false;
            this.dgvListaPreturi.RowTemplate.Height = 24;
            this.dgvListaPreturi.SeIncarca = false;
            this.dgvListaPreturi.SelectedText = "";
            this.dgvListaPreturi.SelectionLength = 0;
            this.dgvListaPreturi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaPreturi.SelectionStart = 0;
            this.dgvListaPreturi.Size = new System.Drawing.Size(632, 385);
            this.dgvListaPreturi.TabIndex = 2;
            // 
            // btnAdaugareLucrare
            // 
            this.btnAdaugareLucrare.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdaugareLucrare.Image = ((System.Drawing.Image)(resources.GetObject("btnAdaugareLucrare.Image")));
            this.btnAdaugareLucrare.Location = new System.Drawing.Point(58, 8);
            this.btnAdaugareLucrare.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdaugareLucrare.Name = "btnAdaugareLucrare";
            this.btnAdaugareLucrare.Size = new System.Drawing.Size(43, 23);
            this.btnAdaugareLucrare.TabIndex = 1;
            this.btnAdaugareLucrare.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdaugareLucrare.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdaugareLucrare.UseVisualStyleBackColor = true;
            // 
            // lblTitluListaDePreturi
            // 
            this.lblTitluListaDePreturi.AutoSize = true;
            this.lblTitluListaDePreturi.Location = new System.Drawing.Point(14, 12);
            this.lblTitluListaDePreturi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitluListaDePreturi.Name = "lblTitluListaDePreturi";
            this.lblTitluListaDePreturi.Size = new System.Drawing.Size(39, 13);
            this.lblTitluListaDePreturi.TabIndex = 0;
            this.lblTitluListaDePreturi.Text = "Lucrari";
            this.lblTitluListaDePreturi.ToolTipText = null;
            this.lblTitluListaDePreturi.ToolTipTitle = null;
            // 
            // txtCautareLucrare
            // 
            this.txtCautareLucrare.AcceptButton = null;
            this.txtCautareLucrare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautareLucrare.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautareLucrare.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautareLucrare.BackColor = System.Drawing.Color.White;
            this.txtCautareLucrare.CapitalizeazaPrimaLitera = false;
            this.txtCautareLucrare.IsInReadOnlyMode = false;
            this.txtCautareLucrare.Location = new System.Drawing.Point(306, 9);
            this.txtCautareLucrare.MaxLength = 32767;
            this.txtCautareLucrare.Multiline = false;
            this.txtCautareLucrare.Name = "txtCautareLucrare";
            this.txtCautareLucrare.ProprietateCorespunzatoare = null;
            this.txtCautareLucrare.RaiseEventLaModificareProgramatica = false;
            this.txtCautareLucrare.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautareLucrare.Size = new System.Drawing.Size(279, 20);
            this.txtCautareLucrare.TabIndex = 5;
            this.txtCautareLucrare.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautareLucrare.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautareLucrare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautareLucrare.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautareLucrare.UseSystemPasswordChar = false;
            // 
            // btnActiviInactivi
            // 
            this.btnActiviInactivi.ForeColor = System.Drawing.Color.Black;
            this.btnActiviInactivi.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnActiviInactivi.Image = ((System.Drawing.Image)(resources.GetObject("btnActiviInactivi.Image")));
            this.btnActiviInactivi.Location = new System.Drawing.Point(107, 7);
            this.btnActiviInactivi.Name = "btnActiviInactivi";
            this.btnActiviInactivi.Size = new System.Drawing.Size(43, 23);
            this.btnActiviInactivi.TabIndex = 6;
            this.btnActiviInactivi.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.ActiviDezactivati;
            this.btnActiviInactivi.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnActiviInactivi.UseVisualStyleBackColor = true;
            // 
            // panelOptiuni
            // 
            this.panelOptiuni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOptiuni.BackColor = System.Drawing.Color.White;
            this.panelOptiuni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOptiuni.Controls.Add(this.btnImporta);
            this.panelOptiuni.Controls.Add(this.btnInchidePanel);
            this.panelOptiuni.Location = new System.Drawing.Point(431, 36);
            this.panelOptiuni.Name = "panelOptiuni";
            this.panelOptiuni.Size = new System.Drawing.Size(200, 47);
            this.panelOptiuni.TabIndex = 32;
            this.panelOptiuni.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // btnImporta
            // 
            this.btnImporta.FlatAppearance.BorderSize = 0;
            this.btnImporta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImporta.Location = new System.Drawing.Point(-1, 21);
            this.btnImporta.Name = "btnImporta";
            this.btnImporta.Size = new System.Drawing.Size(200, 23);
            this.btnImporta.TabIndex = 1;
            this.btnImporta.Text = "Importa";
            this.btnImporta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImporta.UseVisualStyleBackColor = true;
            // 
            // btnInchidePanel
            // 
            this.btnInchidePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInchidePanel.BackColor = System.Drawing.Color.Transparent;
            this.btnInchidePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnInchidePanel.FlatAppearance.BorderSize = 0;
            this.btnInchidePanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInchidePanel.ForeColor = System.Drawing.Color.Black;
            this.btnInchidePanel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInchidePanel.Location = new System.Drawing.Point(174, 0);
            this.btnInchidePanel.Name = "btnInchidePanel";
            this.btnInchidePanel.Size = new System.Drawing.Size(23, 23);
            this.btnInchidePanel.TabIndex = 0;
            this.btnInchidePanel.Text = "X";
            this.btnInchidePanel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInchidePanel.UseVisualStyleBackColor = false;
            // 
            // btnMeniu
            // 
            this.btnMeniu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMeniu.BackColor = System.Drawing.Color.Transparent;
            this.btnMeniu.FlatAppearance.BorderSize = 0;
            this.btnMeniu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMeniu.ForeColor = System.Drawing.Color.Transparent;
            this.btnMeniu.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnMeniu.Image = ((System.Drawing.Image)(resources.GetObject("btnMeniu.Image")));
            this.btnMeniu.Location = new System.Drawing.Point(588, 7);
            this.btnMeniu.Margin = new System.Windows.Forms.Padding(0);
            this.btnMeniu.Name = "btnMeniu";
            this.btnMeniu.Size = new System.Drawing.Size(39, 23);
            this.btnMeniu.TabIndex = 31;
            this.btnMeniu.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.MaiMulte;
            this.btnMeniu.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnMeniu.UseVisualStyleBackColor = false;
            // 
            // ControlListaDePreturi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelOptiuni);
            this.Controls.Add(this.btnMeniu);
            this.Controls.Add(this.btnActiviInactivi);
            this.Controls.Add(this.txtCautareLucrare);
            this.Controls.Add(this.lblTotalListaPreturi);
            this.Controls.Add(this.dgvListaPreturi);
            this.Controls.Add(this.btnAdaugareLucrare);
            this.Controls.Add(this.lblTitluListaDePreturi);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ControlListaDePreturi";
            this.Size = new System.Drawing.Size(632, 440);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPreturi)).EndInit();
            this.panelOptiuni.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.LabelPersonalizat lblTitluListaDePreturi;
        private CCL.UI.ButtonPersonalizat btnAdaugareLucrare;
        private CCL.UI.DataGridViewPersonalizat dgvListaPreturi;
        private CCL.UI.LabelPersonalizat lblTotalListaPreturi;
        private CCL.UI.Caramizi.TextBoxCautare txtCautareLucrare;
        private CCL.UI.ButtonPersonalizat btnActiviInactivi;
        private CCL.UI.PanelPersonalizat panelOptiuni;
        private System.Windows.Forms.Button btnImporta;
        private System.Windows.Forms.Button btnInchidePanel;
        private CCL.UI.ButtonPersonalizat btnMeniu;
    }
}
