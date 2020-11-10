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
using CCL.iStomaLab;
using CCL.UI;
using BLL.iStomaLab.Referinta;

namespace iStomaLab.Setari.Lucrari
{
    public partial class ControlDetaliuLucrare : UserControlPersonalizat
    {

        #region Declaratii generale

        private BListaPreturiStandard lPretLucrare = null;
        private BCategorii lCategorie = null;
        private BColectieEtape lColectieEtape = new BColectieEtape();
        private BColectieLucrariEtape lColectieLucrariEtape = new BColectieLucrariEtape();

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colDenumire,
            colDurataMinute
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlDetaliuLucrare()
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
            this.lblCautaCategorieLucrare.DeschideEcranCautare += LblCautaLucrare_DeschideEcranCautare;
            this.lblCautaSubcategorieLucrare.DeschideEcranCautare += LblCautaLucrare_DeschideEcranCautare;
            this.lblCautaCategorieLucrare.CerereUpdate += LblCautaLucrare_CerereUpdate;
            this.lblCautaSubcategorieLucrare.CerereUpdate += LblCautaSubcategorieLucrare_CerereUpdate;
            this.chkLucrareRon.CheckedChanged += ChkLucrareRon_CheckedChanged;
            this.chkLucrareEuro.CheckedChanged += ChkLucrareEuro_CheckedChanged;
            this.btnAdaugaEtapa.Click += BtnAdaugaEtapa_Click;
            this.dgvListaEtapaAdaugate.StergereLinie += DgvListaEtapaAdaugate_StergereLinie;
        }

