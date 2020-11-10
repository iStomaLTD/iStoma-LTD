IF OBJECT_ID('Regiuni_REF_V', 'V') IS NOT NULL
	DROP VIEW [dbo].[Regiuni_REF_V]

-$$$-

CREATE VIEW [dbo].[Regiuni_REF_V]
AS
SELECT        dbo.Regiuni_REF.xnIdTara, dbo.Regiuni_REF.tNume, dbo.Regiuni_REF.tAbreviere, dbo.Regiuni_REF.tPrefixTelefon, dbo.Regiuni_REF.nLimbaDenumirii, dbo.Regiuni_REF.nPreferinta, dbo.Regiuni_REF.dDataCreare, 
                         dbo.Regiuni_REF.xnUtilizatorCreare, dbo.Regiuni_REF.dDataInchidere, dbo.Regiuni_REF.xnUtilizatorInchidere, dbo.Regiuni_REF.tMotivInchidere, dbo.Tari_REF.tNumeScurt AS tNumeTara, dbo.Regiuni_REF.nIdRegiune, 
                         dbo.Tari_REF.nLimbaDenumirii AS nLimbaDenumiriiTara
FROM            dbo.Regiuni_REF INNER JOIN
                         dbo.Tari_REF ON dbo.Regiuni_REF.xnIdTara = dbo.Tari_REF.nIdTara

-$$$-

IF OBJECT_ID('Localitati_REF_V', 'V') IS NOT NULL
	DROP VIEW [dbo].[Localitati_REF_V]

-$$$-

CREATE VIEW [dbo].[Localitati_REF_V]
AS
SELECT        dbo.Localitati_REF.nIdLocalitate, dbo.Localitati_REF.xnIdRegiune, dbo.Localitati_REF.tNume, dbo.Localitati_REF.nTip, dbo.Localitati_REF.nLimbaDenumirii, dbo.Localitati_REF.nPreferinta, dbo.Localitati_REF.dDataCreare, 
                         dbo.Localitati_REF.xnUtilizatorCreare, dbo.Localitati_REF.dDataInchidere, dbo.Localitati_REF.xnUtilizatorInchidere, dbo.Localitati_REF.tMotivInchidere, dbo.Regiuni_REF_V.xnIdTara, 
                         dbo.Regiuni_REF_V.tNume AS tNumeRegiune, dbo.Regiuni_REF_V.tNumeTara, dbo.Regiuni_REF_V.nLimbaDenumiriiTara
FROM            dbo.Localitati_REF LEFT OUTER JOIN
                         dbo.Regiuni_REF_V ON dbo.Localitati_REF.xnIdRegiune = dbo.Regiuni_REF_V.nIdRegiune

-$$$-

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Regiuni_REF_GetListaCautare]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Regiuni_REF_GetListaCautare]

-$$$-

CREATE PROCEDURE [dbo].[Regiuni_REF_GetListaCautare] 
    @xnIdTara int,
	@tDenumire nVarChar(100),
	@nIdLimba int
AS
BEGIN

    SELECT nIdRegiune, tNume FROM Regiuni_REF_V
	WHERE nLimbaDenumiriiTara = @nIdLimba AND xnIdTara = @xnIdTara AND tNume LIKE @tDenumire collate Latin1_General_BIN2 AND dDataInchidere IS NULL 
	ORDER BY nPreferinta DESC

END

-$$$-

IF OBJECT_ID('ClientiReprezentanti_TD_V', 'V') IS NOT NULL
	DROP VIEW [dbo].[ClientiReprezentanti_TD_V]

-$$$-

