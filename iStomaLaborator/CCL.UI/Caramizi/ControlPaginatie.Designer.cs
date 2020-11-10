namespace CCL.UI.Caramizi
{
    partial class ControlPaginatie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPaginatie));
            this.lblNrPagina = new CCL.UI.LabelPersonalizat(this.components);
            this.btnListaCompleta = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnDreapta = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnStanga = new CCL.UI.ButtonPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // lblNrPagina
            // 
            this.lblNrPagina.Location = new System.Drawing.Point(33, 0);
            this.lblNrPagina.Name = "lblNrPagina";
            this.lblNrPagina.Size = new System.Drawing.Size(39, 23);
            this.lblNrPagina.TabIndex = 3;
            this.lblNrPagina.Text = "19/33";
            this.lblNrPagina.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNrPagina.ToolTipText = null;
            this.lblNrPagina.ToolTipTitle = null;
            // 
            // btnListaCompleta
            // 
            this.btnListaCompleta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListaCompleta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnListaCompleta.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnListaCompleta.Image = null;
            this.btnListaCompleta.Location = new System.Drawing.Point(110, 0);
            this.btnListaCompleta.Name = "btnListaCompleta";
            this.btnListaCompleta.Size = new System.Drawing.Size(75, 23);
            this.btnListaCompleta.TabIndex = 2;
            this.btnListaCompleta.Text = "Lista completa";
            this.btnListaCompleta.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnListaCompleta.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnListaCompleta.UseVisualStyleBackColor = true;
            this.btnListaCompleta.Click += new System.EventHandler(this.btnListaCompleta_Click);
            // 
            // btnDreapta
            // 
            this.btnDreapta.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnDreapta.Image = ((System.Drawing.Image)(resources.GetObject("btnDreapta.Image")));
            this.btnDreapta.Location = new System.Drawing.Point(75, 0);
            this.btnDreapta.Name = "btnDreapta";
            this.btnDreapta.Size = new System.Drawing.Size(29, 23);
            this.btnDreapta.TabIndex = 1;
            this.btnDreapta.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Dreapta;
            this.btnDreapta.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnDreapta.UseVisualStyleBackColor = true;
            this.btnDreapta.Click += new System.EventHandler(this.btnDreapta_Click);
            // 
            // btnStanga
            // 
            this.btnStanga.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnStanga.Image = ((System.Drawing.Image)(resources.GetObject("btnStanga.Image")));
            this.btnStanga.Location = new System.Drawing.Point(1, 0);
            this.btnStanga.Name = "btnStanga";
            this.btnStanga.Size = new System.Drawing.Size(29, 23);
            this.btnStanga.TabIndex = 0;
            this.btnStanga.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Stanga;
            this.btnStanga.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnStanga.UseVisualStyleBackColor = true;
            this.btnStanga.Click += new System.EventHandler(this.btnStanga_Click);
            // 
            // ControlPaginatie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNrPagina);
            this.Controls.Add(this.btnListaCompleta);
            this.Controls.Add(this.btnDreapta);
            this.Controls.Add(this.btnStanga);
            this.Name = "ControlPaginatie";
            this.Size = new System.Drawing.Size(185, 23);
            this.ResumeLayout(false);

        }

        #endregion

        private ButtonPersonalizat btnStanga;
        private ButtonPersonalizat btnDreapta;
        private ButtonPersonalizat btnListaCompleta;
        private LabelPersonalizat lblNrPagina;
    }
}
