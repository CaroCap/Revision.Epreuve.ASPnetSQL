using Revision.Epreuve.BLL.Entities;
using Revision.Epreuve.BLL.Handlers;
using Revision.Epreuve.Common.Repositories;
using Revision.Epreuve.DAL.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Revision.Epreuve.BLL.Services
{
    public class CinemaService : ICinemaRepository<CinemaBLL>
    {
        private readonly ICinemaRepository<CinemaDAL> _cinemaRepository;

        public CinemaService(ICinemaRepository<CinemaDAL> repository)
        {
            _cinemaRepository = repository;
        }

        public void Delete(int id)
        {
            _cinemaRepository.Delete(id);
        }

        public CinemaBLL Get(int id)
        {
            return _cinemaRepository.Get(id).ToBLL();
        }

        public IEnumerable<CinemaBLL> GetAll()
        {
            return _cinemaRepository.GetAll().Select(c=>c.ToBLL());
        }

        public IEnumerable<CinemaBLL> GetByDiffusion(int id_movie, DateTime DateDiffusion)
        {
            return _cinemaRepository.GetByDiffusion(id_movie, DateDiffusion).Select(c=>c.ToBLL());
        }

        public IEnumerable<CinemaBLL> GetByFilm(int id_movie)
        {
            return _cinemaRepository.GetByFilm(id_movie).Select(c => c.ToBLL());
        }

        public int Insert(CinemaBLL entity)
        {
            return _cinemaRepository.Insert(entity.ToDAL());
        }

        public void Update(int id, CinemaBLL entity)
        {
            _cinemaRepository.Update(id, entity.ToDAL());
        }
    }
}
