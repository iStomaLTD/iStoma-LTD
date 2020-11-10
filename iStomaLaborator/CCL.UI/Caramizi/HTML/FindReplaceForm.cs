using System.ComponentModel;
using System.Windows.Forms;

namespace CCL.UI.Caramizi.HTML
{

    /// <summary>
    /// Form designed to control Find and Replace operations
    /// Find and Replace operations performed by the user control class
    /// Delegates need to be defined to reference the class instances
    /// </summary> 
    internal class FindReplaceForm : FormulareComune.frmCuHeader
	{

		private System.Windows.Forms.TabPage tabFind;
		private System.Windows.Forms.TabPage tabReplace;
		private LabelPersonalizat labelFind;
        private System.Windows.Forms.TabControl tabControl;
		private Caramizi.TextBoxGuma textFind;
        private ButtonPersonalizat bFindNext;
        private LabelPersonalizat labelReplace;
        private ButtonPersonalizat bReplaceAll;
        private ButtonPersonalizat bReplace;
        private ButtonPersonalizat bOptions;
		private System.Windows.Forms.CheckBox optionMatchCase;
		private System.Windows.Forms.CheckBox optionMatchWhole;
        private Caramizi.TextBoxGuma textReplace;
		private System.Windows.Forms.Panel panelOptions;
        private System.Windows.Forms.Panel panelInput;
        private IContainer components;

		// private variables defining the state of the form
		private bool options = false;
		private bool findNotReplace  = true;
		private string findText;
		private string replaceText;

		// internal delegate reference
		private FindReplaceResetDelegate FindReplaceReset;
        private FindReplaceOneDelegate FindReplaceOne;
		private FindReplaceAllDelegate FindReplaceAll;
		private FindFirstDelegate FindFirst;
        private PanelPersonalizat panelGlobal;
		private FindNextDelegate FindNext;


		// public constructor that defines the required delegates
		// delegates must be defined for the find and replace to operate
		public FindReplaceForm(string initText, FindReplaceResetDelegate resetDelegate, FindFirstDelegate findFirstDelegate, FindNextDelegate findNextDelegate, FindReplaceOneDelegate replaceOneDelegate, FindReplaceAllDelegate replaceAllDelegate)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            this.Text = IHMUtile.getText(1232); // "Find and Replace";
            this.tabFind.Text = IHMUtile.getText(1233); // "Find";
            this.tabFind.ToolTipText = IHMUtile.getText(1234); // "Find Text";
            this.tabReplace.Text = IHMUtile.getText(1235); // "Replace";
            this.tabReplace.ToolTipText = IHMUtile.getText(1236); // "Find and Replace Text";
            this.labelFind.Text = IHMUtile.getText(1237); // "Find What:";
            this.labelReplace.Text = IHMUtile.getText(1238); // "Replace  With:";
            this.optionMatchCase.Text = IHMUtile.getText(1239); // "Match Exact Case";
            this.optionMatchWhole.Text = IHMUtile.getText(1240); // "Match Whole Word Only";
            this.bOptions.Text = IHMUtile.getText(1241); // "Options";
            this.bFindNext.Text = IHMUtile.getText(1243); // "Find Next";
            this.bReplace.Text = IHMUtile.getText(1235); // "Replace";
            this.bReplaceAll.Text = IHMUtile.getText(1244); // "Replace All";

			// Define the initial state of the form assuming a Find command to be displayed first
			DefineFindWindow(findNotReplace);
			DefineOptionsWindow(options);

			// ensure buttons not initially enabled
			this.bFindNext.Enabled = false;
			this.bReplace.Enabled = false;
			this.bReplaceAll.Enabled = false;

			// save the delegates used to perform find and replcae operations
			this.FindReplaceReset = resetDelegate;
			this.FindFirst = findFirstDelegate;
			this.FindNext = findNextDelegate;
			this.FindReplaceOne = replaceOneDelegate;
			this.FindReplaceAll = replaceAllDelegate;

