namespace iStomaLab.ResurseUmane
{
    partial class ControlVenituri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlVenituri));
            this.ctrlPerioada = new iStomaLab.Caramizi.ControlPerioada();
            this.dgvListaVenituri = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.lblTotal = new CCL.UI.LabelPersonalizat(this.components);
            this.txtCautare = new CCL.UI.Caramizi.TextBoxCautare();
            this.lblCauta = new CCL.UI.LabelPersonalizat(this.components);
            this.btnImprimare = new CCL.UI.ButtonPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaVenituri)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlPerioada
            // 
            this.ctrlPerioada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlPerioada.Location = new System.Drawing.Point(0, 2);
            this.ctrlPerioada.Name = "ctrlPerioada";
            this.ctrlPerioada.Size = new System.Drawing.Size(1005, 56);
            this.ctrlPerioada.TabIndex = 4;
            // 
            // dgvListaVenituri
            // 
            this.dgvListaVenituri.AllowUserToAddRows = false;
            this.dgvListaVenituri.AllowUserToDeleteRows = false;
            this.dgvListaVenituri.AllowUserToResizeRows = false;
            this.dgvListaVenituri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaVenituri.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaVenituri.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaVenituri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaVenituri.HideSelection = true;
            this.dgvListaVenituri.IsInReadOnlyMode = false;
            this.dgvListaVenituri.Location = new System.Drawing.Point(-2, 91);
            this.dgvListaVenituri.MultiSelect = false;
            this.dgvListaVenituri.Name = "dgvListaVenituri";
            this.dgvListaVenituri.ProprietateCorespunzatoare = "";
            this.dgvListaVenituri.RowHeadersVisible = false;
            this.dgvListaVenituri.SeIncarca = false;
            this.dgvListaVenituri.SelectedText = "";
            this.dgvListaVenituri.SelectionLength = 0;
            this.dgvListaVenituri.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaVenituri.SelectionStart = 0;
            this.dgvListaVenituri.Size = new System.Drawing.Size(1008, 389);
            this.dgvListaVenituri.TabIndex = 6;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(1, 483);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(31, 13);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "Total";
            this.lblTotal.ToolTipText = null;
            this.lblTotal.ToolTipTitle = null;
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
            this.txtCautare.Location = new System.Drawing.Point(727, 64);
            this.txtCautare.MaxLength = 32767;
            this.txtCautare.Multiline = false;
            this.txtCautare.Name = "txtCautare";
            this.txtCautare.ProprietateCorespunzatoare = null;
            this.txtCautare.RaiseEventLaModificareProgramatica = false;
            this.txtCautare.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautare.Size = new System.Drawing.Size(225, 21);
            this.txtCautare.TabIndex = 8;
            this.txtCautare.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautare.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautare.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautare.UseSystemPasswordChar = false;
            // 
            // lblCauta
            // 
            this.lblCauta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCauta.AutoSize = true;
            this.lblCauta.Location = new System.Drawing.Point(671, 68);
            this.lblCauta.Name = "lblCauta";
            this.lblCauta.Size = new System.Drawing.Size(35, 13);
            this.lblCauta.TabIndex = 14;
            this.lblCauta.Text = "Cauta";
            this.lblCauta.ToolTipText = null;
            this.lblCauta.ToolTipTitle = null;
            // 
            // btnImprimare
            // 
            this.btnImprimare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimare.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnImprimare.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimare.Image")));
            this.btnImprimare.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimare.Location = new System.Drawing.Point(965, 64);
            this.btnImprimare.Name = "btnImprimare";
            this.btnImprimare.Size = new System.Drawing.Size(37, 23);
            this.btnImprimare.TabIndex = 23;
            this.btnImprimare.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Print;
            this.btnImprimare.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnImprimare.UseVisualStyleBackColor = true;
            // 
            // ControlVenituri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnImprimare);
            this.Controls.Add(this.lblCauta);
            this.Controls.Add(this.txtCautare);
            this.Controls.Add(this.dgvListaVenituri);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.ctrlPerioada);
            this.Name = "ControlVenituri";
            this.Size = new System.Drawing.Size(1005, 500);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaVenituri)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Caramizi.ControlPerioada ctrlPerioada;
        private CCL.UI.DataGridViewPersonalizat dgvListaVenituri;
        private CCL.UI.LabelPersonalizat lblTotal;
        private CCL.UI.Caramizi.TextBoxCautare txtCautare;
        private CCL.UI.LabelPersonalizat lblCauta;
        private CCL.UI.ButtonPersonalizat btnImprimare;
    }
}
