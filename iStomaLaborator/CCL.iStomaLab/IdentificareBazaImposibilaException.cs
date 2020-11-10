using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CCL.iStomaLab
{
    [Serializable()]
    public class IdentificareBazaImposibilaException : Exception
    {
        public IdentificareBazaImposibilaException()
        {
        }
        public IdentificareBazaImposibilaException(string ParamMesaj)
            : base(ParamMesaj)
        {
        }
        public IdentificareBazaImposibilaException(string ParamMesaj, Exception ParamInnerException)
            : base(ParamMesaj, ParamInnerException)
        {
        }
        protected IdentificareBazaImposibilaException(SerializationInfo ParamInfo, StreamingContext ParamContext)
            : base(ParamInfo, ParamContext)
        {
        }
    }
}
