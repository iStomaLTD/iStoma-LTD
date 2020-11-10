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