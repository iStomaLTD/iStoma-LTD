using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL.iStomaLab.Clienti;

namespace iStomaLab.Caramizi
{
    public partial class ControlCautareCabinetClinica : Generale.UserControlPersonalizat
    {

        #region Declaratii generale

        private BClienti lClinica = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlCautareCabinetClinica()
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

        }

        public void Initializeaza(BClienti pClinica)
        {
            base.InitializeazaVariabileleGenerale();

            this.lClinica = pClinica;

            incepeIncarcarea();
            if (this.lClinica == null)
            {
                this.cboListaCabineteClinica.AllowModification(false);
            }
            else
            {
                this.cboListaCabineteClinica.BeginUpdate();
                this.cboListaCabineteClinica.DataSource = BClientiCabinete.GetListByIdClient(this.lClinica.Id, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);
                this.cboListaCabineteClinica.EndUpdate();
                this.cboListaCabineteClinica.SelectedItem = null;
                this.cboListaCabineteClinica.AllowModification(true);
            }

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente



        #endregion

        #region Metode private



        #endregion

        #region Metode publice

        public int GetIdCabinet()
        {
            if (this.cboListaCabineteClinica.SelectedItem == null)
                return 0;

            return (this.cboListaCabineteClinica.SelectedItem as BClientiCabinete).Id;
        }

        public BClientiCabinete GetCabinet()
        {
            if (this.cboListaCabineteClinica.SelectedItem == null)
                return null;

            return this.cboListaCabineteClinica.SelectedItem as BClientiCabinete;
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;

            this.cboListaCabineteClinica.AllowModification(this.lEcranInModificare && this.lClinica != null);
        }

        public void Goleste()
        {
            this.cboListaCabineteClinica.SelectedItem = null;
        }

        #endregion


    }
}
