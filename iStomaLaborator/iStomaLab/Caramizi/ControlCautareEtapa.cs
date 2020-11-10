using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iStomaLab.Generale;
using BLL.iStomaLab.Preturi;
using static CDL.iStomaLab.CDefinitiiComune;

namespace iStomaLab.Caramizi
{
    public partial class ControlCautareEtapa : UserControlPersonalizat
    {
        #region Declaratii generale

        private BListaPreturiStandard lLucrare = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlCautareEtapa()
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

        public void Initializeaza(BListaPreturiStandard pLucrare)
        {
            base.InitializeazaVariabileleGenerale();

            this.lLucrare = pLucrare;

            incepeIncarcarea();
            if (this.lLucrare == null)
            {
                this.cboListaEtape.AllowModification(false);
            }
            else
            {
                BColectieEtape listaEtape = new BColectieEtape();
                if (this.lLucrare != null)
                {
                    BColectieLucrariEtape etape = BLucrariEtape.GetListByParamIdLucrare(this.lLucrare.Id, EnumStare.Activa, null);
                    if (etape.Count > 0)
                    {
                        listaEtape = BEtape.getByListaId(etape.GetListaIdEtape(), null);
                    }
                    else
                    {
                        listaEtape = BEtape.GetListByParam(EnumStare.Activa, null);
                    }
                }

                this.cboListaEtape.BeginUpdate();
                this.cboListaEtape.DataSource = listaEtape;
                this.cboListaEtape.EndUpdate();
                this.cboListaEtape.SelectedItem = null;
                this.cboListaEtape.AllowModification(true);
            }

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente



        #endregion

        #region Metode private



        #endregion

        #region Metode publice

        public int GetIdEtapa()
        {
            if (this.cboListaEtape.SelectedItem == null)
                return 0;

            return (this.cboListaEtape.SelectedItem as BEtape).Id;
        }

        public BEtape GetEtapa()
        {
            if (this.cboListaEtape.SelectedItem == null)
                return null;

            return this.cboListaEtape.SelectedItem as BEtape;
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;

            this.cboListaEtape.AllowModification(this.lEcranInModificare && this.lLucrare != null);
        }

        public void Goleste()
        {
            this.cboListaEtape.SelectedItem = null;
        }

        public bool AreValoare()
        {
            return this.cboListaEtape.SelectedItem != null;
        }

        public void DeschideLista()
        {
            this.cboListaEtape.Focus();
            this.cboListaEtape.DroppedDown = true;
        }

        #endregion
    }
}
