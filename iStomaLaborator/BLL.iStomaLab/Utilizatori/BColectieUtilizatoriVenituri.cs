using CCL.iStomaLab;
using CDL.iStomaLab;
using DAL.iStomaLab.Utilizatori;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.iStomaLab.Utilizatori
{
    public sealed class BColectieUtilizatoriVenituri : List<BUtilizatoriVenituri>, IDisposable
    {

        #region Constructori

        public BColectieUtilizatoriVenituri()
        {
        }

        public BColectieUtilizatoriVenituri(BUtilizatoriVenituri pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieUtilizatoriVenituri(List<BUtilizatoriVenituri> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieUtilizatoriVenituri(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BUtilizatoriVenituri);
                }
            }
        }

        public void Adauga(BUtilizatoriVenituri pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BUtilizatoriVenituri GetById(int pId)
        {
            return this.Find(delegate (BUtilizatoriVenituri pObiect) { return pObiect.Id == pId; });
        }

        public BColectieUtilizatoriVenituri Intersectie(BColectieUtilizatoriVenituri pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieUtilizatoriVenituri, BUtilizatoriVenituri>(this, pListaDeIntersectat);
        }

        public BColectieUtilizatoriVenituri Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieUtilizatoriVenituri SubLista = new BColectieUtilizatoriVenituri();
            foreach (BUtilizatoriVenituri Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public BColectieUtilizatoriVenituri GetVenituriActiveInPerioada(int pIdUtilizator, DateTime pDataInceput, DateTime pDataSfarsit)
        {
            BColectieUtilizatoriVenituri listaRetur = new BColectieUtilizatoriVenituri();

            foreach (var item in this)
            {
                if (item.IdUtilizator != pIdUtilizator)
                    continue;

                if (item.EsteActivInPerioada(pDataInceput, pDataSfarsit)) 
                    listaRetur.Add(item);
            }

            return listaRetur;
        }


        public void RefreshById(int pId)
        {
            BUtilizatoriVenituri ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BUtilizatoriVenituri Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BUtilizatoriVenituri pObiect) { return pObiect.EsteActiv == false; }) != null;
        }

        public List<int> GetListaId()
        {
            List<int> lstRetur = new List<int>();
            foreach (var item in this)
            {
                lstRetur.Add(item.Id);
            }
            return lstRetur;
        }

        public override string ToString()
        {
            return CUtil.getListaCaText<BUtilizatoriVenituri>(this, "; ");
        }

        /// <summary>
        /// Intoarce true daca data trimisa poate fi utilizata pentru crearea unui nou tip de venit (nu exista niciun venit care sa cuprinda in interval data transamisa in parametru)
        /// </summary>
        /// <param name="pDataTest"></param>
        /// <returns></returns>
        public bool EsteDataInceputCoerenta(DateTime pDataTest)
        {
            foreach (var item in this)
            {
                if(item.DataFinal != CConstante.DataNula)
                {
                    if (item.DataInceput >= pDataTest && item.DataFinal <= pDataTest)
                        return false;
                }
                else
                {
                    if (item.DataInceput == pDataTest)
                        return false;
                }
            }

            return true;
        }

       
    }
}
