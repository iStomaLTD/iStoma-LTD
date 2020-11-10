namespace iStomaLab.Caramizi
{
    partial class ControlPerioada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPerioada));
            this.datInceput = new CCL.UI.controlAlegeData();
            this.datSfarsit = new CCL.UI.controlAlegeData();
            this.btnAnulTrecut = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnAnulAcesta = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnSaptamanaAsta = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnSaptamanaTrecuta = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnLunaAsta = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblPerioadaAfisata = new CCL.UI.LabelPersonalizat(this.components);
            this.btnLunaTrecuta = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnAstazi = new CCL.UI.ButtonPersonalizat(this.components);
            this.flpPerioadaCurenta = new CCL.UI.FlowLayoutPanelPersonalizat(this.components);
            this.flpPerioadaUrmatoare = new CCL.UI.FlowLayoutPanelPersonalizat(this.components);
            this.lblLiniuta = new CCL.UI.LabelPersonalizat(this.components);
            this.btnCustom = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnInainte = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnInapoi = new CCL.UI.ButtonPersonalizat(this.components);
            this.flpPerioadaCurenta.SuspendLayout();
            this.flpPerioadaUrmatoare.SuspendLayout();
            this.SuspendLayout();
            // 
            // datInceput
            // 
            this.datInceput.AfiseazaButonGuma = false;
            this.datInceput.AfiseazaCuOra = false;
            this.datInceput.AfiseazaCuSecunde = false;
            this.datInceput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.datInceput.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.datInceput.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.datInceput.BackColor = System.Drawing.Color.White;
            this.datInceput.DataAfisata = new System.DateTime(((long)(0)));
            this.datInceput.IsInReadOnlyMode = false;
            this.datInceput.Location = new System.Drawing.Point(481, 4);
            this.datInceput.Name = "datInceput";
            this.datInceput.PragInferior = new System.DateTime(((long)(0)));
            this.datInceput.PragSuperior = new System.DateTime(((long)(0)));
            this.datInceput.ProprietateCorespunzatoare = null;
            this.datInceput.Size = new System.Drawing.Size(77, 21);
            this.datInceput.TabIndex = 17;
            this.datInceput.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.datInceput.TipDeschidereCalendar = CCL.UI.CEnumerariComune.EnumTipDeschidere.StangaSus;
            // 
            // datSfarsit
            // 
            this.datSfarsit.AfiseazaButonGuma = false;
            this.datSfarsit.AfiseazaCuOra = false;
            this.datSfarsit.AfiseazaCuSecunde = false;
            this.datSfarsit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.datSfarsit.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.datSfarsit.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.datSfarsit.BackColor = System.Drawing.Color.White;
            this.datSfarsit.DataAfisata = new System.DateTime(((long)(0)));
            this.datSfarsit.IsInReadOnlyMode = false;
            this.datSfarsit.Location = new System.Drawing.Point(577, 4);
            this.datSfarsit.Name = "datSfarsit";
            this.datSfarsit.PragInferior = new System.DateTime(((long)(0)));
            this.datSfarsit.PragSuperior = new System.DateTime(((long)(0)));
            this.datSfarsit.ProprietateCorespunzatoare = null;
            this.datSfarsit.Size = new System.Drawing.Size(77, 21);
            this.datSfarsit.TabIndex = 19;
            this.datSfarsit.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.datSfarsit.TipDeschidereCalendar = CCL.UI.CEnumerariComune.EnumTipDeschidere.StangaSus;
            // 
            // btnAnulTrecut
            // 
            this.btnAnulTrecut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnulTrecut.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAnulTrecut.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAnulTrecut.Image = null;
            this.btnAnulTrecut.Location = new System.Drawing.Point(255, 0);
            this.btnAnulTrecut.Margin = new System.Windows.Forms.Padding(4, 0, 3, 3);
            this.btnAnulTrecut.Name = "btnAnulTrecut";
            this.btnAnulTrecut.Size = new System.Drawing.Size(80, 23);
            this.btnAnulTrecut.TabIndex = 25;
            this.btnAnulTrecut.Text = "anul trecut";
            this.btnAnulTrecut.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnAnulTrecut.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAnulTrecut.UseVisualStyleBackColor = true;
            // 
            // btnAnulAcesta
            // 
            this.btnAnulAcesta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAnulAcesta.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAnulAcesta.Image = null;
            this.btnAnulAcesta.Location = new System.Drawing.Point(288, 0);
            this.btnAnulAcesta.Margin = new System.Windows.Forms.Padding(4, 0, 0, 3);
            this.btnAnulAcesta.Name = "btnAnulAcesta";
            this.btnAnulAcesta.Size = new System.Drawing.Size(80, 23);
            this.btnAnulAcesta.TabIndex = 22;
            this.btnAnulAcesta.Text = "anul aceasta";
            this.btnAnulAcesta.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnAnulAcesta.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAnulAcesta.UseVisualStyleBackColor = true;
            // 
            // btnSaptamanaAsta
            // 
            this.btnSaptamanaAsta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSaptamanaAsta.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnSaptamanaAsta.Image = null;
            this.btnSaptamanaAsta.Location = new System.Drawing.Point(81, 0);
            this.btnSaptamanaAsta.Margin = new System.Windows.Forms.Padding(4, 0, 0, 3);
            this.btnSaptamanaAsta.Name = "btnSaptamanaAsta";
            this.btnSaptamanaAsta.Size = new System.Drawing.Size(119, 23);
            this.btnSaptamanaAsta.TabIndex = 20;
            this.btnSaptamanaAsta.Text = "săptămâna aceasta";
            this.btnSaptamanaAsta.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnSaptamanaAsta.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnSaptamanaAsta.UseVisualStyleBackColor = true;
            // 
            // btnSaptamanaTrecuta
            // 
            this.btnSaptamanaTrecuta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaptamanaTrecuta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSaptamanaTrecuta.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnSaptamanaTrecuta.Image = null;
            this.btnSaptamanaTrecuta.Location = new System.Drawing.Point(48, 0);
            this.btnSaptamanaTrecuta.Margin = new System.Windows.Forms.Padding(4, 0, 0, 3);
            this.btnSaptamanaTrecuta.Name = "btnSaptamanaTrecuta";
            this.btnSaptamanaTrecuta.Size = new System.Drawing.Size(119, 23);
            this.btnSaptamanaTrecuta.TabIndex = 23;
            this.btnSaptamanaTrecuta.Text = "săptămâna trecută";
            this.btnSaptamanaTrecuta.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnSaptamanaTrecuta.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnSaptamanaTrecuta.UseVisualStyleBackColor = true;
            // 
            // btnLunaAsta
            // 
            this.btnLunaAsta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLunaAsta.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnLunaAsta.Image = null;
            this.btnLunaAsta.Location = new System.Drawing.Point(204, 0);
            this.btnLunaAsta.Margin = new System.Windows.Forms.Padding(4, 0, 0, 3);
            this.btnLunaAsta.Name = "btnLunaAsta";
            this.btnLunaAsta.Size = new System.Drawing.Size(80, 23);
            this.btnLunaAsta.TabIndex = 21;
            this.btnLunaAsta.Text = "luna aceasta";
            this.btnLunaAsta.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnLunaAsta.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnLunaAsta.UseVisualStyleBackColor = true;
            // 
            // lblPerioadaAfisata
            // 
            this.lblPerioadaAfisata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPerioadaAfisata.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPerioadaAfisata.Location = new System.Drawing.Point(92, 4);
            this.lblPerioadaAfisata.Name = "lblPerioadaAfisata";
            this.lblPerioadaAfisata.Size = new System.Drawing.Size(329, 20);
            this.lblPerioadaAfisata.TabIndex = 15;
            this.lblPerioadaAfisata.Text = "29 aug - 1 sept. 2011";
            this.lblPerioadaAfisata.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPerioadaAfisata.ToolTipText = null;
            this.lblPerioadaAfisata.ToolTipTitle = null;
            // 
            // btnLunaTrecuta
            // 
            this.btnLunaTrecuta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLunaTrecuta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLunaTrecuta.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnLunaTrecuta.Image = null;
            this.btnLunaTrecuta.Location = new System.Drawing.Point(171, 0);
            this.btnLunaTrecuta.Margin = new System.Windows.Forms.Padding(4, 0, 0, 3);
            this.btnLunaTrecuta.Name = "btnLunaTrecuta";
            this.btnLunaTrecuta.Size = new System.Drawing.Size(80, 23);
            this.btnLunaTrecuta.TabIndex = 24;
            this.btnLunaTrecuta.Text = "luna trecută";
            this.btnLunaTrecuta.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnLunaTrecuta.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnLunaTrecuta.UseVisualStyleBackColor = true;
            // 
            // btnAstazi
            // 
            this.btnAstazi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAstazi.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAstazi.Image = null;
            this.btnAstazi.Location = new System.Drawing.Point(2, 0);
            this.btnAstazi.Margin = new System.Windows.Forms.Padding(2, 0, 0, 3);
            this.btnAstazi.Name = "btnAstazi";
            this.btnAstazi.Size = new System.Drawing.Size(75, 23);
            this.btnAstazi.TabIndex = 26;
            this.btnAstazi.Text = "astazi";
            this.btnAstazi.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnAstazi.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAstazi.UseVisualStyleBackColor = true;
            // 
            // flpPerioadaCurenta
            // 
            this.flpPerioadaCurenta.Controls.Add(this.btnAstazi);
            this.flpPerioadaCurenta.Controls.Add(this.btnSaptamanaAsta);
            this.flpPerioadaCurenta.Controls.Add(this.btnLunaAsta);
            this.flpPerioadaCurenta.Controls.Add(this.btnAnulAcesta);
            this.flpPerioadaCurenta.Location = new System.Drawing.Point(-1, 32);
            this.flpPerioadaCurenta.Name = "flpPerioadaCurenta";
            this.flpPerioadaCurenta.Size = new System.Drawing.Size(388, 29);
            this.flpPerioadaCurenta.TabIndex = 27;
            // 
            // flpPerioadaUrmatoare
            // 
            this.flpPerioadaUrmatoare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flpPerioadaUrmatoare.Controls.Add(this.btnAnulTrecut);
            this.flpPerioadaUrmatoare.Controls.Add(this.btnLunaTrecuta);
            this.flpPerioadaUrmatoare.Controls.Add(this.btnSaptamanaTrecuta);
            this.flpPerioadaUrmatoare.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpPerioadaUrmatoare.Location = new System.Drawing.Point(405, 32);
            this.flpPerioadaUrmatoare.Name = "flpPerioadaUrmatoare";
            this.flpPerioadaUrmatoare.Size = new System.Drawing.Size(338, 29);
            this.flpPerioadaUrmatoare.TabIndex = 28;
            // 
            // lblLiniuta
            // 
            this.lblLiniuta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLiniuta.Location = new System.Drawing.Point(561, 6);
            this.lblLiniuta.Name = "lblLiniuta";
            this.lblLiniuta.Size = new System.Drawing.Size(13, 17);
            this.lblLiniuta.TabIndex = 18;
            this.lblLiniuta.Text = "-";
            this.lblLiniuta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLiniuta.ToolTipText = null;
            this.lblLiniuta.ToolTipTitle = null;
            // 
            // btnCustom
            // 
            this.btnCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCustom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCustom.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnCustom.Image = null;
            this.btnCustom.Location = new System.Drawing.Point(660, 3);
            this.btnCustom.Name = "btnCustom";
            this.btnCustom.Size = new System.Drawing.Size(80, 23);
            this.btnCustom.TabIndex = 29;
            this.btnCustom.Text = "Schimba";
            this.btnCustom.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnCustom.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnCustom.UseVisualStyleBackColor = true;
            // 
            // btnInainte
            // 
            this.btnInainte.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnInainte.Image = ((System.Drawing.Image)(resources.GetObject("btnInainte.Image")));
            this.btnInainte.Location = new System.Drawing.Point(45, 3);
            this.btnInainte.Name = "btnInainte";
            this.btnInainte.Size = new System.Drawing.Size(41, 23);
            this.btnInainte.TabIndex = 14;
            this.btnInainte.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Dreapta;
            this.btnInainte.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnInainte.UseVisualStyleBackColor = true;
            // 
            // btnInapoi
            // 
            this.btnInapoi.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnInapoi.Image = ((System.Drawing.Image)(resources.GetObject("btnInapoi.Image")));
            this.btnInapoi.Location = new System.Drawing.Point(1, 3);
            this.btnInapoi.Name = "btnInapoi";
            this.btnInapoi.Size = new System.Drawing.Size(41, 23);
            this.btnInapoi.TabIndex = 13;
            this.btnInapoi.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Stanga;
            this.btnInapoi.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnInapoi.UseVisualStyleBackColor = true;
            // 
            // ControlPerioada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCustom);
            this.Controls.Add(this.datInceput);
            this.Controls.Add(this.datSfarsit);
            this.Controls.Add(this.btnInainte);
            this.Controls.Add(this.lblPerioadaAfisata);
            this.Controls.Add(this.btnInapoi);
            this.Controls.Add(this.flpPerioadaCurenta);
            this.Controls.Add(this.flpPerioadaUrmatoare);
            this.Controls.Add(this.lblLiniuta);
            this.Name = "ControlPerioada";
            this.Size = new System.Drawing.Size(743, 57);
            this.flpPerioadaCurenta.ResumeLayout(false);
            this.flpPerioadaUrmatoare.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private CCL.UI.controlAlegeData datInceput;
        private CCL.UI.controlAlegeData datSfarsit;
        private CCL.UI.ButtonPersonalizat btnAnulTrecut;
        private CCL.UI.ButtonPersonalizat btnAnulAcesta;
        private CCL.UI.ButtonPersonalizat btnSaptamanaAsta;
        private CCL.UI.ButtonPersonalizat btnInainte;
        private CCL.UI.ButtonPersonalizat btnSaptamanaTrecuta;
        private CCL.UI.ButtonPersonalizat btnLunaAsta;
        private CCL.UI.LabelPersonalizat lblPerioadaAfisata;
        private CCL.UI.ButtonPersonalizat btnLunaTrecuta;
        private CCL.UI.ButtonPersonalizat btnInapoi;
        private CCL.UI.ButtonPersonalizat btnAstazi;
        private CCL.UI.FlowLayoutPanelPersonalizat flpPerioadaCurenta;
        private CCL.UI.FlowLayoutPanelPersonalizat flpPerioadaUrmatoare;
        private CCL.UI.LabelPersonalizat lblLiniuta;
        private CCL.UI.ButtonPersonalizat btnCustom;
    }
}
