namespace M4.DataAccess.UnitOfWork
{
    public interface IUnitOfWorkFactory
    {
        TUnitOfWork CreateUnitOfWorkInstance<TUnitOfWork>() where TUnitOfWork : class, IUnitOfWork;
    }
}