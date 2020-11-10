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
using BLL.iStomaLab.Referinta;
using CCL.UI;

namespace iStomaLab.Setari.Liste.Categorii
{
    public partial class ControlDetaliiCategorie : UserControlPersonalizat
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

        public ControlDetaliiCategorie()
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
            this.lblCategorieDenumire.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire);
            this.lblCategorieCuloare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Culoare);
        }

        public void Initializeaza(BCategorii pCategorie, bool pModificaCategorie)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.lCategorie = pCategorie;
            this.lModificaCategorie = pModificaCategorie;

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



        #endregion

        #region Metode private

        private void initializeazaControl(bool pCategorieSelectataVizibila, bool pInitializeazaDenumire, bool pInitializeazaCuloare)
        {
            this.lblCategorieSelectata.Visible = pCategorieSelectataVizibila;
            if (pCategorieSelectataVizibila)
            {
                if (this.lCategorie.IdCategorie == 0)
                    this.lblCategorieSelectata.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Categorie) + this.lCategorie.Denumire;
                else
                    this.lblCategorieSelectata.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Categorie) + BCategorii.getCategorieById(this.lCategorie.IdCategorie, null).Denumire;
            }
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
