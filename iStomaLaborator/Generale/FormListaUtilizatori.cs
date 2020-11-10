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

        public static BUtilizator _SUtilizator = null;
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
                if (BDefinitiiGenerale.StructRol.getStructByEnum(this.lRol).IdInt != 0)
                {
                    Initializeaza(this.lRol);
                }
                else
                {
                    Initializeaza();
                }
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
            ConstruiesteRanduriDGV();

            this.dgvListaUtilizatori.AscundeHeader();

            finalizeazaIncarcarea();
        }

        public void Initializeaza(CDefinitiiComune.EnumRol pRol)
        {
            incepeIncarcarea();

            this.txtCautaUtilizator.Focus();
            this.txtCautaUtilizator.Goleste();

            int idRol = BDefinitiiGenerale.StructRol.getStructByEnum(pRol).IdInt;

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV(idRol);

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
                    _SUtilizator = utilizator;
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
                    _SUtilizator = utilizator;
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

        #endregion

        #region Metode private

        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaUtilizatori.IncepeConstructieColoane();

            this.dgvListaUtilizatori.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.SelectieUnica);

            this.dgvListaUtilizatori.AdaugaColoanaText(null, null, 0, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaUtilizatori.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaUtilizatori.IncepeContructieRanduri();

            var listaElem = BUtilizator.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

            foreach (var elem in listaElem)
            {
                incarcaRand(this.dgvListaUtilizatori.Rows[this.dgvListaUtilizatori.Rows.Add()], elem);
            }

            this.dgvListaUtilizatori.FinalizeazaContructieRanduri();

        }

        private void ConstruiesteRanduriDGV(int pTipUtilizator)
        {
            this.dgvListaUtilizatori.IncepeContructieRanduri();

            var listaElem = BUtilizator.GetListByParamTipUtilizator(pTipUtilizator, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

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

        public static bool Afiseaza(Form pEcranPariente, int x, int y)
        {
            using (FormListaUtilizatori ecran = new FormListaUtilizatori())
            {
                ecran.Location = new Point(x, y);
                return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
            }
        }

        public static bool Afiseaza(Form pEcranPariente, CDefinitiiComune.EnumRol pRol, int x, int y)
        {
            using (FormListaUtilizatori ecran = new FormListaUtilizatori(pRol))
            {
                ecran.Location = new Point(x, y);
                return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
            }
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
