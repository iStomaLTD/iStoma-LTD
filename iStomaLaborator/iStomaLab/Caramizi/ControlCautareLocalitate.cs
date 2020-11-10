using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.iStomaLab;
using BLL.iStomaLab.Referinta;

namespace iStomaLab.Caramizi
{
    public partial class ControlCautareLocalitate : ControlCautareElement
    {
        #region Declaratii generale

        public event System.EventHandler StergeObiectAfisaj;
        public event System.EventHandler SelecteazaObiectAfisaj;
        private frmAfiseazaRezultatCautareLocalitate lEcranCautare = null;
        private string lTextUltimaCautare = string.Empty;

        private StructIdDenumire lPersoanaSauOrganizatie = StructIdDenumire.Empty;
        private CCL.UI.CEnumerariComune.EnumTipDeschidere lTipDeschidere = CCL.UI.CEnumerariComune.EnumTipDeschidere.DreaptaSus;
        private int lIdRegiune = 0;

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

        public ControlCautareLocalitate()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            this.SizeChanged += ControlCautarePersoanaSauOrganizatie_SizeChanged;
        }

        void ControlCautarePersoanaSauOrganizatie_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                this.Initializeaza(this.lIdRegiune, this.lPersoanaSauOrganizatie, this.lTipDeschidere);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        public void Initializeaza(int pIdRegiuneInteres, StructIdDenumire pPersOrg, CCL.UI.CEnumerariComune.EnumTipDeschidere pTipDeschidere)
        {
            base.InitializeazaVariabileleGenerale();
            this.lPersoanaSauOrganizatie = pPersOrg;
            this.lTipDeschidere = pTipDeschidere;
            this.lIdRegiune = pIdRegiuneInteres;

            incepeIncarcarea();

            if (this.lPersoanaSauOrganizatie.AreValoare())
            {
                //Avem o localitate
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
                this.Initializeaza(this.lIdRegiune, StructIdDenumire.Empty, this.lTipDeschidere);
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
                    this.Initializeaza(this.lIdRegiune, pElement, this.lTipDeschidere);
                    ascundeEcranCautare();
                    anuntaSelectia();
                }
                else
                {
                    ascundeEcranCautare();

                    //Adaugam localitatea
                    int id = BLocalitati.Add(this.lIdRegiune, pElement.Denumire, 1, 1, 1, null);

                    this.lPersoanaSauOrganizatie = new StructIdDenumire(id, pElement.Denumire);

                    Initializeaza(this.lIdRegiune, this.lPersoanaSauOrganizatie, this.lTipDeschidere);
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
                this.lEcranCautare = new frmAfiseazaRezultatCautareLocalitate(this.lIdRegiune, this.txtCautare.Text);
                this.lEcranCautare.AplicaPreferintele();
                CCL.UI.IHMUtile.StabilesteLocatia(this.lEcranCautare, this, false, this.lTipDeschidere, false);
                this.lEcranCautare.ElementSelectat += lEcranCautare_ElementSelectat;
                this.lEcranCautare.InchideEcranul += lEcranCautare_InchideEcranul;
            }
            else
                this.lEcranCautare.Initializeaza(this.lIdRegiune, this.txtCautare.Text);

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
            this.txtCautare.AllowModification(this.lIdRegiune > 0 && this.lEcranInModificare);

            if (this.lPersoanaSauOrganizatie.AreValoare())
            {
                this.lblDenumire.Width = this.Width - (2 + (this.lEcranInModificare ? 3 + this.btnSterge.Width : 0));
            }
        }

        #endregion

    }
}
