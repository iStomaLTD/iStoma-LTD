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

namespace iStomaLab.Setari.Liste.Regiuni
{
    public partial class ControlListaRegiuni : UserControlPersonalizat
    {

        #region Declaratii generale


        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colRegiune,
            colAbreviere,
            colPrefixTelefonic,
            colTara
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlListaRegiuni()
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
            this.btnAdaugareRegiune.Click += BtnAdaugareRegiune_Click;
            this.txtCautaTara.CerereUpdate += TxtCautaTara_CerereUpdate;
            this.dgvListaRegiuni.StergereLinie += DgvListaRegiuni_StergereLinie;
            this.dgvListaRegiuni.EditareLinie += DgvListaRegiuni_EditareLinie;
            this.btnActiviInactivi.Click += BtnActiviInactivi_Click;
        }

        private void initTextML()
        {
            this.lblTotalRegiuni.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Regiuni);
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.txtCautaTara.Goleste();

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

        private void DgvListaRegiuni_EditareLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BRegiuni regiuneDeModificat = this.dgvListaRegiuni.Rows[pIndexRand].Tag as BRegiuni;

                if (regiuneDeModificat != null && !this.btnActiviInactivi.Selectat)
                {
                    if (FormAdaugareRegiune.Afiseaza(this.GetFormParinte(), regiuneDeModificat))
                    {
                        incarcaRand(this.dgvListaRegiuni.Rows[pIndexRand], regiuneDeModificat);
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

        private void DgvListaRegiuni_StergereLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BRegiuni regiuneDeSters = this.dgvListaRegiuni.Rows[pIndexRand].Tag as BRegiuni;

                if (regiuneDeSters != null)
                {
                    if (!this.btnActiviInactivi.Selectat)
                    {
                        if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), regiuneDeSters.Nume))
                        {
                            regiuneDeSters.Close(true, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Inchidere), null);
                            ConstruiesteRanduriDGV();
                        }
                    }
                    else
                    {
                        if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiReactivarea), regiuneDeSters.Nume))
                        {
                            regiuneDeSters.Close(false, string.Empty, null);
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

        private void TxtCautaTara_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvListaRegiuni.FiltreazaDupaText(this.txtCautaTara.Text);
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

        private void BtnAdaugareRegiune_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (Setari.Liste.Regiuni.FormAdaugareRegiune.Afiseaza(this.GetFormParinte(), null))
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
            this.dgvListaRegiuni.IncepeConstructieColoane();

            this.dgvListaRegiuni.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvListaRegiuni.AdaugaColoanaText(EnumColoaneDGV.colRegiune.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Regiune), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaRegiuni.AdaugaColoanaText(EnumColoaneDGV.colAbreviere.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Abreviere), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaRegiuni.AdaugaColoanaText(EnumColoaneDGV.colPrefixTelefonic.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PrefixTelefonic), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaRegiuni.AdaugaColoanaText(EnumColoaneDGV.colTara.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tara), 130, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaRegiuni.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvListaRegiuni.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            var listaElem = BRegiuni.GetListByParam(BTari.ConstIDRomania, CDL.iStomaLab.CDefinitiiComune.EnumStare.Toate, null);

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

        private void ConstruiesteRanduriDGV(BColectieRegiuni pListaRegiuni)
        {
            this.dgvListaRegiuni.IncepeContructieRanduri();

            foreach (var elem in pListaRegiuni)
            {
                incarcaRand(this.dgvListaRegiuni.Rows[this.dgvListaRegiuni.Rows.Add()], elem);
            }

            this.dgvListaRegiuni.FinalizeazaContructieRanduri();

            this.lblTotalRegiuni.Text = string.Format(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.xElementeGasite), this.dgvListaRegiuni.RowCount);
        }

        private void incarcaRand(DataGridViewRow pRand, BRegiuni pElem)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);
            pRand.Cells[EnumColoaneDGV.colRegiune.ToString()].Value = pElem.Nume;
            pRand.Cells[EnumColoaneDGV.colAbreviere.ToString()].Value = pElem.Abreviere;
            pRand.Cells[EnumColoaneDGV.colPrefixTelefonic.ToString()].Value = pElem.PrefixTelefon;
            pRand.Cells[EnumColoaneDGV.colTara.ToString()].Value = pElem.NumeTara; 
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
