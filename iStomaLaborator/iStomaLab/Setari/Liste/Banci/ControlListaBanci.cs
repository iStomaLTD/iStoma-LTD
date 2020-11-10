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
using BLL.iStomaLab.Referinta;
using BLL.iStomaLab;
using CCL.UI;

namespace iStomaLab.Setari.Liste.Banci
{
    public partial class ControlListaBanci : UserControlPersonalizat
    {

        #region Declaratii generale
        

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colDenumire,
            colInformatiiComplementare
        }
        
        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlListaBanci()
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
            this.btnAdaugaBanca.Click += BtnAdaugaBanca_Click;
            this.txtCautareBanca.CerereUpdate += TxtCautareBanca_CerereUpdate;
            this.dgvListaBanci.EditareLinie += DgvListaBanci_EditareLinie;
            this.dgvListaBanci.StergereLinie += DgvListaBanci_StergereLinie;
            this.btnActivInactiv.Click += BtnActivInactiv_Click;
        }

        private void initTextML()
        {
            this.lblBanci.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Banci);
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.txtCautareBanca.Goleste();
            this.btnActivInactiv.Selectat = false;

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void BtnAdaugaBanca_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (FormDetaliiBanca.Afiseaza(this.GetFormParinte(), null))
                {
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

        private void TxtCautareBanca_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvListaBanci.FiltreazaDupaText(this.txtCautareBanca.Text);
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

        private void DgvListaBanci_EditareLinie(CCL.UI.DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BBanci bancaDeModificat = this.dgvListaBanci.Rows[pIndexRand].Tag as BBanci;

                if (bancaDeModificat != null && !this.btnActivInactiv.Selectat)
                {
                    if (FormDetaliiBanca.Afiseaza(this.GetFormParinte(), bancaDeModificat))
                    {
                        incarcaRand(this.dgvListaBanci.Rows[pIndexRand], bancaDeModificat);
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

        private void DgvListaBanci_StergereLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BBanci bancaDeSters = this.dgvListaBanci.Rows[pIndexRand].Tag as BBanci;

                if (bancaDeSters != null)
                {
                    if (!this.btnActivInactiv.Selectat)
                    {
                        if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), bancaDeSters.Denumire))
                        {
                            bancaDeSters.Close(true, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stergere), null);
                            ConstruiesteRanduriDGV();
                        }
                    }
                    else
                    {
                        if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiReactivarea), bancaDeSters.Denumire))
                        {
                            bancaDeSters.Close(false, string.Empty, null);
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

        private void BtnActivInactiv_Click(object sender, EventArgs e)
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

        #endregion

        #region Metode private

        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaBanci.IncepeConstructieColoane();

            this.dgvListaBanci.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvListaBanci.AdaugaColoanaText(EnumColoaneDGV.colDenumire.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tara), 200, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaBanci.AdaugaColoanaText(EnumColoaneDGV.colInformatiiComplementare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NumeOficial), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaBanci.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvListaBanci.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            var listaElem = BBanci.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Toate, null);

            if(listaElem.ContineElementeDeactivate())
            {
                this.btnActivInactiv.Visible = true;
            }
            else
            {
                this.btnActivInactiv.Visible = false;
                this.btnActivInactiv.Selectat = false;
            }


            if (!this.btnActivInactiv.Selectat)
                ConstruiesteRanduriDGV(listaElem.GetListaActive());
            else
                ConstruiesteRanduriDGV(listaElem.GetListaInactive());
        }

        private void ConstruiesteRanduriDGV(BColectieBanci pListaBanci)
        {
            this.dgvListaBanci.IncepeContructieRanduri();

            foreach (var elem in pListaBanci)
            {
                incarcaRand(this.dgvListaBanci.Rows[this.dgvListaBanci.Rows.Add()], elem);
            }

            this.dgvListaBanci.FinalizeazaContructieRanduri();

            this.lblNrBanci.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Total) + this.dgvListaBanci.RowCount.ToString();
        }

        private void incarcaRand(DataGridViewRow pRand, BBanci pElem)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);
            pRand.Cells[EnumColoaneDGV.colDenumire.ToString()].Value = pElem.Denumire;
            pRand.Cells[EnumColoaneDGV.colInformatiiComplementare.ToString()].Value = pElem.InformatiiComplementare;
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
