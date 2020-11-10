using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;
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
using System.Windows.Forms;

namespace iStomaLab.TablouDeBord.Clienti
{
    public partial class FormSelectieLucrariNefacturate : FormPersonalizat
    {

        #region Declaratii generale

        private BClienti lClient = null;
        private BColectieClientiComenzi lListaSelectate = null;
        private BColectieClientiComenzi lListaLucrariDeAfisat = null;

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colDataPrimire,
            colMedic,
            colLucrare,
            colNrElemente,
            colDataLaGata,
            colTehnician,
            colDetaliiLucrariEtape,
            colNumePacient,
            colObservatii,
            colPretUnitar,
            colTotal
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormSelectieLucrariNefacturate(BClienti pClient, BColectieClientiComenzi pListaLucrariDeAfisat)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lClient = pClient;
            this.lListaLucrariDeAfisat = pListaLucrariDeAfisat;

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
            this.ctrlValidareAnulare.Validare += CtrlValidareAnulare_Validare;
            this.dgvLista.SelectieUnicaEfectuata += DgvLista_SelectieUnicaEfectuata;
            this.txtCautare.CerereUpdate += TxtCautare_CerereUpdate;
            this.dgvLista.CellClick += DgvLista_CellClick;
        }



        private void initTextML()
        {
            this.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.LucrariNefacturate);
            this.lblLucrariNefacturate.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.LucrariNefacturate);
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

            this.txtCautare.Goleste();

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void TxtCautare_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvLista.FiltreazaDupaText(this.txtCautare.Text);
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

        private void DgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (this.lSeIncarca || e.RowIndex < 0) return;
            try
            {
                incepeIncarcarea();

                string numeColoana = this.dgvLista.Columns[e.ColumnIndex].Name;

                if (numeColoana.Equals(EnumColoaneDGV.colDetaliiLucrariEtape.ToString()))
                {
                    BClientiComenzi comandaSelectata = this.dgvLista.SelectedRow.Tag as BClientiComenzi;
                    if (comandaSelectata != null)
                    {
                        if (FormLucrareListaEtapeRealizate.Afiseaza(this.GetFormParinte(), comandaSelectata))
                        {
                            comandaSelectata.Refresh(null);
                            incarcaRand(this.dgvLista.SelectedRow, comandaSelectata);
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

        private void DgvLista_SelectieUnicaEfectuata(object sender, DataGridViewCellEventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.lListaSelectate = new BColectieClientiComenzi(this.dgvLista.Rows[e.RowIndex].Tag as BClientiComenzi);

                inchideEcranulOK();
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

        private void CtrlValidareAnulare_Validare(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.lListaSelectate = this.dgvLista.GetListaObiecteBifate<BColectieClientiComenzi, BClientiComenzi>();

                inchideEcranulOK();
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
            this.dgvLista.IncepeConstructieColoane();

            this.dgvLista.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.SelectieMultipla);
            this.dgvLista.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.SelectieUnica);

            this.dgvLista.AdaugaColoanaData(EnumColoaneDGV.colDataPrimire.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataPrimire), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);

            this.dgvLista.AdaugaColoanaData(EnumColoaneDGV.colMedic.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Medic), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colLucrare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Lucrare), 300, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colNrElemente.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrElemente), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colPretUnitar.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PretUnitar), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colTotal.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PretTotal), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaData(EnumColoaneDGV.colDataLaGata.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataLaGata), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colTehnician.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tehnician), 130, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaButonClasic(EnumColoaneDGV.colDetaliiLucrariEtape.ToString(), string.Empty, string.Empty, 40, false);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colNumePacient.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pacient), 130, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colObservatii.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii), 150, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvLista.IncepeContructieRanduri();

            //Incarcam lista
            foreach (var elem in this.lListaLucrariDeAfisat)
            {
                incarcaRand(this.dgvLista.Rows[this.dgvLista.Rows.Add()], elem);
            }

            this.dgvLista.FinalizeazaContructieRanduri();
        }

        private void incarcaRand(DataGridViewRow pRand, BClientiComenzi pElem)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaSelectieUnica(pRand, true);
            DataGridViewPersonalizat.InitCelulaDeschideClasic(pRand, EnumColoaneDGV.colDetaliiLucrariEtape.ToString());
            pRand.Cells[EnumColoaneDGV.colDataPrimire.ToString()].Value = pElem.DataPrimire;
            pRand.Cells[EnumColoaneDGV.colMedic.ToString()].Value = pElem.GetIdentitateMedic();
            pRand.Cells[EnumColoaneDGV.colLucrare.ToString()].Value = pElem.GetDenumirePrescurtata();
            pRand.Cells[EnumColoaneDGV.colLucrare.ToString()].ToolTipText = pElem.DenumireLucrare;
            pRand.Cells[EnumColoaneDGV.colNrElemente.ToString()].Value = pElem.NrElemente.ToString();
            pRand.Cells[EnumColoaneDGV.colPretUnitar.ToString()].Value = CUtil.GetValoareMonetara(pElem.GetPretUnitar(), pElem.Moneda);
            pRand.Cells[EnumColoaneDGV.colTotal.ToString()].Value = CUtil.GetValoareMonetara(pElem.ValoareFinala, pElem.Moneda);
            if (pElem.DataLaGata != CConstante.DataNula)
            {
                pRand.Cells[EnumColoaneDGV.colDataLaGata.ToString()].Value = pElem.DataLaGata;
            }
            else
            {
                pRand.Cells[EnumColoaneDGV.colDataLaGata.ToString()].Value = string.Empty;
            }
            if (pElem.IdTehnician != 0)
                pRand.Cells[EnumColoaneDGV.colTehnician.ToString()].Value = pElem.GetIdentitateTehnician();
            else
                pRand.Cells[EnumColoaneDGV.colTehnician.ToString()].Value = string.Empty;
            pRand.Cells[EnumColoaneDGV.colNumePacient.ToString()].Value = pElem.GetNumePrenumePacient();
            pRand.Cells[EnumColoaneDGV.colObservatii.ToString()].Value = pElem.Observatii;
        }

        #endregion

        #region Metode publice

        public static BColectieClientiComenzi Afiseaza(Form pEcranPariente, BClienti pClient, BColectieClientiComenzi pListaComenziDeExclus)
        {
            BColectieClientiComenzi listaLucrariDeAfisat = pClient.GetListaLucrariNefacturate(null);
            listaLucrariDeAfisat = listaLucrariDeAfisat.Exclude(pListaComenziDeExclus);

            if (CUtil.EsteListaVida<BClientiComenzi>(listaLucrariDeAfisat))
            {
                Mesaj.Afiseaza(pEcranPariente, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NuExistaLucrariDeLaAceastaClinica));

                return null;
            }
            else
            {
                using (FormSelectieLucrariNefacturate ecran = new FormSelectieLucrariNefacturate(pClient, listaLucrariDeAfisat))
                {
                    ecran.AplicaPreferinteleUtilizatorului();
                    CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);

                    return ecran.lListaSelectate;
                }
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
