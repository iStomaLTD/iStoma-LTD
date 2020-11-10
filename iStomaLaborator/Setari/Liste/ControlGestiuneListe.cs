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
using CDL.iStomaLab;
using BLL.iStomaLab.Referinta;
using CCL.UI;
using static CDL.iStomaLab.CDefinitiiComune;

namespace iStomaLab.Setari.Liste
{
    public partial class ControlGestiuneListe : UserControlPersonalizat
    {

        #region Declaratii generale

        private CDefinitiiComune.EnumTipLista lListaSelectata = CDefinitiiComune.EnumTipLista.Nespecificat;
        private Setari.Liste.ControlDetaliuLista lctrlListaProfesii = null;
        private Setari.Liste.Tari.ControlDetaliuListaTari lctrlListaTari = null;
        private Setari.Liste.Regiuni.ControlDetaliuListaRegiuni lctrlListaRegiuni = null;
        private Setari.Liste.Localitati.ControlDetaliuListaLocalitati lctrlListaLocalitati = null;
        private Setari.Liste.Categorii.ControlListaCategorii lctrlListaCategorii = null;
        private Setari.Liste.ListeParametrabile.ControlListaParametrabila lctrlListaParametrabila = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlGestiuneListe()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {

                adaugaHandlere();
                initTextML();
            }
            
            this.txtCautareListe.Goleste();

        }

        private void adaugaHandlere()
        {
            this.dgvListe.SelectionChanged += DgvListe_SelectionChanged;
            this.txtCautareListe.CerereUpdate += TxtCautareListe_CerereUpdate;
        }
        
        private void initTextML()
        {

        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.dgvListe.AscundeHeader();

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();
            
            finalizeazaIncarcarea();
        }


        #endregion

        #region Evenimente

        private void TxtCautareListe_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvListe.FiltreazaDupaText(this.txtCautareListe.Text);
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

