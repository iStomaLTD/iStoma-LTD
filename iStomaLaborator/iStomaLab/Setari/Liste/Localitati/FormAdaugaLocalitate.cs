using BLL.iStomaLab;
using BLL.iStomaLab.Referinta;
using CCL.UI;
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

namespace iStomaLab.Setari.Liste.Localitati
{
    public partial class FormAdaugaLocalitate : FormPersonalizat
    {

        #region Declaratii generale

        BLocalitati lLocalitate = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormAdaugaLocalitate(BLocalitati pLocalitati)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lLocalitate = pLocalitati;

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
            this.ctrlValidareAnulareLocalitate.Validare += CtrlValidareAnulareLocalitate_Validare;
        }



        private void initTextML()
        {
            this.Text = string.Empty;
            this.lblDenumireLocalitate.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Localitate);
            this.lblRegiuneLocalitate.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Regiune);
            this.lblTipLocalitate.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tip);
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
            if (this.lLocalitate == null)
            {
                this.txtDenumireLocalitate.Goleste();
                this.txtTipLocalitate.Goleste();
                this.ctrlRegiune.Initializeaza(4, StructIdDenumire.Empty, CCL.UI.CEnumerariComune.EnumTipDeschidere.DreaptaJos);
            }
            else
            {
                this.txtDenumireLocalitate.Text = this.lLocalitate.Nume;
                this.ctrlRegiune.Initializeaza(4, new StructIdDenumire(this.lLocalitate.Id, this.lLocalitate.Nume), CEnumerariComune.EnumTipDeschidere.DreaptaJos);
            }
            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void CtrlValidareAnulareLocalitate_Validare(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (this.Salveaza())
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
            IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.txtDenumireLocalitate, this.lblDenumireLocalitate);

        }

        private void seteazaFocus()
        {
            Control[] controaleFocus = { this.txtDenumireLocalitate, this.ctrlRegiune };
            foreach (var control in controaleFocus)
            {
                if (string.IsNullOrEmpty(control.Text))
                {
                    control.Focus();
                    break;
                }
            }
        }



        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente, BLocalitati pLocalitate)
        {
            using (FormAdaugaLocalitate ecran = new FormAdaugaLocalitate(pLocalitate))
            {
                ecran.AplicaPreferinteleUtilizatorului();
                return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
            }
        }
        
        internal bool Salveaza()
        {
            bool esteValid = BLocalitati.SuntInformatiileNecesareCoerente(this.ctrlRegiune.IdObiectAfisajCorespunzator, this.txtDenumireLocalitate.Text, 1, 1, 1);

            if (this.lLocalitate == null)
            {
                if (esteValid)
                    BLocalitati.Add(this.ctrlRegiune.IdObiectAfisajCorespunzator, this.txtDenumireLocalitate.Text, 1, 1, 1, null);
                else
                    seteazaAlerta();
            }
            else
            {
                this.lLocalitate.Nume = this.txtDenumireLocalitate.Text;
                this.lLocalitate.IdRegiune = this.ctrlRegiune.IdObiectAfisajCorespunzator;
                if (esteValid)
                    this.lLocalitate.UpdateAll();
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
            this.txtDenumireLocalitate.AllowModification(this.lEcranInModificare);
            this.txtTipLocalitate.AllowModification(this.lEcranInModificare);
            this.ctrlRegiune.AllowModification(this.lEcranInModificare);
        }

        #endregion


    }
}
