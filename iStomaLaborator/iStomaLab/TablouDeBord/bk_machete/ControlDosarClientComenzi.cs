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
using BLL.iStomaLab;
using CCL.UI;
using BLL.iStomaLab.Reprezentanti;
using CDL.iStomaLab;
using CCL.iStomaLab;
using BLL.iStomaLab.Preturi;
using CCL.UI.Caramizi;
using static CDL.iStomaLab.CDefinitiiComune;
using BLL.iStomaLab.Utilizatori;

namespace iStomaLab.TablouDeBord.Clienti
{
    public partial class ControlDosarClientComenzi : UserControlPersonalizat
    {

        #region Declaratii generale

        private BClienti lClient = null;

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colTotalEtape,
            colLucrare,
            colNrElemente,
            colEtapaCurenta,
            colNumeMedic,
            colNumePacient,
            colTehnician,
            colDataPrimire,
            colDataLaGata,
            colObservatii
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlDosarClientComenzi()
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
            this.btnAdaugaComandaInLucru.Click += BtnAdaugaComanda_Click;
            //this.btnAdaugaComandaTrecuta.Click += BtnAdaugaComanda_Click;
            this.dgvComenziInLucru.EditareLinie += DgvComenzi_EditareLinie;
            this.dgvComenziTrecute.EditareLinie += DgvComenzi_EditareLinie;
            this.dgvComenziInLucru.StergereLinie += DgvComenzi_StergereLinie;
            this.dgvComenziTrecute.StergereLinie += DgvComenzi_StergereLinie;
            this.btnActiviInactivi.Click += BtnActiviInactivi_Click;
            this.dgvComenziInLucru.CellClick += DgvComenzi_CellClick;
            this.dgvComenziTrecute.CellClick += DgvComenzi_CellClick;
            this.txtCautareInLucru.CerereUpdate += TxtCautareInLucru_CerereUpdate;
            this.txtCautareTrecute.CerereUpdate += TxtCautareTrecute_CerereUpdate;

            this.SizeChanged += ControlDosarClientComenzi_SizeChanged;
        }

