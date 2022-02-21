using Revision.Epreuve.BLL.Entities;
using Revision.Epreuve.DAL.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Revision.Epreuve.BLL.Handlers
{
    public static class Mapper
    {
        public static CinemaBLL ToBLL(this CinemaDAL entity)
        {
            if (entity == null) return null;
            // Si pas null => on renvoie un objet CinemaBLL grâce au constructeur
            return new CinemaBLL(
                entity.Id,
                entity.Nom,
                entity.Ville
                );
        }

        public static CinemaDAL ToDAL(this CinemaBLL entity)
        {
            if(entity == null) return null;
            // Pas de constructeur donc on doit utiliser les { }
            return new CinemaDAL
            {
                Id = entity.Id,
                Nom = entity.Nom,
                Ville = entity.Ville
            };
        }

        public static FilmBLL ToBLL(this FilmDAL entity)
        {
            if (entity == null) return null;
            // Si pas null => on renvoie un objet CinemaBLL grâce au constructeur
            return new FilmBLL(
                entity.Id,
                entity.Titre,
                entity.DateSortie
                );
        }

        public static FilmDAL ToDAL(this FilmBLL entity)
        {
            if (entity == null) return null;
            // Pas de constructeur donc on doit utiliser les { }
            return new FilmDAL
            {
                Id = entity.Id,
                Titre = entity.Titre,
                DateSortie = entity.DateSortie
            };
        }

        // Pour le Mapper Diffusion on aura besoin des Services
        public static DiffusionBLL ToBLL(this DiffusionDAL entity)
        {
            if (entity == null) return null;
            // Si pas null => on renvoie un objet CinemaBLL grâce au constructeur
            return new DiffusionBLL(
                entity.Id,
                entity.Date_Diffusion,
                //null en attendant de pouvoir utiliser le service
                null,
                null
                );
        }

        public static DiffusionDAL ToDAL(this DiffusionBLL entity)
        {
            if (entity == null) return null;
            // Pas de constructeur donc on doit utiliser les { }
            return new DiffusionDAL
            {
                Id = entity.Id,
                Date_Diffusion = entity.Date_Diffusion,
                // On peut récupérer les Id des Objets qu'on a créé dans la class entity
                Cinema_Id = entity.Cinema.Id,
                Film_Id = entity.Film.Id
            };
        }
    }
}
