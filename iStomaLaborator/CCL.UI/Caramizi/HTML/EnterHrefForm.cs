using System;
using System.Drawing;
using System.ComponentModel;

namespace CCL.UI.Caramizi.HTML
{

    /// <summary>
    /// Form used to enter an Html Anchor attribute
    /// Consists of Href, Text and Target Frame
    /// </summary>
    internal class EnterHrefForm : FormulareComune.frmCuHeader
	{
		private ButtonPersonalizat bInsert;
        private ButtonPersonalizat bRemove;
        private ButtonPersonalizat bCancel;
		private LabelPersonalizat labelText;
        private LabelPersonalizat labelHref;
        private Caramizi.TextBoxGuma hrefText;
        private Caramizi.TextBoxGuma hrefLink;
        private LabelPersonalizat labelTarget;
        private System.Windows.Forms.ComboBox listTargets;
        private PanelPersonalizat panelGlobal;
        private IContainer components;

		public EnterHrefForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            this.Text = IHMUtile.getText(1219); // "Enter Href";
            this.labelHref.Text = IHMUtile.getText(1220); // "Href:";
            this.labelTarget.Text = IHMUtile.getText(1221); // "Target:";
            this.labelText.Text = IHMUtile.getText(1222); // "Text:";
            this.hrefText.CapitalizeazaPrimaLitera = false;
            this.hrefText.CapitalizeazaCuvintele = false;
            this.hrefLink.CapitalizeazaPrimaLitera = false;
            this.hrefLink.CapitalizeazaCuvintele = false;

            this.panelGlobal.BackColor = Color.White;

			// define the text for the targets
			this.listTargets.Items.AddRange(Enum.GetNames(typeof(NavigateActionOption)));

			// ensure default value set for target
			this.listTargets.SelectedIndex = 1;

            //permitem deplasarea ecranului si deschidem la pozitia mouse-ului in stanga jos
            DeschidereMouseStangaJosCuDeplasare();

		} //EnterHrefForm


		// property for the text to display
		public string HrefText
		{
			get
			{
				return this.hrefText.Text;
			}
			set
			{
				this.hrefText.Text = value;
                if (!string.IsNullOrEmpty(value))
                    this.hrefText.IsInReadOnlyMode = true;
                this.hrefText.AllowModification(true);
			}

		} //HrefText

		//property for the href target
		public NavigateActionOption HrefTarget
		{
			get
			{
				return (NavigateActionOption)this.listTargets.SelectedIndex;
			}
		}

