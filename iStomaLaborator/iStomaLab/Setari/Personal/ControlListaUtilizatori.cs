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
using CCL.UI.Caramizi;
using System.IO;

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
            colDataInceput,
            colNrCopii,
            colObservatii,
            colEmail,
            colRol,
            colDataCreare,
            colContStoma
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
            this.btnActiviInactivi.Click += BtnActiviInactivi_Click;
            this.btnMeniu.Click += BtnMeniu_Click;
            this.btnInchidePanel.Click += BtnMeniu_Click;
            this.btnImporta.Click += BtnImporta_Click;
            this.cboRol.CerereUpdate += CboRol_CerereUpdate;
        }

        private void initTextML()
        {
            this.btnImporta.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Importa);
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.cboRol.BeginUpdate();
            this.cboRol.DataSource = BDefinitiiGenerale.StructRol.getListaRol();
            this.cboRol.EndUpdate();
            this.cboRol.SelectedItem = null;
            this.txtCautareUtilizatori.Goleste();
            this.btnActiviInactivi.Selectat = false;
            this.panelOptiuni.Visible = false;

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void CboRol_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
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

        private void BtnImporta_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (FormImportPersonal.Afiseaza(this.GetFormParinte()))
                {
                    ConstruiesteRanduriDGV();
                    this.panelOptiuni.Visible = false;
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

        private void BtnMeniu_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.panelOptiuni.Visible = !this.panelOptiuni.Visible;
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

        private void DgvListaUtilizatori_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (this.lSeIncarca || e.RowIndex < 0) return;
            try
            {
                incepeIncarcarea();

                BUtilizator utilizatorSelectat = this.dgvListaUtilizatori.CurrentRow.Tag as BUtilizator;

                string numeColoana = this.dgvListaUtilizatori.Columns[e.ColumnIndex].Name;

                if (numeColoana.Equals(EnumColoaneDGV.colCuloare.ToString()))
                {
                    arataControlAlegeCuloarea(e.RowIndex, e.ColumnIndex, utilizatorSelectat);
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

        private void DgvLista_EditareLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
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
                        if (this.dgvListaUtilizatori.Rows.Count >= pIndexRand)
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
                    if (!this.btnActiviInactivi.Selectat)
                    {
                        if (userDeSters.EsteADMIN())
                        {
                            Mesaj.Informare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.UtilizatorulAdminNuPoateFiSters), userDeSters.GetNumeCompletUtilizator());
                        }
                        else
                        {
                            if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), userDeSters.GetNumeCompletUtilizator()))
                            {
                                userDeSters.Close(true, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stergere), null);
                                ConstruiesteRanduriDGV();
                            }
                        }
                    }
                    else
                    {
                        if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.mesajConfirmareReactivareX), userDeSters.GetNumeCompletUtilizator()))
                        {
                            userDeSters.Close(false, string.Empty, null);
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

        private void BtnAdauga_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (FormCreareUtilizator.Afiseaza(this.GetFormParinte()))
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

        private void arataControlAlegeCuloarea(int pRowIndex, int pColumnIndex, BUtilizator pUtilizator)
        {
            controlGestiuneCuloare ctrlCuloare = new controlGestiuneCuloare();
            int culoare = CUtil.GetAsInt32(this.dgvListaUtilizatori.Rows[pRowIndex].Cells[pColumnIndex].Tag);
            ctrlCuloare.Initializeaza(culoare);
            ctrlCuloare.CautaCuloare(false);

            if (ctrlCuloare.CuloareARGB != 0)
            {
                this.dgvListaUtilizatori.Rows[pRowIndex].Cells[pColumnIndex].Style.BackColor = BDefinitiiGenerale.getCuloareDinARGB(ctrlCuloare.CuloareARGB);

                pUtilizator.Culoare = ctrlCuloare.CuloareARGB;
                pUtilizator.UpdateAll();

                //Refresh la linie
                incarcaRand(this.dgvListaUtilizatori.Rows[pRowIndex], pUtilizator);
            }
        }

        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaUtilizatori.IncepeConstructieColoane();

            this.dgvListaUtilizatori.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvListaUtilizatori.AdaugaColoanaText(EnumColoaneDGV.colCuloare.ToString(), string.Empty, 35, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaUtilizatori.AdaugaColoanaText(EnumColoaneDGV.colNume.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Nume), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaUtilizatori.AdaugaColoanaText(EnumColoaneDGV.colPrenume.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Prenume), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaUtilizatori.AdaugaColoanaText(EnumColoaneDGV.colContStoma.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Cont), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaUtilizatori.AdaugaColoanaData(EnumColoaneDGV.colDataNastere.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataNasterii), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);

            this.dgvListaUtilizatori.AdaugaColoaneTelefonEmail();

            this.dgvListaUtilizatori.AdaugaColoanaData(EnumColoaneDGV.colDataInceput.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataInceput), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);

            this.dgvListaUtilizatori.AdaugaColoanaNumerica(EnumColoaneDGV.colNrCopii.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrCopii), 50, DataGridViewColumnSortMode.Automatic);

            this.dgvListaUtilizatori.AdaugaColoanaText(EnumColoaneDGV.colRol.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Rol), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaUtilizatori.AdaugaColoanaText(EnumColoaneDGV.colObservatii.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaUtilizatori.AdaugaColoanaData(EnumColoaneDGV.colDataCreare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataCreare), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);

            this.dgvListaUtilizatori.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvListaUtilizatori.FinalizeazaConstructieColoane();
        }

        private CDefinitiiComune.EnumRol getRol()
        {
            if (this.cboRol.SelectedItem == null)
                return CDefinitiiComune.EnumRol.Nedefinit;

            return ((BDefinitiiGenerale.StructRol)this.cboRol.SelectedItem).Id;
        }

        private void ConstruiesteRanduriDGV()
        {
            var listaElem = BUtilizator.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Toate, getRol(), null);

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

        private void ConstruiesteRanduriDGV(BColectieUtilizator pListaUtilizatori)
        {
            this.dgvListaUtilizatori.IncepeContructieRanduri();

            foreach (var elem in pListaUtilizatori)
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

            DataGridViewPersonalizat.InitCelulaEditare(pRand, true);
            DataGridViewPersonalizat.SeteazaCuloareFundalCelula(pRand, EnumColoaneDGV.colCuloare.ToString(), BDefinitiiGenerale.getCuloareDinARGB(pElem.Culoare));
            pRand.Cells[EnumColoaneDGV.colCuloare.ToString()].Tag = pElem.Culoare;
            pRand.Cells[EnumColoaneDGV.colNume.ToString()].Value = pElem.Nume;
            pRand.Cells[EnumColoaneDGV.colPrenume.ToString()].Value = pElem.Prenume;
            pRand.Cells[EnumColoaneDGV.colContStoma.ToString()].Value = pElem.ContStoma;
            
            if (pElem.EsteADMIN())
                this.dgvListaUtilizatori.SeteazaFontIngrosat(pRand, EnumColoaneDGV.colContStoma.ToString());

            if (CUtil.isNotNull(pElem.DataNastere))
                pRand.Cells[EnumColoaneDGV.colDataNastere.ToString()].Value = pElem.DataNastere;
            if (CUtil.isNotNull(pElem.DataContract))
                pRand.Cells[EnumColoaneDGV.colDataInceput.ToString()].Value = pElem.DataContract;
            pRand.Cells[EnumColoaneDGV.colNrCopii.ToString()].Value = pElem.NumarCopii;
            pRand.Cells[EnumColoaneDGV.colObservatii.ToString()].Value = pElem.Observatii;
            pRand.Cells[EnumColoaneDGV.colRol.ToString()].Value = pElem.GetRolEticheta();
            if (CUtil.isNotNull(pElem.DataCreare))
                pRand.Cells[EnumColoaneDGV.colDataCreare.ToString()].Value = pElem.DataCreare;
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
