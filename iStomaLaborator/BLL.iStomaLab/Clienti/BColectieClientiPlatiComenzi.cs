using CCL.iStomaLab;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.iStomaLab.Clienti
{
    public sealed class BColectieClientiPlatiComenzi : List<BClientiPlatiComenzi>, IDisposable
    {
        #region Constructori

        public BColectieClientiPlatiComenzi()
        {
        }

        public BColectieClientiPlatiComenzi(int pIdClient)
        {

        }

        public BColectieClientiPlatiComenzi(BClientiPlatiComenzi pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieClientiPlatiComenzi(List<BClientiPlatiComenzi> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieClientiPlatiComenzi(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BClientiPlatiComenzi);
                }
            }
        }

        public void Adauga(BClientiPlatiComenzi pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BClientiPlatiComenzi GetById(int pId)
        {
            return this.Find(delegate (BClientiPlatiComenzi pObiect) { return pObiect.Id == pId; });
        }

        public BColectieClientiPlatiComenzi GetByIdComanda(int pId)
        {
            BColectieClientiPlatiComenzi listaRetur = new BColectieClientiPlatiComenzi();

            foreach (var item in this)
            {
                if (item.IdClientComanda == pId)
                {
                    listaRetur.Adauga(item);
                }
            }

            return listaRetur;
        }

        public BColectieClientiPlatiComenzi Intersectie(BColectieClientiPlatiComenzi pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieClientiPlatiComenzi, BClientiPlatiComenzi>(this, pListaDeIntersectat);
        }

        public BColectieClientiPlatiComenzi Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieClientiPlatiComenzi SubLista = new BColectieClientiPlatiComenzi();
            foreach (BClientiPlatiComenzi Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BClientiPlatiComenzi ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BClientiPlatiComenzi Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BClientiPlatiComenzi pObiect) { return pObiect.EsteActiv == false; }) != null;
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

        public List<int> GetListaIdComenzi()
        {
            List<int> lstRetur = new List<int>();
            foreach (var item in this)
            {
                if (!lstRetur.Contains(item.IdClientComanda))
                    lstRetur.Add(item.IdClientComanda);
            }
            return lstRetur;
        }

        public List<int> GetListaIdPlati()
        {
            List<int> lstRetur = new List<int>();
            foreach (var item in this)
            {
                if (!lstRetur.Contains(item.IdClientPlata))
                    lstRetur.Add(item.IdClientPlata);
            }
            return lstRetur;
        }

        public override string ToString()
        {
            return CUtil.getListaCaText<BClientiPlatiComenzi>(this, "; ");
        }

        public bool ContineElementeDeactivate()
        {
            return this.Find(delegate (BClientiPlatiComenzi pObiect) { return !pObiect.EsteActiv; }) != null;
        }

        public BColectieClientiPlatiComenzi GetListaActive()
        {
            BColectieClientiPlatiComenzi listaRetur = new BColectieClientiPlatiComenzi();

            foreach (var item in this)
            {
                if (item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public BColectieClientiPlatiComenzi GetListaInactive()
        {
            BColectieClientiPlatiComenzi listaRetur = new BColectieClientiPlatiComenzi();

            foreach (var item in this)
            {
                if (!item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public BColectieClientiPlatiComenzi GetByIdComenzi(List<int> pListaIdComenzi)
        {
            BColectieClientiPlatiComenzi listaRetur = new BColectieClientiPlatiComenzi();

            foreach (var item in this)
            {
                if (pListaIdComenzi.Contains(item.IdClientComanda))
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public double GetValoarePlatita()
        {
            double valoare = 0;
            foreach (var item in this)
            {
                valoare += item.Valoare;
            }
            return valoare;
        }
    }
}
