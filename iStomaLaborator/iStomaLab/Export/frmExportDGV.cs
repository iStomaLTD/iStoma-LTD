using BLL.iStomaLab;
using CCL.iStomaLab.Utile;
using CCL.UI;
using iStomaLab.Generale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iStomaLab.Export
{
    public partial class frmExportDGV : FormPersonalizat
    {

        #region Declaratii generale

        private DataGridViewPersonalizat lDGVImprimare = null;
        private string lNumeFisier = string.Empty;
        private bool lDeschideDupaCreare = true;
        private bool lCreeazaInThreadulPrincipal = false;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private frmExportDGV()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                this.lblColoane.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Coloane);
                this.lblSeparator.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Separator);
                this.btnDeselecteaza.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Deselecteaza);

                this.rbPunctVirgula.CheckedChanged += rbPunctVirgula_CheckedChanged;
                this.rbVirgula.CheckedChanged += rbVirgula_CheckedChanged;
                this.btnDeselecteaza.Click += BtnDeselecteaza_Click;
                this.rbCSV.CheckedChanged += RbCSV_CheckedChanged;
                this.rbExportExcel.CheckedChanged += RbExportExcel_CheckedChanged;
            }
        }

        private frmExportDGV(DataGridViewPersonalizat pDGVImprimare, string pNumeFisier, bool pDeschideDupaCreare, bool pCreeazaInThreadulPrincipal)
            : this()
        {
            this.lDGVImprimare = pDGVImprimare;
            this.lNumeFisier = pNumeFisier;
            this.lDeschideDupaCreare = pDeschideDupaCreare;
            this.lCreeazaInThreadulPrincipal = pCreeazaInThreadulPrincipal;

            this.Text = Convert.ToString(this.lDGVImprimare.Tag);

            this.CentratCuDeplasare();
            //this.lvColoane.AfisajVerticalCuOColoana();
        }

        private void frmImprimareDGV_Load(object sender, EventArgs e)
        {
            try
            {
                Initializeaza();
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        public void Initializeaza()
        {
            incepeIncarcarea();

            this.lvColoane.IncepeConstructieColoane();
            this.lvColoane.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.SelectieMultipla);
            this.lvColoane.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.Denumire);
            this.lvColoane.AscundeHeader();

            this.lvColoane.FinalizeazaConstructieColoane();

            this.lvColoane.IncepeContructieRanduri();

            //ListViewItem itemLV = null;
            DataGridViewRow rand = null;
            foreach (DataGridViewColumn coloana in this.lDGVImprimare.Columns)
            {
                if (!this.lDGVImprimare.SeIgnoraColoanaLaImprimare(coloana.Name))
                {
                    //itemLV = new ListViewItem(new[] { coloana.HeaderText });
                    ////itemLV.Text = coloana.HeaderText;
                    //itemLV.Tag = coloana.Name;
                    //itemLV.Checked = !string.IsNullOrEmpty(coloana.Name);
                    rand = this.lvColoane.AdaugaRandNou();
                    rand.Tag = coloana.Name;
                    rand.Cells[DataGridViewPersonalizat._Coloana_Denumire].Value = coloana.HeaderText;
                    rand.Cells[DataGridViewPersonalizat.lColoanaSelectieMultipla].Value = true;
                    //this.lvColoane.Items.Add(itemLV);
                }
            }

            this.lvColoane.FinalizeazaContructieRanduri();

            //Ce separator folosim pe acest calculator
            if (CGestiuneIO.GetSeparatorCSV().Equals(";"))
                this.rbPunctVirgula.Checked = true;
            else
                this.rbVirgula.Checked = true;

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void RbExportExcel_CheckedChanged(object sender, EventArgs e)
        {
            vizibilitateSeparatori();
        }

        private void RbCSV_CheckedChanged(object sender, EventArgs e)
        {
            vizibilitateSeparatori();
        }

        private void BtnDeselecteaza_Click(object sender, EventArgs e)
        {
            try
            {
                incepeIncarcarea();

                this.lvColoane.DebifeazaElementele();
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

        void rbVirgula_CheckedChanged(object sender, EventArgs e)
        {
            if (this.lSeIncarca || !this.rbVirgula.Checked) return;

            try
            {
                CGestiuneIO.SetSeparatorCSV(",");
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        void rbPunctVirgula_CheckedChanged(object sender, EventArgs e)
        {
            if (this.lSeIncarca || !this.rbPunctVirgula.Checked) return;

            try
            {
                CGestiuneIO.SetSeparatorCSV(";");
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        private void btnSus_Click(object sender, EventArgs e)
        {
            try
            {
                this.lvColoane.MutaRandulSelectatInSus();
                //if (this.lvColoane.SelectedIndices.Count > 0)
                //{
                //    int indexSelectie = this.lvColoane.SelectedIndices[0];
                //    if (indexSelectie > 0)
                //    {
                //        ListViewItem obiectSelectat = this.lvColoane.Items[indexSelectie];
                //        this.lvColoane.Items.RemoveAt(indexSelectie);
                //        this.lvColoane.Items.Insert(indexSelectie - 1, obiectSelectat);

                //        obiectSelectat = null;
                //    }
                //}
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        private void btnJos_Click(object sender, EventArgs e)
        {
            try
            {
                this.lvColoane.MutaRandulSelectatInJos();
                //if (this.lvColoane.SelectedIndices.Count > 0)
                //{
                //    int indexSelectie = this.lvColoane.SelectedIndices[0];
                //    if (indexSelectie < this.lvColoane.Items.Count)
                //    {
                //        ListViewItem obiectSelectat = this.lvColoane.Items[indexSelectie];
                //        this.lvColoane.Items.RemoveAt(indexSelectie);
                //        this.lvColoane.Items.Insert(indexSelectie + 1, obiectSelectat);

                //        obiectSelectat = null;
                //    }
                //}
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        private void btnExporta_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rbCSV.Checked)
                {
                    CCL.UI.IHMUtile.ExportaDGV(this.lDGVImprimare, getColoaneSelectate(), this.lNumeFisier, this.rbVirgula.Checked ? "," : ";", this.lDeschideDupaCreare, this.lCreeazaInThreadulPrincipal);
                }
                else
                {
                    this.lNumeFisier = this.lNumeFisier.Replace(".csv", ".xls");
                    CExportExcel.Exporta(this.lDGVImprimare, getColoaneSelectate(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Total).ToUpper(), this.lNumeFisier, this.lDeschideDupaCreare);
                }

                inchideEcranul(System.Windows.Forms.DialogResult.OK);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        #endregion

        #region Metode private

        private void vizibilitateSeparatori()
        {
            this.panelSeparatorCSV.Visible = this.rbCSV.Checked;
        }

        private List<string> getColoaneSelectate()
        {
            List<string> listaRetur = new List<string>();

            foreach (DataGridViewRow item in this.lvColoane.Rows)
            {
                if (Convert.ToBoolean(item.Cells[DataGridViewPersonalizat.lColoanaSelectieMultipla].Value))
                    listaRetur.Add(Convert.ToString(item.Tag));
            }

            return listaRetur;
        }

        #endregion

        #region Metode publice

        public static string Exporta(Form pEcranParinte, DataGridViewPersonalizat pDGVExport, string pNumeFisier, bool pDeschideDupaCreare, bool pCreeazaInThreadulPrincipal)
        {
            if (pDGVExport == null) return string.Empty;

            using (frmExportDGV ecran = new frmExportDGV(pDGVExport, pNumeFisier, pDeschideDupaCreare, pCreeazaInThreadulPrincipal))
            {
                ecran.AplicaPreferinteleUtilizatorului();
                if (CCL.UI.IHMUtile.DeschideEcran(pEcranParinte, ecran))
                    return ecran.lNumeFisier;
            }

            return string.Empty;
        }

        #endregion

    }
}
