using System;
using System.Collections.Generic;
using System.Text;

namespace Revision.Epreuve.Common.Repositories
{
    public interface IDiffusionRepository<TDiffusion> : IRepository<TDiffusion, int>
    {
        public IEnumerable<TDiffusion> GetByDate(DateTime date);
        public IEnumerable<TDiffusion> GetByCinemaID(int cinema_id);
        public IEnumerable<TDiffusion> GetByFilmId(int film_id);

    }
}
