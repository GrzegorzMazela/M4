using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace M4.DataAccess.UnitOfWork
{
    public class BaseUnitOfWorkWithLoggerFactory : BaseUnitOfWorkFactory, IUnitOfWorkWithLoggerFactory
    {
        public BaseUnitOfWorkWithLoggerFactory(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public ILoggerFactory GetLoggerFactory() => serviceProvider.GetService<ILoggerFactory>();
    }
}
