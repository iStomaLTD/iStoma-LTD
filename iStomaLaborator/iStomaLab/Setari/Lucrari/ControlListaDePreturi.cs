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
using CCL.UI;
using CCL.iStomaLab;
using CDL.iStomaLab;
using System;
using BLL.iStomaLab.Preturi;
using BLL.iStomaLab.Referinta;
using System.IO;

namespace iStomaLab.Setari.Lucrari
{
    public partial class ControlListaDePreturi : UserControlPersonalizat
    {

        #region Declaratii generale


        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colDenumire,
            colPrescurtare,
            colCod,
            colCategorie,
            colSubcategorie,
            colTermenMediu,
            colValoareRon,
            colValoareEuro
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlListaDePreturi()
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
            this.btnAdaugareLucrare.Click += BtnAdaugareLucrare_Click;
            this.dgvListaPreturi.StergereLinie += DgvListaPreturi_StergereLinie;
            this.dgvListaPreturi.EditareLinie += DgvListaPreturi_EditareLinie;
            this.txtCautareLucrare.CerereUpdate += TxtCautareLucrare_CerereUpdate;
            this.btnActiviInactivi.Click += BtnActiviInactivi_Click;
            this.btnMeniu.Click += BtnMeniu_Click;
            this.btnInchidePanel.Click += BtnMeniu_Click;
            this.btnImporta.Click += BtnImporta_Click;
        }

