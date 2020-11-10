using ILL.iStomaLab;
using CDL.iStomaLab;
using static CDL.iStomaLab.CDefinitiiComune;

namespace CCL.UI.Caramizi
{
    partial class ControlDataOraGuma
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Cod GENERAT

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlDataOraGuma));
            this.btnGuma = new CCL.UI.ButtonPersonalizat(this.components);
            this.cboOre = new CCL.UI.ComboBoxOra(this.components);
            this.ctrlData = new CCL.UI.controlAlegeData();
            this.SuspendLayout();
            // 
            // btnGuma
            // 
            this.btnGuma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuma.BackColor = System.Drawing.SystemColors.Control;
            this.btnGuma.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGuma.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnGuma.Image = ((System.Drawing.Image)(resources.GetObject("btnGuma.Image")));
            this.btnGuma.Location = new System.Drawing.Point(164, 2);
            this.btnGuma.Name = "btnGuma";
            this.btnGuma.Size = new System.Drawing.Size(23, 19);
            this.btnGuma.TabIndex = 4;
            this.btnGuma.TabStop = false;
            this.btnGuma.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Guma;
            this.btnGuma.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnGuma.UseVisualStyleBackColor = true;
            this.btnGuma.Click += new System.EventHandler(this.btnGuma_Click);
            // 
            // cboOre
            // 
            this.cboOre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOre.AutoCompletePersonalizat = false;
            this.cboOre.FormattingEnabled = true;
            this.cboOre.HideSelection = true;
            this.cboOre.IsInReadOnlyMode = false;
            this.cboOre.Location = new System.Drawing.Point(103, 1);
            this.cboOre.Name = "cboOre";
            this.cboOre.Pas = CCL.UI.ComboBoxOra.EnumPas.CinciMinute;
            this.cboOre.ProprietateCorespunzatoare = null;
            this.cboOre.Size = new System.Drawing.Size(58, 21);
            this.cboOre.TabIndex = 1;
            this.cboOre.Text = "00:00";
            this.cboOre.TextCaData = new System.DateTime(((long)(0)));
            this.cboOre.TipulListei = CCL.UI.ComboBoxPersonalizat.EnumTipLista.Nespecificat;
            this.cboOre.CerereUpdate += new CCL.UI.ComboBoxPersonalizat.ZonaModificata(this.cboOra_CerereUpdate);
            this.cboOre.TextChanged += new System.EventHandler(this.cboOre_TextChanged);
            // 
            // ctrlData
            // 
            this.ctrlData.AfiseazaButonGuma = false;
            this.ctrlData.AfiseazaCuOra = false;
            this.ctrlData.AfiseazaCuSecunde = false;
            this.ctrlData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlData.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ctrlData.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ctrlData.BackColor = System.Drawing.Color.White;
            this.ctrlData.DataAfisata = new System.DateTime(((long)(0)));
            this.ctrlData.IsInReadOnlyMode = false;
            this.ctrlData.Location = new System.Drawing.Point(1, 1);
            this.ctrlData.Name = "ctrlData";
            this.ctrlData.PragInferior = new System.DateTime(((long)(0)));
            this.ctrlData.PragSuperior = new System.DateTime(((long)(0)));
            this.ctrlData.ProprietateCorespunzatoare = null;
            this.ctrlData.Size = new System.Drawing.Size(99, 22);
            this.ctrlData.TabIndex = 0;
            this.ctrlData.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.ctrlData.TipDeschidereCalendar = CCL.UI.CEnumerariComune.EnumTipDeschidere.StangaSus;
            this.ctrlData.CerereUpdate += new CCL.UI.controlAlegeData.ZonaModificata(this.ctrlData_CerereUpdate);
            // 
            // ControlDataOraGuma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGuma);
            this.Controls.Add(this.cboOre);
            this.Controls.Add(this.ctrlData);
            this.Name = "ControlDataOraGuma";
            this.Size = new System.Drawing.Size(188, 23);
            this.ResumeLayout(false);

        }

        #endregion

        private controlAlegeData ctrlData;
        private ComboBoxOra cboOre;
        private ButtonPersonalizat btnGuma;
    }
}
