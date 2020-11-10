using System.Drawing;
using System.Drawing.Text;
using System.ComponentModel;


namespace CCL.UI.Caramizi.HTML
{

    /// <summary>
    /// Form used to enter an Html Font attribute
    /// Input based on the HtmlFontAttribute struct
    /// </summary>
    internal class FontAttributeForm : FormulareComune.frmCuHeader
	{
		private ButtonPersonalizat bCancel;
        private ButtonPersonalizat bApply;
        private IContainer components;
		private System.Windows.Forms.CheckBox checkBold;
		private System.Windows.Forms.CheckBox checkUnderline;
		private System.Windows.Forms.CheckBox checkItalic;
        private LabelPersonalizat labelSize;
		private System.Windows.Forms.CheckBox checkStrikeout;
		private System.Windows.Forms.CheckBox checkSubscript;
		private System.Windows.Forms.CheckBox checkSuperscript;
		private System.Windows.Forms.ComboBox listFontName;
		private System.Windows.Forms.ComboBox listFontSize;
		private LabelPersonalizat labelName;
        private LabelPersonalizat labelSample;
        private PanelPersonalizat panelGlobal;

		// variable for passing back and forth the font attributes
		HtmlFontProperty _font;

		// property to define the Font attribute for the text
		public HtmlFontProperty HtmlFont
		{
			get
			{
				// define the font attributes
				string fontName = this.listFontName.Text;
				HtmlFontSize fontSize = (HtmlFontSize)this.listFontSize.SelectedIndex;
				bool fontBold = this.checkBold.Checked;
				bool fontUnderline = this.checkUnderline.Checked;
				bool fontItalic = this.checkItalic.Checked;
				bool fontStrikeout = this.checkStrikeout.Checked;
				bool fontSuperscript = this.checkSuperscript.Checked;
				bool fontSubscript = this.checkSubscript.Checked;
				_font = new HtmlFontProperty(fontName, fontSize, fontBold, fontItalic, fontUnderline, fontStrikeout, fontSubscript, fontSuperscript);
				return _font;
			}
			set
			{
				_font = value;
				// define font name
				int selection = this.listFontName.FindString(_font.Name);
				this.listFontName.SelectedIndex = selection;
				// define font size
				this.listFontSize.SelectedIndex = (int)_font.Size;
				// define font properties
				this.checkBold.Checked = _font.Bold;
				this.checkUnderline.Checked = _font.Underline;
				this.checkItalic.Checked = _font.Italic;
				this.checkStrikeout.Checked = _font.Strikeout;
				this.checkSubscript.Checked = _font.Subscript;
				this.checkSuperscript.Checked = _font.Superscript;
				// set the sample text font
				SetFontTextSample();
			}

		} //HtmlFont

		public FontAttributeForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            this.Text = IHMUtile.getText(1223); // "Font Attributes";
            this.labelName.Text = IHMUtile.getText(1224); // "Font Name";
            this.labelSize.Text = IHMUtile.getText(1225); // "Font Size";
            this.checkBold.Text = IHMUtile.getText(1226); // "Bold";
            this.checkItalic.Text = IHMUtile.getText(1227); // "Italic";
            this.checkUnderline.Text = IHMUtile.getText(1228); // "Underline";
            this.checkStrikeout.Text = IHMUtile.getText(1229); // "Strikeout";
            this.checkSubscript.Text = IHMUtile.getText(1230); // "Subscript";
            this.checkSuperscript.Text = IHMUtile.getText(1231); // "Superscript";

			// populate the list of available fonts for selection
			LoadFonts();

            //permitem deplasarea ecranului si deschidem la pozitia mouse-ului in stanga jos
            DeschidereMouseStangaJosCuDeplasare();

		} //FontAttributeForm


		// loads into the list of font names
		// a series of font objects that represent the available fonts
		private void LoadFonts()
		{
			// suspend drawing
			this.listFontName.SuspendLayout();

			// load the installed fonts and iterate through the collections
			InstalledFontCollection fonts = new InstalledFontCollection();
			foreach (FontFamily family in fonts.Families) // FontFamily.Families
			{
				// ensure font supports regular, bolding, underlining, and italics
				if (family.IsStyleAvailable(FontStyle.Regular & FontStyle.Bold & FontStyle.Italic & FontStyle.Underline)) 
				{
					this.listFontName.Items.Add(family.Name);
				}
			}

			// define the selected item and resume drawing
			this.listFontName.SelectedIndex = 0;
			this.listFontName.ResumeLayout();

		} //LoadFonts


