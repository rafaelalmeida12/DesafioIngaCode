using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngaCode.Domain.Entities
{
    public class Tasks : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProjectId { get; set; }
        public Projects Project { get; set; }
        public List<TimeTrackers> Trackers { get; set; } = new List<TimeTrackers>();

        public void Update(string name, string description, Guid projectId)
        {
            Name = name;
            Description = description;
            ProjectId = projectId;
        }
    }
}
