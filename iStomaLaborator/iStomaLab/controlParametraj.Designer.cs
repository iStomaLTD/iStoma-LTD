using CDL.iStomaLab;

namespace iStomaLab
{
    partial class controlParametraj
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(controlParametraj));
            this.lblMesajPrincipal = new System.Windows.Forms.Label();
            this.lblEtapa = new System.Windows.Forms.Label();
            this.bwVerifica = new System.ComponentModel.BackgroundWorker();
            this.panelLicenta = new System.Windows.Forms.Panel();
            this.lnkTsC = new System.Windows.Forms.LinkLabel();
            this.chkAcceptaTermeniiSiConditiile = new System.Windows.Forms.CheckBox();
            this.txtLicenta = new System.Windows.Forms.TextBox();
            this.txtParola = new System.Windows.Forms.TextBox();
            this.txtCodClient = new System.Windows.Forms.TextBox();
            this.lblLicenta = new System.Windows.Forms.Label();
            this.lblParola = new System.Windows.Forms.Label();
            this.lblCodClient = new System.Windows.Forms.Label();
            this.panelBDD = new System.Windows.Forms.Panel();
            this.chkServerulEstePeAcestCalculator = new System.Windows.Forms.CheckBox();
            this.txtServerManual = new System.Windows.Forms.TextBox();
            this.lblServerManual = new System.Windows.Forms.Label();
            this.btnAdaugaBDD = new CCL.UI.ButtonPersonalizat(this.components);
            this.cboListaServere = new System.Windows.Forms.ComboBox();
            this.txtNumeInstantaSQL = new System.Windows.Forms.TextBox();
            this.lblInstantaSQL = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.cboBDD = new System.Windows.Forms.ComboBox();
            this.lblBDD = new System.Windows.Forms.Label();
            this.lblUserSQL = new System.Windows.Forms.Label();
            this.txtParolaSQL = new System.Windows.Forms.TextBox();
            this.lblParolaSQL = new System.Windows.Forms.Label();
            this.txtUserSQL = new System.Windows.Forms.TextBox();
            this.bwBDD = new System.ComponentModel.BackgroundWorker();
            this.pbAvans = new System.Windows.Forms.ProgressBar();
            this.panelDocumente = new System.Windows.Forms.Panel();
            this.btnAlegeFolder = new CCL.UI.ButtonPersonalizat(this.components);
            this.txtCaleSalvareDocumente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fbdAlegeFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.picAsteptare = new CCL.UI.PictureBoxPersonalizat(this.components);
            this.btnAnulare = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnActivare = new CCL.UI.ButtonPersonalizat(this.components);
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.panelLicenta.SuspendLayout();
            this.panelBDD.SuspendLayout();
            this.panelDocumente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAsteptare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMesajPrincipal
            // 
            this.lblMesajPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.lblMesajPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMesajPrincipal.ForeColor = System.Drawing.Color.Black;
            this.lblMesajPrincipal.Location = new System.Drawing.Point(207, 4);
            this.lblMesajPrincipal.Name = "lblMesajPrincipal";
            this.lblMesajPrincipal.Size = new System.Drawing.Size(328, 38);
            this.lblMesajPrincipal.TabIndex = 0;
            this.lblMesajPrincipal.Text = "Vă mulțumim pentru alegerea făcută";
            this.lblMesajPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEtapa
            // 
            this.lblEtapa.BackColor = System.Drawing.Color.Transparent;
            this.lblEtapa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblEtapa.ForeColor = System.Drawing.Color.Black;
            this.lblEtapa.Location = new System.Drawing.Point(207, 77);
            this.lblEtapa.Name = "lblEtapa";
            this.lblEtapa.Size = new System.Drawing.Size(328, 41);
            this.lblEtapa.TabIndex = 1;
            this.lblEtapa.Text = "Activare licență";
            this.lblEtapa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bwVerifica
            // 
            this.bwVerifica.WorkerReportsProgress = true;
            this.bwVerifica.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwVerifica_DoWork);
            this.bwVerifica.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwVerifica_ProgressChanged);
            this.bwVerifica.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwVerifica_RunWorkerCompleted);
            // 
            // panelLicenta
            // 
            this.panelLicenta.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelLicenta.Controls.Add(this.lnkTsC);
            this.panelLicenta.Controls.Add(this.chkAcceptaTermeniiSiConditiile);
            this.panelLicenta.Controls.Add(this.txtLicenta);
            this.panelLicenta.Controls.Add(this.txtParola);
            this.panelLicenta.Controls.Add(this.txtCodClient);
            this.panelLicenta.Controls.Add(this.lblLicenta);
            this.panelLicenta.Controls.Add(this.lblParola);
            this.panelLicenta.Controls.Add(this.lblCodClient);
            this.panelLicenta.Location = new System.Drawing.Point(12, 155);
            this.panelLicenta.Name = "panelLicenta";
            this.panelLicenta.Size = new System.Drawing.Size(583, 224);
            this.panelLicenta.TabIndex = 4;
            // 
            // lnkTsC
            // 
            this.lnkTsC.AutoSize = true;
            this.lnkTsC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkTsC.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(194)))), ((int)(((byte)(54)))));
            this.lnkTsC.Location = new System.Drawing.Point(142, 143);
            this.lnkTsC.Name = "lnkTsC";
            this.lnkTsC.Size = new System.Drawing.Size(190, 17);
            this.lnkTsC.TabIndex = 6;
            this.lnkTsC.TabStop = true;
            this.lnkTsC.Text = "Consultă termenii și condițiile";
            this.lnkTsC.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(149)))), ((int)(((byte)(206)))));
            this.lnkTsC.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkTsC_LinkClicked);
            // 
            // chkAcceptaTermeniiSiConditiile
            // 
            this.chkAcceptaTermeniiSiConditiile.AutoSize = true;
            this.chkAcceptaTermeniiSiConditiile.Location = new System.Drawing.Point(140, 188);
            this.chkAcceptaTermeniiSiConditiile.Name = "chkAcceptaTermeniiSiConditiile";
            this.chkAcceptaTermeniiSiConditiile.Size = new System.Drawing.Size(153, 17);
            this.chkAcceptaTermeniiSiConditiile.TabIndex = 7;
            this.chkAcceptaTermeniiSiConditiile.Text = "Accept termenii și condițiile";
            this.chkAcceptaTermeniiSiConditiile.UseVisualStyleBackColor = true;
            // 
            // txtLicenta
            // 
            this.txtLicenta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLicenta.Location = new System.Drawing.Point(140, 86);
            this.txtLicenta.Name = "txtLicenta";
            this.txtLicenta.Size = new System.Drawing.Size(429, 20);
            this.txtLicenta.TabIndex = 5;
            // 
            // txtParola
            // 
            this.txtParola.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParola.Location = new System.Drawing.Point(140, 50);
            this.txtParola.Name = "txtParola";
            this.txtParola.Size = new System.Drawing.Size(429, 20);
            this.txtParola.TabIndex = 3;
            this.txtParola.UseSystemPasswordChar = true;
            // 
            // txtCodClient
            // 
            this.txtCodClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodClient.Location = new System.Drawing.Point(139, 13);
            this.txtCodClient.Name = "txtCodClient";
            this.txtCodClient.Size = new System.Drawing.Size(429, 20);
            this.txtCodClient.TabIndex = 1;
            // 
            // lblLicenta
            // 
            this.lblLicenta.AutoSize = true;
            this.lblLicenta.Location = new System.Drawing.Point(32, 90);
            this.lblLicenta.Name = "lblLicenta";
            this.lblLicenta.Size = new System.Drawing.Size(42, 13);
            this.lblLicenta.TabIndex = 4;
            this.lblLicenta.Text = "Licență";
            // 
            // lblParola
            // 
            this.lblParola.AutoSize = true;
            this.lblParola.Location = new System.Drawing.Point(32, 54);
            this.lblParola.Name = "lblParola";
            this.lblParola.Size = new System.Drawing.Size(37, 13);
            this.lblParola.TabIndex = 2;
            this.lblParola.Text = "Parolă";
            // 
            // lblCodClient
            // 
            this.lblCodClient.AutoSize = true;
            this.lblCodClient.Location = new System.Drawing.Point(32, 17);
            this.lblCodClient.Name = "lblCodClient";
            this.lblCodClient.Size = new System.Drawing.Size(54, 13);
            this.lblCodClient.TabIndex = 0;
            this.lblCodClient.Text = "Cod client";
            // 
            // panelBDD
            // 
            this.panelBDD.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelBDD.Controls.Add(this.chkServerulEstePeAcestCalculator);
            this.panelBDD.Controls.Add(this.txtServerManual);
            this.panelBDD.Controls.Add(this.lblServerManual);
            this.panelBDD.Controls.Add(this.btnAdaugaBDD);
            this.panelBDD.Controls.Add(this.cboListaServere);
            this.panelBDD.Controls.Add(this.txtNumeInstantaSQL);
            this.panelBDD.Controls.Add(this.lblInstantaSQL);
            this.panelBDD.Controls.Add(this.lblServer);
            this.panelBDD.Controls.Add(this.cboBDD);
            this.panelBDD.Controls.Add(this.lblBDD);
            this.panelBDD.Controls.Add(this.lblUserSQL);
            this.panelBDD.Controls.Add(this.txtParolaSQL);
            this.panelBDD.Controls.Add(this.lblParolaSQL);
            this.panelBDD.Controls.Add(this.txtUserSQL);
            this.panelBDD.Location = new System.Drawing.Point(12, 155);
            this.panelBDD.Name = "panelBDD";
            this.panelBDD.Size = new System.Drawing.Size(583, 224);
            this.panelBDD.TabIndex = 5;
            // 
            // chkServerulEstePeAcestCalculator
            // 
            this.chkServerulEstePeAcestCalculator.AutoSize = true;
            this.chkServerulEstePeAcestCalculator.Location = new System.Drawing.Point(339, 10);
            this.chkServerulEstePeAcestCalculator.Name = "chkServerulEstePeAcestCalculator";
            this.chkServerulEstePeAcestCalculator.Size = new System.Drawing.Size(181, 17);
            this.chkServerulEstePeAcestCalculator.TabIndex = 13;
            this.chkServerulEstePeAcestCalculator.Text = "Serverul este pe acest calculator";
            this.chkServerulEstePeAcestCalculator.UseVisualStyleBackColor = true;
            this.chkServerulEstePeAcestCalculator.CheckedChanged += new System.EventHandler(this.chkServerulEstePeAcestCalculator_CheckedChanged);
            // 
            // txtServerManual
            // 
            this.txtServerManual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerManual.Location = new System.Drawing.Point(273, 38);
            this.txtServerManual.Name = "txtServerManual";
            this.txtServerManual.Size = new System.Drawing.Size(249, 20);
            this.txtServerManual.TabIndex = 3;
            this.txtServerManual.Validated += new System.EventHandler(this.txtServerManual_Validated);
            // 
            // lblServerManual
            // 
            this.lblServerManual.AutoSize = true;
            this.lblServerManual.Location = new System.Drawing.Point(161, 42);
            this.lblServerManual.Name = "lblServerManual";
            this.lblServerManual.Size = new System.Drawing.Size(38, 13);
            this.lblServerManual.TabIndex = 2;
            this.lblServerManual.Text = "Server";
            // 
            // btnAdaugaBDD
            // 
            this.btnAdaugaBDD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdaugaBDD.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdaugaBDD.Image = null;
            this.btnAdaugaBDD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdaugaBDD.Location = new System.Drawing.Point(161, 192);
            this.btnAdaugaBDD.Name = "btnAdaugaBDD";
            this.btnAdaugaBDD.Size = new System.Drawing.Size(205, 23);
            this.btnAdaugaBDD.TabIndex = 12;
            this.btnAdaugaBDD.Text = "Creează BDD iStoma";
            this.btnAdaugaBDD.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnAdaugaBDD.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAdaugaBDD.UseVisualStyleBackColor = true;
            this.btnAdaugaBDD.Click += new System.EventHandler(this.btnAdaugaBDD_Click);
            // 
            // cboListaServere
            // 
            this.cboListaServere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboListaServere.FormattingEnabled = true;
            this.cboListaServere.Location = new System.Drawing.Point(161, 8);
            this.cboListaServere.Name = "cboListaServere";
            this.cboListaServere.Size = new System.Drawing.Size(171, 21);
            this.cboListaServere.TabIndex = 1;
            this.cboListaServere.SelectedIndexChanged += new System.EventHandler(this.cboListaServere_SelectedIndexChanged);
            // 
            // txtNumeInstantaSQL
            // 
            this.txtNumeInstantaSQL.Location = new System.Drawing.Point(273, 67);
            this.txtNumeInstantaSQL.Name = "txtNumeInstantaSQL";
            this.txtNumeInstantaSQL.Size = new System.Drawing.Size(249, 20);
            this.txtNumeInstantaSQL.TabIndex = 5;
            this.txtNumeInstantaSQL.Validated += new System.EventHandler(this.txtNumeInstantaSQL_Validated);
            // 
            // lblInstantaSQL
            // 
            this.lblInstantaSQL.AutoSize = true;
            this.lblInstantaSQL.Location = new System.Drawing.Point(161, 71);
            this.lblInstantaSQL.Name = "lblInstantaSQL";
            this.lblInstantaSQL.Size = new System.Drawing.Size(99, 13);
            this.lblInstantaSQL.TabIndex = 4;
            this.lblInstantaSQL.Text = "Nume instanță SQL";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(46, 12);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(79, 13);
            this.lblServer.TabIndex = 0;
            this.lblServer.Text = "Alegeți serverul";
            // 
            // cboBDD
            // 
            this.cboBDD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBDD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBDD.FormattingEnabled = true;
            this.cboBDD.Location = new System.Drawing.Point(161, 159);
            this.cboBDD.Name = "cboBDD";
            this.cboBDD.Size = new System.Drawing.Size(361, 21);
            this.cboBDD.TabIndex = 11;
            // 
            // lblBDD
            // 
            this.lblBDD.AutoSize = true;
            this.lblBDD.Location = new System.Drawing.Point(46, 162);
            this.lblBDD.Name = "lblBDD";
            this.lblBDD.Size = new System.Drawing.Size(104, 13);
            this.lblBDD.TabIndex = 10;
            this.lblBDD.Text = "Alegeți baza de date";
            // 
            // lblUserSQL
            // 
            this.lblUserSQL.AutoSize = true;
            this.lblUserSQL.Location = new System.Drawing.Point(161, 96);
            this.lblUserSQL.Name = "lblUserSQL";
            this.lblUserSQL.Size = new System.Drawing.Size(53, 13);
            this.lblUserSQL.TabIndex = 6;
            this.lblUserSQL.Text = "User SQL";
            // 
            // txtParolaSQL
            // 
            this.txtParolaSQL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParolaSQL.Location = new System.Drawing.Point(273, 125);
            this.txtParolaSQL.Name = "txtParolaSQL";
            this.txtParolaSQL.Size = new System.Drawing.Size(249, 20);
            this.txtParolaSQL.TabIndex = 9;
            this.txtParolaSQL.UseSystemPasswordChar = true;
            this.txtParolaSQL.Validated += new System.EventHandler(this.txtParolaSQL_Validated);
            // 
            // lblParolaSQL
            // 
            this.lblParolaSQL.AutoSize = true;
            this.lblParolaSQL.Location = new System.Drawing.Point(161, 125);
            this.lblParolaSQL.Name = "lblParolaSQL";
            this.lblParolaSQL.Size = new System.Drawing.Size(37, 13);
            this.lblParolaSQL.TabIndex = 8;
            this.lblParolaSQL.Text = "Parolă";
            // 
            // txtUserSQL
            // 
            this.txtUserSQL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserSQL.Location = new System.Drawing.Point(273, 96);
            this.txtUserSQL.Name = "txtUserSQL";
            this.txtUserSQL.Size = new System.Drawing.Size(249, 20);
            this.txtUserSQL.TabIndex = 7;
            this.txtUserSQL.Validated += new System.EventHandler(this.txtUserSQL_Validated);
            // 
            // bwBDD
            // 
            this.bwBDD.WorkerReportsProgress = true;
            this.bwBDD.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwBDD_DoWork);
            this.bwBDD.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwBDD_ProgressChanged);
            this.bwBDD.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwBDD_RunWorkerCompleted);
            // 
            // pbAvans
            // 
            this.pbAvans.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbAvans.Location = new System.Drawing.Point(219, 122);
            this.pbAvans.Name = "pbAvans";
            this.pbAvans.Size = new System.Drawing.Size(293, 17);
            this.pbAvans.Step = 1;
            this.pbAvans.TabIndex = 2;
            // 
            // panelDocumente
            // 
            this.panelDocumente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelDocumente.Controls.Add(this.btnAlegeFolder);
            this.panelDocumente.Controls.Add(this.txtCaleSalvareDocumente);
            this.panelDocumente.Controls.Add(this.label1);
            this.panelDocumente.Location = new System.Drawing.Point(12, 155);
            this.panelDocumente.Name = "panelDocumente";
            this.panelDocumente.Size = new System.Drawing.Size(583, 224);
            this.panelDocumente.TabIndex = 18;
            this.panelDocumente.Visible = false;
            // 
            // btnAlegeFolder
            // 
            this.btnAlegeFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlegeFolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAlegeFolder.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAlegeFolder.Image = null;
            this.btnAlegeFolder.Location = new System.Drawing.Point(541, 10);
            this.btnAlegeFolder.Name = "btnAlegeFolder";
            this.btnAlegeFolder.Size = new System.Drawing.Size(34, 23);
            this.btnAlegeFolder.TabIndex = 2;
            this.btnAlegeFolder.Text = "...";
            this.btnAlegeFolder.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Cautare;
            this.btnAlegeFolder.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAlegeFolder.UseVisualStyleBackColor = true;
            this.btnAlegeFolder.Click += new System.EventHandler(this.btnAlegeFolder_Click);
            // 
            // txtCaleSalvareDocumente
            // 
            this.txtCaleSalvareDocumente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCaleSalvareDocumente.Enabled = false;
            this.txtCaleSalvareDocumente.Location = new System.Drawing.Point(164, 12);
            this.txtCaleSalvareDocumente.Name = "txtCaleSalvareDocumente";
            this.txtCaleSalvareDocumente.Size = new System.Drawing.Size(371, 20);
            this.txtCaleSalvareDocumente.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cale salvare documente";
            // 
            // fbdAlegeFolder
            // 
            this.fbdAlegeFolder.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // picAsteptare
            // 
            this.picAsteptare.BackColor = System.Drawing.Color.Transparent;
            this.picAsteptare.ContinutToolTip = null;
            this.picAsteptare.IcoanaToolTip = System.Windows.Forms.ToolTipIcon.Info;
            this.picAsteptare.Image = global::iStomaLab.Properties.Resources.waiting;
            this.picAsteptare.Location = new System.Drawing.Point(359, 46);
            this.picAsteptare.Name = "picAsteptare";
            this.picAsteptare.Size = new System.Drawing.Size(27, 27);
            this.picAsteptare.TabIndex = 2;
            this.picAsteptare.TabStop = false;
            this.picAsteptare.TitluToolTip = "";
            this.picAsteptare.UtilizamToolTip = false;
            // 
            // btnAnulare
            // 
            this.btnAnulare.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAnulare.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAnulare.Image = ((System.Drawing.Image)(resources.GetObject("btnAnulare.Image")));
            this.btnAnulare.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnulare.Location = new System.Drawing.Point(316, 387);
            this.btnAnulare.Name = "btnAnulare";
            this.btnAnulare.Size = new System.Drawing.Size(119, 23);
            this.btnAnulare.TabIndex = 0;
            this.btnAnulare.Text = "Anulare";
            this.btnAnulare.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Anulare;
            this.btnAnulare.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnAnulare.UseVisualStyleBackColor = true;
            this.btnAnulare.Click += new System.EventHandler(this.btnAnulare_Click);
            // 
            // btnActivare
            // 
            this.btnActivare.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnActivare.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnActivare.Image = ((System.Drawing.Image)(resources.GetObject("btnActivare.Image")));
            this.btnActivare.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActivare.Location = new System.Drawing.Point(191, 387);
            this.btnActivare.Name = "btnActivare";
            this.btnActivare.Size = new System.Drawing.Size(119, 23);
            this.btnActivare.TabIndex = 6;
            this.btnActivare.Text = "Activare";
            this.btnActivare.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Validare;
            this.btnActivare.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnActivare.UseVisualStyleBackColor = true;
            this.btnActivare.Click += new System.EventHandler(this.btnActivare_Click);
            // 
            // picLogo
            // 
            this.picLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLogo.Image = global::iStomaLab.Properties.Resources.logo_mar___iStoma;
            this.picLogo.Location = new System.Drawing.Point(9, 5);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(133, 141);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 15;
            this.picLogo.TabStop = false;
            this.picLogo.Click += new System.EventHandler(this.picLogo_Click);
            // 
            // controlParametraj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(607, 420);
            this.Controls.Add(this.pbAvans);
            this.Controls.Add(this.lblEtapa);
            this.Controls.Add(this.lblMesajPrincipal);
            this.Controls.Add(this.picAsteptare);
            this.Controls.Add(this.btnAnulare);
            this.Controls.Add(this.btnActivare);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.panelLicenta);
            this.Controls.Add(this.panelDocumente);
            this.Controls.Add(this.panelBDD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "controlParametraj";
            this.ShowIcon = false;
            this.ShowInTaskbar = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iStoma LTD";
            this.Load += new System.EventHandler(this.frmActivare_Load);
            this.panelLicenta.ResumeLayout(false);
            this.panelLicenta.PerformLayout();
            this.panelBDD.ResumeLayout(false);
            this.panelBDD.PerformLayout();
            this.panelDocumente.ResumeLayout(false);
            this.panelDocumente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAsteptare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.ButtonPersonalizat btnActivare;
        private CCL.UI.ButtonPersonalizat btnAnulare;
        private CCL.UI.PictureBoxPersonalizat picAsteptare;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblUserSQL;
        private System.Windows.Forms.Label lblParolaSQL;
        private System.Windows.Forms.TextBox txtUserSQL;
        private System.Windows.Forms.TextBox txtParolaSQL;
        private System.Windows.Forms.Label lblBDD;
        private System.Windows.Forms.ComboBox cboBDD;
        private System.Windows.Forms.TextBox txtLicenta;
        private System.Windows.Forms.TextBox txtParola;
        private System.Windows.Forms.TextBox txtCodClient;
        private System.Windows.Forms.Label lblLicenta;
        private System.Windows.Forms.Label lblParola;
        private System.Windows.Forms.Label lblCodClient;
        private System.Windows.Forms.Label lblMesajPrincipal;
        private System.Windows.Forms.LinkLabel lnkTsC;
        private System.Windows.Forms.CheckBox chkAcceptaTermeniiSiConditiile;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblEtapa;
        private System.ComponentModel.BackgroundWorker bwVerifica;
        private System.Windows.Forms.Label lblInstantaSQL;
        private System.Windows.Forms.TextBox txtNumeInstantaSQL;
        private System.Windows.Forms.ComboBox cboListaServere;
        private System.Windows.Forms.Panel panelBDD;
        private System.Windows.Forms.Panel panelLicenta;
        private CCL.UI.ButtonPersonalizat btnAdaugaBDD;
        private System.ComponentModel.BackgroundWorker bwBDD;
        private System.Windows.Forms.TextBox txtServerManual;
        private System.Windows.Forms.Label lblServerManual;
        private System.Windows.Forms.ProgressBar pbAvans;
        private System.Windows.Forms.Panel panelDocumente;
        private CCL.UI.ButtonPersonalizat btnAlegeFolder;
        private System.Windows.Forms.TextBox txtCaleSalvareDocumente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog fbdAlegeFolder;
        private System.Windows.Forms.CheckBox chkServerulEstePeAcestCalculator;
    }
}