		// event handler for all functions that affect font sample
		// font name list and checkboxes for bold, itaic, underline
		private void FontSelectionChanged(object sender, System.EventArgs e)
		{
			SetFontTextSample();

		} //FontSelectionChanged

		// sets the sample font text based on the user selection
		private void SetFontTextSample()
		{
			string fontName = ((string)this.listFontName.SelectedItem);
			float fontSize = this.Font.Size + 2;
			bool fontBold = this.checkBold.Checked;
			bool fontUnderline = this.checkUnderline.Checked;
			bool fontItalic = this.checkItalic.Checked;
			bool fontStrikeout = this.checkStrikeout.Checked;
			FontStyle fontStyle = (fontBold ? FontStyle.Bold : FontStyle.Regular) | (fontItalic ? FontStyle.Italic : FontStyle.Regular) | (fontUnderline ? FontStyle.Underline : FontStyle.Regular) | (fontStrikeout ? FontStyle.Strikeout : FontStyle.Regular);
			// create the font object and define the labels fonts
			Font font = new Font(fontName, fontSize, fontStyle);
			this.labelSample.Font = font;

		} //SetFontTextSample


		// Clean up any resources being used.
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FontAttributeForm));
            this.bCancel = new CCL.UI.ButtonPersonalizat(this.components);
            this.bApply = new CCL.UI.ButtonPersonalizat(this.components);
            this.checkBold = new System.Windows.Forms.CheckBox();
            this.checkUnderline = new System.Windows.Forms.CheckBox();
            this.checkItalic = new System.Windows.Forms.CheckBox();
            this.labelSize = new CCL.UI.LabelPersonalizat(this.components);
            this.checkStrikeout = new System.Windows.Forms.CheckBox();
            this.checkSubscript = new System.Windows.Forms.CheckBox();
            this.checkSuperscript = new System.Windows.Forms.CheckBox();
            this.listFontName = new System.Windows.Forms.ComboBox();
            this.listFontSize = new System.Windows.Forms.ComboBox();
            this.labelName = new CCL.UI.LabelPersonalizat(this.components);
            this.labelSample = new CCL.UI.LabelPersonalizat(this.components);
            this.panelGlobal = new CCL.UI.PanelPersonalizat(this.components);
            this.panelGlobal.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(300, 19);
            this.lblTitluEcran.Text = "Font Attributes";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(299, 0);
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.bCancel.Image = ((System.Drawing.Image)(resources.GetObject("bCancel.Image")));
            this.bCancel.Location = new System.Drawing.Point(235, 224);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 0;
            this.bCancel.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Anulare;
            this.bCancel.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // bApply
            // 
            this.bApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bApply.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.bApply.Image = ((System.Drawing.Image)(resources.GetObject("bApply.Image")));
            this.bApply.Location = new System.Drawing.Point(155, 224);
            this.bApply.Name = "bApply";
            this.bApply.Size = new System.Drawing.Size(75, 23);
            this.bApply.TabIndex = 1;
            this.bApply.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Validare;
            this.bApply.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // checkBold
            // 
            this.checkBold.Location = new System.Drawing.Point(155, 56);
            this.checkBold.Name = "checkBold";
            this.checkBold.Size = new System.Drawing.Size(132, 19);
            this.checkBold.TabIndex = 2;
            this.checkBold.Text = "Bold";
            this.checkBold.CheckStateChanged += new System.EventHandler(this.FontSelectionChanged);
            // 
            // checkUnderline
            // 
            this.checkUnderline.Location = new System.Drawing.Point(155, 98);
            this.checkUnderline.Name = "checkUnderline";
            this.checkUnderline.Size = new System.Drawing.Size(132, 19);
            this.checkUnderline.TabIndex = 3;
            this.checkUnderline.Text = "Underline";
            this.checkUnderline.CheckStateChanged += new System.EventHandler(this.FontSelectionChanged);
            // 
            // checkItalic
            // 
            this.checkItalic.Location = new System.Drawing.Point(155, 77);
            this.checkItalic.Name = "checkItalic";
            this.checkItalic.Size = new System.Drawing.Size(132, 19);
            this.checkItalic.TabIndex = 4;
            this.checkItalic.Text = "Italic";
            this.checkItalic.CheckStateChanged += new System.EventHandler(this.FontSelectionChanged);
            // 
            // labelSize
            // 
            this.labelSize.Location = new System.Drawing.Point(155, 11);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(120, 16);
            this.labelSize.TabIndex = 6;
            this.labelSize.Text = "Font Size";
            this.labelSize.ToolTipText = null;
            this.labelSize.ToolTipTitle = null;
            // 
            // checkStrikeout
            // 
            this.checkStrikeout.Location = new System.Drawing.Point(155, 119);
            this.checkStrikeout.Name = "checkStrikeout";
            this.checkStrikeout.Size = new System.Drawing.Size(132, 19);
            this.checkStrikeout.TabIndex = 7;
            this.checkStrikeout.Text = "Strikeout";
            this.checkStrikeout.CheckStateChanged += new System.EventHandler(this.FontSelectionChanged);
            // 
            // checkSubscript
            // 
            this.checkSubscript.Location = new System.Drawing.Point(155, 146);
            this.checkSubscript.Name = "checkSubscript";
            this.checkSubscript.Size = new System.Drawing.Size(132, 19);
            this.checkSubscript.TabIndex = 8;
            this.checkSubscript.Text = "Subscript";
            // 
            // checkSuperscript
            // 
            this.checkSuperscript.Location = new System.Drawing.Point(155, 167);
            this.checkSuperscript.Name = "checkSuperscript";
            this.checkSuperscript.Size = new System.Drawing.Size(132, 19);
            this.checkSuperscript.TabIndex = 9;
            this.checkSuperscript.Text = "Superscript";
            // 
            // listFontName
            // 
            this.listFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.listFontName.Location = new System.Drawing.Point(11, 27);
            this.listFontName.Name = "listFontName";
            this.listFontName.Size = new System.Drawing.Size(121, 160);
            this.listFontName.TabIndex = 10;
            this.listFontName.SelectedIndexChanged += new System.EventHandler(this.FontSelectionChanged);
            // 
            // listFontSize
            // 
            this.listFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listFontSize.Items.AddRange(new object[] {
            "Default",
            "1 : 8  points",
            "2 : 10 points",
            "3 : 12 points",
            "4 : 14 points",
            "5 : 18 points",
            "6 : 24 points",
            "7 : 36 points"});
            this.listFontSize.Location = new System.Drawing.Point(155, 27);
            this.listFontSize.Name = "listFontSize";
            this.listFontSize.Size = new System.Drawing.Size(121, 21);
            this.listFontSize.TabIndex = 11;
            // 
            // labelName
            // 
            this.labelName.Location = new System.Drawing.Point(11, 11);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(120, 16);
            this.labelName.TabIndex = 12;
            this.labelName.Text = "Font Name";
            this.labelName.ToolTipText = null;
            this.labelName.ToolTipTitle = null;
            // 
            // labelSample
            // 
            this.labelSample.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSample.Location = new System.Drawing.Point(11, 195);
            this.labelSample.Name = "labelSample";
            this.labelSample.Size = new System.Drawing.Size(120, 23);
            this.labelSample.TabIndex = 13;
            this.labelSample.Text = "iDava AaZa19";
            this.labelSample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelSample.ToolTipText = null;
            this.labelSample.ToolTipTitle = null;
            // 
            // panelGlobal
            // 
            this.panelGlobal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGlobal.BackColor = System.Drawing.Color.Linen;
            this.panelGlobal.Controls.Add(this.labelName);
            this.panelGlobal.Controls.Add(this.bCancel);
            this.panelGlobal.Controls.Add(this.labelSample);
            this.panelGlobal.Controls.Add(this.bApply);
            this.panelGlobal.Controls.Add(this.checkBold);
            this.panelGlobal.Controls.Add(this.listFontSize);
            this.panelGlobal.Controls.Add(this.checkUnderline);
            this.panelGlobal.Controls.Add(this.listFontName);
            this.panelGlobal.Controls.Add(this.checkItalic);
            this.panelGlobal.Controls.Add(this.checkSuperscript);
            this.panelGlobal.Controls.Add(this.labelSize);
            this.panelGlobal.Controls.Add(this.checkSubscript);
            this.panelGlobal.Controls.Add(this.checkStrikeout);
            this.panelGlobal.Location = new System.Drawing.Point(1, 19);
            this.panelGlobal.Name = "panelGlobal";
            this.panelGlobal.Size = new System.Drawing.Size(320, 252);
            this.panelGlobal.TabIndex = 14;
            this.panelGlobal.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Tab;
            // 
            // FontAttributeForm
            // 
            this.AcceptButton = this.bApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(322, 272);
            this.Controls.Add(this.panelGlobal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FontAttributeForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Font Attributes";
            this.Controls.SetChildIndex(this.panelGlobal, 0);
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.panelGlobal.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

	}
}
