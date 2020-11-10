namespace CCL.UI.Caramizi
{
    partial class ControlIntervalOrar<R> 
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
            this.lblSeparator = new CCL.UI.LabelPersonalizat(this.components);
            this.cboOraFinal = new CCL.UI.ComboBoxOra(this.components);
            this.cboOraInceput = new CCL.UI.ComboBoxOra(this.components);
            this.SuspendLayout();
            // 
            // lblSeparator
            // 
            this.lblSeparator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSeparator.AutoSize = true;
            this.lblSeparator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSeparator.HideSelection = true;
            this.lblSeparator.IsInReadOnlyMode = true;
            this.lblSeparator.Location = new System.Drawing.Point(84, 4);
            this.lblSeparator.Name = "lblSeparator";
            this.lblSeparator.ProprietateCorespunzatoare = "";
            this.lblSeparator.SelectedText = "";
            this.lblSeparator.SelectionLength = 0;
            this.lblSeparator.SelectionStart = 0;
            this.lblSeparator.Size = new System.Drawing.Size(11, 13);
            this.lblSeparator.TabIndex = 2;
            this.lblSeparator.Text = "-";
            this.lblSeparator.ToolTipText = null;
            this.lblSeparator.ToolTipTitle = null;
            // 
            // cboOraFinal
            // 
            this.cboOraFinal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboOraFinal.AutoCompletePersonalizat = false;
            this.cboOraFinal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOraFinal.FormattingEnabled = true;
            this.cboOraFinal.HideSelection = true;
            this.cboOraFinal.IsInReadOnlyMode = false;
            this.cboOraFinal.Location = new System.Drawing.Point(101, 0);
            this.cboOraFinal.Name = "cboOraFinal";
            this.cboOraFinal.Pas = CCL.UI.ComboBoxOra.EnumPas.CinciMinute;
            this.cboOraFinal.ProprietateCorespunzatoare = null;
            this.cboOraFinal.Size = new System.Drawing.Size(76, 21);
            this.cboOraFinal.TabIndex = 1;
            this.cboOraFinal.TextCaData = new System.DateTime(((long)(0)));
            this.cboOraFinal.TipulListei = CCL.UI.ComboBoxPersonalizat.EnumTipLista.Nespecificat;
            this.cboOraFinal.CerereUpdate += new CCL.UI.ComboBoxPersonalizat.ZonaModificata(this.cboOraFinal_CerereUpdate);
            // 
            // cboOraInceput
            // 
            this.cboOraInceput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboOraInceput.AutoCompletePersonalizat = false;
            this.cboOraInceput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOraInceput.FormattingEnabled = true;
            this.cboOraInceput.HideSelection = true;
            this.cboOraInceput.IsInReadOnlyMode = false;
            this.cboOraInceput.Location = new System.Drawing.Point(0, 0);
            this.cboOraInceput.Name = "cboOraInceput";
            this.cboOraInceput.Pas = CCL.UI.ComboBoxOra.EnumPas.CinciMinute;
            this.cboOraInceput.ProprietateCorespunzatoare = null;
            this.cboOraInceput.Size = new System.Drawing.Size(77, 21);
            this.cboOraInceput.TabIndex = 0;
            this.cboOraInceput.TextCaData = new System.DateTime(((long)(0)));
            this.cboOraInceput.TipulListei = CCL.UI.ComboBoxPersonalizat.EnumTipLista.Nespecificat;
            this.cboOraInceput.CerereUpdate += new CCL.UI.ComboBoxPersonalizat.ZonaModificata(this.cboOraInceput_CerereUpdate);
            // 
            // ControlIntervalOrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblSeparator);
            this.Controls.Add(this.cboOraFinal);
            this.Controls.Add(this.cboOraInceput);
            this.Name = "ControlIntervalOrar";
            this.Size = new System.Drawing.Size(177, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBoxOra cboOraInceput;
        private ComboBoxOra cboOraFinal;
        private LabelPersonalizat lblSeparator;
    }
}
