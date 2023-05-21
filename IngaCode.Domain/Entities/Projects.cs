using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngaCode.Domain.Entities
{
    public class Projects : BaseEntity
    {
        public string Name { get; set; }
        public List<Tasks> Tasks { get; set; }


        public void Update(string name)
        {
            Name = name;
        }
    }
}
