using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ILL.iStomaLab;
using CDL.iStomaLab;
using CCL.iStomaLab;

namespace CCL.UI.FormulareComune
{
    public partial class frmInputBox : frmCuHeaderSiValidare
    {
        private Control lCtrlFocus = null;
        private string lEticheta;

        public enum EnumTipInput
        {
            TextMultiline = 0,
            ValoareMonetara = 1,
            TextParola = 2,
            TextSimplu = 3,
            ValoareNumerica = 4,
            Data = 5,
            DataOra = 6
        }

        #region Declaratii generale

        private EnumTipInput lTipInput = EnumTipInput.TextMultiline;
        private string lTextInitializare = string.Empty;
        private int lLungimeMaxima = 50;
        private DateTime lDataActuala = CConstante.DataNula;

        #endregion

        #region Enumerari si Structuri

        #endregion

        #region Proprietati

        public DateTime DataIntrodusa { get; private set; }

        public string TextIntrodus { get; private set; }

        public KeyValuePair<double, CDefinitiiComune.EnumTipMoneda> ValoareMonetara { get; private set; }
        public Tuple<double, CDefinitiiComune.EnumTipMoneda> ValoareMonetaraTuple { get { return new Tuple<double, CDefinitiiComune.EnumTipMoneda>(this.VMtxtValoare.ValoareDouble, VMctrlMoneda.Moneda); } }

        #endregion

        #region Constructor si Initializare

        public frmInputBox(CDefinitiiComune.EnumTipMoneda pMonedaImplicita, string pTitlu, string pEticheta, bool pDeschideLaPozitiaMouseului, bool pPermiteRedimensionarea)
            : this(pTitlu, pEticheta, pDeschideLaPozitiaMouseului, pPermiteRedimensionarea)
        {
            this.lTipInput = EnumTipInput.ValoareMonetara;
            this.VMtxtValoare.Goleste();
            this.VMctrlMoneda.Moneda = pMonedaImplicita;
        }

        public frmInputBox(CDefinitiiComune.EnumTipMoneda pMonedaImplicita, double pValoare, string pTitlu, string pEticheta, bool pDeschideLaPozitiaMouseului, bool pPermiteRedimensionarea)
            : this(pTitlu, pEticheta, pDeschideLaPozitiaMouseului, pPermiteRedimensionarea)
        {
            this.lTipInput = EnumTipInput.ValoareMonetara;
            this.VMtxtValoare.ValoareDouble = pValoare;

            if (pMonedaImplicita != CDefinitiiComune.EnumTipMoneda.Nedefinit)
                this.VMctrlMoneda.Moneda = pMonedaImplicita;
            else
                this.VMctrlMoneda.Moneda = CDefinitiiComune.EnumTipMoneda.Lei;
        }

        public frmInputBox(string pTitlu, string pEticheta, bool pDeschideLaPozitiaMouseului, bool pPermiteRedimensionarea)
        {
            InitializeComponent();

            this.Text = pTitlu;
            this.lEticheta = pEticheta;

            this.StartPosition = FormStartPosition.Manual;
            this.PermiteMaximizareaEcranului = pPermiteRedimensionarea;
            this.DeschideLaPozitiaMouseului = pDeschideLaPozitiaMouseului;
            this.PermiteDeplasareaEcranului = true;
            this.AcceptButton = this.btnValidare;

            if (this.DeschideLaPozitiaMouseului)
            {
                this.TipDeschidere = CEnumerariComune.EnumTipDeschidere.StangaJos;
                SeteazaPozitia();
            }
            else
            {
                this.TipDeschidere = CEnumerariComune.EnumTipDeschidere.CentrulEcranului;
                SeteazaPozitia();
            }

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                if (!string.IsNullOrEmpty(this.lEticheta))
                {
                    this.lblDenumireTextSimplu.Text = pEticheta;
                    this.VMlblValoare.Text = pEticheta;
                }
            }
        }

