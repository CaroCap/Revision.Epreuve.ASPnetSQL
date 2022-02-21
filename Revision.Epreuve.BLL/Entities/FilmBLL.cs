using System;

namespace Revision.Epreuve.BLL.Entities
{
    public class FilmBLL
    {
        // Même que la DAL
        public int Id { get; set; }

        // On va ajouter Contrôle Taille du titre
        private string _titre;
        public string Titre { 
            get { return _titre; } 
            set { 
                // .Trim() = pour supprimer espaces blancs avant et après la valeurs
                string newTitre = value.Trim();
                // Si null ou vide
                if (string.IsNullOrEmpty(newTitre)) throw new ArgumentException(nameof(newTitre));
                // Si plus grand que la capacité du champs de la DB
                if (newTitre.Length > 128) throw new ArgumentOutOfRangeException(nameof(newTitre));
                // Sinon
                _titre = newTitre;
            } 
        }
        public DateTime DateSortie { get; set; }

        // +++
        //public IEnumerable<FilmBLL> Films { get; set; }

        // Constructor
        public FilmBLL(int id, string titre, DateTime dateSorte)
        {
            Id = id;
            Titre = titre;
            DateSortie = dateSorte;
        }

        // Ajout de Méthode pour changer date sortie
        public void ReportMovieRelease(DateTime newDate)
        {
            DateSortie = newDate;
        }
    }
}