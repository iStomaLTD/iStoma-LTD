namespace iStomaLab.TablouDeBord.Facturare
{
    partial class ControlListaFacturiEmise
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlListaFacturiEmise));
            this.ctrlPerioada = new iStomaLab.Caramizi.ControlPerioada();
            this.lblClinica = new CCL.UI.LabelPersonalizat(this.components);
            this.txtCautare = new CCL.UI.Caramizi.TextBoxCautare();
            this.lblTotal = new CCL.UI.LabelPersonalizat(this.components);
            this.dgvLista = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.ctrlCautareDupaTextClinica = new iStomaLab.Caramizi.ControlCautareDupaTextClinica();
            this.btnImprima = new CCL.UI.ButtonPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlPerioada
            // 
            this.ctrlPerioada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlPerioada.Location = new System.Drawing.Point(1, -1);
            this.ctrlPerioada.Name = "ctrlPerioada";
            this.ctrlPerioada.Size = new System.Drawing.Size(742, 56);
            this.ctrlPerioada.TabIndex = 4;
            // 
            // lblClinica
            // 
            this.lblClinica.AutoSize = true;
            this.lblClinica.Location = new System.Drawing.Point(7, 64);
            this.lblClinica.Name = "lblClinica";
            this.lblClinica.Size = new System.Drawing.Size(38, 13);
            this.lblClinica.TabIndex = 5;
            this.lblClinica.Text = "Clinica";
            this.lblClinica.ToolTipText = null;
            this.lblClinica.ToolTipTitle = null;
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
            this.txtCautare.Location = new System.Drawing.Point(453, 60);
            this.txtCautare.MaxLength = 32767;
            this.txtCautare.Multiline = false;
            this.txtCautare.Name = "txtCautare";
            this.txtCautare.ProprietateCorespunzatoare = null;
            this.txtCautare.RaiseEventLaModificareProgramatica = false;
            this.txtCautare.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautare.Size = new System.Drawing.Size(244, 21);
            this.txtCautare.TabIndex = 1;
            this.txtCautare.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautare.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautare.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautare.UseSystemPasswordChar = false;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTotal.Location = new System.Drawing.Point(3, 453);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(51, 22);
            this.lblTotal.TabIndex = 3;
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
            this.dgvLista.Location = new System.Drawing.Point(0, 85);
            this.dgvLista.MultiSelect = false;
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ProprietateCorespunzatoare = "";
            this.dgvLista.RowHeadersVisible = false;
            this.dgvLista.SeIncarca = false;
            this.dgvLista.SelectedText = "";
            this.dgvLista.SelectionLength = 0;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLista.SelectionStart = 0;
            this.dgvLista.Size = new System.Drawing.Size(743, 364);
            this.dgvLista.TabIndex = 2;
            // 
            // ctrlCautareDupaTextClinica
            // 
            this.ctrlCautareDupaTextClinica.Location = new System.Drawing.Point(51, 59);
            this.ctrlCautareDupaTextClinica.Name = "ctrlCautareDupaTextClinica";
            this.ctrlCautareDupaTextClinica.Size = new System.Drawing.Size(267, 23);
            this.ctrlCautareDupaTextClinica.TabIndex = 0;
            // 
            // btnImprima
            // 
            this.btnImprima.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprima.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnImprima.Image = ((System.Drawing.Image)(resources.GetObject("btnImprima.Image")));
            this.btnImprima.Location = new System.Drawing.Point(704, 59);
            this.btnImprima.Name = "btnImprima";
            this.btnImprima.Size = new System.Drawing.Size(36, 23);
            this.btnImprima.TabIndex = 6;
            this.btnImprima.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Print;
            this.btnImprima.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnImprima.UseVisualStyleBackColor = true;
            // 
            // ControlListaFacturiEmise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnImprima);
            this.Controls.Add(this.ctrlCautareDupaTextClinica);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvLista);
            this.Controls.Add(this.lblClinica);
            this.Controls.Add(this.txtCautare);
            this.Controls.Add(this.ctrlPerioada);
            this.Name = "ControlListaFacturiEmise";
            this.Size = new System.Drawing.Size(743, 477);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Caramizi.ControlPerioada ctrlPerioada;
        private CCL.UI.LabelPersonalizat lblClinica;
        private CCL.UI.Caramizi.TextBoxCautare txtCautare;
        private CCL.UI.LabelPersonalizat lblTotal;
        private CCL.UI.DataGridViewPersonalizat dgvLista;
        private Caramizi.ControlCautareDupaTextClinica ctrlCautareDupaTextClinica;
        private CCL.UI.ButtonPersonalizat btnImprima;
    }
}
