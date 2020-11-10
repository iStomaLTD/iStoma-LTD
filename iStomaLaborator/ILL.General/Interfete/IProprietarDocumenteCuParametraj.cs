using CDL.iStomaLab;

namespace ILL.General.Interfete
{
    //un obiect plus obiectul din parametraj folosit de acesta
    public interface IProprietarDocumenteCuParametraj : IProprietarDocumente
    {
        int IdParametraj { get; }
        CDefinitiiComune.EnumTipObiect TipObiectParametraj { get; }
        string DenumireParametraj { get; }
    }
}
