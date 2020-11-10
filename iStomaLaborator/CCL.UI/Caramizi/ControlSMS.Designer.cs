namespace CCL.UI.Caramizi
{
    partial class ControlSMS
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
            this.lblCaractereRamase = new CCL.UI.LabelPersonalizat(this.components);
            this.lblMesaje = new CCL.UI.LabelPersonalizat(this.components);
            this.lblContinut = new CCL.UI.LabelPersonalizat(this.components);
            this.txtMesaj = new CCL.UI.Caramizi.TextBoxGuma();
            this.SuspendLayout();
            // 
            // lblCaractereRamase
            // 
            this.lblCaractereRamase.Location = new System.Drawing.Point(307, 0);
            this.lblCaractereRamase.Name = "lblCaractereRamase";
            this.lblCaractereRamase.Size = new System.Drawing.Size(175, 14);
            this.lblCaractereRamase.TabIndex = 10;
            this.lblCaractereRamase.Text = "Caractere ramase";
            this.lblCaractereRamase.ToolTipText = null;
            this.lblCaractereRamase.ToolTipTitle = null;
            // 
            // lblMesaje
            // 
            this.lblMesaje.Location = new System.Drawing.Point(146, 0);
            this.lblMesaje.Name = "lblMesaje";
            this.lblMesaje.Size = new System.Drawing.Size(155, 14);
            this.lblMesaje.TabIndex = 9;
            this.lblMesaje.Text = "2 Mesaje";
            this.lblMesaje.ToolTipText = null;
            this.lblMesaje.ToolTipTitle = null;
            // 
            // lblContinut
            // 
            this.lblContinut.Location = new System.Drawing.Point(3, 0);
            this.lblContinut.Name = "lblContinut";
            this.lblContinut.Size = new System.Drawing.Size(85, 14);
            this.lblContinut.TabIndex = 7;
            this.lblContinut.Text = "Continut";
            this.lblContinut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblContinut.ToolTipText = null;
            this.lblContinut.ToolTipTitle = null;
            // 
            // txtMesaj
            // 
            this.txtMesaj.AcceptButton = null;
            this.txtMesaj.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMesaj.BackColor = System.Drawing.Color.Transparent;
            this.txtMesaj.IsInReadOnlyMode = false;
            this.txtMesaj.Location = new System.Drawing.Point(0, 15);
            this.txtMesaj.MaxLength = 32767;
            this.txtMesaj.Multiline = true;
            this.txtMesaj.Name = "txtMesaj";
            this.txtMesaj.ProprietateCorespunzatoare = null;
            this.txtMesaj.RaiseEventLaModificareProgramatica = false;
            this.txtMesaj.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMesaj.Size = new System.Drawing.Size(489, 108);
            this.txtMesaj.TabIndex = 8;
            this.txtMesaj.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtMesaj.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtMesaj.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtMesaj.UseSystemPasswordChar = false;
            this.txtMesaj.UtilizeazaButonGuma = false;
            this.txtMesaj.KeyUpPersonalizat += new System.Windows.Forms.KeyEventHandler(this.txtMesaj_KeyUpPersonalizat);
            // 
            // ControlSMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCaractereRamase);
            this.Controls.Add(this.lblMesaje);
            this.Controls.Add(this.txtMesaj);
            this.Controls.Add(this.lblContinut);
            this.Name = "ControlSMS";
            this.Size = new System.Drawing.Size(489, 123);
            this.ResumeLayout(false);

        }

        #endregion

        private LabelPersonalizat lblCaractereRamase;
        private LabelPersonalizat lblMesaje;
        private LabelPersonalizat lblContinut;
        private TextBoxGuma txtMesaj;
    }
}
