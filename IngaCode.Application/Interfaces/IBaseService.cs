using IngaCode.Domain.Entities;

namespace IngaCode.Application.Interfaces
{
    public interface IBaseService<T> where T : BaseEntity
    {

        Task<IEnumerable<T>> Get(CancellationToken cancellationToken);
        Task<T> Post(T obj, CancellationToken cancellationToken);
        Task<T> Put(T obj, CancellationToken cancellationToken);
        Task<T> GetById(Guid id, CancellationToken cancellationToken);
        Task Delete(Guid id, CancellationToken cancellationToken);

        //Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        //Task<IEnumerable<T>> ObterMuitosAsync(Func<T, bool> predicate);
        //IEnumerable<T> Get();
    }
}
