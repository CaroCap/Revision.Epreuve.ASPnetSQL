CREATE TABLE [dbo].[Diffusion]
(
	[Id] INT IDENTITY NOT NULL,
	[Cinema_Id] INT NOT NULL,
	[Film_Id] INT NOT NULL,
	[DateDiffusion] DATETIME2 NULL,
	/* Possibilité de faire un Alter Table après le GO 
	CONSTRAINT FK_Diffusion_Cinema FOREIGN KEY ([Cinema_Id]) REFERENCES [Cinema]([Id]),*/
	CONSTRAINT PK_Diffusion PRIMARY KEY([Id])
)
GO

ALTER TABLE [Diffusion] ADD CONSTRAINT FK_Diffusion_Cinema FOREIGN KEY ([Cinema_Id]) REFERENCES [Cinema]([Id])
GO 

ALTER TABLE [Diffusion] ADD	CONSTRAINT FK_Diffusion_Film FOREIGN KEY ([Film_Id]) REFERENCES Film([Id])
GO