namespace iStomaLab.Generale
{
    partial class FormInchidereAplicatie
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
            this.lblConfirmareInchidere = new CCL.UI.LabelPersonalizat(this.components);
            this.lblContorSecunde = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlValidareAnulareInchidereAplicatie = new CCL.UI.Caramizi.controlValidareAnulare();
            this.lblAplicatieSeVaInchideAutomatIn = new CCL.UI.LabelPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitluEcran.Size = new System.Drawing.Size(386, 19);
            this.lblTitluEcran.Text = "FormInchidereAplicatie";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(385, 0);
            this.btnInchidereEcran.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            // 
            // lblConfirmareInchidere
            // 
            this.lblConfirmareInchidere.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConfirmareInchidere.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblConfirmareInchidere.Location = new System.Drawing.Point(5, 42);
            this.lblConfirmareInchidere.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConfirmareInchidere.Name = "lblConfirmareInchidere";
            this.lblConfirmareInchidere.Size = new System.Drawing.Size(398, 17);
            this.lblConfirmareInchidere.TabIndex = 2;
            this.lblConfirmareInchidere.Text = "Confirmati inchiderea aplicatiei?";
            this.lblConfirmareInchidere.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblConfirmareInchidere.ToolTipText = null;
            this.lblConfirmareInchidere.ToolTipTitle = null;
            // 
            // lblContorSecunde
            // 
            this.lblContorSecunde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContorSecunde.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblContorSecunde.Location = new System.Drawing.Point(5, 93);
            this.lblContorSecunde.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContorSecunde.Name = "lblContorSecunde";
            this.lblContorSecunde.Size = new System.Drawing.Size(398, 13);
            this.lblContorSecunde.TabIndex = 3;
            this.lblContorSecunde.Text = "3 secunde";
            this.lblContorSecunde.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblContorSecunde.ToolTipText = null;
            this.lblContorSecunde.ToolTipTitle = null;
            // 
            // ctrlValidareAnulareInchidereAplicatie
            // 
            this.ctrlValidareAnulareInchidereAplicatie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlValidareAnulareInchidereAplicatie.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulareInchidereAplicatie.Location = new System.Drawing.Point(124, 130);
            this.ctrlValidareAnulareInchidereAplicatie.Name = "ctrlValidareAnulareInchidereAplicatie";
            this.ctrlValidareAnulareInchidereAplicatie.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulareInchidereAplicatie.TabIndex = 4;
            // 
            // lblAplicatieSeVaInchideAutomatIn
            // 
            this.lblAplicatieSeVaInchideAutomatIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAplicatieSeVaInchideAutomatIn.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblAplicatieSeVaInchideAutomatIn.Location = new System.Drawing.Point(5, 75);
            this.lblAplicatieSeVaInchideAutomatIn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAplicatieSeVaInchideAutomatIn.Name = "lblAplicatieSeVaInchideAutomatIn";
            this.lblAplicatieSeVaInchideAutomatIn.Size = new System.Drawing.Size(398, 13);
            this.lblAplicatieSeVaInchideAutomatIn.TabIndex = 5;
            this.lblAplicatieSeVaInchideAutomatIn.Text = "Aplicatia se va inchide automat in:";
            this.lblAplicatieSeVaInchideAutomatIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAplicatieSeVaInchideAutomatIn.ToolTipText = null;
            this.lblAplicatieSeVaInchideAutomatIn.ToolTipTitle = null;
            // 
            // FormInchidereAplicatie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 165);
            this.Controls.Add(this.lblAplicatieSeVaInchideAutomatIn);
            this.Controls.Add(this.ctrlValidareAnulareInchidereAplicatie);
            this.Controls.Add(this.lblContorSecunde);
            this.Controls.Add(this.lblConfirmareInchidere);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormInchidereAplicatie";
            this.PermiteDeplasareaEcranului = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormInchidereAplicatie";
            this.TipDeschidere = CCL.UI.CEnumerariComune.EnumTipDeschidere.DreaptaSus;
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.lblConfirmareInchidere, 0);
            this.Controls.SetChildIndex(this.lblContorSecunde, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulareInchidereAplicatie, 0);
            this.Controls.SetChildIndex(this.lblAplicatieSeVaInchideAutomatIn, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.LabelPersonalizat lblConfirmareInchidere;
        private CCL.UI.LabelPersonalizat lblContorSecunde;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulareInchidereAplicatie;
        private CCL.UI.LabelPersonalizat lblAplicatieSeVaInchideAutomatIn;
    }
}