using System;
using System.Collections.Generic;
using System.Text;

namespace Revision.Epreuve.Common.Repositories
{
    //public interface IRepository<TEntity>
    //{
    //    IEnumerable<TEntity> GetAll();
    //    //Dans ce cas-ci, on sait que tous nos id sont des int sinon on aurait dû ajouter un TId dans la généricité
    //    TEntity Get(int id);
    //}


    // ! Faire hériter IRepository avec IGetRepository pour récupérer le GetAll et le GetById
    public interface IRepository<TEntity, TId> : IGetRepository<TEntity, TId>
    {
        //// Déplacé dans IGetRepository
        //IEnumerable<TEntity> GetAll();
        ////Dans ce cas-ci, on sait que tous nos id sont des int sinon il faut ajouter un TId dans la généricité
        //TEntity Get(TId id);
        TId Insert(TEntity entity);
        void Delete(TId id);
        void Update(TId id, TEntity entity);

    }
}
