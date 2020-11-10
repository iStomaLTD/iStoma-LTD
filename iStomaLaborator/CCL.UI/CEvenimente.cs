using System;
using System.Drawing;
using System.Windows.Forms;
using CDL.iStomaLab;

namespace CCL.UI
{
    public class CEvenimente
    {
        public delegate void EventDeschideEcranCautare(Control psender, object pxObiectExistent);
        public delegate void ZonaModificata(Control psender, string pNumeProprietate, object pNouaValoare);
        public delegate void EventCNPModificat(Control psender, CDefinitiiComune.EnumSex plSex,
                DateTime pdDataNasterii, int plIdRegiune, int plIdLocalitate,
                CDefinitiiComune.EnumTitulatura plTitulatura, bool pbNascutInRomania);

        public delegate void EventIdHandler(Control psender, int pValoareNumerica);
        public delegate bool EventIdHandlerCuConfirmareExterna(Control psender, int pId);

        public delegate void EventStringHandler(Control psender, string pNouaValoare);
        public delegate void AfiseazaExceptieHandler(Control psender, Exception pExceptie);
        public delegate void ElementSelectatHandler<T>(T pElement);
        public delegate void RaspunsDelegate(Control pSender, CDL.iStomaLab.CDefinitiiComune.EnumRaspuns pNoulRaspuns);
        public delegate Tuple<int, Bitmap> CautaPozaHandler(Control pSender);
        public delegate void ControlDelegate(Control pSender);
    }
}
