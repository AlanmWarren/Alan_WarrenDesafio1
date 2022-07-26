using Domain.Services.Interfaces;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Infrastructure.Data.Context;
using System;

namespace Domain.Services;

public abstract class ServiceBase : IServiceBase
{
    protected IRepositoryFactory RepositoryFactory { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public ServiceBase(
        IRepositoryFactory<DataContext> repositoryFactory,
        IUnitOfWork<DataContext> unitOfWork
    )
    {
        UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        RepositoryFactory = repositoryFactory ?? (IRepositoryFactory)UnitOfWork;
    }

    #region IDisposable Members

    private bool _disposed;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                if (RepositoryFactory is IDisposable repositoryFactory)
                {
                    repositoryFactory.Dispose();
                }

                UnitOfWork.Dispose();
            }

            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion IDisposable Members
}