        private void initTextML()
        {
            this.lblDenumireLucrare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire);
            this.lblPrescurtareLucrare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Prescurtare);
            this.lblCodLucrare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Cod);
            this.lblCategorieLucrare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Categorie);
            this.lblValoareLucrare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Valoare);
            this.chkLucrareRon.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.RON);
            this.chkLucrareEuro.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.EUR);
            this.lblTermenMediuLucrare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TermenMediu);
            this.lblZileLucrare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Zile);
            this.lblSubcategorieLucrare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Subcategorie);
            this.lblAdaugaEtapa.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.AdaugaEtapa);
        }

        public void Initializeaza(BListaPreturiStandard pPretLucrare)
        {
            base.InitializeazaVariabileleGenerale();

            this.lPretLucrare = pPretLucrare;
            incepeIncarcarea();

            if (this.lPretLucrare == null)
            {
                this.txtDenumireLucrare.Goleste();
                this.txtPrescurtareLucrare.Goleste();
                this.txtCodLucrare.Goleste();
                this.lblCautaCategorieLucrare.Goleste();
                this.txtValoareLucrare.Goleste();
                this.chkLucrareEuro.Checked = false;
                this.chkLucrareRon.Checked = false;
                this.txtTermenMediuLucrare.Goleste();
                this.lblCautaSubcategorieLucrare.Goleste();
            }
            else
            {
                this.lColectieLucrariEtape = BLucrariEtape.GetListByParamIdLucrare(this.lPretLucrare.Id, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);
                FormListaCategorii._SCategorie = BCategorii.getCategorieById(this.lPretLucrare.IdCategorie, null);
                this.txtDenumireLucrare.Text = this.lPretLucrare.Denumire;
                this.txtPrescurtareLucrare.Text = this.lPretLucrare.DenumirePrescurtata;
                this.txtCodLucrare.Text = this.lPretLucrare.CodIntern;
                this.lblCautaCategorieLucrare.Text = BListaPreturiStandard.getById(BListaPreturiStandard.getByIdCategorie(this.lPretLucrare.IdCategorie, null), null);
                this.lblCautaSubcategorieLucrare.Text = BListaPreturiStandard.getById(this.lPretLucrare.IdCategorie, null);
                if (this.lPretLucrare.ValoareEUR != 0)
                {
                    this.chkLucrareEuro.Checked = true;
                    this.txtValoareLucrare.Text = lPretLucrare.ValoareEUR.ToString();
                }
                else
                {
                    this.chkLucrareRon.Checked = true;
                    this.txtValoareLucrare.Text = lPretLucrare.ValoareRON.ToString();
                }
                this.txtTermenMediuLucrare.Text = this.lPretLucrare.TermenMediuZile.ToString();
            }

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void DgvListaEtapaAdaugate_StergereLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BEtape etapaSelectata = this.dgvListaEtapaAdaugate.Rows[pIndexRand].Tag as BEtape;

                if (etapaSelectata != null)
                {
                    this.lColectieEtape.Remove(etapaSelectata);
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

        private void BtnAdaugaEtapa_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (SalveazaNull())
                {
                    if (FormListaEtape.Afiseaza(this.GetFormParinte()))
                    {
                        this.lColectieEtape = FormListaEtape._SColectieEtape;
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

        private void ChkLucrareEuro_CheckedChanged(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.chkLucrareRon.Checked = !chkLucrareEuro.Checked;
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

        private void ChkLucrareRon_CheckedChanged(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.chkLucrareEuro.Checked = !chkLucrareRon.Checked;
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

        private void LblCautaSubcategorieLucrare_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                FormListaCategorii._SCategorie = (BCategorii)this.lblCautaCategorieLucrare.Tag;
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

        private void LblCautaLucrare_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                FormListaCategorii._SCategorie = null;
                this.lblCautaSubcategorieLucrare.Goleste();
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

        private void LblCautaLucrare_DeschideEcranCautare(Control psender, object pxObiectExistent)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                FormListaCategorii.Afiseaza(this.GetFormParinte());
                if (FormListaCategorii._SCategorie != null)
                {
                    this.lCategorie = FormListaCategorii._SCategorie;
                    if (string.IsNullOrEmpty(this.lblCautaCategorieLucrare.Text) || this.lblCautaCategorieLucrare.Text.Equals("..."))
                    {
                        this.lblCautaCategorieLucrare.Tag = FormListaCategorii._SCategorie;
                        this.lblCautaCategorieLucrare.Text = this.lCategorie.Denumire;
                    }
                    else
                    {
                        this.lblCautaSubcategorieLucrare.Text = this.lCategorie.Denumire;
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

        #region Metode DGV

        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaEtapaAdaugate.IncepeConstructieColoane();

            this.dgvListaEtapaAdaugate.AdaugaColoanaText(EnumColoaneDGV.colDenumire.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaEtapaAdaugate.AdaugaColoanaText(EnumColoaneDGV.colDurataMinute.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Durata), 80, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaEtapaAdaugate.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvListaEtapaAdaugate.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaEtapaAdaugate.IncepeContructieRanduri();

            if (this.lColectieLucrariEtape != null)
            {
                foreach (var elem in this.lColectieLucrariEtape)
                {
                    incarcaRand(this.dgvListaEtapaAdaugate.Rows[this.dgvListaEtapaAdaugate.Rows.Add()], elem, BEtape.GetEtapaById(elem.IdEtapa, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null));
                }
            }

            if (this.lColectieEtape != null)
            {
                var listaElem = this.lColectieEtape;

                foreach (var elem in listaElem)
                {
                    incarcaRand(this.dgvListaEtapaAdaugate.Rows[this.dgvListaEtapaAdaugate.Rows.Add()], elem);
                }
            }

            this.dgvListaEtapaAdaugate.FinalizeazaContructieRanduri();
        }

        private void incarcaRand(DataGridViewRow pRand, BEtape pEtapa)
        {
            pRand.Tag = pEtapa;

            pRand.Cells[EnumColoaneDGV.colDenumire.ToString()].Value = pEtapa.Denumire;
            pRand.Cells[EnumColoaneDGV.colDurataMinute.ToString()].Value = pEtapa.DurataMedieMinute;
            DataGridViewPersonalizat.InitCelulaStergere(pRand);
        }

        private void incarcaRand(DataGridViewRow pRand, BLucrariEtape pElem, BEtape pEtapa)
        {
            pRand.Tag = pEtapa;

            pRand.Cells[EnumColoaneDGV.colDenumire.ToString()].Value = pEtapa.getNumeEtapa(pElem.IdEtapa, null);
            pRand.Cells[EnumColoaneDGV.colDurataMinute.ToString()].Value = pEtapa.DurataMedieMinute;
            DataGridViewPersonalizat.InitCelulaStergere(pRand);
        }

        #endregion

        private double getValoareRon()
        {
            if (this.chkLucrareRon.Checked && !this.chkLucrareEuro.Checked)
            {
                return Double.Parse(this.txtValoareLucrare.Text);
            }
            return 0;
        }

        private double getValoareEuro()
        {
            if (!this.chkLucrareRon.Checked && this.chkLucrareEuro.Checked)
            {
                return Double.Parse(this.txtValoareLucrare.Text);
            }
            return 0;
        }

        private int getIdCategorie()
        {
            int idCategorie = 0;
            if (string.IsNullOrEmpty(this.lblCategorieLucrare.Text) && string.IsNullOrEmpty(this.lblCautaSubcategorieLucrare.Text))
            {
                idCategorie = 0;
            }
            if (this.lCategorie != null)
            {
                idCategorie = this.lCategorie.Id;
            }
            return idCategorie;
        }

        private void seteazaAlerta()
        {
            IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.txtDenumireLucrare, this.lblDenumireLucrare);
            seteazaFocus();
        }

        private void seteazaFocus()
        {
            if (string.IsNullOrEmpty(this.txtDenumireLucrare.Text))
                this.txtDenumireLucrare.Focus();
        }

        #endregion

        #region Metode publice

        private bool SalveazaNull()
        {
            bool esteValid = BListaPreturiStandard.SuntInformatiileNecesareCoerente(this.txtDenumireLucrare.Text);

            if (this.lPretLucrare == null)
            {
                if (esteValid)
                {
                    int id = BListaPreturiStandard.Add(this.txtDenumireLucrare.Text, this.txtPrescurtareLucrare.Text, this.txtCodLucrare.Text, CUtil.GetTextInt32(this.txtTermenMediuLucrare.Text), getIdCategorie(), getValoareRon(), getValoareEuro(), null);
                    this.lPretLucrare = BListaPreturiStandard.getLucrareById(id, null);
                }
                else
                {
                    seteazaAlerta();
                }
            }
            else
                return true;

            return esteValid;
        }

        internal bool Salveaza()
        {
            bool esteValid = BListaPreturiStandard.SuntInformatiileNecesareCoerente(this.txtDenumireLucrare.Text);
            if (this.lPretLucrare == null)
            {
                if (esteValid)
                {
                    int id = BListaPreturiStandard.Add(this.txtDenumireLucrare.Text, this.txtPrescurtareLucrare.Text, this.txtCodLucrare.Text, CUtil.GetTextInt32(this.txtTermenMediuLucrare.Text), getIdCategorie(), getValoareRon(), getValoareEuro(), null);
                    this.lPretLucrare = BListaPreturiStandard.getLucrareById(id, null);
                }
                else
                {
                    seteazaAlerta();
                }
            }
            else
            {
                this.lPretLucrare.Denumire = this.txtDenumireLucrare.Text;
                this.lPretLucrare.DenumirePrescurtata = this.txtPrescurtareLucrare.Text;
                this.lPretLucrare.CodIntern = this.txtCodLucrare.Text;
                this.lPretLucrare.IdCategorie = getIdCategorie();
                if (this.lPretLucrare.ValoareRON != 0)
                {
                    this.lPretLucrare.ValoareRON = Double.Parse(this.txtValoareLucrare.Text);
                }
                else
                {
                    this.lPretLucrare.ValoareEUR = Double.Parse(this.txtValoareLucrare.Text);
                }
                this.lPretLucrare.TermenMediuZile = CUtil.GetTextInt32(this.txtTermenMediuLucrare.Text);
                if (esteValid)
                {
                    this.lPretLucrare.UpdateAll();
                    if (this.dgvListaEtapaAdaugate.RowCount > 0)
                        salveazaEtape(this.lPretLucrare.Id);
                }
                else
                {
                    seteazaAlerta();
                }
            }

            return esteValid;
        }

        private void salveazaEtape(int pIdLucrare)
        {
            if (this.lColectieEtape.Count != 0)
            {
                foreach (var etapa in this.lColectieEtape)
                {
                    var listaEtapeExistente = BLucrariEtape.GetListByParamIdLucrareEtapa(pIdLucrare, etapa.Id, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);
                    if (!listaEtapeExistente.Contains(etapa.Id))
                    {
                        BLucrariEtape.Add(pIdLucrare, etapa.Id, 1, etapa.DurataMedieMinute, null);
                    }
                }
            }
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
            this.txtDenumireLucrare.AllowModification(this.lEcranInModificare);
            this.txtPrescurtareLucrare.AllowModification(this.lEcranInModificare);
            this.txtCodLucrare.AllowModification(this.lEcranInModificare);
            this.lblCautaCategorieLucrare.AllowModification(this.lEcranInModificare);
            this.txtValoareLucrare.AllowModification(this.lEcranInModificare);
            this.chkLucrareRon.AllowModification(this.lEcranInModificare);
            this.chkLucrareEuro.AllowModification(this.lEcranInModificare);
            this.txtTermenMediuLucrare.AllowModification(this.lEcranInModificare);
        }

        #endregion


    }
}
