using ILL.iStomaLab; using CDL.iStomaLab;
namespace CCL.UI.FormulareComune
{
    partial class frmMesajPersonalizat
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
            this.btnOK = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnCancel = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblMesaj = new CCL.UI.LabelPersonalizat(this.components);
            this.txtMesaj = new CCL.UI.TextBoxPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(422, 19);
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(421, 0);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.BackColor = System.Drawing.SystemColors.Control;
            this.btnOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOK.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnOK.Image = null;
            this.btnOK.Location = new System.Drawing.Point(105, 114);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(114, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnOK.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnCancel.Image = null;
            this.btnCancel.Location = new System.Drawing.Point(225, 114);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(114, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Anuleaza";
            this.btnCancel.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnCancel.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblMesaj
            // 
            this.lblMesaj.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMesaj.BackColor = System.Drawing.Color.Transparent;
            this.lblMesaj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMesaj.Location = new System.Drawing.Point(12, 30);
            this.lblMesaj.Name = "lblMesaj";
            this.lblMesaj.Size = new System.Drawing.Size(420, 76);
            this.lblMesaj.TabIndex = 2;
            this.lblMesaj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMesaj.ToolTipText = null;
            this.lblMesaj.ToolTipTitle = null;
            // 
            // txtMesaj
            // 
            this.txtMesaj.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMesaj.CapitalizeazaPrimaLitera = false;
            this.txtMesaj.IsInReadOnlyMode = false;
            this.txtMesaj.Location = new System.Drawing.Point(12, 30);
            this.txtMesaj.Multiline = true;
            this.txtMesaj.Name = "txtMesaj";
            this.txtMesaj.ProprietateCorespunzatoare = null;
            this.txtMesaj.RaiseEventLaModificareProgramatica = false;
            this.txtMesaj.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMesaj.Size = new System.Drawing.Size(420, 76);
            this.txtMesaj.TabIndex = 3;
            this.txtMesaj.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtMesaj.TotulCuMajuscule = false;
            this.txtMesaj.Visible = false;
            // 
            // frmMesajPersonalizat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 141);
            this.Controls.Add(this.txtMesaj);
            this.Controls.Add(this.lblMesaj);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMesajPersonalizat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmMesajPersonalizat_Load);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblMesaj, 0);
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.txtMesaj, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.ButtonPersonalizat btnOK;
        private CCL.UI.ButtonPersonalizat btnCancel;
        private CCL.UI.LabelPersonalizat lblMesaj;
        private TextBoxPersonalizat txtMesaj;
    }
}