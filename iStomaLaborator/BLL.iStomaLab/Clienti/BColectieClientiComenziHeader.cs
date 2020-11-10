using BLL.iStomaLab.Comune;
using CCL.iStomaLab;
using CDL.iStomaLab;
using DAL.iStomaLab.Clienti;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

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



        public BColectieClientiComenziHeader GetByIdMedic(int pIdMedic)
        {
            BColectieClientiComenziHeader listaRetur = new BColectieClientiComenziHeader();

            foreach (var item in this)
            {
                if (item.IdReprezentantClient == pIdMedic)
                    listaRetur.Add(item);
            }
            return listaRetur;
        }

        public BColectieClientiComenziHeader GetByIdCabinet(int pIdCabinet)
        {
            BColectieClientiComenziHeader listaRetur = new BColectieClientiComenziHeader();

            foreach (var item in this)
            {
                if (item.IdCabinet == pIdCabinet)
                    listaRetur.Add(item);
            }
            return listaRetur;
        }
               
        public BClientiComenziHeader GetUltimaByIdClient(int pIdClient)
        {
            BClientiComenziHeader comandaRetur = null;

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

        /// <summary>
        /// Recuperam ultimele lucrari ale tuturor clinicilor din baza de date
        /// </summary>
        /// <param name="pTranzactie"></param>
        /// <returns></returns>
        public static BColectieClientiComenziHeader GetUltimeleLucrariPerClinica(IDbTransaction pTranzactie)
        {
            BColectieClientiComenziHeader lstDClientiComenzi = new BColectieClientiComenziHeader();
            using (DataSet ds = DClientiComenziHeader.GetUltimeleLucrariPerClinica(pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiComenzi.Add(new BClientiComenziHeader(dr));
                }
            }
            return lstDClientiComenzi;
        }

   

    }
}
