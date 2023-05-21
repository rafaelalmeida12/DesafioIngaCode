using Azure.Core;
using IngaCode.Application.Interfaces;
using IngaCode.Domain.Entities;
using IngaCode.Infrastructure.Repository;
using IngaCode.Infrastructure.UnitOfWork;
using System.Net;

namespace IngaCode.Application.Services
{
    public class TimeTrackersService : BaseService<TimeTrackers>, ITimeTrackersService
    {
        private readonly IRepository<TimeTrackers> _repository;
        public TimeTrackersService(IRepository<TimeTrackers> repository, IUnitOfWork uow) : base(uow)
        {

        }
     
    }
}
