CREATE PROCEDURE [dbo].[sp_register_user]
	@UserId UNIQUEIDENTIFIER,
	@FullName NVARCHAR(100),
	@UserName NVARCHAR(100),
	@PasswordHash NVARCHAR(150)
AS
BEGIN
	INSERT INTO [dbo].[User]
		 VALUES (@UserId
				,@FullName
				,@UserName
				,@PasswordHash);
END