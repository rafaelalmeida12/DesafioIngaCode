using IngaCode.Application.Interfaces;
using IngaCode.Domain.Entities;
using IngaCode.Infrastructure.Repository;
using IngaCode.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace IngaCode.Application.Services
{
    public class UsersService : BaseService<Users>, IUsersService
    {
        private readonly IRepository<Users> _repository;
        public UsersService(IRepository<Users> repository, IUnitOfWork uow) : base(uow)
        {

        }


        public async Task<bool> GetByName(string name, CancellationToken cancellationToken)
        {
            return await _uow.Context.User.AnyAsync(c => c.UserName == name);
        }
    }
}
