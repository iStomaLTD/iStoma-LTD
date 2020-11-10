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
using BLL.iStomaLab.Reprezentanti;
using BLL.iStomaLab;
using CCL.UI;
using BLL.iStomaLab.Clienti;
using CDL.iStomaLab;

namespace iStomaLab.TablouDeBord.Clienti
{
    public partial class ControlDosarClientReprezentanti : UserControlPersonalizat
    {

        #region Declaratii generale
        
        private BClienti lClient = null;

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colNumePrenume,
            colTelefonMobil,
            colEmail,
            colUltimaComanda,
            colTotalComenzi,
            colObservatii
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlDosarClientReprezentanti()
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
            this.btnAdaugaReprezentant.Click += BtnAdaugaReprezentant_Click;
            this.dgvListaReprezentanti.StergereLinie += DgvListaReprezentanti_StergereLinie;
            this.dgvListaReprezentanti.EditareLinie += DgvListaReprezentanti_EditareLinie;
            this.txtCautaReprezentant.CerereUpdate += TxtCautaReprezentant_CerereUpdate;
        }

        private void initTextML()
        {
            this.lblReprezentanti.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Reprezentant);
        }

        public void Initializeaza(BClienti pClient)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();
            this.lClient = pClient;
            this.txtCautaReprezentant.Goleste();

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();
            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void TxtCautaReprezentant_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvListaReprezentanti.FiltreazaDupaText(this.txtCautaReprezentant.Text);
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

        private void DgvListaReprezentanti_EditareLinie(CCL.UI.DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BClientiReprezentanti reprezentantDeModificat = this.dgvListaReprezentanti.Rows[pIndexRand].Tag as BClientiReprezentanti;

                if (reprezentantDeModificat != null)
                {
                    if (FormDetaliuReprezentant.Afiseaza(this.GetFormParinte(), reprezentantDeModificat, this.lClient))
                    {
                        incarcaRand(this.dgvListaReprezentanti.Rows[pIndexRand], reprezentantDeModificat);
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

        private void DgvListaReprezentanti_StergereLinie(CCL.UI.DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BClientiReprezentanti reprezentantDeSters = this.dgvListaReprezentanti.Rows[pIndexRand].Tag as BClientiReprezentanti;

                if (reprezentantDeSters != null)
                {
                    if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), reprezentantDeSters.Nume.ToString() + " " + reprezentantDeSters.Prenume.ToString()))
                    {
                        reprezentantDeSters.Close(true, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stergere), null);
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

        private void BtnAdaugaReprezentant_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (FormDetaliuReprezentant.Afiseaza(this.GetFormParinte(), null, this.lClient))
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
            this.dgvListaReprezentanti.IncepeConstructieColoane();

            this.dgvListaReprezentanti.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.SelectieMultipla);
            this.dgvListaReprezentanti.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvListaReprezentanti.AdaugaColoanaText(EnumColoaneDGV.colNumePrenume.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Nume), 150, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaReprezentanti.AdaugaColoaneTelefonEmail();

            this.dgvListaReprezentanti.AdaugaColoanaData(EnumColoaneDGV.colUltimaComanda.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.UltimaComanda), 110, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);

            this.dgvListaReprezentanti.AdaugaColoanaNumerica(EnumColoaneDGV.colTotalComenzi.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TotalComenzi), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvListaReprezentanti.AdaugaColoanaText(EnumColoaneDGV.colObservatii.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaReprezentanti.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvListaReprezentanti.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaReprezentanti.IncepeContructieRanduri();
            
            var listaElem = BClientiReprezentanti.getById(lClient.Id,null);
            
            foreach (var elem in listaElem)
            {
                incarcaRand(this.dgvListaReprezentanti.Rows[this.dgvListaReprezentanti.Rows.Add()], elem);
            }

            this.dgvListaReprezentanti.FinalizeazaContructieRanduri();

            this.lblTotalReprezentanti.Text = "Total reprezentanti:" + this.dgvListaReprezentanti.RowCount.ToString();
        }

        private void incarcaRand(DataGridViewRow pRand, BClientiReprezentanti pElem)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);
            pRand.Cells[EnumColoaneDGV.colNumePrenume.ToString()].Value = pElem.Nume + " " + pElem.Prenume;
            DataGridViewPersonalizat.InitCeluleTelefonEmail(pRand, pElem.TelefonMobil, pElem.AdresaMail);

            var lstComenziReprezentanti = BClientiComenzi.getByIdReprezentant(this.lClient.Id, pElem.Id, null);
            if (lstComenziReprezentanti.Count != 0)
                pRand.Cells[EnumColoaneDGV.colUltimaComanda.ToString()].Value = lstComenziReprezentanti[lstComenziReprezentanti.Count - 1].DataPrimire;
            pRand.Cells[EnumColoaneDGV.colTotalComenzi.ToString()].Value = BClientiComenzi.GetListByParamIdClientReprezentant(this.lClient.Id, pElem.Id, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null).Count;
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
            this.dgvListaReprezentanti.AllowModification(this.lEcranInModificare);
            this.txtCautaReprezentant.AllowModification(this.lEcranInModificare);
            this.btnAdaugaReprezentant.AllowModification(this.lEcranInModificare);
        }

        #endregion


    }
}
