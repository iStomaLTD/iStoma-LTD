using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CDL.iStomaLab;
using CCL.iStomaLab;

namespace BLL.iStomaLab.Utilizatori
{
    public sealed class BColectieUtilizator : List<BUtilizator>, IDisposable
    {

        #region Constructori

        public BColectieUtilizator()
        {
        }

        public BColectieUtilizator(BUtilizator pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieUtilizator(List<BUtilizator> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieUtilizator(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BUtilizator);
                }
            }
        }

        public void Adauga(BUtilizator pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BUtilizator GetById(int pId)
        {
            return this.Find(delegate (BUtilizator pObiect) { return pObiect.Id == pId; });
        }

        public BUtilizator GetByIdentitate(string pNumePrenumeFaraSpatii)
        {
            return this.Find(delegate (BUtilizator pObiect) { return pObiect.ToString().ToLower().Replace(" ","").Equals(pNumePrenumeFaraSpatii.ToLower()); }); 
        }

        public BColectieUtilizator Intersectie(BColectieUtilizator pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieUtilizator, BUtilizator>(this, pListaDeIntersectat);
        }

        public BColectieUtilizator Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieUtilizator SubLista = new BColectieUtilizator();
            foreach (BUtilizator Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BUtilizator ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BUtilizator Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BUtilizator pObiect) { return pObiect.EsteActiv == false; }) != null;
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

        public List<string> GetNumePrenumeUtilizatori()
        {
            List<string> listaRetur = new List<string>();

            foreach (var item in this)
            {
                if (item.EsteActiv)
                    listaRetur.Add(item.GetNumeCompletUtilizator());
            }

            return listaRetur;
        }

        public override string ToString()
        {
            return CUtil.getListaCaText<BUtilizator>(this, "; ");
        }

        public bool ContineElementeDeactivate()
        {
            return this.Find(delegate (BUtilizator pObiect) { return !pObiect.EsteActiv; }) != null;
        }

        public BColectieUtilizator GetListaActive()
        {
            BColectieUtilizator listaRetur = new BColectieUtilizator();

            foreach (var item in this)
            {
                if (item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public BColectieUtilizator GetListaInactive()
        {
            BColectieUtilizator listaRetur = new BColectieUtilizator();

            foreach (var item in this)
            {
                if (!item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public Dictionary<int, string> GetAsDictIdDenumire()
        {
            Dictionary<int, string> dictRetur = new Dictionary<int, string>();

            int idTemp = 0;
            foreach (var item in this)
            {
                idTemp = item.Id;

                if (!dictRetur.ContainsKey(idTemp))
                    dictRetur.Add(idTemp, string.Format("{0} {1}", item.Nume, item.Prenume));
            }

            return dictRetur;
        }
    }
}
