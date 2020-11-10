using BLL.iStomaLab;
using BLL.iStomaLab.Preturi;
using BLL.iStomaLab.Referinta;
using CCL.iStomaLab;
using CCL.UI;
using iStomaLab.Generale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CDL.iStomaLab.CDefinitiiComune;

namespace iStomaLab.Setari.Lucrari
{
    public partial class FormDetaliuLucrare : FormPersonalizat
    {

        #region Declaratii generale

        private BListaPreturiStandard lLucrare = null;
        private BCategorii lCategorie = null;
        private BColectieEtape lColectieEtape = new BColectieEtape();
        private BColectieEtape lColectieEtapeTemp = new BColectieEtape();
        private BColectieLucrariEtape lColectieLucrariEtape = new BColectieLucrariEtape();
        private bool lSePoateModifica = false;

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

        private FormDetaliuLucrare(BListaPreturiStandard pLucrare)
        {
            this.DoubleBuffered = true;

            InitializeComponent();

            this.AcceptButton = this.ctrlValidareAnulareLucrare.ButonValidare;

            this.lLucrare = pLucrare;

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {

                adaugaHandlere();
                initTextML();

                this.CentratCuDeplasare();
            }
        }

        private void adaugaHandlere()
        {
            this.Load += _Load;
            this.ctrlValidareAnulareLucrare.Validare += CtrlValidareAnulareLucrare_Validare;
            this.FormClosed += FormDetaliuLucrare_FormClosed;

            this.lblCautaCategorieLucrare.DeschideEcranCautare += LblCautaCategorieLucrare_DeschideEcranCautare;
            this.lblCautaCategorieLucrare.CerereUpdate += LblCautaCategorieLucrare_CerereUpdate;

            this.lblCautaSubcategorieLucrare.DeschideEcranCautare += LblCautaSubCategorieLucrare_DeschideEcranCautare;
            this.lblCautaSubcategorieLucrare.CerereUpdate += LblCautaSubcategorieLucrare_CerereUpdate;

            this.btnAdaugaEtapa.Click += BtnAdaugaEtapa_Click;
            this.dgvListaEtapaAdaugate.StergereLinie += DgvListaEtapaAdaugate_StergereLinie;
        }

