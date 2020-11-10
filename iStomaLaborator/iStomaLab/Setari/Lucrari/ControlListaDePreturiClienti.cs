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
using CCL.UI;
using BLL.iStomaLab.Preturi;
using CCL.iStomaLab;
using BLL.iStomaLab.Clienti;
using CDL.iStomaLab;

namespace iStomaLab.Setari.Lucrari
{
    public partial class ControlListaDePreturiClienti : UserControlPersonalizat
    {

        #region Declaratii generale

        private BClienti lClient = null;

        #endregion

        #region Enumerari si Structuri

        public enum EnumColoaneDGV
        {
            colLucrare,
            colPretStandard,
            colPretClient,
            colAjustare,
            colMoneda,
            //colMoneda
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlListaDePreturiClienti()
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
            this.dgvListaDePreturiClienti.CellEndEdit += DgvListaDePreturiClienti_CellEndEdit;
            this.txtCautaLucrare.CerereUpdate += TxtCautaLucrare_CerereUpdate;
            this.dgvListaDePreturiClienti.CellClick += DgvListaDePreturiClienti_CellClick;
            this.dgvListaClinici.CellClick += DgvListaClinici_CellClick;
            this.txtCautareClinici.CerereUpdate += TxtCautareClinici_CerereUpdate;
            this.btnDiscount.Click += BtnDiscount_Click;
        }

        private void initTextML()
        {

        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.txtCautaLucrare.Goleste();
            this.txtCautareClinici.Goleste();

            BColectieClienti listaClienti = BClienti.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);
            if (!CUtil.EsteListaVida<BClienti>(listaClienti))
            {
                this.dgvListaClinici.ConstruiesteRanduriToString<BClienti>(listaClienti);

                this.lClient = this.dgvListaClinici.Rows[0].Tag as BClienti;
                this.dgvListaClinici.Rows[0].Selected = true;

                ConstruiesteColoaneDGV();
                ConstruiesteRanduriDGV();
            }

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void BtnDiscount_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                double valDiscount = CCL.UI.FormulareComune.frmInputBox.GetValoareProcentuala(this.GetFormParinte(), "Discount", "Discount", 0, 2, 200, true);

                List<Tuple<BListaPreturiStandard, BListaPreturiClienti>> listaPreturiActuale = this.dgvListaDePreturiClienti.GetListaObiecteBifate<List<Tuple<BListaPreturiStandard, BListaPreturiClienti>>, Tuple<BListaPreturiStandard, BListaPreturiClienti>>();

