using CDL.iStomaLab;

namespace ILL.BLL.General
{
    public interface IContextPostIT
    {
        int Id { get; }
        CDefinitiiComune.EnumTipProprietarPostIT TipProprietarPostIT { get; }
        string ToString();
    }
}
