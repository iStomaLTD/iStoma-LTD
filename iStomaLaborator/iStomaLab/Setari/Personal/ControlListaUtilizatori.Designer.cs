using static CDL.iStomaLab.CDefinitiiComune;

namespace iStomaLab.Setari.Personal
{
    partial class ControlListaUtilizatori
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlListaUtilizatori));
            this.btnAdaugaUtilizator = new CCL.UI.ButtonPersonalizat(this.components);
            this.dgvListaUtilizatori = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.lblTotalUtilizatori = new CCL.UI.LabelPersonalizat(this.components);
            this.txtCautareUtilizatori = new CCL.UI.Caramizi.TextBoxCautare();
            this.btnActiviInactivi = new CCL.UI.ButtonPersonalizat(this.components);
            this.panelOptiuni = new CCL.UI.PanelPersonalizat(this.components);
            this.btnImporta = new System.Windows.Forms.Button();
            this.btnInchidePanel = new System.Windows.Forms.Button();
            this.btnMeniu = new CCL.UI.ButtonPersonalizat(this.components);
            this.cboRol = new CCL.UI.Caramizi.ComboBoxGuma();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaUtilizatori)).BeginInit();
            this.panelOptiuni.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdaugaUtilizator
            // 
            this.btnAdaugaUtilizator.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdaugaUtilizator.Image = ((System.Drawing.Image)(resources.GetObject("btnAdaugaUtilizator.Image")));
            this.btnAdaugaUtilizator.Location = new System.Drawing.Point(6, 2);
            this.btnAdaugaUtilizator.Name = "btnAdaugaUtilizator";
            this.btnAdaugaUtilizator.Size = new System.Drawing.Size(42, 23);
            this.btnAdaugaUtilizator.TabIndex = 1;
            this.btnAdaugaUtilizator.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdaugaUtilizator.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdaugaUtilizator.UseVisualStyleBackColor = true;
            // 
            // dgvListaUtilizatori
            // 
            this.dgvListaUtilizatori.AllowUserToAddRows = false;
            this.dgvListaUtilizatori.AllowUserToDeleteRows = false;
            this.dgvListaUtilizatori.AllowUserToResizeRows = false;
            this.dgvListaUtilizatori.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaUtilizatori.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaUtilizatori.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaUtilizatori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaUtilizatori.HideSelection = true;
            this.dgvListaUtilizatori.IsInReadOnlyMode = false;
            this.dgvListaUtilizatori.Location = new System.Drawing.Point(0, 29);
            this.dgvListaUtilizatori.MultiSelect = false;
            this.dgvListaUtilizatori.Name = "dgvListaUtilizatori";
            this.dgvListaUtilizatori.ProprietateCorespunzatoare = "";
            this.dgvListaUtilizatori.RowHeadersVisible = false;
            this.dgvListaUtilizatori.SeIncarca = false;
            this.dgvListaUtilizatori.SelectedText = "";
            this.dgvListaUtilizatori.SelectionLength = 0;
            this.dgvListaUtilizatori.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaUtilizatori.SelectionStart = 0;
            this.dgvListaUtilizatori.Size = new System.Drawing.Size(661, 402);
            this.dgvListaUtilizatori.TabIndex = 2;
            // 
            // lblTotalUtilizatori
            // 
            this.lblTotalUtilizatori.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalUtilizatori.AutoSize = true;
            this.lblTotalUtilizatori.Location = new System.Drawing.Point(3, 435);
            this.lblTotalUtilizatori.Name = "lblTotalUtilizatori";
            this.lblTotalUtilizatori.Size = new System.Drawing.Size(43, 13);
            this.lblTotalUtilizatori.TabIndex = 3;
            this.lblTotalUtilizatori.Text = "Nr elem";
            this.lblTotalUtilizatori.ToolTipText = null;
            this.lblTotalUtilizatori.ToolTipTitle = null;
            // 
            // txtCautareUtilizatori
            // 
            this.txtCautareUtilizatori.AcceptButton = null;
            this.txtCautareUtilizatori.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautareUtilizatori.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautareUtilizatori.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautareUtilizatori.BackColor = System.Drawing.Color.White;
            this.txtCautareUtilizatori.CapitalizeazaPrimaLitera = false;
            this.txtCautareUtilizatori.IsInReadOnlyMode = false;
            this.txtCautareUtilizatori.Location = new System.Drawing.Point(375, 3);
            this.txtCautareUtilizatori.MaxLength = 32767;
            this.txtCautareUtilizatori.Multiline = false;
            this.txtCautareUtilizatori.Name = "txtCautareUtilizatori";
            this.txtCautareUtilizatori.ProprietateCorespunzatoare = null;
            this.txtCautareUtilizatori.RaiseEventLaModificareProgramatica = false;
            this.txtCautareUtilizatori.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautareUtilizatori.Size = new System.Drawing.Size(237, 20);
            this.txtCautareUtilizatori.TabIndex = 4;
            this.txtCautareUtilizatori.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautareUtilizatori.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautareUtilizatori.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautareUtilizatori.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautareUtilizatori.UseSystemPasswordChar = false;
            // 
            // btnActiviInactivi
            // 
            this.btnActiviInactivi.ForeColor = System.Drawing.Color.Black;
            this.btnActiviInactivi.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnActiviInactivi.Image = ((System.Drawing.Image)(resources.GetObject("btnActiviInactivi.Image")));
            this.btnActiviInactivi.Location = new System.Drawing.Point(54, 1);
            this.btnActiviInactivi.Name = "btnActiviInactivi";
            this.btnActiviInactivi.Size = new System.Drawing.Size(42, 25);
            this.btnActiviInactivi.TabIndex = 5;
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
            this.panelOptiuni.Location = new System.Drawing.Point(461, 32);
            this.panelOptiuni.Name = "panelOptiuni";
            this.panelOptiuni.Size = new System.Drawing.Size(200, 47);
            this.panelOptiuni.TabIndex = 34;
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
            this.btnMeniu.Location = new System.Drawing.Point(618, 2);
            this.btnMeniu.Margin = new System.Windows.Forms.Padding(0);
            this.btnMeniu.Name = "btnMeniu";
            this.btnMeniu.Size = new System.Drawing.Size(39, 23);
            this.btnMeniu.TabIndex = 33;
            this.btnMeniu.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.MaiMulte;
            this.btnMeniu.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnMeniu.UseVisualStyleBackColor = false;
            // 
            // cboRol
            // 
            this.cboRol.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cboRol.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cboRol.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.cboRol.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.cboRol.DataSource = null;
            this.cboRol.DisplayMember = "";
            this.cboRol.DropDownHeight = 106;
            this.cboRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRol.DropDownWidth = 187;
            this.cboRol.Location = new System.Drawing.Point(131, 3);
            this.cboRol.MaxDropDownItems = 8;
            this.cboRol.Name = "cboRol";
            this.cboRol.SeIncarca = false;
            this.cboRol.SelectedIndex = -1;
            this.cboRol.SelectedItem = null;
            this.cboRol.SelectedValue = null;
            this.cboRol.Size = new System.Drawing.Size(189, 23);
            this.cboRol.TabIndex = 35;
            this.cboRol.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.cboRol.TipulListei = CCL.UI.ComboBoxPersonalizat.EnumTipLista.Nespecificat;
            this.cboRol.ValueMember = "";
            // 
            // ControlListaUtilizatori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.cboRol);
            this.Controls.Add(this.panelOptiuni);
            this.Controls.Add(this.btnMeniu);
            this.Controls.Add(this.btnActiviInactivi);
            this.Controls.Add(this.txtCautareUtilizatori);
            this.Controls.Add(this.lblTotalUtilizatori);
            this.Controls.Add(this.dgvListaUtilizatori);
            this.Controls.Add(this.btnAdaugaUtilizator);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ControlListaUtilizatori";
            this.Size = new System.Drawing.Size(661, 453);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaUtilizatori)).EndInit();
            this.panelOptiuni.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CCL.UI.ButtonPersonalizat btnAdaugaUtilizator;
        private CCL.UI.DataGridViewPersonalizat dgvListaUtilizatori;
        private CCL.UI.LabelPersonalizat lblTotalUtilizatori;
        private CCL.UI.Caramizi.TextBoxCautare txtCautareUtilizatori;
        private CCL.UI.ButtonPersonalizat btnActiviInactivi;
        private CCL.UI.PanelPersonalizat panelOptiuni;
        private System.Windows.Forms.Button btnImporta;
        private System.Windows.Forms.Button btnInchidePanel;
        private CCL.UI.ButtonPersonalizat btnMeniu;
        private CCL.UI.Caramizi.ComboBoxGuma cboRol;
    }
}
