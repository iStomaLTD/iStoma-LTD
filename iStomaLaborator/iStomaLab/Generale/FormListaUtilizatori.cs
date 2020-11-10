using BLL.iStomaLab;
using BLL.iStomaLab.Utilizatori;
using CCL.UI;
using CCL.UI.FormulareComune;
using CDL.iStomaLab;
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
    public partial class FormListaUtilizatori : frmCuHeaderSiValidare
    {

        #region Declaratii generale

        private BUtilizator lUtilizator = null;
        private CDefinitiiComune.EnumRol lRol = CDefinitiiComune.EnumRol.Nedefinit;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormListaUtilizatori()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                adaugaHandlere();
                initTextML();
                this.PermiteDeplasareaEcranului = true;
                this.CenterToScreen();
            }
        }

        private FormListaUtilizatori(CDefinitiiComune.EnumRol pRol)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lRol = pRol;

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                adaugaHandlere();
                initTextML();
                this.PermiteDeplasareaEcranului = true;
                this.CenterToScreen();
            }
        }

        private void adaugaHandlere()
        {
            this.Load += _Load;
            this.btnValidare.Click += BtnValidare_Click;
            this.txtCautaUtilizator.CerereUpdate += TxtCautaUtilizator_CerereUpdate;
            this.dgvListaUtilizatori.SelectieUnicaEfectuata += DgvListaUtilizatori_SelectieUnicaEfectuata;
        }

        private void initTextML()
        {
            this.Text = string.Empty;
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
            incepeIncarcarea();

            this.txtCautaUtilizator.Focus();
            this.txtCautaUtilizator.Goleste();

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV(this.lRol);

            this.dgvListaUtilizatori.AscundeHeader();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void DgvListaUtilizatori_SelectieUnicaEfectuata(object sender, DataGridViewCellEventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BUtilizator utilizator = this.dgvListaUtilizatori.Rows[this.dgvListaUtilizatori.CurrentCell.RowIndex].Tag as BUtilizator;

                if (utilizator != null)
                {
                    this.lUtilizator = utilizator;
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

        private void TxtCautaUtilizator_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvListaUtilizatori.FiltreazaDupaText(this.txtCautaUtilizator.Text);
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

        private void BtnValidare_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BUtilizator utilizator = this.dgvListaUtilizatori.Rows[this.dgvListaUtilizatori.CurrentCell.RowIndex].Tag as BUtilizator;

                if (utilizator != null)
                {
                    this.lUtilizator = utilizator;
                    this.inchideEcranulOK();
                }
                else
                {
                    Mesaj.Informare(this, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.SelectatiTehnicianul), string.Empty);
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

        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaUtilizatori.IncepeConstructieColoane();

            this.dgvListaUtilizatori.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.SelectieUnica);

            this.dgvListaUtilizatori.AdaugaColoanaText(null, null, 0, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaUtilizatori.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV(CDefinitiiComune.EnumRol pTipUtilizator)
        {
            this.dgvListaUtilizatori.IncepeContructieRanduri();

            var listaElem = BUtilizator.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, pTipUtilizator, null);

            foreach (var elem in listaElem)
            {
                incarcaRand(this.dgvListaUtilizatori.Rows[this.dgvListaUtilizatori.Rows.Add()], elem);
            }

            this.dgvListaUtilizatori.FinalizeazaContructieRanduri();

        }

        private void incarcaRand(DataGridViewRow pRand, BUtilizator pElem)
        {
            pRand.Tag = pElem;
            DataGridViewPersonalizat.InitCelulaSelectieUnica(pRand, true);
            pRand.Cells[1].Value = pElem.GetNumeCompletUtilizator();
        }

        #endregion

        #region Metode publice

        public static BUtilizator Afiseaza(Form pEcranPariente, CDefinitiiComune.EnumRol pRol)
        {
            return Caramizi.frmListaObiecte<BUtilizator>.Afiseaza<BUtilizator>(pEcranPariente, BUtilizator.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, pRol, null), string.Empty, CDL.iStomaLab.CDefinitiiComune.EnumTipSelectie.SelectieUnica);

            //using (FormListaUtilizatori ecran = new FormListaUtilizatori(pRol))
            //{

            //    if (CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran))
            //        return ecran.lUtilizator;
            //}
            //return null;
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            //this.lEcranInModificare = pPermiteModificarea;
        }

        #endregion


    }
}
