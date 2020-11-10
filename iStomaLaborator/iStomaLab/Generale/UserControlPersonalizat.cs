using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCL.UI.Caramizi;
using CDL.iStomaLab;
using CCL.UI;

namespace iStomaLab.Generale
{
    public partial class UserControlPersonalizat : UserControlComun
    {
        public event System.EventHandler AnuleazaSelectie;
        public event System.EventHandler InchideEcranPopUp;
        public event System.EventHandler InitializareNecesara;
        private static bool lIncepeProcesul = false;

        protected bool lModCreare = false;
        protected bool lIsInReadOnlyMode = false;
        private static bool lProcesIncheiat = false;
        protected bool lModificariEfectuate = false;
        protected System.Windows.Forms.ToolTip ctrlToolTip = null;

        //protected BUtilizator lUtilizatorConectat
        //{
        //    get { return BUtilizator.GetUtilizatorConectat(); }
        //}

        //protected BPreferinteAplicatie lPreferinteUtilizator
        //{
        //    get { return BPreferinteAplicatie.GetPreferinteUtilizatorConectat(); }
        //}

        //protected BLocatii lLocatieCurenta
        //{
        //    get { return BLocatii.GetLocatieCurenta(null); }
        //}

        public bool ExistaModificari { get { return this.lModificariEfectuate; } }

        protected void CereAnulareaSelectiei()
        {
            if (this.AnuleazaSelectie != null)
                AnuleazaSelectie(this, null);
        }

        protected void CereInchidereEcranPopUp()
        {
            if (this.InchideEcranPopUp != null)
                InchideEcranPopUp(this, null);
        }

        protected void CereInitializare()
        {
            if (this.InitializareNecesara != null)
                InitializareNecesara(this, null);
        }

        public UserControlPersonalizat()
        {
            InitializeComponent();

            this.Font = CDefinitiiComune._Font_DPI;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                InitializeazaVariabileleGenerale();

                this.ctrlToolTip = new ToolTip();
                this.ctrlToolTip.ToolTipIcon = ToolTipIcon.None;
            }
        }

        public UserControlPersonalizat(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            this.Font = CDefinitiiComune._Font_DPI;
        }

        protected new void InitializeazaVariabileleGenerale()
        {
            //Variabile transformate in proprietati pentru a nu avea informatii diferite
            //this.lUtilizatorConectat = BUtilizator.GetUtilizatorConectat();
            //this.lPreferinteUtilizator = BPreferinteAplicatie.GetPreferinteUtilizatorConectat();
            //this.lLocatieCurenta = BLocatii.GetLocatieCurenta();
        }

        //public void AplicaPreferinteleUtilizatorului(BPreferinteAplicatie xPreferinteUtilizator)
        //{
        //    //this.lPreferinteUtilizator = xPreferinteUtilizator;
        //    IHMAplicaPreferinteleUtilizatorului.AplicaPreferintelePeControlUtilizator(this, this.lPreferinteUtilizator);
        //}

        protected Image getLogoSediu()
        {
            ////Incarcam logo-ul sediului
            //using (BDocumente logo = this.lLocatieCurenta.getLogoSediu())
            //{
            //    if (logo != null)
            //    {
            //        return Image.FromFile(logo.LocalizareFizicaDocument);
            //    }
            //    else
            //        return null;
            //}
            return null;
        }

        public Form GetFormParinte()
        {
            return this.ParentForm;
        }
    }
}
