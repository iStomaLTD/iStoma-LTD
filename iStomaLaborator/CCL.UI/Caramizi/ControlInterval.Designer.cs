namespace CCL.UI.Caramizi
{
    partial class ControlInterval
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
            this.cboOraInceput = new CCL.UI.ComboBoxOra(this.components);
            this.cboOraFinal = new CCL.UI.ComboBoxOra(this.components);
            this.labelPersonalizat1 = new CCL.UI.LabelPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // cboOraInceput
            // 
            this.cboOraInceput.AutoCompletePersonalizat = false;
            this.cboOraInceput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOraInceput.FormattingEnabled = true;
            this.cboOraInceput.HideSelection = true;
            this.cboOraInceput.IsInReadOnlyMode = false;
            this.cboOraInceput.Location = new System.Drawing.Point(0, 0);
            this.cboOraInceput.Name = "cboOraInceput";
            this.cboOraInceput.Pas = CCL.UI.ComboBoxOra.EnumPas.CinciMinute;
            this.cboOraInceput.ProprietateCorespunzatoare = null;
            this.cboOraInceput.Size = new System.Drawing.Size(57, 21);
            this.cboOraInceput.TabIndex = 0;
            this.cboOraInceput.TextCaData = new System.DateTime(((long)(0)));
            this.cboOraInceput.TipulListei = CCL.UI.ComboBoxPersonalizat.EnumTipLista.Nespecificat;
            // 
            // cboOraFinal
            // 
            this.cboOraFinal.AutoCompletePersonalizat = false;
            this.cboOraFinal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOraFinal.FormattingEnabled = true;
            this.cboOraFinal.HideSelection = true;
            this.cboOraFinal.IsInReadOnlyMode = false;
            this.cboOraFinal.Location = new System.Drawing.Point(79, 0);
            this.cboOraFinal.Name = "cboOraFinal";
            this.cboOraFinal.Pas = CCL.UI.ComboBoxOra.EnumPas.CinciMinute;
            this.cboOraFinal.ProprietateCorespunzatoare = null;
            this.cboOraFinal.Size = new System.Drawing.Size(57, 21);
            this.cboOraFinal.TabIndex = 1;
            this.cboOraFinal.TextCaData = new System.DateTime(((long)(0)));
            this.cboOraFinal.TipulListei = CCL.UI.ComboBoxPersonalizat.EnumTipLista.Nespecificat;
            // 
            // labelPersonalizat1
            // 
            this.labelPersonalizat1.AutoSize = true;
            this.labelPersonalizat1.Location = new System.Drawing.Point(63, 4);
            this.labelPersonalizat1.Name = "labelPersonalizat1";
            this.labelPersonalizat1.Size = new System.Drawing.Size(10, 13);
            this.labelPersonalizat1.TabIndex = 2;
            this.labelPersonalizat1.Text = "-";
            this.labelPersonalizat1.ToolTipText = null;
            this.labelPersonalizat1.ToolTipTitle = null;
            // 
            // ControlInterval
            // 
            this.Controls.Add(this.labelPersonalizat1);
            this.Controls.Add(this.cboOraFinal);
            this.Controls.Add(this.cboOraInceput);
            this.Name = "ControlInterval";
            this.Size = new System.Drawing.Size(137, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBoxOra cboOraInceput;
        private ComboBoxOra cboOraFinal;
        private LabelPersonalizat labelPersonalizat1;
    }
}
