namespace iStomaLab
{
    partial class frmSugestieClient
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
            this.txtSugestie = new CCL.UI.TextBoxPersonalizat(this.components);
            this.ctrlValidareAnulare = new CCL.UI.Caramizi.controlValidareAnulare();
            this.lblSugestie = new CCL.UI.LabelPersonalizat(this.components);
            this.lblVaMultumim = new CCL.UI.LabelPersonalizat(this.components);
            this.lblUtilizatorConectat = new CCL.UI.LabelPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(638, 19);
            this.lblTitluEcran.Text = "frmSugestieClient";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(637, 0);
            // 
            // txtSugestie
            // 
            this.txtSugestie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSugestie.CapitalizeazaPrimaLitera = false;
            this.txtSugestie.IsInReadOnlyMode = false;
            this.txtSugestie.Location = new System.Drawing.Point(6, 46);
            this.txtSugestie.Multiline = true;
            this.txtSugestie.Name = "txtSugestie";
            this.txtSugestie.ProprietateCorespunzatoare = null;
            this.txtSugestie.RaiseEventLaModificareProgramatica = false;
            this.txtSugestie.Size = new System.Drawing.Size(646, 140);
            this.txtSugestie.TabIndex = 0;
            this.txtSugestie.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtSugestie.TotulCuMajuscule = false;
            // 
            // ctrlValidareAnulare
            // 
            this.ctrlValidareAnulare.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrlValidareAnulare.BackColor = System.Drawing.SystemColors.Control;
            this.ctrlValidareAnulare.Location = new System.Drawing.Point(250, 238);
            this.ctrlValidareAnulare.Name = "ctrlValidareAnulare";
            this.ctrlValidareAnulare.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulare.TabIndex = 2;
            this.ctrlValidareAnulare.Validare += new System.EventHandler(this.ctrlValidareAnulare_Validare);
            // 
            // lblSugestie
            // 
            this.lblSugestie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSugestie.Location = new System.Drawing.Point(6, 24);
            this.lblSugestie.Name = "lblSugestie";
            this.lblSugestie.Size = new System.Drawing.Size(646, 17);
            this.lblSugestie.TabIndex = 1;
            this.lblSugestie.Text = "M-as bucura daca...";
            this.lblSugestie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSugestie.ToolTipText = null;
            this.lblSugestie.ToolTipTitle = null;
            // 
            // lblVaMultumim
            // 
            this.lblVaMultumim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVaMultumim.Location = new System.Drawing.Point(6, 190);
            this.lblVaMultumim.Name = "lblVaMultumim";
            this.lblVaMultumim.Size = new System.Drawing.Size(646, 17);
            this.lblVaMultumim.TabIndex = 3;
            this.lblVaMultumim.Text = "Va multumim";
            this.lblVaMultumim.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVaMultumim.ToolTipText = null;
            this.lblVaMultumim.ToolTipTitle = null;
            // 
            // lblUtilizatorConectat
            // 
            this.lblUtilizatorConectat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUtilizatorConectat.Location = new System.Drawing.Point(6, 212);
            this.lblUtilizatorConectat.Name = "lblUtilizatorConectat";
            this.lblUtilizatorConectat.Size = new System.Drawing.Size(646, 17);
            this.lblUtilizatorConectat.TabIndex = 4;
            this.lblUtilizatorConectat.Text = "Dr. Botorogeanu Ionut";
            this.lblUtilizatorConectat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUtilizatorConectat.ToolTipText = null;
            this.lblUtilizatorConectat.ToolTipTitle = null;
            // 
            // frmSugestieClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 268);
            this.Controls.Add(this.lblUtilizatorConectat);
            this.Controls.Add(this.lblVaMultumim);
            this.Controls.Add(this.lblSugestie);
            this.Controls.Add(this.ctrlValidareAnulare);
            this.Controls.Add(this.txtSugestie);
            this.MinimumSize = new System.Drawing.Size(660, 268);
            this.Name = "frmSugestieClient";
            this.Text = "frmSugestieClient";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.txtSugestie, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulare, 0);
            this.Controls.SetChildIndex(this.lblSugestie, 0);
            this.Controls.SetChildIndex(this.lblVaMultumim, 0);
            this.Controls.SetChildIndex(this.lblUtilizatorConectat, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.TextBoxPersonalizat txtSugestie;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulare;
        private CCL.UI.LabelPersonalizat lblSugestie;
        private CCL.UI.LabelPersonalizat lblVaMultumim;
        private CCL.UI.LabelPersonalizat lblUtilizatorConectat;
    }
}