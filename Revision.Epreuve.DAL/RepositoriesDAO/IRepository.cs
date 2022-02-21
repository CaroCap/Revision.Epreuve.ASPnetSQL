using System;
using System.Collections.Generic;
using System.Text;

namespace Revision.Epreuve.DAL.RepositoriesDAO
{
    //public interface IRepository<TEntity>
    //{
    //    IEnumerable<TEntity> GetAll();
    //    //Dans ce cas-ci, on sait que tous nos id sont des int sinon on aurait dû ajouter un TId dans la généricité
    //    TEntity Get(int id);
    //}

    public interface IRepository<TEntity, TId>
    {
        IEnumerable<TEntity> GetAll();
        //Dans ce cas-ci, on sait que tous nos id sont des int sinon il faut ajouter un TId dans la généricité
        TEntity Get(TId id);
        TId Insert(TEntity entity);
        void Delete(TId id);
        void Update(TId id, TEntity entity);

    }
}
