namespace iStomaLab.TablouDeBord
{
    partial class ControlDataInteresLucrari
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
            this.flowLayoutPanelPersonalizat1 = new CCL.UI.FlowLayoutPanelPersonalizat(this.components);
            this.rbDataPrimire = new CCL.UI.RadioButtonPersonalizat(this.components);
            this.rbDataCreare = new CCL.UI.RadioButtonPersonalizat(this.components);
            this.rbDataTermen = new CCL.UI.RadioButtonPersonalizat(this.components);
            this.rbDataLaGata = new CCL.UI.RadioButtonPersonalizat(this.components);
            this.lblAfiseazaLucrarileInFunctieDe = new CCL.UI.LabelPersonalizat(this.components);
            this.flowLayoutPanelPersonalizat1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelPersonalizat1
            // 
            this.flowLayoutPanelPersonalizat1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelPersonalizat1.Controls.Add(this.rbDataPrimire);
            this.flowLayoutPanelPersonalizat1.Controls.Add(this.rbDataCreare);
            this.flowLayoutPanelPersonalizat1.Controls.Add(this.rbDataTermen);
            this.flowLayoutPanelPersonalizat1.Controls.Add(this.rbDataLaGata);
            this.flowLayoutPanelPersonalizat1.Location = new System.Drawing.Point(6, 22);
            this.flowLayoutPanelPersonalizat1.Name = "flowLayoutPanelPersonalizat1";
            this.flowLayoutPanelPersonalizat1.Size = new System.Drawing.Size(240, 66);
            this.flowLayoutPanelPersonalizat1.TabIndex = 0;
            // 
            // rbDataPrimire
            // 
            this.rbDataPrimire.Location = new System.Drawing.Point(3, 3);
            this.rbDataPrimire.Name = "rbDataPrimire";
            this.rbDataPrimire.Size = new System.Drawing.Size(111, 24);
            this.rbDataPrimire.TabIndex = 0;
            this.rbDataPrimire.TabStop = true;
            this.rbDataPrimire.Text = "Data primire";
            this.rbDataPrimire.UseVisualStyleBackColor = false;
            // 
            // rbDataCreare
            // 
            this.rbDataCreare.Location = new System.Drawing.Point(120, 3);
            this.rbDataCreare.Name = "rbDataCreare";
            this.rbDataCreare.Size = new System.Drawing.Size(111, 24);
            this.rbDataCreare.TabIndex = 1;
            this.rbDataCreare.TabStop = true;
            this.rbDataCreare.Text = "Data creare";
            this.rbDataCreare.UseVisualStyleBackColor = false;
            // 
            // rbDataTermen
            // 
            this.rbDataTermen.Location = new System.Drawing.Point(3, 33);
            this.rbDataTermen.Name = "rbDataTermen";
            this.rbDataTermen.Size = new System.Drawing.Size(111, 24);
            this.rbDataTermen.TabIndex = 2;
            this.rbDataTermen.TabStop = true;
            this.rbDataTermen.Text = "Data termen";
            this.rbDataTermen.UseVisualStyleBackColor = false;
            // 
            // rbDataLaGata
            // 
            this.rbDataLaGata.Location = new System.Drawing.Point(120, 33);
            this.rbDataLaGata.Name = "rbDataLaGata";
            this.rbDataLaGata.Size = new System.Drawing.Size(111, 24);
            this.rbDataLaGata.TabIndex = 3;
            this.rbDataLaGata.TabStop = true;
            this.rbDataLaGata.Text = "Data La Gata";
            this.rbDataLaGata.UseVisualStyleBackColor = false;
            // 
            // lblAfiseazaLucrarileInFunctieDe
            // 
            this.lblAfiseazaLucrarileInFunctieDe.AutoSize = true;
            this.lblAfiseazaLucrarileInFunctieDe.Location = new System.Drawing.Point(2, 4);
            this.lblAfiseazaLucrarileInFunctieDe.Name = "lblAfiseazaLucrarileInFunctieDe";
            this.lblAfiseazaLucrarileInFunctieDe.Size = new System.Drawing.Size(157, 13);
            this.lblAfiseazaLucrarileInFunctieDe.TabIndex = 4;
            this.lblAfiseazaLucrarileInFunctieDe.Text = "Afiseaza Lucrarile In Functie De";
            this.lblAfiseazaLucrarileInFunctieDe.ToolTipText = null;
            this.lblAfiseazaLucrarileInFunctieDe.ToolTipTitle = null;
            // 
            // ControlDataInteresLucrari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblAfiseazaLucrarileInFunctieDe);
            this.Controls.Add(this.flowLayoutPanelPersonalizat1);
            this.Name = "ControlDataInteresLucrari";
            this.Size = new System.Drawing.Size(245, 87);
            this.flowLayoutPanelPersonalizat1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCL.UI.FlowLayoutPanelPersonalizat flowLayoutPanelPersonalizat1;
        private CCL.UI.RadioButtonPersonalizat rbDataPrimire;
        private CCL.UI.RadioButtonPersonalizat rbDataCreare;
        private CCL.UI.RadioButtonPersonalizat rbDataTermen;
        private CCL.UI.RadioButtonPersonalizat rbDataLaGata;
        private CCL.UI.LabelPersonalizat lblAfiseazaLucrarileInFunctieDe;
    }
}
