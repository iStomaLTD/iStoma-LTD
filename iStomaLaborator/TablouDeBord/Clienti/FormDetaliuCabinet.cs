using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Comune;
using CCL.UI;
using CDL.iStomaLab;
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
    public partial class FormDetaliuCabinet : FormPersonalizat
    {

        #region Declaratii generale

        private BClienti lClient = null;
        private BClientiCabinete lCabinet = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormDetaliuCabinet(BClienti pClienti, BClientiCabinete pCabinet)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lClient = pClienti;
            this.lCabinet = pCabinet;

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
            this.ctrlValidareAnulare.Validare += CtrlValidareAnulare_Validare;
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

            this.txtDenumire.Text = this.lCabinet.Denumire;
            this.ctrlAdresaLiniara.Initializeaza(this.lCabinet.GetAdresa(null), BClientiCabinete.TipObiectClasa, this.lCabinet.Id);

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void CtrlValidareAnulare_Validare(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (Salveaza())
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

        private void seteazaAlerta()
        {
            IHMEfecteSpeciale.AplicaEfectNU(this);
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.txtDenumire, this.lblDenumire);
            seteazaFocus();
        }

        private void seteazaFocus()
        {
            Control[] listaControale = { this.txtDenumire };

            foreach (var control in listaControale)
            {
                if (string.IsNullOrEmpty(control.Text))
                {
                    control.Focus();
                    break;
                }
            }
        }

        bool Salveaza()
        {
            bool esteValid = BClientiCabinete.SuntInformatiileNecesareCoerente(this.txtDenumire.Text, BAdrese.getAdresa(this.lCabinet.IdAdresa, null).Id);

            this.lCabinet.Denumire = this.txtDenumire.Text;
            this.lCabinet.IdAdresa = BAdrese.getAdresa(this.lCabinet.IdAdresa, null).Id;
            if (esteValid)
            {
                this.lCabinet.UpdateAll();
            }
            else
            {
                seteazaAlerta();
            }
            
            return esteValid;
        }

        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente, BClienti pClient, BClientiCabinete pCabinet)
        {
            using (FormDetaliuCabinet ecran = new FormDetaliuCabinet(pClient, pCabinet))
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
