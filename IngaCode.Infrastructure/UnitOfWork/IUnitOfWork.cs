
using IngaCode.Domain.Entities;
using IngaCode.Infrastructure.Context;
using IngaCode.Infrastructure.Repository;

namespace IngaCode.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        String CurrentUser { get; }
        IngaCodeContext Context { get; }
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        void Commit();
    }
}
