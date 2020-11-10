using System;
using CDL.iStomaLab;

[assembly: CLSCompliant(true)]
namespace ILL.BLL.General
{
    [CLSCompliant(true)]
    public interface IAfisaj
    {
        int Id { get; }
        string DenumireAfisaj { get; }
        CDefinitiiComune.EnumTipObiect TipObiect { get; }
    }
}
