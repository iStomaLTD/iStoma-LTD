using BLL.iStomaLab;
using BLL.iStomaLab.Utilizatori;
using CCL.iStomaLab;
using CCL.UI;
using CDL.iStomaLab;
using iStomaLab.Generale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iStomaLab.Setari.Personal
{
    public partial class FormImportPersonal : FormPersonalizat
    {

        #region Declaratii generale

        private List<StructImportPersonal> lListaPersonal;

        #endregion

        #region Enumerari si Structuri

        private enum EnumColoaneDGV
        {
            colNume,
            colPrenume,
            colDataNasterii,
            colTelefon
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormImportPersonal(List<StructImportPersonal> pListaPersonal)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lListaPersonal = pListaPersonal;

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
            this.dgvListaImportPersonal.StergereLinie += DgvListaImportPersonal_StergereLinie;
            this.txtCautare.CerereUpdate += TxtCautare_CerereUpdate;
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

            this.txtCautare.Goleste();

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

                this.dgvListaImportPersonal.FiltreazaDupaText(this.txtCautare.Text);
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

        private void DgvListaImportPersonal_StergereLinie(CCL.UI.DataGridViewPersonalizat pDGVSender, int pIndexRand)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                StructImportPersonal personal = (StructImportPersonal)this.dgvListaImportPersonal.Rows[pIndexRand].Tag;

                if (Mesaj.Confirmare(this, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), personal.Nume + " " + personal.Prenume))
                {
                    this.dgvListaImportPersonal.Rows.RemoveAt(pIndexRand);
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

                BColectieUtilizator listaUtilizatoriExistenti = BUtilizator.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, CDefinitiiComune.EnumRol.Nedefinit, null);

                //List<string> listaNumePrenumeUtilizatoriExistenti = listaUtilizatoriExistenti.GetNumePrenumeUtilizatori();

                foreach (DataGridViewRow row in this.dgvListaImportPersonal.Rows)
                {
                    StructImportPersonal personal = (StructImportPersonal)row.Tag;
                    BUtilizator userExistent = listaUtilizatoriExistenti.GetByIdentitate(string.Concat(personal.Nume, personal.Prenume).ToLower().Replace(" ", ""));

                    if (userExistent == null)
                    {
                        BUtilizator.Add(personal.Nume, personal.Prenume, personal.DataNastere, personal.TelefonMobil, null);
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
            this.dgvListaImportPersonal.IncepeConstructieColoane();

            this.dgvListaImportPersonal.AdaugaColoanaText(EnumColoaneDGV.colNume.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Nume), 150, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaImportPersonal.AdaugaColoanaText(EnumColoaneDGV.colPrenume.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Prenume), 200, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaImportPersonal.AdaugaColoanaData(EnumColoaneDGV.colDataNasterii.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataNasterii), 200, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);

            this.dgvListaImportPersonal.AdaugaColoanaText(EnumColoaneDGV.colTelefon.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TelefonMobil), 200, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaImportPersonal.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Stergere);

            this.dgvListaImportPersonal.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaImportPersonal.IncepeContructieRanduri();

            var listaElem = this.lListaPersonal;

            foreach (var elem in listaElem)
            {
                incarcaRand(this.dgvListaImportPersonal.Rows[this.dgvListaImportPersonal.Rows.Add()], elem);
            }

            this.dgvListaImportPersonal.FinalizeazaContructieRanduri();
        }

        private void incarcaRand(DataGridViewRow pRand, StructImportPersonal pElem)
        {
            pRand.Tag = pElem;

            pRand.Cells[EnumColoaneDGV.colNume.ToString()].Value = pElem.Nume;
            pRand.Cells[EnumColoaneDGV.colPrenume.ToString()].Value = pElem.Prenume;
            if (!pElem.DataNastere.Equals(CConstante.DataNula))
                pRand.Cells[EnumColoaneDGV.colDataNasterii.ToString()].Value = pElem.DataNastere;
            pRand.Cells[EnumColoaneDGV.colTelefon.ToString()].Value = pElem.TelefonMobil;
            DataGridViewPersonalizat.InitCelulaStergere(pRand);
        }

        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente)
        {
            System.IO.FileInfo fisier = IHMUtile.GetFisierUnic(pEcranPariente);

            if (fisier != null)
            {
                List<StructImportPersonal> listaPersonal = new List<StructImportPersonal>();
                using (StreamReader sr = new StreamReader(fisier.FullName))
                {
                    string currentLine;
                    // currentLine will be null when the StreamReader reaches the end of file
                    while ((currentLine = sr.ReadLine()) != null)
                    {
                        // Search, case insensitive, if the currentLine contains the searched keyword
                        //if (currentLine.IndexOf(",", StringComparison.CurrentCultureIgnoreCase) >= 0)
                        //{
                        string[] dateLinie = currentLine.Split(new string[] { "," }, StringSplitOptions.None);

                        if (dateLinie.Length > 0)
                            listaPersonal.Add(new StructImportPersonal(dateLinie));
                        //}
                    }
                }

                if (CUtil.EsteListaVida<StructImportPersonal>(listaPersonal))
                {
                    CCL.UI.Mesaj.Eroare(pEcranPariente, "Lista vida");
                }
                else
                {
                    using (FormImportPersonal ecran = new FormImportPersonal(listaPersonal))
                    {
                        ecran.AplicaPreferinteleUtilizatorului();
                        return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
                    }

                }
            }

            return false;
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
