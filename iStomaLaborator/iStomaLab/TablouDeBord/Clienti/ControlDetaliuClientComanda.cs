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
using BLL.iStomaLab.Reprezentanti;
using BLL.iStomaLab.Clienti;
using CCL.UI;
using CDL.iStomaLab;
using BLL.iStomaLab.Preturi;
using CCL.iStomaLab;
using BLL.iStomaLab.Utilizatori;
using System.Windows;

namespace iStomaLab.TablouDeBord.Clienti
{
    public partial class ControlDetaliuClientComanda : UserControlPersonalizat
    {

        #region Declaratii generale

        private BClientiComenzi lComanda = null;
        private BClienti lClient = null;
        private BListaPreturiStandard lLucrareSelectata = null;

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colDenumireEtapa,
            colDataInceput,
            colDataSfarsit,
            colTehnician
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlDetaliuClientComanda()
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
            this.cboComandaReprezentant.Enter += CboComandaReprezentant_Enter;
            this.lblFindLucrare.DeschideEcranCautare += LblFindLucrare_DeschideEcranCautare;
            this.dgvListaEtape.CellClick += DgvListaEtape_CellClick;
            this.dgvListaEtape.StergereLinie += DgvListaEtape_StergereLinie;
            this.btnMeniuComanda.Click += BtnMeniuComanda_Click;
            this.btnInchidePanel.Click += BtnMeniuComanda_Click;
            this.btnModificaTehnician.Click += BtnModificaTehnician_Click;
        }

