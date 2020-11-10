using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iStomaLab.Generale;
using CCL.UI;
using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;
using CCL.iStomaLab;

namespace iStomaLab.Caramizi
{
    public partial class ControlRezumatDGV : UserControlPersonalizat
    {

        #region Declaratii generale

        public event DeschideObiectulDelegate DeschideObiectul;
        public delegate void DeschideObiectulDelegate(Control pSender, int pIdObiect, int pIndexRand);
        private Dictionary<int, string> lDictIdDenumire = null;
        private Dictionary<int, int> lDictIdValoare = null;
        private string lSemnificatie = string.Empty;
        private bool lAfiseazaDetalii = false;

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGVRezumat
        {
            colNrElemente,
            colDetalii,
        }


        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlRezumatDGV()
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
            this.dgvLista.CellClick += DgvLista_CellClick;
        }

        private void initTextML()
        {

        }

        public void Initializeaza(Dictionary<int, string> pDictIdDenumire, Dictionary<int, int> pDictIdValoare, string pSemnificatie, bool pAfiseazaDetalii)
        {
            base.InitializeazaVariabileleGenerale();

            //Salvam in local valorile primite

            incepeIncarcarea();

            this.lblTitlu.Text = pSemnificatie;
            this.lDictIdDenumire = pDictIdDenumire;
            this.lDictIdValoare = pDictIdValoare;
            this.lSemnificatie = pSemnificatie;
            this.lAfiseazaDetalii = pAfiseazaDetalii;

            //Incarcam DGV
            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void DgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.lSeIncarca || e.RowIndex < 0) return;
            try
            {
                incepeIncarcarea();

                string denumireColoanaSelectata = this.dgvLista.Columns[e.ColumnIndex].Name;

                if (this.dgvLista.SelectedRow != null)
                {
                    if (denumireColoanaSelectata.Equals(EnumColoaneDGVRezumat.colDetalii.ToString()))
                    {
                        solicitaDeschidereObiect(CUtil.GetAsInt32(this.dgvLista.SelectedRow.Tag), e.RowIndex);
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

        /// <summary>
        /// Se apeleaza la click pe butonul de detaliu din DGV
        /// </summary>
        /// <param name="pIdObiect"></param>
        /// <param name="pIndexRand"></param>
        private void solicitaDeschidereObiect(int pIdObiect, int pIndexRand)
        {
            if (this.DeschideObiectul != null)
                this.DeschideObiectul(this, pIdObiect, pIndexRand);

        }
        private void ConstruiesteColoaneDGV()
        {
            this.dgvLista.IncepeConstructieColoane();

            this.dgvLista.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.Denumire);
            if (this.lAfiseazaDetalii)
                this.dgvLista.AdaugaColoanaButonClasic(EnumColoaneDGVRezumat.colDetalii.ToString(), string.Empty, string.Empty, 36, false);

            this.dgvLista.AdaugaColoanaNumerica(EnumColoaneDGVRezumat.colNrElemente.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrElemente), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {

            this.dgvLista.IncepeContructieRanduri();

            foreach (var item in this.lDictIdDenumire)
            {
                incarcaRandDGV(this.dgvLista.AdaugaRandNou(), item.Key);
            }

            this.dgvLista.FinalizeazaContructieRanduri();
        }
        private void incarcaRandDGV(DataGridViewRow pRand, int pId)
        {
            pRand.Tag = pId;

            this.dgvLista.InitCelulaDenumire(pRand, this.lDictIdDenumire[pId]);

            if (this.lAfiseazaDetalii)
                DataGridViewPersonalizat.InitCelulaDeschideClasic(pRand, EnumColoaneDGVRezumat.colDetalii.ToString());

            DataGridViewPersonalizat.InitCelulaValoareNumerica(pRand, EnumColoaneDGVRezumat.colNrElemente.ToString(), this.lDictIdValoare[pId]);

            this.dgvLista.FinalizeazaContructieRanduri();
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
