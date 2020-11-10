using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.iStomaLab
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class BIdentitateAttribute : Attribute
    {
        private bool _bIsIdentity;
        public BIdentitateAttribute(bool pIsIdentity)
        {
            this._bIsIdentity = pIsIdentity;
        }
    }
}
