using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Reprezentanti;
using iStomaLab.Generale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iStomaLab.TablouDeBord.Clienti
{
    public partial class FormDetaliuReprezentant : FormPersonalizat
    {

        #region Declaratii generale

        private BClientiReprezentanti lReprezentant = null;
        private BClienti lClient = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormDetaliuReprezentant(BClientiReprezentanti pReprezentant, BClienti pClient)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lReprezentant = pReprezentant;
            this.lClient = pClient;

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {

                adaugaHandlere();
                initTextML();

                this.CentratCuDeplasare();
            }
        }

        private void adaugaHandlere()
        {
            this.Load += _Load;
            this.ctrlValidareAnulareReprezentant.Validare += CtrlValidareAnulareReprezentant_Validare;
        }

        private void initTextML()
        {
            this.Text = string.Empty;
        }

        void _Load(object sender, EventArgs e)
        {
            try
            {
                Initializeaza();
                AllowModification(true);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.ctrlDetaliuReprezentant.Initializeaza(this.lReprezentant, this.lClient);

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void CtrlValidareAnulareReprezentant_Validare(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (this.ctrlDetaliuReprezentant.Salveaza())
                    inchideEcranulOK();
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
            finally
            {
                finalizeazaIncarcarea();
            }
        }

        #endregion

        #region Metode private



        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente, BClientiReprezentanti pReprezentant, BClienti pClient)
        {
            using (FormDetaliuReprezentant ecran = new FormDetaliuReprezentant(pReprezentant, pClient))
            {
                ecran.AplicaPreferinteleUtilizatorului();
                return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
            }
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
        }


        #endregion

    }
}
