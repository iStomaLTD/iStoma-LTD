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
    public partial class FormListaEtape : FormPersonalizat
    {

        #region Declaratii generale

        //public static BColectieEtape _SColectieEtape = new BColectieEtape();
        //public static BEtape _SEtapa = null;

        private BEtape lEtapa = null;
        private BColectieEtape lColectieEtape = new BColectieEtape();

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colDenumire,
            colDurataMinute
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormListaEtape(BColectieEtape pColectieEtape)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lColectieEtape = pColectieEtape;

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {

                adaugaHandlere();
                initTextML();

                this.CentratCuDeplasare();
            }
        }

        private FormListaEtape()
        {
            new FormListaEtape(null);
        }

        private void adaugaHandlere()
        {
            this.Load += _Load;
            this.ctrlValidareAnulare.Validare += CtrlValidareAnulare_Validare;
            this.txtCautaEtapa.CerereUpdate += TxtCautaEtapa_CerereUpdate;
            this.dgvListaEtape.SelectieUnicaEfectuata += DgvListaEtape_SelectieUnicaEfectuata;
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
            this.txtCautaEtapa.Goleste();

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void DgvListaEtape_SelectieUnicaEfectuata(object sender, DataGridViewCellEventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BEtape etapaSelectata = this.dgvListaEtape.Rows[e.RowIndex].Tag as BEtape;

                if (this.lColectieEtape == null || !this.lColectieEtape.Contains(etapaSelectata))
                {
                    if (this.lColectieEtape != null)
                        this.lColectieEtape.Adauga(etapaSelectata);
                    this.lEtapa = etapaSelectata;
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

        private void TxtCautaEtapa_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvListaEtape.FiltreazaDupaText(this.txtCautaEtapa.Text);
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

        #endregion

        #region Metode private

        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaEtape.IncepeConstructieColoane();

            this.dgvListaEtape.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.SelectieUnica);

            this.dgvListaEtape.AdaugaColoanaText(EnumColoaneDGV.colDenumire.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaEtape.AdaugaColoanaText(EnumColoaneDGV.colDurataMinute.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Durata), 80, false, DataGridViewColumnSortMode.Automatic); 

            this.dgvListaEtape.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaEtape.IncepeContructieRanduri();

            var listaElem = BEtape.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

            foreach (var elem in listaElem)
            {
                if (this.lColectieEtape == null || !this.lColectieEtape.Contains(elem))
                    incarcaRand(this.dgvListaEtape.Rows[this.dgvListaEtape.Rows.Add()], elem);
            }

            this.dgvListaEtape.FinalizeazaContructieRanduri();
        }

        private void incarcaRand(DataGridViewRow pRand, BEtape pElem)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaSelectieUnica(pRand, this.lEcranInModificare);
            pRand.Cells[EnumColoaneDGV.colDenumire.ToString()].Value = pElem.Denumire;
            pRand.Cells[EnumColoaneDGV.colDurataMinute.ToString()].Value = pElem.DurataMedieMinute;
        }

        #endregion

        #region Metode publice

        public static BEtape Afiseaza(Form pEcranPariente)
        {
            using (FormListaEtape ecran = new FormListaEtape(null))
            {
                ecran.AplicaPreferinteleUtilizatorului();
                CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
                return ecran.lEtapa;
            }
        }

        public static BEtape Afiseaza(Form pEcranPariente, BColectieEtape pColectieEtapeSelectate)
        {
            using (FormListaEtape ecran = new FormListaEtape(pColectieEtapeSelectate))
            {
                ecran.AplicaPreferinteleUtilizatorului();
                CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
                return ecran.lEtapa;
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
