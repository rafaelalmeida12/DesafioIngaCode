using IngaCode.Application.Interfaces;
using IngaCode.Domain.Entities;
using IngaCode.Infrastructure.Repository;
using IngaCode.Infrastructure.UnitOfWork;

namespace IngaCode.Application.Services
{
    public class TasksService : BaseService<Tasks>, ITasksService
    {
        private readonly IRepository<Tasks> _repository;
        public TasksService(IRepository<Tasks> repository, IUnitOfWork uow) : base(uow)
        {
            _repository=repository;
        }

        public Tasks ObterComObjetosRelacionados(Guid id, CancellationToken cancellationToken)
        {
            return _repository.ObterComObjetosRelacionados(o => o.Id == id, x => x.Trackers);
        }
    }
}
