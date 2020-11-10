namespace iStomaLab.Setari.Lucrari
{
    partial class ControlListaDePreturi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlListaDePreturi));
            this.lblTotalListaPreturi = new CCL.UI.LabelPersonalizat(this.components);
            this.dgvListaPreturi = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.btnAdaugareLucrare = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblTitluListaDePreturi = new CCL.UI.LabelPersonalizat(this.components);
            this.txtCautareLucrare = new CCL.UI.Caramizi.TextBoxCautare();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPreturi)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotalListaPreturi
            // 
            this.lblTotalListaPreturi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalListaPreturi.AutoSize = true;
            this.lblTotalListaPreturi.Location = new System.Drawing.Point(2, 422);
            this.lblTotalListaPreturi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalListaPreturi.Name = "lblTotalListaPreturi";
            this.lblTotalListaPreturi.Size = new System.Drawing.Size(31, 13);
            this.lblTotalListaPreturi.TabIndex = 4;
            this.lblTotalListaPreturi.Text = "Total";
            this.lblTotalListaPreturi.ToolTipText = null;
            this.lblTotalListaPreturi.ToolTipTitle = null;
            // 
            // dgvListaPreturi
            // 
            this.dgvListaPreturi.AllowUserToAddRows = false;
            this.dgvListaPreturi.AllowUserToDeleteRows = false;
            this.dgvListaPreturi.AllowUserToResizeRows = false;
            this.dgvListaPreturi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaPreturi.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaPreturi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaPreturi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaPreturi.HideSelection = true;
            this.dgvListaPreturi.IsInReadOnlyMode = false;
            this.dgvListaPreturi.Location = new System.Drawing.Point(0, 34);
            this.dgvListaPreturi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvListaPreturi.MultiSelect = false;
            this.dgvListaPreturi.Name = "dgvListaPreturi";
            this.dgvListaPreturi.ProprietateCorespunzatoare = "";
            this.dgvListaPreturi.RowHeadersVisible = false;
            this.dgvListaPreturi.RowTemplate.Height = 24;
            this.dgvListaPreturi.SeIncarca = false;
            this.dgvListaPreturi.SelectedText = "";
            this.dgvListaPreturi.SelectionLength = 0;
            this.dgvListaPreturi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaPreturi.SelectionStart = 0;
            this.dgvListaPreturi.Size = new System.Drawing.Size(632, 385);
            this.dgvListaPreturi.TabIndex = 2;
            // 
            // btnAdaugareLucrare
            // 
            this.btnAdaugareLucrare.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdaugareLucrare.Image = ((System.Drawing.Image)(resources.GetObject("btnAdaugareLucrare.Image")));
            this.btnAdaugareLucrare.Location = new System.Drawing.Point(58, 7);
            this.btnAdaugareLucrare.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdaugareLucrare.Name = "btnAdaugareLucrare";
            this.btnAdaugareLucrare.Size = new System.Drawing.Size(32, 20);
            this.btnAdaugareLucrare.TabIndex = 1;
            this.btnAdaugareLucrare.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdaugareLucrare.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdaugareLucrare.UseVisualStyleBackColor = true;
            // 
            // lblTitluListaDePreturi
            // 
            this.lblTitluListaDePreturi.AutoSize = true;
            this.lblTitluListaDePreturi.Location = new System.Drawing.Point(14, 11);
            this.lblTitluListaDePreturi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitluListaDePreturi.Name = "lblTitluListaDePreturi";
            this.lblTitluListaDePreturi.Size = new System.Drawing.Size(39, 13);
            this.lblTitluListaDePreturi.TabIndex = 0;
            this.lblTitluListaDePreturi.Text = "Lucrari";
            this.lblTitluListaDePreturi.ToolTipText = null;
            this.lblTitluListaDePreturi.ToolTipTitle = null;
            // 
            // txtCautareLucrare
            // 
            this.txtCautareLucrare.AcceptButton = null;
            this.txtCautareLucrare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautareLucrare.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautareLucrare.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautareLucrare.CapitalizeazaPrimaLitera = false;
            this.txtCautareLucrare.IsInReadOnlyMode = false;
            this.txtCautareLucrare.Location = new System.Drawing.Point(333, 7);
            this.txtCautareLucrare.MaxLength = 32767;
            this.txtCautareLucrare.Multiline = false;
            this.txtCautareLucrare.Name = "txtCautareLucrare";
            this.txtCautareLucrare.ProprietateCorespunzatoare = null;
            this.txtCautareLucrare.RaiseEventLaModificareProgramatica = false;
            this.txtCautareLucrare.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautareLucrare.Size = new System.Drawing.Size(296, 20);
            this.txtCautareLucrare.TabIndex = 5;
            this.txtCautareLucrare.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautareLucrare.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautareLucrare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautareLucrare.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautareLucrare.UseSystemPasswordChar = false;
            // 
            // ControlListaDePreturi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCautareLucrare);
            this.Controls.Add(this.lblTotalListaPreturi);
            this.Controls.Add(this.dgvListaPreturi);
            this.Controls.Add(this.btnAdaugareLucrare);
            this.Controls.Add(this.lblTitluListaDePreturi);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ControlListaDePreturi";
            this.Size = new System.Drawing.Size(632, 440);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPreturi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.LabelPersonalizat lblTitluListaDePreturi;
        private CCL.UI.ButtonPersonalizat btnAdaugareLucrare;
        private CCL.UI.DataGridViewPersonalizat dgvListaPreturi;
        private CCL.UI.LabelPersonalizat lblTotalListaPreturi;
        private CCL.UI.Caramizi.TextBoxCautare txtCautareLucrare;
    }
}