        private void initTextML()
        {
            this.lblComenziInLucru.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Nefacturate);
            this.lblComenziTrecute.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Facturate);
        }

        public void Initializeaza(BClienti pClient)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.lClient = pClient;
            this.btnActiviInactivi.Selectat = false;
            this.txtCautareInLucru.Goleste();
            this.txtCautareTrecute.Goleste();

            ConstruiesteColoaneDGVComenziInLucru();
            ConstruiesteColoaneDGVComenziTrecute();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void TxtCautareTrecute_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvComenziTrecute.FiltreazaDupaText(this.txtCautareTrecute.Text);
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

        private void TxtCautareInLucru_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvComenziInLucru.FiltreazaDupaText(this.txtCautareInLucru.Text);
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

        private void DgvComenzi_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                DataGridViewPersonalizat dgv = sender as DataGridViewPersonalizat;
                string denumireColoana = dgv.Columns[e.ColumnIndex].Name;

                if (denumireColoana.Equals(EnumColoaneDGV.colTotalEtape.ToString()))
                {
                    BClientiComenzi comanda = dgv.CurrentRow.Tag as BClientiComenzi;
                    if (comanda != null)
                    {
                        if (FormLucrareListaEtapeRealizate.Afiseaza(this.GetFormParinte(), comanda))
                        {
                            comanda.Refresh(null);
                            incarcaRand(dgv.SelectedRow, comanda);
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

        private void ControlDosarClientComenzi_SizeChanged(object sender, EventArgs e)
        {
            //Se modifica dimensiunea ecranului => recalculam si repozitionam panel-urile
            //int inaltime = this.Height / 2;
            //this.panelComenziInLucru.Height = inaltime - 5;
            //this.panelComenziTrecute.Location = new Point(this.panelComenziTrecute.Location.X, inaltime + 5);
            //this.panelComenziTrecute.Height = inaltime - 7;
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

        private void BtnAdaugaComanda_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (FormDetaliuComanda.Afiseaza(this.GetFormParinte(), null, this.lClient, null))
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

        private void DgvComenzi_EditareLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BClientiComenzi comandaDeModificat = pDGVSender.Rows[pIndexRand].Tag as BClientiComenzi;

                if (comandaDeModificat != null && !this.btnActiviInactivi.Selectat)
                {
                    BListaPreturiStandard lucrare = BListaPreturiStandard.getById(comandaDeModificat.IdLucrare, null);

                    if (FormDetaliuComanda.Afiseaza(this.GetFormParinte(), comandaDeModificat, this.lClient, lucrare))
                    {
                        incarcaRand(pDGVSender.Rows[pIndexRand], comandaDeModificat);
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

        private void DgvComenzi_StergereLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BClientiComenzi comandaDeSters = pDGVSender.Rows[pIndexRand].Tag as BClientiComenzi;

                if (comandaDeSters != null)
                {
                    if (!this.btnActiviInactivi.Selectat)
                    {
                        if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), null))
                        {
                            comandaDeSters.Close(true, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Inchidere), null);
                            ConstruiesteRanduriDGV();
                        }
                    }
                    else
                    {
                        if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiReactivarea), string.Empty))
                        {
                            comandaDeSters.Close(false, string.Empty, null);
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

        #endregion

        #region Metode private

        private void ConstruiesteColoaneDGVComenziInLucru()
        {
            this.dgvComenziInLucru.IncepeConstructieColoane();

            this.dgvComenziInLucru.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvComenziInLucru.AdaugaColoanaData(EnumColoaneDGV.colDataPrimire.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataPrimire), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);

            this.dgvComenziInLucru.AdaugaColoanaText(EnumColoaneDGV.colNumeMedic.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Medic), 130, false, DataGridViewColumnSortMode.Automatic);

            this.dgvComenziInLucru.AdaugaColoanaText(EnumColoaneDGV.colLucrare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Lucrare), 200, true, DataGridViewColumnSortMode.Automatic);

            this.dgvComenziInLucru.AdaugaColoanaText(EnumColoaneDGV.colNrElemente.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrElemente), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvComenziInLucru.AdaugaColoanaData(EnumColoaneDGV.colDataLaGata.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataLaGata), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);

            this.dgvComenziInLucru.AdaugaColoanaText(EnumColoaneDGV.colEtapaCurenta.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.EtapaCurenta), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvComenziInLucru.AdaugaColoanaText(EnumColoaneDGV.colTehnician.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tehnician), 130, false, DataGridViewColumnSortMode.Automatic);

            this.dgvComenziInLucru.AdaugaColoanaButonClasic(EnumColoaneDGV.colTotalEtape.ToString(), string.Empty, string.Empty, 40, false);

            this.dgvComenziInLucru.AdaugaColoanaText(EnumColoaneDGV.colNumePacient.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pacient), 130, false, DataGridViewColumnSortMode.Automatic);

            this.dgvComenziInLucru.AdaugaColoanaText(EnumColoaneDGV.colObservatii.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii), 150, false, DataGridViewColumnSortMode.Automatic);

            this.dgvComenziInLucru.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvComenziInLucru.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteColoaneDGVComenziTrecute()
        {
            this.dgvComenziTrecute.IncepeConstructieColoane();

            this.dgvComenziTrecute.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvComenziTrecute.AdaugaColoanaData(EnumColoaneDGV.colDataPrimire.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataPrimire), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);

            this.dgvComenziTrecute.AdaugaColoanaText(EnumColoaneDGV.colNumeMedic.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Medic), 130, false, DataGridViewColumnSortMode.Automatic);

            this.dgvComenziTrecute.AdaugaColoanaText(EnumColoaneDGV.colLucrare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Lucrare), 200, true, DataGridViewColumnSortMode.Automatic);

            this.dgvComenziTrecute.AdaugaColoanaText(EnumColoaneDGV.colNrElemente.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrElemente), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvComenziTrecute.AdaugaColoanaData(EnumColoaneDGV.colDataLaGata.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataLaGata), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);

            this.dgvComenziTrecute.AdaugaColoanaText(EnumColoaneDGV.colEtapaCurenta.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.EtapaCurenta), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvComenziTrecute.AdaugaColoanaText(EnumColoaneDGV.colTehnician.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tehnician), 130, false, DataGridViewColumnSortMode.Automatic);

            this.dgvComenziTrecute.AdaugaColoanaButonClasic(EnumColoaneDGV.colTotalEtape.ToString(), string.Empty, string.Empty, 40, false);

            this.dgvComenziTrecute.AdaugaColoanaText(EnumColoaneDGV.colNumePacient.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pacient), 130, false, DataGridViewColumnSortMode.Automatic);

            this.dgvComenziTrecute.AdaugaColoanaText(EnumColoaneDGV.colObservatii.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii), 150, false, DataGridViewColumnSortMode.Automatic);

            this.dgvComenziTrecute.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvComenziTrecute.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            var listaElem = BClientiComenzi.GetListByParam(this.lClient.Id, -1, -1, CDL.iStomaLab.CDefinitiiComune.EnumStare.Toate, null);

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

        private void ConstruiesteRanduriDGV(BColectieClientiComenzi pListaComenzi)
        {
            this.dgvComenziInLucru.IncepeContructieRanduri();
            this.dgvComenziTrecute.IncepeContructieRanduri();

            foreach (var elem in pListaComenzi)
            {
                if (elem.IdFactura <= 0)
                    incarcaRand(this.dgvComenziInLucru.Rows[this.dgvComenziInLucru.Rows.Add()], elem);
                else
                    incarcaRand(this.dgvComenziTrecute.Rows[this.dgvComenziTrecute.Rows.Add()], elem);
            }

            this.lblNrComenziInLucru.Text = string.Format("{0}: {1}", BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Nefacturate), this.dgvComenziInLucru.RowCount.ToString());
            this.lblNrComenziTrecute.Text = string.Format("{0}: {1}", BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Facturate), this.dgvComenziTrecute.RowCount.ToString());

            this.dgvComenziInLucru.FinalizeazaContructieRanduri();
            this.dgvComenziTrecute.FinalizeazaContructieRanduri();
        }

        private void incarcaRand(DataGridViewRow pRand, BClientiComenzi pElem)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);
            DataGridViewPersonalizat.InitCelulaDeschideClasic(pRand, EnumColoaneDGV.colTotalEtape.ToString());
            pRand.Cells[EnumColoaneDGV.colLucrare.ToString()].Value = pElem.DenumireLucrare;
            pRand.Cells[EnumColoaneDGV.colNrElemente.ToString()].Value = pElem.NrElemente.ToString();

            if (pElem.IdReprezentantClient != 0)
            {
                pRand.Cells[EnumColoaneDGV.colNumeMedic.ToString()].Value = pElem.GetIdentitateMedic();
            }
            pRand.Cells[EnumColoaneDGV.colNumePacient.ToString()].Value = pElem.NumePacient;

            pRand.Cells[EnumColoaneDGV.colTehnician.ToString()].Value = pElem.GetIdentitateTehnician();

            if (CUtil.isNotNull(pElem.DataPrimire))
                pRand.Cells[EnumColoaneDGV.colDataPrimire.ToString()].Value = pElem.DataPrimire;
            if (CUtil.isNotNull(pElem.DataLaGata))
                pRand.Cells[EnumColoaneDGV.colDataLaGata.ToString()].Value = pElem.DataLaGata;
            if (pElem.IdEtapaSetari != 0)
            {
                pRand.Cells[EnumColoaneDGV.colEtapaCurenta.ToString()].Value = BEtape.GetEtapaById(pElem.IdEtapaSetari, EnumStare.Activa, null).Denumire;
            }

            pRand.Cells[EnumColoaneDGV.colObservatii.ToString()].Value = pElem.Observatii;
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
