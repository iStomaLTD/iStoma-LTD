using ILL.iStomaLab;
using CDL.iStomaLab;
namespace CCL.UI.Caramizi
{
    partial class ComboBoxGuma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComboBoxGuma));
            this.btnAccesParametraj = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnAfiseazaDetalii = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnGuma = new CCL.UI.ButtonPersonalizat(this.components);
            this.cboListaCompleta = new CCL.UI.ComboBoxPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // btnAccesParametraj
            // 
            this.btnAccesParametraj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(255)))));
            this.btnAccesParametraj.FlatAppearance.BorderSize = 0;
            this.btnAccesParametraj.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAccesParametraj.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAccesParametraj.Location = new System.Drawing.Point(1, 6);
            this.btnAccesParametraj.Margin = new System.Windows.Forms.Padding(0);
            this.btnAccesParametraj.Name = "btnAccesParametraj";
            this.btnAccesParametraj.Selectat = false;
            this.btnAccesParametraj.Size = new System.Drawing.Size(12, 12);
            this.btnAccesParametraj.TabIndex = 0;
            this.btnAccesParametraj.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Parametraj;
            this.btnAccesParametraj.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnAccesParametraj.ToolTipMessage = "";
            this.btnAccesParametraj.ToolTipTitle = "";
            this.btnAccesParametraj.UseVisualStyleBackColor = false;
            this.btnAccesParametraj.Click += new System.EventHandler(this.btnAccesParametraj_Click);
            // 
            // btnAfiseazaDetalii
            // 
            this.btnAfiseazaDetalii.Image = ((System.Drawing.Image)(resources.GetObject("btnAfiseazaDetalii.Image")));
            this.btnAfiseazaDetalii.Location = new System.Drawing.Point(17, 1);
            this.btnAfiseazaDetalii.Name = "btnAfiseazaDetalii";
            this.btnAfiseazaDetalii.Selectat = false;
            this.btnAfiseazaDetalii.Size = new System.Drawing.Size(23, 20);
            this.btnAfiseazaDetalii.TabIndex = 1;
            this.btnAfiseazaDetalii.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.DetaliiPopUp;
            this.btnAfiseazaDetalii.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnAfiseazaDetalii.ToolTipMessage = "";
            this.btnAfiseazaDetalii.ToolTipTitle = "";
            this.btnAfiseazaDetalii.UseVisualStyleBackColor = true;
            this.btnAfiseazaDetalii.Click += new System.EventHandler(this.btnAfiseazaDetalii_Click);
            // 
            // btnGuma
            // 
            this.btnGuma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuma.BackColor = System.Drawing.SystemColors.Control;
            this.btnGuma.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGuma.Image = ((System.Drawing.Image)(resources.GetObject("btnGuma.Image")));
            this.btnGuma.Location = new System.Drawing.Point(111, 1);
            this.btnGuma.Name = "btnGuma";
            this.btnGuma.Selectat = false;
            this.btnGuma.Size = new System.Drawing.Size(23, 20);
            this.btnGuma.TabIndex = 3;
            this.btnGuma.TabStop = false;
            this.btnGuma.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Guma;
            this.btnGuma.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnGuma.ToolTipMessage = "";
            this.btnGuma.ToolTipTitle = "";
            this.btnGuma.UseVisualStyleBackColor = true;
            this.btnGuma.Click += new System.EventHandler(this.btnGuma_Click);
            // 
            // cboListaCompleta
            // 
            this.cboListaCompleta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboListaCompleta.AutoCompletePersonalizat = false;
            this.cboListaCompleta.FormattingEnabled = true;
            this.cboListaCompleta.HideSelection = true;
            this.cboListaCompleta.IsInReadOnlyMode = false;
            this.cboListaCompleta.Location = new System.Drawing.Point(43, 1);
            this.cboListaCompleta.Name = "cboListaCompleta";
            this.cboListaCompleta.ProprietateCorespunzatoare = null;
            this.cboListaCompleta.Size = new System.Drawing.Size(66, 21);
            this.cboListaCompleta.TabIndex = 2;
            this.cboListaCompleta.TipulListei = CCL.UI.ComboBoxPersonalizat.EnumTipLista.Nespecificat;
            this.cboListaCompleta.CerereUpdate += new CCL.UI.ComboBoxPersonalizat.ZonaModificata(this.cboListaCompleta_CerereUpdate);
            this.cboListaCompleta.SelectedIndexChanged += new System.EventHandler(this.cboListaCompleta_SelectedIndexChanged);
            this.cboListaCompleta.TextChanged += new System.EventHandler(this.cboListaCompleta_SelectedIndexChanged);
            this.cboListaCompleta.Enter += new System.EventHandler(this.cboListaCompleta_Enter);
            // 
            // ComboBoxGuma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAccesParametraj);
            this.Controls.Add(this.btnAfiseazaDetalii);
            this.Controls.Add(this.btnGuma);
            this.Controls.Add(this.cboListaCompleta);
            this.Name = "ComboBoxGuma";
            this.Size = new System.Drawing.Size(134, 23);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private ComboBoxPersonalizat cboListaCompleta;
        private ButtonPersonalizat btnGuma;
        private ButtonPersonalizat btnAfiseazaDetalii;
        private ButtonPersonalizat btnAccesParametraj;
    }
}
