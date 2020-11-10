using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.iStomaLab
{
    [AttributeUsageAttribute(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public class BExportAttribute : Attribute
    {
        public BExportAttribute(string pNumeAfisaj, bool pAfisabilDefaut, long pOrdineAfisaj)
        {

        }
    }
}
