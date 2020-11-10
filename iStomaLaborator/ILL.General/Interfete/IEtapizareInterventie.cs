using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ILL.General.Interfete
{
    public interface IEtapizareInterventie
    {
        int Id { get; }
        int IdEtapa { get; set; }
        int IdVarianta { get; set; }
    }
}
