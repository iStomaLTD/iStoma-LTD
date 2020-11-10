using iStomaLab.Caramizi;

namespace iStomaLab.Generale
{
    partial class ControlAdresaISTOMA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlAdresaISTOMA));
            this.chkActuala = new CCL.UI.CheckBoxPersonalizat(this.components);
            this.txtInterfon = new CCL.UI.Caramizi.TextBoxGuma();
            this.lblInterfon = new CCL.UI.LabelPersonalizat(this.components);
            this.cboTipAdresa = new CCL.UI.Caramizi.ComboBoxGuma();
            this.txtNumar = new CCL.UI.Caramizi.TextBoxGuma();
            this.txtStrada = new CCL.UI.Caramizi.TextBoxGuma();
            this.txtApartament = new CCL.UI.Caramizi.TextBoxGuma();
            this.txtEtaj = new CCL.UI.Caramizi.TextBoxGuma();
            this.txtScara = new CCL.UI.Caramizi.TextBoxGuma();
            this.txtBloc = new CCL.UI.Caramizi.TextBoxGuma();
            this.ctrlTara = new iStomaLab.Caramizi.ControlCautareTara();
            this.lblTara = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlRegiune = new iStomaLab.Caramizi.ControlCautareRegiune();
            this.ctrlLocalitate = new iStomaLab.Caramizi.ControlCautareLocalitate();
            this.txtFax = new CCL.UI.Caramizi.MaskedTextBoxGuma();
            this.txtTelefon = new CCL.UI.Caramizi.MaskedTextBoxGuma();
            this.ctrlDataVerificare = new CCL.UI.controlAlegeData();
            this.lblDataVerificare = new CCL.UI.LabelPersonalizat(this.components);
            this.lblFax = new CCL.UI.LabelPersonalizat(this.components);
            this.lblTelefonFix = new CCL.UI.LabelPersonalizat(this.components);
            this.lblCP = new CCL.UI.LabelPersonalizat(this.components);
            this.lblJudet = new CCL.UI.LabelPersonalizat(this.components);
            this.lblLocalitate = new CCL.UI.LabelPersonalizat(this.components);
            this.lblAp = new CCL.UI.LabelPersonalizat(this.components);
            this.lblEtaj = new CCL.UI.LabelPersonalizat(this.components);
            this.lblScara = new CCL.UI.LabelPersonalizat(this.components);
            this.lblBloc = new CCL.UI.LabelPersonalizat(this.components);
            this.lblNr = new CCL.UI.LabelPersonalizat(this.components);
            this.lblStrada = new CCL.UI.LabelPersonalizat(this.components);
            this.lblTip = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlInchidere = new iStomaLab.Caramizi.controlInchidere();
            this.ctrlCreare = new iStomaLab.Caramizi.controlCreare();
            this.cboListaAdrese = new CCL.UI.ComboBoxPersonalizat(this.components);
            this.panelDetaliiAdresa = new CCL.UI.PanelPersonalizat(this.components);
            this.panelOptiuni = new CCL.UI.PanelPersonalizat(this.components);
            this.btnInchidePanelOptiuni = new System.Windows.Forms.Button();
            this.btnOptiuni = new CCL.UI.ButtonPersonalizat(this.components);
            this.txtComentarii = new CCL.UI.Caramizi.TextBoxGuma();
            this.flpOptiuni = new CCL.UI.FlowLayoutPanelPersonalizat(this.components);
            this.btnStareAdrese = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnAdauga = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnValidare = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnCreeazaSelecteaza = new CCL.UI.ButtonPersonalizat(this.components);
            this.btnAnulare = new CCL.UI.ButtonPersonalizat(this.components);
            this.panelDetaliiAdresa.SuspendLayout();
            this.panelOptiuni.SuspendLayout();
            this.flpOptiuni.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkActuala
            // 
            this.chkActuala.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkActuala.AutoSize = true;
            this.chkActuala.IsInReadOnlyMode = false;
            this.chkActuala.Location = new System.Drawing.Point(101, 59);
            this.chkActuala.Name = "chkActuala";
            this.chkActuala.ProprietateCorespunzatoare = null;
            this.chkActuala.Size = new System.Drawing.Size(62, 17);
            this.chkActuala.TabIndex = 2;
            this.chkActuala.Text = "Actuala";
            this.chkActuala.UseVisualStyleBackColor = true;
            this.chkActuala.CheckedChanged += new System.EventHandler(this.chkActuala_CheckedChanged);
            // 
            // txtInterfon
            // 
            this.txtInterfon.AcceptButton = null;
            this.txtInterfon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInterfon.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtInterfon.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtInterfon.BackColor = System.Drawing.Color.White;
            this.txtInterfon.IsInReadOnlyMode = false;
            this.txtInterfon.Location = new System.Drawing.Point(498, 32);
            this.txtInterfon.MaxLength = 50;
            this.txtInterfon.Multiline = false;
            this.txtInterfon.Name = "txtInterfon";
            this.txtInterfon.ProprietateCorespunzatoare = "CodInterfon";
            this.txtInterfon.RaiseEventLaModificareProgramatica = false;
            this.txtInterfon.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtInterfon.Size = new System.Drawing.Size(70, 22);
            this.txtInterfon.TabIndex = 8;
            this.txtInterfon.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtInterfon.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtInterfon.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtInterfon.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtInterfon.UseSystemPasswordChar = false;
            this.txtInterfon.CerereUpdate += new CCL.UI.CEvenimente.ZonaModificata(this.ProprietateDinamica_CerereUpdate);
            // 
            // lblInterfon
            // 
            this.lblInterfon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInterfon.Location = new System.Drawing.Point(436, 37);
            this.lblInterfon.Name = "lblInterfon";
            this.lblInterfon.Size = new System.Drawing.Size(57, 13);
            this.lblInterfon.TabIndex = 7;
            this.lblInterfon.Text = "Interfon";
            this.lblInterfon.ToolTipText = null;
            this.lblInterfon.ToolTipTitle = null;
            // 
            // cboTipAdresa
            // 
            this.cboTipAdresa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipAdresa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cboTipAdresa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cboTipAdresa.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.cboTipAdresa.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.cboTipAdresa.BackColor = System.Drawing.Color.White;
            this.cboTipAdresa.DataSource = null;
            this.cboTipAdresa.DisplayMember = "";
            this.cboTipAdresa.DropDownHeight = 106;
            this.cboTipAdresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipAdresa.DropDownWidth = 183;
            this.cboTipAdresa.Location = new System.Drawing.Point(54, 5);
            this.cboTipAdresa.MaxDropDownItems = 8;
            this.cboTipAdresa.Name = "cboTipAdresa";
            this.cboTipAdresa.ProprietateCorespunzatoare = "TipAdresa";
            this.cboTipAdresa.SeIncarca = false;
            this.cboTipAdresa.SelectedIndex = -1;
            this.cboTipAdresa.SelectedItem = null;
            this.cboTipAdresa.SelectedValue = null;
            this.cboTipAdresa.Size = new System.Drawing.Size(146, 21);
            this.cboTipAdresa.TabIndex = 2;
            this.cboTipAdresa.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.cboTipAdresa.TipulListei = CCL.UI.ComboBoxPersonalizat.EnumTipLista.Nespecificat;
            this.cboTipAdresa.UtilizeazaButonGuma = false;
            this.cboTipAdresa.ValueMember = "";
            this.cboTipAdresa.CerereUpdate += new CCL.UI.CEvenimente.ZonaModificata(this.ProprietateDinamica_CerereUpdate);
            // 
            // txtNumar
            // 
            this.txtNumar.AcceptButton = null;
            this.txtNumar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumar.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtNumar.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtNumar.BackColor = System.Drawing.Color.White;
            this.txtNumar.IsInReadOnlyMode = false;
            this.txtNumar.Location = new System.Drawing.Point(358, 32);
            this.txtNumar.MaxLength = 50;
            this.txtNumar.Multiline = false;
            this.txtNumar.Name = "txtNumar";
            this.txtNumar.ProprietateCorespunzatoare = "Numar";
            this.txtNumar.RaiseEventLaModificareProgramatica = false;
            this.txtNumar.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNumar.Size = new System.Drawing.Size(68, 22);
            this.txtNumar.TabIndex = 6;
            this.txtNumar.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtNumar.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtNumar.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtNumar.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtNumar.UseSystemPasswordChar = false;
            this.txtNumar.CerereUpdate += new CCL.UI.CEvenimente.ZonaModificata(this.ProprietateDinamica_CerereUpdate);
            // 
            // txtStrada
            // 
            this.txtStrada.AcceptButton = null;
            this.txtStrada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStrada.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtStrada.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtStrada.BackColor = System.Drawing.Color.White;
            this.txtStrada.IsInReadOnlyMode = false;
            this.txtStrada.Location = new System.Drawing.Point(53, 32);
            this.txtStrada.MaxLength = 250;
            this.txtStrada.Multiline = false;
            this.txtStrada.Name = "txtStrada";
            this.txtStrada.ProprietateCorespunzatoare = "NumeStrada";
            this.txtStrada.RaiseEventLaModificareProgramatica = false;
            this.txtStrada.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtStrada.Size = new System.Drawing.Size(269, 22);
            this.txtStrada.TabIndex = 4;
            this.txtStrada.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtStrada.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtStrada.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtStrada.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtStrada.UseSystemPasswordChar = false;
            this.txtStrada.CerereUpdate += new CCL.UI.CEvenimente.ZonaModificata(this.ProprietateDinamica_CerereUpdate);
            // 
            // txtApartament
            // 
            this.txtApartament.AcceptButton = null;
            this.txtApartament.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApartament.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtApartament.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtApartament.BackColor = System.Drawing.Color.White;
            this.txtApartament.IsInReadOnlyMode = false;
            this.txtApartament.Location = new System.Drawing.Point(498, 57);
            this.txtApartament.MaxLength = 50;
            this.txtApartament.Multiline = false;
            this.txtApartament.Name = "txtApartament";
            this.txtApartament.ProprietateCorespunzatoare = "Apartament";
            this.txtApartament.RaiseEventLaModificareProgramatica = false;
            this.txtApartament.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtApartament.Size = new System.Drawing.Size(70, 22);
            this.txtApartament.TabIndex = 16;
            this.txtApartament.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtApartament.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtApartament.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtApartament.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtApartament.UseSystemPasswordChar = false;
            this.txtApartament.CerereUpdate += new CCL.UI.CEvenimente.ZonaModificata(this.ProprietateDinamica_CerereUpdate);
            // 
            // txtEtaj
            // 
            this.txtEtaj.AcceptButton = null;
            this.txtEtaj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEtaj.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtEtaj.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtEtaj.BackColor = System.Drawing.Color.White;
            this.txtEtaj.IsInReadOnlyMode = false;
            this.txtEtaj.Location = new System.Drawing.Point(358, 57);
            this.txtEtaj.MaxLength = 50;
            this.txtEtaj.Multiline = false;
            this.txtEtaj.Name = "txtEtaj";
            this.txtEtaj.ProprietateCorespunzatoare = "Etaj";
            this.txtEtaj.RaiseEventLaModificareProgramatica = false;
            this.txtEtaj.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEtaj.Size = new System.Drawing.Size(68, 22);
            this.txtEtaj.TabIndex = 14;
            this.txtEtaj.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtEtaj.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtEtaj.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtEtaj.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtEtaj.UseSystemPasswordChar = false;
            this.txtEtaj.CerereUpdate += new CCL.UI.CEvenimente.ZonaModificata(this.ProprietateDinamica_CerereUpdate);
            // 
            // txtScara
            // 
            this.txtScara.AcceptButton = null;
            this.txtScara.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScara.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtScara.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtScara.BackColor = System.Drawing.Color.White;
            this.txtScara.IsInReadOnlyMode = false;
            this.txtScara.Location = new System.Drawing.Point(242, 57);
            this.txtScara.MaxLength = 50;
            this.txtScara.Multiline = false;
            this.txtScara.Name = "txtScara";
            this.txtScara.ProprietateCorespunzatoare = "Scara";
            this.txtScara.RaiseEventLaModificareProgramatica = false;
            this.txtScara.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtScara.Size = new System.Drawing.Size(80, 22);
            this.txtScara.TabIndex = 12;
            this.txtScara.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtScara.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtScara.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtScara.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtScara.UseSystemPasswordChar = false;
            this.txtScara.CerereUpdate += new CCL.UI.CEvenimente.ZonaModificata(this.ProprietateDinamica_CerereUpdate);
            // 
            // txtBloc
            // 
            this.txtBloc.AcceptButton = null;
            this.txtBloc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBloc.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtBloc.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtBloc.BackColor = System.Drawing.Color.White;
            this.txtBloc.IsInReadOnlyMode = false;
            this.txtBloc.Location = new System.Drawing.Point(53, 57);
            this.txtBloc.MaxLength = 50;
            this.txtBloc.Multiline = false;
            this.txtBloc.Name = "txtBloc";
            this.txtBloc.ProprietateCorespunzatoare = "Bloc";
            this.txtBloc.RaiseEventLaModificareProgramatica = false;
            this.txtBloc.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBloc.Size = new System.Drawing.Size(146, 22);
            this.txtBloc.TabIndex = 10;
            this.txtBloc.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtBloc.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtBloc.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtBloc.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtBloc.UseSystemPasswordChar = false;
            this.txtBloc.CerereUpdate += new CCL.UI.CEvenimente.ZonaModificata(this.ProprietateDinamica_CerereUpdate);
            // 
            // ctrlTara
            // 
            this.ctrlTara.BackColor = System.Drawing.SystemColors.Control;
            this.ctrlTara.Location = new System.Drawing.Point(53, 86);
            this.ctrlTara.Name = "ctrlTara";
            this.ctrlTara.Size = new System.Drawing.Size(126, 21);
            this.ctrlTara.TabIndex = 18;
            // 
            // lblTara
            // 
            this.lblTara.Location = new System.Drawing.Point(2, 90);
            this.lblTara.Name = "lblTara";
            this.lblTara.Size = new System.Drawing.Size(48, 13);
            this.lblTara.TabIndex = 17;
            this.lblTara.Text = "Țară";
            this.lblTara.ToolTipText = null;
            this.lblTara.ToolTipTitle = null;
            // 
            // ctrlRegiune
            // 
            this.ctrlRegiune.BackColor = System.Drawing.SystemColors.Control;
            this.ctrlRegiune.Location = new System.Drawing.Point(231, 86);
            this.ctrlRegiune.Name = "ctrlRegiune";
            this.ctrlRegiune.Size = new System.Drawing.Size(136, 21);
            this.ctrlRegiune.TabIndex = 20;
            // 
            // ctrlLocalitate
            // 
            this.ctrlLocalitate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlLocalitate.BackColor = System.Drawing.SystemColors.Control;
            this.ctrlLocalitate.Location = new System.Drawing.Point(435, 86);
            this.ctrlLocalitate.Name = "ctrlLocalitate";
            this.ctrlLocalitate.Size = new System.Drawing.Size(133, 21);
            this.ctrlLocalitate.TabIndex = 22;
            // 
            // txtFax
            // 
            this.txtFax.AcceptButton = null;
            this.txtFax.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtFax.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtFax.BackColor = System.Drawing.Color.White;
            this.txtFax.Location = new System.Drawing.Point(231, 138);
            this.txtFax.MaxLength = 32767;
            this.txtFax.Name = "txtFax";
            this.txtFax.ProprietateCorespunzatoare = "Fax";
            this.txtFax.Size = new System.Drawing.Size(147, 22);
            this.txtFax.TabIndex = 28;
            this.txtFax.Text = "0";
            this.txtFax.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtFax.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtFax.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.txtFax.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtFax.ValoareDouble = 0D;
            this.txtFax.CerereUpdate += new CCL.UI.CEvenimente.ZonaModificata(this.ProprietateDinamica_CerereUpdate);
            // 
            // txtTelefon
            // 
            this.txtTelefon.AcceptButton = null;
            this.txtTelefon.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtTelefon.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtTelefon.BackColor = System.Drawing.Color.White;
            this.txtTelefon.Location = new System.Drawing.Point(53, 138);
            this.txtTelefon.MaxLength = 32767;
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.ProprietateCorespunzatoare = "TelefonFix";
            this.txtTelefon.Size = new System.Drawing.Size(126, 22);
            this.txtTelefon.TabIndex = 26;
            this.txtTelefon.Text = "0";
            this.txtTelefon.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTelefon.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtTelefon.TipMasca = CCL.UI.MaskedTextBoxPersonalizat.EnumTipMasca.Niciuna;
            this.txtTelefon.ValoareDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTelefon.ValoareDouble = 0D;
            this.txtTelefon.CerereUpdate += new CCL.UI.CEvenimente.ZonaModificata(this.ProprietateDinamica_CerereUpdate);
            // 
            // ctrlDataVerificare
            // 
            this.ctrlDataVerificare.AfiseazaButonGuma = false;
            this.ctrlDataVerificare.AfiseazaCuOra = false;
            this.ctrlDataVerificare.AfiseazaCuSecunde = false;
            this.ctrlDataVerificare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlDataVerificare.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ctrlDataVerificare.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ctrlDataVerificare.BackColor = System.Drawing.Color.White;
            this.ctrlDataVerificare.DataAfisata = new System.DateTime(((long)(0)));
            this.ctrlDataVerificare.IsInReadOnlyMode = false;
            this.ctrlDataVerificare.Location = new System.Drawing.Point(101, 31);
            this.ctrlDataVerificare.Name = "ctrlDataVerificare";
            this.ctrlDataVerificare.PragInferior = new System.DateTime(((long)(0)));
            this.ctrlDataVerificare.PragSuperior = new System.DateTime(((long)(0)));
            this.ctrlDataVerificare.ProprietateCorespunzatoare = "DataVerificare";
            this.ctrlDataVerificare.Size = new System.Drawing.Size(86, 21);
            this.ctrlDataVerificare.TabIndex = 1;
            this.ctrlDataVerificare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.ctrlDataVerificare.TipDeschidereCalendar = CCL.UI.CEnumerariComune.EnumTipDeschidere.StangaSus;
            this.ctrlDataVerificare.CerereUpdate += new CCL.UI.controlAlegeData.ZonaModificata(this.ProprietateDinamica_CerereUpdate);
            // 
            // lblDataVerificare
            // 
            this.lblDataVerificare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDataVerificare.Location = new System.Drawing.Point(3, 35);
            this.lblDataVerificare.Name = "lblDataVerificare";
            this.lblDataVerificare.Size = new System.Drawing.Size(94, 13);
            this.lblDataVerificare.TabIndex = 0;
            this.lblDataVerificare.Text = "Dată verificare";
            this.lblDataVerificare.ToolTipText = null;
            this.lblDataVerificare.ToolTipTitle = null;
            // 
            // lblFax
            // 
            this.lblFax.Location = new System.Drawing.Point(182, 143);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(45, 13);
            this.lblFax.TabIndex = 27;
            this.lblFax.Text = "Fax";
            this.lblFax.ToolTipText = null;
            this.lblFax.ToolTipTitle = null;
            // 
            // lblTelefonFix
            // 
            this.lblTelefonFix.Location = new System.Drawing.Point(2, 143);
            this.lblTelefonFix.Name = "lblTelefonFix";
            this.lblTelefonFix.Size = new System.Drawing.Size(48, 13);
            this.lblTelefonFix.TabIndex = 25;
            this.lblTelefonFix.Text = "Tel fix";
            this.lblTelefonFix.ToolTipText = null;
            this.lblTelefonFix.ToolTipTitle = null;
            // 
            // lblCP
            // 
            this.lblCP.Location = new System.Drawing.Point(2, 117);
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(48, 13);
            this.lblCP.TabIndex = 23;
            this.lblCP.Text = "CP";
            this.lblCP.ToolTipText = null;
            this.lblCP.ToolTipTitle = null;
            // 
            // lblJudet
            // 
            this.lblJudet.Location = new System.Drawing.Point(182, 90);
            this.lblJudet.Name = "lblJudet";
            this.lblJudet.Size = new System.Drawing.Size(46, 13);
            this.lblJudet.TabIndex = 19;
            this.lblJudet.Text = "Județ";
            this.lblJudet.ToolTipText = null;
            this.lblJudet.ToolTipTitle = null;
            // 
            // lblLocalitate
            // 
            this.lblLocalitate.AutoSize = true;
            this.lblLocalitate.Location = new System.Drawing.Point(373, 90);
            this.lblLocalitate.Name = "lblLocalitate";
            this.lblLocalitate.Size = new System.Drawing.Size(53, 13);
            this.lblLocalitate.TabIndex = 21;
            this.lblLocalitate.Text = "Localitate";
            this.lblLocalitate.ToolTipText = null;
            this.lblLocalitate.ToolTipTitle = null;
            // 
            // lblAp
            // 
            this.lblAp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAp.Location = new System.Drawing.Point(436, 62);
            this.lblAp.Name = "lblAp";
            this.lblAp.Size = new System.Drawing.Size(57, 13);
            this.lblAp.TabIndex = 15;
            this.lblAp.Text = "Apart";
            this.lblAp.ToolTipText = null;
            this.lblAp.ToolTipTitle = null;
            // 
            // lblEtaj
            // 
            this.lblEtaj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEtaj.Location = new System.Drawing.Point(328, 62);
            this.lblEtaj.Name = "lblEtaj";
            this.lblEtaj.Size = new System.Drawing.Size(28, 13);
            this.lblEtaj.TabIndex = 13;
            this.lblEtaj.Text = "Etaj";
            this.lblEtaj.ToolTipText = null;
            this.lblEtaj.ToolTipTitle = null;
            // 
            // lblScara
            // 
            this.lblScara.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScara.Location = new System.Drawing.Point(205, 62);
            this.lblScara.Name = "lblScara";
            this.lblScara.Size = new System.Drawing.Size(35, 13);
            this.lblScara.TabIndex = 11;
            this.lblScara.Text = "Scară";
            this.lblScara.ToolTipText = null;
            this.lblScara.ToolTipTitle = null;
            // 
            // lblBloc
            // 
            this.lblBloc.Location = new System.Drawing.Point(2, 62);
            this.lblBloc.Name = "lblBloc";
            this.lblBloc.Size = new System.Drawing.Size(48, 13);
            this.lblBloc.TabIndex = 9;
            this.lblBloc.Text = "Bloc";
            this.lblBloc.ToolTipText = null;
            this.lblBloc.ToolTipTitle = null;
            // 
            // lblNr
            // 
            this.lblNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNr.Location = new System.Drawing.Point(328, 37);
            this.lblNr.Name = "lblNr";
            this.lblNr.Size = new System.Drawing.Size(28, 13);
            this.lblNr.TabIndex = 5;
            this.lblNr.Text = "Nr";
            this.lblNr.ToolTipText = null;
            this.lblNr.ToolTipTitle = null;
            // 
            // lblStrada
            // 
            this.lblStrada.Location = new System.Drawing.Point(2, 37);
            this.lblStrada.Name = "lblStrada";
            this.lblStrada.Size = new System.Drawing.Size(48, 13);
            this.lblStrada.TabIndex = 3;
            this.lblStrada.Text = "Stradă";
            this.lblStrada.ToolTipText = null;
            this.lblStrada.ToolTipTitle = null;
            // 
            // lblTip
            // 
            this.lblTip.Location = new System.Drawing.Point(3, 9);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(48, 13);
            this.lblTip.TabIndex = 1;
            this.lblTip.Text = "Tip (*)";
            this.lblTip.ToolTipText = null;
            this.lblTip.ToolTipTitle = null;
            // 
            // ctrlInchidere
            // 
            this.ctrlInchidere.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlInchidere.BackColor = System.Drawing.Color.White;
            this.ctrlInchidere.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlInchidere.Location = new System.Drawing.Point(5, 139);
            this.ctrlInchidere.Name = "ctrlInchidere";
            this.ctrlInchidere.Size = new System.Drawing.Size(189, 81);
            this.ctrlInchidere.TabIndex = 40;
            this.ctrlInchidere.TipDeschidereLista = CCL.UI.CEnumerariComune.EnumTipDeschidere.StangaSus;
            this.ctrlInchidere.ModificareInchidere += new System.EventHandler(this.ctrlInchidere_ModificareInchidere);
            // 
            // ctrlCreare
            // 
            this.ctrlCreare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlCreare.BackColor = System.Drawing.Color.White;
            this.ctrlCreare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlCreare.Location = new System.Drawing.Point(5, 81);
            this.ctrlCreare.Name = "ctrlCreare";
            this.ctrlCreare.Size = new System.Drawing.Size(189, 55);
            this.ctrlCreare.TabIndex = 39;
            this.ctrlCreare.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // cboListaAdrese
            // 
            this.cboListaAdrese.AutoCompletePersonalizat = false;
            this.cboListaAdrese.DropDownHeight = 200;
            this.cboListaAdrese.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboListaAdrese.DropDownWidth = 250;
            this.cboListaAdrese.FormattingEnabled = true;
            this.cboListaAdrese.HideSelection = true;
            this.cboListaAdrese.IntegralHeight = false;
            this.cboListaAdrese.IsInReadOnlyMode = false;
            this.cboListaAdrese.Location = new System.Drawing.Point(98, 3);
            this.cboListaAdrese.MaxDropDownItems = 24;
            this.cboListaAdrese.Name = "cboListaAdrese";
            this.cboListaAdrese.ProprietateCorespunzatoare = null;
            this.cboListaAdrese.Size = new System.Drawing.Size(25, 21);
            this.cboListaAdrese.TabIndex = 1;
            this.cboListaAdrese.TipulListei = CCL.UI.ComboBoxPersonalizat.EnumTipLista.Nespecificat;
            this.cboListaAdrese.SelectedIndexChanged += new System.EventHandler(this.cboListaAdrese_SelectedIndexChanged);
            // 
            // panelDetaliiAdresa
            // 
            this.panelDetaliiAdresa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDetaliiAdresa.BackColor = System.Drawing.Color.White;
            this.panelDetaliiAdresa.Controls.Add(this.panelOptiuni);
            this.panelDetaliiAdresa.Controls.Add(this.btnOptiuni);
            this.panelDetaliiAdresa.Controls.Add(this.txtComentarii);
            this.panelDetaliiAdresa.Controls.Add(this.lblStrada);
            this.panelDetaliiAdresa.Controls.Add(this.lblNr);
            this.panelDetaliiAdresa.Controls.Add(this.txtInterfon);
            this.panelDetaliiAdresa.Controls.Add(this.lblBloc);
            this.panelDetaliiAdresa.Controls.Add(this.lblInterfon);
            this.panelDetaliiAdresa.Controls.Add(this.lblScara);
            this.panelDetaliiAdresa.Controls.Add(this.lblEtaj);
            this.panelDetaliiAdresa.Controls.Add(this.lblAp);
            this.panelDetaliiAdresa.Controls.Add(this.txtNumar);
            this.panelDetaliiAdresa.Controls.Add(this.lblLocalitate);
            this.panelDetaliiAdresa.Controls.Add(this.txtStrada);
            this.panelDetaliiAdresa.Controls.Add(this.lblJudet);
            this.panelDetaliiAdresa.Controls.Add(this.txtApartament);
            this.panelDetaliiAdresa.Controls.Add(this.lblCP);
            this.panelDetaliiAdresa.Controls.Add(this.txtEtaj);
            this.panelDetaliiAdresa.Controls.Add(this.lblTelefonFix);
            this.panelDetaliiAdresa.Controls.Add(this.txtScara);
            this.panelDetaliiAdresa.Controls.Add(this.lblFax);
            this.panelDetaliiAdresa.Controls.Add(this.txtBloc);
            this.panelDetaliiAdresa.Controls.Add(this.ctrlTara);
            this.panelDetaliiAdresa.Controls.Add(this.lblTara);
            this.panelDetaliiAdresa.Controls.Add(this.ctrlRegiune);
            this.panelDetaliiAdresa.Controls.Add(this.ctrlLocalitate);
            this.panelDetaliiAdresa.Controls.Add(this.txtFax);
            this.panelDetaliiAdresa.Controls.Add(this.txtTelefon);
            this.panelDetaliiAdresa.Location = new System.Drawing.Point(1, 29);
            this.panelDetaliiAdresa.Name = "panelDetaliiAdresa";
            this.panelDetaliiAdresa.Size = new System.Drawing.Size(573, 254);
            this.panelDetaliiAdresa.TabIndex = 4;
            this.panelDetaliiAdresa.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            // 
            // panelOptiuni
            // 
            this.panelOptiuni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOptiuni.BackColor = System.Drawing.Color.White;
            this.panelOptiuni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOptiuni.Controls.Add(this.btnInchidePanelOptiuni);
            this.panelOptiuni.Controls.Add(this.ctrlCreare);
            this.panelOptiuni.Controls.Add(this.lblDataVerificare);
            this.panelOptiuni.Controls.Add(this.cboTipAdresa);
            this.panelOptiuni.Controls.Add(this.chkActuala);
            this.panelOptiuni.Controls.Add(this.lblTip);
            this.panelOptiuni.Controls.Add(this.ctrlDataVerificare);
            this.panelOptiuni.Controls.Add(this.ctrlInchidere);
            this.panelOptiuni.Location = new System.Drawing.Point(328, 28);
            this.panelOptiuni.Name = "panelOptiuni";
            this.panelOptiuni.Size = new System.Drawing.Size(242, 224);
            this.panelOptiuni.TabIndex = 96;
            this.panelOptiuni.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.panelOptiuni.Visible = false;
            // 
            // btnInchidePanelOptiuni
            // 
            this.btnInchidePanelOptiuni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInchidePanelOptiuni.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnInchidePanelOptiuni.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInchidePanelOptiuni.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnInchidePanelOptiuni.FlatAppearance.BorderSize = 0;
            this.btnInchidePanelOptiuni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInchidePanelOptiuni.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInchidePanelOptiuni.Location = new System.Drawing.Point(204, 3);
            this.btnInchidePanelOptiuni.Name = "btnInchidePanelOptiuni";
            this.btnInchidePanelOptiuni.Size = new System.Drawing.Size(35, 25);
            this.btnInchidePanelOptiuni.TabIndex = 13;
            this.btnInchidePanelOptiuni.TabStop = false;
            this.btnInchidePanelOptiuni.Text = "X";
            this.btnInchidePanelOptiuni.UseVisualStyleBackColor = false;
            // 
            // btnOptiuni
            // 
            this.btnOptiuni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptiuni.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOptiuni.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnOptiuni.Image = ((System.Drawing.Image)(resources.GetObject("btnOptiuni.Image")));
            this.btnOptiuni.Location = new System.Drawing.Point(541, 3);
            this.btnOptiuni.Name = "btnOptiuni";
            this.btnOptiuni.Size = new System.Drawing.Size(29, 23);
            this.btnOptiuni.TabIndex = 95;
            this.btnOptiuni.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.MaiMulte;
            this.btnOptiuni.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnOptiuni.UseVisualStyleBackColor = true;
            // 
            // txtComentarii
            // 
            this.txtComentarii.AcceptButton = null;
            this.txtComentarii.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComentarii.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.txtComentarii.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.txtComentarii.BackColor = System.Drawing.Color.White;
            this.txtComentarii.IsInReadOnlyMode = false;
            this.txtComentarii.Location = new System.Drawing.Point(2, 166);
            this.txtComentarii.MaxLength = 32767;
            this.txtComentarii.Multiline = true;
            this.txtComentarii.Name = "txtComentarii";
            this.txtComentarii.ProprietateCorespunzatoare = "Comentariu";
            this.txtComentarii.RaiseEventLaModificareProgramatica = false;
            this.txtComentarii.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtComentarii.Size = new System.Drawing.Size(568, 83);
            this.txtComentarii.TabIndex = 37;
            this.txtComentarii.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtComentarii.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtComentarii.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.txtComentarii.TipInformatie = CCL.UI.TextBoxPersonalizat.EnumTipInformatie.Nedefinit;
            this.txtComentarii.UseSystemPasswordChar = false;
            this.txtComentarii.CerereUpdate += new CCL.UI.CEvenimente.ZonaModificata(this.ProprietateDinamica_CerereUpdate);
            // 
            // flpOptiuni
            // 
            this.flpOptiuni.Controls.Add(this.btnStareAdrese);
            this.flpOptiuni.Controls.Add(this.cboListaAdrese);
            this.flpOptiuni.Controls.Add(this.btnAdauga);
            this.flpOptiuni.Controls.Add(this.btnValidare);
            this.flpOptiuni.Controls.Add(this.btnCreeazaSelecteaza);
            this.flpOptiuni.Controls.Add(this.btnAnulare);
            this.flpOptiuni.Location = new System.Drawing.Point(0, 0);
            this.flpOptiuni.Name = "flpOptiuni";
            this.flpOptiuni.Size = new System.Drawing.Size(576, 29);
            this.flpOptiuni.TabIndex = 0;
            // 
            // btnStareAdrese
            // 
            this.btnStareAdrese.BackColor = System.Drawing.Color.DarkGray;
            this.btnStareAdrese.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStareAdrese.ForeColor = System.Drawing.Color.Black;
            this.btnStareAdrese.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnStareAdrese.Image = ((System.Drawing.Image)(resources.GetObject("btnStareAdrese.Image")));
            this.btnStareAdrese.Location = new System.Drawing.Point(3, 3);
            this.btnStareAdrese.Name = "btnStareAdrese";
            this.btnStareAdrese.Size = new System.Drawing.Size(89, 23);
            this.btnStareAdrese.TabIndex = 0;
            this.btnStareAdrese.Tag = "1";
            this.btnStareAdrese.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.ActiviDezactivati;
            this.btnStareAdrese.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnStareAdrese.UseVisualStyleBackColor = false;
            this.btnStareAdrese.Click += new System.EventHandler(this.btnStareAdrese_Click);
            // 
            // btnAdauga
            // 
            this.btnAdauga.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdauga.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdauga.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAdauga.Image = ((System.Drawing.Image)(resources.GetObject("btnAdauga.Image")));
            this.btnAdauga.Location = new System.Drawing.Point(129, 3);
            this.btnAdauga.Name = "btnAdauga";
            this.btnAdauga.Size = new System.Drawing.Size(24, 23);
            this.btnAdauga.TabIndex = 2;
            this.btnAdauga.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Adaugare;
            this.btnAdauga.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnAdauga.UseVisualStyleBackColor = false;
            this.btnAdauga.Click += new System.EventHandler(this.btnAdauga_Click);
            // 
            // btnValidare
            // 
            this.btnValidare.BackColor = System.Drawing.SystemColors.Control;
            this.btnValidare.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnValidare.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnValidare.Image = ((System.Drawing.Image)(resources.GetObject("btnValidare.Image")));
            this.btnValidare.Location = new System.Drawing.Point(159, 3);
            this.btnValidare.Name = "btnValidare";
            this.btnValidare.Size = new System.Drawing.Size(56, 23);
            this.btnValidare.TabIndex = 3;
            this.btnValidare.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Validare;
            this.btnValidare.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnValidare.UseVisualStyleBackColor = false;
            this.btnValidare.Click += new System.EventHandler(this.btnValidare_Click);
            // 
            // btnCreeazaSelecteaza
            // 
            this.btnCreeazaSelecteaza.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnCreeazaSelecteaza.Image = ((System.Drawing.Image)(resources.GetObject("btnCreeazaSelecteaza.Image")));
            this.btnCreeazaSelecteaza.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreeazaSelecteaza.Location = new System.Drawing.Point(221, 3);
            this.btnCreeazaSelecteaza.Name = "btnCreeazaSelecteaza";
            this.btnCreeazaSelecteaza.Size = new System.Drawing.Size(102, 23);
            this.btnCreeazaSelecteaza.TabIndex = 5;
            this.btnCreeazaSelecteaza.Text = "Selecteaza";
            this.btnCreeazaSelecteaza.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreeazaSelecteaza.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Validare;
            this.btnCreeazaSelecteaza.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnCreeazaSelecteaza.UseVisualStyleBackColor = true;
            this.btnCreeazaSelecteaza.Click += new System.EventHandler(this.btnCreeazaSelecteaza_Click);
            // 
            // btnAnulare
            // 
            this.btnAnulare.BackColor = System.Drawing.SystemColors.Control;
            this.btnAnulare.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAnulare.GenulTextului = CDL.iStomaLab.CDefinitiiComune.EnumSex.Barbatesc;
            this.btnAnulare.Image = ((System.Drawing.Image)(resources.GetObject("btnAnulare.Image")));
            this.btnAnulare.Location = new System.Drawing.Point(329, 3);
            this.btnAnulare.Name = "btnAnulare";
            this.btnAnulare.Size = new System.Drawing.Size(56, 23);
            this.btnAnulare.TabIndex = 4;
            this.btnAnulare.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Anulare;
            this.btnAnulare.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.btnAnulare.UseVisualStyleBackColor = false;
            this.btnAnulare.Click += new System.EventHandler(this.btnAnulare_Click);
            // 
            // ControlAdresaISTOMA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelDetaliiAdresa);
            this.Controls.Add(this.flpOptiuni);
            this.MinimumSize = new System.Drawing.Size(575, 283);
            this.Name = "ControlAdresaISTOMA";
            this.Size = new System.Drawing.Size(575, 283);
            this.panelDetaliiAdresa.ResumeLayout(false);
            this.panelDetaliiAdresa.PerformLayout();
            this.panelOptiuni.ResumeLayout(false);
            this.panelOptiuni.PerformLayout();
            this.flpOptiuni.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CCL.UI.LabelPersonalizat lblTip;
        private CCL.UI.ButtonPersonalizat btnValidare;
        private CCL.UI.LabelPersonalizat lblStrada;
        private CCL.UI.LabelPersonalizat lblNr;
        private CCL.UI.LabelPersonalizat lblBloc;
        private CCL.UI.LabelPersonalizat lblScara;
        private CCL.UI.LabelPersonalizat lblEtaj;
        private CCL.UI.LabelPersonalizat lblAp;
        private CCL.UI.LabelPersonalizat lblLocalitate;
        private CCL.UI.LabelPersonalizat lblJudet;
        private CCL.UI.LabelPersonalizat lblCP;
        private CCL.UI.LabelPersonalizat lblTelefonFix;
        private CCL.UI.LabelPersonalizat lblFax;
        private CCL.UI.ButtonPersonalizat btnAnulare;
        private CCL.UI.LabelPersonalizat lblDataVerificare;
        private CCL.UI.controlAlegeData ctrlDataVerificare;
        private CCL.UI.ButtonPersonalizat btnAdauga;
        private Caramizi.controlCreare ctrlCreare;
        private Caramizi.controlInchidere ctrlInchidere;
        private CCL.UI.ButtonPersonalizat btnStareAdrese;
        private CCL.UI.Caramizi.MaskedTextBoxGuma txtTelefon;
        private CCL.UI.Caramizi.MaskedTextBoxGuma txtFax;
        private ControlCautareLocalitate ctrlLocalitate;
        private ControlCautareRegiune ctrlRegiune;
        private CCL.UI.LabelPersonalizat lblTara;
        private ControlCautareTara ctrlTara;
        private CCL.UI.Caramizi.TextBoxGuma txtBloc;
        private CCL.UI.Caramizi.TextBoxGuma txtScara;
        private CCL.UI.Caramizi.TextBoxGuma txtEtaj;
        private CCL.UI.Caramizi.TextBoxGuma txtApartament;
        private CCL.UI.Caramizi.TextBoxGuma txtStrada;
        private CCL.UI.Caramizi.TextBoxGuma txtNumar;
        private CCL.UI.Caramizi.ComboBoxGuma cboTipAdresa;
        private CCL.UI.LabelPersonalizat lblInterfon;
        private CCL.UI.Caramizi.TextBoxGuma txtInterfon;
        private CCL.UI.CheckBoxPersonalizat chkActuala;
        private CCL.UI.ComboBoxPersonalizat cboListaAdrese;
        private CCL.UI.PanelPersonalizat panelDetaliiAdresa;
        private CCL.UI.Caramizi.TextBoxGuma txtComentarii;
        private CCL.UI.FlowLayoutPanelPersonalizat flpOptiuni;
        private CCL.UI.ButtonPersonalizat btnCreeazaSelecteaza;
        private CCL.UI.PanelPersonalizat panelOptiuni;
        private System.Windows.Forms.Button btnInchidePanelOptiuni;
        private CCL.UI.ButtonPersonalizat btnOptiuni;
    }
}
