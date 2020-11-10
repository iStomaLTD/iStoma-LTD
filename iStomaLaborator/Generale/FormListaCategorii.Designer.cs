namespace iStomaLab.Generale
{
    partial class FormListaCategorii
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListaCategorii));
            this.dgvListaCategorii = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.btnAdauga = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblNrElemente = new CCL.UI.LabelPersonalizat(this.components);
            this.txtCauta = new CCL.UI.Caramizi.TextBoxCautare();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaCategorii)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitluEcran.Size = new System.Drawing.Size(485, 19);
            this.lblTitluEcran.Text = "FormListaCategoriics";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(484, 0);
            this.btnInchidereEcran.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            // 
            // dgvListaCategorii
            // 
            this.dgvListaCategorii.AllowUserToAddRows = false;
            this.dgvListaCategorii.AllowUserToDeleteRows = false;
            this.dgvListaCategorii.AllowUserToResizeRows = false;
            this.dgvListaCategorii.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaCategorii.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaCategorii.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaCategorii.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaCategorii.HideSelection = true;
            this.dgvListaCategorii.IsInReadOnlyMode = false;
            this.dgvListaCategorii.Location = new System.Drawing.Point(3, 54);
            this.dgvListaCategorii.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvListaCategorii.MultiSelect = false;
            this.dgvListaCategorii.Name = "dgvListaCategorii";
            this.dgvListaCategorii.ProprietateCorespunzatoare = "";
            this.dgvListaCategorii.RowHeadersVisible = false;
            this.dgvListaCategorii.RowTemplate.Height = 24;
            this.dgvListaCategorii.SeIncarca = false;
            this.dgvListaCategorii.SelectedText = "";
            this.dgvListaCategorii.SelectionLength = 0;
            this.dgvListaCategorii.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaCategorii.SelectionStart = 0;
            this.dgvListaCategorii.Size = new System.Drawing.Size(501, 296);
            this.dgvListaCategorii.TabIndex = 2;
            // 
            // btnAdauga
            // 
            this.btnAdauga.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdauga.Image = ((System.Drawing.Image)(resources.GetObject("btnAdauga.Image")));
            this.btnAdauga.Location = new System.Drawing.Point(10, 26);
            this.btnAdauga.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdauga.Name = "btnAdauga";
            this.btnAdauga.Size = new System.Drawing.Size(56, 23);
            this.btnAdauga.TabIndex = 3;
            this.btnAdauga.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdauga.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdauga.UseVisualStyleBackColor = true;
            // 
            // lblNrElemente
            // 
            this.lblNrElemente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNrElemente.AutoSize = true;
            this.lblNrElemente.Location = new System.Drawing.Point(10, 355);
            this.lblNrElemente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNrElemente.Name = "lblNrElemente";
            this.lblNrElemente.Size = new System.Drawing.Size(59, 13);
            this.lblNrElemente.TabIndex = 5;
            this.lblNrElemente.Text = "0 elemente";
            this.lblNrElemente.ToolTipText = null;
            this.lblNrElemente.ToolTipTitle = null;
            // 
            // txtCauta
            // 
            this.txtCauta.AcceptButton = null;
            this.txtCauta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCauta.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCauta.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCauta.BackColor = System.Drawing.Color.Transparent;
            this.txtCauta.CapitalizeazaPrimaLitera = false;
            this.txtCauta.IsInReadOnlyMode = false;
            this.txtCauta.Location = new System.Drawing.Point(215, 26);
            this.txtCauta.MaxLength = 32767;
            this.txtCauta.Multiline = false;
            this.txtCauta.Name = "txtCauta";
            this.txtCauta.ProprietateCorespunzatoare = null;
            this.txtCauta.RaiseEventLaModificareProgramatica = false;
            this.txtCauta.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCauta.Size = new System.Drawing.Size(289, 20);
            this.txtCauta.TabIndex = 6;
            this.txtCauta.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCauta.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCauta.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCauta.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCauta.UseSystemPasswordChar = false;
            // 
            // FormListaCategorii
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 376);
            this.Controls.Add(this.txtCauta);
            this.Controls.Add(this.lblNrElemente);
            this.Controls.Add(this.btnAdauga);
            this.Controls.Add(this.dgvListaCategorii);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormListaCategorii";
            this.Text = "FormListaCategoriics";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.dgvListaCategorii, 0);
            this.Controls.SetChildIndex(this.btnAdauga, 0);
            this.Controls.SetChildIndex(this.lblNrElemente, 0);
            this.Controls.SetChildIndex(this.txtCauta, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaCategorii)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.DataGridViewPersonalizat dgvListaCategorii;
        private CCL.UI.ButtonPersonalizat btnAdauga;
        private CCL.UI.LabelPersonalizat lblNrElemente;
        private CCL.UI.Caramizi.TextBoxCautare txtCauta;
    }
}