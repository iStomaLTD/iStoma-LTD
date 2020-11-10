using System;
using System.Windows.Forms;

namespace CCL.UI.Caramizi
{
    public partial class ControlPerioada : Panel
    {
        private CDL.iStomaLab.CDefinitiiComune.EnumTipPerioada lTipPerioada = CDL.iStomaLab.CDefinitiiComune.EnumTipPerioada.Custom;

        public ControlPerioada()
        {
            InitializeComponent();

            this.datInceput.CerereUpdate += datInceput_CerereUpdate;
            this.datFinal.CerereUpdate += datFinal_CerereUpdate;
        }

        public DateTime DataInceput { get { return this.datInceput.DataAfisata; } set { this.datInceput.DataAfisata = value; } }
        public DateTime DataSfarsit { get { return this.datFinal.DataAfisata; } set { this.datFinal.DataAfisata = value; } }

        public void Initializeaza(CDL.iStomaLab.CDefinitiiComune.EnumTipPerioada pTipPerioada, DateTime pDataInceput, DateTime pDataFinal)
        {
            this.lTipPerioada = pTipPerioada;
            this.DataInceput = pDataInceput;
            this.DataSfarsit = pDataFinal;
        }

        public void AllowModification(bool pInModificare)
        {
            this.datInceput.AllowModification(pInModificare);
            this.datFinal.AllowModification(pInModificare);
        }

        public void Goleste()
        {
            this.datInceput.Goleste();
            this.datFinal.Goleste();
        }

        void datFinal_CerereUpdate(Control psender, string proprietate, object sNouaValoare)
        {
            if (this.datInceput.AreValoare() && this.datInceput.DataAfisata > this.datFinal.DataAfisata)
                this.datInceput.DataAfisata = this.datFinal.DataAfisata;
        }

        void datInceput_CerereUpdate(Control psender, string proprietate, object sNouaValoare)
        {
            if (this.datFinal.AreValoare() && this.datInceput.DataAfisata > this.datFinal.DataAfisata)
                this.datFinal.DataAfisata = this.datInceput.DataAfisata;

            if(this.datInceput.AreValoare() && this.datInceput.DataAfisata.Day == 1 && this.lTipPerioada == CDL.iStomaLab.CDefinitiiComune.EnumTipPerioada.Luna)
            {
                this.datFinal.DataAfisata = CCL.iStomaLab.CUtil.GetUltimaZiDinLuna(this.datInceput.DataAfisata);
            }
        }

    }
}
