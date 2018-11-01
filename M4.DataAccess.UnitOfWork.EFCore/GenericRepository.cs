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
        protected readonly TContext ctx;
        protected readonly DbSet<TEntity> dbSet;

        public GenericRepository(TContext ctx)
        {
            this.ctx = ctx;
            dbSet = ctx.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            if (entity == null) return;
            dbSet.Add(entity);
        }

        public virtual bool Any(Expression<Func<TEntity, bool>> where)
        {
            return dbSet.Any(where);
        }

        public virtual IQueryable<TEntity> AsQueryable()
        {
            return dbSet.AsQueryable();
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null) return;

            if (ctx.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            var itemsToDelete = dbSet.Where(where);
            dbSet.RemoveRange(itemsToDelete);
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> where)
        {
            return dbSet.Where(where);
        }

        public virtual TEntity First(Expression<Func<TEntity, bool>> where)
        {
            return dbSet.First(where);
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where)
        {
            return dbSet.FirstOrDefault(where);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public virtual TEntity Single(Expression<Func<TEntity, bool>> where)
        {
            return dbSet.Single(where);
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null) return;
            ctx.Entry(entity).State = EntityState.Modified;
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