/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO [Cinema]([Nom], [Ville]) VALUES ('Kinepolis', 'Bruxelles'),
                                            ('Kinepolis', 'Braine-l''Aleud'),
                                            ('UGC', 'Bruxelles'),
                                            ('Pathé', 'Charleroi'),
                                            ('Eldorado', 'Namur'),
                                            ('Kinepolis', 'Liège')

--On peut utiliser les procédures stockées pour remplir la base de données
EXEC SP_Film_Insert @titre='Jurassic Park', @date='1993-06-16'
EXEC SP_Film_Insert @titre='Ghostbuster', @date='2021-12-01'
EXEC SP_Film_Insert @titre='Ghostbuster', @date='1984-01-01'
EXEC SP_Film_Insert @titre='Judy n''est pas là', @date='2021-12-16'
EXEC SP_Film_Insert @titre='Spiderman', @date='2021-12-16'
EXEC SP_Film_Insert @titre='Spiderman3', @date='2021-12-16'

INSERT INTO [Diffusion] ([Cinema_Id], [Film_Id], [DateDiffusion]) VALUES (1, 1, '2021-12-16 11:00:00'),
                                                                          (1, 2, '2021-12-16 12:00:00'),
                                                                          (1, 3, '2021-12-16 14:30:00'),
                                                                          (1, 4, '2021-12-16 16:45:00'),
                                                                          (1, 5, '2021-12-16 18:30:00'),
                                                                          (1, 6, '2021-12-16 20:00:00'),
                                                                          (2, 1, '2021-12-16 11:00:00'),
                                                                          (2, 2, '2021-12-16 12:00:00'),
                                                                          (2, 3, '2021-12-16 14:30:00'),
                                                                          (2, 4, '2021-12-16 16:45:00'),
                                                                          (3, 5, '2021-12-16 18:30:00'),
                                                                          (3, 6, '2021-12-16 20:00:00'),
                                                                          (3, 1, '2021-12-16 11:00:00'),
                                                                          (4, 2, '2021-12-16 12:00:00'),
                                                                          (4, 3, '2021-12-16 14:30:00'),
                                                                          (4, 4, '2021-12-16 16:45:00'),
                                                                          (5, 5, '2021-12-16 18:30:00'),
                                                                          (5, 6, '2021-12-16 20:00:00'),
                                                                          (5, 1, '2021-12-16 11:00:00'),
                                                                          (5, 2, '2021-12-16 12:00:00'),
                                                                          (6, 3, '2021-12-16 14:30:00'),
                                                                          (6, 4, '2021-12-16 16:45:00'),
                                                                          (6, 5, '2021-12-16 18:30:00'),
                                                                          (6, 6, '2021-12-16 20:00:00')