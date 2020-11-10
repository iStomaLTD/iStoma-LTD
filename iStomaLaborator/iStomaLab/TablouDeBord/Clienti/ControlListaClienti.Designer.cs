using static CDL.iStomaLab.CDefinitiiComune;

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
            this.btnActiviInactivi = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnOptiuni = new CCL.UI.ControaleSpecializate.ButonMaiMulte();
            this.panelOptiuni1 = new CCL.UI.ControaleSpecializate.PanelOptiuni();
            this.btnInchidePanelOptiuni = new CCL.UI.ControaleSpecializate.ButonInchidePanelOptiuni();
            this.btnImporta = new CCL.UI.ControaleSpecializate.ButonOptiunePanelOptiuni();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaClienti)).BeginInit();
            this.panelOptiuni1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTotalClienti
            // 
            this.lblTotalClienti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalClienti.AutoSize = true;
            this.lblTotalClienti.Location = new System.Drawing.Point(2, 436);
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
            this.dgvListaClienti.Location = new System.Drawing.Point(-1, 30);
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
            this.dgvListaClienti.Size = new System.Drawing.Size(637, 402);
            this.dgvListaClienti.TabIndex = 3;
            // 
            // btnAdaugaClient
            // 
            this.btnAdaugaClient.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdaugaClient.Image = ((System.Drawing.Image)(resources.GetObject("btnAdaugaClient.Image")));
            this.btnAdaugaClient.Location = new System.Drawing.Point(51, 3);
            this.btnAdaugaClient.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdaugaClient.Name = "btnAdaugaClient";
            this.btnAdaugaClient.Size = new System.Drawing.Size(50, 23);
            this.btnAdaugaClient.TabIndex = 1;
            this.btnAdaugaClient.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdaugaClient.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdaugaClient.UseVisualStyleBackColor = true;
            // 
            // lblTitluListaClienti
            // 
            this.lblTitluListaClienti.AutoSize = true;
            this.lblTitluListaClienti.Location = new System.Drawing.Point(2, 8);
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
            this.txtCautareClient.Location = new System.Drawing.Point(370, 5);
            this.txtCautareClient.MaxLength = 32767;
            this.txtCautareClient.Multiline = false;
            this.txtCautareClient.Name = "txtCautareClient";
            this.txtCautareClient.ProprietateCorespunzatoare = null;
            this.txtCautareClient.RaiseEventLaModificareProgramatica = false;
            this.txtCautareClient.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautareClient.Size = new System.Drawing.Size(225, 21);
            this.txtCautareClient.TabIndex = 5;
            this.txtCautareClient.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautareClient.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautareClient.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautareClient.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautareClient.UseSystemPasswordChar = false;
            // 
            // btnActiviInactivi
            // 
            this.btnActiviInactivi.ForeColor = System.Drawing.Color.Black;
            this.btnActiviInactivi.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnActiviInactivi.Image = ((System.Drawing.Image)(resources.GetObject("btnActiviInactivi.Image")));
            this.btnActiviInactivi.Location = new System.Drawing.Point(106, 3);
            this.btnActiviInactivi.Name = "btnActiviInactivi";
            this.btnActiviInactivi.Size = new System.Drawing.Size(50, 23);
            this.btnActiviInactivi.TabIndex = 6;
            this.btnActiviInactivi.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.ActiviDezactivati;
            this.btnActiviInactivi.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnActiviInactivi.UseVisualStyleBackColor = true;
            // 
            // btnOptiuni
            // 
            this.btnOptiuni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptiuni.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOptiuni.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnOptiuni.Image = ((System.Drawing.Image)(resources.GetObject("btnOptiuni.Image")));
            this.btnOptiuni.Location = new System.Drawing.Point(602, 4);
            this.btnOptiuni.Name = "btnOptiuni";
            this.btnOptiuni.Size = new System.Drawing.Size(29, 23);
            this.btnOptiuni.TabIndex = 7;
            this.btnOptiuni.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.MaiMulte;
            this.btnOptiuni.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnOptiuni.UseVisualStyleBackColor = true;
            // 
            // panelOptiuni1
            // 
            this.panelOptiuni1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOptiuni1.BackColor = System.Drawing.Color.White;
            this.panelOptiuni1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOptiuni1.Controls.Add(this.btnImporta);
            this.panelOptiuni1.Controls.Add(this.btnInchidePanelOptiuni);
            this.panelOptiuni1.Location = new System.Drawing.Point(515, 30);
            this.panelOptiuni1.Name = "panelOptiuni1";
            this.panelOptiuni1.Size = new System.Drawing.Size(120, 57);
            this.panelOptiuni1.TabIndex = 8;
            this.panelOptiuni1.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.panelOptiuni1.Visible = false;
            // 
            // btnInchidePanelOptiuni
            // 
            this.btnInchidePanelOptiuni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInchidePanelOptiuni.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnInchidePanelOptiuni.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInchidePanelOptiuni.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnInchidePanelOptiuni.FlatAppearance.BorderSize = 0;
            this.btnInchidePanelOptiuni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInchidePanelOptiuni.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInchidePanelOptiuni.Location = new System.Drawing.Point(84, 1);
            this.btnInchidePanelOptiuni.Name = "btnInchidePanelOptiuni";
            this.btnInchidePanelOptiuni.Size = new System.Drawing.Size(35, 25);
            this.btnInchidePanelOptiuni.TabIndex = 13;
            this.btnInchidePanelOptiuni.TabStop = false;
            this.btnInchidePanelOptiuni.Text = "X";
            this.btnInchidePanelOptiuni.UseVisualStyleBackColor = false;
            // 
            // btnImporta
            // 
            this.btnImporta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImporta.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnImporta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImporta.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnImporta.FlatAppearance.BorderSize = 0;
            this.btnImporta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImporta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImporta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImporta.Location = new System.Drawing.Point(-1, 30);
            this.btnImporta.Name = "btnImporta";
            this.btnImporta.Size = new System.Drawing.Size(121, 26);
            this.btnImporta.TabIndex = 14;
            this.btnImporta.Text = "Importa";
            this.btnImporta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImporta.UseVisualStyleBackColor = false;
            // 
            // ControlListaClienti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelOptiuni1);
            this.Controls.Add(this.btnOptiuni);
            this.Controls.Add(this.btnActiviInactivi);
            this.Controls.Add(this.txtCautareClient);
            this.Controls.Add(this.lblTotalClienti);
            this.Controls.Add(this.dgvListaClienti);
            this.Controls.Add(this.btnAdaugaClient);
            this.Controls.Add(this.lblTitluListaClienti);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ControlListaClienti";
            this.Size = new System.Drawing.Size(635, 451);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaClienti)).EndInit();
            this.panelOptiuni1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.LabelPersonalizat lblTitluListaClienti;
        private CCL.UI.ButtonPersonalizat btnAdaugaClient;
        private CCL.UI.DataGridViewPersonalizat dgvListaClienti;
        private CCL.UI.LabelPersonalizat lblTotalClienti;
        private CCL.UI.Caramizi.TextBoxCautare txtCautareClient;
        private CCL.UI.ButtonPersonalizat btnActiviInactivi;
        private CCL.UI.ControaleSpecializate.ButonMaiMulte btnOptiuni;
        private CCL.UI.ControaleSpecializate.PanelOptiuni panelOptiuni1;
        private CCL.UI.ControaleSpecializate.ButonOptiunePanelOptiuni btnImporta;
        private CCL.UI.ControaleSpecializate.ButonInchidePanelOptiuni btnInchidePanelOptiuni;
    }
}
