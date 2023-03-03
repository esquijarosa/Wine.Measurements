CREATE PROCEDURE [dbo].[sp_get_wine_types]
AS
BEGIN
	SELECT [Id],
		   [Type] AS [Value]
	  FROM [dbo].[WineType]
	ORDER BY [Type];
END
