using IngaCode.Domain.Entities;

namespace IngaCode.Application.Models.InputModels
{
    public class ProjectInputModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Projects ToEntity()
        {
            var project = new Projects
            {
                Name = this.Name,

            };
            return project;
        }
    }
}
