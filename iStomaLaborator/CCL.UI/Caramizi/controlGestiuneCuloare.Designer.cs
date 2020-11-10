using static CDL.iStomaLab.CDefinitiiComune;

namespace CCL.UI.Caramizi
{
    partial class controlGestiuneCuloare
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
            this.btnSchimbaCuloare = new CCL.UI.ButtonPersonalizat(this.components);
            this.SuspendLayout();
            // 
            // btnSchimbaCuloare
            // 
            this.btnSchimbaCuloare.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSchimbaCuloare.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSchimbaCuloare.GenulTextului = EnumSex.Barbatesc;
            this.btnSchimbaCuloare.Image = null;
            this.btnSchimbaCuloare.Location = new System.Drawing.Point(4, 5);
            this.btnSchimbaCuloare.Name = "btnSchimbaCuloare";
            this.btnSchimbaCuloare.Size = new System.Drawing.Size(15, 13);
            this.btnSchimbaCuloare.TabIndex = 0;
            this.btnSchimbaCuloare.Text = "...";
            this.btnSchimbaCuloare.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.Cautare;
            this.btnSchimbaCuloare.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.btnSchimbaCuloare.UseVisualStyleBackColor = true;
            this.btnSchimbaCuloare.Click += new System.EventHandler(this.btnSchimbaCuloare_Click);
            // 
            // controlGestiuneCuloare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnSchimbaCuloare);
            this.Name = "controlGestiuneCuloare";
            this.Size = new System.Drawing.Size(23, 22);
            this.ResumeLayout(false);

        }

        #endregion

        private ButtonPersonalizat btnSchimbaCuloare;
    }
}
