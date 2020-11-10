namespace iStomaLab.Generale
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.panelPersonalizatLogin = new CCL.UI.PanelPersonalizat(this.components);
            this.lblMinimalizeazaLogin = new CCL.UI.LabelPersonalizat(this.components);
            this.chkPastreazaUserLogat = new CCL.UI.CheckBoxPersonalizat(this.components);
            this.lblParola = new CCL.UI.LabelPersonalizat(this.components);
            this.lblContUtilizator = new CCL.UI.LabelPersonalizat(this.components);
            this.txtBoxParolaUtilizator = new CCL.UI.TextBoxPersonalizat(this.components);
            this.txtBoxContUtilizator = new CCL.UI.TextBoxPersonalizat(this.components);
            this.controlValidareAnulareLogin = new CCL.UI.Caramizi.controlValidareAnulare();
            this.pctBoxLogin = new CCL.UI.PictureBoxPersonalizat(this.components);
            this.panelPersonalizatLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPersonalizatLogin
            // 
            this.panelPersonalizatLogin.AllowDrop = true;
            this.panelPersonalizatLogin.BackColor = System.Drawing.Color.White;
            this.panelPersonalizatLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPersonalizatLogin.Controls.Add(this.lblMinimalizeazaLogin);
            this.panelPersonalizatLogin.Controls.Add(this.chkPastreazaUserLogat);
            this.panelPersonalizatLogin.Controls.Add(this.lblParola);
            this.panelPersonalizatLogin.Controls.Add(this.lblContUtilizator);
            this.panelPersonalizatLogin.Controls.Add(this.txtBoxParolaUtilizator);
            this.panelPersonalizatLogin.Controls.Add(this.txtBoxContUtilizator);
            this.panelPersonalizatLogin.Controls.Add(this.controlValidareAnulareLogin);
            this.panelPersonalizatLogin.Controls.Add(this.pctBoxLogin);
            this.panelPersonalizatLogin.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.panelPersonalizatLogin, "panelPersonalizatLogin");
            this.panelPersonalizatLogin.Name = "panelPersonalizatLogin";
            this.panelPersonalizatLogin.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // lblMinimalizeazaLogin
            // 
            resources.ApplyResources(this.lblMinimalizeazaLogin, "lblMinimalizeazaLogin");
            this.lblMinimalizeazaLogin.ForeColor = System.Drawing.Color.Black;
            this.lblMinimalizeazaLogin.Name = "lblMinimalizeazaLogin";
            this.lblMinimalizeazaLogin.ToolTipText = null;
            this.lblMinimalizeazaLogin.ToolTipTitle = null;
            // 
            // chkPastreazaUserLogat
            // 
            resources.ApplyResources(this.chkPastreazaUserLogat, "chkPastreazaUserLogat");
            this.chkPastreazaUserLogat.BackColor = System.Drawing.Color.White;
            this.chkPastreazaUserLogat.Checked = true;
            this.chkPastreazaUserLogat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPastreazaUserLogat.ForeColor = System.Drawing.Color.Black;
            this.chkPastreazaUserLogat.IsInReadOnlyMode = false;
            this.chkPastreazaUserLogat.Name = "chkPastreazaUserLogat";
            this.chkPastreazaUserLogat.ProprietateCorespunzatoare = null;
            this.chkPastreazaUserLogat.UseVisualStyleBackColor = false;
            // 
            // lblParola
            // 
            resources.ApplyResources(this.lblParola, "lblParola");
            this.lblParola.BackColor = System.Drawing.Color.Transparent;
            this.lblParola.ForeColor = System.Drawing.Color.Black;
            this.lblParola.Name = "lblParola";
            this.lblParola.ToolTipText = null;
            this.lblParola.ToolTipTitle = null;
            // 
            // lblContUtilizator
            // 
            resources.ApplyResources(this.lblContUtilizator, "lblContUtilizator");
            this.lblContUtilizator.ForeColor = System.Drawing.Color.Black;
            this.lblContUtilizator.Name = "lblContUtilizator";
            this.lblContUtilizator.ToolTipText = null;
            this.lblContUtilizator.ToolTipTitle = null;
            // 
            // txtBoxParolaUtilizator
            // 
            resources.ApplyResources(this.txtBoxParolaUtilizator, "txtBoxParolaUtilizator");
            this.txtBoxParolaUtilizator.BackColor = System.Drawing.Color.White;
            this.txtBoxParolaUtilizator.CapitalizeazaPrimaLitera = false;
            this.txtBoxParolaUtilizator.ForeColor = System.Drawing.Color.Black;
            this.txtBoxParolaUtilizator.IsInReadOnlyMode = false;
            this.txtBoxParolaUtilizator.Name = "txtBoxParolaUtilizator";
            this.txtBoxParolaUtilizator.ProprietateCorespunzatoare = null;
            this.txtBoxParolaUtilizator.RaiseEventLaModificareProgramatica = false;
            this.txtBoxParolaUtilizator.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtBoxParolaUtilizator.TotulCuMajuscule = false;
            this.txtBoxParolaUtilizator.UseSystemPasswordChar = true;
            // 
            // txtBoxContUtilizator
            // 
            resources.ApplyResources(this.txtBoxContUtilizator, "txtBoxContUtilizator");
            this.txtBoxContUtilizator.CapitalizeazaPrimaLitera = false;
            this.txtBoxContUtilizator.ForeColor = System.Drawing.Color.Black;
            this.txtBoxContUtilizator.IsInReadOnlyMode = false;
            this.txtBoxContUtilizator.Name = "txtBoxContUtilizator";
            this.txtBoxContUtilizator.ProprietateCorespunzatoare = null;
            this.txtBoxContUtilizator.RaiseEventLaModificareProgramatica = false;
            this.txtBoxContUtilizator.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtBoxContUtilizator.TotulCuMajuscule = false;
            // 
            // controlValidareAnulareLogin
            // 
            resources.ApplyResources(this.controlValidareAnulareLogin, "controlValidareAnulareLogin");
            this.controlValidareAnulareLogin.BackColor = System.Drawing.Color.White;
            this.controlValidareAnulareLogin.ForeColor = System.Drawing.Color.Transparent;
            this.controlValidareAnulareLogin.Name = "controlValidareAnulareLogin";
            // 
            // pctBoxLogin
            // 
            resources.ApplyResources(this.pctBoxLogin, "pctBoxLogin");
            this.pctBoxLogin.ContinutToolTip = null;
            this.pctBoxLogin.IcoanaToolTip = System.Windows.Forms.ToolTipIcon.Info;
            this.pctBoxLogin.Name = "pctBoxLogin";
            this.pctBoxLogin.TabStop = false;
            this.pctBoxLogin.TitluToolTip = "";
            this.pctBoxLogin.UtilizamToolTip = false;
            // 
            // FormLogin
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.panelPersonalizatLogin);
            this.ForeColor = System.Drawing.Color.DimGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogin";
            this.TransparencyKey = System.Drawing.Color.DimGray;
            this.panelPersonalizatLogin.ResumeLayout(false);
            this.panelPersonalizatLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxLogin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.Caramizi.controlValidareAnulare controlValidareAnulareLogin;
        private CCL.UI.PanelPersonalizat panelPersonalizatLogin;
        private CCL.UI.LabelPersonalizat lblContUtilizator;
        private CCL.UI.LabelPersonalizat lblParola;
        private CCL.UI.TextBoxPersonalizat txtBoxParolaUtilizator;
        private CCL.UI.TextBoxPersonalizat txtBoxContUtilizator;
        private CCL.UI.PictureBoxPersonalizat pctBoxLogin;
        private CCL.UI.CheckBoxPersonalizat chkPastreazaUserLogat;
        private CCL.UI.LabelPersonalizat lblMinimalizeazaLogin;
    }
}