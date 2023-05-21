using IngaCode.Application.Interfaces;
using IngaCode.Domain.Entities;
using IngaCode.Infrastructure.Repository;
using IngaCode.Infrastructure.UnitOfWork;

namespace IngaCode.Application.Services
{
    public class ProjectsService : BaseService<Projects>, IProjectsService
    {
        private readonly IRepository<Projects> _repository;
        public ProjectsService(IRepository<Projects> repository, IUnitOfWork uow) : base(uow)
        {

        }
    }
}
