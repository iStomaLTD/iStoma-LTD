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
    public sealed class BColectieClientiComenziHeader : List<BClientiComenziHeader>, IDisposable
    {

        #region Constructori

        public BColectieClientiComenziHeader()
        {
        }

        public BColectieClientiComenziHeader(int pIdClient)
        {

        }

        public BColectieClientiComenziHeader(BClientiComenziHeader pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieClientiComenziHeader(List<BClientiComenziHeader> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieClientiComenziHeader(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BClientiComenziHeader);
                }
            }
        }

        public void Adauga(BClientiComenziHeader pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BClientiComenziHeader GetById(int pId)
        {
            return this.Find(delegate (BClientiComenziHeader pObiect) { return pObiect.Id == pId; });
        }

        public BColectieClientiComenziHeader Intersectie(BColectieClientiComenziHeader pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieClientiComenziHeader, BClientiComenziHeader>(this, pListaDeIntersectat);
        }

        public BColectieClientiComenziHeader Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieClientiComenziHeader SubLista = new BColectieClientiComenziHeader();
            foreach (BClientiComenziHeader Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BClientiComenziHeader ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BClientiComenziHeader Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BClientiComenziHeader pObiect) { return pObiect.EsteActiv == false; }) != null;
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
            return CUtil.getListaCaText<BClientiComenziHeader>(this, "; ");
        }

        public bool ContineElementeDeactivate()
        {
            return this.Find(delegate (BClientiComenziHeader pObiect) { return !pObiect.EsteActiv; }) != null;
        }

        public BColectieClientiComenziHeader GetListaActive()
        {
            BColectieClientiComenziHeader listaRetur = new BColectieClientiComenziHeader();

            foreach (var item in this)
            {
                if (item.EsteActiv)
                    listaRetur.Add(item);
            }
            return listaRetur;
        }

        public BColectieClientiComenziHeader GetListaInactive()
        {
            BColectieClientiComenziHeader listaRetur = new BColectieClientiComenziHeader();

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
                   // lucrare.UpdateAll(pIdEtapaParam, pIdTehnician, pDataTermen, lucrare.Observatii, pRefacere, pStatus, Tranzactie); //lucrare.ObservatiiEtapa
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

        public double GetValoareTotalaFactura(CDefinitiiComune.EnumTipMoneda pMoneda, double pCursBNR)
        {
            double total = 0;

            foreach (var item in this)
            {
               // total += CUtil.GetValoareMoneda(item.ValoareFinala, item.moneda, pCursBNR, pMoneda);
            }

            return total;
        }

        public BClientiComenziHeader GetUltimaByIdClient(int pIdClient)
        {
            BClientiComenziHeader comanda = null;
            foreach (var item in this)
            {
                if (comanda == null)
                    comanda = item;
                else
                {
                    if (comanda.DataPrimire < item.DataPrimire)
                        comanda = item;
                }
            }

            return comanda;
        }

        public BColectieClientiComenziHeader GetByIdCabinet(int pIdCabinet)
        {
            BColectieClientiComenziHeader listaRetur = new BColectieClientiComenziHeader();

            foreach (var item in this)
            {
                if (item.IdCabinet == pIdCabinet)
                    listaRetur.Adauga(item);
            }

            return listaRetur;
        }

        public BColectieClientiComenziHeader GetByIdMedic(int pIdMedic)
        {
            BColectieClientiComenziHeader listaRetur = new BColectieClientiComenziHeader();

            foreach (var item in this)
            {
                if (item.IdClient == pIdMedic)
                    listaRetur.Adauga(item);
            }

            return listaRetur;
        }

    }
}
