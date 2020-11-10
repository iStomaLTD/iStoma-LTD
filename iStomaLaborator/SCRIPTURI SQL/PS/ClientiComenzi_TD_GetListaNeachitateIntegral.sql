/****** Object:  StoredProcedure [dbo].[ClientiComenzi_TD_GetListaNeachitateIntegral]    Script Date: 10/8/2020 2:12:24 PM ******/
DROP PROCEDURE [dbo].[ClientiComenzi_TD_GetListaNeachitateIntegral]
GO

/****** Object:  StoredProcedure [dbo].[ClientiComenzi_TD_GetListaNeachitateIntegral]    Script Date: 10/8/2020 2:12:24 PM ******/ 
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ClientiComenzi_TD_GetListaNeachitateIntegral] @xnIdClient int
AS
BEGIN
	
	SET NOCOUNT ON;
	
	SELECT * FROM ClientiComenzi_TD WHERE xnIdClient = @xnIdClient and xnIdFactura is not null AND nId IN
	(
	SELECT CC.nId from ClientiComenzi_TD AS CC LEFT OUTER JOIN 
	(SELECT xnIdClientComanda, SUM(nValoare) AS nTotalPlati FROM ClientiPlatiComenzi_TD WHERE xnIdClient = @xnIdClient
	GROUP BY xnIdClientComanda) AS CPC ON CC.nId = CPC.xnIdClientComanda AND CC.xnIdClient = @xnIdClient
	WHERE CC.nValoareFinala - ISNULL( CPC.nTotalPlati,0) <> 0 
	)

END
GO


