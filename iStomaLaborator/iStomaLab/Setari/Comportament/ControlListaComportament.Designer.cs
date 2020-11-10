namespace iStomaLab.Setari.Comportament
{
    partial class ControlListaComportament
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
            this.lblTitlu = new CCL.UI.LabelPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // lblTitlu
            // 
            this.lblTitlu.AutoSize = true;
            this.lblTitlu.Location = new System.Drawing.Point(4, 4);
            this.lblTitlu.Name = "lblTitlu";
            this.lblTitlu.Size = new System.Drawing.Size(110, 13);
            this.lblTitlu.TabIndex = 0;
            this.lblTitlu.Text = "Comportament iStoma";
            this.lblTitlu.ToolTipText = null;
            this.lblTitlu.ToolTipTitle = null;
            // 
            // ControlListaComportament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTitlu);
            this.Name = "ControlListaComportament";
            this.Size = new System.Drawing.Size(540, 450);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.LabelPersonalizat lblTitlu;
    }
}
