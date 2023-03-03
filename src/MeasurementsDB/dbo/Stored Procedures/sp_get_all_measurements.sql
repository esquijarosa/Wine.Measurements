CREATE PROCEDURE [dbo].[sp_get_all_measurements]
AS
BEGIN
	SELECT M.[Id],
		   [Year],
		   WV.[Variety],
		   WT.[Type],
		   [Color],
		   [Temperature],
		   [Graduation],
		   [PH],
		   [Observations],
		   [RecordedBy],
		   [RecordedAt]
	  FROM [dbo].[Measurement] M
	INNER JOIN [dbo].[WineVariety] WV ON M.[VarietyId] = WV.[Id]
	INNER JOIN [dbo].[WineType] WT ON M.[TypeId] = WT.[Id]
	ORDER BY [RecordedAt] DESC;
END