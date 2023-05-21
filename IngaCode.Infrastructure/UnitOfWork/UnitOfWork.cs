using IngaCode.Domain.Entities;
using IngaCode.Infrastructure.Context;
using IngaCode.Infrastructure.Repository;

namespace IngaCode.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IngaCodeContext Context { get; }
        public string CurrentUser { get; set; }

        public UnitOfWork(IngaCodeContext context)
        {
            Context = context;
            CurrentUser = Environment.UserName;
            //CurrentUser = httpContextAccessor?.HttpContext?.User?.FindFirst("cpf")?.Value; 
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(this);
        }
    }
}
