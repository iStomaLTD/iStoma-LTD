using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CCL.iStomaLab;
using CDL.iStomaLab;

namespace BLL.iStomaLab.Referinta
{
    public sealed class BColectieLocalitati : List<BLocalitati>, IDisposable
    {

        #region Constructori

        public BColectieLocalitati()
        {
        }

        public BColectieLocalitati(BLocalitati pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieLocalitati(List<BLocalitati> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieLocalitati(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BLocalitati);
                }
            }
        }

        public void Adauga(BLocalitati pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BLocalitati GetById(int pId)
        {
            return this.Find(delegate (BLocalitati pObiect) { return pObiect.Id == pId; });
        }

        public BColectieLocalitati Intersectie(BColectieLocalitati pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieLocalitati, BLocalitati>(this, pListaDeIntersectat);
        }

        public BColectieLocalitati Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieLocalitati SubLista = new BColectieLocalitati();
            foreach (BLocalitati Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BLocalitati ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BLocalitati Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BLocalitati pObiect) { return pObiect.EsteActiv == false; }) != null;
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
            return CUtil.getListaCaText<BLocalitati>(this, "; ");
        }

        public bool ContineElementeDeactivate()
        {
            return this.Find(delegate (BLocalitati pObiect) { return !pObiect.EsteActiv; }) != null;
        }

        public BColectieLocalitati GetListaActive()
        {
            BColectieLocalitati listaRetur = new BColectieLocalitati();

            foreach (var item in this)
            {
                if (item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public BColectieLocalitati GetListaInactive()
        {
            BColectieLocalitati listaRetur = new BColectieLocalitati();

            foreach (var item in this)
            {
                if (!item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

    }
}
