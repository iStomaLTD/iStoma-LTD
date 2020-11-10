using BLL.iStomaLab;
using CCL.UI;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iStomaLab.Imprimare
{
    public partial class frmImprimareDGV : Generale.FormPersonalizat
    {

        #region Declaratii generale

        private DataGridViewPersonalizat lDGVImprimare = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private frmImprimareDGV()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                this.chkTitlu.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Titlu);
                this.chkCentrat.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CentrareInPagina);
                this.chkNumarPagina.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.AfiseazaNumarulPaginii);
                this.chkTitluPeFiecarePagina.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PeFiecarePagina);
                this.btnDeselecteaza.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Deselecteaza);
                this.btnAstazi.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Astazi);
                this.chkClasic.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Clasic);

                this.btnSchimbaPaleta.Visible = false;
                this.btnDeselecteaza.Click += BtnDeselecteaza_Click;
            }
        }

        private frmImprimareDGV(DataGridViewPersonalizat pDGVImprimare)
            : this()
        {
            this.lDGVImprimare = pDGVImprimare;

            this.Text = DateTime.Today.ToString(CConstante.FORMAT_DATA);// BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Imprimare);
            this.chkTitluPeFiecarePagina.Checked = true;

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
            //Titlul
            this.txtTitlu.Text = this.lDGVImprimare.GetTitlu();
            this.txtFooter.Text = this.lDGVImprimare.GetFooter();
            this.txtHeader.Text = this.lDGVImprimare.GetHeader();

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

            //this.lvColoane.Clear();

            //ListViewItem itemLV = null;
            //foreach (DataGridViewColumn coloana in this.lDGVImprimare.Columns)
            //{
            //    if (!this.lDGVImprimare.SeIgnoraColoanaLaImprimare(coloana.Name))
            //    {
            //        itemLV = new ListViewItem(new[] { coloana.HeaderText });
            //        //itemLV.Text = coloana.HeaderText;
            //        itemLV.Tag = coloana.Name;
            //        itemLV.Checked = true;
            //        this.lvColoane.Items.Add(itemLV);
            //    }
            //}

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void btnAstazi_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.txtTitlu.Text = DateTime.Today.ToString(CConstante.FORMAT_DATA);
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

        private void btnSchimbaPaleta_Click(object sender, EventArgs e)
        {
            try
            {
                //IHM.General.Imprimare.FormSchimbarePaletaDGV.Afiseaza(this);
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

        private void btnImprima_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.chkClasic.Checked)
                {
                    System.Drawing.Image logo = null;

                    //if (this.chkImprimaCuLogo.Checked)
                    //    logo = this.lLocatieCurenta.getLogoSediuCaImagine();

                    CCL.UI.IHMUtile.PrintPreviewDGV(this.lDGVImprimare, BLL.iStomaLab.Comune.BComportamentAplicatie.GetPaletaCuloriDGV(), (this.chkTitlu.Checked ? this.txtTitlu.Text : string.Empty), this.chkTitluPeFiecarePagina.Checked, this.chkNumarPagina.Checked, this.chkCentrat.Checked, getColoaneSelectate(), logo, this.txtHeader.GetText(), this.txtFooter.GetText());
                }
                else
                {
                    Imprimare.FormImprimaWebBrowser.Afiseaza(this, this.lDGVImprimare.GetTabelHTML(getColoaneSelectate(), this.txtTitlu.Text, this.txtHeader.Text, this.txtFooter.Text), 1, this.chkImprimaCuLogo.Checked);
                }
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        #endregion

        #region Metode private

        private List<string> getColoaneSelectate()
        {
            List<string> listaRetur = new List<string>();

            foreach (DataGridViewRow item in this.lvColoane.Rows)
            {
                if (Convert.ToBoolean(item.Cells[DataGridViewPersonalizat.lColoanaSelectieMultipla].Value))
                    listaRetur.Add(Convert.ToString(item.Tag));
            }

            //foreach (ListViewItem item in this.lvColoane.Items)
            //{
            //    if (item.Checked)
            //        listaRetur.Add(Convert.ToString(item.Tag));
            //}

            return listaRetur;
        }

        #endregion

        #region Metode publice

        public static void Imprima(DataGridViewPersonalizat pDGVImprimare)
        {
            if (pDGVImprimare == null) return;

            using (frmImprimareDGV ecran = new frmImprimareDGV(pDGVImprimare))
            {
                ecran.AplicaPreferinteleUtilizatorului();
                CCL.UI.IHMUtile.DeschideEcran(CCL.UI.IHMUtile.GetFormParinte(pDGVImprimare), ecran);
                pDGVImprimare.Focus();
            }
        }

        #endregion

    }
}
