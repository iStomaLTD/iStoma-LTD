using CCL.iStomaLab;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static BLL.iStomaLab.Comune.BComportamentAplicatie;

namespace BLL.iStomaLab.Comune
{
    public sealed class BColectieComportamentAplicatie : List<BComportamentAplicatie>, IDisposable
    {
        #region Constructori

        public BColectieComportamentAplicatie()
        {
        }

        public BColectieComportamentAplicatie(BComportamentAplicatie pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieComportamentAplicatie(List<BComportamentAplicatie> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieComportamentAplicatie(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BComportamentAplicatie);
                }
            }
        }

        public void Adauga(BComportamentAplicatie pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BComportamentAplicatie GetById(EnumComportamentAplicatie pId)
        {
            return this.Find(delegate (BComportamentAplicatie pObiect) { return pObiect.Id == pId; });
        }

        public BColectieComportamentAplicatie Intersectie(BColectieComportamentAplicatie pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieComportamentAplicatie, BComportamentAplicatie>(this, pListaDeIntersectat);
        }

        public BColectieComportamentAplicatie Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieComportamentAplicatie SubLista = new BColectieComportamentAplicatie();
            foreach (BComportamentAplicatie Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(EnumComportamentAplicatie pId)
        {
            BComportamentAplicatie ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BComportamentAplicatie Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BComportamentAplicatie pObiect) { return pObiect.EsteActiv == false; }) != null;
        }

        public override string ToString()
        {
            return CUtil.getListaCaText<BComportamentAplicatie>(this, "; ");
        }

        public BComportamentAplicatie GetAdresaDeAfisatDinOficiu()
        {
            if (this.Count > 0)
                return this[0];

            return null;
        }
    }
}
