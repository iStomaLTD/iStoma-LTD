using System;

namespace ILL.BLL.General
{
    [CLSCompliant(true)]
    public interface IPosesorAdresa : IProprietar
    {
        CDL.iStomaLab.CDefinitiiComune.EnumTipObiect TipObiect { get; }
        IAfisaj GetAdresa(System.Data.IDbTransaction pTranzactie);
    }
}
