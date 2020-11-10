using static CDL.iStomaLab.CDefinitiiComune;

namespace iStomaLab.Setari.Liste.Localitati
{
    partial class ControlDetaliuListaLocalitati
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlDetaliuListaLocalitati));
            this.dgvListaLocalitati = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.lblTotalLocalitati = new CCL.UI.LabelPersonalizat(this.components);
            this.lblLocalitate = new CCL.UI.LabelPersonalizat(this.components);
            this.txtCautaLocalitate = new CCL.UI.Caramizi.TextBoxCautare();
            this.btnAdaugaLocalitate = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnActiviInactivi = new CCL.UI.ButtonPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaLocalitati)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListaLocalitati
            // 
            this.dgvListaLocalitati.AllowUserToAddRows = false;
            this.dgvListaLocalitati.AllowUserToDeleteRows = false;
            this.dgvListaLocalitati.AllowUserToResizeRows = false;
            this.dgvListaLocalitati.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaLocalitati.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaLocalitati.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaLocalitati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaLocalitati.HideSelection = true;
            this.dgvListaLocalitati.IsInReadOnlyMode = false;
            this.dgvListaLocalitati.Location = new System.Drawing.Point(0, 31);
            this.dgvListaLocalitati.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListaLocalitati.MultiSelect = false;
            this.dgvListaLocalitati.Name = "dgvListaLocalitati";
            this.dgvListaLocalitati.ProprietateCorespunzatoare = "";
            this.dgvListaLocalitati.RowHeadersVisible = false;
            this.dgvListaLocalitati.RowTemplate.Height = 24;
            this.dgvListaLocalitati.SeIncarca = false;
            this.dgvListaLocalitati.SelectedText = "";
            this.dgvListaLocalitati.SelectionLength = 0;
            this.dgvListaLocalitati.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaLocalitati.SelectionStart = 0;
            this.dgvListaLocalitati.Size = new System.Drawing.Size(631, 380);
            this.dgvListaLocalitati.TabIndex = 0;
            // 
            // lblTotalLocalitati
            // 
            this.lblTotalLocalitati.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalLocalitati.AutoSize = true;
            this.lblTotalLocalitati.Location = new System.Drawing.Point(2, 415);
            this.lblTotalLocalitati.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalLocalitati.Name = "lblTotalLocalitati";
            this.lblTotalLocalitati.Size = new System.Drawing.Size(31, 13);
            this.lblTotalLocalitati.TabIndex = 1;
            this.lblTotalLocalitati.Text = "Total";
            this.lblTotalLocalitati.ToolTipText = null;
            this.lblTotalLocalitati.ToolTipTitle = null;
            // 
            // lblLocalitate
            // 
            this.lblLocalitate.AutoSize = true;
            this.lblLocalitate.Location = new System.Drawing.Point(0, 9);
            this.lblLocalitate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLocalitate.Name = "lblLocalitate";
            this.lblLocalitate.Size = new System.Drawing.Size(53, 13);
            this.lblLocalitate.TabIndex = 2;
            this.lblLocalitate.Text = "Localitate";
            this.lblLocalitate.ToolTipText = null;
            this.lblLocalitate.ToolTipTitle = null;
            // 
            // txtCautaLocalitate
            // 
            this.txtCautaLocalitate.AcceptButton = null;
            this.txtCautaLocalitate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautaLocalitate.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautaLocalitate.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautaLocalitate.BackColor = System.Drawing.Color.White;
            this.txtCautaLocalitate.CapitalizeazaPrimaLitera = false;
            this.txtCautaLocalitate.IsInReadOnlyMode = false;
            this.txtCautaLocalitate.Location = new System.Drawing.Point(371, 5);
            this.txtCautaLocalitate.Margin = new System.Windows.Forms.Padding(2);
            this.txtCautaLocalitate.MaxLength = 32767;
            this.txtCautaLocalitate.Multiline = false;
            this.txtCautaLocalitate.Name = "txtCautaLocalitate";
            this.txtCautaLocalitate.ProprietateCorespunzatoare = null;
            this.txtCautaLocalitate.RaiseEventLaModificareProgramatica = false;
            this.txtCautaLocalitate.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautaLocalitate.Size = new System.Drawing.Size(260, 20);
            this.txtCautaLocalitate.TabIndex = 3;
            this.txtCautaLocalitate.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautaLocalitate.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautaLocalitate.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautaLocalitate.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautaLocalitate.UseSystemPasswordChar = false;
            // 
            // btnAdaugaLocalitate
            // 
            this.btnAdaugaLocalitate.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdaugaLocalitate.Image = ((System.Drawing.Image)(resources.GetObject("btnAdaugaLocalitate.Image")));
            this.btnAdaugaLocalitate.Location = new System.Drawing.Point(59, 3);
            this.btnAdaugaLocalitate.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdaugaLocalitate.Name = "btnAdaugaLocalitate";
            this.btnAdaugaLocalitate.Size = new System.Drawing.Size(41, 24);
            this.btnAdaugaLocalitate.TabIndex = 4;
            this.btnAdaugaLocalitate.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdaugaLocalitate.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdaugaLocalitate.UseVisualStyleBackColor = true;
            // 
            // btnActiviInactivi
            // 
            this.btnActiviInactivi.ForeColor = System.Drawing.Color.Black;
            this.btnActiviInactivi.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnActiviInactivi.Image = ((System.Drawing.Image)(resources.GetObject("btnActiviInactivi.Image")));
            this.btnActiviInactivi.Location = new System.Drawing.Point(105, 3);
            this.btnActiviInactivi.Name = "btnActiviInactivi";
            this.btnActiviInactivi.Size = new System.Drawing.Size(41, 24);
            this.btnActiviInactivi.TabIndex = 5;
            this.btnActiviInactivi.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.ActiviDezactivati;
            this.btnActiviInactivi.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnActiviInactivi.UseVisualStyleBackColor = true;
            // 
            // ControlDetaliuListaLocalitati
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnActiviInactivi);
            this.Controls.Add(this.btnAdaugaLocalitate);
            this.Controls.Add(this.txtCautaLocalitate);
            this.Controls.Add(this.lblLocalitate);
            this.Controls.Add(this.lblTotalLocalitati);
            this.Controls.Add(this.dgvListaLocalitati);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ControlDetaliuListaLocalitati";
            this.Size = new System.Drawing.Size(631, 430);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaLocalitati)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.DataGridViewPersonalizat dgvListaLocalitati;
        private CCL.UI.LabelPersonalizat lblTotalLocalitati;
        private CCL.UI.LabelPersonalizat lblLocalitate;
        private CCL.UI.Caramizi.TextBoxCautare txtCautaLocalitate;
        private CCL.UI.ButtonPersonalizat btnAdaugaLocalitate;
        private CCL.UI.ButtonPersonalizat btnActiviInactivi;
    }
}
