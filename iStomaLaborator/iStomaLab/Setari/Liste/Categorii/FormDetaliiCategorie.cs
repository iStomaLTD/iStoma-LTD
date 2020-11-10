using BLL.iStomaLab;
using BLL.iStomaLab.Referinta;
using CCL.UI;
using CCL.UI.FormulareComune;
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

namespace iStomaLab.Setari.Liste.Categorii
{
    public partial class FormDetaliiCategorie : FormPersonalizat
    {

        #region Declaratii generale

        private BCategorii lCategorie = null;
        private bool lModificaCategorie = false;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormDetaliiCategorie(BCategorii pCategorie, bool pModificaCategorie)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lCategorie = pCategorie;
            this.lModificaCategorie = pModificaCategorie;

            this.AcceptButton = this.ctrlValidareAnulareCategorie.ButonValidare;

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                adaugaHandlere();
                initTextML();
                this.txtCategorieDenumire.CapitalizeazaCuvintele = false;
                this.txtCategorieDenumire.CapitalizeazaPrimaLitera = true;

                this.CentratCuDeplasare();
            }
        }

        private void adaugaHandlere()
        {
            this.Load += _Load;
            this.ctrlValidareAnulareCategorie.Validare += CtrlValidareAnulareCategorie_Validare;
        }

        private void initTextML()
        {
            this.Text = string.Empty;
            this.lblCategorieDenumire.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire);
            this.lblCategorieCuloare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Culoare);
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

            if (this.lCategorie != null && this.lCategorie.IdCategorie > 0)
                this.Text = new BCategorii(this.lCategorie.IdCategorie, null).Denumire;
            else
                this.Text = string.Empty;

           
            if (this.lCategorie == null)
            {
                initializeazaControl(false, false, true);
            }
            else
            {
                if (this.lModificaCategorie)
                {
                    initializeazaControl(false, true, true);
                }
                else if (this.lCategorie.IdCategorie == 0)
                {
                    initializeazaControl(true, false, false);
                }

                else if (this.lCategorie.IdCategorie != 0)
                {
                    initializeazaControl(true, true, true);
                }
            }

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void CtrlValidareAnulareCategorie_Validare(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();
                if (this.Salveaza())
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

        private void initializeazaControl(bool pCategorieSelectataVizibila, bool pInitializeazaDenumire, bool pInitializeazaCuloare)
        {
            if (pInitializeazaDenumire)
            {
                this.txtCategorieDenumire.Text = this.lCategorie.Denumire;
            }
            else
                this.txtCategorieDenumire.Goleste();

            if (pInitializeazaCuloare)
            {
                if (this.lCategorie == null)
                    this.ctrlCategorieCuloare.Initializeaza(Color.White);
                else if (this.lModificaCategorie)
                    this.ctrlCategorieCuloare.Initializeaza(BCategorii.getCategorieById(this.lCategorie.Id, null).Culoare);
                else if (this.lCategorie.IdCategorie != 0)
                {
                    this.ctrlCategorieCuloare.Initializeaza(BCategorii.getCategorieById(this.lCategorie.IdCategorie, null).Culoare);
                    this.ctrlCategorieCuloare.Enabled = false;
                }

            }
            else
            {
                this.lblCategorieCuloare.Visible = pInitializeazaCuloare;
                this.ctrlCategorieCuloare.Visible = pInitializeazaCuloare;
            }
        }

        private void seteazaAlerta()
        {
            IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.txtCategorieDenumire, this.lblCategorieDenumire);
            this.txtCategorieDenumire.Focus();
        }


        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente, BCategorii pCategorie, bool pModificaCategorie)
        {
            using (FormDetaliiCategorie ecran = new FormDetaliiCategorie(pCategorie, pModificaCategorie))
            {
                ecran.AplicaPreferinteleUtilizatorului();
                return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
            }
        }

        internal bool Salveaza()
        {
            bool esteValid = BCategorii.SuntInformatiileNecesareCoerente(this.txtCategorieDenumire.Text);

            if (this.lCategorie == null)
            {
                if (esteValid)
                    BCategorii.Add(this.txtCategorieDenumire.Text, 0, this.ctrlCategorieCuloare.CuloareARGB, null);
                else
                    seteazaAlerta();
            }
            else
            {
                this.lCategorie.Denumire = this.txtCategorieDenumire.Text;
                this.lCategorie.Culoare = this.ctrlCategorieCuloare.CuloareARGB;
                if (esteValid)
                {
                    if (this.lModificaCategorie)
                        this.lCategorie.UpdateAll();
                    else if (this.lCategorie.IdCategorie == 0)
                        BCategorii.Add(this.txtCategorieDenumire.Text, this.lCategorie.Id, this.ctrlCategorieCuloare.CuloareARGB, null);
                    else if (this.lCategorie.IdCategorie != 0)
                        this.lCategorie.UpdateAll();
                }
                else
                    seteazaAlerta();
            }
            return esteValid;
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
