using System;
using System.Drawing;
using System.Windows.Forms;

namespace CCL.UI.FormulareComune
{
    public partial class frmToolTipEditabil : Form
    {
        public static event ToolTipEditabilDelegate DetaliiModificate = null;
        public static event ToolTipEditabilDelegate DorintaStergere = null;
        public delegate void ToolTipEditabilDelegate(frmToolTipEditabil pSender, object pObiectContinut, string pContinut);

        private static frmToolTipEditabil _SInstanta = null;
        private bool lInchide = true;
        private static string _STitlu = null;
        private static string _SContinut = null;
        private static object _SObiectContinut = null;
        private static bool _SPermiteModificarea = true;

        private void Initializeaza()
        {
            this.panelTextMultilinie.BackColor = Color.White;

            this.lblTitlu.Text = _STitlu;

            this.txtContinut.IsInReadOnlyMode = !_SPermiteModificarea;
            this.txtContinut.Text = _SContinut;

            this.btnSalveaza.Visible = _SPermiteModificarea;

            this.panelTextMultilinie.Visible = true;
        }

        private static void anuntaModificareaDetaliilor()
        {
            if (DetaliiModificate != null)
                DetaliiModificate(getInstanta(), _SObiectContinut, _SContinut);
        }

        private static void anuntaDorintaDeStergere()
        {
            if (DorintaStergere != null)
                DorintaStergere(getInstanta(), _SObiectContinut, _SContinut);
        }

        private static frmToolTipEditabil getInstanta()
        {
            if (_SInstanta == null || _SInstanta.Disposing || _SInstanta.IsDisposed)
                _SInstanta = new frmToolTipEditabil();

            return _SInstanta;
        }

        public frmToolTipEditabil()
        {
            InitializeComponent();

            this.panelTextMultilinie.BackColor = Color.WhiteSmoke;
        }

        public static void Afiseaza(object pObiectContinut, string pTitlu, string pContinut, bool pPermiteModificarea, bool pPermiteStergerea)
        {
            getInstanta().afiseaza(pPermiteStergerea);

            _SObiectContinut = pObiectContinut;
            _STitlu = pTitlu;
            _SContinut = pContinut;
            _SPermiteModificarea = pPermiteModificarea;
        }

        public static void Ascunde()
        {
            if (_SInstanta != null && !_SInstanta.Disposing && !_SInstanta.IsDisposed)
                _SInstanta.inchide();
        }

        public static void ForteazaInchiderea()
        {
            if (_SInstanta != null && !_SInstanta.Disposing && !_SInstanta.IsDisposed)
                _SInstanta.forteazaInchidereaEcranului();
        }

        private void inchide()
        {
            this.Close();
        }

        private void afiseaza(bool pPermiteStergerea)
        {
            this.txtContinut.BackColor = Color.White;
            this.lInchide = false;
            this.btnSterge.Visible = pPermiteStergerea;
            this.timerDeschidere.Start();
        }

        private void forteazaInchidereaEcranului()
        {
            this.lInchide = true;
            this.timerDeschidere.Stop();
            this.timerInchidere.Stop();
            this.Close();
        }

        public static void Distruge()
        {
            if (_SInstanta != null && !_SInstanta.IsDisposed)
            {
                _SInstanta.Dispose();
                _SInstanta = null;
            }
            _STitlu = null;
            _SContinut = null;
            _SObiectContinut = null;
        }

        private void btnSalveaza_Click(object sender, EventArgs e)
        {
            _SContinut = this.txtContinut.Text;
            anuntaModificareaDetaliilor();
        }

        private void btnSterge_Click(object sender, EventArgs e)
        {
            anuntaDorintaDeStergere();
        }

        private void picSus_MouseEnter(object sender, EventArgs e)
        {
            this.lInchide = false;
            //this.txtInterventii.Text += "i";
        }

        private void picSus_MouseLeave(object sender, EventArgs e)
        {
            //this.txtInterventii.Text += "O";
            inchide();
        }

        private void panelDetalii_Enter(object sender, EventArgs e)
        {
            this.lInchide = false;
            //this.txtInterventii.Text += "2";
        }

        private void panelDetalii_MouseEnter(object sender, EventArgs e)
        {
            this.lInchide = false;
            //this.txtInterventii.Text += "M";
        }

        private void txtInterventii_MouseEnter(object sender, EventArgs e)
        {
            this.lInchide = false;
        }

