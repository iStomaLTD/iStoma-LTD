namespace iStomaLab.TablouDeBord.Clienti
{
    partial class FormLucrareListaEtapeRealizate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLucrareListaEtapeRealizate));
            this.txtCautaEtapa = new CCL.UI.Caramizi.TextBoxCautare();
            this.dgvListaEtape = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.ctrlValidareAnulare = new CCL.UI.Caramizi.controlValidareAnulare();
            this.lblTitlu = new CCL.UI.LabelPersonalizat(this.components);
            this.btnActivDezactivat = new CCL.UI.ButtonPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaEtape)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(958, 19);
            this.lblTitluEcran.TabIndex = 5;
            this.lblTitluEcran.Text = "FormLucrareListaEtapeRealizate";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(957, 0);
            this.btnInchidereEcran.TabIndex = 6;
            // 
            // txtCautaEtapa
            // 
            this.txtCautaEtapa.AcceptButton = null;
            this.txtCautaEtapa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautaEtapa.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautaEtapa.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautaEtapa.BackColor = System.Drawing.Color.White;
            this.txtCautaEtapa.CapitalizeazaPrimaLitera = false;
            this.txtCautaEtapa.IsInReadOnlyMode = false;
            this.txtCautaEtapa.Location = new System.Drawing.Point(706, 25);
            this.txtCautaEtapa.MaxLength = 32767;
            this.txtCautaEtapa.Multiline = false;
            this.txtCautaEtapa.Name = "txtCautaEtapa";
            this.txtCautaEtapa.ProprietateCorespunzatoare = null;
            this.txtCautaEtapa.RaiseEventLaModificareProgramatica = false;
            this.txtCautaEtapa.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautaEtapa.Size = new System.Drawing.Size(271, 20);
            this.txtCautaEtapa.TabIndex = 0;
            this.txtCautaEtapa.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautaEtapa.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautaEtapa.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautaEtapa.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautaEtapa.UseSystemPasswordChar = false;
            // 
            // dgvListaEtape
            // 
            this.dgvListaEtape.AllowUserToAddRows = false;
            this.dgvListaEtape.AllowUserToDeleteRows = false;
            this.dgvListaEtape.AllowUserToResizeRows = false;
            this.dgvListaEtape.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaEtape.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaEtape.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaEtape.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaEtape.HideSelection = true;
            this.dgvListaEtape.IsInReadOnlyMode = false;
            this.dgvListaEtape.Location = new System.Drawing.Point(3, 51);
            this.dgvListaEtape.MultiSelect = false;
            this.dgvListaEtape.Name = "dgvListaEtape";
            this.dgvListaEtape.ProprietateCorespunzatoare = "";
            this.dgvListaEtape.RowHeadersVisible = false;
            this.dgvListaEtape.SeIncarca = false;
            this.dgvListaEtape.SelectedText = "";
            this.dgvListaEtape.SelectionLength = 0;
            this.dgvListaEtape.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaEtape.SelectionStart = 0;
            this.dgvListaEtape.Size = new System.Drawing.Size(974, 302);
            this.dgvListaEtape.TabIndex = 1;
            // 
            // ctrlValidareAnulare
            // 
            this.ctrlValidareAnulare.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrlValidareAnulare.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulare.Location = new System.Drawing.Point(414, 359);
            this.ctrlValidareAnulare.Name = "ctrlValidareAnulare";
            this.ctrlValidareAnulare.Size = new System.Drawing.Size(166, 23);
            this.ctrlValidareAnulare.TabIndex = 2;
            // 
            // lblTitlu
            // 
            this.lblTitlu.AutoSize = true;
            this.lblTitlu.Location = new System.Drawing.Point(6, 29);
            this.lblTitlu.Name = "lblTitlu";
            this.lblTitlu.Size = new System.Drawing.Size(35, 13);
            this.lblTitlu.TabIndex = 3;
            this.lblTitlu.Text = "Etape";
            this.lblTitlu.ToolTipText = null;
            this.lblTitlu.ToolTipTitle = null;
            // 
            // btnActivDezactivat
            // 
            this.btnActivDezactivat.ForeColor = System.Drawing.Color.Black;
            this.btnActivDezactivat.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnActivDezactivat.Image = ((System.Drawing.Image)(resources.GetObject("btnActivDezactivat.Image")));
            this.btnActivDezactivat.Location = new System.Drawing.Point(47, 23);
            this.btnActivDezactivat.Name = "btnActivDezactivat";
            this.btnActivDezactivat.Size = new System.Drawing.Size(40, 25);
            this.btnActivDezactivat.TabIndex = 4;
            this.btnActivDezactivat.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.ActiviDezactivati;
            this.btnActivDezactivat.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnActivDezactivat.UseVisualStyleBackColor = true;
            // 
            // FormLucrareListaEtapeRealizate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 387);
            this.Controls.Add(this.btnActivDezactivat);
            this.Controls.Add(this.lblTitlu);
            this.Controls.Add(this.ctrlValidareAnulare);
            this.Controls.Add(this.dgvListaEtape);
            this.Controls.Add(this.txtCautaEtapa);
            this.MinimumSize = new System.Drawing.Size(738, 387);
            this.Name = "FormLucrareListaEtapeRealizate";
            this.Text = "FormLucrareListaEtapeRealizate";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.txtCautaEtapa, 0);
            this.Controls.SetChildIndex(this.dgvListaEtape, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulare, 0);
            this.Controls.SetChildIndex(this.lblTitlu, 0);
            this.Controls.SetChildIndex(this.btnActivDezactivat, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaEtape)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.Caramizi.TextBoxCautare txtCautaEtapa;
        private CCL.UI.DataGridViewPersonalizat dgvListaEtape;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulare;
        private CCL.UI.LabelPersonalizat lblTitlu;
        private CCL.UI.ButtonPersonalizat btnActivDezactivat;
    }
}