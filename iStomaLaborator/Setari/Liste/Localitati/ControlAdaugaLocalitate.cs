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

namespace iStomaLab.Setari.Liste.Localitati
{
    public partial class ControlAdaugaLocalitate : UserControlPersonalizat
    {

        #region Declaratii generale

        BLocalitati lLocalitate = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlAdaugaLocalitate()
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
            this.lblDenumireLocalitate.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Localitate);
            this.lblRegiuneLocalitate.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Regiune);
            this.lblTipLocalitate.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tip);
        }

        public void Initializeaza(BLocalitati pLocalitati)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.lLocalitate = pLocalitati;

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



        #endregion

        #region Metode private

        private void seteazaAlerta()
        {
            IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.txtDenumireLocalitate, this.lblDenumireLocalitate);

        }

        private void seteazaFocus()
        {
            Control[] controaleFocus = { this.txtDenumireLocalitate, this.ctrlRegiune};
            foreach(var control in controaleFocus)
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

        internal bool Salveaza()
        {
            bool esteValid = BLocalitati.SuntInformatiileNecesareCoerente(this.ctrlRegiune.IdObiectAfisajCorespunzator, this.txtDenumireLocalitate.Text, 1, 1, 1);

            if (this.lLocalitate == null)
            {
                if (esteValid)
                    BLocalitati.Add(this.ctrlRegiune.IdObiectAfisajCorespunzator, this.txtDenumireLocalitate.Text, 1, 1, 1, null);
                else
                    seteazaAlerta();
            }else
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
