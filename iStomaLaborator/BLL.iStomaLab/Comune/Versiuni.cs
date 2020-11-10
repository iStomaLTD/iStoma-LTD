using DAL.iStomaLab.Comune;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL.iStomaLab.Comune
{
    public static class Versiuni
    {
        public const string VERSIUNE_APLICATIE = "104";
        public const string VERSIUNE_APLICATIE_AFISAJ = "1.0.4";

        public static bool ExistaCompatibilitate()
        {
            return VERSIUNE_APLICATIE.Equals(getVersiuneBDD());
        }

        public static string getVersiuneAfisajBDD()
        {
            string versiune = getVersiuneBDD();
            if (string.IsNullOrEmpty(versiune))
                versiune = VERSIUNE_APLICATIE;

            return string.Format("{0}.{1}.{2}", versiune[0], versiune[1], versiune[2]);
        }

        public static string getVersiuneBDD()
        {
            string versiune = VERSIUNE_APLICATIE;
            using (DataSet ds = DVersiuni.GetUltimaVersiuneBDD(null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    versiune = Convert.ToString(ds.Tables[0].Rows[0][DVersiuni.EnumCampuriTabela.tVersiune.ToString()]);
                }
            }
            return versiune;
        }

        public static void SeFolosescRegistriiPentruConexiuneaBDD(bool pSeFolosesc)
        {
            //CCL.DAL.CInterfataSQLServer._SConexiuneInRegistrii = pSeFolosesc;
            //CCL.Furnizori.CSecuritate._SConexiuneInRegistrii = pSeFolosesc;
        }
    }
}
