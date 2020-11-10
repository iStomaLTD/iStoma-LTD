using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iStomaLab.Generale;
using BLL.iStomaLab.Clienti;
using CDL.iStomaLab;
using BLL.iStomaLab;
using CCL.iStomaLab;
using CCL.UI;

namespace iStomaLab.TablouDeBord.Facturare
{
    public partial class ControlListaIncasari : UserControlPersonalizat
    {

        #region Declaratii generale

        private double lTotalIncasariInRON = 0;

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colData,
            colModalitate,
            colClinica,
            colValoare,
            colCursBNR,
            colDetaliiClinica,
            colObservatii
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlListaIncasari()
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
            this.ctrlPerioada.PerioadaSchimbata += CtrlPerioada_PerioadaSchimbata;
            this.txtCautare.CerereUpdate += TxtCautare_CerereUpdate;
            this.ctrlCautareDupaTextClinica.SelecteazaObiectAfisaj += CtrlCautareDupaTextClinica_Update;
            this.ctrlCautareDupaTextClinica.StergeObiectAfisaj += CtrlCautareDupaTextClinica_Update;
            this.ctrlCautareDupaTextClinica.DeschideEcranCautare += CtrlCautareDupaTextClinica_Update;

            this.dgvLista.EditareLinie += DgvLista_EditareLinie;
            this.dgvLista.StergereLinie += DgvLista_StergereLinie;
            this.dgvLista.CellClick += DgvLista_CellClick;
            this.dgvLista.CereRefresh += DgvLista_CereRefresh;

            this.VisibleChanged += ControlListaIncasari_VisibleChanged;
        }


        private void initTextML()
        {
            this.lblClinica.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Clinica);
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.txtCautare.Goleste();

            this.ctrlPerioada.Initializeaza(CDefinitiiComune.EnumTipPerioada.Luna, DateTime.Now);
            this.ctrlCautareDupaTextClinica.Initializeaza(StructIdDenumire.Empty, CEnumerariComune.EnumTipDeschidere.DreaptaJos);

