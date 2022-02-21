CREATE TABLE [dbo].[Film]
(
	[Id] INT IDENTITY NOT NULL ,
	[Titre] NVARCHAR(128) NOT NULL,
	[DateSortie] DATE NOT NULL,
	CONSTRAINT PK_Film PRIMARY KEY([Id]),
	CONSTRAINT UK_Film_Titre_DateSortie UNIQUE ([Titre], [DateSortie])
)
