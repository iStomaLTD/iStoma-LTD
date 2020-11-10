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
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Preturi;
using BLL.iStomaLab;
using CCL.UI;
using CCL.iStomaLab;

namespace iStomaLab.TablouDeBord.Clienti
{
    public partial class ControlDosarClientListaPreturi : UserControlPersonalizat
    {

        #region Declaratii generale
        
        private BClienti lClient = null;

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colLucrare,
            colPretStandard,
            colPretClient,
            colMoneda
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlDosarClientListaPreturi()
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
            this.dgvClientListaPreturi.CellEndEdit += DgvClientListaPreturi_CellEndEdit;
            this.dgvClientListaPreturi.EditareLinie += DgvClientListaPreturi_EditareLinie;
        }
        
        private void initTextML()
        {

        }

        public void Initializeaza(BClienti pClient)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.lClient = pClient;

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void DgvClientListaPreturi_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                Tuple<BListaPreturiStandard, BListaPreturiClienti> valori = this.dgvClientListaPreturi.Rows[this.dgvClientListaPreturi.CurrentCell.RowIndex].Tag as Tuple<BListaPreturiStandard, BListaPreturiClienti>;

                BListaPreturiStandard pretStandard = valori.Item1;
                BListaPreturiClienti pretClient = valori.Item2;
                
                if (pretClient != null)
                {
                    pretClient.TermenAgreat = pretStandard.TermenMediuZile;
                    if (pretClient.ValoareRON == 0)
                    {
                        double valoareEuro = CUtil.GetAsDouble(this.dgvClientListaPreturi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                        pretClient.ValoareRON = 0;
                        pretClient.ValoareEUR = valoareEuro;
                    }
                    else
                    {
                        double valoareRon = CUtil.GetAsDouble(this.dgvClientListaPreturi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                        pretClient.ValoareRON = valoareRon;
                        pretClient.ValoareEUR = 0;
                    }
                    pretClient.UpdateAll();
                }
                else
                {
                    if (pretStandard.ValoareRON == 0)
                    {
                        double valoareEuro = CUtil.GetAsDouble(this.dgvClientListaPreturi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                        BListaPreturiClienti.Add(pretStandard.Id, this.lClient.Id, 0, valoareEuro, pretStandard.TermenMediuZile, null);
                    }
                    else
                    {
                        double valoareRon = CUtil.GetAsDouble(this.dgvClientListaPreturi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                        BListaPreturiClienti.Add(pretStandard.Id, this.lClient.Id, 0, valoareRon, pretStandard.TermenMediuZile, null);
                    }

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

        private void DgvClientListaPreturi_EditareLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                Tuple<BListaPreturiStandard, BListaPreturiClienti> valori = this.dgvClientListaPreturi.Rows[this.dgvClientListaPreturi.CurrentCell.RowIndex].Tag as Tuple<BListaPreturiStandard, BListaPreturiClienti>;
                BListaPreturiStandard pretStandard = valori.Item1;

                if (pretStandard != null)
                {
                    if (Setari.Lucrari.FormDetaliuLucrare.Afiseaza(this.GetFormParinte(), pretStandard))
                    {
                        incarcaRand(this.dgvClientListaPreturi.Rows[pIndexRand], valori.Item1, valori.Item2);
                    }
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

        private double getTipPretStandard(BListaPreturiStandard pPretStandard, bool esteRon)
        {
            if (esteRon)
                return pPretStandard.ValoareRON == 0 ? pPretStandard.ValoareEUR : pPretStandard.ValoareRON;
            else
                return pPretStandard.ValoareEUR == 0 ? pPretStandard.ValoareEUR : pPretStandard.ValoareRON;
        }

        private void ConstruiesteColoaneDGV()
        {
            this.dgvClientListaPreturi.IncepeConstructieColoane();
            this.dgvClientListaPreturi.EditMode = DataGridViewEditMode.EditOnEnter;

            this.dgvClientListaPreturi.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvClientListaPreturi.AdaugaColoanaText(EnumColoaneDGV.colLucrare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Lucrare), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvClientListaPreturi.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colPretStandard.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PretStandard), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvClientListaPreturi.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colPretClient.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PretClient), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvClientListaPreturi.AdaugaColoanaText(EnumColoaneDGV.colMoneda.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Moneda), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvClientListaPreturi.Columns[EnumColoaneDGV.colPretClient.ToString()].ReadOnly = false;

            this.dgvClientListaPreturi.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvClientListaPreturi.IncepeContructieRanduri();

            var listaElem = BListaPreturiStandard.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

            foreach (var elem in listaElem)
            {
                incarcaRand(this.dgvClientListaPreturi.Rows[this.dgvClientListaPreturi.Rows.Add()], elem, BListaPreturiClienti.GetPretClient(elem.Id, this.lClient.Id, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null));
            }

            this.dgvClientListaPreturi.FinalizeazaContructieRanduri();

            this.lblClientTotalPreturi.Text = "Total preturi:" + this.dgvClientListaPreturi.RowCount.ToString();
        }

        private void incarcaRand(DataGridViewRow pRand, BListaPreturiStandard pElem, BListaPreturiClienti pPretClient)
        {
            pRand.Tag = new Tuple<BListaPreturiStandard, BListaPreturiClienti>(pElem, pPretClient);

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);
            pRand.Cells[EnumColoaneDGV.colLucrare.ToString()].Value = pElem.Denumire;
            pRand.Cells[EnumColoaneDGV.colMoneda.ToString()].Value = pElem.ValoareRON == 0 ? CUtil.getText(1265) : CUtil.getText(1264);
            pRand.Cells[EnumColoaneDGV.colPretStandard.ToString()].Value = pElem.ValoareRON == 0 ? pElem.ValoareEUR : pElem.ValoareRON;
            if (pPretClient != null)
                pRand.Cells[EnumColoaneDGV.colPretClient.ToString()].Value = pPretClient.GetValoare();
            else
            {
                pRand.Cells[EnumColoaneDGV.colPretClient.ToString()].Value = pElem.ValoareRON == 0 ? pElem.ValoareEUR : pElem.ValoareRON;
            }
        }

        #endregion

        #region Metode publice



        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
        }

        #endregion


    }
}
