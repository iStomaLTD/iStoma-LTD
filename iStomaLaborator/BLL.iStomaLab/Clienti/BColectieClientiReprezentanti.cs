using CCL.iStomaLab;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.iStomaLab.Reprezentanti
{
    public sealed class BColectieReprezentant: List<BClientiReprezentanti>, IDisposable
    {

        #region Constructori

        public BColectieReprezentant()
        {
        }

        public BColectieReprezentant(int pIdClient)
        {

        }

        public BColectieReprezentant(BClientiReprezentanti pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieReprezentant(List<BClientiReprezentanti> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieReprezentant(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BClientiReprezentanti);
                }
            }
        }

        public void Adauga(BClientiReprezentanti pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BClientiReprezentanti GetById(int pId)
        {
            return this.Find(delegate (BClientiReprezentanti pObiect) { return pObiect.Id == pId; });
        }

        public BColectieReprezentant Intersectie(BColectieReprezentant pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieReprezentant, BClientiReprezentanti>(this, pListaDeIntersectat);
        }

        public BColectieReprezentant Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieReprezentant SubLista = new BColectieReprezentant();
            foreach (BClientiReprezentanti Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BClientiReprezentanti ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BClientiReprezentanti Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BClientiReprezentanti pObiect) { return pObiect.EsteActiv == false; }) != null;
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
            return CUtil.getListaCaText<BClientiReprezentanti>(this, "; ");
        }

        public bool ContineElementeDeactivate()
        {
            return this.Find(delegate (BClientiReprezentanti pObiect) { return !pObiect.EsteActiv; }) != null;
        }

        public BColectieReprezentant GetListaActive()
        {
            BColectieReprezentant listaRetur = new BColectieReprezentant();

            foreach (var item in this)
            {
                if (item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public BColectieReprezentant GetListaInactive()
        {
            BColectieReprezentant listaRetur = new BColectieReprezentant();

            foreach (var item in this)
            {
                if (!item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }
    }
}
