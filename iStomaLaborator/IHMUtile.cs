using BLL.iStomaLab.Comune;
using CDL.iStomaLab;
using ILL.BLL.General;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iStomaLab
{
    #region Enumerari

    internal enum EnumRubrica
    {
        TablouDeBord = 1,
        Rapoarte = 2,
        Setari = 3
    }

    internal enum EnumOptiune
    {
        TablouDeBord = 101,
        Rapoarte = 201,
        SetariListaPreturi = 301,
        SetariLocatii = 302,
        SetariPersonal = 303,
        SetariDiverse = 304,
        Clienti = 305,
        SetariListe = 306,
        Email = 307,
        Comunicare = 308
    }
    
    public enum EnumRubricaEmail
    {
        Inbox = 1,
        Drafts = 2,
        Sent = 3,
        Trash = 4
    }

    #endregion

    internal static class IHMUtile
    {
        internal static Image GetImagineSageataJos()
        {
            return Properties.Resources.collapse;
        }

        internal static Image GetImagineSageataDreapta()
        {
            return Properties.Resources.expand;
        }

        public static Tuple<DateTime, DateTime> GetPerioada(System.Windows.Forms.Form pEcranParinte, DateTime pDataInceput, DateTime pDataSfarsit)
        {
            return Caramizi.FormSelecteazaDate.Afiseaza(pEcranParinte, pDataInceput, pDataSfarsit);
        }

        #region Adrese

        public static BAdrese AdaugaAdresa(Form pEcranParinte, CDefinitiiComune.EnumTipObiect pTipProprietar, int pIdProprietar)
        {
            if (pIdProprietar > 0)
                return Generale.frmAfiseazaAdresa.AfiseazaEcran(pEcranParinte, pTipProprietar, pIdProprietar, BAdrese.EnumTipAdresa.Principala, true, true, true);

            return null;
        }

        public static BAdrese AdaugaAdresa(Form pEcranParinte, IProprietar pObiectProprietarAdresa)
        {
            if (pObiectProprietarAdresa != null)
                return Generale.frmAfiseazaAdresa.AfiseazaEcran(pEcranParinte, pObiectProprietarAdresa, true, true, true);

            return null;
        }

        public static BAdrese GetAdresa(Form pEcranParinte, CDefinitiiComune.EnumTipObiect pTipProprietar, int pIdProprietar, bool pEcranInModificare)
        {
            if (pIdProprietar > 0)
                return Generale.frmAfiseazaAdresa.AfiseazaEcran(pEcranParinte, pTipProprietar, pIdProprietar, BAdrese.EnumTipAdresa.Principala, false, true, pEcranInModificare);

            return null;
        }

        public static BAdrese GetAdresa(Form pEcranParinte, IProprietar pObiectProprietarAdresa, bool pEcranInModificare)
        {
            return Generale.frmAfiseazaAdresa.AfiseazaEcran(pEcranParinte, pObiectProprietarAdresa, false, true, pEcranInModificare);
        }

        internal static void ModificaAdresa(Form pEcranParinte, BAdrese pAdresa)
        {
            Generale.frmAfiseazaAdresa.AfiseazaEcran(pEcranParinte, pAdresa);
        }

        #endregion

    }
}
