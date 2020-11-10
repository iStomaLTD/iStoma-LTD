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
using BLL.iStomaLab.Clienti;
using CCL.UI;
using BLL.iStomaLab.Reprezentanti;
using CDL.iStomaLab;
using BLL.iStomaLab.Referinta;
using CCL.iStomaLab;
using BLL.iStomaLab.Comune;

namespace iStomaLab.TablouDeBord.Clienti
{
    public partial class ControlDateClinica : UserControlPersonalizat
    {

        #region Declaratii generale

        private BClienti lClient = null;
        private EnumOptiuneAfisare lOptiune = EnumOptiuneAfisare.Medici;

        #endregion

        #region Enumerari si Structuri

        private enum EnumOptiuneAfisare
        {
            Medici,
            Cabinete
        }

        private enum EnumColoaneDGVMedici
        {
            colNumePrenume,
            colTelefonMobil,
            colEmail,
            colUltimaLucrare,
            colTotalLucrari,
            colObservatii
        }

        private enum EnumColoaneDGVCabinete
        {
            colDenumire,
            colAdresa,
            colUltimaLucrare,
            colTotalLucrari,
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlDateClinica()
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
            //meniu sus
            this.btnMedici.Click += BtnZonaAfisaj_Click;
            this.btnCabinete.Click += BtnZonaAfisaj_Click;

            //panel Medici Cabinete
            this.btnAdauga.Click += BtnAdauga_Click;
            this.dgvLista.StergereLinie += DgvLista_StergereLinie;
            this.dgvLista.EditareLinie += DgvLista_EditareLinie;
            this.txtCauta.CerereUpdate += TxtCauta_CerereUpdate;
            this.btnActiviInactivi.Click += BtnActiviInactivi_Click;

        }

