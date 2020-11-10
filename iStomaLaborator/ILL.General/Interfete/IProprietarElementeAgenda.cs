using System;
using System.Collections.Generic;
using CDL.iStomaLab;
using ILL.General.Interfete;

namespace ILL.BLL.General
{
    public interface IProprietarElementeAgenda
    {
        int IdProprietarElementeAgenda { get; }
        string Denumire { get; }
        System.Drawing.Color getCuloareAgenda(int pIdUtilizator);
        CDefinitiiComune.EnumTipObiect TipObiect { get; }
        List<IElementAgenda> ListaElementeAgenda { get; set; }
        List<IIntervalDeLucru> ListaIntervaleDeActivitate { get; }
        List<IIntervalDeLucru> ListaIntervaleDeInactivitate { get; }
        Dictionary<DateTime, Tuple<string, System.Drawing.Color>> ListaZileConcediu { get; set; }

        //pentru agenda financiara
        Dictionary<long, Tuple<double, double>> ListaIncasariEfectuate { get; set; } // cheia reprezinta data (20120806 de exemplu pt 06/08/2012)
        Dictionary<long, Tuple<double, double>> ListaIncasariPrevizionate { get; set; } //Cuplul reprezinta suma in lei, suma in euro

        Tuple<double, double> getSumarIncasari(DateTime pData, CDefinitiiComune.EnumTipPerioada pTipPerioada);
        string getInfoCastigPrevizionat(DateTime pData, CDefinitiiComune.EnumTipPerioada pTipPerioada);
        string getInfoCastigReal(DateTime pData, CDefinitiiComune.EnumTipPerioada pTipPerioada);

        //pentru programul de lucru
        //void IncarcaIntervaleleDeActivitate(DateTime pDataInceput, DateTime pDataFinal, int pOraInceput, int pOraFinal);
    }
}
