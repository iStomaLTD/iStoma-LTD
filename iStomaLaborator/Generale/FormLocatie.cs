using BLL.iStomaLab;
using BLL.iStomaLab.Referinta;
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
    public partial class FormLocatie : FormPersonalizat
    {

        #region Declaratii generale

        public static BRegiuni _SRegiune = null;
        public static BTari _STara = null;
        public static BLocalitati _SLocalitate = null;
        private EnumTipLista lTipLista = EnumTipLista.Tara;

        #endregion

        #region Enumerari si Structuri

        enum EnumTipLista
        {
            Tara = 0,
            Regiune = 1,
            Localitate = 2
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormLocatie(BRegiuni pRegiune, BTari pTara, BLocalitati pLocalitate)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            _SRegiune = pRegiune;
            _STara = pTara;
            _SLocalitate = pLocalitate;

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {

                adaugaHandlere();
                initTextML();

                this.CentratCuDeplasare();
            }
        }

        private void adaugaHandlere()
        {
            this.Load += _Load;
            this.txtTara.TextChanged += Txt_TextChanged;
            this.txtRegiune.TextChanged += Txt_TextChanged;
            this.txtLocalitate.TextChanged += Txt_TextChanged;
            
        }

        private void initTextML()
        {
            this.Text = string.Empty;
            this.lblNationalitate.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Nationalitate);
            this.lblRegiune.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Regiune);
            this.lblLocalitate.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Localitate);
            this.lblTara.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tara);
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

            this.txtTara.Tag = EnumTipLista.Tara;
            this.txtRegiune.Tag = EnumTipLista.Regiune;
            this.txtLocalitate.Tag = EnumTipLista.Localitate;


            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void Txt_TextChanged(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                EnumTipLista tipLista = (EnumTipLista)(sender as TextBoxPersonalizat).Tag;

                afiseazaDGV(tipLista);
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

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Enter)
            {
                MessageBox.Show(this.dgvListaLocatii.SelectedRow.Tag.ToString());
            }
            else if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.dgvListaLocatii.Visible = false;
            }
            return base.ProcessDialogKey(keyData);
        }

        #endregion

        #region Metode private

        private void afiseazaDGV(EnumTipLista pTipLista)
        {
            this.lTipLista = pTipLista;

            this.dgvListaLocatii.ColumnHeadersVisible = false;

            ConstruiesteColoaneDGV();

            switch (pTipLista)
            {
                case EnumTipLista.Tara:
                    ConstruiesteRanduriDGVTari();
                    break;
            }
        }

        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaLocatii.Visible = true;
            this.dgvListaLocatii.BringToFront();

            this.dgvListaLocatii.IncepeConstructieColoane();

            this.dgvListaLocatii.AdaugaColoanaText(null, null, 0, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaLocatii.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGVTari()
        {
            this.dgvListaLocatii.IncepeContructieRanduri();

            var listaElem = BTari.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

            foreach (var elem in listaElem)
            {
                incarcaRandTara(this.dgvListaLocatii.Rows[this.dgvListaLocatii.Rows.Add()], elem);
            }

            this.dgvListaLocatii.FinalizeazaContructieRanduri();

        }

        private void incarcaRandTara(DataGridViewRow pRand, BTari pElem)
        {
            pRand.Tag = pElem;
            pRand.Cells[0].Value = pElem.NumeScurt;
        }

        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente, BRegiuni pRegiune, BTari pTara, BLocalitati pLocalitate, int x, int y)
        {
            using (FormLocatie ecran = new FormLocatie(pRegiune, pTara, pLocalitate))
            {
                ecran.Location = new Point(x, y);
                return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
            }
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
