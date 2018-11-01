using Microsoft.EntityFrameworkCore.Storage;

namespace M4.DataAccess.UnitOfWork.EFCore
{
    public interface IUnitOfWorkTransaction
    {
        IDbContextTransaction BeginTransaction();
    }
}