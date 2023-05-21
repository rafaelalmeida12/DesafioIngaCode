using IngaCode.Domain.Entities;
using System.Linq.Expressions;

namespace IngaCode.Infrastructure.Repository
{
    public interface IRepository<T> : IDisposable where T : BaseEntity
    {
        Task AdicionarAsync(T entity, CancellationToken cancellationToken);
        Task AlterarAsync(T entity, CancellationToken cancellationToken);
        Task<T> ObterPorIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> Obter(CancellationToken cancellationToken);
        Task ExcluirAsync(Guid id, CancellationToken cancellationToken);
        T ObterComObjetosRelacionados(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
    }

}
