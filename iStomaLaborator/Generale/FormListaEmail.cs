using BLL.iStomaLab;
using BLL.iStomaLab.Email;
using CCL.UI.FormulareComune;
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
    public partial class FormListaEmail : frmCuHeaderSiValidare
    {

        #region Declaratii generale

        public static BEmail _SEmail = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormListaEmail()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {

                adaugaHandlere();
                initTextML();

                this.PermiteDeplasareaEcranului = true;
            }
        }

        private void adaugaHandlere()
        {
            this.Load += _Load;
            this.btnValidare.Click += BtnValidare_Click;
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

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            this.dgvListaEmail.AscundeHeader();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void BtnValidare_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BEmail email = this.dgvListaEmail.Rows[this.dgvListaEmail.CurrentCell.RowIndex].Tag as BEmail;

                if (email != null)
                {
                    _SEmail = email;
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
            this.dgvListaEmail.IncepeConstructieColoane();

            this.dgvListaEmail.AdaugaColoanaText(null, null, 0, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaEmail.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaEmail.IncepeContructieRanduri();

            var listaElem = BEmail.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

            foreach (var elem in listaElem)
            {
                incarcaRand(this.dgvListaEmail.Rows[this.dgvListaEmail.Rows.Add()], elem);
            }

            this.dgvListaEmail.FinalizeazaContructieRanduri();

        }

        private void incarcaRand(DataGridViewRow pRand, BEmail pElem)
        {
            pRand.Tag = pElem;
            pRand.Cells[0].Value = pElem.AdresaMail;
        }

        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente, int x, int y)
        {
            using (FormListaEmail ecran = new FormListaEmail())
            {
                ecran.Location = new Point(x, y);
                return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
            }
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {

        }

        #endregion


    }
}
