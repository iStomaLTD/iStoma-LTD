using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CCL.iStomaLab;
using CDL.iStomaLab;

namespace BLL.iStomaLab.Referinta
{
    public sealed class BColectieTari : List<BTari>, IDisposable
    {

        #region Constructori

        public BColectieTari()
        {
        }

        public BColectieTari(BTari pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieTari(List<BTari> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieTari(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BTari);
                }
            }
        }

        public void Adauga(BTari pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BTari GetById(int pId)
        {
            return this.Find(delegate (BTari pObiect) { return pObiect.Id == pId; });
        }

        public BColectieTari Intersectie(BColectieTari pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieTari, BTari>(this, pListaDeIntersectat);
        }

        public BColectieTari Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieTari SubLista = new BColectieTari();
            foreach (BTari Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BTari ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BTari Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BTari pObiect) { return pObiect.EsteActiv == false; }) != null;
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
            return CUtil.getListaCaText<BTari>(this, "; ");
        }

    }
}
