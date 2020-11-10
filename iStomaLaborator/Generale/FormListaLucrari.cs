using BLL.iStomaLab;
using BLL.iStomaLab.Preturi;
using CCL.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iStomaLab.Generale
{
    public partial class FormListaLucrari : FormPersonalizat
    {

        #region Declaratii generale

        public static BListaPreturiStandard _SLucrare = null;

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colDenumire,
            colPret,
            colMoneda
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public FormListaLucrari()
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
            this.dgvListaLucrari.SelectieUnicaEfectuata += DgvListaLucrari_SelectieUnicaEfectuata;
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

            this.txtCautaLucrare.Goleste();

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

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

        private void DgvListaLucrari_SelectieUnicaEfectuata(object sender, DataGridViewCellEventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BListaPreturiStandard lucrareSelectata = this.dgvListaLucrari.Rows[e.RowIndex].Tag as BListaPreturiStandard;

                if(lucrareSelectata != null)
                {
                    _SLucrare = lucrareSelectata;
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

        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaLucrari.IncepeConstructieColoane();

            this.dgvListaLucrari.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.SelectieUnica);

            this.dgvListaLucrari.AdaugaColoanaText(EnumColoaneDGV.colDenumire.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaLucrari.AdaugaColoanaNumerica(EnumColoaneDGV.colPret.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Valoare), 80, DataGridViewColumnSortMode.Automatic);

            this.dgvListaLucrari.AdaugaColoanaText(EnumColoaneDGV.colMoneda.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Moneda), 70, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaLucrari.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaLucrari.IncepeContructieRanduri();

            var listaElem = BListaPreturiStandard.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

            foreach (var elem in listaElem)
            {
                incarcaRand(this.dgvListaLucrari.Rows[this.dgvListaLucrari.Rows.Add()], elem);
            }

            this.dgvListaLucrari.FinalizeazaContructieRanduri();
        }

        private void incarcaRand(DataGridViewRow pRand, BListaPreturiStandard pElem)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaSelectieUnica(pRand, this.lEcranInModificare);
            pRand.Cells[EnumColoaneDGV.colDenumire.ToString()].Value = pElem.Denumire;
            pRand.Cells[EnumColoaneDGV.colPret.ToString()].Value = pElem.GetValoare();
            pRand.Cells[EnumColoaneDGV.colMoneda.ToString()].Value = pElem.GetEtichetaMoneda();
        }

        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente)
        {
            using (FormListaLucrari ecran = new FormListaLucrari())
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
