using CCL.iStomaLab;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.iStomaLab.Clienti
{
    public sealed class BColectieClientiFacturi : List<BClientiFacturi>, IDisposable
    {
        #region Constructori

        public BColectieClientiFacturi()
        {
        }

        public BColectieClientiFacturi(int pIdClient)
        {

        }

        public BColectieClientiFacturi(BClientiFacturi pElement)
        {
            this.Adauga(pElement);
        }

        public BColectieClientiFacturi(List<BClientiFacturi> pListaElemente)
        {
            if (pListaElemente != null)
                this.AddRange(pListaElemente);
        }

        public BColectieClientiFacturi(List<object> pListaElemente)
        {
            if (pListaElemente != null)
            {
                foreach (object element in pListaElemente)
                {
                    this.Adauga(element as BClientiFacturi);
                }
            }
        }

        public void Adauga(BClientiFacturi pElement)
        {
            if (pElement != null)
                this.Add(pElement);
        }

        #endregion //Constructori

        public BClientiFacturi GetById(int pId)
        {
            return this.Find(delegate (BClientiFacturi pObiect) { return pObiect.Id == pId; });
        }

        public BColectieClientiFacturi Intersectie(BColectieClientiFacturi pListaDeIntersectat)
        {
            return CUtil.GetIntersectie<BColectieClientiFacturi, BClientiFacturi>(this, pListaDeIntersectat);
        }

        public BColectieClientiFacturi Filtreaza(CDefinitiiComune.EnumStare pStare)
        {
            BColectieClientiFacturi SubLista = new BColectieClientiFacturi();
            foreach (BClientiFacturi Element in this)
            {
                if (Element.EsteActiv != (pStare == CDefinitiiComune.EnumStare.Activa || pStare == CDefinitiiComune.EnumStare.Toate))
                    continue; SubLista.Add(Element);
            }
            return SubLista;
        }

        public void RefreshById(int pId)
        {
            BClientiFacturi ObiectGasit = GetById(pId);
            if (ObiectGasit != null)
                ObiectGasit.Refresh(null);
        }

        public void Dispose()
        {
            foreach (BClientiFacturi Element in this)
            {
                Element.Dispose();
            }
        }

        public bool ExistaElementeInchise()
        {
            return this.Find(delegate (BClientiFacturi pObiect) { return pObiect.EsteActiv == false; }) != null;
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
            return CUtil.getListaCaText<BClientiFacturi>(this, "; ");
        }

        public bool ContineElementeDeactivate()
        {
            return this.Find(delegate (BClientiFacturi pObiect) { return !pObiect.EsteActiv; }) != null;
        }

        public BColectieClientiFacturi GetListaActive()
        {
            BColectieClientiFacturi listaRetur = new BColectieClientiFacturi();

            foreach (var item in this)
            {
                if (item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public BColectieClientiFacturi GetListaInactive()
        {
            BColectieClientiFacturi listaRetur = new BColectieClientiFacturi();

            foreach (var item in this)
            {
                if (!item.EsteActiv)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public List<int> GetIdFacturaDistincteDinLista()
        {
            List<int> listaIduri = new List<int>();

            foreach (var item in this)
            {
                if (!listaIduri.Contains(item.Id))
                    listaIduri.Add(item.Id);
            }

            return listaIduri;
        }

        public BColectieClientiFacturi GetListaFacturiDupaIdClient(int id)
        {
            BColectieClientiFacturi listaRetur = new BColectieClientiFacturi();

            foreach (var item in this)
            {
                if (item.IdClient == id)
                    listaRetur.Add(item);
            }

            return listaRetur;
        }
        public BClientiFacturi GetUltimaByIdClient(int pIdClient)
        {
            BClientiFacturi facturaRetur = null;

            foreach (var item in this)
            {
                if (item.IdClient == pIdClient)
                {
                    if (facturaRetur == null || facturaRetur.DataFactura < item.DataFactura)
                        facturaRetur = item;
                }
            }

            return facturaRetur;
        }


        public BColectieClientiFacturi GetListaNeachitateIntegral(BColectieClientiComenzi pComenzi)
        {
            BColectieClientiFacturi listaRetur = new BColectieClientiFacturi();

            BColectieClientiPlatiComenzi pPlati = BClientiPlatiComenzi.GetByListIdComenzi(pComenzi.GetListaId(), null);

            double valoare = 0;
            double platit = 0;
            BColectieClientiComenzi comenziTemp = new BColectieClientiComenzi();
            BColectieClientiPlatiComenzi platiTemp = new BColectieClientiPlatiComenzi();

            foreach (var item in this)
            {
                //verificam daca a fost facuta plata inainte
                comenziTemp = pComenzi.GetByIdFactura(item.Id);
                if (!CUtil.EsteListaVida<BClientiComenzi>(comenziTemp))
                {
                    //verificam cat a fost platit

                    platiTemp = pPlati.GetByIdComenzi(comenziTemp.GetListaId());
                    valoare = comenziTemp.GetValoareTotalaFactura(item.MonedaFactura, item.CursBNR);
                    platit = platiTemp.GetValoarePlatita();

                    if (valoare - platit > 0)
                    {
                        listaRetur.Adauga(item);
                    }
                }
                else
                {
                    listaRetur.Adauga(item);
                }


                //valoare = item.GetValoare(pListaComenzi, this.ctrlLeiEuro.Moneda, this.txtCursSchimb.ValoareDouble);
                //platit = pListaPlatiCurente.GetByIdComenzi(pListaComenzi.GetListaId()).GetValoarePlatita();
            }

            return listaRetur;
        }
              
    }
}
