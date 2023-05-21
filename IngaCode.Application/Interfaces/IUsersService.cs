using IngaCode.Domain.Entities;

namespace IngaCode.Application.Interfaces
{
    public interface IUsersService : IBaseService<Users>
    {
        Task<bool> GetByName(string name, CancellationToken cancellationToken);
    }
}
