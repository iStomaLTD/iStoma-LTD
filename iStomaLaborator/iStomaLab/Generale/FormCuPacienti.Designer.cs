using BLL.iStomaLab.Clienti;

namespace iStomaLab.Generale
{
    partial class FormCuPacienti
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
            this.ctrlListaPacienti = new iStomaLab.Setari.Liste.Pacienti.ControlListaPacienti(this.lClient);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitluEcran.Size = new System.Drawing.Size(585, 19);
            this.lblTitluEcran.Text = "FormLocatie";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(585, 0);
            this.btnInchidereEcran.Margin = new System.Windows.Forms.Padding(2);
            // 
            // ctrlListaPacienti
            // 
            this.ctrlListaPacienti.Location = new System.Drawing.Point(6, 23);
            this.ctrlListaPacienti.Name = "ctrlListaPacienti";
            this.ctrlListaPacienti.Size = new System.Drawing.Size(593, 352);
            this.ctrlListaPacienti.TabIndex = 2;
          
            // FormCuPacienti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 379);
            this.Controls.Add(this.label1);
//            this.Controls.Add(this.ctrlListaPacienti);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormCuPacienti";
            this.Text = "FormLocatie";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
//            this.Controls.SetChildIndex(this.ctrlListaPacienti, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private Setari.Liste.Pacienti.ControlListaPacienti ctrlListaPacienti;
        private System.Windows.Forms.Label label1;
    }
}