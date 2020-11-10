EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClientiPlati_TD_V'
GO

EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClientiPlati_TD_V'
GO

/****** Object:  View [dbo].[ClientiPlati_TD_V]    Script Date: 10/8/2020 10:16:53 AM ******/
DROP VIEW [dbo].[ClientiPlati_TD_V]
GO

/****** Object:  View [dbo].[ClientiPlati_TD_V]    Script Date: 10/8/2020 10:16:53 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ClientiPlati_TD_V]
AS
SELECT        dbo.ClientiPlati_TD.nId, dbo.ClientiPlati_TD.xnIdClient, dbo.ClientiPlati_TD.dDataPlata, dbo.ClientiPlati_TD.nSumaPlatita, dbo.ClientiPlati_TD.nModalitatePlata, dbo.ClientiPlati_TD.nCursBNR, 
                         dbo.ClientiPlati_TD.xnUtilizatorCreare, dbo.ClientiPlati_TD.dDataCreare, dbo.ClientiPlati_TD.dDataInchidere, dbo.ClientiPlati_TD.xnUtilizatorInchidere, dbo.ClientiPlati_TD.tMotivInchidere, dbo.ClientiPlati_TD.tObservatii, 
                         dbo.Clienti_TD.tDenumire
FROM            dbo.ClientiPlati_TD INNER JOIN
                         dbo.Clienti_TD ON dbo.ClientiPlati_TD.xnIdClient = dbo.Clienti_TD.nId
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
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ClientiPlati_TD"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 267
               Right = 271
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Clienti_TD"
            Begin Extent = 
               Top = 79
               Left = 529
               Bottom = 209
               Right = 735
            End
            DisplayFlags = 280
            TopColumn = 24
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClientiPlati_TD_V'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClientiPlati_TD_V'
GO


