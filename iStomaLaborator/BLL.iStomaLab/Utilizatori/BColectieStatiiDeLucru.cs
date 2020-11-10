using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CCL.iStomaLab;

namespace BLL.iStomaLab.Utilizatori
{
    public sealed class BColectieStatiiDeLucru : List<BStatiiDeLucru>, IDisposable
    {

        #region Constructori

        public BColectieStatiiDeLucru()
        {
        }

        public BColectieStatiiDeLucru(BStatiiDeLucru pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieStatiiDeLucru(List<BStatiiDeLucru> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieStatiiDeLucru(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BStatiiDeLucru);
                }
            }
        }

        public void Adauga(BStatiiDeLucru pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BStatiiDeLucru GetById(int pId)
        {
            return this.Find(delegate (BStatiiDeLucru pObiect) { return pObiect.Id == pId; });
        }

        public BColectieStatiiDeLucru Intersectie(BColectieStatiiDeLucru pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieStatiiDeLucru, BStatiiDeLucru>(this, pListaDeIntersectat);
        }

        public BColectieStatiiDeLucru Filtreaza()
        {
            BColectieStatiiDeLucru SubLista = new BColectieStatiiDeLucru();
            foreach (BStatiiDeLucru Element in this)
            {
                SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BStatiiDeLucru ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BStatiiDeLucru Element in this)
            {
                Element.Dispose();
            }
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
            return CUtil.getListaCaText<BStatiiDeLucru>(this, "; ");
        }

    }
}
