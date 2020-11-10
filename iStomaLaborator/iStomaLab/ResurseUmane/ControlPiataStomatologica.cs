using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iStomaLab.Generale;
using CefSharp;
using CefSharp.WinForms;

namespace iStomaLab.ResurseUmane
{
    public partial class ControlPiataStomatologica : UserControlPersonalizat
    {

        #region Declaratii generale

        private ChromiumWebBrowser cwbPiata;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlPiataStomatologica()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
         
            InitializeChromium();

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                adaugaHandlere();
                initTextML();
            }
        }

        private void adaugaHandlere()
        {

        }

        private void initTextML()
        {

        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            //this.wbPiata.Navigate("https://piatastomatologica.ro/");

            finalizeazaIncarcarea();
        }

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            cwbPiata = new ChromiumWebBrowser("https://piatastomatologica.ro/");
            this.Controls.Add(cwbPiata);
            cwbPiata.Dock = DockStyle.Fill;
        }

        #endregion

        #region Evenimente



        #endregion

        #region Metode private



        #endregion

        #region Metode publice



        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
        }

        #endregion


    }
}
