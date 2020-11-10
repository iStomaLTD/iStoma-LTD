using CCL.iStomaLab;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.iStomaLab.Clienti
{
    public sealed class BColectieClientiCabinete : List<BClientiCabinete>, IDisposable
    {

        #region Constructori

        public BColectieClientiCabinete()
        {
        }

        public BColectieClientiCabinete(int pIdClient)
        {

        }

        public BColectieClientiCabinete(BClientiCabinete pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieClientiCabinete(List<BClientiCabinete> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieClientiCabinete(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BClientiCabinete);
                }
            }
        }

        public void Adauga(BClientiCabinete pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BClientiCabinete GetById(int pId)
        {
            return this.Find(delegate (BClientiCabinete pObiect) { return pObiect.Id == pId; });
        }

        public BColectieClientiCabinete Intersectie(BColectieClientiCabinete pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieClientiCabinete, BClientiCabinete>(this, pListaDeIntersectat);
        }

        public BColectieClientiCabinete Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieClientiCabinete SubLista = new BColectieClientiCabinete();
            foreach (BClientiCabinete Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BClientiCabinete ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BClientiCabinete Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BClientiCabinete pObiect) { return pObiect.EsteActiv == false; }) != null;
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
            return CUtil.getListaCaText<BClientiCabinete>(this, "; ");
        }

        public List<int> GetListaIdAdrese()
        {
            List<int> listaRetur = new List<int>();

            foreach (var item in this)
            {
                if (!listaRetur.Contains(item.IdAdresa))
                    listaRetur.Add(item.IdAdresa);
            }
            return listaRetur;
        }

        public bool ContineElementeDeactivate()
        {
            return this.Find(delegate (BClientiCabinete pObiect) { return !pObiect.EsteActiv; }) != null;
        }

        public BColectieClientiCabinete GetListaActive()
        {
            BColectieClientiCabinete listaRetur = new BColectieClientiCabinete();

            foreach (var item in this)
            {
                if (item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public BColectieClientiCabinete GetListaInactive()
        {
            BColectieClientiCabinete listaRetur = new BColectieClientiCabinete();

            foreach (var item in this)
            {
                if (!item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }
    }
}
