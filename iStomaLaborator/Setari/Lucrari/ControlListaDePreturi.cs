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
using CCL.iStomaLab;
using CDL.iStomaLab;
using System;
using BLL.iStomaLab.Preturi;
using BLL.iStomaLab.Referinta;

namespace iStomaLab.Setari.Lucrari
{
    public partial class ControlListaDePreturi : UserControlPersonalizat
    {

        #region Declaratii generale


        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colDenumire,
            colPrescurtare,
            colCod,
            colCategorie,
            colTermenMediu,
            colValoareRon,
            colValoareEuro
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlListaDePreturi()
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
            this.btnAdaugareLucrare.Click += BtnAdaugareLucrare_Click;
            this.dgvListaPreturi.StergereLinie += DgvListaPreturi_StergereLinie;
            this.dgvListaPreturi.EditareLinie += DgvListaPreturi_EditareLinie;
            this.txtCautareLucrare.CerereUpdate += TxtCautareLucrare_CerereUpdate;
            this.dgvListaPreturi.CellFormatting += DgvListaPreturi_CellFormatting;
        }

        private void initTextML()
        {
            this.lblTitluListaDePreturi.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Lucrari);

        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();
            this.txtCautareLucrare.Goleste();

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();
            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void TxtCautareLucrare_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvListaPreturi.FiltreazaDupaText(this.txtCautareLucrare.Text);
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

        private void DgvListaPreturi_EditareLinie(CCL.UI.DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BListaPreturiStandard lucrareDeModificat = this.dgvListaPreturi.Rows[pIndexRand].Tag as BListaPreturiStandard;

                if (lucrareDeModificat != null)
                {
                    if (FormDetaliuLucrare.Afiseaza(this.GetFormParinte(), lucrareDeModificat))
                    {
                        incarcaRand(this.dgvListaPreturi.Rows[pIndexRand], lucrareDeModificat);
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

        private void DgvListaPreturi_StergereLinie(CCL.UI.DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BListaPreturiStandard lucrareDeSters = this.dgvListaPreturi.Rows[pIndexRand].Tag as BListaPreturiStandard;

                if (lucrareDeSters != null)
                {
                    if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), lucrareDeSters.Denumire))
                    {
                        lucrareDeSters.Close(true, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stergere), null);
                        ConstruiesteRanduriDGV();
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

        private void BtnAdaugareLucrare_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (FormDetaliuLucrare.Afiseaza(this.GetFormParinte(), null))
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

        private void DgvListaPreturi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.BackColor = Color.White;
            e.CellStyle.ForeColor = Color.Black;
        }

        #endregion

        #region Metode private

        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaPreturi.IncepeConstructieColoane();

            this.dgvListaPreturi.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvListaPreturi.AdaugaColoanaText(EnumColoaneDGV.colDenumire.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaPreturi.AdaugaColoanaText(EnumColoaneDGV.colPrescurtare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Prescurtare), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaPreturi.AdaugaColoanaText(EnumColoaneDGV.colCod.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Cod), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaPreturi.AdaugaColoanaText(EnumColoaneDGV.colCategorie.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Categorie), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaPreturi.AdaugaColoanaText(EnumColoaneDGV.colTermenMediu.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TermenMediu), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaPreturi.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colValoareRon.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.RON), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvListaPreturi.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colValoareEuro.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.EUR), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvListaPreturi.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvListaPreturi.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaPreturi.IncepeContructieRanduri();

            var listaElem = BListaPreturiStandard.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

            //Incarcam lista
            foreach (var elem in listaElem)
            {
                incarcaRand(this.dgvListaPreturi.Rows[this.dgvListaPreturi.Rows.Add()], elem);
            }

            this.dgvListaPreturi.FinalizeazaContructieRanduri();

            int totalElemente = this.dgvListaPreturi.RowCount;
            if (totalElemente == 1)
            {
                this.lblTotalListaPreturi.Text = totalElemente.ToString() + BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ElementGasit);
            }
            else
            {
                this.lblTotalListaPreturi.Text = totalElemente.ToString() + BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ElementeGasite);
            }


        }

        private void incarcaRand(DataGridViewRow pRand, BListaPreturiStandard pElem)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);
            pRand.Cells[EnumColoaneDGV.colDenumire.ToString()].Value = pElem.Denumire;
            pRand.Cells[EnumColoaneDGV.colPrescurtare.ToString()].Value = pElem.DenumirePrescurtata;
            pRand.Cells[EnumColoaneDGV.colCod.ToString()].Value = pElem.CodIntern;
            pRand.Cells[EnumColoaneDGV.colCategorie.ToString()].Value = BListaPreturiStandard.getById(BListaPreturiStandard.getByIdCategorie(pElem.IdCategorie, null), null);
            pRand.Cells[EnumColoaneDGV.colTermenMediu.ToString()].Value = pElem.TermenMediuZile;
            pRand.Cells[EnumColoaneDGV.colValoareRon.ToString()].Value = pElem.ValoareRON;
            pRand.Cells[EnumColoaneDGV.colValoareEuro.ToString()].Value = pElem.ValoareEUR;
            DataGridViewPersonalizat.InitCelulaStergere(pRand);
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
