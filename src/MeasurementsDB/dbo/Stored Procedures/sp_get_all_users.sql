CREATE PROCEDURE [dbo].[sp_get_all_users]
AS
BEGIN
	SELECT [UserId],
		   [FullName],
		   [UserName]
	  FROM [dbo].[User]
	ORDER BY [FullName];
END