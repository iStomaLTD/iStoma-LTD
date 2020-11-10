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
using BLL.iStomaLab.Referinta;

namespace iStomaLab.Setari.Liste.Localitati
{
    public partial class ControlDetaliuListaLocalitati : UserControlPersonalizat
    {

        #region Declaratii generale


        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colLocalitate,
            colTip,
            colRegiune,
            colTara
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlDetaliuListaLocalitati()
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
            this.btnAdaugaLocalitate.Click += BtnAdaugaLocalitate_Click;
            this.txtCautaLocalitate.CerereUpdate += TxtCautaLocalitate_CerereUpdate;
            this.dgvListaLocalitati.EditareLinie += DgvListaLocalitati_EditareLinie;
            this.dgvListaLocalitati.StergereLinie += DgvListaLocalitati_StergereLinie;
            this.btnActiviInactivi.Click += BtnActiviInactivi_Click;
        }

        private void initTextML()
        {
            this.lblLocalitate.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Localitate);
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.txtCautaLocalitate.Goleste();
            this.btnActiviInactivi.Selectat = false;

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void BtnActiviInactivi_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

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

        private void DgvListaLocalitati_StergereLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BLocalitati localitateDeSters = this.dgvListaLocalitati.Rows[pIndexRand].Tag as BLocalitati;

                if (localitateDeSters != null)
                {

                    if (!this.btnActiviInactivi.Selectat)
                    {
                        if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), localitateDeSters.Nume))
                        {
                            localitateDeSters.Close(true, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stergere), null);
                            ConstruiesteRanduriDGV();
                        }
                    }
                    else
                    {
                        if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiReactivarea), localitateDeSters.Nume))
                        {
                            localitateDeSters.Close(false, string.Empty, null);
                            ConstruiesteRanduriDGV();
                        }
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

        private void DgvListaLocalitati_EditareLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BLocalitati localitateDeModificat = this.dgvListaLocalitati.Rows[pIndexRand].Tag as BLocalitati;

                if (localitateDeModificat != null && !btnActiviInactivi.Selectat)
                {
                    if (FormAdaugaLocalitate.Afiseaza(this.GetFormParinte(), localitateDeModificat))
                    {
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

        private void TxtCautaLocalitate_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvListaLocalitati.FiltreazaDupaText(this.txtCautaLocalitate.Text);
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

        private void BtnAdaugaLocalitate_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (FormAdaugaLocalitate.Afiseaza(this.GetFormParinte(), null))
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

        #endregion

        #region Metode private

        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaLocalitati.IncepeConstructieColoane();

            this.dgvListaLocalitati.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvListaLocalitati.AdaugaColoanaText(EnumColoaneDGV.colLocalitate.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Localitate), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaLocalitati.AdaugaColoanaText(EnumColoaneDGV.colRegiune.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Regiune), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaLocalitati.AdaugaColoanaText(EnumColoaneDGV.colTara.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tara), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaLocalitati.AdaugaColoanaText(EnumColoaneDGV.colTip.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tip), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaLocalitati.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvListaLocalitati.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            var listaElem = BLocalitati.GetListByParam(-1, BTari.ConstIDRomania, CDL.iStomaLab.CDefinitiiComune.EnumStare.Toate, null);

            if (listaElem.ContineElementeDeactivate())
            {
                this.btnActiviInactivi.Visible = true;
            }
            else
            {
                this.btnActiviInactivi.Visible = false;
                this.btnActiviInactivi.Selectat = false;
            }


            if (!this.btnActiviInactivi.Selectat)
                ConstruiesteRanduriDGV(listaElem.GetListaActive());
            else
                ConstruiesteRanduriDGV(listaElem.GetListaInactive());
        }

        private void ConstruiesteRanduriDGV(BColectieLocalitati pListaLocalitati)
        {
            this.dgvListaLocalitati.IncepeContructieRanduri();

            foreach (var elem in pListaLocalitati)
            {
                incarcaRand(this.dgvListaLocalitati.Rows[this.dgvListaLocalitati.Rows.Add()], elem);
            }

            this.dgvListaLocalitati.FinalizeazaContructieRanduri();

            this.lblTotalLocalitati.Text = string.Format(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.xElementeGasite), this.dgvListaLocalitati.RowCount);
        }

        private void incarcaRand(DataGridViewRow pRand, BLocalitati pElem)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);
            pRand.Cells[EnumColoaneDGV.colLocalitate.ToString()].Value = pElem.Nume;
            pRand.Cells[EnumColoaneDGV.colRegiune.ToString()].Value = pElem.NumeRegiune;
            pRand.Cells[EnumColoaneDGV.colTara.ToString()].Value = pElem.NumeTara;
            pRand.Cells[EnumColoaneDGV.colTip.ToString()].Value = pElem.Tip;
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
