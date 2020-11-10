using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CDL.iStomaLab;
using iStomaLab.Generale;
using CCL.iStomaLab;
using BLL.iStomaLab;

namespace iStomaLab.Caramizi
{
    [DefaultEvent("PerioadaSchimbata")]
    public partial class ControlPerioada : UserControlPersonalizat
    {
        #region Declaratii generale

        public event System.EventHandler PerioadaSchimbata;
        private CDefinitiiComune.EnumTipPerioada lTipPerioada = CDefinitiiComune.EnumTipPerioada.Luna;
        private bool lSpreViitor = false;
        private bool lEsteInitializat = false;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati

        public CDefinitiiComune.EnumTipPerioada TipPerioada { get { return this.lTipPerioada; } }
        public DateTime DataInceput { get { return CUtil.GetPrimaOraDinData(this.datInceput.DataAfisata); } }
        public DateTime DataSfarsit { get { return CUtil.GetUltimaOraDinData(this.datSfarsit.DataAfisata); } }

        public string EtichetaPerioada { get { return this.lblPerioadaAfisata.Text; } }

        #endregion

        #region Constructor si Initializare

        public ControlPerioada()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            //Adaugam handlerele
            this.datInceput.CerereUpdate += datInceput_CerereUpdate;
            this.datSfarsit.CerereUpdate += datSfarsit_CerereUpdate;
            this.btnAnulTrecut.Click += btnAnulTrecut_Click;
            this.btnAnulAcesta.Click += btnAnulAcesta_Click;
            this.btnLunaTrecuta.Click += btnLunaTrecuta_Click;
            this.btnLunaAsta.Click += btnLunaAsta_Click;
            this.btnSaptamanaTrecuta.Click += btnSaptamanaTrecuta_Click;
            this.btnSaptamanaAsta.Click += btnSaptamanaAsta_Click;
            this.btnAstazi.Click += btnAstazi_Click;
            this.btnInapoi.Click += btnInapoi_Click;
            this.btnInainte.Click += btnInainte_Click;
            this.btnCustom.Click += BtnCustom_Click;

            this.lblPerioadaAfisata.Cursor = Cursors.Hand;
            this.lblPerioadaAfisata.MouseEnter += LblPerioadaAfisata_MouseEnter;
            this.lblPerioadaAfisata.MouseLeave += LblPerioadaAfisata_MouseLeave;
            this.lblPerioadaAfisata.Click += LblPerioadaAfisata_Click;

