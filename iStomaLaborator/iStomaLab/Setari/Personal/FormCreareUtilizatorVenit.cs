using BLL.iStomaLab;
using BLL.iStomaLab.Preturi;
using BLL.iStomaLab.Utilizatori;
using CCL.iStomaLab;
using CCL.UI;
using CDL.iStomaLab;
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
using static BLL.iStomaLab.Utilizatori.BUtilizatoriVenituri;
using static BLL.iStomaLab.Utilizatori.BUtilizatoriVenituriDetalii;
using static CDL.iStomaLab.CDefinitiiComune;

namespace iStomaLab.Setari.Personal
{
    public partial class FormCreareUtilizatorVenit : FormPersonalizat
    {

        #region Declaratii generale

        private BUtilizatoriVenituri lVenituri = null;
        private BUtilizator lUser = null;

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colEtapa,
            colPret
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormCreareUtilizatorVenit(BUtilizator pUser, BUtilizatoriVenituri pVenituri)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lUser = pUser;
            this.lVenituri = pVenituri;

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
            this.ctrlValidareAnulareVenit.Validare += CtrlValidareAnulareVenit_Validare;
            this.FormClosed += FormDetaliuLucrare_FormClosed;
            this.cboTipVenit.CerereUpdate += CboTipVenit_CerereUpdate;
            this.dgvListaVenituriEtape.CellEndEdit += DgvListaVenituriEtape_CellEndEdit;
        }



