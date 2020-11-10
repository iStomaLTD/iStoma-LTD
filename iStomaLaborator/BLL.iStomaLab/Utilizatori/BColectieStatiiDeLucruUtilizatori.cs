using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CCL.iStomaLab;

namespace BLL.iStomaLab.Utilizatori
{
    public sealed class BColectieStatiiDeLucruUtilizatori : List<BStatiiDeLucruUtilizatori>, IDisposable
    {

        #region Constructori

        public BColectieStatiiDeLucruUtilizatori()
        {
        }

        public BColectieStatiiDeLucruUtilizatori(BStatiiDeLucruUtilizatori pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieStatiiDeLucruUtilizatori(List<BStatiiDeLucruUtilizatori> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieStatiiDeLucruUtilizatori(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BStatiiDeLucruUtilizatori);
                }
            }
        }

        public void Adauga(BStatiiDeLucruUtilizatori pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BStatiiDeLucruUtilizatori GetByIdUtilizator(int pId)
        {
            return this.Find(delegate (BStatiiDeLucruUtilizatori pObiect) { return pObiect.IdUtilizator == pId; });
        }

        public BColectieStatiiDeLucruUtilizatori Intersectie(BColectieStatiiDeLucruUtilizatori pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieStatiiDeLucruUtilizatori, BStatiiDeLucruUtilizatori>(this, pListaDeIntersectat);
        }

        public BColectieStatiiDeLucruUtilizatori Filtreaza()
        {
            BColectieStatiiDeLucruUtilizatori SubLista = new BColectieStatiiDeLucruUtilizatori();
            foreach (BStatiiDeLucruUtilizatori Element in this)
            {
                SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshByIdUtilizator(int pId)
        {
            BStatiiDeLucruUtilizatori ObiectGasit = GetByIdUtilizator(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BStatiiDeLucruUtilizatori Element in this)
            {
                Element.Dispose();
            }
        }

        public List<int> GetListaIdUtilizatori()
        {
            List<int> lstRetur = new List<int>();
            foreach (var item in this)
            {
                lstRetur.Add(item.IdUtilizator);
            }
            return lstRetur;
        }

        public override string ToString()
        {
            return CUtil.getListaCaText<BStatiiDeLucruUtilizatori>(this, "; ");
        }

    }
}
