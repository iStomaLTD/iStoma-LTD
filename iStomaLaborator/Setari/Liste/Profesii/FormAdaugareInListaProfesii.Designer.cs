namespace iStomaLab.Setari.Liste
{
    partial class FormAdaugareInLista
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
            this.ctrlAdaugareInListaProfesie = new iStomaLab.Setari.Liste.ControlAdaugareInLista();
            this.ctrlValidareAnulareProfesie = new CCL.UI.Caramizi.controlValidareAnulare();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(526, 23);
            this.lblTitluEcran.Text = "FormAdaugareInLista";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(525, 0);
            // 
            // ctrlAdaugareInListaProfesie
            // 
            this.ctrlAdaugareInListaProfesie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlAdaugareInListaProfesie.Location = new System.Drawing.Point(13, 31);
            this.ctrlAdaugareInListaProfesie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctrlAdaugareInListaProfesie.Name = "ctrlAdaugareInListaProfesie";
            this.ctrlAdaugareInListaProfesie.Size = new System.Drawing.Size(522, 109);
            this.ctrlAdaugareInListaProfesie.TabIndex = 2;
            // 
            // ctrlValidareAnulareProfesie
            // 
            this.ctrlValidareAnulareProfesie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlValidareAnulareProfesie.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulareProfesie.Location = new System.Drawing.Point(150, 145);
            this.ctrlValidareAnulareProfesie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctrlValidareAnulareProfesie.Name = "ctrlValidareAnulareProfesie";
            this.ctrlValidareAnulareProfesie.Size = new System.Drawing.Size(234, 30);
            this.ctrlValidareAnulareProfesie.TabIndex = 3;
            // 
            // FormAdaugareInLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 188);
            this.Controls.Add(this.ctrlValidareAnulareProfesie);
            this.Controls.Add(this.ctrlAdaugareInListaProfesie);
            this.Name = "FormAdaugareInLista";
            this.Text = "FormAdaugareInLista";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.ctrlAdaugareInListaProfesie, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulareProfesie, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlAdaugareInLista ctrlAdaugareInListaProfesie;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulareProfesie;
    }
}