using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CCL.iStomaLab;
using CDL.iStomaLab;

namespace BLL.iStomaLab.Referinta
{
    public sealed class BColectieRegiuni : List<BRegiuni>, IDisposable
    {

        #region Constructori

        public BColectieRegiuni()
        {
        }

        public BColectieRegiuni(BRegiuni pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieRegiuni(List<BRegiuni> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieRegiuni(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BRegiuni);
                }
            }
        }

        public void Adauga(BRegiuni pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BRegiuni GetById(int pId)
        {
            return this.Find(delegate (BRegiuni pObiect) { return pObiect.Id == pId; });
        }

        public BColectieRegiuni Intersectie(BColectieRegiuni pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieRegiuni, BRegiuni>(this, pListaDeIntersectat);
        }

        public BColectieRegiuni Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieRegiuni SubLista = new BColectieRegiuni();
            foreach (BRegiuni Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BRegiuni ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BRegiuni Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BRegiuni pObiect) { return pObiect.EsteActiv == false; }) != null;
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
            return CUtil.getListaCaText<BRegiuni>(this, "; ");
        }

        public bool ContineElementeDeactivate()
        {
            return this.Find(delegate (BRegiuni pObiect) { return !pObiect.EsteActiv; }) != null;
        }

        public BColectieRegiuni GetListaActive()
        {
            BColectieRegiuni listaRetur = new BColectieRegiuni();

            foreach (var item in this)
            {
                if (item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public BColectieRegiuni GetListaInactive()
        {
            BColectieRegiuni listaRetur = new BColectieRegiuni();

            foreach (var item in this)
            {
                if (!item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

    }
}
