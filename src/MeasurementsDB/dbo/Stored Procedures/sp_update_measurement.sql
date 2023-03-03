CREATE PROCEDURE [dbo].[sp_update_measurement]
	@Id INT,
	@Year INT,
	@VarietyId INT,
	@TypeId INT,
	@Color NVARCHAR(50),
	@Temperature FLOAT,
	@Graduation FLOAT,
	@PH FLOAT,
	@Observations NVARCHAR(250) = NULL,
	@RecordedBy NVARCHAR(100),
	@RecordedAt DATETIMEOFFSET
AS
BEGIN
	UPDATE [dbo].[Measurement]
	   SET [Year] = @Year,
		   [VarietyId] = @VarietyId,
		   [TypeId] = @TypeId,
		   [Color] = @Color,
		   [Temperature] = @Temperature,
		   [Graduation] = @Graduation,
		   [PH] = @PH,
		   [Observations] = @Observations,
		   [RecordedBy] = @RecordedBy,
		   [RecordedAt] = @RecordedAt
	 WHERE [Id] = @Id;
END