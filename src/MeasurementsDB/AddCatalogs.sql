IF NOT EXISTS (SELECT 1 FROM [dbo].[WineVariety])
BEGIN
	INSERT INTO [dbo].[WineVariety]
		 VALUES (N'Cabernet'),
				(N'Shiraz'),
				(N'Tempranillo')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[WineType])
BEGIN
	INSERT INTO [dbo].[WineType]
		 VALUES (N'Tinto'),
				(N'Rosado'),
				(N'Blanco')
END