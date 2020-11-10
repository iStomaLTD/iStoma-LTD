using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Preturi;
using BLL.iStomaLab.Utilizatori;
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

namespace iStomaLab.TablouDeBord.Clienti
{
    public partial class FormLucrareListaEtapeRealizate : FormPersonalizat
    {

        #region Declaratii generale

        private BClientiComenzi lComanda = null;

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colEtapa,
            colDataInceput,
            colDataFinal,
            colTehnician,
            colStatus,
            colObservatii
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormLucrareListaEtapeRealizate(BClientiComenzi pComandaEtapa)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lComanda = pComandaEtapa;

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
            this.txtCautaEtapa.CerereUpdate += TxtCautaEtapa_CerereUpdate;
            this.dgvListaEtape.EditareLinie += DgvListaEtape_EditareLinie;
            this.dgvListaEtape.StergereLinie += DgvListaEtape_StergereLinie;
            this.ctrlValidareAnulare.Validare += CtrlValidareAnulare_Validare;
            this.btnActivDezactivat.Click += BtnActivDezactivat_Click;
        }

        private void initTextML()
        {
            this.Text = this.lComanda.DenumireLucrare;
            this.lblTitlu.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Etape);
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

            this.txtCautaEtapa.Goleste();
            this.btnActivDezactivat.Selectat = false;

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void BtnActivDezactivat_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

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

        private void CtrlValidareAnulare_Validare(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

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

        private void DgvListaEtape_StergereLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BClientiComenziEtape etapa = this.dgvListaEtape.Rows[pIndexRand].Tag as BClientiComenziEtape;

                if (etapa != null)
                {
                    if (!this.btnActivDezactivat.Selectat)
                    {
                        if (Mesaj.Confirmare(this, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), etapa.DenumireEtapa))
                        {
                            this.lComanda.CloseEtapa(etapa, null);
                            ConstruiesteRanduriDGV();
                        }
                    }
                    else
                    {
                        if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiReactivarea), etapa.DenumireEtapa))
                        {
                            etapa.Close(false, string.Empty, null);
                            ConstruiesteRanduriDGV();
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

        private void DgvListaEtape_EditareLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BClientiComenziEtape etapa = this.dgvListaEtape.Rows[pIndexRand].Tag as BClientiComenziEtape;
                if (etapa != null && !this.btnActivDezactivat.Selectat)
                {
                    if (FormDetaliuEtapaComanda.Afiseaza(this, etapa))
                        incarcaRand(this.dgvListaEtape.Rows[pIndexRand], etapa);
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

        #endregion

        #region Metode private

        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaEtape.IncepeConstructieColoane();

            this.dgvListaEtape.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvListaEtape.AdaugaColoanaText(EnumColoaneDGV.colEtapa.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Etapa), 150, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaEtape.AdaugaColoanaText(EnumColoaneDGV.colTehnician.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tehnician), 150, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaEtape.AdaugaColoanaData(EnumColoaneDGV.colDataInceput.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataInceput), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA_ORA);

            this.dgvListaEtape.AdaugaColoanaData(EnumColoaneDGV.colDataFinal.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataSfarsit), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA_ORA);

            this.dgvListaEtape.AdaugaColoanaText(EnumColoaneDGV.colStatus.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stare), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaEtape.AdaugaColoanaText(EnumColoaneDGV.colObservatii.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii), 150, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaEtape.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvListaEtape.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            var listaElem = BClientiComenziEtape.GetListByIdComanda(this.lComanda.Id, CDefinitiiComune.EnumStare.Toate, null);

            if (listaElem.ContineElementeDeactivate())
            {
                this.btnActivDezactivat.Visible = true;
            }
            else
            {
                this.btnActivDezactivat.Visible = false;
                this.btnActivDezactivat.Selectat = false;
            }

            if (!this.btnActivDezactivat.Selectat)
                ConstruiesteRanduriDGV(listaElem.GetListaActive());
            else
                ConstruiesteRanduriDGV(listaElem.GetListaInactive());
        }

        private void ConstruiesteRanduriDGV(BColectieClientiComenziEtape pListaElem)
        {
            this.dgvListaEtape.IncepeContructieRanduri();

            foreach (var elem in pListaElem)
            {
                incarcaRand(this.dgvListaEtape.Rows[this.dgvListaEtape.Rows.Add()], elem);
            }

            this.dgvListaEtape.FinalizeazaContructieRanduri();

        }

        private void incarcaRand(DataGridViewRow pRand, BClientiComenziEtape pElem)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);

            if (pElem.IdEtapa != 0)
                pRand.Cells[EnumColoaneDGV.colEtapa.ToString()].Value = BEtape.GetEtapaById(pElem.IdEtapa, CDefinitiiComune.EnumStare.Activa, null).Denumire;
            pRand.Cells[EnumColoaneDGV.colDataInceput.ToString()].Value = pElem.DataInceput;

            if (pElem.Refacere)
            {
                DataGridViewPersonalizat.SeteazaAlerta(pRand, EnumColoaneDGV.colEtapa.ToString());
                pRand.Cells[EnumColoaneDGV.colEtapa.ToString()].ToolTipText = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Refacere);
            }
            else
                DataGridViewPersonalizat.IndeparteazaAlerta(pRand, EnumColoaneDGV.colEtapa.ToString());

            pRand.Cells[EnumColoaneDGV.colDataFinal.ToString()].Value = pElem.DataFinal;
            if (pElem.IdTehnician != 0)
                pRand.Cells[EnumColoaneDGV.colTehnician.ToString()].Value = BUtilizator.GetById(pElem.IdTehnician, null).GetNumeCompletUtilizator();
            pRand.Cells[EnumColoaneDGV.colObservatii.ToString()].Value = pElem.Observatii;
            pRand.Cells[EnumColoaneDGV.colStatus.ToString()].Value = BClientiComenziEtape.StructStareEtapa.GetStructById(pElem.Status).Denumire;
            DataGridViewPersonalizat.InitCelulaStergere(pRand);
        }

        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente, BClientiComenzi pComandaEtapa)
        {
            using (FormLucrareListaEtapeRealizate ecran = new FormLucrareListaEtapeRealizate(pComandaEtapa))
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
