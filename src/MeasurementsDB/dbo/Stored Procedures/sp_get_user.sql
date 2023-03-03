CREATE PROCEDURE [dbo].[sp_get_user]
	@UserName NVARCHAR(100),
	@PasswordHash NVARCHAR(150)
AS
BEGIN
	SELECT [UserId],
		   [FullName],
		   [UserName]
	  FROM [dbo].[User]
	 WHERE [UserName] = @UserName
	   AND [PasswordHash] = @PasswordHash;
END