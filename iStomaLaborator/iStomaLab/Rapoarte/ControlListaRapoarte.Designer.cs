namespace iStomaLab.Rapoarte
{
    partial class ControlListaRapoarte
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
            this.panelContainer = new CCL.UI.PanelPersonalizat(this.components);
            this.dgvListaRapoarte = new CCL.UI.DataGridViewPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaRapoarte)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContainer.Location = new System.Drawing.Point(195, -1);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(790, 585);
            this.panelContainer.TabIndex = 1;
            this.panelContainer.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // dgvListaRapoarte
            // 
            this.dgvListaRapoarte.AllowUserToAddRows = false;
            this.dgvListaRapoarte.AllowUserToDeleteRows = false;
            this.dgvListaRapoarte.AllowUserToResizeRows = false;
            this.dgvListaRapoarte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvListaRapoarte.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaRapoarte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaRapoarte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaRapoarte.HideSelection = true;
            this.dgvListaRapoarte.IsInReadOnlyMode = false;
            this.dgvListaRapoarte.Location = new System.Drawing.Point(0, 0);
            this.dgvListaRapoarte.MultiSelect = false;
            this.dgvListaRapoarte.Name = "dgvListaRapoarte";
            this.dgvListaRapoarte.ProprietateCorespunzatoare = "";
            this.dgvListaRapoarte.RowHeadersVisible = false;
            this.dgvListaRapoarte.SeIncarca = false;
            this.dgvListaRapoarte.SelectedText = "";
            this.dgvListaRapoarte.SelectionLength = 0;
            this.dgvListaRapoarte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaRapoarte.SelectionStart = 0;
            this.dgvListaRapoarte.Size = new System.Drawing.Size(196, 584);
            this.dgvListaRapoarte.TabIndex = 2;
            // 
            // ControlListaRapoarte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.dgvListaRapoarte);
            this.Name = "ControlListaRapoarte";
            this.Size = new System.Drawing.Size(985, 584);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaRapoarte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CCL.UI.PanelPersonalizat panelContainer;
        private CCL.UI.DataGridViewPersonalizat dgvListaRapoarte;
    }
}