        private void DgvListe_SelectionChanged(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BDefinitiiGenerale.StructLista lista = this.dgvListe.Rows[this.dgvListe.CurrentCell.RowIndex].Tag as BDefinitiiGenerale.StructLista;
                incarcaOptiuneaSelectata(BDefinitiiGenerale.StructLista.getListaByEnum(lista.Id).Id);

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

        private void incarcaOptiuneaSelectata(CDefinitiiComune.EnumTipLista pOptiune)
        {
            this.lListaSelectata = pOptiune;
            if (this.lctrlListaProfesii != null)
                this.lctrlListaProfesii.Visible = false;
            if (this.lctrlListaTari != null)
                this.lctrlListaTari.Visible = false;
            if (this.lctrlListaRegiuni != null)
                this.lctrlListaRegiuni.Visible = false;
            if (this.lctrlListaLocalitati != null)
                this.lctrlListaLocalitati.Visible = false;
            if (this.lctrlListaCategorii != null)
                this.lctrlListaCategorii.Visible = false;
            if (this.lctrlListaParametrabila != null)
                this.lctrlListaParametrabila.Visible = false;

            switch (pOptiune)
            {
                case CDefinitiiComune.EnumTipLista.ListaProfesii:
                    initControlListaProfesii();
                    break;
                case CDefinitiiComune.EnumTipLista.ListaTari:
                    initControlListaTari();
                    break;
                case CDefinitiiComune.EnumTipLista.ListaRegiuni:
                    initControlListaRegiuni();
                    break;
                case CDefinitiiComune.EnumTipLista.ListaLocalitati:
                    initControlListaLocalitati();
                    break;
                case CDefinitiiComune.EnumTipLista.ListaCategorii:
                    initControlListaCategorii();
                    break;
                case CDefinitiiComune.EnumTipLista.ListaParametrabila:
                    initControlListaParametrabila(EnumTipLista.AltePersoane);
                    break;
            }
        }

        private void initControlListaProfesii()
        {
            if (this.lctrlListaProfesii == null)
            {
                this.lctrlListaProfesii = new ControlDetaliuLista();
                this.lctrlListaProfesii.Name = "ctrlListaProfesii";
                adaugaControlInZonaUtila(this.lctrlListaProfesii);
            }

            this.lctrlListaProfesii.Initializeaza();
            this.lctrlListaProfesii.Visible = true;
            this.lctrlListaProfesii.BringToFront();
        }

        private void initControlListaTari()
        {
            if (this.lctrlListaTari == null)
            {
                this.lctrlListaTari = new Tari.ControlDetaliuListaTari();
                this.lctrlListaTari.Name = "ctrlListaTari";
                adaugaControlInZonaUtila(this.lctrlListaTari);
            }

            this.lctrlListaTari.Initializeaza();
            this.lctrlListaTari.Visible = true;
            this.lctrlListaTari.BringToFront();
        }

        private void initControlListaRegiuni()
        {
            if (this.lctrlListaRegiuni == null)
            {
                this.lctrlListaRegiuni = new Regiuni.ControlDetaliuListaRegiuni();
                this.lctrlListaRegiuni.Name = "ctrlListaRegiuni";
                adaugaControlInZonaUtila(this.lctrlListaRegiuni);
            }

            this.lctrlListaRegiuni.Initializeaza();
            this.lctrlListaRegiuni.Visible = true;
            this.lctrlListaRegiuni.BringToFront();
        }

        private void initControlListaLocalitati()
        {
            if (this.lctrlListaLocalitati == null)
            {
                this.lctrlListaLocalitati = new Localitati.ControlDetaliuListaLocalitati();
                this.lctrlListaLocalitati.Name = "ctrlListaLocalitati";
                adaugaControlInZonaUtila(this.lctrlListaLocalitati);
            }

            this.lctrlListaLocalitati.Initializeaza();
            this.lctrlListaLocalitati.Visible = true;
            this.lctrlListaLocalitati.BringToFront();
        }

        private void initControlListaCategorii()
        {
            if (this.lctrlListaCategorii == null)
            {
                this.lctrlListaCategorii = new Categorii.ControlListaCategorii();
                this.lctrlListaCategorii.Name = "ctrlListaCategorii";
                adaugaControlInZonaUtila(this.lctrlListaCategorii);
            }

            this.lctrlListaCategorii.Initializeaza();
            this.lctrlListaCategorii.Visible = true;
            this.lctrlListaCategorii.BringToFront();
        }

        private void initControlListaParametrabila(EnumTipLista pTipLista)
        {
            if (this.lctrlListaParametrabila == null)
            {
                this.lctrlListaParametrabila = new ListeParametrabile.ControlListaParametrabila();
                this.lctrlListaParametrabila.Name = "ctrlListaParametrabila";
                adaugaControlInZonaUtila(this.lctrlListaParametrabila);
            }

            this.lctrlListaParametrabila.Initializeaza(pTipLista);
            this.lctrlListaParametrabila.Visible = true;
            this.lctrlListaParametrabila.BringToFront();
        }

        private void adaugaControlInZonaUtila(Control pControl)
        {
            this.panelDetaliiLista.Controls.Add(pControl);
            pControl.Dock = DockStyle.Fill;
        }

        private void ConstruiesteColoaneDGV()
        {
            this.dgvListe.IncepeConstructieColoane();

            this.dgvListe.AdaugaColoanaText(null, null, 0, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListe.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListe.IncepeContructieRanduri();

            var listaElem = BDefinitiiGenerale.StructLista.getLista();

            foreach (var elem in listaElem)
            {
                incarcaRand(this.dgvListe.Rows[this.dgvListe.Rows.Add()], elem);
            }

            this.dgvListe.FinalizeazaContructieRanduri();

        }

        private void incarcaRand(DataGridViewRow pRand, BDefinitiiGenerale.StructLista pElem)
        {
            pRand.Tag = pElem;
            pRand.Cells[0].Value = pElem.TitluLung;

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
