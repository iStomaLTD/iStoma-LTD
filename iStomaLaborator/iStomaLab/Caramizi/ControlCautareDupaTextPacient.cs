﻿using System;
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
using CCL.UI;

namespace iStomaLab.Caramizi
{
    public partial class ControlCautareDupaTextPacient: ControlCautareElement
    {

        #region Declaratii generale

        public event System.EventHandler CerereUpdate;
        public event System.EventHandler StergeObiectAfisaj;
        public event System.EventHandler SelecteazaObiectAfisaj;      
        private frmAfiseazaRezultatCautarePacient lEcranCautare = null;
        private string lTextUltimaCautare = string.Empty;
        private int lIdClient= 0;   
        private BClientiPacienti pPacient = null;
        private StructIdDenumire lPersoanaSauOrganizatie = StructIdDenumire.Empty;
        private CCL.UI.CEnumerariComune.EnumTipDeschidere lTipDeschidere = CCL.UI.CEnumerariComune.EnumTipDeschidere.DreaptaJos;      
        private bool lAscundeDeschide = false;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati

        public TextBoxPersonalizat TextBox { get { return this.txtCautare.TextBox; } }

        public StructIdDenumire ObiectAfisajCorespunzator
        {
            get { return this.lPersoanaSauOrganizatie; }
        }

        public int IdObiectAfisajCorespunzator { get { return this.lPersoanaSauOrganizatie.Id; } }

        #endregion

        #region Constructor si Initializare

        public ControlCautareDupaTextPacient()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            this.SizeChanged += ControlCautarePersoanaSauOrganizatie_SizeChanged;
            this.txtCautare.CerereUpdate += txtCautare_CerereUpdate;
            this.txtCautare.KeyUpPersonalizat += txtCautare_KeyUpPersonalizat;
            this.btnSterge.Click += btnSterge_Click;
            this.btnDeschide.Click += BtnDeschide_Click;
        }

        public void Initializeaza(int pIdClient, StructIdDenumire pPersOrg, CCL.UI.CEnumerariComune.EnumTipDeschidere pTipDeschidere)
        {
            base.InitializeazaVariabileleGenerale();
            this.lPersoanaSauOrganizatie = pPersOrg;
            this.lTipDeschidere = pTipDeschidere;
            this.lIdClient = pIdClient;
            incepeIncarcarea();

            if (this.lPersoanaSauOrganizatie.AreValoare())
            {
                //Avem un pacient
                this.lblDenumire.Text = this.lPersoanaSauOrganizatie.Denumire;
                this.lblDenumire.Width = this.Width - (2 + (this.lEcranInModificare ? 3 + this.btnSterge.Width + this.btnDeschide.Width + 3 : 0));
                this.btnSterge.Location = new Point(this.lblDenumire.Location.X + this.lblDenumire.Width + 2, this.btnSterge.Location.Y);
                this.txtCautare.Visible = false;
                this.btnSterge.Visible = this.lEcranInModificare;
                this.lblDenumire.Visible = true;
            }
            else
            {
                //Nu avem nimic
                this.lTextUltimaCautare = string.Empty;
                this.txtCautare.Location = new Point(this.btnDeschide.Location.X + this.lblDenumire.Location.X - 4, this.txtCautare.Location.Y);
                this.txtCautare.Width = this.Width - this.btnDeschide.Width - 5;
                this.txtCautare.Visible = true;
                this.btnSterge.Visible = false;
                this.lblDenumire.Visible = false;
                this.txtCautare.Goleste();
            }

            if (this.lAscundeDeschide)
            {
                AscundeButonCautare();
            }

            finalizeazaIncarcarea();
        }

