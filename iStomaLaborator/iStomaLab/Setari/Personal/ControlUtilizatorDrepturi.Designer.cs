namespace iStomaLab.Setari.Personal
{
    partial class ControlUtilizatorDrepturi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlUtilizatorDrepturi));
            this.btnInainte = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnInapoi = new CCL.UI.ButtonPersonalizat(this.components);
            this.dgvListaSelectata = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.dgvListaOptiuniDrepturi = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.txtCautareListaSelectata = new CCL.UI.Caramizi.TextBoxCautare();
            this.txtCautaOptiuniDrepturi = new CCL.UI.Caramizi.TextBoxCautare();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaSelectata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaOptiuniDrepturi)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInainte
            // 
            this.btnInainte.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnInainte.Image = ((System.Drawing.Image)(resources.GetObject("btnInainte.Image")));
            this.btnInainte.Location = new System.Drawing.Point(412, 211);
            this.btnInainte.Name = "btnInainte";
            this.btnInainte.Size = new System.Drawing.Size(41, 23);
            this.btnInainte.TabIndex = 16;
            this.btnInainte.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Dreapta;
            this.btnInainte.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnInainte.UseVisualStyleBackColor = true;
            // 
            // btnInapoi
            // 
            this.btnInapoi.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnInapoi.Image = ((System.Drawing.Image)(resources.GetObject("btnInapoi.Image")));
            this.btnInapoi.Location = new System.Drawing.Point(412, 240);
            this.btnInapoi.Name = "btnInapoi";
            this.btnInapoi.Size = new System.Drawing.Size(41, 23);
            this.btnInapoi.TabIndex = 15;
            this.btnInapoi.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Stanga;
            this.btnInapoi.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnInapoi.UseVisualStyleBackColor = true;
            // 
            // dgvListaSelectata
            // 
            this.dgvListaSelectata.AllowUserToAddRows = false;
            this.dgvListaSelectata.AllowUserToDeleteRows = false;
            this.dgvListaSelectata.AllowUserToResizeRows = false;
            this.dgvListaSelectata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaSelectata.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaSelectata.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaSelectata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaSelectata.HideSelection = true;
            this.dgvListaSelectata.IsInReadOnlyMode = false;
            this.dgvListaSelectata.Location = new System.Drawing.Point(459, 29);
            this.dgvListaSelectata.MultiSelect = false;
            this.dgvListaSelectata.Name = "dgvListaSelectata";
            this.dgvListaSelectata.ProprietateCorespunzatoare = "";
            this.dgvListaSelectata.RowHeadersVisible = false;
            this.dgvListaSelectata.SeIncarca = false;
            this.dgvListaSelectata.SelectedText = "";
            this.dgvListaSelectata.SelectionLength = 0;
            this.dgvListaSelectata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaSelectata.SelectionStart = 0;
            this.dgvListaSelectata.Size = new System.Drawing.Size(413, 474);
            this.dgvListaSelectata.TabIndex = 6;
            // 
            // dgvListaOptiuniDrepturi
            // 
            this.dgvListaOptiuniDrepturi.AllowUserToAddRows = false;
            this.dgvListaOptiuniDrepturi.AllowUserToDeleteRows = false;
            this.dgvListaOptiuniDrepturi.AllowUserToResizeRows = false;
            this.dgvListaOptiuniDrepturi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvListaOptiuniDrepturi.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaOptiuniDrepturi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaOptiuniDrepturi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaOptiuniDrepturi.HideSelection = true;
            this.dgvListaOptiuniDrepturi.IsInReadOnlyMode = false;
            this.dgvListaOptiuniDrepturi.Location = new System.Drawing.Point(0, 29);
            this.dgvListaOptiuniDrepturi.MultiSelect = false;
            this.dgvListaOptiuniDrepturi.Name = "dgvListaOptiuniDrepturi";
            this.dgvListaOptiuniDrepturi.ProprietateCorespunzatoare = "";
            this.dgvListaOptiuniDrepturi.RowHeadersVisible = false;
            this.dgvListaOptiuniDrepturi.SeIncarca = false;
            this.dgvListaOptiuniDrepturi.SelectedText = "";
            this.dgvListaOptiuniDrepturi.SelectionLength = 0;
            this.dgvListaOptiuniDrepturi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaOptiuniDrepturi.SelectionStart = 0;
            this.dgvListaOptiuniDrepturi.Size = new System.Drawing.Size(406, 474);
            this.dgvListaOptiuniDrepturi.TabIndex = 5;
            // 
            // txtCautareListaSelectata
            // 
            this.txtCautareListaSelectata.AcceptButton = null;
            this.txtCautareListaSelectata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautareListaSelectata.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautareListaSelectata.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautareListaSelectata.CapitalizeazaPrimaLitera = false;
            this.txtCautareListaSelectata.IsInReadOnlyMode = false;
            this.txtCautareListaSelectata.Location = new System.Drawing.Point(605, 3);
            this.txtCautareListaSelectata.MaxLength = 32767;
            this.txtCautareListaSelectata.Multiline = false;
            this.txtCautareListaSelectata.Name = "txtCautareListaSelectata";
            this.txtCautareListaSelectata.ProprietateCorespunzatoare = null;
            this.txtCautareListaSelectata.RaiseEventLaModificareProgramatica = false;
            this.txtCautareListaSelectata.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautareListaSelectata.Size = new System.Drawing.Size(267, 20);
            this.txtCautareListaSelectata.TabIndex = 17;
            this.txtCautareListaSelectata.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautareListaSelectata.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautareListaSelectata.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautareListaSelectata.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautareListaSelectata.UseSystemPasswordChar = false;
            // 
            // txtCautaOptiuniDrepturi
            // 
            this.txtCautaOptiuniDrepturi.AcceptButton = null;
            this.txtCautaOptiuniDrepturi.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautaOptiuniDrepturi.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautaOptiuniDrepturi.CapitalizeazaPrimaLitera = false;
            this.txtCautaOptiuniDrepturi.IsInReadOnlyMode = false;
            this.txtCautaOptiuniDrepturi.Location = new System.Drawing.Point(139, 3);
            this.txtCautaOptiuniDrepturi.MaxLength = 32767;
            this.txtCautaOptiuniDrepturi.Multiline = false;
            this.txtCautaOptiuniDrepturi.Name = "txtCautaOptiuniDrepturi";
            this.txtCautaOptiuniDrepturi.ProprietateCorespunzatoare = null;
            this.txtCautaOptiuniDrepturi.RaiseEventLaModificareProgramatica = false;
            this.txtCautaOptiuniDrepturi.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautaOptiuniDrepturi.Size = new System.Drawing.Size(267, 20);
            this.txtCautaOptiuniDrepturi.TabIndex = 18;
            this.txtCautaOptiuniDrepturi.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautaOptiuniDrepturi.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautaOptiuniDrepturi.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautaOptiuniDrepturi.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautaOptiuniDrepturi.UseSystemPasswordChar = false;
            // 
            // ControlUtilizatorDrepturi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCautaOptiuniDrepturi);
            this.Controls.Add(this.txtCautareListaSelectata);
            this.Controls.Add(this.btnInainte);
            this.Controls.Add(this.btnInapoi);
            this.Controls.Add(this.dgvListaSelectata);
            this.Controls.Add(this.dgvListaOptiuniDrepturi);
            this.Name = "ControlUtilizatorDrepturi";
            this.Size = new System.Drawing.Size(872, 503);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaSelectata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaOptiuniDrepturi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CCL.UI.DataGridViewPersonalizat dgvListaOptiuniDrepturi;
        private CCL.UI.DataGridViewPersonalizat dgvListaSelectata;
        private CCL.UI.ButtonPersonalizat btnInainte;
        private CCL.UI.ButtonPersonalizat btnInapoi;
        private CCL.UI.Caramizi.TextBoxCautare txtCautareListaSelectata;
        private CCL.UI.Caramizi.TextBoxCautare txtCautaOptiuniDrepturi;
    }
}
