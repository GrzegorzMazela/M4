using M4.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace M4.BusinessLogic.CQS
{
    public abstract class Base
    {
        //private readonly TUnitOfWorkFactory unitOfWorkFactory;

        //protected async Task RunCodeAsync<TUnitOfWork>(string methodName, Func<TUnitOfWork, Task> action, IsolationLevel? isolationLevel = null)
        //    where TUnitOfWork : class, IUnitOfWork
        //{
        //    using (var uow = unitOfWorkFactory.CreateUnitOfWorkInstance<TUnitOfWork>())
        //    using (var transaction = uow.BeginTransaction(isolationLevel))
        //    {
        //        try
        //        {
        //            await action(uow);
        //            transaction.Commit();
        //        }
        //        catch (Exception)
        //        {
        //            transaction.Rollback();
        //            throw;
        //        }
        //        finally
        //        {
        //            transaction.Dispose();
        //        }
        //    }
        //}
    }
}
