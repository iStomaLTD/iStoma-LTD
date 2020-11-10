using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iStomaLab.Generale;
using BLL.iStomaLab.Utilizatori;
using BLL.iStomaLab;
using CDL.iStomaLab;
using CCL.UI;
using CCL.iStomaLab;

namespace iStomaLab.Setari.Personal
{
    public partial class ControlUtilizatorPontaj : UserControlPersonalizat
    {

        #region Declaratii generale

        private BUtilizator lUtilizator = null;
        private EnumTipAfisarePontaj lTipPontaj = EnumTipAfisarePontaj.Detalii;

        #endregion

        #region Enumerari si Structuri
        
        private enum EnumTipAfisarePontaj
        {
            Detalii = 0,
            Rezumat = 1
        }

        private enum EnumColoaneDGVDetalii
        {
            colTip,
            colData,
            colObservatii
        }

        private enum EnumColoaneDGVRezumat
        {
            colTotal,
            colConcedii,
            colZileNelucratoare,
            colZile,
            colNrZiDinLuna
        }

        #endregion

        #region Proprietati


        #endregion

        #region Constructor si Initializare

        public ControlUtilizatorPontaj()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {

                adaugaHandlere();
                initTextML();
            }
        }

        private void adaugaHandlere()
        {
            this.btnPontajDetalii.Click += BtnPontaj_Click;
            this.btnPontajRezumat.Click += BtnPontaj_Click;
            this.ctrlPerioada.PerioadaSchimbata += CtrlPerioada_PerioadaSchimbata;
        }

