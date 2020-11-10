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
using BLL.iStomaLab.Clienti;
using iStomaLab.TablouDeBord.Clienti;

namespace iStomaLab.Setari.Liste.Pacienti
{
    public partial class ControlListaPacienti : UserControlPersonalizat
    {

        #region Declaratii generale

            private BClienti lClient = null;
            private BClientiPacienti lPacient = null;
            int IdClient =0;
            int IdPacient = 0;
        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colDenumirePacient,
            colData,
            colTelefonMobil,
            colEmail,
            colEditare,
            colSterge,
        }
        
        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlListaPacienti(BClienti pClient)
        {
            this.lClient = pClient;
            IdClient = this.lClient.Id;

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
            this.Load += _Load;
            this.btnAdaugaPacienti.Click += BtnAdaugaPacienti_Click;
            this.txtCautarePacienti.CerereUpdate += TxtCautareBanca_CerereUpdate;
            this.dgvListaPacienti.EditareLinie += DgvListaPacienti_EditareLinie;
            this.dgvListaPacienti.StergereLinie += DgvListaPacienti_StergereLinie;
            this.btnActivInactiv.Click += BtnActivInactiv_Click; 
            this.txtCautarePacienti.RandulUrmator += TxtCautarePacienti_RandulUrmator;
           this.dgvListaPacienti.CellClick += DgvListaPacienti_CellClick;          
        }

        private void initTextML()
        {
            this.lblPacienti.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pacient);
            this.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pacient);
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

        private void DgvListaPacienti_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BClientiPacienti pacient = this.dgvListaPacienti.Rows[this.dgvListaPacienti.CurrentCell.RowIndex].Tag as BClientiPacienti;

                if (pacient != null)
                {
                    this.lPacient = pacient;
                    IdPacient = this.lPacient.Id;

                    //Recunoastere formular parinte
                    FormCuPacienti formCuPacienti = (this.GetFormParinte() as FormCuPacienti);
                    formCuPacienti.pPacient = pacient;
                    formCuPacienti.InchideEcranul();      
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
        
        private void TxtCautarePacienti_RandulUrmator(object sender, EventArgs e)
        {
            DataGridViewRow randSelectat = this.dgvListaPacienti.SelectedRow;
            if (randSelectat != null)
            {
                //Trecem la urmatorul rand vizibil, daca exista
                for (int i = randSelectat.Index + 1; i < this.dgvListaPacienti.Rows.Count; i++)
                {
                    if (this.dgvListaPacienti.Rows[i].Visible)
                    {
                        this.dgvListaPacienti.Rows[i].Selected = true;
                        break;
                    }
                }
            }
            else
            {
                //selectam primul rand vizibil
                foreach (DataGridViewRow rand in this.dgvListaPacienti.Rows)
                {
                    if (rand.Visible)
                    {
                        rand.Selected = true;
                        break;
                    }
                }
            }
        }

        public void Initializeaza()
        {
            this.Text = "Lista Pacienti";
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.txtCautarePacienti.Goleste();
            this.btnActivInactiv.Selectat = false;

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void TxtCautareBanca_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvListaPacienti.FiltreazaDupaText(this.txtCautarePacienti.Text);
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

        private void DgvListaPacienti_EditareLinie(CCL.UI.DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BClientiPacienti pacientDeModificat = this.dgvListaPacienti.Rows[pIndexRand].Tag as BClientiPacienti;

                if (pacientDeModificat != null && !this.btnActivInactiv.Selectat)
                {
                    int idPacModificat = pacientDeModificat.Id;
                    FormDetaliuPacient.Afiseaza(this.GetFormParinte(), IdClient, ref idPacModificat, string.Empty); 
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

        private void DgvListaPacienti_StergereLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BClientiPacienti pacientDeSters = this.dgvListaPacienti.Rows[pIndexRand].Tag as BClientiPacienti;
               
                if (pacientDeSters != null)
                {
                    string Denumire = pacientDeSters.GetIdentitateReprezentant();  //aici reprezentantul e pacient

                    if (!this.btnActivInactiv.Selectat)
                    {
                        if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), Denumire))
                        {
                            pacientDeSters.Close(true, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stergere), null);
                            ConstruiesteRanduriDGV();
                        }
                    }
                    else
                    {
                        if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiReactivarea), Denumire))
                        {
                            pacientDeSters.Close(false, string.Empty, null);
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
            this.dgvListaPacienti.IncepeConstructieColoane();

            this.dgvListaPacienti.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvListaPacienti.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.SelectieUnica);

            this.dgvListaPacienti.AdaugaColoanaText(EnumColoaneDGV.colDenumirePacient.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire), 10, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaPacienti.AdaugaColoanaText(EnumColoaneDGV.colData.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Data), 80, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaPacienti.AdaugaColoanaText(EnumColoaneDGV.colTelefonMobil.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TelefonMobil), 130, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaPacienti.AdaugaColoanaText(EnumColoaneDGV.colEmail.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Email), 150, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaPacienti.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvListaPacienti.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            var listaElem = BClientiPacienti.GetListByIdClient(IdClient, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

            if (listaElem.ContineElementeDeactivate())
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

        private void ConstruiesteRanduriDGV(BColectiePacienti pListaPacienti)
        {
            this.dgvListaPacienti.IncepeContructieRanduri();

            foreach (var elem in pListaPacienti)
            {
                BColectiePacienti pElemClient = BClientiPacienti.GetListByIdClient(elem.IdClient, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);
                incarcaRand(this.dgvListaPacienti.Rows[this.dgvListaPacienti.Rows.Add()], elem);
            }

            this.dgvListaPacienti.FinalizeazaContructieRanduri();

            this.lblNrPacienti.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Total) + this.dgvListaPacienti.RowCount.ToString();
        }

        private void incarcaRand(DataGridViewRow pRand, BClientiPacienti pElem)
        {
            pRand.Tag = pElem;
            string denumire= String.Concat(pElem.Nume, " ", pElem.Prenume);
            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);            
            DataGridViewPersonalizat.InitCelulaSelectieUnica(pRand, true);
            pRand.Cells[2].Value = denumire;
            pRand.Cells[3].Value = pElem.DataCreare;
            pRand.Cells[4].Value = pElem.TelefonMobil;
            pRand.Cells[5].Value = pElem.AdresaMail;
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

        private void CtrlValidareAnulare_Validare(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (this.dgvListaPacienti.SelectedRow != null)
                {
                    this.lPacient = this.dgvListaPacienti.SelectedRow.Tag as BClientiPacienti;
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

        private void BtnAdaugaPacienti_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();
                
                if (FormDetaliuPacient.Afiseaza(this.GetFormParinte(), IdClient, ref IdPacient, string.Empty))
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

    }
}
