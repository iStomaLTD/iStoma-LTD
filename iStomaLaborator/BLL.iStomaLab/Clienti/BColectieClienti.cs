using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CCL.iStomaLab;
using CDL.iStomaLab;

namespace BLL.iStomaLab.Clienti
{
    public sealed class BColectieClienti : List<BClienti>, IDisposable
    {

        #region Constructori

        public BColectieClienti()
        {
        }

        public BColectieClienti(BClienti pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieClienti(List<BClienti> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieClienti(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BClienti);
                }
            }
        }

        public void Adauga(BClienti pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BClienti GetById(int pId)
        {
            return this.Find(delegate (BClienti pObiect) { return pObiect.Id == pId; });
        }

        public BClienti GetPrimaByDenumire(string pDenumireCabinet)
        {
            pDenumireCabinet = pDenumireCabinet.Trim();
            return this.Find(delegate (BClienti pObiect) { return pObiect.Denumire.ToLower().Equals(pDenumireCabinet); });
        }

        public BColectieClienti Intersectie(BColectieClienti pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieClienti, BClienti>(this, pListaDeIntersectat);
        }

        public BColectieClienti Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieClienti SubLista = new BColectieClienti();
            foreach (BClienti Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BClienti ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BClienti Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BClienti pObiect) { return pObiect.EsteActiv == false; }) != null;
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
            return CUtil.getListaCaText<BClienti>(this, "; ");
        }

        public List<String> GetDenumireClienti()
        {
            List<String> listaRetur = new List<String>();

            foreach (var item in this)
            {
                if (item.EsteActiv)
                    listaRetur.Add(item.Denumire);
            }

            return listaRetur;
        }

        public bool ContineElementeDeactivate()
        {
            return this.Find(delegate (BClienti pObiect) { return !pObiect.EsteActiv; }) != null;
        }

        public BColectieClienti GetListaActive()
        {
            BColectieClienti listaRetur = new BColectieClienti();

            foreach (var item in this)
            {
                if (item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public BColectieClienti GetListaInactive()
        {
            BColectieClienti listaRetur = new BColectieClienti();

            foreach (var item in this)
            {
                if (!item.EsteActiv)
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
