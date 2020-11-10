namespace ILL.BLL.General
{
    public interface IColectieElementePozitionate
    {
        void InterschimbaPozitieElemente(int pPozitieActualaElement, bool pInSus);
        void SchimbaDirectPozitieElement(int pPozitieActualaElement, int pNouaPozitie);
        void SorteazaAlfabeticInBaza();
        int Count { get; }
    }
}
