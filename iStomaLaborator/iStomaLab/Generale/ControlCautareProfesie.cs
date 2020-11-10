using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iStomaLab.Caramizi;
using BLL.iStomaLab;
using BLL.iStomaLab.Referinta;

namespace iStomaLab.Generale
{
    public partial class ControlCautareProfesie : ControlCautareElement
    {

        #region Declaratii generale

        public event System.EventHandler StergeObiectAfisaj;
        public event System.EventHandler SelecteazaObiectAfisaj;
        private frmAfiseazaRezultatCautareProfesie lEcranCautare = null;
        private string lTextUltimaCautare = string.Empty;

        private StructIdDenumire lPersoanaSauOrganizatie = StructIdDenumire.Empty;
        private CCL.UI.CEnumerariComune.EnumTipDeschidere lTipDeschidere = CCL.UI.CEnumerariComune.EnumTipDeschidere.DreaptaSus;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati

        public StructIdDenumire ObiectAfisajCorespunzator
        {
            get { return this.lPersoanaSauOrganizatie; }
        }

        public int IdObiectAfisajCorespunzator { get { return this.lPersoanaSauOrganizatie.Id; } }

        #endregion

        #region Constructor si Initializare

        public ControlCautareProfesie()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            this.SizeChanged += ControlCautarePersoanaSauOrganizatie_SizeChanged;
            this.txtCautare.CerereUpdate += txtCautare_CerereUpdate;
            this.txtCautare.KeyUpPersonalizat += txtCautare_KeyUpPersonalizat;
            this.btnSterge.Click += btnSterge_Click;
            //this.lEcranCautare.InchideEcranul += lEcranCautare_InchideEcranul;
            //this.lEcranCautare.ElementSelectat += lEcranCautare_ElementSelectat;
        }
        
        public void Initializeaza(StructIdDenumire pPersOrg, CCL.UI.CEnumerariComune.EnumTipDeschidere pTipDeschidere)
        {
            base.InitializeazaVariabileleGenerale();
            this.lPersoanaSauOrganizatie = pPersOrg;
            this.lTipDeschidere = pTipDeschidere;

            incepeIncarcarea();

            if (this.lPersoanaSauOrganizatie.AreValoare())
            {
                //Avem o profesie
                this.lblDenumire.Text = this.lPersoanaSauOrganizatie.Denumire;
                this.lblDenumire.Width = this.Width - (2 + (this.lEcranInModificare ? 3 + this.btnSterge.Width : 0));
                this.btnSterge.Location = new Point(this.lblDenumire.Location.X + this.lblDenumire.Width + 3, this.btnSterge.Location.Y);
                this.txtCautare.Visible = false;
                this.btnSterge.Visible = this.lEcranInModificare;
                this.lblDenumire.Visible = true;
            }
            else
            {
                //Nu avem nimic
                this.lTextUltimaCautare = string.Empty;
                this.txtCautare.Location = new Point(1, this.txtCautare.Location.Y);
                this.txtCautare.Goleste();
                this.txtCautare.Width = this.Width - 2;
                this.txtCautare.Visible = true;
                this.btnSterge.Visible = false;
                this.lblDenumire.Visible = false;
            }

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        void ControlCautarePersoanaSauOrganizatie_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                this.Initializeaza(this.lPersoanaSauOrganizatie, this.lTipDeschidere);
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

        private void btnSterge_Click(object sender, EventArgs e)
        {
            if (!this.lEcranInModificare) return;

            try
            {
                this.lTextUltimaCautare = string.Empty;
                this.Initializeaza(StructIdDenumire.Empty, this.lTipDeschidere);
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
                    this.Initializeaza(pElement, this.lTipDeschidere);
                    ascundeEcranCautare();
                    anuntaSelectia();
                }
                else
                {
                    ascundeEcranCautare();

                    ////Adaugam profesia
                    int id = BProfesii.Add(pElement.Denumire, string.Empty, null);
                    this.lPersoanaSauOrganizatie = new BLL.iStomaLab.StructIdDenumire(id, pElement.Denumire);

                    Initializeaza(this.lPersoanaSauOrganizatie, this.lTipDeschidere);
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

        private void anuntaStergerea()
        {
            if (this.StergeObiectAfisaj != null)
                StergeObiectAfisaj(this, null);
        }

        private void anuntaSelectia()
        {
            if (this.SelecteazaObiectAfisaj != null)
                SelecteazaObiectAfisaj(this, null);
        }

        private void afiseazaCautare()
        {
            if (this.lEcranCautare == null)
            {
                this.lEcranCautare = new frmAfiseazaRezultatCautareProfesie(this.txtCautare.Text);
                this.lEcranCautare.AplicaPreferintele();
                CCL.UI.IHMUtile.StabilesteLocatia(this.lEcranCautare, this, false, this.lTipDeschidere, false);
                this.lEcranCautare.ElementSelectat += lEcranCautare_ElementSelectat;
                this.lEcranCautare.InchideEcranul += lEcranCautare_InchideEcranul;
            }
            else
            {
                this.lEcranCautare.AplicaPreferintele();
                CCL.UI.IHMUtile.StabilesteLocatia(this.lEcranCautare, this, false, this.lTipDeschidere, false);
                this.lEcranCautare.Initializeaza(this.txtCautare.Text);
            }

            this.lEcranCautare.Show();
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



        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
            this.btnSterge.Visible = this.lPersoanaSauOrganizatie.AreValoare() && this.lEcranInModificare;
            this.txtCautare.AllowModification(this.lEcranInModificare);

            if (this.lPersoanaSauOrganizatie.AreValoare())
            {
                this.lblDenumire.Width = this.Width - (2 + (this.lEcranInModificare ? 3 + this.btnSterge.Width : 0));
            }
        }

        #endregion

    }
}
