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
using CDL.iStomaLab;
using CCL.iStomaLab;
using BLL.iStomaLab.Comune;

namespace iStomaLab.TablouDeBord.Clienti
{
    public partial class ControlDosarClientCabinete : UserControlPersonalizat
    {

        #region Declaratii generale

        private BClienti lClient = null;

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colDenumire,
            colAdresa,
            colUltimaComanda,
            colTotalComenzi
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlDosarClientCabinete()
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
            this.btnAdaugaCabinet.Click += BtnAdaugaCabinet_Click;
            this.dgvListaCabinete.EditareLinie += DgvListaCabinete_EditareLinie;
        }

        private void initTextML()
        {
            this.lblCabinete.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Cabinete);
        }

        public void Initializeaza(BClienti pClient)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.lClient = pClient;
            this.txtCautaCabinet.Goleste();

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void DgvListaCabinete_EditareLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BClientiCabinete cabinetDeModificat = this.dgvListaCabinete.Rows[pIndexRand].Tag as BClientiCabinete;

                if (cabinetDeModificat != null)
                {
                    if (FormDetaliuCabinet.Afiseaza(this.GetFormParinte(), this.lClient, cabinetDeModificat))
                    {
                        incarcaRand(this.dgvListaCabinete.Rows[pIndexRand], cabinetDeModificat, cabinetDeModificat.GetAdresa(null));
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

        private void BtnAdaugaCabinet_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                string denumire = CCL.UI.IHMUtile.GetTextSimpluUtilizator(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire), string.Empty, BClientiCabinete.StructCampuriTabela.DenumireMaxLength);

                if (!string.IsNullOrEmpty(denumire))
                {
                    BClientiCabinete cabinetNou = BClientiCabinete.Add(this.lClient.Id, denumire, null);

                    FormDetaliuCabinet.Afiseaza(this.GetFormParinte(), this.lClient, cabinetNou);
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
            this.dgvListaCabinete.IncepeConstructieColoane();

            this.dgvListaCabinete.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvListaCabinete.AdaugaColoanaText(EnumColoaneDGV.colDenumire.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaCabinete.AdaugaColoanaText(EnumColoaneDGV.colAdresa.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Adresa), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaCabinete.AdaugaColoanaData(EnumColoaneDGV.colUltimaComanda.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.UltimaComanda), 70, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);

            this.dgvListaCabinete.AdaugaColoanaNumerica(EnumColoaneDGV.colTotalComenzi.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TotalComenzi), 60, DataGridViewColumnSortMode.Automatic);

            this.dgvListaCabinete.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvListaCabinete.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaCabinete.IncepeContructieRanduri();

            var listaElem = BClientiCabinete.GetListByParamIdClient(this.lClient.Id, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

            var lstComenzi = BClientiComenzi.GetListByParamIdClient(this.lClient.Id, CDefinitiiComune.EnumStare.Activa, null);

            BColectieAdrese listaAdrese = BAdrese.getByListaId(listaElem.GetListaIdAdrese(), null);

            BColectieClientiComenzi listaComenzi = BClientiComenzi.getByListaId(lstComenzi.GetListaIdComenzi(), null);

            foreach (var elem in listaElem)
            {
                incarcaRand(this.dgvListaCabinete.Rows[this.dgvListaCabinete.Rows.Add()], elem, listaAdrese.GetById(elem.IdAdresa));
            }

            this.dgvListaCabinete.FinalizeazaContructieRanduri();

            this.lblNrCabinete.Text = "Total cabinete:" + this.dgvListaCabinete.RowCount.ToString();
        }

        private void incarcaRand(DataGridViewRow pRand, BClientiCabinete pElem, BAdrese pAdresa)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);
            pRand.Cells[EnumColoaneDGV.colDenumire.ToString()].Value = pElem.Denumire;
            pRand.Cells[EnumColoaneDGV.colAdresa.ToString()].Value = pAdresa.ToString();

            var lstComenziCabinet = BClientiComenzi.getById(this.lClient.Id, pElem.Id, null);
            if (lstComenziCabinet.Count != 0)
                pRand.Cells[EnumColoaneDGV.colUltimaComanda.ToString()].Value = lstComenziCabinet[lstComenziCabinet.Count - 1].DataPrimire;

            pRand.Cells[EnumColoaneDGV.colTotalComenzi.ToString()].Value = BClientiComenzi.getById(this.lClient.Id, pElem.Id, null).Count;
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
