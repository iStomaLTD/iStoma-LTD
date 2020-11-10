namespace iStomaLab.Caramizi
{
    partial class FormSelecteazaDate
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
            this.lblDataInceput = new CCL.UI.LabelPersonalizat(this.components);
            this.lblDataSfarsit = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlDataInceput = new CCL.UI.controlAlegeData();
            this.ctrlDataSfarsit = new CCL.UI.controlAlegeData();
            this.labelPersonalizat1 = new CCL.UI.LabelPersonalizat(this.components);
            this.ctrlValidareAnulare = new CCL.UI.Caramizi.controlValidareAnulare();
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(514, 19);
            this.lblTitluEcran.Text = "FormSelecteazaDate";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(513, 0);
            // 
            // lblDataInceput
            // 
            this.lblDataInceput.Location = new System.Drawing.Point(8, 42);
            this.lblDataInceput.Name = "lblDataInceput";
            this.lblDataInceput.Size = new System.Drawing.Size(120, 23);
            this.lblDataInceput.TabIndex = 2;
            this.lblDataInceput.Text = "Data Inceput";
            this.lblDataInceput.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDataInceput.ToolTipText = null;
            this.lblDataInceput.ToolTipTitle = null;
            // 
            // lblDataSfarsit
            // 
            this.lblDataSfarsit.Location = new System.Drawing.Point(408, 42);
            this.lblDataSfarsit.Name = "lblDataSfarsit";
            this.lblDataSfarsit.Size = new System.Drawing.Size(120, 23);
            this.lblDataSfarsit.TabIndex = 3;
            this.lblDataSfarsit.Text = "Data Sfarsit";
            this.lblDataSfarsit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDataSfarsit.ToolTipText = null;
            this.lblDataSfarsit.ToolTipTitle = null;
            // 
            // ctrlDataInceput
            // 
            this.ctrlDataInceput.AfiseazaButonGuma = false;
            this.ctrlDataInceput.AfiseazaCuOra = false;
            this.ctrlDataInceput.AfiseazaCuSecunde = false;
            this.ctrlDataInceput.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ctrlDataInceput.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ctrlDataInceput.BackColor = System.Drawing.Color.White;
            this.ctrlDataInceput.DataAfisata = new System.DateTime(((long)(0)));
            this.ctrlDataInceput.IsInReadOnlyMode = false;
            this.ctrlDataInceput.Location = new System.Drawing.Point(141, 44);
            this.ctrlDataInceput.Name = "ctrlDataInceput";
            this.ctrlDataInceput.PragInferior = new System.DateTime(((long)(0)));
            this.ctrlDataInceput.PragSuperior = new System.DateTime(((long)(0)));
            this.ctrlDataInceput.ProprietateCorespunzatoare = null;
            this.ctrlDataInceput.Size = new System.Drawing.Size(108, 21);
            this.ctrlDataInceput.TabIndex = 4;
            this.ctrlDataInceput.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.ctrlDataInceput.TipDeschidereCalendar = CCL.UI.CEnumerariComune.EnumTipDeschidere.StangaSus;
            // 
            // ctrlDataSfarsit
            // 
            this.ctrlDataSfarsit.AfiseazaButonGuma = false;
            this.ctrlDataSfarsit.AfiseazaCuOra = false;
            this.ctrlDataSfarsit.AfiseazaCuSecunde = false;
            this.ctrlDataSfarsit.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ctrlDataSfarsit.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ctrlDataSfarsit.BackColor = System.Drawing.Color.White;
            this.ctrlDataSfarsit.DataAfisata = new System.DateTime(((long)(0)));
            this.ctrlDataSfarsit.IsInReadOnlyMode = false;
            this.ctrlDataSfarsit.Location = new System.Drawing.Point(286, 44);
            this.ctrlDataSfarsit.Name = "ctrlDataSfarsit";
            this.ctrlDataSfarsit.PragInferior = new System.DateTime(((long)(0)));
            this.ctrlDataSfarsit.PragSuperior = new System.DateTime(((long)(0)));
            this.ctrlDataSfarsit.ProprietateCorespunzatoare = null;
            this.ctrlDataSfarsit.Size = new System.Drawing.Size(108, 21);
            this.ctrlDataSfarsit.TabIndex = 5;
            this.ctrlDataSfarsit.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.ctrlDataSfarsit.TipDeschidereCalendar = CCL.UI.CEnumerariComune.EnumTipDeschidere.StangaSus;
            // 
            // labelPersonalizat1
            // 
            this.labelPersonalizat1.AutoSize = true;
            this.labelPersonalizat1.Location = new System.Drawing.Point(263, 47);
            this.labelPersonalizat1.Name = "labelPersonalizat1";
            this.labelPersonalizat1.Size = new System.Drawing.Size(10, 13);
            this.labelPersonalizat1.TabIndex = 6;
            this.labelPersonalizat1.Text = "-";
            this.labelPersonalizat1.ToolTipText = null;
            this.labelPersonalizat1.ToolTipTitle = null;
            // 
            // ctrlValidareAnulare
            // 
            this.ctrlValidareAnulare.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrlValidareAnulare.BackColor = System.Drawing.Color.White;
            this.ctrlValidareAnulare.Location = new System.Drawing.Point(188, 94);
            this.ctrlValidareAnulare.Name = "ctrlValidareAnulare";
            this.ctrlValidareAnulare.Size = new System.Drawing.Size(161, 23);
            this.ctrlValidareAnulare.TabIndex = 7;
            // 
            // FormSelecteazaDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 129);
            this.Controls.Add(this.ctrlValidareAnulare);
            this.Controls.Add(this.labelPersonalizat1);
            this.Controls.Add(this.ctrlDataSfarsit);
            this.Controls.Add(this.ctrlDataInceput);
            this.Controls.Add(this.lblDataSfarsit);
            this.Controls.Add(this.lblDataInceput);
            this.MaximumSize = new System.Drawing.Size(536, 129);
            this.MinimumSize = new System.Drawing.Size(536, 129);
            this.Name = "FormSelecteazaDate";
            this.Text = "FormSelecteazaDate";
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.lblDataInceput, 0);
            this.Controls.SetChildIndex(this.lblDataSfarsit, 0);
            this.Controls.SetChildIndex(this.ctrlDataInceput, 0);
            this.Controls.SetChildIndex(this.ctrlDataSfarsit, 0);
            this.Controls.SetChildIndex(this.labelPersonalizat1, 0);
            this.Controls.SetChildIndex(this.ctrlValidareAnulare, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.LabelPersonalizat lblDataInceput;
        private CCL.UI.LabelPersonalizat lblDataSfarsit;
        private CCL.UI.controlAlegeData ctrlDataInceput;
        private CCL.UI.controlAlegeData ctrlDataSfarsit;
        private CCL.UI.LabelPersonalizat labelPersonalizat1;
        private CCL.UI.Caramizi.controlValidareAnulare ctrlValidareAnulare;
    }
}