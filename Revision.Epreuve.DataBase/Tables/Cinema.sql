﻿CREATE TABLE [dbo].[Cinema]
(
	[Id] INT NOT NULL IDENTITY,
	[Nom] NVARCHAR(64) NOT NULL,
	[Ville] NVARCHAR(64) NOT NULL,
	CONSTRAINT PK_Cinema PRIMARY KEY ([Id])
)