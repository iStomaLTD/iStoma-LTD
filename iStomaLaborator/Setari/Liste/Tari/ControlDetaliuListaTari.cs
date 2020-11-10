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

namespace iStomaLab.Setari.Liste.Tari
{
    public partial class ControlDetaliuListaTari : UserControlPersonalizat
    {

        #region Declaratii generale


        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colTara,
            colNumeOficial,
            colAbreviere,
            colPrefixTelefonic,
            colCetatenie
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlDetaliuListaTari()
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
            this.btnAdaugaTara.Click += BtnAdaugaTara_Click;
            this.txtCautaTara.CerereUpdate += TxtCautaTara_CerereUpdate;
            this.dgvListaTari.EditareLinie += DgvListaTari_EditareLinie;
        }
        
        private void initTextML()
        {
            this.lblTara.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tara);
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.txtCautaTara.Goleste();

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void TxtCautaTara_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvListaTari.FiltreazaDupaText(this.txtCautaTara.Text);
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

        private void BtnAdaugaTara_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (Setari.Liste.Tari.FormAdaugareTara.Afiseaza(this.GetFormParinte(),null))
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

        private void DgvListaTari_EditareLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BTari taraDeModificat = this.dgvListaTari.Rows[pIndexRand].Tag as BTari;

                if (taraDeModificat != null)
                {
                    if (FormAdaugareTara.Afiseaza(this.GetFormParinte(), taraDeModificat))
                    {
                        incarcaRand(this.dgvListaTari.Rows[pIndexRand], taraDeModificat);
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

        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaTari.IncepeConstructieColoane();

            this.dgvListaTari.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvListaTari.AdaugaColoanaText(EnumColoaneDGV.colTara.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tara), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaTari.AdaugaColoanaText(EnumColoaneDGV.colNumeOficial.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NumeOficial), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaTari.AdaugaColoanaText(EnumColoaneDGV.colAbreviere.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Abreviere), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaTari.AdaugaColoanaText(EnumColoaneDGV.colPrefixTelefonic.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PrefixTelefonic), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaTari.AdaugaColoanaText(EnumColoaneDGV.colCetatenie.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Cetatenie), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaTari.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaTari.IncepeContructieRanduri();

            var listaElem = BTari.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

            foreach (var elem in listaElem)
            {
                incarcaRand(this.dgvListaTari.Rows[this.dgvListaTari.Rows.Add()], elem);
            }

            this.dgvListaTari.FinalizeazaContructieRanduri();

            this.lblTotalTari.Text = "Total tari: " + this.dgvListaTari.RowCount.ToString();
        }

        private void incarcaRand(DataGridViewRow pRand, BTari pElem)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);
            pRand.Cells[EnumColoaneDGV.colTara.ToString()].Value = pElem.NumeScurt;
            pRand.Cells[EnumColoaneDGV.colNumeOficial.ToString()].Value = pElem.NumeOficial;
            pRand.Cells[EnumColoaneDGV.colPrefixTelefonic.ToString()].Value = pElem.PrefixTelefonic;
            pRand.Cells[EnumColoaneDGV.colAbreviere.ToString()].Value = pElem.Abreviere;
            pRand.Cells[EnumColoaneDGV.colCetatenie.ToString()].Value = pElem.Cetatenie;
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
