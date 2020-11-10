using static CDL.iStomaLab.CDefinitiiComune;

namespace iStomaLab.Setari.Liste.Regiuni
{
    partial class ControlListaRegiuni
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlListaRegiuni));
            this.dgvListaRegiuni = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.lblTotalRegiuni = new CCL.UI.LabelPersonalizat(this.components);
            this.btnAdaugareRegiune = new CCL.UI.ButtonPersonalizat(this.components);
            this.txtCautaTara = new CCL.UI.Caramizi.TextBoxCautare();
            this.btnActiviInactivi = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblRegiuni = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaRegiuni)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListaRegiuni
            // 
            this.dgvListaRegiuni.AllowUserToAddRows = false;
            this.dgvListaRegiuni.AllowUserToDeleteRows = false;
            this.dgvListaRegiuni.AllowUserToResizeRows = false;
            this.dgvListaRegiuni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaRegiuni.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaRegiuni.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaRegiuni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaRegiuni.HideSelection = true;
            this.dgvListaRegiuni.IsInReadOnlyMode = false;
            this.dgvListaRegiuni.Location = new System.Drawing.Point(-1, 30);
            this.dgvListaRegiuni.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListaRegiuni.MultiSelect = false;
            this.dgvListaRegiuni.Name = "dgvListaRegiuni";
            this.dgvListaRegiuni.ProprietateCorespunzatoare = "";
            this.dgvListaRegiuni.RowHeadersVisible = false;
            this.dgvListaRegiuni.RowTemplate.Height = 24;
            this.dgvListaRegiuni.SeIncarca = false;
            this.dgvListaRegiuni.SelectedText = "";
            this.dgvListaRegiuni.SelectionLength = 0;
            this.dgvListaRegiuni.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaRegiuni.SelectionStart = 0;
            this.dgvListaRegiuni.Size = new System.Drawing.Size(648, 387);
            this.dgvListaRegiuni.TabIndex = 0;
            // 
            // lblTotalRegiuni
            // 
            this.lblTotalRegiuni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalRegiuni.AutoSize = true;
            this.lblTotalRegiuni.Location = new System.Drawing.Point(2, 422);
            this.lblTotalRegiuni.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalRegiuni.Name = "lblTotalRegiuni";
            this.lblTotalRegiuni.Size = new System.Drawing.Size(65, 13);
            this.lblTotalRegiuni.TabIndex = 1;
            this.lblTotalRegiuni.Text = "Total regiuni";
            this.lblTotalRegiuni.ToolTipText = null;
            this.lblTotalRegiuni.ToolTipTitle = null;
            // 
            // btnAdaugareRegiune
            // 
            this.btnAdaugareRegiune.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdaugareRegiune.Image = ((System.Drawing.Image)(resources.GetObject("btnAdaugareRegiune.Image")));
            this.btnAdaugareRegiune.Location = new System.Drawing.Point(74, 3);
            this.btnAdaugareRegiune.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdaugareRegiune.Name = "btnAdaugareRegiune";
            this.btnAdaugareRegiune.Size = new System.Drawing.Size(32, 24);
            this.btnAdaugareRegiune.TabIndex = 6;
            this.btnAdaugareRegiune.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdaugareRegiune.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdaugareRegiune.UseVisualStyleBackColor = true;
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
            this.txtCautaTara.Location = new System.Drawing.Point(489, 5);
            this.txtCautaTara.Margin = new System.Windows.Forms.Padding(2);
            this.txtCautaTara.MaxLength = 32767;
            this.txtCautaTara.Multiline = false;
            this.txtCautaTara.Name = "txtCautaTara";
            this.txtCautaTara.ProprietateCorespunzatoare = null;
            this.txtCautaTara.RaiseEventLaModificareProgramatica = false;
            this.txtCautaTara.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautaTara.Size = new System.Drawing.Size(154, 20);
            this.txtCautaTara.TabIndex = 7;
            this.txtCautaTara.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautaTara.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautaTara.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautaTara.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautaTara.UseSystemPasswordChar = false;
            // 
            // btnActiviInactivi
            // 
            this.btnActiviInactivi.ForeColor = System.Drawing.Color.Black;
            this.btnActiviInactivi.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnActiviInactivi.Image = ((System.Drawing.Image)(resources.GetObject("btnActiviInactivi.Image")));
            this.btnActiviInactivi.Location = new System.Drawing.Point(112, 4);
            this.btnActiviInactivi.Name = "btnActiviInactivi";
            this.btnActiviInactivi.Size = new System.Drawing.Size(40, 23);
            this.btnActiviInactivi.TabIndex = 8;
            this.btnActiviInactivi.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.ActiviDezactivati;
            this.btnActiviInactivi.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnActiviInactivi.UseVisualStyleBackColor = true;
            // 
            // lblRegiuni
            // 
            this.lblRegiuni.AutoSize = true;
            this.lblRegiuni.Location = new System.Drawing.Point(2, 9);
            this.lblRegiuni.Name = "lblRegiuni";
            this.lblRegiuni.Size = new System.Drawing.Size(43, 13);
            this.lblRegiuni.TabIndex = 9;
            this.lblRegiuni.Text = "Regiuni";
            // 
            // ControlListaRegiuni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblRegiuni);
            this.Controls.Add(this.btnActiviInactivi);
            this.Controls.Add(this.txtCautaTara);
            this.Controls.Add(this.btnAdaugareRegiune);
            this.Controls.Add(this.lblTotalRegiuni);
            this.Controls.Add(this.dgvListaRegiuni);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ControlListaRegiuni";
            this.Size = new System.Drawing.Size(646, 438);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaRegiuni)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.DataGridViewPersonalizat dgvListaRegiuni;
        private CCL.UI.LabelPersonalizat lblTotalRegiuni;
        private CCL.UI.ButtonPersonalizat btnAdaugareRegiune;
        private CCL.UI.Caramizi.TextBoxCautare txtCautaTara;
        private CCL.UI.ButtonPersonalizat btnActiviInactivi;
        private System.Windows.Forms.Label lblRegiuni;
    }
}
