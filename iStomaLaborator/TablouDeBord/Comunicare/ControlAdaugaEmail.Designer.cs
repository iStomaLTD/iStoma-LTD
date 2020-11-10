namespace iStomaLab.TablouDeBord.Email
{
    partial class ControlAdaugaEmail
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
            this.lblEmail = new CCL.UI.LabelPersonalizat(this.components);
            this.lblParola = new CCL.UI.LabelPersonalizat(this.components);
            this.txtEmail = new CCL.UI.TextBoxPersonalizat(this.components);
            this.txtParola = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblUser = new CCL.UI.LabelPersonalizat(this.components);
            this.txtUser = new CCL.UI.TextBoxPersonalizat(this.components);
            this.lblInfoEmail = new CCL.UI.LabelPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(15, 13);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email";
            this.lblEmail.ToolTipText = null;
            this.lblEmail.ToolTipTitle = null;
            // 
            // lblParola
            // 
            this.lblParola.AutoSize = true;
            this.lblParola.Location = new System.Drawing.Point(15, 45);
            this.lblParola.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblParola.Name = "lblParola";
            this.lblParola.Size = new System.Drawing.Size(37, 13);
            this.lblParola.TabIndex = 3;
            this.lblParola.Text = "Parola";
            this.lblParola.ToolTipText = null;
            this.lblParola.ToolTipTitle = null;
            // 
            // txtEmail
            // 
            this.txtEmail.CapitalizeazaPrimaLitera = false;
            this.txtEmail.IsInReadOnlyMode = false;
            this.txtEmail.Location = new System.Drawing.Point(68, 13);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ProprietateCorespunzatoare = null;
            this.txtEmail.RaiseEventLaModificareProgramatica = false;
            this.txtEmail.Size = new System.Drawing.Size(247, 20);
            this.txtEmail.TabIndex = 6;
            this.txtEmail.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtEmail.TotulCuMajuscule = false;
            // 
            // txtParola
            // 
            this.txtParola.CapitalizeazaPrimaLitera = false;
            this.txtParola.IsInReadOnlyMode = false;
            this.txtParola.Location = new System.Drawing.Point(68, 45);
            this.txtParola.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtParola.Name = "txtParola";
            this.txtParola.ProprietateCorespunzatoare = null;
            this.txtParola.RaiseEventLaModificareProgramatica = false;
            this.txtParola.Size = new System.Drawing.Size(247, 20);
            this.txtParola.TabIndex = 7;
            this.txtParola.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtParola.TotulCuMajuscule = false;
            this.txtParola.UseSystemPasswordChar = true;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(17, 79);
            this.lblUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(29, 13);
            this.lblUser.TabIndex = 20;
            this.lblUser.Text = "User";
            this.lblUser.ToolTipText = null;
            this.lblUser.ToolTipTitle = null;
            // 
            // txtUser
            // 
            this.txtUser.CapitalizeazaPrimaLitera = false;
            this.txtUser.IsInReadOnlyMode = false;
            this.txtUser.Location = new System.Drawing.Point(68, 79);
            this.txtUser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUser.Name = "txtUser";
            this.txtUser.ProprietateCorespunzatoare = null;
            this.txtUser.RaiseEventLaModificareProgramatica = false;
            this.txtUser.Size = new System.Drawing.Size(247, 20);
            this.txtUser.TabIndex = 21;
            this.txtUser.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtUser.TotulCuMajuscule = false;
            // 
            // lblInfoEmail
            // 
            this.lblInfoEmail.AutoSize = true;
            this.lblInfoEmail.Location = new System.Drawing.Point(26, 111);
            this.lblInfoEmail.Name = "lblInfoEmail";
            this.lblInfoEmail.Size = new System.Drawing.Size(289, 13);
            this.lblInfoEmail.TabIndex = 22;
            this.lblInfoEmail.Text = "Pentru verificarea datelor veti primii automat un email de test";
            this.lblInfoEmail.ToolTipText = null;
            this.lblInfoEmail.ToolTipTitle = null;
            // 
            // ControlSetariEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblInfoEmail);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtParola);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblParola);
            this.Controls.Add(this.lblEmail);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ControlSetariEmail";
            this.Size = new System.Drawing.Size(334, 141);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CCL.UI.LabelPersonalizat lblEmail;
        private CCL.UI.LabelPersonalizat lblParola;
        private CCL.UI.TextBoxPersonalizat txtEmail;
        private CCL.UI.TextBoxPersonalizat txtParola;
        private CCL.UI.LabelPersonalizat lblUser;
        private CCL.UI.TextBoxPersonalizat txtUser;
        private CCL.UI.LabelPersonalizat lblInfoEmail;
    }
}
