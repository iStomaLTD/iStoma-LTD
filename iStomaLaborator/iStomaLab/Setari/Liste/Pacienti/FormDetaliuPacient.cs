using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Preturi;
using BLL.iStomaLab.Reprezentanti;
using BLL.iStomaLab.Utilizatori;
using CCL.iStomaLab;
using CCL.UI;
using CDL.iStomaLab;
using iStomaLab.Caramizi;
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
using static CDL.iStomaLab.CDefinitiiComune;
using static iStomaLab.Setari.Lucrari.ControlListaDePreturiClienti;

namespace iStomaLab.TablouDeBord.Clienti
{
    public partial class FormDetaliuPacient : FormPersonalizat
    {

        #region Declaratii generale   
      
        private BClienti lClient = null;
       // private BClientiPacienti lPacient = null;
        private BClientiPacienti pPacient = null;       
        int IdClient = 0;
        string nume;
        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormDetaliuPacient(BClienti pClient, BClientiPacienti pPacient, string Denumire)
        {   
            this.DoubleBuffered = true;
            InitializeComponent();
            nume = Denumire;
            this.lClient = pClient;
            this.pPacient = pPacient;
            IdClient = this.lClient.Id;

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
            this.ctrlValidareAnularePacient.Validare += CtrlValidareAnularePacient_Validare;
            this.chkFemininPacient.CheckedChanged += ChkFemininPacient_CheckedChanged;
            this.chkMasculinPacient.CheckedChanged += ChkMasculinPacient_CheckedChanged;
        }

        private void initTextML()
        {
            this.Text = string.Empty;
            this.lblNumePacient.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Nume);
            this.lblPrenumePacient.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Prenume);
            this.lblSexPacient.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Sex);
            this.chkFemininPacient.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.captionFeminin);
            this.chkMasculinPacient.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.captionMasculin);
            this.lblDataNasteriiPacient.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataNasterii);
            this.lblVarstaPacient.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Varsta);        
            this.lblObservatiiPacient.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii);
        }

        void _Load(object sender, EventArgs e)
        {
            try
            {
                Initializeaza(nume);
                AllowModification(true);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        public void Initializeaza(string Denumire)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();
        
            this.txtNumePacient.CapitalizeazaPrimaLitera = true;
            this.txtPrenumePacient.CapitalizeazaPrimaLitera = true;
           

            this.txtNumePacient.Focus();

            if (this.pPacient == null)
            {
                this.txtNumePacient.Goleste();
                this.txtPrenumePacient.Goleste();
                this.chkFemininPacient.Checked = false;
                this.chkMasculinPacient.Checked = false;
                this.ctrlDataNasteriiPacient.Goleste();
                this.txtVarstaPacient.Goleste();               
                this.txtObservatiiPacient.Goleste();

                //Adaugam un pacient nou din controlul de cautare
                this.txtNumePacient.Text = nume;
            }
            else
            {                
                this.txtNumePacient.Text = pPacient.Nume;
                this.txtPrenumePacient.Text = pPacient.Prenume;
                this.chkFemininPacient.Checked = getSexPersonal(true);
                this.chkMasculinPacient.Checked = getSexPersonal(false);              
                this.ctrlDataNasteriiPacient.DataAfisata = pPacient.DataNastere;
                this.txtVarstaPacient.Text = pPacient.Varsta.ToString();          
               this.txtObservatiiPacient.Text = pPacient.Observatii;
            }

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void CtrlValidareAnularePacient_Validare(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (this.Salveaza())
                     inchideEcranul();                   
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

        private void ChkMasculinPacient_CheckedChanged(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.chkFemininPacient.Checked = !chkMasculinPacient.Checked;
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

        private void ChkFemininPacient_CheckedChanged(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.chkMasculinPacient.Checked = !chkFemininPacient.Checked;
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

        private bool getSexPersonal(bool pEsteFeminin)
        {
            if (this.pPacient.Sex == 0)
                return false;
            return this.pPacient.Sex == 1 ? !pEsteFeminin : pEsteFeminin;
        }

        private int getSexSelectat()
        {
            if (this.chkFemininPacient.Checked)
                return 2;
            else if (this.chkMasculinPacient.Checked)
                return 1;
            return 0;
        } 

        private void seteazaAlerta()
        {
            IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.txtNumePacient, this.lblNumePacient);
            if (string.IsNullOrEmpty(this.txtNumePacient.Text))
            {
                this.txtNumePacient.Focus();
            }
        }

        #endregion

        #region Metode publice
       
        public static bool Afiseaza(Form pEcranPariente, int pIdComandaClient, ref int pIdPacient, string denumpac)
        {
            BClienti pClient = pIdComandaClient > 0 ? new BClienti(pIdComandaClient) : BClienti.getClient(pIdComandaClient,null);
            BClientiPacienti pPacient = pIdPacient > 0 ?  BClientiPacienti.getPacient(pIdPacient, null) : null;
            string Denumire = denumpac;                 

            using (FormDetaliuPacient ecran = new FormDetaliuPacient(pClient, pPacient, Denumire))
            {
                ecran.AplicaPreferinteleUtilizatorului();
                
                if (CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran))
                {
                    return false;
                }
                else
                    //cand adauga un pacient nou din control
                    pIdPacient = ecran.pPacient.Id;
            }           
            return true;
          
        }


        internal bool Salveaza()
        {           
            bool esteValid = BClientiPacienti.SuntInformatiileNecesareCoerente(this.txtNumePacient.Text, this.txtPrenumePacient.Text);

            if (this.pPacient == null)
            {
                if (esteValid)
                {
                    int id = BClientiPacienti.Add(IdClient, this.txtNumePacient.Text, this.txtPrenumePacient.Text, this.ctrlDataNasteriiPacient.DataAfisata, CUtil.GetAsInt32(this.txtVarstaPacient.Text), getSexSelectat(), string.Empty, string.Empty, this.txtObservatiiPacient.Text, null);                  
                    this.pPacient = BClientiPacienti.getPacient(id, null);
                    BClientiPacienti pPacient = BClientiPacienti.getPacient(id, null);
                }
                else
                {
                    seteazaAlerta();
                }
            }
            else
            {
                pPacient.Nume = this.txtNumePacient.Text;
                pPacient.Prenume = this.txtPrenumePacient.Text;
                pPacient.Sex = getSexSelectat();
                pPacient.DataNastere = this.ctrlDataNasteriiPacient.DataAfisata;
                pPacient.Varsta = Int32.Parse(this.txtVarstaPacient.Text);
                pPacient.Observatii = this.txtObservatiiPacient.Text;
                if (esteValid)
                {
                    this.pPacient.UpdateAll();
                }
                else
                {
                    seteazaAlerta();
                }
            }
            return esteValid;
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
