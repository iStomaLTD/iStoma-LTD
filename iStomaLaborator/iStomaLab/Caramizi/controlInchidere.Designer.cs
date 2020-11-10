namespace iStomaLab.Caramizi
{
    partial class controlInchidere
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(controlInchidere));
            this.txtMotivInchidere = new CCL.UI.Caramizi.TextBoxGuma();
            this.lblMotivulInchiderii = new CCL.UI.LabelPersonalizat(this.components);
            this.chkDezactiveaza = new CCL.UI.CheckBoxPersonalizat(this.components);
            this.lblDataInchidere = new CCL.UI.LabelPersonalizat(this.components);
            this.btnDeschideListaMotiveInchidere = new CCL.UI.ButtonPersonalizat(this.components);
            this.flpOptiuni = new CCL.UI.FlowLayoutPanelPersonalizat(this.components);
            this.btnSterge = new CCL.UI.ButtonPersonalizat(this.components);
            this.flpOptiuni.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMotivInchidere
            // 
            this.txtMotivInchidere.AcceptButton = null;
            this.txtMotivInchidere.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMotivInchidere.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtMotivInchidere.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtMotivInchidere.BackColor = System.Drawing.Color.White;
            this.txtMotivInchidere.IsInReadOnlyMode = false;
            this.txtMotivInchidere.Location = new System.Drawing.Point(1, 46);
            this.txtMotivInchidere.MaxLength = 500;
            this.txtMotivInchidere.Multiline = true;
            this.txtMotivInchidere.Name = "txtMotivInchidere";
            this.txtMotivInchidere.ProprietateCorespunzatoare = "MotivInchidere";
            this.txtMotivInchidere.RaiseEventLaModificareProgramatica = false;
            this.txtMotivInchidere.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMotivInchidere.Size = new System.Drawing.Size(199, 45);
            this.txtMotivInchidere.TabIndex = 7;
            this.txtMotivInchidere.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtMotivInchidere.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtMotivInchidere.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtMotivInchidere.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtMotivInchidere.UseSystemPasswordChar = false;
            this.txtMotivInchidere.UtilizeazaButonGuma = false;
            this.txtMotivInchidere.CerereUpdate += new CCL.UI.CEvenimente.ZonaModificata(this.txtMotivInchidere_ZonaModificata);
            // 
            // lblMotivulInchiderii
            // 
            this.lblMotivulInchiderii.AutoSize = true;
            this.lblMotivulInchiderii.Location = new System.Drawing.Point(2, 28);
            this.lblMotivulInchiderii.Name = "lblMotivulInchiderii";
            this.lblMotivulInchiderii.Size = new System.Drawing.Size(87, 13);
            this.lblMotivulInchiderii.TabIndex = 6;
            this.lblMotivulInchiderii.Text = "Motivul închiderii";
            this.lblMotivulInchiderii.ToolTipText = null;
            this.lblMotivulInchiderii.ToolTipTitle = null;
            // 
            // chkDezactiveaza
            // 
            this.chkDezactiveaza.AutoSize = true;
            this.chkDezactiveaza.IsInReadOnlyMode = false;
            this.chkDezactiveaza.Location = new System.Drawing.Point(3, 3);
            this.chkDezactiveaza.Name = "chkDezactiveaza";
            this.chkDezactiveaza.ProprietateCorespunzatoare = null;
            this.chkDezactiveaza.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDezactiveaza.Size = new System.Drawing.Size(70, 17);
            this.chkDezactiveaza.TabIndex = 5;
            this.chkDezactiveaza.Text = "Închidere";
            this.chkDezactiveaza.UseVisualStyleBackColor = true;
            this.chkDezactiveaza.CheckedChanged += new System.EventHandler(this.chkDezactiveaza_CheckedChanged);
            // 
            // lblDataInchidere
            // 
            this.lblDataInchidere.AutoSize = true;
            this.lblDataInchidere.Location = new System.Drawing.Point(79, 3);
            this.lblDataInchidere.Margin = new System.Windows.Forms.Padding(3);
            this.lblDataInchidere.MinimumSize = new System.Drawing.Size(0, 17);
            this.lblDataInchidere.Name = "lblDataInchidere";
            this.lblDataInchidere.Size = new System.Drawing.Size(34, 17);
            this.lblDataInchidere.TabIndex = 4;
            this.lblDataInchidere.Text = "Acum";
            this.lblDataInchidere.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDataInchidere.ToolTipText = null;
            this.lblDataInchidere.ToolTipTitle = null;
            // 
            // btnDeschideListaMotiveInchidere
            // 
            this.btnDeschideListaMotiveInchidere.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeschideListaMotiveInchidere.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeschideListaMotiveInchidere.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeschideListaMotiveInchidere.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnDeschideListaMotiveInchidere.Image = null;
            this.btnDeschideListaMotiveInchidere.Location = new System.Drawing.Point(176, 22);
            this.btnDeschideListaMotiveInchidere.Name = "btnDeschideListaMotiveInchidere";
            this.btnDeschideListaMotiveInchidere.Size = new System.Drawing.Size(24, 21);
            this.btnDeschideListaMotiveInchidere.TabIndex = 8;
            this.btnDeschideListaMotiveInchidere.Text = "...";
            this.btnDeschideListaMotiveInchidere.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Cautare;
            this.btnDeschideListaMotiveInchidere.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnDeschideListaMotiveInchidere.UseVisualStyleBackColor = false;
            this.btnDeschideListaMotiveInchidere.Click += new System.EventHandler(this.btnDeschideListaMotiveInchidere_Click);
            // 
            // flpOptiuni
            // 
            this.flpOptiuni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpOptiuni.Controls.Add(this.chkDezactiveaza);
            this.flpOptiuni.Controls.Add(this.lblDataInchidere);
            this.flpOptiuni.Location = new System.Drawing.Point(-1, -1);
            this.flpOptiuni.Name = "flpOptiuni";
            this.flpOptiuni.Size = new System.Drawing.Size(205, 22);
            this.flpOptiuni.TabIndex = 10;
            // 
            // btnSterge
            // 
            this.btnSterge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSterge.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnSterge.Image = ((System.Drawing.Image)(resources.GetObject("btnSterge.Image")));
            this.btnSterge.Location = new System.Drawing.Point(146, 22);
            this.btnSterge.Name = "btnSterge";
            this.btnSterge.Size = new System.Drawing.Size(24, 21);
            this.btnSterge.TabIndex = 9;
            this.btnSterge.TabStop = false;
            this.btnSterge.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Stergere;
            this.btnSterge.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnSterge.UseVisualStyleBackColor = true;
            this.btnSterge.Click += new System.EventHandler(this.btnSterge_Click);
            // 
            // controlInchidere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnSterge);
            this.Controls.Add(this.btnDeschideListaMotiveInchidere);
            this.Controls.Add(this.txtMotivInchidere);
            this.Controls.Add(this.lblMotivulInchiderii);
            this.Controls.Add(this.flpOptiuni);
            this.Name = "controlInchidere";
            this.Size = new System.Drawing.Size(203, 92);
            this.flpOptiuni.ResumeLayout(false);
            this.flpOptiuni.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.Caramizi.TextBoxGuma txtMotivInchidere;
        private CCL.UI.LabelPersonalizat lblMotivulInchiderii;
        private CCL.UI.CheckBoxPersonalizat chkDezactiveaza;
        private CCL.UI.LabelPersonalizat lblDataInchidere;
        private CCL.UI.ButtonPersonalizat btnDeschideListaMotiveInchidere;
        private CCL.UI.ButtonPersonalizat btnSterge;
        private CCL.UI.FlowLayoutPanelPersonalizat flpOptiuni;
    }
}
