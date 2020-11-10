namespace CCL.UI.FormulareComune
{
    partial class frmAfiseazaImagine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAfiseazaImagine));
            this.picZonaImagine = new CCL.UI.PictureBoxPersonalizat(this.components);
            this.panelContinut = new CCL.UI.PanelPersonalizat(this.components);
            this.splitGlobal = new CCL.UI.SplitContainerPersonalizat(this.components);
            this.panelOptiuni = new CCL.UI.PanelPersonalizat(this.components);
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnInvert = new System.Windows.Forms.Button();
            this.btnSalveazaPeDisc = new System.Windows.Forms.Button();
            this.btnContrast = new System.Windows.Forms.Button();
            this.btnBrughtness = new System.Windows.Forms.Button();
            this.btnRotesteDreapta = new System.Windows.Forms.Button();
            this.btnRotesteStanga = new System.Windows.Forms.Button();
            this.panelImagine = new CCL.UI.PanelPersonalizat(this.components);
            this.panelContrast = new CCL.UI.PanelPersonalizat(this.components);
            this.tbContrast = new System.Windows.Forms.TrackBar();
            this.panelBrightness = new CCL.UI.PanelPersonalizat(this.components);
            this.tbBrightness = new System.Windows.Forms.TrackBar();
            this.btnPrint = new CCL.UI.ButtonPersonalizat(this.components);
            this.flpPreview = new CCL.UI.FlowLayoutPanelPersonalizat(this.components);
            this.btnImprimaImaginea = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picZonaImagine)).BeginInit();
            this.panelContinut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitGlobal)).BeginInit();
            this.splitGlobal.Panel1.SuspendLayout();
            this.splitGlobal.Panel2.SuspendLayout();
            this.splitGlobal.SuspendLayout();
            this.panelOptiuni.SuspendLayout();
            this.panelImagine.SuspendLayout();
            this.panelContrast.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).BeginInit();
            this.panelBrightness.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrightness)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(585, 19);
            this.lblTitluEcran.Text = "frmAfiseazaImagine";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(584, 0);
            // 
            // picZonaImagine
            // 
            this.picZonaImagine.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picZonaImagine.BackColor = System.Drawing.Color.Black;
            this.picZonaImagine.ContinutToolTip = null;
            this.picZonaImagine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picZonaImagine.IcoanaToolTip = System.Windows.Forms.ToolTipIcon.Info;
            this.picZonaImagine.Location = new System.Drawing.Point(-14, 1);
            this.picZonaImagine.Name = "picZonaImagine";
            this.picZonaImagine.Size = new System.Drawing.Size(591, 304);
            this.picZonaImagine.TabIndex = 2;
            this.picZonaImagine.TabStop = false;
            this.picZonaImagine.TitluToolTip = "";
            this.picZonaImagine.UtilizamToolTip = false;
            this.picZonaImagine.DoubleClick += new System.EventHandler(this.picZonaImagine_DoubleClick);
            this.picZonaImagine.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picZonaImagine_MouseDown);
            this.picZonaImagine.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picZonaImagine_MouseMove);
            this.picZonaImagine.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picZonaImagine_MouseUp);
            // 
            // panelContinut
            // 
            this.panelContinut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContinut.BackColor = System.Drawing.SystemColors.Control;
            this.panelContinut.Controls.Add(this.splitGlobal);
            this.panelContinut.Location = new System.Drawing.Point(1, 19);
            this.panelContinut.Name = "panelContinut";
            this.panelContinut.Size = new System.Drawing.Size(605, 389);
            this.panelContinut.TabIndex = 3;
            this.panelContinut.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // splitGlobal
            // 
            this.splitGlobal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitGlobal.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitGlobal.IsSplitterFixed = true;
            this.splitGlobal.Location = new System.Drawing.Point(0, 0);
            this.splitGlobal.Name = "splitGlobal";
            this.splitGlobal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitGlobal.Panel1
            // 
            this.splitGlobal.Panel1.Controls.Add(this.panelOptiuni);
            this.splitGlobal.Panel1.Controls.Add(this.panelImagine);
            // 
            // splitGlobal.Panel2
            // 
            this.splitGlobal.Panel2.Controls.Add(this.btnPrint);
            this.splitGlobal.Panel2.Controls.Add(this.flpPreview);
            this.splitGlobal.Size = new System.Drawing.Size(605, 389);
            this.splitGlobal.SplitterDistance = 311;
            this.splitGlobal.TabIndex = 3;
            this.splitGlobal.TabStop = false;
            // 
            // panelOptiuni
            // 
            this.panelOptiuni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOptiuni.BackColor = System.Drawing.SystemColors.Control;
            this.panelOptiuni.Controls.Add(this.btnImprimaImaginea);
            this.panelOptiuni.Controls.Add(this.btnZoomOut);
            this.panelOptiuni.Controls.Add(this.btnZoomIn);
            this.panelOptiuni.Controls.Add(this.btnRestore);
            this.panelOptiuni.Controls.Add(this.btnInvert);
            this.panelOptiuni.Controls.Add(this.btnSalveazaPeDisc);
            this.panelOptiuni.Controls.Add(this.btnContrast);
            this.panelOptiuni.Controls.Add(this.btnBrughtness);
            this.panelOptiuni.Controls.Add(this.btnRotesteDreapta);
            this.panelOptiuni.Controls.Add(this.btnRotesteStanga);
            this.panelOptiuni.Location = new System.Drawing.Point(577, -1);
            this.panelOptiuni.Name = "panelOptiuni";
            this.panelOptiuni.Size = new System.Drawing.Size(28, 306);
            this.panelOptiuni.TabIndex = 4;
            this.panelOptiuni.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomOut.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnZoomOut.FlatAppearance.BorderSize = 0;
            this.btnZoomOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnZoomOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomOut.Image = global::CCL.UI.Properties.Resources.zoomOut;
            this.btnZoomOut.Location = new System.Drawing.Point(-2, 283);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(31, 23);
            this.btnZoomOut.TabIndex = 8;
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomIn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnZoomIn.FlatAppearance.BorderSize = 0;
            this.btnZoomIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnZoomIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomIn.Image = global::CCL.UI.Properties.Resources.zoomIn;
            this.btnZoomIn.Location = new System.Drawing.Point(-2, 254);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(31, 23);
            this.btnZoomIn.TabIndex = 7;
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestore.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnRestore.FlatAppearance.BorderSize = 0;
            this.btnRestore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnRestore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.Image = global::CCL.UI.Properties.Resources.eraser;
            this.btnRestore.Location = new System.Drawing.Point(-1, 84);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(31, 23);
            this.btnRestore.TabIndex = 6;
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnInvert
            // 
            this.btnInvert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvert.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnInvert.FlatAppearance.BorderSize = 0;
            this.btnInvert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnInvert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnInvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvert.Image = global::CCL.UI.Properties.Resources.Invert;
            this.btnInvert.Location = new System.Drawing.Point(-1, 109);
            this.btnInvert.Name = "btnInvert";
            this.btnInvert.Size = new System.Drawing.Size(31, 23);
            this.btnInvert.TabIndex = 5;
            this.btnInvert.UseVisualStyleBackColor = true;
            this.btnInvert.Click += new System.EventHandler(this.btnInvert_Click);
            // 
            // btnSalveazaPeDisc
            // 
            this.btnSalveazaPeDisc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalveazaPeDisc.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSalveazaPeDisc.FlatAppearance.BorderSize = 0;
            this.btnSalveazaPeDisc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnSalveazaPeDisc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnSalveazaPeDisc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalveazaPeDisc.Image = global::CCL.UI.Properties.Resources.Text_save;
            this.btnSalveazaPeDisc.Location = new System.Drawing.Point(-1, 4);
            this.btnSalveazaPeDisc.Name = "btnSalveazaPeDisc";
            this.btnSalveazaPeDisc.Size = new System.Drawing.Size(31, 23);
            this.btnSalveazaPeDisc.TabIndex = 4;
            this.btnSalveazaPeDisc.UseVisualStyleBackColor = true;
            this.btnSalveazaPeDisc.Click += new System.EventHandler(this.btnSalveazaPeDisc_Click);
            // 
            // btnContrast
            // 
            this.btnContrast.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContrast.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnContrast.FlatAppearance.BorderSize = 0;
            this.btnContrast.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnContrast.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnContrast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContrast.Image = global::CCL.UI.Properties.Resources.brightness_contrast;
            this.btnContrast.Location = new System.Drawing.Point(-1, 138);
            this.btnContrast.Name = "btnContrast";
            this.btnContrast.Size = new System.Drawing.Size(31, 23);
            this.btnContrast.TabIndex = 3;
            this.btnContrast.UseVisualStyleBackColor = true;
            this.btnContrast.Click += new System.EventHandler(this.btnContrast_Click);
            // 
            // btnBrughtness
            // 
            this.btnBrughtness.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrughtness.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnBrughtness.FlatAppearance.BorderSize = 0;
            this.btnBrughtness.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnBrughtness.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnBrughtness.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrughtness.Image = global::CCL.UI.Properties.Resources.asterisk_yellow;
            this.btnBrughtness.Location = new System.Drawing.Point(-1, 167);
            this.btnBrughtness.Name = "btnBrughtness";
            this.btnBrughtness.Size = new System.Drawing.Size(31, 23);
            this.btnBrughtness.TabIndex = 2;
            this.btnBrughtness.UseVisualStyleBackColor = true;
            this.btnBrughtness.Click += new System.EventHandler(this.btnBrightness_Click);
            // 
            // btnRotesteDreapta
            // 
            this.btnRotesteDreapta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRotesteDreapta.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnRotesteDreapta.FlatAppearance.BorderSize = 0;
            this.btnRotesteDreapta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnRotesteDreapta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnRotesteDreapta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRotesteDreapta.Image = global::CCL.UI.Properties.Resources.Actions_object_flip_horizontal_icon;
            this.btnRotesteDreapta.Location = new System.Drawing.Point(-2, 196);
            this.btnRotesteDreapta.Name = "btnRotesteDreapta";
            this.btnRotesteDreapta.Size = new System.Drawing.Size(31, 23);
            this.btnRotesteDreapta.TabIndex = 1;
            this.btnRotesteDreapta.UseVisualStyleBackColor = true;
            this.btnRotesteDreapta.Click += new System.EventHandler(this.btnRotesteDreapta_Click);
            // 
            // btnRotesteStanga
            // 
            this.btnRotesteStanga.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRotesteStanga.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnRotesteStanga.FlatAppearance.BorderSize = 0;
            this.btnRotesteStanga.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnRotesteStanga.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnRotesteStanga.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRotesteStanga.Image = global::CCL.UI.Properties.Resources.shape_rotate_anticlockwise;
            this.btnRotesteStanga.Location = new System.Drawing.Point(-2, 225);
            this.btnRotesteStanga.Name = "btnRotesteStanga";
            this.btnRotesteStanga.Size = new System.Drawing.Size(31, 23);
            this.btnRotesteStanga.TabIndex = 0;
            this.btnRotesteStanga.UseVisualStyleBackColor = true;
            this.btnRotesteStanga.Click += new System.EventHandler(this.btnRotesteStanga_Click);
            // 
            // panelImagine
            // 
            this.panelImagine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelImagine.BackColor = System.Drawing.SystemColors.Control;
            this.panelImagine.Controls.Add(this.panelContrast);
            this.panelImagine.Controls.Add(this.panelBrightness);
            this.panelImagine.Controls.Add(this.picZonaImagine);
            this.panelImagine.Location = new System.Drawing.Point(0, -1);
            this.panelImagine.Name = "panelImagine";
            this.panelImagine.Size = new System.Drawing.Size(577, 306);
            this.panelImagine.TabIndex = 3;
            this.panelImagine.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // panelContrast
            // 
            this.panelContrast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContrast.BackColor = System.Drawing.SystemColors.Control;
            this.panelContrast.Controls.Add(this.tbContrast);
            this.panelContrast.Location = new System.Drawing.Point(296, 213);
            this.panelContrast.Name = "panelContrast";
            this.panelContrast.Size = new System.Drawing.Size(281, 50);
            this.panelContrast.TabIndex = 4;
            this.panelContrast.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.panelContrast.Visible = false;
            // 
            // tbContrast
            // 
            this.tbContrast.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbContrast.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbContrast.Location = new System.Drawing.Point(3, 3);
            this.tbContrast.Maximum = 100;
            this.tbContrast.Minimum = -100;
            this.tbContrast.Name = "tbContrast";
            this.tbContrast.Size = new System.Drawing.Size(275, 45);
            this.tbContrast.TabIndex = 0;
            this.tbContrast.TickFrequency = 10;
            this.tbContrast.Scroll += new System.EventHandler(this.tbContrast_Scroll);
            // 
            // panelBrightness
            // 
            this.panelBrightness.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBrightness.BackColor = System.Drawing.SystemColors.Control;
            this.panelBrightness.Controls.Add(this.tbBrightness);
            this.panelBrightness.Location = new System.Drawing.Point(296, 239);
            this.panelBrightness.Name = "panelBrightness";
            this.panelBrightness.Size = new System.Drawing.Size(281, 50);
            this.panelBrightness.TabIndex = 3;
            this.panelBrightness.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.panelBrightness.Visible = false;
            // 
            // tbBrightness
            // 
            this.tbBrightness.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBrightness.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbBrightness.Location = new System.Drawing.Point(3, 3);
            this.tbBrightness.Maximum = 100;
            this.tbBrightness.Minimum = -100;
            this.tbBrightness.Name = "tbBrightness";
            this.tbBrightness.Size = new System.Drawing.Size(275, 45);
            this.tbBrightness.TabIndex = 0;
            this.tbBrightness.TickFrequency = 10;
            this.tbBrightness.Scroll += new System.EventHandler(this.tbBrightness_Scroll);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(534, 1);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(70, 73);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Print;
            this.btnPrint.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // flpPreview
            // 
            this.flpPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpPreview.BackColor = System.Drawing.Color.Black;
            this.flpPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpPreview.Location = new System.Drawing.Point(0, 0);
            this.flpPreview.Name = "flpPreview";
            this.flpPreview.Size = new System.Drawing.Size(605, 75);
            this.flpPreview.TabIndex = 0;
            // 
            // btnImprimaImaginea
            // 
            this.btnImprimaImaginea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimaImaginea.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnImprimaImaginea.FlatAppearance.BorderSize = 0;
            this.btnImprimaImaginea.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnImprimaImaginea.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnImprimaImaginea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimaImaginea.Image = global::CCL.UI.Properties.Resources.printer;
            this.btnImprimaImaginea.Location = new System.Drawing.Point(-1, 33);
            this.btnImprimaImaginea.Name = "btnImprimaImaginea";
            this.btnImprimaImaginea.Size = new System.Drawing.Size(31, 23);
            this.btnImprimaImaginea.TabIndex = 9;
            this.btnImprimaImaginea.UseVisualStyleBackColor = true;
            this.btnImprimaImaginea.Click += new System.EventHandler(this.btnImprimaImaginea_Click);
            // 
            // frmAfiseazaImagine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 409);
            this.Controls.Add(this.panelContinut);
            this.MinimumSize = new System.Drawing.Size(607, 409);
            this.Name = "frmAfiseazaImagine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAfiseazaImagine";
            this.TipDeschidere = CCL.UI.CEnumerariComune.EnumTipDeschidere.CentrulEcranului;
            this.Load += new System.EventHandler(this.frmAfiseazaImagine_Load);
            this.SizeChanged += new System.EventHandler(this.frmAfiseazaImagine_SizeChanged);
            this.Controls.SetChildIndex(this.panelContinut, 0);
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picZonaImagine)).EndInit();
            this.panelContinut.ResumeLayout(false);
            this.splitGlobal.Panel1.ResumeLayout(false);
            this.splitGlobal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitGlobal)).EndInit();
            this.splitGlobal.ResumeLayout(false);
            this.panelOptiuni.ResumeLayout(false);
            this.panelImagine.ResumeLayout(false);
            this.panelContrast.ResumeLayout(false);
            this.panelContrast.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).EndInit();
            this.panelBrightness.ResumeLayout(false);
            this.panelBrightness.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrightness)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBoxPersonalizat picZonaImagine;
        private PanelPersonalizat panelContinut;
        private SplitContainerPersonalizat splitGlobal;
        private PanelPersonalizat panelImagine;
        private FlowLayoutPanelPersonalizat flpPreview;
        private ButtonPersonalizat btnPrint;
        private PanelPersonalizat panelOptiuni;
        private System.Windows.Forms.Button btnRotesteStanga;
        private System.Windows.Forms.Button btnRotesteDreapta;
        private System.Windows.Forms.Button btnBrughtness;
        private System.Windows.Forms.Button btnContrast;
        private System.Windows.Forms.Button btnSalveazaPeDisc;
        private PanelPersonalizat panelBrightness;
        private System.Windows.Forms.TrackBar tbBrightness;
        private PanelPersonalizat panelContrast;
        private System.Windows.Forms.TrackBar tbContrast;
        private System.Windows.Forms.Button btnInvert;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnImprimaImaginea;
    }
}