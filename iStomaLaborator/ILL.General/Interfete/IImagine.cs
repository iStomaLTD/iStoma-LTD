using CDL.iStomaLab;

namespace ILL.BLL.General
{
    public interface IImagine
    {
        int Id { get; }
        int ImagineCurenta { get; set; }
        CDefinitiiComune.EnumTipProprietarDocumente TipProprietarImagine { get; }
        CDefinitiiComune.EnumTipObiect TipObiect { get; }
        string ContFacebook { get; set; }
        bool UpdateAll(System.Data.IDbTransaction pTranzactie);
        CDL.iStomaLab.CDefinitiiComune.EnumSex Sex { get; set; }
    }
}
