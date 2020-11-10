using System;
using System.Collections.Generic;
using System.Drawing;
using CDL.iStomaLab;
using ILL.BLL.General;
using static CDL.iStomaLab.CDefinitiiComune;

namespace ILL.General.Interfete
{
    [CLSCompliant(true)]
    public interface IAccesTotal
    {
        //IAfisaj getObiect(CDefinitiiComune.EnumTipObiect pTipObiect, int pIdObiect);
        //IAfisaj getObiect(CDefinitiiComune.EnumTipObiect pTipObiect, int pIdObiect, System.Data.IDbTransaction pTranzactie);
        //void afiseazaDetaliiObiect(object pEcranParinte, IAfisaj pObiect);
        //IAfisaj getObiectDinIHM(object pEcranParinte, CDefinitiiComune.EnumTipObiect pTipObiect);
        //List<IAfisaj> getListaObiecteDinIHM(object pEcranParinte, CDefinitiiComune.EnumTipObiect pTipObiect);
        //Image getImagineTipObiect(CDefinitiiComune.EnumTipObiect pTipObiect);
        //List<IAfisaj> getByListaId(CDefinitiiComune.EnumTipObiect pTipObiect, List<int> pListaId);
        //void AfiseazaLista(object pEcranParinte, CDefinitiiComune.EnumTipObiect pTipLista, params object[] pListaParametri);
        void Notifica(string pText, string pTitlu, string pContinut, bool pEroare);
        void Notifica(EnumTipNotificare pTipNotificare, string pText, string pTitlu, string pContinut, bool pEroare);
        void AscundeIconitaNotificare();
       // string TrimiteSMS(int pIdSediu, string pNumarDestinatar, string pMesaj, CDefinitiiComune.EnumTipObiect pTipObiect, int pId, CDefinitiiComune.EnumTipObiect pTipOcazie, int pIdOcazie, int pMetodaTrimitere, bool pUrgent);
        bool SchimbaParolaISTOMA(int pId);
        int CereFunctionalitate(int pIdEcran, string pLocalizare, string pDescriere, int pTip);
        //void CereActiune(CDefinitiiComune.EnumTipActiune pTipActiune);
        //int getIdImagineAtasataObiect(CDefinitiiComune.EnumTipObiect pTipObiect, int pIdResursa);
        //List<IAfisaj> getByTipLista(CDefinitiiComune.EnumTipLista pTipLista, System.Data.IDbTransaction pTranzactie);
        //void Sincronizeaza(int pIdMedic, int pIdTratamentAdministrativ, CDefinitiiComune.EnumTipObiect pTipObiect);
        //void UpdateElementSincronizat(IAfisaj pElement);
        //void SchimbaCalendarElementSincronizat(IAfisaj pElement, int pIdMedicVechi, int pIdMedicNou);
        //bool TrimiteEmail(object pEmail, IContact pDestinatar, CDefinitiiComune.EnumTipObiect pTipOcazie, int pIdOcazie, ref string pMesajEroare);
        //void inchideEcranAsteptare();
        //void Deconecteaza();
        //void TransmitePrinChat(string lMesaj, int pIdDestinatar);
        //void TransmitePrinChat(EnumTipNotificare pTipNotificare, string lMesaj, int pIdDestinatar);
        //IAfisaj AdaugaObiect(CDefinitiiComune.EnumTipObiect pTipObiect, string pDenumire, bool pCompleteazaDetaliiExtinse);
        //void ConecteazaIStomaSMS();
        //bool SemnaleazaEroarea(string pEroare);
        //bool TrimiteMailAsincron(IContact pCatre, object pEmail, CDefinitiiComune.EnumTipObiect pTipOcazie, int pIdOcazie);
        //void AdaugaPacientInListaMinimizati(int pIdPacient);

        ////De tipul BPacientOrganeArtificiale.StructComandaProtetica daca exista sau null daca a fost finalizata/anulata
        //void SemnaleazaLucrareNefinalizata(object pLucrareNefinalizata);

        ////De tipul BLL.Gestiune.Furnizori.BFacturiFurnizori.StructFactura daca exista sau nu daca a fost finalizata/anulata
        //void SemnaleazaFacturaNefinalizata(object pFacturaNefinalizata);

        //void DeleteEvent(IAfisaj pMedic, string pIdEvent);

        //bool ConexiuneGooglePosibila(IAfisaj pMedic, ref string pMotiv);
        //string GetNumeCalendarGoogle(IAfisaj pMedic);
        //string GetNumeGrupPacienti(IAfisaj pMedic);

        //string GetSold(int pIdSediu);

        //string GetEtichetaValoareInterventie(int pIdInterventie);

        //bool PoateFiStersObiectul(IElementAgenda pElement, bool pCuAfisareMesaj);
        //bool PoateUtilizatorulSaModificeObiectul(IElementAgenda pElement, bool pCuAfisareMesaj);

        //void TrimiteSMSListaId(List<int> pListaId);
    }

}
