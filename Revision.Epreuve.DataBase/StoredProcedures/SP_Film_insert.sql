CREATE PROCEDURE [dbo].[SP_Film_insert]
	@titre	NVARCHAR(128),
	@date DATE
AS
	INSERT INTO [Film]([Titre],[DateSortie])
	-- Ajouter OUTPUT pour récupérer ID de l'élément stocké
	OUTPUT [inserted].[Id]
	VALUES (@titre, @date)
RETURN 0
