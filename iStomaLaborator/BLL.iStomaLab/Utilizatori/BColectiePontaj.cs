using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CDL.iStomaLab;
using CCL.iStomaLab;

namespace BLL.iStomaLab.Utilizatori
{
    
    public sealed class BColectiePontaj : List<BPontaj>, IDisposable
    {


        #region Constructori

        public BColectiePontaj()
        {
        }

        public BColectiePontaj(BPontaj pElement)
        {
            this.Adauga(pElement);
        }

        public BColectiePontaj(List<BPontaj> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectiePontaj(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BPontaj);
                }
            }
        }

        public void Adauga(BPontaj pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BPontaj GetById(int pId)
        {
            return this.Find(delegate (BPontaj pObiect) { return pObiect.Id == pId; });
        }

        public BColectiePontaj Intersectie(BColectiePontaj pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectiePontaj, BPontaj>(this, pListaDeIntersectat);
        }

        public BColectiePontaj Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectiePontaj SubLista = new BColectiePontaj();
            foreach (BPontaj Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BPontaj ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BPontaj Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BPontaj pObiect) { return pObiect.EsteActiv == false; }) != null;
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
            return CUtil.getListaCaText<BPontaj>(this, "; ");
        }

    }
}
