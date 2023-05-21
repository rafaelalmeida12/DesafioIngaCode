using Microsoft.EntityFrameworkCore;
using IngaCode.Infrastructure.UnitOfWork;
using IngaCode.Domain.Entities;
using System.Linq.Expressions;
using IngaCode.Infrastructure.Extensions;

namespace IngaCode.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AdicionarAsync(T entity, CancellationToken cancellationToken)
        {
            await _unitOfWork.Context.Set<T>().AddAsync(entity, cancellationToken);
            await _unitOfWork.Context.SaveChangesAsync(cancellationToken);
        }
        public async Task AlterarAsync(T entity, CancellationToken cancellationToken)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Context.Set<T>().Update(entity);
            await _unitOfWork.Context.SaveChangesAsync(cancellationToken);

        }
        public async Task<T> ObterPorIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Context.Set<T>().FindAsync(id);
        }
        public async Task ExcluirAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await ObterPorIdAsync(id, cancellationToken);
            _unitOfWork.Context.Set<T>().Remove(entity);
            await _unitOfWork.Context.SaveChangesAsync(cancellationToken);
        }
        public async Task<IEnumerable<T>> Obter(CancellationToken cancellationToken)
        {
            return await _unitOfWork.Context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
        }
        public T ObterComObjetosRelacionados(Func<T, bool> firstOrDefault,
            params Expression<Func<T, object>>[] properties)
        {
            if (properties == null)
                throw new ArgumentNullException(nameof(properties));

            var query = _unitOfWork.Context.Set<T>() as IQueryable<T>;

            var propertiesAsPath = new List<string>();

            properties.ToList().ForEach(property => { propertiesAsPath.Add(ExpressionExtensions.AsPath(property)); });

            query = propertiesAsPath.Aggregate(query, (current, property) => current.Include(property));

            return query.AsNoTracking().AsNoTracking().FirstOrDefault(firstOrDefault);
        }
        public void Dispose()
        {
            _unitOfWork.Context.Dispose();
        }
    }
}
