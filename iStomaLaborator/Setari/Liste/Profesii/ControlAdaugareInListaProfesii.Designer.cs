namespace iStomaLab.Setari.Liste
{
    partial class ControlAdaugareInLista
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
            this.lblDenumireProfesie = new CCL.UI.LabelPersonalizat(this.components);
            this.lblCodCorProfesie = new CCL.UI.LabelPersonalizat(this.components);
            this.txtDenumireProfesie = new CCL.UI.TextBoxPersonalizat(this.components);
            this.txtCodCorProfesie = new CCL.UI.TextBoxPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // lblDenumireProfesie
            // 
            this.lblDenumireProfesie.AutoSize = true;
            this.lblDenumireProfesie.Location = new System.Drawing.Point(19, 21);
            this.lblDenumireProfesie.Name = "lblDenumireProfesie";
            this.lblDenumireProfesie.Size = new System.Drawing.Size(69, 17);
            this.lblDenumireProfesie.TabIndex = 0;
            this.lblDenumireProfesie.Text = "Denumire";
            this.lblDenumireProfesie.ToolTipText = null;
            this.lblDenumireProfesie.ToolTipTitle = null;
            // 
            // lblCodCorProfesie
            // 
            this.lblCodCorProfesie.AutoSize = true;
            this.lblCodCorProfesie.Location = new System.Drawing.Point(19, 58);
            this.lblCodCorProfesie.Name = "lblCodCorProfesie";
            this.lblCodCorProfesie.Size = new System.Drawing.Size(67, 17);
            this.lblCodCorProfesie.TabIndex = 1;
            this.lblCodCorProfesie.Text = "Cod COR";
            this.lblCodCorProfesie.ToolTipText = null;
            this.lblCodCorProfesie.ToolTipTitle = null;
            // 
            // txtDenumireProfesie
            // 
            this.txtDenumireProfesie.CapitalizeazaPrimaLitera = false;
            this.txtDenumireProfesie.IsInReadOnlyMode = false;
            this.txtDenumireProfesie.Location = new System.Drawing.Point(119, 21);
            this.txtDenumireProfesie.Name = "txtDenumireProfesie";
            this.txtDenumireProfesie.ProprietateCorespunzatoare = null;
            this.txtDenumireProfesie.RaiseEventLaModificareProgramatica = false;
            this.txtDenumireProfesie.Size = new System.Drawing.Size(397, 22);
            this.txtDenumireProfesie.TabIndex = 2;
            this.txtDenumireProfesie.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtDenumireProfesie.TotulCuMajuscule = false;
            // 
            // txtCodCorProfesie
            // 
            this.txtCodCorProfesie.CapitalizeazaPrimaLitera = false;
            this.txtCodCorProfesie.IsInReadOnlyMode = false;
            this.txtCodCorProfesie.Location = new System.Drawing.Point(119, 58);
            this.txtCodCorProfesie.Name = "txtCodCorProfesie";
            this.txtCodCorProfesie.ProprietateCorespunzatoare = null;
            this.txtCodCorProfesie.RaiseEventLaModificareProgramatica = false;
            this.txtCodCorProfesie.Size = new System.Drawing.Size(397, 22);
            this.txtCodCorProfesie.TabIndex = 3;
            this.txtCodCorProfesie.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtCodCorProfesie.TotulCuMajuscule = false;
            // 
            // ControlAdaugareInLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCodCorProfesie);
            this.Controls.Add(this.txtDenumireProfesie);
            this.Controls.Add(this.lblCodCorProfesie);
            this.Controls.Add(this.lblDenumireProfesie);
            this.Name = "ControlAdaugareInLista";
            this.Size = new System.Drawing.Size(535, 109);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.LabelPersonalizat lblDenumireProfesie;
        private CCL.UI.LabelPersonalizat lblCodCorProfesie;
        private CCL.UI.TextBoxPersonalizat txtDenumireProfesie;
        private CCL.UI.TextBoxPersonalizat txtCodCorProfesie;
    }
}
