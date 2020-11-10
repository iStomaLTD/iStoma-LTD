using System.Data;

namespace ILL.General.Interfete
{
    public interface IStergere
    {
        bool poateFiStearsa();
        void Delete(IDbTransaction pTranzactie);
    }
}
