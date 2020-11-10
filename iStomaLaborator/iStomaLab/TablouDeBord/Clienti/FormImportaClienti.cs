using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Reprezentanti;
using CCL.UI;
using iStomaLab.Generale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iStomaLab.TablouDeBord.Clienti
{
    public partial class FormImportaClienti : FormPersonalizat
    {

        #region Declaratii generale

        private List<StructImportClienti> lListaClienti;

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colDenumireCabinet,
            colNumeMedic,
            colPrenumeMedic
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public FormImportaClienti(List<StructImportClienti> pLista)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lListaClienti = pLista;

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {

                adaugaHandlere();
                initTextML();

                this.CentratCuDeplasare();
                //this.Maximizeaza();
            }
        }

        private void adaugaHandlere()
        {
            this.Load += _Load;
            this.ctrlValidareAnulare.Validare += CtrlValidareAnulare_Validare;
            this.dgvListaImportClienti.StergereLinie += DgvListaImportClienti_StergereLinie;
            this.txtCautaClienti.CerereUpdate += TxtCautaClienti_CerereUpdate;
        }

        private void initTextML()
        {
            this.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ImportDate);
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

            this.txtCautaClienti.Goleste();

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void TxtCautaClienti_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.dgvListaImportClienti.FiltreazaDupaText(this.txtCautaClienti.Text);
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

        private void DgvListaImportClienti_StergereLinie(DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                StructImportClienti client = (StructImportClienti)this.dgvListaImportClienti.Rows[pIndexRand].Tag;

                if (Mesaj.Confirmare(this, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), client.NumeClient + " " + client.PrenumeClient))
                {
                    this.dgvListaImportClienti.Rows.RemoveAt(pIndexRand);
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

        private void CtrlValidareAnulare_Validare(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BColectieClienti listaClientiExistenti = BClienti.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null);

                //List<string> listaDenumireClientiExistenti = listaClientiExistenti.GetDenumireClienti();

                foreach (DataGridViewRow row in this.dgvListaImportClienti.Rows)
                {
                    StructImportClienti client = (StructImportClienti)row.Tag;

                    BClienti clinicaExistenta = listaClientiExistenti.GetPrimaByDenumire(client.DenumireCabinet.ToLower());

                    if (!string.IsNullOrEmpty(client.DenumireCabinet))
                    {
                        if (clinicaExistenta == null)
                        {
                            int idClient = BClienti.Add(client.DenumireCabinet, null);
                            listaClientiExistenti.Add(new BClienti(idClient));

                            BClientiReprezentanti.Add(idClient, client.NumeClient, client.PrenumeClient, string.Empty, null);
                        }
                        else
                        {
                            //Tuple<int, string> listeClientiExistentiDenumire = BClienti.getListaClientiDenumire(client.DenumireCabinet);

                            //List<string> lstMediciExistentiDenumire = BClientiReprezentanti.getListaMediciDenumire(listeClientiExistentiDenumire.Item1);

                            //if (!lstMediciExistentiDenumire.Contains(client.NumeClient + " " + client.PrenumeClient))
                            //{
                            BClientiReprezentanti.Add(clinicaExistenta.Id, client.NumeClient, client.PrenumeClient, string.Empty, null);
                            //}
                        }
                    }
                }

                inchideEcranulOK();
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
            this.dgvListaImportClienti.IncepeConstructieColoane();

            this.dgvListaImportClienti.AdaugaColoanaText(EnumColoaneDGV.colDenumireCabinet.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Cabinet), 200, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaImportClienti.AdaugaColoanaText(EnumColoaneDGV.colNumeMedic.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NumeMedic), 200, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaImportClienti.AdaugaColoanaText(EnumColoaneDGV.colPrenumeMedic.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PrenumeMedic), 200, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaImportClienti.AdaugaColoana(DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvListaImportClienti.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaImportClienti.IncepeContructieRanduri();

            var listaElem = this.lListaClienti;

            foreach (var elem in listaElem)
            {
                incarcaRand(this.dgvListaImportClienti.Rows[this.dgvListaImportClienti.Rows.Add()], elem);
            }

            this.dgvListaImportClienti.FinalizeazaContructieRanduri();
        }

        private void incarcaRand(DataGridViewRow pRand, StructImportClienti pElem)
        {
            pRand.Tag = pElem;

            pRand.Cells[EnumColoaneDGV.colDenumireCabinet.ToString()].Value = pElem.DenumireCabinet;
            pRand.Cells[EnumColoaneDGV.colNumeMedic.ToString()].Value = pElem.NumeClient;
            pRand.Cells[EnumColoaneDGV.colPrenumeMedic.ToString()].Value = pElem.PrenumeClient;
            DataGridViewPersonalizat.InitCelulaStergere(pRand);
        }

        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente, List<StructImportClienti> pLista)
        {
            using (FormImportaClienti ecran = new FormImportaClienti(pLista))
            {
                ecran.AplicaPreferinteleUtilizatorului();
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