        private void initTextML()
        {
            this.btnMedici.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Medici);
            this.btnCabinete.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Cabinete);
            this.lblDenumire.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire);
            this.lblTelefonMobil.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TelefonMobil);
            this.lblTelefonFix.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TelefonFix);
            this.lblEmail.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Email);
            this.lblWebSite.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Website);
            this.lblRecomandant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Recomandant);
            this.lblObservatiiDateClinica.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii);

        }

        public void Initializeaza(BClienti pClient)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.lClient = pClient;

            this.btnMedici.Tag = EnumOptiuneAfisare.Medici;
            this.btnCabinete.Tag = EnumOptiuneAfisare.Cabinete;

            initDateClinicaDinBDD();
            stabilestePanelDeAfisat(this.lOptiune);

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void BtnZonaAfisaj_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                EnumOptiuneAfisare optiune = (EnumOptiuneAfisare)(sender as ButtonPersonalizat).Tag;
                this.lOptiune = optiune;

                stabilestePanelDeAfisat(this.lOptiune);

                this.txtCauta.Focus();
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

        private void BtnActiviInactivi_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (this.lOptiune == EnumOptiuneAfisare.Medici)
                {
                    ConstruiesteRanduriDGVMedici();
                }
                else if (this.lOptiune == EnumOptiuneAfisare.Cabinete)
                {
                    ConstruiesteRanduriDGVCabinete();
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

        private void TxtCauta_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvLista.FiltreazaDupaText(this.txtCauta.Text);
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

        private void DgvLista_EditareLinie(CCL.UI.DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (this.lOptiune == EnumOptiuneAfisare.Medici)
                {
                    BClientiReprezentanti reprezentantDeModificat = this.dgvLista.Rows[pIndexRand].Tag as BClientiReprezentanti;

                    if (reprezentantDeModificat != null && !this.btnActiviInactivi.Selectat)
                    {
                        if (FormDetaliuReprezentant.Afiseaza(this.GetFormParinte(), reprezentantDeModificat, this.lClient))
                        {
                            incarcaRandMedic(this.dgvLista.Rows[pIndexRand], reprezentantDeModificat, BClientiComenzi.GetListByParam(this.lClient.Id, reprezentantDeModificat.Id, -1, CDefinitiiComune.EnumStare.Activa, null));
                        }
                    }
                }
                else
                {
                    BClientiCabinete cabinetDeModificat = this.dgvLista.Rows[pIndexRand].Tag as BClientiCabinete;

                    if (cabinetDeModificat != null && !this.btnActiviInactivi.Selectat)
                    {
                        if (FormDetaliuCabinet.Afiseaza(this.GetFormParinte(), this.lClient, cabinetDeModificat))
                        {
                            incarcaRand(this.dgvLista.Rows[pIndexRand], cabinetDeModificat, BClientiComenzi.GetListByParam(this.lClient.Id, -1, cabinetDeModificat.Id, CDefinitiiComune.EnumStare.Activa, null));
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

        private void DgvLista_StergereLinie(CCL.UI.DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (this.lOptiune == EnumOptiuneAfisare.Medici)
                {
                    BClientiReprezentanti reprezentantDeSters = pDGVSender.Rows[pIndexRand].Tag as BClientiReprezentanti;

                    if (reprezentantDeSters != null)
                    {

                        if (!this.btnActiviInactivi.Selectat)
                        {
                            if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), reprezentantDeSters.ToString()))
                            {
                                reprezentantDeSters.Close(true, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stergere), null);
                                ConstruiesteRanduriDGVMedici();
                            }
                        }
                        else
                        {
                            if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiReactivarea), reprezentantDeSters.ToString()))
                            {
                                reprezentantDeSters.Close(false, string.Empty, null);
                                ConstruiesteRanduriDGVMedici();
                            }
                        }
                    }
                }
                else if (this.lOptiune == EnumOptiuneAfisare.Cabinete)
                {
                    BClientiCabinete cabinetDeSters = this.dgvLista.Rows[pIndexRand].Tag as BClientiCabinete;

                    if (cabinetDeSters != null)
                    {
                        if (!this.btnActiviInactivi.Selectat)
                        {
                            if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), cabinetDeSters.Denumire))
                            {
                                cabinetDeSters.Close(true, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stergere), null);
                                ConstruiesteRanduriDGVCabinete();
                            }
                        }
                        else
                        {
                            if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiReactivarea), cabinetDeSters.Denumire))
                            {
                                cabinetDeSters.Close(false, string.Empty, null);
                                ConstruiesteRanduriDGVCabinete();
                            }
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

        private void BtnAdauga_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (this.lOptiune == EnumOptiuneAfisare.Medici)
                {
                    if (FormCreareReprezentant.Afiseaza(this.GetFormParinte(), this.lClient))
                        ConstruiesteRanduriDGVMedici();
                }
                else if (this.lOptiune == EnumOptiuneAfisare.Cabinete)
                {
                    string denumire = CCL.UI.IHMUtile.GetTextSimpluUtilizator(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire), string.Empty, BClientiCabinete.StructCampuriTabela.DenumireMaxLength);

                    if (!string.IsNullOrEmpty(denumire))
                    {
                        BClientiCabinete cabinetNou = BClientiCabinete.Add(this.lClient.Id, denumire, null);

                        FormDetaliuCabinet.Afiseaza(this.GetFormParinte(), this.lClient, cabinetNou);
                        ConstruiesteRanduriDGVCabinete();
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

        private void stabilestePanelDeAfisat(EnumOptiuneAfisare pOptiune)
        {
            if (pOptiune == EnumOptiuneAfisare.Medici)
            {
                initListaMedici();
            }
            else if (pOptiune == EnumOptiuneAfisare.Cabinete)
            {
                initListaCabinete();
            }
            this.btnMedici.Selectat = pOptiune == EnumOptiuneAfisare.Medici;
            this.btnCabinete.Selectat = pOptiune == EnumOptiuneAfisare.Cabinete;
        }

        private void initListaCabinete()
        {
            this.txtCauta.Goleste();
            this.btnActiviInactivi.Selectat = false;

            this.lblTitlu.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Cabinete);

            ConstruiesteColoaneDGVCabinete();
            ConstruiesteRanduriDGVCabinete();
        }

        private void initListaMedici()
        {
            this.txtCauta.Goleste();
            this.btnActiviInactivi.Selectat = false;

            this.lblTitlu.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Medic);

            ConstruiesteColoaneDGVMedici();
            ConstruiesteRanduriDGVMedici();
        }

        private void initDateClinicaDinBDD()
        {
            this.txtDenumire.Text = this.lClient.Denumire;
            this.txtTelefonMobil.Text = this.lClient.TelefonMobil;
            this.txtTelefonFix.Text = this.lClient.TelefonFix;
            this.txtEmail.Text = this.lClient.AdresaMail;
            this.txtWebsite.Text = this.lClient.PaginaWeb;
            if (this.lClient.IdRecomandant == 0)
                this.ctrlCautareRecomandant.Initializeaza(StructIdDenumire.Empty, CEnumerariComune.EnumTipDeschidere.DreaptaJos);
            else
                this.ctrlCautareRecomandant.Initializeaza(new StructIdDenumire(this.lClient.IdRecomandant, BListeParametrabile.getParametru(this.lClient.IdRecomandant, null).Denumire), CEnumerariComune.EnumTipDeschidere.DreaptaJos);
            this.txtObservatiiDateClinica.Text = this.lClient.ObservatiiDateClinica;

        }

        #region DGV Medici

        private void ConstruiesteColoaneDGVMedici()
        {
            this.dgvLista.IncepeConstructieColoane();

            this.dgvLista.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGVMedici.colNumePrenume.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Nume), 150, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoaneTelefonEmail(100);

            this.dgvLista.AdaugaColoanaData(EnumColoaneDGVMedici.colUltimaLucrare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.UltimaLucrare), 110, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA_ORA);

            this.dgvLista.AdaugaColoanaNumerica(EnumColoaneDGVMedici.colTotalLucrari.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TotalLucrari), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGVMedici.colObservatii.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvLista.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGVMedici()
        {
            var listaElem = BClientiReprezentanti.GetListByIdClient(lClient.Id, CDefinitiiComune.EnumStare.Toate, null);

            if (listaElem.ContineElementeDeactivate())
            {
                this.btnActiviInactivi.Visible = true;
            }
            else
            {
                this.btnActiviInactivi.Visible = false;
                this.btnActiviInactivi.Selectat = false;
            }


            if (!this.btnActiviInactivi.Selectat)
                ConstruiesteRanduriDGVMedici(listaElem.GetListaActive());
            else
                ConstruiesteRanduriDGVMedici(listaElem.GetListaInactive());
        }

        private void ConstruiesteRanduriDGVMedici(BColectieReprezentant pListaReprezentanti)
        {
            this.dgvLista.IncepeContructieRanduri();

            BColectieClientiComenzi listaComenzi = BClientiComenzi.GetListByParam(this.lClient.Id, -1, -1, CDefinitiiComune.EnumStare.Activa, null);

            foreach (var elem in pListaReprezentanti)
            {
                incarcaRandMedic(this.dgvLista.Rows[this.dgvLista.Rows.Add()], elem, listaComenzi.GetByIdMedic(elem.Id));
            }

            this.dgvLista.FinalizeazaContructieRanduri();

            this.lblTotal.Text = string.Format("{0}: {1}", BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Medici), this.dgvLista.RowCount.ToString());
        }

        private void incarcaRandMedic(DataGridViewRow pRand, BClientiReprezentanti pElem, BColectieClientiComenzi pListaLucrariMedic)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);
            pRand.Cells[EnumColoaneDGVMedici.colNumePrenume.ToString()].Value = pElem.GetIdentitateReprezentant();
            DataGridViewPersonalizat.InitCeluleTelefonEmail(pRand, pElem.TelefonMobil, pElem.AdresaMail);

            initColoaneUltimaLucrareSiTotal(pRand, pListaLucrariMedic);

            pRand.Cells[EnumColoaneDGVMedici.colObservatii.ToString()].Value = pElem.Observatii;
            DataGridViewPersonalizat.InitCelulaStergere(pRand);
        }

        #endregion

        private void initColoaneUltimaLucrareSiTotal(DataGridViewRow pRand, BColectieClientiComenzi pListaLucrari)
        {
            if (!CUtil.EsteListaVida<BClientiComenzi>(pListaLucrari))
            {
                BClientiComenzi ultimaComanda = pListaLucrari.GetUltimaByIdClient(this.lClient.Id);

                pRand.Cells[EnumColoaneDGVMedici.colUltimaLucrare.ToString()].Value = ultimaComanda.DataPrimire;
                pRand.Cells[EnumColoaneDGVMedici.colUltimaLucrare.ToString()].ToolTipText = ultimaComanda.ToString();
                pRand.Cells[EnumColoaneDGVMedici.colTotalLucrari.ToString()].Value = pListaLucrari.Count;
            }
        }

        #region DGV Cabinete

        private void ConstruiesteColoaneDGVCabinete()
        {
            this.dgvLista.IncepeConstructieColoane();

            this.dgvLista.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGVCabinete.colDenumire.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire), 130, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGVCabinete.colAdresa.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Adresa), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaData(EnumColoaneDGVCabinete.colUltimaLucrare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.UltimaLucrare), 130, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA_ORA);

            this.dgvLista.AdaugaColoanaNumerica(EnumColoaneDGVCabinete.colTotalLucrari.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TotalLucrari), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvLista.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGVCabinete()
        {
            var listaElem = BClientiCabinete.GetListByIdClient(this.lClient.Id, CDL.iStomaLab.CDefinitiiComune.EnumStare.Toate, null);

            if (listaElem.ContineElementeDeactivate())
            {
                this.btnActiviInactivi.Visible = true;
            }
            else
            {
                this.btnActiviInactivi.Visible = false;
                this.btnActiviInactivi.Selectat = false;
            }


            if (!this.btnActiviInactivi.Selectat)
                ConstruiesteRanduriDGVCabinete(listaElem.GetListaActive());
            else
                ConstruiesteRanduriDGVCabinete(listaElem.GetListaInactive());
        }

        private void ConstruiesteRanduriDGVCabinete(BColectieClientiCabinete pListaCabinete)
        {
            this.dgvLista.IncepeContructieRanduri();

            BColectieClientiComenzi listaComenzi = BClientiComenzi.GetListByParam(this.lClient.Id, -1, -1, CDefinitiiComune.EnumStare.Activa, null);

            foreach (var elem in pListaCabinete)
            {
                incarcaRand(this.dgvLista.Rows[this.dgvLista.Rows.Add()], elem, listaComenzi.GetByIdCabinet(elem.Id));
            }

            this.dgvLista.FinalizeazaContructieRanduri();

            this.lblTotal.Text = string.Format("{0}: {1}", BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Cabinete), this.dgvLista.RowCount.ToString());
        }

        private void incarcaRand(DataGridViewRow pRand, BClientiCabinete pElem, BColectieClientiComenzi pListaLucrariCabinet)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);
            pRand.Cells[EnumColoaneDGVCabinete.colDenumire.ToString()].Value = pElem.Denumire;
            pRand.Cells[EnumColoaneDGVCabinete.colAdresa.ToString()].Value = BAdrese.getAdresa(pElem.IdAdresa, null).ToString();

            initColoaneUltimaLucrareSiTotal(pRand, pListaLucrariCabinet);

            DataGridViewPersonalizat.InitCelulaStergere(pRand);
        }

        #endregion

        #endregion

        #region Metode publice

        internal void UpdateClinica()
        {
            if (!string.IsNullOrEmpty(this.txtDenumire.Text))
                this.lClient.Denumire = this.txtDenumire.Text;
            this.lClient.TelefonMobil = this.txtTelefonMobil.Text;
            this.lClient.TelefonFix = this.txtTelefonFix.Text;
            this.lClient.AdresaMail = this.txtEmail.Text;
            this.lClient.PaginaWeb = this.txtWebsite.Text;
            this.lClient.IdRecomandant = this.ctrlCautareRecomandant.IdObiectAfisajCorespunzator;
            this.lClient.TipRecomandant = this.ctrlCautareRecomandant.TipObiectAfisajCorespunzator;
            this.lClient.ObservatiiDateClinica = this.txtObservatiiDateClinica.Text;

            this.lClient.UpdateAll();
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
