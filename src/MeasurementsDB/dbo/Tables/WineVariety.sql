CREATE TABLE [dbo].[WineVariety] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [Variety] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_WineVariety] PRIMARY KEY CLUSTERED ([Id] ASC)
);
