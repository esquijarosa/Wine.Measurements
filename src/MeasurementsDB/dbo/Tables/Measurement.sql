CREATE TABLE [dbo].[Measurement] (
    [Id]           INT                IDENTITY (1, 1) NOT NULL,
    [Year]         INT                NOT NULL,
    [VarietyId]    INT                NOT NULL,
    [TypeId]       INT                NOT NULL,
    [Color]        NVARCHAR (50)      NOT NULL,
    [Temperature]  FLOAT (53)         NOT NULL,
    [Graduation]   FLOAT (53)         NOT NULL,
    [PH]           FLOAT (53)         NOT NULL,
    [Observations] NVARCHAR (250)     NULL,
    [RecordedBy]   NVARCHAR (100)     NOT NULL,
    [RecordedAt]   DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_Measurement] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Measurement_Variety] FOREIGN KEY ([VarietyId]) REFERENCES [dbo].[WineVariety] ([Id]),
    CONSTRAINT [FK_Measurement_Type] FOREIGN KEY ([TypeId]) REFERENCES [dbo].[WineType] ([Id])
);