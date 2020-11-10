using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iStomaLab.Generale;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Reprezentanti;

namespace iStomaLab.Caramizi
{
    public partial class ControlCautareMedicClinica : UserControlPersonalizat
    {
        #region Declaratii generale

        private BClienti lClinica = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlCautareMedicClinica()
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
                this.cboListaMediciClinica.AllowModification(false);
            }
            else
            {
                this.cboListaMediciClinica.BeginUpdate();
                this.cboListaMediciClinica.DataSource = BClientiReprezentanti.GetListByIdClient(this.lClinica.Id, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);
                this.cboListaMediciClinica.EndUpdate();
                this.cboListaMediciClinica.SelectedItem = null;
                this.cboListaMediciClinica.AllowModification(true);
            }

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente



        #endregion

        #region Metode private



        #endregion

        #region Metode publice

        public int GetIdMedic()
        {
            if (this.cboListaMediciClinica.SelectedItem == null)
                return 0;

            return (this.cboListaMediciClinica.SelectedItem as BClientiReprezentanti).Id;
        }

        public BClientiReprezentanti GetMedic()
        {
            if (this.cboListaMediciClinica.SelectedItem == null)
                return null;

            return this.cboListaMediciClinica.SelectedItem as BClientiReprezentanti;
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;

            this.cboListaMediciClinica.AllowModification(this.lEcranInModificare && this.lClinica != null);
        }

        public void Goleste()
        {
            this.cboListaMediciClinica.SelectedItem = null;
        }

        #endregion
    }
}
