namespace ActualizareAplicatie
{
    partial class frmActualizeaza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActualizeaza));
            this.txtModificari = new System.Windows.Forms.RichTextBox();
            this.lblActiune = new System.Windows.Forms.Label();
            this.btnFinalizeaza = new System.Windows.Forms.Button();
            this.pbStareActualizare = new System.Windows.Forms.ProgressBar();
            this.lblTitlu = new System.Windows.Forms.Label();
            this.btnLanseazaActualizarea = new System.Windows.Forms.Button();
            this.panelDetalii = new System.Windows.Forms.Panel();
            this.picIDAVA = new System.Windows.Forms.PictureBox();
            this.lnkISTOMA = new System.Windows.Forms.LinkLabel();
            this.picIStoma2 = new System.Windows.Forms.PictureBox();
            this.panelStart = new System.Windows.Forms.Panel();
            this.pictureBoxIStoma = new System.Windows.Forms.PictureBox();
            this.picIDAVA2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblInitializareComunicareIStoma = new System.Windows.Forms.Label();
            this.lblAsteptati = new System.Windows.Forms.Label();
            this.bwServer = new System.ComponentModel.BackgroundWorker();
            this.panelDetalii.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIDAVA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIStoma2)).BeginInit();
            this.panelStart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIStoma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIDAVA2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtModificari
            // 
            this.txtModificari.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtModificari.BackColor = System.Drawing.Color.LightGreen;
            this.txtModificari.Location = new System.Drawing.Point(13, 32);
            this.txtModificari.Name = "txtModificari";
            this.txtModificari.ReadOnly = true;
            this.txtModificari.Size = new System.Drawing.Size(477, 274);
            this.txtModificari.TabIndex = 1;
            this.txtModificari.Text = "";
            // 
            // lblActiune
            // 
            this.lblActiune.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblActiune.AutoSize = true;
            this.lblActiune.Location = new System.Drawing.Point(13, 342);
            this.lblActiune.Name = "lblActiune";
            this.lblActiune.Size = new System.Drawing.Size(43, 13);
            this.lblActiune.TabIndex = 2;
            this.lblActiune.Text = "Actiune";
            // 
            // btnFinalizeaza
            // 
            this.btnFinalizeaza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinalizeaza.Location = new System.Drawing.Point(324, 312);
            this.btnFinalizeaza.Name = "btnFinalizeaza";
            this.btnFinalizeaza.Size = new System.Drawing.Size(166, 23);
            this.btnFinalizeaza.TabIndex = 3;
            this.btnFinalizeaza.Text = "Lansează iStoma";
            this.btnFinalizeaza.UseVisualStyleBackColor = true;
            this.btnFinalizeaza.Click += new System.EventHandler(this.btnFinalizeaza_Click);
            // 
            // pbStareActualizare
            // 
            this.pbStareActualizare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbStareActualizare.Location = new System.Drawing.Point(12, 358);
            this.pbStareActualizare.Name = "pbStareActualizare";
            this.pbStareActualizare.Size = new System.Drawing.Size(478, 12);
            this.pbStareActualizare.TabIndex = 0;
            // 
            // lblTitlu
            // 
            this.lblTitlu.AutoSize = true;
            this.lblTitlu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitlu.Location = new System.Drawing.Point(12, 9);
            this.lblTitlu.Name = "lblTitlu";
            this.lblTitlu.Size = new System.Drawing.Size(258, 17);
            this.lblTitlu.TabIndex = 4;
            this.lblTitlu.Text = "În noua versiune veți avea următoarele:";
            // 
            // btnLanseazaActualizarea
            // 
            this.btnLanseazaActualizarea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLanseazaActualizarea.Location = new System.Drawing.Point(13, 312);
            this.btnLanseazaActualizarea.Name = "btnLanseazaActualizarea";
            this.btnLanseazaActualizarea.Size = new System.Drawing.Size(179, 23);
            this.btnLanseazaActualizarea.TabIndex = 5;
            this.btnLanseazaActualizarea.Text = "Actualizează iStoma";
            this.btnLanseazaActualizarea.UseVisualStyleBackColor = true;
            this.btnLanseazaActualizarea.Click += new System.EventHandler(this.btnLanseazaActualizarea_Click);
            // 
            // panelDetalii
            // 
            this.panelDetalii.BackColor = System.Drawing.Color.White;
            this.panelDetalii.Controls.Add(this.picIDAVA);
            this.panelDetalii.Controls.Add(this.lnkISTOMA);
            this.panelDetalii.Controls.Add(this.picIStoma2);
            this.panelDetalii.Controls.Add(this.pbStareActualizare);
            this.panelDetalii.Controls.Add(this.lblActiune);
            this.panelDetalii.Controls.Add(this.btnLanseazaActualizarea);
            this.panelDetalii.Controls.Add(this.txtModificari);
            this.panelDetalii.Controls.Add(this.btnFinalizeaza);
            this.panelDetalii.Controls.Add(this.lblTitlu);
            this.panelDetalii.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetalii.Location = new System.Drawing.Point(0, 0);
            this.panelDetalii.Name = "panelDetalii";
            this.panelDetalii.Size = new System.Drawing.Size(627, 385);
            this.panelDetalii.TabIndex = 6;
            // 
            // picIDAVA
            // 
            this.picIDAVA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picIDAVA.Image = global::ActualizareAplicatie.Properties.Resources.logo_idava_solutions;
            this.picIDAVA.Location = new System.Drawing.Point(496, 333);
            this.picIDAVA.Name = "picIDAVA";
            this.picIDAVA.Size = new System.Drawing.Size(128, 49);
            this.picIDAVA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picIDAVA.TabIndex = 11;
            this.picIDAVA.TabStop = false;
            // 
            // lnkISTOMA
            // 
            this.lnkISTOMA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkISTOMA.AutoSize = true;
            this.lnkISTOMA.Location = new System.Drawing.Point(513, 191);
            this.lnkISTOMA.Name = "lnkISTOMA";
            this.lnkISTOMA.Size = new System.Drawing.Size(71, 13);
            this.lnkISTOMA.TabIndex = 7;
            this.lnkISTOMA.TabStop = true;
            this.lnkISTOMA.Text = "Detalii iStoma";
            this.lnkISTOMA.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkISTOMA_LinkClicked);
            // 
            // picIStoma2
            // 
            this.picIStoma2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picIStoma2.Image = global::ActualizareAplicatie.Properties.Resources.logo_mar___iStoma;
            this.picIStoma2.Location = new System.Drawing.Point(496, 32);
            this.picIStoma2.Name = "picIStoma2";
            this.picIStoma2.Size = new System.Drawing.Size(128, 141);
            this.picIStoma2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIStoma2.TabIndex = 6;
            this.picIStoma2.TabStop = false;
            // 
            // panelStart
            // 
            this.panelStart.BackColor = System.Drawing.Color.White;
            this.panelStart.Controls.Add(this.pictureBoxIStoma);
            this.panelStart.Controls.Add(this.picIDAVA2);
            this.panelStart.Controls.Add(this.pictureBox1);
            this.panelStart.Controls.Add(this.lblInitializareComunicareIStoma);
            this.panelStart.Controls.Add(this.lblAsteptati);
            this.panelStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStart.Location = new System.Drawing.Point(0, 0);
            this.panelStart.Name = "panelStart";
            this.panelStart.Size = new System.Drawing.Size(627, 385);
            this.panelStart.TabIndex = 7;
            // 
            // pictureBoxIStoma
            // 
            this.pictureBoxIStoma.Image = global::ActualizareAplicatie.Properties.Resources.logo_mar___iStoma;
            this.pictureBoxIStoma.Location = new System.Drawing.Point(484, 12);
            this.pictureBoxIStoma.Name = "pictureBoxIStoma";
            this.pictureBoxIStoma.Size = new System.Drawing.Size(131, 132);
            this.pictureBoxIStoma.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIStoma.TabIndex = 4;
            this.pictureBoxIStoma.TabStop = false;
            // 
            // picIDAVA2
            // 
            this.picIDAVA2.Image = global::ActualizareAplicatie.Properties.Resources.logo_idava_solutions;
            this.picIDAVA2.Location = new System.Drawing.Point(16, 12);
            this.picIDAVA2.Name = "picIDAVA2";
            this.picIDAVA2.Size = new System.Drawing.Size(129, 132);
            this.picIDAVA2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIDAVA2.TabIndex = 3;
            this.picIDAVA2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ActualizareAplicatie.Properties.Resources.waiting_animation_circle;
            this.pictureBox1.Location = new System.Drawing.Point(271, 285);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 85);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblInitializareComunicareIStoma
            // 
            this.lblInitializareComunicareIStoma.AutoSize = true;
            this.lblInitializareComunicareIStoma.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblInitializareComunicareIStoma.ForeColor = System.Drawing.Color.Green;
            this.lblInitializareComunicareIStoma.Location = new System.Drawing.Point(119, 221);
            this.lblInitializareComunicareIStoma.Name = "lblInitializareComunicareIStoma";
            this.lblInitializareComunicareIStoma.Size = new System.Drawing.Size(388, 22);
            this.lblInitializareComunicareIStoma.TabIndex = 1;
            this.lblInitializareComunicareIStoma.Text = "Se inițializează comunicarea cu serverul iStoma";
            // 
            // lblAsteptati
            // 
            this.lblAsteptati.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblAsteptati.ForeColor = System.Drawing.Color.Teal;
            this.lblAsteptati.Location = new System.Drawing.Point(151, 72);
            this.lblAsteptati.Name = "lblAsteptati";
            this.lblAsteptati.Size = new System.Drawing.Size(327, 22);
            this.lblAsteptati.TabIndex = 0;
            this.lblAsteptati.Text = "Vă rugăm să așteptați";
            this.lblAsteptati.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bwServer
            // 
            this.bwServer.WorkerReportsProgress = true;
            this.bwServer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwServer_DoWork);
            this.bwServer.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwServer_ProgressChanged);
            this.bwServer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwServer_RunWorkerCompleted);
            // 
            // frmActualizeaza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 385);
            this.Controls.Add(this.panelDetalii);
            this.Controls.Add(this.panelStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmActualizeaza";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iStoma LTD - Actualizare";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmActualizeaza_FormClosing);
            this.Load += new System.EventHandler(this.frmActualizeaza_Load);
            this.panelDetalii.ResumeLayout(false);
            this.panelDetalii.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIDAVA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIStoma2)).EndInit();
            this.panelStart.ResumeLayout(false);
            this.panelStart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIStoma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIDAVA2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtModificari;
        private System.Windows.Forms.Label lblActiune;
        private System.Windows.Forms.Button btnFinalizeaza;
        private System.Windows.Forms.ProgressBar pbStareActualizare;
        private System.Windows.Forms.Label lblTitlu;
        private System.Windows.Forms.Button btnLanseazaActualizarea;
        private System.Windows.Forms.Panel panelDetalii;
        private System.Windows.Forms.Panel panelStart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblInitializareComunicareIStoma;
        private System.Windows.Forms.Label lblAsteptati;
        private System.ComponentModel.BackgroundWorker bwServer;
        private System.Windows.Forms.PictureBox picIDAVA2;
        private System.Windows.Forms.PictureBox pictureBoxIStoma;
        private System.Windows.Forms.LinkLabel lnkISTOMA;
        private System.Windows.Forms.PictureBox picIStoma2;
        private System.Windows.Forms.PictureBox picIDAVA;
    }
}

