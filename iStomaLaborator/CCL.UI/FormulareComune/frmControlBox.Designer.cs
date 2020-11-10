namespace CCL.UI
{
    partial class frmControlBox
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
            this.calData = new System.Windows.Forms.MonthCalendar();
            this.lblPeste = new CCL.UI.LabelPersonalizat(this.components);
            this.cboPeste = new CCL.UI.ComboBoxPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(229, 19);
            this.lblTitluEcran.Text = "Calendar";
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(228, 0);
            // 
            // calData
            // 
            this.calData.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.calData.Location = new System.Drawing.Point(1, 19);
            this.calData.MinimumSize = new System.Drawing.Size(193, 162);
            this.calData.Name = "calData";
            this.calData.ShowWeekNumbers = true;
            this.calData.TabIndex = 1;
            this.calData.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calData_DateSelected);
            this.calData.SizeChanged += new System.EventHandler(this.calData_SizeChanged);
            // 
            // lblPeste
            // 
            this.lblPeste.AutoSize = true;
            this.lblPeste.Location = new System.Drawing.Point(3, 186);
            this.lblPeste.Name = "lblPeste";
            this.lblPeste.Size = new System.Drawing.Size(34, 13);
            this.lblPeste.TabIndex = 2;
            this.lblPeste.Text = "Peste";
            this.lblPeste.ToolTipText = null;
            this.lblPeste.ToolTipTitle = null;
            // 
            // cboPeste
            // 
            this.cboPeste.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPeste.AutoCompletePersonalizat = false;
            this.cboPeste.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeste.FormattingEnabled = true;
            this.cboPeste.HideSelection = true;
            this.cboPeste.IsInReadOnlyMode = false;
            this.cboPeste.ItemHeight = 13;
            this.cboPeste.Location = new System.Drawing.Point(44, 182);
            this.cboPeste.MaxDropDownItems = 22;
            this.cboPeste.Name = "cboPeste";
            this.cboPeste.ProprietateCorespunzatoare = null;
            this.cboPeste.Size = new System.Drawing.Size(205, 21);
            this.cboPeste.TabIndex = 3;
            this.cboPeste.TipulListei = CCL.UI.ComboBoxPersonalizat.EnumTipLista.Nespecificat;
            this.cboPeste.CerereUpdate += new CCL.UI.ComboBoxPersonalizat.ZonaModificata(this.cboPeste_CerereUpdate);
            // 
            // frmControlBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 207);
            this.Controls.Add(this.cboPeste);
            this.Controls.Add(this.lblPeste);
            this.Controls.Add(this.calData);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(195, 182);
            this.Name = "frmControlBox";
            this.Text = "Calendar";
            this.Controls.SetChildIndex(this.calData, 0);
            this.Controls.SetChildIndex(this.lblTitluEcran, 0);
            this.Controls.SetChildIndex(this.btnInchidereEcran, 0);
            this.Controls.SetChildIndex(this.lblPeste, 0);
            this.Controls.SetChildIndex(this.cboPeste, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calData;
        private LabelPersonalizat lblPeste;
        private ComboBoxPersonalizat cboPeste;
    }
}