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

namespace iStomaLab.Setari.Liste.Regiuni
{
    public partial class ControlDetaliuListaRegiuni : UserControlPersonalizat
    {

        #region Declaratii generale


        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colRegiune,
            colAbreviere,
            colPrefixTelefonic
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlDetaliuListaRegiuni()
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
            this.btnAdaugareRegiune.Click += BtnAdaugareRegiune_Click;
            this.txtCautaRegiune.CerereUpdate += TxtCautaRegiune_CerereUpdate;
            this.txtCautaTara.CerereUpdate += TxtCautaTara_CerereUpdate;
            this.dgvListaRegiuni.StergereLinie += DgvListaRegiuni_StergereLinie;
            this.dgvListaRegiuni.EditareLinie += DgvListaRegiuni_EditareLinie;
        }
        
        private void initTextML()
        {
            this.lblRegiune.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Regiune);
            this.lblTara.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tara);
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.txtCautaRegiune.Goleste();
            this.txtCautaTara.Goleste();

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void DgvListaRegiuni_EditareLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BRegiuni regiuneDeModificat = this.dgvListaRegiuni.Rows[pIndexRand].Tag as BRegiuni;

                if (regiuneDeModificat != null)
                {
                    if(FormAdaugareRegiune.Afiseaza(this.GetFormParinte(), regiuneDeModificat))
                    {
                        incarcaRand(this.dgvListaRegiuni.Rows[pIndexRand], regiuneDeModificat);
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

        private void DgvListaRegiuni_StergereLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BRegiuni regiuneDeSters = this.dgvListaRegiuni.Rows[pIndexRand].Tag as BRegiuni;

                if (regiuneDeSters != null)
                {
                    if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmareInchidere), regiuneDeSters.Nume))
                    {
                        regiuneDeSters.Close(true, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Inchidere), null);
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

        private void TxtCautaTara_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvListaRegiuni.FiltreazaDupaText(this.txtCautaTara.Text);
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

        private void TxtCautaRegiune_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvListaRegiuni.FiltreazaDupaText(this.txtCautaRegiune.Text);
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

        private void BtnAdaugareRegiune_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (Setari.Liste.Regiuni.FormAdaugareRegiune.Afiseaza(this.GetFormParinte(),null))
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
            this.dgvListaRegiuni.IncepeConstructieColoane();

            this.dgvListaRegiuni.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvListaRegiuni.AdaugaColoanaText(EnumColoaneDGV.colRegiune.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Regiune), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaRegiuni.AdaugaColoanaText(EnumColoaneDGV.colAbreviere.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Abreviere), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaRegiuni.AdaugaColoanaText(EnumColoaneDGV.colPrefixTelefonic.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PrefixTelefonic), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaRegiuni.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvListaRegiuni.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaRegiuni.IncepeContructieRanduri();

            var listaElem = BRegiuni.GetListByParam(0, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

            foreach (var elem in listaElem)
            {
                incarcaRand(this.dgvListaRegiuni.Rows[this.dgvListaRegiuni.Rows.Add()], elem);
            }

            this.dgvListaRegiuni.FinalizeazaContructieRanduri();

            this.lblTotalRegiuni.Text = "Total regiuni: " + this.dgvListaRegiuni.RowCount.ToString();
        }

        private void incarcaRand(DataGridViewRow pRand, BRegiuni pElem)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);
            pRand.Cells[EnumColoaneDGV.colRegiune.ToString()].Value = pElem.Nume;
            pRand.Cells[EnumColoaneDGV.colAbreviere.ToString()].Value = pElem.Abreviere;
            pRand.Cells[EnumColoaneDGV.colPrefixTelefonic.ToString()].Value = pElem.PrefixTelefon;
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
