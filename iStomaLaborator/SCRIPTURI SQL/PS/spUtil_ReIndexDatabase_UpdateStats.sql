IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('spUtil_ReIndexDatabase_UpdateStats'))
DROP PROCEDURE [dbo].spUtil_ReIndexDatabase_UpdateStats

GO 

CREATE PROCEDURE spUtil_ReIndexDatabase_UpdateStats
AS
DECLARE @MyTable VARCHAR(255)
DECLARE myCursor
CURSOR FOR
SELECT '['+TABLE_SCHEMA+'].['+TABLE_NAME+']'
FROM information_schema.tables
WHERE table_type = 'base table'
OPEN myCursor
FETCH NEXT
FROM myCursor INTO @MyTable
WHILE @@FETCH_STATUS = 0
BEGIN
PRINT 'Reindexing Table:  ' + @MyTable
DBCC DBREINDEX(@MyTable, '', 80)
FETCH NEXT
FROM myCursor INTO @MyTable
END
CLOSE myCursor
DEALLOCATE myCursor
EXEC sp_updatestats
GO