        public void AscundeButonCautare()
        {
            try
            {
                this.lAscundeDeschide = true;
                this.btnDeschide.Visible = false;
                this.txtCautare.Location = new Point(this.btnDeschide.Location.X, this.txtCautare.Location.Y);
                this.txtCautare.Width = this.Width;
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        #endregion

        #region Evenimente

        void ControlCautarePersoanaSauOrganizatie_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                this.Initializeaza(this.lIdClient, this.lPersoanaSauOrganizatie, this.lTipDeschidere);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        private void txtCautare_KeyUpPersonalizat(object sender, KeyEventArgs e)
        {
            if (!this.lEcranInModificare) return;

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (this.lEcranCautare != null)
                        this.lEcranCautare.Selecteaza();
                }
                else
                if (e.KeyCode == Keys.Down)
                {
                    if (this.lEcranCautare != null)
                        this.lEcranCautare.MutaSelectiaInJos();
                }
                else
                if (e.KeyCode == Keys.Up)
                {
                    if (this.lEcranCautare != null)
                        this.lEcranCautare.MutaSelectiaInSus();
                }
                else
                if (e.KeyCode == Keys.Escape)
                {
                    this.txtCautare.Goleste();
                    this.lTextUltimaCautare = string.Empty;
                    ascundeEcranCautare();
                }
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        private void txtCautare_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            if (!this.lEcranInModificare) return;
            try
            {
                if (!this.lTextUltimaCautare.Equals(this.txtCautare.Text))
                {
                    this.lTextUltimaCautare = this.txtCautare.Text;

                    if (!string.IsNullOrEmpty(this.lTextUltimaCautare))
                        afiseazaCautare();
                    else
                        ascundeEcranCautare();
                }
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        private void BtnDeschide_Click(object sender, EventArgs e)
        {
           
            if (this.lSeIncarca) return;
            try
            {
               incepeIncarcarea();

               BClientiPacienti pacient = FormCuPacienti.Afiseaza(this.GetFormParinte(),BClienti.getClient(this.lIdClient,null),pPacient);               

                if (pacient != null)
                {
                    this.Initializeaza(this.lIdClient, new StructIdDenumire(pacient.Id, BClientiPacienti.getPacient(pacient.Id, null).DenumireAfisaj), this.lTipDeschidere);
                   
                    ascundeEcranCautare();
                    anuntaSelectia();
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

        private void btnSterge_Click(object sender, EventArgs e)
        {
            if (!this.lEcranInModificare) return;

            try
            {
                this.lTextUltimaCautare = string.Empty;
                this.Initializeaza(this.lIdClient, StructIdDenumire.Empty, this.lTipDeschidere) ;
                anuntaStergerea();
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        void lEcranCautare_InchideEcranul(object sender, EventArgs e)
        {
            try
            {
                this.lTextUltimaCautare = string.Empty;
                this.txtCautare.Goleste();
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        void lEcranCautare_ElementSelectat(StructIdDenumire pElement)
        {
            try
            {
                if (pElement.Id > 0)
                 {
                     this.Initializeaza(this.lIdClient, pElement, this.lTipDeschidere);
                     ascundeEcranCautare();
                     anuntaSelectia();
                 }
                 else
                 {  
                   //Adaugam pacient nou
                    ascundeEcranCautare();
                    int idPac = 0;
                    frmAfiseazaRezultatCautarePacient.GetIdPacient(ref idPac);      // recuperam ultimul id pacient din BD              
                   
                    this.lPersoanaSauOrganizatie = new StructIdDenumire(idPac, pElement.Denumire); 
                    //Initializeaza(this.lIdClient, this.lPersoanaSauOrganizatie, this.lTipDeschidere);
                    Initializeaza(this.lIdClient, new StructIdDenumire(idPac, BClientiPacienti.getPacient(idPac, null).DenumireAfisaj), this.lTipDeschidere);
                    anuntaSelectia();
                 }
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }
        #endregion

        #region Metode private
    
        private void anuntaCerereUpdate()
        {
            if (this.CerereUpdate != null)
                CerereUpdate(this, null);
        }

        private void anuntaStergerea()
        {
            if (this.StergeObiectAfisaj != null)
                StergeObiectAfisaj(this, null);
            else
                anuntaCerereUpdate();
        }

        private void anuntaSelectia()
        {
            if (this.SelecteazaObiectAfisaj != null)
                SelecteazaObiectAfisaj(this, null);
            else
                anuntaCerereUpdate();
        }

        private void afiseazaCautare()
        {
            BClienti pClient = this.lIdClient > 0 ? new BClienti(this.lIdClient) : BClienti.getClient(this.lIdClient, null);
            if (this.lEcranCautare == null)
            {
                this.lEcranCautare = new frmAfiseazaRezultatCautarePacient(pClient,pPacient, this.txtCautarePacient.Text);                
                this.lEcranCautare.AplicaPreferintele();
                this.lEcranCautare.ElementSelectat += lEcranCautare_ElementSelectat;
                CCL.UI.IHMUtile.StabilesteLocatia(this.lEcranCautare, this.txtCautare, false, this.lTipDeschidere, false);               
                this.lEcranCautare.InchideEcranul += lEcranCautare_InchideEcranul;
            }
            else
            {
                this.lEcranCautare.AplicaPreferintele();               
                CCL.UI.IHMUtile.StabilesteLocatia(this.lEcranCautare, this.txtCautare, false, this.lTipDeschidere, false);
                this.lEcranCautare.Initializeaza(lIdClient ,this.txtCautare.Text);  
            }
            this.lEcranCautare.Show();
        }

        public void Goleste()
        {
            Initializeaza(this.lIdClient,StructIdDenumire.Empty, this.lTipDeschidere);
        }

        private void ascundeEcranCautare()
        {
            if (this.lEcranCautare != null)
            {
                this.lEcranCautare.Hide();
                this.lEcranCautare.DistrugeCautarea();
            }
        }    
      
        #endregion

        #region Metode publice

        public BClienti GetClient()
        {
            if (this.IdObiectAfisajCorespunzator > 0)
                return new BClienti(this.IdObiectAfisajCorespunzator);

            return null;
        }

        public bool AreValoare()
        {
            return this.IdObiectAfisajCorespunzator > 0;
        }

        public void AscundeEcranRezultatCautare()
        {
            ascundeEcranCautare();
        }

        public int GetIdPacient()
        {
            return this.IdObiectAfisajCorespunzator;
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
            this.btnSterge.Visible = this.lPersoanaSauOrganizatie.AreValoare() && this.lEcranInModificare;
            this.txtCautare.AllowModification(this.lEcranInModificare);

            if (this.lPersoanaSauOrganizatie.AreValoare())
            {
                if (this.lEcranInModificare)
                {
                    this.lblDenumire.Width = this.Width - (5 + this.btnSterge.Width + this.btnDeschide.Width);
                }
                else
                {
                    this.lblDenumire.Width = this.Width - 2;
                    this.lblDenumire.Location = new Point(1, this.lblDenumire.Location.Y);
                }
            }
        }

        #endregion
    }
}
