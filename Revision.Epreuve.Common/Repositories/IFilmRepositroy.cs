using Revision.Epreuve.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Revision.Epreuve.Common.RepositoriesDAO
{
    public interface IFilmRepository<TFilm> : IRepository<TFilm, int>,
        IGetByDiffusionRepository<TFilm>
    {
        public IEnumerable<TFilm> GetByYear(int year);
    }
}
