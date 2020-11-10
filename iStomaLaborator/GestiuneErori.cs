using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStomaLab
{
    public class GestiuneErori
    {
        public static void AfiseazaMesaj(System.Windows.Forms.Form pEcranParinte, Exception ParamExceptie)
        {
            //if (IHMUtile._AccesTotal != null)
            //    IHMUtile._AccesTotal.inchideEcranAsteptare();

            using (Erori.frmEroare ecran = new Erori.frmEroare(ParamExceptie))
            {
                CCL.UI.IHMUtile.DeschideEcran(pEcranParinte, ecran);
            }
        }

        public static void AfiseazaMesaj(System.Windows.Forms.Form pEcranParinte, string pEroare)
        {
            //if (IHMUtile._AccesTotal != null)
            //    IHMUtile._AccesTotal.inchideEcranAsteptare();

            using (Erori.frmEroare ecran = new Erori.frmEroare(new Exception(pEroare)))
            {
                ecran.AscundeButonDetalii();
                CCL.UI.IHMUtile.DeschideEcran(pEcranParinte, ecran);
            }
        }
    }
}
