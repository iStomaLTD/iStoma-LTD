﻿namespace CCL.UI.Caramizi
{
    partial class TextBoxCautare
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
            this.timerDeclansareEvent = new System.Windows.Forms.Timer(this.components);
            this.lblIconitaCautare = new CCL.UI.LabelPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // timerDeclansareEvent
            // 
            this.timerDeclansareEvent.Interval = 300;
            this.timerDeclansareEvent.Tick += new System.EventHandler(this.timerDeclansareEvent_Tick);
            // 
            // lblIconitaCautare
            // 
            this.lblIconitaCautare.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIconitaCautare.Image = global::CCL.UI.Properties.Resources.find;
            this.lblIconitaCautare.Location = new System.Drawing.Point(0, 0);
            this.lblIconitaCautare.Name = "lblIconitaCautare";
            this.lblIconitaCautare.Size = new System.Drawing.Size(16, 16);
            this.lblIconitaCautare.TabIndex = 0;
            this.lblIconitaCautare.ToolTipText = null;
            this.lblIconitaCautare.ToolTipTitle = null;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerDeclansareEvent;
        private LabelPersonalizat lblIconitaCautare;
    }
}