        private void frmToolTipPacientAgenda_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.lInchide)
            {
                e.Cancel = true;
                this.lInchide = true;
                this.timerInchidere.Start();
            }
        }

        private void timerInchidere_Tick(object sender, EventArgs e)
        {
            if (this.lInchide)
                this.Close();
        }

        private void timerDeschidere_Tick(object sender, EventArgs e)
        {
            if (!this.lInchide)
            {
                this.timerDeschidere.Stop();
                getInstanta().stabilesteLocatia();
                getInstanta().Initializeaza();
                getInstanta().Show();
            }
            else
                inchide();
        }

        private void stabilesteLocatia()
        {
            Size MarimeEcran = this.Size;

            //Unde afisam ecranul?
            this.StartPosition = FormStartPosition.Manual;
            Point PunctAfisaj = new Point(0, 0);
            PunctAfisaj = new Point(Control.MousePosition.X, Control.MousePosition.Y - 5);
            Image fundal = Properties.Resources.ToolTipChenar.Clone() as Image;

            //Verificam daca tipul de deschidere este posibil
            CEnumerariComune.EnumTipDeschidere pTipDeschidere = CEnumerariComune.EnumTipDeschidere.StangaJos;

            Screen ecranCurent = Screen.FromControl(this); //this is the Form class

            if (ecranCurent == null)
                ecranCurent = Screen.PrimaryScreen;

            //Se poate in stanga?
            if (PunctAfisaj.X - MarimeEcran.Width < 0 && (pTipDeschidere == CEnumerariComune.EnumTipDeschidere.StangaJos || pTipDeschidere == CEnumerariComune.EnumTipDeschidere.StangaSus))
            {
                if (pTipDeschidere == CEnumerariComune.EnumTipDeschidere.StangaJos)
                    pTipDeschidere = CEnumerariComune.EnumTipDeschidere.DreaptaJos;
                else
                    pTipDeschidere = CEnumerariComune.EnumTipDeschidere.DreaptaSus;
            }

            //Se poate in dreapta
            if (pTipDeschidere == CEnumerariComune.EnumTipDeschidere.DreaptaJos || pTipDeschidere == CEnumerariComune.EnumTipDeschidere.DreaptaSus)
            {
                if (ecranCurent.WorkingArea.Width < PunctAfisaj.X + MarimeEcran.Width)
                {
                    if (pTipDeschidere == CEnumerariComune.EnumTipDeschidere.DreaptaJos)
                        pTipDeschidere = CEnumerariComune.EnumTipDeschidere.StangaJos;
                    else
                        pTipDeschidere = CEnumerariComune.EnumTipDeschidere.StangaSus;
                }
            }

            //Se poate in sus?
            if (PunctAfisaj.Y - MarimeEcran.Height < 0 && (pTipDeschidere == CEnumerariComune.EnumTipDeschidere.StangaSus || pTipDeschidere == CEnumerariComune.EnumTipDeschidere.DreaptaSus))
            {
                if (pTipDeschidere == CEnumerariComune.EnumTipDeschidere.StangaSus)
                    pTipDeschidere = CEnumerariComune.EnumTipDeschidere.StangaJos;
                else
                    pTipDeschidere = CEnumerariComune.EnumTipDeschidere.DreaptaJos;
            }

            //Se poate in jos
            if (pTipDeschidere == CEnumerariComune.EnumTipDeschidere.DreaptaJos || pTipDeschidere == CEnumerariComune.EnumTipDeschidere.StangaJos)
            {
                if (ecranCurent.WorkingArea.Height < PunctAfisaj.Y + MarimeEcran.Height)
                {
                    if (pTipDeschidere == CEnumerariComune.EnumTipDeschidere.DreaptaJos)
                        pTipDeschidere = CEnumerariComune.EnumTipDeschidere.DreaptaSus;
                    else
                        pTipDeschidere = CEnumerariComune.EnumTipDeschidere.StangaSus;
                }
            }

            switch (pTipDeschidere)
            {
                case CEnumerariComune.EnumTipDeschidere.StangaSus:
                    PunctAfisaj.X -= this.Width - 45;
                    PunctAfisaj.Y -= (this.Height - 10);
                    fundal.RotateFlip(RotateFlipType.RotateNoneFlipXY);
                    this.panelTextMultilinie.Location = new Point(15, 10);
                    break;
                case CEnumerariComune.EnumTipDeschidere.DreaptaSus:
                    PunctAfisaj.X -= 45;
                    PunctAfisaj.Y -= (this.Height - 10);
                    fundal.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    this.panelTextMultilinie.Location = new Point(14, 10);
                    break;
                case CEnumerariComune.EnumTipDeschidere.DreaptaJos:
                    PunctAfisaj.X -= 40;
                    this.panelTextMultilinie.Location = new Point(14, 19);
                    break;
                case CEnumerariComune.EnumTipDeschidere.StangaJos:
                    PunctAfisaj.X -= this.Width - 45;
                    fundal.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    this.panelTextMultilinie.Location = new Point(14, 19);
                    break;
            }

            this.picSus.Image = fundal;
            this.Location = PunctAfisaj;
            fundal = null;
        }

    }
}
