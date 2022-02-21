using System;
using System.Collections.Generic;
using System.Text;

namespace Revision.Epreuve.Common.Repositories
{
    public interface IGetRepository<TEntity, TId>
    {
        IEnumerable<TEntity> GetAll();
        //Dans ce cas-ci, on sait que tous nos id sont des int sinon il faut ajouter un TId dans la généricité
        TEntity Get(TId id);
    }
}
