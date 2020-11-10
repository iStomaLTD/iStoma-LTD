using CCL.iStomaLab;
using CDL.iStomaLab;
using DAL.iStomaLab.Preturi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.iStomaLab.Preturi
{
    public sealed class BColectieEtape : List<BEtape>, IDisposable
    {

        #region Constructori

        public BColectieEtape()
        {
        }

        public BColectieEtape(BEtape pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieEtape(List<BEtape> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieEtape(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BEtape);
                }
            }
        }

        public void Adauga(BEtape pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BEtape GetById(int pId)
        {
            return this.Find(delegate (BEtape pObiect) { return pObiect.Id == pId; });
        }

        public BColectieEtape Intersectie(BColectieEtape pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieEtape, BEtape>(this, pListaDeIntersectat);
        }

        public BColectieEtape Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieEtape SubLista = new BColectieEtape();
            foreach (BEtape Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BEtape ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BEtape Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BEtape pObiect) { return pObiect.EsteActiv == false; }) != null;
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
            return CUtil.getListaCaText<BEtape>(this, "; ");
        }

        public bool ContineElementeDeactivate()
        {
            return this.Find(delegate (BEtape pObiect) { return !pObiect.EsteActiv; }) != null;
        }

        public BColectieEtape GetListaActive()
        {
            BColectieEtape listaRetur = new BColectieEtape();

            foreach (var item in this)
            {
                if (item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public BColectieEtape GetListaInactive()
        {
            BColectieEtape listaRetur = new BColectieEtape();

            foreach (var item in this)
            {
                if (!item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public Dictionary<int, string> GetAsDictIdDenumire()
        {
            Dictionary<int, string> dictRetur = new Dictionary<int, string>();

            int idTemp = 0;
            foreach (var item in this)
            {
                idTemp = item.Id;

                if (!dictRetur.ContainsKey(idTemp))
                    dictRetur.Add(idTemp, item.Denumire);
            }

            return dictRetur;
        }
    }
}