CREATE VIEW [dbo].[ClientiReprezentanti_TD_V]
AS
SELECT        dbo.ClientiReprezentanti_TD.nId, dbo.ClientiReprezentanti_TD.xnIdClient, dbo.ClientiReprezentanti_TD.tCNP, dbo.ClientiReprezentanti_TD.tNume, dbo.ClientiReprezentanti_TD.tPrenume, 
                         dbo.ClientiReprezentanti_TD.dDataNastere, dbo.ClientiReprezentanti_TD.nSex, dbo.ClientiReprezentanti_TD.nTitulatura, dbo.ClientiReprezentanti_TD.tNumeDeFata, dbo.ClientiReprezentanti_TD.tPorecla, 
                         dbo.ClientiReprezentanti_TD.tTelefonMobil, dbo.ClientiReprezentanti_TD.tTelefonFix, dbo.ClientiReprezentanti_TD.tFax, dbo.ClientiReprezentanti_TD.tContSkype, dbo.ClientiReprezentanti_TD.tContYM, 
                         dbo.ClientiReprezentanti_TD.tAdresaMail, dbo.ClientiReprezentanti_TD.nRol, dbo.ClientiReprezentanti_TD.nStareCivila, dbo.ClientiReprezentanti_TD.nNumarCopii, dbo.ClientiReprezentanti_TD.tScoala, 
                         dbo.ClientiReprezentanti_TD.xnIdNationalitate, dbo.ClientiReprezentanti_TD.xnIdTaraNastere, dbo.ClientiReprezentanti_TD.xnIdJudetNastere, dbo.ClientiReprezentanti_TD.xnIdLocalitateNastere, 
                         dbo.ClientiReprezentanti_TD.xnIdProfesie, dbo.ClientiReprezentanti_TD.tObservatii, dbo.ClientiReprezentanti_TD.dDataCreare, dbo.ClientiReprezentanti_TD.xnUtilizatorCreare, dbo.ClientiReprezentanti_TD.dDataInchidere, 
                         dbo.ClientiReprezentanti_TD.xnUtilizatorInchidere, dbo.ClientiReprezentanti_TD.tMotivInchidere, dbo.Clienti_TD.tDenumire
FROM            dbo.ClientiReprezentanti_TD INNER JOIN
                         dbo.Clienti_TD ON dbo.ClientiReprezentanti_TD.xnIdClient = dbo.Clienti_TD.nId

-$$$-

IF OBJECT_ID('Clienti_V', 'V') IS NOT NULL
	DROP VIEW [dbo].[Clienti_V]

-$$$-

CREATE VIEW [dbo].[Clienti_V]
AS
SELECT        nId, tDenumire
FROM            dbo.Clienti_TD AS c WHERE C.dDataInchidere is null
UNION
SELECT xnIdClient, isnull(tNume,'') + ' ' + isnull(tPrenume, '') + ' ' + isnull(tPorecla,'') + ' - ' + tDenumire   from ClientiReprezentanti_TD_V as cr WHERE cr.dDataInchidere is null

-$$$-

IF COL_LENGTH('ClientiComenzi_TD','nPretUnitarInitial') IS NULL
BEGIN
	ALTER TABLE ClientiComenzi_TD
	ADD nPretUnitarInitial money NULL
END

-$$$-

IF COL_LENGTH('ClientiComenzi_TD','nPretUnitarFinal') IS NULL
BEGIN
	ALTER TABLE ClientiComenzi_TD
	ADD nPretUnitarFinal money NULL
END

-$$$-

IF COL_LENGTH('ClientiComenzi_TD','tCodLucrare') IS NULL
BEGIN
	ALTER TABLE ClientiComenzi_TD
	ADD tCodLucrare varchar(20) NULL
END

-$$$-

IF OBJECT_ID('ClientiComenzi_TD_V', 'V') IS NOT NULL
    DROP VIEW ClientiComenzi_TD_V;

-$$$-

