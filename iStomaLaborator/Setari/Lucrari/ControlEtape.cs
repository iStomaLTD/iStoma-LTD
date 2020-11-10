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
using BLL.iStomaLab.Preturi;
using BLL.iStomaLab;
using CCL.UI;

namespace iStomaLab.Setari.Lucrari
{
    public partial class ControlEtape : UserControlPersonalizat
    {

        #region Declaratii generale
        

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colDenumire,
            colDurata
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlEtape()
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
            this.btnAdaugareEtapa.Click += BtnAdaugareEtapa_Click;
            this.txtCautaEtapa.CerereUpdate += TxtCautaEtapa_CerereUpdate;
            this.dgvListaEtape.StergereLinie += DgvListaEtape_StergereLinie;
            this.dgvListaEtape.EditareLinie += DgvListaEtape_EditareLinie;
        }
        
        private void initTextML()
        {
            this.lblEtape.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Etape);
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.txtCautaEtapa.Goleste();
            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void DgvListaEtape_EditareLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BEtape etapaDeModificat = this.dgvListaEtape.Rows[pIndexRand].Tag as BEtape;
                if (etapaDeModificat != null)
                {
                    if (FormAdaugareEtapa.Afiseaza(this.GetFormParinte(), etapaDeModificat))
                        incarcaRand(this.dgvListaEtape.Rows[pIndexRand], etapaDeModificat);
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

        private void TxtCautaEtapa_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvListaEtape.FiltreazaDupaText(this.txtCautaEtapa.Text);
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

        private void BtnAdaugareEtapa_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();
                if (FormAdaugareEtapa.Afiseaza(this.GetFormParinte(), null))
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

        private void DgvListaEtape_StergereLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BEtape etapaDeSters = this.dgvListaEtape.Rows[pIndexRand].Tag as BEtape;

                if (etapaDeSters != null)
                {
                    if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), etapaDeSters.Denumire))
                    {
                        etapaDeSters.Close(true, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stergere), null);
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

        #endregion

        #region Metode private

        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaEtape.IncepeConstructieColoane();

            this.dgvListaEtape.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvListaEtape.AdaugaColoanaText(EnumColoaneDGV.colDenumire.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire), 100, true, DataGridViewColumnSortMode.Automatic);
            
            this.dgvListaEtape.AdaugaColoanaNumerica(EnumColoaneDGV.colDurata.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DurataMinute), 60, DataGridViewColumnSortMode.Automatic);
            
            this.dgvListaEtape.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvListaEtape.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaEtape.IncepeContructieRanduri();

            var listaElem = BEtape.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

            foreach (var elem in listaElem)
            {
                incarcaRand(this.dgvListaEtape.Rows[this.dgvListaEtape.Rows.Add()], elem);
            }

            this.dgvListaEtape.FinalizeazaContructieRanduri();

            int totalEtape = listaElem.Count;

            this.lblTotalEtape.Text = totalEtape.ToString() + " etape";
        }

        private void incarcaRand(DataGridViewRow pRand, BEtape pElem)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);
            pRand.Cells[EnumColoaneDGV.colDenumire.ToString()].Value = pElem.Denumire;
            pRand.Cells[EnumColoaneDGV.colDurata.ToString()].Value = pElem.DurataMedieMinute;
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
