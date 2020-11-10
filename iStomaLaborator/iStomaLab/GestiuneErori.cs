using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStomaLab
{
    public class GestiuneErori
    {
        public static void AfiseazaMesaj(System.Windows.Forms.Form pEcranParinte, Exception pExceptie)
        {
            Erori.frmEroare.Afiseaza(pEcranParinte, pExceptie);
        }

        public static void AfiseazaMesaj(System.Windows.Forms.Form pEcranParinte, string pEroare)
        {
            Erori.frmEroare.Afiseaza(pEcranParinte, new Exception(pEroare));
        }
    }
}
