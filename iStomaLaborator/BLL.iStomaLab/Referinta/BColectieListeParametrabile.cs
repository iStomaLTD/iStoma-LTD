using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CDL.iStomaLab;
using CCL.iStomaLab;

namespace BLL.iStomaLab.Referinta
{
    public sealed class BColectieListeParametrabile : List<BListeParametrabile>, IDisposable
    {

        #region Constructori

        public BColectieListeParametrabile()
        {
        }

        public BColectieListeParametrabile(BListeParametrabile pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieListeParametrabile(List<BListeParametrabile> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieListeParametrabile(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BListeParametrabile);
                }
            }
        }

        public void Adauga(BListeParametrabile pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BListeParametrabile GetById(int pId)
        {
            return this.Find(delegate (BListeParametrabile pObiect) { return pObiect.Id == pId; });
        }

        public BColectieListeParametrabile Intersectie(BColectieListeParametrabile pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieListeParametrabile, BListeParametrabile>(this, pListaDeIntersectat);
        }

        public BColectieListeParametrabile Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieListeParametrabile SubLista = new BColectieListeParametrabile();
            foreach (BListeParametrabile Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BListeParametrabile ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BListeParametrabile Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BListeParametrabile pObiect) { return pObiect.EsteActiv == false; }) != null;
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
            return CUtil.getListaCaText<BListeParametrabile>(this, "; ");
        }

        public bool ContineElementeDeactivate()
        {
            return this.Find(delegate (BListeParametrabile pObiect) { return !pObiect.EsteActiv; }) != null;
        }

        public BColectieListeParametrabile GetListaActive()
        {
            BColectieListeParametrabile listaRetur = new BColectieListeParametrabile();

            foreach (var item in this)
            {
                if (item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public BColectieListeParametrabile GetListaInactive()
        {
            BColectieListeParametrabile listaRetur = new BColectieListeParametrabile();

            foreach (var item in this)
            {
                if (!item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

    }
}
