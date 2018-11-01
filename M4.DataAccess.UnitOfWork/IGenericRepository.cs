using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace M4.DataAccess.UnitOfWork
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        bool Any(Expression<Func<TEntity, bool>> where);

        IQueryable<TEntity> AsQueryable();

        void Delete(TEntity entity);

        void Delete(Expression<Func<TEntity, bool>> where);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> where);

        TEntity First(Expression<Func<TEntity, bool>> where);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where);

        IEnumerable<TEntity> GetAll();

        TEntity Single(Expression<Func<TEntity, bool>> where);

        void Update(TEntity entity);
    }
}