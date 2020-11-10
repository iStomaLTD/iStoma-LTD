using System;
namespace ILL.BLL.General
{
    public interface ICreare
    {
        DateTime DataCreare { get; }
        int UtilizatorCreare { get; }
        string UtilizatorCreareNumeComplet { get; }
        CDL.iStomaLab.CDefinitiiComune.EnumTipObiect TipObiect { get; }
        int Id { get; }
    }
}