			// define the original text
			this.textFind.Text = initText;

            //permitem deplasarea ecranului si deschidem la pozitia mouse-ului in stanga jos
            DeschidereMouseStangaJosCuDeplasare();

		} //FindReplaceForm


		// setup the properties based on the find or repalce functionality
		private void DefineFindWindow(bool find)
		{
			this.textReplace.Visible = !find;
			this.labelReplace.Visible = !find;
			this.bReplace.Visible = !find;
			this.bReplaceAll.Visible = !find;
			this.textFind.Focus();

		} //DefineFindWindow


		// define if the options dialog is shown
		private void DefineOptionsWindow(bool options)
		{
			if (options)
			{
				// Form displayed with the options shown
                this.bOptions.Text = IHMUtile.getText(1242); //"Less Options";
				this.panelOptions.Visible = true;
				this.tabControl.Height = 216;
				this.Height = 264;
				this.optionMatchCase.Focus();
			}
			else
			{
				// Form displayed without the options shown
                this.bOptions.Text = IHMUtile.getText(1241); //"More Options";
				this.panelOptions.Visible = false;
				this.tabControl.Height = 152;
				this.Height = 200;
				this.textFind.Focus();
			}

		} //DefineOptionsWindow


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

		} //Dispose

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabFind = new System.Windows.Forms.TabPage();
            this.tabReplace = new System.Windows.Forms.TabPage();
            this.labelFind = new CCL.UI.LabelPersonalizat(this.components);
            this.textFind = new CCL.UI.Caramizi.TextBoxGuma();
            this.bFindNext = new CCL.UI.ButtonPersonalizat(this.components);
            this.labelReplace = new CCL.UI.LabelPersonalizat(this.components);
            this.textReplace = new CCL.UI.Caramizi.TextBoxGuma();
            this.bReplaceAll = new CCL.UI.ButtonPersonalizat(this.components);
            this.bReplace = new CCL.UI.ButtonPersonalizat(this.components);
            this.bOptions = new CCL.UI.ButtonPersonalizat(this.components);
            this.optionMatchCase = new System.Windows.Forms.CheckBox();
            this.optionMatchWhole = new System.Windows.Forms.CheckBox();
            this.panelOptions = new System.Windows.Forms.Panel();
            this.panelInput = new System.Windows.Forms.Panel();
            this.panelGlobal = new CCL.UI.PanelPersonalizat(this.components);
            this.tabControl.SuspendLayout();
            this.panelOptions.SuspendLayout();
            this.panelInput.SuspendLayout();
            this.panelGlobal.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(462, 19);
            this.lblTitluEcran.Text = "Find and Replace";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(461, 0);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabFind);
            this.tabControl.Controls.Add(this.tabReplace);
            this.tabControl.Location = new System.Drawing.Point(1, 1);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.ShowToolTips = true;
            this.tabControl.Size = new System.Drawing.Size(481, 32);
            this.tabControl.TabIndex = 0;
            this.tabControl.TabStop = false;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabFind
            // 
            this.tabFind.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabFind.Location = new System.Drawing.Point(4, 22);
            this.tabFind.Name = "tabFind";
            this.tabFind.Size = new System.Drawing.Size(473, 6);
            this.tabFind.TabIndex = 0;
            this.tabFind.Text = "Find";
            this.tabFind.ToolTipText = "Find Text";
            // 
            // tabReplace
            // 
            this.tabReplace.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabReplace.Location = new System.Drawing.Point(4, 22);
            this.tabReplace.Name = "tabReplace";
            this.tabReplace.Size = new System.Drawing.Size(471, 6);
            this.tabReplace.TabIndex = 1;
            this.tabReplace.Text = "Replace";
            this.tabReplace.ToolTipText = "Find and Replace Text";
            // 
            // labelFind
            // 
            this.labelFind.Location = new System.Drawing.Point(8, 16);
            this.labelFind.Name = "labelFind";
            this.labelFind.Size = new System.Drawing.Size(96, 20);
            this.labelFind.TabIndex = 0;
            this.labelFind.Text = "Find What:";
            this.labelFind.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelFind.ToolTipText = null;
            this.labelFind.ToolTipTitle = null;
            // 
            // textFind
            // 
            this.textFind.AcceptButton = null;
            this.textFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textFind.IsInReadOnlyMode = false;
            this.textFind.Location = new System.Drawing.Point(112, 16);
            this.textFind.MaxLength = 32767;
            this.textFind.Multiline = false;
            this.textFind.Name = "textFind";
            this.textFind.ProprietateCorespunzatoare = null;
            this.textFind.RaiseEventLaModificareProgramatica = false;
            this.textFind.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textFind.Size = new System.Drawing.Size(337, 20);
            this.textFind.TabIndex = 1;
            this.textFind.TextBackColor = System.Drawing.SystemColors.Window;
            this.textFind.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textFind.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.textFind.CerereUpdate += new CCL.UI.CEvenimente.ZonaModificata(this.textFind_CerereUpdate);
            this.textFind.KeyUpPersonalizat += new System.Windows.Forms.KeyEventHandler(this.textFind_KeyUpPersonalizat);
            // 
            // bFindNext
            // 
            this.bFindNext.BackColor = System.Drawing.SystemColors.Control;
            this.bFindNext.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bFindNext.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.bFindNext.Location = new System.Drawing.Point(344, 80);
            this.bFindNext.Name = "bFindNext";
            this.bFindNext.Size = new System.Drawing.Size(105, 23);
            this.bFindNext.TabIndex = 3;
            this.bFindNext.Text = "Find Next";
            this.bFindNext.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.bFindNext.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.bFindNext.UseVisualStyleBackColor = false;
            this.bFindNext.Click += new System.EventHandler(this.bFindNext_Click);
            // 
            // labelReplace
            // 
            this.labelReplace.Location = new System.Drawing.Point(8, 48);
            this.labelReplace.Name = "labelReplace";
            this.labelReplace.Size = new System.Drawing.Size(96, 20);
            this.labelReplace.TabIndex = 0;
            this.labelReplace.Text = "Replace  With:";
            this.labelReplace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelReplace.ToolTipText = null;
            this.labelReplace.ToolTipTitle = null;
            // 
            // textReplace
            // 
            this.textReplace.AcceptButton = null;
            this.textReplace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textReplace.IsInReadOnlyMode = false;
            this.textReplace.Location = new System.Drawing.Point(112, 48);
            this.textReplace.MaxLength = 32767;
            this.textReplace.Multiline = false;
            this.textReplace.Name = "textReplace";
            this.textReplace.ProprietateCorespunzatoare = null;
            this.textReplace.RaiseEventLaModificareProgramatica = false;
            this.textReplace.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textReplace.Size = new System.Drawing.Size(337, 20);
            this.textReplace.TabIndex = 2;
            this.textReplace.TextBackColor = System.Drawing.SystemColors.Window;
            this.textReplace.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textReplace.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.textReplace.CerereUpdate += new CCL.UI.CEvenimente.ZonaModificata(this.textReplace_CerereUpdate);
            this.textReplace.KeyUpPersonalizat += new System.Windows.Forms.KeyEventHandler(this.textReplace_KeyUpPersonalizat);
            // 
            // bReplaceAll
            // 
            this.bReplaceAll.BackColor = System.Drawing.SystemColors.Control;
            this.bReplaceAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bReplaceAll.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.bReplaceAll.Location = new System.Drawing.Point(228, 80);
            this.bReplaceAll.Name = "bReplaceAll";
            this.bReplaceAll.Size = new System.Drawing.Size(105, 23);
            this.bReplaceAll.TabIndex = 7;
            this.bReplaceAll.Text = "Replace All";
            this.bReplaceAll.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.bReplaceAll.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.bReplaceAll.UseVisualStyleBackColor = false;
            this.bReplaceAll.Click += new System.EventHandler(this.bReplaceAll_Click);
            // 
            // bReplace
            // 
            this.bReplace.BackColor = System.Drawing.SystemColors.Control;
            this.bReplace.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bReplace.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.bReplace.Location = new System.Drawing.Point(112, 80);
            this.bReplace.Name = "bReplace";
            this.bReplace.Size = new System.Drawing.Size(105, 23);
            this.bReplace.TabIndex = 6;
            this.bReplace.Text = "Replace";
            this.bReplace.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.bReplace.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.bReplace.UseVisualStyleBackColor = false;
            this.bReplace.Click += new System.EventHandler(this.bReplace_Click);
            // 
            // bOptions
            // 
            this.bOptions.BackColor = System.Drawing.SystemColors.Control;
            this.bOptions.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bOptions.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.bOptions.Location = new System.Drawing.Point(6, 80);
            this.bOptions.Name = "bOptions";
            this.bOptions.Size = new System.Drawing.Size(85, 23);
            this.bOptions.TabIndex = 5;
            this.bOptions.Text = "Options";
            this.bOptions.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Standard;
            this.bOptions.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.bOptions.UseVisualStyleBackColor = false;
            this.bOptions.Click += new System.EventHandler(this.bOptions_Click);
            // 
            // optionMatchCase
            // 
            this.optionMatchCase.AutoSize = true;
            this.optionMatchCase.Location = new System.Drawing.Point(8, 8);
            this.optionMatchCase.Name = "optionMatchCase";
            this.optionMatchCase.Size = new System.Drawing.Size(113, 17);
            this.optionMatchCase.TabIndex = 8;
            this.optionMatchCase.Text = "Match Exact Case";
            // 
            // optionMatchWhole
            // 
            this.optionMatchWhole.AutoSize = true;
            this.optionMatchWhole.Location = new System.Drawing.Point(8, 32);
            this.optionMatchWhole.Name = "optionMatchWhole";
            this.optionMatchWhole.Size = new System.Drawing.Size(143, 17);
            this.optionMatchWhole.TabIndex = 9;
            this.optionMatchWhole.Text = "Match Whole Word Only";
            // 
            // panelOptions
            // 
            this.panelOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOptions.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelOptions.Controls.Add(this.optionMatchCase);
            this.panelOptions.Controls.Add(this.optionMatchWhole);
            this.panelOptions.Location = new System.Drawing.Point(9, 145);
            this.panelOptions.Name = "panelOptions";
            this.panelOptions.Size = new System.Drawing.Size(469, 64);
            this.panelOptions.TabIndex = 8;
            // 
            // panelInput
            // 
            this.panelInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelInput.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelInput.Controls.Add(this.labelFind);
            this.panelInput.Controls.Add(this.textFind);
            this.panelInput.Controls.Add(this.labelReplace);
            this.panelInput.Controls.Add(this.textReplace);
            this.panelInput.Controls.Add(this.bOptions);
            this.panelInput.Controls.Add(this.bReplace);
            this.panelInput.Controls.Add(this.bReplaceAll);
            this.panelInput.Controls.Add(this.bFindNext);
            this.panelInput.Location = new System.Drawing.Point(9, 33);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(469, 112);
            this.panelInput.TabIndex = 9;
            // 
            // panelGlobal
            // 
            this.panelGlobal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGlobal.BackColor = System.Drawing.Color.Linen;
            this.panelGlobal.Controls.Add(this.panelOptions);
            this.panelGlobal.Controls.Add(this.panelInput);
            this.panelGlobal.Controls.Add(this.tabControl);
            this.panelGlobal.Location = new System.Drawing.Point(1, 19);
            this.panelGlobal.Name = "panelGlobal";
            this.panelGlobal.Size = new System.Drawing.Size(482, 210);
            this.panelGlobal.TabIndex = 10;
            this.panelGlobal.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Tab;
            // 
            // FindReplaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(484, 230);
            this.Controls.Add(this.panelGlobal);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindReplaceForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Find and Replace";
            this.Controls.SetChildIndex(this.panelGlobal, 0);
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.tabControl.ResumeLayout(false);
            this.panelOptions.ResumeLayout(false);
            this.panelOptions.PerformLayout();
            this.panelInput.ResumeLayout(false);
            this.panelGlobal.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion


		// define the visibility of the options
		// based on the user clicking the options button
		private void bOptions_Click(object sender, System.EventArgs e)
		{
			options = !options;
			DefineOptionsWindow(options);

		} //OptionsClick


		// set the state of the form based on the index slected
		private void tabControl_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.tabControl.SelectedIndex == 0)
			{
				findNotReplace = true;
			}
			else
			{
				findNotReplace = false;
			}
			DefineFindWindow(findNotReplace);
		
		} //SelectedIndexChanged


		// replace a given text string with the replace value
		private void bReplace_Click(object sender, System.EventArgs e)
		{
			// find and replace the given text
			if (!this.FindReplaceOne(findText, replaceText, this.optionMatchWhole.Checked, this.optionMatchCase.Checked)) 
			{
                Mesaj.Afiseaza(this, IHMUtile.getText(1245), IHMUtile.getText(1232), Mesaj.EnumButoane.OK, Mesaj.EnumIcoana.Informatie);//"All occurrences have been replaced!", "Find and Replace");
			}
		
		} //ReplaceClick


		// replace all occurences of a string with the replace value
		private void bReplaceAll_Click(object sender, System.EventArgs e)
		{
			int found = this.FindReplaceAll(findText, replaceText, this.optionMatchWhole.Checked, this.optionMatchCase.Checked);

			// indicate the number of replaces found
            Mesaj.Afiseaza(this, string.Format(IHMUtile.getText(1246), found), IHMUtile.getText(1232), Mesaj.EnumButoane.OK, Mesaj.EnumIcoana.Informatie);//string.Format("{0} occurrences replaced", found), "Find and Replace");
		
		} // ReplaceAllClick


		// find the next occurence of the given string
		private void bFindNext_Click(object sender, System.EventArgs e)
		{
			// once find has completed indicate to the user success or failure
			if (!this.FindNext(findText, this.optionMatchWhole.Checked, this.optionMatchCase.Checked))
			{
                Mesaj.Afiseaza(this, IHMUtile.getText(1247), IHMUtile.getText(1232), Mesaj.EnumButoane.OK, Mesaj.EnumIcoana.Informatie);//"No more occurrences found!", "Find and Replace");
			}
		
		} //FindNextClick

        private void textFind_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            ResetTextState();
        }

        private void textReplace_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            ResetTextState();
        }

        private void textFind_KeyUpPersonalizat(object sender, KeyEventArgs e)
        {
            ResetTextState();
        }

        private void textReplace_KeyUpPersonalizat(object sender, KeyEventArgs e)
        {
            ResetTextState();
        }

		// sets the form state based on user input for Replace
		private void ResetTextState()
		{
			// reset the range being worked with
			this.FindReplaceReset();

			// determine the text values
			findText = this.textFind.Text.Trim();
			replaceText = this.textReplace.Text.Trim();

			// if no find text available disable find button
			if (findText != string.Empty)
			{
				this.bFindNext.Enabled = true;
			}
			else
			{
				this.bFindNext.Enabled = false;
			}

			// if no find text available disable replace button
			if (this.textFind.Text.Trim() != string.Empty && replaceText != string.Empty)
			{
				this.bReplace.Enabled = true;
				this.bReplaceAll.Enabled = true;
			}
			else
			{
				this.bReplace.Enabled = false;
				this.bReplaceAll.Enabled = false;
			}

		} //ResetTextReplace

	}
}