		// property for the href for the text
		public string HrefLink
		{
			get
			{
				return this.hrefLink.Text.Trim();
			}
			set
			{
				this.hrefLink.Text = value.Trim();
			}

		} //HrefLink


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnterHrefForm));
            this.bInsert = new CCL.UI.ButtonPersonalizat(this.components);
            this.bRemove = new CCL.UI.ButtonPersonalizat(this.components);
            this.bCancel = new CCL.UI.ButtonPersonalizat(this.components);
            this.labelText = new CCL.UI.LabelPersonalizat(this.components);
            this.labelHref = new CCL.UI.LabelPersonalizat(this.components);
            this.hrefText = new CCL.UI.Caramizi.TextBoxGuma();
            this.hrefLink = new CCL.UI.Caramizi.TextBoxGuma();
            this.labelTarget = new CCL.UI.LabelPersonalizat(this.components);
            this.listTargets = new System.Windows.Forms.ComboBox();
            this.panelGlobal = new CCL.UI.PanelPersonalizat(this.components);
            this.panelGlobal.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(410, 19);
            this.lblTitluEcran.TabIndex = 1;
            this.lblTitluEcran.Text = "Enter Href";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(409, 0);
            this.btnInchidereEcran.TabIndex = 2;
            // 
            // bInsert
            // 
            this.bInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bInsert.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.bInsert.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.bInsert.Image = ((System.Drawing.Image)(resources.GetObject("bInsert.Image")));
            this.bInsert.Location = new System.Drawing.Point(183, 101);
            this.bInsert.Name = "bInsert";
            this.bInsert.Size = new System.Drawing.Size(75, 23);
            this.bInsert.TabIndex = 6;
            this.bInsert.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Validare;
            this.bInsert.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // bRemove
            // 
            this.bRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bRemove.DialogResult = System.Windows.Forms.DialogResult.No;
            this.bRemove.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bRemove.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.bRemove.Image = ((System.Drawing.Image)(resources.GetObject("bRemove.Image")));
            this.bRemove.Location = new System.Drawing.Point(263, 101);
            this.bRemove.Name = "bRemove";
            this.bRemove.Size = new System.Drawing.Size(80, 23);
            this.bRemove.TabIndex = 7;
            this.bRemove.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Guma;
            this.bRemove.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.bCancel.Image = ((System.Drawing.Image)(resources.GetObject("bCancel.Image")));
            this.bCancel.Location = new System.Drawing.Point(351, 101);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 8;
            this.bCancel.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Anulare;
            this.bCancel.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // labelText
            // 
            this.labelText.BackColor = System.Drawing.Color.Transparent;
            this.labelText.Location = new System.Drawing.Point(7, 10);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(40, 23);
            this.labelText.TabIndex = 1;
            this.labelText.Text = "Text:";
            this.labelText.ToolTipText = null;
            this.labelText.ToolTipTitle = null;
            // 
            // labelHref
            // 
            this.labelHref.BackColor = System.Drawing.Color.Transparent;
            this.labelHref.Location = new System.Drawing.Point(7, 42);
            this.labelHref.Name = "labelHref";
            this.labelHref.Size = new System.Drawing.Size(40, 23);
            this.labelHref.TabIndex = 3;
            this.labelHref.Text = "Href:";
            this.labelHref.ToolTipText = null;
            this.labelHref.ToolTipTitle = null;
            // 
            // hrefText
            // 
            this.hrefText.AcceptButton = null;
            this.hrefText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hrefText.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.hrefText.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.hrefText.IsInReadOnlyMode = false;
            this.hrefText.Location = new System.Drawing.Point(55, 10);
            this.hrefText.MaxLength = 32767;
            this.hrefText.Multiline = false;
            this.hrefText.Name = "hrefText";
            this.hrefText.ProprietateCorespunzatoare = null;
            this.hrefText.RaiseEventLaModificareProgramatica = false;
            this.hrefText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.hrefText.Size = new System.Drawing.Size(368, 20);
            this.hrefText.TabIndex = 0;
            this.hrefText.TextBackColor = System.Drawing.SystemColors.Window;
            this.hrefText.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.hrefText.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.hrefText.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.hrefText.UseSystemPasswordChar = false;
            this.hrefText.UtilizeazaButonGuma = false;
            // 
            // hrefLink
            // 
            this.hrefLink.AcceptButton = null;
            this.hrefLink.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hrefLink.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.hrefLink.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.hrefLink.IsInReadOnlyMode = false;
            this.hrefLink.Location = new System.Drawing.Point(55, 42);
            this.hrefLink.MaxLength = 32767;
            this.hrefLink.Multiline = false;
            this.hrefLink.Name = "hrefLink";
            this.hrefLink.ProprietateCorespunzatoare = null;
            this.hrefLink.RaiseEventLaModificareProgramatica = false;
            this.hrefLink.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.hrefLink.Size = new System.Drawing.Size(368, 20);
            this.hrefLink.TabIndex = 2;
            this.hrefLink.TextBackColor = System.Drawing.SystemColors.Window;
            this.hrefLink.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.hrefLink.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.hrefLink.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.hrefLink.UseSystemPasswordChar = false;
            this.hrefLink.UtilizeazaButonGuma = false;
            // 
            // labelTarget
            // 
            this.labelTarget.BackColor = System.Drawing.Color.Transparent;
            this.labelTarget.Location = new System.Drawing.Point(7, 74);
            this.labelTarget.Name = "labelTarget";
            this.labelTarget.Size = new System.Drawing.Size(40, 23);
            this.labelTarget.TabIndex = 5;
            this.labelTarget.Text = "Target:";
            this.labelTarget.ToolTipText = null;
            this.labelTarget.ToolTipTitle = null;
            this.labelTarget.Visible = false;
            // 
            // listTargets
            // 
            this.listTargets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listTargets.Location = new System.Drawing.Point(55, 74);
            this.listTargets.Name = "listTargets";
            this.listTargets.Size = new System.Drawing.Size(121, 21);
            this.listTargets.TabIndex = 4;
            this.listTargets.Visible = false;
            // 
            // panelGlobal
            // 
            this.panelGlobal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGlobal.BackColor = System.Drawing.Color.Linen;
            this.panelGlobal.Controls.Add(this.labelText);
            this.panelGlobal.Controls.Add(this.bInsert);
            this.panelGlobal.Controls.Add(this.listTargets);
            this.panelGlobal.Controls.Add(this.bRemove);
            this.panelGlobal.Controls.Add(this.labelTarget);
            this.panelGlobal.Controls.Add(this.bCancel);
            this.panelGlobal.Controls.Add(this.hrefLink);
            this.panelGlobal.Controls.Add(this.labelHref);
            this.panelGlobal.Controls.Add(this.hrefText);
            this.panelGlobal.Location = new System.Drawing.Point(1, 19);
            this.panelGlobal.Name = "panelGlobal";
            this.panelGlobal.Size = new System.Drawing.Size(430, 130);
            this.panelGlobal.TabIndex = 0;
            this.panelGlobal.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Tab;
            // 
            // EnterHrefForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(432, 150);
            this.Controls.Add(this.panelGlobal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnterHrefForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Enter Href";
            this.Controls.SetChildIndex(this.panelGlobal, 0);
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.panelGlobal.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

	}
}
