using CDL.iStomaLab;
using System.Windows.Forms;

namespace iStomaLab
{
    partial class frmDespre
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
            this.panelGlobal = new CCL.UI.PanelPersonalizat(this.components);
            this.lnkCloud = new CCL.UI.LinkLabelPersonalizat(this.components);
            this.lnkPiataStomatologica = new CCL.UI.LinkLabelPersonalizat(this.components);
            this.btnOptimizeaza = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblLicenta = new CCL.UI.LabelPersonalizat(this.components);
            this.btnCheckForUpdates = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnSugestie = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblNumeCalculator = new CCL.UI.LabelPersonalizat(this.components);
            this.lnkIStomaLTD = new CCL.UI.LinkLabelPersonalizat(this.components);
            this.pictureBoxPersonalizat1 = new CCL.UI.PictureBoxPersonalizat(this.components);
            this.lblVersiuneBDD = new CCL.UI.LabelPersonalizat(this.components);
            this.lblVersiuneAplicatie = new CCL.UI.LabelPersonalizat(this.components);
            this.lblTitluVersiuneBDD = new CCL.UI.LabelPersonalizat(this.components);
            this.lblTitluVersiuneAplicatie = new CCL.UI.LabelPersonalizat(this.components);
            this.panelTelefoane = new CCL.UI.PanelPersonalizat(this.components);
            this.btnConsiliereJuridic = new CCL.UI.ButtonPersonalizat(this.components);
            this.lblMailJuridic = new CCL.UI.LabelPersonalizat(this.components);
            this.lblJuridic = new CCL.UI.LabelPersonalizat(this.components);
            this.lblTelMobilJuridic = new CCL.UI.LabelPersonalizat(this.components);
            this.labelPersonalizat2 = new CCL.UI.LabelPersonalizat(this.components);
            this.labelPersonalizat1 = new CCL.UI.LabelPersonalizat(this.components);
            this.lblMarketing = new CCL.UI.LabelPersonalizat(this.components);
            this.lblSuport = new CCL.UI.LabelPersonalizat(this.components);
            this.lblTelefonFeedBack = new CCL.UI.LabelPersonalizat(this.components);
            this.lblFeedBack = new CCL.UI.LabelPersonalizat(this.components);
            this.lblTelefonFixSuport = new CCL.UI.LabelPersonalizat(this.components);
            this.lblTelefonMobilSuport = new CCL.UI.LabelPersonalizat(this.components);
            this.wbNoutatiVersiune = new System.Windows.Forms.WebBrowser();
            this.ctrlValidareAnulare = new CCL.UI.Caramizi.controlValidareAnulare();
            this.panelGlobal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPersonalizat1)).BeginInit();
            this.panelTelefoane.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(901, 19);
            this.lblTitluEcran.TabIndex = 2;
            this.lblTitluEcran.Text = "Despre";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(900, 0);
            this.btnInchidereEcran.TabIndex = 0;
            // 
            // panelGlobal
            // 
            this.panelGlobal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelGlobal.BackColor = System.Drawing.Color.White;
            this.panelGlobal.Controls.Add(this.lnkCloud);
            this.panelGlobal.Controls.Add(this.lnkPiataStomatologica);
            this.panelGlobal.Controls.Add(this.btnOptimizeaza);
            this.panelGlobal.Controls.Add(this.lblLicenta);
            this.panelGlobal.Controls.Add(this.btnCheckForUpdates);
            this.panelGlobal.Controls.Add(this.btnSugestie);
            this.panelGlobal.Controls.Add(this.lblNumeCalculator);
            this.panelGlobal.Controls.Add(this.lnkIStomaLTD);
            this.panelGlobal.Controls.Add(this.pictureBoxPersonalizat1);
            this.panelGlobal.Controls.Add(this.lblVersiuneBDD);
            this.panelGlobal.Controls.Add(this.lblVersiuneAplicatie);
            this.panelGlobal.Controls.Add(this.lblTitluVersiuneBDD);
            this.panelGlobal.Controls.Add(this.lblTitluVersiuneAplicatie);
            this.panelGlobal.Controls.Add(this.panelTelefoane);
            this.panelGlobal.Location = new System.Drawing.Point(1, 19);
            this.panelGlobal.Name = "panelGlobal";
            this.panelGlobal.Size = new System.Drawing.Size(363, 540);
            this.panelGlobal.TabIndex = 1;
            this.panelGlobal.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // lnkCloud
            // 
            this.lnkCloud.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCloud.LinkColor = System.Drawing.Color.Green;
            this.lnkCloud.Location = new System.Drawing.Point(3, 98);
            this.lnkCloud.Name = "lnkCloud";
            this.lnkCloud.Size = new System.Drawing.Size(357, 31);
            this.lnkCloud.TabIndex = 20;
            this.lnkCloud.TabStop = true;
            this.lnkCloud.Text = "https://iStomaDemo.iDava.ro/";
            this.lnkCloud.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkCloud.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.lnkCloud.ToolTipMessage = "";
            this.lnkCloud.ToolTipTitle = "";
            // 
            // lnkPiataStomatologica
            // 
            this.lnkPiataStomatologica.AutoSize = true;
            this.lnkPiataStomatologica.LinkColor = System.Drawing.Color.Green;
            this.lnkPiataStomatologica.Location = new System.Drawing.Point(134, 52);
            this.lnkPiataStomatologica.Name = "lnkPiataStomatologica";
            this.lnkPiataStomatologica.Size = new System.Drawing.Size(137, 13);
            this.lnkPiataStomatologica.TabIndex = 19;
            this.lnkPiataStomatologica.TabStop = true;
            this.lnkPiataStomatologica.Text = "www.PiataStomatologica.ro";
            this.lnkPiataStomatologica.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.lnkPiataStomatologica.ToolTipMessage = "";
            this.lnkPiataStomatologica.ToolTipTitle = "";
            // 
            // btnOptimizeaza
            // 
            this.btnOptimizeaza.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOptimizeaza.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOptimizeaza.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnOptimizeaza.Image = null;
            this.btnOptimizeaza.Location = new System.Drawing.Point(67, 502);
            this.btnOptimizeaza.Name = "btnOptimizeaza";
            this.btnOptimizeaza.Size = new System.Drawing.Size(224, 27);
            this.btnOptimizeaza.TabIndex = 18;
            this.btnOptimizeaza.Text = "Optimizeaza";
            this.btnOptimizeaza.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnOptimizeaza.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnOptimizeaza.UseVisualStyleBackColor = true;
            // 
            // lblLicenta
            // 
            this.lblLicenta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLicenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblLicenta.Location = new System.Drawing.Point(3, 164);
            this.lblLicenta.Name = "lblLicenta";
            this.lblLicenta.Size = new System.Drawing.Size(357, 18);
            this.lblLicenta.TabIndex = 17;
            this.lblLicenta.Text = "LICENTA";
            this.lblLicenta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLicenta.ToolTipText = null;
            this.lblLicenta.ToolTipTitle = null;
            // 
            // btnCheckForUpdates
            // 
            this.btnCheckForUpdates.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCheckForUpdates.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCheckForUpdates.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnCheckForUpdates.Image = null;
            this.btnCheckForUpdates.Location = new System.Drawing.Point(67, 457);
            this.btnCheckForUpdates.Name = "btnCheckForUpdates";
            this.btnCheckForUpdates.Size = new System.Drawing.Size(224, 27);
            this.btnCheckForUpdates.TabIndex = 16;
            this.btnCheckForUpdates.Text = "Check for Updates";
            this.btnCheckForUpdates.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnCheckForUpdates.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnCheckForUpdates.UseVisualStyleBackColor = true;
            // 
            // btnSugestie
            // 
            this.btnSugestie.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSugestie.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSugestie.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnSugestie.Image = null;
            this.btnSugestie.Location = new System.Drawing.Point(67, 353);
            this.btnSugestie.Name = "btnSugestie";
            this.btnSugestie.Size = new System.Drawing.Size(224, 27);
            this.btnSugestie.TabIndex = 15;
            this.btnSugestie.Text = "M-as bucura daca ...";
            this.btnSugestie.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnSugestie.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnSugestie.UseVisualStyleBackColor = true;
            // 
            // lblNumeCalculator
            // 
            this.lblNumeCalculator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumeCalculator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNumeCalculator.Location = new System.Drawing.Point(3, 137);
            this.lblNumeCalculator.Name = "lblNumeCalculator";
            this.lblNumeCalculator.Size = new System.Drawing.Size(357, 18);
            this.lblNumeCalculator.TabIndex = 6;
            this.lblNumeCalculator.Text = "Nume calculator";
            this.lblNumeCalculator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNumeCalculator.ToolTipText = null;
            this.lblNumeCalculator.ToolTipTitle = null;
            // 
            // lnkIStomaLTD
            // 
            this.lnkIStomaLTD.AutoSize = true;
            this.lnkIStomaLTD.LinkColor = System.Drawing.Color.Green;
            this.lnkIStomaLTD.Location = new System.Drawing.Point(134, 22);
            this.lnkIStomaLTD.Name = "lnkIStomaLTD";
            this.lnkIStomaLTD.Size = new System.Drawing.Size(99, 13);
            this.lnkIStomaLTD.TabIndex = 0;
            this.lnkIStomaLTD.TabStop = true;
            this.lnkIStomaLTD.Text = "www.iStomaLTD.ro";
            this.lnkIStomaLTD.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.lnkIStomaLTD.ToolTipMessage = "";
            this.lnkIStomaLTD.ToolTipTitle = "";
            this.lnkIStomaLTD.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkIStoma_LinkClicked);
            // 
            // pictureBoxPersonalizat1
            // 
            this.pictureBoxPersonalizat1.ContinutToolTip = null;
            this.pictureBoxPersonalizat1.IcoanaToolTip = System.Windows.Forms.ToolTipIcon.Info;
            this.pictureBoxPersonalizat1.Image = global::iStomaLab.Properties.Resources.logo_mar___iStoma;
            this.pictureBoxPersonalizat1.Location = new System.Drawing.Point(5, 7);
            this.pictureBoxPersonalizat1.Name = "pictureBoxPersonalizat1";
            this.pictureBoxPersonalizat1.Size = new System.Drawing.Size(105, 72);
            this.pictureBoxPersonalizat1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPersonalizat1.TabIndex = 5;
            this.pictureBoxPersonalizat1.TabStop = false;
            this.pictureBoxPersonalizat1.TitluToolTip = "";
            this.pictureBoxPersonalizat1.UtilizamToolTip = false;
            // 
            // lblVersiuneBDD
            // 
            this.lblVersiuneBDD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVersiuneBDD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblVersiuneBDD.Location = new System.Drawing.Point(187, 420);
            this.lblVersiuneBDD.Name = "lblVersiuneBDD";
            this.lblVersiuneBDD.Size = new System.Drawing.Size(174, 20);
            this.lblVersiuneBDD.TabIndex = 4;
            this.lblVersiuneBDD.Text = "1.0.1";
            this.lblVersiuneBDD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVersiuneBDD.ToolTipText = null;
            this.lblVersiuneBDD.ToolTipTitle = null;
            // 
            // lblVersiuneAplicatie
            // 
            this.lblVersiuneAplicatie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVersiuneAplicatie.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblVersiuneAplicatie.Location = new System.Drawing.Point(7, 420);
            this.lblVersiuneAplicatie.Name = "lblVersiuneAplicatie";
            this.lblVersiuneAplicatie.Size = new System.Drawing.Size(157, 20);
            this.lblVersiuneAplicatie.TabIndex = 2;
            this.lblVersiuneAplicatie.Text = "1.0.1";
            this.lblVersiuneAplicatie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVersiuneAplicatie.ToolTipText = null;
            this.lblVersiuneAplicatie.ToolTipTitle = null;
            // 
            // lblTitluVersiuneBDD
            // 
            this.lblTitluVersiuneBDD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTitluVersiuneBDD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitluVersiuneBDD.Location = new System.Drawing.Point(186, 396);
            this.lblTitluVersiuneBDD.Name = "lblTitluVersiuneBDD";
            this.lblTitluVersiuneBDD.Size = new System.Drawing.Size(174, 20);
            this.lblTitluVersiuneBDD.TabIndex = 3;
            this.lblTitluVersiuneBDD.Text = "Versiune baza de date";
            this.lblTitluVersiuneBDD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitluVersiuneBDD.ToolTipText = null;
            this.lblTitluVersiuneBDD.ToolTipTitle = null;
            // 
            // lblTitluVersiuneAplicatie
            // 
            this.lblTitluVersiuneAplicatie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTitluVersiuneAplicatie.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitluVersiuneAplicatie.Location = new System.Drawing.Point(7, 396);
            this.lblTitluVersiuneAplicatie.Name = "lblTitluVersiuneAplicatie";
            this.lblTitluVersiuneAplicatie.Size = new System.Drawing.Size(157, 20);
            this.lblTitluVersiuneAplicatie.TabIndex = 1;
            this.lblTitluVersiuneAplicatie.Text = "Versiune aplicatie";
            this.lblTitluVersiuneAplicatie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitluVersiuneAplicatie.ToolTipText = null;
            this.lblTitluVersiuneAplicatie.ToolTipTitle = null;
            // 
            // panelTelefoane
            // 
            this.panelTelefoane.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTelefoane.BackColor = System.Drawing.Color.White;
            this.panelTelefoane.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTelefoane.Controls.Add(this.btnConsiliereJuridic);
            this.panelTelefoane.Controls.Add(this.lblMailJuridic);
            this.panelTelefoane.Controls.Add(this.lblJuridic);
            this.panelTelefoane.Controls.Add(this.lblTelMobilJuridic);
            this.panelTelefoane.Controls.Add(this.labelPersonalizat2);
            this.panelTelefoane.Controls.Add(this.labelPersonalizat1);
            this.panelTelefoane.Controls.Add(this.lblMarketing);
            this.panelTelefoane.Controls.Add(this.lblSuport);
            this.panelTelefoane.Controls.Add(this.lblTelefonFeedBack);
            this.panelTelefoane.Controls.Add(this.lblFeedBack);
            this.panelTelefoane.Controls.Add(this.lblTelefonFixSuport);
            this.panelTelefoane.Controls.Add(this.lblTelefonMobilSuport);
            this.panelTelefoane.Location = new System.Drawing.Point(-1, 185);
            this.panelTelefoane.Name = "panelTelefoane";
            this.panelTelefoane.Size = new System.Drawing.Size(365, 159);
            this.panelTelefoane.TabIndex = 14;
            this.panelTelefoane.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // btnConsiliereJuridic
            // 
            this.btnConsiliereJuridic.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnConsiliereJuridic.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnConsiliereJuridic.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnConsiliereJuridic.Image = null;
            this.btnConsiliereJuridic.Location = new System.Drawing.Point(194, 115);
            this.btnConsiliereJuridic.Name = "btnConsiliereJuridic";
            this.btnConsiliereJuridic.Size = new System.Drawing.Size(97, 27);
            this.btnConsiliereJuridic.TabIndex = 19;
            this.btnConsiliereJuridic.Text = "Consiliere";
            this.btnConsiliereJuridic.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnConsiliereJuridic.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnConsiliereJuridic.UseVisualStyleBackColor = true;
            // 
            // lblMailJuridic
            // 
            this.lblMailJuridic.AutoSize = true;
            this.lblMailJuridic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMailJuridic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMailJuridic.Location = new System.Drawing.Point(34, 133);
            this.lblMailJuridic.Name = "lblMailJuridic";
            this.lblMailJuridic.Size = new System.Drawing.Size(119, 17);
            this.lblMailJuridic.TabIndex = 18;
            this.lblMailJuridic.Text = "juridic@iStoma.ro";
            this.lblMailJuridic.ToolTipText = null;
            this.lblMailJuridic.ToolTipTitle = null;
            // 
            // lblJuridic
            // 
            this.lblJuridic.AutoSize = true;
            this.lblJuridic.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblJuridic.Location = new System.Drawing.Point(21, 83);
            this.lblJuridic.Name = "lblJuridic";
            this.lblJuridic.Size = new System.Drawing.Size(51, 18);
            this.lblJuridic.TabIndex = 16;
            this.lblJuridic.Text = "Juridic";
            this.lblJuridic.ToolTipText = null;
            this.lblJuridic.ToolTipTitle = null;
            // 
            // lblTelMobilJuridic
            // 
            this.lblTelMobilJuridic.AutoSize = true;
            this.lblTelMobilJuridic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTelMobilJuridic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTelMobilJuridic.Location = new System.Drawing.Point(34, 110);
            this.lblTelMobilJuridic.Name = "lblTelMobilJuridic";
            this.lblTelMobilJuridic.Size = new System.Drawing.Size(100, 17);
            this.lblTelMobilJuridic.TabIndex = 17;
            this.lblTelMobilJuridic.Text = "0734.78.66.21";
            this.lblTelMobilJuridic.ToolTipText = null;
            this.lblTelMobilJuridic.ToolTipTitle = null;
            // 
            // labelPersonalizat2
            // 
            this.labelPersonalizat2.AutoSize = true;
            this.labelPersonalizat2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelPersonalizat2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPersonalizat2.Location = new System.Drawing.Point(222, 55);
            this.labelPersonalizat2.Name = "labelPersonalizat2";
            this.labelPersonalizat2.Size = new System.Drawing.Size(128, 17);
            this.labelPersonalizat2.TabIndex = 15;
            this.labelPersonalizat2.Text = "contact@iStoma.ro";
            this.labelPersonalizat2.ToolTipText = null;
            this.labelPersonalizat2.ToolTipTitle = null;
            // 
            // labelPersonalizat1
            // 
            this.labelPersonalizat1.AutoSize = true;
            this.labelPersonalizat1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelPersonalizat1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPersonalizat1.Location = new System.Drawing.Point(34, 55);
            this.labelPersonalizat1.Name = "labelPersonalizat1";
            this.labelPersonalizat1.Size = new System.Drawing.Size(122, 17);
            this.labelPersonalizat1.TabIndex = 14;
            this.labelPersonalizat1.Text = "suport@iStoma.ro";
            this.labelPersonalizat1.ToolTipText = null;
            this.labelPersonalizat1.ToolTipTitle = null;
            // 
            // lblMarketing
            // 
            this.lblMarketing.AutoSize = true;
            this.lblMarketing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMarketing.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMarketing.Location = new System.Drawing.Point(234, 191);
            this.lblMarketing.Name = "lblMarketing";
            this.lblMarketing.Size = new System.Drawing.Size(100, 17);
            this.lblMarketing.TabIndex = 13;
            this.lblMarketing.Text = "0724.47.86.62";
            this.lblMarketing.ToolTipText = null;
            this.lblMarketing.ToolTipTitle = null;
            // 
            // lblSuport
            // 
            this.lblSuport.AutoSize = true;
            this.lblSuport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSuport.Location = new System.Drawing.Point(21, 5);
            this.lblSuport.Name = "lblSuport";
            this.lblSuport.Size = new System.Drawing.Size(52, 18);
            this.lblSuport.TabIndex = 8;
            this.lblSuport.Text = "Suport";
            this.lblSuport.ToolTipText = null;
            this.lblSuport.ToolTipTitle = null;
            // 
            // lblTelefonFeedBack
            // 
            this.lblTelefonFeedBack.AutoSize = true;
            this.lblTelefonFeedBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTelefonFeedBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTelefonFeedBack.Location = new System.Drawing.Point(222, 32);
            this.lblTelefonFeedBack.Name = "lblTelefonFeedBack";
            this.lblTelefonFeedBack.Size = new System.Drawing.Size(100, 17);
            this.lblTelefonFeedBack.TabIndex = 12;
            this.lblTelefonFeedBack.Text = "0737.42.42.73";
            this.lblTelefonFeedBack.ToolTipText = null;
            this.lblTelefonFeedBack.ToolTipTitle = null;
            // 
            // lblFeedBack
            // 
            this.lblFeedBack.AutoSize = true;
            this.lblFeedBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblFeedBack.Location = new System.Drawing.Point(209, 5);
            this.lblFeedBack.Name = "lblFeedBack";
            this.lblFeedBack.Size = new System.Drawing.Size(73, 18);
            this.lblFeedBack.TabIndex = 9;
            this.lblFeedBack.Text = "Feedback";
            this.lblFeedBack.ToolTipText = null;
            this.lblFeedBack.ToolTipTitle = null;
            // 
            // lblTelefonFixSuport
            // 
            this.lblTelefonFixSuport.AutoSize = true;
            this.lblTelefonFixSuport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTelefonFixSuport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTelefonFixSuport.Location = new System.Drawing.Point(40, 191);
            this.lblTelefonFixSuport.Name = "lblTelefonFixSuport";
            this.lblTelefonFixSuport.Size = new System.Drawing.Size(100, 17);
            this.lblTelefonFixSuport.TabIndex = 11;
            this.lblTelefonFixSuport.Text = "021.555.10.52";
            this.lblTelefonFixSuport.ToolTipText = null;
            this.lblTelefonFixSuport.ToolTipTitle = null;
            // 
            // lblTelefonMobilSuport
            // 
            this.lblTelefonMobilSuport.AutoSize = true;
            this.lblTelefonMobilSuport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTelefonMobilSuport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTelefonMobilSuport.Location = new System.Drawing.Point(34, 32);
            this.lblTelefonMobilSuport.Name = "lblTelefonMobilSuport";
            this.lblTelefonMobilSuport.Size = new System.Drawing.Size(100, 17);
            this.lblTelefonMobilSuport.TabIndex = 10;
            this.lblTelefonMobilSuport.Text = "0731.47.86.62";
            this.lblTelefonMobilSuport.ToolTipText = null;
            this.lblTelefonMobilSuport.ToolTipTitle = null;
            // 
            // wbNoutatiVersiune
            // 
            this.wbNoutatiVersiune.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbNoutatiVersiune.Location = new System.Drawing.Point(365, 21);
            this.wbNoutatiVersiune.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbNoutatiVersiune.Name = "wbNoutatiVersiune";
            this.wbNoutatiVersiune.Size = new System.Drawing.Size(554, 538);
            this.wbNoutatiVersiune.TabIndex = 3;
            // 
            // ctrlValidareAnulare
            // 
            this.ctrlValidareAnulare.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrlValidareAnulare.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulare.Location = new System.Drawing.Point(381, 568);
            this.ctrlValidareAnulare.Name = "ctrlValidareAnulare";
            this.ctrlValidareAnulare.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulare.TabIndex = 4;
            // 
            // frmDespre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 600);
            this.Controls.Add(this.ctrlValidareAnulare);
            this.Controls.Add(this.wbNoutatiVersiune);
            this.Controls.Add(this.panelGlobal);
            this.MinimumSize = new System.Drawing.Size(923, 600);
            this.Name = "frmDespre";
            this.Text = "Despre";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.panelGlobal, 0);
            this.Controls.SetChildIndex(this.wbNoutatiVersiune, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulare, 0);
            this.panelGlobal.ResumeLayout(false);
            this.panelGlobal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPersonalizat1)).EndInit();
            this.panelTelefoane.ResumeLayout(false);
            this.panelTelefoane.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.PanelPersonalizat panelGlobal;
        private CCL.UI.LabelPersonalizat lblVersiuneBDD;
        private CCL.UI.LabelPersonalizat lblVersiuneAplicatie;
        private CCL.UI.LabelPersonalizat lblTitluVersiuneBDD;
        private CCL.UI.LabelPersonalizat lblTitluVersiuneAplicatie;
        private CCL.UI.PictureBoxPersonalizat pictureBoxPersonalizat1;
        private CCL.UI.LinkLabelPersonalizat lnkIStomaLTD;
        private CCL.UI.LabelPersonalizat lblNumeCalculator;
        private CCL.UI.LabelPersonalizat lblTelefonFeedBack;
        private CCL.UI.LabelPersonalizat lblTelefonFixSuport;
        private CCL.UI.LabelPersonalizat lblTelefonMobilSuport;
        private CCL.UI.LabelPersonalizat lblFeedBack;
        private CCL.UI.LabelPersonalizat lblSuport;
        private CCL.UI.PanelPersonalizat panelTelefoane;
        private CCL.UI.LabelPersonalizat lblMarketing;
        private CCL.UI.ButtonPersonalizat btnSugestie;
        private CCL.UI.ButtonPersonalizat btnCheckForUpdates;
        private WebBrowser wbNoutatiVersiune;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulare;
        private CCL.UI.LabelPersonalizat lblLicenta;
        private CCL.UI.ButtonPersonalizat btnOptimizeaza;
        private CCL.UI.LabelPersonalizat labelPersonalizat2;
        private CCL.UI.LabelPersonalizat labelPersonalizat1;
        private CCL.UI.LabelPersonalizat lblMailJuridic;
        private CCL.UI.LabelPersonalizat lblJuridic;
        private CCL.UI.LabelPersonalizat lblTelMobilJuridic;
        private CCL.UI.LinkLabelPersonalizat lnkPiataStomatologica;
        private CCL.UI.ButtonPersonalizat btnConsiliereJuridic;
        private CCL.UI.LinkLabelPersonalizat lnkCloud;
    }
}