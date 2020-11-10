DROP PROCEDURE [dbo].[ClientiPlatiComenzi_TD_GetListaPlatiteByIdFactura]
GO

CREATE PROCEDURE [dbo].[ClientiPlatiComenzi_TD_GetListaPlatiteByIdFactura] 
    @xnIdFactura int
AS
BEGIN

    select * from ClientiPlatiComenzi_TD CPC
	inner join ClientiComenzi_TD CC on CPC.xnIdClientComanda = CC.nId
	where CC.xnIdFactura = @xnIdFactura

END