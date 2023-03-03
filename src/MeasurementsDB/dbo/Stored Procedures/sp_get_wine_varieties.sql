CREATE PROCEDURE [dbo].[sp_get_wine_varieties]
AS
BEGIN
	SELECT [Id],
		   [Variety] AS [Value]
	  FROM [dbo].[WineVariety]
	ORDER BY [Variety];
END
