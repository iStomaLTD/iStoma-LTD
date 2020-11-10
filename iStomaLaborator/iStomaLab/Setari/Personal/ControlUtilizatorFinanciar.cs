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
using BLL.iStomaLab.Utilizatori;
using BLL.iStomaLab;
using CCL.UI;
using CCL.iStomaLab;
using CDL.iStomaLab;
using static BLL.iStomaLab.BDefinitiiGenerale;
using static CDL.iStomaLab.CDefinitiiComune;

namespace iStomaLab.Setari.Personal
{
    public partial class ControlUtilizatorFinanciar : UserControlPersonalizat
    {

        #region Declaratii generale

        private BUtilizator lUtilizator = null;

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colTipVenit,
            colDataInceput,
            colDataSfarsit,
            colObservatii,
            colSalariuFix,
            colDataCreare
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlUtilizatorFinanciar()
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
            this.btnAdaugaVenit.Click += BtnAdaugaVenit_Click;
            this.dgvListaVenituri.EditareLinie += DgvListaVenituri_EditareLinie;
            this.dgvListaVenituri.StergereLinie += DgvListaVenituri_StergereLinie;
        }

        private void initTextML()
        {
            this.lblTitlu.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Venituri);
            this.lblTotalVenituri.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrElemente);
        }

        public void Initializeaza(BUtilizator pUtilizator)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.lUtilizator = pUtilizator;

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void BtnAdaugaVenit_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (FormCreareUtilizatorVenit.Afiseaza(this.GetFormParinte(), this.lUtilizator, null))
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

        private void DgvListaVenituri_EditareLinie(CCL.UI.DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BUtilizatoriVenituri venitDeModificat = this.dgvListaVenituri.Rows[pIndexRand].Tag as BUtilizatoriVenituri;

                if (venitDeModificat != null)
                {
                    if (FormCreareUtilizatorVenit.Afiseaza(this.GetFormParinte(), this.lUtilizator, venitDeModificat))
                    {
                        incarcaRand(this.dgvListaVenituri.Rows[pIndexRand], venitDeModificat);
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

        private void DgvListaVenituri_StergereLinie(CCL.UI.DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BUtilizatoriVenituri venitDeSters = this.dgvListaVenituri.Rows[pIndexRand].Tag as BUtilizatoriVenituri;

                if (venitDeSters != null)
                {

                    if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), venitDeSters.TipVenit.ToString()))
                    {
                        venitDeSters.Close(true, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stergere), null);
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


        #endregion

        #region Metode private

        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaVenituri.IncepeConstructieColoane();

            this.dgvListaVenituri.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvListaVenituri.AdaugaColoanaText(EnumColoaneDGV.colTipVenit.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TipVenit), 200, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaVenituri.AdaugaColoanaData(EnumColoaneDGV.colDataInceput.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DeLa), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);

            this.dgvListaVenituri.AdaugaColoanaData(EnumColoaneDGV.colDataSfarsit.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PanaLa), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);

            this.dgvListaVenituri.AdaugaColoanaText(EnumColoaneDGV.colSalariuFix.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.SalariuFix), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaVenituri.AdaugaColoanaText(EnumColoaneDGV.colObservatii.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii), 60, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaVenituri.AdaugaColoanaData(EnumColoaneDGV.colDataCreare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataCreare), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);

            this.dgvListaVenituri.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvListaVenituri.FinalizeazaConstructieColoane();
        }


        private void ConstruiesteRanduriDGV()
        {
            var listaElem = BUtilizatoriVenituri.GetListByParam(lUtilizator.Id, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

            this.dgvListaVenituri.IncepeContructieRanduri();

            foreach (var item in listaElem)
            {
                incarcaRand(this.dgvListaVenituri.Rows[this.dgvListaVenituri.Rows.Add()], item);
            }

            this.dgvListaVenituri.FinalizeazaContructieRanduri();

            int totalElemente = this.dgvListaVenituri.RowCount;
            if (totalElemente == 1)
                this.lblTotalVenituri.Text = totalElemente.ToString() + BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ElementGasit);
            else
                this.lblTotalVenituri.Text = totalElemente.ToString() + BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ElementeGasite);
        }

        private void incarcaRand(DataGridViewRow pRand, BUtilizatoriVenituri pElem)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, true);

            pRand.Cells[EnumColoaneDGV.colTipVenit.ToString()].Value = BUtilizatoriVenituri.StructTipVenit.GetStringByEnum((BUtilizatoriVenituri.EnumTipVenit)pElem.TipVenit);

            if (CUtil.isNotNull(pElem.DataInceput))
                pRand.Cells[EnumColoaneDGV.colDataInceput.ToString()].Value = pElem.DataInceput;
            if (CUtil.isNotNull(pElem.DataFinal))
                pRand.Cells[EnumColoaneDGV.colDataSfarsit.ToString()].Value = pElem.DataFinal;
            pRand.Cells[EnumColoaneDGV.colSalariuFix.ToString()].Value = pElem.SalariuFix;
            pRand.Cells[EnumColoaneDGV.colObservatii.ToString()].Value = CUtil.PregatesteStringMultiLineDGV(pElem.Observatii);

            if (CUtil.isNotNull(pElem.DataCreare))
                pRand.Cells[EnumColoaneDGV.colDataCreare.ToString()].Value = pElem.DataCreare;

            DataGridViewPersonalizat.InitCelulaStergere(pRand);
        }

        #endregion

        #region Metode publice



        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;

            this.btnAdaugaVenit.AllowModification(this.lEcranInModificare);
            this.dgvListaVenituri.AllowModification(this.lEcranInModificare);

        }

        #endregion


    }
}
