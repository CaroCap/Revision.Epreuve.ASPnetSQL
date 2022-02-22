using Revision.Epreuve.Common.Repositories;
using Revision.Epreuve.DAL.EntitiesDTO;
using Revision.Epreuve.DAL.Handlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Revision.Epreuve.DAL.RepositoriesDAO
{
    public class DiffusionService : ServiceBase, IDiffusionRepository<DiffusionDAL>
    {
        public void Delete(int idVar)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                // Création de la commande
                using (SqlCommand command = connection.CreateCommand())
                {
                    // écrire la commande
                    command.CommandText = "DELETE FROM [Diffusion] WHERE [Id] = @idParam";
                    // Préciser les paramètres
                    SqlParameter p_id = new SqlParameter() { ParameterName = "idParam", Value = idVar };
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

        public DiffusionDAL Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT [Id],[Cinema_Id],[Film_Id],[Date_Diffusion] FROM [Diffusion] WHERE [Id] = @id";
                    SqlParameter p_id = new SqlParameter() { ParameterName = "id", Value = id };
                    cmd.Parameters.Add(p_id);
                    connection.Open();
                    // Cette méthode nécéssite un Return  
                    // Execute Reader car attend un retour de 3 informations. => Création d'un reader + while tant que tu read, retourne la conversion du mapper sinon renvoie null
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) return Mapper.convertToDiffusion(reader);
                    return null;
                }
            }
        }

        public IEnumerable<DiffusionDAL> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT [Id],[Cinema_Id],[Film_Id],[Date_Diffusion] FROM [Diffusion]";
                    connection.Open();
                    // Cette méthode nécéssite un Return  
                    // Execute Reader car attend un retour de 3 informations. => Création d'un reader + while tant que tu read, retourne la conversion du mapper sinon renvoie null
                    // Faire un Yield return pour faire une boucle de chaque élément récupéré !
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) yield return Mapper.convertToDiffusion(reader);
                }
            }
        }

        public IEnumerable<DiffusionDAL> GetByCinemaID(int cinema_id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DiffusionDAL> GetByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DiffusionDAL> GetByFilmId(int film_id)
        {
            throw new NotImplementedException();
        }

        public int Insert(DiffusionDAL entity)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {

                    // OUTPUT pour récupérer l'ID qui a été créé automatiquement via l'incrémentation
                    cmd.CommandText = "INSERT INTO [Diffusion] ([Cinema_Id],[Film_Id], [Date_Diffusion) OUTPUT [inserted].[Id] VALUES (@cinema_id, @film_id, @dateDiffusion)";
                    SqlParameter p_cine = new SqlParameter() { ParameterName = "cinema_id", Value = entity.Cinema_Id };
                    SqlParameter p_film = new SqlParameter() { ParameterName = "film_id", Value = entity.Film_Id };
                    SqlParameter p_dateDiff = new SqlParameter() { ParameterName = "dateDiffusion", Value = entity.Date_Diffusion };
                    cmd.Parameters.Add(p_cine);
                    cmd.Parameters.Add(p_film);
                    cmd.Parameters.Add(p_dateDiff);
                    connection.Open();
                    // Cette méthode nécéssite un Return car attend un retour en INT donc il faut parser (int) 
                    // Execute Scalar car attente d'une seule réponse. (retour d'un objet donc besoin de parser en int pour récupérer le bon retour)
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(int id, DiffusionDAL entity)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE [Diffusion] SET [Cinema_Id] = @cinema_Id, [Film_Id] = @film_Id, [Date_Diffusion] = @dateDiffusion WHERE [Id] = @idCinema";
                    SqlParameter p_cine = new SqlParameter() { ParameterName = "cinema_Id", Value = entity.Cinema_Id };
                    SqlParameter p_film = new SqlParameter() { ParameterName = "film_Id", Value = entity.Film_Id };
                    SqlParameter p_diff = new SqlParameter() { ParameterName = "dateDiffusion", Value = entity.Date_Diffusion };
                    SqlParameter p_id = new SqlParameter() { ParameterName = "idCinema", Value = id };
                    cmd.Parameters.Add(p_cine);
                    cmd.Parameters.Add(p_film);
                    cmd.Parameters.Add(p_diff);
                    cmd.Parameters.Add(p_id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
