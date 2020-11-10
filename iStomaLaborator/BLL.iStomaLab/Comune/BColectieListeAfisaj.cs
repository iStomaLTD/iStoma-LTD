using CCL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL.iStomaLab.Comune
{
    public sealed class BColectieListeAfisaj : List<BListeAfisaj>, IDisposable
    {

        #region Constructori

        public BColectieListeAfisaj()
        {
        }

        public BColectieListeAfisaj(BListeAfisaj pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieListeAfisaj(List<BListeAfisaj> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieListeAfisaj(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BListeAfisaj);
                }
            }
        }

        public void Adauga(BListeAfisaj pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BListeAfisaj GetById(int pId)
        {
            return this.Find(delegate (BListeAfisaj pObiect) { return pObiect.Id == pId; });
        }

        internal BListeAfisaj GetByNume(string pNumeLista)
        {
            return this.Find(delegate (BListeAfisaj pObiect) { return pObiect.DenumireLista == pNumeLista; });
        }

        public BColectieListeAfisaj Intersectie(BColectieListeAfisaj pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieListeAfisaj, BListeAfisaj>(this, pListaDeIntersectat);
        }

        public BColectieListeAfisaj Filtreaza()
        {
            BColectieListeAfisaj SubLista = new BColectieListeAfisaj();
            foreach (BListeAfisaj Element in this)
            {
                SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BListeAfisaj ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void StergeListaDinBaza()
        {
            IDbTransaction xTransact = null;
            try
            {
                xTransact = CCL.DAL.CCerereSQL.GetTransactionOnConnection();
                foreach (BListeAfisaj ObiectDeSters in this)
                {
                    ObiectDeSters.Delete(xTransact);
                }
                CCL.DAL.CCerereSQL.CloseTransactionOnConnection(xTransact, true);
            }
            catch (Exception exc)
            {
                if (xTransact != null) CCL.DAL.CCerereSQL.CloseTransactionOnConnection(xTransact, false);
                throw exc;
            }
        }
        public void Dispose()
        {
            foreach (BListeAfisaj Element in this)
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
            return CUtil.getListaCaText<BListeAfisaj>(this, "; ");
        }

    }
}