                if (!CUtil.EsteListaVida<Tuple<BListaPreturiStandard, BListaPreturiClienti>>(listaPreturiActuale))
                {
                    BListaPreturiClienti.AplicaDiscount(this.lClient.Id, listaPreturiActuale, valDiscount);

                    ConstruiesteRanduriDGV();
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

        private void TxtCautareClinici_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvListaClinici.FiltreazaDupaText(this.txtCautareClinici.Text);
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

        private void DgvListaClinici_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (this.lSeIncarca || e.RowIndex < 0) return;
            try
            {
                incepeIncarcarea();

                this.lClient = this.dgvListaClinici.Rows[e.RowIndex].Tag as BClienti;

                ConstruiesteRanduriDGV();

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

        private void DgvListaDePreturiClienti_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (this.lSeIncarca || e.RowIndex < 0) return;
            try
            {
                incepeIncarcarea();

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

        private void TxtCautaLucrare_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvListaDePreturiClienti.FiltreazaDupaText(this.txtCautaLucrare.Text);
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

        private void DgvListaDePreturiClienti_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (this.lSeIncarca || e.RowIndex < 0) return;
            try
            {
                incepeIncarcarea();

                Tuple<BListaPreturiStandard, BListaPreturiClienti> valori = this.dgvListaDePreturiClienti.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag as Tuple<BListaPreturiStandard, BListaPreturiClienti>;

                if (valori != null)
                {
                    BListaPreturiStandard pretStandard = valori.Item1;
                    BListaPreturiClienti pretClient = valori.Item2;
                    bool refresh = false;
                    if (pretClient != null)
                    {
                        //Update
                        refresh = pretClient.UpdatePret(CUtil.GetAsDouble(this.dgvListaDePreturiClienti.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                    }
                    else
                    {
                        //Adaugare
                        double pretNou = CUtil.GetAsDouble(this.dgvListaDePreturiClienti.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                        if (pretNou != pretStandard.GetValoare())
                        {
                            int id = BListaPreturiClienti.Add(pretStandard.Id, this.lClient.Id, pretNou, pretStandard.GetMoneda(), pretStandard.TermenMediuZile, null);

                            if (id > 0)
                            {
                                refresh = true;
                                pretClient = new BListaPreturiClienti(id);
                            }
                        }
                    }

                    if (refresh)
                        incarcaRandPretStandard(this.dgvListaDePreturiClienti.Rows[e.RowIndex], pretStandard, pretClient);
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
            this.dgvListaDePreturiClienti.IncepeConstructieColoane();
            this.dgvListaDePreturiClienti.EditMode = DataGridViewEditMode.EditOnEnter;

            this.dgvListaDePreturiClienti.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.SelectieMultipla);
            this.dgvListaDePreturiClienti.AdaugaColoanaText(EnumColoaneDGV.colLucrare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Lucrare), 300, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaDePreturiClienti.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colPretStandard.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PretStandard), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvListaDePreturiClienti.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colAjustare.ToString(), "%", 80, DataGridViewColumnSortMode.Automatic);

            this.dgvListaDePreturiClienti.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colPretClient.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PretNegociat), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvListaDePreturiClienti.Columns[EnumColoaneDGV.colPretClient.ToString()].ReadOnly = false;

            this.dgvListaDePreturiClienti.AdaugaColoanaText(EnumColoaneDGV.colMoneda.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Moneda), 50, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaDePreturiClienti.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaDePreturiClienti.IncepeContructieRanduri();

            this.lblClinica.Text = this.lClient.Denumire;

            var listaElem = BListaPreturiStandard.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

            foreach (var elem in listaElem)
            {
                incarcaRandPretStandard(this.dgvListaDePreturiClienti.Rows[this.dgvListaDePreturiClienti.Rows.Add()], elem, null);
            }

            this.dgvListaDePreturiClienti.FinalizeazaContructieRanduri();
        }

        private void incarcaRandPretStandard(DataGridViewRow pRand, BListaPreturiStandard pElem, BListaPreturiClienti pElemClient)
        {
            pElemClient = BListaPreturiClienti.GetPretClient(pElem.Id, this.lClient.Id, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

            pRand.Tag = new Tuple<BListaPreturiStandard, BListaPreturiClienti>(pElem, pElemClient);

            pRand.Cells[EnumColoaneDGV.colLucrare.ToString()].Value = pElem.Denumire;
            pRand.Cells[EnumColoaneDGV.colMoneda.ToString()].Value = pElem.GetEtichetaMoneda();
            pRand.Cells[EnumColoaneDGV.colPretStandard.ToString()].Value = pElem.GetValoare();

            if (pElemClient != null)
            {
                pRand.Cells[EnumColoaneDGV.colPretClient.ToString()].Value = pElemClient.GetValoareClient();
                pRand.Cells[EnumColoaneDGV.colAjustare.ToString()].Value = pElemClient.GetEtichetaAjustare();
            }
            else
            {
                pRand.Cells[EnumColoaneDGV.colPretClient.ToString()].Value = pElem.GetValoare();
            }
            pRand.Cells[EnumColoaneDGV.colPretClient.ToString()].Tag = new Tuple<BListaPreturiStandard, BListaPreturiClienti>(pElem, pElemClient);
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
