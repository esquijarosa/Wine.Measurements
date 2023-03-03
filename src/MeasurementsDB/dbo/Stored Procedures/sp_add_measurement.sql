CREATE PROCEDURE [dbo].[sp_add_measurement]
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
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Measurement]
		 VALUES (@Year
				,@VarietyId
				,@TypeId
				,@Color
				,@Temperature
				,@Graduation
				,@PH
				,@Observations
				,@RecordedBy
				,@RecordedAt);

	SELECT @@IDENTITY;
END