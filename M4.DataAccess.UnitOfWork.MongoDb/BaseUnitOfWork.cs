using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace M4.DataAccess.UnitOfWork.MongoDb
{
    public class BaseUnitOfWork : IUnitOfWork
    {
        protected IMongoDatabase _mongoDatabase { get; set; }

        public BaseUnitOfWork(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }


        public int Save()
        {
            return 1;
        }

        public async Task<int> SaveAsync()
        {
            return 1;
        }

        protected IMongoCollection<TEntity> GetCollection<TEntity>() where TEntity : class, IBaseEntity
        {
            var collectionName = typeof(TEntity).Name;
            return _mongoDatabase.GetCollection<TEntity>(collectionName);
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _mongoDatabase = null;
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion IDisposable Support
    }
}
