using System;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity entity);

        void Commit();

        void Delete(Func<TEntity, bool> predicate);

        void Edit(TEntity entity);

        TEntity Find(params object[] key);

        TEntity First(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> where);

        IQueryable<TEntity> GetAll();
    }
}