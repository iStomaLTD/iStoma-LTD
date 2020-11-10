using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CCL.UI
{
    public partial class frmCautare : FormulareComune.frmCuHeader
    {
        #region Declaratii Generale

        public event SelectareHandler SelecteazaLaPozitia;
        public delegate void SelectareHandler(int pPozitie, int pLungime);

        IMembriComuniControalePersonalizate lMembriComuni = null;
        List<int> lRezultateCautare = null;
        int lPozitieActualaListaRezultate = -1;

        #endregion

        public frmCautare(IMembriComuniControalePersonalizate pMembriComuni)
        {
            InitializeComponent();

            this.lMembriComuni = pMembriComuni;
            this.txtCauta.Text = pMembriComuni.SelectedText;
            this.txtCauta.PoateFiControlTinta = false;
            this.txtCauta.AcceptButton = this.btnValidare;
            this.btnValidare.Visible = false;

            this.Text = IHMUtile.getText(1234);
            this.CancelButton = this.btnInchidereEcran;
            this.lblCauta.Text = IHMUtile.getText(1233);

            DeschidereMouseStangaJosCuDeplasare();

            txtCauta_KeyUpPersonalizat(this.txtCauta, null);
        }

        private void txtCauta_KeyUpPersonalizat(object sender, KeyEventArgs e)
        {
            this.btnValidare.Visible = false;
            if (!string.IsNullOrEmpty(txtCauta.Text))
            {
                this.btnInainte.Visible = true;
                this.btnInapoi.Visible = true;
                this.lblRezultat.Visible = true;

                this.lRezultateCautare = lMembriComuni.Cauta(txtCauta.Text);
                if (lRezultateCautare.Count == 0)
                    this.lblRezultat.Text = IHMUtile.getText(1290);// "Textul cautat nu a fost gasit";
                else
                {
                    this.lblRezultat.Text = string.Format(IHMUtile.getText(1291), 1, lRezultateCautare.Count); // "1 din {0}"
                    this.lPozitieActualaListaRezultate = 0;
                    GenereazaEvenimentSchimbarePozitie(0);
                    this.btnValidare.Visible = this.lMembriComuni.AcceptaActiunea(EnumTipActiuneControl.ValidareCautare);
                }
            }
            else
            {
                this.btnInainte.Visible = false;
                this.btnInapoi.Visible = false;
                this.lblRezultat.Visible = false;
            }
        }

        private void txtCauta_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            txtCauta_KeyUpPersonalizat(psender, null);
        }

        private void btnInapoi_Click(object sender, EventArgs e)
        {
            if (lPozitieActualaListaRezultate > 0)
            {
                lPozitieActualaListaRezultate -= 1;
                GenereazaEvenimentSchimbarePozitie(lPozitieActualaListaRezultate);
            }
        }

        private void btnInainte_Click(object sender, EventArgs e)
        {
            if (lPozitieActualaListaRezultate < this.lRezultateCautare.Count - 1)
            {
                lPozitieActualaListaRezultate += 1;
                GenereazaEvenimentSchimbarePozitie(lPozitieActualaListaRezultate);
            }
        }

        private void GenereazaEvenimentSchimbarePozitie(int pPozitie)
        {
            if (this.SelecteazaLaPozitia != null)
            {
                //Fie gestioneaza ecranul apelant selectarea
                SelecteazaLaPozitia(lRezultateCautare[pPozitie], this.txtCauta.Text.Length);
            }
            else
            {
                //Fie o gestionam noi
                this.lMembriComuni.HideSelection = false;
                this.lMembriComuni.SelecteazaLaPozitia(lRezultateCautare[pPozitie], this.txtCauta.Text.Length);
                this.lMembriComuni.Focus();
            }

            this.lblRezultat.Text = string.Format(IHMUtile.getText(1291), pPozitie + 1, this.lRezultateCautare.Count);
        }

        private void frmCautare_Shown(object sender, EventArgs e)
        {
            this.txtCauta.Focus();
        }

        private void btnValidare_Click(object sender, EventArgs e)
        {
            if (this.lMembriComuni.AcceptaActiunea(EnumTipActiuneControl.ValidareCautare))
            {
                this.lMembriComuni.ExecutaActiunea(EnumTipActiuneControl.ValidareCautare);
                this.txtCauta.SelecteazaTextul();
                this.txtCauta.Focus();
            }
        }

    }
}
