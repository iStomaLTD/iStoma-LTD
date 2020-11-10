using CCL.iStomaLab;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.iStomaLab.Email
{
    public sealed class BColectieEmailuriExtrase : List<BEmailuriExtrase>, IDisposable
    {

        #region Constructori

        public BColectieEmailuriExtrase()
        {
        }

        public BColectieEmailuriExtrase(BEmailuriExtrase pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieEmailuriExtrase(List<BEmailuriExtrase> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieEmailuriExtrase(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BEmailuriExtrase);
                }
            }
        }

        public void Adauga(BEmailuriExtrase pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BEmailuriExtrase GetById(int pId)
        {
            return this.Find(delegate (BEmailuriExtrase pObiect) { return pObiect.Id == pId; });
        }

        public BColectieEmailuriExtrase Intersectie(BColectieEmailuriExtrase pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieEmailuriExtrase, BEmailuriExtrase>(this, pListaDeIntersectat);
        }

        public BColectieEmailuriExtrase Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieEmailuriExtrase SubLista = new BColectieEmailuriExtrase();
            foreach (BEmailuriExtrase Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BEmailuriExtrase ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BEmailuriExtrase Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BEmailuriExtrase pObiect) { return pObiect.EsteActiv == false; }) != null;
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
            return CUtil.getListaCaText<BEmailuriExtrase>(this, "; ");
        }

    }
}
