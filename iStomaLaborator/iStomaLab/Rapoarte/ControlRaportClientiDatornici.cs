using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iStomaLab.Generale;
using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;
using static iStomaLab.Setari.Lucrari.ControlListaDePreturiClienti;
using CCL.UI;
using CCL.iStomaLab;

namespace iStomaLab.Rapoarte
{
    public partial class ControlRaportClientiDatornici : UserControlPersonalizat
    {

        #region Declaratii generale


        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colClient,
            colSold,
            colDeschideDosar,
            colObservatii,
            colTotalLucrariNefact,
        }


        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlRaportClientiDatornici()
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
            this.txtCautare.CerereUpdate += TxtCautare_CerereUpdate;

            this.dgvLista.CellClick += DgvLista_CellClick;
            this.dgvLista.CereRefresh += DgvLista_CereRefresh;
        }

        private void initTextML()
        {

        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.txtCautare.Goleste();
            this.lblTitlu.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ClientiDatornici);

            ConstruiesteColoaneDGV();

            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void TxtCautare_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                filtreazaDupaText();
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

        private void DgvLista_CereRefresh(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                ConstruiesteColoaneDGV();

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

        private void DgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.lSeIncarca || e.RowIndex < 0) return;
            try
            {
                incepeIncarcarea();

                string denumireColoanaSelectata = this.dgvLista.Columns[e.ColumnIndex].Name;

                if (this.dgvLista.SelectedRow != null)
                {
                    BClienti client = this.dgvLista.SelectedRow.Tag as BClienti;

                    if (client != null)
                    {
                        if (denumireColoanaSelectata.Equals(EnumColoaneDGV.colDeschideDosar.ToString()))
                        {
                            if (TablouDeBord.Clienti.FormDosarClient.Afiseaza(this.GetFormParinte(), client))
                                incarcaRand(this.dgvLista.SelectedRow, client.GetSold(null), client.Id, client, client.GetUltimaLucrare(null), client.GetUltimaFactura(null), client.GetListaLucrariNefacturate(null).Count());
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


        #endregion

        #region Metode private

        private void filtreazaDupaText()
        {
            setNrLinii(this.dgvLista.FiltreazaDupaText(this.txtCautare.Text));
        }

        private void setNrLinii(int pNrLinii)
        {
            BClienti datorie = null;
            foreach (DataGridViewRow rand in this.dgvLista.Rows)
            {
                if (rand.Visible)
                {
                    datorie = rand.Tag as BClienti;
                }
            }

            this.lblTotal.Text = string.Format("{0}: {1}",
              BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ClientiDatornici),
              pNrLinii);
        }

        private void ConstruiesteColoaneDGV()
        {
            this.dgvLista.IncepeConstructieColoane();

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colClient.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Client), 200, false, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaButonClasic(EnumColoaneDGV.colDeschideDosar.ToString(), string.Empty, string.Empty, 40, false);

            this.dgvLista.AdaugaColoaneTelefonEmail();

            this.dgvLista.AdaugaColoanaText(EnumColoaneDGV.colObservatii.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii), 200, true, DataGridViewColumnSortMode.Automatic);

            IHMUtile.AdaugaColoanaUltimaLucrare(this.dgvLista);

            IHMUtile.AdaugaColoanaUltimaFactura(this.dgvLista);

            this.dgvLista.AdaugaColoanaNumerica(EnumColoaneDGV.colTotalLucrariNefact.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.LucrariNefacturate), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.AdaugaColoanaValoareMonetara(EnumColoaneDGV.colSold.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Sold), 100, DataGridViewColumnSortMode.Automatic);

            this.dgvLista.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvLista.IncepeContructieRanduri();

            Dictionary<int, double> listaClientiDatornici = BClienti.GetListaDatornici(null);
            List<int> listaIdClinici = IHMUtile.GetListaKey(listaClientiDatornici);
            BColectieClienti listaClinici = BClienti.getByListaId(listaIdClinici, null);

            BColectieClientiComenzi listaUltimelorLucrari = BClientiComenzi.GetUltimeleLucrariPerClinica(listaIdClinici, null);
            BColectieClientiFacturi listaUltimelorFacturi = BClientiFacturi.GetUltimeleFacturiPerClinica(listaIdClinici, null);
            Dictionary<int, int> dictIdClinicaNrLucrariNefacturate = BClientiComenzi.GetDictIdClinicaNrLucrariNefacturate(listaIdClinici, null);

            BClienti clinicaTemp = null;
            foreach (var elem in listaClientiDatornici)
            {
                clinicaTemp = listaClinici.GetById(elem.Key);

                incarcaRand(this.dgvLista.AdaugaRandNou(), elem.Value, elem.Key, clinicaTemp, listaUltimelorLucrari.GetUltimaByIdClient(elem.Key), listaUltimelorFacturi.GetUltimaByIdClient(elem.Key), dictIdClinicaNrLucrariNefacturate.ContainsKey(elem.Key)? dictIdClinicaNrLucrariNefacturate[elem.Key]: 0);
            }

            this.dgvLista.FinalizeazaContructieRanduri();

            this.lblTotal.Text = string.Format("{0}: {1}", BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ClientiDatornici), this.dgvLista.RowCount.ToString());
        }

        private void incarcaRand(DataGridViewRow pRand, double pSold, int pId, BClienti pClinica, BClientiComenzi pUltimaLucrare, BClientiFacturi pUltimaFactura, int pNrLucrariNefacturate)
        {
            pRand.Tag = pClinica;
            pRand.Cells[EnumColoaneDGV.colClient.ToString()].Value = pClinica.Denumire;
            DataGridViewPersonalizat.InitCelulaDeschideClasic(pRand, EnumColoaneDGV.colDeschideDosar.ToString());

            DataGridViewPersonalizat.InitCeluleTelefonEmail(pRand, pClinica.TelefonMobil, pClinica.AdresaMail);

            pRand.Cells[EnumColoaneDGV.colObservatii.ToString()].Value = pClinica.ObservatiiDateClinica;

            DataGridViewPersonalizat.InitCelulaValoareMonetara(pRand, EnumColoaneDGV.colSold.ToString(), pSold);
            IHMUtile.IncarcaRandUltimaLucrare(pRand, pUltimaLucrare);
            IHMUtile.IncarcaRandUltimaFactura(pRand, pUltimaFactura);
            DataGridViewPersonalizat.InitCelulaValoareNumerica(pRand, EnumColoaneDGV.colTotalLucrariNefact.ToString(), pNrLucrariNefacturate);
            DataGridViewPersonalizat.SeteazaAlerta(pRand, EnumColoaneDGV.colSold.ToString());
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
