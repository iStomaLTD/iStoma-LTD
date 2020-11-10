namespace iStomaLab.TablouDeBord.Clienti
{
    partial class ControlListaClienti
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlListaClienti));
            this.lblTotalClienti = new CCL.UI.LabelPersonalizat(this.components);
            this.dgvListaClienti = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.btnAdaugaClient = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblTitluListaClienti = new CCL.UI.LabelPersonalizat(this.components);
            this.txtCautareClient = new CCL.UI.Caramizi.TextBoxCautare();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaClienti)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotalClienti
            // 
            this.lblTotalClienti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalClienti.AutoSize = true;
            this.lblTotalClienti.Location = new System.Drawing.Point(9, 433);
            this.lblTotalClienti.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalClienti.Name = "lblTotalClienti";
            this.lblTotalClienti.Size = new System.Drawing.Size(41, 13);
            this.lblTotalClienti.TabIndex = 4;
            this.lblTotalClienti.Text = "Nr total";
            this.lblTotalClienti.ToolTipText = null;
            this.lblTotalClienti.ToolTipTitle = null;
            // 
            // dgvListaClienti
            // 
            this.dgvListaClienti.AllowUserToAddRows = false;
            this.dgvListaClienti.AllowUserToDeleteRows = false;
            this.dgvListaClienti.AllowUserToResizeRows = false;
            this.dgvListaClienti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaClienti.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaClienti.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaClienti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListaClienti.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListaClienti.HideSelection = true;
            this.dgvListaClienti.IsInReadOnlyMode = false;
            this.dgvListaClienti.Location = new System.Drawing.Point(1, 35);
            this.dgvListaClienti.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListaClienti.MultiSelect = false;
            this.dgvListaClienti.Name = "dgvListaClienti";
            this.dgvListaClienti.ProprietateCorespunzatoare = "";
            this.dgvListaClienti.RowHeadersVisible = false;
            this.dgvListaClienti.RowTemplate.Height = 24;
            this.dgvListaClienti.SeIncarca = false;
            this.dgvListaClienti.SelectedText = "";
            this.dgvListaClienti.SelectionLength = 0;
            this.dgvListaClienti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaClienti.SelectionStart = 0;
            this.dgvListaClienti.Size = new System.Drawing.Size(634, 394);
            this.dgvListaClienti.TabIndex = 3;
            // 
            // btnAdaugaClient
            // 
            this.btnAdaugaClient.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdaugaClient.Image = ((System.Drawing.Image)(resources.GetObject("btnAdaugaClient.Image")));
            this.btnAdaugaClient.Location = new System.Drawing.Point(44, 8);
            this.btnAdaugaClient.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdaugaClient.Name = "btnAdaugaClient";
            this.btnAdaugaClient.Size = new System.Drawing.Size(44, 21);
            this.btnAdaugaClient.TabIndex = 1;
            this.btnAdaugaClient.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdaugaClient.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdaugaClient.UseVisualStyleBackColor = true;
            // 
            // lblTitluListaClienti
            // 
            this.lblTitluListaClienti.AutoSize = true;
            this.lblTitluListaClienti.Location = new System.Drawing.Point(9, 12);
            this.lblTitluListaClienti.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitluListaClienti.Name = "lblTitluListaClienti";
            this.lblTitluListaClienti.Size = new System.Drawing.Size(33, 13);
            this.lblTitluListaClienti.TabIndex = 0;
            this.lblTitluListaClienti.Text = "Client";
            this.lblTitluListaClienti.ToolTipText = null;
            this.lblTitluListaClienti.ToolTipTitle = null;
            // 
            // txtCautareClient
            // 
            this.txtCautareClient.AcceptButton = null;
            this.txtCautareClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautareClient.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautareClient.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautareClient.BackColor = System.Drawing.Color.White;
            this.txtCautareClient.CapitalizeazaPrimaLitera = false;
            this.txtCautareClient.IsInReadOnlyMode = false;
            this.txtCautareClient.Location = new System.Drawing.Point(281, 8);
            this.txtCautareClient.MaxLength = 32767;
            this.txtCautareClient.Multiline = false;
            this.txtCautareClient.Name = "txtCautareClient";
            this.txtCautareClient.ProprietateCorespunzatoare = null;
            this.txtCautareClient.RaiseEventLaModificareProgramatica = false;
            this.txtCautareClient.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautareClient.Size = new System.Drawing.Size(351, 20);
            this.txtCautareClient.TabIndex = 5;
            this.txtCautareClient.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautareClient.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautareClient.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautareClient.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautareClient.UseSystemPasswordChar = false;
            // 
            // ControlListaClienti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCautareClient);
            this.Controls.Add(this.lblTotalClienti);
            this.Controls.Add(this.dgvListaClienti);
            this.Controls.Add(this.btnAdaugaClient);
            this.Controls.Add(this.lblTitluListaClienti);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ControlListaClienti";
            this.Size = new System.Drawing.Size(635, 451);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaClienti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.LabelPersonalizat lblTitluListaClienti;
        private CCL.UI.ButtonPersonalizat btnAdaugaClient;
        private CCL.UI.DataGridViewPersonalizat dgvListaClienti;
        private CCL.UI.LabelPersonalizat lblTotalClienti;
        private CCL.UI.Caramizi.TextBoxCautare txtCautareClient;
    }
}
