using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace M4.DataAccess.UnitOfWork.MongoDb
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IBaseEntity
    {
        protected IMongoCollection<TEntity> _mongoCollection { get; set; }

        public GenericRepository(IMongoCollection<TEntity> mongoCollection)
        {
            _mongoCollection = mongoCollection;
        }

        public void Add(TEntity entity)
        {
            _mongoCollection.InsertOne(entity);
        }

        public bool Any(Expression<Func<TEntity, bool>> where)
        {
            return _mongoCollection.Find(where).Any();
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _mongoCollection.AsQueryable();
        }

        public void Delete(TEntity entity)
        {
            _mongoCollection.DeleteOne(x => x.Id == entity.Id);
        }

        public void Delete(Expression<Func<TEntity, bool>> where)
        {
            _mongoCollection.DeleteMany(where);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> where)
        {
            return _mongoCollection.Find(where).ToList();
        }

        public TEntity First(Expression<Func<TEntity, bool>> where)
        {
            return _mongoCollection.Find(where).First();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where)
        {
            return _mongoCollection.Find(where).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _mongoCollection.Find(Builders<TEntity>.Filter.Empty).ToList();
        }

        public TEntity Single(Expression<Func<TEntity, bool>> where)
        {
            return _mongoCollection.Find(Builders<TEntity>.Filter.Empty).Single();
        }

        public void Update(TEntity entity)
        {
            _mongoCollection.ReplaceOne(x => x.Id == entity.Id, entity);
        }


    }
}
