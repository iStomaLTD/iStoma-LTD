using ILL.BLL.General;

namespace ILL.General.Interfete
{
    public interface IPosesorCodDeBare : IIdentitate
    {
        string NumarCardFidelitate { get; set; }
        int TipCardFidelitate { get; set; }

        string GetTipCardFidelitate(System.Data.IDbTransaction pTranzactie);
        IPosesorCodDeBare GetByCodDeBare(string pCodDeBare);
        void UpdateCardFidelitate(int pTipCard, string pNumarCard, System.Data.IDbTransaction pTranzactie);
        System.DateTime GetDataExpirare();
    }
}
