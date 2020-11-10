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

namespace iStomaLab.Setari.Lucrari
{
    public partial class ControlListaDePreturiClienti : UserControlPersonalizat
    {

        #region Declaratii generale


        #endregion

        #region Enumerari si Structuri

        public enum EnumColoaneDGV
        {
            colLucrare,
            colPret,
            colMoneda
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
            this.dgvListaDePreturiClienti.CellFormatting += DgvListaDePreturiClienti_CellFormatting;
            this.dgvListaDePreturiClienti.CellEndEdit += DgvListaDePreturiClienti_CellEndEdit;
            this.txtCautaLucrare.CerereUpdate += TxtCautaLucrare_CerereUpdate;
            this.dgvListaDePreturiClienti.EditareLinie += DgvListaDePreturiClienti_EditareLinie;
        }
        
        private void initTextML()
        {

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

        private void DgvListaDePreturiClienti_EditareLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BListaPreturiStandard listaPret = this.dgvListaDePreturiClienti.Rows[this.dgvListaDePreturiClienti.CurrentCell.RowIndex].Tag as BListaPreturiStandard;

                if (FormDetaliuLucrare.Afiseaza(this.GetFormParinte(), listaPret))
                {
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

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                Tuple<BClienti, BListaPreturiClienti> dateClient = this.dgvListaDePreturiClienti.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag as Tuple<BClienti, BListaPreturiClienti>;

                if (dateClient != null)
                {

                    if (dateClient.Item2 != null)
                    {
                        //UPDATE
                        dateClient.Item2.UpdatePret(CUtil.GetAsDouble(this.dgvListaDePreturiClienti.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                    }
                    else
                    {
                        //ADD
                        BListaPreturiStandard listaPret = this.dgvListaDePreturiClienti.Rows[this.dgvListaDePreturiClienti.CurrentCell.RowIndex].Tag as BListaPreturiStandard;

                        bool esteRon = listaPret.ValoareRON != 0 ? true : false;

                        BListaPreturiClienti.Add(listaPret.Id, dateClient.Item1.Id, esteRon ? CUtil.GetAsDouble(this.dgvListaDePreturiClienti.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) : 0, esteRon ? 0 : CUtil.GetAsDouble(this.dgvListaDePreturiClienti.Rows[e.RowIndex].Cells[e.ColumnIndex].Value), listaPret.TermenMediuZile, null);
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

        private void DgvListaDePreturiClienti_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.BackColor = Color.White;
            e.CellStyle.ForeColor = Color.Black;
        }

        #endregion

        #region Metode private

        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaDePreturiClienti.IncepeConstructieColoane();
            this.dgvListaDePreturiClienti.EditMode = DataGridViewEditMode.EditOnEnter;

            this.dgvListaDePreturiClienti.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvListaDePreturiClienti.AdaugaColoanaText(EnumColoaneDGV.colLucrare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Lucrare), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaDePreturiClienti.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colPret.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pret), 70, DataGridViewColumnSortMode.Automatic);

            this.dgvListaDePreturiClienti.AdaugaColoanaText(EnumColoaneDGV.colMoneda.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Moneda), 50, false, DataGridViewColumnSortMode.Automatic);

            foreach (BClienti pClient in BClienti.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null))
            {

                this.dgvListaDePreturiClienti.AdaugaColoanaValoareMonetara(pClient.Denumire, pClient.Denumire, 100, DataGridViewColumnSortMode.Automatic);
                this.dgvListaDePreturiClienti.Columns[pClient.Denumire].ReadOnly = false;
            }
            
            this.dgvListaDePreturiClienti.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaDePreturiClienti.IncepeContructieRanduri();

            var listaElem = BListaPreturiStandard.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

            foreach (var elem in listaElem)
            {
                incarcaRandPretStandard(this.dgvListaDePreturiClienti.Rows[this.dgvListaDePreturiClienti.Rows.Add()], elem, null);
            }


            this.dgvListaDePreturiClienti.FinalizeazaContructieRanduri();
        }

        private void incarcaRandPretStandard(DataGridViewRow pRand, BListaPreturiStandard pElem, BListaPreturiClienti pElemClient)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);
            pRand.Cells[EnumColoaneDGV.colLucrare.ToString()].Value = pElem.Denumire;
            pRand.Cells[EnumColoaneDGV.colMoneda.ToString()].Value = pElem.ValoareRON == 0 ? CUtil.getText(1265) : CUtil.getText(1264);
            pRand.Cells[EnumColoaneDGV.colPret.ToString()].Value = pElem.ValoareRON == 0 ? pElem.ValoareEUR : pElem.ValoareRON;
            foreach (BClienti client in BClienti.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null))
            {
                pElemClient = BListaPreturiClienti.GetPretClient(pElem.Id, client.Id, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

                if (pElemClient != null)
                {
                    pRand.Cells[client.Denumire].Value = pElemClient.GetValoare();
                }
                else
                {
                    pRand.Cells[client.Denumire].Value = pElem.GetValoare();
                }

                pRand.Cells[client.Denumire].Tag = new Tuple<BClienti, BListaPreturiClienti>(client, pElemClient);
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
