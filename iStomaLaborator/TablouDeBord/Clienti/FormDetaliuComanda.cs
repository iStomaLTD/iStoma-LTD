using BLL.iStomaLab.Clienti;
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
    public partial class FormDetaliuComanda : FormPersonalizat
    {

        #region Declaratii generale

        private BClientiComenzi lComanda = null;
        private BClienti lClient = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormDetaliuComanda(BClientiComenzi pComanda, BClienti pClient)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lComanda = pComanda;
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
            this.ctrlValidareAnulareComanda.Validare += CtrlValidareAnulareComanda_Validare;
            this.FormClosed += FormDetaliuComanda_FormClosed;
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
            this.ctrlDetaliuClientComanda.Initializeaza(this.lComanda, this.lClient);
            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void FormDetaliuComanda_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (FormListaLucrari._SLucrare != null)
                    FormListaLucrari._SLucrare = null;
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

        private void CtrlValidareAnulareComanda_Validare(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();
                if (this.ctrlDetaliuClientComanda.Salveaza())
                {
                    inchideEcranulOK();
                }
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

        public static bool Afiseaza(Form pEcranPariente, BClientiComenzi pComanda, BClienti pClient)
        {
            bool deschide = false;

            if(FormListaLucrari._SLucrare == null)
            {
                using (FormListaLucrari ecranLucrari = new FormListaLucrari())
                {
                    ecranLucrari.AplicaPreferinteleUtilizatorului();
                    CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecranLucrari);
                }
            }
            
            if (FormListaLucrari._SLucrare != null)
            {
                using (FormDetaliuComanda ecran = new FormDetaliuComanda(pComanda, pClient))
                {
                    ecran.AplicaPreferinteleUtilizatorului();
                    deschide= CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
                }
            }

            return deschide;

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
