using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CCL.iStomaLab;
using CDL.iStomaLab;
using BLL.iStomaLab.Locatii;

namespace BLL.iStomaLab.Clienti
{
    public sealed class BColectieLocatii : List<BLocatii>, IDisposable
    {

        #region Constructori

        public BColectieLocatii()
        {
        }

        public BColectieLocatii(BLocatii pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieLocatii(List<BLocatii> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieLocatii(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BLocatii);
                }
            }
        }

        public void Adauga(BLocatii pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BLocatii GetById(int pId)
        {
            return this.Find(delegate (BLocatii pObiect) { return pObiect.Id == pId; });
        }

        public BColectieLocatii Intersectie(BColectieLocatii pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieLocatii, BLocatii>(this, pListaDeIntersectat);
        }

        public BColectieLocatii Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieLocatii SubLista = new BColectieLocatii();
            foreach (BLocatii Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BLocatii ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BLocatii Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BLocatii pObiect) { return pObiect.EsteActiv == false; }) != null;
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
            return CUtil.getListaCaText<BLocatii>(this, "; ");
        }

        public bool ContineElementeDeactivate()
        {
            return this.Find(delegate (BLocatii pObiect) { return !pObiect.EsteActiv; }) != null;
        }

        public BColectieLocatii GetListaActive()
        {
            BColectieLocatii listaRetur = new BColectieLocatii();

            foreach (var item in this)
            {
                if (item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public BColectieLocatii GetListaInactive()
        {
            BColectieLocatii listaRetur = new BColectieLocatii();

            foreach (var item in this)
            {
                if (!item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

    }
}
