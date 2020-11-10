namespace CCL.UI.Caramizi
{
    partial class ControlPerioada
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
            this.datInceput = new CCL.UI.controlAlegeData();
            this.datFinal = new CCL.UI.controlAlegeData();
            this.labelPersonalizat1 = new CCL.UI.LabelPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // datInceput
            // 
            this.datInceput.AfiseazaButonGuma = false;
            this.datInceput.AfiseazaCuOra = false;
            this.datInceput.AfiseazaCuSecunde = false;
            this.datInceput.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.datInceput.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.datInceput.BackColor = System.Drawing.SystemColors.Control;
            this.datInceput.DataAfisata = new System.DateTime(((long)(0)));
            this.datInceput.IsInReadOnlyMode = false;
            this.datInceput.Location = new System.Drawing.Point(1, 1);
            this.datInceput.Name = "datInceput";
            this.datInceput.PragInferior = new System.DateTime(((long)(0)));
            this.datInceput.PragSuperior = new System.DateTime(((long)(0)));
            this.datInceput.ProprietateCorespunzatoare = null;
            this.datInceput.Size = new System.Drawing.Size(129, 21);
            this.datInceput.TabIndex = 0;
            this.datInceput.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.datInceput.TipDeschidereCalendar = CCL.UI.CEnumerariComune.EnumTipDeschidere.StangaSus;
            // 
            // datFinal
            // 
            this.datFinal.AfiseazaButonGuma = false;
            this.datFinal.AfiseazaCuOra = false;
            this.datFinal.AfiseazaCuSecunde = false;
            this.datFinal.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.datFinal.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.datFinal.DataAfisata = new System.DateTime(((long)(0)));
            this.datFinal.IsInReadOnlyMode = false;
            this.datFinal.Location = new System.Drawing.Point(155, 1);
            this.datFinal.Name = "datFinal";
            this.datFinal.PragInferior = new System.DateTime(((long)(0)));
            this.datFinal.PragSuperior = new System.DateTime(((long)(0)));
            this.datFinal.ProprietateCorespunzatoare = null;
            this.datFinal.Size = new System.Drawing.Size(129, 21);
            this.datFinal.TabIndex = 1;
            this.datFinal.Tip = CCL.UI.PanelPersonalizat.EnumTipPanel.Nespecificat;
            this.datFinal.TipDeschidereCalendar = CCL.UI.CEnumerariComune.EnumTipDeschidere.StangaSus;
            // 
            // labelPersonalizat1
            // 
            this.labelPersonalizat1.AutoSize = true;
            this.labelPersonalizat1.Location = new System.Drawing.Point(138, 5);
            this.labelPersonalizat1.Name = "labelPersonalizat1";
            this.labelPersonalizat1.Size = new System.Drawing.Size(10, 13);
            this.labelPersonalizat1.TabIndex = 2;
            this.labelPersonalizat1.Text = "-";
            this.labelPersonalizat1.ToolTipText = null;
            this.labelPersonalizat1.ToolTipTitle = null;
            // 
            // ControlPerioada
            // 
            this.Controls.Add(this.labelPersonalizat1);
            this.Controls.Add(this.datFinal);
            this.Controls.Add(this.datInceput);
            this.MinimumSize = new System.Drawing.Size(286, 24);
            this.Name = "ControlPerioada";
            this.Size = new System.Drawing.Size(286, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private controlAlegeData datInceput;
        private controlAlegeData datFinal;
        private LabelPersonalizat labelPersonalizat1;
    }
}
