using CCL.iStomaLab;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL.iStomaLab.Comune
{
    public sealed class BColectieDocumenteInline : List<BDocumenteInline>, IDisposable
    {

        #region Constructori

        public BColectieDocumenteInline()
        {
        }

        public BColectieDocumenteInline(BDocumenteInline pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieDocumenteInline(List<BDocumenteInline> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieDocumenteInline(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BDocumenteInline);
                }
            }
        }

        public void Adauga(BDocumenteInline pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BDocumenteInline GetById(int pId)
        {
            return this.Find(delegate (BDocumenteInline pObiect) { return pObiect.Id == pId; });
        }

        public BColectieDocumenteInline Intersectie(BColectieDocumenteInline pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieDocumenteInline, BDocumenteInline>(this, pListaDeIntersectat);
        }

        public BColectieDocumenteInline Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieDocumenteInline SubLista = new BColectieDocumenteInline();
            foreach (BDocumenteInline Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BDocumenteInline ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void StergeListaDinBaza()
        {
            IDbTransaction xTransact = null;
            try
            {
                xTransact = CCL.DAL.CCerereSQL.GetTransactionOnConnection();
                foreach (BDocumenteInline ObiectDeSters in this)
                {
                    ObiectDeSters.Delete(xTransact);
                }
                CCL.DAL.CCerereSQL.CloseTransactionOnConnection(xTransact, true);
            }
            catch (Exception exc)
            {
                if (xTransact != null) CCL.DAL.CCerereSQL.CloseTransactionOnConnection(xTransact, false);
                throw exc;
            }
        }
        public void Dispose()
        {
            foreach (BDocumenteInline Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BDocumenteInline pObiect) { return pObiect.EsteActiv == false; }) != null;
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
            return CUtil.getListaCaText<BDocumenteInline>(this, "; ");
        }

        public Dictionary<int, BDocumenteInline> GrupeazaPeMedici()
        {
            Dictionary<int, BDocumenteInline> dictRetur = new Dictionary<int, BDocumenteInline>();

            foreach (var item in this)
            {
                if (!dictRetur.ContainsKey(item.IdObiect))
                    dictRetur.Add(item.IdObiect, item);
            }

            return dictRetur;
        }
    }
}
