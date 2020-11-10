using ILL.iStomaLab;
using CDL.iStomaLab;
using static CDL.iStomaLab.CDefinitiiComune;

namespace CCL.UI
{
    partial class ControlGestiuneNumarOrdine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlGestiuneNumarOrdine));
            this.btnSortareAlfabetica = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnSus = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnJos = new CCL.UI.ButtonPersonalizat(this.components);
            this.txtNumarOrdine = new CCL.UI.MaskedTextBoxPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // btnSortareAlfabetica
            // 
            this.btnSortareAlfabetica.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSortareAlfabetica.GenulTextului = EnumSex.Barbatesc;
            this.btnSortareAlfabetica.Image = ((System.Drawing.Image)(resources.GetObject("btnSortareAlfabetica.Image")));
            this.btnSortareAlfabetica.Location = new System.Drawing.Point(0, 0);
            this.btnSortareAlfabetica.Name = "btnSortareAlfabetica";
            this.btnSortareAlfabetica.Selectat = false;
            this.btnSortareAlfabetica.Size = new System.Drawing.Size(30, 29);
            this.btnSortareAlfabetica.TabIndex = 9;
            this.btnSortareAlfabetica.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.SortareAlfabetica;
            this.btnSortareAlfabetica.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnSortareAlfabetica.ToolTipMessage = "";
            this.btnSortareAlfabetica.ToolTipTitle = "";
            this.btnSortareAlfabetica.UseVisualStyleBackColor = true;
            this.btnSortareAlfabetica.Click += new System.EventHandler(this.btnSortareAlfabetica_Click);
            // 
            // btnSus
            // 
            this.btnSus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSus.GenulTextului = EnumSex.Barbatesc;
            this.btnSus.Image = ((System.Drawing.Image)(resources.GetObject("btnSus.Image")));
            this.btnSus.Location = new System.Drawing.Point(0, 87);
            this.btnSus.Name = "btnSus";
            this.btnSus.Selectat = false;
            this.btnSus.Size = new System.Drawing.Size(30, 33);
            this.btnSus.TabIndex = 8;
            this.btnSus.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Sus;
            this.btnSus.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnSus.ToolTipMessage = "";
            this.btnSus.ToolTipTitle = "";
            this.btnSus.UseVisualStyleBackColor = true;
            this.btnSus.Click += new System.EventHandler(this.btnSus_Click);
            // 
            // btnJos
            // 
            this.btnJos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJos.GenulTextului = EnumSex.Barbatesc;
            this.btnJos.Image = ((System.Drawing.Image)(resources.GetObject("btnJos.Image")));
            this.btnJos.Location = new System.Drawing.Point(0, 126);
            this.btnJos.Name = "btnJos";
            this.btnJos.Selectat = false;
            this.btnJos.Size = new System.Drawing.Size(30, 33);
            this.btnJos.TabIndex = 7;
            this.btnJos.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Jos;
            this.btnJos.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnJos.ToolTipMessage = "";
            this.btnJos.ToolTipTitle = "";
            this.btnJos.UseVisualStyleBackColor = true;
            this.btnJos.Click += new System.EventHandler(this.btnJos_Click);
            // 
            // txtNumarOrdine
            // 
            this.txtNumarOrdine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumarOrdine.BackColor = System.Drawing.SystemColors.Window;
            this.txtNumarOrdine.IsInReadOnlyMode = false;
            this.txtNumarOrdine.Location = new System.Drawing.Point(0, 48);
            this.txtNumarOrdine.Name = "txtNumarOrdine";
            this.txtNumarOrdine.ProprietateCorespunzatoare = null;
            this.txtNumarOrdine.Size = new System.Drawing.Size(30, 20);
            this.txtNumarOrdine.TabIndex = 10;
            this.txtNumarOrdine.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.txtNumarOrdine.AfterUpdate += new CCL.UI.MaskedTextBoxPersonalizat.ValoareModificata(this.txtNumarOrdine_AfterUpdate);
            // 
            // ControlGestiuneNumarOrdine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtNumarOrdine);
            this.Controls.Add(this.btnSortareAlfabetica);
            this.Controls.Add(this.btnSus);
            this.Controls.Add(this.btnJos);
            this.MinimumSize = new System.Drawing.Size(31, 163);
            this.Name = "ControlGestiuneNumarOrdine";
            this.Size = new System.Drawing.Size(31, 163);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ButtonPersonalizat btnSortareAlfabetica;
        private ButtonPersonalizat btnSus;
        private ButtonPersonalizat btnJos;
        private MaskedTextBoxPersonalizat txtNumarOrdine;
    }
}
