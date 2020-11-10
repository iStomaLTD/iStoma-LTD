namespace iStomaLab.Generale
{
    partial class ControlPauza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPauza));
            this.txtParolaPauza = new CCL.UI.TextBoxPersonalizat(this.components);
            this.btnPauza = new CCL.UI.ButtonPersonalizat(this.components);
            this.picPauza = new CCL.UI.PictureBoxPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picPauza)).BeginInit();
            this.SuspendLayout();
            // 
            // txtParolaPauza
            // 
            this.txtParolaPauza.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtParolaPauza.CapitalizeazaPrimaLitera = false;
            this.txtParolaPauza.IsInReadOnlyMode = false;
            this.txtParolaPauza.Location = new System.Drawing.Point(24, 219);
            this.txtParolaPauza.Name = "txtParolaPauza";
            this.txtParolaPauza.ProprietateCorespunzatoare = null;
            this.txtParolaPauza.RaiseEventLaModificareProgramatica = false;
            this.txtParolaPauza.Size = new System.Drawing.Size(230, 22);
            this.txtParolaPauza.TabIndex = 0;
            this.txtParolaPauza.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtParolaPauza.TotulCuMajuscule = false;
            this.txtParolaPauza.UseSystemPasswordChar = true;
            // 
            // btnPauza
            // 
            this.btnPauza.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPauza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPauza.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnPauza.Image = ((System.Drawing.Image)(resources.GetObject("btnPauza.Image")));
            this.btnPauza.Location = new System.Drawing.Point(270, 219);
            this.btnPauza.Name = "btnPauza";
            this.btnPauza.Size = new System.Drawing.Size(75, 23);
            this.btnPauza.TabIndex = 1;
            this.btnPauza.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Validare;
            this.btnPauza.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnPauza.UseVisualStyleBackColor = true;
            // 
            // picPauza
            // 
            this.picPauza.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picPauza.ContinutToolTip = null;
            this.picPauza.Enabled = false;
            this.picPauza.IcoanaToolTip = System.Windows.Forms.ToolTipIcon.Info;
            this.picPauza.Image = global::iStomaLab.Properties.Resources.logo_manual;
            this.picPauza.Location = new System.Drawing.Point(66, 37);
            this.picPauza.Name = "picPauza";
            this.picPauza.Size = new System.Drawing.Size(211, 158);
            this.picPauza.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPauza.TabIndex = 0;
            this.picPauza.TabStop = false;
            this.picPauza.TitluToolTip = "";
            this.picPauza.UtilizamToolTip = false;
            // 
            // ControlPauza
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnPauza);
            this.Controls.Add(this.txtParolaPauza);
            this.Controls.Add(this.picPauza);
            this.Name = "ControlPauza";
            this.Size = new System.Drawing.Size(666, 478);
            ((System.ComponentModel.ISupportInitialize)(this.picPauza)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.PictureBoxPersonalizat picPauza;
        private CCL.UI.TextBoxPersonalizat txtParolaPauza;
        private CCL.UI.ButtonPersonalizat btnPauza;
    }
}
