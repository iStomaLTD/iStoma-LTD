using BLL.iStomaLab;
using BLL.iStomaLab.Utilizatori;
using iStomaLab.Caramizi;
using iStomaLab.Generale;
using iStomaLab.TablouDeBord.Email;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iStomaLab
{
    public partial class EcranPrincipal : Form, ILL.iStomaLab.IComunicareIHM
    {

        #region Declaratii generale

        private bool lSeVreaDeconectare = false;
        private bool lEcranInModificare = true;
        private bool lSeIncarca = false;
        private EnumRubrica lRubricaSelectata = EnumRubrica.TablouDeBord;
        private EnumOptiune lOptiuneSelectata = EnumOptiune.TablouDeBord;
        private ButonOptiuneMeniuStanga btnOptiuneMeniuStanga = null;

        private Setari.Personal.ControlListaUtilizatori lctrlGestiunePersonal = null;
        private TablouDeBord.Clienti.ControlListaClienti lctrlGestiuneClienti = null;
        private ControlComunicare lctrlComunicare = null;
        private Setari.Lucrari.ControlGestiuneListaDePreturi lctrlGestiuneListaDePreturi = null;
        private Setari.Locatii.ControlListaLocatii lctrlGestiuneLocatii = null;
        private Setari.Liste.ControlGestiuneListe lctrlGestiuneDiverse = null;
        private TablouDeBord.ControlTablouDeBord lctrlTablouDeBord = null;

        #endregion

        #region Enumerari si Structuri


        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public EcranPrincipal()
        {
            if (BUtilizator.GetUtilizatorConectat() == null)
                FormLogin.Afiseaza(null);

            this.DoubleBuffered = true;
            InitializeComponent();

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                adaugaHandlere();
                initTextML();
            }
        }

        void _Load(object sender, EventArgs e)
        {
            try
            {
                if (!CCL.UI.IHMUtile.SuntemInDebug())
                {
                    Initializeaza();
                    AllowModification(true);
                }
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this, ex);
            }
        }

        public void Initializeaza()
        {
            incepeIncarcarea();

            this.mnuStTablouDeBord.Initializeaza(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TablouDeBord), EnumRubrica.TablouDeBord, EnumRubrica.TablouDeBord == this.lRubricaSelectata, this.mnuStPanelTablouDeBord);
            this.mnuStRapoarte.Initializeaza(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Rapoarte), EnumRubrica.Rapoarte, EnumRubrica.Rapoarte == this.lRubricaSelectata, this.mnuStPanelRapoarte);
            this.mnuStSetari.Initializeaza(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Setari), EnumRubrica.Setari, EnumRubrica.Setari == this.lRubricaSelectata, this.mnuStPanelSetari);

            this.mnuStOptTablouDeBord.Initializeaza(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TablouDeBord), EnumOptiune.TablouDeBord, EnumOptiune.TablouDeBord == this.lOptiuneSelectata);
            this.mnuStOptClienti.Initializeaza(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Clienti), EnumOptiune.Clienti, EnumOptiune.Clienti == this.lOptiuneSelectata);
            this.mnuStOptComunicare.Initializeaza(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Comunicare), EnumOptiune.Comunicare, EnumOptiune.Comunicare == this.lOptiuneSelectata);
            this.mnuStOptRapoarte.Initializeaza(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Rapoarte), EnumOptiune.Rapoarte, EnumOptiune.Rapoarte == this.lOptiuneSelectata);
            this.mnuStOptSetariListaDePreturi.Initializeaza(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ListaDePreturi), EnumOptiune.SetariListaPreturi, EnumOptiune.SetariListaPreturi == this.lOptiuneSelectata);
            this.mnuStOptSetariLocatii.Initializeaza(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Locatii), EnumOptiune.SetariLocatii, EnumOptiune.SetariLocatii == this.lOptiuneSelectata);
            this.mnuStOptSetariPersonal.Initializeaza(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Personal), EnumOptiune.SetariPersonal, EnumOptiune.SetariPersonal == this.lOptiuneSelectata);
            this.mnuStOptSetariDiverse.Initializeaza(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Diverse), EnumOptiune.SetariDiverse, EnumOptiune.SetariDiverse == this.lOptiuneSelectata);

            CCL.UI.IHMUtile._ComunicareIHM = this;

            incarcaOptiuneaSelectata(this.lOptiuneSelectata);

            finalizeazaIncarcarea();
        }

        private void adaugaHandlere()
        {
            this.Load += _Load;
            this.mnuIesire.Click += MnuIesire_Click;
            this.mnuDeconectare.Click += MnuDeconectare_Click;
            this.mnuPauza.Click += MnuPauza_Click;
            this.mnuMeniuStanga.Click += MnuMeniuStanga_Click;
            this.mnuCheckInOut.Click += MnuCheckInOut_Click;

            this.mnuStTablouDeBord.Click += MnuRubrica_Click;
            this.mnuStRapoarte.Click += MnuRubrica_Click;
            this.mnuStSetari.Click += MnuRubrica_Click;

            this.mnuStOptRapoarte.Click += MnuStOpt_Click;
            this.mnuStOptSetariListaDePreturi.Click += MnuStOpt_Click;
            this.mnuStOptSetariLocatii.Click += MnuStOpt_Click;
            this.mnuStOptSetariPersonal.Click += MnuStOpt_Click;
            this.mnuStOptTablouDeBord.Click += MnuStOpt_Click;
            this.mnuStOptClienti.Click += MnuStOpt_Click;
            this.mnuStOptSetariDiverse.Click += MnuStOpt_Click;
            this.mnuStOptComunicare.Click += MnuStOpt_Click;

            this.ctrlPauza.ParolaCorecta += CtrlPauza_ParolaCorecta;
            this.FormClosing += EcranPrincipal_FormClosing;

        }

        private void initTextML()
        {
            this.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.iStoma);
            this.mnuStTablouDeBord.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TablouDeBord);
            this.mnuStOptTablouDeBord.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TablouDeBord);
            this.mnuStOptClienti.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Clienti);
            this.mnuStOptComunicare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Comunicare);
            this.mnuStRapoarte.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Rapoarte);
            this.mnuStOptRapoarte.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Rapoarte);
            this.mnuStSetari.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Setari);
            this.mnuStOptSetariListaDePreturi.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ListaDePreturi);
            this.mnuStOptSetariLocatii.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Locatii);
            this.mnuStOptSetariPersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Personal);
            this.mnuStOptSetariDiverse.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Diverse);
            this.mnuMeniuStanga.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.MeniuStanga);
            this.mnuPauza.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pauza);
            this.mnuDeconectare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Deconectare);
            this.mnuIesire.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Iesire);
        }

        #endregion

        #region Evenimente

        #region Comunicare IHM

        public System.Drawing.Point GetLocation() { return this.Location; }
        public System.Drawing.Size GetSize() { return this.Size; }

        public void ImprimaDGV(object pDGV)
        {
            //Imprimare.frmImprimareDGV.Imprima(pDGV as DataGridViewPersonalizat);
        }

        public void ExportaDGV(object pDGV)
        {
            //Export.frmExportDGV.Exporta(this, pDGV as DataGridViewPersonalizat, string.Empty, true, false);
        }

        public void TrimiteDGVPeEmail(object pDGV)
        {

        }

        #endregion

        #region Meniu Sus

        private void MnuCheckInOut_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                FormCheckInOut.Afiseaza(this);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this, ex);
            }
            finally
            {
                finalizeazaIncarcarea();
            }

        }

        private void MnuMeniuStanga_Click(object sender, EventArgs e)
        {

            this.flpMeniuStanga.Visible = !this.flpMeniuStanga.Visible;


            if (this.flpMeniuStanga.Visible)
            {
                this.panelContainer.Dock = DockStyle.None;
                this.panelContainer.Height = this.panelGlobal.Height;
                this.panelContainer.Width = this.panelGlobal.Width - this.flpMeniuStanga.Width;
            }
            else
            {
                this.panelContainer.Width = this.panelGlobal.Width;
                this.panelContainer.Dock = DockStyle.Fill;
            }

        }

        private void MnuIesire_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MnuDeconectare_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.lSeVreaDeconectare = true;
                BUtilizator.DeconecteazaUtilizatorConectat(null);
                BGeneral.DistrugeObiectele();
                Program.Deconectare(this);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this, ex);
            }
            finally
            {
                finalizeazaIncarcarea();
            }
        }

        private void MnuPauza_Click(object sender, EventArgs e)
        {
            this.mnuSus.Visible = false;
            this.panelGlobal.Visible = false;
            this.ctrlPauza.Visible = true;
            this.ctrlPauza.Focus();
            this.ctrlPauza.Initializeaza();
        }

        #endregion

        private void MnuStOpt_Click(object sender, EventArgs e)
        {
            schimbaOptiuneaActiva(sender as ButonOptiuneMeniuStanga);
        }

        private void MnuRubrica_Click(object sender, EventArgs e)
        {
            schimbaDeschidereaRubricilor(sender as ButonRubricaMeniuStanga);
        }

        private void CtrlPauza_ParolaCorecta(object sender, EventArgs e)
        {
            this.mnuSus.Visible = true;
            this.panelGlobal.Visible = true;
            this.ctrlPauza.Visible = false;
        }

        private void EcranPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.lSeVreaDeconectare)
            {
                bool ok = FormInchidereAplicatie.Afiseaza(this);

                if (!ok)
                    e.Cancel = true;
            }
        }

        #endregion

        #region Metode private

        #region Controale incarcate dinamic

        private void adaugaControlInZonaUtila(Control pControl)
        {
            this.panelContainer.Controls.Add(pControl);
            pControl.Dock = DockStyle.Fill;
        }

        private void initControlGestiunePersonal()
        {
            if (this.lctrlGestiunePersonal == null)
            {
                this.lctrlGestiunePersonal = new Setari.Personal.ControlListaUtilizatori();
                this.lctrlGestiunePersonal.Name = "ctrlGestiunePersonal";
                adaugaControlInZonaUtila(this.lctrlGestiunePersonal);
            }

            this.lctrlGestiunePersonal.Initializeaza();
            this.lctrlGestiunePersonal.Visible = true;
            this.lctrlGestiunePersonal.BringToFront();
        }

        private void initControlGestiuneClienti()
        {
            if (this.lctrlGestiuneClienti == null)
            {
                this.lctrlGestiuneClienti = new TablouDeBord.Clienti.ControlListaClienti();
                this.lctrlGestiuneClienti.Name = "ctrlGestiuneClienti";
                adaugaControlInZonaUtila(this.lctrlGestiuneClienti);
            }

            this.lctrlGestiuneClienti.Initializeaza();
            this.lctrlGestiuneClienti.Visible = true;
            this.lctrlGestiuneClienti.BringToFront();
        }

        private void initControlGestiuneComunicare()
        {
            if (this.lctrlComunicare == null)
            {
                this.lctrlComunicare = new ControlComunicare();
                this.lctrlComunicare.Name = "ctrlGestiuneComunicare";
                adaugaControlInZonaUtila(this.lctrlComunicare);
            }

            this.lctrlComunicare.Initializeaza();
            this.lctrlComunicare.Visible = true;
            this.lctrlComunicare.BringToFront();
        }

        private void initControlGestiuneListaDePreturi()
        {
            if (this.lctrlGestiuneListaDePreturi == null)
            {
                this.lctrlGestiuneListaDePreturi = new Setari.Lucrari.ControlGestiuneListaDePreturi();
                this.lctrlGestiuneListaDePreturi.Name = "ctrlGestiuneListaDePreturi";
                adaugaControlInZonaUtila(this.lctrlGestiuneListaDePreturi);
            }

            this.lctrlGestiuneListaDePreturi.Initializeaza();
            this.lctrlGestiuneListaDePreturi.Visible = true;
            this.lctrlGestiuneListaDePreturi.BringToFront();
        }

        private void initControlGestiuneLocatii()
        {
            if (this.lctrlGestiuneLocatii == null)
            {
                this.lctrlGestiuneLocatii = new Setari.Locatii.ControlListaLocatii();
                this.lctrlGestiuneLocatii.Name = "ctrlGestiuneLocatii";
                adaugaControlInZonaUtila(this.lctrlGestiuneLocatii);
            }

            this.lctrlGestiuneLocatii.Initializeaza();
            this.lctrlGestiuneLocatii.Visible = true;
            this.lctrlGestiuneLocatii.BringToFront();
        }

        private void initControlGestiuneDiverse()
        {
            if (this.lctrlGestiuneDiverse == null)
            {
                this.lctrlGestiuneDiverse = new Setari.Liste.ControlGestiuneListe();
                this.lctrlGestiuneDiverse.Name = "ctrlGestiuneDiverse";
                adaugaControlInZonaUtila(this.lctrlGestiuneDiverse);
            }

            this.lctrlGestiuneDiverse.Initializeaza();
            this.lctrlGestiuneDiverse.Visible = true;
            this.lctrlGestiuneDiverse.BringToFront();
        }

        private void initControlTablouDeBord()
        {
            if (this.lctrlTablouDeBord == null)
            {
                this.lctrlTablouDeBord = new TablouDeBord.ControlTablouDeBord();
                this.lctrlTablouDeBord.Name = "ctrlTablouDeBord";
                adaugaControlInZonaUtila(this.lctrlTablouDeBord);
            }

            this.lctrlTablouDeBord.Initializeaza();
            this.lctrlTablouDeBord.Visible = true;
            this.lctrlTablouDeBord.BringToFront();
        }

        #endregion

        private void incarcaOptiuneaSelectata(EnumOptiune pOptiune)
        {
            this.lOptiuneSelectata = pOptiune;
            if (this.lctrlGestiunePersonal != null)
                this.lctrlGestiunePersonal.Visible = false;
            if (this.lctrlGestiuneClienti != null)
                this.lctrlGestiuneClienti.Visible = false;
            if (this.lctrlGestiuneListaDePreturi != null)
                this.lctrlGestiuneListaDePreturi.Visible = false;
            if (this.lctrlGestiuneLocatii != null)
                this.lctrlGestiuneLocatii.Visible = false;
            if (this.lctrlGestiuneDiverse!= null)
                this.lctrlGestiuneDiverse.Visible = false;
            if (this.lctrlComunicare != null)
                this.lctrlComunicare.Visible = false;
            if (this.lctrlTablouDeBord != null)
                this.lctrlTablouDeBord.Visible = false;

            switch (pOptiune)
            {
                case EnumOptiune.SetariPersonal:
                    initControlGestiunePersonal();
                    break;
                case EnumOptiune.Clienti:
                    initControlGestiuneClienti();
                    break;
                case EnumOptiune.SetariListaPreturi:
                    initControlGestiuneListaDePreturi();
                    break;
                case EnumOptiune.SetariLocatii:
                    initControlGestiuneLocatii();
                    break;
                case EnumOptiune.SetariDiverse:
                    initControlGestiuneDiverse();
                    break;
                case EnumOptiune.Comunicare:
                    initControlGestiuneComunicare();
                    break;
                case EnumOptiune.TablouDeBord:
                    initControlTablouDeBord();
                    break;
            }
        }

        private void incepeIncarcarea()
        {
            this.lSeIncarca = true;
        }

        private void finalizeazaIncarcarea()
        {
            this.lSeIncarca = false;
        }

        private void schimbaOptiuneaActiva(ButonOptiuneMeniuStanga pSender)
        {
            EnumOptiune optiune = pSender.Optiune;

            foreach (Control panelRubrica in this.flpMeniuStanga.Controls)
            {
                if (panelRubrica is PanelOptiuniMeniuStanga)
                {
                    foreach (var butonOptiuni in panelRubrica.Controls)
                    {
                        if (butonOptiuni is ButonOptiuneMeniuStanga)
                        {
                            (butonOptiuni as ButonOptiuneMeniuStanga).SchimbaSelectia(butonOptiuni == pSender);
                        }
                    }
                }
            }

            incarcaOptiuneaSelectata(optiune);
        }

        private void schimbaDeschidereaRubricilor(ButonRubricaMeniuStanga pSender)
        {
            EnumRubrica rubricaNoua = pSender.Rubrica;
            foreach (Control btnRubrica in this.flpMeniuStanga.Controls)
            {
                if (btnRubrica is ButonRubricaMeniuStanga)
                {
                    if (btnRubrica == pSender)
                    {
                        (btnRubrica as ButonRubricaMeniuStanga).SchimbaDeschiderea(pSender.Deschis);
                    }
                    else
                        (btnRubrica as ButonRubricaMeniuStanga).SchimbaDeschiderea(false);
                }
            }
            this.lRubricaSelectata = rubricaNoua;

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

