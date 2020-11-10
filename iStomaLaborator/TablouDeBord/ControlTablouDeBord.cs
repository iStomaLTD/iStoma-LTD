using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.iStomaLab;
using CDL.iStomaLab;
using CCL.UI;
using BLL.iStomaLab.Clienti;
using DAL.iStomaLab.Clienti;
using BLL.iStomaLab.Reprezentanti;

namespace iStomaLab.TablouDeBord
{
    public partial class ControlTablouDeBord : Generale.UserControlPersonalizat
    {

        #region Declaratii generale


        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colClient,
            colReprezentant,
            colDataPrimire,
            colDataLaGata,
            colObservatii
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlTablouDeBord()
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
            this.btnAdaugareComanda.Click += BtnAdaugareComanda_Click;
            this.dgvListaComenzi.EditareLinie += DgvListaComenzi_EditareLinie;
            this.ctrlPerioada.PerioadaSchimbata += CtrlPerioada_PerioadaSchimbata;
        }
        
        private void initTextML()
        {
            this.lblComenziInLucru.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ComenziInLucru);
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.ctrlPerioada.Initializeaza(CDefinitiiComune.EnumTipPerioada.Saptamana, DateTime.Today);

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

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

        private void DgvListaComenzi_EditareLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BClientiComenzi comandaDeModificat = this.dgvListaComenzi.Rows[pIndexRand].Tag as BClientiComenzi;
                if(comandaDeModificat != null)
                {
                    if(TablouDeBord.Clienti.FormDetaliuComanda.Afiseaza(this.GetFormParinte(), comandaDeModificat, BClienti.getClient(comandaDeModificat.IdClient, null)))
                    {
                        incarcaRand(this.dgvListaComenzi.Rows[pIndexRand], comandaDeModificat);
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

        private void BtnAdaugareComanda_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();
                
                if(Clienti.FormDetaliuComanda.Afiseaza(this.GetFormParinte(), null, null))
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
            this.dgvListaComenzi.IncepeConstructieColoane();

            this.dgvListaComenzi.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Editare);
            
            this.dgvListaComenzi.AdaugaColoanaText(EnumColoaneDGV.colClient.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Client), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaComenzi.AdaugaColoanaText(EnumColoaneDGV.colReprezentant.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Reprezentant), 150, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaComenzi.AdaugaColoanaData(EnumColoaneDGV.colDataPrimire.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataPrimire), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);

            this.dgvListaComenzi.AdaugaColoanaData(EnumColoaneDGV.colDataLaGata.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataLaGata), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);

            this.dgvListaComenzi.AdaugaColoanaText(EnumColoaneDGV.colObservatii.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaComenzi.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaComenzi.IncepeContructieRanduri();

            var listaElem = BClientiComenzi.GetListByParamIntrePerioada(this.ctrlPerioada.DataInceput, this.ctrlPerioada.DataSfarsit, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

            foreach (var elem in listaElem)
            {
                incarcaRand(this.dgvListaComenzi.Rows[this.dgvListaComenzi.Rows.Add()], elem);
            }

            this.dgvListaComenzi.FinalizeazaContructieRanduri();
        }

        private void incarcaRand(DataGridViewRow pRand, BClientiComenzi pElem)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);
            pRand.Cells[EnumColoaneDGV.colClient.ToString()].Value = BClienti.getClient(pElem.IdClient, null).Denumire;
            pRand.Cells[EnumColoaneDGV.colReprezentant.ToString()].Value = BClientiReprezentanti.getNumeCompletReprezentant(BClientiReprezentanti.getReprezentant(pElem.IdReprezentantClient, null));
            pRand.Cells[EnumColoaneDGV.colDataPrimire.ToString()].Value = pElem.DataPrimire;
            pRand.Cells[EnumColoaneDGV.colDataLaGata.ToString()].Value = pElem.DataLaGata;
            pRand.Cells[EnumColoaneDGV.colObservatii.ToString()].Value = pElem.Observatii;
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
