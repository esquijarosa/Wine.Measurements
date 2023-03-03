CREATE PROCEDURE [dbo].[sp_delete_measurement]
	@Id INT
AS
BEGIN
	DELETE FROM [dbo].[Measurement]
		  WHERE [Id] = @Id;
END