        public frmInputBox(EnumTipInput pTipValoare, DateTime pDataActuala, string pTitlu, string pEticheta)
            : this(pTitlu, pEticheta, true, false)
        {
            this.lTipInput = pTipValoare;
            this.lDataActuala = pDataActuala;
            this.DeschideLaPozitiaMouseului = true;
            this.SeteazaPozitia();
        }

        public frmInputBox(EnumTipInput pTipValoare, string pValoareActuala, string pTitlu, string pEticheta, int pLungimeMaxima, CCL.UI.CEnumerariComune.EnumTipDeschidere pTipDeschidere, int pLatimeEcran) :
            this(pTitlu, pEticheta, false, false)
        {
            if (pLatimeEcran > 0)
                this.Width = pLatimeEcran;
            this.lTipInput = pTipValoare;
            this.lTextInitializare = pValoareActuala;
            this.lLungimeMaxima = pLungimeMaxima;
            this.TipDeschidere = pTipDeschidere;
            this.DeschideLaPozitiaMouseului = true;
            this.SeteazaPozitia();
        }

        public frmInputBox(string pTitlu, string pEticheta, string pTextInitializare, int pLungimeMaxima,
            bool pDeschideLaPozitiaMouseului, bool pPermiteRedimensionarea, bool pParola)
            : this(pTitlu, pEticheta, pDeschideLaPozitiaMouseului, pPermiteRedimensionarea)
        {
            this.lTextInitializare = pTextInitializare;
            this.lLungimeMaxima = pLungimeMaxima;

            if (!pParola)
            {
                this.lTipInput = EnumTipInput.TextMultiline;
                this.txtContinut.Text = pTextInitializare;

                if (pLungimeMaxima > 0)
                    this.txtContinut.MaxLength = pLungimeMaxima;
                else
                    this.txtContinut.MaxLength = 4000; //nvarchar(MAX)
            }
            else
            {
                this.lTipInput = EnumTipInput.TextParola;
                this.PRLlblParola.Text = IHMUtile.getText(607);//Parola
                this.PRLchkAfiseazaCaracterele.Text = IHMUtile.getText(1378); //Afiseaza
                this.PRLtxtParola.Text = pTextInitializare;
                this.PRLtxtParola.CapitalizeazaCuvintele = false;
                this.PRLtxtParola.CapitalizeazaPrimaLitera = false;
                if (pLungimeMaxima > 0)
                    this.PRLtxtParola.MaxLength = pLungimeMaxima;
                else
                    this.PRLtxtParola.MaxLength = 50;
                if (string.IsNullOrEmpty(pTextInitializare))
                {
                    this.PRLchkAfiseazaCaracterele.Visible = true;
                    this.PRLchkAfiseazaCaracterele.Checked = false;
                }
                else
                    this.PRLchkAfiseazaCaracterele.Visible = false;
            }
        }

        private void frmInputBox_Load(object sender, EventArgs e)
        {
            if (this.lCtrlFocus != null)
                this.lCtrlFocus.Focus();
        }

        private void frmInputBox_Shown(object sender, EventArgs e)
        {
            Initializeaza();
            if (this.lCtrlFocus != null)
                this.lCtrlFocus.Focus();
        }

