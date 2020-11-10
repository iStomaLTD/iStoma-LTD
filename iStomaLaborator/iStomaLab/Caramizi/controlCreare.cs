using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.iStomaLab;
using CDL.iStomaLab;
using ILL.BLL.General;

namespace iStomaLab.Caramizi
{
    public partial class controlCreare : CCL.UI.PanelPersonalizat
    {

        #region Declaratii generale

        private ICreare lDetaliiCreare;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public controlCreare()
        {
            InitializeComponent();
            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                this.lblDataCreare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataCreare);
                this.lblNumeUtilizator.Goleste();

                this.btnAccesIstoric.Click += BtnAccesIstoric_Click;
            }
        }

        public void Initializeaza(ICreare pdetaliiCreare)
        {
            //this.lEcranInModificare = false;
            this.lDetaliiCreare = pdetaliiCreare;

            //incepeIncarcarea();
            if (this.lDetaliiCreare.DataCreare == CConstante.DataNula)
            {
                this.txtDataCreare.Text = "-";
            }
            else
            {
                this.txtDataCreare.Text = this.lDetaliiCreare.DataCreare.ToString(CConstante.FORMAT_DATA_ORA);
            }

            this.lblNumeUtilizator.Text = this.lDetaliiCreare.UtilizatorCreareNumeComplet;

            this.btnAccesIstoric.Visible = false;// pdetaliiCreare != null && BDefinitiiGenerale.StructTipObiect.AreIstoric(pdetaliiCreare.TipObiect);
            //finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void BtnAccesIstoric_Click(object sender, System.EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                //General.Caramizi.FormAfiseazaJurnal.Afiseaza(this.GetFormParinte(), this.lDetaliiCreare);
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



        #endregion

        #region IControlDava Members

        public void AllowModification(bool bPermiteModificarea)
        {
            //this.lEcranInModificare = bPermiteModificarea;
        }

        #endregion
    }
}
