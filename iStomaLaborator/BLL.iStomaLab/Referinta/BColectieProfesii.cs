using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CCL.iStomaLab;
using CDL.iStomaLab;

namespace BLL.iStomaLab.Referinta
{
    public sealed class BColectieProfesii : List<BProfesii>, IDisposable
    {

        #region Constructori

        public BColectieProfesii()
        {
        }

        public BColectieProfesii(BProfesii pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieProfesii(List<BProfesii> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieProfesii(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BProfesii);
                }
            }
        }

        public void Adauga(BProfesii pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BProfesii GetById(int pId)
        {
            return this.Find(delegate (BProfesii pObiect) { return pObiect.Id == pId; });
        }

        public BColectieProfesii Intersectie(BColectieProfesii pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieProfesii, BProfesii>(this, pListaDeIntersectat);
        }

        public BColectieProfesii Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieProfesii SubLista = new BColectieProfesii();
            foreach (BProfesii Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BProfesii ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BProfesii Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BProfesii pObiect) { return pObiect.EsteActiv == false; }) != null;
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
            return CUtil.getListaCaText<BProfesii>(this, "; ");
        }

        public bool ContineElementeDeactivate()
        {
            return this.Find(delegate (BProfesii pObiect) { return !pObiect.EsteActiv; }) != null;
        }

        public BColectieProfesii GetListaActive()
        {
            BColectieProfesii listaRetur = new BColectieProfesii();

            foreach (var item in this)
            {
                if (item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public BColectieProfesii GetListaInactive()
        {
            BColectieProfesii listaRetur = new BColectieProfesii();

            foreach (var item in this)
            {
                if (!item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

    }
}
