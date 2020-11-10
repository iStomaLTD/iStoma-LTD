using ILL.BLL.General;

namespace ILL.General.Interfete
{
    public interface ISemnalizareVizuala : IAfisaj
    {
        int IdTipSemnalizareVizuala { get; }
        int ARGBCuloareSemnalizareVizuala { get; }
        int IdImagineSemnalizareVizuala { get; }
    }
}
