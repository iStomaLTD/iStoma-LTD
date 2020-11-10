EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClientiReprezentanti_TD_V'
GO

EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClientiReprezentanti_TD_V'
GO

EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClientiReprezentanti_TD_V'
GO

/****** Object:  View [dbo].[ClientiReprezentanti_TD_V]    Script Date: 25-Sep-18 16:25:52 ******/
DROP VIEW [dbo].[ClientiReprezentanti_TD_V]
GO

/****** Object:  View [dbo].[ClientiReprezentanti_TD_V]    Script Date: 25-Sep-18 16:25:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

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
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[21] 2[15] 3) )"
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
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ClientiReprezentanti_TD"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 240
            End
            DisplayFlags = 280
            TopColumn = 27
         End
         Begin Table = "Clienti_TD"
            Begin Extent = 
               Top = 6
               Left = 278
               Bottom = 136
               Right = 484
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
      Begin ColumnWidths = 33
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
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
     ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClientiReprezentanti_TD_V'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'    Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClientiReprezentanti_TD_V'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClientiReprezentanti_TD_V'
GO


