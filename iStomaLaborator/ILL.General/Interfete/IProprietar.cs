using ILL.iStomaLab;
using CDL.iStomaLab;

namespace ILL.BLL.General
{
    public interface IProprietar: ICheie
    {
        CDefinitiiComune.EnumTipObiect TipObiect { get; }
        string ToString();
    }
}
