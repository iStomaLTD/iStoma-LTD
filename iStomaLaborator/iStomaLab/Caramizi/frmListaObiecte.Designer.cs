namespace iStomaLab.Caramizi
{
    partial class frmListaObiecte<T>
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaObiecte<T>));
            this.dgvListaObiecte = new CCL.UI.DataGridViewPersonalizat(this.components);
            this.btnValidare = new CCL.UI.ButtonPersonalizat(this.components);
            this.txtCautare = new CCL.UI.Caramizi.TextBoxCautare();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaObiecte)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(324, 19);
            this.lblTitluEcran.TabIndex = 3;
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(323, 0);
            this.btnInchidereEcran.TabIndex = 4;
            // 
            // dgvListaObiecte
            // 
            this.dgvListaObiecte.AllowUserToAddRows = false;
            this.dgvListaObiecte.AllowUserToDeleteRows = false;
            this.dgvListaObiecte.AllowUserToResizeColumns = false;
            this.dgvListaObiecte.AllowUserToResizeRows = false;
            this.dgvListaObiecte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaObiecte.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvListaObiecte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListaObiecte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaObiecte.HideSelection = true;
            this.dgvListaObiecte.IsInReadOnlyMode = false;
            this.dgvListaObiecte.Location = new System.Drawing.Point(1, 45);
            this.dgvListaObiecte.MultiSelect = false;
            this.dgvListaObiecte.Name = "dgvListaObiecte";
            this.dgvListaObiecte.ProprietateCorespunzatoare = "";
            this.dgvListaObiecte.RowHeadersVisible = false;
            this.dgvListaObiecte.SeIncarca = false;
            this.dgvListaObiecte.SelectedText = "";
            this.dgvListaObiecte.SelectionLength = 0;
            this.dgvListaObiecte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaObiecte.SelectionStart = 0;
            this.dgvListaObiecte.Size = new System.Drawing.Size(344, 327);
            this.dgvListaObiecte.TabIndex = 1;
            this.dgvListaObiecte.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvListaObiecte_CellMouseClick);
            this.dgvListaObiecte.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvListaObiecte_CurrentCellDirtyStateChanged);
            // 
            // btnValidare
            // 
            this.btnValidare.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnValidare.Location = new System.Drawing.Point(112, 374);
            this.btnValidare.Name = "btnValidare";
            this.btnValidare.Size = new System.Drawing.Size(122, 23);
            this.btnValidare.TabIndex = 2;
            this.btnValidare.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Validare;
            this.btnValidare.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnValidare.UseVisualStyleBackColor = true;
            this.btnValidare.Click += new System.EventHandler(this.btnValidare_Click);
            // 
            // txtCautare
            // 
            this.txtCautare.AcceptButton = null;
            this.txtCautare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCautare.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtCautare.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtCautare.BackColor = System.Drawing.SystemColors.Control;
            this.txtCautare.IsInReadOnlyMode = false;
            this.txtCautare.Location = new System.Drawing.Point(3, 22);
            this.txtCautare.MaxLength = 32767;
            this.txtCautare.Multiline = false;
            this.txtCautare.Name = "txtCautare";
            this.txtCautare.ProprietateCorespunzatoare = null;
            this.txtCautare.RaiseEventLaModificareProgramatica = false;
            this.txtCautare.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCautare.Size = new System.Drawing.Size(341, 20);
            this.txtCautare.TabIndex = 0;
            this.txtCautare.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtCautare.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCautare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtCautare.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCautare.UseSystemPasswordChar = false;
            this.txtCautare.CerereUpdate += new CCL.UI.CEvenimente.ZonaModificata(this.txtCautare_CerereUpdate);
            // 
            // frmListaObiecte
            // 
            this.AcceptButton = this.btnValidare;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(346, 399);
            this.Controls.Add(this.txtCautare);
            this.Controls.Add(this.btnValidare);
            this.Controls.Add(this.dgvListaObiecte);
            this.Name = "frmListaObiecte";
            this.Load += new System.EventHandler(this.frmListaObiecte_Load);
            this.Controls.SetChildIndex(this.dgvListaObiecte, 0);
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.btnValidare, 0);
            this.Controls.SetChildIndex(this.txtCautare, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaObiecte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.DataGridViewPersonalizat dgvListaObiecte;
        private CCL.UI.ButtonPersonalizat btnValidare;
        private CCL.UI.Caramizi.TextBoxCautare txtCautare;
    }
}