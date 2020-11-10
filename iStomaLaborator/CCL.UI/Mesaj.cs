using System.Windows.Forms;
using CCL.UI.FormulareComune;
using EnumTipButon = CCL.UI.FormulareComune.frmMesajPersonalizat.EnumTipButon;

namespace CCL.UI
{
    public static class Mesaj
    {
        //private static frmMesajPersonalizat frmMesaj = null;

        public enum EnumButoane
        {
            OK = 1,
            Anuleaza = 2,
            OkAnuleaza = 3,
            DaNu = 4
        }

        public enum EnumIcoana
        {
            Niciunul = 0,
            Informatie = 1,
            Intrebare = 2,
            Eroare = 3
        }

        public static DialogResult Afiseaza(Form pEcranParinte, string pMesaj)
        {
            using (frmMesajPersonalizat frmMesaj = new frmMesajPersonalizat(pMesaj, "", EnumButoane.OK, EnumIcoana.Niciunul))
            {
                return IHMUtile.DeschideEcranShowDialog(pEcranParinte, frmMesaj);
            }
        }

        public static DialogResult Afiseaza(Form pEcranParinte, string pMesaj, string pTitlu)
        {
            using (frmMesajPersonalizat frmMesaj = new frmMesajPersonalizat(pMesaj, pTitlu, EnumButoane.OK, EnumIcoana.Niciunul))
                return IHMUtile.DeschideEcranShowDialog(pEcranParinte, frmMesaj);
        }

        public static DialogResult Afiseaza(Form pEcranParinte, string pMesaj, string pTitlu, EnumButoane pButoane)
        {
            using (frmMesajPersonalizat frmMesaj = new frmMesajPersonalizat(pMesaj, pTitlu, pButoane, EnumIcoana.Niciunul))
                return IHMUtile.DeschideEcranShowDialog(pEcranParinte, frmMesaj);
        }

        public static DialogResult Afiseaza(Form pEcranParinte, string pMesaj, string pTitlu, EnumButoane pButoane, EnumIcoana pIcoana)
        {
            return Afiseaza(pEcranParinte, pMesaj, pTitlu, pButoane, pIcoana, false);
        }

        public static DialogResult Afiseaza(Form pEcranParinte, string pMesaj, string pTitlu, EnumButoane pButoane, EnumIcoana pIcoana, bool pDeschideInCentrulEcranului)
        {
            using (frmMesajPersonalizat frmMesaj = new frmMesajPersonalizat(pMesaj, pTitlu, pButoane, pIcoana))
            {
                if (pDeschideInCentrulEcranului)
                    frmMesaj.StartPosition = FormStartPosition.CenterScreen;

                return IHMUtile.DeschideEcranShowDialog(pEcranParinte, frmMesaj);
            }
        }

        public static DialogResult Afiseaza(Form pEcranParinte, string pMesaj, string pTitlu, EnumButoane pButoane, EnumIcoana pIcoana, EnumTipButon pButonEnter)
        {
            return Afiseaza(pEcranParinte, pMesaj, pTitlu, pButoane, pIcoana, pButonEnter, CEnumerariComune.EnumTipDeschidere.DreaptaSus);
        }

        public static DialogResult Afiseaza(Form pEcranParinte, string pMesaj, string pTitlu, EnumButoane pButoane, EnumIcoana pIcoana, EnumTipButon pButonEnter, CCL.UI.CEnumerariComune.EnumTipDeschidere pTipDeschidere)
        {
            using (frmMesajPersonalizat frmMesaj = new frmMesajPersonalizat(pMesaj, pTitlu, pButoane, pIcoana, pButonEnter, pTipDeschidere))
            {
                return IHMUtile.DeschideEcranShowDialog(pEcranParinte, frmMesaj);
            }
        }

        public static bool Confirmare(Form pEcranParinte, string pMesaj, string pTitlu)
        {
            return Confirmare(pEcranParinte, pMesaj, pTitlu, false);
        }

        public static bool Confirmare(Form pEcranParinte, string pMesaj, string pTitlu, bool pDeschideInCentrulEcranului)
        {
            using (frmMesajPersonalizat frmMesaj = new frmMesajPersonalizat(pMesaj, pTitlu, EnumButoane.DaNu, EnumIcoana.Intrebare))
            {
                if (pDeschideInCentrulEcranului)
                    frmMesaj.StartPosition = FormStartPosition.CenterScreen;
                else
                    frmMesaj.TipDeschidere = CEnumerariComune.EnumTipDeschidere.DreaptaSus;

                return IHMUtile.DeschideEcran(pEcranParinte, frmMesaj);
            }
        }

        public static void Informare(Form pEcranParinte, string pMesaj, string pTitlu)
        {
            Informare(pEcranParinte, pMesaj, pTitlu, false);
        }

        public static void Informare(Form pEcranParinte, string pMesaj, string pTitlu, bool pDeschideInCentrulEcranului)
        {
            using (frmMesajPersonalizat frmMesaj = new frmMesajPersonalizat(pMesaj, pTitlu, EnumButoane.OK, EnumIcoana.Informatie))
            {
                if (pDeschideInCentrulEcranului)
                    frmMesaj.StartPosition = FormStartPosition.CenterScreen;
                IHMUtile.DeschideEcran(pEcranParinte, frmMesaj);
            }
        }

        public static void Eroare(Form pEcranParinte, string pMesaj)
        {
            Eroare(pEcranParinte, pMesaj, "Eroare", false);
        }

        public static void Eroare(Form pEcranParinte, string pMesaj, string pTitlu)
        {
            Eroare(pEcranParinte, pMesaj, pTitlu, false);
        }

        public static void Eroare(Form pEcranParinte, string pMesaj, string pTitlu, bool pDeschideInCentrulEcranului)
        {
            using (frmMesajPersonalizat frmMesaj = new frmMesajPersonalizat(pMesaj, pTitlu, EnumButoane.OK, EnumIcoana.Eroare))
            {
                if (pDeschideInCentrulEcranului)
                    frmMesaj.StartPosition = FormStartPosition.CenterScreen;
                CCL.UI.IHMUtile.DeschideEcran(pEcranParinte, frmMesaj);
            }
        }
    }
}
