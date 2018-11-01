using Microsoft.Extensions.Logging;

namespace M4.DataAccess.UnitOfWork
{
    public interface IUnitOfWorkWithLoggerFactory : IUnitOfWorkFactory
    {
        ILoggerFactory GetLoggerFactory();
    }
}