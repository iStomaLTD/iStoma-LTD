using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;
using CCL.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iStomaLab.Generale
{
    public partial class FormListaClinici : FormPersonalizat
    {

        #region Declaratii generale

        private BClienti lClient = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormListaClinici()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {

                adaugaHandlere();
                initTextML();

                this.AcceptButton = this.ctrlValidareAnulare.ButonValidare;

                this.CentratCuDeplasare();
            }
        }

        private void adaugaHandlere()
        {
            this.Load += _Load;
            this.txtCautaClinica.CerereUpdate += TxtCautaClinica_CerereUpdate;
            this.txtCautaClinica.RandulUrmator += TxtCautaClinica_RandulUrmator;
            this.dgvListaClinici.CellClick += DgvListaClinici_CellClick;

            this.ctrlValidareAnulare.Validare += CtrlValidareAnulare_Validare;
        }

        private void initTextML()
        {
            this.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Clinici);
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

            this.txtCautaClinica.Goleste();

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            this.dgvListaClinici.AscundeHeader();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void CtrlValidareAnulare_Validare(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if(this.dgvListaClinici.SelectedRow != null)
                {
                    this.lClient = this.dgvListaClinici.SelectedRow.Tag as BClienti;
                }

                inchideEcranulCancel();
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

        private void TxtCautaClinica_RandulUrmator(object sender, EventArgs e)
        {
            DataGridViewRow randSelectat = this.dgvListaClinici.SelectedRow;
            if (randSelectat != null)
            {
                //Trecem la urmatorul rand vizibil, daca exista
                for (int i = randSelectat.Index + 1; i < this.dgvListaClinici.Rows.Count; i++)
                {
                    if(this.dgvListaClinici.Rows[i].Visible)
                    {
                        this.dgvListaClinici.Rows[i].Selected = true;
                        break;
                    }
                }
            }
            else
            {
                //selectam primul rand vizibil
                foreach (DataGridViewRow rand in this.dgvListaClinici.Rows)
                {
                    if (rand.Visible)
                    {
                        rand.Selected = true;
                        break;
                    }
                }
            }
        }

        private void DgvListaClinici_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.lSeIncarca || e.RowIndex < 0) return;
            try
            {
                incepeIncarcarea();

                BClienti client = this.dgvListaClinici.Rows[this.dgvListaClinici.CurrentCell.RowIndex].Tag as BClienti;

                if (client != null)
                {
                    this.lClient = client;
                    this.inchideEcranulOK();

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

        private void TxtCautaClinica_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvListaClinici.FiltreazaDupaText(this.txtCautaClinica.Text);
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
            this.dgvListaClinici.IncepeConstructieColoane();

            this.dgvListaClinici.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.SelectieUnica);

            this.dgvListaClinici.AdaugaColoanaText(null, null, 0, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaClinici.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaClinici.IncepeContructieRanduri();

            var listaElem = BClienti.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

            foreach (var elem in listaElem)
            {
                incarcaRand(this.dgvListaClinici.Rows[this.dgvListaClinici.Rows.Add()], elem);
            }

            this.dgvListaClinici.FinalizeazaContructieRanduri();

        }

        private void incarcaRand(DataGridViewRow pRand, BClienti pElem)
        {
            pRand.Tag = pElem;
            DataGridViewPersonalizat.InitCelulaSelectieUnica(pRand, true);
            pRand.Cells[1].Value = pElem.Denumire;
        }

        #endregion

        #region Metode publice

        public static BClienti Afiseaza(Form pEcranPariente)
        {
            return Caramizi.frmListaObiecte<BClienti>.Afiseaza<BClienti>(pEcranPariente, BClienti.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null), string.Empty, CDL.iStomaLab.CDefinitiiComune.EnumTipSelectie.SelectieUnica);

            //using (FormListaClinici ecran = new FormListaClinici())
            //{
            //    ecran.AplicaPreferinteleUtilizatorului();
            //    CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);

            //    return ecran.lClient;
            //}

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
