using CCL.iStomaLab;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.iStomaLab.Clienti
{
    public sealed class BColectieClientiComenzi : List<BClientiComenzi>, IDisposable
    {

        #region Constructori

        public BColectieClientiComenzi()
        {
        }

        public BColectieClientiComenzi(int pIdClient)
        {

        }

        public BColectieClientiComenzi(BClientiComenzi pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieClientiComenzi(List<BClientiComenzi> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieClientiComenzi(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BClientiComenzi);
                }
            }
        }

        public void Adauga(BClientiComenzi pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BClientiComenzi GetById(int pId)
        {
            return this.Find(delegate (BClientiComenzi pObiect) { return pObiect.Id == pId; });
        }

        public BColectieClientiComenzi Intersectie(BColectieClientiComenzi pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieClientiComenzi, BClientiComenzi>(this, pListaDeIntersectat);
        }

        public BColectieClientiComenzi Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieClientiComenzi SubLista = new BColectieClientiComenzi();
            foreach (BClientiComenzi Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BClientiComenzi ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BClientiComenzi Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BClientiComenzi pObiect) { return pObiect.EsteActiv == false; }) != null;
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

        public List<int> GetListaIdFacturi()
        {
            List<int> lstRetur = new List<int>();
            foreach (var item in this)
            {
                if (!lstRetur.Contains(item.IdFactura))
                    lstRetur.Add(item.IdFactura);
            }
            return lstRetur;
        }

        public override string ToString()
        {
            return CUtil.getListaCaText<BClientiComenzi>(this, "; ");
        }

        public bool ContineElementeDeactivate()
        {
            return this.Find(delegate (BClientiComenzi pObiect) { return !pObiect.EsteActiv; }) != null;
        }

        public BColectieClientiComenzi GetListaActive()
        {
            BColectieClientiComenzi listaRetur = new BColectieClientiComenzi();

            foreach (var item in this)
            {
                if (item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public BColectieClientiComenzi GetListaInactive()
        {
            BColectieClientiComenzi listaRetur = new BColectieClientiComenzi();

            foreach (var item in this)
            {
                if (!item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public void TreciLaEtapa(int pIdEtapaParam, int pIdTehnician, DateTime pDataTermen, bool pRefacere, int pStatus, IDbTransaction pTranzactie)
        {
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCL.DAL.CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;

                foreach (var lucrare in this)
                {
                    lucrare.UpdateAll(pIdEtapaParam, pIdTehnician, pDataTermen, lucrare.ObservatiiEtapa, pRefacere, pStatus, Tranzactie);
                }

                if (pTranzactie == null)
                {
                    //Facem Comit tranzactiei doar daca aceasta nu a fost transmisa in parametru. Altfel comitul va fi gestionat de functia apelanta
                    CCL.DAL.CCerereSQL.CloseTransactionOnConnection(Tranzactie, true);
                }
            }
            catch (Exception)
            {
                if ((pTranzactie == null) && (Tranzactie != null)) CCL.DAL.CCerereSQL.CloseTransactionOnConnection(Tranzactie, false);
                throw;
            }
        }

        public BColectieClientiComenzi Exclude(BColectieClientiComenzi pListaComenziDeExclus)
        {
            if (CUtil.EsteListaVida<BClientiComenzi>(pListaComenziDeExclus))
                return this;

            BColectieClientiComenzi listaRetur = new BColectieClientiComenzi();
            foreach (var item in this)
            {
                if (pListaComenziDeExclus.GetById(item.Id) == null)
                    listaRetur.Adauga(item);
            }

            return listaRetur;
        }

        public double GetTotal(CDefinitiiComune.EnumTipMoneda pMoneda, double pCursSchimb)
        {
            double total = 0;

            foreach (var item in this)
            {
                total += item.GetValoareMoneda(pMoneda, pCursSchimb);
            }

            return total;
        }

        public int GetIdClientDinLista()
        {
            int id = 0;

            foreach (var item in this)
            {
                if (id == 0)
                    id = item.IdClient;
                else if (id != item.IdClient)
                    return 0;
            }

            return id;
        }

        public void UpdateIdFactura(int pIdFactura, IDbTransaction pTranzactie)
        {
            BClientiComenzi.UpdateIdFacturaForListaId(pIdFactura, GetListaId(), pTranzactie);
        }

        public List<int> GetIdFacturaDistincteDinLista()
        {
            List<int> lstIduri = new List<int>();
            foreach (var item in this)
            {
                if (!lstIduri.Contains(item.IdFactura))
                    lstIduri.Add(item.IdFactura);
            }

            return lstIduri;
        }

        public BColectieClientiComenzi GetByIdFactura(int id)
        {
            BColectieClientiComenzi listaRetur = new BColectieClientiComenzi();

            foreach (var item in this)
            {
                if (item.IdFactura == id)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public double GetValoareTotalaFactura(CDefinitiiComune.EnumTipMoneda pMoneda, double pCursBNR)
        {
            double total = 0;

            foreach (var item in this)
            {
                total += CUtil.GetValoareMoneda(item.ValoareFinala, item.Moneda, pCursBNR, pMoneda);
            }

            return total;
        }

        public BClientiComenzi GetUltimaByIdClient(int pIdClient)
        {
            BClientiComenzi comandaRetur = null;

            foreach (var item in this)
            {
                if (item.IdClient == pIdClient)
                {
                    if (comandaRetur == null || comandaRetur.DataPrimire < item.DataPrimire)
                        comandaRetur = item;
                }
            }

            return comandaRetur;
        }

        public void ScoateDinFactura(IDbTransaction pTranzactie)
        {
            foreach (var item in this)
            {
                item.ScoateDinFactura(pTranzactie);
            }
        }

        public BColectieClientiComenzi GetByIdMedic(int pIdMedic)
        {
            BColectieClientiComenzi listaRetur = new BColectieClientiComenzi();

            foreach (var item in this)
            {
                if (item.IdReprezentantClient == pIdMedic)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public BColectieClientiComenzi GetByIdCabinet(int pIdCabinet)
        {
            BColectieClientiComenzi listaRetur = new BColectieClientiComenzi();

            foreach (var item in this)
            {
                if (item.IdCabinet == pIdCabinet)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public BColectieClientiComenzi GetCeleNeachitateIntegral(BColectieClientiPlatiComenzi pListaPlatiComenzi)
        {
            BColectieClientiComenzi listaRetur = new BColectieClientiComenzi();
            BColectieClientiPlatiComenzi listaPlatiTemp = new BColectieClientiPlatiComenzi();
            double totalAchitat = 0;

            foreach (var item in this)
            {
                listaPlatiTemp = pListaPlatiComenzi.GetByIdComanda(item.Id);
                if (!CUtil.EsteListaVida<BClientiPlatiComenzi>(listaPlatiTemp))
                {
                    totalAchitat = listaPlatiTemp.GetValoarePlatita();

                    if (item.ValoareFinala != totalAchitat)
                    {
                        listaRetur.Adauga(item);
                    }
                }
                else
                {
                    listaRetur.Adauga(item);
                }
            }

            return listaRetur;
        }
        public BColectieClientiComenzi GetByListaIdFacturi(List<int> pListaIdFacturi)
        {
            BColectieClientiComenzi listaRetur = new BColectieClientiComenzi();

            foreach (var item in this)
            {
                if (pListaIdFacturi.Contains(item.IdFactura))
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

    }
}
