using System;
using System.Collections.Generic;
using System.Text;

namespace Revision.Epreuve.BLL.Entities
{
    public class DiffusionBLL
    {
        // Même que la DAL
        public int Id { get; set; }

        // Plus besoin des ID Cinema et Film car dans BLL on peut récupérer l'objet lui même et pas juste son ID
        //public int Cinema_Id { get; set; }
        //public int Film_Id { get; set; }

        public DateTime Date_Diffusion { get; set; }

        // +++
        // On crée des objets Cinema et Film pour remplacer IDs
        public CinemaBLL Cinema { get; set; }
        public FilmBLL Film { get; set; }

        // Constructor
        public DiffusionBLL(int id, DateTime dateDiff, CinemaBLL cinema, FilmBLL film)
        {
            // On peut ajouter des vérifications dans la construction
            if (Film.DateSortie > dateDiff) throw new ArgumentException();
            Id = id;
            Date_Diffusion = dateDiff;  
            Cinema = cinema;
            Film = film;
        }
    }
}
