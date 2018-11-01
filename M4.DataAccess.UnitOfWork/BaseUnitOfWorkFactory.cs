using Microsoft.Extensions.DependencyInjection;
using System;

namespace M4.DataAccess.UnitOfWork
{
    public class BaseUnitOfWorkFactory : IUnitOfWorkFactory
    {
        protected readonly IServiceProvider serviceProvider;

        public BaseUnitOfWorkFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        TUnitOfWork IUnitOfWorkFactory.CreateUnitOfWorkInstance<TUnitOfWork>() => serviceProvider.GetService<TUnitOfWork>();
    }
}