        private void initTextML()
        {
            this.Text = string.Empty;
            this.lblDataInceput.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DeLa);
            this.lblDataSfarsit.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PanaLa);
            this.lblTipVenit.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TipVenit);
            this.lblSalariu.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.SalariuFix);
            this.lblTitluEcran.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Venituri);
            this.lblObservatii.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii);
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

            initListe();

            if (this.lVenituri == null)
            {
                this.ctrlSalariu.Initializeaza(null);
                this.ctrlAlegeDataInceput.Initializeaza(CUtil.GetPrimaZiDinLuna(DateTime.Now));
                this.ctrlAlegeDataFinal.Goleste();
                this.txtObservatii.Goleste();
                this.cboTipVenit.SelectedItem = BUtilizatoriVenituri.EnumTipVenit.PretFixPeEtapa;
            }
            else
            {
                this.ctrlAlegeDataInceput.Initializeaza(this.lVenituri.DataInceput);
                this.ctrlAlegeDataFinal.Initializeaza(this.lVenituri.DataFinal);
                this.txtObservatii.Text = this.lVenituri.Observatii;
                this.cboTipVenit.SelectedItem = this.lVenituri.TipVenit;
                this.ctrlSalariu.Initializeaza(this.lVenituri.SalariuFix, EnumTipMoneda.Lei);
            }

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            ascundeDataGridView();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void DgvListaVenituriEtape_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (this.lSeIncarca || e.RowIndex < 0) return;
            try
            {
                incepeIncarcarea();

                //In modul creare vom recupera Dictionarul cu id etapa si pret la salvare

                if (this.lVenituri != null)
                {
                    //In mod modificare facem update sau insert in BUtilizatoriVenituriDetalii  in functie de ce avem in Tag rand
                    //recuperam numele coloanei si ne asiguram ca e coloana pret

                    string denumireColoanaSelectata = this.dgvListaVenituriEtape.Columns[e.ColumnIndex].Name;
                    if (denumireColoanaSelectata.Equals(EnumColoaneDGV.colPret.ToString()))
                    {
                        BEtape etape = this.dgvListaVenituriEtape.Rows[e.RowIndex].Cells[EnumColoaneDGV.colEtapa.ToString()].Tag as BEtape;
                        BUtilizatoriVenituriDetalii pretVenituriDetalii = this.dgvListaVenituriEtape.Rows[e.RowIndex].Tag as BUtilizatoriVenituriDetalii;

                        if (pretVenituriDetalii != null)
                        {
                            if (pretVenituriDetalii != null)
                            {
                                //Update
                                pretVenituriDetalii.UpdatePret(CUtil.GetAsDouble(this.dgvListaVenituriEtape.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                            }
                        }
                        else
                        {
                            double pretNou = CUtil.GetAsDouble(this.dgvListaVenituriEtape.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                            int id = BUtilizatoriVenituriDetalii.Add(this.lVenituri.Id, etape.Id, pretNou, null);

                            if (id > 0)
                                pretVenituriDetalii = new BUtilizatoriVenituriDetalii(id);
                        }

                        incarcaRand(this.dgvListaVenituriEtape.Rows[e.RowIndex], etape, pretVenituriDetalii);
                    }
                }
                else
                {
                    //Validam Pret valoare introdusa
                    string name = this.dgvListaVenituriEtape.Columns[e.ColumnIndex].Name;
                    if (name.Equals(EnumColoaneDGV.colPret.ToString()))
                    {
                        string text = Convert.ToString(this.dgvListaVenituriEtape.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                        if (!string.IsNullOrEmpty(text) && !CUtil.PermiteDoarNumericeDinString(text))
                            this.dgvListaVenituriEtape.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = CUtil.ExtrageDoarNumericeDinString(text);
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


        private void CboTipVenit_CerereUpdate(object psender, string proprietate, object sNouaValoare)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                //SalariuFix = 1, //PretFixPeEtapa = 2
                this.dgvListaVenituriEtape.Visible = (getTipVenit() != EnumTipVenit.SalariuFix);
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

        private void CtrlValidareAnulareVenit_Validare(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (this.salveaza())
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

        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaVenituriEtape.IncepeConstructieColoane();
            this.dgvListaVenituriEtape.EditMode = DataGridViewEditMode.EditOnEnter;

            this.dgvListaVenituriEtape.AdaugaColoanaText(EnumColoaneDGV.colEtapa.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Etapa), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaVenituriEtape.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colPret.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PretLei), 80, DataGridViewColumnSortMode.Automatic);

            this.dgvListaVenituriEtape.Columns[EnumColoaneDGV.colPret.ToString()].ReadOnly = false;

            this.dgvListaVenituriEtape.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaVenituriEtape.IncepeContructieRanduri();

            var listaEtape = BEtape.GetListByParam(EnumStare.Activa, null);

            if (this.lVenituri == null)
            {
                //Mod creare ... incarcam cu BEtape

                foreach (var elem in listaEtape)
                {
                    incarcaRand(this.dgvListaVenituriEtape.AdaugaRandNou(), elem);
                }
            }
            else
            {
                //Mod modificare ... incarcam cu BColectieUtilizatoriVenituriDetalii
                var listaElem = BUtilizatoriVenituriDetalii.GetListByParam(this.lVenituri.Id, null);

                foreach (var etapa in listaEtape)
                {
                    incarcaRand(this.dgvListaVenituriEtape.AdaugaRandNou(), etapa, listaElem.GetByIdEtapa(etapa.Id));
                }
            }

            this.dgvListaVenituriEtape.FinalizeazaContructieRanduri();
        }

        private void incarcaRand(DataGridViewRow pRand, BEtape pEtapa)
        {
            pRand.Tag = pEtapa.Id;

            pRand.Cells[EnumColoaneDGV.colEtapa.ToString()].Value = pEtapa.Denumire;
        }

        private Dictionary<int, double> getDictEtapeValori()
        {
            Dictionary<int, double> dictRetur = new Dictionary<int, double>();

            int idEtapaTemp = 0;
            double pretTemp = 0;
            foreach (DataGridViewRow rand in this.dgvListaVenituriEtape.Rows)
            {
                pretTemp = CUtil.GetAsDouble(rand.Cells[EnumColoaneDGV.colPret.ToString()].Value);

                if (pretTemp > 0)
                {
                    idEtapaTemp = CUtil.GetAsInt32(rand.Tag);

                    dictRetur.Add(idEtapaTemp, pretTemp);
                }

            }

            return dictRetur;
        }


        private void incarcaRand(DataGridViewRow pRand, BEtape pEtapa, BUtilizatoriVenituriDetalii pVenitDetalii)
        {
            pRand.Tag = pVenitDetalii;

            pRand.Cells[EnumColoaneDGV.colEtapa.ToString()].Value = pEtapa.Denumire;
            pRand.Cells[EnumColoaneDGV.colEtapa.ToString()].Tag = pEtapa;

            if (pVenitDetalii != null)
                DataGridViewPersonalizat.InitCelulaValoareMonetara(pRand, EnumColoaneDGV.colPret.ToString(), pVenitDetalii.Pret);
        }

        private void initListe()
        {
            this.cboTipVenit.BeginUpdate();
            this.cboTipVenit.DataSource = BUtilizatoriVenituri.StructTipVenit.GetList();
            this.cboTipVenit.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboTipVenit.EndUpdate();
        }

        private void ascundeDataGridView()
        {
            if ((getTipVenit() == EnumTipVenit.SalariuFix))
                this.dgvListaVenituriEtape.AscundeDataGridView();
        }

        private bool suntDateleValide()
        {
            bool esteValid = this.ctrlAlegeDataInceput.AreValoare();

            if (esteValid)
            {
                var listaElem = BUtilizatoriVenituri.GetListByParam(this.lUser.Id, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

                if (this.lVenituri != null)
                    listaElem.Remove(this.lVenituri);

                esteValid = listaElem.EsteDataInceputCoerenta(this.ctrlAlegeDataInceput.GetValoare());

                if (!esteValid)
                    Mesaj.Afiseaza(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataDeInceputNuEsteCoerenta));
            }
            else
            {
                IHMEfecteSpeciale.AplicaEfectNU(this, this.lblDataInceput, this.ctrlAlegeDataInceput);
            }

            return esteValid;
        }

        private bool salveaza()
        {
            if (!suntDateleValide())
                return false;

            if (this.lVenituri == null)
            {
                //Mod creare

                bool esteValid = this.ctrlAlegeDataInceput.AreValoare();
                if (esteValid)
                {
                    return BUtilizatoriVenituri.Add(this.lUser.Id, this.ctrlAlegeDataInceput.DataAfisata, this.ctrlAlegeDataFinal.DataAfisata, this.txtObservatii.Text, getTipVenit(), this.ctrlSalariu.Valoare, getDictEtapeValori(), null) > 0;
                }

                return false;
            }
            else
            {
                //Mod Modificare
                this.lVenituri.DataInceput = this.ctrlAlegeDataInceput.DataAfisata;
                this.lVenituri.DataFinal = this.ctrlAlegeDataFinal.DataAfisata;
                this.lVenituri.Observatii = this.txtObservatii.Text;
                this.lVenituri.TipVenit = getTipVenit();
                this.lVenituri.SalariuFix = this.ctrlSalariu.Valoare;
                this.lVenituri.IdUtilizator = lVenituri.IdUtilizator;

                this.lVenituri.UpdateAll();
            }

            return true;
        }

        private EnumTipVenit getTipVenit()
        {
            if (this.cboTipVenit.SelectedItem == null)
                return EnumTipVenit.Nedefinit;

            return ((BUtilizatoriVenituri.StructTipVenit)this.cboTipVenit.SelectedItem).IdEnum;
        }


        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente, BUtilizator pUser, BUtilizatoriVenituri pVenituri)
        {
            using (FormCreareUtilizatorVenit ecran = new FormCreareUtilizatorVenit(pUser, pVenituri))
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
