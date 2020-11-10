namespace iStomaLab.Setari.Liste.Categorii
{
    partial class ControlListaCategorii
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlListaCategorii));
            this.tgvListaCategorii = new CCL.UI.TGV.TreeGridView();
            this.btnAdaugaCategorie = new CCL.UI.ButtonPersonalizat(this.components);
            this.txtCautaCategorie = new CCL.UI.Caramizi.TextBoxCautare();
            this.lblCategorie = new CCL.UI.LabelPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tgvListaCategorii)).BeginInit();
            this.SuspendLayout();
            // 
            // tgvListaCategorii
            // 
            this.tgvListaCategorii.AllowUserToAddRows = false;
            this.tgvListaCategorii.AllowUserToDeleteRows = false;
            this.tgvListaCategorii.AllowUserToResizeRows = false;
            this.tgvListaCategorii.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tgvListaCategorii.BackgroundColor = System.Drawing.Color.White;
            this.tgvListaCategorii.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tgvListaCategorii.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tgvListaCategorii.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tgvListaCategorii.HideSelection = true;
            this.tgvListaCategorii.ImageList = null;
            this.tgvListaCategorii.IsInReadOnlyMode = false;
            this.tgvListaCategorii.Location = new System.Drawing.Point(1, 32);
            this.tgvListaCategorii.Margin = new System.Windows.Forms.Padding(2);
            this.tgvListaCategorii.MultiSelect = false;
            this.tgvListaCategorii.Name = "tgvListaCategorii";
            this.tgvListaCategorii.ProprietateCorespunzatoare = "";
            this.tgvListaCategorii.RowHeadersVisible = false;
            this.tgvListaCategorii.SeIncarca = false;
            this.tgvListaCategorii.SelectedText = "";
            this.tgvListaCategorii.SelectionLength = 0;
            this.tgvListaCategorii.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tgvListaCategorii.SelectionStart = 0;
            this.tgvListaCategorii.Size = new System.Drawing.Size(650, 405);
            this.tgvListaCategorii.TabIndex = 0;
            // 
            // btnAdaugaCategorie
            // 
            this.btnAdaugaCategorie.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdaugaCategorie.Image = ((System.Drawing.Image)(resources.GetObject("btnAdaugaCategorie.Image")));
            this.btnAdaugaCategorie.Location = new System.Drawing.Point(60, 5);
            this.btnAdaugaCategorie.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdaugaCategorie.Name = "btnAdaugaCategorie";
            this.btnAdaugaCategorie.Size = new System.Drawing.Size(37, 23);
            this.btnAdaugaCategorie.TabIndex = 1;
            this.btnAdaugaCategorie.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdaugaCategorie.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdaugaCategorie.UseVisualStyleBackColor = true;
            // 
            // txtCautaCategorie
            // 
            this.txtCautaCategorie.AcceptButton = null;
            this.txtCautaCategorie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautaCategorie.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautaCategorie.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautaCategorie.BackColor = System.Drawing.Color.White;
            this.txtCautaCategorie.CapitalizeazaPrimaLitera = false;
            this.txtCautaCategorie.IsInReadOnlyMode = false;
            this.txtCautaCategorie.Location = new System.Drawing.Point(329, 5);
            this.txtCautaCategorie.Margin = new System.Windows.Forms.Padding(2);
            this.txtCautaCategorie.MaxLength = 32767;
            this.txtCautaCategorie.Multiline = false;
            this.txtCautaCategorie.Name = "txtCautaCategorie";
            this.txtCautaCategorie.ProprietateCorespunzatoare = null;
            this.txtCautaCategorie.RaiseEventLaModificareProgramatica = false;
            this.txtCautaCategorie.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautaCategorie.Size = new System.Drawing.Size(318, 22);
            this.txtCautaCategorie.TabIndex = 2;
            this.txtCautaCategorie.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautaCategorie.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautaCategorie.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautaCategorie.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautaCategorie.UseSystemPasswordChar = false;
            // 
            // lblCategorie
            // 
            this.lblCategorie.AutoSize = true;
            this.lblCategorie.Location = new System.Drawing.Point(3, 10);
            this.lblCategorie.Name = "lblCategorie";
            this.lblCategorie.Size = new System.Drawing.Size(52, 13);
            this.lblCategorie.TabIndex = 3;
            this.lblCategorie.Text = "Categorie";
            this.lblCategorie.ToolTipText = null;
            this.lblCategorie.ToolTipTitle = null;
            // 
            // ControlListaCategorii
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCategorie);
            this.Controls.Add(this.txtCautaCategorie);
            this.Controls.Add(this.btnAdaugaCategorie);
            this.Controls.Add(this.tgvListaCategorii);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ControlListaCategorii";
            this.Size = new System.Drawing.Size(652, 436);
            ((System.ComponentModel.ISupportInitialize)(this.tgvListaCategorii)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.TGV.TreeGridView tgvListaCategorii;
        private CCL.UI.ButtonPersonalizat btnAdaugaCategorie;
        private CCL.UI.Caramizi.TextBoxCautare txtCautaCategorie;
        private CCL.UI.LabelPersonalizat lblCategorie;
    }
}
