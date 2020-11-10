using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILL.iStomaLab
{
    public interface IPreferinteDGV
    {
        System.Drawing.Color CuloareDGVFundal { get; set; }
        System.Drawing.Color CuloareDGVLinie { get; set; }
        System.Drawing.Color CuloareDGVTextLinieNormala { get; set; }
        System.Drawing.Color CuloareDGVLinieAlernanta { get; set; }
        System.Drawing.Color CuloareDGVTextLinieAlternanta { get; set; }
        System.Drawing.Color CuloareDGVFundalLinieSelectata { get; set; }
        System.Drawing.Color CuloareDGVTextLinieSelectata { get; set; }
        System.Drawing.Color CuloareDGVTextAlerta { get; }
        System.Drawing.Color CuloareDGVTextAlertaRandSelectat { get; }
    }
}
