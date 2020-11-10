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
            this.lblTitlu = new CCL.UI.LabelPersonalizat(this.components);
            this.btnAdaugaUtilizator = new CCL.UI.ButtonPersonalizat(this.components);
            this.dgvListaUtilizatori = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.lblTotalUtilizatori = new CCL.UI.LabelPersonalizat(this.components);
            this.txtCautareUtilizatori = new CCL.UI.Caramizi.TextBoxCautare();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaUtilizatori)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitlu
            // 
            this.lblTitlu.Location = new System.Drawing.Point(4, 2);
            this.lblTitlu.Name = "lblTitlu";
            this.lblTitlu.Size = new System.Drawing.Size(100, 23);
            this.lblTitlu.TabIndex = 0;
            this.lblTitlu.Text = "Personal";
            this.lblTitlu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitlu.ToolTipText = null;
            this.lblTitlu.ToolTipTitle = null;
            // 
            // btnAdaugaUtilizator
            // 
            this.btnAdaugaUtilizator.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdaugaUtilizator.Image = ((System.Drawing.Image)(resources.GetObject("btnAdaugaUtilizator.Image")));
            this.btnAdaugaUtilizator.Location = new System.Drawing.Point(59, 2);
            this.btnAdaugaUtilizator.Name = "btnAdaugaUtilizator";
            this.btnAdaugaUtilizator.Size = new System.Drawing.Size(48, 23);
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
            this.dgvListaUtilizatori.Size = new System.Drawing.Size(601, 373);
            this.dgvListaUtilizatori.TabIndex = 2;
            // 
            // lblTotalUtilizatori
            // 
            this.lblTotalUtilizatori.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalUtilizatori.AutoSize = true;
            this.lblTotalUtilizatori.Location = new System.Drawing.Point(3, 406);
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
            this.txtCautareUtilizatori.Location = new System.Drawing.Point(247, 3);
            this.txtCautareUtilizatori.MaxLength = 32767;
            this.txtCautareUtilizatori.Multiline = false;
            this.txtCautareUtilizatori.Name = "txtCautareUtilizatori";
            this.txtCautareUtilizatori.ProprietateCorespunzatoare = null;
            this.txtCautareUtilizatori.RaiseEventLaModificareProgramatica = false;
            this.txtCautareUtilizatori.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautareUtilizatori.Size = new System.Drawing.Size(351, 20);
            this.txtCautareUtilizatori.TabIndex = 4;
            this.txtCautareUtilizatori.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautareUtilizatori.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautareUtilizatori.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautareUtilizatori.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautareUtilizatori.UseSystemPasswordChar = false;
            // 
            // ControlListaUtilizatori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.txtCautareUtilizatori);
            this.Controls.Add(this.lblTotalUtilizatori);
            this.Controls.Add(this.dgvListaUtilizatori);
            this.Controls.Add(this.btnAdaugaUtilizator);
            this.Controls.Add(this.lblTitlu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ControlListaUtilizatori";
            this.Size = new System.Drawing.Size(601, 424);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaUtilizatori)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.LabelPersonalizat lblTitlu;
        private CCL.UI.ButtonPersonalizat btnAdaugaUtilizator;
        private CCL.UI.DataGridViewPersonalizat dgvListaUtilizatori;
        private CCL.UI.LabelPersonalizat lblTotalUtilizatori;
        private CCL.UI.Caramizi.TextBoxCautare txtCautareUtilizatori;
    }
}
