CREATE TABLE [dbo].[User] (
    [UserId]       UNIQUEIDENTIFIER NOT NULL,
    [FullName]     NVARCHAR (100)   NOT NULL,
    [UserName]     NVARCHAR (100)   NOT NULL,
    [PasswordHash] NVARCHAR (250)   NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC)
);
GO

CREATE UNIQUE INDEX [UK_UserName] ON [dbo].[User] ([UserName])
