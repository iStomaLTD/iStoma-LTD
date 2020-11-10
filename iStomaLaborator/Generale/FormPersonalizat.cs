using CCL.UI.FormulareComune;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iStomaLab.Generale
{
    public partial class FormPersonalizat : frmCuHeader
    {
        protected bool lEcranInModificare = true;
        protected bool lReadOnly = false;
        protected bool lModCreare = false;

        public FormPersonalizat()
        {
            Initializeaza();
        }

        protected void inchideEcranul()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        public FormPersonalizat(IContainer container)
            : this()
        {
            container.Add(this);
        }

        private void Initializeaza()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            if (!CCL.UI.IHMUtile.SuntemInDebug())
                this.InitializeazaVariabileleGenerale();
        }

        protected void CentratCuDeplasare()
        {
            Screen ecranCurent = Screen.FromControl(this); //this is the Form class

            if (ecranCurent == null)
                ecranCurent = Screen.PrimaryScreen;

            if (ecranCurent.WorkingArea.Height < this.Size.Height)
            {
                this.MinimumSize = new System.Drawing.Size(this.MinimumSize.Width, ecranCurent.WorkingArea.Height - 10);
                this.Height = ecranCurent.WorkingArea.Height - 10;
            }

            if (ecranCurent.WorkingArea.Width < this.Size.Width)
            {
                this.MinimumSize = new System.Drawing.Size(ecranCurent.WorkingArea.Width - 10, this.MinimumSize.Height);
                this.Width = ecranCurent.WorkingArea.Width - 10;
            }

            this.PermiteDeplasareaEcranului = true;
            this.PermiteMaximizareaEcranului = true;
            this.PermiteRedimensionarea = true;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        protected void InitializeazaVariabileleGenerale()
        {
            //this.lUtilizatorConectat = BUtilizator.GetUtilizatorConectat();
            //this.lPreferinteUtilizator = BPreferinteAplicatie.GetPreferinteUtilizatorConectat();
            //this.lLocatieCurenta = BLocatii.GetLocatieCurenta();
            //if (this.lPreferinteUtilizator != null && this.lEcranInModificare)
            //    this.lEcranInModificare = (this.lPreferinteUtilizator.DeschidemInModificare);
            //else
            this.lEcranInModificare = true;
        }

        //public void AplicaPreferinteleUtilizatorului(BPreferinteAplicatie pPreferinteUtilizator)
        //{
        //    //this.lPreferinteUtilizator = pPreferinteUtilizator;
        //    //IHMAplicaPreferinteleUtilizatorului.AplicaPreferintelePeFormular(this, this.lPreferinteUtilizator);
        //}

        public void AplicaPreferinteleUtilizatorului()
        {
            //IHMAplicaPreferinteleUtilizatorului.AplicaPreferintelePeFormular(this, this.lPreferinteUtilizator);
        }

    }
}
