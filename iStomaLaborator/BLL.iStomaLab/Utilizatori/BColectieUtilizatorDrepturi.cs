using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CCL.iStomaLab;
using static BLL.iStomaLab.Utilizatori.BUtilizatorDrepturi;

namespace BLL.iStomaLab.Utilizatori
{
    public sealed class BColectieUtilizatorDrepturi : List<BUtilizatorDrepturi>, IDisposable
    {

        #region Constructori

        public BColectieUtilizatorDrepturi()
        {
        }

        public BColectieUtilizatorDrepturi(BUtilizatorDrepturi pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieUtilizatorDrepturi(List<BUtilizatorDrepturi> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieUtilizatorDrepturi(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BUtilizatorDrepturi);
                }
            }
        }

        public void Adauga(BUtilizatorDrepturi pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BUtilizatorDrepturi GetByIdOptiune(EnumOptiune pIdOptiune)
        {
            return this.Find(delegate (BUtilizatorDrepturi pObiect) { return pObiect.IdOptiune == pIdOptiune; });
        }

        public BColectieUtilizatorDrepturi Intersectie(BColectieUtilizatorDrepturi pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieUtilizatorDrepturi, BUtilizatorDrepturi>(this, pListaDeIntersectat);
        }

        public BColectieUtilizatorDrepturi Filtreaza()
        {
            BColectieUtilizatorDrepturi SubLista = new BColectieUtilizatorDrepturi();
            foreach (BUtilizatorDrepturi Element in this)
            {
                SubLista.Add(Element);
            }
            return SubLista;
        }

        public void Dispose()
        {
            foreach (BUtilizatorDrepturi Element in this)
            {
                Element.Dispose();
            }
        }

        public List<EnumOptiune> GetListaIdOptiuni()
        {
            List<EnumOptiune> lstRetur = new List<EnumOptiune>();
            foreach (var item in this)
            {
                lstRetur.Add(item.IdOptiune);
            }
            return lstRetur;
        }

        public override string ToString()
        {
            return CUtil.getListaCaText<BUtilizatorDrepturi>(this, "; ");
        }

        public void Delete(IDbTransaction pTranzactie)
        {
            foreach (var item in this)
            {
                item.Delete(pTranzactie);
            }
        }

        public ColectieStructOptiuni GetAsColectieStructOptiuni()
        {
            ColectieStructOptiuni listaRetur = new ColectieStructOptiuni();

            foreach (var item in this)
            {
                listaRetur.Add(item.GetAsStructOptiuni());
            }

            return listaRetur;
        }
    }
}


