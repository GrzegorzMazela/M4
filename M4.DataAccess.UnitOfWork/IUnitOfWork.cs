using System;
using System.Threading.Tasks;

namespace M4.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int Save();

        Task<int> SaveAsync();
    }
}