using System;
using System.Data;
using CDL.iStomaLab;
using ILL.iStomaLab;

namespace ILL.BLL.General
{
    public interface IInchidere : ICheie
    {
        void Close(bool pInchide, string pMotivInchidere, IDbTransaction pTranzactie);
        DateTime DataInchidere { get; }
        CDefinitiiComune.EnumTipLista ListaMotiveInchidere { get; }
        string MotivInchidere { get; set; }
        string ToString();
        bool UpdateAll(IDbTransaction pTranzactie);
        int UtilizatorInchidere { get; }
        string UtilizatorInchidereNumeComplet { get; }
        bool EsteActiv { get; }
    }
}
