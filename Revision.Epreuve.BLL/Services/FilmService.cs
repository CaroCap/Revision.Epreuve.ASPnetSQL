﻿using Revision.Epreuve.BLL.Entities;
using Revision.Epreuve.BLL.Handlers;
using Revision.Epreuve.Common.Repositories;
using Revision.Epreuve.DAL.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Revision.Epreuve.BLL.Services
{
    public class FilmService : IRepository<FilmBLL, int>
    {
        // Pour communiquer avec DAL il va falloir utiliser les services de la DAL
        private readonly IRepository<FilmDAL, int> _filmRepository;

        public FilmService(IRepository<FilmDAL, int> repository)
        {
            _filmRepository = repository;
        }

        // CRUD implémenté via interface (clic droit sur IRepository
        public void Delete(int id)
        {
            _filmRepository.Delete(id);
            // Pas besoin de Mapper car Service existe déjà dans DAL id est int des 2 côtés
        }

        public FilmBLL Get(int id)
        {
            return _filmRepository.Get(id).ToBLL();
        }

        public IEnumerable<FilmBLL> GetAll()
        {
            return _filmRepository.GetAll().Select( f => f.ToBLL() );
        }

        public int Insert(FilmBLL entity)
        {
            return _filmRepository.Insert(entity.ToDAL());
        }

        public void Update(int id, FilmBLL entity)
        {
            // Pas besoin de return car Void
            _filmRepository.Update(id, entity.ToDAL());
        }
    }
}
