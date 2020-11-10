using System;
using System.Collections.Generic;
using System.Data;
using CCL.iStomaLab;
using CDL.iStomaLab;

namespace CCL.DAL
{
    public class BColectieParametriSQL : List<IDataParameter>
    {
        public BColectieParametriSQL()
        {

        }

        /// <summary>
        /// Constructor util pentru metodele GetById
        /// </summary>
        /// <param name="pNumeParametru">Numele parametrului ID</param>
        /// <param name="pValoare">valoarea parametrului ID</param>
        public BColectieParametriSQL(string pNumeParametru, int pValoare)
        {
            this.Add(CInterfataSQLServer.getNewDataParameterForStoredProcedure(pNumeParametru, pValoare));
        }

        public void AdaugaParametriiLaComanda(IDbCommand pComanda)
        {
            //Stergem parametrii precedenti ai comenzii
            pComanda.Parameters.Clear();
            //Adaugam noii parametri la comanda
            foreach (IDataParameter sqlParam in this)
            {
                pComanda.Parameters.Add(sqlParam);
            }
        }

        public void AddEmpty(string pNumeParametru)
        {
            this.Add(CInterfataSQLServer.getParametruEmpty(pNumeParametru));
        }

        public void Add(string pNumeParametru, short pValoare)
        {
            Add(pNumeParametru, pValoare, false);
        }
        public void Add(string pNumeParametru, short pValoare, bool pTestNull)
        {
            if (pTestNull && pValoare <= 0)
                this.Add(CInterfataSQLServer.getParametruEmpty(pNumeParametru));
            else
                this.Add(CInterfataSQLServer.getNewDataParameterForStoredProcedure(pNumeParametru, pValoare));
        }

        public void Add(string pNumeParametru, CDefinitiiComune.EnumTipObiect pValoare)
        {
            if (pValoare == CDefinitiiComune.EnumTipObiect.Nedefinit)
                this.Add(CInterfataSQLServer.getParametruEmpty(pNumeParametru));
            else
                this.Add(CInterfataSQLServer.getNewDataParameterForStoredProcedure(pNumeParametru, Convert.ToInt32(pValoare)));
        }

        public void Add(string pNumeParametru, CDefinitiiComune.EnumTipMoneda pValoare, bool pTestNull)
        {
            if (pValoare == CDefinitiiComune.EnumTipMoneda.Nedefinit && pTestNull)
                this.Add(CInterfataSQLServer.getParametruEmpty(pNumeParametru));
            else
                this.Add(CInterfataSQLServer.getNewDataParameterForStoredProcedure(pNumeParametru, Convert.ToInt32(pValoare)));
        }

        public void Add(string pNumeParametru, List<int> pValoare)
        {
            if (!CUtil.EsteListaVida<int>(pValoare))
                Add(pNumeParametru, CUtil.getListaCaText<int>(pValoare, ","));
            else
                AddEmpty(pNumeParametru);
        }

        public void Add(string pNumeParametru, int pValoare)
        {
            Add(pNumeParametru, pValoare, false);
        }
        public void Add(string pNumeParametru, int pValoare, bool pTestNull)
        {
            if (pTestNull && pValoare <= 0)
                this.Add(CInterfataSQLServer.getParametruEmpty(pNumeParametru));
            else
                this.Add(CInterfataSQLServer.getNewDataParameterForStoredProcedure(pNumeParametru, pValoare));
        }

        public void Add(string pNumeParametru, long pValoare)
        {
            Add(pNumeParametru, pValoare, false);
        }
        public void Add(string pNumeParametru, long pValoare, bool pTestNull)
        {
            if (pTestNull && pValoare <= 0)
                this.Add(CInterfataSQLServer.getParametruEmpty(pNumeParametru));
            else
                this.Add(CInterfataSQLServer.getNewDataParameterForStoredProcedure(pNumeParametru, pValoare));
        }

        public void Add(string pNumeParametru, decimal pValoare)
        {
            Add(pNumeParametru, pValoare, false);
        }
        public void Add(string pNumeParametru, decimal pValoare, bool pTestNull)
        {
            if (pTestNull && pValoare <= 0)
                this.Add(CInterfataSQLServer.getParametruEmpty(pNumeParametru));
            else
                this.Add(CInterfataSQLServer.getNewDataParameterForStoredProcedure(pNumeParametru, pValoare));
        }
        public void Add(string pNumeParametru, double pValoare)
        {
            Add(pNumeParametru, pValoare, false);
        }
        public void Add(string pNumeParametru, double pValoare, bool pTestNull)
        {
            if (pTestNull && pValoare <= 0)
                this.Add(CInterfataSQLServer.getParametruEmpty(pNumeParametru));
            else
                this.Add(CInterfataSQLServer.getNewDataParameterForStoredProcedure(pNumeParametru, pValoare));
        }
        public void Add(string pNumeParametru, string pValoare)
        {
            Add(pNumeParametru, pValoare, false);
        }
        public void Add(string pNumeParametru, string pValoare, bool pTestNull)
        {
            if (pTestNull && string.IsNullOrEmpty(pValoare))
                this.Add(CInterfataSQLServer.getParametruEmpty(pNumeParametru));
            else
                this.Add(CInterfataSQLServer.getNewDataParameterForStoredProcedure(pNumeParametru, pValoare));
        }

        public void Add(string pNumeParametru, bool pValoare)
        {
            Add(pNumeParametru, pValoare, false);
        }
        public void Add(string pNumeParametru, bool pValoare, bool pTestNull)
        {
            if (pTestNull && pValoare == false)
                this.AddEmpty(pNumeParametru);
            else
                this.Add(CInterfataSQLServer.getNewDataParameterForStoredProcedure(pNumeParametru, pValoare));
        }

        public void Add(string pNumeParametru, DateTime pValoare)
        {
            Add(pNumeParametru, pValoare, false);
        }
        public void Add(string pNumeParametru, DateTime pValoare, bool pTestNull)
        {
            if (pTestNull && pValoare == CConstante.DataNula)
                this.Add(CInterfataSQLServer.getParametruEmpty(pNumeParametru));
            else
                this.Add(CInterfataSQLServer.getNewDataParameterForStoredProcedure(pNumeParametru, pValoare));
        }

        public void Add(string pNumeParametru, CDefinitiiComune.EnumRaspuns pValoare)
        {
            if (pValoare == CDefinitiiComune.EnumRaspuns.NuStiu || pValoare == null)
                this.Add(CInterfataSQLServer.getParametruEmpty(pNumeParametru));
            else
            {
                if (pValoare == CDefinitiiComune.EnumRaspuns.Da)
                    this.Add(CInterfataSQLServer.getNewDataParameterForStoredProcedure(pNumeParametru, true));
                else
                    this.Add(CInterfataSQLServer.getNewDataParameterForStoredProcedure(pNumeParametru, false));
            }
        }

        public void Add(string pNumeParametru, object pValoare)
        {
            if (pValoare == null)
                this.Add(CInterfataSQLServer.getParametruEmpty(pNumeParametru));
            else
                this.Add(CInterfataSQLServer.getNewDataParameterForStoredProcedure(pNumeParametru, pValoare));
        }
    }
}
