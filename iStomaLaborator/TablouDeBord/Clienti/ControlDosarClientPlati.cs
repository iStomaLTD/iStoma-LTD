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
using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;

namespace iStomaLab.TablouDeBord.Clienti
{
    public partial class ControlDosarClientPlati : UserControlPersonalizat
    {

        #region Declaratii generale
        


        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlDosarClientPlati()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

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
            this.lblPlatiFacturi.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Facturi);
            this.lblPlatiIncasari.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Incasari);
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();
            //TODO			
            finalizeazaIncarcarea();
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
