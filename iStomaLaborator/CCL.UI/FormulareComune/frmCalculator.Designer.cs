using ILL.iStomaLab; using CDL.iStomaLab;
namespace CCL.UI
{
    partial class frmCalculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalculator));
            this.btnSterge = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnGuma = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnEgal = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnImpartire = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnInmultire = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnMinus = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnPlus = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnVirgula = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnNoua = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnOpt = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnSapte = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnSase = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnCinci = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnPatru = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnTrei = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnDoi = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnUnu = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnZero = new CCL.UI.ButtonPersonalizat(this.components);
            this.txtRezultat = new CCL.UI.Caramizi.TextBoxGuma();
            this.panelPersonalizat1 = new CCL.UI.PanelPersonalizat(this.components);
            this.btnValidare = new CCL.UI.ButtonPersonalizat(this.components);
            this.panelGlobal = new CCL.UI.PanelPersonalizat(this.components);
            this.panelPersonalizat1.SuspendLayout();
            this.panelGlobal.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(197, 19);
            this.lblTitluEcran.Text = "Calculator";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(196, 0);
            // 
            // btnSterge
            // 
            this.btnSterge.BackColor = System.Drawing.SystemColors.Control;
            this.btnSterge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSterge.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSterge.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnSterge.Location = new System.Drawing.Point(172, 91);
            this.btnSterge.Name = "btnSterge";
            this.btnSterge.Size = new System.Drawing.Size(42, 27);
            this.btnSterge.TabIndex = 20;
            this.btnSterge.Text = "back";
            this.btnSterge.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnSterge.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnSterge.UseVisualStyleBackColor = true;
            this.btnSterge.Click += new System.EventHandler(this.btnSterge_Click);
            // 
            // btnGuma
            // 
            this.btnGuma.BackColor = System.Drawing.SystemColors.Control;
            this.btnGuma.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGuma.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnGuma.Image = global::CCL.UI.Properties.Resources.eraser;
            this.btnGuma.Location = new System.Drawing.Point(172, 120);
            this.btnGuma.Name = "btnGuma";
            this.btnGuma.Size = new System.Drawing.Size(42, 27);
            this.btnGuma.TabIndex = 19;
            this.btnGuma.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnGuma.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnGuma.UseVisualStyleBackColor = true;
            this.btnGuma.Click += new System.EventHandler(this.btnGuma_Click);
            // 
            // btnEgal
            // 
            this.btnEgal.BackColor = System.Drawing.SystemColors.Control;
            this.btnEgal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEgal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEgal.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnEgal.Location = new System.Drawing.Point(86, 120);
            this.btnEgal.Name = "btnEgal";
            this.btnEgal.Size = new System.Drawing.Size(38, 27);
            this.btnEgal.TabIndex = 18;
            this.btnEgal.Text = "=";
            this.btnEgal.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnEgal.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnEgal.UseVisualStyleBackColor = true;
            this.btnEgal.Click += new System.EventHandler(this.btnCalculeaza_Click);
            // 
            // btnImpartire
            // 
            this.btnImpartire.BackColor = System.Drawing.SystemColors.Control;
            this.btnImpartire.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnImpartire.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnImpartire.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnImpartire.Location = new System.Drawing.Point(128, 33);
            this.btnImpartire.Name = "btnImpartire";
            this.btnImpartire.Size = new System.Drawing.Size(38, 27);
            this.btnImpartire.TabIndex = 17;
            this.btnImpartire.Text = "/";
            this.btnImpartire.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnImpartire.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnImpartire.UseVisualStyleBackColor = true;
            this.btnImpartire.Click += new System.EventHandler(this.btnCalculeaza_Click);
            // 
            // btnInmultire
            // 
            this.btnInmultire.BackColor = System.Drawing.SystemColors.Control;
            this.btnInmultire.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnInmultire.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnInmultire.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnInmultire.Location = new System.Drawing.Point(128, 62);
            this.btnInmultire.Name = "btnInmultire";
            this.btnInmultire.Size = new System.Drawing.Size(38, 27);
            this.btnInmultire.TabIndex = 16;
            this.btnInmultire.Text = "*";
            this.btnInmultire.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnInmultire.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnInmultire.UseVisualStyleBackColor = true;
            this.btnInmultire.Click += new System.EventHandler(this.btnCalculeaza_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.BackColor = System.Drawing.SystemColors.Control;
            this.btnMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnMinus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMinus.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnMinus.Location = new System.Drawing.Point(128, 91);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(38, 27);
            this.btnMinus.TabIndex = 15;
            this.btnMinus.Text = "-";
            this.btnMinus.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnMinus.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnCalculeaza_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.BackColor = System.Drawing.SystemColors.Control;
            this.btnPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPlus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPlus.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnPlus.Location = new System.Drawing.Point(128, 120);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(38, 27);
            this.btnPlus.TabIndex = 14;
            this.btnPlus.Text = "+";
            this.btnPlus.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnPlus.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnCalculeaza_Click);
            // 
            // btnVirgula
            // 
            this.btnVirgula.BackColor = System.Drawing.SystemColors.Control;
            this.btnVirgula.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnVirgula.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnVirgula.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnVirgula.Location = new System.Drawing.Point(44, 120);
            this.btnVirgula.Name = "btnVirgula";
            this.btnVirgula.Size = new System.Drawing.Size(38, 27);
            this.btnVirgula.TabIndex = 13;
            this.btnVirgula.Text = ".";
            this.btnVirgula.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnVirgula.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnVirgula.UseVisualStyleBackColor = true;
            this.btnVirgula.Click += new System.EventHandler(this.btnCifra_Click);
            // 
            // btnNoua
            // 
            this.btnNoua.BackColor = System.Drawing.SystemColors.Control;
            this.btnNoua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNoua.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNoua.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnNoua.Location = new System.Drawing.Point(86, 33);
            this.btnNoua.Name = "btnNoua";
            this.btnNoua.Size = new System.Drawing.Size(38, 27);
            this.btnNoua.TabIndex = 12;
            this.btnNoua.Text = "9";
            this.btnNoua.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnNoua.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnNoua.UseVisualStyleBackColor = true;
            this.btnNoua.Click += new System.EventHandler(this.btnCifra_Click);
            // 
            // btnOpt
            // 
            this.btnOpt.BackColor = System.Drawing.SystemColors.Control;
            this.btnOpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOpt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOpt.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnOpt.Location = new System.Drawing.Point(44, 33);
            this.btnOpt.Name = "btnOpt";
            this.btnOpt.Size = new System.Drawing.Size(38, 27);
            this.btnOpt.TabIndex = 11;
            this.btnOpt.Text = "8";
            this.btnOpt.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnOpt.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnOpt.UseVisualStyleBackColor = true;
            this.btnOpt.Click += new System.EventHandler(this.btnCifra_Click);
            // 
            // btnSapte
            // 
            this.btnSapte.BackColor = System.Drawing.SystemColors.Control;
            this.btnSapte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSapte.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSapte.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnSapte.Location = new System.Drawing.Point(2, 33);
            this.btnSapte.Name = "btnSapte";
            this.btnSapte.Size = new System.Drawing.Size(38, 27);
            this.btnSapte.TabIndex = 10;
            this.btnSapte.Text = "7";
            this.btnSapte.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnSapte.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnSapte.UseVisualStyleBackColor = true;
            this.btnSapte.Click += new System.EventHandler(this.btnCifra_Click);
            // 
            // btnSase
            // 
            this.btnSase.BackColor = System.Drawing.SystemColors.Control;
            this.btnSase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSase.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSase.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnSase.Location = new System.Drawing.Point(86, 62);
            this.btnSase.Name = "btnSase";
            this.btnSase.Size = new System.Drawing.Size(38, 27);
            this.btnSase.TabIndex = 9;
            this.btnSase.Text = "6";
            this.btnSase.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnSase.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnSase.UseVisualStyleBackColor = true;
            this.btnSase.Click += new System.EventHandler(this.btnCifra_Click);
            // 
            // btnCinci
            // 
            this.btnCinci.BackColor = System.Drawing.SystemColors.Control;
            this.btnCinci.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCinci.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCinci.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnCinci.Location = new System.Drawing.Point(44, 62);
            this.btnCinci.Name = "btnCinci";
            this.btnCinci.Size = new System.Drawing.Size(38, 27);
            this.btnCinci.TabIndex = 8;
            this.btnCinci.Text = "5";
            this.btnCinci.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnCinci.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnCinci.UseVisualStyleBackColor = true;
            this.btnCinci.Click += new System.EventHandler(this.btnCifra_Click);
            // 
            // btnPatru
            // 
            this.btnPatru.BackColor = System.Drawing.SystemColors.Control;
            this.btnPatru.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPatru.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPatru.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnPatru.Location = new System.Drawing.Point(2, 62);
            this.btnPatru.Name = "btnPatru";
            this.btnPatru.Size = new System.Drawing.Size(38, 27);
            this.btnPatru.TabIndex = 7;
            this.btnPatru.Text = "4";
            this.btnPatru.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnPatru.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnPatru.UseVisualStyleBackColor = true;
            this.btnPatru.Click += new System.EventHandler(this.btnCifra_Click);
            // 
            // btnTrei
            // 
            this.btnTrei.BackColor = System.Drawing.SystemColors.Control;
            this.btnTrei.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnTrei.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTrei.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnTrei.Location = new System.Drawing.Point(86, 91);
            this.btnTrei.Name = "btnTrei";
            this.btnTrei.Size = new System.Drawing.Size(38, 27);
            this.btnTrei.TabIndex = 6;
            this.btnTrei.Text = "3";
            this.btnTrei.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnTrei.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnTrei.UseVisualStyleBackColor = true;
            this.btnTrei.Click += new System.EventHandler(this.btnCifra_Click);
            // 
            // btnDoi
            // 
            this.btnDoi.BackColor = System.Drawing.SystemColors.Control;
            this.btnDoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDoi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDoi.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnDoi.Location = new System.Drawing.Point(44, 91);
            this.btnDoi.Name = "btnDoi";
            this.btnDoi.Size = new System.Drawing.Size(38, 27);
            this.btnDoi.TabIndex = 5;
            this.btnDoi.Text = "2";
            this.btnDoi.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnDoi.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnDoi.UseVisualStyleBackColor = true;
            this.btnDoi.Click += new System.EventHandler(this.btnCifra_Click);
            // 
            // btnUnu
            // 
            this.btnUnu.BackColor = System.Drawing.SystemColors.Control;
            this.btnUnu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUnu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUnu.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnUnu.Location = new System.Drawing.Point(2, 91);
            this.btnUnu.Name = "btnUnu";
            this.btnUnu.Size = new System.Drawing.Size(38, 27);
            this.btnUnu.TabIndex = 4;
            this.btnUnu.Text = "1";
            this.btnUnu.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnUnu.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnUnu.UseVisualStyleBackColor = true;
            this.btnUnu.Click += new System.EventHandler(this.btnCifra_Click);
            // 
            // btnZero
            // 
            this.btnZero.BackColor = System.Drawing.SystemColors.Control;
            this.btnZero.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnZero.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnZero.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnZero.Location = new System.Drawing.Point(2, 120);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(38, 27);
            this.btnZero.TabIndex = 3;
            this.btnZero.Text = "0";
            this.btnZero.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.btnZero.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnZero.UseVisualStyleBackColor = true;
            this.btnZero.Click += new System.EventHandler(this.btnCifra_Click);
            // 
            // txtRezultat
            // 
            this.txtRezultat.AcceptButton = null;
            this.txtRezultat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRezultat.BackColor = System.Drawing.Color.Transparent;
            this.txtRezultat.IsInReadOnlyMode = true;
            this.txtRezultat.Location = new System.Drawing.Point(2, 5);
            this.txtRezultat.MaxLength = 32767;
            this.txtRezultat.Multiline = false;
            this.txtRezultat.Name = "txtRezultat";
            this.txtRezultat.ProprietateCorespunzatoare = null;
            this.txtRezultat.RaiseEventLaModificareProgramatica = false;
            this.txtRezultat.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRezultat.Size = new System.Drawing.Size(212, 22);
            this.txtRezultat.TabIndex = 0;
            this.txtRezultat.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtRezultat.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtRezultat.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtRezultat.CerereUpdate += new CCL.UI.CEvenimente.ZonaModificata(this.txtRezultat_CerereUpdate);
            // 
            // panelPersonalizat1
            // 
            this.panelPersonalizat1.BackColor = System.Drawing.Color.Transparent;
            this.panelPersonalizat1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPersonalizat1.Controls.Add(this.panelGlobal);
            this.panelPersonalizat1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPersonalizat1.Location = new System.Drawing.Point(0, 0);
            this.panelPersonalizat1.Name = "panelPersonalizat1";
            this.panelPersonalizat1.Size = new System.Drawing.Size(219, 170);
            this.panelPersonalizat1.TabIndex = 21;
            this.panelPersonalizat1.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // btnValidare
            // 
            this.btnValidare.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnValidare.Image = ((System.Drawing.Image)(resources.GetObject("btnValidare.Image")));
            this.btnValidare.Location = new System.Drawing.Point(172, 33);
            this.btnValidare.Name = "btnValidare";
            this.btnValidare.Size = new System.Drawing.Size(42, 56);
            this.btnValidare.TabIndex = 0;
            this.btnValidare.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Validare;
            this.btnValidare.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnValidare.UseVisualStyleBackColor = true;
            this.btnValidare.Click += new System.EventHandler(this.btnValidare_Click);
            // 
            // panelGlobal
            // 
            this.panelGlobal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGlobal.BackColor = System.Drawing.Color.Linen;
            this.panelGlobal.Controls.Add(this.btnValidare);
            this.panelGlobal.Controls.Add(this.txtRezultat);
            this.panelGlobal.Controls.Add(this.btnZero);
            this.panelGlobal.Controls.Add(this.btnSterge);
            this.panelGlobal.Controls.Add(this.btnUnu);
            this.panelGlobal.Controls.Add(this.btnGuma);
            this.panelGlobal.Controls.Add(this.btnDoi);
            this.panelGlobal.Controls.Add(this.btnEgal);
            this.panelGlobal.Controls.Add(this.btnTrei);
            this.panelGlobal.Controls.Add(this.btnImpartire);
            this.panelGlobal.Controls.Add(this.btnPatru);
            this.panelGlobal.Controls.Add(this.btnInmultire);
            this.panelGlobal.Controls.Add(this.btnCinci);
            this.panelGlobal.Controls.Add(this.btnMinus);
            this.panelGlobal.Controls.Add(this.btnSase);
            this.panelGlobal.Controls.Add(this.btnPlus);
            this.panelGlobal.Controls.Add(this.btnSapte);
            this.panelGlobal.Controls.Add(this.btnVirgula);
            this.panelGlobal.Controls.Add(this.btnOpt);
            this.panelGlobal.Controls.Add(this.btnNoua);
            this.panelGlobal.Location = new System.Drawing.Point(1, 18);
            this.panelGlobal.Name = "panelGlobal";
            this.panelGlobal.Size = new System.Drawing.Size(216, 150);
            this.panelGlobal.TabIndex = 1;
            this.panelGlobal.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Tab;
            // 
            // frmCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 170);
            this.Controls.Add(this.panelPersonalizat1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCalculator";
            this.ShowIcon = false;
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.frmCalculator_Load);
            this.Controls.SetChildIndex(this.panelPersonalizat1, 0);
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.panelPersonalizat1.ResumeLayout(false);
            this.panelGlobal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.Caramizi.TextBoxGuma txtRezultat;
        private ButtonPersonalizat btnZero;
        private ButtonPersonalizat btnUnu;
        private ButtonPersonalizat btnDoi;
        private ButtonPersonalizat btnTrei;
        private ButtonPersonalizat btnPatru;
        private ButtonPersonalizat btnCinci;
        private ButtonPersonalizat btnSase;
        private ButtonPersonalizat btnSapte;
        private ButtonPersonalizat btnOpt;
        private ButtonPersonalizat btnNoua;
        private ButtonPersonalizat btnVirgula;
        private ButtonPersonalizat btnPlus;
        private ButtonPersonalizat btnMinus;
        private ButtonPersonalizat btnInmultire;
        private ButtonPersonalizat btnImpartire;
        private ButtonPersonalizat btnEgal;
        private ButtonPersonalizat btnGuma;
        private ButtonPersonalizat btnSterge;
        private PanelPersonalizat panelPersonalizat1;
        private ButtonPersonalizat btnValidare;
        private PanelPersonalizat panelGlobal;
    }
}