namespace CCL.UI.FormulareComune
{
    partial class frmCuHeader
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
            this.lblTitluEcran = new CCL.UI.ControalePersonalizate.LabelChenar(this.components);
            this.btnInchidereEcran = new CCL.UI.ButtonPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitluEcran.BackColor = System.Drawing.Color.Gray;
            this.lblTitluEcran.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitluEcran.ForeColor = System.Drawing.Color.Gold;
            this.lblTitluEcran.Location = new System.Drawing.Point(0, 0);
            this.lblTitluEcran.Name = "lblTitluEcran";
            this.lblTitluEcran.Size = new System.Drawing.Size(262, 19);
            this.lblTitluEcran.TabIndex = 0;
            this.lblTitluEcran.Text = "Titlu";
            this.lblTitluEcran.ToolTipText = null;
            this.lblTitluEcran.ToolTipTitle = null;
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInchidereEcran.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnInchidereEcran.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnInchidereEcran.Image = null;
            this.btnInchidereEcran.Location = new System.Drawing.Point(261, 0);
            this.btnInchidereEcran.Name = "btnInchidereEcran";
            this.btnInchidereEcran.Size = new System.Drawing.Size(23, 19);
            this.btnInchidereEcran.TabIndex = 1;
            this.btnInchidereEcran.Text = "X";
            this.btnInchidereEcran.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.InchidereEcran;
            this.btnInchidereEcran.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnInchidereEcran.UseVisualStyleBackColor = true;
            this.btnInchidereEcran.Click += new System.EventHandler(this.btnInchidereEcran_Click);
            // 
            // frmCuHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnInchidereEcran;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnInchidereEcran);
            this.Controls.Add(this.lblTitluEcran);
            this.Name = "frmCuHeader";
            this.ShowIcon = false;
            this.ResumeLayout(false);

        }

        #endregion

        protected ControalePersonalizate.LabelChenar lblTitluEcran;
        protected ButtonPersonalizat btnInchidereEcran;
    }
}