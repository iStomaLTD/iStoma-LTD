using CCL.iStomaLab;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.iStomaLab.Utilizatori
{
    public sealed class BColectieUtilizatorLucrariEtape : List<BUtilizatorLucrariEtape>, IDisposable
    {

        #region Constructori

        public BColectieUtilizatorLucrariEtape()
        {
        }

        public BColectieUtilizatorLucrariEtape(BUtilizatorLucrariEtape pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieUtilizatorLucrariEtape(List<BUtilizatorLucrariEtape> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieUtilizatorLucrariEtape(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BUtilizatorLucrariEtape);
                }
            }
        }

        public void Adauga(BUtilizatorLucrariEtape pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BUtilizatorLucrariEtape GetById(int pId)
        {
            return this.Find(delegate (BUtilizatorLucrariEtape pObiect) { return pObiect.Id == pId; });
        }

        public BColectieUtilizatorLucrariEtape Intersectie(BColectieUtilizatorLucrariEtape pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieUtilizatorLucrariEtape, BUtilizatorLucrariEtape>(this, pListaDeIntersectat);
        }

        public BColectieUtilizatorLucrariEtape Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieUtilizatorLucrariEtape SubLista = new BColectieUtilizatorLucrariEtape();
            foreach (BUtilizatorLucrariEtape Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BUtilizatorLucrariEtape ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BUtilizatorLucrariEtape Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BUtilizatorLucrariEtape pObiect) { return pObiect.EsteActiv == false; }) != null;
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
            return CUtil.getListaCaText<BUtilizatorLucrariEtape>(this, "; ");
        }

    }
}
