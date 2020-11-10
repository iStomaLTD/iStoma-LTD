namespace iStomaLab.TablouDeBord
{
    partial class FormSchimbareEtapa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSchimbareEtapa));
            this.lblEtapa = new CCL.UI.LabelPersonalizat(this.components);
            this.lgfEtapa = new CCL.UI.Caramizi.LabelGumaFind();
            this.lgfTehnician = new CCL.UI.Caramizi.LabelGumaFind();
            this.btnAfiseazaDetalii = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnGuma = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblText = new CCL.UI.LabelPersonalizat(this.components);
            this.btnCautare = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblTehnician = new CCL.UI.LabelPersonalizat(this.components);
            this.lblTermen = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlDataTermen = new CCL.UI.Caramizi.ControlDataOraGuma();
            this.ctrlValidareAnulare = new CCL.UI.Caramizi.controlValidareAnulare();
            this.lblStare = new CCL.UI.LabelPersonalizat(this.components);
            this.cboStare = new CCL.UI.ComboBoxPersonalizat(this.components);
            this.chkRefacere = new CCL.UI.CheckBoxPersonalizat(this.components);
            this.lgfTehnician.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(355, 19);
            this.lblTitluEcran.TabIndex = 8;
            this.lblTitluEcran.Text = "FormSchimbareEtapa";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(354, 0);
            this.btnInchidereEcran.TabIndex = 9;
            // 
            // lblEtapa
            // 
            this.lblEtapa.AutoSize = true;
            this.lblEtapa.Location = new System.Drawing.Point(16, 36);
            this.lblEtapa.Name = "lblEtapa";
            this.lblEtapa.Size = new System.Drawing.Size(35, 13);
            this.lblEtapa.TabIndex = 4;
            this.lblEtapa.Text = "Etapa";
            this.lblEtapa.ToolTipText = null;
            this.lblEtapa.ToolTipTitle = null;
            // 
            // lgfEtapa
            // 
            this.lgfEtapa.AfiseazaButonCautare = true;
            this.lgfEtapa.AfiseazaButonDetalii = false;
            this.lgfEtapa.AfiseazaButonGuma = true;
            this.lgfEtapa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lgfEtapa.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.lgfEtapa.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.lgfEtapa.BackColor = System.Drawing.Color.White;
            this.lgfEtapa.FolosesteToString = false;
            this.lgfEtapa.IsInReadOnlyMode = false;
            this.lgfEtapa.Location = new System.Drawing.Point(73, 32);
            this.lgfEtapa.Name = "lgfEtapa";
            this.lgfEtapa.ObiectAfisajCorespunzator = null;
            this.lgfEtapa.ObiectCorespunzator = null;
            this.lgfEtapa.ProprietateCorespunzatoare = null;
            this.lgfEtapa.Size = new System.Drawing.Size(282, 20);
            this.lgfEtapa.TabIndex = 0;
            this.lgfEtapa.Text = "labelGumaFind1";
            this.lgfEtapa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lgfEtapa.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.lgfEtapa.ToolTipText = null;
            this.lgfEtapa.ToolTipTitle = null;
            // 
            // lgfTehnician
            // 
            this.lgfTehnician.AfiseazaButonCautare = true;
            this.lgfTehnician.AfiseazaButonDetalii = false;
            this.lgfTehnician.AfiseazaButonGuma = true;
            this.lgfTehnician.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lgfTehnician.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.lgfTehnician.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.lgfTehnician.BackColor = System.Drawing.Color.White;
            this.lgfTehnician.Controls.Add(this.btnAfiseazaDetalii);
            this.lgfTehnician.Controls.Add(this.btnGuma);
            this.lgfTehnician.Controls.Add(this.lblText);
            this.lgfTehnician.Controls.Add(this.btnCautare);
            this.lgfTehnician.FolosesteToString = false;
            this.lgfTehnician.IsInReadOnlyMode = false;
            this.lgfTehnician.Location = new System.Drawing.Point(73, 67);
            this.lgfTehnician.Name = "lgfTehnician";
            this.lgfTehnician.ObiectAfisajCorespunzator = null;
            this.lgfTehnician.ObiectCorespunzator = null;
            this.lgfTehnician.ProprietateCorespunzatoare = null;
            this.lgfTehnician.Size = new System.Drawing.Size(282, 20);
            this.lgfTehnician.TabIndex = 5;
            this.lgfTehnician.Text = "labelGumaFind2";
            this.lgfTehnician.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lgfTehnician.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.lgfTehnician.ToolTipText = null;
            this.lgfTehnician.ToolTipTitle = null;
            // 
            // btnAfiseazaDetalii
            // 
            this.btnAfiseazaDetalii.BackColor = System.Drawing.SystemColors.Control;
            this.btnAfiseazaDetalii.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAfiseazaDetalii.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAfiseazaDetalii.Image = ((System.Drawing.Image)(resources.GetObject("btnAfiseazaDetalii.Image")));
            this.btnAfiseazaDetalii.Location = new System.Drawing.Point(28, 0);
            this.btnAfiseazaDetalii.Name = "btnAfiseazaDetalii";
            this.btnAfiseazaDetalii.Size = new System.Drawing.Size(23, 19);
            this.btnAfiseazaDetalii.TabIndex = 2;
            this.btnAfiseazaDetalii.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.DetaliiPopUp;
            this.btnAfiseazaDetalii.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnAfiseazaDetalii.UseVisualStyleBackColor = true;
            this.btnAfiseazaDetalii.Visible = false;
            // 
            // btnGuma
            // 
            this.btnGuma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuma.BackColor = System.Drawing.SystemColors.Control;
            this.btnGuma.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGuma.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnGuma.Image = ((System.Drawing.Image)(resources.GetObject("btnGuma.Image")));
            this.btnGuma.Location = new System.Drawing.Point(348, 0);
            this.btnGuma.Name = "btnGuma";
            this.btnGuma.Size = new System.Drawing.Size(23, 19);
            this.btnGuma.TabIndex = 3;
            this.btnGuma.TabStop = false;
            this.btnGuma.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Guma;
            this.btnGuma.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnGuma.UseVisualStyleBackColor = true;
            // 
            // lblText
            // 
            this.lblText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblText.Location = new System.Drawing.Point(25, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(321, 19);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "labelGumaFind1";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblText.ToolTipText = null;
            this.lblText.ToolTipTitle = null;
            // 
            // btnCautare
            // 
            this.btnCautare.BackColor = System.Drawing.SystemColors.Control;
            this.btnCautare.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCautare.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnCautare.Image = null;
            this.btnCautare.Location = new System.Drawing.Point(0, 0);
            this.btnCautare.Margin = new System.Windows.Forms.Padding(0);
            this.btnCautare.Name = "btnCautare";
            this.btnCautare.Size = new System.Drawing.Size(23, 19);
            this.btnCautare.TabIndex = 1;
            this.btnCautare.Text = "...";
            this.btnCautare.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnCautare.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnCautare.UseVisualStyleBackColor = true;
            // 
            // lblTehnician
            // 
            this.lblTehnician.AutoSize = true;
            this.lblTehnician.Location = new System.Drawing.Point(16, 71);
            this.lblTehnician.Name = "lblTehnician";
            this.lblTehnician.Size = new System.Drawing.Size(54, 13);
            this.lblTehnician.TabIndex = 5;
            this.lblTehnician.Text = "Tehnician";
            this.lblTehnician.ToolTipText = null;
            this.lblTehnician.ToolTipTitle = null;
            // 
            // lblTermen
            // 
            this.lblTermen.AutoSize = true;
            this.lblTermen.Location = new System.Drawing.Point(16, 104);
            this.lblTermen.Name = "lblTermen";
            this.lblTermen.Size = new System.Drawing.Size(43, 13);
            this.lblTermen.TabIndex = 6;
            this.lblTermen.Text = "Termen";
            this.lblTermen.ToolTipText = null;
            this.lblTermen.ToolTipTitle = null;
            // 
            // ctrlDataTermen
            // 
            this.ctrlDataTermen.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ctrlDataTermen.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ctrlDataTermen.BackColor = System.Drawing.Color.White;
            this.ctrlDataTermen.DataAfisata = new System.DateTime(((long)(0)));
            this.ctrlDataTermen.IsInReadOnlyMode = false;
            this.ctrlDataTermen.Location = new System.Drawing.Point(73, 99);
            this.ctrlDataTermen.Name = "ctrlDataTermen";
            this.ctrlDataTermen.PragInferior = new System.DateTime(((long)(0)));
            this.ctrlDataTermen.PragSuperior = new System.DateTime(((long)(0)));
            this.ctrlDataTermen.ProprietateCorespunzatoare = null;
            this.ctrlDataTermen.Size = new System.Drawing.Size(197, 23);
            this.ctrlDataTermen.TabIndex = 1;
            this.ctrlDataTermen.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.ctrlDataTermen.TipDeschidereCalendar = CCL.UI.CEnumerariComune.EnumTipDeschidere.StangaSus;
            // 
            // ctrlValidareAnulare
            // 
            this.ctrlValidareAnulare.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrlValidareAnulare.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulare.Location = new System.Drawing.Point(109, 164);
            this.ctrlValidareAnulare.Name = "ctrlValidareAnulare";
            this.ctrlValidareAnulare.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulare.TabIndex = 10;
            // 
            // lblStare
            // 
            this.lblStare.AutoSize = true;
            this.lblStare.Location = new System.Drawing.Point(19, 135);
            this.lblStare.Name = "lblStare";
            this.lblStare.Size = new System.Drawing.Size(32, 13);
            this.lblStare.TabIndex = 7;
            this.lblStare.Text = "Stare";
            this.lblStare.ToolTipText = null;
            this.lblStare.ToolTipTitle = null;
            // 
            // cboStare
            // 
            this.cboStare.AutoCompletePersonalizat = false;
            this.cboStare.FormattingEnabled = true;
            this.cboStare.HideSelection = true;
            this.cboStare.IsInReadOnlyMode = false;
            this.cboStare.Location = new System.Drawing.Point(73, 131);
            this.cboStare.Name = "cboStare";
            this.cboStare.ProprietateCorespunzatoare = null;
            this.cboStare.Size = new System.Drawing.Size(197, 21);
            this.cboStare.TabIndex = 2;
            this.cboStare.TipulListei = CCL.UI.ComboBoxPersonalizat.EnumTipLista.Nespecificat;
            // 
            // chkRefacere
            // 
            this.chkRefacere.AutoSize = true;
            this.chkRefacere.IsInReadOnlyMode = false;
            this.chkRefacere.Location = new System.Drawing.Point(285, 134);
            this.chkRefacere.Name = "chkRefacere";
            this.chkRefacere.ProprietateCorespunzatoare = null;
            this.chkRefacere.Size = new System.Drawing.Size(70, 17);
            this.chkRefacere.TabIndex = 3;
            this.chkRefacere.Text = "Refacere";
            this.chkRefacere.UseVisualStyleBackColor = true;
            // 
            // FormSchimbareEtapa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 196);
            this.Controls.Add(this.chkRefacere);
            this.Controls.Add(this.cboStare);
            this.Controls.Add(this.lblStare);
            this.Controls.Add(this.ctrlValidareAnulare);
            this.Controls.Add(this.ctrlDataTermen);
            this.Controls.Add(this.lblTermen);
            this.Controls.Add(this.lgfTehnician);
            this.Controls.Add(this.lblTehnician);
            this.Controls.Add(this.lgfEtapa);
            this.Controls.Add(this.lblEtapa);
            this.Name = "FormSchimbareEtapa";
            this.Text = "FormSchimbareEtapa";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.lblEtapa, 0);
            this.Controls.SetChildIndex(this.lgfEtapa, 0);
            this.Controls.SetChildIndex(this.lblTehnician, 0);
            this.Controls.SetChildIndex(this.lgfTehnician, 0);
            this.Controls.SetChildIndex(this.lblTermen, 0);
            this.Controls.SetChildIndex(this.ctrlDataTermen, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulare, 0);
            this.Controls.SetChildIndex(this.lblStare, 0);
            this.Controls.SetChildIndex(this.cboStare, 0);
            this.Controls.SetChildIndex(this.chkRefacere, 0);
            this.lgfTehnician.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.LabelPersonalizat lblEtapa;
        private CCL.UI.Caramizi.LabelGumaFind lgfEtapa;
        private CCL.UI.Caramizi.LabelGumaFind lgfTehnician;
        private CCL.UI.ButtonPersonalizat btnAfiseazaDetalii;
        private CCL.UI.ButtonPersonalizat btnGuma;
        private CCL.UI.LabelPersonalizat lblText;
        private CCL.UI.ButtonPersonalizat btnCautare;
        private CCL.UI.LabelPersonalizat lblTehnician;
        private CCL.UI.LabelPersonalizat lblTermen;
        private CCL.UI.Caramizi.ControlDataOraGuma ctrlDataTermen;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulare;
        private CCL.UI.LabelPersonalizat lblStare;
        private CCL.UI.ComboBoxPersonalizat cboStare;
        private CCL.UI.CheckBoxPersonalizat chkRefacere;
    }
}