        public void Initializeaza()
        {
            switch (this.lTipInput)
            {
                case EnumTipInput.Data:
                    if (string.IsNullOrEmpty(this.lEticheta))
                        this.DATlblData.Text = CUtil.getText(1299);
                    else
                        this.DATlblData.Text = this.lEticheta;
                    this.panelData.Visible = true;
                    this.DATctrlData.DataAfisata = this.lDataActuala;
                    this.DATctrlData.setVizibilitateOra(false);
                    this.DATctrlData.Focus();
                    this.lCtrlFocus = this.DATctrlData;
                    break;
                case EnumTipInput.DataOra:
                    if (string.IsNullOrEmpty(this.lEticheta))
                        this.DATlblData.Text = CUtil.getText(1299);
                    else
                        this.DATlblData.Text = this.lEticheta;
                    this.panelData.Visible = true;
                    this.DATctrlData.DataAfisata = this.lDataActuala;
                    this.DATctrlData.setVizibilitateOra(true);
                    this.DATctrlData.Focus();
                    this.lCtrlFocus = this.DATctrlData;
                    break;
                case EnumTipInput.TextMultiline:
                    this.txtContinut.Visible = true;
                    this.txtContinut.Focus();
                    this.lCtrlFocus = this.txtContinut;
                    break;
                case EnumTipInput.ValoareMonetara:
                    this.panelValoareMonetara.Visible = true;
                    this.VMtxtValoare.Focus();
                    this.lCtrlFocus = this.VMtxtValoare;
                    break;
                case EnumTipInput.TextParola:
                    this.panelParola.Visible = true;
                    this.PRLtxtParola.Focus();
                    this.lCtrlFocus = this.PRLtxtParola;
                    break;
                case EnumTipInput.TextSimplu:
                case EnumTipInput.ValoareNumerica:
                    this.panelTextSimplu.Visible = true;

                    if (this.lTipInput == EnumTipInput.TextSimplu)
                    {
                        this.txtNumeric.Visible = false;
                        this.txtSimplu.Text = this.lTextInitializare;
                        this.txtSimplu.MaxLength = this.lLungimeMaxima;
                        this.txtSimplu.Focus();
                        this.lCtrlFocus = this.txtSimplu;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(this.lEticheta))
                            this.lblDenumireTextSimplu.Text = this.lEticheta;
                        else
                            this.lblDenumireTextSimplu.Text = this.Text;
                        this.txtSimplu.Visible = false;
                        this.txtNumeric.Text = this.lTextInitializare;
                        this.txtNumeric.MaxLength = this.lLungimeMaxima;
                        this.txtNumeric.SelectAll();
                        this.txtNumeric.Focus();
                        this.lCtrlFocus = this.txtNumeric;
                    }

                    //Pentru a se vedea ok
                    this.txtNumeric.Location = new System.Drawing.Point(Math.Max(this.txtNumeric.Location.X, this.lblDenumireTextSimplu.Location.X + this.lblDenumireTextSimplu.Width + 6), this.txtNumeric.Location.Y);
                    this.txtNumeric.Width = this.panelTextSimplu.Width - (this.txtNumeric.Location.X + this.lblDenumireTextSimplu.Location.X);

                    this.txtSimplu.Location = this.txtNumeric.Location;
                    this.txtSimplu.Width = this.txtNumeric.Width;

                    break;
            }
        }

        #endregion

        #region Evenimente

        private void btnValidare_Click(object sender, EventArgs e)
        {
            bool ok = true;
            switch (this.lTipInput)
            {
                case EnumTipInput.Data:
                    this.DataIntrodusa = this.DATctrlData.DataAfisata;
                    break;
                case EnumTipInput.DataOra:
                    this.DataIntrodusa = this.DATctrlData.DataAfisata;
                    break;
                case EnumTipInput.TextSimplu:
                    this.TextIntrodus = this.txtSimplu.Text;
                    break;
                case EnumTipInput.TextMultiline:
                    this.TextIntrodus = this.txtContinut.Text.Trim();
                    break;
                case EnumTipInput.ValoareMonetara:
                    if (ok)
                    {
                        this.TextIntrodus = this.VMtxtValoare.Text.Trim();
                        this.ValoareMonetara = new KeyValuePair<double, CDefinitiiComune.EnumTipMoneda>(
                                                        this.VMtxtValoare.ValoareDouble,
                                                        this.VMctrlMoneda.Moneda);
                    }
                    break;
                case EnumTipInput.TextParola:
                    this.TextIntrodus = this.PRLtxtParola.Text.Trim();
                    break;
                case EnumTipInput.ValoareNumerica:
                    this.TextIntrodus = this.txtNumeric.Text;
                    break;
            }
            if (ok)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void PRLchkAfiseazaCaracterele_CheckedChanged(object sender, EventArgs e)
        {
            this.PRLtxtParola.UseSystemPasswordChar = !this.PRLchkAfiseazaCaracterele.Checked;
        }

        #endregion

        #region Metode private


        #endregion

        #region Metode publice

        private void AllowModification(bool pEcranInModificare)
        {
            switch (this.lTipInput)
            {
                case EnumTipInput.TextMultiline:
                    this.txtContinut.AllowModification(pEcranInModificare);
                    break;
                case EnumTipInput.ValoareMonetara:
                    this.VMtxtValoare.AllowModification(pEcranInModificare);
                    this.VMctrlMoneda.AllowModification(pEcranInModificare);
                    break;
                case EnumTipInput.TextParola:
                    this.PRLtxtParola.AllowModification(pEcranInModificare);
                    break;
            }
        }

        public static Tuple<double, CDefinitiiComune.EnumTipMoneda> GetValoareMonetara(Form pEcranParinte, string pTitluEcran, double pValoareActuala, CDefinitiiComune.EnumTipMoneda pMonedaImplicita)
        {
            return GetValoareMonetara(pEcranParinte, pTitluEcran, pTitluEcran, pValoareActuala, pMonedaImplicita);
        }

        public static Tuple<double, CDefinitiiComune.EnumTipMoneda> GetValoareMonetara(Form pEcranParinte, string pTitluEcran, string pEticheta, double pValoareActuala, CDefinitiiComune.EnumTipMoneda pMonedaImplicita)
        {
            using (frmInputBox text = new frmInputBox(pMonedaImplicita, pValoareActuala, pTitluEcran, pEticheta, true, false))
            {
                if (IHMUtile.DeschideEcran(pEcranParinte, text))
                    return text.ValoareMonetaraTuple;

                return null;
            }
        }

        public static KeyValuePair<double, CDefinitiiComune.EnumTipMoneda> GetValoareMonetara(Form pEcranParinte, string pTitluEcran, CDefinitiiComune.EnumTipMoneda pMonedaImplicita)
        {
            return GetValoareMonetara(pEcranParinte, pTitluEcran, pTitluEcran, pMonedaImplicita);
        }

        public static KeyValuePair<double, CDefinitiiComune.EnumTipMoneda> GetValoareMonetara(Form pEcranParinte, string pTitluEcran, string pEticheta, CDefinitiiComune.EnumTipMoneda pMonedaImplicita)
        {
            using (frmInputBox text = new frmInputBox(pMonedaImplicita, pTitluEcran, pEticheta, true, false))
            {
                if (IHMUtile.DeschideEcran(pEcranParinte, text))
                    return text.ValoareMonetara;

                return new KeyValuePair<double, CDefinitiiComune.EnumTipMoneda>(0, CDefinitiiComune.EnumTipMoneda.Nedefinit);
            }
        }

        /// <summary>
        /// Titlul este folosit ca eticheta a zonei de text
        /// </summary>
        /// <param name="pTitlu"></param>
        /// <returns></returns>
        public static string GetTextSimpluUtilizator(Form pEcranParinte, string pTitlu)
        {
            using (frmInputBox text = new frmInputBox(EnumTipInput.TextSimplu, string.Empty, string.Empty, string.Empty, 100, CEnumerariComune.EnumTipDeschidere.StangaJos, 0))
            {
                text.lblDenumireTextSimplu.Text = pTitlu;

                if (IHMUtile.DeschideEcran(pEcranParinte, text))
                    return text.TextIntrodus;

                return string.Empty;
            }
        }

        public static string GetTextSimpluUtilizator(Form pEcranParinte, string pTitlu, string pEticheta, int pLungimeMaxima)
        {
            return GetTextSimpluUtilizator(pEcranParinte, pTitlu, pEticheta, string.Empty, pLungimeMaxima);
        }

        public static string GetTextSimpluUtilizator(Form pEcranParinte, string pTitlu, string pEticheta, string pTextActual, int pLungimeMaxima)
        {
            return GetTextSimpluUtilizator(pEcranParinte, pTitlu, pEticheta, pTextActual, pLungimeMaxima, false);
        }

        public static string GetTextSimpluUtilizator(Form pEcranParinte, string pTitlu, string pEticheta, string pTextActual, int pLungimeMaxima, bool pDeschideInCentrulEcranului)
        {
            using (frmInputBox text = new frmInputBox(EnumTipInput.TextSimplu, pTextActual, pTitlu, pEticheta, pLungimeMaxima, CEnumerariComune.EnumTipDeschidere.StangaJos, 0))
            {
                if (pDeschideInCentrulEcranului)
                    text.StartPosition = FormStartPosition.CenterScreen;

                if (IHMUtile.DeschideEcran(pEcranParinte, text))
                    return text.TextIntrodus;

                return string.Empty;
            }
        }

        public static string GetTextParolaUtilizator(Form pEcranParinte, string pTitlu, string pEticheta, string pTextActual, int pLungimeMaxima)
        {
            return GetTextParolaUtilizator(pEcranParinte, pTitlu, pEticheta, pTextActual, pLungimeMaxima, false); 
        }


        public static string GetTextUtilizator(Form pParinte, string pTitlu, string pEticheta, int pLungimeMaxima)
        {
            using (frmInputBox text = new frmInputBox(pTitlu, pEticheta, string.Empty, pLungimeMaxima, true, false, false))
            {
                if (CCL.UI.IHMUtile.DeschideEcran(pParinte, text))
                    return text.TextIntrodus;
                
                return string.Empty;
            }
        }

        public static string GetTextUtilizator(Form pParinte, string pTitluEcran, string pEticheta, string pTextActual, int pLungimeMaximaText, bool pEcranInModificare)
        {
            return GetTextUtilizator(pParinte, pTitluEcran, pEticheta, pTextActual, pLungimeMaximaText, pEcranInModificare, false, false);
        }

        public static string GetTextUtilizator(Form pParinte, string pTitluEcran, string pEticheta, string pTextActual, int pLungimeMaximaText, bool pEcranInModificare, bool pPermiteRedimensionarea, bool pNullDacaSeInchide)
        {
            using (frmInputBox text = new frmInputBox(pTitluEcran, pEticheta, pTextActual, pLungimeMaximaText, true, false, false))
            {
                text.PermiteMaximizareaEcranului = pPermiteRedimensionarea;
                text.PermiteRedimensionarea = pPermiteRedimensionarea;

                text.AllowModification(pEcranInModificare);

                if (CCL.UI.IHMUtile.DeschideEcran(pParinte, text))
                    return text.TextIntrodus;
                else
                    if (pNullDacaSeInchide)
                    return string.Empty;
                else
                    return pTextActual;
            }
        }

        public static int GetValoareNumerica(Form pParinte, string pTitluEcran, string pEticheta, int pTextActual, int pLungimeMaximaText, int pLatimeEcran, bool pEcranInModificare)
        {
            return GetValoareNumerica(pParinte, pTitluEcran, pEticheta, pTextActual, pLungimeMaximaText, pLatimeEcran, pEcranInModificare, false, false);
        }

        public static double GetValoareNumerica(Form pParinte, string pTitluEcran, string pEticheta, double pTextActual, int pLungimeMaximaText, int pLatimeEcran, bool pEcranInModificare)
        {
            using (frmInputBox text = new frmInputBox(EnumTipInput.ValoareNumerica, Convert.ToString(pTextActual), pTitluEcran, pEticheta, pLungimeMaximaText, CEnumerariComune.EnumTipDeschidere.StangaJos, pLatimeEcran))
            {
                text.AllowModification(pEcranInModificare);

                if (IHMUtile.DeschideEcran(pParinte, text))
                    return CUtil.GetTextDouble(text.TextIntrodus);

                return pTextActual;
            }
        }

        public static int GetValoareNumerica(Form pParinte, string pTitluEcran, string pEticheta, int pTextActual, int pLungimeMaximaText, int pLatimeEcran, bool pEcranInModificare, bool pReturneazaZeroDacaNuSeValideaza, bool pDeschideInCentrulEcranului)
        {
            using (frmInputBox text = new frmInputBox(EnumTipInput.ValoareNumerica, Convert.ToString(pTextActual), pTitluEcran, pEticheta, pLungimeMaximaText, pDeschideInCentrulEcranului ? CEnumerariComune.EnumTipDeschidere.CentrulEcranului : CEnumerariComune.EnumTipDeschidere.StangaJos, pLatimeEcran))
            {
                text.AllowModification(pEcranInModificare);

                if (IHMUtile.DeschideEcran(pParinte, text))
                    return CUtil.GetTextInt32(text.TextIntrodus);

                if (pReturneazaZeroDacaNuSeValideaza)
                    return 0;
                else
                    return pTextActual;
            }
        }

        public static double GetValoareProcentuala(Form pParinte, string pTitluEcran, string pEticheta, double pValoareActuala, int pLungimeMaximaText, int pLatimeEcran, bool pEcranInModificare)
        {
            using (frmInputBox text = new frmInputBox(EnumTipInput.ValoareNumerica, Convert.ToString(pValoareActuala), pTitluEcran, pEticheta, pLungimeMaximaText, CEnumerariComune.EnumTipDeschidere.StangaJos, pLatimeEcran))
            {
                text.AllowModification(pEcranInModificare);

                if (IHMUtile.DeschideEcran(pParinte, text))
                    return CUtil.GetTextDouble(text.TextIntrodus);

                return pValoareActuala;
            }
        }

        public static string GetTextParolaUtilizator(Form pParinte, string pTitluEcran, string pEticheta, string pTextActual, int pLungimeMaximaText, bool pDeschideInCentrulEcranului)
        {
            using (frmInputBox text = new frmInputBox(EnumTipInput.TextParola, pTextActual, pTitluEcran, pEticheta, pLungimeMaximaText, CEnumerariComune.EnumTipDeschidere.StangaJos, 0))
            {
                if (pDeschideInCentrulEcranului)
                    text.StartPosition = FormStartPosition.CenterScreen;

                if (IHMUtile.DeschideEcran(pParinte, text))
                    return text.TextIntrodus;

                return string.Empty;
            }

            //using (frmInputBox text = new frmInputBox(pTitluEcran, pEticheta, pTextActual, pLungimeMaximaText, !pDeschideInCentrulEcranului, false, true))
            //{
            //    if (IHMUtile.DeschideEcran(pParinte, text))
            //        return text.TextIntrodus;

            //    return pTextActual;
            //}
        }
    
        public static DateTime GetData(Form pParinte, DateTime pDataActuala, string pTitlu)
        {
            return GetData(pParinte, pDataActuala, pTitlu, string.Empty);
        }

        public static DateTime GetData(Form pParinte, DateTime pDataActuala, string pTitlu, string pEticheta)
        {
            using (frmInputBox data = new frmInputBox(EnumTipInput.Data, pDataActuala, pTitlu, pEticheta))
            {
                if (IHMUtile.DeschideEcran(pParinte, data))
                    return data.DataIntrodusa;

                return pDataActuala;
            }
        }

        public static DateTime GetData(Form pParinte, DateTime pDataActuala, string pTitlu, string pEticheta, bool pReturDataVidaNOK)
        {
            using (frmInputBox data = new frmInputBox(EnumTipInput.Data, pDataActuala, pTitlu, pEticheta))
            {
                if (IHMUtile.DeschideEcran(pParinte, data))
                    return data.DataIntrodusa;

                if (pReturDataVidaNOK)
                    return CConstante.DataNula;

                return pDataActuala;
            }
        }

        public static DateTime GetDataOra(Form pParinte, DateTime pData, string pTitlu, string pEticheta)
        {
            using (frmInputBox data = new frmInputBox(EnumTipInput.DataOra, pData, pTitlu, pEticheta))
            {
                if (IHMUtile.DeschideEcran(pParinte, data))
                    return data.DataIntrodusa;

                return pData;
            }
        }

        public static DateTime GetDataOraDataVida(Form pParinte, DateTime pData, string pTitlu, string pEticheta)
        {
            using (frmInputBox data = new frmInputBox(EnumTipInput.DataOra, pData, pTitlu, pEticheta))
            {
                if (IHMUtile.DeschideEcran(pParinte, data))
                    return data.DataIntrodusa;

                return CConstante.DataNula;
            }
        }

        #endregion

    }
}
