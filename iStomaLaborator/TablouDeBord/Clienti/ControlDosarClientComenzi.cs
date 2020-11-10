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
using DAL.iStomaLab.Clienti;
using BLL.iStomaLab.Reprezentanti;
using CDL.iStomaLab;
using CCL.iStomaLab;
using BLL.iStomaLab.Preturi;

namespace iStomaLab.TablouDeBord.Clienti
{
    public partial class ControlDosarClientComenzi : UserControlPersonalizat
    {

        #region Declaratii generale

        private BClienti lClient = null;
        private BClientiComenzi lComanda = null;

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colNumeReprezentant,
            colNumePacient,
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
            this.btnAdaugaComandaTrecuta.Click += BtnAdaugaComanda_Click;
            this.dgvComenziInLucru.EditareLinie += DgvComenzi_EditareLinie;
            this.dgvComenziTrecute.EditareLinie += DgvComenzi_EditareLinie;
            this.dgvComenziInLucru.StergereLinie += DgvComenzi_StergereLinie;
            this.dgvComenziTrecute.StergereLinie += DgvComenzi_StergereLinie;

            this.SizeChanged += ControlDosarClientComenzi_SizeChanged;
        }

        private void ControlDosarClientComenzi_SizeChanged(object sender, EventArgs e)
        {
            //Se modifica dimensiunea ecranului => recalculam si repozitionam panel-urile
            int inaltime = this.Height / 2;
            this.panelComenziInLucru.Height = inaltime - 5;
            this.panelComenziTrecute.Location = new Point(this.panelComenziTrecute.Location.X, inaltime + 5);
            this.panelComenziTrecute.Height = inaltime - 7;
        }

        private void initTextML()
        {

        }

        public void Initializeaza(BClienti pClient)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.lClient = pClient;

            ConstruiesteColoaneDGVComenziInLucru();
            ConstruiesteColoaneDGVComenziTrecute();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void BtnAdaugaComanda_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (FormDetaliuComanda.Afiseaza(this.GetFormParinte(), null, this.lClient))
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

                BClientiComenzi comandaDeModificat = (pDGVSender as DataGridViewPersonalizat).Rows[pIndexRand].Tag as BClientiComenzi;

                if (comandaDeModificat != null)
                {
                    FormListaLucrari._SLucrare = BListaPreturiStandard.getLucrareById(comandaDeModificat.IdLucrare, null);

                    if (FormDetaliuComanda.Afiseaza(this.GetFormParinte(), comandaDeModificat, this.lClient))
                    {
                        incarcaRand(this.dgvComenziInLucru.Rows[pIndexRand], comandaDeModificat);
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

                BClientiComenzi comandaDeSters = (pDGVSender as DataGridViewPersonalizat).Rows[pIndexRand].Tag as BClientiComenzi;

                if (comandaDeSters != null)
                {
                    if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), null)) ;
                    {
                        comandaDeSters.Close(true, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Inchidere), null);
                    }
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

        private void ConstruiesteColoaneDGVComenziInLucru()
        {
            this.dgvComenziInLucru.IncepeConstructieColoane();

            this.dgvComenziInLucru.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvComenziInLucru.AdaugaColoanaText(EnumColoaneDGV.colNumeReprezentant.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Reprezentant), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvComenziInLucru.AdaugaColoanaText(EnumColoaneDGV.colNumePacient.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pacient), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvComenziInLucru.AdaugaColoanaData(EnumColoaneDGV.colDataPrimire.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataPrimire), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);

            this.dgvComenziInLucru.AdaugaColoanaData(EnumColoaneDGV.colDataLaGata.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataLaGata), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);

            this.dgvComenziInLucru.AdaugaColoanaText(EnumColoaneDGV.colObservatii.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvComenziInLucru.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvComenziInLucru.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteColoaneDGVComenziTrecute()
        {
            this.dgvComenziTrecute.IncepeConstructieColoane();

            this.dgvComenziTrecute.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvComenziTrecute.AdaugaColoanaText(EnumColoaneDGV.colNumeReprezentant.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Reprezentant), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvComenziTrecute.AdaugaColoanaText(EnumColoaneDGV.colNumePacient.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pacient), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvComenziTrecute.AdaugaColoanaData(EnumColoaneDGV.colDataPrimire.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataPrimire), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);

            this.dgvComenziTrecute.AdaugaColoanaData(EnumColoaneDGV.colDataLaGata.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataLaGata), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);

            this.dgvComenziTrecute.AdaugaColoanaText(EnumColoaneDGV.colObservatii.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvComenziTrecute.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvComenziTrecute.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvComenziInLucru.IncepeContructieRanduri();
            this.dgvComenziTrecute.IncepeContructieRanduri();

            var listaElemViitoare = BClientiComenzi.GetListComenziViitoareByParam(this.lClient.Id, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

            var listaElemTrecute = BClientiComenzi.GetListComenziTrecuteByParam(this.lClient.Id, CDefinitiiComune.EnumStare.Activa, null);

            foreach (var elem in listaElemViitoare)
            {
                incarcaRand(this.dgvComenziInLucru.Rows[this.dgvComenziInLucru.Rows.Add()], elem);
            }

            foreach (var elem in listaElemTrecute)
            {
                incarcaRand(this.dgvComenziTrecute.Rows[this.dgvComenziTrecute.Rows.Add()], elem);
            }

            this.dgvComenziInLucru.FinalizeazaContructieRanduri();
            this.dgvComenziTrecute.FinalizeazaContructieRanduri();
        }

        private void incarcaRand(DataGridViewRow pRand, BClientiComenzi pElem)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);
            pRand.Cells[EnumColoaneDGV.colNumeReprezentant.ToString()].Value = BClientiReprezentanti.getReprezentant(pElem.IdReprezentantClient, null).Nume + " " + BClientiReprezentanti.getReprezentant(pElem.IdReprezentantClient, null).Prenume;
            pRand.Cells[EnumColoaneDGV.colNumePacient.ToString()].Value = pElem.NumePacient;
            if (CUtil.isNotNull(pElem.DataPrimire))
                pRand.Cells[EnumColoaneDGV.colDataPrimire.ToString()].Value = pElem.DataPrimire;
            if (CUtil.isNotNull(pElem.DataLaGata))
                pRand.Cells[EnumColoaneDGV.colDataLaGata.ToString()].Value = pElem.DataLaGata;
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
