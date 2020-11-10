EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClientiComenzi_TD_V'
GO

EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClientiComenzi_TD_V'
GO

EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClientiComenzi_TD_V'
GO

/****** Object:  View [dbo].[ClientiComenzi_TD_V]    Script Date: 09-Mar-20 16:47:46 ******/
DROP VIEW [dbo].[ClientiComenzi_TD_V]
GO

/****** Object:  View [dbo].[ClientiComenzi_TD_V]    Script Date: 09-Mar-20 16:47:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

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
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -288
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ClientiComenzi_TD"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 249
            End
            DisplayFlags = 280
            TopColumn = 26
         End
         Begin Table = "ClientiComenziEtape_TD"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 235
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Clienti_TD"
            Begin Extent = 
               Top = 270
               Left = 38
               Bottom = 400
               Right = 244
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ListaPreturiStandard_TP"
            Begin Extent = 
               Top = 402
               Left = 38
               Bottom = 532
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Etape_TP"
            Begin Extent = 
               Top = 534
               Left = 38
               Bottom = 664
               Right = 240
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Utilizator_TD"
            Begin Extent = 
               Top = 666
               Left = 38
               Bottom = 796
               Right = 273
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ClientiCabinete_TD"
            Begin Extent = 
               Top = 798
               Left = 38
               Bottom = 928
            ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClientiComenzi_TD_V'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'   Right = 235
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ClientiReprezentanti_TD"
            Begin Extent = 
               Top = 930
               Left = 38
               Bottom = 1060
               Right = 240
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ClientiFacturi_TD"
            Begin Extent = 
               Top = 1062
               Left = 38
               Bottom = 1192
               Right = 235
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClientiComenzi_TD_V'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClientiComenzi_TD_V'
GO


