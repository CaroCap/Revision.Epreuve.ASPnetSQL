using System;
using System.Collections.Generic;
using System.Text;

namespace Revision.Epreuve.BLL.Entities
{
    public class CinemaBLL
    {
        // Même que la DAL
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Ville { get; set; }

        // +++
        public IEnumerable<DiffusionBLL> Diffusions { get; set; }

        // Constructor
        public CinemaBLL(int id, string nom, string ville)
        {
            Id = id;
            Nom = nom;
            Ville = ville;
        }

        public void AddDiffusion(DateTime dateDiffusion, FilmBLL film)
        {
            throw new NotImplementedException();
        }

        public void CancelDiffusion(DiffusionBLL diffusion)
        {
            throw new NotImplementedException();
        }
    }
}
