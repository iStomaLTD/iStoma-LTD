using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CCL.iStomaLab;
using CDL.iStomaLab;

namespace BLL.iStomaLab.Preturi
{
    public sealed class BColectieListaPreturiClienti : List<BListaPreturiClienti>, IDisposable
    {

        #region Constructori

        public BColectieListaPreturiClienti()
        {
        }

        public BColectieListaPreturiClienti(BListaPreturiClienti pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieListaPreturiClienti(List<BListaPreturiClienti> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieListaPreturiClienti(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BListaPreturiClienti);
                }
            }
        }

        public void Adauga(BListaPreturiClienti pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BListaPreturiClienti GetById(int pId)
        {
            return this.Find(delegate (BListaPreturiClienti pObiect) { return pObiect.Id == pId; });
        }

        public BColectieListaPreturiClienti Intersectie(BColectieListaPreturiClienti pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieListaPreturiClienti, BListaPreturiClienti>(this, pListaDeIntersectat);
        }

        public BColectieListaPreturiClienti Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieListaPreturiClienti SubLista = new BColectieListaPreturiClienti();
            foreach (BListaPreturiClienti Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BListaPreturiClienti ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BListaPreturiClienti Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BListaPreturiClienti pObiect) { return pObiect.EsteActiv == false; }) != null;
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
            return CUtil.getListaCaText<BListaPreturiClienti>(this, "; ");
        }

    }
}
