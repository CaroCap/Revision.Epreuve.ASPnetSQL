using Revision.Epreuve.Common.Repositories;
using Revision.Epreuve.DAL.EntitiesDTO;
using Revision.Epreuve.DAL.Handlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Revision.Epreuve.DAL.RepositoriesDAO
{
    public class CinemaService : ServiceBase, ICinemaRepository<CinemaDAL>
    {
        private string _connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Revision.Epreuve.DataBase;Integrated Security=True";
        public void Delete(int idCinema)
        {
            // Création de Sql Connection
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                // Création de la commande
                using (SqlCommand command = connection.CreateCommand())
                {
                    // écrire la commande
                    command.CommandText = "DELETE FROM [Cinema] WHERE [Id] = @id";
                    // Préciser les paramètres
                    SqlParameter p_id = new SqlParameter() { ParameterName = "id", Value = idCinema };
                    // Lier/Associé le paramètre à la commande
                    command.Parameters.Add(p_id);
                    // Ouvrir la connexion
                    connection.Open();
                    // Effectuer la commande - Execution où on ne doit rien récupérer comme données donc ExecuteNonQuery
                    command.ExecuteNonQuery();
                    // Connexion se ferme automatiquement
                }
            }
        }

        public CinemaDAL Get(int idCinema)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT [Id],[Nom],[Ville] FROM [Cinema] WHERE [Id] = @id";
                    SqlParameter p_id = new SqlParameter() { ParameterName = "id", Value = idCinema };
                    cmd.Parameters.Add(p_id);
                    connection.Open();
                    // Cette méthode nécéssite un Return  
                    // Execute Reader car attend un retour de 3 informations. => Création d'un reader + while tant que tu read, retourne la conversion du mapper sinon renvoie null
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) return Mapper.convertToCinema(reader);
                    return null;
                }
            }
        }

        public IEnumerable<CinemaDAL> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT [Id],[Nom],[Ville] FROM [Cinema]";
                    connection.Open();
                    // Cette méthode nécéssite un Return  
                    // Execute Reader car attend un retour de 3 informations. => Création d'un reader + while tant que tu read, retourne la conversion du mapper sinon renvoie null
                    // Faire un Yield return pour faire une boucle de chaque élément récupéré !
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) yield return Mapper.convertToCinema(reader);
                }
            }
        }

        public int Insert(CinemaDAL entity)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    // AVEC PROCEDURE STOCKEE (1. Définir le Type // 2. appeler la procédure stockée)
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.CommandText = "SP_Film_Insert";
                    //SqlParameter p_nom = new SqlParameter("nom", entity.Nom);
                    //SqlParameter p_ville = new SqlParameter("ville", entity.Ville);
                    //cmd.Parameters.Add(p_nom);
                    //cmd.Parameters.Add(p_ville);

                    // OUTPUT pour récupérer l'ID qui a été créé automatiquement via l'incrémentation
                    //cmd.CommandText = "INSERT INTO [Cinema] ([Nom],[Ville]) OUTPUT [inserted].[Id] VALUES (@nom, @ville)";
                    SqlParameter p_nom = new SqlParameter() { ParameterName= "nom", Value = entity.Nom };
                    SqlParameter p_ville = new SqlParameter() { ParameterName= "ville", Value = entity.Ville };
                    cmd.Parameters.Add(p_nom);
                    cmd.Parameters.Add(p_ville);
                    connection.Open();
                    // Cette méthode nécéssite un Return car attend un retour en INT donc il faut parser (int) 
                    // Execute Scalar car attente d'une seule réponse. (retour d'un objet donc besoin de parser en int pour récupérer le bon retour)
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(int idCinema, CinemaDAL entity)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE [Cinema] SET [Nom] = @nom, [Ville] = @ville WHERE [Id] = @idCinema";
                    SqlParameter p_nom = new SqlParameter() { ParameterName = "nom", Value = entity.Nom };
                    SqlParameter p_ville = new SqlParameter() { ParameterName = "ville", Value = entity.Ville };
                    SqlParameter p_id = new SqlParameter() { ParameterName = "id", Value = idCinema };
                    cmd.Parameters.Add(p_nom);
                    cmd.Parameters.Add(p_ville);
                    cmd.Parameters.Add(p_id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        IEnumerable<CinemaDAL> ICinemaRepository<CinemaDAL>.GetByDiffusion(int id_movie, DateTime DateDiffusion)
        {
            throw new NotImplementedException();
        }

        IEnumerable<CinemaDAL> ICinemaRepository<CinemaDAL>.GetByFilm(int id_movie)
        {
            throw new NotImplementedException();
        }
    }
}
