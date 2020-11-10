namespace iStomaLab.TablouDeBord.Clienti
{
    partial class ControlDosarClientListaPreturi
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
            this.dgvClientListaPreturi = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.lblClientTotalPreturi = new CCL.UI.LabelPersonalizat(this.components);
            this.txtCautare = new CCL.UI.Caramizi.TextBoxCautare();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientListaPreturi)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClientListaPreturi
            // 
            this.dgvClientListaPreturi.AllowUserToAddRows = false;
            this.dgvClientListaPreturi.AllowUserToDeleteRows = false;
            this.dgvClientListaPreturi.AllowUserToResizeRows = false;
            this.dgvClientListaPreturi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClientListaPreturi.BackgroundColor = System.Drawing.Color.White;
            this.dgvClientListaPreturi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvClientListaPreturi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientListaPreturi.HideSelection = true;
            this.dgvClientListaPreturi.IsInReadOnlyMode = false;
            this.dgvClientListaPreturi.Location = new System.Drawing.Point(2, 32);
            this.dgvClientListaPreturi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvClientListaPreturi.MultiSelect = false;
            this.dgvClientListaPreturi.Name = "dgvClientListaPreturi";
            this.dgvClientListaPreturi.ProprietateCorespunzatoare = "";
            this.dgvClientListaPreturi.RowHeadersVisible = false;
            this.dgvClientListaPreturi.RowTemplate.Height = 24;
            this.dgvClientListaPreturi.SeIncarca = false;
            this.dgvClientListaPreturi.SelectedText = "";
            this.dgvClientListaPreturi.SelectionLength = 0;
            this.dgvClientListaPreturi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientListaPreturi.SelectionStart = 0;
            this.dgvClientListaPreturi.Size = new System.Drawing.Size(589, 440);
            this.dgvClientListaPreturi.TabIndex = 0;
            // 
            // lblClientTotalPreturi
            // 
            this.lblClientTotalPreturi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblClientTotalPreturi.AutoSize = true;
            this.lblClientTotalPreturi.Location = new System.Drawing.Point(11, 475);
            this.lblClientTotalPreturi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClientTotalPreturi.Name = "lblClientTotalPreturi";
            this.lblClientTotalPreturi.Size = new System.Drawing.Size(31, 13);
            this.lblClientTotalPreturi.TabIndex = 1;
            this.lblClientTotalPreturi.Text = "Total";
            this.lblClientTotalPreturi.ToolTipText = null;
            this.lblClientTotalPreturi.ToolTipTitle = null;
            // 
            // txtCautare
            // 
            this.txtCautare.AcceptButton = null;
            this.txtCautare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautare.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautare.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautare.CapitalizeazaPrimaLitera = false;
            this.txtCautare.IsInReadOnlyMode = false;
            this.txtCautare.Location = new System.Drawing.Point(379, 7);
            this.txtCautare.MaxLength = 32767;
            this.txtCautare.Multiline = false;
            this.txtCautare.Name = "txtCautare";
            this.txtCautare.ProprietateCorespunzatoare = null;
            this.txtCautare.RaiseEventLaModificareProgramatica = false;
            this.txtCautare.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautare.Size = new System.Drawing.Size(212, 20);
            this.txtCautare.TabIndex = 2;
            this.txtCautare.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautare.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautare.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautare.UseSystemPasswordChar = false;
            // 
            // ControlDosarClientListaPreturi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCautare);
            this.Controls.Add(this.lblClientTotalPreturi);
            this.Controls.Add(this.dgvClientListaPreturi);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ControlDosarClientListaPreturi";
            this.Size = new System.Drawing.Size(594, 493);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientListaPreturi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.DataGridViewPersonalizat dgvClientListaPreturi;
        private CCL.UI.LabelPersonalizat lblClientTotalPreturi;
        private CCL.UI.Caramizi.TextBoxCautare txtCautare;
    }
}