            //Aplicam multilingv-ul
            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                this.btnCustom.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Schimba);
                this.btnAnulAcesta.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.AnulAcesta);
                this.btnAnulTrecut.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.AnulTrecut);
                this.btnLunaAsta.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.LunaAceasta);
                this.btnLunaTrecuta.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.LunaTrecuta);
                this.btnSaptamanaAsta.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.SaptamanaAceasta);
                this.btnSaptamanaTrecuta.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.SaptamanaTrecuta);
                this.btnAstazi.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Astazi);

                this.datInceput.AllowModification(false);
                this.datSfarsit.AllowModification(false);
            }
        }

        public void Initializeaza(CDefinitiiComune.EnumTipPerioada pTipPerioada, DateTime pDataReferinta)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.lEsteInitializat = true;

            if (pDataReferinta == CConstante.DataNula)
                pDataReferinta = DateTime.Today;

            seteazaPerioada(pTipPerioada, pDataReferinta);

            finalizeazaIncarcarea();
        }

        public void Initializeaza(DateTime pDataInceput, DateTime pDataSfarsit)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.datInceput.DataAfisata = pDataInceput;
            this.datSfarsit.DataAfisata = pDataSfarsit;

            CDefinitiiComune.EnumTipPerioada tipPerioada = CDefinitiiComune.EnumTipPerioada.Custom;
            if (pDataInceput.Date == pDataSfarsit.Date)
                tipPerioada = CDefinitiiComune.EnumTipPerioada.Zi;
            else
                if (pDataInceput.DayOfWeek == DayOfWeek.Monday && pDataSfarsit.DayOfWeek == DayOfWeek.Sunday && DateAndTime.DateDiff(DateInterval.Day, pDataInceput, pDataInceput) < 8)
                tipPerioada = CDefinitiiComune.EnumTipPerioada.Saptamana;

            seteazaPerioada(tipPerioada, pDataInceput);

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void BtnCustom_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                Tuple<DateTime, DateTime> perioada = IHMUtile.GetPerioada(this.GetFormParinte(), this.DataInceput, this.DataSfarsit);

                if (perioada != null && perioada.Item1 != this.DataInceput && perioada.Item2 != this.DataSfarsit)
                {
                    this.lTipPerioada = CDefinitiiComune.EnumTipPerioada.Custom;
                    this.datInceput.DataAfisata = perioada.Item1;
                    this.datSfarsit.DataAfisata = perioada.Item2;

                    afiseazaPerioda();

                    anuntaSchimbareaPerioadei();
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

        private void LblPerioadaAfisata_Click(object sender, EventArgs e)
        {
            try
            {
                incepeIncarcarea();

                DateTime dataAleasa = CCL.UI.frmControlBox.GetData(this.GetFormParinte(), this.DataInceput);

                if (dataAleasa != CConstante.DataNula && dataAleasa != this.DataInceput)
                {
                    seteazaPerioada(CDefinitiiComune.EnumTipPerioada.Zi, dataAleasa);
                    afiseazaPerioda();

                    anuntaSchimbareaPerioadei();
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

        private void LblPerioadaAfisata_MouseLeave(object sender, EventArgs e)
        {
            this.lblPerioadaAfisata.ForeColor = System.Drawing.Color.Black;// this.lPreferinteUtilizator.CuloareText;
        }

        private void LblPerioadaAfisata_MouseEnter(object sender, EventArgs e)
        {
            this.lblPerioadaAfisata.ForeColor = System.Drawing.Color.Green;
        }

        private void btnInapoi_Click(object sender, EventArgs e)
        {
            try
            {
                incepeIncarcarea();
                schimbaPerioada(false);
                anuntaSchimbareaPerioadei();
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

        private void btnInainte_Click(object sender, EventArgs e)
        {
            try
            {
                incepeIncarcarea();
                schimbaPerioada(true);
                anuntaSchimbareaPerioadei();
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

        private void btnAstazi_Click(object sender, EventArgs e)
        {
            try
            {
                incepeIncarcarea();
                seteazaPerioada(CDefinitiiComune.EnumTipPerioada.Zi, DateTime.Today);
                anuntaSchimbareaPerioadei();
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

        private void btnSaptamanaAsta_Click(object sender, EventArgs e)
        {
            try
            {
                incepeIncarcarea();
                seteazaPerioada(CDefinitiiComune.EnumTipPerioada.Saptamana, DateTime.Today);
                anuntaSchimbareaPerioadei();
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

        private void btnSaptamanaTrecuta_Click(object sender, EventArgs e)
        {
            try
            {
                incepeIncarcarea();

                bool perioadaSelectata = false;
                if (this.lTipPerioada == CDefinitiiComune.EnumTipPerioada.Zi)
                {
                    if (CUtil.GetNumarSaptamana(this.datInceput.DataAfisata) != CUtil.GetNumarSaptamana(DateTime.Today.AddDays(this.lSpreViitor ? 7 : -7)))
                    {
                        //Ne pozitionam pe aceeasi zi a saptamanii trecute
                        perioadaSelectata = true;
                        int nrSaptamana = CUtil.GetNumarSaptamanaLuna(this.datInceput.DataAfisata);
                        seteazaPerioada(CDefinitiiComune.EnumTipPerioada.Zi, CUtil.GetDataZiSaptamana(this.datInceput.DataAfisata.DayOfWeek, CUtil.GetZiLuniDinSaptamanaLunii(DateTime.Today.AddDays(this.lSpreViitor ? 7 : -7), nrSaptamana)));
                    }
                }

                if (!perioadaSelectata)
                    seteazaPerioada(CDefinitiiComune.EnumTipPerioada.Saptamana, this.lSpreViitor ? DateTime.Today.AddDays(7) : DateTime.Today.AddDays(-7));

                anuntaSchimbareaPerioadei();
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

        private void btnLunaAsta_Click(object sender, EventArgs e)
        {
            try
            {
                incepeIncarcarea();
                seteazaPerioada(CDefinitiiComune.EnumTipPerioada.Luna, DateTime.Today);
                anuntaSchimbareaPerioadei();
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

        private void btnLunaTrecuta_Click(object sender, EventArgs e)
        {
            try
            {
                incepeIncarcarea();

                bool perioadaSelectata = false;
                if (this.lTipPerioada != CDefinitiiComune.EnumTipPerioada.Luna && this.lTipPerioada != CDefinitiiComune.EnumTipPerioada.An)
                {
                    if (this.datInceput.DataAfisata.Month != DateTime.Today.AddMonths(this.lSpreViitor ? 1 : -1).Month)
                    {
                        perioadaSelectata = true;
                        if (this.lTipPerioada == CDefinitiiComune.EnumTipPerioada.Saptamana)
                        {
                            //Ne pozitionam pe aceeasi saptamana dar luna trecuta
                            int nrSaptamana = CUtil.GetNumarSaptamanaLuna(this.datInceput.DataAfisata);
                            seteazaPerioada(CDefinitiiComune.EnumTipPerioada.Saptamana, CUtil.GetZiLuniDinSaptamanaLunii(DateTime.Today.AddMonths(this.lSpreViitor ? 1 : -1), nrSaptamana));
                        }
                        else
                            if (this.lTipPerioada == CDefinitiiComune.EnumTipPerioada.Zi)
                        {
                            //Ne pozitionam pe aceeasi zi dar din aceeasi saptamana a anului trecut
                            int nrSaptamana = CUtil.GetNumarSaptamanaLuna(this.datInceput.DataAfisata);
                            seteazaPerioada(CDefinitiiComune.EnumTipPerioada.Zi, CUtil.GetDataZiSaptamana(this.datInceput.DataAfisata.DayOfWeek, CUtil.GetZiLuniDinSaptamanaLunii(DateTime.Today.AddMonths(this.lSpreViitor ? 1 : -1), nrSaptamana)));
                        }
                        else
                        {
                            seteazaPerioada(CDefinitiiComune.EnumTipPerioada.Luna, DateTime.Today.AddMonths(-1));
                        }
                    }
                }

                if (!perioadaSelectata)
                    seteazaPerioada(CDefinitiiComune.EnumTipPerioada.Luna, this.lSpreViitor ? DateTime.Today.AddMonths(1) : DateTime.Today.AddMonths(-1));

                anuntaSchimbareaPerioadei();
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

        private void btnAnulAcesta_Click(object sender, EventArgs e)
        {
            try
            {
                incepeIncarcarea();
                seteazaPerioada(CDefinitiiComune.EnumTipPerioada.An, DateTime.Today);
                anuntaSchimbareaPerioadei();
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

        private void btnAnulTrecut_Click(object sender, EventArgs e)
        {
            try
            {
                incepeIncarcarea();
                bool perioadaSelectata = false;
                if (this.lTipPerioada != CDefinitiiComune.EnumTipPerioada.An)
                {
                    if (this.datInceput.DataAfisata.Year != DateTime.Today.AddYears(this.lSpreViitor ? 1 : -1).Year)
                    {
                        perioadaSelectata = true;
                        if (this.lTipPerioada == CDefinitiiComune.EnumTipPerioada.Luna)
                        {
                            //Ne pozitionam pe aceeasi luna dar din anul trecut/viitor
                            seteazaPerioada(CDefinitiiComune.EnumTipPerioada.Luna, (this.datInceput.AreValoare() ? this.datInceput.DataAfisata : DateTime.Today).AddYears(this.lSpreViitor ? 1 : -1));
                        }
                        else
                            if (this.lTipPerioada == CDefinitiiComune.EnumTipPerioada.Saptamana)
                        {
                            //Ne pozitionam pe aceeasi saptamana dar anul trecut
                            int nrSaptamana = CUtil.GetNumarSaptamana(this.datInceput.DataAfisata);
                            seteazaPerioada(CDefinitiiComune.EnumTipPerioada.Saptamana, CUtil.GetZiLuniDinSaptamana((this.datInceput.AreValoare() ? this.datInceput.DataAfisata : DateTime.Today).AddYears(this.lSpreViitor ? 1 : -1), nrSaptamana));
                        }
                        else
                                if (this.lTipPerioada == CDefinitiiComune.EnumTipPerioada.Zi)
                        {
                            //Ne pozitionam pe aceeasi zi dar din aceeasi saptamana a anului trecut
                            int nrSaptamana = CUtil.GetNumarSaptamana(this.datInceput.DataAfisata);
                            seteazaPerioada(CDefinitiiComune.EnumTipPerioada.Zi, CUtil.GetDataZiSaptamana(this.datInceput.DataAfisata.DayOfWeek, CUtil.GetZiLuniDinSaptamana((this.datInceput.AreValoare() ? this.datInceput.DataAfisata : DateTime.Today).AddYears(this.lSpreViitor ? 1 : -1), nrSaptamana)));
                        }
                    }
                }

                if (!perioadaSelectata)
                    seteazaPerioada(CDefinitiiComune.EnumTipPerioada.An, this.lSpreViitor ? DateTime.Today.AddYears(1) : DateTime.Today.AddYears(-1));
                anuntaSchimbareaPerioadei();
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

        private void datInceput_CerereUpdate(Control psender, string proprietate, object sNouaValoare)
        {
            if (this.lSeIncarca) return;

            try
            {
                incepeIncarcarea();

                if (!this.datInceput.AreValoare())
                    seteazaPerioada(CDefinitiiComune.EnumTipPerioada.Luna, DateTime.Today);
                else
                {
                    if (this.datSfarsit.AreValoare() && this.datInceput.DataAfisata > this.datSfarsit.DataAfisata)
                    {
                        this.datSfarsit.DataAfisata = this.datInceput.DataAfisata;
                        seteazaPerioada(CDefinitiiComune.EnumTipPerioada.Zi, this.datInceput.DataAfisata);
                    }
                    else
                        seteazaPerioada(CDefinitiiComune.EnumTipPerioada.Custom, this.datInceput.DataAfisata);
                }

                anuntaSchimbareaPerioadei();
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

        public bool EstePerioadaSintezaGrafica()
        {
            return DateAndTime.DateDiff(DateInterval.Day, this.DataInceput, this.DataSfarsit) > 90;
        }

        private void datSfarsit_CerereUpdate(Control psender, string proprietate, object sNouaValoare)
        {
            try
            {
                incepeIncarcarea();

                if (!this.datSfarsit.AreValoare())
                    seteazaPerioada(CDefinitiiComune.EnumTipPerioada.Luna, DateTime.Today);
                else
                {
                    if (this.datInceput.AreValoare() && this.datInceput.DataAfisata > this.datSfarsit.DataAfisata)
                    {
                        this.datInceput.DataAfisata = this.datSfarsit.DataAfisata;
                        seteazaPerioada(CDefinitiiComune.EnumTipPerioada.Zi, this.datInceput.DataAfisata);
                    }
                    else
                    {
                        CDefinitiiComune.EnumTipPerioada tipPer = CDefinitiiComune.EnumTipPerioada.Custom;
                        if (this.datInceput.AreValoare() && this.datSfarsit.AreValoare())
                        {
                            if (DateAndTime.DateDiff(DateInterval.Day, this.datInceput.DataAfisata, this.datSfarsit.DataAfisata) <= 1)
                                tipPer = CDefinitiiComune.EnumTipPerioada.Zi;
                        }

                        seteazaPerioada(tipPer, this.datSfarsit.DataAfisata);
                    }
                }

                anuntaSchimbareaPerioadei();
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

        private void anuntaSchimbareaPerioadei()
        {
            if (this.PerioadaSchimbata != null)
                PerioadaSchimbata(this, null);
        }

        private void schimbaPerioada(bool pInainte)
        {
            switch (this.lTipPerioada)
            {
                case CDefinitiiComune.EnumTipPerioada.Custom:
                    if (this.datInceput.AreData && this.datSfarsit.AreData)
                    {
                        //La custom aceeasi zi ar fi 0 zile si nu ar permite schimbarea
                        long diferentaInZile = Math.Max(1, Math.Abs(DateAndTime.DateDiff(DateInterval.Day, this.datSfarsit.DataAfisata.Date, this.datInceput.DataAfisata.Date)));
                        this.datInceput.DataAfisata = this.datInceput.DataAfisata.Date.AddDays(((pInainte) ? 1 : -1) * diferentaInZile);
                        this.datSfarsit.DataAfisata = this.datSfarsit.DataAfisata.AddDays(diferentaInZile);
                    }
                    seteazaPerioada(CDefinitiiComune.EnumTipPerioada.Custom, this.datInceput.DataAfisata);
                    break;
                case CDefinitiiComune.EnumTipPerioada.Luna:
                    seteazaPerioada(CDefinitiiComune.EnumTipPerioada.Luna, this.datInceput.DataAfisata.AddMonths((pInainte) ? 1 : -1));
                    break;
                case CDefinitiiComune.EnumTipPerioada.Saptamana:
                    seteazaPerioada(CDefinitiiComune.EnumTipPerioada.Saptamana, this.datInceput.DataAfisata.AddDays((pInainte) ? 7 : -7));
                    break;
                case CDefinitiiComune.EnumTipPerioada.An:
                    seteazaPerioada(CDefinitiiComune.EnumTipPerioada.An, this.datInceput.DataAfisata.AddYears((pInainte) ? 1 : -1));
                    break;
                case CDefinitiiComune.EnumTipPerioada.Zi:
                    seteazaPerioada(CDefinitiiComune.EnumTipPerioada.Zi, this.datInceput.DataAfisata.AddDays((pInainte) ? 1 : -1));
                    break;
            }
        }

        private void seteazaPerioada(CDefinitiiComune.EnumTipPerioada pTipPerioada, DateTime pDataReferinta)
        {
            this.lTipPerioada = pTipPerioada;
            switch (pTipPerioada)
            {
                case CDefinitiiComune.EnumTipPerioada.Custom:
                    //Tratat in amonte
                    break;
                case CDefinitiiComune.EnumTipPerioada.Luna:
                    DateTime intai = CUtil.GetPrimaZiDinLuna(pDataReferinta);
                    this.datInceput.DataAfisata = intai;
                    this.datSfarsit.DataAfisata = intai.AddMonths(1).AddDays(-1);
                    break;
                case CDefinitiiComune.EnumTipPerioada.PatruZile:
                case CDefinitiiComune.EnumTipPerioada.Saptamana:
                    DateTime luni = CUtil.GetDataZileiDeLuniDinSaptamanaData(pDataReferinta.Date);
                    this.datInceput.DataAfisata = luni;
                    this.datSfarsit.DataAfisata = luni.AddDays(6);
                    break;
                case CDefinitiiComune.EnumTipPerioada.An:
                    this.datInceput.DataAfisata = CUtil.getIntaiIanuarie(pDataReferinta.Date);
                    this.datSfarsit.DataAfisata = CUtil.GetUltimaZiDinAn(pDataReferinta.Date);
                    break;
                case CDefinitiiComune.EnumTipPerioada.Zi:
                    this.datInceput.DataAfisata = CUtil.GetPrimaOraDinData(pDataReferinta.Date);
                    this.datSfarsit.DataAfisata = CUtil.GetUltimaOraDinData(pDataReferinta.Date);
                    break;
            }

            afiseazaPerioda();
        }

        private void afiseazaPerioda()
        {
            //Afisam perioada
            switch (this.lTipPerioada)
            {
                case CDefinitiiComune.EnumTipPerioada.Custom:
                    this.lblPerioadaAfisata.Text = string.Format("{0:dd MMM yyyy} - {1:dd MMM yyyy}",
                                                                        this.datInceput.DataAfisata,
                                                                        this.datSfarsit.DataAfisata);
                    break;
                case CDefinitiiComune.EnumTipPerioada.Luna:
                    string IndicatieLuna = CUtil.GetIndicatieLuna(this.datInceput.DataAfisata);
                    if (string.IsNullOrEmpty(IndicatieLuna))
                        this.lblPerioadaAfisata.Text = string.Format("{0:dd MMM yyyy} - {1:dd MMM yyyy}",
                                                                        this.datInceput.DataAfisata,
                                                                        this.datSfarsit.DataAfisata);
                    else
                        this.lblPerioadaAfisata.Text = string.Format("{0:dd MMM yyyy} - {1:dd MMM yyyy} ({2})",
                                                                        this.datInceput.DataAfisata,
                                                                        this.datSfarsit.DataAfisata,
                                                                        IndicatieLuna.ToLower());
                    break;
                case CDefinitiiComune.EnumTipPerioada.Saptamana:
                    string IndicatieSaptamana = CUtil.GetIndicatieSaptamana(this.datInceput.DataAfisata);
                    if (string.IsNullOrEmpty(IndicatieSaptamana))
                        this.lblPerioadaAfisata.Text = string.Format("{0:dd MMM yyyy} - {1:dd MMM yyyy}",
                                                                        this.datInceput.DataAfisata,
                                                                        this.datSfarsit.DataAfisata.AddDays(-1));
                    else
                        this.lblPerioadaAfisata.Text = string.Format("{0:dd MMM yyyy} - {1:dd MMM yyyy} ({2})",
                                                                        this.datInceput.DataAfisata,
                                                                        this.datSfarsit.DataAfisata.AddDays(-1),
                                                                        IndicatieSaptamana.ToLower());
                    break;
                case CDefinitiiComune.EnumTipPerioada.An:
                    string IndicatieAn = CUtil.GetIndicatieAn(this.datInceput.DataAfisata);
                    if (string.IsNullOrEmpty(IndicatieAn))
                        this.lblPerioadaAfisata.Text = string.Format("{0:yyyy}",
                                                                        this.datInceput.DataAfisata);
                    else
                        this.lblPerioadaAfisata.Text = string.Format("{0:yyyy} ({1})",
                                                                        this.datInceput.DataAfisata,
                                                                        IndicatieAn.ToLower());
                    break;
                case CDefinitiiComune.EnumTipPerioada.Zi:
                    string IndicatieZi = CUtil.GetIndicatieZi(this.datInceput.DataAfisata);
                    if (string.IsNullOrEmpty(IndicatieZi))
                        this.lblPerioadaAfisata.Text = string.Format("{1}, {0:dd.MM.yyyy}",
                                                                        this.datInceput.DataAfisata,
                                                                        CUtil.GetNumeZiSaptamana(this.datInceput.DataAfisata.DayOfWeek).Substring(0, 2));
                    else
                        this.lblPerioadaAfisata.Text = string.Format("{2}, {0:dd.MM.yyyy} ({1})",
                                                                        this.datInceput.DataAfisata,
                                                                        IndicatieZi.ToLower(),
                                                                        CUtil.GetNumeZiSaptamana(this.datInceput.DataAfisata.DayOfWeek).Substring(0, 2));
                    break;
            }
        }

        #endregion

        #region Metode publice

        public void SpreViitor()
        {
            this.lSpreViitor = true;
            this.btnAnulTrecut.Text = CUtil.Capitalizeaza(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.AnulViitor));
            this.btnLunaTrecuta.Text = CUtil.Capitalizeaza(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.LunaViitoare));
            this.btnSaptamanaTrecuta.Text = CUtil.Capitalizeaza(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.saptamanaViitoare));
        }

        public void AscundeAn()
        {
            this.btnAnulAcesta.Visible = false;
            this.btnAnulTrecut.Visible = false;
        }

        public void AscundeCustom()
        {
            this.datInceput.Visible = false;
            this.datSfarsit.Visible = false;
            this.btnCustom.Visible = false;
            this.lblLiniuta.Visible = false;
        }

        public bool EsteInitializat()
        {
            return this.lEsteInitializat;
        }

        public string GetEtichetaPerioada()
        {
            return CUtil.getEtichetaPerioada(this.DataInceput, this.DataSfarsit);
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;

            this.btnAnulAcesta.Enabled = this.lEcranInModificare;
            this.btnAnulTrecut.Enabled = this.lEcranInModificare;

            this.btnLunaAsta.Enabled = this.lEcranInModificare;
            this.btnLunaTrecuta.Enabled = this.lEcranInModificare;

            this.btnSaptamanaAsta.Enabled = this.lEcranInModificare;
            this.btnSaptamanaTrecuta.Enabled = this.lEcranInModificare;

            this.btnAstazi.Enabled = this.lEcranInModificare;
            this.btnInainte.Enabled = this.lEcranInModificare;
            this.btnInapoi.Enabled = this.lEcranInModificare;
            this.btnCustom.Enabled = this.lEcranInModificare;

            this.datInceput.AllowModification(false);
            this.datSfarsit.AllowModification(false);

            this.lblPerioadaAfisata.Enabled = this.lEcranInModificare;
        }

        #endregion

    }
}