            this.ctrlCautareDupaTextClinica.Focus();

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente
        private void DgvLista_CereRefresh(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                ConstruiesteColoaneDGV();
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
        private void DgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.lSeIncarca || e.RowIndex < 0) return;
            try
            {
                incepeIncarcarea();

                string numeColoana = this.dgvLista.Columns[e.ColumnIndex].Name;

                if (numeColoana.Equals(EnumColoaneDGV.colDetaliiClinica.ToString()))
                {
                    BClientiPlati plata = this.dgvLista.SelectedRow.Tag as BClientiPlati;

                    IHMUtile.DeschideDosarClient(this.GetFormParinte(), plata.IdClient);
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

        private void DgvLista_StergereLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca || pIndexRand < 0) return;
            try
            {
                incepeIncarcarea();

                if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stergere)))
                {
                    BClientiPlati plata = this.dgvLista.Rows[pIndexRand].Tag as BClientiPlati;

                    plata.Close(true, string.Empty, null);

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

        private void ControlListaIncasari_VisibleChanged(object sender, EventArgs e)
        {
            this.ctrlCautareDupaTextClinica.AscundeEcranRezultatCautare();
        }

        private void DgvLista_EditareLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();
                BClientiPlati plata = this.dgvLista.Rows[pIndexRand].Tag as BClientiPlati;

                if (plata != null)
                {
                    BColectieClientiPlatiComenzi listaPlati = BClientiPlatiComenzi.GetByIdPlata(plata.Id, null);
                    if (!CUtil.EsteListaVida<BClientiPlatiComenzi>(listaPlati))
                    {
                        BColectieClientiComenzi listaLucrari = BClientiComenzi.getByListaId(listaPlati.GetListaIdComenzi(), null);

                        BColectieClientiFacturi listaFacturi = BClientiFacturi.GetByListId(listaLucrari.GetListaIdFacturi(), null);

                        BClienti client = plata.GetClient(null);

                        if (FormCreeazaIncasareClient.Afiseaza(this.GetFormParinte(), client, listaLucrari, listaFacturi, plata))
                        {
                            incarcaRand(this.dgvLista.Rows[pIndexRand], plata);
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

        private void CtrlCautareDupaTextClinica_Update(object sender, EventArgs e)
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

        private void TxtCautare_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                filtreazaDupaText();
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

        private void CtrlPerioada_PerioadaSchimbata(object sender, EventArgs e)
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

        #endregion

        #region Metode private

        private void filtreazaDupaText()
        {
            setNrLinii(this.dgvLista.FiltreazaDupaText(this.txtCautare.Text));
        }

        private void setNrLinii(int pNrLinii)
        {
           double totalRON = 0;

            BClientiPlati plata = null;
            this.lTotalIncasariInRON = 0;
            double valTemp = 0;
            foreach (DataGridViewRow rand in this.dgvLista.Rows)
            {
                if (rand.Visible)
                {
                    plata = rand.Tag as BClientiPlati;

                    valTemp = DataGridViewPersonalizat.GetValoareTagColoanaRand(rand, EnumColoaneDGV.colValoare.ToString());
                    totalRON += valTemp;

                }
            }

            this.lTotalIncasariInRON = totalRON;

            this.lblTotal.Text = string.Format("{0}: {1} [{2}: {3}]",
                        BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Incasari),
                        this.dgvLista.RowCount,
                        BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Total),
                       CUtil.GetValoareMonetara(totalRON));
        }

        private void ConstruiesteColoaneDGV()
        {
            this.dgvLista.IncepeConstructieColoane();

            this.dgvLista.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvLista.AdaugaColoanaData(EnumColoaneDGV.colData.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Data), 100, false, DataGridViewColumnSortMode.Automatic);
            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colClinica.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Clinica), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaButonClasic(EnumColoaneDGV.colDetaliiClinica.ToString(), string.Empty, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DeschideFisaClinicii), DataGridViewPersonalizat._SLatimeButonDeschidere, false);

            this.dgvLista.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colValoare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Valoare), 100, DataGridViewColumnSortMode.Automatic);
            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colModalitate.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Modalitate), 150, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colObservatii.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colCursBNR.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Curs), 80, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvLista.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvLista.IncepeContructieRanduri();

            BColectieClientiPlati listaPlati = null;

            int idClinica = this.ctrlCautareDupaTextClinica.GetIdClinica();

            listaPlati = BClientiPlati.GetListaIncasari(idClinica, this.ctrlPerioada.DataInceput, this.ctrlPerioada.DataSfarsit, null);
            
            foreach (var item in listaPlati)
            {
                incarcaRand(this.dgvLista.Rows[this.dgvLista.Rows.Add()], item);
            }

            filtreazaDupaText();

            this.dgvLista.FinalizeazaContructieRanduri();
        }

        private void incarcaRand(DataGridViewRow pRand, BClientiPlati pElem)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);

            pRand.Cells[EnumColoaneDGV.colData.ToString()].Value = pElem.DataPlata;
            pRand.Cells[EnumColoaneDGV.colModalitate.ToString()].Value = BDefinitiiGenerale.StructModalitatePlata.GetStringByEnum((BDefinitiiGenerale.EnumModalitatePlata)pElem.ModalitatePlata);
            DataGridViewPersonalizat.InitCelulaValoareMonetara(pRand, EnumColoaneDGV.colValoare.ToString(), pElem.SumaPlatita, CDefinitiiComune.EnumTipMoneda.Lei);

            pRand.Cells[EnumColoaneDGV.colClinica.ToString()].Value = pElem.DenumireClient;
            pRand.Cells[EnumColoaneDGV.colObservatii.ToString()].Value = pElem.Observatii;
            pRand.Cells[EnumColoaneDGV.colCursBNR.ToString()].Value = pElem.CursBNR;

            DataGridViewPersonalizat.InitCelulaStergere(pRand);

            DataGridViewPersonalizat.InitCelulaDeschideClasic(pRand, EnumColoaneDGV.colDetaliiClinica.ToString());
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
