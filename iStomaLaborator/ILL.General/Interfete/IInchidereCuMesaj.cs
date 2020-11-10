using ILL.iStomaLab;

namespace ILL.BLL.General
{
    public interface IInchidereCuMesaj : IInchidere
    {
        bool getDetaliiActiuneInchidere(ref string pTitlu, ref string pMesajConfirmare);
        string getMesajInchidere();
        string getMesajReactivare();
    }
}
