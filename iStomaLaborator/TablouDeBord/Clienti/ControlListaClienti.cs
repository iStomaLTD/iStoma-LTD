﻿using System;
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
            colObservatii
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
        }
        
        private void initTextML()
        {
            this.lblTitluListaClienti.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Client);
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.txtCautareClient.Goleste();

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

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
                    if (TablouDeBord.Clienti.FormDosarClient.Afiseaza(this.GetFormParinte(),clientDeModificat))
                    {
                        incarcaRand(this.dgvListaClienti.Rows[pIndexRand], clientDeModificat);
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
                    if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), clientDeSters.Denumire.ToString()))
                    {
                        clientDeSters.Close(true, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stergere), null);
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

        private void BtnAdaugaClient_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (FormDetaliuClient.Afiseaza(this.GetFormParinte(), null))
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

            this.dgvListaClienti.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvListaClienti.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaClienti.IncepeContructieRanduri();

            var listaElem = BClienti.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);
            
            foreach (var elem in listaElem)
            {
                incarcaRand(this.dgvListaClienti.Rows[this.dgvListaClienti.Rows.Add()], elem);
            }

            this.dgvListaClienti.FinalizeazaContructieRanduri();

            this.lblTotalClienti.Text ="Total clienti:"+ this.dgvListaClienti.RowCount.ToString();
        }

        private void incarcaRand(DataGridViewRow pRand, BClienti pElem)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);
            pRand.Cells[EnumColoaneDGV.colDenumire.ToString()].Value = pElem.Denumire;
            pRand.Cells[EnumColoaneDGV.colDenumireFiscala.ToString()].Value = pElem.DenumireFiscala;
            pRand.Cells[EnumColoaneDGV.colCUI.ToString()].Value = pElem.CUI;
            DataGridViewPersonalizat.InitCeluleTelefonEmail(pRand, pElem.TelefonMobil, pElem.AdresaMail);
            pRand.Cells[EnumColoaneDGV.colTelefonFix.ToString()].Value = pElem.TelefonFix;
            pRand.Cells[EnumColoaneDGV.colObservatii.ToString()].Value = pElem.Observatii;
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
