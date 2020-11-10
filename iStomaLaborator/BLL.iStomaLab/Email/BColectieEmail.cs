using CCL.iStomaLab;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.iStomaLab.Email
{
    public sealed class BColectieEmail : List<BEmail>, IDisposable
    {

        #region Constructori

        public BColectieEmail()
        {
        }

        public BColectieEmail(BEmail pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieEmail(List<BEmail> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieEmail(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BEmail);
                }
            }
        }

        public void Adauga(BEmail pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BEmail GetById(int pId)
        {
            return this.Find(delegate (BEmail pObiect) { return pObiect.Id == pId; });
        }

        public BColectieEmail Intersectie(BColectieEmail pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieEmail, BEmail>(this, pListaDeIntersectat);
        }

        public BColectieEmail Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieEmail SubLista = new BColectieEmail();
            foreach (BEmail Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BEmail ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BEmail Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BEmail pObiect) { return pObiect.EsteActiv == false; }) != null;
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
            return CUtil.getListaCaText<BEmail>(this, "; ");
        }

    }
}