        private void initTextML()
        {
            this.Text = string.Empty;

            this.lblDenumireLucrare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire);
            this.lblPrescurtareLucrare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Prescurtare);
            this.lblCodLucrare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Cod);
            this.lblCategorieLucrare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Categorie);
            this.lblTermenMediuLucrare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TermenMediu);
            this.lblZileLucrare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.zile);
            this.lblSubcategorieLucrare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Subcategorie);
            this.lblAdaugaEtapa.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.AdaugaEtapa);
            this.lblPret.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pret);
        }

        void _Load(object sender, EventArgs e)
        {
            try
            {
                Initializeaza();
                AllowModification(true);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            if (this.lLucrare == null)
            {
                this.txtDenumireLucrare.Goleste();
                this.txtPrescurtareLucrare.Goleste();
                this.txtCodLucrare.Goleste();
                this.lblCautaCategorieLucrare.Goleste();
                this.ctrlValoareMonetara.Initializeaza(null);
                this.txtTermenMediuLucrare.Goleste();
                this.lblCautaSubcategorieLucrare.Goleste();
            }
            else
            {
                this.lColectieLucrariEtape = BLucrariEtape.GetListByParamIdLucrare(this.lLucrare.Id, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);
                foreach (var etapa in this.lColectieLucrariEtape)
                {
                    this.lColectieEtape.Adauga(BEtape.GetEtapaById(etapa.IdEtapa, EnumStare.Activa, null));
                }

                this.lColectieEtapeTemp = this.lColectieEtape;

                this.txtDenumireLucrare.Text = this.lLucrare.Denumire;
                this.txtPrescurtareLucrare.Text = this.lLucrare.DenumirePrescurtata;
                this.txtCodLucrare.Text = this.lLucrare.CodIntern;

                if (this.lLucrare.IdCategorie != 0)
                {
                    this.lCategorie = BCategorii.getCategorieById(this.lLucrare.IdCategorie, null);

                    this.lblCautaCategorieLucrare.ObiectAfisajCorespunzator = this.lCategorie;
                    this.lblCautaCategorieLucrare.Tag = this.lCategorie;

                    if (this.lCategorie.IdCategorie > 0)
                    {

                        BCategorii categ = BCategorii.getCategorieById(this.lCategorie.IdCategorie, null);
                        this.lblCautaCategorieLucrare.ObiectAfisajCorespunzator = categ;
                        this.lblCautaCategorieLucrare.Text = categ.Denumire;

                        this.lblCautaSubcategorieLucrare.ObiectAfisajCorespunzator = this.lCategorie;
                        this.lblCautaSubcategorieLucrare.Text = this.lCategorie.Denumire;
                    }
                    else
                    {
                        this.lblCautaCategorieLucrare.Text = this.lCategorie.Denumire;
                        this.lblCautaSubcategorieLucrare.Goleste();
                    }
                }

                if (this.lLucrare.ValoareEUR != 0)
                {
                    Tuple<double, EnumTipMoneda> tupleValoareMonetara = new Tuple<double, EnumTipMoneda>(this.lLucrare.ValoareEUR, EnumTipMoneda.Euro);
                    this.ctrlValoareMonetara.Initializeaza(tupleValoareMonetara);
                }
                else
                {
                    Tuple<double, EnumTipMoneda> tupleValoareMonetara = new Tuple<double, EnumTipMoneda>(this.lLucrare.ValoareRON, EnumTipMoneda.Lei);
                    this.ctrlValoareMonetara.Initializeaza(tupleValoareMonetara);
                }
                this.txtTermenMediuLucrare.Text = this.lLucrare.TermenMediuZile.ToString();
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
                    this.lSePoateModifica = true;
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

                //if (SalveazaNull())
                //{
                BEtape etapa = FormListaEtape.Afiseaza(this.GetFormParinte(), this.lColectieEtape);

                if (etapa != null)
                {
                    this.lSePoateModifica = true;
                    //this.lColectieEtape.Add(etapa);
                }
                ConstruiesteRanduriDGV();


                //{
                //    if (FormListaEtape._SEtapa != null)
                //    {
                //        
                //    }

                //    
                //}
                // }
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

                BCategorii categorie = (BCategorii)this.lblCautaCategorieLucrare.Tag;

                this.lCategorie = BCategorii.getCategorieById(categorie.IdCategorie, null);
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

        private void LblCautaCategorieLucrare_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.lCategorie = null;
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

        private void LblCautaSubCategorieLucrare_DeschideEcranCautare(Control psender, object pxObiectExistent)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (this.lblCautaCategorieLucrare.AreValoare())
                {
                    BCategorii categorie = FormListaCategorii.Afiseaza(this.GetFormParinte(), this.lblCautaCategorieLucrare.IdObiectCorespunzator);

                    if (categorie != null)
                    {
                        this.lCategorie = categorie;
                        this.lblCautaSubcategorieLucrare.ObiectAfisajCorespunzator = categorie;
                        this.lblCautaSubcategorieLucrare.Tag = categorie;
                        this.lblCautaSubcategorieLucrare.Text = categorie.Denumire;
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

        private void LblCautaCategorieLucrare_DeschideEcranCautare(Control psender, object pxObiectExistent)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BCategorii categorie = FormListaCategorii.Afiseaza(this.GetFormParinte(), 0);

                if (categorie != null)
                {
                    this.lCategorie = categorie;

                    if (this.lCategorie.IdCategorie == 0)
                    {
                        this.lblCautaCategorieLucrare.ObiectAfisajCorespunzator = this.lCategorie;
                        this.lblCautaCategorieLucrare.Tag = this.lCategorie;
                        this.lblCautaCategorieLucrare.Text = this.lCategorie.Denumire;
                        this.lblCautaSubcategorieLucrare.Text = string.Empty;
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

        private void FormDetaliuLucrare_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();


            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this, ex);
            }
            finally
            {
                finalizeazaIncarcarea();
            }

        }

        private void CtrlValidareAnulareLucrare_Validare(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (this.Salveaza())
                {
                    inchideEcranulOK();
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

        #endregion

        private bool Salveaza()
        {
            bool esteValid = BListaPreturiStandard.SuntInformatiileNecesareCoerente(this.txtDenumireLucrare.Text);
            if (this.lLucrare == null)
            {
                if (esteValid)
                {
                    int id = BListaPreturiStandard.Add(this.txtDenumireLucrare.Text, this.txtPrescurtareLucrare.Text, this.txtCodLucrare.Text, CUtil.GetTextInt32(this.txtTermenMediuLucrare.Text), getIdCategorie(), getValoareRon(), getValoareEuro(), null);
                    this.lLucrare = BListaPreturiStandard.getById(id, null);
                    salveazaEtape(this.lLucrare.Id);
                }
                else
                {
                    seteazaAlerta();
                }
            }
            else
            {
                this.lLucrare.Denumire = this.txtDenumireLucrare.Text;
                this.lLucrare.DenumirePrescurtata = this.txtPrescurtareLucrare.Text;
                this.lLucrare.CodIntern = this.txtCodLucrare.Text;
                this.lLucrare.IdCategorie = getIdCategorie();

                Tuple<double, EnumTipMoneda> tupleValoare = this.ctrlValoareMonetara.ValoareTuple;

                if (tupleValoare.Item2 == EnumTipMoneda.Lei)
                {
                    this.lLucrare.ValoareRON = tupleValoare.Item1;
                    this.lLucrare.ValoareEUR = 0;
                }
                else
                {
                    this.lLucrare.ValoareRON = 0;
                    this.lLucrare.ValoareEUR = tupleValoare.Item1;
                }
                this.lLucrare.TermenMediuZile = CUtil.GetTextInt32(this.txtTermenMediuLucrare.Text);
                if (esteValid)
                {
                    this.lLucrare.UpdateAll();
                    salveazaEtape(this.lLucrare.Id);
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
            List<int> listaEtapeExistente = BLucrariEtape.GetListIdEtapeByParamIdLucrare(pIdLucrare, EnumStare.Activa, null);

            if (this.lSePoateModifica)
            {
                foreach (var idEtapa in listaEtapeExistente)
                {
                    BLucrariEtape.getByIdLucrareEtapa(pIdLucrare, idEtapa, null).Close(true, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stergere), null);
                }

                foreach (var etapaCurenta in this.lColectieEtape)
                {
                    BLucrariEtape.Add(pIdLucrare, etapaCurenta.Id, 1, etapaCurenta.DurataMedieMinute, null);
                }
            }
        }

        private double getValoareRon()
        {
            Tuple<double, EnumTipMoneda> tupleValoare = this.ctrlValoareMonetara.ValoareTuple;

            if (tupleValoare.Item2 == EnumTipMoneda.Lei)
            {
                return tupleValoare.Item1;
            }
            return 0;
        }

        private double getValoareEuro()
        {
            Tuple<double, EnumTipMoneda> tupleValoare = this.ctrlValoareMonetara.ValoareTuple;

            if (tupleValoare.Item2 == EnumTipMoneda.Euro)
            {
                return tupleValoare.Item1;
            }
            return 0;
        }

        private int getIdCategorie()
        {
            int idCategorie = 0;
            if (this.lCategorie == null)
            {
                idCategorie = 0;
            }
            else
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

        public static bool Afiseaza(Form pEcranPariente, BListaPreturiStandard pLucrare)
        {
            using (FormDetaliuLucrare ecran = new FormDetaliuLucrare(pLucrare))
            {
                ecran.AplicaPreferinteleUtilizatorului();
                return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
            }
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
        }

        #endregion

    }
}
