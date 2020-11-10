namespace iStomaLab.Setari.Liste
{
    partial class ControlDetaliuLista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlDetaliuLista));
            this.txtCautareProfesie = new CCL.UI.Caramizi.TextBoxCautare();
            this.btnAdaugaProfesie = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblTitluLista = new CCL.UI.LabelPersonalizat(this.components);
            this.lblTotalProfesie = new CCL.UI.LabelPersonalizat(this.components);
            this.dgvListaProfesii = new CCL.UI.DataGridViewPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaProfesii)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCautareProfesie
            // 
            this.txtCautareProfesie.AcceptButton = null;
            this.txtCautareProfesie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautareProfesie.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautareProfesie.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautareProfesie.BackColor = System.Drawing.Color.White;
            this.txtCautareProfesie.CapitalizeazaPrimaLitera = false;
            this.txtCautareProfesie.IsInReadOnlyMode = false;
            this.txtCautareProfesie.Location = new System.Drawing.Point(318, 6);
            this.txtCautareProfesie.Margin = new System.Windows.Forms.Padding(2);
            this.txtCautareProfesie.MaxLength = 32767;
            this.txtCautareProfesie.Multiline = false;
            this.txtCautareProfesie.Name = "txtCautareProfesie";
            this.txtCautareProfesie.ProprietateCorespunzatoare = null;
            this.txtCautareProfesie.RaiseEventLaModificareProgramatica = false;
            this.txtCautareProfesie.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautareProfesie.Size = new System.Drawing.Size(200, 21);
            this.txtCautareProfesie.TabIndex = 6;
            this.txtCautareProfesie.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautareProfesie.TextBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCautareProfesie.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautareProfesie.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautareProfesie.UseSystemPasswordChar = false;
            // 
            // btnAdaugaProfesie
            // 
            this.btnAdaugaProfesie.ForeColor = System.Drawing.Color.Black;
            this.btnAdaugaProfesie.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdaugaProfesie.Image = ((System.Drawing.Image)(resources.GetObject("btnAdaugaProfesie.Image")));
            this.btnAdaugaProfesie.Location = new System.Drawing.Point(55, 5);
            this.btnAdaugaProfesie.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdaugaProfesie.Name = "btnAdaugaProfesie";
            this.btnAdaugaProfesie.Size = new System.Drawing.Size(35, 21);
            this.btnAdaugaProfesie.TabIndex = 5;
            this.btnAdaugaProfesie.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdaugaProfesie.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdaugaProfesie.UseVisualStyleBackColor = true;
            // 
            // lblTitluLista
            // 
            this.lblTitluLista.AutoSize = true;
            this.lblTitluLista.Location = new System.Drawing.Point(10, 9);
            this.lblTitluLista.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitluLista.Name = "lblTitluLista";
            this.lblTitluLista.Size = new System.Drawing.Size(41, 13);
            this.lblTitluLista.TabIndex = 4;
            this.lblTitluLista.Text = "Profesii";
            this.lblTitluLista.ToolTipText = null;
            this.lblTitluLista.ToolTipTitle = null;
            // 
            // lblTotalProfesie
            // 
            this.lblTotalProfesie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalProfesie.AutoSize = true;
            this.lblTotalProfesie.Location = new System.Drawing.Point(10, 425);
            this.lblTotalProfesie.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalProfesie.Name = "lblTotalProfesie";
            this.lblTotalProfesie.Size = new System.Drawing.Size(31, 13);
            this.lblTotalProfesie.TabIndex = 1;
            this.lblTotalProfesie.Text = "Total";
            this.lblTotalProfesie.ToolTipText = null;
            this.lblTotalProfesie.ToolTipTitle = null;
            // 
            // dgvListaProfesii
            // 
            this.dgvListaProfesii.AllowUserToAddRows = false;
            this.dgvListaProfesii.AllowUserToDeleteRows = false;
            this.dgvListaProfesii.AllowUserToResizeRows = false;
            this.dgvListaProfesii.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaProfesii.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaProfesii.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaProfesii.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaProfesii.HideSelection = true;
            this.dgvListaProfesii.IsInReadOnlyMode = false;
            this.dgvListaProfesii.Location = new System.Drawing.Point(0, 31);
            this.dgvListaProfesii.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListaProfesii.MultiSelect = false;
            this.dgvListaProfesii.Name = "dgvListaProfesii";
            this.dgvListaProfesii.ProprietateCorespunzatoare = "";
            this.dgvListaProfesii.RowHeadersVisible = false;
            this.dgvListaProfesii.RowTemplate.Height = 24;
            this.dgvListaProfesii.SeIncarca = false;
            this.dgvListaProfesii.SelectedText = "";
            this.dgvListaProfesii.SelectionLength = 0;
            this.dgvListaProfesii.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaProfesii.SelectionStart = 0;
            this.dgvListaProfesii.Size = new System.Drawing.Size(518, 387);
            this.dgvListaProfesii.TabIndex = 0;
            // 
            // ControlDetaliuLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCautareProfesie);
            this.Controls.Add(this.btnAdaugaProfesie);
            this.Controls.Add(this.lblTitluLista);
            this.Controls.Add(this.lblTotalProfesie);
            this.Controls.Add(this.dgvListaProfesii);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ControlDetaliuLista";
            this.Size = new System.Drawing.Size(520, 443);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaProfesii)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.DataGridViewPersonalizat dgvListaProfesii;
        private CCL.UI.LabelPersonalizat lblTotalProfesie;
        private CCL.UI.LabelPersonalizat lblTitluLista;
        private CCL.UI.ButtonPersonalizat btnAdaugaProfesie;
        private CCL.UI.Caramizi.TextBoxCautare txtCautareProfesie;
    }
}
