using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Preturi;
using CCL.iStomaLab;
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

namespace iStomaLab.Marketing
{
    public partial class FormScanareBarcode : FormPersonalizat
    {

        #region Declaratii generale

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormScanareBarcode()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

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
            this.txtCodDeBare.AfterUpdate += TxtCodDeBare_AfterUpdate;
        }

        private void initTextML()
        {
            this.Text = string.Empty;
            this.lblIndicatie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ScanatiCodulDeBare);
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
            this.txtCodDeBare.Goleste();
            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente



        #endregion

        #region Metode private

        private void TxtCodDeBare_AfterUpdate(Control sender, string sNumeProprietateAtasata, string sNouaValoare)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (this.txtCodDeBare.AreValoare())
                {
                    int idLucrare = Convert.ToInt32(this.txtCodDeBare.Text);
                    BClientiComenzi comanda = null;
                    try
                    {
                        comanda = new BClientiComenzi(idLucrare);
                    }
                    catch (Exception)
                    {
                        //Afisam ca nu am gasit lucrarea
                        Mesaj.Informare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.LucrareaNuAFostGasitaInSistem), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ScanatiCodulDeBare)); 
                    }

                    if (comanda != null)
                    {
                        TablouDeBord.Clienti.FormDetaliuComanda.Afiseaza(this.GetFormParinte(), comanda, comanda.GetClient(), comanda.GetLucrare(null));
                        this.Close();
                    }
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

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente)
        {
            using (FormScanareBarcode ecran = new FormScanareBarcode())
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
