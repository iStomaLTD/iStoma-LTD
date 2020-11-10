using System;

namespace ILL.General.Interfete
{
    public interface IIntervalDeLucru
    {
        DateTime DataInceputInterval { get; }
        DateTime DataFinalInterval { get; }
        int IdLocatie { get; }
        System.Drawing.Color CuloareAgenda { get; }
        string DenumireMedic { get; }
    }
}
