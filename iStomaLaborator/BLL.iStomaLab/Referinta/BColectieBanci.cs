using CCL.iStomaLab;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.iStomaLab.Referinta
{
    public sealed class BColectieBanci : List<BBanci>, IDisposable
    {
        #region Constructori

        public BColectieBanci()
        {
        }

        public BColectieBanci(BBanci pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieBanci(List<BBanci> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieBanci(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BBanci);
                }
            }
        }

        public void Adauga(BBanci pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BBanci GetById(int pId)
        {
            return this.Find(delegate (BBanci pObiect) { return pObiect.Id == pId; });
        }

        public BColectieBanci Intersectie(BColectieBanci pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieBanci, BBanci>(this, pListaDeIntersectat);
        }

        public BColectieBanci Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieBanci SubLista = new BColectieBanci();
            foreach (BBanci Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BBanci ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BBanci Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BBanci pObiect) { return pObiect.EsteActiv == false; }) != null;
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
            return CUtil.getListaCaText<BBanci>(this, "; ");
        }

        public bool ContineElementeDeactivate()
        {
            return this.Find(delegate (BBanci pObiect) { return !pObiect.EsteActiv; }) != null;
        }

        public BColectieBanci GetListaActive()
        {
            BColectieBanci listaRetur = new Referinta.BColectieBanci();

            foreach (var item in this)
            {
                if (item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public BColectieBanci GetListaInactive()
        {
            BColectieBanci listaRetur = new Referinta.BColectieBanci();

            foreach (var item in this)
            {
                if (!item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }
    }
}
