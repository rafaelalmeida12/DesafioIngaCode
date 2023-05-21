using IngaCode.Domain.Entities;

namespace IngaCode.Application.Interfaces
{
    public interface ITasksService : IBaseService<Tasks>
    {
        Tasks ObterComObjetosRelacionados(Guid id, CancellationToken cancellationToken);
    }
}
