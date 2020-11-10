namespace iStomaLab.Rapoarte
{
    partial class ControlRaportClientiDatornici
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
            this.txtCautare = new CCL.UI.Caramizi.TextBoxCautare();
            this.labelPersonalizat1 = new CCL.UI.LabelPersonalizat(this.components);
            this.dgvLista = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.lblTotal = new CCL.UI.LabelPersonalizat(this.components);
            this.lblTitlu = new CCL.UI.LabelPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.SuspendLayout();
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
            this.txtCautare.Location = new System.Drawing.Point(629, 3);
            this.txtCautare.MaxLength = 32767;
            this.txtCautare.Multiline = false;
            this.txtCautare.Name = "txtCautare";
            this.txtCautare.ProprietateCorespunzatoare = null;
            this.txtCautare.RaiseEventLaModificareProgramatica = false;
            this.txtCautare.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautare.Size = new System.Drawing.Size(237, 20);
            this.txtCautare.TabIndex = 0;
            this.txtCautare.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautare.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautare.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautare.UseSystemPasswordChar = false;
            // 
            // labelPersonalizat1
            // 
            this.labelPersonalizat1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPersonalizat1.AutoSize = true;
            this.labelPersonalizat1.Location = new System.Drawing.Point(588, 7);
            this.labelPersonalizat1.Name = "labelPersonalizat1";
            this.labelPersonalizat1.Size = new System.Drawing.Size(35, 13);
            this.labelPersonalizat1.TabIndex = 1;
            this.labelPersonalizat1.Text = "Cauta";
            this.labelPersonalizat1.ToolTipText = null;
            this.labelPersonalizat1.ToolTipTitle = null;
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
            this.dgvLista.Location = new System.Drawing.Point(0, 29);
            this.dgvLista.MultiSelect = false;
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ProprietateCorespunzatoare = "";
            this.dgvLista.RowHeadersVisible = false;
            this.dgvLista.SeIncarca = false;
            this.dgvLista.SelectedText = "";
            this.dgvLista.SelectionLength = 0;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLista.SelectionStart = 0;
            this.dgvLista.Size = new System.Drawing.Size(869, 429);
            this.dgvLista.TabIndex = 2;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(4, 465);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(31, 13);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Total";
            this.lblTotal.ToolTipText = null;
            this.lblTotal.ToolTipTitle = null;
            // 
            // lblTitlu
            // 
            this.lblTitlu.AutoSize = true;
            this.lblTitlu.Location = new System.Drawing.Point(4, 7);
            this.lblTitlu.Name = "lblTitlu";
            this.lblTitlu.Size = new System.Drawing.Size(81, 13);
            this.lblTitlu.TabIndex = 4;
            this.lblTitlu.Text = "Clienti cu datorii";
            this.lblTitlu.ToolTipText = null;
            this.lblTitlu.ToolTipTitle = null;
            // 
            // ControlRaportClientiDatornici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTitlu);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvLista);
            this.Controls.Add(this.labelPersonalizat1);
            this.Controls.Add(this.txtCautare);
            this.Name = "ControlRaportClientiDatornici";
            this.Size = new System.Drawing.Size(869, 487);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.Caramizi.TextBoxCautare txtCautare;
        private CCL.UI.LabelPersonalizat labelPersonalizat1;
        private CCL.UI.DataGridViewPersonalizat dgvLista;
        private CCL.UI.LabelPersonalizat lblTotal;
        private CCL.UI.LabelPersonalizat lblTitlu;
    }
}
