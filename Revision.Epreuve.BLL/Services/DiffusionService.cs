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
    public class DiffusionService : IDiffusionRepository<DiffusionBLL>
    {
        private readonly IDiffusionRepository<DiffusionDAL> _diffusionRepository;

        public DiffusionService(IDiffusionRepository<DiffusionDAL> repository)
        {
            _diffusionRepository = repository;
        }

        public void Delete(int id)
        {
            _diffusionRepository.Delete(id);
        }

        public DiffusionBLL Get(int id)
        {
            return _diffusionRepository.Get(id).ToBLL();
        }

        public IEnumerable<DiffusionBLL> GetAll()
        {
            return _diffusionRepository.GetAll().Select(d => d.ToBLL());

        }

        public IEnumerable<DiffusionBLL> GetByCinemaID(int cinema_id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DiffusionBLL> GetByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DiffusionBLL> GetByFilmId(int film_id)
        {
            throw new NotImplementedException();
        }

        public int Insert(DiffusionBLL entity)
        {
            return _diffusionRepository.Insert(entity.ToDAL());
        }

        public void Update(int id, DiffusionBLL entity)
        {
            _diffusionRepository.Update(id, entity.ToDAL());
        }
    }
}
