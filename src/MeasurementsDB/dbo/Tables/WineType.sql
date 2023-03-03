CREATE TABLE [dbo].[WineType] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Type] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_WineType] PRIMARY KEY CLUSTERED ([Id] ASC)
);