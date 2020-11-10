using ILL.iStomaLab;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using CCL.iStomaLab;

namespace CCL.UI.ControaleSpecializate
{
    [DefaultEvent("OperatiuneCalendar")]
    public class PictureBoxCalendarLunar : PictureBoxPersonalizat
    {

        public event ZiHandler OperatiuneCalendar;
        public delegate void ZiHandler(PictureBoxCalendarLunar pSender, EnumOperatieCalendar pTipOperatie, DateTime pZiSelectata);

        protected bool lEcranInModificare = true;

        private DateTime lDataReferinta = CConstante.DataNula;
        private Dictionary<DateTime, Tuple<System.Drawing.Color, int, string>> lListaDateSelectate = null;
        private List<DateTime> lListaZileNelucratoare = null;

        private ColectieZileLuna lLunaAfisata = null;
        private System.Windows.Forms.Timer timerAfisaj;
        private IContainer components;
        private int lNrSaptamani = 0;
        private Bitmap lImagineCalendar = null;
        private bool lImagineDisponibila = true;

        private Color lCuloareZiEvidentiata = Color.Goldenrod;

        public enum EnumOperatieCalendar
        {
            ClickPeData,
            AfiseazaToolTip,
            AscundeToolTip,
            ForteazaInchidereToolTip
        }

        public DateTime DataInceput { get { return this.lDataReferinta; } }

        private void CereOperatiune(EnumOperatieCalendar pTipOperatie, DateTime pDataSelectata)
        {
            if (OperatiuneCalendar != null)
                OperatiuneCalendar(this, pTipOperatie, pDataSelectata);
        }

        public PictureBoxCalendarLunar()
        {
            InitializeComponent();
        }

        public void Initializeaza(DateTime pData, List<DateTime> pListaDateSelectate, List<DateTime> pListaZileNelucratoare)
        {
            Dictionary<DateTime, Tuple<System.Drawing.Color, int, string>> dict = new Dictionary<DateTime, Tuple<System.Drawing.Color, int, string>>();

            if (!CUtil.EsteListaVida<DateTime>(pListaDateSelectate))
            {
                foreach (var item in pListaDateSelectate)
                {
                    if (!dict.ContainsKey(item))
                        dict.Add(item, new Tuple<Color, int, string>(Color.Empty, 0, string.Empty));
                }
            }

            Initializeaza(pData, dict, pListaZileNelucratoare);
        }

        public void Initializeaza(DateTime pData, Dictionary<DateTime, Tuple<System.Drawing.Color, int, string>> pListaDateSelectate, List<DateTime> pListaZileNelucratoare)
        {
            this.lDataReferinta = pData;
            if (pListaDateSelectate == null)
                this.lListaDateSelectate = new Dictionary<DateTime, Tuple<System.Drawing.Color, int, string>>(); // ca sa nu crape la test
            else
                this.lListaDateSelectate = pListaDateSelectate;

            if (pListaZileNelucratoare == null)
                this.lListaZileNelucratoare = new List<DateTime>(); // ca sa nu crape la test
            else
                this.lListaZileNelucratoare = pListaZileNelucratoare;

            this.lNrSaptamani = CUtil.GetNumarSaptamaniDinLuna(this.lDataReferinta);

            creazaImagineCalendar();
            startTimer();
        }

        public new void Dispose()
        {
            stopTimer();

            if (this.lImagineCalendar != null)
                this.lImagineCalendar.Dispose();

            this.lImagineCalendar = null;
        }

        private void creazaImagineCalendar()
        {
            this.Image = null;

            if (this.lImagineCalendar != null)
            {
                this.lImagineCalendar.Dispose();
                this.lImagineCalendar = null;
            }

            this.lImagineCalendar = new Bitmap(this.DisplayRectangle.Width, this.DisplayRectangle.Height);

            using (Graphics g = Graphics.FromImage(this.lImagineCalendar))
            {
                DeseneazaCalendarul(g);

                g.Save();
            }

            this.lImagineDisponibila = true;
        }

