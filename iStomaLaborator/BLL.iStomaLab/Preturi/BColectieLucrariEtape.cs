using CCL.iStomaLab;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.iStomaLab.Preturi
{
    public sealed class BColectieLucrariEtape : List<BLucrariEtape>, IDisposable
    {
        #region Constructori

        public BColectieLucrariEtape()
        {
        }

        public BColectieLucrariEtape(BLucrariEtape pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieLucrariEtape(List<BLucrariEtape> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieLucrariEtape(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BLucrariEtape);
                }
            }
        }

        public void Adauga(BLucrariEtape pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BLucrariEtape GetById(int pId)
        {
            return this.Find(delegate (BLucrariEtape pObiect) { return pObiect.Id == pId; });
        }

        public BColectieLucrariEtape Intersectie(BColectieLucrariEtape pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieLucrariEtape, BLucrariEtape>(this, pListaDeIntersectat);
        }

        public BColectieLucrariEtape Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieLucrariEtape SubLista = new BColectieLucrariEtape();
            foreach (BLucrariEtape Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BLucrariEtape ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BLucrariEtape Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BLucrariEtape pObiect) { return pObiect.EsteActiv == false; }) != null;
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
            return CUtil.getListaCaText<BLucrariEtape>(this, "; ");
        }

        public List<int> GetListaIdEtape()
        {
            List<int> listaRetur = new List<int>();

            foreach (var item in this)
            {
                if (!listaRetur.Contains(item.IdEtapa))
                    listaRetur.Add(item.IdEtapa);
            }

            return listaRetur;
        }
    }
}
