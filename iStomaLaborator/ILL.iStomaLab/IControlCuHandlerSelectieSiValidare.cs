using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILL.iStomaLab
{
    public interface IControlCuHandlerSelectieSiValidare<T>
    {
        event SelectieHandler<T> SelectieMultiplaEfectuata;
        void ValideazaSelectiaMultipla();
        void SetGestionareValidareUnica(bool pSeGestioneaza);
    }
}
