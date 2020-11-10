using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILL.iStomaLab
{
    public interface IAcceptaValidare<T>
    {
        T Validare();
        void Initializeaza();
    }
}
