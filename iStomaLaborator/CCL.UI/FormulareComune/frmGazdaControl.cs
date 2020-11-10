using System;
using System.Drawing;
using System.Windows.Forms;
using ILL.iStomaLab;
using ILL.iStomaLab;

namespace CCL.UI.FormulareComune
{
    // T este tipul controlului ce se incarca
    // R este tipul informatiei de retur a controlului
    public partial class frmGazdaControl<T, R> : frmCuHeaderSiValidare where T : Control, IAcceptaValidare<R>
    {

        #region Declaratii generale

        // Required designer variable.
        private System.ComponentModel.IContainer components = null;

        IAcceptaValidare<R> lControlGazduit = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati

        public R ObiectSelectat { get; private set; }

        #endregion

        #region Constructor si Initializare

        private void frmGazdaControl_Load(object sender, EventArgs e)
        {
            this.lControlGazduit.Initializeaza();
        }

        public frmGazdaControl(T pControlDeGazduit, Control pControlLegatura, bool pLaPozitiaMouseului, CEnumerariComune.EnumTipDeschidere pTipDeschidere, string pTitluEcran)
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();

            this.lControlGazduit = pControlDeGazduit;
            this.TipDeschidere = pTipDeschidere;
            this.Text = pTitluEcran;
            this.PermiteDeplasareaEcranului = true;
            this.PermiteMaximizareaEcranului = false;
            this.PermiteRedimensionarea = false;

            StabilesteMarimea(pControlDeGazduit);

            SeteazaPozitia();

            //Adaugam controlul in panelul corespunzator
            this.panelGlobal.Controls.Clear();
            this.panelGlobal.Controls.Add(pControlDeGazduit);
            pControlDeGazduit.Dock = DockStyle.Fill;
        }

        #endregion

        #region Evenimente

        private void btnValidare_Click(object sender, EventArgs e)
        {
            try
            {
                this.ObiectSelectat = this.lControlGazduit.Validare();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Mesaj.Afiseaza(this, ex.Message, "Eroare", Mesaj.EnumButoane.OK, Mesaj.EnumIcoana.Eroare);
            }
        }

        #endregion

        #region Metode private

        private void StabilesteMarimea(T pControlDeGazduit)
        {
            //Stabilim dimensiunea ecranului
            Size MarimeEcran = pControlDeGazduit.Size;
            MarimeEcran.Height += this.btnValidare.Height + this.lblTitluEcran.Height; ; //pentru a putea afisa butoanele
            //MarimeEcran.Width += 10; //marja de siguranta

            this.Size = MarimeEcran;
        }

        // Clean up any resources being used.
        // <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Required method for Designer support
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // panelGlobal
            // 
            this.panelGlobal.Location = new System.Drawing.Point(1, 19);
            this.panelGlobal.Size = new System.Drawing.Size(261, 194);
            // 
            // btnValidare
            // 
            this.btnValidare.Location = new System.Drawing.Point(54, 212);
            this.btnValidare.Size = new System.Drawing.Size(155, 23);
            this.btnValidare.Click += new System.EventHandler(this.btnValidare_Click);
            // 
            // lblTitluEcran
            // 
            this.lblTitluEcran.Size = new System.Drawing.Size(242, 19);
            // 
            // btnInchidereEcran
            // 
            this.btnInchidereEcran.Location = new System.Drawing.Point(240, 0);
            // 
            // frmGazdaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 237);
            this.Name = "frmGazdaControl";
            this.Load += new System.EventHandler(this.frmGazdaControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        #region Metode publice


        #endregion

    }
}
