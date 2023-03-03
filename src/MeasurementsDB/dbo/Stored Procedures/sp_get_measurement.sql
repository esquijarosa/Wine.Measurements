CREATE PROCEDURE [dbo].[sp_get_measurement]
	@Id INT
AS
BEGIN
	SELECT [Year],
		   [VarietyId] AS [Variety],
		   [TypeId] AS [Type],
		   [Color],
		   [Temperature],
		   [Graduation],
		   [PH],
		   [Observations],
		   [RecordedBy],
		   [RecordedAt]
	  FROM [dbo].[Measurement]
	 WHERE [Id] = @Id;
END