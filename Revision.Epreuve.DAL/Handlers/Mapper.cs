using Revision.Epreuve.DAL.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Revision.Epreuve.DAL.Handlers
{
    // PUBLIC STATIC pour la classe et pour les méthodes !
    public static class Mapper
    {
        public static CinemaDAL convertToCinema(IDataRecord record)
        {
            if (record is null) return null;
            return new CinemaDAL
            {
                //Id = (int)record["Id"],
                //Nom = (string)record["Nom"],
                //Ville = (string)record["Ville"]
                // Pour éviter les erreurs de frappe et pouvoir changer le nom de la colonne sans tout casser, on va plutôt utiliser nameof
                Id = (int)record[nameof(CinemaDAL.Id)],
                Nom = (string)record[nameof(CinemaDAL.Nom)],
                Ville = (string)record[nameof(CinemaDAL.Ville)]
                // Si DB est NULLABLE alors il faut d'abord vérifier pour éviter les erreurs (Test si record nameof est null alors renvoi null sinon renvoie record nameof Parsé )
                // Ville = (record[nameof(CinemaDAL.Id) is DBNull)? null : (string?)record[nameof(CinemaDAL.Ville)]
            };
        }

        public static FilmDAL convertToFilm(IDataRecord record)
        {
            if (record is null) return null;
            return new FilmDAL
            {
                Id = (int)record[nameof(FilmDAL.Id)],
                Titre = (string)record[nameof(FilmDAL.Titre)],
                DateSortie = (DateTime)record[nameof(FilmDAL.DateSortie)]
                // Si DB est NULLABLE alors il faut d'abord vérifier pour éviter les erreurs (Test si record nameof est null alors renvoi null sinon renvoie record nameof Parsé )
                // Ville = (record[nameof(CinemaDAL.Id) is DBNull)? null : (string?)record[nameof(CinemaDAL.Ville)]
            };
        }

        public static DiffusionDAL convertToDiffusion(IDataRecord record)
        {
            if (record is null) return null;
            return new DiffusionDAL
            {
                Id = (int)record[nameof(DiffusionDAL.Id)],
                Cinema_Id = (int)record[nameof(DiffusionDAL.Cinema_Id)],
                Film_Id = (int)record[nameof(DiffusionDAL.Film_Id)],
                Date_Diffusion = (record[nameof(DiffusionDAL.Date_Diffusion) is DBNull)? null : (DateTime?)record[nameof(DiffusionDAL.Date_Diffusion)]
                // Si DB est NULLABLE alors il faut d'abord vérifier pour éviter les erreurs (Test si record nameof est null alors renvoi null sinon renvoie record nameof Parsé )
                // Ville = (record[nameof(CinemaDAL.Id) is DBNull)? null : (string?)record[nameof(CinemaDAL.Ville)]
            };
        }
    }
}
