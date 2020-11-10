using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace CCL.UI
{
    public struct StructUtilizareToolTip
    {
        public bool UtilizeazaToolTip { get; set; }
        public System.Windows.Forms.ToolTipIcon IcoanaToolTip { get; set; }
        public string TitluToolTip { get; set; }
        public string MesajToolTip { get; set; }
    }

    public struct StructZileLuna
    {
        internal RectangleF Chenar { get; private set; }
        public DateTime Data { get; set; }
        private Color lCuloareZiEvidentiata;
        private bool lEsteSelectata;
        private bool lZiActiva;
        private bool lZiEvidentiata;
        private bool lZiNelucratoare;
        private string lObservatii;
        private int lCantitate;

        public bool Exista
        {
            get { return this.Data != CConstante.DataNula; }
        }
        public bool Selectata
        {
            get { return this.lEsteSelectata; }
            set { this.lEsteSelectata = value; }
        }
        public bool Nelucratoare
        {
            get { return this.lZiNelucratoare; }
        }
        public bool AreObservatii
        {
            get { return !string.IsNullOrEmpty(this.lObservatii); }
        }
        public static StructZileLuna Empty
        {
            get { return new StructZileLuna(CConstante.DataNula, -1, -1, -1, -1, false, false, false, string.Empty, 0); }
        }
        public StructZileLuna(DateTime pData, float x, float y, float w, float h, bool pZiActiva, bool pZiEvidentiata, bool pZiNelucratoare, string pObservatii, int pCantitate)
            : this()
        {
            if (pData != CConstante.DataNula)
            {
                this.Data = pData;
                this.Chenar = new RectangleF(x + 1, y + 1, w - 2, h - 2);
                this.lZiActiva = pZiActiva;
                this.lZiEvidentiata = pZiEvidentiata;
                this.lZiNelucratoare = pZiNelucratoare;
                this.lObservatii = pObservatii;
                this.lCantitate = pCantitate;
            }
            else
            {
                this.Data = CConstante.DataNula;
                this.Chenar = Rectangle.Empty;
            }
        }

        public void Deseneaza(Graphics g, Font FONT_DESEN, Font FONT_DESEN_MIC)
        {
            Deseneaza(g, FONT_DESEN, FONT_DESEN_MIC, Color.Goldenrod);
        }

        public void Deseneaza(Graphics g, Font FONT_DESEN, Font FONT_DESEN_MIC, Color pCuloareZiEvidentiata)
        {
            this.lCuloareZiEvidentiata = pCuloareZiEvidentiata;

            //Data evidentiata o coloram
            if (this.lZiEvidentiata)
            {
                using (Brush br = new SolidBrush(pCuloareZiEvidentiata))
                {
                    IHMUtile.FillRectangleF(g, br, this.Chenar);
                }

                using (Pen pn = new Pen(pCuloareZiEvidentiata))
                {
                    g.DrawRectangle(pn, this.Chenar.X, this.Chenar.Y, this.Chenar.Width, this.Chenar.Height);
                }
            }

            //Data de azi o desenam in chenar doar daca este activa in luna afisata
            if (this.Data == DateTime.Today && this.lZiActiva)
                g.DrawRectangle(IHMUtile.PENSULA_CHENAR, this.Chenar.X, this.Chenar.Y, this.Chenar.Width, this.Chenar.Height);

            //Sambetele si Duminicile le desenam cu o alta culoare
            //Zilele libere sunt desenate cu rosu
            if (this.lZiNelucratoare)
                IHMUtile.ScrieInCentru(g, Brushes.Red, this.Chenar, Convert.ToString(this.Data.Day), FONT_DESEN);
            else
                IHMUtile.ScrieInCentru(g, this.lZiActiva ? (this.Data.DayOfWeek == DayOfWeek.Saturday || this.Data.DayOfWeek == DayOfWeek.Sunday) ? Brushes.DarkGray : Brushes.Black : Brushes.LightGray, this.Chenar, Convert.ToString(this.Data.Day), FONT_DESEN);

            if (this.lCantitate != 1)
                IHMUtile.ScrieInDreaptaJos(g, Brushes.DarkRed, this.Chenar, this.lCantitate.ToString(), FONT_DESEN_MIC);
        }

        public bool ReactieLaPozitie(Graphics g, Point pPunctDeInteres, bool pReactioneazaChiarDacaEInactiva)
        {
            this.lEsteSelectata = (pReactioneazaChiarDacaEInactiva || !pReactioneazaChiarDacaEInactiva && this.lZiActiva) && this.EsteInInterior(pPunctDeInteres);

            if (this.lZiEvidentiata)
            {
                using (Pen pnEv = new Pen(this.lCuloareZiEvidentiata))
                {
                    IHMUtile.DrawRectangleF(g, this.lEsteSelectata ? IHMUtile.PENSULA_CHENAR_SELECTAT : (this.Data == DateTime.Today) ? IHMUtile.PENSULA_CHENAR : pnEv, this.Chenar);
                }
            }
            else
            {
                IHMUtile.DrawRectangleF(g, this.lEsteSelectata ? IHMUtile.PENSULA_CHENAR_SELECTAT : (this.Data == DateTime.Today) ? IHMUtile.PENSULA_CHENAR : Pens.White, this.Chenar);
            }

            return this.lEsteSelectata;
        }

        public bool EsteInInterior(Point pPozitie)
        {
            return IHMUtile.EstePunctulInDreptunghi(this.Chenar, pPozitie);
        }
    }

    public class ColectieZileLuna : List<StructZileLuna>
    {

        public StructZileLuna VerificaPozitia(Graphics g, Point pPunctInteres, bool pReactioneazaChiarDacaEInactiva)
        {
            StructZileLuna zi = StructZileLuna.Empty;
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].ReactieLaPozitie(g, pPunctInteres, pReactioneazaChiarDacaEInactiva))
                    zi = this[i];
            }
            return zi;
        }

        public StructZileLuna GetZiSelectata()
        {
            StructZileLuna zi = StructZileLuna.Empty;
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Selectata)
                    zi = this[i];
            }

            return zi;
        }

        public StructZileLuna GetZiPozitie(Graphics g, Point pPunctInteres, bool pReactioneazaChiarDacaEInactiva)
        {
            StructZileLuna zi = StructZileLuna.Empty;
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].ReactieLaPozitie(g, pPunctInteres, pReactioneazaChiarDacaEInactiva))
                    zi = this[i];
            }

            return zi;
        }
    }

    public enum EnumMargine
    {
        Sus = 0,
        Jos = 2,
        Stanga = 3,
        Dreapta = 4,
        StangaJosDreapta = 5,
        StangaSusDreapta = 6
    }

    public class CEnumerariComune
    {
        public enum EnumTipDeschidere
        {
            CentrulEcranului = -1,
            StangaSus = 0,
            DreaptaSus = 1,
            DreaptaJos = 2,
            StangaJos = 3
        }

        public enum EnumTipAliniere
        {
            LaStanga = 0,
            LaDreapta = 1
        }
    }
}
