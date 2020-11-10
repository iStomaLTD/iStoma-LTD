using System;
using System.Collections.Generic;
using System.Data;
using CDL.iStomaLab;

namespace ILL.BLL.General
{
    //public enum EnumStatusAgenda
    //{
    //    Previzionat = 1,
    //    InCurs = 2,
    //    Anulat = 3,
    //    Terminat = 4
    //}

    public interface IElementAgenda
    {
        int Id { get; }
        DateTime DataInceputAgenda { get; }
        DateTime DataSfarsitAgenda { get; }

        string DenumireAgendaImprimataLinie1 { get; }
        string IntervalOrar { get; }
        string DenumirePrincipala { get; }
        string InformatiiGenerale { get; }
        string InformatiiSpecifice { get; }
        string DenumireAgendaLinie1 { get; }
        string DenumireAgendaLinie2 { get; }
        bool AreInterventiiDeAchitat { get; }
        CDefinitiiComune.EnumTipMoneda MonedaDePlata { get; }
        string EtichetaValoareInterventiiNefacturate { get; }
        string EtichetaValoareInterventii { get; }
        string DenumireAgendaFinanciara { get; }
        CDefinitiiComune.EnumTipObiect TipObiect { get; }
        int StatusAgenda { get; }
        int CategorieInterventii { get; }
        string StatusAgendaDenumire { get; }
        int IdProprietarAgenda { get; }
        bool IsRealizarePosibila { get; }
        bool IsAnularePosibila { get; }
        bool IsModificarePosibila { get; }
        List<int> ListaImagini { get; set; }
        bool SMSNotificareTrimis { get; set; }
        bool ContactatTelefonic { get; set; }

        bool EsteAnulat();

        bool IncepeAcum(IDbTransaction pTranzactie);
        bool FinalizeazaAcum(IDbTransaction pTranzactie);
        bool Realizeaza(IDbTransaction pTranzactie);
        bool Anuleaza(string pMotivInchidere, IDbTransaction pTranzactie);
        void Achita(CDefinitiiComune.EnumTipMoneda pTipMoneda, IDbTransaction pTranzactie);
        double getSumaInterventiiNefacturate(CDefinitiiComune.EnumTipMoneda pTipMoneda, IDbTransaction pTranzactie);
        bool areInterventii(IDbTransaction pTranzactie);
        List<int> ListaPersonalNecesar { get; }

        void ModificaDurata(DateTime pDataInceput, int pDurataNoua);
        void Reprogrameaza(Tuple<DateTime, IProprietarElementeAgenda> pDateMutare);

        bool AreCuloarePersonalizata();
        System.Drawing.Color GetCuloarePersonalizata();

        System.Drawing.Color CuloareCategorie { get; }

        long GetNumarMinuteLucrate(List<ILL.General.Interfete.IIntervalDeLucru> pListaIntervaleDeLucru);

        void Refresh(IDbTransaction pTranzactie);

        bool EsteElPersoana(int pIdPersoana);
    }
}
