using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace M4.DataAccess.UnitOfWork.EFCore
{
    public abstract class BaseUnitOfWork : BaseUnitOfWork<DbContext>
    {
        public BaseUnitOfWork(DbContext context, bool supportTransaction = true, bool autoDispose = false)
            : base(context, supportTransaction, autoDispose)
        {
        }
    }

    public abstract class BaseUnitOfWork<TContext>
     : IUnitOfWorkTransaction
     where TContext : DbContext
    {
        protected readonly TContext context;
        protected readonly bool supportTransaction;
        protected readonly bool autoDispose;

        public BaseUnitOfWork(TContext context, bool supportTransaction = true, bool autoDispose = false)
        {
            this.context = context;
            this.supportTransaction = supportTransaction;
            this.autoDispose = autoDispose;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return supportTransaction ? context.Database.BeginTransaction() : new FakeTransaction();
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing && autoDispose)
                {
                    context.Dispose();
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