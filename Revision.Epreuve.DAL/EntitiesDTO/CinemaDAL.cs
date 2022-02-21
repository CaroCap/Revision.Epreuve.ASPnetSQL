// Créer une classe par Table de ma DB
// Supprimer les using inutiles 
// Mettre la class en PUBLIC
// Créer une propriété par colonne de la Table

namespace Revision.Epreuve.DAL.EntitiesDTO
{
    public class CinemaDAL
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Ville { get; set; }

    }
}
