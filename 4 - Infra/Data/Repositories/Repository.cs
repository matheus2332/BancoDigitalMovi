using System;
using System.Linq;
using System.Linq.Expressions;
using Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ContextApplication _contextApplication;

        public Repository(ContextApplication contextApplication)
        {
            _contextApplication = contextApplication;
        }

        public void Add(TEntity entity)
        {
            _contextApplication.Set<TEntity>().Add(entity);
        }

        public void Commit()
        {
            _contextApplication.SaveChanges();
        }

        public void Delete(Func<TEntity, bool> predicate)
        {
            _contextApplication.Set<TEntity>()
                .Where(predicate).ToList()
                .ForEach(del => _contextApplication.Set<TEntity>().Remove(del));
        }

        public void Dispose()
        {
            if (_contextApplication != null)
            {
                _contextApplication.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        public void Edit(TEntity entity)
        {
            _contextApplication.Entry(entity).State = EntityState.Modified;
        }

        public TEntity Find(params object[] key)
        {
            return _contextApplication.Set<TEntity>().Find(key);
        }

        public TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            return _contextApplication.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> whereCondition) => _contextApplication.Set<TEntity>().Where(whereCondition);

        public IQueryable<TEntity> GetAll() => _contextApplication.Set<TEntity>();
    }
}