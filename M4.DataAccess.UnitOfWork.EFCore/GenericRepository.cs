using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace M4.DataAccess.UnitOfWork.EFCore
{
    public class GenericRepository<TEntity, TContext>
        : IGenericRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        protected readonly TContext _ctx;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(TContext ctx)
        {
            _ctx = ctx;
            _dbSet = ctx.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            if (entity == null) return;
            _dbSet.Add(entity);
        }

        public virtual bool Any(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.Any(where);
        }

        public virtual IQueryable<TEntity> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null) return;

            if (_ctx.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            var itemsToDelete = _dbSet.Where(where);
            _dbSet.RemoveRange(itemsToDelete);
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.Where(where);
        }

        public virtual TEntity First(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.First(where);
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.FirstOrDefault(where);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public virtual TEntity Single(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.Single(where);
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null) return;
            _ctx.Entry(entity).State = EntityState.Modified;
        }
    }

    public class GenericRepository<TEntity>
        : GenericRepository<TEntity, DbContext>, IGenericRepository<TEntity>
        where TEntity : class
    {
        public GenericRepository(DbContext ctx) : base(ctx)
        {
        }
    }
}