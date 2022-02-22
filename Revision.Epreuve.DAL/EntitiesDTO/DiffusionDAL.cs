using System;

namespace Revision.Epreuve.DAL.EntitiesDTO
{
    public class DiffusionDAL
    {
        public int Id { get; set; }
        public int Cinema_Id { get; set; }
        public int Film_Id { get; set; }
        public DateTime? Date_Diffusion { get; set; }

    }
}
