using CCL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.iStomaLab.Utilizatori
{

    public sealed class BColectieUtilizatoriVenituriDetalii : List<BUtilizatoriVenituriDetalii>, IDisposable
    {

        #region Constructori

        public BColectieUtilizatoriVenituriDetalii()
        {
        }

        public BColectieUtilizatoriVenituriDetalii(BUtilizatoriVenituriDetalii pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieUtilizatoriVenituriDetalii(List<BUtilizatoriVenituriDetalii> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieUtilizatoriVenituriDetalii(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BUtilizatoriVenituriDetalii);
                }
            }
        }

        public void Adauga(BUtilizatoriVenituriDetalii pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BUtilizatoriVenituriDetalii GetById(int pId)
        {
            return this.Find(delegate (BUtilizatoriVenituriDetalii pObiect) { return pObiect.Id == pId; });
        }

        public BColectieUtilizatoriVenituriDetalii Intersectie(BColectieUtilizatoriVenituriDetalii pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieUtilizatoriVenituriDetalii, BUtilizatoriVenituriDetalii>(this, pListaDeIntersectat);
        }

        public BColectieUtilizatoriVenituriDetalii Filtreaza()
        {
            BColectieUtilizatoriVenituriDetalii SubLista = new BColectieUtilizatoriVenituriDetalii();
            foreach (BUtilizatoriVenituriDetalii Element in this)
            {
                SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BUtilizatoriVenituriDetalii ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BUtilizatoriVenituriDetalii Element in this)
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
            return CUtil.getListaCaText<BUtilizatoriVenituriDetalii>(this, "; ");
        }

        public BUtilizatoriVenituriDetalii GetByIdEtapa(int pIdEtapa)
        {
            return this.Find(delegate (BUtilizatoriVenituriDetalii pObiect) { return pObiect.IdEtapa == pIdEtapa; });
        }

       
        public Dictionary<int, string> GetAsDictIdDenumire()
        {
            Dictionary<int, string> dictRetur = new Dictionary<int, string>();

            int idTemp = 0;
            foreach (var item in this)
            {
                idTemp = item.IdEtapa;

                if (!dictRetur.ContainsKey(idTemp))
                    dictRetur.Add(idTemp, item.Denumire);
            }

            return dictRetur;
        }
    }

}
