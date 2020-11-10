using CCL.iStomaLab;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.iStomaLab.Referinta
{
    public sealed class BColectieCategorii : List<BCategorii>, IDisposable
    {

        #region Constructori

        public BColectieCategorii()
        {
        }

        public BColectieCategorii(BCategorii pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieCategorii(List<BCategorii> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieCategorii(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BCategorii);
                }
            }
        }

        public void Adauga(BCategorii pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BCategorii GetById(int pId)
        {
            return this.Find(delegate (BCategorii pObiect) { return pObiect.Id == pId; });
        }

        public BColectieCategorii Intersectie(BColectieCategorii pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieCategorii, BCategorii>(this, pListaDeIntersectat);
        }

        public BColectieCategorii Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieCategorii SubLista = new BColectieCategorii();
            foreach (BCategorii Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BCategorii ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BCategorii Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BCategorii pObiect) { return pObiect.EsteActiv == false; }) != null;
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
            return CUtil.getListaCaText<BCategorii>(this, "; ");
        }
        
    }
}
