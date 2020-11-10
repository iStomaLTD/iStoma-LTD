using CCL.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using BLL.iStomaLab;
using System.Runtime.InteropServices;
using BLL.iStomaLab.Utilizatori;
using CCL.iStomaLab;

namespace iStomaLab.Generale
{
    public partial class FormLogin : Form
    {

        #region Declaratii generale

        //necesare pentru mutarea formului
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        internal FormLogin()
        {
            this.DoubleBuffered = true;

            InitializeComponent();

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                adaugaHandlere();
                initTextML();
            }

            this.txtBoxContUtilizator.Focus();
        }

        #region metode si declaratii pentru mutarea form-ului
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        #endregion

        private void adaugaHandlere()
        {
            this.Load += _Load;
            this.controlValidareAnulareLogin.Validare += ControlValidareAnulareLogin_Validare;
            this.controlValidareAnulareLogin.Anulare += ControlValidareAnulareLogin_Anulare;
            this.panelPersonalizatLogin.MouseDown += PanelPersonalizatLogin_MouseDown;
            this.btnMinimineaza.Click += BtnMinimineaza_Click;
            this.Shown += FormLogin_Shown;
        }

        private void initTextML()
        {
            this.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Conectare);
            this.lblContUtilizator.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Cont);
            this.lblParola.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Parola);
            this.chkPastreazaUserLogat.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PastreazaMaConectat);
        }

        void _Load(object sender, EventArgs e)
        {
            try
            {
                Initializeaza();
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this, ex);
            }
        }

        private void FormLogin_Shown(object sender, EventArgs e)
        {
            if (this.txtBoxContUtilizator.AreValoare())
                this.txtBoxParolaUtilizator.Focus();
        }

        public void Initializeaza()
        {
            CCL.UI.IHMUtile.SeteazaProprietatiButonMinimizare(this.btnMinimineaza);

            string ultimulUserConectat = CCL.iStomaLab.Utile.CGestiuneIO.getUltimulUtilizatorConectat();
            if (ultimulUserConectat != string.Empty)
            {
                this.txtBoxContUtilizator.Text = ultimulUserConectat;
            }

            //BColectieUtilizator listaRetur = BUtilizator.GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, CDL.iStomaLab.CDefinitiiComune.EnumRol.Nedefinit, null);

            //if (CUtil.EsteListaVida(listaRetur))
            //{
            //    this.txtBoxContUtilizator.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.admin);
            //    this.txtBoxParolaUtilizator.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.admin);

            //    BUtilizator.AddAdmin(null);
            //}

            this.chkPastreazaUserLogat.Checked = false;
        }

        #endregion

        #region Evenimente

        private void BtnMinimineaza_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PanelPersonalizatLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void ControlValidareAnulareLogin_Anulare(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ControlValidareAnulareLogin_Validare(object sender, EventArgs e)
        {
            verificaConectarea();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Enter)
            {
                verificaConectarea();
            }
            else if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            return base.ProcessDialogKey(keyData);
        }

        #endregion

        #region Metode private

        private void seteazaAlerta()
        {
            IHMEfecteSpeciale.AplicaEfectNU(this);
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.txtBoxContUtilizator, this.lblContUtilizator);
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.txtBoxParolaUtilizator, this.lblParola);

            Control[] lstControale = { this.txtBoxContUtilizator, this.txtBoxParolaUtilizator };
            foreach (var control in lstControale)
            {
                if (string.IsNullOrEmpty(control.Text))
                {
                    control.Focus();
                    break;
                }
                else
                {
                    this.txtBoxParolaUtilizator.Focus();
                }
            }
        }

        private void verificaConectarea()
        {
            if (!string.IsNullOrEmpty(this.txtBoxContUtilizator.Text) && !string.IsNullOrEmpty(this.txtBoxParolaUtilizator.Text))
            {
                if (BUtilizator.Conectare(this.txtBoxContUtilizator.Text, this.txtBoxParolaUtilizator.Text, this.chkPastreazaUserLogat.Checked, null) != null)
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }
                else
                {
                    seteazaAlerta();
                }
            }
            else
            {
                seteazaAlerta();
            }
        }

        private void dezactiveazaCapsLock()
        {
            //if (Control.IsKeyLocked(Keys.CapsLock))
            //{
            //    const int KEYEVENTF_EXTENDEDKEY = 0x1;
            //    const int KEYEVENTF_KEYUP = 0x2;
            //    keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
            //    keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP,
            //    (UIntPtr)0);
            //}
        }

        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente)
        {
            using (FormLogin ecran = new FormLogin())
            {
                return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
            }
        }

        #endregion

        #region IControlDava Members

        #endregion

    }
}
