using IngaCode.Domain.Entities;

namespace IngaCode.Application.Models.InputModels
{
    public class TaskInputModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProjectId { get; set; }
        public Tasks ToEntity()
        {
            var task = new Tasks
            {
                Name = this.Name,
                Description = this.Description,
                ProjectId = this.ProjectId,
            };
            return task;
        }
    }
}