CREATE VIEW [dbo].[ClientiComenzi_TD_V]
AS
SELECT        dbo.ClientiComenzi_TD.nId, dbo.ClientiComenzi_TD.xnIdClient, dbo.ClientiComenzi_TD.xnIdReprezentantClient, dbo.ClientiComenzi_TD.tNumePacient, dbo.ClientiComenzi_TD.tPrenumePacient, 
                         dbo.ClientiComenzi_TD.dDataNasterePacient, dbo.ClientiComenzi_TD.nSexPacient, dbo.ClientiComenzi_TD.dDataPrimire, dbo.ClientiComenzi_TD.dDataLaGata, dbo.ClientiComenzi_TD.dDataCreare, 
                         dbo.ClientiComenzi_TD.xnUtilizatorCreare, dbo.ClientiComenzi_TD.dDataInchidere, dbo.ClientiComenzi_TD.xnUtilizatorInchidere, dbo.ClientiComenzi_TD.tMotivInchidere, dbo.ClientiComenzi_TD.tObservatii, 
                         dbo.ClientiComenzi_TD.xnIdCabinet, dbo.ClientiComenzi_TD.xnIdLucrare, dbo.ClientiComenzi_TD.nValoareInitiala, dbo.ClientiComenzi_TD.nValoareFinala, dbo.ClientiComenzi_TD.xnIdFactura, dbo.ClientiComenzi_TD.nMoneda, 
                         dbo.ClientiComenzi_TD.bUrgent, dbo.ClientiComenzi_TD.nNrElemente, dbo.ClientiComenzi_TD.xnIdEtapaCurenta, dbo.ClientiComenziEtape_TD.xnIdTehnician, dbo.Clienti_TD.tDenumire, 
                         dbo.ClientiCabinete_TD.tDenumire AS tDenumireCabinet, dbo.ClientiReprezentanti_TD.tNume AS tNumeMedic, dbo.ClientiReprezentanti_TD.tPrenume AS tPrenumeMedic, dbo.Utilizator_TD.tNume AS tNumeTehnician, 
                         dbo.Utilizator_TD.tPrenume AS tPrenumeTehnician, dbo.ClientiComenziEtape_TD.xnIdEtapa AS xnIdEtapaSetari, dbo.Etape_TP.tDenumire AS tDenumireEtapa, dbo.ListaPreturiStandard_TP.tDenumire AS tDenumireLucrare, 
                         dbo.ClientiComenziEtape_TD.dDataInceput AS dDataInceputEtapa, dbo.ClientiComenziEtape_TD.dDataFinal AS dDataSfarsitEtapa, dbo.ClientiComenziEtape_TD.tObservatii AS tObservatiiEtapa, 
                         dbo.ClientiComenziEtape_TD.nStatus AS nStatusEtapa, dbo.ClientiComenzi_TD.tCuloareLucrare, dbo.ClientiComenziEtape_TD.bRefacere, dbo.ListaPreturiStandard_TP.tDenumirePrescurtata, dbo.ClientiComenzi_TD.bAcceptata, 
                         dbo.Utilizator_TD.nCuloare AS nCuloareTehnician, ClientiFacturi_TD.dDataFactura, ClientiFacturi_TD.tSerieFactura, ClientiFacturi_TD.nNumarFactura, ClientiFacturi_TD.nMonedaFactura, 
                         ClientiFacturi_TD.tObservatii AS tObservatiiFactura, dbo.ClientiComenzi_TD.nVarsta, dbo.ClientiComenzi_TD.nPretUnitarInitial, dbo.ClientiComenzi_TD.nPretUnitarFinal, dbo.ClientiComenzi_TD.tCodLucrare
FROM            dbo.ClientiComenzi_TD LEFT OUTER JOIN
                         dbo.ClientiComenziEtape_TD ON dbo.ClientiComenzi_TD.xnIdEtapaCurenta = dbo.ClientiComenziEtape_TD.nId INNER JOIN
                         dbo.Clienti_TD ON dbo.ClientiComenzi_TD.xnIdClient = dbo.Clienti_TD.nId INNER JOIN
                         dbo.ListaPreturiStandard_TP ON dbo.ClientiComenzi_TD.xnIdLucrare = dbo.ListaPreturiStandard_TP.nId LEFT OUTER JOIN
                         dbo.Etape_TP ON dbo.ClientiComenziEtape_TD.xnIdEtapa = dbo.Etape_TP.nId LEFT OUTER JOIN
                         dbo.Utilizator_TD ON dbo.ClientiComenziEtape_TD.xnIdTehnician = dbo.Utilizator_TD.nId LEFT OUTER JOIN
                         dbo.ClientiCabinete_TD ON dbo.ClientiComenzi_TD.xnIdCabinet = dbo.ClientiCabinete_TD.nId LEFT OUTER JOIN
                         dbo.ClientiReprezentanti_TD ON dbo.ClientiComenzi_TD.xnIdReprezentantClient = dbo.ClientiReprezentanti_TD.nId LEFT OUTER JOIN
                         dbo.ClientiFacturi_TD AS ClientiFacturi_TD ON dbo.ClientiComenzi_TD.xnIdFactura = ClientiFacturi_TD.nId


-$$$-