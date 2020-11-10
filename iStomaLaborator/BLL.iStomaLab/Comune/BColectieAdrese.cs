using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CCL.iStomaLab;
using CDL.iStomaLab;

namespace BLL.iStomaLab.Comune
{
    public sealed class BColectieAdrese : List<BAdrese>, IDisposable
    {

        #region Constructori

        public BColectieAdrese()
        {
        }

        public BColectieAdrese(BAdrese pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieAdrese(List<BAdrese> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieAdrese(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BAdrese);
                }
            }
        }

        public void Adauga(BAdrese pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BAdrese GetById(int pId)
        {
            return this.Find(delegate (BAdrese pObiect) { return pObiect.Id == pId; });
        }

        public BColectieAdrese Intersectie(BColectieAdrese pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieAdrese, BAdrese>(this, pListaDeIntersectat);
        }

        public BColectieAdrese Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieAdrese SubLista = new BColectieAdrese();
            foreach (BAdrese Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BAdrese ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BAdrese Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BAdrese pObiect) { return pObiect.EsteActiv == false; }) != null;
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
            return CUtil.getListaCaText<BAdrese>(this, "; ");
        }

        public BAdrese GetAdresaDeAfisatDinOficiu()
        {
            if (this.Count > 0)
                return this[0];

            return null;
        }
    }
}
