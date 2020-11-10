namespace iStomaLab.Setari.Liste.Tari
{
    partial class ControlListaTari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlListaTari));
            this.lblTara = new CCL.UI.LabelPersonalizat(this.components);
            this.txtCautaTara = new CCL.UI.Caramizi.TextBoxCautare();
            this.dgvListaTari = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.btnAdaugaTara = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblTotalTari = new CCL.UI.LabelPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaTari)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTara
            // 
            this.lblTara.AutoSize = true;
            this.lblTara.Location = new System.Drawing.Point(2, 7);
            this.lblTara.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTara.Name = "lblTara";
            this.lblTara.Size = new System.Drawing.Size(29, 13);
            this.lblTara.TabIndex = 0;
            this.lblTara.Text = "Tara";
            this.lblTara.ToolTipText = null;
            this.lblTara.ToolTipTitle = null;
            // 
            // txtCautaTara
            // 
            this.txtCautaTara.AcceptButton = null;
            this.txtCautaTara.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautaTara.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautaTara.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautaTara.BackColor = System.Drawing.Color.White;
            this.txtCautaTara.CapitalizeazaPrimaLitera = false;
            this.txtCautaTara.IsInReadOnlyMode = false;
            this.txtCautaTara.Location = new System.Drawing.Point(285, 3);
            this.txtCautaTara.Margin = new System.Windows.Forms.Padding(2);
            this.txtCautaTara.MaxLength = 32767;
            this.txtCautaTara.Multiline = false;
            this.txtCautaTara.Name = "txtCautaTara";
            this.txtCautaTara.ProprietateCorespunzatoare = null;
            this.txtCautaTara.RaiseEventLaModificareProgramatica = false;
            this.txtCautaTara.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautaTara.Size = new System.Drawing.Size(249, 20);
            this.txtCautaTara.TabIndex = 1;
            this.txtCautaTara.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautaTara.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautaTara.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautaTara.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautaTara.UseSystemPasswordChar = false;
            // 
            // dgvListaTari
            // 
            this.dgvListaTari.AllowUserToAddRows = false;
            this.dgvListaTari.AllowUserToDeleteRows = false;
            this.dgvListaTari.AllowUserToResizeRows = false;
            this.dgvListaTari.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaTari.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaTari.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaTari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaTari.HideSelection = true;
            this.dgvListaTari.IsInReadOnlyMode = false;
            this.dgvListaTari.Location = new System.Drawing.Point(0, 27);
            this.dgvListaTari.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListaTari.MultiSelect = false;
            this.dgvListaTari.Name = "dgvListaTari";
            this.dgvListaTari.ProprietateCorespunzatoare = "";
            this.dgvListaTari.RowHeadersVisible = false;
            this.dgvListaTari.RowTemplate.Height = 24;
            this.dgvListaTari.SeIncarca = false;
            this.dgvListaTari.SelectedText = "";
            this.dgvListaTari.SelectionLength = 0;
            this.dgvListaTari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaTari.SelectionStart = 0;
            this.dgvListaTari.Size = new System.Drawing.Size(536, 405);
            this.dgvListaTari.TabIndex = 2;
            // 
            // btnAdaugaTara
            // 
            this.btnAdaugaTara.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdaugaTara.Image = ((System.Drawing.Image)(resources.GetObject("btnAdaugaTara.Image")));
            this.btnAdaugaTara.Location = new System.Drawing.Point(42, 4);
            this.btnAdaugaTara.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdaugaTara.Name = "btnAdaugaTara";
            this.btnAdaugaTara.Size = new System.Drawing.Size(37, 19);
            this.btnAdaugaTara.TabIndex = 3;
            this.btnAdaugaTara.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdaugaTara.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdaugaTara.UseVisualStyleBackColor = true;
            // 
            // lblTotalTari
            // 
            this.lblTotalTari.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalTari.AutoSize = true;
            this.lblTotalTari.Location = new System.Drawing.Point(2, 437);
            this.lblTotalTari.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalTari.Name = "lblTotalTari";
            this.lblTotalTari.Size = new System.Drawing.Size(31, 13);
            this.lblTotalTari.TabIndex = 4;
            this.lblTotalTari.Text = "Total";
            this.lblTotalTari.ToolTipText = null;
            this.lblTotalTari.ToolTipTitle = null;
            // 
            // ControlListaTari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTotalTari);
            this.Controls.Add(this.btnAdaugaTara);
            this.Controls.Add(this.dgvListaTari);
            this.Controls.Add(this.txtCautaTara);
            this.Controls.Add(this.lblTara);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ControlListaTari";
            this.Size = new System.Drawing.Size(536, 453);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaTari)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.LabelPersonalizat lblTara;
        private CCL.UI.Caramizi.TextBoxCautare txtCautaTara;
        private CCL.UI.DataGridViewPersonalizat dgvListaTari;
        private CCL.UI.ButtonPersonalizat btnAdaugaTara;
        private CCL.UI.LabelPersonalizat lblTotalTari;
    }
}
