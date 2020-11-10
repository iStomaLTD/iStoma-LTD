using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CCL.iStomaLab
{
    [Serializable]
    public class InregistrareDejaModificataException : Exception
    {
        public InregistrareDejaModificataException()
        {
        }

        public InregistrareDejaModificataException(string pMesaj)
            : base(pMesaj)
        {
        }

        public InregistrareDejaModificataException(string pMesaj, Exception pInnerException)
            : base(pMesaj, pInnerException)
        {
        }

        protected InregistrareDejaModificataException(SerializationInfo pInfo, StreamingContext pContext)
            : base(pInfo, pContext)
        {
        }
    }
}
