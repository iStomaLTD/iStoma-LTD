namespace iStomaLab.TablouDeBord.Facturare
{
    partial class ControlListaLucrariNefacturate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlListaLucrariNefacturate));
            this.ctrlPerioada = new iStomaLab.Caramizi.ControlPerioada();
            this.txtCautare = new CCL.UI.Caramizi.TextBoxCautare();
            this.lblClinica = new CCL.UI.LabelPersonalizat(this.components);
            this.lblTotal = new CCL.UI.LabelPersonalizat(this.components);
            this.dgvLista = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.btnFactureaza = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnOptiuni = new CCL.UI.ControaleSpecializate.ButonMaiMulte();
            this.panelOptiuni = new CCL.UI.ControaleSpecializate.PanelOptiuni();
            this.btnInchidePanelOptiuni = new CCL.UI.ControaleSpecializate.ButonInchidePanelOptiuni();
            this.ctrlDataInteres = new iStomaLab.TablouDeBord.ControlDataInteresLucrari();
            this.ctrlCautareClinica = new iStomaLab.Caramizi.ControlCautareDupaTextClinica();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.panelOptiuni.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlPerioada
            // 
            this.ctrlPerioada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlPerioada.Location = new System.Drawing.Point(1, -1);
            this.ctrlPerioada.Name = "ctrlPerioada";
            this.ctrlPerioada.Size = new System.Drawing.Size(851, 56);
            this.ctrlPerioada.TabIndex = 8;
            // 
            // txtCautare
            // 
            this.txtCautare.AcceptButton = null;
            this.txtCautare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautare.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautare.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautare.BackColor = System.Drawing.Color.White;
            this.txtCautare.CapitalizeazaPrimaLitera = false;
            this.txtCautare.IsInReadOnlyMode = false;
            this.txtCautare.Location = new System.Drawing.Point(563, 58);
            this.txtCautare.MaxLength = 32767;
            this.txtCautare.Multiline = false;
            this.txtCautare.Name = "txtCautare";
            this.txtCautare.ProprietateCorespunzatoare = null;
            this.txtCautare.RaiseEventLaModificareProgramatica = false;
            this.txtCautare.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautare.Size = new System.Drawing.Size(251, 21);
            this.txtCautare.TabIndex = 9;
            this.txtCautare.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautare.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautare.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautare.UseSystemPasswordChar = false;
            // 
            // lblClinica
            // 
            this.lblClinica.AutoSize = true;
            this.lblClinica.Location = new System.Drawing.Point(3, 62);
            this.lblClinica.Name = "lblClinica";
            this.lblClinica.Size = new System.Drawing.Size(38, 13);
            this.lblClinica.TabIndex = 13;
            this.lblClinica.Text = "Clinica";
            this.lblClinica.ToolTipText = null;
            this.lblClinica.ToolTipTitle = null;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTotal.Location = new System.Drawing.Point(3, 451);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(51, 22);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "Total";
            this.lblTotal.ToolTipText = null;
            this.lblTotal.ToolTipTitle = null;
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
            this.dgvLista.Location = new System.Drawing.Point(-1, 82);
            this.dgvLista.MultiSelect = false;
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ProprietateCorespunzatoare = "";
            this.dgvLista.RowHeadersVisible = false;
            this.dgvLista.SeIncarca = false;
            this.dgvLista.SelectedText = "";
            this.dgvLista.SelectionLength = 0;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLista.SelectionStart = 0;
            this.dgvLista.Size = new System.Drawing.Size(854, 365);
            this.dgvLista.TabIndex = 10;
            // 
            // btnFactureaza
            // 
            this.btnFactureaza.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFactureaza.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnFactureaza.Image = null;
            this.btnFactureaza.Location = new System.Drawing.Point(383, 57);
            this.btnFactureaza.Name = "btnFactureaza";
            this.btnFactureaza.Size = new System.Drawing.Size(148, 23);
            this.btnFactureaza.TabIndex = 14;
            this.btnFactureaza.Text = "Factureaza";
            this.btnFactureaza.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnFactureaza.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnFactureaza.UseVisualStyleBackColor = true;
            // 
            // btnOptiuni
            // 
            this.btnOptiuni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptiuni.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOptiuni.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnOptiuni.Image = ((System.Drawing.Image)(resources.GetObject("btnOptiuni.Image")));
            this.btnOptiuni.Location = new System.Drawing.Point(820, 57);
            this.btnOptiuni.Name = "btnOptiuni";
            this.btnOptiuni.Size = new System.Drawing.Size(29, 23);
            this.btnOptiuni.TabIndex = 15;
            this.btnOptiuni.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.MaiMulte;
            this.btnOptiuni.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnOptiuni.UseVisualStyleBackColor = true;
            // 
            // panelOptiuni
            // 
            this.panelOptiuni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOptiuni.BackColor = System.Drawing.Color.White;
            this.panelOptiuni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOptiuni.Controls.Add(this.btnInchidePanelOptiuni);
            this.panelOptiuni.Controls.Add(this.ctrlDataInteres);
            this.panelOptiuni.Location = new System.Drawing.Point(630, 82);
            this.panelOptiuni.Name = "panelOptiuni";
            this.panelOptiuni.Size = new System.Drawing.Size(222, 113);
            this.panelOptiuni.TabIndex = 16;
            this.panelOptiuni.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.panelOptiuni.Visible = false;
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
            this.btnInchidePanelOptiuni.Location = new System.Drawing.Point(184, 1);
            this.btnInchidePanelOptiuni.Name = "btnInchidePanelOptiuni";
            this.btnInchidePanelOptiuni.Size = new System.Drawing.Size(35, 25);
            this.btnInchidePanelOptiuni.TabIndex = 13;
            this.btnInchidePanelOptiuni.TabStop = false;
            this.btnInchidePanelOptiuni.Text = "X";
            this.btnInchidePanelOptiuni.UseVisualStyleBackColor = false;
            // 
            // ctrlDataInteres
            // 
            this.ctrlDataInteres.Location = new System.Drawing.Point(1, 30);
            this.ctrlDataInteres.Name = "ctrlDataInteres";
            this.ctrlDataInteres.Size = new System.Drawing.Size(245, 87);
            this.ctrlDataInteres.TabIndex = 14;
            // 
            // ctrlCautareClinica
            // 
            this.ctrlCautareClinica.Location = new System.Drawing.Point(78, 57);
            this.ctrlCautareClinica.Name = "ctrlCautareClinica";
            this.ctrlCautareClinica.Size = new System.Drawing.Size(267, 23);
            this.ctrlCautareClinica.TabIndex = 17;
            // 
            // ControlListaLucrariNefacturate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlCautareClinica);
            this.Controls.Add(this.panelOptiuni);
            this.Controls.Add(this.btnOptiuni);
            this.Controls.Add(this.btnFactureaza);
            this.Controls.Add(this.lblClinica);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvLista);
            this.Controls.Add(this.txtCautare);
            this.Controls.Add(this.ctrlPerioada);
            this.Name = "ControlListaLucrariNefacturate";
            this.Size = new System.Drawing.Size(852, 477);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.panelOptiuni.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Caramizi.ControlPerioada ctrlPerioada;
        private CCL.UI.Caramizi.TextBoxCautare txtCautare;
        private CCL.UI.LabelPersonalizat lblClinica;
        private CCL.UI.LabelPersonalizat lblTotal;
        private CCL.UI.DataGridViewPersonalizat dgvLista;
        private CCL.UI.ButtonPersonalizat btnFactureaza;
        private CCL.UI.ControaleSpecializate.ButonMaiMulte btnOptiuni;
        private CCL.UI.ControaleSpecializate.PanelOptiuni panelOptiuni;
        private CCL.UI.ControaleSpecializate.ButonInchidePanelOptiuni btnInchidePanelOptiuni;
        private ControlDataInteresLucrari ctrlDataInteres;
        private Caramizi.ControlCautareDupaTextClinica ctrlCautareClinica;
    }
}
