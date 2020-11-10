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
using BLL.iStomaLab.Utilizatori;
using CCL.UI;
using CCL.iStomaLab;
using CDL.iStomaLab;
using System;

namespace iStomaLab.Setari.Personal
{
    public partial class ControlListaUtilizatori : UserControlPersonalizat
    {

        #region Declaratii generale


        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colCuloare,
            colNume,
            colPrenume,
            colDataNastere,
            colTelefonMobil,
            colTelefonFix,
            colCnp,
            colEmail
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlListaUtilizatori()
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
            this.btnAdaugaUtilizator.Click += BtnAdauga_Click;
            this.dgvListaUtilizatori.StergereLinie += DgvLista_StergereLinie;
            this.dgvListaUtilizatori.EditareLinie += DgvLista_EditareLinie;
            this.txtCautareUtilizatori.CerereUpdate += TxtCautare_CerereUpdate;
            this.dgvListaUtilizatori.CellClick += DgvListaUtilizatori_CellClick;
        }
        
        private void initTextML()
        {

        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.txtCautareUtilizatori.Goleste();

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void DgvListaUtilizatori_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BUtilizator utilizatorSelectat = this.dgvListaUtilizatori.CurrentRow.Tag as BUtilizator;

                if (utilizatorSelectat != null)
                {
                    this.dgvListaUtilizatori.CurrentRow.Cells[1].Style.SelectionBackColor = BDefinitiiGenerale.getCuloareDinARGB(utilizatorSelectat.Culoare);
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

        private void TxtCautare_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvListaUtilizatori.FiltreazaDupaText(this.txtCautareUtilizatori.Text);
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

        private void DgvLista_EditareLinie(CCL.UI.DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BUtilizator userDeModificat = this.dgvListaUtilizatori.Rows[pIndexRand].Tag as BUtilizator;

                if (userDeModificat != null)
                {
                    if (FormDosarUtilizator.Afiseaza(this.GetFormParinte(), userDeModificat))
                    {
                        incarcaRand(this.dgvListaUtilizatori.Rows[pIndexRand], userDeModificat);
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

        private void DgvLista_StergereLinie(CCL.UI.DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BUtilizator userDeSters = this.dgvListaUtilizatori.Rows[pIndexRand].Tag as BUtilizator;

                if (userDeSters != null)
                {
                    if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), userDeSters.Nume + " " + userDeSters.Prenume))
                    {
                        userDeSters.Close(true, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stergere), null);
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

        private void BtnAdauga_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (FormDetaliuUtilizator.Afiseaza(this.GetFormParinte(), null))
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

        #endregion

        #region Metode private

        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaUtilizatori.IncepeConstructieColoane();

            this.dgvListaUtilizatori.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvListaUtilizatori.AdaugaColoanaText(EnumColoaneDGV.colCuloare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Culoare), 50, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaUtilizatori.AdaugaColoanaText(EnumColoaneDGV.colNume.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Nume), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaUtilizatori.AdaugaColoanaText(EnumColoaneDGV.colPrenume.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Prenume), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaUtilizatori.AdaugaColoanaData(EnumColoaneDGV.colDataNastere.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataNasterii), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);

            this.dgvListaUtilizatori.AdaugaColoaneTelefonEmail();

            this.dgvListaUtilizatori.AdaugaColoanaText(EnumColoaneDGV.colTelefonFix.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TelefonFix), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaUtilizatori.AdaugaColoanaText(EnumColoaneDGV.colCnp.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CNP), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaUtilizatori.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvListaUtilizatori.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaUtilizatori.IncepeContructieRanduri();

            var listaElem = BUtilizator.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

            foreach (var elem in listaElem)
            {
                incarcaRand(this.dgvListaUtilizatori.Rows[this.dgvListaUtilizatori.Rows.Add()], elem);
            }

            this.dgvListaUtilizatori.FinalizeazaContructieRanduri();

            int totalUtilizatori = this.dgvListaUtilizatori.RowCount;
            if (totalUtilizatori == 1)
            {
                this.lblTotalUtilizatori.Text = totalUtilizatori + BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ElementGasit);
            }
            else
            {
                this.lblTotalUtilizatori.Text = totalUtilizatori + BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ElementeGasite);
            }
        }

        private void incarcaRand(DataGridViewRow pRand, BUtilizator pElem)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);
            pRand.Cells[EnumColoaneDGV.colCuloare.ToString()].Style.BackColor = BDefinitiiGenerale.getCuloareDinARGB(pElem.Culoare);
            pRand.Cells[EnumColoaneDGV.colNume.ToString()].Value = pElem.Nume;
            pRand.Cells[EnumColoaneDGV.colPrenume.ToString()].Value = pElem.Prenume;
            if (CUtil.isNotNull(pElem.DataNastere))
                pRand.Cells[EnumColoaneDGV.colDataNastere.ToString()].Value = pElem.DataNastere;
            pRand.Cells[EnumColoaneDGV.colTelefonFix.ToString()].Value = pElem.TelefonFix;
            pRand.Cells[EnumColoaneDGV.colCnp.ToString()].Value = pElem.CNP;
            DataGridViewPersonalizat.InitCeluleTelefonEmail(pRand, pElem.TelefonMobil, pElem.AdresaMail);
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