        private void DeseneazaCalendarul(Graphics g)
        {
            Font FONT_DESEN = IHMUtile.getFONT_DESEN();
            Font FONT_DESEN_MIC = IHMUtile.getFONT_DESEN_MIC();
            Font FONT_DESEN_BOLD = IHMUtile.getFONT_DESEN_BOLD();

            //Desenam zilele
            if (this.lDataReferinta != CConstante.DataNula)
            {
                float lX1SuprafataUtila = 0;
                float lY1SuprafataUtila = 0;
                float lWUnitateOrizontala = this.ClientRectangle.Width / 7;
                float lHUnitateVerticala = 0;

                DateTime dataDeLuni = CUtil.GetDataZileiDeLuniDinSaptamanaData(this.lDataReferinta);
                this.lLunaAfisata = new ColectieZileLuna();
                StructZileLuna ziLuna = StructZileLuna.Empty;

                //Fundalul calendarului este alb
                g.FillRectangle(Brushes.White, this.ClientRectangle);

                //Desenam denumirea lunii
                string numeLuna = CUtil.GetNumeLunaAn(this.lDataReferinta.Month);
                SizeF marimeLuna = g.MeasureString(numeLuna, FONT_DESEN);

                IHMUtile.ScrieInCentru(g, Brushes.SteelBlue, lX1SuprafataUtila, lY1SuprafataUtila, this.ClientRectangle.Width, marimeLuna.Height, numeLuna, FONT_DESEN);

                lY1SuprafataUtila += marimeLuna.Height;

                //Desenam zilele saptamanii
                using (Font fontNumeZi = new System.Drawing.Font("Arial", 8))
                {
                    SizeF marimeZi = g.MeasureString("Mi", FONT_DESEN);

                    IHMUtile.ScrieInCentru(g, Brushes.DarkBlue, lX1SuprafataUtila, lY1SuprafataUtila, lWUnitateOrizontala, marimeZi.Height, CDL.iStomaLab.CConstante.ZileDinDouaLitere.Substring(0, 2), fontNumeZi);
                    IHMUtile.ScrieInCentru(g, Brushes.DarkBlue, lX1SuprafataUtila + lWUnitateOrizontala, lY1SuprafataUtila, lWUnitateOrizontala, marimeZi.Height, CDL.iStomaLab.CConstante.ZileDinDouaLitere.Substring(2, 2), fontNumeZi);
                    IHMUtile.ScrieInCentru(g, Brushes.DarkBlue, lX1SuprafataUtila + 2 * lWUnitateOrizontala, lY1SuprafataUtila, lWUnitateOrizontala, marimeZi.Height, CDL.iStomaLab.CConstante.ZileDinDouaLitere.Substring(4, 2), fontNumeZi);
                    IHMUtile.ScrieInCentru(g, Brushes.DarkBlue, lX1SuprafataUtila + 3 * lWUnitateOrizontala, lY1SuprafataUtila, lWUnitateOrizontala, marimeZi.Height, CDL.iStomaLab.CConstante.ZileDinDouaLitere.Substring(6, 2), fontNumeZi);
                    IHMUtile.ScrieInCentru(g, Brushes.DarkBlue, lX1SuprafataUtila + 4 * lWUnitateOrizontala, lY1SuprafataUtila, lWUnitateOrizontala, marimeZi.Height, CDL.iStomaLab.CConstante.ZileDinDouaLitere.Substring(8, 2), fontNumeZi);
                    IHMUtile.ScrieInCentru(g, Brushes.DarkBlue, lX1SuprafataUtila + 5 * lWUnitateOrizontala, lY1SuprafataUtila, lWUnitateOrizontala, marimeZi.Height, CDL.iStomaLab.CConstante.ZileDinDouaLitere.Substring(10, 2), fontNumeZi);
                    IHMUtile.ScrieInCentru(g, Brushes.DarkBlue, lX1SuprafataUtila + 6 * lWUnitateOrizontala, lY1SuprafataUtila, lWUnitateOrizontala, marimeZi.Height, CDL.iStomaLab.CConstante.ZileDinDouaLitere.Substring(12), fontNumeZi);

                    lY1SuprafataUtila += marimeZi.Height;
                }

                lHUnitateVerticala = (this.ClientRectangle.Height - lY1SuprafataUtila) / this.lNrSaptamani;

                //scriem datele in casutele corespunzatoare
                for (int i = 0; i < this.lNrSaptamani; i++)
                {
                    do
                    {

                        ziLuna = new StructZileLuna(dataDeLuni, lX1SuprafataUtila + (((int)dataDeLuni.DayOfWeek + 6) % 7) * lWUnitateOrizontala,
                                                                lY1SuprafataUtila + i * lHUnitateVerticala,
                                                                lWUnitateOrizontala,
                                                                lHUnitateVerticala,
                                                                dataDeLuni.Month == this.lDataReferinta.Month,
                                                                dataDeLuni.Month == this.lDataReferinta.Month && this.lListaDateSelectate.ContainsKey(dataDeLuni),
                                                                dataDeLuni.Month == this.lDataReferinta.Month && this.lListaZileNelucratoare.Contains(dataDeLuni),
                                                                this.lListaDateSelectate.ContainsKey(dataDeLuni) ? this.lListaDateSelectate[dataDeLuni].Item3 : string.Empty,
                                                                this.lListaDateSelectate.ContainsKey(dataDeLuni) ? this.lListaDateSelectate[dataDeLuni].Item2 : 1);

                        if (this.lListaDateSelectate.ContainsKey(dataDeLuni) && !this.lListaDateSelectate[dataDeLuni].Item1.IsEmpty)
                        {
                            if (string.IsNullOrEmpty(this.lListaDateSelectate[dataDeLuni].Item3))
                                ziLuna.Deseneaza(g, FONT_DESEN, FONT_DESEN_MIC, this.lListaDateSelectate[dataDeLuni].Item1);
                            else
                                ziLuna.Deseneaza(g, FONT_DESEN_BOLD, FONT_DESEN_MIC, this.lListaDateSelectate[dataDeLuni].Item1);
                        }
                        else
                            ziLuna.Deseneaza(g, FONT_DESEN, FONT_DESEN_MIC, this.lCuloareZiEvidentiata);

                        this.lLunaAfisata.Add(ziLuna);

                        dataDeLuni = dataDeLuni.AddDays(1);
                    } while (dataDeLuni.DayOfWeek != DayOfWeek.Monday);
                }
            }
            else
            {
                g.DrawString(this.Name, FONT_DESEN, Brushes.Black, 10, 10);
            }

            FONT_DESEN.Dispose();
            FONT_DESEN = null;
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            if (this.lLunaAfisata != null)
            {
                using (Graphics g = Graphics.FromImage(this.lImagineCalendar))
                {
                    StructZileLuna ziSelectata = this.lLunaAfisata.VerificaPozitia(g, e.Location, false);
                    if (ziSelectata.Exista && (ziSelectata.Nelucratoare || ziSelectata.AreObservatii))
                        CereOperatiune(EnumOperatieCalendar.AfiseazaToolTip, ziSelectata.Data);
                    else
                        CereOperatiune(EnumOperatieCalendar.ForteazaInchidereToolTip, ziSelectata.Data);
                    g.Save();
                    this.lImagineDisponibila = true;
                    startTimer();
                }
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (this.lLunaAfisata != null)
            {
                using (Graphics g = Graphics.FromImage(this.lImagineCalendar))
                {
                    StructZileLuna ziSelectata = this.lLunaAfisata.VerificaPozitia(g, Point.Empty, false);
                    CereOperatiune(EnumOperatieCalendar.AscundeToolTip, ziSelectata.Data);
                    g.Save();
                    this.lImagineDisponibila = true;
                    startTimer();
                }
            }

            base.OnMouseLeave(e);
        }

        protected override void OnMouseClick(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (this.lLunaAfisata != null && this.lEcranInModificare)
            {
                using (Graphics g = Graphics.FromImage(this.lImagineCalendar))
                {
                    CereOperatiune(EnumOperatieCalendar.ClickPeData, this.lLunaAfisata.GetZiPozitie(g, e.Location, false).Data);
                    g.Save();
                    this.lImagineDisponibila = true;
                    startTimer();
                }
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerAfisaj = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // timerAfisaj
            // 
            this.timerAfisaj.Interval = 50;
            this.timerAfisaj.Tick += new System.EventHandler(this.timerAfisaj_Tick);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private int lNumarAfisariFaraModificare = 0;

        private void startTimer()
        {
            this.lNumarAfisariFaraModificare = 0;
            this.timerAfisaj.Start();
        }

        private void stopTimer()
        {
            if (this.timerAfisaj != null)
                this.timerAfisaj.Stop();
        }

        private void timerAfisaj_Tick(object sender, EventArgs e)
        {
            //Dupa 3 afisari fara modificare oprim timerul
            if (this.lImagineDisponibila)
            {
                this.Image = this.lImagineCalendar;
                this.lImagineDisponibila = false;
                this.lNumarAfisariFaraModificare = 0;
            }
            else
                this.lNumarAfisariFaraModificare += 1;

            if (this.lNumarAfisariFaraModificare >= 3)
            {
                stopTimer();
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (this.Image != null)
                creazaImagineCalendar();

            base.OnSizeChanged(e);
        }

        public void SetCuloareZiEvidentiata(Color pCuloareZiEvidentiata)
        {
            this.lCuloareZiEvidentiata = pCuloareZiEvidentiata;
        }

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
        }
    }
}
