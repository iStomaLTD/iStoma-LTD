using CCL.iStomaLab;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.iStomaLab.Clienti
{
    public sealed class BColectieClientiComenziEtape : List<BClientiComenziEtape>, IDisposable
    {

        #region Constructori

        public BColectieClientiComenziEtape()
        {
        }

        public BColectieClientiComenziEtape(int pIdClient)
        {

        }

        public BColectieClientiComenziEtape(BClientiComenziEtape pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieClientiComenziEtape(List<BClientiComenziEtape> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieClientiComenziEtape(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BClientiComenziEtape);
                }
            }
        }

        public void Adauga(BClientiComenziEtape pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BClientiComenziEtape GetById(int pId)
        {
            return this.Find(delegate (BClientiComenziEtape pObiect) { return pObiect.Id == pId; });
        }

        public BColectieClientiComenziEtape Intersectie(BColectieClientiComenziEtape pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieClientiComenziEtape, BClientiComenziEtape>(this, pListaDeIntersectat);
        }

        public BColectieClientiComenziEtape Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieClientiComenziEtape SubLista = new BColectieClientiComenziEtape();
            foreach (BClientiComenziEtape Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BClientiComenziEtape ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BClientiComenziEtape Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BClientiComenziEtape pObiect) { return pObiect.EsteActiv == false; }) != null;
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
            return CUtil.getListaCaText<BClientiComenziEtape>(this, "; ");
        }

        public BClientiComenziEtape GetEtapaAnterioara(BClientiComenziEtape pEtapa)
        {
            BClientiComenziEtape etapaRetur = null;

            foreach (var item in this)
            {
                if (item.EsteActiv && item.Id < pEtapa.Id)
                {
                    if (etapaRetur == null || etapaRetur.Id < item.Id)
                        etapaRetur = item;
                }
            }

            return etapaRetur;
        }

        public bool ContineElementeDeactivate()
        {
            return this.Find(delegate (BClientiComenziEtape pObiect) { return !pObiect.EsteActiv; }) != null;
        }

        public BColectieClientiComenziEtape GetListaActive()
        {
            BColectieClientiComenziEtape listaRetur = new BColectieClientiComenziEtape();

            foreach (var item in this)
            {
                if (item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public BColectieClientiComenziEtape GetListaInactive()
        {
            BColectieClientiComenziEtape listaRetur = new BColectieClientiComenziEtape();

            foreach (var item in this)
            {
                if (!item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }
    }
}
