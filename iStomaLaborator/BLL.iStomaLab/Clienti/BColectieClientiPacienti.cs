using BLL.iStomaLab.Clienti;
using CCL.iStomaLab;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.iStomaLab.Clienti
{
    public sealed class BColectiePacienti: List<BClientiPacienti>, IDisposable
    {

        #region Constructori

        public BColectiePacienti()
        {
        }

        public BColectiePacienti(int pIdClient)
        {

        }

        public BColectiePacienti(BClientiPacienti pElement)
        {
            this.Adauga(pElement);
        }

        public BColectiePacienti(List<BClientiPacienti> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectiePacienti(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BClientiPacienti);
                }
            }
        }

        public void Adauga(BClientiPacienti pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BClientiPacienti GetById(int pId)
        {
            return this.Find(delegate (BClientiPacienti pObiect) { return pObiect.Id == pId; });
        }

        public BColectiePacienti Intersectie(BColectiePacienti pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectiePacienti, BClientiPacienti>(this, pListaDeIntersectat);
        }

        public BColectiePacienti Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectiePacienti SubLista = new BColectiePacienti();
            foreach (BClientiPacienti Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BClientiPacienti ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BClientiPacienti Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BClientiPacienti pObiect) { return pObiect.EsteActiv == false; }) != null;
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
            return CUtil.getListaCaText<BClientiPacienti>(this, "; ");
        }

        public bool ContineElementeDeactivate()
        {
            return this.Find(delegate (BClientiPacienti pObiect) { return !pObiect.EsteActiv; }) != null;
        }

        public BColectiePacienti GetListaActive()
        {
            BColectiePacienti listaRetur = new BColectiePacienti();

            foreach (var item in this)
            {
                if (item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public BColectiePacienti GetListaInactive()
        {
            BColectiePacienti listaRetur = new BColectiePacienti();

            foreach (var item in this)
            {
                if (!item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }
    }
}
