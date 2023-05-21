using IngaCode.Application.Extensions;
using IngaCode.Application.Interfaces;
using IngaCode.Domain.Entities;
using IngaCode.Infrastructure.Repository;
using IngaCode.Infrastructure.UnitOfWork;

namespace IngaCode.Application.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected IRepository<T> _repo;
        protected IUnitOfWork _uow;
        public BaseService(IUnitOfWork uow)
        {
            _repo = uow.GetRepository<T>();
            _uow = uow;
        }


        public async Task<T> Post(T obj, CancellationToken cancellationToken)
        {
  
            await _repo.AdicionarAsync(obj, cancellationToken);
            return obj;
        }
        public async Task<T> Put(T obj, CancellationToken cancellationToken)
        {
            await _repo.AlterarAsync(obj, cancellationToken);
            return obj;
        }
        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            await _repo.ExcluirAsync(id,cancellationToken);
        }
        public async Task<T> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await _repo.ObterPorIdAsync(id, cancellationToken);
        }
       
        public async Task<IEnumerable<T>> Get(CancellationToken cancellationToken)
        {
            return await _repo.Obter(cancellationToken);

        }
    }
}
