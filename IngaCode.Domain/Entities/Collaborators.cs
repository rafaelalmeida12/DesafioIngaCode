using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngaCode.Domain.Entities
{
    public class Collaborators : BaseEntity
    {
        public Collaborators()
        {
            
        }
        public Collaborators(string userName, Users users)
        {
            this.Name = userName;
            this.Users = users;

        }
        public Guid UserId { get; set; }
        public Users Users { get; set; }
        public string Name { get; set; }
        public List<TimeTrackers> TimeTracks { get; set; }
    }
}
