IF OBJECT_ID('ClientiComenziEtape_TD_V', 'V') IS NOT NULL
    DROP VIEW ClientiComenziEtape_TD_V;
GO

/****** Object:  View [dbo].[ClientiComenziEtape_TD_V]    Script Date: 10/9/2020 2:54:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ClientiComenziEtape_TD_V]
AS
SELECT        CCE.nId, CCE.xnIdComandaClient, CCE.xnIdEtapa, CCE.dDataInceput, CCE.dDataFinal, CCE.xnIdTehnician, CCE.tObservatii, CCE.dDataCreare, CCE.xnUtilizatorCreare, CCE.dDataInchidere, CCE.xnUtilizatorInchidere, 
                         CCE.tMotivInchidere, CCE.bRefacere, dbo.Etape_TP.tDenumire, CCE.nStatus, CC.xnIdClient, CC.xnIdReprezentantClient, CC.tNumePacient, CC.tPrenumePacient, CC.tObservatii AS tObservatiiComanda, CC.xnIdCabinet, 
                         CC.xnIdLucrare, CC.nNrElemente, CC.bUrgent, CC.tCuloareLucrare, dbo.Clienti_TD.tDenumire AS tDenumireClient, dbo.Utilizator_TD.tNume, dbo.Utilizator_TD.tPrenume, dbo.Utilizator_TD.tPorecla, 
                         dbo.ListaPreturiStandard_TP.tDenumire AS tDenumireLucrare, dbo.ListaPreturiStandard_TP.tDenumirePrescurtata AS tDenumirePrescurtataLucrare, CC.dDataCreare AS dDataCreareLucrare, 
                         CC.dDataLaGata AS dDataLaGataLucrare, CC.dDataPrimire AS dDataPrimireLucrare, CC.xnIdFactura, CC.nValoareInitiala, CC.nValoareFinala, CC.nMoneda, CC.nPretUnitarInitial, CC.nPretUnitarFinal, CC.tCodLucrare
FROM            dbo.ClientiComenziEtape_TD AS CCE INNER JOIN
                         dbo.Etape_TP ON CCE.xnIdEtapa = dbo.Etape_TP.nId INNER JOIN
                         dbo.ClientiComenzi_TD AS CC ON CCE.xnIdComandaClient = CC.nId INNER JOIN
                         dbo.Clienti_TD ON CC.xnIdClient = dbo.Clienti_TD.nId INNER JOIN
                         dbo.Utilizator_TD ON CCE.xnIdTehnician = dbo.Utilizator_TD.nId INNER JOIN
                         dbo.ListaPreturiStandard_TP ON CC.xnIdLucrare = dbo.ListaPreturiStandard_TP.nId LEFT OUTER JOIN
                         dbo.ClientiReprezentanti_TD ON CC.xnIdReprezentantClient = dbo.ClientiReprezentanti_TD.nId
GO



