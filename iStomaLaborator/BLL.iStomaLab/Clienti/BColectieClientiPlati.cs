using CCL.iStomaLab;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.iStomaLab.Clienti
{
    public sealed class BColectieClientiPlati : List<BClientiPlati>, IDisposable
    {
        #region Constructori

        public BColectieClientiPlati()
        {
        }

        public BColectieClientiPlati(int pIdClient)
        {

        }

        public BColectieClientiPlati(BClientiPlati pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieClientiPlati(List<BClientiPlati> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieClientiPlati(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BClientiPlati);
                }
            }
        }

        public void Adauga(BClientiPlati pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BClientiPlati GetById(int pId)
        {
            return this.Find(delegate (BClientiPlati pObiect) { return pObiect.Id == pId; });
        }

        public BColectieClientiPlati GetByIdPlati(List<int> pListaIdPlati)
        {
            BColectieClientiPlati listaRetur = new BColectieClientiPlati();

            foreach (var item in this)
            {
                if (pListaIdPlati.Contains(item.Id))
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public BColectieClientiPlati Intersectie(BColectieClientiPlati pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieClientiPlati, BClientiPlati>(this, pListaDeIntersectat);
        }

        public BColectieClientiPlati Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieClientiPlati SubLista = new BColectieClientiPlati();
            foreach (BClientiPlati Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BClientiPlati ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BClientiPlati Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BClientiPlati pObiect) { return pObiect.EsteActiv == false; }) != null;
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
            return CUtil.getListaCaText<BClientiPlati>(this, "; ");
        }

        public bool ContineElementeDeactivate()
        {
            return this.Find(delegate (BClientiPlati pObiect) { return !pObiect.EsteActiv; }) != null;
        }

        public BColectieClientiPlati GetListaActive()
        {
            BColectieClientiPlati listaRetur = new BColectieClientiPlati();

            foreach (var item in this)
            {
                if (item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public BColectieClientiPlati GetListaInactive()
        {
            BColectieClientiPlati listaRetur = new BColectieClientiPlati();

            foreach (var item in this)
            {
                if (!item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public double GetSumaPlatita()
        {
            double suma = 0;

            foreach (var item in this)
            {
                suma += item.SumaPlatita;
            }

            return suma;
        }
    }
}
