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
using BLL.iStomaLab.Clienti;
using CCL.UI;
using BLL.iStomaLab;
using System.IO;
using CCL.iStomaLab;
using CDL.iStomaLab;

namespace iStomaLab.TablouDeBord.Clienti
{
    public partial class ControlListaClienti : UserControlPersonalizat
    {

        #region Declaratii generale


        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colDenumire,
            colDenumireFiscala,
            colCUI,
            colRegCom,
            colEmail,
            colPaginaWeb,
            colTelefonMobil,
            colTelefonFix,
            colFax,
            colSkype,
            colObservatii,
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlListaClienti()
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
            this.btnAdaugaClient.Click += BtnAdaugaClient_Click;
            this.dgvListaClienti.StergereLinie += DgvListaClienti_StergereLinie;
            this.dgvListaClienti.EditareLinie += DgvListaClienti_EditareLinie;
            this.txtCautareClient.CerereUpdate += TxtCautareClient_CerereUpdate;
            this.btnActiviInactivi.Click += BtnActiviInactivi_Click;
            this.btnImporta.Click += BtnImporta_Click;
        }

        private void initTextML()
        {
            this.lblTitluListaClienti.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Clinica);
            this.btnImporta.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Importa);
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.btnOptiuni.Initializeaza(this.panelOptiuni1);
            this.btnInchidePanelOptiuni.Initializeaza(this.panelOptiuni1);
            this.panelOptiuni1.Initializeaza();
            this.btnImporta.Initializeaza(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Importa));

            this.txtCautareClient.Goleste();
            this.btnActiviInactivi.Selectat = false;

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void BtnImporta_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                System.IO.FileInfo fisier = IHMUtile.GetFisierUnic(this.GetFormParinte());

                if (fisier != null)
                {
                    List<StructImportClienti> listaClienti = new List<StructImportClienti>();
                    using (StreamReader sr = new StreamReader(fisier.FullName))
                    {
                        string currentLine;
                        // currentLine will be null when the StreamReader reaches the end of file
                        while ((currentLine = sr.ReadLine()) != null)
                        {
                            // Search, case insensitive, if the currentLine contains the searched keyword
                            if (currentLine.IndexOf(",", StringComparison.CurrentCultureIgnoreCase) >= 0)
                            {
                                string[] dateLinie = currentLine.Split(new string[] { "," }, StringSplitOptions.None);

                                if (dateLinie.Length > 1)
                                    listaClienti.Add(new StructImportClienti(dateLinie));
                            }
                        }
                    }

                    if (CUtil.EsteListaVida<StructImportClienti>(listaClienti))
                    {
                        CCL.UI.Mesaj.Eroare(this.GetFormParinte(), "Eroare");
                    }
                    else
                    {
                        if (FormImportaClienti.Afiseaza(this.GetFormParinte(), listaClienti))
                        {
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

        private void BtnActiviInactivi_Click(object sender, EventArgs e)
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

        private void TxtCautareClient_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvListaClienti.FiltreazaDupaText(this.txtCautareClient.Text);
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

        private void DgvListaClienti_EditareLinie(CCL.UI.DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BClienti clientDeModificat = this.dgvListaClienti.Rows[pIndexRand].Tag as BClienti;

                if (clientDeModificat != null)
                {
                    if (TablouDeBord.Clienti.FormDosarClient.Afiseaza(this.GetFormParinte(), clientDeModificat))
                    {
                        incarcaRand(this.dgvListaClienti.Rows[pIndexRand], clientDeModificat, BClientiComenzi.GetUltimaLucrare(clientDeModificat.Id, null));
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

        private void DgvListaClienti_StergereLinie(CCL.UI.DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BClienti clientDeSters = this.dgvListaClienti.Rows[pIndexRand].Tag as BClienti;

                if (clientDeSters != null)
                {
                    if (!this.btnActiviInactivi.Selectat)
                    {
                        if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), clientDeSters.Denumire))
                        {
                            clientDeSters.Close(true, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stergere), null);
                            ConstruiesteRanduriDGV();
                        }
                    }
                    else
                    {
                        if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiReactivarea), clientDeSters.Denumire))
                        {
                            clientDeSters.Close(false, string.Empty, null);
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

        private void BtnAdaugaClient_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (FormCreareClient.Afiseaza(this.GetFormParinte()))
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

        #endregion

        #region Metode private

        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaClienti.IncepeConstructieColoane();

            this.dgvListaClienti.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvListaClienti.AdaugaColoanaText(EnumColoaneDGV.colDenumire.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaClienti.AdaugaColoanaText(EnumColoaneDGV.colDenumireFiscala.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DenumireFiscala), 150, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaClienti.AdaugaColoanaText(EnumColoaneDGV.colCUI.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CUI), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaClienti.AdaugaColoaneTelefonEmail();

            this.dgvListaClienti.AdaugaColoanaText(EnumColoaneDGV.colTelefonFix.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TelefonFix), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaClienti.AdaugaColoanaText(EnumColoaneDGV.colObservatii.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii), 100, true, DataGridViewColumnSortMode.Automatic);

            IHMUtile.AdaugaColoanaUltimaLucrare(this.dgvListaClienti);

            this.dgvListaClienti.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvListaClienti.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            var listaElem = BClienti.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Toate, null);

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
                ConstruiesteRanduriDGV(listaElem.GetListaActive());
            else
                ConstruiesteRanduriDGV(listaElem.GetListaInactive());
        }

        private void ConstruiesteRanduriDGV(BColectieClienti pListaClienti)
        {
            this.dgvListaClienti.IncepeContructieRanduri();

            BColectieClientiComenzi listaUltimelorLucrari = BClientiComenzi.GetUltimeleLucrariPerClinica(null);

            foreach (var elem in pListaClienti)
            {
                incarcaRand(this.dgvListaClienti.Rows[this.dgvListaClienti.Rows.Add()], elem, listaUltimelorLucrari.GetUltimaByIdClient(elem.Id));
            }

            this.dgvListaClienti.FinalizeazaContructieRanduri();

            this.lblTotalClienti.Text = string.Format("{0}: {1}", BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Clienti), this.dgvListaClienti.RowCount.ToString());
        }

        private void incarcaRand(DataGridViewRow pRand, BClienti pElem, BClientiComenzi pUltimaLucrare)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);
            pRand.Cells[EnumColoaneDGV.colDenumire.ToString()].Value = pElem.Denumire;
            pRand.Cells[EnumColoaneDGV.colDenumireFiscala.ToString()].Value = pElem.DenumireFiscala;
            pRand.Cells[EnumColoaneDGV.colCUI.ToString()].Value = pElem.CUI;
            DataGridViewPersonalizat.InitCeluleTelefonEmail(pRand, pElem.TelefonMobil, pElem.AdresaMail);
            pRand.Cells[EnumColoaneDGV.colTelefonFix.ToString()].Value = pElem.TelefonFix;
            pRand.Cells[EnumColoaneDGV.colObservatii.ToString()].Value = pElem.ObservatiiDateClinica;

            IHMUtile.IncarcaRandUltimaLucrare(pRand, pUltimaLucrare, EnumColoaneDGV.colDenumire.ToString());
                      
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
