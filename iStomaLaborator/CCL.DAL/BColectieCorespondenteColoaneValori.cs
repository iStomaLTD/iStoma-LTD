using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.DAL
{
    public class BColectieCorespondenteColoaneValori : Dictionary<string, object>
    {

        public void AdaugaNull(string pCheie)
        {
            this.Add(pCheie, DBNull.Value);
        }

        public void Adauga(string pCheie, CDefinitiiComune.EnumTipObiect pValoare)
        {
            if (pValoare != CDefinitiiComune.EnumTipObiect.Nedefinit)
                this.Add(pCheie, (int)pValoare);
            else
                this.Add(pCheie, DBNull.Value);
        }

        public void Adauga(string pCheie, CDefinitiiComune.EnumStare pValoare)
        {
            this.Add(pCheie, pValoare);
        }

        public void Adauga(string pCheie, double pValoare)
        {
            Adauga(pCheie, pValoare, true);
        }

        public void Adauga(string pCheie, double pValoare, bool pCuVerificare)
        {
            if (pValoare > 0 || !pCuVerificare)
                this.Add(pCheie, pValoare);
            else
                this.Add(pCheie, DBNull.Value);
        }

        public void Adauga(string pCheie, double? pValoare)
        {
            if (pValoare.HasValue)
                this.Add(pCheie, pValoare.Value);
            else
                this.Add(pCheie, DBNull.Value);
        }

        public void Adauga(string pCheie, double? pValoare, bool pCuVerificare)
        {
            if (pValoare.HasValue)
            {
                if (pValoare.Value <= 0 && pCuVerificare)
                    this.Add(pCheie, DBNull.Value);
                else
                    this.Add(pCheie, pValoare.Value);
            }
            else
            {
                this.Add(pCheie, DBNull.Value);
            }
        }

        public void Adauga(string pCheie, CDefinitiiComune.EnumTipMoneda pValoare)
        {
            Adauga(pCheie, pValoare, true);
        }

        public void Adauga(string pCheie, CDefinitiiComune.EnumTipMoneda pValoare, bool pCuVerificare)
        {
            if (pValoare != CDefinitiiComune.EnumTipMoneda.Nedefinit || !pCuVerificare)
                this.Add(pCheie, Convert.ToInt32(pValoare));
            else
                this.Add(pCheie, DBNull.Value);
        }

        public void Adauga(string pCheie, long pValoare)
        {
            if (pValoare > 0)
                this.Add(pCheie, pValoare);
            else
                this.Add(pCheie, DBNull.Value);
        }

        public void Adauga(string pCheie, bool pValoare)
        {
            this.Add(pCheie, pValoare);
        }

        public void Adauga(string pCheie, int pValoare)
        {
            this.Adauga(pCheie, pValoare, true);
        }

        public void Adauga(string pCheie, bool pValoare, bool pCuVerificare)
        {
            if (pValoare || !pCuVerificare)
                this.Add(pCheie, pValoare);
            else
                this.Add(pCheie, DBNull.Value);
        }

        public void Adauga(string pCheie, int pValoare, bool pCuVerificare)
        {
            if (pValoare > 0 || !pCuVerificare)
                this.Add(pCheie, pValoare);
            else
                this.Add(pCheie, DBNull.Value);
        }

        public void Adauga(string pCheie, int? pValoare)
        {
            this.Adauga(pCheie, pValoare, true);
        }

        public void Adauga(string pCheie, int? pValoare, bool pCuVerificare)
        {
            if (pValoare.HasValue)
            {
                if (pValoare.Value <= 0 && pCuVerificare)
                    this.Add(pCheie, DBNull.Value);
                else
                    this.Add(pCheie, pValoare.Value);
            }
            else
            {
                this.Add(pCheie, DBNull.Value);
            }
        }

        public void Adauga(string pCheie, byte pValoare)
        {
            if (pValoare > 0)
                this.Add(pCheie, pValoare);
            else
                this.Add(pCheie, DBNull.Value);
        }

        public void Adauga(string pCheie, byte[] pValoare)
        {
            if (pValoare != null && pValoare.Length > 0)
                this.Add(pCheie, pValoare);
            else
                this.Add(pCheie, DBNull.Value);
        }

        public void Adauga(string pCheie, short pValoare)
        {
            if (pValoare > 0)
                this.Add(pCheie, pValoare);
            else
                this.Add(pCheie, DBNull.Value);
        }

        public void Adauga(string pCheie, string pValoare, bool pCuVerificare)
        {
            if (!string.IsNullOrEmpty(pValoare) || !pCuVerificare)
                this.Add(pCheie, pValoare);
            else
                this.Add(pCheie, DBNull.Value);
        }

        public void Adauga(string pCheie, string pValoare)
        {
            if (!string.IsNullOrEmpty(pValoare))
                this.Add(pCheie, pValoare);
            else
                this.Add(pCheie, DBNull.Value);
        }

        public void Adauga(string pCheie, DateTime pValoare, bool pCuVerificare)
        {
            if (pValoare != CConstante.DataNula || !pCuVerificare)
                this.Add(pCheie, pValoare);
            else
                this.Add(pCheie, DBNull.Value);
        }

        public void Adauga(string pCheie, DateTime pValoare)
        {
            if (pValoare != CConstante.DataNula)
                this.Add(pCheie, pValoare);
            else
                this.Add(pCheie, DBNull.Value);
        }

        //public void Adauga(string pCheie, object pValoare)
        //{
        //    if (pValoare != null)
        //        this.Add(pCheie, pValoare);
        //    else
        //        this.Add(pCheie, DBNull.Value);
        //}

        public static string GetFaraUltimulAND(StringBuilder pText)
        {
            string WHERE = pText.ToString();
            //Stergem ultimul AND
            if (WHERE.Length > 5)
                WHERE = WHERE.Substring(0, WHERE.Length - 5);

            return WHERE;
        }

        public static string GetFaraUltimaVirgula(StringBuilder pText)
        {
            string listaColoane = pText.ToString();
            listaColoane = listaColoane.Substring(0, listaColoane.Length - 3);
            return listaColoane;
        }

        public void AppendForInsert(BColectieParametriSQL pListaParametri, StringBuilder pColoane, StringBuilder pValori)
        {
            foreach (KeyValuePair<string, object> corespondenta in this)
            {
                pColoane.Append(string.Format("{0} , ", corespondenta.Key));
                pValori.Append(string.Format("@{0} , ", corespondenta.Key));
                pListaParametri.Add(string.Format("@{0}", corespondenta.Key), corespondenta.Value);
            }
        }

        public void AppendForConditie(BColectieParametriSQL pListaParametri, StringBuilder pConditie)
        {
            foreach (KeyValuePair<string, object> coloanaId in this)
            {
                if (coloanaId.Value == DBNull.Value)
                    continue;
                pConditie.AppendFormat(" {0} = @{0} AND ", coloanaId.Key);
                pListaParametri.Add(coloanaId.Key, coloanaId.Value);
            }
        }

        public void AppendForUpdate(BColectieParametriSQL pListaParametri, StringBuilder pSet)
        {
            foreach (KeyValuePair<string, object> corespondenta in this)
            {
                pSet.AppendFormat(" {0} = @{0} , ", corespondenta.Key);
                pListaParametri.Add(corespondenta.Key, corespondenta.Value);
            }
        }
    }
}
