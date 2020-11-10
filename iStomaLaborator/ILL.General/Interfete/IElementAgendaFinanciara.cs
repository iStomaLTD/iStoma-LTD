using System;
using System.Collections.Generic;
using CDL.iStomaLab;
using ILL.BLL.General;

namespace ILL.General.Interfete
{
    /// <summary>
    /// Pentru a putea afisa pacientii cu sumele pe care le-au platit azi
    /// </summary>
    public interface IElementAgendaFinanciara : IElementAgenda
    {
        Dictionary<DateTime, Dictionary<CDefinitiiComune.EnumTipMoneda, double>> ListaPlatiAgendaFinanciara { get; }
        double GetRezumaPlatiAgendaFinanciara(DateTime pDataDeInteres, CDefinitiiComune.EnumTipMoneda pMoneda);
    }
}