        private void initTextML()
        {
            this.lblTitluListaDePreturi.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Lucrari);
            this.btnImporta.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Importa);

        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();
            this.txtCautareLucrare.Goleste();

            this.btnActiviInactivi.Selectat = false;
            this.panelOptiuni.Visible = false;

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();
            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void BtnImporta_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                System.IO.FileInfo fisier = IHMUtile.GetFisierUnic(this.GetFormParinte());

                if (fisier != null)
                {
                    List<StructImportListaPreturi> listaInterv = new List<StructImportListaPreturi>();
                    using (StreamReader sr = new StreamReader(fisier.FullName))
                    {
                        string currentLine;
                        // currentLine will be null when the StreamReader reaches the end of file
                        while ((currentLine = sr.ReadLine()) != null)
                        {
                            // Search, case insensitive, if the currentLine contains the searched keyword
                            if (currentLine.IndexOf(",", StringComparison.CurrentCultureIgnoreCase) >= 0)
                            {
                                string[] dateLinie = currentLine.Split(new string[] { "," }, StringSplitOptions.None);

                                if (dateLinie.Length > 1)
                                    listaInterv.Add(new StructImportListaPreturi(dateLinie));
                            }
                        }
                    }

                    if (CUtil.EsteListaVida<StructImportListaPreturi>(listaInterv))
                    {
                        CCL.UI.Mesaj.Eroare(this.GetFormParinte(), "Eroare");
                    }
                    else
                    {
                        if (FormImportaListaPreturi.Afiseaza(this.GetFormParinte(), listaInterv))
                        {
                            ConstruiesteRanduriDGV();
                            this.panelOptiuni.Visible = false;
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

        private void BtnMeniu_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.panelOptiuni.Visible = !this.panelOptiuni.Visible;
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

        private void BtnActiviInactivi_Click(object sender, EventArgs e)
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

        private void TxtCautareLucrare_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvListaPreturi.FiltreazaDupaText(this.txtCautareLucrare.Text);
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

        private void DgvListaPreturi_EditareLinie(CCL.UI.DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BListaPreturiStandard lucrareDeModificat = this.dgvListaPreturi.Rows[pIndexRand].Tag as BListaPreturiStandard;

                if (lucrareDeModificat != null)
                {
                    if (FormDetaliuLucrare.Afiseaza(this.GetFormParinte(), lucrareDeModificat))
                    {
                        incarcaRand(this.dgvListaPreturi.Rows[pIndexRand], lucrareDeModificat);
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

        private void DgvListaPreturi_StergereLinie(CCL.UI.DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BListaPreturiStandard lucrareDeSters = this.dgvListaPreturi.Rows[pIndexRand].Tag as BListaPreturiStandard;

                if (lucrareDeSters != null)
                {

                    if (!this.btnActiviInactivi.Selectat)
                    {
                        if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), lucrareDeSters.Denumire))
                        {
                            lucrareDeSters.Close(true, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stergere), null);
                            ConstruiesteRanduriDGV();
                        }
                    }
                    else
                    {
                        if (Mesaj.Confirmare(this.GetFormParinte(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiReactivarea), lucrareDeSters.Denumire))
                        {
                            lucrareDeSters.Close(false, string.Empty, null);
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

        private void BtnAdaugareLucrare_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (FormDetaliuLucrare.Afiseaza(this.GetFormParinte(), null))
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
            this.dgvListaPreturi.IncepeConstructieColoane();

            this.dgvListaPreturi.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvListaPreturi.AdaugaColoanaText(EnumColoaneDGV.colDenumire.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaPreturi.AdaugaColoanaText(EnumColoaneDGV.colPrescurtare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Prescurtare), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaPreturi.AdaugaColoanaText(EnumColoaneDGV.colCod.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Cod), 80, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaPreturi.AdaugaColoanaText(EnumColoaneDGV.colCategorie.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Categorie), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaPreturi.AdaugaColoanaText(EnumColoaneDGV.colSubcategorie.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Subcategorie), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaPreturi.AdaugaColoanaNumerica(EnumColoaneDGV.colTermenMediu.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TermenMediu), 50, DataGridViewColumnSortMode.Automatic);

            this.dgvListaPreturi.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colValoareRon.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.RON), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvListaPreturi.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colValoareEuro.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.EUR), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvListaPreturi.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvListaPreturi.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            var listaElem = BListaPreturiStandard.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Toate, null);

            if (listaElem.ContineElementeDeactivate())
            {
                this.btnActiviInactivi.Visible = true;
            }
            else
            {
                this.btnActiviInactivi.Visible = false;
                this.btnActiviInactivi.Selectat = false;
            }

            if (!this.btnActiviInactivi.Selectat)
                ConstruiesteRanduriDGV(listaElem.GetListaActive());
            else
                ConstruiesteRanduriDGV(listaElem.GetListaInactive());
        }

        private void ConstruiesteRanduriDGV(BColectieListaPreturiStandard pListaPreturi)
        {
            this.dgvListaPreturi.IncepeContructieRanduri();

            foreach (var elem in pListaPreturi)
            {
                incarcaRand(this.dgvListaPreturi.Rows[this.dgvListaPreturi.Rows.Add()], elem);
            }

            this.dgvListaPreturi.FinalizeazaContructieRanduri();

            int totalElemente = this.dgvListaPreturi.RowCount;
            if (totalElemente == 1)
            {
                this.lblTotalListaPreturi.Text = totalElemente.ToString() + BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ElementGasit);
            }
            else
            {
                this.lblTotalListaPreturi.Text = totalElemente.ToString() + BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ElementeGasite);
            }


        }

        private void incarcaRand(DataGridViewRow pRand, BListaPreturiStandard pElem)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);
            pRand.Cells[EnumColoaneDGV.colDenumire.ToString()].Value = pElem.Denumire;
            pRand.Cells[EnumColoaneDGV.colPrescurtare.ToString()].Value = pElem.DenumirePrescurtata;
            pRand.Cells[EnumColoaneDGV.colCod.ToString()].Value = pElem.CodIntern;

            if (pElem.IdCategorie != 0)
            {
                BCategorii categorie = BCategorii.getCategorieById(pElem.IdCategorie, null);

                if (categorie.IdCategorie != 0)
                {
                    pRand.Cells[EnumColoaneDGV.colCategorie.ToString()].Value = BCategorii.getCategorieById(categorie.IdCategorie, null).Denumire;
                    pRand.Cells[EnumColoaneDGV.colSubcategorie.ToString()].Value = categorie.Denumire;
                }
                else
                {
                    pRand.Cells[EnumColoaneDGV.colCategorie.ToString()].Value = categorie.Denumire;
                    pRand.Cells[EnumColoaneDGV.colSubcategorie.ToString()].Value = string.Empty;
                }
            }
            else
            {
                pRand.Cells[EnumColoaneDGV.colCategorie.ToString()].Value = string.Empty;
                pRand.Cells[EnumColoaneDGV.colSubcategorie.ToString()].Value = string.Empty;
            }

            pRand.Cells[EnumColoaneDGV.colTermenMediu.ToString()].Value = pElem.TermenMediuZile;

            pRand.Cells[EnumColoaneDGV.colValoareRon.ToString()].Value = pElem.GetEtichetaRon();
            pRand.Cells[EnumColoaneDGV.colValoareEuro.ToString()].Value = pElem.GetEtichetaEuro();
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
