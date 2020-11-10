using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CCL.iStomaLab;
using CDL.iStomaLab;

namespace BLL.iStomaLab.Preturi
{
    public sealed class BColectieListaPreturiStandard : List<BListaPreturiStandard>, IDisposable
    {

        #region Constructori

        public BColectieListaPreturiStandard()
        {
        }

        public BColectieListaPreturiStandard(BListaPreturiStandard pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieListaPreturiStandard(List<BListaPreturiStandard> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieListaPreturiStandard(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BListaPreturiStandard);
                }
            }
        }

        public void Adauga(BListaPreturiStandard pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BListaPreturiStandard GetById(int pId)
        {
            return this.Find(delegate (BListaPreturiStandard pObiect) { return pObiect.Id == pId; });
        }

        public BColectieListaPreturiStandard Intersectie(BColectieListaPreturiStandard pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieListaPreturiStandard, BListaPreturiStandard>(this, pListaDeIntersectat);
        }

        public BColectieListaPreturiStandard Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieListaPreturiStandard SubLista = new BColectieListaPreturiStandard();
            foreach (BListaPreturiStandard Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BListaPreturiStandard ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BListaPreturiStandard Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BListaPreturiStandard pObiect) { return pObiect.EsteActiv == false; }) != null;
        }

        public List<string> GetDenumireLucrari()
        {
            List<string> listaRetur = new List<string>();

            foreach (var item in this)
            {
                if (item.EsteActiv)
                    listaRetur.Add(item.Denumire);
            }

            return listaRetur;
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
            return CUtil.getListaCaText<BListaPreturiStandard>(this, "; ");
        }

        public bool ContineElementeDeactivate()
        {
            return this.Find(delegate (BListaPreturiStandard pObiect) { return !pObiect.EsteActiv; }) != null;
        }

        public BColectieListaPreturiStandard GetListaActive()
        {
            BColectieListaPreturiStandard listaRetur = new BColectieListaPreturiStandard();

            foreach (var item in this)
            {
                if (item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public BColectieListaPreturiStandard GetListaInactive()
        {
            BColectieListaPreturiStandard listaRetur = new BColectieListaPreturiStandard();

            foreach (var item in this)
            {
                if (!item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public BColectieListaPreturiStandard GetListaPreturiIdCategorie(int idCategorie)
        {
            BColectieListaPreturiStandard listaRetur = new BColectieListaPreturiStandard();

            foreach (var item in this)
            {
                if (item.IdCategorie == idCategorie)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public Dictionary<int, string> GetAsDictIdDenumire()
        {
            Dictionary<int, string> dictRetur = new Dictionary<int, string>();

            int idTemp = 0;
            foreach (var item in this)
            {
                idTemp = item.Id;

                if (!dictRetur.ContainsKey(idTemp))
                    dictRetur.Add(idTemp, item.Denumire);
            }

            return dictRetur;
        }
    }
}
