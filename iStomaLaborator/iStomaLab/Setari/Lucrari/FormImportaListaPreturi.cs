using BLL.iStomaLab;
using BLL.iStomaLab.Preturi;
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

namespace iStomaLab.Setari.Lucrari
{
    public partial class FormImportaListaPreturi : FormPersonalizat
    {

        #region Declaratii generale

        private List<StructImportListaPreturi> lListaPreturi;

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colCod,
            colDenumire,
            colPretLei,
            colPretEuro
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormImportaListaPreturi(List<StructImportListaPreturi> pListaPreturi)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lListaPreturi = pListaPreturi;

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {

                adaugaHandlere();
                initTextML();

                this.CentratCuDeplasare();
                //this.Maximizeaza();
            }
        }

        private void adaugaHandlere()
        {
            this.Load += _Load;
            this.ctrlValidareAnulare.Validare += CtrlValidareAnulare_Validare;
            this.dgvListaImportPreturi.StergereLinie += DgvListaImportPreturi_StergereLinie;
            this.txtCautare.CerereUpdate += TxtCautare_CerereUpdate;
        }
        
        private void initTextML()
        {
            this.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ImportDate);
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

            this.txtCautare.Goleste();

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void TxtCautare_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvListaImportPreturi.FiltreazaDupaText(this.txtCautare.Text);
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

        private void DgvListaImportPreturi_StergereLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                StructImportListaPreturi listaPret = (StructImportListaPreturi)this.dgvListaImportPreturi.Rows[pIndexRand].Tag;

                if (Mesaj.Confirmare(this, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), listaPret.Denumire))
                {
                    this.dgvListaImportPreturi.Rows.RemoveAt(pIndexRand);
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

        private void CtrlValidareAnulare_Validare(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BColectieListaPreturiStandard listaPreturiExistenta = BListaPreturiStandard.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

                List<string> listaDenumireLucrareExistenta = listaPreturiExistenta.GetDenumireLucrari();

                foreach (DataGridViewRow row in this.dgvListaImportPreturi.Rows)
                {
                    StructImportListaPreturi lucrare = (StructImportListaPreturi)row.Tag;

                    if (!listaDenumireLucrareExistenta.Contains(lucrare.Denumire.Trim()))
                    {
                        BListaPreturiStandard.Add(lucrare.Denumire, string.Empty, lucrare.Cod, 0, 0, lucrare.PretLei, lucrare.PretEuro, null);
                    }
                }

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
            this.dgvListaImportPreturi.IncepeConstructieColoane();

            this.dgvListaImportPreturi.AdaugaColoanaText(EnumColoaneDGV.colCod.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Cod), 150, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaImportPreturi.AdaugaColoanaText(EnumColoaneDGV.colDenumire.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire), 200, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaImportPreturi.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colPretLei.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.RON), 200, DataGridViewColumnSortMode.Automatic);

            this.dgvListaImportPreturi.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colPretEuro.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.EUR), 200, DataGridViewColumnSortMode.Automatic);

            this.dgvListaImportPreturi.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvListaImportPreturi.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaImportPreturi.IncepeContructieRanduri();

            var listaElem = this.lListaPreturi;

            foreach (var elem in listaElem)
            {
                incarcaRand(this.dgvListaImportPreturi.Rows[this.dgvListaImportPreturi.Rows.Add()], elem);
            }

            this.dgvListaImportPreturi.FinalizeazaContructieRanduri();
        }

        private void incarcaRand(DataGridViewRow pRand, StructImportListaPreturi pElem)
        {
            pRand.Tag = pElem;

            pRand.Cells[EnumColoaneDGV.colCod.ToString()].Value = pElem.Cod;
            pRand.Cells[EnumColoaneDGV.colDenumire.ToString()].Value = pElem.Denumire;
            pRand.Cells[EnumColoaneDGV.colPretLei.ToString()].Value = pElem.PretLei;
            pRand.Cells[EnumColoaneDGV.colPretEuro.ToString()].Value = pElem.PretEuro;
            DataGridViewPersonalizat.InitCelulaStergere(pRand);
        }

        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente, List<StructImportListaPreturi> pListaPreturi)
        {
            using (FormImportaListaPreturi ecran = new FormImportaListaPreturi(pListaPreturi))
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
