using IngaCode.Domain.Entities;

namespace IngaCode.Application.Interfaces
{
    public interface ICollaboratorsService : IBaseService<Collaborators>
    {
        Task<bool> GetByName(string name, CancellationToken cancellationToken);
    }
}