        private void initTextML()
        {
            this.lblComandaReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Reprezentant);
            this.lblComandaPacient.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pacient);
            this.lblComandaPacientNume.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Nume);
            this.lblComandaPacientPrenume.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Prenume);
            this.lblComandaPacientDataNasterii.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataNasterii);
            this.lblComandaPacientSex.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Sex);
            this.chkComandaPacientFeminin.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.captionFeminin);
            this.chkComandaPacientMasculin.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.captionMasculin);
            this.lblComandaDataPrimire.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataPrimire);
            this.lblComandaDataLaGata.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataLaGata);
            this.lblComandaObservatii.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii);
            this.lblCabinet.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Cabinet);
            this.lblLucrare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Lucrare);
            this.lblEtape.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Etape);
            this.btnModificaTehnician.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ModificaTehnician);
        }

        public void Initializeaza(BClientiComenzi pComanda, BClienti pClient)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.lComanda = pComanda;
            this.lClient = pClient;
            initListe();

            this.cboComandaReprezentant.Focus();
            this.panelOptiuni.Visible = false;

            if (this.lComanda == null || this.lClient == null)
            {
                this.ctrlComandaDataPrimire.DataAfisata = DateTime.Now;

                this.lLucrareSelectata = FormListaLucrari._SLucrare;
                this.lblFindLucrare.Text = this.lLucrareSelectata.Denumire;
                this.ctrlComandaDataLaGata.DataAfisata = this.ctrlComandaDataPrimire.DataAfisata.AddDays(this.lLucrareSelectata.TermenMediuZile);
                this.txtComandaPacientNume.Goleste();
                this.txtComandaPacientPrenume.Goleste();
                this.ctrlPacientDataNasterii.Goleste();
                this.chkComandaPacientFeminin.Checked = false;
                this.chkComandaPacientMasculin.Checked = false;
                this.txtComandaObservatii.Goleste();
            }
            else
            {
                this.lLucrareSelectata = BListaPreturiStandard.getLucrareById(this.lComanda.IdLucrare, null);
                this.lblFindLucrare.Text = this.lLucrareSelectata.Denumire;
                this.cboComandaReprezentant.SelectedValue = lComanda.IdReprezentantClient;
                this.cboCabinet.SelectedValue = lComanda.IdCabinet;
                this.txtComandaPacientNume.Text = lComanda.NumePacient;
                this.txtComandaPacientPrenume.Text = lComanda.PrenumePacient;
                this.ctrlPacientDataNasterii.DataAfisata = lComanda.DataNasterePacient;
                this.chkComandaPacientFeminin.Checked = getSexClient(true);
                this.chkComandaPacientMasculin.Checked = getSexClient(false);
                this.ctrlComandaDataPrimire.DataAfisata = lComanda.DataPrimire;
                this.ctrlComandaDataLaGata.DataAfisata = lComanda.DataLaGata;
                this.txtComandaObservatii.Text = lComanda.Observatii;
            }

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void BtnModificaTehnician_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BColectieClientiComenziEtape listaEtapeBifate = this.dgvListaEtape.GetListaObiecteBifate<BColectieClientiComenziEtape, BClientiComenziEtape>();

                if (listaEtapeBifate.Count > 0)
                {
                    if (FormListaUtilizatori.Afiseaza(this.GetFormParinte(), CDefinitiiComune.EnumRol.Tehnician, 750, 250) && FormListaUtilizatori._SUtilizator != null)
                    {
                        foreach (var rand in this.dgvListaEtape.GetListaLiniiSelectate())
                        {
                            rand.Cells[EnumColoaneDGV.colTehnician.ToString()].Value = FormListaUtilizatori._SUtilizator.GetNumeCompletUtilizator();
                            rand.Cells[EnumColoaneDGV.colTehnician.ToString()].Tag = FormListaUtilizatori._SUtilizator.Id;
                        }
                    }
                }
                else
                {
                    Mesaj.Informare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.InformareSelectareLinie), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Etape));
                }

                this.panelOptiuni.Visible = false;
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

        private void BtnMeniuComanda_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.panelOptiuni.Visible = !this.panelOptiuni.Visible;
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

                BEtape etapa = this.dgvListaEtape.Rows[pIndexRand].Tag as BEtape;
                if (etapa != null)
                {
                    if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), etapa.Denumire.ToString()))
                    {
                        this.dgvListaEtape.Rows.RemoveAt(pIndexRand);
                    }
                }
                else
                {
                    BLucrariEtape lucrareEtapa = this.dgvListaEtape.Rows[pIndexRand].Tag as BLucrariEtape;
                    if (lucrareEtapa != null)
                    {
                        if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), BEtape.GetEtapaById(lucrareEtapa.IdEtapa, CDefinitiiComune.EnumStare.Activa, null).Denumire.ToString()))
                        {
                            this.dgvListaEtape.Rows.RemoveAt(pIndexRand);
                        }
                    }
                    else
                    {
                        BClientiComenziEtape lucrareClientEtapa = this.dgvListaEtape.Rows[pIndexRand].Tag as BClientiComenziEtape;
                        if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), BEtape.GetEtapaById(lucrareClientEtapa.IdEtapa, CDefinitiiComune.EnumStare.Activa, null).Denumire.ToString()))
                        {
                            this.dgvListaEtape.Rows.RemoveAt(pIndexRand);
                        }
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

        private void DgvListaEtape_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                string numeColoana = this.dgvListaEtape.Columns[e.ColumnIndex].Name;

                if ((numeColoana.Equals(EnumColoaneDGV.colDataInceput.ToString()) || numeColoana.Equals(EnumColoaneDGV.colDataSfarsit.ToString())) && e.RowIndex != -1)
                {
                    arataControlData(e.RowIndex, e.ColumnIndex);
                }
                else if (numeColoana.Equals(EnumColoaneDGV.colTehnician.ToString()) && e.RowIndex != -1)
                {
                    if (FormListaUtilizatori.Afiseaza(this.GetFormParinte(), CDefinitiiComune.EnumRol.Tehnician, 750, 250) && FormListaUtilizatori._SUtilizator != null)
                    {
                        this.dgvListaEtape.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = FormListaUtilizatori._SUtilizator.GetNumeCompletUtilizator();
                        this.dgvListaEtape.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag = FormListaUtilizatori._SUtilizator.Id;
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

        private void LblFindLucrare_DeschideEcranCautare(Control psender, object pxObiectExistent)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (FormListaLucrari.Afiseaza(this.GetFormParinte()) && FormListaLucrari._SLucrare != null)
                {
                    Initializeaza(this.lComanda, this.lClient);
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

        private void CboComandaReprezentant_Enter(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.cboComandaReprezentant.DroppedDown = true;
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

        private void arataControlData(int pRowIndex, int pColumnIndex)
        {
            controlAlegeData ctrlData = new controlAlegeData();
            DateTime dataAfisata = CUtil.GetAsDate(this.dgvListaEtape.Rows[pRowIndex].Cells[pColumnIndex].Value);
            if (dataAfisata != null)
            {
                ctrlData.InitializeazaData(dataAfisata, false, false);
            }
            ctrlData.AfiseazaCalendar();
            if (!ctrlData.DataAfisata.Equals(CConstante.DataNula))
            {
                this.dgvListaEtape.Rows[pRowIndex].Cells[pColumnIndex].Value = ctrlData.DataAfisata;
                this.dgvListaEtape.Rows[pRowIndex].Cells[pColumnIndex].Tag = ctrlData.DataAfisata;
            }
        }

        private bool getSexClient(bool pEsteFeminin)
        {
            if (this.lComanda.SexPacient == 0)
                return false;
            return this.lComanda.SexPacient == 1 ? !pEsteFeminin : pEsteFeminin;
        }

        private int getSexSelectat()
        {
            if (this.chkComandaPacientFeminin.Checked)
                return 2;
            else if (this.chkComandaPacientMasculin.Checked)
                return 1;
            return 0;
        }

        private void initListe()
        {
            Dictionary<int, string> lstReprezentanti = new Dictionary<int, string>();
            Dictionary<int, string> lstCabinete = new Dictionary<int, string>();

            lstReprezentanti.Add(0, string.Empty);
            lstCabinete.Add(0, string.Empty);

            foreach (var elem in BClientiReprezentanti.GetListByParamIdClient(this.lClient.Id, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null))
            {
                lstReprezentanti.Add(elem.Id, BClientiReprezentanti.getNumeCompletReprezentant(elem));
            }
            foreach (var elem in BClientiCabinete.GetListByParamIdClient(this.lClient.Id, CDefinitiiComune.EnumStare.Activa, null))
            {
                lstCabinete.Add(elem.Id, elem.Denumire);
            }

            this.cboComandaReprezentant.DataSource = new BindingSource(lstReprezentanti, null);
            this.cboComandaReprezentant.DisplayMember = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Value);
            this.cboComandaReprezentant.ValueMember = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Key);

            this.cboCabinet.DataSource = new BindingSource(lstCabinete, null);
            this.cboCabinet.DisplayMember = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Value);
            this.cboCabinet.ValueMember = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Key);

            if (this.lComanda != null)
            {
                if (this.lClient.IdRecomandant != 0)
                    this.cboComandaReprezentant.Text = BClientiReprezentanti.getNumeCompletReprezentant(BClientiReprezentanti.getReprezentant(this.lClient.IdRecomandant, null));
            }

            this.cboComandaReprezentant.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboCabinet.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void seteazaAlerta()
        {
            IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.cboComandaReprezentant, this.lblComandaReprezentant);
            if (string.IsNullOrEmpty(this.cboComandaReprezentant.Text))
            {
                this.cboComandaReprezentant.Focus();
            }
        }

        #region Metode DGV

        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaEtape.IncepeConstructieColoane();

            this.dgvListaEtape.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.SelectieMultipla);

            this.dgvListaEtape.AdaugaColoanaText(EnumColoaneDGV.colDenumireEtapa.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaEtape.AdaugaColoanaData(EnumColoaneDGV.colDataInceput.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataInceput), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);

            this.dgvListaEtape.AdaugaColoanaData(EnumColoaneDGV.colDataSfarsit.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataSfarsit), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);

            this.dgvListaEtape.AdaugaColoanaText(EnumColoaneDGV.colTehnician.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tehnician), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaEtape.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvListaEtape.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaEtape.IncepeContructieRanduri();

            if (this.lComanda == null)
            {
                var listaElem = BLucrariEtape.GetListByParamIdLucrare(this.lLucrareSelectata.Id, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

                var listaEtape = BEtape.GetListByParam(CDefinitiiComune.EnumStare.Activa, null);

                if (listaElem.Count != 0)
                {
                    foreach (var elem in listaElem)
                    {
                        incarcaRand(this.dgvListaEtape.Rows[this.dgvListaEtape.Rows.Add()], elem);
                    }

                    this.dgvListaEtape.Rows[0].Cells[EnumColoaneDGV.colDataInceput.ToString()].Value = this.ctrlComandaDataPrimire.DataAfisata;
                    this.dgvListaEtape.Rows[0].Cells[EnumColoaneDGV.colDataInceput.ToString()].Tag = this.ctrlComandaDataPrimire.DataAfisata;
                }
                else
                {
                    foreach (var etapa in listaEtape)
                    {
                        incarcaRand(this.dgvListaEtape.Rows[this.dgvListaEtape.Rows.Add()], etapa);
                    }
                }
            }
            else
            {
                var listaEtapeSalvate = BClientiComenziEtape.GetListByParamIdComandaClient(this.lComanda.Id, CDefinitiiComune.EnumStare.Activa, null);

                foreach (var etapaSalvata in listaEtapeSalvate)
                {
                    incarcaRand(this.dgvListaEtape.Rows[this.dgvListaEtape.Rows.Add()], etapaSalvata);
                }
            }
            this.dgvListaEtape.FinalizeazaContructieRanduri();
        }

        private void incarcaRand(DataGridViewRow pRand, BLucrariEtape pElem)
        {
            pRand.Tag = pElem;

            pRand.Cells[EnumColoaneDGV.colDenumireEtapa.ToString()].Value = BEtape.GetEtapaById(pElem.IdEtapa, CDefinitiiComune.EnumStare.Activa, null).Denumire;
            pRand.Cells[EnumColoaneDGV.colDenumireEtapa.ToString()].Tag = pElem;
            DataGridViewPersonalizat.InitCelulaStergere(pRand);
        }

        private void incarcaRand(DataGridViewRow pRand, BEtape pElem)
        {
            pRand.Tag = pElem;

            pRand.Cells[EnumColoaneDGV.colDenumireEtapa.ToString()].Value = pElem.Denumire;
            pRand.Cells[EnumColoaneDGV.colDenumireEtapa.ToString()].Tag = pElem;
            DataGridViewPersonalizat.InitCelulaStergere(pRand);
        }

        private void incarcaRand(DataGridViewRow pRand, BClientiComenziEtape pElem)
        {
            pRand.Tag = pElem;

            pRand.Cells[EnumColoaneDGV.colDenumireEtapa.ToString()].Value = BEtape.GetEtapaById(pElem.IdEtapa, CDefinitiiComune.EnumStare.Activa, null).Denumire;
            pRand.Cells[EnumColoaneDGV.colDenumireEtapa.ToString()].Tag = pElem;
            if (pElem.DataInceput != CConstante.DataNula)
            {
                pRand.Cells[EnumColoaneDGV.colDataInceput.ToString()].Value = pElem.DataInceput;
                pRand.Cells[EnumColoaneDGV.colDataInceput.ToString()].Tag = pElem.DataInceput;
            }
            if (pElem.DataFinal != CConstante.DataNula)
            {
                pRand.Cells[EnumColoaneDGV.colDataSfarsit.ToString()].Value = pElem.DataFinal;
                pRand.Cells[EnumColoaneDGV.colDataSfarsit.ToString()].Tag = pElem.DataFinal;
            }

            if (pElem.IdTehnician != 0)
            {
                pRand.Cells[EnumColoaneDGV.colTehnician.ToString()].Value = BUtilizator.GetById(pElem.IdTehnician, null).GetNumeCompletUtilizator();
                pRand.Cells[EnumColoaneDGV.colTehnician.ToString()].Tag = BUtilizator.GetById(pElem.IdTehnician, null).Id;
            }

            DataGridViewPersonalizat.InitCelulaStergere(pRand);
        }

        #endregion

        #region Metode Salveaza Etape

        bool SalveazaComandaEtape(BLucrariEtape pLucrareEtapa, DateTime pDataInceput, DateTime pDataSfarsit, int pIdTehnician)
        {
            bool esteValid = BClientiComenziEtape.SuntInformatiileNecesareCoerente(this.lComanda.Id, pLucrareEtapa.IdEtapa);

            if (esteValid)
            {
                BClientiComenziEtape.Add(this.lComanda.Id, pLucrareEtapa.IdEtapa, pDataInceput, pDataSfarsit, pIdTehnician, string.Empty, null);
            }
            else
            {
                IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());
            }
            return esteValid;
        }

        bool SalveazaComandaEtape(BEtape pLucrareEtapa, DateTime pDataInceput, DateTime pDataSfarsit, int pIdTehnician)
        {
            bool esteValid = BClientiComenziEtape.SuntInformatiileNecesareCoerente(this.lComanda.Id, pLucrareEtapa.Id);

            if (esteValid)
            {
                BClientiComenziEtape.Add(this.lComanda.Id, pLucrareEtapa.Id, pDataInceput, pDataSfarsit, pIdTehnician, string.Empty, null);
            }
            else
            {
                IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());
            }
            return esteValid;
        }

        bool SalveazaComandaEtape(BClientiComenziEtape pLucrareEtapa, DateTime pDataInceput, DateTime pDataSfarsit, int pIdTehnician)
        {
            bool esteValid = BClientiComenziEtape.SuntInformatiileNecesareCoerente(this.lComanda.Id, pLucrareEtapa.Id);

            if (esteValid)
            {
                List<int> lstEtape = BClientiComenziEtape.GetIdListByParamIdComandaClient(this.lComanda.Id, CDefinitiiComune.EnumStare.Activa, null);

                if (lstEtape.Contains(pLucrareEtapa.Id))
                {
                    pLucrareEtapa.DataInceput = pDataInceput;
                    pLucrareEtapa.DataFinal = pDataSfarsit;
                    pLucrareEtapa.IdTehnician = pIdTehnician;
                    pLucrareEtapa.UpdateAll();
                }
                else
                {
                    BClientiComenziEtape.Add(this.lComanda.Id, pLucrareEtapa.IdEtapa, pDataInceput, pDataSfarsit, pIdTehnician, string.Empty, null);
                }
            }
            else
            {
                IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());
            }
            return esteValid;
        }

        bool SalveazaEtapele()
        {
            bool esteSalvat = false;

            foreach (DataGridViewRow rand in this.dgvListaEtape.Rows)
            {
                DateTime dataInceput = CUtil.GetAsDate(this.dgvListaEtape.Rows[rand.Index].Cells[EnumColoaneDGV.colDataInceput.ToString()].Tag);
                DateTime dataSfarsit = CUtil.GetAsDate(this.dgvListaEtape.Rows[rand.Index].Cells[EnumColoaneDGV.colDataSfarsit.ToString()].Tag);
                int idUtilizator = CUtil.GetAsInt32(this.dgvListaEtape.Rows[rand.Index].Cells[EnumColoaneDGV.colTehnician.ToString()].Tag);

                BClientiComenziEtape listaLucrariEtapa = this.dgvListaEtape.Rows[rand.Index].Cells[EnumColoaneDGV.colDenumireEtapa.ToString()].Tag as BClientiComenziEtape;

                BLucrariEtape lucrareEtapa = this.dgvListaEtape.Rows[rand.Index].Cells[EnumColoaneDGV.colDenumireEtapa.ToString()].Tag as BLucrariEtape;
                if (listaLucrariEtapa == null)
                {
                    if (lucrareEtapa == null)
                    {
                        BEtape etapa = this.dgvListaEtape.Rows[rand.Index].Cells[EnumColoaneDGV.colDenumireEtapa.ToString()].Tag as BEtape;
                        if (etapa != null && dataInceput != CConstante.DataNula && dataSfarsit != CConstante.DataNula && idUtilizator != 0)
                        {
                            SalveazaComandaEtape(etapa, dataInceput, dataSfarsit, idUtilizator);
                            esteSalvat = true;
                        }
                    }
                    else
                    {
                        if (lucrareEtapa != null && dataInceput != CConstante.DataNula && dataSfarsit != CConstante.DataNula && idUtilizator != 0)
                        {
                            SalveazaComandaEtape(lucrareEtapa, dataInceput, dataSfarsit, idUtilizator);
                            esteSalvat = true;
                        }
                    }
                }
                else
                {
                    if (listaLucrariEtapa != null && dataInceput != CConstante.DataNula && dataSfarsit != CConstante.DataNula && idUtilizator != 0)
                    {
                        SalveazaComandaEtape(listaLucrariEtapa, dataInceput, dataSfarsit, idUtilizator);
                        esteSalvat = true;
                    }
                }

            }
            if (esteSalvat == false)
                Mesaj.Informare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.InformatiiIncomplete), string.Empty);

            return esteSalvat;
        }

        #endregion

        #endregion

        #region Metode publice

        internal bool Salveaza()
        {
            bool esteValid = BClientiComenzi.SuntInformatiileNecesareCoerente(CUtil.GetAsInt32(this.cboComandaReprezentant.SelectedValue));

            if (this.lComanda == null)
            {
                if (esteValid)
                {
                    BClientiComenzi.Add(this.lClient.Id, CUtil.GetAsInt32(this.cboComandaReprezentant.SelectedValue), this.txtComandaPacientNume.Text, this.txtComandaPacientPrenume.Text, this.ctrlPacientDataNasterii.DataAfisata, getSexSelectat(), this.ctrlComandaDataPrimire.DataAfisata, this.ctrlComandaDataLaGata.DataAfisata, this.txtComandaObservatii.Text, CUtil.GetAsInt32(this.cboCabinet.SelectedValue), this.lLucrareSelectata.Id, null);
                    BColectieClientiComenzi lstComenzi = BClientiComenzi.GetListByParamIdClient(this.lClient.Id, CDefinitiiComune.EnumStare.Activa, null);
                    this.lComanda = lstComenzi[lstComenzi.Count - 1];
                }
                else
                {
                    seteazaAlerta();
                }
            }
            else
            {
                this.lComanda.IdReprezentantClient = CUtil.GetAsInt32(this.cboComandaReprezentant.SelectedValue);
                this.lComanda.NumePacient = this.txtComandaPacientNume.Text;
                this.lComanda.PrenumePacient = this.txtComandaPacientPrenume.Text;
                this.lComanda.DataNasterePacient = this.ctrlPacientDataNasterii.DataAfisata;
                this.lComanda.SexPacient = getSexSelectat();
                this.lComanda.DataPrimire = this.ctrlComandaDataPrimire.DataAfisata;
                this.lComanda.DataLaGata = this.ctrlComandaDataLaGata.DataAfisata;
                this.lComanda.Observatii = this.txtComandaObservatii.Text;
                this.lComanda.IdCabinet = CUtil.GetAsInt32(this.cboCabinet.SelectedValue);

                if (esteValid)
                {
                    this.lComanda.UpdateAll();
                }
                else
                {
                    seteazaAlerta();
                }

            }

            return esteValid && SalveazaEtapele();
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
            this.cboComandaReprezentant.AllowModification(this.lEcranInModificare);
            this.txtComandaPacientNume.AllowModification(this.lEcranInModificare);
            this.txtComandaPacientPrenume.AllowModification(this.lEcranInModificare);
            this.ctrlPacientDataNasterii.AllowModification(this.lEcranInModificare);
            this.chkComandaPacientFeminin.AllowModification(this.lEcranInModificare);
            this.chkComandaPacientMasculin.AllowModification(this.lEcranInModificare);
            this.ctrlComandaDataPrimire.AllowModification(this.lEcranInModificare);
            this.ctrlComandaDataLaGata.AllowModification(this.lEcranInModificare);
            this.txtComandaObservatii.AllowModification(this.lEcranInModificare);
            this.lblFindLucrare.AllowModification(this.lEcranInModificare);
            this.dgvListaEtape.AllowModification(this.lEcranInModificare);
        }


        #endregion

    }
}