        private void initTextML()
        {
            this.btnPontajDetalii.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Detalii);
            this.btnPontajRezumat.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Rezumat);
        }

        public void Initializeaza(BUtilizator pUtilizator)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();
            this.lUtilizator = pUtilizator;
            
            this.ctrlPerioada.Initializeaza(CDefinitiiComune.EnumTipPerioada.Zi, DateTime.Today);
            
            this.btnPontajDetalii.Tag = EnumTipAfisarePontaj.Detalii;
            this.btnPontajRezumat.Tag = EnumTipAfisarePontaj.Rezumat;

            if (this.lUtilizator != null)
            {
                incarcaTipPontajSelectat(this.lTipPontaj);
            }
            

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void CtrlPerioada_PerioadaSchimbata(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                incarcaTipPontajSelectat(this.lTipPontaj);
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
        
        private void BtnPontaj_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                EnumTipAfisarePontaj tipAfisare = (EnumTipAfisarePontaj)(sender as ButtonPersonalizat).Tag;

                this.lTipPontaj = tipAfisare;

                incarcaTipPontajSelectat(tipAfisare);
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
        
        private void stabilesteTotalOre()
        {
            //BDefinitiiGenerale.StructCheckInOut.GetDenumireTip(pElem.TipPontaj)
            int totalMinuteLucrate = 0;
            int totalMinutePauza = 0;
            int totalMinuteDeplasare = 0;

            BColectiePontaj lstPontaj = BPontaj.GetListByIdUtilizatorTotalPePerioada(this.lUtilizator.Id, this.ctrlPerioada.DataInceput, this.ctrlPerioada.DataSfarsit, null);

            foreach(var elem in lstPontaj)
            {
                
            }

            StringBuilder sb = new StringBuilder();
            if (totalMinuteLucrate > 0)
            {
                sb.Append("Ore lucrate: " + CUtil.GetTextDurataOreMinute(totalMinuteLucrate) + " ");
            }
            if (totalMinutePauza > 0)
            {
                sb.Append("Pauza: " + CUtil.GetTextDurataOreMinute(totalMinutePauza) + " ");
            }
            if (totalMinuteDeplasare > 0)
            {
                sb.Append("Deplasare: " + CUtil.GetTextDurataOreMinute(totalMinuteDeplasare) + " ");
            }
        }

        private void incarcaTipPontajSelectat(EnumTipAfisarePontaj pTipAfisare)
        {
            this.lTipPontaj = pTipAfisare;
            switch (pTipAfisare)
            {
                case EnumTipAfisarePontaj.Detalii:
                    ConstruiesteColoaneDGVDetalii();
                    ConstruiesteRanduriDGVDetalii();
                    break;
                case EnumTipAfisarePontaj.Rezumat:
                    ConstruiesteColoaneDGVRezumat();
                    ConstruiesteRanduriDGVRezumat();

                    break;
            }
        }

        private void ConstruiesteColoaneDGVDetalii()
        {
            this.dgvListaPontaj.IncepeConstructieColoane();

            this.dgvListaPontaj.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvListaPontaj.AdaugaColoanaText(EnumColoaneDGVDetalii.colTip.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tip), 200, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaPontaj.AdaugaColoanaData(EnumColoaneDGVDetalii.colData.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Data), 100, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA_ORA);

            this.dgvListaPontaj.AdaugaColoanaText(EnumColoaneDGVDetalii.colObservatii.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii), 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaPontaj.FinalizeazaConstructieColoane();
        }
        
        private void ConstruiesteRanduriDGVDetalii()
        {
            this.dgvListaPontaj.IncepeContructieRanduri();

            var listaElem = BPontaj.GetListByIdUtilizatorTotalPePerioada(this.lUtilizator.Id, this.ctrlPerioada.DataInceput, this.ctrlPerioada.DataSfarsit, null);

            foreach (var elem in listaElem)
            {
                incarcaRandDetalii(this.dgvListaPontaj.Rows[this.dgvListaPontaj.Rows.Add()], elem);
            }

            this.dgvListaPontaj.FinalizeazaContructieRanduri();

        }

        private void incarcaRandDetalii(DataGridViewRow pRand, BPontaj pElem)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);

            pRand.Cells[EnumColoaneDGVDetalii.colTip.ToString()].Value = BDefinitiiGenerale.StructCheckInOut.GetDenumireTip(pElem.TipPontaj);
            pRand.Cells[EnumColoaneDGVDetalii.colData.ToString()].Value = pElem.DataPontaj;
            pRand.Cells[EnumColoaneDGVDetalii.colObservatii.ToString()].Value = pElem.Observatii;
        }

        private void ConstruiesteColoaneDGVRezumat()
        {
            this.dgvListaPontaj.IncepeConstructieColoane();

            this.dgvListaPontaj.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Editare);

            this.dgvListaPontaj.AdaugaColoanaText(EnumColoaneDGVRezumat.colTotal.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Total), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaPontaj.AdaugaColoanaText(EnumColoaneDGVRezumat.colConcedii.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Concedii), 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaPontaj.AdaugaColoanaText(EnumColoaneDGVRezumat.colZileNelucratoare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ZileNelucratoare), 150, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaPontaj.AdaugaColoanaText(EnumColoaneDGVRezumat.colZile.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Zile), 100, true, DataGridViewColumnSortMode.Automatic);

            int ultimaZiDinLuna = Convert.ToInt32(DateAndTime.DateDiff(DateInterval.Day, this.ctrlPerioada.DataInceput, this.ctrlPerioada.DataSfarsit));

            for (int i = this.ctrlPerioada.DataInceput.Day; i <= this.ctrlPerioada.DataSfarsit.Day; i++)
            {
                this.dgvListaPontaj.AdaugaColoanaText((i).ToString(), (i).ToString(), 45, false, DataGridViewColumnSortMode.Automatic);
                DateTime data = this.ctrlPerioada.DataInceput;
            }

            this.dgvListaPontaj.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGVRezumat()
        {
            this.dgvListaPontaj.IncepeContructieRanduri();

            BColectiePontaj listaElem = BPontaj.GetListByIdUtilizatorTotalPePerioada(this.lUtilizator.Id, this.ctrlPerioada.DataInceput, this.ctrlPerioada.DataSfarsit, null);

            incarcaRandRezumat(this.dgvListaPontaj.Rows[this.dgvListaPontaj.Rows.Add()], listaElem);

            this.dgvListaPontaj.FinalizeazaContructieRanduri();

        }

        private void incarcaRandRezumat(DataGridViewRow pRand, BColectiePontaj pElem)
        {
            pRand.Tag = pElem;

            DataGridViewPersonalizat.InitCelulaEditare(pRand, this.lEcranInModificare);

            pRand.Cells[EnumColoaneDGVRezumat.colConcedii.ToString()].Value = this.lUtilizator.NumarZileCOAgreate;
            pRand.Cells[EnumColoaneDGVRezumat.colZileNelucratoare.ToString()].Value = "0";
            pRand.Cells[EnumColoaneDGVRezumat.colZile.ToString()].Value = CUtil.GetNumarZileLucratoareLuna(this.ctrlPerioada.DataInceput);

            pRand.Cells[EnumColoaneDGVRezumat.colTotal.ToString()].Value = CUtil.GetTextPrescurtatDurataOreMinute(getDurataTotalaPePerioada());

            int ultimaZiDinLuna = Convert.ToInt32(DateAndTime.DateDiff(DateInterval.Day, this.ctrlPerioada.DataInceput, this.ctrlPerioada.DataSfarsit));

            DateTime dataInceput = this.ctrlPerioada.DataInceput;
            DateTime dataSfarsit = dataInceput.AddDays(1);

            for (int i = this.ctrlPerioada.DataInceput.Day; i <= this.ctrlPerioada.DataSfarsit.Day; i++)
            {
                this.dgvListaPontaj.Columns[0].Tag = pElem;

                long totalPontajZi = 0;

                var listaElem = BPontaj.GetListByIdUtilizatorTotalPePerioada(this.lUtilizator.Id, dataInceput, dataSfarsit, null);

                foreach (var elem in listaElem)
                {
                    if (elem.TipPontaj == 1)
                    {
                        dataInceput = elem.DataPontaj;
                    }

                    if (elem.TipPontaj == 2)
                    {
                        totalPontajZi += getNrMinuteZi(dataInceput, elem.DataPontaj);
                    }
                }
                pRand.Cells[(dataInceput.Day).ToString()].Value = CUtil.GetTextPrescurtatDurataOreMinute(totalPontajZi);

                dataInceput = dataInceput.AddDays(1);
                dataSfarsit = dataSfarsit.AddDays(1);
            }

        }

        private long getDurataTotalaPePerioada()
        {
            long totalMinute = 0;
            DateTime datCheckIn = CConstante.DataNula;

            var listaElem = BPontaj.GetListByIdUtilizatorTotalPePerioada(this.lUtilizator.Id, this.ctrlPerioada.DataInceput, this.ctrlPerioada.DataSfarsit, null);

            foreach (var elem in listaElem)
            {
                if (elem.TipPontaj == 1)
                {
                    datCheckIn = elem.DataPontaj;
                }

                if (elem.TipPontaj == 2)
                {
                    totalMinute += getNrMinuteZi(datCheckIn, elem.DataPontaj);
                }
            }

            return totalMinute;
        }

        private long getNrMinuteZi(DateTime pOraInceput, DateTime pOraSfarsit)
        {
            long nrMinuteInceput = pOraInceput.Hour * 60 + pOraInceput.Minute;
            long nrMinuteSfarsit = pOraSfarsit.Hour * 60 + pOraSfarsit.Minute;
            return nrMinuteSfarsit - nrMinuteInceput;
        }

        #endregion

        #region Metode publice



        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
        }

        #endregion


    }
}
