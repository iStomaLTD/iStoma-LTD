using CCL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.iStomaLab.Comune
{
    public sealed class BColectieColoaneListeAfisaj : List<BColoaneListeAfisaj>, IDisposable
    {

        #region Constructori

        public BColectieColoaneListeAfisaj()
        {
        }

        public BColectieColoaneListeAfisaj(BColoaneListeAfisaj pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieColoaneListeAfisaj(List<BColoaneListeAfisaj> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieColoaneListeAfisaj(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BColoaneListeAfisaj);
                }
            }
        }

        public void Adauga(BColoaneListeAfisaj pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BColectieColoaneListeAfisaj Intersectie(BColectieColoaneListeAfisaj pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieColoaneListeAfisaj, BColoaneListeAfisaj>(this, pListaDeIntersectat);
        }

        public BColectieColoaneListeAfisaj Filtreaza()
        {
            BColectieColoaneListeAfisaj SubLista = new BColectieColoaneListeAfisaj();
            foreach (BColoaneListeAfisaj Element in this)
            {
                SubLista.Add(Element);
            }
            return SubLista;
        }

        public void Dispose()
        {
            foreach (BColoaneListeAfisaj Element in this)
            {
                Element.Dispose();
            }
        }

        public List<int> GetListaIdListe()
        {
            List<int> lstRetur = new List<int>();
            foreach (var item in this)
            {
                if (!lstRetur.Contains(item.IdLista))
                    lstRetur.Add(item.IdLista);
            }
            return lstRetur;
        }

        public override string ToString()
        {
            return  CUtil.getListaCaText<BColoaneListeAfisaj>(this, "; ");
        }

        public BColoaneListeAfisaj GetByNume(string pNumeColoana)
        {
            return this.Find(delegate (BColoaneListeAfisaj pObiect) { return pObiect.Coloana.Equals(pNumeColoana); });
        }

        internal List<string> GetListaColoaneAscunse()
        {
            List<string> listaRetur = new List<string>();

            foreach (var item in this)
            {
                if (!item.Vizibila)
                    listaRetur.Add(item.Coloana);
            }

            return listaRetur;
        }

        public Dictionary<string, int> GetOrdineAfisareColoane()
        {
            Dictionary<string, int> dictRetur = new Dictionary<string, int>();

            foreach (var item in this)
            {
                if (item.Ordine >= 0)
                    dictRetur.Add(item.Coloana, item.Ordine);
            }

            return dictRetur;
        }

        public Dictionary<string, int> GetLatimeColoane()
        {
            Dictionary<string, int> dictRetur = new Dictionary<string, int>();

            foreach (var item in this)
            {
                if (item.Latime > 20)
                    dictRetur.Add(item.Coloana, item.Latime);
            }

            return dictRetur;
        }
    }
}
